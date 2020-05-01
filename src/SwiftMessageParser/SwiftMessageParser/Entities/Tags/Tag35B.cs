using SwiftMessageParser.Extensions;
using System.Collections.Generic;

namespace SwiftMessageParser.Entities.MT.Tags
{
  public class Tag35B : Tag, ITag
  {
    public ITag GetTagValues(string resultText)
    {
      List<string> stringList = new List<string>();
      if (resultText.Substring(5, 4) == "ISIN")
      {
        this.Qualifier = resultText.Substring(5, 4);
        this.Value = resultText.ParseWithStringAndIndex("ISIN ", 12);
        this.Description = resultText.ToEndOfString(this.Value).Trim();
        this.TagName = "35B";
      }
      else
      {
        this.Qualifier = resultText.ParseWithStringAndIndex(":/", 2);
        this.Value = resultText.ToEndOfString(this.Qualifier + "/");
      }
      return (ITag) this;
    }

    public Tag35B()
    {
      this.TagName = "35B";
    }
  }
}
