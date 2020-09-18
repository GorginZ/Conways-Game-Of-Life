using System;
using System.Collections.Generic;
namespace ConwaysGameOfLife
{
  public class World
  {
    public CellState[,] Grid;


    public World(int rows, int columns)
    {
      Grid = BuildWorld(rows, columns);
    }


    //have range of acceptable, what's point of tiny world or stupidly large
    private CellState[,] BuildWorld(int rows, int columns)
    {
      var grid = new CellState[rows, columns];

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
          Grid[row, col] = CellState.Alive;
        }

      }
    }

    //one of the conditions for ending program.
    public bool IsDeadWorld()
    {
      foreach (int element in Grid)
      {
        if (element.Equals(CellState.Alive))
        {
          return false;
        }
      }
      return true;
    }

    public void PrintWorld(CellState[,] currentWorld)
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

    public bool IsLiveCell(CellState valueAtIndex)
    {

      if (valueAtIndex.Equals(CellState.Alive))
      {
        return true;

      }
      return false;
    }

    public int NeighbourCount(CellState[,] gridCopy, int row, int column)
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
      if (IsLiveCell(gridCopy[row, rightNeighbour]))
      {
        count++;
      }

      //look immediate left neighbour
      // need special case for edge cells do next
      if (IsLiveCell(gridCopy[row, leftNeighbour]))
      {
        count++;
      }
      // check index above
      if (IsLiveCell(gridCopy[upNeighbour, column]))
      {
        count++;
      }

      // check index below

      if (IsLiveCell(gridCopy[downNeighbour, column]))
      {
        count++;
      }

      //check index diagonal right UP
      if (IsLiveCell(gridCopy[upNeighbour, rightNeighbour]))
      {
        count++;
      }

      // check index diagonal left UP
      if (IsLiveCell(gridCopy[upNeighbour, leftNeighbour]))
      {
        count++;
      }

      // check index diagonal left down
      if (IsLiveCell(gridCopy[downNeighbour, leftNeighbour]))
      {
        count++;
      }

      // check index diagonal right down
      if (IsLiveCell(gridCopy[downNeighbour, rightNeighbour]))
      {
        count++;
      }


      return count;
    }

    public int RowCount => Grid.GetLength(0);
    public int ColumnCount => Grid.GetLength(1);

    public void Die(int row, int column)
    {
      Grid[row, column] = CellState.Dead;
    }

    public void Live(int row, int column)
    {
      Grid[row, column] = CellState.Alive;
    }

    public void Tick()
    {


CellState[,] gridCopy = Grid.Clone() as CellState[,];

      for (int row = 0; row < RowCount; row++)
      {
        for (int column = 0; column < ColumnCount; column++)
        {
          var neighbours = NeighbourCount(gridCopy, row, column);

          // Any live cell with fewer than two live neighbours dies, as if caused by underpopulation.
          if (IsLiveCell(gridCopy[row, column]) && neighbours < 2)
          {
            Die(row, column);
          }

          // Any live cell with more than three live neighbours dies, as if by overcrowding.
          if (IsLiveCell(gridCopy[row, column]) && neighbours > 3)
          {
            Die(row, column);
          }

          // Any live cell with two or three live neighbours lives on to the next generation.
          if (IsLiveCell(gridCopy[row, column]) && (neighbours.Equals(3) || neighbours.Equals(2)))
          {
            Live(row, column);
          }
          // Any dead cell with exactly three live neighbours becomes a live cell.
          if (!IsLiveCell(gridCopy[row, column]) && neighbours.Equals(3))
          {
            Live(row, column);
          }
        }
      }

   
    }

  }
}
