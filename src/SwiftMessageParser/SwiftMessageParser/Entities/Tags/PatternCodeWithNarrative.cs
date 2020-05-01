using SwiftMessageParser.Extensions;

namespace SwiftMessageParser.Entities.MT.Tags
{
    public class PatternCodeWithNarrative : Tag, ITag
    {

        public ITag GetTagValues(string resultText)
        {
            this.GetTagName(resultText);
            this.Qualifier = resultText.Between("::", "/");
            this.Code = resultText.ParseFromString(this.Qualifier + "/", "/");
            this.Value = resultText.ToEndOfString(this.Code + "/");
            return (ITag)this;
        }
    }
}
