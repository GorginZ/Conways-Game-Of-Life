using System;
using Xunit;

namespace ConwaysGameOfLife.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void OnTickShouldChange()
        {
          var game = new Game();

          var initialGrid = game.GetGrid();
          game.Tick();
          var transformedGrid = game.GetGrid();

          Assert.NotEqual(initialGrid, transformedGrid);
        }
    }
}
