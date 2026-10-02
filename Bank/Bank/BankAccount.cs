using System.Text;

namespace Bank;

// Bank account - потомок классa object => можно переопределить
// вирутальные методы, находящиеся в object

public class BankAccount
{
    private List<Transaction> _allTransactions = new List<Transaction>();
    public string Owner { get; private set; }
    public string Number { get; }
    public decimal Balance
    {
        get
        {
            decimal balance = 0;
            foreach (var transaction in _allTransactions)
            {
                balance += transaction.Amount;
            }
            return balance;
        }
    }
    private static int s_accountNumberSeed = 1000000000;
    public BankAccount(string name, decimal initialBalance)
    {

        MakeDeposite(initialBalance, DateTime.UtcNow, "initial balance"); // this.Balance = initialBalance;
        Owner = name;
        Number = s_accountNumberSeed.ToString();
        s_accountNumberSeed++;
    }

    public void MakeDeposite(decimal amout, DateTime date, string note)
    {
        if (amout <= 0)
        {
            throw new ArgumentOutOfRangeException
                    (nameof(amout), "Amount of deposite must be positive");
        }

        var deposite = new Transaction(amout, date, note);
        _allTransactions.Add(deposite);
    }

    public void MakeWithdrawal(decimal amout, DateTime date, string note)
    {
        if (amout <= 0)
        {
            throw new ArgumentOutOfRangeException
                    (nameof(amout), "Amount of withdrawal must be positive");
        }
        if (Balance < amout)
        {
            throw new InvalidOperationException
                    ("Not sufficient money for this withdrawal");
        }

        var withdrawal = new Transaction(-amout, date, note);
        _allTransactions.Add(withdrawal);
    }

    public string GetAccountHistory()
    {
        var report = new StringBuilder();

        decimal balance = 0;
        report.AppendLine("Data\t\tAmount\tBalance\tNote");
        foreach (var item in _allTransactions)
        {
            balance += item.Amount;
            report.AppendLine($"" +
                $"{item.Date.ToShortDateString()}\t" +
                $"{item.Amount}\t{balance}\t{item.Note}");
        }
        return report.ToString();
    }

    // Ключевое слово Virtual позволяет в дочернем классе
    // предоставить другую реализацию
    // метода PerformMonthAndTransactions
    public virtual void PerformMonthAndTransactions()
    {

    }
    // переопределяем метод, который унаследовали от object
    // этот метод должен возвращать строку с состоянием объекта
    //public override string ToString()
    //{
    //    return $"Type:{GetType().Name}\t" +
    //        $"Owner: {Owner}\t" +
    //        $"Number of acccount:{Number}\t" +
    //        $"Balance: {Balance}";

    //}
    public override string ToString()
        => $"type: {GetType().Name}\t" +
        $"Owner: {Owner}\t" +
        $"Number of account: {Number}\t" +
        $"Balance: {Balance}";
}
