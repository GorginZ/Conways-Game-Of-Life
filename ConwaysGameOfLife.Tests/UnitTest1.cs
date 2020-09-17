using System;
using Xunit;

namespace ConwaysGameOfLife.Tests
{
  public class UnitTest1
  {
    [Fact]
    public void ShouldGenerateGridWithSpecifiedDimensions()
    {
      var game = new World(5, 10);

      var grid = game.Grid;

      var gridRows = grid.GetLength(0);
      var gridCols = grid.GetLength(1);

      var expectedRows = 5;
      var expectedCols = 10;

      Assert.Equal(expectedRows, gridRows);
      Assert.Equal(expectedCols, gridCols);

    }

    [Fact]
    public void CanCreateDeadWorld()
    {
      var world = new World(10, 10);

      var result = world.IsDeadWorld();

      Assert.True(result);
    }

    [Fact]
    public void CanPopulateWorld()
    {
      var world = new World(10, 10);
      var coords = "4,4 4,5 4,6";

      world.Populate(coords);

      var result = world.IsDeadWorld();

      Assert.False(result);

    }

    [Fact]
    public void WillPopulateAndNotBreakIfOutOfBoundsCoordsInInput()
    {
      var world = new World(5, 5);
      var coords = "4,4 4,5 4,9";

      world.Populate(coords);

      var result = world.IsDeadWorld();

      Assert.False(result);
      //could also check to make sure only populates one cell, but mostly about it not crashing

    }

    // [Fact]
    // public void ForSteppingThroughPrintWorld()
    // {
    //   var world = new World(5, 10);
    //   world.PrintWorld();
    //   var coords = "4,4 4,5 4,9";

    //   world.Populate(coords);

    //   var result = world.IsDeadWorld();

    //   Assert.True(result);
    // }

    [Fact]
    public void OnTickShouldChange()
    {
      var world = new World(10, 10);
      var coords = "0,0 0,1 0,2 4,4 4,5 4,6";

      world.Populate(coords);
      var initialGrid = world.Grid;
      world.Tick();
      var transformedGrid = world.Grid;

      Assert.NotEqual(initialGrid, transformedGrid);
    }

    [Fact]
    public void ShouldSayHowManyNeighboursAreAlive()
    {
      var world = new World(10, 10);
      var coords = "4,4 4,5 4,6";

      world.Populate(coords);
      var neighbours = world.NeighbourCount(4, 5);

      Assert.Equal(2, neighbours);
    }

    [Fact]
    public void ShouldReproduceOscilatingPattern()
    {
      var coords = "3,3 4,3 5,3";
      var world = new World(10, 10);

      world.Populate(coords);

      Assert.Equal(1, world.Grid[3, 3]);
      Assert.Equal(1, world.Grid[4, 3]);
      Assert.Equal(1, world.Grid[5, 3]);

      Assert.Equal(0, world.Grid[4, 2]);
      Assert.Equal(1, world.Grid[4, 3]);
      Assert.Equal(0, world.Grid[4, 4]);

      world.Tick();

      Assert.Equal(0, world.Grid[3, 3]);
      Assert.Equal(1, world.Grid[4, 3]);
      Assert.Equal(0, world.Grid[5, 3]);

      Assert.Equal(1, world.Grid[4, 2]);
      Assert.Equal(1, world.Grid[4, 3]);
      Assert.Equal(1, world.Grid[4, 4]);

      world.Tick();

      Assert.Equal(1, world.Grid[3, 3]);
      Assert.Equal(1, world.Grid[4, 3]);
      Assert.Equal(1, world.Grid[5, 3]);

      Assert.Equal(0, world.Grid[4, 2]);
      Assert.Equal(1, world.Grid[4, 3]);
      Assert.Equal(0, world.Grid[4, 4]);
    }


    // [Fact]
    // public void BoolToDetermineIfCellHasTooFewNeighboursAndWillDie()
    // {
    //   var world = new World(10, 10);
    //   var coords = "4,4 4,5 4,6";
    //   world.Populate(coords);

    //   // var result = world.LiveCellHasTooFewNeighbours(world.Grid[4,4]);

    //   Assert.True(result);
    // }

    // [Fact]
    // public void CellWithLessThanTwoLiveNeighboursDies()
    // {
    //   // Any live cell with fewer than two live neighbours dies, as if caused by underpopulation.

    //   var world = new World(10, 10);
    //   var coords = "4,4 4,5 4,6";
    //   world.Populate(coords);

    //   var initialGrid = world.Grid;
    //   // var initialStateOfCellFourFour = world.Grid[4,4];
    //   world.Tick();
    //   var transformedGrid = world.Grid;

    //   var result = world.IsLiveCell(world.Grid[4,4]);

    //   // var transformedStateOfCellFourFour = world.Grid[4,4];

    //   Assert.False(result);

    // }



    // Any live cell with more than three live neighbours dies, as if by overcrowding.
    // Any live cell with two or three live neighbours lives on to the next generation.
    // Any dead cell with exactly three live neighbours becomes a live cell.

  }
}
