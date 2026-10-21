using System;

namespace Bank;

/// <summary>
/// Сервис для проведения операций перевода между счетами.
/// </summary>
public static class TransferService
{
    /// <summary>
    /// Переводит указанную сумму денег с одного счета на другой.
    /// </summary>
    /// <param name="source">Счет-отправитель.</param>
    /// <param name="destination">Счет-получатель.</param>
    /// <param name="amount">Сумма перевода.</param>
    /// <param name="date">Дата совершения перевода.</param>
    /// <exception cref="ArgumentNullException">Выбрасывается, если один из счетов равен null.</exception>
    public static void Transfer(BankAccount source, BankAccount destination, decimal amount, DateTime date)
    {
        if (source == null || destination == null)
        {
            throw new ArgumentNullException("Accounts cannot be null");
        }

        source.MakeWithdrawal(amount, date, $"Transfer to account #{destination.Number}");

        try
        {
            destination.MakeDeposit(amount, date, $"Transfer from account #{source.Number}");
        }

        catch (Exception)
        {
            // Откат транзакции списания при ошибке пополнения
            source.MakeDeposit(amount, date, $"Rollback transfer to #{destination.Number}");
            throw;
        }
    }
}