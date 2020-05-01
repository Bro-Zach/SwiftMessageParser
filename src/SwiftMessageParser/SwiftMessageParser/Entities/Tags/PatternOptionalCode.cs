using SwiftMessageParser.Extensions;

namespace SwiftMessageParser.Entities.MT.Tags
{
  public class PatternOptionalCode : Tag, ITag
  {
    public ITag GetTagValues(string resultText)
    {
      this.TagName = resultText.ParseFromString(":", ":");
      if (resultText.Contains("//"))
      {
        this.Qualifier = resultText.Between("::", "/");
        this.Value = resultText.ParseWithStringAndIndex(this.Qualifier + "//", 4);
      }
      else
      {
        this.Qualifier = resultText.Between("::", "/");
        this.Code = resultText.ParseFromString(this.Qualifier + "/", "/");
        this.Value = resultText.ParseWithStringAndIndex(this.Code + "/", 4);
      }
      return (ITag) this;
    }
  }
}
