using SwiftMessageParser.Extensions;

namespace SwiftMessageParser.Entities.MT.Tags
{
  public class PatternOptionalSubFunction : Tag, ITag
  {
    public ITag GetTagValues(string resultText)
    {
      this.GetTagName(resultText);
      if (resultText.Contains("/"))
      {
        this.Value = resultText.Between(this.TagName + ":", "/");
        this.Code = resultText.ParseWithStringAndIndex(this.Value + "/", 4).Trim();
      }
      else
        this.Value = resultText.ToEndOfString(this.TagName + ":").TrimColon().Trim();
      return (ITag) this;
    }
  }
}
