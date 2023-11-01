namespace Disaheim
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            ValuableRepository valuableRepository = new ValuableRepository();
            Book book1 = new Book("B1", "The Great Gatsby", 10.99);
            Book book2 = new Book("B2", "To Kill a Mockingbird", 7.99);
            Book book3 = new Book("B3", "1984", 8.99);
            Book book4 = new Book("B4", "The Catcher in the Rye", 9.99);

            valuableRepository.AddValuable(book1);
            valuableRepository.AddValuable(book2);
            valuableRepository.AddValuable(book3);
            valuableRepository.AddValuable(book4);
            valuableRepository.Save();
            ValuableRepository loadedRepo = new ValuableRepository();
            loadedRepo.Load();
        }
    }
}