namespace SwiftMessageParser.Entities.MT.Tags
{
  public class PatternSequenceSeperator : Tag, ITag
  {
    public ITag GetTagValues(string resultText)
    {
      this.GetTagName(resultText);
      return (ITag) this;
    }
  }
}
