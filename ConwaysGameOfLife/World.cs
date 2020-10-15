using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ConwaysGameOfLife
{
  public class World
  {
    private Grid<CellState> _grid;

    public World(int rowDimension, int columnDimension)
    {
      _grid = new Grid<CellState>(rowDimension, columnDimension);
    }

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
    public string PrintWorld()
    {
      return this._grid.GridToSTring();
    }

    public void PopulateGrid(List<RowColumn> CoordinatesList)
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


    public List<RowColumn> GetListOfCoordinatesForThisCellsNeighbours(int row, int column)
    {
      var leftNeighbour = column == 0 ? (_grid.ColumnCount - 1) : (column - 1);
      var rightNeighbour = column == (_grid.ColumnCount - 1) ? (0) : (column + 1);
      var upNeighbour = row == 0 ? (_grid.RowCount - 1) : (row - 1);
      var downNeighbour = row == (_grid.RowCount - 1) ? (0) : (row + 1);

      var neighbourList = new List<RowColumn>
      {
        new RowColumn(row, rightNeighbour), new RowColumn(row, leftNeighbour), new RowColumn(upNeighbour, column), new RowColumn(downNeighbour, column), new RowColumn(upNeighbour, rightNeighbour), new RowColumn(upNeighbour, leftNeighbour), new RowColumn(downNeighbour, rightNeighbour), new RowColumn(downNeighbour, leftNeighbour)
        };

      return neighbourList;
    }
    public int LiveNeighbourCount(Grid<CellState> _grid, List<RowColumn> neighbourList)
    {
      int count = 0;

      foreach (RowColumn coordinate in neighbourList)
      {
        if (IsLiveCell(_grid[coordinate.Row, coordinate.Column]))
        {
          count++;
        }
      }
      return count;
    }

    private List<RowColumn> CellsToMakeAliveOnTick()
    {
      var CoordinatesOfCellsToAlive = new List<RowColumn>();

      for (int row = 0; row < _grid.RowCount; row++)
      {
        for (int column = 0; column < _grid.ColumnCount; column++)
        {
          var neighboursList = GetListOfCoordinatesForThisCellsNeighbours(row, column);
          var numberOfLiveNeighbours = LiveNeighbourCount(_grid, neighboursList);

          // Any live cell with two or three live neighbours lives on to the next generation.
          if (IsLiveCell(_grid[row, column]) && (numberOfLiveNeighbours.Equals(3) || numberOfLiveNeighbours.Equals(2)))
          {
            CoordinatesOfCellsToAlive.Add(new RowColumn(row, column));
          }
          // Any dead cell with exactly three live neighbours becomes a live cell.
          if (!IsLiveCell(_grid[row, column]) && numberOfLiveNeighbours.Equals(3))
          {
            CoordinatesOfCellsToAlive.Add(new RowColumn(row, column));
          }

        }
      }
      return CoordinatesOfCellsToAlive;
    }
    public void Tick()
    {
      var ListOfCoordinatesToMakeAlive = CellsToMakeAliveOnTick();

      _grid = new Grid<CellState>(_grid.RowCount, _grid.ColumnCount);

      _grid.SetMany(ListOfCoordinatesToMakeAlive, CellState.Alive);

    }

  }
}
