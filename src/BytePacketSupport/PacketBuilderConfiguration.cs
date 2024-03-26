using BytePacketSupport.Enums;

namespace BytePacketSupport
{
    public class PacketBuilderConfiguration
    {
        public Endian DefaultEndian { get; set; } = Endian.LITTLE;
    }
}
