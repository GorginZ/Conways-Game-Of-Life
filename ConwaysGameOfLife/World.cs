using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ConwaysGameOfLife
{
  public class World
  {
    private Grid<CellState> _grid;


    private List<Index> _startingState;
    [Required]
    private int _rowDimension;
    [Required]
    private int _columnDimension;

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
      return this._grid.SeeGrid();
    }

    public void PopulateGrid(List<Index> CoordinatesList)
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


    public List<Index> GetListOfCoordinatesForThisCellsNeighbours(int row, int column)
    {
      var leftNeighbour = column == 0 ? (_grid.ColumnCount - 1) : (column - 1);
      var rightNeighbour = column == (_grid.ColumnCount - 1) ? (0) : (column + 1);
      var upNeighbour = row == 0 ? (_grid.RowCount - 1) : (row - 1);
      var downNeighbour = row == (_grid.RowCount - 1) ? (0) : (row + 1);

      var neighbourList = new List<Index>
      {
        new Index(row, rightNeighbour), new Index(row, leftNeighbour), new Index(upNeighbour, column), new Index(downNeighbour, column), new Index(upNeighbour, rightNeighbour), new Index(upNeighbour, leftNeighbour), new Index(downNeighbour, rightNeighbour), new Index(downNeighbour, leftNeighbour)
        };

      return neighbourList;
    }
    public int LiveNeighbourCount(Grid<CellState> _grid, List<Index> neighbourList)
    {
      int count = 0;

      foreach (Index coordinate in neighbourList)
      {
        if (IsLiveCell(_grid[coordinate.Row, coordinate.Column]))
        {
          count++;
        }
      }
      return count;
    }

    private List<Index> CellsToMakeAliveOnTick()
    {
      var CoordinatesOfCellsToAlive = new List<Index>();

      for (int row = 0; row < _grid.RowCount; row++)
      {
        for (int column = 0; column < _grid.ColumnCount; column++)
        {
          var neighboursList = GetListOfCoordinatesForThisCellsNeighbours(row, column);
          var numberOfLiveNeighbours = LiveNeighbourCount(_grid, neighboursList);

          // Any live cell with two or three live neighbours lives on to the next generation.
          if (IsLiveCell(_grid[row, column]) && (numberOfLiveNeighbours.Equals(3) || numberOfLiveNeighbours.Equals(2)))
          {
            CoordinatesOfCellsToAlive.Add(new Index(row, column));
          }
          // Any dead cell with exactly three live neighbours becomes a live cell.
          if (!IsLiveCell(_grid[row, column]) && numberOfLiveNeighbours.Equals(3))
          {
            CoordinatesOfCellsToAlive.Add(new Index(row, column));
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
