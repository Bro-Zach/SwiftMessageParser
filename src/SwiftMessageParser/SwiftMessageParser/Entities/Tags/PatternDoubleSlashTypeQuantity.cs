using SwiftMessageParser.Extensions;

namespace SwiftMessageParser.Entities.MT.Tags
{
  public class PatternDoubleSlashTypeQuantity : Tag, ITag
  {
    public ITag GetTagValues(string resultText)
    {
      this.GetTagName(resultText);
      if (resultText.Contains("::"))
      {
        this.Qualifier = resultText.Between(this.TagName + "::", "/");
        this.Type = resultText.ParseFromString(this.Qualifier + "//", "/");
        this.Value = resultText.ToEndOfString(this.Type + "/").TrimAllNewLines();
      }
      else
      {
        this.Qualifier = resultText.Between(this.TagName + ":", "/");
        this.Type = resultText.ParseFromString(this.Qualifier + "//", "/");
        this.Value = resultText.ToEndOfString(this.Type + "/").TrimAllNewLines();
      }
      return (ITag) this;
    }
  }
}
