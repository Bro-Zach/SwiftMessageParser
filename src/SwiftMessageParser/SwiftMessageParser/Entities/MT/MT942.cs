using SwiftMessageParser.Entities.MT.Tags;
using SwiftMessageParser.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SwiftMessageParser.Entities.MT
{
    public class MT942 : IMessageType
    {
        /// <summary>
        /// Gets or sets the sender reference.
        /// </summary>
        /// <value>
        /// The sender reference.
        /// </value>
        public string SenderReference { get; set; }

        /// <summary>
        /// Gets or sets the account identification.
        /// </summary>
        /// <value>
        /// The account identification.
        /// </value>
        public string AccountIdentification { get; set; }

        /// <summary>
        /// Gets or sets the field61s.
        /// </summary>
        /// <value>
        /// The field61s.
        /// </value>
        public List<Field61> Field61s { get; set; }

        /// <summary>
        /// Parses the MT942.
        /// </summary>
        /// <param name="mt942Message">The MT942 message.</param>
        public void Parse(SwiftMessage mt942Message)
        {
            var field20 = mt942Message.Block4.Where(x => x.TagName == "20").FirstOrDefault();
            if (field20 != null)
            {
                ParseField20(field20);
            }

            var field25 = mt942Message.Block4.Where(x => x.TagName == "25").FirstOrDefault();
            if (field25 != null)
            {
                ParseField25(field25);
            }

            var field61 = mt942Message.Block4.Where(x => x.TagName == "61").ToList();
            if (field61 != null)
            {
                ParseField61F(field61);
            }
        }

        /// <summary>
        /// Parses the field61 f.
        /// </summary>
        /// <param name="field61">The field61.</param>
        private void ParseField61F(List<ITag> field61)
        {
            List<Field61> field61sObject = new List<Field61>();
            foreach (var item in field61)
            {
                Field61 field61Object = new Field61();
                field61Object.RelatedReference = item.Value ?? "";
                string _tempString = item.Qualifier;
                field61Object.ValueDate = _tempString.Substring(0, 6).CovertToDate("yyMMdd");

                int operationCodeIndex = -1;
                string operationCode = string.Empty;

                if (_tempString.Contains("CD"))
                {
                    operationCodeIndex = _tempString.IndexOf("CD");
                    operationCode = "CD";
                    field61Object.Currency = "USD";
                }
                else if (_tempString.Contains("CR"))
                {
                    operationCodeIndex = _tempString.IndexOf("CR");
                    operationCode = "CR";
                    field61Object.Currency = "EUR";
                }
                else if (_tempString.Contains("CP"))
                {
                    operationCodeIndex = _tempString.IndexOf("CP");
                    operationCode = "CP";
                    field61Object.Currency = "GBP";
                }
                else
                {
                    //log invalid operation code and the field 61
                    continue;
                }
                //field61Object.TransactionReference = _tempString.Substring(_tempString.IndexOf(",") + 3);
                field61Object.InterbankSettledAmount = Convert.ToDouble(_tempString.AmountFromField61(operationCode, ","));

                field61sObject.Add(field61Object);
            }
            Field61s = field61sObject;
        }

        /// <summary>
        /// Parses the field20.
        /// </summary>
        /// <param name="field20">The field20.</param>
        private void ParseField20(ITag field20)
        {
            SenderReference = field20.Value ?? "";
        }

        /// <summary>
        /// Parses the field25.
        /// </summary>
        /// <param name="field25">The field25.</param>
        private void ParseField25(ITag field25)
        {
           AccountIdentification = field25.Value ?? "";
        }
    }

    
}
