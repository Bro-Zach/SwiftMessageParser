using SwiftMessageParser.Extensions;

namespace SwiftMessageParser.Entities.MT.Tags
{
  public class PatternYYMMDDCurrencyAmount : Tag, ITag
  {
    public ITag GetTagValues(string resultText)
    {
      this.GetTagName(resultText);
      this.Qualifier = resultText.Substring(5, 6);
      this.Code = resultText.Substring(11, 3);
      this.Value = resultText.ToEndOfString(this.Code).Trim();
      return (ITag) this;
    }
  }
}
