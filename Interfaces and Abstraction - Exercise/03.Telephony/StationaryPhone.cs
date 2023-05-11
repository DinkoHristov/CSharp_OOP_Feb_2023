using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Telephony
{
    public class StationaryPhone : ICall
    {
        private string number;

        public string Number
        {
            get
            {
                return this.number;
            }
            set
            {
                for (int i = 0; i < value.Length; i++)
                {
                    char currNumber = value[i];

                    if (!char.IsDigit(currNumber))
                    {
                        throw new ArgumentException("Invalid number!");
                    }
                }

                this.number = value;
            }
        }

        public void Call()
        {
            Console.WriteLine($"Dialing... {this.number}");
        }
    }
}
