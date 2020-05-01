using SwiftMessageParser.Extensions;
using System;

namespace SwiftMessageParser.Entities.MT.Tags
{
    public class PatternSlashConditionalLines : Tag, ITag
    {
        public ITag GetTagValues(string resultText)
        {
            ////":59:/0000911466\r\nTHE MOORHOUSE COMPANY LTD\r\n.//NG"
            if (resultText.Contains(":59:"))
                resultText = resultText.Replace("//", string.Empty);

            this.GetTagName(resultText);
            if (resultText.Contains("/D/"))
            {
                this.Code = "D";
                if (resultText.Contains(Environment.NewLine))
                {
                    if (resultText.IndexOf("\n") != resultText.Length)
                    {
                        this.Value = resultText.ToEndOfString("/D/").TrimAllNewLines();
                        return (ITag)this;
                    }
                    this.Value = resultText.ParseFromString("/D", Environment.NewLine).TrimAllNewLines();
                    this.Description = resultText.ToEndOfString(this.Value).TrimAllNewLines();
                    return (ITag)this;
                }
                this.Value = resultText.ToEndOfString("/D/");
                return (ITag)this;
            }
            if (resultText.Contains("/C/"))
            {
                this.Code = "C";
                if (resultText.Contains(Environment.NewLine))
                {
                    if (resultText.IndexOf("\n") != resultText.Length)
                    {
                        this.Value = resultText.ToEndOfString("/C/").TrimAllNewLines();
                        return (ITag)this;
                    }
                    this.Value = resultText.ParseFromString("/C/", Environment.NewLine).TrimAllNewLines();
                    this.Description = resultText.ToEndOfString(this.Value).TrimAllNewLines();
                    return (ITag)this;
                }
                this.Value = resultText.ToEndOfString("/C/");
                return (ITag)this;
            }
            if (resultText.Contains("//"))
            {
                if (resultText.IndexOf("\n") != resultText.Length)
                {
                    this.Value = resultText.ToEndOfString("//");
                    return (ITag)this;
                }
                this.Value = resultText.ParseFromString("//", Environment.NewLine);
                this.Description = resultText.ToEndOfString(this.Value).TrimAllNewLines();
                return (ITag)this;
            }
            if (resultText.Contains("\n"))
            {
                if (resultText.IndexOf("\n") != resultText.Length)
                {
                    if (resultText.Contains("/"))
                    {
                        this.Value = resultText.Between("/", "\n").Trim();
                        string tempString = resultText.ToEndOfString(this.Value).Trim();
                        if (tempString.Contains("\n"))
                        {
                            this.Qualifier = tempString.Substring(0, tempString.IndexOf("\n") + 1).Trim();
                            this.Description = tempString.ToEndOfString(this.Qualifier).TrimAllNewLines();
                        }
                        else
                        {
                            this.Qualifier = resultText.ToEndOfString(this.Value).TrimAllNewLines();
                        }

                        return (ITag)this;
                    }
                    this.Value = resultText.Between(this.TagName + ":", Environment.NewLine);
                    string tempString2 = resultText.ToEndOfString(this.Value).Trim();
                    if (tempString2.Contains("\n"))
                    {
                        this.Qualifier = tempString2.Substring(0, tempString2.IndexOf("\n") + 1).Trim();
                        this.Description = tempString2.ToEndOfString(this.Qualifier).TrimAllNewLines();
                    }
                    else
                    {
                        this.Qualifier = resultText.ToEndOfString(this.Value).TrimAllNewLines();
                    }
                    return (ITag)this;
                }
                if (resultText.Contains("/"))
                {
                    this.Value = resultText.Between("/", Environment.NewLine);
                    return (ITag)this;
                }
                this.Value = resultText.Between(this.TagName + ":", Environment.NewLine);
                return (ITag)this;
            }
            if (resultText.Contains("/"))
            {
                this.Value = resultText.ToEndOfString("/");
                return (ITag)this;
            }
            this.Value = resultText.ToEndOfString(this.TagName + ":").Trim();
            return (ITag)this;
        }
    }
}
