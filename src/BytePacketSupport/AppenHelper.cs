using System;
using System.Collections.Generic;
using System.Text;

namespace BytePacketSupport
{
    public static class AppendHelper
    {
        public static byte[] AppendByte(this byte b, byte AppenByte)
        {
            byte[] ToTalBytes = new byte[] { b, AppenByte };

            return ToTalBytes;
        }

        public static byte[] AppendBytes(this byte b, byte[] AppenBytes)
        {
            byte[] ToTalBytes = new byte[1 + AppenBytes.Length];
            ToTalBytes[0] = b;
            Buffer.BlockCopy (AppenBytes, 0, ToTalBytes, 1, AppenBytes.Length);

            return ToTalBytes;
        }

        public static byte[] AppendASCII(this byte b, string asciiByte)
        {
            byte[] asciibyte = Encoding.ASCII.GetBytes (asciiByte);
            return b.AppendBytes (asciibyte);
        }

        public static byte[] AppendByte(this byte[] bs, byte AppenByte)
        {
            byte[] ToTalBytes = new byte[bs.Length + 1];

            Buffer.BlockCopy (bs, 0, ToTalBytes, 0, bs.Length);
            ToTalBytes[bs.Length] = AppenByte;

            return ToTalBytes;
        }

        public static byte[] AppendBytes(this byte[] bs, byte[] AppenBytes)
        {
            byte[] ToTalBytes = new byte[bs.Length + AppenBytes.Length];

            Buffer.BlockCopy (bs, 0, ToTalBytes, 0, bs.Length);
            Buffer.BlockCopy (AppenBytes, 0, ToTalBytes, bs.Length, AppenBytes.Length);

            return ToTalBytes;
        }

        public static byte[] AppendASCII(this byte[] bs, string asciiByte)
        {
            byte[] asciibyte = Encoding.ASCII.GetBytes (asciiByte);
            return bs.AppendBytes (asciibyte);
        }

        public static byte[] AppendBytes(this byte[] bs, byte[] AppenBytes, int offset, int count)
        {
            byte[] ToTalBytes = new byte[bs.Length + AppenBytes.Length];

            Buffer.BlockCopy (bs, 0, ToTalBytes, 0, bs.Length);
            Buffer.BlockCopy (AppenBytes, offset, ToTalBytes, bs.Length, count);

            return ToTalBytes;
        }
        public static byte[] AppendASCII(this byte[] bs, string asciiByte, int offset, int count)
        {
            byte[] asciibyte = Encoding.ASCII.GetBytes (asciiByte);
            return bs.AppendBytes (asciibyte, offset, count);
        }

        public static byte[] AppendBytes(this byte b, List<byte> AppenBytes)
        {
            byte[] source = AppenBytes.ToArray ();
            return b.AppendBytes (source);
        }

        public static byte[] AppendBytes(this byte[] bs, List<byte> AppenBytes)
        {
            byte[] source = AppenBytes.ToArray ();
            return bs.AppendBytes (source);
        }

        public static byte[] AppendBytes(this byte[] bs, List<byte> AppenBytes, int offset, int count)
        {
            byte[] source = AppenBytes.ToArray ();
            return bs.AppendBytes (source, offset, count);
        }
    }
}
