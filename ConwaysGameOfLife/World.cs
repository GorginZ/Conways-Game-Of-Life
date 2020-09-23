using System;
using System.Collections.Generic;
namespace ConwaysGameOfLife
{
  public class World
  {
    public CellState[,] Grid;


    public World(int rowDimension, int columnDimension)
    {
      Grid = BuildWorld(rowDimension, columnDimension);
    }


    //have range of acceptable, what's point of tiny world or stupidly large

    //take a coordinate
    private CellState[,] BuildWorld(int rowDimension, int columnDimension)
    {
      var grid = new CellState[rowDimension, columnDimension];

      return grid;
    }


    public void Populate(List<Coordinates> coordinates)
    {
      foreach (Coordinates coordinate in coordinates)
      {
        if (coordinate.Column < ColumnCount && coordinate.Row < RowCount)
        {
          Grid[coordinate.Row, coordinate.Column] = CellState.Alive;
        }
      }
    }

    public bool IsDeadWorld()
    {
      for (int row = 0; row < RowCount; row++)
      {
        for (int column = 0; column < ColumnCount; column++)
        {
          if (IsLiveCell(Grid[row, column]))
          {
            return false;
          }
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
    // does it need gridcopy?
    public List<Coordinates> GetNeighbours(int row, int column)
    {
      var leftNeighbour = column == 0 ? (Grid.GetLength(1) - 1) : (column - 1);

      var rightNeighbour = column == (ColumnCount - 1) ? (0) : (column + 1);

      var upNeighbour = row == 0 ? (Grid.GetLength(0) - 1) : (row - 1);

      var downNeighbour = row == (RowCount - 1) ? (0) : (row + 1);

      var neighbourList = new List<Coordinates>();

      neighbourList.Add(new Coordinates(row, rightNeighbour));
      neighbourList.Add(new Coordinates(row, leftNeighbour));
      neighbourList.Add(new Coordinates(upNeighbour, column));
      neighbourList.Add(new Coordinates(downNeighbour, column));
      neighbourList.Add(new Coordinates(upNeighbour, rightNeighbour));
      neighbourList.Add(new Coordinates(upNeighbour, leftNeighbour));
      neighbourList.Add(new Coordinates(downNeighbour, rightNeighbour));
      neighbourList.Add(new Coordinates(downNeighbour, leftNeighbour));

      return neighbourList;
    }
    public int LiveNeighbourCount(CellState[,] gridCopy, List<Coordinates> neighbourList)
    {
      int count = 0;

      foreach (Coordinates coordinate in neighbourList)
      {
        if (IsLiveCell(gridCopy[coordinate.Row, coordinate.Column]))
        {
          count++;
        }
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

          var neighboursList = GetNeighbours(row, column);

          var numberOfLiveNeighbours = LiveNeighbourCount(gridCopy, neighboursList);

          // Any live cell with fewer than two live neighbours dies, as if caused by underpopulation.
          if (IsLiveCell(gridCopy[row, column]) && numberOfLiveNeighbours < 2)
          {
            Die(row, column);
          }

          // Any live cell with more than three live neighbours dies, as if by overcrowding.
          if (IsLiveCell(gridCopy[row, column]) && numberOfLiveNeighbours > 3)
          {
            Die(row, column);
          }

          // Any live cell with two or three live neighbours lives on to the next generation.
          if (IsLiveCell(gridCopy[row, column]) && (numberOfLiveNeighbours.Equals(3) || numberOfLiveNeighbours.Equals(2)))
          {
            Live(row, column);
          }
          // Any dead cell with exactly three live neighbours becomes a live cell.
          if (!IsLiveCell(gridCopy[row, column]) && numberOfLiveNeighbours.Equals(3))
          {
            Live(row, column);
          }
        }
      }


    }

  }
}
