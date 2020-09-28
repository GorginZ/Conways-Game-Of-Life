using System.Collections.Generic;

namespace ConwaysGameOfLife
{
  public class Grid
  {
    public CellState[,] CellGrid;


    public Grid(int rowDimension, int columnDimension)
    {
      CellGrid = BuildGrid(rowDimension, columnDimension);
    }

    public int RowCount => CellGrid.GetLength(0);
    public int ColumnCount => CellGrid.GetLength(1);

    public CellState[,] BuildGrid(int rowDimension, int columnDimension)
    {
      var grid = new CellState[rowDimension, columnDimension];

      return grid;
    }


    public void PopulateGrid(List<Coordinates> coordinates)
    {
      foreach (Coordinates coordinate in coordinates)
      {
        if (coordinate.Column < ColumnCount && coordinate.Row < RowCount)
        {
          CellGrid[coordinate.Row, coordinate.Column] = CellState.Alive;
        }
      }
    }


  }
}