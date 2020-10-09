using System.Collections.Generic;

namespace ConwaysGameOfLife
{
  public static class InputParser
  {
    public static bool TryParseInputIndexes(string input, out List<Index> indexList)
    {

      indexList = new List<Index>();

      if (input.Length < 3)
      {
        return false;
      }
      var indexs = input.Split(" ");
      int indexCount = indexs.GetLength(0);

      foreach (string index in indexs)
      {
        var rowTryParse = int.TryParse(index[0].ToString(), out int row);
        var colTryParse = int.TryParse(index[2].ToString(), out int column);

        if (rowTryParse && colTryParse)
        {
          indexList.Add(new Index(row, column));
        }
      }
      if (indexList.Count == indexCount)
      {
        return true;
      }
      return false;
    }

    public static bool TryParseDimensions(string inputDimension, out int dimension)
    {
      if (int.Parse(inputDimension) < 100 && int.Parse(inputDimension) > 3)
      {
        dimension = int.Parse(inputDimension);
        return true;
      }
      else
      {
        dimension = 0;
        return false;
      }


    }


  }
}