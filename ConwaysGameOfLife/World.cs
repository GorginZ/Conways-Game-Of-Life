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


    //have range of acceptable, what's point of tiny world or stupidly large
    private int[,] BuildWorld(int rows, int columns)
    {
      var grid = new int[rows, columns];

      return grid;
    }
    public static int[,] WorldFactory()
    {
      int[,] grid = {
{0,0,0,0,0,0,0,0,0,0},
{0,0,0,0,0,0,0,0,0,0},
{0,0,0,0,0,0,0,0,0,0},
{0,0,0,0,0,0,0,0,0,0},
{0,0,0,0,1,1,1,0,0,0},
{0,0,0,0,0,0,0,0,0,0},
{0,0,0,0,0,0,0,0,0,0},
{0,0,0,0,0,0,0,0,0,0},
{0,0,0,0,0,0,0,0,0,0},
{0,0,0,0,0,0,0,0,0,0}};

      return grid;
    }




    //does this pass two digit ints? I feel like it doesn't
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

    //one of the conditions for ending program.
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
      int gridrow = Grid.GetLength(0);
      int gridcol = Grid.GetLength(1);

      for (int i = 0; i < gridrow; i++)
      {
        for (int j = 0; j < gridcol; j++)
        {
          Console.Write(Grid[i, j]);
        }
        Console.WriteLine();
      }
    }

    public bool IsLiveCell(int valueAtIndex)
    {

      if (valueAtIndex == 1)
      {
        return true;

      }
      return false;
    }

    public int NeighbourCount()
    {
      int count = 0;
      foreach (int element in Grid)
      {
          //check index plus 1
          //immedite right neighbour
          if (IsLiveCell(Grid[element, element + 1]))
          {
            count++;
          }
          //look immediate left neighbour
          // need special case for edge cells do next
          if (IsLiveCell(Grid[element, element - 1]))
          {
            count++;
          }
          // check index above
          if (IsLiveCell(Grid[element - 1, element]))
          {
            count++;
          }

          // check index below

          if (IsLiveCell(Grid[element + 1, element]))
          {
            count++;
          }

          //check index diagonal right UP
          if (IsLiveCell(Grid[element - 1, element + 1]))
          {
            count++;
          }

          // check index diagonal left UP
          if (IsLiveCell(Grid[element - 1, element - 1]))
          {
            count++;
          }

          // check index diagonal left down
          if (IsLiveCell(Grid[element + 1, element - 1]))
          {
            count++;
          }

          // check index diagonal right down
          if (IsLiveCell(Grid[element + 1, element + 1]))
          {
            count++;
          }
      }
      return count;
    }

    public void Tick()
    {

      foreach (int element in Grid)
      {
        if (IsLiveCell(element))
        {
          // Any live cell with fewer than two live neighbours dies, as if caused by underpopulation.

          // Any live cell with more than three live neighbours dies, as if by overcrowding.

          // Any live cell with two or three live neighbours lives on to the next generation.
        }

      }


    }
  }
}
