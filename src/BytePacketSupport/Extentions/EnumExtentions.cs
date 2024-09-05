using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BytePacketSupport.Extentions
{
    [AttributeUsage (AttributeTargets.Enum, Inherited = false, AllowMultiple = false)]
    public class AutoFlagsAttribute : Attribute
    {
    }
    public static class EnumHelper
    {
        private static readonly Dictionary<Type, byte[]> BitValuesCache = new Dictionary<Type, byte[]> ();

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

        public static List<string> ToEnumString<T>(this byte byteValue) where T : Enum
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

        public static List<T> ToEnum<T>(this byte byteValue) where T : Enum
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
    }
}