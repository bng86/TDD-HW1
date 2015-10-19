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

    public class Product
    {
        public int Id { get; set; }
        public int Cost { get; set; }
        public int Revenue { get; set; }
        public int SellPrice { get; set; }
    }

    public class Group
    {
        public List<int> GetGroupPriceList(List<int> items, int numberOfGroup)
        {
            var result = new List<int>();

            if (numberOfGroup < 0) numberOfGroup = 1;

            var group = items.Count % numberOfGroup == 0 ?
                items.Count / numberOfGroup : items.Count / numberOfGroup + 1;

            for (int i = 0; i < group; i++)
            {
                int total;
                if (items.Count >= numberOfGroup)
                {
                    total = items.Take(numberOfGroup).Sum();
                    result.Add(total);
                }
                else
                {
                    total = items.Sum();
                    result.Add(total);
                    break;
                }

                items.RemoveRange(0, numberOfGroup);
            }

            return result;
        }
    }
}
