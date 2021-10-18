using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SigmaTask7.Task2
{
    class Dishes
    {
        //матиме два словника
        //назва страви, і словник по продуктам і їхнім вагам
        Dictionary<string, Dictionary<string, double>> menu;
        Dictionary<string, double> priceList; 

        public Dishes(string pricePath ="N/A", string dishesPath = "N/A")
        {
            menu = new Dictionary<string, Dictionary<string, double>>();
            priceList = new Dictionary<string, double>();
            ReadPricesFromFile(pricePath);
            ReadDishesFromFile(dishesPath);
        }

        public void ReadPricesFromFile(string path)
        {
            try
            {
                if (File.Exists(path))
                {
                    using (StreamReader reader = new StreamReader(path))
                    {
                        //зчитуємо вид продутку і ціну
                        string line;
                        while ((line = reader.ReadLine())!= null)
                        {
                            string[] splitLine = line.Split();
                            if (splitLine.Length != 2)
                                throw new ArgumentException("Wrong input info");
                            double priceOfProduct;
                            if (!Double.TryParse(splitLine[0], out priceOfProduct) || (priceOfProduct <= 0))
                                throw new ArgumentException("Wrong Price of product");
                            //добавляємо
                            priceList[splitLine[0]] = priceOfProduct;
                        }
                    }    
                }
                else throw new FileNotFoundException("File not found");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

        public void ReadDishesFromFile(string path)
        {
            try
            {
                if (File.Exists(path))
                {
                    using (StreamReader reader = new StreamReader(path))
                    {
                        string line;
                        while((line = reader.ReadLine())!=null)
                        {
                            //якщо не букви, то протустити
                            if (!Char.IsLetter(line[0]))
                                continue;

                            string[] lineSplit = line.Split();

                            //тимчасові змінні
                            string dishName;
                            KeyValuePair<string, double> temp;
                            //якщо одне слово - це страва
                            //запам'ятовуємо її
                            if(lineSplit.Length == 1)
                            {
                                dishName = lineSplit[0];
                            }
                            //ідуть пари для продуктів і ваги
                            if (lineSplit.Length == 2)
                            {
                                double weight;
                            }
                            else
                                throw new ArgumentException("Wrong input data");
                        }
                    }
                }
                else throw new FileNotFoundException("File not found");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

    }
}
