using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace fmsf.lib
{
    [Serializable]
    public class TransportationPacket
    {

        public TransportationPacket()
        {
            //Default Constructor
        }

        ~TransportationPacket()
        {
            //Default Destructor
        }

        public virtual void Dispose()
        {

        }

        public int MessageId
        { get; set; }

        public object MessagePacket
        { get; set; }

        public object MessageResultset
        { get; set; }

        public EStatus MessageStatus
        { get; set; }

        public EMessageType MessageType
        { get; set; }
    }
}
