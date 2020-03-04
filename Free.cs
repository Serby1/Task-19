using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp28
{
    public class Free : Software
    {
        public Free() { }

        public Free(string n, string m)
        {
            this.name = n;
            this.manufct = m;
            
        }

        
        public override bool relevance(DateTime dataNow)
        {
            return true;
        }

        public override void showInf()
        {
            Console.WriteLine("Название: {0}\nПроизводитель: {1}", name, manufct);
            Console.WriteLine();
        }


    }
}
