namespace Disaheim
{
    public class ValuableRepository : IPersistable
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

        public void Save()
        {
            string fileName = "ValuableRepository.txt";
            // Check if file already exists. If yes, delete it.
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
            // Create a new file
            using (FileStream fs = File.Create(fileName))
            using (StreamWriter sw = new StreamWriter(fs))
            {
                foreach (var valuable in valuables)
                {
                    string s = $"{valuable.GetType().Name};{valuable.ToString()}";
                    sw.WriteLine($"{valuable.GetType().Name};{valuable.ToString()}");
                }
            }
        }

        public void Save(string fileName)
        {
            // Check if file already exists. If yes, delete it.
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
            // Create a new file
            using (FileStream fs = File.Create(fileName))
            using (StreamWriter sw = new StreamWriter(fs))
            {
                foreach (var valuable in valuables)
                {
                    sw.WriteLine($"{valuable.GetType().Name};{valuable.ToString()}");
                }
            }
        }

        public void Load()
        {
            string fileName = "ValuableRepository.txt";
            using (StreamReader sr = new StreamReader(fileName))
            {
                List<string> values = new List<string>();

                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] parts = line.Split(';');
                    if (parts.Length > 1)
                    {
                        string type = parts[0];
                        string[] properties = parts.Skip(1).ToArray();
                        IValuable valuable = CreateValuableObject(type, properties);
                        if (valuable != null)
                        {
                            valuables.Add(valuable);
                        }
                    }
                }
            }
        }

        public void Load(string fileName)
        {
            using (StreamReader sr = new StreamReader(fileName))
            {
                List<string> values = new List<string>();
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] parts = line.Split(';');
                    if (parts.Length > 1)
                    {
                        string type = parts[0];
                        string[] properties = parts.Skip(1).ToArray();
                        IValuable valuable = CreateValuableObject(type, properties);
                        if (valuable != null)
                        {
                            valuables.Add(valuable);
                        }
                    }
                }
            }
        }
        private IValuable CreateValuableObject(string type, string[] properties)
        {
            if (type == "Book" && properties.Length == 4)
            {
                return new Book
                {
                    ItemId = properties[1],
                    Title = properties[2],
                    Price = double.TryParse(properties[3], out double price) ? price : 0
                };
            }
            else if (type == "Amulet" && properties.Length == 4)
            {
                return new Amulet
                {
                    ItemId = properties[1],
                    Design = properties[2],
                    Quality = Enum.TryParse<Level>(properties[3], true, out Level quality) ? quality : Level.medium
                };
            }
            else if (type == "Course" && properties.Length == 3)
            {
                return new Course
                {
                    Name = properties[1],
                    DurationInMinutes = double.TryParse(properties[2], out double duration) ? duration : 0
                };
            }
            // Add other types as needed

            return null;
        }
    }
}