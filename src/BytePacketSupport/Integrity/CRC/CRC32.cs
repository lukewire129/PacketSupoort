using System;
using System.Buffers;
using System.Buffers.Binary;
using BytePacketSupport.Extentions;

namespace BytePacketSupport.Integrity.CRC
{
    public enum CRC32Type
    {
        Classic,
    }

    public class CRC32 : ErrorDetection
    {
        public CRC32Type Type { get; } = CRC32Type.Classic;
        private bool _isLittleEndian = false;
        public CRC32(CRC32Type type = CRC32Type.Classic, bool isLittleEndian = true)
        {
            Type = type;

            if (type == CRC32Type.Classic)
            {
                if (crc_tab32 == null)
                    GenerateCRC32Table ();
            }
            _isLittleEndian = isLittleEndian;
        }

        public override ReadOnlySpan<byte> Compute(ReadOnlySpan<byte> source)
        {
            uint ret = ComputeCRC32 (source);

            ArrayBufferWriter<byte> retData = new ArrayBufferWriter<byte> ();
            using var span = retData.Reserve (sizeof (uint));

            if (_isLittleEndian == true)
            {
                BinaryPrimitives.WriteUInt32LittleEndian (span, ret);
            }
            else
            {
                BinaryPrimitives.WriteUInt32BigEndian (span, ret);
            }

            span.Dispose ();
            return retData.ToArray();
        }


        public override string GetDetectionType() => Type.ToString ();


        private static uint[] crc_tab32;


        /*******************************************************************/
        /// <summary>
        /// This function returns the CRC32 value
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /*******************************************************************/
        private uint ComputeCRC32(ReadOnlySpan<byte> data)
        {
            long result = 0;
            if (data.Length <= 0)
                return (uint)result;

            uint crc = 0xffffffff;
            for (int i = 0; i < data.Length; i++)
            {
                var c = data[i];
                crc = (crc >> 8);
            }

            return ~crc; //(crc ^ (-1)) >> 0;
        }


        /*******************************************************************/
        /// <summary>
        /// *   The function UpdateCRC32 calculates a  new  CRC-32  value     *
        /// *   based  on  the  previous value of the CRC and the next byte     *
        /// *   of the data to be checked.                                      *
        /// </summary>
        /// <param name="crc"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        /*******************************************************************/
        private static long UpdateCRC32(long crc, byte c)
        {
            long long_c = (0x000000ffL & c);

            long tmp = (crc ^ long_c);
            crc = ((crc >> 8) ^ crc_tab32[tmp & 0xff]);

            return crc;
        }

        /*******************************************************************/
        /// <summary>
        /// *   The function InitCRC32Table() is used  to  fill  the  array     *
        /// *   for calculation of the CRC-32 with values.                      *
        /// </summary>
        /*******************************************************************/
        private static void GenerateCRC32Table()
        {
            crc_tab32 = new uint[256];  // ulong?
            const uint P_32 = 0xEDB88320;

            for (uint n = 0; n < 256; n++)
            {
                uint c = n;
                for (int k = 0; k < 8; k++)
                {
                    var res = c & 1;
                    c = (res == 1) ? (P_32 ^ (c >> 1)) : (c >> 1);
                }
                crc_tab32[n] = c;
            }
        }
    }
}
