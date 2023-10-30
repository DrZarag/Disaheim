    using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disaheim
{
    public class Course
    {
        public string Name;
        public int DurationInMinutes;

        public Course(string name)
        { 
            this.Name = name; 
        }
        public Course(string name, int durationInMinutes) 
        {
            this.Name = name;
            this.DurationInMinutes = durationInMinutes;
        }
        public override string ToString()
        {
            return $"Name: {Name}, Duration in Minutes: {DurationInMinutes}";
        }

    }
}
