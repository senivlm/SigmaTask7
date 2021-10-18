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




            Console.WriteLine("\nEnter to end");
            Console.ReadLine();
        }
    }
}
