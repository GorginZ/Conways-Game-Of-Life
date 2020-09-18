using System.Collections.Generic;

namespace ConwaysGameOfLife
{
  public class Coordinates
  {
    public int Row;
    public int Column;

    public static List<Coordinates> DigestCoordinates(string coordString)
    {
      var coordinatesList = new List<Coordinates>();
      var coordinates = coordString.Split(" ");
      foreach (string coord in coordinates)
      {
        var rowTryParse = int.TryParse(coord[0].ToString(), out int row);
        var colTryParse = int.TryParse(coord[2].ToString(), out int col);

        if (rowTryParse && colTryParse)
        {
          coordinatesList.Add(new Coordinates { Row = row, Column = col });
        }
      }
      return coordinatesList;
    }

  }
}

