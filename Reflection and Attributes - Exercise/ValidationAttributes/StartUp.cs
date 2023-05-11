using System;
using ValidationAttributes.Models;

namespace ValidationAttributes
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var person = new Person
             (
                 "Ivan",
                 18
             );

            bool isValidEntity = Utils.Validator.IsValid(person);

            Console.WriteLine(isValidEntity);
        }
    }
}
