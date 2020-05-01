using SwiftMessageParser.Entities;
using SwiftMessageParser.Entities.MT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftMessageParser
{
    public interface IMessageParser
    {
        /// <summary>
        /// Parses the specified swift formatted message.
        /// </summary>
        /// <param name="swiftFormattedMessage">The swift formatted message.</param>
        /// <returns></returns>
        SwiftMessage Parse(string swiftFormattedMessage);
        IMessageType ParseExact(string swiftFormattedMessage, MessageType type);
        List<IMessageType> ParseExact(string swiftFormattedFile);
        MessageType GetType(string swiftFormattedMessage);

    }
}
