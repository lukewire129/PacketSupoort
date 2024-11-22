using PacketSupport.Core.Enums;
using BytePacketSupport.Extentions;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BytePacketSupport
{
    public partial class PacketBuilder
    {
        private readonly PacketBuilderConfiguration _configuration;
        private ArrayBufferWriter<byte> packetData = new ArrayBufferWriter<byte> ();

        private readonly Endian endianType;
        private readonly IPacketWriter writer;
        private IPacketWriter LittleEndian()
        {
            if (BitConverter.IsLittleEndian)
                return new PacketWriter ();

            return new ReversePacketWriter ();
        }
        private IPacketWriter BigEndian()
        {
            if (BitConverter.IsLittleEndian)
                return new ReversePacketWriter ();

            return new PacketWriter ();
        }
        private IPacketWriter LittleEndianSwap()
        {
            if (BitConverter.IsLittleEndian)
                return new SwapPacketWriter ();

            return new ReverseSwapPacketWriter ();
        }
        private IPacketWriter BigEndianSwap()
        {
            if (BitConverter.IsLittleEndian)
                return new ReverseSwapPacketWriter ();

            return new SwapPacketWriter ();
        }

        public PacketBuilder()
        {
            this._configuration = new PacketBuilderConfiguration ();

            endianType = _configuration.DefaultEndian;
            switch (endianType)
            {
                case Endian.BIG:
                    writer = BigEndian();
                    break;
                case Endian.LITTLE:
                    writer = LittleEndian();
                    break;
                case Endian.BIGBYTESWAP:
                    writer = BigEndianSwap();
                    break;
                case Endian.LITTLEBYTESWAP:
                    writer = LittleEndianSwap();
                    break;
            }
        }
        public PacketBuilder(PacketBuilderConfiguration configuration)
        {
            this._configuration = configuration;

            endianType = configuration.DefaultEndian;

            switch (endianType)
            {
                case Endian.BIG:
                    writer = BigEndian ();
                    break;
                case Endian.LITTLE:
                    writer = LittleEndian ();
                    break;
                case Endian.BIGBYTESWAP:
                    writer = BigEndianSwap ();
                    break;
                case Endian.LITTLEBYTESWAP:
                    writer = LittleEndianSwap ();
                    break;
            }
        }

        private PacketBuilder Append(byte data)
        {
            using (var span = packetData.Reserve (sizeof (byte)))
            {
                span.Span[0] = data;
            }

            return this;
        }

        private PacketBuilder Append(IEnumerable<byte> datas)
        {
            if (!(datas is byte[] b))
            {
                b = datas.ToArray ();
            }

            packetData.Write (b);
            return this;
        }

        private PacketBuilder Append(string ascii)
        {
            var length = Encoding.ASCII.GetByteCount (ascii);

            using var span = packetData.Reserve (length);
            Encoding.ASCII.GetBytes (ascii, span);
            return this;
        }
        private PacketBuilder Append(short value)
        {
            using var span = packetData.Reserve (sizeof (short));

            writer.@short (span, value);
            return this;
        }

        private PacketBuilder Append(int value)
        {
            using var span = packetData.Reserve (sizeof (int));

            writer.@int (span, value);
            return this;
        }

        private PacketBuilder Append(long value)
        {
            using var span = packetData.Reserve (sizeof (long));
            writer.@long (span, value);
            return this;
        }

        private PacketBuilder Append(ushort value)
        {
            using var span = packetData.Reserve (sizeof (ushort));
            writer.@ushort (span, value);
            return this;
        }

        private PacketBuilder Append(uint value)
        {
            using var span = packetData.Reserve (sizeof (uint));
            writer.@uint (span, value);
            return this;
        }

        private PacketBuilder Append(ulong value)
        {
            using var span = packetData.Reserve (sizeof (ulong));
            writer.@ulong (span, value);
            return this;
        }

        private PacketBuilder Append<TSource>(TSource AppendClass) where TSource : class
        {
            byte[] datas = PacketParse.Serialize (AppendClass);
            AppendBytes (datas.ToList());
            return this;
        }

        public byte[] Build()
        {
            return this.packetData.ToArray();
        }
    }
}

