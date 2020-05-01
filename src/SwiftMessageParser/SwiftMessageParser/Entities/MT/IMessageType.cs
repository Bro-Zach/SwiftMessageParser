using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftMessageParser.Entities.MT
{
    public interface IMessageType
    {
        void Parse(SwiftMessage swiftMessage);
    }
}
