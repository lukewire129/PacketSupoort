using BytePacketSupport.Extentions;
using System;
using System.Buffers;

namespace BytePacketSupport.Integrity.Checksum
{
    [Obsolete ("CheckSum8Type is obsolete. Use Checksum8Type instead.")]
    public enum CheckSum8Type
    {
        Xor,
        NMEA,
        Modulo256,
        TwosComplement,
    }

    public enum Checksum8Type
    {
        Xor,
        NMEA,
        Modulo256,
        TwosComplement,
    }

    public class Checksum8 : ErrorDetection
    {
        public Checksum8Type Type { get; } = Checksum8Type.Xor;

        public Checksum8(Checksum8Type type = Checksum8Type.Xor)
        {
            Type = type;
        }


        public override ReadOnlySpan<byte> Compute(ReadOnlySpan<byte> source)
        {
            byte ret = 0x00;
            if (Type == Checksum8Type.Xor || Type == Checksum8Type.NMEA)
                ret = (Checksum8Xor (source));
            else if (Type == Checksum8Type.Modulo256)
                ret = (Checksum8Modulo256 (source));
            else if (Type == Checksum8Type.TwosComplement)
                ret = (Checksum8TwosComplement (source));

            ArrayBufferWriter<byte> retData = new ArrayBufferWriter<byte> ();
            using (var span = retData.Reserve (sizeof (byte)))
            {
                span.Span[0] = ret;
            }
            return retData.WrittenSpan;
        }

        public override string GetDetectionType() => Type.ToString ();


        /*****************************************************/
        /// <summary>
        /// This function returns 1byte checksum. [xor]
        /// </summary>
        /// <param name="data"></param>
        /// <see cref="https://www.scadacore.com/tools/programming-calculators/online-checksum-calculator/"/>
        /// <returns></returns>
        /*****************************************************/
        private byte Checksum8Xor(ReadOnlySpan<byte> data)
        {
            byte result = 0;

            for (int i = 0; i < data.Length; i++)
                result ^= data[i];

            return result;
        }

        /*****************************************************/
        /// <summary>
        /// This function returns 1byte checksum. [modulo-256]
        /// </summary>
        /// <param name="data"></param>
        /// <see cref="https://www.scadacore.com/tools/programming-calculators/online-checksum-calculator/"/>
        /// <returns></returns>
        /*****************************************************/
        private static byte Checksum8Modulo256(ReadOnlySpan<byte> data)
        {
            ulong sum = 0;
            for (int i = 0; i < data.Length; i++)
                sum += data[i];
            byte result = (byte)(sum % 256);

            return result;
        }

        /*****************************************************/
        /// <summary>
        /// This function returns 1byte checksum. [2's complement]
        /// </summary>
        /// <param name="data"></param>
        /// <see cref="https://www.scadacore.com/tools/programming-calculators/online-checksum-calculator/"/>
        /// <returns></returns>
        /*****************************************************/
        private static byte Checksum8TwosComplement(ReadOnlySpan<byte> data)
        {
            ulong sum = 0;
            for (int i = 0; i < data.Length; i++)
                sum += data[i];
            byte result = (byte)(0x100 - sum);

            return result;
        }
    }
}
