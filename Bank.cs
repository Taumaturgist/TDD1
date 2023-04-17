using System.Collections;
using Newtonsoft.Json;

namespace NUnitLearningProject
{
    public class Bank
    {
        private Hashtable ratesHash = new Hashtable();
        public Money Reduce(Expression source, string to)
        {
            return source.Reduce(this, to);
        }

        public int Rate(string from, string to)
        {
            if (from == to)
            {
                return 1;
            }

            int rate = (int)ratesHash[JsonConvert.SerializeObject(new Pair(from, to))];
            return rate;
        }

        public void AddRate(string from, string to, int rate)
        {
            ratesHash.Add(JsonConvert.SerializeObject(new Pair(from, to)), rate);
        }
    }
}
