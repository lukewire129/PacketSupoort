using System;
using System.Collections.Generic;
using System.Linq;

namespace BitPacketSupoort.Extentions
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

        public static T Test<T>(this byte byteValue) where T : Enum
        {
            var enumType = typeof (T);
            var attributes = enumType.GetCustomAttributes (false);
            string attributeName = "BitSupportFlagsAttribute";
            bool hasAttribute = attributes.Any (attr => attr.GetType ().Name == attributeName);
            if (hasAttribute)
            {
                string flagsEnumName = $"{enumType.Name}Flags";
                var assembly = enumType.Assembly;

                // 동일한 어셈블리 내에서 새로운 타입을 찾음
                var flagsEnumType = assembly.GetType (enumType.Namespace + "." + flagsEnumName);

                if (flagsEnumType != null && flagsEnumType.IsEnum)
                {
                    // Flags 타입으로 byteValue 변환 후 다시 T로 변환하여 반환
                    var flagsEnumValue = Enum.ToObject (flagsEnumType, byteValue);

                }
                else
                {
                    throw new InvalidOperationException ($"Enum type '{flagsEnumName}' not found.");
                }
            }

            return (T)Enum.ToObject (typeof (T), byteValue);
        }

        //public static bool HasAnyFlag<T>(this byte byteValue)
        //{
        //    var enumType = typeof (T);
        //    var attributes = enumType.GetCustomAttributes (false);
        //    string attributeName = "BitSupportFlagsAttribute";
        //    bool hasAttribute = attributes.Any (attr => attr.GetType ().Name == attributeName);

        //    if (hasAttribute)
        //    {
        //        string flagsEnumName = $"{e.Name}Flags";
        //        var assembly = e.Assembly;

        //        // 동일한 어셈블리 내에서 새로운 타입을 찾음
        //        var flagsEnumType = assembly.GetType (e.Namespace + "." + flagsEnumName);

        //        if (flagsEnumType != null && flagsEnumType.IsEnum)
        //        {
        //            return flagsEnumType;
        //        }
        //        else
        //        {
        //        }
        //    }
        //    throw new InvalidOperationException ($"Enum type '{enumType.Name}Flags' not found.");
        //}

        //public static bool HasNotFlag<T>(this byte byteValue)
        //{
        //    var enumType = typeof (T);
        //    var attributes = enumType.GetCustomAttributes (false);
        //    string attributeName = "BitSupportFlagsAttribute";
        //    bool hasAttribute = attributes.Any (attr => attr.GetType ().Name == attributeName);

        //    if (hasAttribute)
        //    {
        //        string flagsEnumName = $"{enumType.Name}Flags";
        //        var assembly = enumType.Assembly;

        //        // 동일한 어셈블리 내에서 새로운 타입을 찾음
        //        var flagsEnumType = assembly.GetType (enumType.Namespace + "." + flagsEnumName);

        //        if (flagsEnumType != null && flagsEnumType.IsEnum)
        //        {
        //            flagsEnumType.HasFlag ();
        //        }
        //    }
        //    throw new InvalidOperationException ($"Enum type '{enumType.Name}Flags' not found.");
        //}

        public static byte ToByte(this Enum enumValue)
        {
            return Convert.ToByte (enumValue);
        }
        public static byte ToByte<T>(this Enum enumValue)
        {
            return Convert.ToByte (enumValue);
        }
    }
}