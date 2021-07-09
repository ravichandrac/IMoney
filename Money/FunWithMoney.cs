using System;
using System.Collections.Generic;
using System.Linq;

namespace MoneySpace
{
    class FunWithMoney
    {
        static int objSize = 6;

        public Money[] CreateMoneyObjs(String objs)
        {
            Money[] money = new Money[objSize];

            var obj = objs.Replace("{", "").Replace("}", "").Split(',');

            //var obj = objs.Split(',');
            int index = 0;
            foreach (string str in obj)
            {
                string s = str.Trim();
                money[index] = new Money(s.ToString().Substring(0, 3), decimal.Parse(s.ToString().Substring(3, s.Length - 3)));
                index++;
            }
            return money;
        }

        public static void Main(string[] args)
        {
            MoneyCalculator mc = new MoneyCalculator();
            FunWithMoney f = new FunWithMoney(); ;
            Money[] money = new Money[objSize];

            //--------------------------------------------------------------------
            Console.WriteLine("Test 1");
            money = f.CreateMoneyObjs("{GBP10, GBP20, GBP50,USD10,GBP10,EUR20}");
            IEnumerable<IMoney> arrMoney = money;

            //Find Max instance
            var moneyVar = mc.Max(arrMoney);
            if (moneyVar != null)
                Console.WriteLine("Max Currency instance is {" + moneyVar.Currency + moneyVar.Amount + "}");

            //Sum of similar currencies
            var spc = mc.SumPerCurrency(arrMoney);

            f.DisplayAggregateResults(spc);

            //--------------------------------------------------------------------
            Console.WriteLine("Test 2");
            objSize = 5;
            Money[] money2 = new Money[objSize];

            money2 = f.CreateMoneyObjs("{GBP10, GBP20, GBP30,GBP90,GBP10}");
            arrMoney = money2;

            //Find Max instance
            moneyVar = mc.Max(arrMoney);
            if (moneyVar != null)
                Console.WriteLine("Max Currency instance is {" + moneyVar.Currency + moneyVar.Amount + "}");

            //Sum of similar currencies
            spc = mc.SumPerCurrency(arrMoney);

            f.DisplayAggregateResults(spc);

            Console.ReadLine();
        }

        public void DisplayAggregateResults(IEnumerable<IMoney> spc)
        {
            Console.WriteLine("Aggregated Totals per Currency:");
            for (int i = 0; i < spc.Count(); i++)
                Console.WriteLine("{" + spc.ElementAt(i).Currency + spc.ElementAt(i).Amount + "}");
        }

    }
}

