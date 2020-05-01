using SwiftMessageParser.Extensions;

namespace SwiftMessageParser.Entities.MT.Tags
{
  public class PatternDoubleSlashSeperator : Tag, ITag
  {
    public ITag GetTagValues(string resultText)
    {
      this.GetTagName(resultText);
      if (resultText.Contains("::"))
      {
        this.Qualifier = resultText.Between(this.TagName + "::", "/").Trim();
        this.Value = resultText.ToEndOfString("//").TrimAllNewLines();
      }
      else
      {
        this.Qualifier = resultText.Between(this.TagName + ":", "/").Trim();
        this.Value = resultText.ToEndOfString("//").TrimAllNewLines();
      }
      return (ITag) this;
    }
  }
}
