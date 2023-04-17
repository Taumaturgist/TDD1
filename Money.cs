namespace NUnitLearningProject
{
    public class Money : Expression
    {
        public int Amount;
        protected string Currency;
        
        public Money Reduce(Bank bank, string to)
        {
            int rate = bank.Rate(GetCurrency(), to);
            return new Money(Amount / rate, to);
        }

        public Expression Plus(Money addend)
        {
            return new Sum(this, addend);
        }

        public Money Times(int multiplier)
        {
            return new Money(Amount * multiplier, Currency);
        }

        public Money(int amount, string currency)
        {
            Amount = amount;
            Currency = currency;
        }
        public string GetCurrency()
        {
            return Currency;
        }
        public bool IsEqual(object obj)
        {
            Money money = (Money)obj;
            return money.Amount == Amount
                && GetCurrency() == money.GetCurrency();
        }
        static public Money Dollar(int amount)
        {
            return new Money(amount, "USD");
        }

        static public Money Franc(int amount)
        {
            return new Money(amount, "CHF");
        }
    }
}
