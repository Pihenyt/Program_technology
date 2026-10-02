namespace Bank
{
    public class InterestEarningAcccount : BankAccount
    {
        public InterestEarningAcccount(string name, decimal initialBalance): base(name, initialBalance) 
        {
        }
        public override void PerformMonthAndTransactions()
        {
            if (Balance > 500)
            {
                decimal interest = Balance * 0.2m;
                MakeDeposite(interest, DateTime.UtcNow, "Apply month interest");
            }
        }
    }
}
