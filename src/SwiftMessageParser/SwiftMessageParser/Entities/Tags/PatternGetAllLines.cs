using SwiftMessageParser.Extensions;

namespace SwiftMessageParser.Entities.MT.Tags
{
  public class PatternGetAllLines : Tag, ITag
  {
    public ITag GetTagValues(string resultText)
    {
      this.GetTagName(resultText);
      this.Value = resultText.ToEndOfString(this.TagName + ":").TrimAllNewLines();
      return (ITag) this;
    }
  }
}
