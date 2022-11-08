using System;
using System.Runtime.InteropServices;

namespace OpenTK.Platform.Linux
{
	// Token: 0x02000B9C RID: 2972
	internal class Terminal
	{
		// Token: 0x06005C8F RID: 23695
		[DllImport("libc", CallingConvention = CallingConvention.Cdecl, EntryPoint = "isatty")]
		[return: MarshalAs(UnmanagedType.I4)]
		public static extern bool IsTerminal(int fd);

		// Token: 0x06005C90 RID: 23696
		[DllImport("libc", CallingConvention = CallingConvention.Cdecl, EntryPoint = "tcgetattr")]
		public static extern int GetAttributes(int fd, out TerminalState state);

		// Token: 0x06005C91 RID: 23697
		[DllImport("libc", CallingConvention = CallingConvention.Cdecl, EntryPoint = "tcsetattr")]
		public static extern int SetAttributes(int fd, OptionalActions actions, ref TerminalState state);

		// Token: 0x0400B918 RID: 47384
		private const string lib = "libc";
	}
}
