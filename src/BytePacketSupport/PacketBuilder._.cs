using BytePacketSupport.Enums;
using BytePacketSupport.Extentions;
using System;
using System.Buffers;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BytePacketSupport
{
    public partial class PacketBuilder
    {
        private readonly PacketBuilderConfiguration _configuration;
        private ArrayBufferWriter<byte> packetData = new ArrayBufferWriter<byte> ();

        private readonly Endian endanType;
        private readonly IPacketWriter writer;
        public PacketBuilder()
        {
            this._configuration = new PacketBuilderConfiguration ();

            endanType = _configuration.DefaultEndian;

            if (endanType == Endian.BIG && BitConverter.IsLittleEndian == true)
            {
                writer = new ReversePacketWriter ();
            }
            else if (endanType == Endian.BIG && BitConverter.IsLittleEndian == false)
            {
                writer = new PacketWriter ();
            }
            if (endanType == Endian.LITTLE && BitConverter.IsLittleEndian == true)
            {
                writer = new PacketWriter ();
            }
            else if (endanType == Endian.LITTLE && BitConverter.IsLittleEndian == false)
            {
                writer = new ReversePacketWriter ();
            }
            else if (endanType == Endian.BIGBYTESWAP && BitConverter.IsLittleEndian == true)
            {
                writer = new ReverseSwapPacketWriter ();
            }
            else if (endanType == Endian.BIGBYTESWAP && BitConverter.IsLittleEndian == false)
            {
                writer = new SwapPacketWriter ();
            }
            if (endanType == Endian.LITTLEBYTESWAP && BitConverter.IsLittleEndian == true)
            {
                writer = new SwapPacketWriter ();
            }
            else if (endanType == Endian.LITTLEBYTESWAP && BitConverter.IsLittleEndian == false)
            {
                writer = new ReverseSwapPacketWriter ();
            }
        }
        public PacketBuilder(PacketBuilderConfiguration configuration)
        {
            this._configuration = configuration;

            endanType = configuration.DefaultEndian;

            if (endanType == Endian.BIG && BitConverter.IsLittleEndian == true)
            {
                writer = new ReversePacketWriter ();
            }
            else if (endanType == Endian.BIG && BitConverter.IsLittleEndian == false)
            {
                writer = new PacketWriter ();
            }
            if (endanType == Endian.LITTLE && BitConverter.IsLittleEndian == true)
            {
                writer = new PacketWriter ();
            }
            else if (endanType == Endian.LITTLE && BitConverter.IsLittleEndian == false)
            {
                writer = new ReversePacketWriter ();
            }
            else if (endanType == Endian.BIGBYTESWAP && BitConverter.IsLittleEndian == true)
            {
                writer = new ReverseSwapPacketWriter ();
            }
            else if (endanType == Endian.BIGBYTESWAP && BitConverter.IsLittleEndian == false)
            {
                writer = new SwapPacketWriter ();
            }
            if (endanType == Endian.LITTLEBYTESWAP && BitConverter.IsLittleEndian == true)
            {
                writer = new SwapPacketWriter ();
            }
            else if (endanType == Endian.LITTLEBYTESWAP && BitConverter.IsLittleEndian == false)
            {
                writer = new ReverseSwapPacketWriter ();
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
            this.AppendBytes (datas);
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

