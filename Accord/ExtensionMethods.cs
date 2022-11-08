using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using Accord.IO;

namespace Accord
{
	// Token: 0x02000023 RID: 35
	public static class ExtensionMethods
	{
		// Token: 0x060000EE RID: 238 RVA: 0x000037D0 File Offset: 0x000027D0
		public static void Add(this DataColumnCollection collection, params string[] columnNames)
		{
			for (int i = 0; i < columnNames.Length; i++)
			{
				collection.Add(columnNames[i]);
			}
		}

		// Token: 0x060000EF RID: 239 RVA: 0x000037F8 File Offset: 0x000027F8
		public static string GetDescription<T>(this T source)
		{
			FieldInfo field = source.GetType().GetField(source.ToString());
			DescriptionAttribute[] array = (DescriptionAttribute[])field.GetCustomAttributes(typeof(DescriptionAttribute), false);
			if (array != null && array.Length != 0)
			{
				return array[0].Description;
			}
			return source.ToString();
		}

		// Token: 0x060000F0 RID: 240 RVA: 0x0000385C File Offset: 0x0000285C
		public static bool Read<T>(this BinaryReader stream, out T structure) where T : struct
		{
			Type typeFromHandle = typeof(T);
			int num = Marshal.SizeOf(typeFromHandle);
			byte[] array = new byte[num];
			if (stream.Read(array, 0, array.Length) == 0)
			{
				structure = default(T);
				return false;
			}
			GCHandle gchandle = GCHandle.Alloc(array, GCHandleType.Pinned);
			structure = (T)((object)Marshal.PtrToStructure(gchandle.AddrOfPinnedObject(), typeof(T)));
			gchandle.Free();
			return true;
		}

		// Token: 0x060000F1 RID: 241 RVA: 0x000038CC File Offset: 0x000028CC
		public static bool Write<T>(this BinaryWriter stream, T[] array) where T : struct
		{
			Type typeFromHandle = typeof(T);
			int num = Marshal.SizeOf(typeFromHandle);
			byte[] array2 = new byte[num * array.Length];
			Buffer.BlockCopy(array, 0, array2, 0, array2.Length);
			stream.Write(array2, 0, array2.Length);
			return true;
		}

		// Token: 0x060000F2 RID: 242 RVA: 0x00003910 File Offset: 0x00002910
		public static bool Write<T>(this BinaryWriter stream, T[][] array) where T : struct
		{
			Type typeFromHandle = typeof(T);
			int num = Marshal.SizeOf(typeFromHandle);
			byte[] array2 = new byte[num * array[0].Length];
			for (int i = 0; i < array.Length; i++)
			{
				Buffer.BlockCopy(array[i], 0, array2, 0, array2.Length);
				stream.Write(array2, 0, array2.Length);
			}
			return true;
		}

		// Token: 0x060000F3 RID: 243 RVA: 0x00003964 File Offset: 0x00002964
		public static bool Write<T>(this BinaryWriter stream, T[,] array) where T : struct
		{
			Type typeFromHandle = typeof(T);
			int num = Marshal.SizeOf(typeFromHandle);
			byte[] array2 = new byte[num * array.Length];
			Buffer.BlockCopy(array, 0, array2, 0, array2.Length);
			stream.Write(array2, 0, array2.Length);
			return true;
		}

		// Token: 0x060000F4 RID: 244 RVA: 0x000039AC File Offset: 0x000029AC
		public static T[][] ReadJagged<T>(this BinaryReader stream, int rows, int columns) where T : struct
		{
			Type typeFromHandle = typeof(T);
			int num = Marshal.SizeOf(typeFromHandle);
			byte[] array = new byte[num * columns];
			T[][] array2 = new T[rows][];
			for (int i = 0; i < array2.Length; i++)
			{
				array2[i] = new T[columns];
			}
			for (int j = 0; j < array2.Length; j++)
			{
				stream.Read(array, 0, array.Length);
				Buffer.BlockCopy(array, 0, array2[j], 0, array.Length);
			}
			return array2;
		}

		// Token: 0x060000F5 RID: 245 RVA: 0x00003A25 File Offset: 0x00002A25
		public static T[,] ReadMatrix<T>(this BinaryReader stream, int rows, int columns) where T : struct
		{
			return (T[,])stream.ReadMatrix(typeof(T), new int[]
			{
				rows,
				columns
			});
		}

		// Token: 0x060000F6 RID: 246 RVA: 0x00003A4C File Offset: 0x00002A4C
		public static Array ReadMatrix(this BinaryReader stream, Type type, params int[] lengths)
		{
			int num = Marshal.SizeOf(type);
			int num2 = 1;
			for (int i = 0; i < lengths.Length; i++)
			{
				num2 *= lengths[i];
			}
			byte[] array = new byte[num * num2];
			Array array2 = Array.CreateInstance(type, lengths);
			stream.Read(array, 0, array.Length);
			Buffer.BlockCopy(array, 0, array2, 0, array.Length);
			return array2;
		}

