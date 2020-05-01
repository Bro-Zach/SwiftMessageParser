using SwiftMessageParser.Extensions;

namespace SwiftMessageParser.Entities.MT.Tags
{
    public class PatternAmountTypeCurrencyValue : Tag, ITag
    {

        public ITag GetTagValues(string resultText)
        {
            this.GetTagName(resultText);
            if (resultText.Contains("::"))
            {
                this.Qualifier = resultText.Between(this.TagName + "::", "/");
                this.Type = resultText.ParseFromString(this.Qualifier + "//", "/");
                this.Code = resultText.ParseWithStringAndIndex(this.Type + "/", 3);
                this.Value = resultText.ToEndOfString(this.Code).TrimAllNewLines();
            }
            else
            {
                this.Qualifier = resultText.Between(this.TagName + ":", "/");
                this.Type = resultText.ParseFromString(this.Qualifier + "//", "/");
                this.Code = resultText.ParseWithStringAndIndex(this.Type + "/", 3);
                this.Value = resultText.ToEndOfString(this.Code).TrimAllNewLines();
            }
            return (ITag)this;
        }
    }
}
