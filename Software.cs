using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp28
{
    abstract public class Software : IComparable<Software>
    {
        protected string name;
        protected string manufct;

        abstract public void showInf();
        abstract public bool relevance(DateTime dateNow);
        private double converter(string type)
        {
            return double.Parse(type);
        }
       
        public int CompareTo(Software a)
        {

            if (this.name == a.name)
            {
                return 0;
            }
            else
            {
                return String.Compare(this.name, a.name);
            }
        }

    }   
}
