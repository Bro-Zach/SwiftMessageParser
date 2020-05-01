using SwiftMessageParser.Extensions;
using System.Collections.Generic;

namespace SwiftMessageParser
{
    public class MTParser
    {
        /// <summary>
        /// The swift tags
        /// </summary>
        private List<string> _swiftTags = new List<string>();

        /// <summary>
        /// The is tag
        /// </summary>
        private bool _isTag;

        /// <summary>
        /// Block4s to list.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public List<string> Block4ToList(string message)
        {
            List<string> stringList = new List<string>();

            this._isTag = false;
            int num = 0;
            int length1 = message.Length;
            while (num < length1)
            {
                int swiftTag = message.GetSwiftTag(num);
                if (swiftTag > 0)
                {
                    int length2 = this.CheckTag(num + swiftTag, length1, message);
                    if (this._isTag)
                    {
                        string str = message.Substring(num, swiftTag);
                        stringList.Add(str.Trim());
                        num += swiftTag;
                        this._isTag = false;
                    }
                    else
                    {
                        if (message.LastIndexOf(":") > num && length2 != length1)
                        {
                            swiftTag = length2 - num;
                            string str = message.Substring(num, swiftTag);
                            stringList.Add(str.Trim());
                            num += swiftTag;
                        }
                        else
                        {
                            string str = message.Substring(num, length2);
                            stringList.Add(str.TrimAllNewLines());
                            num = length2;
                            this._isTag = false;
                        }
                    }
                }
                else
                {
                    string str = message.Substring(num, length1 - num);
                    stringList.Add(str.TrimEndOfSwift().Trim());
                    num = length1 + 1;
                }
            }
            return stringList;
        }

        /// <summary>
        /// Checks the tag.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="size">The size.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        private int CheckTag(int index, int size, string message)
        {
            int num1;
            if (index + 3 >= size || index + 4 >= size)
                num1 = 0;
            else if (message.Substring(index + 3, 1) == ":" || message.Substring(index + 4, 1) == ":")
            {
                if (this.CheckValidTag(index, message))
                {
                    int num2 = index;
                    this._isTag = true;
                    return num2;
                }
                int swiftTag = message.GetSwiftTag(index);
                num1 = this.CheckTag(index + swiftTag, size, message);
                this._isTag = false;
            }
            else
            {
                int swiftTag = message.GetSwiftTag(index);
                num1 = this.CheckTag(index + swiftTag, size, message);
                this._isTag = false;
            }
            return num1;
        }

        /// <summary>
        /// Checks the valid tag.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        private bool CheckValidTag(int index, string message)
        {
            bool flag = false;
            foreach (string swiftTag in this._swiftTags)
            {
                if (swiftTag == message.Substring(index + 1, 2) || swiftTag == message.Substring(index + 1, 3))
                {
                    flag = true;
                    return flag;
                }
            }
            return flag;
        }

        /// <summary>
        /// Seperates the swift file.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public Dictionary<string, string> SeperateSWIFTFile(string message)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            if (message.Contains("{1:"))
            {
                string str = message.Between("{1:", "}");
                dictionary.Add("BasicHeader", str);
            }
            if (message.Contains("{2:"))
            {
                string str = message.Between("{2:", "}");
                dictionary.Add("ApplicationHeader", str);
            }
            if (message.Contains("{3:"))
            {
                string str = message.Between("{3:", "{4:");
                dictionary.Add("UserHeader", str);
            }
            if (message.Contains("{4:"))
            {
                string str = message.Between("{4:", "}");
                dictionary.Add("TextBlock", str);
            }
            if (message.Contains("{5:"))
            {
                string str = message.Between("{5:", "}");
                dictionary.Add("Trailer", str);
            }
            return dictionary;
        }

