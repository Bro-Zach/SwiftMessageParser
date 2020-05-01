using SwiftMessageParser.Extensions;

namespace SwiftMessageParser.Entities.MT.Tags
{
  public class PatternPrecedingSlash : Tag, ITag
  {
    public ITag GetTagValues(string resultText)
    {
      this.GetTagName(resultText);
      this.Value = resultText.ToEndOfString("/").Trim();
      return (ITag) this;
    }
  }
}
