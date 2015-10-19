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


    public enum GroupField
    {
        Cost,
        Revenue
    }

    public class Group
    {
        private readonly List<Product> _products;

        public Group(List<Product> products)
        {
            _products = products;
        }

        public List<int> GetGroupPriceList(GroupField field, int numberOfGroup)
        {
            var result = new List<int>();

            if (numberOfGroup < 0) numberOfGroup = 1;

            var groupSize = CalculateGroupSize(_products.Count, numberOfGroup);

            var items = GetGroupByField(field);

            for (int i = 0; i < groupSize; i++)
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

        private int CalculateGroupSize(int total, int groupSize)
        {
            return total % groupSize == 0 ? total / groupSize : total / groupSize + 1;
        }

        private List<int> GetGroupByField(GroupField field)
        {
            List<int> result;

            switch (field)
            {
                case GroupField.Cost:
                    result = _products.Select(x => x.Cost).ToList();
                    break;
                case GroupField.Revenue:
                    result = _products.Select(x => x.Revenue).ToList();
                    break;
                default:
                    result = _products.Select(x => x.Cost).ToList();
                    break;
            }

            return result;
        }
    }
}
