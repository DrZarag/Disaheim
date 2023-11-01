using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Disaheim
{
    public class Utility
    {
        public double LowQualityValue { get; set; } = 12.5;
        public double MediumQualityValue { get; set; } = 20.0;
        public double HighQualityValue { get; set; } = 27.5;
        public double CourseHourValue { get; set; } = 875.0;

        public double GetValueOfBook(Book book)
        {
            return book.Price;
        }
        public double GetValueOfAmulet(Amulet amulet)
        {
            double price = 0;
            switch (amulet.Quality)
            {
                case Level.low:
                    return 12.5;
                    break;
                case Level.medium:
                    return 20.0;
                    break;
                case Level.high:
                    return 27.5;
                    break;
            }
            return price;
        }
        public double GetValueOfCourse(Course course) 
        {
            double value = course.DurationInMinutes / 60;
            double rest = course.DurationInMinutes % 60;
            
            if (rest > 0 )
            {
                value++;
            }
            return value * 875;
        }
        public double GetValueOfMerchandise(Merchandise merchandise)
        {
            if (merchandise is Book book)
            {
                return book.Price;
            }
            else if (merchandise is Amulet amulet)
            {
                switch (amulet.Quality)
                {
                    case Level.low:
                        return LowQualityValue;
                        break;
                    case Level.medium:
                        return MediumQualityValue;
                        break;
                    case Level.high:
                        return HighQualityValue;
                        break;
                    default:
                        return 0;
                        break;
                }
            }
            else { return 0; }
        }
    }
}
