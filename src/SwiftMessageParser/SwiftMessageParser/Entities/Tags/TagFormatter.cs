using System.Collections.Generic;

namespace SwiftMessageParser.Entities.MT.Tags
{
  public class TagFormatter
  {
    public List<ITag> MoneyFormatter(List<ITag> listOfTags)
    {
      foreach (ITag listOfTag in listOfTags)
      {
        if (listOfTag.Value.Contains(","))
        {
          if (listOfTag.Value.IndexOf(",") == listOfTag.Value.Length - 1)
          {
            string str = listOfTag.Value.Replace(",", ".00");
            listOfTag.Value = str;
          }
          else
          {
            string str = listOfTag.Value.Replace(",", ".");
            listOfTag.Value = str;
          }
        }
      }
      return listOfTags;
    }
  }
}
