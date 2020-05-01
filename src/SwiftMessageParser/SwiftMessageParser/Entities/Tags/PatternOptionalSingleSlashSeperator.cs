using SwiftMessageParser.Extensions;

namespace SwiftMessageParser.Entities.MT.Tags
{
  public class PatternOptionalSingleSlashSeperator : Tag, ITag
  {
    public ITag GetTagValues(string resultText)
    {
      this.GetTagName(resultText);
      if (resultText.Contains("/"))
      {
        this.Qualifier = resultText.ParseFromString(this.TagName + ":", "/");
        this.Value = resultText.ToEndOfString(this.Qualifier + "/");
      }
      else
        this.Value = resultText.ToEndOfString(this.TagName + ":");
      return (ITag) this;
    }
  }
}
