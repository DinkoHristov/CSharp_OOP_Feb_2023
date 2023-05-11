namespace Formula1
{
    using Formula1.Core;
    using Formula1.Core.Contracts;
    using Formula1.IO;
    using Formula1.IO.Contracts;
    using Formula1.Models;
    using Formula1.Models.Contracts;
    using Formula1.Repositories;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            IReader reader = new Reader();
            IWriter writer = new Writer();

            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
