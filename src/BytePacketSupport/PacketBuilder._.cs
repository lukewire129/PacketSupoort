using BytePacketSupport.Converter;
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
        private PacketBuilder Append(byte data)
        {
            packetData.Add (data);

            return this;
        }

        private PacketBuilder Append(IEnumerable<byte> datas)
        {
            packetData.AddRange (datas);
            return this;
        }

        private PacketBuilder Append(string ascii)
        {
            byte[] datas = ByteConverter.GetBytes (ascii);
            packetData.AddRange (datas);
            return this;
        }

        private PacketBuilder Append(int intByte)
        {
            byte[] datas = ByteConverter.GetBytes (intByte, _isLittleEndian);
            packetData.AddRange (datas);
            return this;
        }

        private PacketBuilder Append(long longByte)
        {
            byte[] datas = ByteConverter.GetBytes (longByte, _isLittleEndian);
            packetData.AddRange (datas);
            return this;
        }

        private PacketBuilder Append(short shortByte)
        {
            byte[] datas = ByteConverter.GetBytes (shortByte, _isLittleEndian);
            packetData.AddRange (datas);
            return this;
        }

        private PacketBuilder Append(uint uintByte)
        {
            byte[] datas = ByteConverter.GetBytes (uintByte, _isLittleEndian);
            packetData.AddRange (datas);
            return this;
        }

        private PacketBuilder Append(ulong ulongByte)
        {
            byte[] datas = ByteConverter.GetBytes (ulongByte, _isLittleEndian);
            packetData.AddRange (datas);
            return this;
        }

        private PacketBuilder Append(ushort ushortByte)
        {
            byte[] datas = ByteConverter.GetBytes (ushortByte, _isLittleEndian);
            packetData.AddRange (datas);
            return this;
        }

        private PacketBuilder Append<TSource>(TSource AppenClass) where TSource : class
        {
            byte[] datas = PacketParse.Serialize (AppenClass);
            packetData.AddRange (datas);
            return this;
        }
        public PacketBuilder AppendByte(byte data)
        {
            return Append (data);
        }

        public PacketBuilder AppendBytes(IEnumerable<byte> datas)
        {
            return Append (datas);
        }

        public PacketBuilder AppendString(string ascii)
        {
            return Append (ascii);
        }

        public byte[] Build()
        {
            return this.packetData.ToArray();
        }
    }
}

