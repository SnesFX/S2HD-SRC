using System;
using System.Globalization;
using System.IO;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace OpenTK
{
	// Token: 0x02000531 RID: 1329
	[Serializable]
	public struct Vector2h : ISerializable, IEquatable<Vector2h>
	{
		// Token: 0x0600407F RID: 16511 RVA: 0x000ACCB4 File Offset: 0x000AAEB4
		public Vector2h(Half value)
		{
			this.X = value;
			this.Y = value;
		}

		// Token: 0x06004080 RID: 16512 RVA: 0x000ACCC4 File Offset: 0x000AAEC4
		public Vector2h(float value)
		{
			this.X = new Half(value);
			this.Y = new Half(value);
		}

		// Token: 0x06004081 RID: 16513 RVA: 0x000ACCE0 File Offset: 0x000AAEE0
		public Vector2h(Half x, Half y)
		{
			this.X = x;
			this.Y = y;
		}

		// Token: 0x06004082 RID: 16514 RVA: 0x000ACCF0 File Offset: 0x000AAEF0
		public Vector2h(float x, float y)
		{
			this.X = new Half(x);
			this.Y = new Half(y);
		}

		// Token: 0x06004083 RID: 16515 RVA: 0x000ACD0C File Offset: 0x000AAF0C
		public Vector2h(float x, float y, bool throwOnError)
		{
			this.X = new Half(x, throwOnError);
			this.Y = new Half(y, throwOnError);
		}

		// Token: 0x06004084 RID: 16516 RVA: 0x000ACD28 File Offset: 0x000AAF28
		[CLSCompliant(false)]
		public Vector2h(Vector2 v)
		{
			this.X = new Half(v.X);
			this.Y = new Half(v.Y);
		}

		// Token: 0x06004085 RID: 16517 RVA: 0x000ACD50 File Offset: 0x000AAF50
		[CLSCompliant(false)]
		public Vector2h(Vector2 v, bool throwOnError)
		{
			this.X = new Half(v.X, throwOnError);
			this.Y = new Half(v.Y, throwOnError);
		}

		// Token: 0x06004086 RID: 16518 RVA: 0x000ACD78 File Offset: 0x000AAF78
		public Vector2h(ref Vector2 v)
		{
			this.X = new Half(v.X);
			this.Y = new Half(v.Y);
		}

		// Token: 0x06004087 RID: 16519 RVA: 0x000ACD9C File Offset: 0x000AAF9C
		public Vector2h(ref Vector2 v, bool throwOnError)
		{
			this.X = new Half(v.X, throwOnError);
			this.Y = new Half(v.Y, throwOnError);
		}

		// Token: 0x06004088 RID: 16520 RVA: 0x000ACDC4 File Offset: 0x000AAFC4
		[CLSCompliant(false)]
		public Vector2h(Vector2d v)
		{
			this.X = new Half(v.X);
			this.Y = new Half(v.Y);
		}

		// Token: 0x06004089 RID: 16521 RVA: 0x000ACDEC File Offset: 0x000AAFEC
		[CLSCompliant(false)]
		public Vector2h(Vector2d v, bool throwOnError)
		{
			this.X = new Half(v.X, throwOnError);
			this.Y = new Half(v.Y, throwOnError);
		}

		// Token: 0x0600408A RID: 16522 RVA: 0x000ACE14 File Offset: 0x000AB014
		[CLSCompliant(false)]
		public Vector2h(ref Vector2d v)
		{
			this.X = new Half(v.X);
			this.Y = new Half(v.Y);
		}

		// Token: 0x0600408B RID: 16523 RVA: 0x000ACE38 File Offset: 0x000AB038
		[CLSCompliant(false)]
		public Vector2h(ref Vector2d v, bool throwOnError)
		{
			this.X = new Half(v.X, throwOnError);
			this.Y = new Half(v.Y, throwOnError);
		}

		// Token: 0x17000344 RID: 836
		// (get) Token: 0x0600408C RID: 16524 RVA: 0x000ACE60 File Offset: 0x000AB060
		// (set) Token: 0x0600408D RID: 16525 RVA: 0x000ACE74 File Offset: 0x000AB074
		[XmlIgnore]
		public Vector2h Yx
		{
			get
			{
				return new Vector2h(this.Y, this.X);
			}
			set
			{
				this.Y = value.X;
				this.X = value.Y;
			}
		}

		// Token: 0x0600408E RID: 16526 RVA: 0x000ACE90 File Offset: 0x000AB090
		public Vector2 ToVector2()
		{
			return new Vector2(this.X, this.Y);
		}

		// Token: 0x0600408F RID: 16527 RVA: 0x000ACEB0 File Offset: 0x000AB0B0
		public Vector2d ToVector2d()
		{
			return new Vector2d(this.X, this.Y);
		}

		// Token: 0x06004090 RID: 16528 RVA: 0x000ACED0 File Offset: 0x000AB0D0
		public static explicit operator Vector2h(Vector2 v)
		{
			return new Vector2h(v);
		}

		// Token: 0x06004091 RID: 16529 RVA: 0x000ACED8 File Offset: 0x000AB0D8
		public static explicit operator Vector2h(Vector2d v)
		{
			return new Vector2h(v);
		}

		// Token: 0x06004092 RID: 16530 RVA: 0x000ACEE0 File Offset: 0x000AB0E0
		public static explicit operator Vector2(Vector2h h)
		{
			return new Vector2(h.X, h.Y);
		}

		// Token: 0x06004093 RID: 16531 RVA: 0x000ACF04 File Offset: 0x000AB104
		public static explicit operator Vector2d(Vector2h h)
		{
			return new Vector2d(h.X, h.Y);
		}

		// Token: 0x06004094 RID: 16532 RVA: 0x000ACF28 File Offset: 0x000AB128
		public Vector2h(SerializationInfo info, StreamingContext context)
		{
			this.X = (Half)info.GetValue("X", typeof(Half));
			this.Y = (Half)info.GetValue("Y", typeof(Half));
		}

		// Token: 0x06004095 RID: 16533 RVA: 0x000ACF78 File Offset: 0x000AB178
		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.AddValue("X", this.X);
			info.AddValue("Y", this.Y);
		}

		// Token: 0x06004096 RID: 16534 RVA: 0x000ACFA8 File Offset: 0x000AB1A8
		public void FromBinaryStream(BinaryReader bin)
		{
			this.X.FromBinaryStream(bin);
			this.Y.FromBinaryStream(bin);
		}

		// Token: 0x06004097 RID: 16535 RVA: 0x000ACFC4 File Offset: 0x000AB1C4
		public void ToBinaryStream(BinaryWriter bin)
		{
			this.X.ToBinaryStream(bin);
			this.Y.ToBinaryStream(bin);
		}

		// Token: 0x06004098 RID: 16536 RVA: 0x000ACFE0 File Offset: 0x000AB1E0
		public bool Equals(Vector2h other)
		{
			return this.X.Equals(other.X) && this.Y.Equals(other.Y);
		}

		// Token: 0x06004099 RID: 16537 RVA: 0x000AD00C File Offset: 0x000AB20C
		public override string ToString()
		{
			return string.Format("({0}{2} {1})", this.X, this.Y, Vector2h.listSeparator);
		}

		// Token: 0x0600409A RID: 16538 RVA: 0x000AD034 File Offset: 0x000AB234
		public static byte[] GetBytes(Vector2h h)
		{
			byte[] array = new byte[Vector2h.SizeInBytes];
			byte[] bytes = Half.GetBytes(h.X);
			array[0] = bytes[0];
			array[1] = bytes[1];
			bytes = Half.GetBytes(h.Y);
			array[2] = bytes[0];
			array[3] = bytes[1];
			return array;
		}

		// Token: 0x0600409B RID: 16539 RVA: 0x000AD080 File Offset: 0x000AB280
		public static Vector2h FromBytes(byte[] value, int startIndex)
		{
			return new Vector2h
			{
				X = Half.FromBytes(value, startIndex),
				Y = Half.FromBytes(value, startIndex + 2)
			};
		}

		// Token: 0x04004E17 RID: 19991
		public Half X;

		// Token: 0x04004E18 RID: 19992
		public Half Y;

		// Token: 0x04004E19 RID: 19993
		public static readonly int SizeInBytes = 4;

		// Token: 0x04004E1A RID: 19994
		private static string listSeparator = CultureInfo.CurrentCulture.TextInfo.ListSeparator;
	}
}
