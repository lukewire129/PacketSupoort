using System;
using System.Collections.Generic;

namespace BytePacketSupport
{
    public partial class PacketBuilder
    {
        private readonly PacketBuilderConfiguration _configuration;
        private List<byte> packetData = new List<byte> ();

        private readonly bool _isLittleEndian;
        public PacketBuilder()
        {
            this._configuration = new PacketBuilderConfiguration ();

            _isLittleEndian = BitConverter.IsLittleEndian;
        }
        public PacketBuilder(PacketBuilderConfiguration configuration)
        {
            this._configuration = configuration;

            _isLittleEndian = configuration.DefaultEndian == Enums.Endian.LITTLE;
        }

        public byte[] Build()
        {
            return this.packetData.ToArray();
        }
    }
}

