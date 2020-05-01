﻿
// Type: SwiftMessageParser.Entities.BasicHeader
// Assembly: SwiftMessageParser, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: EFC8C9C4-3B99-44EA-BCBA-17BF9BD684F2
// Assembly location: C:\Users\Zach\Documents\SwiftMessageParser.dll

using System.Collections.Generic;

namespace SwiftMessageParser.Entities
{
    public class BasicHeader
    {
        /// <summary>
        /// Gets or sets the receiver bic.
        /// </summary>
        /// <value>
        /// The receiver bic.
        /// </value>
        public string ReceiverBIC { get; set; }

        /// <summary>
        /// Gets or sets the branch code.
        /// </summary>
        /// <value>
        /// The branch code.
        /// </value>
        public string BranchCode { get; set; }

        /// <summary>
        /// Gets or sets the session number.
        /// </summary>
        /// <value>
        /// The session number.
        /// </value>
        public string SessionNumber { get; set; }

        /// <summary>
        /// Gets or sets the sequence number.
        /// </summary>
        /// <value>
        /// The sequence number.
        /// </value>
        public string SequenceNumber { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BasicHeader"/> class.
        /// </summary>
        public BasicHeader()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BasicHeader"/> class.
        /// </summary>
        /// <param name="parsedSwiftMessage">The parsed swift message.</param>
        public BasicHeader(Dictionary<string, string> parsedSwiftMessage)
        {
            string str = parsedSwiftMessage[nameof(BasicHeader)];
            this.ReceiverBIC = str.Substring(3, 8);
            this.BranchCode = str.Substring(12, 3);
        }
    }
}
