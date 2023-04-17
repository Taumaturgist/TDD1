namespace NUnitLearningProject
{
    public class Pair
    {
        public string From;
        public string To;

        public Pair(string from, string to)
        {
            From = from;
            To = to;
        }

        public bool IsEqual(object obj)
        {
            Pair pair = (Pair)obj;
            return From == pair.From && To == pair.To;
        }

        public int GetHash()
        {
            return 0;
        }
    }
}
