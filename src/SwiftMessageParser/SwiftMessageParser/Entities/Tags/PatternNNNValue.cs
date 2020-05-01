using SwiftMessageParser.Extensions;

namespace SwiftMessageParser.Entities.MT.Tags
{
  public class PatternNNNValue : Tag, ITag
  {
    public ITag GetTagValues(string resultText)
    {
      this.GetTagName(resultText);
      this.Qualifier = resultText.ParseWithStringAndIndex(this.TagName + ":", 3);
      this.Value = resultText.ToEndOfString(this.Qualifier).Trim();
      return (ITag) this;
    }
  }
}
