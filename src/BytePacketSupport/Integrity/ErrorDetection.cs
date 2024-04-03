using System;
using System.Buffers;

namespace BytePacketSupport.Integrity
{
    public abstract class ErrorDetection
    {
        public abstract ReadOnlySpan<byte> Compute(ReadOnlySpan<byte> source);

        public abstract string GetDetectionType();
    }
}
