using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftMessageParser.Entities.MT
{
    public class Field61
    {
        /// <summary>
        /// Gets or sets the related reference.
        /// </summary>
        /// <value>
        /// The related reference.
        /// </value>
        public string RelatedReference { get; set; }

        /// <summary>
        /// Gets or sets the value date.
        /// </summary>
        /// <value>
        /// The value date.
        /// </value>
        public DateTime? ValueDate { get; set; }

        /// <summary>
        /// Gets or sets the interbank settled amount.
        /// </summary>
        /// <value>
        /// The interbank settled amount.
        /// </value>
        public double? InterbankSettledAmount { get; set; }

        /// <summary>
        /// Gets or sets the currency.
        /// </summary>
        /// <value>
        /// The currency.
        /// </value>
        public string Currency { get; set; }
    }
}
