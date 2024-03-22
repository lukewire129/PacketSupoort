using System.Collections.Generic;
using System.Reflection;

namespace BytePacketSupport
{
    public static partial class AppendHelper
    {

        public static byte[] Append<TSource>(this byte b, TSource AppenClass) where TSource : class
        {
            FieldInfo[] fields = typeof (TSource).GetFields (BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            byte[] result = new byte[] { b };

            return result.Append (PacketParse.Serialization (AppenClass));
        }

        public static byte[] Append<TSource>(this byte[] b, TSource AppenClass) where TSource : class
        {
            FieldInfo[] fields = typeof (TSource).GetFields (BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            byte[] result = b;

            return result.Append (PacketParse.Serialization (AppenClass));
        }
    }
}
