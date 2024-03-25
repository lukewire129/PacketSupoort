using System.Collections.Generic;

namespace BytePacketSupport
{
    public partial class PacketBuilder
    {
        private readonly PacketBuilderConfiguration _configuration;
        private List<byte> packetData = new List<byte> ();

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
            return this.packetData.ToArray ();
        }
    }
}

