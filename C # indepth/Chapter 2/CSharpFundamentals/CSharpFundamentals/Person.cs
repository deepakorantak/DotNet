using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFundamentals
{
    class Person
    {
        public string name { get; set; }
        public int age { get; set; }

        public Person(string iname, int iage)
        {
            name = iname;
            age = iage;

        }
    }
}
