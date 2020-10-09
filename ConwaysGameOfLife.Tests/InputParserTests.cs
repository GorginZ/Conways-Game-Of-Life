using System.Collections.Generic;
using Xunit;

namespace ConwaysGameOfLife.Tests
{
  public class InputParserTests
  {
    [Fact]
    public void CanReturnListOfIndexesFromInputString()
    {
      var world = new World(10, 10);

      string inputString = "3";
      List<Index> listOfIndexes;
      InputParser.TryParseInputIndexes(inputString, out listOfIndexes);

      world.PopulateGrid(listOfIndexes);
      var worldGrid = world.GetGrid();

      Assert.True(world.IsLiveCell(worldGrid[0, 0]));
    }
  }
}