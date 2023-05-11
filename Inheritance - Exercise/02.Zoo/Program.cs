using System;

namespace Zoo
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Lizard lizard = new Lizard("Lizard");

            Snake snake = new Snake("Snake");

            Gorilla gorilla = new Gorilla("Gorilla");

            Bear bear = new Bear("Bear");

            Console.WriteLine(lizard.Name);
            Console.WriteLine(snake.Name);
            Console.WriteLine(gorilla.Name);
            Console.WriteLine(bear.Name);
        }
    }
}