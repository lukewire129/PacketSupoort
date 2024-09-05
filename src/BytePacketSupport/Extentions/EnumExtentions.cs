using System;
using System.Collections.Generic;
using System.Linq;

namespace BytePacketSupport.Extentions
{
    public static class EnumHelper
    {
        public static byte Byte<T>(params T[] enumValues) where T : Enum
        {
            byte result = 0;
            var values = Enum.GetValues (typeof (T)).Cast<Enum> ().ToArray ();
            foreach (var value in enumValues)
            {
                int idx = Convert.ToInt32 (value);

                result |= (byte)(1 << idx);
            }

            return result;
        }

        public static List<string> ToEnumDataString<T>(this byte byteValue) where T : Enum
        {
            var result = new List<string> ();

            int bitPosition = 0;
            if (byteValue == 0)
                return null;

            foreach (T value in Enum.GetValues (typeof (T)).Cast<T> ().ToArray ())
            {
                byte bitValue = (byte)(1 << bitPosition);
                bitPosition++;

                if ((byteValue & bitValue) == bitValue)
                {
                    result.Add (value.ToString ());
                }
            }

            return result;
        }

        public static List<T> ToEnumData<T>(this byte byteValue) where T : Enum
        {
            var result = new List<T> ();
            int bitPosition = 0;

            if (byteValue == 0)
                return null;

            foreach (T value in Enum.GetValues (typeof (T)).Cast<T> ().ToArray ())
            {
                byte bitValue = (byte)(1 << bitPosition);
                bitPosition++;

                if ((byteValue & bitValue) == bitValue)
                {
                    result.Add (value);
                }
            }

            return result;
        }

        public static T ToEnum<T>(this byte byteValue) where T : Enum
        {
            return (T)Enum.ToObject (typeof (T), byteValue);
        }

        public static byte ToByte(this Enum enumValue)
        {
            return Convert.ToByte (enumValue);
        }
    }
}