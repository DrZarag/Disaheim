using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disaheim
{
    public class AmuletRepository
    {
        private List<Amulet> amulets = new List<Amulet>();

        public void AddAmulet(Amulet amulet)
        {
            amulets.Add(amulet);
        }
        public Amulet GetAmulet(string itemId)
        {
            Amulet amulet = null;
            foreach (Amulet a in amulets)
            {
                if (a.ItemId == itemId)
                {
                    amulet = a;
                    break;
                }
            }
            return amulet;
        }
        public double GetTotalValue()
        {
            Utility utility = new();
            double total = 0.00;
            foreach (Amulet a in amulets)
            {
                total += utility.GetValueOfAmulet(a);
            }
            return total;
        }
    }
}
