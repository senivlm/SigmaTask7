using System;

namespace SigmaTask7
{
    class Program
    {
        static void Main(string[] args)
        {
            Task1.Vocabulary voc = new Task1.Vocabulary();

            string text2 = "She. Dotn e likes     ... ?  nature. I go to school.";

            Console.WriteLine("Curent text:\n{0}", text2);
            Console.WriteLine("Changed text:\n{0}", voc.ChangeText(text2));
            Console.WriteLine("\nOur vocabulary:\n {0}",voc.ToString());

            string pricePath = @"C:\Users\Acer\OneDrive\Робочий стіл\C#\SigmaTask7\Task2\Prices.txt";
            string productsPath = @"C:\Users\Acer\OneDrive\Робочий стіл\C#\SigmaTask7\Task2\Menu.txt";
            Task2.Dishes menu = new Task2.Dishes(pricePath, productsPath);

            Console.WriteLine("\n{0}",menu.ToString());

            Console.WriteLine("\nEnter to end");
            Console.ReadLine();
        }
    }
}
