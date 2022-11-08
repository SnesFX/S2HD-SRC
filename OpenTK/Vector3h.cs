using System;
using System.Globalization;
using System.IO;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace OpenTK
{
	// Token: 0x02000532 RID: 1330
	[Serializable]
	public struct Vector3h : ISerializable, IEquatable<Vector3h>
	{
		// Token: 0x0600409D RID: 16541 RVA: 0x000AD0D0 File Offset: 0x000AB2D0
		public Vector3h(Half value)
		{
			this.X = value;
			this.Y = value;
			this.Z = value;
		}

		// Token: 0x0600409E RID: 16542 RVA: 0x000AD0E8 File Offset: 0x000AB2E8
		public Vector3h(float value)
		{
			this.X = new Half(value);
			this.Y = new Half(value);
			this.Z = new Half(value);
		}

		// Token: 0x0600409F RID: 16543 RVA: 0x000AD110 File Offset: 0x000AB310
		public Vector3h(Half x, Half y, Half z)
		{
			this.X = x;
			this.Y = y;
			this.Z = z;
		}

		// Token: 0x060040A0 RID: 16544 RVA: 0x000AD128 File Offset: 0x000AB328
		public Vector3h(float x, float y, float z)
		{
			this.X = new Half(x);
			this.Y = new Half(y);
			this.Z = new Half(z);
		}

		// Token: 0x060040A1 RID: 16545 RVA: 0x000AD150 File Offset: 0x000AB350
		public Vector3h(float x, float y, float z, bool throwOnError)
		{
			this.X = new Half(x, throwOnError);
			this.Y = new Half(y, throwOnError);
			this.Z = new Half(z, throwOnError);
		}

		// Token: 0x060040A2 RID: 16546 RVA: 0x000AD17C File Offset: 0x000AB37C
		[CLSCompliant(false)]
		public Vector3h(Vector3 v)
		{
			this.X = new Half(v.X);
			this.Y = new Half(v.Y);
			this.Z = new Half(v.Z);
		}

		// Token: 0x060040A3 RID: 16547 RVA: 0x000AD1B4 File Offset: 0x000AB3B4
		[CLSCompliant(false)]
		public Vector3h(Vector3 v, bool throwOnError)
		{
			this.X = new Half(v.X, throwOnError);
			this.Y = new Half(v.Y, throwOnError);
			this.Z = new Half(v.Z, throwOnError);
		}

		// Token: 0x060040A4 RID: 16548 RVA: 0x000AD1F0 File Offset: 0x000AB3F0
		public Vector3h(ref Vector3 v)
		{
			this.X = new Half(v.X);
			this.Y = new Half(v.Y);
			this.Z = new Half(v.Z);
		}

		// Token: 0x060040A5 RID: 16549 RVA: 0x000AD228 File Offset: 0x000AB428
		[CLSCompliant(false)]
		public Vector3h(ref Vector3 v, bool throwOnError)
		{
			this.X = new Half(v.X, throwOnError);
			this.Y = new Half(v.Y, throwOnError);
			this.Z = new Half(v.Z, throwOnError);
		}

		// Token: 0x060040A6 RID: 16550 RVA: 0x000AD260 File Offset: 0x000AB460
		[CLSCompliant(false)]
		public Vector3h(Vector3d v)
		{
			this.X = new Half(v.X);
			this.Y = new Half(v.Y);
			this.Z = new Half(v.Z);
		}

		// Token: 0x060040A7 RID: 16551 RVA: 0x000AD298 File Offset: 0x000AB498
		[CLSCompliant(false)]
		public Vector3h(Vector3d v, bool throwOnError)
		{
			this.X = new Half(v.X, throwOnError);
			this.Y = new Half(v.Y, throwOnError);
			this.Z = new Half(v.Z, throwOnError);
		}

		// Token: 0x060040A8 RID: 16552 RVA: 0x000AD2D4 File Offset: 0x000AB4D4
		[CLSCompliant(false)]
		public Vector3h(ref Vector3d v)
		{
			this.X = new Half(v.X);
			this.Y = new Half(v.Y);
			this.Z = new Half(v.Z);
		}

		// Token: 0x060040A9 RID: 16553 RVA: 0x000AD30C File Offset: 0x000AB50C
		[CLSCompliant(false)]
		public Vector3h(ref Vector3d v, bool throwOnError)
		{
			this.X = new Half(v.X, throwOnError);
			this.Y = new Half(v.Y, throwOnError);
			this.Z = new Half(v.Z, throwOnError);
		}

		// Token: 0x17000345 RID: 837
		// (get) Token: 0x060040AA RID: 16554 RVA: 0x000AD344 File Offset: 0x000AB544
		// (set) Token: 0x060040AB RID: 16555 RVA: 0x000AD358 File Offset: 0x000AB558
		[XmlIgnore]
		public Vector2h Xy
		{
			get
			{
				return new Vector2h(this.X, this.Y);
			}
			set
			{
				this.X = value.X;
				this.Y = value.Y;
			}
		}

		// Token: 0x17000346 RID: 838
		// (get) Token: 0x060040AC RID: 16556 RVA: 0x000AD374 File Offset: 0x000AB574
		// (set) Token: 0x060040AD RID: 16557 RVA: 0x000AD388 File Offset: 0x000AB588
		[XmlIgnore]
		public Vector2h Xz
		{
			get
			{
				return new Vector2h(this.X, this.Z);
			}
			set
			{
				this.X = value.X;
				this.Z = value.Y;
			}
		}

		// Token: 0x17000347 RID: 839
		// (get) Token: 0x060040AE RID: 16558 RVA: 0x000AD3A4 File Offset: 0x000AB5A4
		// (set) Token: 0x060040AF RID: 16559 RVA: 0x000AD3B8 File Offset: 0x000AB5B8
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

		// Token: 0x17000348 RID: 840
		// (get) Token: 0x060040B0 RID: 16560 RVA: 0x000AD3D4 File Offset: 0x000AB5D4
		// (set) Token: 0x060040B1 RID: 16561 RVA: 0x000AD3E8 File Offset: 0x000AB5E8
		[XmlIgnore]
		public Vector2h Yz
		{
			get
			{
				return new Vector2h(this.Y, this.Z);
			}
			set
			{
				this.Y = value.X;
				this.Z = value.Y;
			}
		}

		// Token: 0x17000349 RID: 841
		// (get) Token: 0x060040B2 RID: 16562 RVA: 0x000AD404 File Offset: 0x000AB604
		// (set) Token: 0x060040B3 RID: 16563 RVA: 0x000AD418 File Offset: 0x000AB618
		[XmlIgnore]
		public Vector2h Zx
		{
			get
			{
				return new Vector2h(this.Z, this.X);
			}
			set
			{
				this.Z = value.X;
				this.X = value.Y;
			}
		}

		// Token: 0x1700034A RID: 842
		// (get) Token: 0x060040B4 RID: 16564 RVA: 0x000AD434 File Offset: 0x000AB634
		// (set) Token: 0x060040B5 RID: 16565 RVA: 0x000AD448 File Offset: 0x000AB648
		[XmlIgnore]
		public Vector2h Zy
		{
			get
			{
				return new Vector2h(this.Z, this.Y);
			}
			set
			{
				this.Z = value.X;
				this.Y = value.Y;
			}
		}

		// Token: 0x1700034B RID: 843
		// (get) Token: 0x060040B6 RID: 16566 RVA: 0x000AD464 File Offset: 0x000AB664
		// (set) Token: 0x060040B7 RID: 16567 RVA: 0x000AD480 File Offset: 0x000AB680
		[XmlIgnore]
		public Vector3h Xzy
		{
			get
			{
				return new Vector3h(this.X, this.Z, this.Y);
			}
			set
			{
				this.X = value.X;
				this.Z = value.Y;
				this.Y = value.Z;
			}
		}

		// Token: 0x1700034C RID: 844
		// (get) Token: 0x060040B8 RID: 16568 RVA: 0x000AD4AC File Offset: 0x000AB6AC
		// (set) Token: 0x060040B9 RID: 16569 RVA: 0x000AD4C8 File Offset: 0x000AB6C8
		[XmlIgnore]
		public Vector3h Yxz
		{
			get
			{
				return new Vector3h(this.Y, this.X, this.Z);
			}
			set
			{
				this.Y = value.X;
				this.X = value.Y;
				this.Z = value.Z;
			}
		}

		// Token: 0x1700034D RID: 845
		// (get) Token: 0x060040BA RID: 16570 RVA: 0x000AD4F4 File Offset: 0x000AB6F4
		// (set) Token: 0x060040BB RID: 16571 RVA: 0x000AD510 File Offset: 0x000AB710
		[XmlIgnore]
		public Vector3h Yzx
		{
			get
			{
				return new Vector3h(this.Y, this.Z, this.X);
			}
			set
			{
				this.Y = value.X;
				this.Z = value.Y;
				this.X = value.Z;
			}
		}

		// Token: 0x1700034E RID: 846
		// (get) Token: 0x060040BC RID: 16572 RVA: 0x000AD53C File Offset: 0x000AB73C
		// (set) Token: 0x060040BD RID: 16573 RVA: 0x000AD558 File Offset: 0x000AB758
		[XmlIgnore]
		public Vector3h Zxy
		{
			get
			{
				return new Vector3h(this.Z, this.X, this.Y);
			}
			set
			{
				this.Z = value.X;
				this.X = value.Y;
				this.Y = value.Z;
			}
		}

		// Token: 0x1700034F RID: 847
		// (get) Token: 0x060040BE RID: 16574 RVA: 0x000AD584 File Offset: 0x000AB784
		// (set) Token: 0x060040BF RID: 16575 RVA: 0x000AD5A0 File Offset: 0x000AB7A0
		[XmlIgnore]
		public Vector3h Zyx
		{
			get
			{
				return new Vector3h(this.Z, this.Y, this.X);
			}
			set
			{
				this.Z = value.X;
				this.Y = value.Y;
				this.X = value.Z;
			}
		}

		// Token: 0x060040C0 RID: 16576 RVA: 0x000AD5CC File Offset: 0x000AB7CC
		public Vector3 ToVector3()
		{
			return new Vector3(this.X, this.Y, this.Z);
		}

		// Token: 0x060040C1 RID: 16577 RVA: 0x000AD5F8 File Offset: 0x000AB7F8
		public Vector3d ToVector3d()
		{
			return new Vector3d(this.X, this.Y, this.Z);
		}

		// Token: 0x060040C2 RID: 16578 RVA: 0x000AD624 File Offset: 0x000AB824
		public static explicit operator Vector3h(Vector3 v3f)
		{
			return new Vector3h(v3f);
		}

		// Token: 0x060040C3 RID: 16579 RVA: 0x000AD62C File Offset: 0x000AB82C
		public static explicit operator Vector3h(Vector3d v3d)
		{
			return new Vector3h(v3d);
		}

		// Token: 0x060040C4 RID: 16580 RVA: 0x000AD634 File Offset: 0x000AB834
		public static explicit operator Vector3(Vector3h h3)
		{
			return new Vector3
			{
				X = h3.X.ToSingle(),
				Y = h3.Y.ToSingle(),
				Z = h3.Z.ToSingle()
			};
		}

		// Token: 0x060040C5 RID: 16581 RVA: 0x000AD684 File Offset: 0x000AB884
		public static explicit operator Vector3d(Vector3h h3)
		{
			return new Vector3d
			{
				X = (double)h3.X.ToSingle(),
				Y = (double)h3.Y.ToSingle(),
				Z = (double)h3.Z.ToSingle()
			};
		}

		// Token: 0x060040C6 RID: 16582 RVA: 0x000AD6D8 File Offset: 0x000AB8D8
		public Vector3h(SerializationInfo info, StreamingContext context)
		{
			this.X = (Half)info.GetValue("X", typeof(Half));
			this.Y = (Half)info.GetValue("Y", typeof(Half));
			this.Z = (Half)info.GetValue("Z", typeof(Half));
		}

		// Token: 0x060040C7 RID: 16583 RVA: 0x000AD748 File Offset: 0x000AB948
		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.AddValue("X", this.X);
			info.AddValue("Y", this.Y);
			info.AddValue("Z", this.Z);
		}

		// Token: 0x060040C8 RID: 16584 RVA: 0x000AD79C File Offset: 0x000AB99C
		public void FromBinaryStream(BinaryReader bin)
		{
			this.X.FromBinaryStream(bin);
			this.Y.FromBinaryStream(bin);
			this.Z.FromBinaryStream(bin);
		}

		// Token: 0x060040C9 RID: 16585 RVA: 0x000AD7C4 File Offset: 0x000AB9C4
		public void ToBinaryStream(BinaryWriter bin)
		{
			this.X.ToBinaryStream(bin);
			this.Y.ToBinaryStream(bin);
			this.Z.ToBinaryStream(bin);
		}

		// Token: 0x060040CA RID: 16586 RVA: 0x000AD7EC File Offset: 0x000AB9EC
		public bool Equals(Vector3h other)
		{
			return this.X.Equals(other.X) && this.Y.Equals(other.Y) && this.Z.Equals(other.Z);
		}

		// Token: 0x060040CB RID: 16587 RVA: 0x000AD82C File Offset: 0x000ABA2C
		public override string ToString()
		{
			return string.Format("({0}{3} {1}{3} {2})", new object[]
			{
				this.X.ToString(),
				this.Y.ToString(),
				this.Z.ToString(),
				Vector3h.listSeparator
			});
		}

		// Token: 0x060040CC RID: 16588 RVA: 0x000AD890 File Offset: 0x000ABA90
		public static byte[] GetBytes(Vector3h h)
		{
			byte[] array = new byte[Vector3h.SizeInBytes];
			byte[] bytes = Half.GetBytes(h.X);
			array[0] = bytes[0];
			array[1] = bytes[1];
			bytes = Half.GetBytes(h.Y);
			array[2] = bytes[0];
			array[3] = bytes[1];
			bytes = Half.GetBytes(h.Z);
			array[4] = bytes[0];
			array[5] = bytes[1];
			return array;
		}

		// Token: 0x060040CD RID: 16589 RVA: 0x000AD8F4 File Offset: 0x000ABAF4
		public static Vector3h FromBytes(byte[] value, int startIndex)
		{
			return new Vector3h
			{
				X = Half.FromBytes(value, startIndex),
				Y = Half.FromBytes(value, startIndex + 2),
				Z = Half.FromBytes(value, startIndex + 4)
			};
		}

		// Token: 0x04004E1B RID: 19995
		public Half X;

		// Token: 0x04004E1C RID: 19996
		public Half Y;

		// Token: 0x04004E1D RID: 19997
		public Half Z;

		// Token: 0x04004E1E RID: 19998
		public static readonly int SizeInBytes = 6;

		// Token: 0x04004E1F RID: 19999
		private static string listSeparator = CultureInfo.CurrentCulture.TextInfo.ListSeparator;
	}
}
