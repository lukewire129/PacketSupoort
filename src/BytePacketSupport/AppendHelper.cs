using System;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace BytePacketSupport
{
    public static partial class AppendHelper
    {
        public static byte[] Append<TSource>(this byte b, TSource AppenClass) where TSource : class
        {
            FieldInfo[] fields = typeof (TSource).GetFields (BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            byte[] result = new byte[] { b };
            foreach (FieldInfo field in fields)
            {
                object value = field.GetValue (AppenClass);

                // 필드의 타입으로 캐스팅
                if (field.FieldType == typeof (int))
                {
                    result = result.Append (value.GetFieldType<int> ());
                }
                else if (field.FieldType == typeof (string))
                {
                    result = result.Append (value.GetFieldType<string> ());
                }
                else if (field.FieldType == typeof (long))
                {
                    result = result.Append (value.GetFieldType<string> ());
                }
                else if (field.FieldType == typeof (short))
                {
                    result = result.Append (value.GetFieldType<string> ());
                }
                else if (field.FieldType == typeof (byte))
                {
                    result = result.Append (value.GetFieldType<string> ());
                }
                else if (field.FieldType == typeof (byte[]))
                {
                    result = result.Append (value.GetFieldType<string> ());
                }
            }

            return result;
        }

        public static byte[] Append<TSource>(this byte[] b, TSource AppenClass) where TSource : class
        {
            FieldInfo[] fields = typeof (TSource).GetFields (BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            byte[] result = b;
            foreach (FieldInfo field in fields)
            {
                object value = field.GetValue (AppenClass);

                // 필드의 타입으로 캐스팅
                if (field.FieldType == typeof (int))
                {
                    result = result.Append (value.GetFieldType<int> ());
                }
                else if (field.FieldType == typeof (string))
                {
                    result = result.Append (value.GetFieldType<string> ());
                }
                else if (field.FieldType == typeof (long))
                {
                    result = result.Append (value.GetFieldType<string> ());
                }
                else if (field.FieldType == typeof (short))
                {
                    result = result.Append (value.GetFieldType<string> ());
                }
                else if (field.FieldType == typeof (byte))
                {
                    result = result.Append (value.GetFieldType<string> ());
                }
                else if (field.FieldType == typeof (byte[]))
                {
                    result = result.Append (value.GetFieldType<string> ());
                }
            }

            return result;
        }

        private static T GetFieldType<T>(this object obj)
        {
            return (T)obj;
        }
    }
}
