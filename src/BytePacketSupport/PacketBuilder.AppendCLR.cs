using BytePacketSupport.Converter;
using System.Collections.Generic;

namespace BytePacketSupport
{
    public partial class PacketBuilder
    {
        public PacketBuilder AppendByte(byte data)
        {
            packetData.Add (data);

            return this;
        }

        public PacketBuilder AppendBytes(IEnumerable<byte> datas)
        {
            packetData.AddRange (datas);
            return this;
        }

        public PacketBuilder AppendString(string ascii)
        {
            byte[] datas = ByteConverter.GetBytes (ascii);
            packetData.AddRange (datas);
            return this;
        }

        public PacketBuilder AppendInt32(int intByte)
        {
            byte[] datas = ByteConverter.GetBytes (intByte, _isLittleEndian);
            packetData.AddRange (datas);
            return this;
        }

        public PacketBuilder AppendInt64(long longByte)
        {
            byte[] datas = ByteConverter.GetBytes (longByte, _isLittleEndian);
            packetData.AddRange (datas);
            return this;
        }

        public PacketBuilder AppendInt16(short shortByte)
        {
            byte[] datas = ByteConverter.GetBytes (shortByte, _isLittleEndian);
            packetData.AddRange (datas);
            return this;
        }

        public PacketBuilder AppendUInt32(uint uintByte)
        {
            byte[] datas = ByteConverter.GetBytes (uintByte, _isLittleEndian);
            packetData.AddRange (datas);
            return this;
        }

        public PacketBuilder AppendUInt64 (ulong ulongByte)
        {
            byte[] datas = ByteConverter.GetBytes (ulongByte, _isLittleEndian);
            packetData.AddRange (datas);
            return this;
        }

        public PacketBuilder AppendUInt16 (ushort ushortByte)
        {
            byte[] datas = ByteConverter.GetBytes (ushortByte, _isLittleEndian);
            packetData.AddRange (datas);
            return this;
        }
    }
}

