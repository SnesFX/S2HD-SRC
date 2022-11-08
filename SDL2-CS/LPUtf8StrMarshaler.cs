using System;
using System.Runtime.InteropServices;
using System.Text;

namespace SDL2
{
	// Token: 0x02000006 RID: 6
	internal class LPUtf8StrMarshaler : ICustomMarshaler
	{
		// Token: 0x06000277 RID: 631 RVA: 0x00002B3C File Offset: 0x00000D3C
		public static ICustomMarshaler GetInstance(string cookie)
		{
			ICustomMarshaler result;
			if (!(cookie == "LeaveAllocated"))
			{
				result = LPUtf8StrMarshaler._defaultInstance;
			}
			else
			{
				result = LPUtf8StrMarshaler._leaveAllocatedInstance;
			}
			return result;
		}

		// Token: 0x06000278 RID: 632 RVA: 0x00002B6C File Offset: 0x00000D6C
		public LPUtf8StrMarshaler(bool leaveAllocated)
		{
			this._leaveAllocated = leaveAllocated;
		}

		// Token: 0x06000279 RID: 633 RVA: 0x00002B80 File Offset: 0x00000D80
		public unsafe object MarshalNativeToManaged(IntPtr pNativeData)
		{
			bool flag = pNativeData == IntPtr.Zero;
			object result;
			if (flag)
			{
				result = null;
			}
			else
			{
				byte* ptr = (byte*)((void*)pNativeData);
				while (*ptr > 0)
				{
					ptr++;
				}
				byte[] array = new byte[(long)((byte*)ptr - (byte*)((void*)pNativeData))];
				Marshal.Copy(pNativeData, array, 0, array.Length);
				result = Encoding.UTF8.GetString(array);
			}
			return result;
		}

		// Token: 0x0600027A RID: 634 RVA: 0x00002BE8 File Offset: 0x00000DE8
		public unsafe IntPtr MarshalManagedToNative(object ManagedObj)
		{
			bool flag = ManagedObj == null;
			IntPtr result;
			if (flag)
			{
				result = IntPtr.Zero;
			}
			else
			{
				string text = ManagedObj as string;
				bool flag2 = text == null;
				if (flag2)
				{
					throw new ArgumentException("ManagedObj must be a string.", "ManagedObj");
				}
				byte[] bytes = Encoding.UTF8.GetBytes(text);
				IntPtr intPtr = SDL.SDL_malloc((IntPtr)(bytes.Length + 1));
				Marshal.Copy(bytes, 0, intPtr, bytes.Length);
				((byte*)((void*)intPtr))[bytes.Length] = 0;
				result = intPtr;
			}
			return result;
		}

		// Token: 0x0600027B RID: 635 RVA: 0x00002C64 File Offset: 0x00000E64
		public void CleanUpManagedData(object ManagedObj)
		{
		}

		// Token: 0x0600027C RID: 636 RVA: 0x00002C68 File Offset: 0x00000E68
		public void CleanUpNativeData(IntPtr pNativeData)
		{
			bool flag = !this._leaveAllocated;
			if (flag)
			{
				SDL.SDL_free(pNativeData);
			}
		}

		// Token: 0x0600027D RID: 637 RVA: 0x00002C8C File Offset: 0x00000E8C
		public int GetNativeDataSize()
		{
			return -1;
		}

		// Token: 0x040000E7 RID: 231
		public const string LeaveAllocated = "LeaveAllocated";

		// Token: 0x040000E8 RID: 232
		private static ICustomMarshaler _leaveAllocatedInstance = new LPUtf8StrMarshaler(true);

		// Token: 0x040000E9 RID: 233
		private static ICustomMarshaler _defaultInstance = new LPUtf8StrMarshaler(false);

		// Token: 0x040000EA RID: 234
		private bool _leaveAllocated;
	}
}
