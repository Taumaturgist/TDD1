using Newtonsoft.Json;
using NUnit.Framework;

namespace NUnitLearningProject
{
    public class Tests
    {     
        [Test]
        public void TestSumTimes()
        {
            Expression fiveBucks = Money.Dollar(5);
            Expression tenFrancs = Money.Franc(10);
            Bank bank = new Bank();
            bank.AddRate("CHF", "USD", 2);
            Expression sum = new Sum(fiveBucks, tenFrancs).Times(2);
            Money result = bank.Reduce(sum, "USD");
            Assert.AreEqual(
                JsonConvert.SerializeObject(Money.Dollar(20)),
                JsonConvert.SerializeObject(result)
                );
        }

        [Test]
        public void TestSumPlusMoney()
        {
            Expression fiveBucks = Money.Dollar(5);
            Expression tenFrancs = Money.Franc(10);
            Bank bank = new Bank();
            bank.AddRate("CHF", "USD", 2);
            Expression sum = new Sum(fiveBucks, tenFrancs).Plus(fiveBucks);
            Money result = bank.Reduce(sum, "USD");
            Assert.AreEqual(
                JsonConvert.SerializeObject(Money.Dollar(15)),
                JsonConvert.SerializeObject(result)
                );

        }

        [Test]
        public void TestMixedAddition()
        {
            Expression fiveBucks = Money.Dollar(5);
            Expression tenFrancs = Money.Franc(10);
            Bank bank = new Bank();
            bank.AddRate("CHF", "USD", 2);
            Money result = bank.Reduce(fiveBucks.Plus(tenFrancs), "USD");
            Assert.AreEqual(
                JsonConvert.SerializeObject(Money.Dollar(10)),
                JsonConvert.SerializeObject(result)
                );
        }

        [Test]
        public void TestIdentityRate()
        {
            Assert.AreEqual(
                1,
                new Bank().Rate("USD", "USD"));
        }

        [Test]
        public void TestReduceMoneyDifferentCurrency()
        {
            Bank bank = new Bank();
            bank.AddRate("CHF", "USD", 2);
            Money result = bank.Reduce(Money.Franc(2), "USD");
            Assert.AreEqual(
                JsonConvert.SerializeObject(Money.Dollar(1)),
                JsonConvert.SerializeObject(result)
                );
        }

        [Test]
        public void TestReduceMoney()
        {
            Bank bank = new Bank();
            Money result = bank.Reduce(Money.Dollar(1), "USD");
            Assert.AreEqual(
                JsonConvert.SerializeObject(Money.Dollar(1)),
                JsonConvert.SerializeObject(result)
                );
        }

        [Test]
        public void TestReduceSum()
        {
            Expression sum = new Sum(Money.Dollar(3), Money.Dollar(4));
            Bank bank = new Bank();
            Money result = bank.Reduce(sum, "USD");
            Assert.AreEqual(
                JsonConvert.SerializeObject(Money.Dollar(7)),
                JsonConvert.SerializeObject(result)
                );
        }

        [Test]
        public void TestPlusReturnsSum()
        {
            Money five = Money.Dollar(5);
            Expression result = five.Plus(five);
            Sum sum = (Sum)result;
            Assert.AreEqual(
                JsonConvert.SerializeObject(five),
                JsonConvert.SerializeObject(sum.Augend)
                );
            Assert.AreEqual(
                JsonConvert.SerializeObject(five),
                JsonConvert.SerializeObject(sum.Addend)
                );
        }

        [Test]
        public void TestSimpleAddition()
        {
            Money five = Money.Dollar(5);
            Expression sum = five.Plus(five);
            Bank bank = new Bank();
            Money reduced = bank.Reduce(sum, "USD");
            Assert.AreEqual(
                JsonConvert.SerializeObject(reduced),
                JsonConvert.SerializeObject(Money.Dollar(10))
            );
        }

        [Test]
        public void TestCurrency()
        {
            Assert.AreEqual("USD", Money.Dollar(1).GetCurrency());
            Assert.AreEqual("CHF", Money.Franc(1).GetCurrency());
        }

        [Test]
        public void TestEquality()
        {
            Assert.True(Money.Dollar(5).IsEqual(Money.Dollar(5)));
            Assert.False(Money.Dollar(5).IsEqual(Money.Dollar(6)));           
            Assert.False(Money.Franc(5).IsEqual(Money.Dollar(5)));
        }

        [Test]
        public void TestMultiplication()
        {
            Money five = Money.Dollar(5);
            Assert.AreEqual(
                JsonConvert.SerializeObject(five.Times(2)), 
                JsonConvert.SerializeObject(Money.Dollar(10)));
            Assert.AreEqual(
                JsonConvert.SerializeObject(five.Times(3)), 
                JsonConvert.SerializeObject(Money.Dollar(15)));
        }
    }
}