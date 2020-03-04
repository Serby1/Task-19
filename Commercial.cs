using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp28
{
    class Commercial:Software
    {
        private string dateSetting;
        private string dateUsing;
        private int Price;

        public Commercial() { }

        public Commercial(string n, string m, string dateSetting, string dateUsing, int Price)
        {
            this.name = n;
            this.manufct = m;
            this.dateSetting = dateSetting;
            this.dateUsing = dateUsing;
            this.Price = Price;
        }

        public override void showInf()
        {
            Console.WriteLine("Название: {0}\nПроизводитель: {1}\nДата установки: {2}\n Срок использования: {3}\nЦена: {4}", name, manufct, dateSetting, dateUsing, Price);
            Console.WriteLine();
        }

        public override bool relevance(DateTime dateNow)
        {
            DateTime a = DateTime.Parse(dateSetting);
            string[] line = dateUsing.Split(' ');
            if (line[1] == "day")
            {
                a = a.AddDays(int.Parse(line[0]));
            }
            else if (line[1] == "months")
            {

                a = a.AddMonths(int.Parse(line[0]));
            }
            else if (line[1] == "Years")
            {
                a = a.AddYears(int.Parse(line[0]));
            }
            else Console.WriteLine("Некорректный срок действия лицензии");
            if (a > dateNow)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

    }
}
