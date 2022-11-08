using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace OpenTK.Input
{
	// Token: 0x0200051A RID: 1306
	public struct KeyboardState : IEquatable<KeyboardState>
	{
		// Token: 0x1700028C RID: 652
		public bool this[Key key]
		{
			get
			{
				return this.IsKeyDown(key);
			}
			internal set
			{
				this.SetKeyState(key, value);
			}
		}

		// Token: 0x1700028D RID: 653
		public bool this[short code]
		{
			get
			{
				return this.IsKeyDown((Key)code);
			}
		}

		// Token: 0x06003D6E RID: 15726 RVA: 0x000A1A10 File Offset: 0x0009FC10
		public bool IsKeyDown(Key key)
		{
			return this.ReadBit((int)key);
		}

		// Token: 0x06003D6F RID: 15727 RVA: 0x000A1A1C File Offset: 0x0009FC1C
		public bool IsKeyDown(short code)
		{
			return code >= 0 && code < 131 && this.ReadBit((int)code);
		}

		// Token: 0x06003D70 RID: 15728 RVA: 0x000A1A34 File Offset: 0x0009FC34
		public bool IsKeyUp(Key key)
		{
			return !this.ReadBit((int)key);
		}

		// Token: 0x06003D71 RID: 15729 RVA: 0x000A1A40 File Offset: 0x0009FC40
		public bool IsKeyUp(short code)
		{
			return !this.IsKeyDown(code);
		}

		// Token: 0x1700028E RID: 654
		// (get) Token: 0x06003D72 RID: 15730 RVA: 0x000A1A4C File Offset: 0x0009FC4C
		// (set) Token: 0x06003D73 RID: 15731 RVA: 0x000A1A54 File Offset: 0x0009FC54
		public bool IsConnected
		{
			get
			{
				return this.is_connected;
			}
			internal set
			{
				this.is_connected = value;
			}
		}

		// Token: 0x06003D74 RID: 15732 RVA: 0x000A1A60 File Offset: 0x0009FC60
		public static bool operator ==(KeyboardState left, KeyboardState right)
		{
			return left.Equals(right);
		}

		// Token: 0x06003D75 RID: 15733 RVA: 0x000A1A6C File Offset: 0x0009FC6C
		public static bool operator !=(KeyboardState left, KeyboardState right)
		{
			return !left.Equals(right);
		}

		// Token: 0x06003D76 RID: 15734 RVA: 0x000A1A7C File Offset: 0x0009FC7C
		public override bool Equals(object obj)
		{
			return obj is KeyboardState && this == (KeyboardState)obj;
		}

		// Token: 0x06003D77 RID: 15735 RVA: 0x000A1A9C File Offset: 0x0009FC9C
		public unsafe override int GetHashCode()
		{
			fixed (int* ptr = &this.Keys.FixedElementField)
			{
				int num = 0;
				for (int i = 0; i < 33; i++)
				{
					num ^= ptr[i].GetHashCode();
				}
				return num;
			}
		}

		// Token: 0x06003D78 RID: 15736 RVA: 0x000A1AD8 File Offset: 0x0009FCD8
		internal void SetKeyState(Key key, bool down)
		{
			if (down)
			{
				this.EnableBit((int)key);
				return;
			}
			this.DisableBit((int)key);
		}

		// Token: 0x06003D79 RID: 15737 RVA: 0x000A1AEC File Offset: 0x0009FCEC
		internal unsafe bool ReadBit(int offset)
		{
			KeyboardState.ValidateOffset(offset);
			int num = offset / 32;
			int num2 = offset % 32;
			fixed (int* ptr = &this.Keys.FixedElementField)
			{
				return (long)(ptr[num] & 1 << num2) != 0L;
			}
		}

		// Token: 0x06003D7A RID: 15738 RVA: 0x000A1B30 File Offset: 0x0009FD30
		internal unsafe void EnableBit(int offset)
		{
			KeyboardState.ValidateOffset(offset);
			int num = offset / 32;
			int num2 = offset % 32;
			fixed (int* ptr = &this.Keys.FixedElementField)
			{
				ptr[num] |= 1 << num2;
			}
		}

		// Token: 0x06003D7B RID: 15739 RVA: 0x000A1B70 File Offset: 0x0009FD70
		internal unsafe void DisableBit(int offset)
		{
			KeyboardState.ValidateOffset(offset);
			int num = offset / 32;
			int num2 = offset % 32;
			fixed (int* ptr = &this.Keys.FixedElementField)
			{
				ptr[num] &= ~(1 << num2);
			}
		}

		// Token: 0x06003D7C RID: 15740 RVA: 0x000A1BB0 File Offset: 0x0009FDB0
		internal unsafe void MergeBits(KeyboardState other)
		{
			int* ptr = &other.Keys.FixedElementField;
			fixed (int* ptr2 = &this.Keys.FixedElementField)
			{
				for (int i = 0; i < 33; i++)
				{
					ptr2[i] |= ptr[i];
				}
			}
			this.IsConnected |= other.IsConnected;
		}

		// Token: 0x06003D7D RID: 15741 RVA: 0x000A1C10 File Offset: 0x0009FE10
		internal void SetIsConnected(bool value)
		{
			this.IsConnected = value;
		}

		// Token: 0x06003D7E RID: 15742 RVA: 0x000A1C1C File Offset: 0x0009FE1C
		private static void ValidateOffset(int offset)
		{
			if (offset < 0 || offset >= 132)
			{
				throw new ArgumentOutOfRangeException();
			}
		}

		// Token: 0x06003D7F RID: 15743 RVA: 0x000A1C30 File Offset: 0x0009FE30
		public unsafe bool Equals(KeyboardState other)
		{
			bool flag = true;
			int* ptr = &other.Keys.FixedElementField;
			fixed (int* ptr2 = &this.Keys.FixedElementField)
			{
				int num = 0;
				while (flag && num < 33)
				{
					flag &= (ptr2[num] == ptr[num]);
					num++;
				}
			}
			return flag;
		}

		// Token: 0x04004DA6 RID: 19878
		private const int IntSize = 4;

		// Token: 0x04004DA7 RID: 19879
		private const int NumInts = 33;

		// Token: 0x04004DA8 RID: 19880
		[FixedBuffer(typeof(int), 33)]
		private KeyboardState.<Keys>e__FixedBuffer1 Keys;

		// Token: 0x04004DA9 RID: 19881
		private bool is_connected;

		// Token: 0x0200051B RID: 1307
		[CompilerGenerated]
		[UnsafeValueType]
		[StructLayout(LayoutKind.Sequential, Size = 132)]
		public struct <Keys>e__FixedBuffer1
		{
			// Token: 0x04004DAA RID: 19882
			public int FixedElementField;
		}
	}
}
