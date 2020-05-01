using SwiftMessageParser.Extensions;

namespace SwiftMessageParser.Entities.MT.Tags
{
  public class PatternOptionalCodeWithOptionalNarrative : Tag, ITag
  {
    public ITag GetTagValues(string resultText)
    {
      this.GetTagName(resultText);
      if (resultText.Contains("//"))
      {
        this.Qualifier = resultText.Between("::", "/");
        this.Value = resultText.ParseWithStringAndIndex(this.Qualifier + "//", 4);
        this.Description = resultText.ToEndOfString(this.Value);
      }
      else
      {
        this.Qualifier = resultText.Between("::", "/");
        this.Code = resultText.ParseFromString(this.Qualifier + "/", "/");
        this.Value = resultText.ToEndOfString(this.Code + "/");
        this.Description = resultText.ToEndOfString(this.Value);
      }
      return (ITag) this;
    }
  }
}
