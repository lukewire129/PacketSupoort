using System;
using System.Collections.Generic;
using System.Linq;

namespace BytePacketSupport
{
    public static partial class AppendHelper
    {
        public static byte[] @byte(this byte b, byte AppenByte) => new byte[] { b, AppenByte };
        public static byte[] @byte(this IEnumerable<byte> bs, byte AppenByte) => bs.Append<byte> (AppenByte).ToArray ();
        public static byte[] @bytes(this byte b, IEnumerable<byte> AppenBytes)
        {
            byte[] ToTalBytes = new byte[1 + AppenBytes.Count()];
            ToTalBytes[0] = b;
            Buffer.BlockCopy (AppenBytes.ToArray(), 0, ToTalBytes, 1, AppenBytes.Count());

            return ToTalBytes;
        }

        public static byte[] @bytes(this IEnumerable<byte> bs, IEnumerable<byte> AppenBytes)
        {
            byte[] ToTalBytes = new byte[bs.Count() + AppenBytes.Count()];

            Buffer.BlockCopy (bs.ToArray(), 0, ToTalBytes, 0, bs.Count());
            Buffer.BlockCopy (AppenBytes.ToArray(), 0, ToTalBytes, bs.Count (), AppenBytes.Count());

            return ToTalBytes;
        }

        public static byte[] @bytes(this IEnumerable<byte> bs, IEnumerable<byte> AppenBytes, int offset, int count)
        {
            byte[] ToTalBytes = new byte[bs.Count () + AppenBytes.Count ()];

            Buffer.BlockCopy (bs.ToArray (), 0, ToTalBytes, 0, bs.Count ());
            Buffer.BlockCopy (AppenBytes.ToArray (), offset, ToTalBytes, bs.Count (), count);

            return ToTalBytes;
        }
    }
}
