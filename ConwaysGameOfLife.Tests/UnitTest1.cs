using System;
using Xunit;
using System.Collections;
using System.Collections.Generic;

namespace ConwaysGameOfLife.Tests
{
  public class UnitTest1
  {

    // [Fact]
    // public void ShouldGenerateGridWithSpecifiedDimensions()
    // {
    //   var game = new World(5, 10);

    //   var grid = game.Grid.CellGrid;

    //   var gridRows = grid.GetLength(0);
    //   var gridCols = grid.GetLength(1);

    //   var expectedRows = 5;
    //   var expectedCols = 10;

    //   Assert.Equal(expectedRows, gridRows);
    //   Assert.Equal(expectedCols, gridCols);
    // }

    // [Fact]
    // public void CanCreateDeadWorld()
    // {
    //   var world = new World(10, 10);

    //   var result = world.IsDeadWorld();

    //   Assert.True(result);
    // }

    [Fact]
    public void Can_Populate_World()
    {
      var world = new World(10, 10);
      var coords = "0,0 4,4 4,5 4,9";
      var coordinateList = Coordinates.DigestCoordinates(coords);
      world.PopulateGrid(coordinateList);


      var result = world.IsDeadWorld();

      Assert.False(result);

    }

    // [Fact]
    // public void Will_Populate_And_Not_Break_If_Out_Of_Bounds_Coords_In_Input()
    // {
    //   var world = new World(5, 5);
    //   var coords = "4,4 4,5 4,9";

    //   var coordinateList = Coordinates.DigestCoordinates(coords);
    //   world.Populate(coordinateList);

    //   var result = world.IsDeadWorld();

    //   Assert.False(result);
    //   //could also check to make sure only populates one cell, but mostly about it not crashing

    // }

    [Fact]
    public void OnTickShouldChange()
    {
      var world = new World(10, 10);
      var coords = "3,3 4,3 5,3";

      var coordinateList = Coordinates.DigestCoordinates(coords);
      world.PopulateGrid(coordinateList);


      // var gridCopy = world._grid.Clone() as CellState[,];

      var gridBefore = world.GetGrid();

      world.Tick();
      var gridAfter = world.GetGrid();
      Assert.NotEqual(gridBefore, world.GetGrid());
    }

    // [Fact]
    // public void ShouldSayHowManyNeighboursAreAlive()
    // {
    //   var world = new World(10, 10);
    //   var coords = "4,4 4,5 4,6";

    //   var coordinateList = Coordinates.DigestCoordinates(coords);
    //   world.Populate(coordinateList);

    //   var neighboursList = world.GetNeighbours(4, 5);
    //   var numberOfLiveNeighbours = world.LiveNeighbourCount(world._grid, neighboursList);

    //   Assert.Equal(2, numberOfLiveNeighbours);
    // }

    // [Fact]
    // public void Any_Live_Cell_With_Two_Live_Neighbours_Lives()
    // {
    //   var coords = "1,5 1,6, 1,7";
    //   var world = new World(10, 10);

    //   var coordinateList = Coordinates.DigestCoordinates(coords);
    //   world.Populate(coordinateList);

    //   world.Tick();
    //   Assert.True(world.IsLiveCell(world._grid[1, 6]));
    // }

    // [Fact]
    // public void Any_Live_Cell_With_Three_Live_Neighbours_Lives()
    // {
    //   var coords = "1,5 1,6, 1,7 0,6";
    //   var world = new World(10, 10);

    //   var coordinateList = Coordinates.DigestCoordinates(coords);
    //   world.Populate(coordinateList);

    //   world.Tick();
    //   Assert.True(world.IsLiveCell(world._grid[1, 6]));
    // }


    // [Fact]
    // public void Any_Live_Cell_With_Fewer_Than_Two_Live_Neighbours_Dies()
    // {
    //   var world = new World(10, 10);
    //   var coords = "4,4 4,5 4,6";
    //   var coordinateList = Coordinates.DigestCoordinates(coords);
    //   world.Populate(coordinateList);


    //   Assert.True(world.IsLiveCell(world._grid[4, 4]));

    //   world.Tick();

    //   Assert.False(world.IsLiveCell(world._grid[4, 4]));
    // }

    // [Fact]
    // static void Any_Live_Cell_With_More_Than_Three_Live_Neighbours_Dies()
    // {
    //   var world = new World(10, 10);
    //   var coords = "4,4 4,5 4,6 5,3 5,4 5,5";
    //   var coordinateList = Coordinates.DigestCoordinates(coords);
    //   world.Populate(coordinateList);


    //   Assert.True(world.IsLiveCell(world._grid[4, 4]));

    //   world.Tick();

    //   Assert.False(world.IsLiveCell(world._grid[4, 4]));

    // }

    // [Fact]
    // static void Any_Dead_Cell_With_Exactly_Three_Live_Neighbours_Becomes_Live()
    // {
    //   var world = new World(10, 10);
    //   var coords = "4,4 4,5 4,6 5,3 5,4 5,5";
    //   var coordinateList = Coordinates.DigestCoordinates(coords);
    //   world.Populate(coordinateList);


    //   world.Tick();

    //   Assert.True(world.IsLiveCell(world._grid[5, 6]));

    // }
    // [Fact]
    // static void Neighbours_Should_Wrap_Over_On_Y_Axis()
    // {
    //   var world = new World(10, 10);
    //   var coords = "0,0 0,1 0,2";
    //   var coordinateList = Coordinates.DigestCoordinates(coords);
    //   world.Populate(coordinateList);
    //   var neighboursList = world.GetNeighbours(0, 1);

    //   Assert.Contains(new Coordinates(9,1), neighboursList);

    // }

    // [Fact]
    // static void Neighbours_Should_Wrap_Over_On_X_Axis()
    // {
    //   var world = new World(10, 10);
    //   var coords = "0,0 1,0 2,0";
    //   var coordinateList = Coordinates.DigestCoordinates(coords);
    //   world.Populate(coordinateList);
    //   var neighboursList = world.GetNeighbours(1, 0);

    //   Assert.Contains(new Coordinates (1,9), neighboursList);
    // }


  }
}
