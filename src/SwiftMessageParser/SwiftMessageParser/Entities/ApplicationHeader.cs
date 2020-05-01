
// Type: SwiftMessageParser.Entities.ApplicationHeader
// Assembly: SwiftMessageParser, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: EFC8C9C4-3B99-44EA-BCBA-17BF9BD684F2
// Assembly location: C:\Users\Zach\Documents\SwiftMessageParser.dll

using System.Collections.Generic;

namespace SwiftMessageParser.Entities
{
    public class ApplicationHeader
    {
        /// <summary>
        /// Gets or sets the swift direction.
        /// </summary>
        /// <value>
        /// The swift direction.
        /// </value>
        public string SwiftDirection { get; set; }

        /// <summary>
        /// Gets or sets the type of the message.
        /// </summary>
        /// <value>
        /// The type of the message.
        /// </value>
        public string MessageType { get; set; }

        /// <summary>
        /// Gets or sets the sender bic.
        /// </summary>
        /// <value>
        /// The sender bic.
        /// </value>
        public string SenderBIC { get; set; }

        /// <summary>
        /// Gets or sets the branch code.
        /// </summary>
        /// <value>
        /// The branch code.
        /// </value>
        public string BranchCode { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationHeader"/> class.
        /// </summary>
        public ApplicationHeader()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationHeader"/> class.
        /// </summary>
        /// <param name="parsedSwiftMessage">The parsed swift message.</param>
        public ApplicationHeader(Dictionary<string, string> parsedSwiftMessage)
        {
            string str = parsedSwiftMessage[nameof(ApplicationHeader)];
            this.SwiftDirection = str.Substring(0, 1);
            this.MessageType = str.Substring(1, 3);
            if (str.Length < 24)
                this.SenderBIC = str.Substring(4, 8);
            else
                this.SenderBIC = str.Substring(14, 8);
        }
    }
}
