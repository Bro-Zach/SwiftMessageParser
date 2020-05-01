using SwiftMessageParser.Extensions;

namespace SwiftMessageParser.Entities.MT.Tags
{
  public class PatternSingleSlashSeperator : Tag, ITag
  {
    public ITag GetTagValues(string resultText)
    {
      this.GetTagName(resultText);
      this.Qualifier = resultText.ParseFromString(this.TagName + ":", "/");
      this.Value = resultText.ToEndOfString(this.Qualifier + "/");
      return (ITag) this;
    }
  }
}
