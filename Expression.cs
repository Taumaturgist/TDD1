namespace NUnitLearningProject
{
    public interface Expression
    {
        public Money Reduce(Bank bank, string to);
    }
}
