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
    public static List<Coordinate> DigestCoordinates(string coordinatesString)
    {
      var coordinatesList = new List<Coordinate>();
      var coordinates = coordinatesString.Split(" ");
      foreach (string coord in coordinates)
      {
        var rowTryParse = int.TryParse(coord[0].ToString(), out int row);
        var colTryParse = int.TryParse(coord[2].ToString(), out int column);

        if (rowTryParse && colTryParse)
        {
          coordinatesList.Add(new Coordinate(row, column));
        }
      }
      return coordinatesList;
    }

 
  }
}