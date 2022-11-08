using System;
using System.Globalization;
using System.IO;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace OpenTK
{
	// Token: 0x0200053B RID: 1339
	[Serializable]
	public struct Vector4h : ISerializable, IEquatable<Vector4h>
	{
		// Token: 0x060042DB RID: 17115 RVA: 0x000B5024 File Offset: 0x000B3224
		public Vector4h(Half value)
		{
			this.X = value;
			this.Y = value;
			this.Z = value;
			this.W = value;
		}

		// Token: 0x060042DC RID: 17116 RVA: 0x000B5044 File Offset: 0x000B3244
		public Vector4h(float value)
		{
			this.X = new Half(value);
			this.Y = new Half(value);
			this.Z = new Half(value);
			this.W = new Half(value);
		}

		// Token: 0x060042DD RID: 17117 RVA: 0x000B5078 File Offset: 0x000B3278
		public Vector4h(Half x, Half y, Half z, Half w)
		{
			this.X = x;
			this.Y = y;
			this.Z = z;
			this.W = w;
		}

		// Token: 0x060042DE RID: 17118 RVA: 0x000B5098 File Offset: 0x000B3298
		public Vector4h(float x, float y, float z, float w)
		{
			this.X = new Half(x);
			this.Y = new Half(y);
			this.Z = new Half(z);
			this.W = new Half(w);
		}

		// Token: 0x060042DF RID: 17119 RVA: 0x000B50CC File Offset: 0x000B32CC
		public Vector4h(float x, float y, float z, float w, bool throwOnError)
		{
			this.X = new Half(x, throwOnError);
			this.Y = new Half(y, throwOnError);
			this.Z = new Half(z, throwOnError);
			this.W = new Half(w, throwOnError);
		}

		// Token: 0x060042E0 RID: 17120 RVA: 0x000B5108 File Offset: 0x000B3308
		[CLSCompliant(false)]
		public Vector4h(Vector4 v)
		{
			this.X = new Half(v.X);
			this.Y = new Half(v.Y);
			this.Z = new Half(v.Z);
			this.W = new Half(v.W);
		}

		// Token: 0x060042E1 RID: 17121 RVA: 0x000B5160 File Offset: 0x000B3360
		[CLSCompliant(false)]
		public Vector4h(Vector4 v, bool throwOnError)
		{
			this.X = new Half(v.X, throwOnError);
			this.Y = new Half(v.Y, throwOnError);
			this.Z = new Half(v.Z, throwOnError);
			this.W = new Half(v.W, throwOnError);
		}

		// Token: 0x060042E2 RID: 17122 RVA: 0x000B51BC File Offset: 0x000B33BC
		public Vector4h(ref Vector4 v)
		{
			this.X = new Half(v.X);
			this.Y = new Half(v.Y);
			this.Z = new Half(v.Z);
			this.W = new Half(v.W);
		}

		// Token: 0x060042E3 RID: 17123 RVA: 0x000B5210 File Offset: 0x000B3410
		public Vector4h(ref Vector4 v, bool throwOnError)
		{
			this.X = new Half(v.X, throwOnError);
			this.Y = new Half(v.Y, throwOnError);
			this.Z = new Half(v.Z, throwOnError);
			this.W = new Half(v.W, throwOnError);
		}

		// Token: 0x060042E4 RID: 17124 RVA: 0x000B5268 File Offset: 0x000B3468
		[CLSCompliant(false)]
		public Vector4h(Vector4d v)
		{
			this.X = new Half(v.X);
			this.Y = new Half(v.Y);
			this.Z = new Half(v.Z);
			this.W = new Half(v.W);
		}

		// Token: 0x060042E5 RID: 17125 RVA: 0x000B52C0 File Offset: 0x000B34C0
		[CLSCompliant(false)]
		public Vector4h(Vector4d v, bool throwOnError)
		{
			this.X = new Half(v.X, throwOnError);
			this.Y = new Half(v.Y, throwOnError);
			this.Z = new Half(v.Z, throwOnError);
			this.W = new Half(v.W, throwOnError);
		}

		// Token: 0x060042E6 RID: 17126 RVA: 0x000B531C File Offset: 0x000B351C
		[CLSCompliant(false)]
		public Vector4h(ref Vector4d v)
		{
			this.X = new Half(v.X);
			this.Y = new Half(v.Y);
			this.Z = new Half(v.Z);
			this.W = new Half(v.W);
		}

		// Token: 0x060042E7 RID: 17127 RVA: 0x000B5370 File Offset: 0x000B3570
		[CLSCompliant(false)]
		public Vector4h(ref Vector4d v, bool throwOnError)
		{
			this.X = new Half(v.X, throwOnError);
			this.Y = new Half(v.Y, throwOnError);
			this.Z = new Half(v.Z, throwOnError);
			this.W = new Half(v.W, throwOnError);
		}

		// Token: 0x170003C0 RID: 960
		// (get) Token: 0x060042E8 RID: 17128 RVA: 0x000B53C8 File Offset: 0x000B35C8
		// (set) Token: 0x060042E9 RID: 17129 RVA: 0x000B53DC File Offset: 0x000B35DC
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

		// Token: 0x170003C1 RID: 961
		// (get) Token: 0x060042EA RID: 17130 RVA: 0x000B53F8 File Offset: 0x000B35F8
		// (set) Token: 0x060042EB RID: 17131 RVA: 0x000B540C File Offset: 0x000B360C
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

		// Token: 0x170003C2 RID: 962
		// (get) Token: 0x060042EC RID: 17132 RVA: 0x000B5428 File Offset: 0x000B3628
		// (set) Token: 0x060042ED RID: 17133 RVA: 0x000B543C File Offset: 0x000B363C
		[XmlIgnore]
		public Vector2h Xw
		{
			get
			{
				return new Vector2h(this.X, this.W);
			}
			set
			{
				this.X = value.X;
				this.W = value.Y;
			}
		}

		// Token: 0x170003C3 RID: 963
		// (get) Token: 0x060042EE RID: 17134 RVA: 0x000B5458 File Offset: 0x000B3658
		// (set) Token: 0x060042EF RID: 17135 RVA: 0x000B546C File Offset: 0x000B366C
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

		// Token: 0x170003C4 RID: 964
		// (get) Token: 0x060042F0 RID: 17136 RVA: 0x000B5488 File Offset: 0x000B3688
		// (set) Token: 0x060042F1 RID: 17137 RVA: 0x000B549C File Offset: 0x000B369C
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

		// Token: 0x170003C5 RID: 965
		// (get) Token: 0x060042F2 RID: 17138 RVA: 0x000B54B8 File Offset: 0x000B36B8
		// (set) Token: 0x060042F3 RID: 17139 RVA: 0x000B54CC File Offset: 0x000B36CC
		[XmlIgnore]
		public Vector2h Yw
		{
			get
			{
				return new Vector2h(this.Y, this.W);
			}
			set
			{
				this.Y = value.X;
				this.W = value.Y;
			}
		}

		// Token: 0x170003C6 RID: 966
		// (get) Token: 0x060042F4 RID: 17140 RVA: 0x000B54E8 File Offset: 0x000B36E8
		// (set) Token: 0x060042F5 RID: 17141 RVA: 0x000B54FC File Offset: 0x000B36FC
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

		// Token: 0x170003C7 RID: 967
		// (get) Token: 0x060042F6 RID: 17142 RVA: 0x000B5518 File Offset: 0x000B3718
		// (set) Token: 0x060042F7 RID: 17143 RVA: 0x000B552C File Offset: 0x000B372C
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

		// Token: 0x170003C8 RID: 968
		// (get) Token: 0x060042F8 RID: 17144 RVA: 0x000B5548 File Offset: 0x000B3748
		// (set) Token: 0x060042F9 RID: 17145 RVA: 0x000B555C File Offset: 0x000B375C
		[XmlIgnore]
		public Vector2h Zw
		{
			get
			{
				return new Vector2h(this.Z, this.W);
			}
			set
			{
				this.Z = value.X;
				this.W = value.Y;
			}
		}

		// Token: 0x170003C9 RID: 969
		// (get) Token: 0x060042FA RID: 17146 RVA: 0x000B5578 File Offset: 0x000B3778
		// (set) Token: 0x060042FB RID: 17147 RVA: 0x000B558C File Offset: 0x000B378C
		[XmlIgnore]
		public Vector2h Wx
		{
			get
			{
				return new Vector2h(this.W, this.X);
			}
			set
			{
				this.W = value.X;
				this.X = value.Y;
			}
		}

		// Token: 0x170003CA RID: 970
		// (get) Token: 0x060042FC RID: 17148 RVA: 0x000B55A8 File Offset: 0x000B37A8
		// (set) Token: 0x060042FD RID: 17149 RVA: 0x000B55BC File Offset: 0x000B37BC
		[XmlIgnore]
		public Vector2h Wy
		{
			get
			{
				return new Vector2h(this.W, this.Y);
			}
			set
			{
				this.W = value.X;
				this.Y = value.Y;
			}
		}

		// Token: 0x170003CB RID: 971
		// (get) Token: 0x060042FE RID: 17150 RVA: 0x000B55D8 File Offset: 0x000B37D8
		// (set) Token: 0x060042FF RID: 17151 RVA: 0x000B55EC File Offset: 0x000B37EC
		[XmlIgnore]
		public Vector2h Wz
		{
			get
			{
				return new Vector2h(this.W, this.Z);
			}
			set
			{
				this.W = value.X;
				this.Z = value.Y;
			}
		}

		// Token: 0x170003CC RID: 972
		// (get) Token: 0x06004300 RID: 17152 RVA: 0x000B5608 File Offset: 0x000B3808
		// (set) Token: 0x06004301 RID: 17153 RVA: 0x000B5624 File Offset: 0x000B3824
		[XmlIgnore]
		public Vector3h Xyz
		{
			get
			{
				return new Vector3h(this.X, this.Y, this.Z);
			}
			set
			{
				this.X = value.X;
				this.Y = value.Y;
				this.Z = value.Z;
			}
		}

		// Token: 0x170003CD RID: 973
		// (get) Token: 0x06004302 RID: 17154 RVA: 0x000B5650 File Offset: 0x000B3850
		// (set) Token: 0x06004303 RID: 17155 RVA: 0x000B566C File Offset: 0x000B386C
		[XmlIgnore]
		public Vector3h Xyw
		{
			get
			{
				return new Vector3h(this.X, this.Y, this.W);
			}
			set
			{
				this.X = value.X;
				this.Y = value.Y;
				this.W = value.Z;
			}
		}

		// Token: 0x170003CE RID: 974
		// (get) Token: 0x06004304 RID: 17156 RVA: 0x000B5698 File Offset: 0x000B3898
		// (set) Token: 0x06004305 RID: 17157 RVA: 0x000B56B4 File Offset: 0x000B38B4
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

		// Token: 0x170003CF RID: 975
		// (get) Token: 0x06004306 RID: 17158 RVA: 0x000B56E0 File Offset: 0x000B38E0
		// (set) Token: 0x06004307 RID: 17159 RVA: 0x000B56FC File Offset: 0x000B38FC
		[XmlIgnore]
		public Vector3h Xzw
		{
			get
			{
				return new Vector3h(this.X, this.Z, this.W);
			}
			set
			{
				this.X = value.X;
				this.Z = value.Y;
				this.W = value.Z;
			}
		}

		// Token: 0x170003D0 RID: 976
		// (get) Token: 0x06004308 RID: 17160 RVA: 0x000B5728 File Offset: 0x000B3928
		// (set) Token: 0x06004309 RID: 17161 RVA: 0x000B5744 File Offset: 0x000B3944
		[XmlIgnore]
		public Vector3h Xwy
		{
			get
			{
				return new Vector3h(this.X, this.W, this.Y);
			}
			set
			{
				this.X = value.X;
				this.W = value.Y;
				this.Y = value.Z;
			}
		}

		// Token: 0x170003D1 RID: 977
		// (get) Token: 0x0600430A RID: 17162 RVA: 0x000B5770 File Offset: 0x000B3970
		// (set) Token: 0x0600430B RID: 17163 RVA: 0x000B578C File Offset: 0x000B398C
		[XmlIgnore]
		public Vector3h Xwz
		{
			get
			{
				return new Vector3h(this.X, this.W, this.Z);
			}
			set
			{
				this.X = value.X;
				this.W = value.Y;
				this.Z = value.Z;
			}
		}

		// Token: 0x170003D2 RID: 978
		// (get) Token: 0x0600430C RID: 17164 RVA: 0x000B57B8 File Offset: 0x000B39B8
		// (set) Token: 0x0600430D RID: 17165 RVA: 0x000B57D4 File Offset: 0x000B39D4
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

		// Token: 0x170003D3 RID: 979
		// (get) Token: 0x0600430E RID: 17166 RVA: 0x000B5800 File Offset: 0x000B3A00
		// (set) Token: 0x0600430F RID: 17167 RVA: 0x000B581C File Offset: 0x000B3A1C
		[XmlIgnore]
		public Vector3h Yxw
		{
			get
			{
				return new Vector3h(this.Y, this.X, this.W);
			}
			set
			{
				this.Y = value.X;
				this.X = value.Y;
				this.W = value.Z;
			}
		}

		// Token: 0x170003D4 RID: 980
		// (get) Token: 0x06004310 RID: 17168 RVA: 0x000B5848 File Offset: 0x000B3A48
		// (set) Token: 0x06004311 RID: 17169 RVA: 0x000B5864 File Offset: 0x000B3A64
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

		// Token: 0x170003D5 RID: 981
		// (get) Token: 0x06004312 RID: 17170 RVA: 0x000B5890 File Offset: 0x000B3A90
		// (set) Token: 0x06004313 RID: 17171 RVA: 0x000B58AC File Offset: 0x000B3AAC
		[XmlIgnore]
		public Vector3h Yzw
		{
			get
			{
				return new Vector3h(this.Y, this.Z, this.W);
			}
			set
			{
				this.Y = value.X;
				this.Z = value.Y;
				this.W = value.Z;
			}
		}

		// Token: 0x170003D6 RID: 982
		// (get) Token: 0x06004314 RID: 17172 RVA: 0x000B58D8 File Offset: 0x000B3AD8
		// (set) Token: 0x06004315 RID: 17173 RVA: 0x000B58F4 File Offset: 0x000B3AF4
		[XmlIgnore]
		public Vector3h Ywx
		{
			get
			{
				return new Vector3h(this.Y, this.W, this.X);
			}
			set
			{
				this.Y = value.X;
				this.W = value.Y;
				this.X = value.Z;
			}
		}

		// Token: 0x170003D7 RID: 983
		// (get) Token: 0x06004316 RID: 17174 RVA: 0x000B5920 File Offset: 0x000B3B20
		// (set) Token: 0x06004317 RID: 17175 RVA: 0x000B593C File Offset: 0x000B3B3C
		[XmlIgnore]
		public Vector3h Ywz
		{
			get
			{
				return new Vector3h(this.Y, this.W, this.Z);
			}
			set
			{
				this.Y = value.X;
				this.W = value.Y;
				this.Z = value.Z;
			}
		}

		// Token: 0x170003D8 RID: 984
		// (get) Token: 0x06004318 RID: 17176 RVA: 0x000B5968 File Offset: 0x000B3B68
		// (set) Token: 0x06004319 RID: 17177 RVA: 0x000B5984 File Offset: 0x000B3B84
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

		// Token: 0x170003D9 RID: 985
		// (get) Token: 0x0600431A RID: 17178 RVA: 0x000B59B0 File Offset: 0x000B3BB0
		// (set) Token: 0x0600431B RID: 17179 RVA: 0x000B59CC File Offset: 0x000B3BCC
		[XmlIgnore]
		public Vector3h Zxw
		{
			get
			{
				return new Vector3h(this.Z, this.X, this.W);
			}
			set
			{
				this.Z = value.X;
				this.X = value.Y;
				this.W = value.Z;
			}
		}

		// Token: 0x170003DA RID: 986
		// (get) Token: 0x0600431C RID: 17180 RVA: 0x000B59F8 File Offset: 0x000B3BF8
		// (set) Token: 0x0600431D RID: 17181 RVA: 0x000B5A14 File Offset: 0x000B3C14
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

		// Token: 0x170003DB RID: 987
		// (get) Token: 0x0600431E RID: 17182 RVA: 0x000B5A40 File Offset: 0x000B3C40
		// (set) Token: 0x0600431F RID: 17183 RVA: 0x000B5A5C File Offset: 0x000B3C5C
		[XmlIgnore]
		public Vector3h Zyw
		{
			get
			{
				return new Vector3h(this.Z, this.Y, this.W);
			}
			set
			{
				this.Z = value.X;
				this.Y = value.Y;
				this.W = value.Z;
			}
		}

		// Token: 0x170003DC RID: 988
		// (get) Token: 0x06004320 RID: 17184 RVA: 0x000B5A88 File Offset: 0x000B3C88
		// (set) Token: 0x06004321 RID: 17185 RVA: 0x000B5AA4 File Offset: 0x000B3CA4
		[XmlIgnore]
		public Vector3h Zwx
		{
			get
			{
				return new Vector3h(this.Z, this.W, this.X);
			}
			set
			{
				this.Z = value.X;
				this.W = value.Y;
				this.X = value.Z;
			}
		}

		// Token: 0x170003DD RID: 989
		// (get) Token: 0x06004322 RID: 17186 RVA: 0x000B5AD0 File Offset: 0x000B3CD0
		// (set) Token: 0x06004323 RID: 17187 RVA: 0x000B5AEC File Offset: 0x000B3CEC
		[XmlIgnore]
		public Vector3h Zwy
		{
			get
			{
				return new Vector3h(this.Z, this.W, this.Y);
			}
			set
			{
				this.Z = value.X;
				this.W = value.Y;
				this.Y = value.Z;
			}
		}

		// Token: 0x170003DE RID: 990
		// (get) Token: 0x06004324 RID: 17188 RVA: 0x000B5B18 File Offset: 0x000B3D18
		// (set) Token: 0x06004325 RID: 17189 RVA: 0x000B5B34 File Offset: 0x000B3D34
		[XmlIgnore]
		public Vector3h Wxy
		{
			get
			{
				return new Vector3h(this.W, this.X, this.Y);
			}
			set
			{
				this.W = value.X;
				this.X = value.Y;
				this.Y = value.Z;
			}
		}

		// Token: 0x170003DF RID: 991
		// (get) Token: 0x06004326 RID: 17190 RVA: 0x000B5B60 File Offset: 0x000B3D60
		// (set) Token: 0x06004327 RID: 17191 RVA: 0x000B5B7C File Offset: 0x000B3D7C
		[XmlIgnore]
		public Vector3h Wxz
		{
			get
			{
				return new Vector3h(this.W, this.X, this.Z);
			}
			set
			{
				this.W = value.X;
				this.X = value.Y;
				this.Z = value.Z;
			}
		}

		// Token: 0x170003E0 RID: 992
		// (get) Token: 0x06004328 RID: 17192 RVA: 0x000B5BA8 File Offset: 0x000B3DA8
		// (set) Token: 0x06004329 RID: 17193 RVA: 0x000B5BC4 File Offset: 0x000B3DC4
		[XmlIgnore]
		public Vector3h Wyx
		{
			get
			{
				return new Vector3h(this.W, this.Y, this.X);
			}
			set
			{
				this.W = value.X;
				this.Y = value.Y;
				this.X = value.Z;
			}
		}

		// Token: 0x170003E1 RID: 993
		// (get) Token: 0x0600432A RID: 17194 RVA: 0x000B5BF0 File Offset: 0x000B3DF0
		// (set) Token: 0x0600432B RID: 17195 RVA: 0x000B5C0C File Offset: 0x000B3E0C
		[XmlIgnore]
		public Vector3h Wyz
		{
			get
			{
				return new Vector3h(this.W, this.Y, this.Z);
			}
			set
			{
				this.W = value.X;
				this.Y = value.Y;
				this.Z = value.Z;
			}
		}

		// Token: 0x170003E2 RID: 994
		// (get) Token: 0x0600432C RID: 17196 RVA: 0x000B5C38 File Offset: 0x000B3E38
		// (set) Token: 0x0600432D RID: 17197 RVA: 0x000B5C54 File Offset: 0x000B3E54
		[XmlIgnore]
		public Vector3h Wzx
		{
			get
			{
				return new Vector3h(this.W, this.Z, this.X);
			}
			set
			{
				this.W = value.X;
				this.Z = value.Y;
				this.X = value.Z;
			}
		}

		// Token: 0x170003E3 RID: 995
		// (get) Token: 0x0600432E RID: 17198 RVA: 0x000B5C80 File Offset: 0x000B3E80
		// (set) Token: 0x0600432F RID: 17199 RVA: 0x000B5C9C File Offset: 0x000B3E9C
		[XmlIgnore]
		public Vector3h Wzy
		{
			get
			{
				return new Vector3h(this.W, this.Z, this.Y);
			}
			set
			{
				this.W = value.X;
				this.Z = value.Y;
				this.Y = value.Z;
			}
		}

		// Token: 0x170003E4 RID: 996
		// (get) Token: 0x06004330 RID: 17200 RVA: 0x000B5CC8 File Offset: 0x000B3EC8
		// (set) Token: 0x06004331 RID: 17201 RVA: 0x000B5CE8 File Offset: 0x000B3EE8
		[XmlIgnore]
		public Vector4h Xywz
		{
			get
			{
				return new Vector4h(this.X, this.Y, this.W, this.Z);
			}
			set
			{
				this.X = value.X;
				this.Y = value.Y;
				this.W = value.Z;
				this.Z = value.W;
			}
		}

		// Token: 0x170003E5 RID: 997
		// (get) Token: 0x06004332 RID: 17202 RVA: 0x000B5D20 File Offset: 0x000B3F20
		// (set) Token: 0x06004333 RID: 17203 RVA: 0x000B5D40 File Offset: 0x000B3F40
		[XmlIgnore]
		public Vector4h Xzyw
		{
			get
			{
				return new Vector4h(this.X, this.Z, this.Y, this.W);
			}
			set
			{
				this.X = value.X;
				this.Z = value.Y;
				this.Y = value.Z;
				this.W = value.W;
			}
		}

		// Token: 0x170003E6 RID: 998
		// (get) Token: 0x06004334 RID: 17204 RVA: 0x000B5D78 File Offset: 0x000B3F78
		// (set) Token: 0x06004335 RID: 17205 RVA: 0x000B5D98 File Offset: 0x000B3F98
		[XmlIgnore]
		public Vector4h Xzwy
		{
			get
			{
				return new Vector4h(this.X, this.Z, this.W, this.Y);
			}
			set
			{
				this.X = value.X;
				this.Z = value.Y;
				this.W = value.Z;
				this.Y = value.W;
			}
		}

		// Token: 0x170003E7 RID: 999
		// (get) Token: 0x06004336 RID: 17206 RVA: 0x000B5DD0 File Offset: 0x000B3FD0
		// (set) Token: 0x06004337 RID: 17207 RVA: 0x000B5DF0 File Offset: 0x000B3FF0
		[XmlIgnore]
		public Vector4h Xwyz
		{
			get
			{
				return new Vector4h(this.X, this.W, this.Y, this.Z);
			}
			set
			{
				this.X = value.X;
				this.W = value.Y;
				this.Y = value.Z;
				this.Z = value.W;
			}
		}

		// Token: 0x170003E8 RID: 1000
		// (get) Token: 0x06004338 RID: 17208 RVA: 0x000B5E28 File Offset: 0x000B4028
		// (set) Token: 0x06004339 RID: 17209 RVA: 0x000B5E48 File Offset: 0x000B4048
		[XmlIgnore]
		public Vector4h Xwzy
		{
			get
			{
				return new Vector4h(this.X, this.W, this.Z, this.Y);
			}
			set
			{
				this.X = value.X;
				this.W = value.Y;
				this.Z = value.Z;
				this.Y = value.W;
			}
		}

		// Token: 0x170003E9 RID: 1001
		// (get) Token: 0x0600433A RID: 17210 RVA: 0x000B5E80 File Offset: 0x000B4080
		// (set) Token: 0x0600433B RID: 17211 RVA: 0x000B5EA0 File Offset: 0x000B40A0
		[XmlIgnore]
		public Vector4h Yxzw
		{
			get
			{
				return new Vector4h(this.Y, this.X, this.Z, this.W);
			}
			set
			{
				this.Y = value.X;
				this.X = value.Y;
				this.Z = value.Z;
				this.W = value.W;
			}
		}

		// Token: 0x170003EA RID: 1002
		// (get) Token: 0x0600433C RID: 17212 RVA: 0x000B5ED8 File Offset: 0x000B40D8
		// (set) Token: 0x0600433D RID: 17213 RVA: 0x000B5EF8 File Offset: 0x000B40F8
		[XmlIgnore]
		public Vector4h Yxwz
		{
			get
			{
				return new Vector4h(this.Y, this.X, this.W, this.Z);
			}
			set
			{
				this.Y = value.X;
				this.X = value.Y;
				this.W = value.Z;
				this.Z = value.W;
			}
		}

		// Token: 0x170003EB RID: 1003
		// (get) Token: 0x0600433E RID: 17214 RVA: 0x000B5F30 File Offset: 0x000B4130
		// (set) Token: 0x0600433F RID: 17215 RVA: 0x000B5F50 File Offset: 0x000B4150
		[XmlIgnore]
		public Vector4h Yyzw
		{
			get
			{
				return new Vector4h(this.Y, this.Y, this.Z, this.W);
			}
			set
			{
				this.X = value.X;
				this.Y = value.Y;
				this.Z = value.Z;
				this.W = value.W;
			}
		}

		// Token: 0x170003EC RID: 1004
		// (get) Token: 0x06004340 RID: 17216 RVA: 0x000B5F88 File Offset: 0x000B4188
		// (set) Token: 0x06004341 RID: 17217 RVA: 0x000B5FA8 File Offset: 0x000B41A8
		[XmlIgnore]
		public Vector4h Yywz
		{
			get
			{
				return new Vector4h(this.Y, this.Y, this.W, this.Z);
			}
			set
			{
				this.X = value.X;
				this.Y = value.Y;
				this.W = value.Z;
				this.Z = value.W;
			}
		}

		// Token: 0x170003ED RID: 1005
		// (get) Token: 0x06004342 RID: 17218 RVA: 0x000B5FE0 File Offset: 0x000B41E0
		// (set) Token: 0x06004343 RID: 17219 RVA: 0x000B6000 File Offset: 0x000B4200
		[XmlIgnore]
		public Vector4h Yzxw
		{
			get
			{
				return new Vector4h(this.Y, this.Z, this.X, this.W);
			}
			set
			{
				this.Y = value.X;
				this.Z = value.Y;
				this.X = value.Z;
				this.W = value.W;
			}
		}

		// Token: 0x170003EE RID: 1006
		// (get) Token: 0x06004344 RID: 17220 RVA: 0x000B6038 File Offset: 0x000B4238
		// (set) Token: 0x06004345 RID: 17221 RVA: 0x000B6058 File Offset: 0x000B4258
		[XmlIgnore]
		public Vector4h Yzwx
		{
			get
			{
				return new Vector4h(this.Y, this.Z, this.W, this.X);
			}
			set
			{
				this.Y = value.X;
				this.Z = value.Y;
				this.W = value.Z;
				this.X = value.W;
			}
		}

		// Token: 0x170003EF RID: 1007
		// (get) Token: 0x06004346 RID: 17222 RVA: 0x000B6090 File Offset: 0x000B4290
		// (set) Token: 0x06004347 RID: 17223 RVA: 0x000B60B0 File Offset: 0x000B42B0
		[XmlIgnore]
		public Vector4h Ywxz
		{
			get
			{
				return new Vector4h(this.Y, this.W, this.X, this.Z);
			}
			set
			{
				this.Y = value.X;
				this.W = value.Y;
				this.X = value.Z;
				this.Z = value.W;
			}
		}

		// Token: 0x170003F0 RID: 1008
		// (get) Token: 0x06004348 RID: 17224 RVA: 0x000B60E8 File Offset: 0x000B42E8
		// (set) Token: 0x06004349 RID: 17225 RVA: 0x000B6108 File Offset: 0x000B4308
		[XmlIgnore]
		public Vector4h Ywzx
		{
			get
			{
				return new Vector4h(this.Y, this.W, this.Z, this.X);
			}
			set
			{
				this.Y = value.X;
				this.W = value.Y;
				this.Z = value.Z;
				this.X = value.W;
			}
		}

		// Token: 0x170003F1 RID: 1009
		// (get) Token: 0x0600434A RID: 17226 RVA: 0x000B6140 File Offset: 0x000B4340
		// (set) Token: 0x0600434B RID: 17227 RVA: 0x000B6160 File Offset: 0x000B4360
		[XmlIgnore]
		public Vector4h Zxyw
		{
			get
			{
				return new Vector4h(this.Z, this.X, this.Y, this.W);
			}
			set
			{
				this.Z = value.X;
				this.X = value.Y;
				this.Y = value.Z;
				this.W = value.W;
			}
		}

		// Token: 0x170003F2 RID: 1010
		// (get) Token: 0x0600434C RID: 17228 RVA: 0x000B6198 File Offset: 0x000B4398
		// (set) Token: 0x0600434D RID: 17229 RVA: 0x000B61B8 File Offset: 0x000B43B8
		[XmlIgnore]
		public Vector4h Zxwy
		{
			get
			{
				return new Vector4h(this.Z, this.X, this.W, this.Y);
			}
			set
			{
				this.Z = value.X;
				this.X = value.Y;
				this.W = value.Z;
				this.Y = value.W;
			}
		}

		// Token: 0x170003F3 RID: 1011
		// (get) Token: 0x0600434E RID: 17230 RVA: 0x000B61F0 File Offset: 0x000B43F0
		// (set) Token: 0x0600434F RID: 17231 RVA: 0x000B6210 File Offset: 0x000B4410
		[XmlIgnore]
		public Vector4h Zyxw
		{
			get
			{
				return new Vector4h(this.Z, this.Y, this.X, this.W);
			}
			set
			{
				this.Z = value.X;
				this.Y = value.Y;
				this.X = value.Z;
				this.W = value.W;
			}
		}

		// Token: 0x170003F4 RID: 1012
		// (get) Token: 0x06004350 RID: 17232 RVA: 0x000B6248 File Offset: 0x000B4448
		// (set) Token: 0x06004351 RID: 17233 RVA: 0x000B6268 File Offset: 0x000B4468
		[XmlIgnore]
		public Vector4h Zywx
		{
			get
			{
				return new Vector4h(this.Z, this.Y, this.W, this.X);
			}
			set
			{
				this.Z = value.X;
				this.Y = value.Y;
				this.W = value.Z;
				this.X = value.W;
			}
		}

		// Token: 0x170003F5 RID: 1013
		// (get) Token: 0x06004352 RID: 17234 RVA: 0x000B62A0 File Offset: 0x000B44A0
		// (set) Token: 0x06004353 RID: 17235 RVA: 0x000B62C0 File Offset: 0x000B44C0
		[XmlIgnore]
		public Vector4h Zwxy
		{
			get
			{
				return new Vector4h(this.Z, this.W, this.X, this.Y);
			}
			set
			{
				this.Z = value.X;
				this.W = value.Y;
				this.X = value.Z;
				this.Y = value.W;
			}
		}

		// Token: 0x170003F6 RID: 1014
		// (get) Token: 0x06004354 RID: 17236 RVA: 0x000B62F8 File Offset: 0x000B44F8
		// (set) Token: 0x06004355 RID: 17237 RVA: 0x000B6318 File Offset: 0x000B4518
		[XmlIgnore]
		public Vector4h Zwyx
		{
			get
			{
				return new Vector4h(this.Z, this.W, this.Y, this.X);
			}
			set
			{
				this.Z = value.X;
				this.W = value.Y;
				this.Y = value.Z;
				this.X = value.W;
			}
		}

		// Token: 0x170003F7 RID: 1015
		// (get) Token: 0x06004356 RID: 17238 RVA: 0x000B6350 File Offset: 0x000B4550
		// (set) Token: 0x06004357 RID: 17239 RVA: 0x000B6370 File Offset: 0x000B4570
		[XmlIgnore]
		public Vector4h Zwzy
		{
			get
			{
				return new Vector4h(this.Z, this.W, this.Z, this.Y);
			}
			set
			{
				this.X = value.X;
				this.W = value.Y;
				this.Z = value.Z;
				this.Y = value.W;
			}
		}

		// Token: 0x170003F8 RID: 1016
		// (get) Token: 0x06004358 RID: 17240 RVA: 0x000B63A8 File Offset: 0x000B45A8
		// (set) Token: 0x06004359 RID: 17241 RVA: 0x000B63C8 File Offset: 0x000B45C8
		[XmlIgnore]
		public Vector4h Wxyz
		{
			get
			{
				return new Vector4h(this.W, this.X, this.Y, this.Z);
			}
			set
			{
				this.W = value.X;
				this.X = value.Y;
				this.Y = value.Z;
				this.Z = value.W;
			}
		}

		// Token: 0x170003F9 RID: 1017
		// (get) Token: 0x0600435A RID: 17242 RVA: 0x000B6400 File Offset: 0x000B4600
		// (set) Token: 0x0600435B RID: 17243 RVA: 0x000B6420 File Offset: 0x000B4620
		[XmlIgnore]
		public Vector4h Wxzy
		{
			get
			{
				return new Vector4h(this.W, this.X, this.Z, this.Y);
			}
			set
			{
				this.W = value.X;
				this.X = value.Y;
				this.Z = value.Z;
				this.Y = value.W;
			}
		}

		// Token: 0x170003FA RID: 1018
		// (get) Token: 0x0600435C RID: 17244 RVA: 0x000B6458 File Offset: 0x000B4658
		// (set) Token: 0x0600435D RID: 17245 RVA: 0x000B6478 File Offset: 0x000B4678
		[XmlIgnore]
		public Vector4h Wyxz
		{
			get
			{
				return new Vector4h(this.W, this.Y, this.X, this.Z);
			}
			set
			{
				this.W = value.X;
				this.Y = value.Y;
				this.X = value.Z;
				this.Z = value.W;
			}
		}

		// Token: 0x170003FB RID: 1019
		// (get) Token: 0x0600435E RID: 17246 RVA: 0x000B64B0 File Offset: 0x000B46B0
		// (set) Token: 0x0600435F RID: 17247 RVA: 0x000B64D0 File Offset: 0x000B46D0
		[XmlIgnore]
		public Vector4h Wyzx
		{
			get
			{
				return new Vector4h(this.W, this.Y, this.Z, this.X);
			}
			set
			{
				this.W = value.X;
				this.Y = value.Y;
				this.Z = value.Z;
				this.X = value.W;
			}
		}

		// Token: 0x170003FC RID: 1020
		// (get) Token: 0x06004360 RID: 17248 RVA: 0x000B6508 File Offset: 0x000B4708
		// (set) Token: 0x06004361 RID: 17249 RVA: 0x000B6528 File Offset: 0x000B4728
		[XmlIgnore]
		public Vector4h Wzxy
		{
			get
			{
				return new Vector4h(this.W, this.Z, this.X, this.Y);
			}
			set
			{
				this.W = value.X;
				this.Z = value.Y;
				this.X = value.Z;
				this.Y = value.W;
			}
		}

		// Token: 0x170003FD RID: 1021
		// (get) Token: 0x06004362 RID: 17250 RVA: 0x000B6560 File Offset: 0x000B4760
		// (set) Token: 0x06004363 RID: 17251 RVA: 0x000B6580 File Offset: 0x000B4780
		[XmlIgnore]
		public Vector4h Wzyx
		{
			get
			{
				return new Vector4h(this.W, this.Z, this.Y, this.X);
			}
			set
			{
				this.W = value.X;
				this.Z = value.Y;
				this.Y = value.Z;
				this.X = value.W;
			}
		}

		// Token: 0x170003FE RID: 1022
		// (get) Token: 0x06004364 RID: 17252 RVA: 0x000B65B8 File Offset: 0x000B47B8
		// (set) Token: 0x06004365 RID: 17253 RVA: 0x000B65D8 File Offset: 0x000B47D8
		[XmlIgnore]
		public Vector4h Wzyw
		{
			get
			{
				return new Vector4h(this.W, this.Z, this.Y, this.W);
			}
			set
			{
				this.X = value.X;
				this.Z = value.Y;
				this.Y = value.Z;
				this.W = value.W;
			}
		}

		// Token: 0x06004366 RID: 17254 RVA: 0x000B6610 File Offset: 0x000B4810
		public Vector4 ToVector4()
		{
			return new Vector4(this.X, this.Y, this.Z, this.W);
		}

		// Token: 0x06004367 RID: 17255 RVA: 0x000B6648 File Offset: 0x000B4848
		public Vector4d ToVector4d()
		{
			return new Vector4d(this.X, this.Y, this.Z, this.W);
		}

		// Token: 0x06004368 RID: 17256 RVA: 0x000B6680 File Offset: 0x000B4880
		public static explicit operator Vector4h(Vector4 v4f)
		{
			return new Vector4h(v4f);
		}

		// Token: 0x06004369 RID: 17257 RVA: 0x000B6688 File Offset: 0x000B4888
		public static explicit operator Vector4h(Vector4d v4d)
		{
			return new Vector4h(v4d);
		}

		// Token: 0x0600436A RID: 17258 RVA: 0x000B6690 File Offset: 0x000B4890
		public static explicit operator Vector4(Vector4h h4)
		{
			return new Vector4
			{
				X = h4.X.ToSingle(),
				Y = h4.Y.ToSingle(),
				Z = h4.Z.ToSingle(),
				W = h4.W.ToSingle()
			};
		}

		// Token: 0x0600436B RID: 17259 RVA: 0x000B66F4 File Offset: 0x000B48F4
		public static explicit operator Vector4d(Vector4h h4)
		{
			return new Vector4d
			{
				X = (double)h4.X.ToSingle(),
				Y = (double)h4.Y.ToSingle(),
				Z = (double)h4.Z.ToSingle(),
				W = (double)h4.W.ToSingle()
			};
		}

		// Token: 0x0600436C RID: 17260 RVA: 0x000B675C File Offset: 0x000B495C
		public Vector4h(SerializationInfo info, StreamingContext context)
		{
			this.X = (Half)info.GetValue("X", typeof(Half));
			this.Y = (Half)info.GetValue("Y", typeof(Half));
			this.Z = (Half)info.GetValue("Z", typeof(Half));
			this.W = (Half)info.GetValue("W", typeof(Half));
		}

		// Token: 0x0600436D RID: 17261 RVA: 0x000B67EC File Offset: 0x000B49EC
		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.AddValue("X", this.X);
			info.AddValue("Y", this.Y);
			info.AddValue("Z", this.Z);
			info.AddValue("W", this.W);
		}

		// Token: 0x0600436E RID: 17262 RVA: 0x000B6858 File Offset: 0x000B4A58
		public void FromBinaryStream(BinaryReader bin)
		{
			this.X.FromBinaryStream(bin);
			this.Y.FromBinaryStream(bin);
			this.Z.FromBinaryStream(bin);
			this.W.FromBinaryStream(bin);
		}

		// Token: 0x0600436F RID: 17263 RVA: 0x000B688C File Offset: 0x000B4A8C
		public void ToBinaryStream(BinaryWriter bin)
		{
			this.X.ToBinaryStream(bin);
			this.Y.ToBinaryStream(bin);
			this.Z.ToBinaryStream(bin);
			this.W.ToBinaryStream(bin);
		}

		// Token: 0x06004370 RID: 17264 RVA: 0x000B68C0 File Offset: 0x000B4AC0
		public bool Equals(Vector4h other)
		{
			return this.X.Equals(other.X) && this.Y.Equals(other.Y) && this.Z.Equals(other.Z) && this.W.Equals(other.W);
		}

		// Token: 0x06004371 RID: 17265 RVA: 0x000B6920 File Offset: 0x000B4B20
		public override string ToString()
		{
			return string.Format("({0}{4} {1}{4} {2}{4} {3})", new object[]
			{
				this.X.ToString(),
				this.Y.ToString(),
				this.Z.ToString(),
				this.W.ToString(),
				Vector4h.listSeparator
			});
		}

		// Token: 0x06004372 RID: 17266 RVA: 0x000B6998 File Offset: 0x000B4B98
		public static byte[] GetBytes(Vector4h h)
		{
			byte[] array = new byte[Vector4h.SizeInBytes];
			byte[] bytes = Half.GetBytes(h.X);
			array[0] = bytes[0];
			array[1] = bytes[1];
			bytes = Half.GetBytes(h.Y);
			array[2] = bytes[0];
			array[3] = bytes[1];
			bytes = Half.GetBytes(h.Z);
			array[4] = bytes[0];
			array[5] = bytes[1];
			bytes = Half.GetBytes(h.W);
			array[6] = bytes[0];
			array[7] = bytes[1];
			return array;
		}

		// Token: 0x06004373 RID: 17267 RVA: 0x000B6A18 File Offset: 0x000B4C18
		public static Vector4h FromBytes(byte[] value, int startIndex)
		{
			return new Vector4h
			{
				X = Half.FromBytes(value, startIndex),
				Y = Half.FromBytes(value, startIndex + 2),
				Z = Half.FromBytes(value, startIndex + 4),
				W = Half.FromBytes(value, startIndex + 6)
			};
		}

		// Token: 0x04004E56 RID: 20054
		public Half X;

		// Token: 0x04004E57 RID: 20055
		public Half Y;

		// Token: 0x04004E58 RID: 20056
		public Half Z;

		// Token: 0x04004E59 RID: 20057
		public Half W;

		// Token: 0x04004E5A RID: 20058
		public static readonly int SizeInBytes = 8;

		// Token: 0x04004E5B RID: 20059
		private static string listSeparator = CultureInfo.CurrentCulture.TextInfo.ListSeparator;
	}
}
