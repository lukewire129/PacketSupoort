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
    public static class EnumExtentions
    {
        private static readonly Dictionary<Type, byte[]> BitValuesCache = new Dictionary<Type, byte[]> ();

        public static byte EnumByte<T>(params T[] enumValues) where T : Enum
        {
            byte result = 0;
            var values = Enum.GetValues (typeof (T)).Cast<Enum> ().ToArray ();

            bool isNone = values.Any (x => x.ToString ().ToUpper () == "NONE");
            foreach (var value in enumValues)
            {
                int idx = Convert.ToInt32 (value);
                if(isNone)

                result |= (byte)(1 << Convert.ToInt32 (value));
            }

            return result;
        }
        private static byte[] GetBitValues(Type enumType)
        {
            if (BitValuesCache.TryGetValue (enumType, out var bitValues))
                return bitValues;

            var attribute = enumType.GetCustomAttributes (typeof (AutoFlagsAttribute), false)
                .Cast<AutoFlagsAttribute> ()
                .SingleOrDefault ();

            if (attribute != null)
            {
                var values = Enum.GetValues (enumType).Cast<Enum> ().ToArray ();
                var bitValuesArray = new byte[values.Length];
                for (int i = 0; i < values.Length; i++)
                {
                    bitValuesArray[i] = (byte)(1 << i);
                }
                BitValuesCache[enumType] = bitValuesArray;
                return bitValuesArray;
            }

            throw new InvalidOperationException ($"Enum type {enumType} does not have the AutoFlags attribute.");
        }

        public static byte ToByte(this Enum enumValue)
        {
            byte result = 0;
            var enumType = enumValue.GetType ();
            var bitValues = GetBitValues (enumType);
            var values = Enum.GetValues (enumType).Cast<Enum> ().ToArray ();
            int index = Array.IndexOf (values, enumValue);

            if (index != -1)
            {
                result = bitValues[index];
            }

            return result;
        }

        public static List<string> ToEnumString(this byte byteValue, Type enumType)
        {
            var result = new List<string> ();
            var bitValues = GetBitValues (enumType);
            var values = Enum.GetValues (enumType).Cast<Enum> ().ToArray ();

            for (int i = 0; i < values.Length; i++)
            {
                if ((byteValue & bitValues[i]) != 0)
                {
                    result.Add (values[i].ToString ());
                }
            }

            return result.Count > 0 ? result : new List<string> { "NONE" };
        }

        public static T ToEnum<T>(this byte byteValue) where T : Enum
        {
            var enumType = typeof (T);
            var bitValues = GetBitValues (enumType);
            var values = Enum.GetValues (enumType).Cast<Enum> ().ToArray ();
            int result = 0;

            for (int i = 0; i < values.Length; i++)
            {
                if ((byteValue & bitValues[i]) != 0)
                {
                    result |= (int)bitValues[i];
                }
            }

            return (T)Enum.ToObject (enumType, result);
        }

        public static bool HasFlag<T>(this T state, T flag) where T : Enum
        {
            var stateValue = (int)(object)state;
            var flagValue = (int)(object)flag;
            return (stateValue & flagValue) == flagValue;
        }
    }
}