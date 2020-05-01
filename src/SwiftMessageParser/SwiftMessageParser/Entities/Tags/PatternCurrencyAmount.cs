using SwiftMessageParser.Extensions;

namespace SwiftMessageParser.Entities.MT.Tags
{
  public class PatternCurrencyAmount : Tag, ITag
  {
    public ITag GetTagValues(string resultText)
    {
      this.GetTagName(resultText);
      this.Code = resultText.ParseWithStringAndIndex(this.TagName + ":", 3);
      this.Value = resultText.ToEndOfString(this.Code).Trim();
      return (ITag) this;
    }
  }
}
