using System;
using System.Collections.Generic;

namespace BytePacketSupport
{
    public partial class PacketBuilder
    {
        private readonly PacketBuilderConfiguration _configuration;
        private List<byte> packetData = new List<byte> ();

        private readonly bool isMustReverseUnit;
        public PacketBuilder()
        {
            this._configuration = new PacketBuilderConfiguration ();

            isMustReverseUnit = (BitConverter.IsLittleEndian == true && this._configuration.DefaultEndian == Enums.Endian.BIG) ||
                                (BitConverter.IsLittleEndian == false && this._configuration.DefaultEndian == Enums.Endian.LITTLE);
        }
        public PacketBuilder(PacketBuilderConfiguration configuration)
        {
            this._configuration = configuration;

            isMustReverseUnit = (BitConverter.IsLittleEndian == true && this._configuration.DefaultEndian == Enums.Endian.BIG) ||
                                (BitConverter.IsLittleEndian == false && this._configuration.DefaultEndian == Enums.Endian.LITTLE);
        }

        public byte[] Build()
        {
            return this.packetData.ToArray();
        }
    }
}

