using System;
using System.Collections.Generic;
namespace ConwaysGameOfLife
{
  public class World
  {
    private Grid<CellState> _grid;

    public World(int rowDimension, int columnDimension)
    {
      _grid = new Grid<CellState>(rowDimension, columnDimension);
    }

// shallow copy may be obscuring some test results.
    public Grid<CellState> GetGrid()
    {
      return _grid;
    }

    public bool IsDeadWorld()
    {
      for (int row = 0; row < _grid.RowCount; row++)
      {
        for (int column = 0; column < _grid.ColumnCount; column++)
        {
          if (IsLiveCell(_grid[row, column]))
          {
            return false;
          }
        }
      }
      return true;

    }
    public void PrintWorld()
    {
      for (int i = 0; i < _grid.RowCount; i++)
      {
        for (int j = 0; j < _grid.ColumnCount; j++)
        {
          Console.Write(_grid[i, j]);
        }
        Console.WriteLine();
      }
    }

    public void PopulateGrid(List<Coordinates> CoordinatesList)
    {
      this._grid.SetMany(CoordinatesList, CellState.Alive);
    }


    public bool IsLiveCell(CellState valueAtIndex)
    {
      if (valueAtIndex.Equals(CellState.Alive))
      {
        return true;

      }
      return false;
    }


    public List<Coordinates> GetNeighbours(int row, int column)
    {
      var leftNeighbour = column == 0 ? (_grid.ColumnCount - 1) : (column - 1);

      var rightNeighbour = column == (_grid.ColumnCount - 1) ? (0) : (column + 1);

      var upNeighbour = row == 0 ? (_grid.RowCount - 1) : (row - 1);

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
    public int LiveNeighbourCount(Grid<CellState> _grid, List<Coordinates> neighbourList)
    {
      int count = 0;

      foreach (Coordinates coordinate in neighbourList)
      {
        if (IsLiveCell(_grid[coordinate.Row, coordinate.Column]))
        {
          count++;
        }
      }
      return count;
    }

// public void CellsToMakeAliveOnTick()
// {

// }
    public void Tick()
    {
      // var CoordinatesOfCellsToDie = new List<Coordinates>();
      var CoordinatesOfCellsToAlive = new List<Coordinates>();

      for (int row = 0; row < _grid.RowCount; row++)
      {
        for (int column = 0; column < _grid.ColumnCount; column++)
        {

          var neighboursList = GetNeighbours(row, column);
          var numberOfLiveNeighbours = LiveNeighbourCount(_grid, neighboursList);

          // Any live cell with fewer than two live neighbours dies, as if caused by underpopulation.

          // if (IsLiveCell(_grid[row, column]) && numberOfLiveNeighbours < 2)
          // {
          //   CoordinatesOfCellsToDie.Add(new Coordinates(row, column));
          // }

          // // Any live cell with more than three live neighbours dies, as if by overcrowding.

          // if (IsLiveCell(_grid[row, column]) && numberOfLiveNeighbours > 3)
          // {
          //   CoordinatesOfCellsToDie.Add(new Coordinates(row, column));
          // }

          // Any live cell with two or three live neighbours lives on to the next generation.
          if (IsLiveCell(_grid[row, column]) && (numberOfLiveNeighbours.Equals(3) || numberOfLiveNeighbours.Equals(2)))
          {
            CoordinatesOfCellsToAlive.Add(new Coordinates(row, column));
          }
          // Any dead cell with exactly three live neighbours becomes a live cell.
          if (!IsLiveCell(_grid[row, column]) && numberOfLiveNeighbours.Equals(3))
          {
            CoordinatesOfCellsToAlive.Add(new Coordinates(row, column));
          }

        }
      }
      _grid = new Grid<CellState>(_grid.RowCount, _grid.ColumnCount);

      _grid.SetMany(CoordinatesOfCellsToAlive, CellState.Alive);
      // _grid.SetMany(CoordinatesOfCellsToDie, CellState.Dead);

    }

  }
}
