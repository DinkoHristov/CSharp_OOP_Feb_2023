
using _02.VehiclesExtension.Core;
using _02.VehiclesExtension.Core.Interfaces;
using _02.VehiclesExtension.Models;

namespace _02.VehiclesExtension
{
    public class Program
    {
        static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
