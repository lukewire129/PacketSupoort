using BytePacketSupport.Converter;
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
        public PacketBuilder()
        {
            this._configuration = new PacketBuilderConfiguration ();

            endanType = _configuration.DefaultEndian;
        }
        public PacketBuilder(PacketBuilderConfiguration configuration)
        {
            this._configuration = configuration;

            endanType = configuration.DefaultEndian;
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

            if (endanType == Endian.LITTLE)
            {
                BinaryPrimitives.WriteInt16LittleEndian (span, value);
            }
            else
            {
                BinaryPrimitives.WriteInt16BigEndian (span, value);
            }
            return this;
        }

        private PacketBuilder Append(int value)
        {
            using var span = packetData.Reserve (sizeof (int));

            if (endanType == Endian.LITTLE)
            {
                BinaryPrimitives.WriteInt32LittleEndian (span, value);
            }
            else
            {
                BinaryPrimitives.WriteInt32BigEndian (span, value);
            }

            return this;
        }

        private PacketBuilder Append(long value)
        {
            using var span = packetData.Reserve (sizeof (long));

            if (endanType == Endian.LITTLE)
            {
                BinaryPrimitives.WriteInt64LittleEndian (span, value);
            }
            else
            {
                BinaryPrimitives.WriteInt64BigEndian (span, value);
            }
            return this;
        }

        private PacketBuilder Append(ushort value)
        {
            using var span = packetData.Reserve (sizeof (ushort));

            if (endanType == Endian.LITTLE)
            {
                BinaryPrimitives.WriteUInt16LittleEndian (span, value);
            }
            else
            {
                BinaryPrimitives.WriteUInt16BigEndian (span, value);
            }
            return this;
        }

        private PacketBuilder Append(uint value)
        {
            using var span = packetData.Reserve (sizeof (uint));

            if (endanType == Endian.LITTLE)
            {
                BinaryPrimitives.WriteUInt32LittleEndian (span, value);
            }
            else
            {
                BinaryPrimitives.WriteUInt32BigEndian (span, value);
            }
            return this;
        }

        private PacketBuilder Append(ulong value)
        {
            using var span = packetData.Reserve (sizeof (ulong));

            if (endanType == Endian.LITTLE)
            {
                BinaryPrimitives.WriteUInt64LittleEndian (span, value);
            }
            else
            {
                BinaryPrimitives.WriteUInt64BigEndian (span, value);
            }
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

