using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ConwaysGameOfLife
{
  class Program
  {
    static void Main(string[] args)
    {
      var userInput = new UserInput();
      var output = new Output();
      Console.Write(output.IntroMessage);

      int rowDimension;
      int columnDimension;

      Console.Write(output.RowPrompt);
      InputParser.TryParseDimensions(userInput.ReadInput(), out rowDimension);
      Console.Write(output.ColumnPrompt);
      InputParser.TryParseDimensions(userInput.ReadInput(), out columnDimension);
      var world = new World(rowDimension, columnDimension);

      Console.Write(world.PrintWorld());
      Console.WriteLine("innoculate world with some live cells");
      Console.WriteLine("input your coordinates in the following format: 0,0 0,1 0,2 4,4 2,2 ");
     List<Index> coordinateList = GetValidIndexList();
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
    
    private static List<Index> GetValidIndexList()
    {
      var input = Console.ReadLine();
      List<Index> coordinateList;

      while (!InputParser.TryParseInputIndexes(input, out coordinateList))
      {
        Console.WriteLine("input your coordinates in the following format: 0,0 0,1 0,2 4,4 2,2 ");
        input = Console.ReadLine();

      }
      return coordinateList;
    }
  }
}
