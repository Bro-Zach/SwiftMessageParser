
using SwiftMessageParser.Entities;
using SwiftMessageParser.Entities.MT;
using SwiftMessageParser.Entities.MT.Tags;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SwiftMessageParser.Entities
{
    public class SwiftMessage
    {
        /// <summary>
        /// Gets or sets the block1.
        /// </summary>
        /// <value>
        /// The block1.
        /// </value>
        public BasicHeader Block1 { get; set; }

        /// <summary>
        /// Gets or sets the block2.
        /// </summary>
        /// <value>
        /// The block2.
        /// </value>
        public ApplicationHeader Block2 { get; set; }

        /// <summary>
        /// Gets or sets the block3.
        /// </summary>
        /// <value>
        /// The block3.
        /// </value>
        public UserHeader Block3 { get; set; }

        /// <summary>
        /// Gets or sets the block4.
        /// </summary>
        /// <value>
        /// The block4.
        /// </value>
        public List<ITag> Block4 { get; set; }

        /// <summary>
        /// Gets or sets the block5.
        /// </summary>
        /// <value>
        /// The block5.
        /// </value>
        public Trailer Block5 { get; set; }
    }
}
