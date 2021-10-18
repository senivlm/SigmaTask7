using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SigmaTask7.Task2
{А де main?
    class Dishes
    {
        //матиме два словника
        //перший зберігає продукти і їх ваги
        Dictionary<string, double> products;
        //другий продукт і його вартість
        Dictionary<string, double> productsPrice; 

        public Dishes(string pricePath ="N/A", string dishesPath = "N/A")
        {
            products = new Dictionary<string, double>();
            productsPrice = new Dictionary<string, double>();
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
                            if (!Double.TryParse(splitLine[1], out priceOfProduct) || (priceOfProduct <= 0))
                                throw new ArgumentException("Wrong Price of product");
                            //добавляємо
                            productsPrice[splitLine[0]] = priceOfProduct;
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
        {Ви тут і читаєте і одразу обчислюєте. Чи не краще розділити це на різні функції. Або ж адекватно називати метод.
            try
            {
                if (File.Exists(path))
                {
                    using (StreamReader reader = new StreamReader(path))
                    {
                        string line;
                        while((line = reader.ReadLine())!=null)
                        {
                            //Console.WriteLine(line);
                            //якщо не букви, то протустити
                            if (line.Length ==0)
                                continue;

                            string[] lineSplit = line.Split();
                            //якщо 1 слово, це назва страви
                            if(lineSplit.Length == 1)
                                continue;
                            
                            //ідуть пари для продуктів і ваги
                            else if (lineSplit.Length == 2)
                            {
                                double weight;
                                if (!Double.TryParse(lineSplit[1], out weight) || (weight <= 0))
                                    throw new ArgumentException("wrong weight");

                                if(!products.ContainsKey(lineSplit[0]))
                                {
                                    products[lineSplit[0]] = weight;
                                }
                                //якщо вже існує, збільшити вагу, кільки продутку взяли
                                else
                                {
                                    products[lineSplit[0]] += weight;
                                }
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

        public override string ToString()
        {
            string res = "";
            try
            {
                foreach (var item in products)
                {
                    res += string.Format("Name: {0}\tTotal weight: {1:f2}kg\tTotal price: {2:f2}$\n", item.Key, item.Value,
                        productsPrice[item.Key] * item.Value);
                }
            }
            catch (KeyNotFoundException ex)
            {
                res = ex.Message;
            }
            return res;
        }
    }
}
