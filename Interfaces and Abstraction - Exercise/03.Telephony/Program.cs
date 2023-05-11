using System;

namespace _03.Telephony
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] phoneNumbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            foreach (string phoneNumber in phoneNumbers)
            {
                if (phoneNumber.Length == 7)
                {
                    // It's a stationary phone
                    try
                    {
                        StationaryPhone stationaryPhone = new StationaryPhone();

                        stationaryPhone.Number = phoneNumber;
                        stationaryPhone.Call();
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine(exception.Message);
                    }
                }
                else
                {
                    // It's a smartphone
                    try
                    {
                        Smartphone smartphone = new Smartphone();

                        smartphone.Number = phoneNumber;
                        smartphone.Call();
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine(exception.Message);
                    }
                }
            }

            string[] urls = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            foreach (string url in urls)
            {
                try
                {
                    Smartphone smartPhone = new Smartphone();

                    smartPhone.URL = url;
                    smartPhone.Browse();
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }
        }
    }
}
