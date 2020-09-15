using System;
using System.Collections.Generic;
namespace ConwaysGameOfLife
{
  public class World
  {
    public int[,] Grid;

    public World(int rows, int columns)
    {
      Grid = BuildWorld(rows, columns);
    }

    private int[,] BuildWorld(int rows, int columns)
    {
      var grid = new int[rows, columns];

      return grid;
    }



    public void Populate(string coordString)
    {
      var coordinates = coordString.Split(" ");
      foreach (string coord in coordinates)
      {
        var rowTryParse = int.TryParse(coord[0].ToString(), out int row);
        var colTryParse = int.TryParse(coord[2].ToString(), out int col);

        if (rowTryParse && colTryParse && col < Grid.GetLength(0) && col < Grid.GetLength(1) && row < Grid.GetLength(0) && row < Grid.GetLength(1))
        {
          Grid[row, col] = 1;
        }

      }
    }

    public bool IsDeadWorld()
    {
      foreach (int element in Grid)
      {
        if (element == 1)
        {
          return false;
        }
      }

      return true;
    }

    public void PrintWorld()
    {
      int gridcol = Grid.GetLength(0);
      int gridrow = Grid.GetLength(1);

      for (int i = 0; i < gridcol; i++)
      {
        for (int j = 0; j < gridrow; j++)
        {
          Console.Write(Grid[i, j]);
        }
        Console.WriteLine();
      }
    }
  }
}
