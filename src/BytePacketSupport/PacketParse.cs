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
        public static byte[] Serialization<TSource>(TSource AppendClass) where TSource : class
        {
            FieldInfo[] fields = typeof (TSource).GetFields (BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            byte[] result = new byte[0];
            foreach (FieldInfo field in fields)
            {
                object value = field.GetValue (AppendClass);

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
                    result = result.Append (value.GetFieldType<long> ());
                }
                else if (field.FieldType == typeof (short))
                {
                    result = result.Append (value.GetFieldType<short> ());
                }
                else if (field.FieldType == typeof (byte))
                {
                    result = result.Append (value.GetFieldType<byte> ());
                }
                else if (field.FieldType == typeof (byte[]))
                {
                    result = result.Append (value.GetFieldType<byte[]> ());
                }
                else if (field.FieldType == typeof (List<byte>))
                {
                    result = result.Append (value.GetFieldType<List<byte>> ());
                }
            }

            return result;
        }

        public static T DeserializeObject<T>(byte[] bytes) where T : new()
        {
            FieldInfo[] fields = typeof (T).GetFields (BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            var instance = Activator.CreateInstance<T> ();
            BinaryReader reader = new BinaryReader (new MemoryStream (bytes, writable: false));
            long position = 0;
            foreach (FieldInfo field in fields)
            {
                if (field.FieldType == typeof (int))
                {
                    field.SetValue (instance, reader.ReadInt32 ());
                }
                else if (field.FieldType == typeof (string))
                {
                    var attribute = field.CustomAttributes.FirstOrDefault ();
                    if (attribute == null)
                        continue;
                    
                    position = reader.BaseStream.Position;
                    var value = Encoding.ASCII.GetString (bytes, Convert.ToInt32(position), (int)attribute.ConstructorArguments.First ().Value);
                    field.SetValue (instance, value);
                }
                else if (field.FieldType == typeof (long))
                {
                    field.SetValue (instance, reader.ReadInt64 ());
                }
                else if (field.FieldType == typeof (short))
                {
                    field.SetValue (instance, reader.ReadInt16 ());
                }
                else if (field.FieldType == typeof (byte))
                {
                    field.SetValue (instance, reader.ReadByte ());
                }
                else if (field.FieldType == typeof (byte[]))
                {
                    var attribute = field.CustomAttributes.FirstOrDefault ();
                    int length = 0;
                    if (attribute != null)
                    {
                        length = (int)attribute.ConstructorArguments.First ().Value;
                    }
                    else
                    {
                        length = ((byte[])field.GetValue (instance)).Count ();
                    }
                    field.SetValue (instance, reader.ReadBytes(length));
                }
                else if (field.FieldType == typeof(System.Collections.Generic.List<Byte>))
                {
                    var attribute = field.CustomAttributes.FirstOrDefault ();
                    int length = 0;
                    if (attribute != null)
                    {
                        length = (int)attribute.ConstructorArguments.First ().Value;
                    }
                    else
                    {
                        length = ((List<Byte>)field.GetValue (instance)).Capacity;
                        if (length == 0)
                            continue;
                    }
                    field.SetValue (instance, reader.ReadBytes (length).ToList());
                }
            }
            return instance;
        }
        private static T GetFieldType<T>(this object obj)
        {
            return (T)obj;
        }
    }
}
