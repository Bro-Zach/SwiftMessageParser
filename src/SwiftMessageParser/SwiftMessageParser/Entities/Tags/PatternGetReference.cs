using SwiftMessageParser.Extensions;

namespace SwiftMessageParser.Entities.MT.Tags
{
  public class PatternGetReference : Tag, ITag
  {
    public ITag GetTagValues(string resultText)
    {
      this.GetTagName(resultText);
      if (resultText.Contains("::"))
        this.Value = resultText.ToEndOfString(this.TagName + "::").TrimAllNewLines();
      else
        this.Value = resultText.ToEndOfString(this.TagName + ":").TrimAllNewLines();
      return (ITag) this;
    }
  }
}
