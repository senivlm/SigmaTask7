using System;
using System.Collections.Generic;
using System.Text;

namespace SigmaTask7.Task1
{
    class Vocabulary
    {
        Dictionary<string, string> vocabulary;
        public Vocabulary()
        {
            vocabulary = new Dictionary<string, string>();
            vocabulary.Add("I", "boy");
            vocabulary.Add("go", "run");
            vocabulary.Add("to", "to");
            vocabulary.Add("school", "cinema");
        }

        public string ChangeText(string text)
        {
            //текст виводу
            StringBuilder result = new StringBuilder();
            //проходимось по кожному символу
            for (int i = 0; i < text.Length; i++)
            {
                //якшо якийсь не буква, то просто додати
                if (!Char.IsLetter(text[i]))
                {
                    result.Append(text[i]);
                }
                //інакше робимо слово
                else
                {
                    int wordLenght = 0;
                    //додатковий індексатор для проходу
                    int k = i;

                    while (Char.IsLetter(text[k]))
                    {
                        wordLenght++;
                        k++;
                        //якщо кінець тексту, то зупинити
                        if (k == text.Length)
                            break;
                    }
                    //отрмуємо слово
                    string keyWord = text.Substring(i, wordLenght);
                    //якщо є таке слово то отримати значення

                    if (vocabulary.ContainsKey(keyWord))
                    {
                        result.Append(vocabulary[keyWord]);
                    }
                    //якщо нема, то запросити відповідник
                    else
                    {
                        Console.WriteLine("Enter a couple for the word \"{0}\"", keyWord);
                        string couple = Console.ReadLine();
                        //втсавляємо нову пару
                        vocabulary[keyWord] = couple;

                        result.Append(vocabulary[keyWord]);
                    }
                    //вносимо зміни до індекса і
                    i += wordLenght - 1;
                }
            }
            return result.ToString();
        }
        //вивести набори ключ - значення
        public override string ToString()
        {
            string res = "";
            foreach(var item in vocabulary)
            {
                res += string.Format("{0} = {1}\n",item.Key,item.Value);
            }
            return res;
        }
    }
}
