namespace Bank;
/// <summary>
/// Тип данных, который запрещает менять состояние объекта
/// </summary>
/// <param name="Amount"> сумма транзакции </param>
/// <param name="Date"> дата транзации </param>
/// <param name="Note"> заметка транзакции </param>
internal record Transaction(decimal Amount, DateTime Date, string Note);

//internal record Transaction
//{
//    public decimal Amount { get; }
//    public DateTime Date { get; }
//    public string Note { get; }
//    public Transaction(decimal Amount, DateTime Date, string Note)
//    {
//        this.Amount = Amount;
//        this.Date = Date;
//        this.Note = Note;
//    }
//}