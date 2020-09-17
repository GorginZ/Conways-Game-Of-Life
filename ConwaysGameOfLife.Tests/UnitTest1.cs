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

    [Fact]
    public void OnTickShouldChange()
    {
      var world = new World(10, 10);
      var coords = "3,3 4,3 5,3";

      world.Populate(coords);

      Assert.Equal(1, world.Grid[3, 3]);
      Assert.Equal(1, world.Grid[4, 3]);
      Assert.Equal(1, world.Grid[5, 3]);

      world.Tick();

      Assert.NotEqual(1, world.Grid[3, 3]);
      Assert.Equal(1, world.Grid[4, 3]);
      Assert.NotEqual(1, world.Grid[5, 3]);

    }

    [Fact]
    public void ShouldSayHowManyNeighboursAreAlive()
    {
      var world = new World(10, 10);
      var coords = "4,4 4,5 4,6";

      world.Populate(coords);
      var neighbours = world.NeighbourCount(world.Grid, 4, 5);

      Assert.Equal(2, neighbours);
    }

    [Fact]

    public void Any_Live_Cell_With_Two_Or_Three_Live_Neighbours_Lives()
    {
      var coords = "3,3 4,3 5,3 1,5 1,6, 1,7";
      var world = new World(10, 10);

      world.Populate(coords);
      var initialFourThree = world.Grid[4, 3];
      var initialOneFive = world.Grid[1, 6];
      world.PrintWorld(world.Grid);
      world.Tick();
      Console.WriteLine();
      world.PrintWorld(world.Grid);
      var transformedFourThree = world.Grid[4, 3];
      var transformedOneFive = world.Grid[1, 6];

      Assert.Equal(initialFourThree, transformedFourThree);
      Assert.Equal(initialOneFive, transformedOneFive);
    }

    [Fact]
    public void ShouldReproduceOscilatingPattern()
    {
      var coords = "3,3 4,3 5,3";
      var world = new World(10, 10);

      world.Populate(coords);
      world.PrintWorld(world.Grid);
      Console.WriteLine();

      Assert.Equal(1, world.Grid[3, 3]);
      Assert.Equal(1, world.Grid[4, 3]);
      Assert.Equal(1, world.Grid[5, 3]);

      Assert.Equal(0, world.Grid[4, 2]);
      Assert.Equal(1, world.Grid[4, 3]);
      Assert.Equal(0, world.Grid[4, 4]);

      world.Tick();
      world.PrintWorld(world.Grid);
      Console.WriteLine();

      Assert.Equal(0, world.Grid[3, 3]);
      Assert.Equal(1, world.Grid[4, 3]);
      Assert.Equal(0, world.Grid[5, 3]);

      Assert.Equal(1, world.Grid[4, 2]);
      Assert.Equal(1, world.Grid[4, 3]);
      Assert.Equal(1, world.Grid[4, 4]);

      world.Tick();
      world.PrintWorld(world.Grid);
      Console.WriteLine();

      Assert.Equal(1, world.Grid[3, 3]);
      Assert.Equal(1, world.Grid[4, 3]);
      Assert.Equal(1, world.Grid[5, 3]);

      Assert.Equal(0, world.Grid[4, 2]);
      Assert.Equal(1, world.Grid[4, 3]);
      Assert.Equal(0, world.Grid[4, 4]);
    }


    [Fact]
    public void Any_Live_Cell_With_Fewer_Than_Two_Live_Neighbours_Dies()
    {
      var world = new World(10, 10);
      var coords = "4,4 4,5 4,6";
      world.Populate(coords);

      Assert.True(world.IsLiveCell(world.Grid[4, 4]));
      Assert.True(world.IsLiveCell(world.Grid[4, 6]));

      world.Tick();

      Assert.False(world.IsLiveCell(world.Grid[4, 4]));
      Assert.False(world.IsLiveCell(world.Grid[4, 6]));

    }



    // Any live cell with more than three live neighbours dies, as if by overcrowding.
    // Any live cell with two or three live neighbours lives on to the next generation.
    // Any dead cell with exactly three live neighbours becomes a live cell.

  }
}
