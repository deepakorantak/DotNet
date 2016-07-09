using System;

namespace DelegateLambda
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
                PrintDelegateEventArgs arg1 = new PrintDelegateEventArgs();

                if (!string.IsNullOrEmpty(value) && value.IndexOf(" ") > 0)
                {

                    arg1.printString = $"Name changed from {Name} to {value}";
                    firstName = value.Substring(0, value.IndexOf(" ")).Trim();
                    lastName = value.Substring(value.IndexOf(" ") + 1).Trim();
                }

                else
                {
                    arg1.printString = $"Name did not changed from {Name} to {value}.Either null or did not contain space";

                }
                printChange(this, arg1);

            }
        }
        private string firstName, lastName;

        public Person(string ifirstName, string ilastName)
        {
            firstName = ifirstName;
            lastName = ilastName;


        }
        // public event PrintDelegate printChange;
        public event Action<object, PrintDelegateEventArgs> printChange;
    }
}
