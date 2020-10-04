using System.Collections.Generic;
using Xunit;

namespace ConwaysGameOfLife.Tests
{
  public class GridTests
  {
    [Fact]
    public void If_Input_Coordinate_Out_Of_Range_Will_Ignore_And_Still_Manipulate_Other_Grid_Cells()
    {
      var grid = new Grid<CellState>(5, 5);

      var listOfCoordinatesToManipulate = new List<Coordinates> { new Coordinates(4, 4), new Coordinates(4, 9) };

      grid.SetMany(listOfCoordinatesToManipulate, CellState.Alive);

      Assert.Equal(CellState.Alive, grid[4, 4]);

    }
  }
}