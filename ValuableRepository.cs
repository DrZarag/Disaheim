using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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
                    sw.WriteLine($"{valuable.GetType().Name};{valuable.ToString}");
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
                    sw.WriteLine($"{valuable.GetType().Name};{valuable.ToString}");
                }
            }
        }

        public void Load()
        {
            string fileName = "ValuableRepository.txt";
            using (StreamReader sr = new StreamReader(fileName))
            {
                List<string> values = new List<string>();
                string aa = sr.Read();
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
            if (type == "Book" && properties.Length == 3)
            {
                return new Book
                {
                    ItemId = properties[0],
                    Title = properties[1],
                    Price = double.TryParse(properties[2], out double price) ? price : 0
                };
            }
            else if (type == "Amulet" && properties.Length == 2)
            {
                return new Amulet
                {
                    Design = properties[0],
                    Quality = Enum.TryParse<Level>(properties[1], true, out Level quality) ? quality : Level.medium
                };
            }
            // Add other types as needed

            return null;
        }
    }
}
