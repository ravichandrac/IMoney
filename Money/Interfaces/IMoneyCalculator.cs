using System.Collections.Generic;
namespace MoneySpace
{
    interface IMoneyCalculator
    {
        IMoney Max(IEnumerable<IMoney> monies);
        IEnumerable<IMoney> SumPerCurrency(IEnumerable<IMoney> monies);
    }
}