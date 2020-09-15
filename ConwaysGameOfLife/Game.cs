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
        int row = int.Parse(coord[0].ToString());
        int col = int.Parse(coord[2].ToString());

        Grid[row, col] = 1;
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
  }
}