using System;

namespace Bank;

/// <summary>
/// Представляет неизменяемую запись о проведенной транзакции на счете.
/// </summary>
/// <param name="Amount">Сумма транзакции (положительная при зачислении, отрицательная при списании).</param>
/// <param name="Date">Дата и время совершения транзакции.</param>
/// <param name="Note">Описание или комментарий к транзакции.</param>
public record Transaction(decimal Amount, DateTime Date, string Note);