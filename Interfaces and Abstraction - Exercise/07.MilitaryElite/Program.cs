using _07.MilitaryElite.Core;
using _07.MilitaryElite.Core.Interface;
using _07.MilitaryElite.Enums;
using System;

namespace _07.MilitaryElite
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IEngine engine = new Engine();

            engine.Run();
        }
    }
}
