using System;
using System.Collections.Generic;
namespace ConwaysGameOfLife
{
  public class World
  {
    public int[,] Grid;

    public int[,] TickGrid;

    public World(int rows, int columns)
    {
      Grid = BuildWorld(rows, columns);
      TickGrid = BuildWorld(rows, columns);
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

    public void PrintWorld(int[,] currentWorld)
    {
      int gridrow = Grid.GetLength(0);
      int gridcol = Grid.GetLength(1);

      for (int i = 0; i < gridrow; i++)
      {
        for (int j = 0; j < gridcol; j++)
        {
          Console.Write(currentWorld[i, j]);
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

    public int NeighbourCount(int row, int column)
    {
      int count = 0;

      var leftNeighbour = column == 0
        ? (Grid.GetLength(1) - 1)
        : (column - 1);


      var rightNeighbour = column == (ColumnCount - 1)
     ? (0)
     : (column + 1);

      var upNeighbour = row == 0
        ? (Grid.GetLength(0) - 1)
        : (row - 1);

      var downNeighbour = row == (RowCount - 1)
           ? (0)
           : (row + 1);


      // check index plus 1
      // immedite right neighbour
      if (IsLiveCell(Grid[row, rightNeighbour]))
      {
        count++;
      }

      //look immediate left neighbour
      // need special case for edge cells do next
      if (IsLiveCell(Grid[row, leftNeighbour]))
      {
        count++;
      }
      // check index above
      if (IsLiveCell(Grid[upNeighbour, column]))
      {
        count++;
      }

      // check index below

      if (IsLiveCell(Grid[downNeighbour, column]))
      {
        count++;
      }

      //check index diagonal right UP
      if (IsLiveCell(Grid[upNeighbour, rightNeighbour]))
      {
        count++;
      }

      // check index diagonal left UP
      if (IsLiveCell(Grid[upNeighbour, leftNeighbour]))
      {
        count++;
      }

      // check index diagonal left down
      if (IsLiveCell(Grid[downNeighbour, leftNeighbour]))
      {
        count++;
      }

      // check index diagonal right down
      if (IsLiveCell(Grid[downNeighbour, rightNeighbour]))
      {
        count++;
      }


      return count;
    }

    public int RowCount => Grid.GetLength(0);
    public int ColumnCount => Grid.GetLength(1);

    public void Die(int row, int column)
    {
      TickGrid[row, column] = 0;
    }

    public void Live(int row, int column)
    {
      TickGrid[row, column] = 1;
    }

    public void Tick()
    {
      for (int row = 0; row < RowCount; row++)
      {
        for (int column = 0; column < ColumnCount; column++)
        {
          var neighbours = NeighbourCount(row, column);

          // Any live cell with fewer than two live neighbours dies, as if caused by underpopulation.
          if (IsLiveCell(Grid[row, column]) && neighbours < 2)
          {
            Die(row, column);
          }

          // Any live cell with more than three live neighbours dies, as if by overcrowding.
          if (IsLiveCell(Grid[row, column]) && neighbours > 3)
          {
            Die(row, column);
          }

          // Any live cell with two or three live neighbours lives on to the next generation.
          if (IsLiveCell(Grid[row, column]) && (neighbours.Equals(3) || neighbours.Equals(2)))
          {
            Live(row, column);
          }
          // Any dead cell with exactly three live neighbours becomes a live cell.
          if (!IsLiveCell(Grid[row, column]) && neighbours.Equals(3))
          {
            Live(row, column);
          }
        }
      }
      Grid = TickGrid;
    }

  }
}
