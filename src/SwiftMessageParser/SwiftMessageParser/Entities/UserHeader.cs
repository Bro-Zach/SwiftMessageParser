
// Type: SwiftMessageParser.Entities.UserHeader
// Assembly: SwiftMessageParser, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: EFC8C9C4-3B99-44EA-BCBA-17BF9BD684F2
// Assembly location: C:\Users\Zach\Documents\SwiftMessageParser.dll

using SwiftMessageParser.Extensions;
using System.Collections.Generic;

namespace SwiftMessageParser.Entities
{

  public class UserHeader
  {

        /// <summary>
        /// Gets or sets the uetr.
        /// </summary>
        /// <value>
        /// The uetr.
        /// </value>
        public string Uetr { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserHeader"/> class.
        /// </summary>
        public UserHeader()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserHeader"/> class.
        /// </summary>
        /// <param name="parsedSwiftMessage">The parsed swift message.</param>
        public UserHeader(Dictionary<string, string> parsedSwiftMessage)
        {
            string str = parsedSwiftMessage[nameof(UserHeader)];
            if (str.Contains("{121:"))
                this.Uetr = str.Between("{121:", "}");
            else
                this.Uetr = "";
        }
    }
}
