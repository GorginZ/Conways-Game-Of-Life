using System;

namespace ConwaysGameOfLife
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Welcome to Life Game!");
      Console.WriteLine("A new world has been made.");

      Console.WriteLine("how many rows should be in this world?");
      var inputRows = Console.ReadLine();

      Console.WriteLine("how many columns should be in this world?");
      var inputCols = Console.ReadLine();

      var tryParseRows = int.TryParse(inputRows, out int rows);
      var tryParseCols = int.TryParse(inputCols, out int cols);


      var world = new World(rows, cols);

      world.PrintWorld();

      Console.WriteLine("innoculate world with some live cells");
      Console.WriteLine("input your coordinates in the following format: 0,0 0,1 0,2 4,4 2,2 ");

      var coords = Console.ReadLine();
      var coordinateList = Coordinates.DigestCoordinates(coords);
  

      Console.Clear();
      world.PrintWorld();

    while (1 < 100)
    { 
         Console.WriteLine("press Y key to 'tick N to cancel");
      
        var userinput = Console.ReadLine();
        if (userinput == "Y")
        {
          Console.Clear();
          world.Tick();
          world.PrintWorld();
        }
    }
     

      

    }
  }
}
