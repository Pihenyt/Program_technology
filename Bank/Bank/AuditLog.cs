using System;
using System.Collections.Generic;

namespace Bank;

/// <summary>
/// Журнал аудита для записи всех финансовых операций в системе.
/// </summary>
public static class AuditLog
{
    private static readonly List<string> s_entries = new();

    /// <summary>
    /// Записывает новую операцию в журнал аудита.
    /// </summary>
    /// <param name="accountNumber">Номер счета, по которому проведена операция.</param>
    /// <param name="operationType">Тип операции (Deposit, Withdrawal, Interest, Fee, Cashback).</param>
    /// <param name="amount">Сумма операции.</param>
    /// <param name="date">Дата и время выполнения операции.</param>
    public static void Record(string accountNumber, string operationType, decimal amount, DateTime date)
    {
        string logMessage = $"[{date:yyyy-MM-dd HH:mm:ss}] Счет #{accountNumber} | Операция: {operationType} | Сумма: {amount} руб.";
        s_entries.Add(logMessage);
        Console.WriteLine($"[AUDIT] {logMessage}");
    }

    /// <summary>
    /// Возвращает список всех записанных событий аудита.
    /// </summary>

    public static IReadOnlyList<string> GetEntries() => s_entries.AsReadOnly();
}