		// Token: 0x060000F7 RID: 247 RVA: 0x00003AA8 File Offset: 0x00002AA8
		public static long GetPosition(this StreamReader reader)
		{
			char[] chars = (char[])reader.GetType().InvokeMember("charBuffer", BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.GetField, null, reader, null, CultureInfo.InvariantCulture);
			int count = (int)reader.GetType().InvokeMember("charPos", BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.GetField, null, reader, null, CultureInfo.InvariantCulture);
			int num = (int)reader.GetType().InvokeMember("byteLen", BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.GetField, null, reader, null, CultureInfo.InvariantCulture);
			int byteCount = reader.CurrentEncoding.GetByteCount(chars, 0, count);
			return reader.BaseStream.Position - (long)num + (long)byteCount;
		}

		// Token: 0x060000F8 RID: 248 RVA: 0x00003B3E File Offset: 0x00002B3E
		[Obsolete("Please use Accord.IO.Serializer.Load<T>() instead.")]
		public static T DeserializeAnyVersion<T>(this BinaryFormatter formatter, Stream stream)
		{
			return Serializer.Load<T>(stream, SerializerCompression.None);
		}

		// Token: 0x060000F9 RID: 249 RVA: 0x00003B48 File Offset: 0x00002B48
		public static T To<T>(this object value)
		{
			if (value == null)
			{
				return (T)((object)Convert.ChangeType(null, typeof(T)));
			}
			if (value is IConvertible)
			{
				return (T)((object)Convert.ChangeType(value, typeof(T)));
			}
			Type type = value.GetType();
			MethodInfo[] methods = type.GetMethods(BindingFlags.Static | BindingFlags.Public);
			foreach (MethodInfo methodInfo in methods)
			{
				if (methodInfo.IsPublic && methodInfo.IsStatic && (methodInfo.Name == "op_Implicit" || methodInfo.Name == "op_Explicit") && methodInfo.ReturnType == typeof(T))
				{
					return (T)((object)methodInfo.Invoke(null, new object[]
					{
						value
					}));
				}
			}
			return (T)((object)Convert.ChangeType(value, typeof(T)));
		}

		// Token: 0x060000FA RID: 250 RVA: 0x00003C2E File Offset: 0x00002C2E
		public static bool HasDefaultConstructor(this Type t)
		{
			return t.IsValueType || t.GetConstructor(Type.EmptyTypes) != null;
		}

		// Token: 0x060000FB RID: 251 RVA: 0x00003C4B File Offset: 0x00002C4B
		public static string Format(this string str, params object[] args)
		{
			return string.Format(str, args);
		}

		// Token: 0x060000FC RID: 252 RVA: 0x00003C54 File Offset: 0x00002C54
		public static bool IsEqual<TKey, TValue>(this IDictionary<TKey, TValue> a, IDictionary<TKey, TValue> b)
		{
			if (a == b)
			{
				return true;
			}
			if (a.Count != b.Count)
			{
				return false;
			}
			HashSet<TKey> hashSet = new HashSet<TKey>(a.Keys);
			HashSet<TKey> equals = new HashSet<TKey>(b.Keys);
			if (!hashSet.SetEquals(equals))
			{
				return false;
			}
			if (ExtensionMethods.HasMethod<TValue>("SetEquals"))
			{
				MethodInfo method = typeof(TValue).GetMethod("SetEquals");
				using (HashSet<TKey>.Enumerator enumerator = hashSet.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						TKey key = enumerator.Current;
						if (!(bool)method.Invoke(a[key], new object[]
						{
							b[key]
						}))
						{
							return false;
						}
					}
					return true;
				}
			}
			foreach (TKey key2 in hashSet)
			{
				TValue tvalue = a[key2];
				if (!tvalue.Equals(b[key2]))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x060000FD RID: 253 RVA: 0x00003D94 File Offset: 0x00002D94
		public static bool HasMethod(this object obj, string methodName)
		{
			bool result;
			try
			{
				Type type = obj.GetType();
				result = (type.GetMethod(methodName) != null);
			}
			catch (AmbiguousMatchException)
			{
				result = true;
			}
			return result;
		}

		// Token: 0x060000FE RID: 254 RVA: 0x00003DD0 File Offset: 0x00002DD0
		public static bool HasMethod<T>(string methodName)
		{
			bool result;
			try
			{
				Type typeFromHandle = typeof(T);
				result = (typeFromHandle.GetMethod(methodName) != null);
			}
			catch (AmbiguousMatchException)
			{
				result = true;
			}
			return result;
		}

		// Token: 0x060000FF RID: 255 RVA: 0x00003E10 File Offset: 0x00002E10
		public static bool IsGreaterThan<T>(this T a, object b) where T : IComparable
		{
			return a.CompareTo(b) > 0;
		}

		// Token: 0x06000100 RID: 256 RVA: 0x00003E23 File Offset: 0x00002E23
		public static bool IsGreaterThanOrEqual<T>(this T a, object b) where T : IComparable
		{
			return a.CompareTo(b) >= 0;
		}

		// Token: 0x06000101 RID: 257 RVA: 0x00003E39 File Offset: 0x00002E39
		public static bool IsLessThan<T>(this T a, object b) where T : IComparable
		{
			return a.CompareTo(b) < 0;
		}

		// Token: 0x06000102 RID: 258 RVA: 0x00003E4C File Offset: 0x00002E4C
		public static bool IsLessThanOrEqual<T>(this T a, object b) where T : IComparable
		{
			return a.CompareTo(b) <= 0;
		}
	}
}
