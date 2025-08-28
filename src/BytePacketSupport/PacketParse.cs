using PacketSupport.Core.Attibutes;
using PacketSupport.Core.Converter;
using PacketSupport.Core.Enums;
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
        public static byte[] Deserialize<TSource>(TSource AppendClass) where TSource : class
        {
            FieldInfo[] fields = typeof (TSource).GetFields (BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            var attribute = (EndianAttribute)Attribute.GetCustomAttribute (typeof (TSource), typeof (EndianAttribute));
            PacketBuilder packetBuilder = null;
            if (attribute == null)
            {
                packetBuilder = new PacketBuilder ();
            }
            else
            {
                 packetBuilder = new PacketBuilder (new PacketBuilderConfiguration ()
                {
                    DefaultEndian = attribute._endian
                });
            }
            foreach (FieldInfo field in fields)
            {
                object value = field.GetValue (AppendClass);

                // 필드의 타입으로 캐스팅
                if (field.FieldType == typeof (string))
                {
                    packetBuilder.Append (value.Cast<string> ());
                }
                else if (field.FieldType == typeof (short))
                {
                    packetBuilder.Append ((short)value);
                }
                else if (field.FieldType == typeof (int))
                {
                    packetBuilder.Append ((int)value);
                }
                else if (field.FieldType == typeof (long))
                {
                    packetBuilder.Append ((long)value);
                }
                else if (field.FieldType == typeof (ushort))
                {
                    packetBuilder.Append ((ushort)value);
                }
                else if (field.FieldType == typeof (uint))
                {
                    packetBuilder.Append ((uint)value);
                }
                else if (field.FieldType == typeof (ulong))
                {
                    packetBuilder.Append ((ulong)value);
                }
                else if (field.FieldType == typeof (byte))
                {
                    packetBuilder.Append (value.Cast<byte> ());
                }
                else if (field.FieldType == typeof (byte[]))
                {
                    packetBuilder.Append (value.Cast<byte[]> ());
                }

                else if (field.FieldType == typeof (List<byte>))
                {
                    packetBuilder.Append (value.Cast<List<byte>> ());
                }
            }

            return packetBuilder.Build ();
        }

        public static T Serialize<T>(byte[] bytes) where T : new()
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
                    byte[] value = SignedGetBytes (field, reader, 2);
                    field.SetValue (instance, BitConverter.ToInt16(value));
                }
                else if (field.FieldType == typeof (int))
                {
                    byte[] value = SignedGetBytes (field, reader, 4);
                    field.SetValue (instance, BitConverter.ToInt32 (value));
                }
                else if (field.FieldType == typeof (long))
                {
                    byte[] value = SignedGetBytes (field, reader, 8);
                    field.SetValue (instance, BitConverter.ToInt64 (value));
                }
                else if (field.FieldType == typeof (byte))
                {
                    field.SetValue (instance, reader.ReadByte ());
                }
                else if (field.FieldType == typeof (ushort))
                {
                    byte[] value = UnSignedGetBytes (field, reader, 2);
                    field.SetValue (instance, BitConverter.ToUInt16 (value));
                }
                else if (field.FieldType == typeof (uint))
                {
                    byte[] value = UnSignedGetBytes (field, reader, 2);
                    field.SetValue (instance, BitConverter.ToUInt32 (value));
                }
                else if (field.FieldType == typeof (ulong))
                {
                    byte[] value = UnSignedGetBytes (field, reader, 2);
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

        private static byte[] SignedGetBytes(FieldInfo field, BinaryReader br, int length)
        {
            byte[] bytes = br.ReadBytes (length);
            var attribute = ((EndianAttribute)Attribute.GetCustomAttribute (field, typeof (EndianAttribute)));

            if (attribute == null)
                return bytes;
            Endian endian = attribute._endian;

            return ByteConverter.GetBytes (bytes, endian);
        }

        private static byte[] UnSignedGetBytes(FieldInfo field, BinaryReader br, int length)
        {
            byte[] bytes = br.ReadBytes (length);
            var attribute = ((EndianAttribute)Attribute.GetCustomAttribute (field, typeof (EndianAttribute)));

            if (attribute == null)
                return bytes;
            Endian endian = attribute._endian;

            return ByteConverter.GetBytes (bytes, endian);
        }

        private static byte[] EndianChange(byte[] byteArray, Endian endian)
        {
            if (endian == Endian.BIG || endian == Endian.LITTLE)
            {
                bool isLittleEndian = endian == Endian.LITTLE;
                if (BitConverter.IsLittleEndian != isLittleEndian)
                    Array.Reverse (byteArray);
            }
            else
            {
                Array.Reverse (byteArray);
            }

            return byteArray;
        }
    }
}
