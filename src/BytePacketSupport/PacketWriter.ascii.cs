namespace BytePacketSupport
{
    public partial class PacketWriter
    {
        public PacketWriter Append(string ascii)
        {
            this.bytes = bytes.Append (ascii);

            return this;
        }

        public PacketWriter Append(string ascii, int offset, int count)
        {
            this.bytes = bytes.Append (ascii, offset, count);

            return this;
        }
    }
}
