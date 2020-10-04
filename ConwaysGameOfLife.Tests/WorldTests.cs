using System;
using Xunit;
using System.Collections;
using System.Collections.Generic;

namespace ConwaysGameOfLife.Tests
{
  public class WorldTests
  {

    [Fact]
    public void Can_Create_Dead_World()
    {
      var world = new World(10, 10);

      var result = world.IsDeadWorld();

      Assert.True(result);
    }

    [Fact]
    public void Can_Populate_World_With_List_Of_Coordinates()
    {
      var world = new World(10, 10);

      Assert.True(world.IsDeadWorld());

      var coordinatesToPopulateList = new List<Coordinates> { new Coordinates(0, 0), new Coordinates(0, 1) };

      world.PopulateGrid(coordinatesToPopulateList);

      Assert.False(world.IsDeadWorld());
    }



    //concerns abt this test. need to find better way to compare
    [Fact]
    public void OnTickShouldChange()
    {
      var world = new World(10, 10);
      var coords = "3,3 4,3 5,3";

      var coordinateList = Coordinates.DigestCoordinates(coords);
      world.PopulateGrid(coordinateList);

      var gridBefore = world.GetGrid();

      world.Tick();
      var gridAfter = world.GetGrid();
      //problems with this test again regarding references/ getGrid
      Assert.NotEqual(gridBefore, world.GetGrid());
    }

    [Fact]
    public void Should_Be_Able_To_Determine_Number_Of_Live_Neighbours()
    {
      var world = new World(10, 10);
      var coordinatesToPopulateList = new List<Coordinates> { new Coordinates(4, 4), new Coordinates(4, 5), new Coordinates(4, 6) };
      world.PopulateGrid(coordinatesToPopulateList);

      var neighboursList = world.GetCellsNeighbours(4, 5);
      var numberOfLiveNeighbours = world.LiveNeighbourCount(world.GetGrid(), neighboursList);

      Assert.Equal(2, numberOfLiveNeighbours);
    }

    [Fact]
    public void Any_Live_Cell_With_Two_Live_Neighbours_Lives()
    {
      var world = new World(10, 10);
      var coordinatesToPopulateList = new List<Coordinates> { new Coordinates(1, 5), new Coordinates(1, 6), new Coordinates(1, 7) };
      world.PopulateGrid(coordinatesToPopulateList);


      world.Tick();

      Assert.True(world.IsLiveCell(world.GetGrid()[1, 6]));
    }

    [Fact]
    public void Any_Live_Cell_With_Three_Live_Neighbours_Lives()
    {
      var world = new World(10, 10);
      var coordinatesToPopulateList = new List<Coordinates> { new Coordinates(1, 5), new Coordinates(1, 6), new Coordinates(1, 7), new Coordinates(0, 6) };
      world.PopulateGrid(coordinatesToPopulateList);

      world.Tick();

      Assert.True(world.IsLiveCell(world.GetGrid()[1, 6]));
    }


    [Fact]
    public void Any_Live_Cell_With_Fewer_Than_Two_Live_Neighbours_Dies()
    {
      var world = new World(10, 10);
      var coordinatesToPopulateList = new List<Coordinates> { new Coordinates(4, 4), new Coordinates(4, 5), new Coordinates(4, 6) };
      world.PopulateGrid(coordinatesToPopulateList);

      Assert.True(world.IsLiveCell(world.GetGrid()[4, 4]));

      world.Tick();

      var updatedCellGrid = world.GetGrid();

      Assert.False(world.IsLiveCell(updatedCellGrid[4, 4]));
    }

    [Fact]
    static void Any_Live_Cell_With_More_Than_Three_Live_Neighbours_Dies()
    {
      var world = new World(10, 10);
      var coordinatesToPopulateList = new List<Coordinates> { new Coordinates(4, 4), new Coordinates(4, 5), new Coordinates(4, 6), new Coordinates(5, 3), new Coordinates(5, 4), new Coordinates(5, 5) };
      world.PopulateGrid(coordinatesToPopulateList);

      Assert.True(world.IsLiveCell(world.GetGrid()[4, 4]));

      world.Tick();

      Assert.False(world.IsLiveCell(world.GetGrid()[4, 4]));

    }

    [Fact]
    static void Any_Dead_Cell_With_Exactly_Three_Live_Neighbours_Becomes_Live()
    {
      var world = new World(10, 10);
      var coordinatesToPopulateList = new List<Coordinates> { new Coordinates(4, 4), new Coordinates(4, 5), new Coordinates(4, 6), new Coordinates(5, 3), new Coordinates(5, 4), new Coordinates(5, 5) };
      world.PopulateGrid(coordinatesToPopulateList);


      world.Tick();
      var grid = world.GetGrid();

      Assert.True(world.IsLiveCell(grid[5, 6]));

    }
    [Fact]
    static void Neighbours_Should_Wrap_Over_On_Y_Axis()
    {
      var world = new World(10, 10);

      var neighboursList = world.GetCellsNeighbours(0, 1);

      Assert.Contains(new Coordinates(9, 1), neighboursList);

    }

    [Fact]
    static void Neighbours_Should_Wrap_Over_On_X_Axis()
    {
      var world = new World(10, 10);
  
      var neighboursList = world.GetCellsNeighbours(1, 0);

      Assert.Contains(new Coordinates(1, 9), neighboursList);
    }


  }
}
