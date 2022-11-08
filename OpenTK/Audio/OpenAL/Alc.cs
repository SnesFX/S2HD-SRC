using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;

namespace OpenTK.Audio.OpenAL
{
	// Token: 0x0200054D RID: 1357
	public static class Alc
	{
		// Token: 0x06004436 RID: 17462
		[SuppressUnmanagedCodeSecurity]
		[DllImport("openal32.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "alcCreateContext", ExactSpelling = true)]
		private unsafe static extern IntPtr sys_CreateContext([In] IntPtr device, [In] int* attrlist);

		// Token: 0x06004437 RID: 17463 RVA: 0x000B9788 File Offset: 0x000B7988
		[CLSCompliant(false)]
		public unsafe static ContextHandle CreateContext([In] IntPtr device, [In] int* attrlist)
		{
			return new ContextHandle(Alc.sys_CreateContext(device, attrlist));
		}

		// Token: 0x06004438 RID: 17464 RVA: 0x000B9798 File Offset: 0x000B7998
		public unsafe static ContextHandle CreateContext(IntPtr device, int[] attriblist)
		{
			fixed (int* ptr = attriblist)
			{
				return Alc.CreateContext(device, ptr);
			}
		}

		// Token: 0x06004439 RID: 17465
		[SuppressUnmanagedCodeSecurity]
		[DllImport("openal32.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "alcMakeContextCurrent", ExactSpelling = true)]
		private static extern bool MakeContextCurrent(IntPtr context);

		// Token: 0x0600443A RID: 17466 RVA: 0x000B97C8 File Offset: 0x000B79C8
		public static bool MakeContextCurrent(ContextHandle context)
		{
			return Alc.MakeContextCurrent(context.Handle);
		}

		// Token: 0x0600443B RID: 17467
		[SuppressUnmanagedCodeSecurity]
		[DllImport("openal32.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "alcProcessContext", ExactSpelling = true)]
		private static extern void ProcessContext(IntPtr context);

		// Token: 0x0600443C RID: 17468 RVA: 0x000B97D8 File Offset: 0x000B79D8
		public static void ProcessContext(ContextHandle context)
		{
			Alc.ProcessContext(context.Handle);
		}

		// Token: 0x0600443D RID: 17469
		[SuppressUnmanagedCodeSecurity]
		[DllImport("openal32.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "alcSuspendContext", ExactSpelling = true)]
		private static extern void SuspendContext(IntPtr context);

		// Token: 0x0600443E RID: 17470 RVA: 0x000B97E8 File Offset: 0x000B79E8
		public static void SuspendContext(ContextHandle context)
		{
			Alc.SuspendContext(context.Handle);
		}

		// Token: 0x0600443F RID: 17471
		[SuppressUnmanagedCodeSecurity]
		[DllImport("openal32.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "alcDestroyContext", ExactSpelling = true)]
		private static extern void DestroyContext(IntPtr context);

		// Token: 0x06004440 RID: 17472 RVA: 0x000B97F8 File Offset: 0x000B79F8
		public static void DestroyContext(ContextHandle context)
		{
			Alc.DestroyContext(context.Handle);
		}

		// Token: 0x06004441 RID: 17473
		[SuppressUnmanagedCodeSecurity]
		[DllImport("openal32.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "alcGetCurrentContext", ExactSpelling = true)]
		private static extern IntPtr sys_GetCurrentContext();

		// Token: 0x06004442 RID: 17474 RVA: 0x000B9808 File Offset: 0x000B7A08
		public static ContextHandle GetCurrentContext()
		{
			return new ContextHandle(Alc.sys_GetCurrentContext());
		}

		// Token: 0x06004443 RID: 17475
		[SuppressUnmanagedCodeSecurity]
		[DllImport("openal32.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "alcGetContextsDevice", ExactSpelling = true)]
		private static extern IntPtr GetContextsDevice(IntPtr context);

		// Token: 0x06004444 RID: 17476 RVA: 0x000B9814 File Offset: 0x000B7A14
		public static IntPtr GetContextsDevice(ContextHandle context)
		{
			return Alc.GetContextsDevice(context.Handle);
		}

		// Token: 0x06004445 RID: 17477
		[SuppressUnmanagedCodeSecurity]
		[DllImport("openal32.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "alcOpenDevice", ExactSpelling = true)]
		public static extern IntPtr OpenDevice([In] string devicename);

		// Token: 0x06004446 RID: 17478
		[SuppressUnmanagedCodeSecurity]
		[DllImport("openal32.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "alcCloseDevice", ExactSpelling = true)]
		public static extern bool CloseDevice([In] IntPtr device);

		// Token: 0x06004447 RID: 17479
		[SuppressUnmanagedCodeSecurity]
		[DllImport("openal32.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "alcGetError", ExactSpelling = true)]
		public static extern AlcError GetError([In] IntPtr device);

		// Token: 0x06004448 RID: 17480
		[SuppressUnmanagedCodeSecurity]
		[DllImport("openal32.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "alcIsExtensionPresent", ExactSpelling = true)]
		public static extern bool IsExtensionPresent([In] IntPtr device, [In] string extname);

		// Token: 0x06004449 RID: 17481
		[SuppressUnmanagedCodeSecurity]
		[DllImport("openal32.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "alcGetProcAddress", ExactSpelling = true)]
		public static extern IntPtr GetProcAddress([In] IntPtr device, [In] string funcname);

		// Token: 0x0600444A RID: 17482
		[SuppressUnmanagedCodeSecurity]
		[DllImport("openal32.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "alcGetEnumValue", ExactSpelling = true)]
		public static extern int GetEnumValue([In] IntPtr device, [In] string enumname);

		// Token: 0x0600444B RID: 17483
		[SuppressUnmanagedCodeSecurity]
		[DllImport("openal32.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "alcGetString", ExactSpelling = true)]
		private static extern IntPtr GetStringPrivate([In] IntPtr device, AlcGetString param);

		// Token: 0x0600444C RID: 17484 RVA: 0x000B9824 File Offset: 0x000B7A24
		public static string GetString(IntPtr device, AlcGetString param)
		{
			IntPtr stringPrivate = Alc.GetStringPrivate(device, param);
			string result = string.Empty;
			if (stringPrivate != IntPtr.Zero)
			{
				result = Marshal.PtrToStringAnsi(stringPrivate);
			}
			return result;
		}

		// Token: 0x0600444D RID: 17485 RVA: 0x000B9854 File Offset: 0x000B7A54
		public static IList<string> GetString(IntPtr device, AlcGetStringList param)
		{
			List<string> list = new List<string>();
			IntPtr stringPrivate = Alc.GetStringPrivate(device, (AlcGetString)param);
			if (stringPrivate != IntPtr.Zero)
			{
				StringBuilder stringBuilder = new StringBuilder();
				int ofs = 0;
				for (;;)
				{
					byte b = Marshal.ReadByte(stringPrivate, ofs++);
					if (b != 0)
					{
						stringBuilder.Append((char)b);
					}
					else
					{
						list.Add(stringBuilder.ToString());
						if (Marshal.ReadByte(stringPrivate, ofs) == 0)
						{
							break;
						}
						stringBuilder.Remove(0, stringBuilder.Length);
					}
				}
			}
			return list;
		}

		// Token: 0x0600444E RID: 17486
		[SuppressUnmanagedCodeSecurity]
		[DllImport("openal32.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "alcGetIntegerv", ExactSpelling = true)]
		private unsafe static extern void GetInteger(IntPtr device, AlcGetInteger param, int size, int* data);

		// Token: 0x0600444F RID: 17487 RVA: 0x000B98C8 File Offset: 0x000B7AC8
		public unsafe static void GetInteger(IntPtr device, AlcGetInteger param, int size, out int data)
		{
			fixed (int* ptr = &data)
			{
				Alc.GetInteger(device, param, size, ptr);
			}
		}

		// Token: 0x06004450 RID: 17488 RVA: 0x000B98E4 File Offset: 0x000B7AE4
		public unsafe static void GetInteger(IntPtr device, AlcGetInteger param, int size, int[] data)
		{
			fixed (int* ptr = data)
			{
				Alc.GetInteger(device, param, size, ptr);
			}
		}

		// Token: 0x06004451 RID: 17489
		[CLSCompliant(false)]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("openal32.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "alcCaptureOpenDevice", ExactSpelling = true)]
		public static extern IntPtr CaptureOpenDevice(string devicename, uint frequency, ALFormat format, int buffersize);

		// Token: 0x06004452 RID: 17490
		[SuppressUnmanagedCodeSecurity]
		[DllImport("openal32.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "alcCaptureOpenDevice", ExactSpelling = true)]
		public static extern IntPtr CaptureOpenDevice(string devicename, int frequency, ALFormat format, int buffersize);

		// Token: 0x06004453 RID: 17491
		[SuppressUnmanagedCodeSecurity]
		[DllImport("openal32.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "alcCaptureCloseDevice", ExactSpelling = true)]
		public static extern bool CaptureCloseDevice([In] IntPtr device);

		// Token: 0x06004454 RID: 17492
		[SuppressUnmanagedCodeSecurity]
		[DllImport("openal32.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "alcCaptureStart", ExactSpelling = true)]
		public static extern void CaptureStart([In] IntPtr device);

		// Token: 0x06004455 RID: 17493
		[SuppressUnmanagedCodeSecurity]
		[DllImport("openal32.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "alcCaptureStop", ExactSpelling = true)]
		public static extern void CaptureStop([In] IntPtr device);

		// Token: 0x06004456 RID: 17494
		[SuppressUnmanagedCodeSecurity]
		[DllImport("openal32.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "alcCaptureSamples", ExactSpelling = true)]
		public static extern void CaptureSamples(IntPtr device, IntPtr buffer, int samples);

		// Token: 0x06004457 RID: 17495 RVA: 0x000B9918 File Offset: 0x000B7B18
		public static void CaptureSamples<T>(IntPtr device, ref T buffer, int samples) where T : struct
		{
			GCHandle gchandle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
			try
			{
				Alc.CaptureSamples(device, gchandle.AddrOfPinnedObject(), samples);
			}
			finally
			{
				gchandle.Free();
			}
		}

		// Token: 0x06004458 RID: 17496 RVA: 0x000B9960 File Offset: 0x000B7B60
		[CLSCompliant(false)]
		public static void CaptureSamples<T>(IntPtr device, T[] buffer, int samples) where T : struct
		{
			Alc.CaptureSamples<T>(device, ref buffer[0], samples);
		}

		// Token: 0x06004459 RID: 17497 RVA: 0x000B9970 File Offset: 0x000B7B70
		[CLSCompliant(false)]
		public static void CaptureSamples<T>(IntPtr device, T[,] buffer, int samples) where T : struct
		{
			Alc.CaptureSamples<T>(device, ref buffer[0, 0], samples);
		}

		// Token: 0x0600445A RID: 17498 RVA: 0x000B9984 File Offset: 0x000B7B84
		[CLSCompliant(false)]
		public static void CaptureSamples<T>(IntPtr device, T[,,] buffer, int samples) where T : struct
		{
			Alc.CaptureSamples<T>(device, ref buffer[0, 0, 0], samples);
		}

		// Token: 0x04004EAE RID: 20142
		private const string Lib = "openal32.dll";

		// Token: 0x04004EAF RID: 20143
		private const CallingConvention Style = CallingConvention.Cdecl;
	}
}
