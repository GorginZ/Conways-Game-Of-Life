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

      var coordinatesToPopulateList = new List<Coordinate> { new Coordinate(0, 0), new Coordinate(0, 1) };

      world.PopulateGrid(coordinatesToPopulateList);

      Assert.False(world.IsDeadWorld());
    }


    [Fact]
    public void Can_Determine_Number_Of_Live_Neighbours()
    {
      var world = new World(10, 10);
      var coordinatesToPopulateList = new List<Coordinate> { new Coordinate(4, 4), new Coordinate(4, 5), new Coordinate(4, 6) };
      world.PopulateGrid(coordinatesToPopulateList);

      var neighboursList = world.GetListOfCoordinatesForThisCellsNeighbours(4, 5);
      var numberOfLiveNeighbours = world.LiveNeighbourCount(world.GetGrid(), neighboursList);

      Assert.Equal(2, numberOfLiveNeighbours);
    }

    [Fact]
    public void Any_Live_Cell_With_Two_Live_Neighbours_Lives()
    {
      var world = new World(10, 10);
      var coordinatesToPopulateList = new List<Coordinate> { new Coordinate(1, 5), new Coordinate(1, 6), new Coordinate(1, 7) };
      world.PopulateGrid(coordinatesToPopulateList);


      world.Tick();

      Assert.True(world.IsLiveCell(world.GetGrid()[1, 6]));
    }

    [Fact]
    public void Any_Live_Cell_With_Three_Live_Neighbours_Lives()
    {
      var world = new World(10, 10);
      var coordinatesToPopulateList = new List<Coordinate> { new Coordinate(1, 5), new Coordinate(1, 6), new Coordinate(1, 7), new Coordinate(0, 6) };
      world.PopulateGrid(coordinatesToPopulateList);

      world.Tick();

      Assert.True(world.IsLiveCell(world.GetGrid()[1, 6]));
    }


    [Fact]
    public void Any_Live_Cell_With_Fewer_Than_Two_Live_Neighbours_Dies()
    {
      var world = new World(10, 10);
      var coordinatesToPopulateList = new List<Coordinate> { new Coordinate(4, 4), new Coordinate(4, 5), new Coordinate(4, 6) };
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
      var coordinatesToPopulateList = new List<Coordinate> { new Coordinate(4, 4), new Coordinate(4, 5), new Coordinate(4, 6), new Coordinate(5, 3), new Coordinate(5, 4), new Coordinate(5, 5) };
      world.PopulateGrid(coordinatesToPopulateList);

      Assert.True(world.IsLiveCell(world.GetGrid()[4, 4]));

      world.Tick();

      Assert.False(world.IsLiveCell(world.GetGrid()[4, 4]));

    }

    [Fact]
    static void Any_Dead_Cell_With_Exactly_Three_Live_Neighbours_Becomes_Live()
    {
      var world = new World(10, 10);
      var coordinatesToPopulateList = new List<Coordinate> { new Coordinate(4, 4), new Coordinate(4, 5), new Coordinate(4, 6), new Coordinate(5, 3), new Coordinate(5, 4), new Coordinate(5, 5) };
      world.PopulateGrid(coordinatesToPopulateList);


      world.Tick();
      var grid = world.GetGrid();

      Assert.True(world.IsLiveCell(grid[5, 6]));

    }
    [Fact]
    static void Neighbours_Should_Wrap_Over_On_Y_Axis()
    {
      var world = new World(10, 10);

      var neighboursList = world.GetListOfCoordinatesForThisCellsNeighbours(0, 1);

      Assert.Contains(new Coordinate(9, 1), neighboursList);

    }

    [Fact]
    static void Neighbours_Should_Wrap_Over_On_X_Axis()
    {
      var world = new World(10, 10);
  
      var neighboursList = world.GetListOfCoordinatesForThisCellsNeighbours(1, 0);

      Assert.Contains(new Coordinate(1, 9), neighboursList);
    }


  }
}
