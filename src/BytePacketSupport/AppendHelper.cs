using System;
using System.Collections.Generic;
using System.Linq;

namespace BytePacketSupport
{
    public static partial class AppendHelper
    {
        public static byte[] @byte(this byte b, byte AppenByte) => new byte[] { b, AppenByte };
        public static byte[] @byte(this IEnumerable<byte> bs, byte AppenByte) => bs.Append<byte> (AppenByte).ToArray ();
        public static byte[] @bytes(this byte b, byte[] AppenBytes)
        {
            byte[] ToTalBytes = new byte[1 + AppenBytes.Length];
            ToTalBytes[0] = b;
            Buffer.BlockCopy (AppenBytes, 0, ToTalBytes, 1, AppenBytes.Length);

            return ToTalBytes;
        }

        public static byte[] @bytes(this byte[] bs, byte[] AppenBytes)
        {
            byte[] ToTalBytes = new byte[bs.Length + AppenBytes.Length];

            Buffer.BlockCopy (bs, 0, ToTalBytes, 0, bs.Length);
            Buffer.BlockCopy (AppenBytes, 0, ToTalBytes, bs.Length, AppenBytes.Length);

            return ToTalBytes;
        }

        public static byte[] @bytes(this byte[] bs, byte[] AppenBytes, int offset, int count)
        {
            byte[] ToTalBytes = new byte[bs.Length + AppenBytes.Length];

            Buffer.BlockCopy (bs, 0, ToTalBytes, 0, bs.Length);
            Buffer.BlockCopy (AppenBytes, offset, ToTalBytes, bs.Length, count);

            return ToTalBytes;
        }

        public static byte[] @bytes(this byte b, List<byte> AppenBytes) => b.@bytes (AppenBytes.ToArray ());

        public static byte[] @bytes(this byte[] bs, List<byte> AppenBytes) => bs.@bytes (AppenBytes.ToArray ());

        public static byte[] @bytes(this byte[] bs, List<byte> AppenBytes, int offset, int count) => bs.@bytes (AppenBytes.ToArray (), offset, count);
    }
}
