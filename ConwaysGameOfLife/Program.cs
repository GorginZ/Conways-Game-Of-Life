using System;

namespace ConwaysGameOfLife
{
  class Program
  {
    static void Main(string[] args)
    {
      var userInput = new UserInput();
      var output = new Output();

      Console.Write(output.GetIntro());
      var inputRows = userInput.ReadInput();

      Console.Write(output.)
      var inputCols = userInput.ReadInput();

      var tryParseRows = int.TryParse(inputRows, out int rows);
      var tryParseCols = int.TryParse(inputCols, out int cols);

      var world = new World(rows, cols);

      Console.Write(world.PrintWorld());

      Console.WriteLine("innoculate world with some live cells");
      Console.WriteLine("input your coordinates in the following format: 0,0 0,1 0,2 4,4 2,2 ");

      var coordinateList = UserInput.DigestCoordinates(userInput.ReadInput());
      world.PopulateGrid(coordinateList);


      Console.Clear();
      Console.Write(world.PrintWorld());


      while (1 < 100)
      {
        Console.WriteLine("press Y key to 'tick N to cancel");

        var userinput = Console.ReadLine();
        if (userinput == "Y")
        {
          Console.Clear();
          world.Tick();
          Console.Write(world.PrintWorld());
        }
      }




    }
  }
}
