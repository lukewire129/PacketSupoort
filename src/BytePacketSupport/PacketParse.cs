using BytePacketSupport.Attibutes;
using BytePacketSupport.Converter;
using BytePacketSupport.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace BytePacketSupport
{
    public static class PacketParse
    {
        public static byte[] Serialize<TSource>(TSource AppendClass) where TSource : class
        {
            FieldInfo[] fields = typeof (TSource).GetFields (BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            List<byte> result = new List<byte>();
            foreach (FieldInfo field in fields)
            {
                object value = field.GetValue (AppendClass);

                // 필드의 타입으로 캐스팅
                if (field.FieldType == typeof (string))
                {
                    result.AddRange (ByteConverter.GetBytes (value.Cast<string> ()));
                }
                else if (field.FieldType == typeof (short))
                {
                    var attribute = ((EndianAttribute)Attribute.GetCustomAttribute (field, typeof (EndianAttribute)));
                    
                    if (attribute == null)
                    {
                        result.AddRange(ByteConverter.GetBytes ((short)value));
                        continue;
                    }
                    bool ret = isSameEndian ((attribute._endian));
                    result.AddRange (ByteConverter.GetBytes ((short)value, ret));
                }
                else if (field.FieldType == typeof (int))
                {
                    var attribute = ((EndianAttribute)Attribute.GetCustomAttribute (field, typeof (EndianAttribute)));

                    if (attribute == null)
                    {
                        result.AddRange (ByteConverter.GetBytes ((int)value));
                        continue;
                    }
                    bool ret = isSameEndian ((attribute._endian));
                    result.AddRange (ByteConverter.GetBytes ((int)value, ret));
                }
                else if (field.FieldType == typeof (long))
                {
                    var attribute = ((EndianAttribute)Attribute.GetCustomAttribute (field, typeof (EndianAttribute)));

                    if (attribute == null)
                    {
                        result.AddRange (ByteConverter.GetBytes ((long)value));
                        continue;
                    }
                    bool ret = isSameEndian ((attribute._endian));
                    result.AddRange (ByteConverter.GetBytes ((long)value, ret));
                }
                else if (field.FieldType == typeof (ushort))
                {
                    var attribute = ((EndianAttribute)Attribute.GetCustomAttribute (field, typeof (EndianAttribute)));

                    if (attribute == null)
                    {
                        result.AddRange (ByteConverter.GetBytes ((ushort)value));
                        continue;
                    }
                    bool ret = isSameEndian ((attribute._endian));
                    result.AddRange (ByteConverter.GetBytes ((ushort)value, ret));
                }
                else if (field.FieldType == typeof (uint))
                {
                    var attribute = ((EndianAttribute)Attribute.GetCustomAttribute (field, typeof (EndianAttribute)));

                    if (attribute == null)
                    {
                        result.AddRange (ByteConverter.GetBytes ((uint)value));
                        continue;
                    }
                    bool ret = isSameEndian ((attribute._endian));
                    result.AddRange (ByteConverter.GetBytes ((uint)value, ret));
                }
                else if (field.FieldType == typeof (ulong))
                {
                    var attribute = ((EndianAttribute)Attribute.GetCustomAttribute (field, typeof (EndianAttribute)));

                    if (attribute == null)
                    {
                        result.AddRange (ByteConverter.GetBytes ((ulong)value));
                        continue;
                    }
                    bool ret = isSameEndian ((attribute._endian));
                    result.AddRange (ByteConverter.GetBytes ((ulong)value, ret));
                }
                else if (field.FieldType == typeof (byte))
                {
                    result.Add (value.Cast<byte> ());
                }
                else if (field.FieldType == typeof (byte[]))
                {
                    result.AddRange (value.Cast<byte[]> ());
                }
                else if (field.FieldType == typeof (List<byte>))
                {
                    result.AddRange (value.Cast<List<byte>> ());
                }
            }

            return result.ToArray();
        }

        public static T Deserialize<T>(byte[] bytes) where T : new()
        {
            FieldInfo[] fields = typeof (T).GetFields (BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            var instance = Activator.CreateInstance<T> ();
            BinaryReader reader = new BinaryReader (new MemoryStream (bytes, writable: false));
            foreach (FieldInfo field in fields)
            {
                if (field.FieldType == typeof (string))
                {
                    var attribute = ((ByteSizeAttribute)Attribute.GetCustomAttribute (field, typeof (ByteSizeAttribute)));

                    if (attribute == null)
                        continue;
                    byte[] value = reader.ReadBytes (attribute.Size);
                    field.SetValue (instance, Encoding.ASCII.GetString (value, 0, value.Length));
                }
                else if (field.FieldType == typeof (short))
                {
                    byte[] value = GetBytes (field, reader, 2);
                    field.SetValue (instance, BitConverter.ToInt16(value));
                }
                else if (field.FieldType == typeof (int))
                {
                    byte[] value = GetBytes (field, reader, 4);
                    field.SetValue (instance, BitConverter.ToInt32 (value));
                }
                else if (field.FieldType == typeof (long))
                {
                    byte[] value = GetBytes (field, reader, 8);
                    field.SetValue (instance, BitConverter.ToInt64 (value));
                }
                else if (field.FieldType == typeof (byte))
                {
                    field.SetValue (instance, reader.ReadByte ());
                }
                else if (field.FieldType == typeof (ushort))
                {
                    byte[] value = GetBytes (field, reader, 2);
                    field.SetValue (instance, BitConverter.ToUInt16 (value));
                }
                else if (field.FieldType == typeof (uint))
                {
                    byte[] value = GetBytes (field, reader, 2);
                    field.SetValue (instance, BitConverter.ToUInt32 (value));
                }
                else if (field.FieldType == typeof (ulong))
                {
                    byte[] value = GetBytes (field, reader, 2);
                    field.SetValue (instance, BitConverter.ToUInt64 (value));
                }
                else if (field.FieldType == typeof (byte[]))
                {
                    var attribute = ((ByteSizeAttribute)Attribute.GetCustomAttribute (field, typeof (ByteSizeAttribute)));

                    int length = 0;
                    if (attribute != null)
                    {
                        length = attribute.Size;
                    }
                    else
                    {
                        byte[] temp = (byte[])field.GetValue (instance);
                        if (temp == null)
                            continue;
                        if (temp.Count () == 0)
                            continue;

                        length = temp.Count ();
                    }
                    field.SetValue (instance, reader.ReadBytes(length));
                }
                else if (field.FieldType == typeof(System.Collections.Generic.List<Byte>))
                {
                    var attribute = ((ByteSizeAttribute)Attribute.GetCustomAttribute (field, typeof (ByteSizeAttribute)));
                    int length = 0;
                    if (attribute != null)
                    {
                        length = attribute.Size;
                    }
                    else
                    {
                        var temp = ((List<Byte>)field.GetValue (instance));
                        if (temp == null)
                            continue;
                        if (temp.Count () == 0)
                            continue;

                        length = temp.Count ();
                    }

                    field.SetValue (instance, reader.ReadBytes (length));
                }
            }
            return instance;
        }
        private static T Cast<T>(this object obj)
        {
            return (T)obj;
        }

        private static bool isSameEndian (Endian endian)
        {
            bool isSetEnidan = endian == Endian.LITTLE;

            if (BitConverter.IsLittleEndian == isSetEnidan)
                return true;

            return false;
        }

        private static byte[] GetBytes(FieldInfo field, BinaryReader br, int length)
        {
            byte[] bytes = br.ReadBytes (length);
            var attribute = ((EndianAttribute)Attribute.GetCustomAttribute (field, typeof (EndianAttribute)));

            if (attribute == null)
                return bytes;

            bool ret = isSameEndian (attribute._endian);
            if (ret == true)
                return bytes;

            return bytes.Reverse ().ToArray();
        }
    }
}
