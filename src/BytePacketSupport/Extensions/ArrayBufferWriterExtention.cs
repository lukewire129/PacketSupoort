using System;
using System.Buffers;

namespace BytePacketSupport.Extensions
{
    public static class ArrayBufferWriterExtension
    {
        public static ReservedSpan Reserve(this ArrayBufferWriter<byte> writer, int length)
            => new ReservedSpan (writer, length);

        public static byte[] ToArray(this ArrayBufferWriter<byte> writer)
            => writer.WrittenSpan.ToArray ();
    }

    public ref struct ReservedSpan
    {
        private int _length;
        private ArrayBufferWriter<byte> _list;

        public ReservedSpan(ArrayBufferWriter<byte> list, int length)
        {
            _length = length;
            _list = list;
            Span = list.GetSpan (length);
        }

        public Span<byte> Span { get; }

        public static implicit operator Span<byte>(ReservedSpan reserved) => reserved.Span;

        public void Dispose() => _list.Advance (_length);
    }
}
