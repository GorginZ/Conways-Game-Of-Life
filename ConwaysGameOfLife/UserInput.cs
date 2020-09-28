using System;

namespace ConwaysGameOfLife
{
  public class UserInput
  {
    public int UserInputValue => int.Parse(Console.ReadLine());

    public string UserInputCoordinates => Console.ReadLine();

  }
}