using System;
using System.Collections.Generic;
using System.Text;

namespace Bank;

/// <summary>
/// Базовый класс банковского счета, управляющий балансом, транзакциями и статусом клиента.
/// </summary>
public class BankAccount
{
    private static int s_accountNumberSeed = 1000000000;
    private readonly List<Transaction> _allTransactions = new();

    /// <summary>
    /// Уникальный номер счета.
    /// </summary>
    public string Number { get; }

    /// <summary>
    /// Имя владельца счета.
    /// </summary>
    public string Owner { get; private set; }

    /// <summary>
    /// Текущий баланс счета, рассчитываемый как сумма всех проведенных транзакций.
    /// </summary>
    public decimal Balance
    {
        get
        {
            decimal balance = 0;
            foreach (var item in _allTransactions)
            {
                balance += item.Amount;
            }
            return balance;
        }
    }

    /// <summary>
    /// Статус клиента для расчета комиссий и специальных условий.
    /// </summary>
    public CustomerStatus Status { get; set; }

    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="BankAccount"/>.
    /// </summary>
    /// <param name="name">Имя владельца счета.</param>
    /// <param name="initialBalance">Начальный баланс счета.</param>
    /// <param name="status">Статус клиента (по умолчанию Regular).</param>
    public BankAccount(string name, decimal initialBalance, CustomerStatus status = CustomerStatus.Regular)
    {
        Owner = name;
        Status = status;
        Number = s_accountNumberSeed.ToString();
        s_accountNumberSeed++;

        MakeDeposit(initialBalance, DateTime.UtcNow, "Initial balance");
    }

    /// <summary>
    /// Пополняет счет на указанную сумму и записывает событие в журнал аудита.
    /// </summary>
    /// <param name="amount">Сумма пополнения. Должна быть строго больше нуля.</param>
    /// <param name="date">Дата и время операции.</param>
    /// <param name="note">Комментарий к операции.</param>
    /// <exception cref="ArgumentOutOfRangeException">Выбрасывается, если <paramref name="amount"/> меньше или равен нулю.</exception>
    public void MakeDeposit(decimal amount, DateTime date, string note)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
        }

        var deposit = new Transaction(amount, date, note);
        _allTransactions.Add(deposit);

        // Задача 2: Вызов аудита
        AuditLog.Record(Number, "Deposit", amount, date);
    }

    /// <summary>
    /// Списывает средства со счета, проверяет лимиты баланса, начисляют кэшбэк для VIP и записывает операцию в аудит.
    /// </summary>
    /// <param name="amount">Сумма списания. Должна быть строго больше нуля.</param>
    /// <param name="date">Дата и время операции.</param>
    /// <param name="note">Комментарий к операции.</param>
    /// <exception cref="ArgumentOutOfRangeException">Выбрасывается, если <paramref name="amount"/> меньше или равен нулю.</exception>
    /// <exception cref="InvalidOperationException">Выбрасывается при недостаточном количестве средств на счете.</exception>
    public void MakeWithdrawal(decimal amount, DateTime date, string note)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
        }

        if (Balance < amount)
        {
            throw new InvalidOperationException("Not sufficient rubles for this withdrawal");
        }

        var withdrawal = new Transaction(-amount, date, note);
        _allTransactions.Add(withdrawal);

        // Задача 2: Вызов аудита
        AuditLog.Record(Number, "Withdrawal", amount, date);

        // Задача 1: Кэшбэк 5% для VIP-клиентов
        if (Status == CustomerStatus.VIP)
        {
            decimal cashback = amount * 0.05m;
            MakeDeposit(cashback, date, "VIP 5% Cashback");
        }
    }

    /// <summary>
    /// Формирует текстовый отчет со списком всех транзакций и промежуточным балансом.
    /// </summary>
    /// <returns>Строка с форматированной таблицей транзакций.</returns>
    public string GetAccountHistory()
    {
        var report = new StringBuilder();
        decimal balance = 0;
        report.AppendLine("Date\t\tAmount\tBalance\tNote");
        foreach (var item in _allTransactions)
        {
            balance += item.Amount;
            report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t{balance}\t{item.Note}");
        }
        return report.ToString();
    }

    /// <summary>
    /// Выполняет ежемесячные процедуры счета: списывает комиссию за обслуживание и начисляет проценты согласно статусу.
    /// </summary>
    public virtual void PerformMonthAndTransactions()
    {
        // Задача 1: Комиссии и проценты по статусам
        if (Status == CustomerStatus.Regular)
        {
            MakeWithdrawal(50m, DateTime.UtcNow, "Monthly service fee");
        }
        else if (Status == CustomerStatus.Premium || Status == CustomerStatus.VIP)
        {
            if (Balance > 10000m)
            {
                decimal rate = Status == CustomerStatus.Premium ? 0.01m : 0.03m;
                decimal interest = (Balance - 10000m) * rate;
                MakeDeposit(interest, DateTime.UtcNow, $"{Status} monthly interest");
            }
        }
    }

    /// <summary>
    /// Возвращает текстовую информацию об экземпляре счета.
    /// </summary>
    /// <returns>Форматированная строка с типом, владельцем, номером и балансом.</returns>
    public override string ToString()
        => $"Type:{GetType().Name}\tOwner:{Owner}\tNumber of account:{Number}\tBalance:{Balance}";
}