using System;
using System.Collections.Generic;
using System.Linq;

namespace MoneySpace
{
    class Money : IMoney
    {
        public decimal Amount { get; }
        public string Currency { get; }

        public Money(string c, decimal d)
        {
            Amount = d;
            Currency = c;
        }
    }

    class MoneyCalculator : IMoneyCalculator
    {
        public IEnumerable<IMoney> SumPerCurrency(IEnumerable<IMoney> monies)
        {
            var result = (from p in monies.AsEnumerable()
                          group p by p.Currency into r
                          select new Money (r.Key,
                              r.Sum((s) => s.Amount)
                          )).ToList();
            
            return result;
        }

        public IMoney Max(IEnumerable<IMoney> monies)
        {
            try
            {
                var val = monies.First().Currency;

                if (monies.All(x=>x.Currency == val))
                    return new Money(val, monies.Max(x => x.Amount));
                else
                    throw new Exception("Cannot find Max instance as Currencies are different!");
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}

