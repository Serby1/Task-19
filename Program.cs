using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;


namespace ConsoleApp28
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "C:/Users/Vlad/source/repos/ConsoleApp28/fileIn.txt";
            using (StreamReader fileIn = new StreamReader(path, Encoding.GetEncoding(1251)))
            {
                Software[] array = new Software[4];
                for (int i = 0; i < array.Length; ++i)
                {
                    string str = fileIn.ReadLine();
                    str = str.ToLower();
                    if (str == "свободное")
                    {
                        string name = fileIn.ReadLine();
                        string manufct = fileIn.ReadLine();
                        array[i] = new Free(name, manufct);
                    }
                    else if (str == "условно-бесплатное")
                    {
                        string name = fileIn.ReadLine();
                        string manufct = fileIn.ReadLine();
                        string dateSetting = fileIn.ReadLine();
                        string dateUsing = fileIn.ReadLine();
                        array[i] = new Shareware(name, manufct, dateSetting, dateUsing);
                    }
                    else if (str == "коммерческое")
                    {
                        string name = fileIn.ReadLine();
                        string manufct = fileIn.ReadLine();
                        string dateSetting = fileIn.ReadLine();
                        string dateUsing = fileIn.ReadLine();
                        string price = fileIn.ReadLine();
                        array[i] = new Commercial(name, manufct, dateSetting, dateUsing, int.Parse(price));
                    }
                    else { Console.WriteLine("Неверно введены данные"); }
                    str = fileIn.ReadLine();
                }
                foreach (Software x in array)
                {
                    x.showInf();
                }
                Console.WriteLine("\n-------------------Отсортированные данные-------------------\n");
                Array.Sort(array);
                foreach (Software x in array)
                {
                    x.showInf();
                }

                DateTime dateNow  = new DateTime();
                Console.Write("Введите дату(дд.мм.гггг): ");
                bool valid = false;
                while (valid != true)
                {
                    string date = Console.ReadLine();
                    Regex r = new Regex(@"(0[1-9]|[12][0-9]|3[01])[.](0[1-9]|1[012])[.](19|20)\d\d");
                    MatchCollection validDate = r.Matches(date);
                    if (validDate.Count > 0)
                    {
                        dateNow = DateTime.Parse(date);
                        valid = true;
                    }
                    else { Console.Write("\nНеверно введена дата\nВведите дату(дд.мм.гггг): "); }
                }
                valid = false;
                int count = 0;

                Console.WriteLine("--------------------Результаты--------------------");
                foreach (Software x in array)
                {
                    if (x.relevance(dateNow))
                    {
                        ++count;
                        x.showInf();
                    }
                }
                if (count == 0)
                {
                    Console.WriteLine("Подходящего ПО не найдено");
                }
                Console.ReadLine();
            }
        }
    }
}
