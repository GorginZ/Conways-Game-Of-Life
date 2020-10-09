using System;
using System.Collections.Generic;

namespace ConwaysGameOfLife
{
  public class UserInput : IRead
  {
    public string ReadConsole => Console.ReadLine();


   public string ReadInput()
    {
      return ReadConsole;
    }




 
  }
}