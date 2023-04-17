namespace NUnitLearningProject
{
    public class Sum : Expression
    {
        public Money Augend;
        public Money Addend;

        public Sum(Money augend, Money addend)
        {
            this.Augend = augend;
            this.Addend = addend;
        }

        public Money Reduce(Bank bank, string to)
        {
            int amount = Augend.Amount + Addend.Amount;
            return new Money(amount, to);
        }
    }
}
