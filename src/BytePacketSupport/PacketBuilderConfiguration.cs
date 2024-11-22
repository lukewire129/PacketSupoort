using PacketSupport.Core.Enums;

namespace BytePacketSupport
{
    public class PacketBuilderConfiguration
    {
        public Endian DefaultEndian { get; set; } = Endian.LITTLE;
    }
}
