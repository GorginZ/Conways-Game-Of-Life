using System;
using System.Collections.Generic;
namespace ConwaysGameOfLife
{
  public class World
  {
    private Grid _grid ;

    public World(int rowDimension, int columnDimension)
    {
      _grid = new Grid(rowDimension, columnDimension);
    }

    public Grid GetGrid()
    {
      return _grid;
    }

    public bool IsDeadWorld()
    {
      for (int row = 0; row < _grid.RowCount; row++)
      {
        for (int column = 0; column < _grid.ColumnCount; column++)
        {
          if (IsLiveCell(_grid.CellGrid[row, column]))
          {
            return false;
          }
        }
      }
      return true;

    }

    public void PrintWorld(Grid cellGrid)
    {
      int gridrow = _grid.CellGrid.GetLength(0);
      int gridcol = _grid.CellGrid.GetLength(1);

      for (int i = 0; i < gridrow; i++)
      {
        for (int j = 0; j < gridcol; j++)
        {
          Console.Write(cellGrid.CellGrid[i, j]);
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
      var leftNeighbour = column == 0 ? (_grid.CellGrid.GetLength(1) - 1) : (column - 1);

      var rightNeighbour = column == (_grid.ColumnCount - 1) ? (0) : (column + 1);

      var upNeighbour = row == 0 ? (_grid.CellGrid.GetLength(0) - 1) : (row - 1);

      var downNeighbour = row == (_grid.RowCount - 1) ? (0) : (row + 1);

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

    // private int RowCount => _grid.CellGrid.GetLength(0);
    // private int ColumnCount => _grid.CellGrid.GetLength(1);

    private void Die(int row, int column)
    {
      _grid.CellGrid[row, column] = CellState.Dead;
    }

    private void Live(int row, int column)
    {
      _grid.CellGrid[row, column] = CellState.Alive;
    }

    public void Tick()
    {


      CellState[,] gridCopy = _grid.CellGrid.Clone() as CellState[,];

      for (int row = 0; row < _grid.RowCount; row++)
      {
        for (int column = 0; column < _grid.ColumnCount; column++)
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
