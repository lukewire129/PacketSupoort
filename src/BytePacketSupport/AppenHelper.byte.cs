using System;
using System.Collections.Generic;

namespace BytePacketSupport
{
    public static partial class AppendHelper
    {
        public static byte[] Append(this byte b, byte AppenByte)
        {
            byte[] ToTalBytes = new byte[] { b, AppenByte };

            return ToTalBytes;
        }

        public static byte[] Append(this byte b, byte[] AppenBytes)
        {
            byte[] ToTalBytes = new byte[1 + AppenBytes.Length];
            ToTalBytes[0] = b;
            Buffer.BlockCopy (AppenBytes, 0, ToTalBytes, 1, AppenBytes.Length);

            return ToTalBytes;
        }

        public static byte[] Append(this byte[] bs, byte AppenByte)
        {
            byte[] ToTalBytes = new byte[bs.Length + 1];

            Buffer.BlockCopy (bs, 0, ToTalBytes, 0, bs.Length);
            ToTalBytes[bs.Length] = AppenByte;

            return ToTalBytes;
        }

        public static byte[] Append(this byte[] bs, byte[] AppenBytes)
        {
            byte[] ToTalBytes = new byte[bs.Length + AppenBytes.Length];

            Buffer.BlockCopy (bs, 0, ToTalBytes, 0, bs.Length);
            Buffer.BlockCopy (AppenBytes, 0, ToTalBytes, bs.Length, AppenBytes.Length);

            return ToTalBytes;
        }

        public static byte[] Append(this byte[] bs, byte[] AppenBytes, int offset, int count)
        {
            byte[] ToTalBytes = new byte[bs.Length + AppenBytes.Length];

            Buffer.BlockCopy (bs, 0, ToTalBytes, 0, bs.Length);
            Buffer.BlockCopy (AppenBytes, offset, ToTalBytes, bs.Length, count);

            return ToTalBytes;
        }

        public static byte[] Append(this byte b, List<byte> AppenBytes)
        {
            byte[] source = AppenBytes.ToArray ();
            return b.Append (source);
        }

        public static byte[] Append(this byte[] bs, List<byte> AppenBytes)
        {
            byte[] source = AppenBytes.ToArray ();
            return bs.Append (source);
        }

        public static byte[] Append(this byte[] bs, List<byte> AppenBytes, int offset, int count)
        {
            byte[] source = AppenBytes.ToArray ();
            return bs.Append (source, offset, count);
        }
    }
}
