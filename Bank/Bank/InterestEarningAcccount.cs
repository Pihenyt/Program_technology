using System;

namespace Bank;

/// <summary>
/// Накопительный счет с дополнительным процентом на остаток.
/// </summary>
public class InterestEarningAccount : BankAccount
{
    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="InterestEarningAccount"/>.
    /// </summary>
    /// <param name="name">Имя владельца счета.</param>
    /// <param name="initialBalance">Начальный баланс счета.</param>
    /// <param name="status">Статус клиента.</param>
    public InterestEarningAccount(string name, decimal initialBalance, CustomerStatus status = CustomerStatus.Regular)
        : base(name, initialBalance, status) { }

    /// <summary>
    /// Выполняет ежемесячные процедуры счета и дополнительно начисляет 2% на остаток свыше 500 рублей.
    /// </summary>
    public override void PerformMonthAndTransactions()
    {
        base.PerformMonthAndTransactions();

        if (Balance > 500m)
        {
            decimal interest = Balance * 0.02m;
            MakeDeposit(interest, DateTime.UtcNow, "Apply month interest");
        }
    }
}