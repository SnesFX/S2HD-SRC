using System;
using System.Runtime.InteropServices;

namespace Accord
{
	// Token: 0x02000014 RID: 20
	public static class SystemTools
	{
		// Token: 0x060000BF RID: 191 RVA: 0x000033C1 File Offset: 0x000023C1
		public static bool IsRunningOnMono()
		{
			return Type.GetType("Mono.Runtime") != null;
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x000033D3 File Offset: 0x000023D3
		public unsafe static IntPtr CopyUnmanagedMemory(IntPtr dst, IntPtr src, int count)
		{
			SystemTools.CopyUnmanagedMemory((byte*)dst.ToPointer(), (byte*)src.ToPointer(), count);
			return dst;
		}

		// Token: 0x060000C1 RID: 193 RVA: 0x000033EB File Offset: 0x000023EB
		public unsafe static byte* CopyUnmanagedMemory(byte* dst, byte* src, int count)
		{
			return SystemTools.memcpy(dst, src, count);
		}

		// Token: 0x060000C2 RID: 194 RVA: 0x000033F5 File Offset: 0x000023F5
		public unsafe static IntPtr SetUnmanagedMemory(IntPtr dst, int filler, int count)
		{
			SystemTools.SetUnmanagedMemory((byte*)dst.ToPointer(), filler, count);
			return dst;
		}

		// Token: 0x060000C3 RID: 195 RVA: 0x00003407 File Offset: 0x00002407
		public unsafe static byte* SetUnmanagedMemory(byte* dst, int filler, int count)
		{
			return SystemTools.memset(dst, filler, count);
		}

		// Token: 0x060000C4 RID: 196
		[DllImport("ntdll.dll", CallingConvention = CallingConvention.Cdecl)]
		private unsafe static extern byte* memcpy(byte* dst, byte* src, int count);

		// Token: 0x060000C5 RID: 197
		[DllImport("ntdll.dll", CallingConvention = CallingConvention.Cdecl)]
		private unsafe static extern byte* memset(byte* dst, int filler, int count);
	}
}
