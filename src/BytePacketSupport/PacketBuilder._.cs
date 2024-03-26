using System;
using System.Collections.Generic;

namespace BytePacketSupport
{
    public partial class PacketBuilder
    {
        private readonly PacketBuilderConfiguration _configuration;
        private List<byte> packetData = new List<byte> ();

        private bool isLittleEnidan = true; 
        public PacketBuilder()
        {
            this._configuration = new PacketBuilderConfiguration ();

            isLittleEnidan = BitConverter.IsLittleEndian;
        }
        public PacketBuilder(PacketBuilderConfiguration? configuration)
        {
            this._configuration = configuration;

            isLittleEnidan = this._configuration.DefaultEndian == Enums.Endian.LITTLE;
        }

        public byte[] Build()
        {
            return this.packetData.ToArray();
        }
    }
}

