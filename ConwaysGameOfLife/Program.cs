using System;

namespace ConwaysGameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var world = new World(10,20);
            world.PrintWorld();
        }
    }
}
