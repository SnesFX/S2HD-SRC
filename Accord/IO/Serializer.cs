using System;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Accord.IO
{
	// Token: 0x0200002A RID: 42
	public static class Serializer
	{
		// Token: 0x0600011C RID: 284 RVA: 0x00003EBC File Offset: 0x00002EBC
		private static SerializerCompression ParseCompression(string path)
		{
			string extension = Path.GetExtension(path);
			if (extension == ".gz")
			{
				return SerializerCompression.GZip;
			}
			return SerializerCompression.None;
		}

		// Token: 0x0600011D RID: 285 RVA: 0x00003EE0 File Offset: 0x00002EE0
		public static void Save<T>(this T obj, Stream stream, SerializerCompression compression = SerializerCompression.None)
		{
			if (compression == SerializerCompression.GZip)
			{
				using (GZipStream gzipStream = new GZipStream(stream, CompressionLevel.Optimal, true))
				{
					new BinaryFormatter().Serialize(gzipStream, obj);
					return;
				}
			}
			if (compression == SerializerCompression.None)
			{
				new BinaryFormatter().Serialize(stream, obj);
				return;
			}
			throw new ArgumentException("compression");
		}

		// Token: 0x0600011E RID: 286 RVA: 0x00003F48 File Offset: 0x00002F48
		public static void Save<T>(this T obj, string path)
		{
			obj.Save(path, Serializer.ParseCompression(path));
		}

		// Token: 0x0600011F RID: 287 RVA: 0x00003F58 File Offset: 0x00002F58
		public static void Save<T>(this T obj, string path, SerializerCompression compression = SerializerCompression.None)
		{
			path = Path.GetFullPath(path);
			string directoryName = Path.GetDirectoryName(path);
			if (!Directory.Exists(directoryName))
			{
				Directory.CreateDirectory(directoryName);
			}
			if (compression == SerializerCompression.GZip && !path.EndsWith(".gz"))
			{
				path += ".gz";
			}
			using (FileStream fileStream = new FileStream(path, FileMode.Create))
			{
				obj.Save(fileStream, compression);
			}
		}

		// Token: 0x06000120 RID: 288 RVA: 0x00003FD0 File Offset: 0x00002FD0
		public static byte[] Save<T>(this T obj, SerializerCompression compression = SerializerCompression.None)
		{
			byte[] result;
			obj.Save(out result, compression);
			return result;
		}

		// Token: 0x06000121 RID: 289 RVA: 0x00003FE8 File Offset: 0x00002FE8
		public static void Save<T>(this T obj, out byte[] bytes, SerializerCompression compression = SerializerCompression.None)
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				obj.Save(memoryStream, compression);
				memoryStream.Seek(0L, SeekOrigin.Begin);
				bytes = memoryStream.ToArray();
			}
		}

		// Token: 0x06000122 RID: 290 RVA: 0x00004034 File Offset: 0x00003034
		public static T Load<T>(Stream stream, SerializerCompression compression = SerializerCompression.None)
		{
			return Serializer.Load<T>(stream, new BinaryFormatter(), compression);
		}

		// Token: 0x06000123 RID: 291 RVA: 0x00004042 File Offset: 0x00003042
		public static T Load<T>(string path)
		{
			return Serializer.Load<T>(path, Serializer.ParseCompression(path));
		}

		// Token: 0x06000124 RID: 292 RVA: 0x00004050 File Offset: 0x00003050
		public static T Load<T>(string path, SerializerCompression compression = SerializerCompression.None)
		{
			path = Path.GetFullPath(path);
			return Serializer.load<T>(path, compression);
		}

		// Token: 0x06000125 RID: 293 RVA: 0x00004064 File Offset: 0x00003064
		private static T load<T>(string path, SerializerCompression compression)
		{
			T result;
			using (FileStream fileStream = new FileStream(path, FileMode.Open))
			{
				result = Serializer.Load<T>(fileStream, compression);
			}
			return result;
		}

		// Token: 0x06000126 RID: 294 RVA: 0x000040A0 File Offset: 0x000030A0
		public static T Load<T>(byte[] bytes, SerializerCompression compression = SerializerCompression.None)
		{
			T result;
			using (MemoryStream memoryStream = new MemoryStream(bytes, false))
			{
				result = Serializer.Load<T>(memoryStream, compression);
			}
			return result;
		}

		// Token: 0x06000127 RID: 295 RVA: 0x000040DC File Offset: 0x000030DC
		public static T Load<T>(Stream stream, out T value, SerializerCompression compression = SerializerCompression.None)
		{
			return value = Serializer.Load<T>(stream, compression);
		}

		// Token: 0x06000128 RID: 296 RVA: 0x000040F9 File Offset: 0x000030F9
		public static T Load<T>(string path, out T value)
		{
			return Serializer.Load<T>(path, out value, Serializer.ParseCompression(path));
		}

		// Token: 0x06000129 RID: 297 RVA: 0x00004108 File Offset: 0x00003108
		public static T Load<T>(string path, out T value, SerializerCompression compression)
		{
			return value = Serializer.Load<T>(path, compression);
		}

		// Token: 0x0600012A RID: 298 RVA: 0x00004128 File Offset: 0x00003128
		public static T Load<T>(byte[] bytes, out T value, SerializerCompression compression = SerializerCompression.None)
		{
			return value = Serializer.Load<T>(bytes, compression);
		}

		// Token: 0x0600012B RID: 299 RVA: 0x00004148 File Offset: 0x00003148
		public static T Load<T>(Stream stream, BinaryFormatter formatter, SerializerCompression compression = SerializerCompression.None)
		{
			object obj = Serializer.lockObj;
			T result;
			lock (obj)
			{
				try
				{
					if (formatter.Binder == null)
					{
						formatter.Binder = Serializer.GetBinder(typeof(T));
					}
					AppDomain.CurrentDomain.AssemblyResolve += Serializer.resolve;
					object obj2;
					if (compression == SerializerCompression.GZip)
					{
						using (GZipStream gzipStream = new GZipStream(stream, CompressionMode.Decompress, true))
						{
							obj2 = formatter.Deserialize(gzipStream);
							goto IL_7C;
						}
					}
					if (compression != SerializerCompression.None)
					{
						throw new ArgumentException("compression");
					}
					obj2 = formatter.Deserialize(stream);
					IL_7C:
					if (obj2 is T)
					{
						result = (T)((object)obj2);
					}
					else
					{
						result = obj2.To<T>();
					}
				}
				finally
				{
					AppDomain.CurrentDomain.AssemblyResolve -= Serializer.resolve;
				}
			}
			return result;
		}

		// Token: 0x0600012C RID: 300 RVA: 0x00004238 File Offset: 0x00003238
		public static T DeepClone<T>(this T obj)
		{
			return Serializer.Load<T>(obj.Save(SerializerCompression.None), SerializerCompression.None);
		}

		// Token: 0x0600012D RID: 301 RVA: 0x00004248 File Offset: 0x00003248
		private static SerializationBinder GetBinder(Type type)
		{
			SerializationBinderAttribute serializationBinderAttribute = Attribute.GetCustomAttribute(type, typeof(SerializationBinderAttribute)) as SerializationBinderAttribute;
			if (serializationBinderAttribute != null)
			{
				return serializationBinderAttribute.Binder;
			}
			FieldInfo field = type.GetField("Binder", BindingFlags.Static | BindingFlags.NonPublic);
			if (field != null)
			{
				SerializationBinder serializationBinder = field.GetValue(null) as SerializationBinder;
				if (serializationBinder != null)
				{
					return serializationBinder;
				}
			}
			return null;
		}

		// Token: 0x0600012E RID: 302 RVA: 0x000042A0 File Offset: 0x000032A0
		private static Assembly resolve(object sender, ResolveEventArgs args)
		{
			AssemblyName assemblyName = new AssemblyName(args.Name);
			if (assemblyName.Name == args.Name)
			{
				return null;
			}
			return ((AppDomain)sender).Load(assemblyName.Name);
		}

		// Token: 0x0600012F RID: 303 RVA: 0x000042E0 File Offset: 0x000032E0
		public static T GetValue<T>(this SerializationInfo info, string name, out T value)
		{
			return value = (T)((object)info.GetValue(name, typeof(T)));
		}

		// Token: 0x04000017 RID: 23
		private const SerializerCompression DEFAULT_COMPRESSION = SerializerCompression.None;

		// Token: 0x04000018 RID: 24
		private static readonly object lockObj = new object();
	}
}
