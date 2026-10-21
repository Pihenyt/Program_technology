using System;

namespace Bank;

/// <summary>
/// Кредитный счет с возможностью ухода в отрицательный баланс.
/// </summary>
public class LineOfCreditAccount : BankAccount
{
    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="LineOfCreditAccount"/>.
    /// </summary>
    /// <param name="name">Имя заемщика.</param>
    /// <param name="initialBalance">Начальный баланс счета.</param>
    public LineOfCreditAccount(string name, decimal initialBalance)
        : base(name, initialBalance, CustomerStatus.Regular) { }
}