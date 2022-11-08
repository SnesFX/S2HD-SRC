using System;

namespace OpenTK
{
	// Token: 0x0200004A RID: 74
	public struct ContextHandle : IComparable<ContextHandle>, IEquatable<ContextHandle>
	{
		// Token: 0x17000109 RID: 265
		// (get) Token: 0x06000500 RID: 1280 RVA: 0x00014AF4 File Offset: 0x00012CF4
		public IntPtr Handle
		{
			get
			{
				return this.handle;
			}
		}

		// Token: 0x06000501 RID: 1281 RVA: 0x00014AFC File Offset: 0x00012CFC
		public ContextHandle(IntPtr h)
		{
			this.handle = h;
		}

		// Token: 0x06000502 RID: 1282 RVA: 0x00014B08 File Offset: 0x00012D08
		public override string ToString()
		{
			return this.Handle.ToString();
		}

		// Token: 0x06000503 RID: 1283 RVA: 0x00014B2C File Offset: 0x00012D2C
		public override bool Equals(object obj)
		{
			return obj is ContextHandle && this.Equals((ContextHandle)obj);
		}

		// Token: 0x06000504 RID: 1284 RVA: 0x00014B44 File Offset: 0x00012D44
		public override int GetHashCode()
		{
			return this.Handle.GetHashCode();
		}

		// Token: 0x06000505 RID: 1285 RVA: 0x00014B68 File Offset: 0x00012D68
		public static explicit operator IntPtr(ContextHandle c)
		{
			if (!(c != ContextHandle.Zero))
			{
				return IntPtr.Zero;
			}
			return c.handle;
		}

		// Token: 0x06000506 RID: 1286 RVA: 0x00014B84 File Offset: 0x00012D84
		public static explicit operator ContextHandle(IntPtr p)
		{
			return new ContextHandle(p);
		}

		// Token: 0x06000507 RID: 1287 RVA: 0x00014B8C File Offset: 0x00012D8C
		public static bool operator ==(ContextHandle left, ContextHandle right)
		{
			return left.Equals(right);
		}

		// Token: 0x06000508 RID: 1288 RVA: 0x00014B98 File Offset: 0x00012D98
		public static bool operator !=(ContextHandle left, ContextHandle right)
		{
			return !left.Equals(right);
		}

		// Token: 0x06000509 RID: 1289 RVA: 0x00014BA8 File Offset: 0x00012DA8
		public unsafe int CompareTo(ContextHandle other)
		{
			return (int)((long)(((byte*)other.handle.ToPointer() - (byte*)this.handle.ToPointer()) / 4));
		}

		// Token: 0x0600050A RID: 1290 RVA: 0x00014BC8 File Offset: 0x00012DC8
		public bool Equals(ContextHandle other)
		{
			return this.Handle == other.Handle;
		}

		// Token: 0x0400014A RID: 330
		private IntPtr handle;

		// Token: 0x0400014B RID: 331
		public static readonly ContextHandle Zero = new ContextHandle(IntPtr.Zero);
	}
}
