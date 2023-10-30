using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disaheim
{
    public abstract class Merchandise
    {
        public string ItemId;
        
        //public Merchandise(string itemId) 
        //{ 
        //    ItemId = itemId;
        //}
        public override string ToString()
        {
            return $"ItemId: {ItemId}";
        }

    }
}
