using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace OpenTK.Platform.SDL2
{
	// Token: 0x020005CD RID: 1485
	internal struct JoystickGuid
	{
		// Token: 0x060046DE RID: 18142 RVA: 0x000C34E8 File Offset: 0x000C16E8
		public unsafe Guid ToGuid()
		{
			byte[] array = new byte[16];
			fixed (byte* ptr = &this.data.FixedElementField)
			{
				Marshal.Copy(new IntPtr((void*)ptr), array, 0, array.Length);
			}
			return new Guid(array);
		}

		// Token: 0x04005536 RID: 21814
		[FixedBuffer(typeof(byte), 16)]
		private JoystickGuid.<data>e__FixedBuffer3 data;

		// Token: 0x020005CE RID: 1486
		[UnsafeValueType]
		[CompilerGenerated]
		[StructLayout(LayoutKind.Sequential, Size = 16)]
		public struct <data>e__FixedBuffer3
		{
			// Token: 0x04005537 RID: 21815
			public byte FixedElementField;
		}
	}
}
