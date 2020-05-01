using SwiftMessageParser.Extensions;

namespace SwiftMessageParser.Entities.MT.Tags
{
  public class PatternQualifierSlashCurrencyAmount : Tag, ITag
  {
    public ITag GetTagValues(string resultText)
    {
      this.GetTagName(resultText);
      if (resultText.Contains("//"))
      {
        this.Qualifier = resultText.ParseFromString(this.TagName + ":", "/");
        this.Code = resultText.ParseWithStringAndIndex(this.Qualifier + "//", 3);
        this.Value = resultText.ToEndOfString(this.Code);
      }
      else
      {
        this.Qualifier = resultText.ParseFromString(this.TagName + ":", "/");
        this.Code = resultText.ParseWithStringAndIndex(this.Qualifier + "/", 3);
        this.Value = resultText.ToEndOfString(this.Code);
      }
      return (ITag) this;
    }
  }
}
