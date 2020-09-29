using System;
using System.Collections.Generic;


namespace ConwaysGameOfLife
{
  public class Grid<TItemType>
  {
    public readonly TItemType[,] _cellGrid;

    public Grid(int rowDimension, int columnDimension)
    {
      _cellGrid = new TItemType[rowDimension, columnDimension];
    }

    public int RowCount => _cellGrid.GetLength(0);
    public int ColumnCount => _cellGrid.GetLength(1);

    public TItemType this[int row, int column]
    {
      get => _cellGrid[row, column];
      set => _cellGrid[row, column] = value;
    }

    public TItemType this[Coordinates coordinates]
    {
      get => _cellGrid[coordinates.Row, coordinates.Column];
      set => _cellGrid[coordinates.Row, coordinates.Column] = value;
    }

    public void SetMany(List<Coordinates> coordinatesToSet, TItemType value)
    {
      foreach (Coordinates coordinate in coordinatesToSet)
      {
        if (coordinate.Column < ColumnCount && coordinate.Row < RowCount)
        {
          this[coordinate] = value;
        }
      }
    }

    public Grid<TItemType> CloneGrid()
    {

      // CellState[,] gridCopy = _grid.Clone(_grid) as CellState[,];

      var CloneGrid = _cellGrid.Clone() as Grid<TItemType>;
      return CloneGrid;
    }

    // public Grid<TItemType> CloneGrid(Grid<TItemType>[,] grid)
    // {
    //   var clone = new Grid<TItemType>(grid.GetLength(0), grid.GetLength(1));

    //   for (int i = 0; i < grid.GetLength(0); i++)
    //   {
    //     for (int j = 0; j < grid.GetLength(1); j++)
    //     {
    //       clone._cellGrid[i,j] = grid[i,j];
    //     }
    //   }
    //   return clone;
    // }
  }
}