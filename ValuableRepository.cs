using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Disaheim
{
    public class ValuableRepository
    {
        private List<IValuable> valuables = new List<IValuable>();

        public void AddValuable(IValuable valuable)
        {
            valuables.Add(valuable);
        }
        public IValuable GetValuable(string id)
        {
            foreach (IValuable v in valuables)
            {
                if (v is Merchandise merchandise && merchandise.ItemId == id)
                {
                    return (IValuable)merchandise;
                }
                else if (v is Course course && course.Name == id)
                {
                    return (IValuable)course;
                }
            }
            return null;
        }
        public double GetTotalValue()
        {
            double totalValue = 0;

            foreach (IValuable valuable in valuables)
            {
                totalValue += valuable.GetValue();
            }
            return totalValue;
        }
        public int Count()
        {
            return valuables.Count();
        }
    }
}
