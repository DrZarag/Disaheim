using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Disaheim
{
    public class Amulet : Merchandise
    {
        public string Design
        { get; set; }
        public Level Quality { get; set; } = Level.medium;
        public static double LowQualityValue = 12.5;
        public static double MediumQualityValue = 20.0;
        public static double HighQualityValue = 27.5;
        public Amulet()
        {
            
        }


        public Amulet(string itemId)
        {
            ItemId = itemId;
        }
        public Amulet(string itemId, Level quality) : this(itemId)
        {
            this.ItemId = itemId;
            this.Quality = quality;
        }
        public Amulet(string itemId, Level quality, string design) : this(itemId, quality)
        {
            this.ItemId = itemId;
            this.Quality = quality;
            this.Design = design;
        }

        public override string ToString()
        {
            return $"ItemId: {ItemId}, Quality: {Quality}, Design: {Design}";

        }
        public override double GetValue()
        {
            switch (Quality)
            {
                case Level.low:
                    return LowQualityValue;
                case Level.medium:
                    return MediumQualityValue;
                case Level.high:
                    return HighQualityValue;
                default:
                    return 0.0;
            }
        }
    }
}

