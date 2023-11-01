    using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disaheim
{
    public class Course : IValuable
    {
        public string Name;
        public double DurationInMinutes;

        public Course(string name)
        { 
            this.Name = name; 
        }
        public Course(string name, int durationInMinutes) 
        {
            Name = name;
            DurationInMinutes = durationInMinutes;
        }
        public static double CourseHourValue = 875;
        public override string ToString()
        {
            return $"Name: {Name}, Duration in Minutes: {DurationInMinutes}, Value: {GetValue()}";
        }
        public double GetValue()
        {
            int hours = (int)Math.Round(DurationInMinutes / 60);
            return CourseHourValue * hours;
        }

    }
}
