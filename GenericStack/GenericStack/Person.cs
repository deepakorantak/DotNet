using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericStack
{
    class Person
    {
        public string Name
        {
            get
            {
                return firstName + " " + lastName;
            }
            set
            {


                if (!string.IsNullOrEmpty(value) && value.IndexOf(" ") > 0)
                {

                    firstName = value.Substring(0, value.IndexOf(" ")).Trim();
                    lastName = value.Substring(value.IndexOf(" ") + 1).Trim();
                }

            }
        }
        private string firstName, lastName;

        public Person(string ifirstName, string ilastName)
        {
            firstName = ifirstName;
            lastName = ilastName;


        }
    }
}
