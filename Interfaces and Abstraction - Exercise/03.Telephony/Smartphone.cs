using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Telephony
{
    public class Smartphone : ICall
    {
        private string number;
        private string url;

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

        public string URL
        {
            get
            {
                return this.url;
            }
            set
            {
                for (int i = 0; i < value.Length; i++)
                {
                    char currURL = value[i];

                    if (char.IsDigit(currURL))
                    {
                        throw new ArgumentException("Invalid URL!");
                    }
                }

                this.url = value;
            }
        }

        public void Call()
        {
            Console.WriteLine($"Calling... {this.number}");
        }

        public void Browse()
        {
            Console.WriteLine($"Browsing: {this.url}!");
        }
    }
}
