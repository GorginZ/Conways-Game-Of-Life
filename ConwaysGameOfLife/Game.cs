using System.Collections.Generic;
namespace ConwaysGameOfLife
{
  public class Game
  {
    // public int[,] Grid {get;}
    private int[,] _grid = {

      };

    public Game()
    {
      _grid = BuildGrid();
    }

    public int[,] BuildGrid()
    {
      int[,] _grid = {
{0,0,0,0,0,0,0,0,0,0},
{0,0,0,0,0,0,0,0,0,0},
{0,0,0,0,0,0,0,0,0,0},
{0,0,0,0,0,0,0,0,0,0},
{0,0,0,0,1,1,1,0,0,0},
{0,0,0,0,0,0,0,0,0,0},
{0,0,0,0,0,0,0,0,0,0},
{0,0,0,0,0,0,0,0,0,0},
{0,0,0,0,0,0,0,0,0,0},
{0,0,0,0,0,0,0,0,0,0}

      };
      return _grid;
    }

    public int[,] GetGrid()
    {
      return _grid;
    }

    public void Tick()
    {
      
    }

  }


}