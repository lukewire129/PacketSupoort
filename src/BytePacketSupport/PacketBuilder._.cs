using BytePacketSupport.Converter;
using BytePacketSupport.Enums;
using System.Collections.Generic;

namespace BytePacketSupport
{
    public partial class PacketBuilder
    {
        private readonly PacketBuilderConfiguration _configuration;
        private List<byte> packetData = new List<byte> ();

        private readonly Endian endanType;
        public PacketBuilder()
        {
            this._configuration = new PacketBuilderConfiguration ();
            endanType = this._configuration.DefaultEndian;
        }
        public PacketBuilder(PacketBuilderConfiguration configuration)
        {
            this._configuration = configuration;

            endanType = this._configuration.DefaultEndian;
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
            byte[] datas = ByteConverter.GetBytes (intByte, endanType);
            packetData.AddRange (datas);
            return this;
        }

        private PacketBuilder Append(long longByte)
        {
            byte[] datas = ByteConverter.GetBytes (longByte, endanType);
            packetData.AddRange (datas);
            return this;
        }

        private PacketBuilder Append(short shortByte)
        {
            byte[] datas = ByteConverter.GetBytes (shortByte, endanType);
            packetData.AddRange (datas);
            return this;
        }

        private PacketBuilder Append(uint uintByte)
        {
            byte[] datas = ByteConverter.GetBytes (uintByte, endanType);
            packetData.AddRange (datas);
            return this;
        }

        private PacketBuilder Append(ulong ulongByte)
        {
            byte[] datas = ByteConverter.GetBytes (ulongByte, endanType);
            packetData.AddRange (datas);
            return this;
        }

        private PacketBuilder Append(ushort ushortByte)
        {
            byte[] datas = ByteConverter.GetBytes (ushortByte, endanType);
            packetData.AddRange (datas);
            return this;
        }

        private PacketBuilder Append<TSource>(TSource AppendClass) where TSource : class
        {
            byte[] datas = PacketParse.Serialize (AppendClass);
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

        public PacketBuilder AppendPacketBuilder(PacketBuilder builder)
        {
            return AppendBytes (builder.Build ());
        }

        public PacketBuilder AppendClass<TSource>(TSource AppendClass) where TSource : class
        {
            return Append (AppendClass);
        }

        public byte[] Build()
        {
            return this.packetData.ToArray();
        }
    }
}

