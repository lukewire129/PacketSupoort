using System.Collections.Generic;
using System.Linq;

namespace BytePacketSupport
{
    public partial class PacketBuilder
    {
        private readonly PacketBuilderConfiguration _configuration;
        private LinkedList<byte> packetData = new LinkedList<byte> ();

        public PacketBuilder()
        {
            this._configuration = new PacketBuilderConfiguration ();
        }
        public PacketBuilder(PacketBuilderConfiguration? configuration)
        {
            this._configuration = configuration;
        }

        public byte[] Build()
        {
            return this.packetData.ToArray();
        }
    }
}

