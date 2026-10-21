using System;

namespace Bank;

/// <summary>
/// Подарочный счет с фиксированным первоначальным балансом.
/// </summary>
public class GiftCardAccount : BankAccount
{
    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="GiftCardAccount"/>.
    /// </summary>
    /// <param name="name">Имя владельца подарочной карты.</param>
    /// <param name="initialBalance">Сумма подарочного сертификата.</param>
    public GiftCardAccount(string name, decimal initialBalance)
        : base(name, initialBalance, CustomerStatus.Regular) { }
}