using System;
using System.Collections.Generic;
namespace ConwaysGameOfLife
{
  public class World
  {
    private Grid<CellState> _grid;
    private List<Coordinates> _cellsOfInterest = new List<Coordinates>();

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

    public void PopulateGrid(List<Coordinates> CoordinatesToPopulateList)
    {
      this._grid.SetMany(CoordinatesToPopulateList, CellState.Alive);
    }

    public void SetCellsOfInterest(List<Coordinates> cellsThatAreAlive)
    {
      foreach (Coordinates coordinate in cellsThatAreAlive)
      {
        var neighboursList = GetNeighbours(coordinate.Row, coordinate.Column);
        _cellsOfInterest.AddRange(neighboursList);
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

    private List<Coordinates> CellsToMakeAliveOnTick()
    {
    
      var CoordinatesOfCellsToAlive = new List<Coordinates>();

      // for (int row = 0; row < _grid.RowCount; row++)
      // {
      //   for (int column = 0; column < _grid.ColumnCount; column++)
      //   {

      foreach (Coordinates coordinate in _cellsOfInterest)
      {

        var neighboursList = GetNeighbours(coordinate.Row, coordinate.Column);
        var numberOfLiveNeighbours = LiveNeighbourCount(_grid, neighboursList);

        // Any live cell with two or three live neighbours lives on to the next generation.
        if (IsLiveCell(_grid[coordinate.Row, coordinate.Column]) && (numberOfLiveNeighbours.Equals(3) || numberOfLiveNeighbours.Equals(2)))
        {
          CoordinatesOfCellsToAlive.Add(new Coordinates(coordinate.Row, coordinate.Column));
        }
        // Any dead cell with exactly three live neighbours becomes a live cell.
        if (!IsLiveCell(_grid[coordinate.Row, coordinate.Column]) && numberOfLiveNeighbours.Equals(3))
        {
          CoordinatesOfCellsToAlive.Add(new Coordinates(coordinate.Row, coordinate.Column));
        }
      }

      //   }
      // }
      return CoordinatesOfCellsToAlive;
    }
    public void Tick()
    {
      var ListOfCoordinatesToMakeAlive = CellsToMakeAliveOnTick();

      SetCellsOfInterest(ListOfCoordinatesToMakeAlive);

      _grid = new Grid<CellState>(_grid.RowCount, _grid.ColumnCount);
      //hold onto this value, cells that are alive.can look at these coordinates next time and their neighbours become of interest.

      _grid.SetMany(ListOfCoordinatesToMakeAlive, CellState.Alive);

    }

  }
}
