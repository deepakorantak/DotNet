using delegateEvent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertiesVsFields
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
                if(!string.IsNullOrEmpty(value) && value.IndexOf(" ")>0)
                {

                    PrintDelegateEventArgs arg1 = new PrintDelegateEventArgs();
                    arg1.printString = $"Name changed from {Name} to {value}";
                    printName(this, arg1);

                    firstName = value.Substring(0,value.IndexOf(" ")).Trim();
                    lastName = value.Substring(value.IndexOf(" ")+1).Trim();
                             

                }
            }
        }    
        private string firstName,lastName;
        
        public Person(string ifirstName,string ilastName)
        {
            firstName = ifirstName;
            lastName = ilastName;
            

        }

        public event PrintDelegate printName;
    }
}
