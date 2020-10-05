using System.Collections.Generic;
using Xunit;

namespace ConwaysGameOfLife.Tests
{
  public class GridTests
  {

    [Fact]
    public void Can_Generate_Grid_Of_A_Specified_Type()
    {
      var grid = new Grid<int>(5, 10);

      Assert.IsType<int>(grid[0,0]);
    }
    
    [Fact]
    public void Should_Generate_Grid_With_Specified_Dimensions()
    {
      var grid = new Grid<CellState>(5, 10);

      Assert.Equal(5, grid.RowCount);
      Assert.Equal(10, grid.ColumnCount);
    }
    [Fact]
    public void Can_Manipulate_Grid_Cells_At_Specified_Input_Coordinates()
    {
      var grid = new Grid<CellState>(5, 5);

      var listOfCoordinatesToManipulate = new List<Coordinate> { new Coordinate(0, 0), new Coordinate(0, 1) };

      grid.SetMany(listOfCoordinatesToManipulate, CellState.Alive);

      Assert.Equal(CellState.Alive, grid[0, 0]);

    }
    [Fact]
    public void If_Input_Coordinate_Out_Of_Range_Will_Ignore_And_Still_Manipulate_Other_Grid_Cells()
    {
      var grid = new Grid<CellState>(5, 5);

      var listOfCoordinatesToManipulate = new List<Coordinate> { new Coordinate(4, 4), new Coordinate(4, 9) };

      grid.SetMany(listOfCoordinatesToManipulate, CellState.Alive);

      Assert.Equal(CellState.Alive, grid[4, 4]);

    }

  }
}