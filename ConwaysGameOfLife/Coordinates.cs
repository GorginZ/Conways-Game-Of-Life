using System.Collections.Generic;

namespace ConwaysGameOfLife
{
  public struct Coordinate
  {
    public int Row;
    public int Column;

    public Coordinate(int row, int column)
    {
      Row = row;
      Column = column;
    }
// should coordinates be a data structure? Should I remove 'behaviour'

    // public static List<Coordinate> DigestCoordinates(string coordinatesString)
    // {
    //   var coordinatesList = new List<Coordinate>();
    //   var coordinates = coordinatesString.Split(" ");
    //   foreach (string coord in coordinates)
    //   {
    //     var rowTryParse = int.TryParse(coord[0].ToString(), out int row);
    //     var colTryParse = int.TryParse(coord[2].ToString(), out int column);

    //     if (rowTryParse && colTryParse)
    //     {
    //       coordinatesList.Add(new Coordinate (row, column));
    //     }
    //   }
    //   return coordinatesList;
    // }

  }
}

