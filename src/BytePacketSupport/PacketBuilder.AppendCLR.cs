namespace BytePacketSupport
{
    public partial class PacketBuilder
    {
        public PacketBuilder AppendInt16(short shortByte)
        {
            return Append (shortByte);
        }
        public PacketBuilder AppendInt32(int intByte)
        {
            return Append (intByte);
        }

        public PacketBuilder AppendInt64(long longByte)
        {
            return Append (longByte);
        }

        public PacketBuilder AppendUInt16(ushort ushortByte)
        {
            return Append (ushortByte);
        }

        public PacketBuilder AppendUInt32(uint uintByte)
        {
            return Append (uintByte);
        }

        public PacketBuilder AppendUInt64 (ulong ulongByte)
        {
            return Append (ulongByte);
        }
    }
}

