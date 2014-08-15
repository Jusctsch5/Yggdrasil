﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;

namespace Yggdrasil
{
    public static class ExtensionMethods
    {
        public static dynamic GetProperty<T>(this T obj, string property)
        {
            return obj.GetType().GetProperty(property).GetValue(obj, null);
        }

        public static dynamic GetAttribute<T>(this object obj)
        {
            return obj.GetType().GetCustomAttributes(typeof(T), false).FirstOrDefault();
        }

        public static int Round(this int value, int roundTo)
        {
            return ((value + roundTo - 1) / roundTo) * roundTo;
        }

        public static void DoubleBuffered(this Control control, bool setting)
        {
            Type controlType = control.GetType();
            PropertyInfo pi = controlType.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(control, setting, null);
        }

        public static string Truncate(this string value, int maxChars)
        {
            return value.Length <= maxChars ? value : value.Substring(0, maxChars) + " ..";
        }

        public static ushort Reverse(this ushort value)
        {
            return (ushort)((value & 0xFFU) << 8 | (value & 0xFF00U) >> 8);
        }

        public static void CopyTo(this object obj, byte[] data, int offset)
        {
            byte[] bytes = null;
            Type type = obj.GetType();
            if (type == typeof(byte))
                bytes = new byte[1] { unchecked((byte)obj) };
            else if (type == typeof(sbyte))
                bytes = new byte[1] { unchecked((byte)((sbyte)obj)) };
            else
            {
                MethodInfo mi = typeof(BitConverter).GetMethod("GetBytes", new Type[] { type });
                if (mi == null) throw new ArgumentException(string.Format("Cannot get bytes from object of type {0}", type));
                bytes = (mi.Invoke(null, new object[] { obj }) as byte[]);
            }
            Buffer.BlockCopy(bytes, 0, data, offset, bytes.Length);
        }
    }
}