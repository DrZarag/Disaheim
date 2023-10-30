using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Disaheim
{
    public class MerchandiseRepository
    {
        private List<Merchandise> merchandises = new List<Merchandise>();

        public void AddMerchandise(Merchandise merchandise)
        {
            merchandises.Add(merchandise);
        }
        public Merchandise GetMerchandise(string itemId)
        {
            Merchandise merchandise = null;
            foreach (Merchandise m in merchandises)
            {
                if (m.ItemId == itemId)
                {
                    merchandise = m;
                    break;
                }
            }
            return merchandise;
        }
        public double GetTotalValue()
        {
            double total = 0;
            Utility utility = new Utility();
            foreach (Merchandise m in merchandises)
            {
                total += utility.GetValueOfMerchandise(m);
            }
            return total;
        }
    }
}
