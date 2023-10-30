using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disaheim
{
    public class CourseRepository
    {
        private List<Course> courses = new List<Course>();

        public void AddCourse(Course course)
        {
            courses.Add(course);
        }
        public Course GetCourse(string name)
        {
            Course course  = null;
            foreach (Course c in courses)
            {
                if (c.Name == name)
                {
                    course = c;
                    break;
                }
            }
            return course;
        }
        public double GetTotalValue()
        {
            Utility utility = new();
            double total = 0.00;
            foreach (Course c in courses)
            {
                total += utility.GetValueOfCourse(c);
            }
            return total;
        }   
    }
}
