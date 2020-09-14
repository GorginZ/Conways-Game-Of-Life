using System;
using Xunit;

namespace ConwaysGameOfLife.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void OnTickShouldChange()
        {
          var game = new Game(10,10);

          var initialGrid = game.GetGrid();
          game.Tick();
          var transformedGrid = game.GetGrid();

          Assert.NotEqual(initialGrid, transformedGrid);
        }

        [Fact]
        public void ShouldGenerateGridWithSpecifiedDimensions()
        {
          var game = new Game(10,10);

          var grid = game.GetGrid();

          var gridRows = grid.GetLength(1);
          var gridCols = grid.GetLength(0);

          var expectedRows = 10;
          var expectedCols = 10;

          Assert.Equal(expectedRows, gridRows);
          Assert.Equal(expectedCols, gridCols);


        }
    }
}
