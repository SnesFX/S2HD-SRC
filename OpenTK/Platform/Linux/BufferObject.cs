using System;

namespace OpenTK.Platform.Linux
{
	// Token: 0x02000B78 RID: 2936
	internal struct BufferObject : IEquatable<BufferObject>
	{
		// Token: 0x06005BBF RID: 23487 RVA: 0x000F8B28 File Offset: 0x000F6D28
		public unsafe int Write(byte[] data)
		{
			fixed (byte* ptr = data)
			{
				return Gbm.BOWrite(this.buffer, (IntPtr)((void*)ptr), (IntPtr)data.Length);
			}
		}

		// Token: 0x06005BC0 RID: 23488 RVA: 0x000F8B6C File Offset: 0x000F6D6C
		public void SetUserData(IntPtr data, DestroyUserDataCallback destroyFB)
		{
			Gbm.BOSetUserData(this.buffer, data, destroyFB);
		}

		// Token: 0x170004E4 RID: 1252
		// (get) Token: 0x06005BC1 RID: 23489 RVA: 0x000F8B7C File Offset: 0x000F6D7C
		public IntPtr Device
		{
			get
			{
				return Gbm.BOGetDevice(this.buffer);
			}
		}

		// Token: 0x170004E5 RID: 1253
		// (get) Token: 0x06005BC2 RID: 23490 RVA: 0x000F8B8C File Offset: 0x000F6D8C
		public int Handle
		{
			get
			{
				return Gbm.BOGetHandle(this.buffer).ToInt32();
			}
		}

		// Token: 0x170004E6 RID: 1254
		// (get) Token: 0x06005BC3 RID: 23491 RVA: 0x000F8BAC File Offset: 0x000F6DAC
		public int Width
		{
			get
			{
				return Gbm.BOGetWidth(this.buffer);
			}
		}

		// Token: 0x170004E7 RID: 1255
		// (get) Token: 0x06005BC4 RID: 23492 RVA: 0x000F8BBC File Offset: 0x000F6DBC
		public int Height
		{
			get
			{
				return Gbm.BOGetHeight(this.buffer);
			}
		}

		// Token: 0x170004E8 RID: 1256
		// (get) Token: 0x06005BC5 RID: 23493 RVA: 0x000F8BCC File Offset: 0x000F6DCC
		public int Stride
		{
			get
			{
				return Gbm.BOGetStride(this.buffer);
			}
		}

		// Token: 0x06005BC6 RID: 23494 RVA: 0x000F8BDC File Offset: 0x000F6DDC
		public void Dispose()
		{
			Gbm.DestroyBuffer(this);
			this.buffer = IntPtr.Zero;
		}

		// Token: 0x06005BC7 RID: 23495 RVA: 0x000F8BF4 File Offset: 0x000F6DF4
		public static bool operator ==(BufferObject left, BufferObject right)
		{
			return left.Equals(right);
		}

		// Token: 0x06005BC8 RID: 23496 RVA: 0x000F8C00 File Offset: 0x000F6E00
		public static bool operator !=(BufferObject left, BufferObject right)
		{
			return !left.Equals(right);
		}

		// Token: 0x06005BC9 RID: 23497 RVA: 0x000F8C10 File Offset: 0x000F6E10
		public override bool Equals(object obj)
		{
			return obj is BufferObject && this.Equals((BufferObject)obj);
		}

		// Token: 0x06005BCA RID: 23498 RVA: 0x000F8C28 File Offset: 0x000F6E28
		public override int GetHashCode()
		{
			return this.buffer.GetHashCode();
		}

		// Token: 0x06005BCB RID: 23499 RVA: 0x000F8C3C File Offset: 0x000F6E3C
		public override string ToString()
		{
			return string.Format("[BufferObject: {0}]", this.buffer);
		}

		// Token: 0x06005BCC RID: 23500 RVA: 0x000F8C54 File Offset: 0x000F6E54
		public bool Equals(BufferObject other)
		{
			return this.buffer == other.buffer;
		}

		// Token: 0x0400B887 RID: 47239
		private IntPtr buffer;

		// Token: 0x0400B888 RID: 47240
		public static readonly BufferObject Zero = default(BufferObject);
	}
}
