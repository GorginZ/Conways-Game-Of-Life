using System;
using Xunit;

namespace ConwaysGameOfLife.Tests
{
  public class AcceptanceTest
  {
    [Fact]
    public void ShouldReproduceOscilatingPatterns()
    {
      var coords = "3,3 4,3 5,3";
      var world = new World(10, 10);

      var coordinateList = Coordinates.DigestCoordinates(coords);
      world.Populate(coordinateList);

      world.PrintWorld(world.Grid);
      Console.WriteLine();

      Assert.True(world.IsLiveCell(world.Grid[3, 3]));
      Assert.True(world.IsLiveCell(world.Grid[4, 3]));
      Assert.True(world.IsLiveCell(world.Grid[5, 3]));

      Assert.False(world.IsLiveCell(world.Grid[4, 2]));
      Assert.True(world.IsLiveCell(world.Grid[4, 3]));
      Assert.False(world.IsLiveCell(world.Grid[4, 4]));

      world.Tick();
      world.PrintWorld(world.Grid);
      Console.WriteLine();

      Assert.False(world.IsLiveCell(world.Grid[3, 3]));
      Assert.True(world.IsLiveCell(world.Grid[4, 3]));
      Assert.False(world.IsLiveCell(world.Grid[5, 3]));

      Assert.True(world.IsLiveCell(world.Grid[4, 2]));
      Assert.True(world.IsLiveCell(world.Grid[4, 3]));
      Assert.True(world.IsLiveCell(world.Grid[4, 4]));

      world.Tick();
      world.PrintWorld(world.Grid);
      Console.WriteLine();

      Assert.True(world.IsLiveCell(world.Grid[3, 3]));
      Assert.True(world.IsLiveCell(world.Grid[4, 3]));
      Assert.True(world.IsLiveCell(world.Grid[5, 3]));

      Assert.False(world.IsLiveCell(world.Grid[4, 2]));
      Assert.True(world.IsLiveCell(world.Grid[4, 3]));
      Assert.False(world.IsLiveCell(world.Grid[4, 4]));
    }
  }
}