using System;

namespace ConwaysGameOfLife
{
  public class OutPut : IWrite
  {
    private string _introMessage = "Welcome to Conways Game of Life.\n \n John Horton Conway has contributed immensely to many fields of mathematical theory and his Game of Life is one of his most famous and fun contributions which presents fun and interesting challenges for programmers and captures interest beyond those already enaged in mathematical theory. \n \n John Conway passed away in April 2020 just three days after developing COVID19 symptoms. This is a huge loss to the mathematical community and to the world more broadly. RIP John Conway. \n\n In the Game of Life we set a world of cells and apply a series of rules to them in each 'tick', the tick represents the discrete moment in time where the state of the world changes. This tick changes the state, living or dead, of all of the cells.\n\n the rules: \n\n 1. Any live cell with fewer than two live neighbours dies, as if by underpopulation. \n 2. Any live cell with two or three live neighbours lives on to the next generation. \n 3. Any live cell with more than three live neighbours dies, as if by overpopulation. \n 4. Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction. \n\n You will set dimensions of the world and the initial state of the cells by selecting coordinates and watch how they behave.";

    private string _rowPrompt = "How many rows in the world?";
    private string _columnPrompt = "How many columns in the world?";


    public string WriteOutput()
    {
      return 
    }
  }
}