using System;
namespace lab0
{
    class Program
    {
        static void Main(string[] args)
        {
            string name;
            Console.WriteLine("Имя пользователя:");
            name = Console.ReadLine();
            Console.WriteLine("Привет, {0}", name);
        }
    }
}
