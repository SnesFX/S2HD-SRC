using System;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenTK.Platform.Linux
{
	// Token: 0x02000B7D RID: 2941
	internal class Libc
	{
		// Token: 0x06005BF2 RID: 23538
		[DllImport("libc")]
		public static extern int dup(int file);

		// Token: 0x06005BF3 RID: 23539
		[DllImport("libc")]
		public static extern int dup2(int file1, int file2);

		// Token: 0x06005BF4 RID: 23540
		[DllImport("libc")]
		public static extern int ioctl(int d, JoystickIoctlCode request, ref int data);

		// Token: 0x06005BF5 RID: 23541
		[DllImport("libc")]
		public static extern int ioctl(int d, JoystickIoctlCode request, StringBuilder data);

		// Token: 0x06005BF6 RID: 23542
		[DllImport("libc")]
		public static extern int ioctl(int d, EvdevIoctlCode request, out EvdevInputId data);

		// Token: 0x06005BF7 RID: 23543
		[DllImport("libc")]
		public static extern int ioctl(int d, KeyboardIoctlCode request, ref IntPtr data);

		// Token: 0x06005BF8 RID: 23544
		[DllImport("libc")]
		public static extern int ioctl(int d, KeyboardIoctlCode request, int data);

		// Token: 0x06005BF9 RID: 23545
		[DllImport("libc")]
		public static extern int open([MarshalAs(UnmanagedType.LPStr)] string pathname, OpenFlags flags);

		// Token: 0x06005BFA RID: 23546
		[DllImport("libc")]
		public static extern int open(IntPtr pathname, OpenFlags flags);

		// Token: 0x06005BFB RID: 23547
		[DllImport("libc")]
		public static extern int close(int fd);

		// Token: 0x06005BFC RID: 23548
		[DllImport("libc")]
		public unsafe static extern IntPtr read(int fd, void* buffer, UIntPtr count);

		// Token: 0x06005BFD RID: 23549 RVA: 0x000F99B8 File Offset: 0x000F7BB8
		public unsafe static int read(int fd, out byte b)
		{
			fixed (byte* ptr = &b)
			{
				return Libc.read(fd, (void*)ptr, (UIntPtr)1U).ToInt32();
			}
		}

		// Token: 0x06005BFE RID: 23550 RVA: 0x000F99E4 File Offset: 0x000F7BE4
		public unsafe static int read(int fd, out short s)
		{
			fixed (short* ptr = &s)
			{
				return Libc.read(fd, (void*)ptr, (UIntPtr)2U).ToInt32();
			}
		}

		// Token: 0x06005BFF RID: 23551
		[DllImport("libc")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool isatty(int fd);

		// Token: 0x06005C00 RID: 23552
		[DllImport("libc", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
		public static extern int poll(ref PollFD fd, IntPtr fd_count, int timeout);

		// Token: 0x06005C01 RID: 23553 RVA: 0x000F9A10 File Offset: 0x000F7C10
		public static int poll(ref PollFD fd, int fd_count, int timeout)
		{
			return Libc.poll(ref fd, (IntPtr)fd_count, timeout);
		}

		// Token: 0x0400B89A RID: 47258
		private const string lib = "libc";
	}
}
