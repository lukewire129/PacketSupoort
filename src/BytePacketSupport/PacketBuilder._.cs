using System.Collections.Generic;

namespace BytePacketSupport
{
    public partial class PacketBuilder
    {
        private List<byte> packetData = new List<byte> ();

        public byte[] Build()
        {
            return this.packetData.ToArray ();
        }
    }
}

