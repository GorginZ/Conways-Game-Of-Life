using System.Collections.Generic;
namespace ConwaysGameOfLife
{
  public class Game
  {
    private int[,] _grid = {

      };

    public Game(int rows, int columns)
    {
      _grid = BuildGrid(rows, columns);
    }

    public int[,] BuildGrid(int rows, int columns)
    {
      int[,] _grid = new int[rows, columns];

      return _grid;
    }

    public int[,] TenByTenGridFactory()
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