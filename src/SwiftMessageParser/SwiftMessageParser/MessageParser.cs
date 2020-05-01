using SwiftMessageParser.Entities;
using SwiftMessageParser.Entities.MT;
using SwiftMessageParser.Entities.MT.Tags;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SwiftMessageParser
{
    public class MessageParser: IMessageParser
    {
        public MessageType GetType(string swiftFormattedMessage)
        {
            if (string.IsNullOrEmpty(swiftFormattedMessage))
                throw new ArgumentNullException("Swift message cannot be null or empty");

            throw new NotImplementedException();
        }

        /// <summary>
        /// Parses the swift message.
        /// </summary>
        /// <param name="swiftFormattedMessage">The swift formatted message.</param>
        public SwiftMessage Parse(string swiftFormattedMessage)
        {
            MTParser mtParser = new MTParser();
            TagFactory tagFactory = new TagFactory();
            List<string> stringList = new List<string>();
            List<ITag> listOfITags = new List<ITag>();
            List<string> list = new List<string>();
            Dictionary<string, string> parsedSwiftMessage = mtParser.SeperateSWIFTFile(swiftFormattedMessage);
            SwiftMessage swiftMessage = new SwiftMessage {
                Block1 = new BasicHeader(parsedSwiftMessage),
                Block2 = new ApplicationHeader(parsedSwiftMessage)
            };

            if (parsedSwiftMessage.ContainsKey("UserHeader"))
                swiftMessage.Block3 = new UserHeader(parsedSwiftMessage);

            if (swiftMessage.Block2 != null && swiftMessage.Block2.MessageType.Trim().Equals("942"))
            {
                List<string> filteredString = parsedSwiftMessage["TextBlock"].Split(new[] { Environment.NewLine }, StringSplitOptions.None).ToList();
                filteredString = filteredString.Where(x => x.StartsWith(":") && !x.Contains(":86:")).ToList();
                list = mtParser.Block4ToList(string.Join(Environment.NewLine, filteredString));
            }
            else
            {
                list = mtParser.Block4ToList(parsedSwiftMessage["TextBlock"]);
            }

            foreach (string parsedSwiftTag in list)
                listOfITags = tagFactory.CreateInstance(parsedSwiftTag, listOfITags);

            swiftMessage.Block4 = listOfITags;

            return swiftMessage;
        }

        /// <summary>
        /// Parses the swift file to exact message type. <see cref="MessageType"/>
        /// </summary>
        /// <param name="swiftFormattedMessage">The swift formatted file.</param>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Invalid message type</exception>
        public IMessageType ParseExact(string swiftFormattedMessage, MessageType type)
        {
            var parsedMessage = Parse(swiftFormattedMessage);
            IMessageType messageParser = null;
            switch (type)
            {
                case MessageType.MT103:
                    messageParser = new MT103();
                    break;
                case MessageType.MT910:
                    messageParser = new MT910();
                    break;
                case MessageType.MT942:
                    messageParser = new MT942();
                    break;
                default:
                    throw new ArgumentException("Invalid message type");
            }
            messageParser.Parse(parsedMessage);
            return messageParser;
        }

        public List<IMessageType> ParseExact(string swiftFormattedFile)
        {
            throw new NotImplementedException();
        }
    }
    public enum MessageType
    {
        MT103 = 0,
        MT910 = 1,
        MT942 = 2
    }
}