        /// <summary>
        /// Loads the swift tags.
        /// </summary>
        private void LoadSwiftTags()
        {
            this._swiftTags.Add("11A");
            this._swiftTags.Add("11R");
            this._swiftTags.Add("11S");
            this._swiftTags.Add("12");
            this._swiftTags.Add("12A");
            this._swiftTags.Add("12B");
            this._swiftTags.Add("12C");
            this._swiftTags.Add("12E");
            this._swiftTags.Add("12F");
            this._swiftTags.Add("13A");
            this._swiftTags.Add("13B");
            this._swiftTags.Add("13C");
            this._swiftTags.Add("13D");
            this._swiftTags.Add("13E");
            this._swiftTags.Add("13J");
            this._swiftTags.Add("13K");
            this._swiftTags.Add("14A");
            this._swiftTags.Add("14C");
            this._swiftTags.Add("14D");
            this._swiftTags.Add("14F");
            this._swiftTags.Add("14G");
            this._swiftTags.Add("14J");
            this._swiftTags.Add("14S");
            this._swiftTags.Add("15A");
            this._swiftTags.Add("15B");
            this._swiftTags.Add("15C");
            this._swiftTags.Add("15D");
            this._swiftTags.Add("15E");
            this._swiftTags.Add("15F");
            this._swiftTags.Add("15G");
            this._swiftTags.Add("15H");
            this._swiftTags.Add("15I");
            this._swiftTags.Add("15J");
            this._swiftTags.Add("15K");
            this._swiftTags.Add("15L");
            this._swiftTags.Add("15M");
            this._swiftTags.Add("15N");
            this._swiftTags.Add("16A");
            this._swiftTags.Add("16R");
            this._swiftTags.Add("16S");
            this._swiftTags.Add("17A");
            this._swiftTags.Add("17B");
            this._swiftTags.Add("17F");
            this._swiftTags.Add("17G");
            this._swiftTags.Add("17N");
            this._swiftTags.Add("17O");
            this._swiftTags.Add("17R");
            this._swiftTags.Add("17T");
            this._swiftTags.Add("17U");
            this._swiftTags.Add("17V");
            this._swiftTags.Add("18A");
            this._swiftTags.Add("19");
            this._swiftTags.Add("19A");
            this._swiftTags.Add("19B");
            this._swiftTags.Add("20");
            this._swiftTags.Add("20C");
            this._swiftTags.Add("20D");
            this._swiftTags.Add("21");
            this._swiftTags.Add("21A");
            this._swiftTags.Add("21B");
            this._swiftTags.Add("21C");
            this._swiftTags.Add("21D");
            this._swiftTags.Add("21E");
            this._swiftTags.Add("21F");
            this._swiftTags.Add("21G");
            this._swiftTags.Add("21N");
            this._swiftTags.Add("21P");
            this._swiftTags.Add("21R");
            this._swiftTags.Add("22");
            this._swiftTags.Add("22A");
            this._swiftTags.Add("22B");
            this._swiftTags.Add("22C");
            this._swiftTags.Add("22D");
            this._swiftTags.Add("22E");
            this._swiftTags.Add("22F");
            this._swiftTags.Add("22G");
            this._swiftTags.Add("22H");
            this._swiftTags.Add("22J");
            this._swiftTags.Add("22K");
            this._swiftTags.Add("22X");
            this._swiftTags.Add("23");
            this._swiftTags.Add("23A");
            this._swiftTags.Add("23B");
            this._swiftTags.Add("23C");
            this._swiftTags.Add("23D");
            this._swiftTags.Add("23E");
            this._swiftTags.Add("23F");
            this._swiftTags.Add("23G");
            this._swiftTags.Add("24B");
            this._swiftTags.Add("24D");
            this._swiftTags.Add("25");
            this._swiftTags.Add("25A");
            this._swiftTags.Add("25D");
            this._swiftTags.Add("26A");
            this._swiftTags.Add("26B");
            this._swiftTags.Add("26C");
            this._swiftTags.Add("26D");
            this._swiftTags.Add("26E");
            this._swiftTags.Add("26F");
            this._swiftTags.Add("26H");
            this._swiftTags.Add("26N");
            this._swiftTags.Add("26P");
            this._swiftTags.Add("26T");
            this._swiftTags.Add("27");
            this._swiftTags.Add("28");
            this._swiftTags.Add("28C");
            this._swiftTags.Add("28D");
            this._swiftTags.Add("28E");
            this._swiftTags.Add("29A");
            this._swiftTags.Add("29B");
            this._swiftTags.Add("29C");
            this._swiftTags.Add("29E");
            this._swiftTags.Add("29F");
            this._swiftTags.Add("29G");
            this._swiftTags.Add("29H");
            this._swiftTags.Add("29J");
            this._swiftTags.Add("29K");
            this._swiftTags.Add("30");
            this._swiftTags.Add("30F");
            this._swiftTags.Add("30G");
            this._swiftTags.Add("30H");
            this._swiftTags.Add("30P");
            this._swiftTags.Add("30Q");
            this._swiftTags.Add("30T");
            this._swiftTags.Add("30U");
            this._swiftTags.Add("30V");
            this._swiftTags.Add("30X");
            this._swiftTags.Add("31C");
            this._swiftTags.Add("31D");
            this._swiftTags.Add("31E");
            this._swiftTags.Add("31F");
            this._swiftTags.Add("31G");
            this._swiftTags.Add("31L");
            this._swiftTags.Add("31P");
            this._swiftTags.Add("31R");
            this._swiftTags.Add("31S");
            this._swiftTags.Add("31X");
            this._swiftTags.Add("32A");
            this._swiftTags.Add("32B");
            this._swiftTags.Add("32C");
            this._swiftTags.Add("32D");
            this._swiftTags.Add("32E");
            this._swiftTags.Add("32F");
            this._swiftTags.Add("32G");
            this._swiftTags.Add("32H");
            this._swiftTags.Add("32J");
            this._swiftTags.Add("32K");
            this._swiftTags.Add("32M");
            this._swiftTags.Add("32N");
            this._swiftTags.Add("32P");
            this._swiftTags.Add("32Q");
            this._swiftTags.Add("32U");
            this._swiftTags.Add("33A");
            this._swiftTags.Add("33B");
            this._swiftTags.Add("33C");
            this._swiftTags.Add("33D");
            this._swiftTags.Add("33E");
            this._swiftTags.Add("33F");
            this._swiftTags.Add("33G");
            this._swiftTags.Add("33K");
            this._swiftTags.Add("33N");
            this._swiftTags.Add("33P");
            this._swiftTags.Add("33R");
            this._swiftTags.Add("33S");
            this._swiftTags.Add("33T");
            this._swiftTags.Add("34A");
            this._swiftTags.Add("34B");
            this._swiftTags.Add("34E");
            this._swiftTags.Add("34F");
            this._swiftTags.Add("34N");
            this._swiftTags.Add("34P");
            this._swiftTags.Add("34R");
            this._swiftTags.Add("35A");
            this._swiftTags.Add("35B");
            this._swiftTags.Add("35C");
            this._swiftTags.Add("35D");
            this._swiftTags.Add("35E");
            this._swiftTags.Add("35F");
            this._swiftTags.Add("35H");
            this._swiftTags.Add("35L");
            this._swiftTags.Add("35N");
            this._swiftTags.Add("35S");
            this._swiftTags.Add("35U");
            this._swiftTags.Add("36");
            this._swiftTags.Add("36A");
            this._swiftTags.Add("36B");
            this._swiftTags.Add("36C");
            this._swiftTags.Add("36E");
            this._swiftTags.Add("37A");
            this._swiftTags.Add("37B");
            this._swiftTags.Add("37C");
            this._swiftTags.Add("37D");
            this._swiftTags.Add("37E");
            this._swiftTags.Add("37F");
            this._swiftTags.Add("37G");
            this._swiftTags.Add("37H");
            this._swiftTags.Add("37J");
            this._swiftTags.Add("37K");
            this._swiftTags.Add("37L");
            this._swiftTags.Add("37M");
            this._swiftTags.Add("37N");
            this._swiftTags.Add("37P");
            this._swiftTags.Add("37R");
            this._swiftTags.Add("37U");
            this._swiftTags.Add("38A");
            this._swiftTags.Add("38B");
            this._swiftTags.Add("38D");
            this._swiftTags.Add("38E");
            this._swiftTags.Add("38G");
            this._swiftTags.Add("38H");
            this._swiftTags.Add("38J");
            this._swiftTags.Add("39A");
            this._swiftTags.Add("39B");
            this._swiftTags.Add("39C");
            this._swiftTags.Add("39P");
            this._swiftTags.Add("40A");
            this._swiftTags.Add("40B");
            this._swiftTags.Add("40C");
            this._swiftTags.Add("40E");
            this._swiftTags.Add("40F");
            this._swiftTags.Add("41A");
            this._swiftTags.Add("41D");
            this._swiftTags.Add("42A");
            this._swiftTags.Add("42C");
            this._swiftTags.Add("42D");
            this._swiftTags.Add("42M");
            this._swiftTags.Add("42P");
            this._swiftTags.Add("43P");
            this._swiftTags.Add("43T");
            this._swiftTags.Add("44A");
            this._swiftTags.Add("44B");
            this._swiftTags.Add("44C");
            this._swiftTags.Add("44D");
            this._swiftTags.Add("44E");
            this._swiftTags.Add("44F");
            this._swiftTags.Add("45A");
            this._swiftTags.Add("45B");
            this._swiftTags.Add("46A");
            this._swiftTags.Add("46B");
            this._swiftTags.Add("47A");
            this._swiftTags.Add("47B");
            this._swiftTags.Add("48");
            this._swiftTags.Add("49");
            this._swiftTags.Add("50");
            this._swiftTags.Add("50A");
            this._swiftTags.Add("50B");
            this._swiftTags.Add("50C");
            this._swiftTags.Add("50D");
            this._swiftTags.Add("50F");
            this._swiftTags.Add("50G");
            this._swiftTags.Add("50H");
            this._swiftTags.Add("50K");
            this._swiftTags.Add("50L");
            this._swiftTags.Add("51A");
            this._swiftTags.Add("51C");
            this._swiftTags.Add("51D");
            this._swiftTags.Add("52A");
            this._swiftTags.Add("52B");
            this._swiftTags.Add("52C");
            this._swiftTags.Add("52D");
            this._swiftTags.Add("52G");
            this._swiftTags.Add("53");
            this._swiftTags.Add("53A");
            this._swiftTags.Add("53B");
            this._swiftTags.Add("53C");
            this._swiftTags.Add("53D");
            this._swiftTags.Add("53J");
            this._swiftTags.Add("54");
            this._swiftTags.Add("54A");
            this._swiftTags.Add("54B");
            this._swiftTags.Add("54D");
            this._swiftTags.Add("55");
            this._swiftTags.Add("55A");
            this._swiftTags.Add("55B");
            this._swiftTags.Add("55D");
            this._swiftTags.Add("56");
            this._swiftTags.Add("56A");
            this._swiftTags.Add("56B");
            this._swiftTags.Add("56C");
            this._swiftTags.Add("56D");
            this._swiftTags.Add("56J");
            this._swiftTags.Add("57");
            this._swiftTags.Add("57A");
            this._swiftTags.Add("57B");
            this._swiftTags.Add("57C");
            this._swiftTags.Add("57D");
            this._swiftTags.Add("57J");
            this._swiftTags.Add("58A");
            this._swiftTags.Add("58B");
            this._swiftTags.Add("58C");
            this._swiftTags.Add("58D");
            this._swiftTags.Add("58J");
            this._swiftTags.Add("59");
            this._swiftTags.Add("59A");
            this._swiftTags.Add("59F");
            this._swiftTags.Add("60F");
            this._swiftTags.Add("60M");
            this._swiftTags.Add("61");
            this._swiftTags.Add("62F");
            this._swiftTags.Add("62M");
            this._swiftTags.Add("64");
            this._swiftTags.Add("65");
            this._swiftTags.Add("67A");
            this._swiftTags.Add("68A");
            this._swiftTags.Add("68B");
            this._swiftTags.Add("68C");
            this._swiftTags.Add("69A");
            this._swiftTags.Add("69B");
            this._swiftTags.Add("69C");
            this._swiftTags.Add("69D");
            this._swiftTags.Add("69E");
            this._swiftTags.Add("69F");
            this._swiftTags.Add("69J");
            this._swiftTags.Add("70");
            this._swiftTags.Add("70C");
            this._swiftTags.Add("70D");
            this._swiftTags.Add("70E");
            this._swiftTags.Add("70F");
            this._swiftTags.Add("70G");
            this._swiftTags.Add("71A");
            this._swiftTags.Add("71B");
            this._swiftTags.Add("71C");
            this._swiftTags.Add("71F");
            this._swiftTags.Add("71G");
            this._swiftTags.Add("71H");
            this._swiftTags.Add("71J");
            this._swiftTags.Add("71K");
            this._swiftTags.Add("71L");
            this._swiftTags.Add("72");
            this._swiftTags.Add("73");
            this._swiftTags.Add("74");
            this._swiftTags.Add("75");
            this._swiftTags.Add("76");
            this._swiftTags.Add("77A");
            this._swiftTags.Add("77B");
            this._swiftTags.Add("77D");
            this._swiftTags.Add("77E");
            this._swiftTags.Add("77F");
            this._swiftTags.Add("77G");
            this._swiftTags.Add("77H");
            this._swiftTags.Add("77J");
            this._swiftTags.Add("77T");
            this._swiftTags.Add("78");
            this._swiftTags.Add("79");
            this._swiftTags.Add("80C");
            this._swiftTags.Add("82A");
            this._swiftTags.Add("82B");
            this._swiftTags.Add("82D");
            this._swiftTags.Add("82J");
            this._swiftTags.Add("82S");
            this._swiftTags.Add("83A");
            this._swiftTags.Add("83C");
            this._swiftTags.Add("83D");
            this._swiftTags.Add("83J");
            this._swiftTags.Add("84A");
            this._swiftTags.Add("84B");
            this._swiftTags.Add("84D");
            this._swiftTags.Add("84J");
            this._swiftTags.Add("85A");
            this._swiftTags.Add("85B");
            this._swiftTags.Add("85D");
            this._swiftTags.Add("85J");
            this._swiftTags.Add("86");
            this._swiftTags.Add("86A");
            this._swiftTags.Add("86B");
            this._swiftTags.Add("86D");
            this._swiftTags.Add("86J");
            this._swiftTags.Add("87A");
            this._swiftTags.Add("87B");
            this._swiftTags.Add("87D");
            this._swiftTags.Add("87J");
            this._swiftTags.Add("90A");
            this._swiftTags.Add("90B");
            this._swiftTags.Add("90C");
            this._swiftTags.Add("90D");
            this._swiftTags.Add("90E");
            this._swiftTags.Add("90F");
            this._swiftTags.Add("90J");
            this._swiftTags.Add("91A");
            this._swiftTags.Add("91B");
            this._swiftTags.Add("91C");
            this._swiftTags.Add("91D");
            this._swiftTags.Add("91E");
            this._swiftTags.Add("91F");
            this._swiftTags.Add("91G");
            this._swiftTags.Add("91H");
            this._swiftTags.Add("92A");
            this._swiftTags.Add("92B");
            this._swiftTags.Add("92C");
            this._swiftTags.Add("92D");
            this._swiftTags.Add("92E");
            this._swiftTags.Add("92F");
            this._swiftTags.Add("92J");
            this._swiftTags.Add("92K");
            this._swiftTags.Add("92L");
            this._swiftTags.Add("92M");
            this._swiftTags.Add("92N");
            this._swiftTags.Add("93A");
            this._swiftTags.Add("93B");
            this._swiftTags.Add("93C");
            this._swiftTags.Add("93D");
            this._swiftTags.Add("94A");
            this._swiftTags.Add("94B");
            this._swiftTags.Add("94C");
            this._swiftTags.Add("94D");
            this._swiftTags.Add("94F");
            this._swiftTags.Add("94G");
            this._swiftTags.Add("95C");
            this._swiftTags.Add("95P");
            this._swiftTags.Add("95Q");
            this._swiftTags.Add("95R");
            this._swiftTags.Add("95S");
            this._swiftTags.Add("95T");
            this._swiftTags.Add("95U");
            this._swiftTags.Add("95V");
            this._swiftTags.Add("97A");
            this._swiftTags.Add("97B");
            this._swiftTags.Add("97C");
            this._swiftTags.Add("98A");
            this._swiftTags.Add("98B");
            this._swiftTags.Add("98C");
            this._swiftTags.Add("98D");
            this._swiftTags.Add("98E");
            this._swiftTags.Add("99A");
            this._swiftTags.Add("99B");
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="MTParser"/> class.
        /// </summary>
        public MTParser()
        {
            this.LoadSwiftTags();
        }
    }
}
