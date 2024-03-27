using BytePacketSupport.Converter;

namespace BytePacketSupport
{
    public partial class PacketBuilder
    {
        public PacketBuilder Appendshort(short shortByte)
        {
            byte[] datas = ByteConverter.GetBytes (shortByte, _isLittleEndian);
            packetData.AddRange (datas);
            return this;
        }
        public PacketBuilder Appendint(int intByte)
        {
            byte[] datas = ByteConverter.GetBytes (intByte, _isLittleEndian);
            packetData.AddRange (datas);
            return this;
        }

        public PacketBuilder Appendlong(long longByte)
        {
            byte[] datas = ByteConverter.GetBytes (longByte, _isLittleEndian);
            packetData.AddRange (datas);
            return this;
        }

        public PacketBuilder Appenduint(uint uintByte)
        {
            byte[] datas = ByteConverter.GetBytes (uintByte, _isLittleEndian);
            packetData.AddRange (datas);
            return this;
        }

        public PacketBuilder Appendulong (ulong ulongByte)
        {
            byte[] datas = ByteConverter.GetBytes (ulongByte, _isLittleEndian);
            packetData.AddRange (datas);
            return this;
        }

        public PacketBuilder Appendushort (ushort ushortByte)
        {
            byte[] datas = ByteConverter.GetBytes (ushortByte, _isLittleEndian);
            packetData.AddRange (datas);
            return this;
        }
    }
}

