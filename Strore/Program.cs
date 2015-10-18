using System.Collections.Generic;
using System.Linq;

namespace Strore
{
    class Program
    {
        static void Main(string[] args)
        {

        }        
    }

    public class Sell
    {
        public List<int> GetPriceSum(List<int> costs, int numberOfGroup)
        {
            var result = new List<int>();

            if (numberOfGroup < 0) numberOfGroup = 1;

            var group = costs.Count % numberOfGroup == 0 ?
                costs.Count / numberOfGroup : costs.Count / numberOfGroup + 1;

            for (int i = 0; i < group; i++)
            {
                int total;
                if (costs.Count >= numberOfGroup)
                {
                    total = costs.Take(numberOfGroup).Sum();
                    result.Add(total);
                }
                else
                {
                    total = costs.Sum();
                    result.Add(total);
                    break;
                }

                costs.RemoveRange(0, numberOfGroup);
            }

            return result;
        }
    }
}
