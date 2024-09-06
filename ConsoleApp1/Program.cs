using System.Text;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            StringBuilder stringBuilder = new();

            for (int i = 0; i < 100; i++)
            {
                stringBuilder.Append(i.ToString());
            }

            Console.WriteLine(stringBuilder.ToString());

            Console.ReadLine();
        }
    }
}
