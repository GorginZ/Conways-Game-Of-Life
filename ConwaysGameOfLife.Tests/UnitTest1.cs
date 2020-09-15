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

        public void WillPopulateAndNotBreakIfOutOfBoundsCoordsInInput()
    {
      var world = new World(5, 5);
      var coords = "4,4 4,5 4,9";

      world.Populate(coords);

      var result = world.IsDeadWorld();

      Assert.False(result);
      //could also check to make sure only populates one cell, but mostly about it not crashing

    }

    // populate world with dead cells

    // thinking about representing cells, if alive and if dead

    // test: can put live cells on world

    // world sets specific live cells

    // how does the world take input for where to put live cells

    // what does that input looks 
  }
}
