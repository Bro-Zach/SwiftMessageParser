using SwiftMessageParser.Extensions;

namespace SwiftMessageParser.Entities.MT.Tags
{
  public class PatternSignCurrencyAmount : Tag, ITag
  {
    public ITag GetTagValues(string resultText)
    {
      this.GetTagName(resultText);
      if (resultText.Contains("+") || resultText.Contains("-"))
      {
        this.Qualifier = resultText.Between("::", "/");
        string withStringAndIndex = resultText.ParseWithStringAndIndex("//", 1);
        this.Code = resultText.ParseWithStringAndIndex(withStringAndIndex, 3);
        this.Value = withStringAndIndex + resultText.ToEndOfString(this.Code);
      }
      else
      {
        this.Qualifier = resultText.Between("::", "/");
        this.Code = resultText.ParseWithStringAndIndex("//", 3);
        this.Value = resultText.ToEndOfString(this.Code);
      }
      return (ITag) this;
    }
  }
}
