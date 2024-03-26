using BytePacketSupport.Converter;
using System.Collections.Generic;

namespace BytePacketSupport
{
    public partial class PacketBuilder
    {
        public PacketBuilder @byte(byte data)
        {
            packetData.Add (data);

            return this;
        }

        public PacketBuilder @bytes(IEnumerable<byte> datas)
        {
            packetData.AddRange (datas);
            return this;
        }

        public PacketBuilder @string(string ascii)
        {
            byte[] datas = ByteConverter.GetBytes (ascii);
            packetData.AddRange (datas);
            return this;
        }

        public PacketBuilder @int(int intByte)
        {
            byte[] datas = ByteConverter.GetBytes (intByte, _isLittleEndian);
            packetData.AddRange (datas);
            return this;
        }

        public PacketBuilder @long(long longByte)
        {
            byte[] datas = ByteConverter.GetBytes (longByte, _isLittleEndian);
            packetData.AddRange (datas);
            return this;
        }

        public PacketBuilder @short(short shortByte)
        {
            byte[] datas = ByteConverter.GetBytes (shortByte, _isLittleEndian);
            packetData.AddRange (datas);
            return this;
        }

        public PacketBuilder @uint(uint uintByte)
        {
            byte[] datas = ByteConverter.GetBytes (uintByte, _isLittleEndian);
            packetData.AddRange (datas);
            return this;
        }

        public PacketBuilder @ulong (ulong ulongByte)
        {
            byte[] datas = ByteConverter.GetBytes (ulongByte, _isLittleEndian);
            packetData.AddRange (datas);
            return this;
        }

        public PacketBuilder @ushort (ushort ushortByte)
        {
            byte[] datas = ByteConverter.GetBytes (ushortByte, _isLittleEndian);
            packetData.AddRange (datas);
            return this;
        }


        public PacketBuilder @class<TSource>(TSource AppenClass) where TSource : class
        {
            byte[] datas = PacketParse.Serialize (AppenClass);
            packetData.AddRange (datas);
            return this;
        }
    }
}

