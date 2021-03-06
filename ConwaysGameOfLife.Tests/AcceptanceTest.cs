using System;
using System.Collections.Generic;
using Xunit;

namespace ConwaysGameOfLife.Tests
{
  public class AcceptanceTest
  {
    [Fact]
    public void ShouldReproduceOscilatingPatterns()
    {
      var coordinates = "3,3 4,3 5,3";
      var world = new World(10, 10);

      List<RowColumn> coordinateList;
      InputParser.TryParseInputIndexes(coordinates, out coordinateList);
      world.PopulateGrid(coordinateList);

      Assert.True(world.IsLiveCell(world.GetGrid()[3, 3]));
      Assert.True(world.IsLiveCell(world.GetGrid()[4, 3]));
      Assert.True(world.IsLiveCell(world.GetGrid()[5, 3]));

      Assert.False(world.IsLiveCell(world.GetGrid()[4, 2]));
      Assert.True(world.IsLiveCell(world.GetGrid()[4, 3]));
      Assert.False(world.IsLiveCell(world.GetGrid()[4, 4]));

      world.Tick();

      Assert.False(world.IsLiveCell(world.GetGrid()[3, 3]));
      Assert.True(world.IsLiveCell(world.GetGrid()[4, 3]));
      Assert.False(world.IsLiveCell(world.GetGrid()[5, 3]));

      Assert.True(world.IsLiveCell(world.GetGrid()[4, 2]));
      Assert.True(world.IsLiveCell(world.GetGrid()[4, 3]));
      Assert.True(world.IsLiveCell(world.GetGrid()[4, 4]));

      world.Tick();

      Assert.True(world.IsLiveCell(world.GetGrid()[3, 3]));
      Assert.True(world.IsLiveCell(world.GetGrid()[4, 3]));
      Assert.True(world.IsLiveCell(world.GetGrid()[5, 3]));

      Assert.False(world.IsLiveCell(world.GetGrid()[4, 2]));
      Assert.True(world.IsLiveCell(world.GetGrid()[4, 3]));
      Assert.False(world.IsLiveCell(world.GetGrid()[4, 4]));
    }
  }
}