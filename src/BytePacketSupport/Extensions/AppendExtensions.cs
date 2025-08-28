using System.Collections.Generic;

namespace BytePacketSupport.Extensions
{
    public static class AppendExtensions
    {
        public static PacketBuilder AppendByte(this PacketBuilder builder, byte data)
        {
            return builder.Append (data);
        }

        public static PacketBuilder AppendByte(this PacketBuilder builder, params byte[] datas)
        {
            return builder.Append (datas);
        }

        public static PacketBuilder AppendByte(this PacketBuilder builder, IEnumerable<byte> datas)
        {
            return builder.Append (datas);
        }

        public static PacketBuilder AppendString(this PacketBuilder builder, string ascii)
        {
            return builder.Append (ascii);
        }

        public static PacketBuilder AppendPacketBuilder(this PacketBuilder sourceBuilder, PacketBuilder builder)
        {
            return sourceBuilder.Append (builder.Build ());
        }

        public static PacketBuilder AppendClass<TSource>(this PacketBuilder builder, TSource AppendClass) where TSource : class
        {
            return builder.Append (AppendClass);
        }

        public static PacketBuilder AppendInt16(this PacketBuilder builder, short data)
        {
            return builder.Append (data);
        }

        public static PacketBuilder Appendshort(this PacketBuilder builder, short data)
        {
            return builder.Append (data);
        }

        public static PacketBuilder AppendInt32(this PacketBuilder builder, int data)
        {
            return builder.Append (data);
        }
        public static PacketBuilder Appendint(this PacketBuilder builder, int data)
        {
            return builder.Append (data);
        }

        public static PacketBuilder AppendInt64(this PacketBuilder builder, long data)
        {
            return builder.Append (data);
        }

        public static PacketBuilder Appendlong(this PacketBuilder builder, long data)
        {
            return builder.Append (data);
        }

        public static PacketBuilder AppendUInt16(this PacketBuilder builder, ushort data)
        {
            return builder.Append (data);
        }

        public static PacketBuilder Appendushort(this PacketBuilder builder, ushort data)
        {
            return builder.Append (data);
        }

        public static PacketBuilder AppendUInt32(this PacketBuilder builder, uint data)
        {
            return builder.Append (data);
        }
        public static PacketBuilder Appenduint(this PacketBuilder builder, uint data)
        {
            return builder.Append (data);
        }

        public static PacketBuilder AppendUInt64(this PacketBuilder builder, ulong data)
        {
            return builder.Append (data);
        }
        public static PacketBuilder Appendulong(this PacketBuilder builder, ulong data)
        {
            return builder.Append (data);
        }


        public static PacketBuilder @byte(this PacketBuilder builder, byte data)
        {
            return builder.Append (data);
        }

        public static PacketBuilder @byte(this PacketBuilder builder, IEnumerable<byte> datas)
        {
            return builder.Append (datas);
        }

        public static PacketBuilder @byte(this PacketBuilder builder, params byte[] datas)
        {
            return builder.Append (datas);
        }
        public static PacketBuilder @string(this PacketBuilder builder, string data)
        {
            return builder.Append (data);
        }

        public static PacketBuilder @short(this PacketBuilder builder, short data)
        {
            return builder.Append (data);
        }

        public static PacketBuilder @int(this PacketBuilder builder, int data)
        {
            return builder.Append (data);
        }

        public static PacketBuilder @long(this PacketBuilder builder, long data)
        {
            return builder.Append (data);
        }

        public static PacketBuilder @ushort(this PacketBuilder builder, ushort data)
        {
            return builder.Append (data);
        }

        public static PacketBuilder @uint(this PacketBuilder builder, uint data)
        {
            return builder.Append (data);
        }

        public static PacketBuilder @ulong(this PacketBuilder builder, ulong data)
        {
            return builder.Append (data);
        }

        public static PacketBuilder @class<TSource>(this PacketBuilder builder, TSource data) where TSource : class
        {
            return builder.Append (data);
        }

        public static PacketBuilder @packetbuilder(this PacketBuilder sourceBuilder, PacketBuilder packetbuilder)
        {
            return sourceBuilder.Append (packetbuilder.Build ());
        }
    }
}
