namespace Disaheim
{
    public class Course : IValuable
    {
        public string Name;
        public double DurationInMinutes;

        public Course()
        {

        }
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
            return $"Course;{Name};{DurationInMinutes}";
        }
        public double GetValue()
        {
            int hours = (int)Math.Round(DurationInMinutes / 60);
            return CourseHourValue * hours;
        }

    }
}
