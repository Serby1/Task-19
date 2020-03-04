using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp28
{
    public class Shareware : Software
    {
        private string dateUsing;
        private string dateSetting;

        public Shareware() { }

        public Shareware(string n, string m, string dateSetting, string dateUsing)
        {
            this.name = n;
            this.manufct = m;
            this.dateSetting = dateSetting;
            this.dateUsing = dateUsing;
        }
        public override void showInf()
        {
            Console.WriteLine("Название:{0}\nПроизводитель: {1}\nДата установки:{2}\nСрок использования: {3}", name, manufct, dateSetting, dateUsing);
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
            else if (line[1] == "years")
            {
                a = a.AddYears(int.Parse(line[0]));
            }
            else Console.WriteLine("Некорректный срок действия лицензии");
            if(a > dateNow)
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
