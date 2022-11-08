using System;
using System.Runtime.InteropServices;
using System.Security;

namespace OpenTK.Audio.OpenAL
{
	// Token: 0x02000577 RID: 1399
	public static class AL
	{
		// Token: 0x06004517 RID: 17687
		[SuppressUnmanagedCodeSecurity]
		[DllImport("openal32.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "alEnable", ExactSpelling = true)]
		public static extern void Enable(ALCapability capability);

		// Token: 0x06004518 RID: 17688
		[SuppressUnmanagedCodeSecurity]
		[DllImport("openal32.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "alDisable", ExactSpelling = true)]
		public static extern void Disable(ALCapability capability);

		// Token: 0x06004519 RID: 17689
		[SuppressUnmanagedCodeSecurity]
		[DllImport("openal32.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "alIsEnabled", ExactSpelling = true)]
		public static extern bool IsEnabled(ALCapability capability);

		// Token: 0x0600451A RID: 17690
		[SuppressUnmanagedCodeSecurity]
		[DllImport("openal32.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "alGetString", ExactSpelling = true)]
		private static extern IntPtr GetStringPrivate(ALGetString param);

		// Token: 0x0600451B RID: 17691 RVA: 0x000BE73C File Offset: 0x000BC93C
		public static string Get(ALGetString param)
		{
			return Marshal.PtrToStringAnsi(AL.GetStringPrivate(param));
		}

		// Token: 0x0600451C RID: 17692 RVA: 0x000BE74C File Offset: 0x000BC94C
		public static string GetErrorString(ALError param)
		{
			return Marshal.PtrToStringAnsi(AL.GetStringPrivate((ALGetString)param));
		}

		// Token: 0x0600451D RID: 17693
		[SuppressUnmanagedCodeSecurity]
		[DllImport("openal32.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "alGetInteger", ExactSpelling = true)]
		public static extern int Get(ALGetInteger param);

		// Token: 0x0600451E RID: 17694
		[SuppressUnmanagedCodeSecurity]
		[DllImport("openal32.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "alGetFloat", ExactSpelling = true)]
		public static extern float Get(ALGetFloat param);

		// Token: 0x0600451F RID: 17695
		[SuppressUnmanagedCodeSecurity]
		[DllImport("openal32.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "alGetError", ExactSpelling = true)]
		public static extern ALError GetError();

		// Token: 0x06004520 RID: 17696
		[SuppressUnmanagedCodeSecurity]
		[DllImport("openal32.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "alIsExtensionPresent", ExactSpelling = true)]
		public static extern bool IsExtensionPresent([In] string extname);

		// Token: 0x06004521 RID: 17697
		[SuppressUnmanagedCodeSecurity]
		[DllImport("openal32.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "alGetProcAddress", ExactSpelling = true)]
		public static extern IntPtr GetProcAddress([In] string fname);

		// Token: 0x06004522 RID: 17698
		[SuppressUnmanagedCodeSecurity]
		[DllImport("openal32.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "alGetEnumValue", ExactSpelling = true)]
		public static extern int GetEnumValue([In] string ename);

		// Token: 0x06004523 RID: 17699
		[SuppressUnmanagedCodeSecurity]
		[DllImport("openal32.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "alListenerf", ExactSpelling = true)]
		public static extern void Listener(ALListenerf param, float value);

		// Token: 0x06004524 RID: 17700
		[SuppressUnmanagedCodeSecurity]
		[DllImport("openal32.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "alListener3f", ExactSpelling = true)]
		public static extern void Listener(ALListener3f param, float value1, float value2, float value3);

		// Token: 0x06004525 RID: 17701 RVA: 0x000BE75C File Offset: 0x000BC95C
		public static void Listener(ALListener3f param, ref Vector3 values)
		{
			AL.Listener(param, values.X, values.Y, values.Z);
		}

		// Token: 0x06004526 RID: 17702
		[SuppressUnmanagedCodeSecurity]
		[DllImport("openal32.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "alListenerfv", ExactSpelling = true)]
		private unsafe static extern void ListenerPrivate(ALListenerfv param, float* values);

		// Token: 0x06004527 RID: 17703 RVA: 0x000BE778 File Offset: 0x000BC978
		public unsafe static void Listener(ALListenerfv param, ref float[] values)
		{
			fixed (float* ptr = &values[0])
			{
				AL.ListenerPrivate(param, ptr);
			}
		}

		// Token: 0x06004528 RID: 17704 RVA: 0x000BE79C File Offset: 0x000BC99C
		public unsafe static void Listener(ALListenerfv param, ref Vector3 at, ref Vector3 up)
		{
			fixed (float* ptr = ref (new float[]
			{
				at.X,
				at.Y,
				at.Z,
				up.X,
				up.Y,
				up.Z
			})[0])
			{
				AL.ListenerPrivate(param, ptr);
			}
		}

		// Token: 0x06004529 RID: 17705
		[SuppressUnmanagedCodeSecurity]
		[DllImport("openal32.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "alGetListenerf", ExactSpelling = true)]
		public static extern void GetListener(ALListenerf param, out float value);

		// Token: 0x0600452A RID: 17706
		[SuppressUnmanagedCodeSecurity]
		[DllImport("openal32.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "alGetListener3f", ExactSpelling = true)]
		public static extern void GetListener(ALListener3f param, out float value1, out float value2, out float value3);

		// Token: 0x0600452B RID: 17707 RVA: 0x000BE7FC File Offset: 0x000BC9FC
		public static void GetListener(ALListener3f param, out Vector3 values)
		{
			AL.GetListener(param, out values.X, out values.Y, out values.Z);
		}

		// Token: 0x0600452C RID: 17708
		[CLSCompliant(false)]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("openal32.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "alGetListenerfv", ExactSpelling = true)]
		public unsafe static extern void GetListener(ALListenerfv param, float* values);

		// Token: 0x0600452D RID: 17709 RVA: 0x000BE818 File Offset: 0x000BCA18
		public unsafe static void GetListener(ALListenerfv param, out Vector3 at, out Vector3 up)
		{
			float[] array = new float[6];
			fixed (float* ptr = &array[0])
			{
				AL.GetListener(param, ptr);
				at.X = array[0];
				at.Y = array[1];
				at.Z = array[2];
				up.X = array[3];
				up.Y = array[4];
				up.Z = array[5];
			}
		}

		// Token: 0x0600452E RID: 17710
		[SuppressUnmanagedCodeSecurity]
		[DllImport("openal32.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "alGenSources", ExactSpelling = true)]
		private unsafe static extern void GenSourcesPrivate(int n, [Out] uint* sources);

		// Token: 0x0600452F RID: 17711 RVA: 0x000BE878 File Offset: 0x000BCA78
		[CLSCompliant(false)]
		public unsafe static void GenSources(int n, out uint sources)
		{
			fixed (uint* ptr = &sources)
			{
				AL.GenSourcesPrivate(n, ptr);
			}
		}

		// Token: 0x06004530 RID: 17712 RVA: 0x000BE894 File Offset: 0x000BCA94
		public unsafe static void GenSources(int n, out int sources)
		{
			fixed (int* ptr = &sources)
			{
				AL.GenSourcesPrivate(n, (uint*)ptr);
			}
		}

		// Token: 0x06004531 RID: 17713 RVA: 0x000BE8B0 File Offset: 0x000BCAB0
		public static void GenSources(int[] sources)
		{
			uint[] array = new uint[sources.Length];
			AL.GenSources(array.Length, out array[0]);
			for (int i = 0; i < array.Length; i++)
			{
				sources[i] = (int)array[i];
			}
		}

		// Token: 0x06004532 RID: 17714 RVA: 0x000BE8EC File Offset: 0x000BCAEC
		public static int[] GenSources(int n)
		{
			uint[] array = new uint[n];
			AL.GenSources(array.Length, out array[0]);
			int[] array2 = new int[n];
			for (int i = 0; i < array.Length; i++)
			{
				array2[i] = (int)array[i];
			}
			return array2;
		}

		// Token: 0x06004533 RID: 17715 RVA: 0x000BE92C File Offset: 0x000BCB2C
		public static int GenSource()
		{
			int result;
			AL.GenSources(1, out result);
			return result;
		}

		// Token: 0x06004534 RID: 17716 RVA: 0x000BE944 File Offset: 0x000BCB44
		[CLSCompliant(false)]
		public static void GenSource(out uint source)
		{
			AL.GenSources(1, out source);
		}

		// Token: 0x06004535 RID: 17717
		[SuppressUnmanagedCodeSecurity]
		[CLSCompliant(false)]
		[DllImport("openal32.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "alDeleteSources", ExactSpelling = true)]
		public unsafe static extern void DeleteSources(int n, [In] uint* sources);

		// Token: 0x06004536 RID: 17718
		[CLSCompliant(false)]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("openal32.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "alDeleteSources", ExactSpelling = true)]
		public static extern void DeleteSources(int n, ref uint sources);

		// Token: 0x06004537 RID: 17719
		[SuppressUnmanagedCodeSecurity]
		[DllImport("openal32.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "alDeleteSources", ExactSpelling = true)]
		public static extern void DeleteSources(int n, ref int sources);

		// Token: 0x06004538 RID: 17720 RVA: 0x000BE950 File Offset: 0x000BCB50
		[CLSCompliant(false)]
		public static void DeleteSources(uint[] sources)
		{
			if (sources == null)
			{
				throw new ArgumentNullException();
			}
			if (sources.Length == 0)
			{
				throw new ArgumentOutOfRangeException();
			}
			AL.DeleteBuffers(sources.Length, ref sources[0]);
		}

		// Token: 0x06004539 RID: 17721 RVA: 0x000BE978 File Offset: 0x000BCB78
		public static void DeleteSources(int[] sources)
		{
			if (sources == null)
			{
				throw new ArgumentNullException();
			}
			if (sources.Length == 0)
			{
				throw new ArgumentOutOfRangeException();
			}
			AL.DeleteBuffers(sources.Length, ref sources[0]);
		}

		// Token: 0x0600453A RID: 17722 RVA: 0x000BE9A0 File Offset: 0x000BCBA0
		[CLSCompliant(false)]
		public static void DeleteSource(ref uint source)
		{
			AL.DeleteSources(1, ref source);
		}

		// Token: 0x0600453B RID: 17723 RVA: 0x000BE9AC File Offset: 0x000BCBAC
		public static void DeleteSource(int source)
		{
			AL.DeleteSources(1, ref source);
		}

		// Token: 0x0600453C RID: 17724
		[SuppressUnmanagedCodeSecurity]
		[CLSCompliant(false)]
		[DllImport("openal32.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "alIsSource", ExactSpelling = true)]
		public static extern bool IsSource(uint sid);

		// Token: 0x0600453D RID: 17725 RVA: 0x000BE9B8 File Offset: 0x000BCBB8
		public static bool IsSource(int sid)
		{
			return AL.IsSource((uint)sid);
		}

		// Token: 0x0600453E RID: 17726
		[SuppressUnmanagedCodeSecurity]
		[CLSCompliant(false)]
		[DllImport("openal32.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "alSourcef", ExactSpelling = true)]
		public static extern void Source(uint sid, ALSourcef param, float value);

		// Token: 0x0600453F RID: 17727 RVA: 0x000BE9C0 File Offset: 0x000BCBC0
		public static void Source(int sid, ALSourcef param, float value)
		{
			AL.Source((uint)sid, param, value);
		}

		// Token: 0x06004540 RID: 17728
		[SuppressUnmanagedCodeSecurity]
		[CLSCompliant(false)]
		[DllImport("openal32.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "alSource3f", ExactSpelling = true)]
		public static extern void Source(uint sid, ALSource3f param, float value1, float value2, float value3);

		// Token: 0x06004541 RID: 17729 RVA: 0x000BE9CC File Offset: 0x000BCBCC
		public static void Source(int sid, ALSource3f param, float value1, float value2, float value3)
		{
			AL.Source((uint)sid, param, value1, value2, value3);
		}

		// Token: 0x06004542 RID: 17730 RVA: 0x000BE9DC File Offset: 0x000BCBDC
		[CLSCompliant(false)]
		public static void Source(uint sid, ALSource3f param, ref Vector3 values)
		{
			AL.Source(sid, param, values.X, values.Y, values.Z);
		}

		// Token: 0x06004543 RID: 17731 RVA: 0x000BE9F8 File Offset: 0x000BCBF8
		public static void Source(int sid, ALSource3f param, ref Vector3 values)
		{
			AL.Source((uint)sid, param, values.X, values.Y, values.Z);
		}

		// Token: 0x06004544 RID: 17732
		[SuppressUnmanagedCodeSecurity]
		[CLSCompliant(false)]
		[DllImport("openal32.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "alSourcei", ExactSpelling = true)]
		public static extern void Source(uint sid, ALSourcei param, int value);

		// Token: 0x06004545 RID: 17733 RVA: 0x000BEA14 File Offset: 0x000BCC14
		public static void Source(int sid, ALSourcei param, int value)
		{
			AL.Source((uint)sid, param, value);
		}

		// Token: 0x06004546 RID: 17734 RVA: 0x000BEA20 File Offset: 0x000BCC20
		[CLSCompliant(false)]
		public static void Source(uint sid, ALSourceb param, bool value)
		{
			AL.Source(sid, (ALSourcei)param, value ? 1 : 0);
		}

		// Token: 0x06004547 RID: 17735 RVA: 0x000BEA30 File Offset: 0x000BCC30
		public static void Source(int sid, ALSourceb param, bool value)
		{
			AL.Source((uint)sid, (ALSourcei)param, value ? 1 : 0);
		}

		// Token: 0x06004548 RID: 17736 RVA: 0x000BEA40 File Offset: 0x000BCC40
		[CLSCompliant(false)]
		public static void BindBufferToSource(uint source, uint buffer)
		{
			AL.Source(source, ALSourcei.Buffer, (int)buffer);
		}

		// Token: 0x06004549 RID: 17737 RVA: 0x000BEA50 File Offset: 0x000BCC50
		public static void BindBufferToSource(int source, int buffer)
		{
			AL.Source((uint)source, ALSourcei.Buffer, buffer);
		}

		// Token: 0x0600454A RID: 17738
		[SuppressUnmanagedCodeSecurity]
		[CLSCompliant(false)]
		[DllImport("openal32.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "alSource3i", ExactSpelling = true)]
		public static extern void Source(uint sid, ALSource3i param, int value1, int value2, int value3);

		// Token: 0x0600454B RID: 17739 RVA: 0x000BEA60 File Offset: 0x000BCC60
		public static void Source(int sid, ALSource3i param, int value1, int value2, int value3)
		{
			AL.Source((uint)sid, param, value1, value2, value3);
		}

		// Token: 0x0600454C RID: 17740
		[SuppressUnmanagedCodeSecurity]
		[CLSCompliant(false)]
		[DllImport("openal32.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "alGetSourcef", ExactSpelling = true)]
		public static extern void GetSource(uint sid, ALSourcef param, out float value);

		// Token: 0x0600454D RID: 17741 RVA: 0x000BEA70 File Offset: 0x000BCC70
		public static void GetSource(int sid, ALSourcef param, out float value)
		{
			AL.GetSource((uint)sid, param, out value);
		}

		// Token: 0x0600454E RID: 17742
		[SuppressUnmanagedCodeSecurity]
		[CLSCompliant(false)]
		[DllImport("openal32.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "alGetSource3f", ExactSpelling = true)]
		public static extern void GetSource(uint sid, ALSource3f param, out float value1, out float value2, out float value3);

		// Token: 0x0600454F RID: 17743 RVA: 0x000BEA7C File Offset: 0x000BCC7C
		public static void GetSource(int sid, ALSource3f param, out float value1, out float value2, out float value3)
		{
			AL.GetSource((uint)sid, param, out value1, out value2, out value3);
		}

		// Token: 0x06004550 RID: 17744 RVA: 0x000BEA8C File Offset: 0x000BCC8C
		[CLSCompliant(false)]
		public static void GetSource(uint sid, ALSource3f param, out Vector3 values)
		{
			AL.GetSource(sid, param, out values.X, out values.Y, out values.Z);
		}

		// Token: 0x06004551 RID: 17745 RVA: 0x000BEAA8 File Offset: 0x000BCCA8
		public static void GetSource(int sid, ALSource3f param, out Vector3 values)
		{
			AL.GetSource((uint)sid, param, out values.X, out values.Y, out values.Z);
		}

		// Token: 0x06004552 RID: 17746
		[SuppressUnmanagedCodeSecurity]
		[CLSCompliant(false)]
		[DllImport("openal32.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "alGetSourcei", ExactSpelling = true)]
		public static extern void GetSource(uint sid, ALGetSourcei param, out int value);

		// Token: 0x06004553 RID: 17747 RVA: 0x000BEAC4 File Offset: 0x000BCCC4
		public static void GetSource(int sid, ALGetSourcei param, out int value)
		{
			AL.GetSource((uint)sid, param, out value);
		}

		// Token: 0x06004554 RID: 17748 RVA: 0x000BEAD0 File Offset: 0x000BCCD0
		[CLSCompliant(false)]
		public static void GetSource(uint sid, ALSourceb param, out bool value)
		{
			int num;
			AL.GetSource(sid, (ALGetSourcei)param, out num);
			value = (num != 0);
		}

		// Token: 0x06004555 RID: 17749 RVA: 0x000BEAF0 File Offset: 0x000BCCF0
		public static void GetSource(int sid, ALSourceb param, out bool value)
		{
			int num;
			AL.GetSource((uint)sid, (ALGetSourcei)param, out num);
			value = (num != 0);
		}

		// Token: 0x06004556 RID: 17750
		[CLSCompliant(false)]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("openal32.dll", EntryPoint = "alSourcePlayv")]
		public unsafe static extern void SourcePlay(int ns, [In] uint* sids);

		// Token: 0x06004557 RID: 17751 RVA: 0x000BEB10 File Offset: 0x000BCD10
		[CLSCompliant(false)]
		public unsafe static void SourcePlay(int ns, uint[] sids)
		{
			fixed (uint* ptr = sids)
			{
				AL.SourcePlay(ns, ptr);
			}
		}

		// Token: 0x06004558 RID: 17752 RVA: 0x000BEB40 File Offset: 0x000BCD40
		public static void SourcePlay(int ns, int[] sids)
		{
			uint[] array = new uint[ns];
			for (int i = 0; i < ns; i++)
			{
				array[i] = (uint)sids[i];
			}
			AL.SourcePlay(ns, array);
		}

		// Token: 0x06004559 RID: 17753 RVA: 0x000BEB70 File Offset: 0x000BCD70
		[CLSCompliant(false)]
		public unsafe static void SourcePlay(int ns, ref uint sids)
		{
			fixed (uint* ptr = &sids)
			{
				AL.SourcePlay(ns, ptr);
			}
		}

		// Token: 0x0600455A RID: 17754
		[SuppressUnmanagedCodeSecurity]
		[CLSCompliant(false)]
		[DllImport("openal32.dll", EntryPoint = "alSourceStopv")]
		public unsafe static extern void SourceStop(int ns, [In] uint* sids);

		// Token: 0x0600455B RID: 17755 RVA: 0x000BEB8C File Offset: 0x000BCD8C
		[CLSCompliant(false)]
		public unsafe static void SourceStop(int ns, uint[] sids)
		{
			fixed (uint* ptr = sids)
			{
				AL.SourceStop(ns, ptr);
			}
		}

		// Token: 0x0600455C RID: 17756 RVA: 0x000BEBBC File Offset: 0x000BCDBC
		public static void SourceStop(int ns, int[] sids)
		{
			uint[] array = new uint[ns];
			for (int i = 0; i < ns; i++)
			{
				array[i] = (uint)sids[i];
			}
			AL.SourceStop(ns, array);
		}

		// Token: 0x0600455D RID: 17757 RVA: 0x000BEBEC File Offset: 0x000BCDEC
		[CLSCompliant(false)]
		public unsafe static void SourceStop(int ns, ref uint sids)
		{
			fixed (uint* ptr = &sids)
			{
				AL.SourceStop(ns, ptr);
			}
		}

		// Token: 0x0600455E RID: 17758
		[CLSCompliant(false)]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("openal32.dll", EntryPoint = "alSourceRewindv")]
		public unsafe static extern void SourceRewind(int ns, [In] uint* sids);

		// Token: 0x0600455F RID: 17759 RVA: 0x000BEC08 File Offset: 0x000BCE08
		[CLSCompliant(false)]
		public unsafe static void SourceRewind(int ns, uint[] sids)
		{
			fixed (uint* ptr = sids)
			{
				AL.SourceRewind(ns, ptr);
			}
		}

		// Token: 0x06004560 RID: 17760 RVA: 0x000BEC38 File Offset: 0x000BCE38
		public static void SourceRewind(int ns, int[] sids)
		{
			uint[] array = new uint[ns];
			for (int i = 0; i < ns; i++)
			{
				array[i] = (uint)sids[i];
			}
			AL.SourceRewind(ns, array);
		}

		// Token: 0x06004561 RID: 17761 RVA: 0x000BEC68 File Offset: 0x000BCE68
		[CLSCompliant(false)]
		public unsafe static void SourceRewind(int ns, ref uint sids)
		{
			fixed (uint* ptr = &sids)
			{
				AL.SourceRewind(ns, ptr);
			}
		}

		// Token: 0x06004562 RID: 17762
		[CLSCompliant(false)]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("openal32.dll", EntryPoint = "alSourcePausev")]
		public unsafe static extern void SourcePause(int ns, [In] uint* sids);

		// Token: 0x06004563 RID: 17763 RVA: 0x000BEC84 File Offset: 0x000BCE84
		[CLSCompliant(false)]
		public unsafe static void SourcePause(int ns, uint[] sids)
		{
			fixed (uint* ptr = sids)
			{
				AL.SourcePause(ns, ptr);
			}
		}

		// Token: 0x06004564 RID: 17764 RVA: 0x000BECB4 File Offset: 0x000BCEB4
		public static void SourcePause(int ns, int[] sids)
		{
			uint[] array = new uint[ns];
			for (int i = 0; i < ns; i++)
			{
				array[i] = (uint)sids[i];
			}
			AL.SourcePause(ns, array);
		}

		// Token: 0x06004565 RID: 17765 RVA: 0x000BECE4 File Offset: 0x000BCEE4
		[CLSCompliant(false)]
		public unsafe static void SourcePause(int ns, ref uint sids)
		{
			fixed (uint* ptr = &sids)
			{
				AL.SourcePause(ns, ptr);
			}
		}

		// Token: 0x06004566 RID: 17766
		[CLSCompliant(false)]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("openal32.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "alSourcePlay", ExactSpelling = true)]
		public static extern void SourcePlay(uint sid);

		// Token: 0x06004567 RID: 17767 RVA: 0x000BED00 File Offset: 0x000BCF00
		public static void SourcePlay(int sid)
		{
			AL.SourcePlay((uint)sid);
		}

		// Token: 0x06004568 RID: 17768
		[SuppressUnmanagedCodeSecurity]
		[CLSCompliant(false)]
		[DllImport("openal32.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "alSourceStop", ExactSpelling = true)]
		public static extern void SourceStop(uint sid);

		// Token: 0x06004569 RID: 17769 RVA: 0x000BED08 File Offset: 0x000BCF08
		public static void SourceStop(int sid)
		{
			AL.SourceStop((uint)sid);
		}

		// Token: 0x0600456A RID: 17770
		[CLSCompliant(false)]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("openal32.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "alSourceRewind", ExactSpelling = true)]
		public static extern void SourceRewind(uint sid);

		// Token: 0x0600456B RID: 17771 RVA: 0x000BED10 File Offset: 0x000BCF10
		public static void SourceRewind(int sid)
		{
			AL.SourceRewind((uint)sid);
		}

		// Token: 0x0600456C RID: 17772
		[CLSCompliant(false)]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("openal32.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "alSourcePause", ExactSpelling = true)]
		public static extern void SourcePause(uint sid);

		// Token: 0x0600456D RID: 17773 RVA: 0x000BED18 File Offset: 0x000BCF18
		public static void SourcePause(int sid)
		{
			AL.SourcePause((uint)sid);
		}

		// Token: 0x0600456E RID: 17774
		[SuppressUnmanagedCodeSecurity]
		[CLSCompliant(false)]
		[DllImport("openal32.dll", EntryPoint = "alSourceQueueBuffers")]
		public unsafe static extern void SourceQueueBuffers(uint sid, int numEntries, [In] uint* bids);

		// Token: 0x0600456F RID: 17775 RVA: 0x000BED20 File Offset: 0x000BCF20
		[CLSCompliant(false)]
		public unsafe static void SourceQueueBuffers(uint sid, int numEntries, uint[] bids)
		{
			fixed (uint* ptr = bids)
			{
				AL.SourceQueueBuffers(sid, numEntries, ptr);
			}
		}

		// Token: 0x06004570 RID: 17776 RVA: 0x000BED50 File Offset: 0x000BCF50
		public static void SourceQueueBuffers(int sid, int numEntries, int[] bids)
		{
			uint[] array = new uint[numEntries];
			for (int i = 0; i < numEntries; i++)
			{
				array[i] = (uint)bids[i];
			}
			AL.SourceQueueBuffers((uint)sid, numEntries, array);
		}

		// Token: 0x06004571 RID: 17777 RVA: 0x000BED80 File Offset: 0x000BCF80
		[CLSCompliant(false)]
		public unsafe static void SourceQueueBuffers(uint sid, int numEntries, ref uint bids)
		{
			fixed (uint* ptr = &bids)
			{
				AL.SourceQueueBuffers(sid, numEntries, ptr);
			}
		}

		// Token: 0x06004572 RID: 17778 RVA: 0x000BED9C File Offset: 0x000BCF9C
		public unsafe static void SourceQueueBuffer(int source, int buffer)
		{
			AL.SourceQueueBuffers((uint)source, 1, (uint*)(&buffer));
		}

		// Token: 0x06004573 RID: 17779
		[SuppressUnmanagedCodeSecurity]
		[CLSCompliant(false)]
		[DllImport("openal32.dll", EntryPoint = "alSourceUnqueueBuffers")]
		public unsafe static extern void SourceUnqueueBuffers(uint sid, int numEntries, [In] uint* bids);

		// Token: 0x06004574 RID: 17780
		[CLSCompliant(false)]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("openal32.dll", EntryPoint = "alSourceUnqueueBuffers")]
		public static extern void SourceUnqueueBuffers(uint sid, int numEntries, [Out] uint[] bids);

		// Token: 0x06004575 RID: 17781
		[SuppressUnmanagedCodeSecurity]
		[DllImport("openal32.dll", EntryPoint = "alSourceUnqueueBuffers")]
		public static extern void SourceUnqueueBuffers(int sid, int numEntries, [Out] int[] bids);

		// Token: 0x06004576 RID: 17782
		[CLSCompliant(false)]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("openal32.dll", EntryPoint = "alSourceUnqueueBuffers")]
		public static extern void SourceUnqueueBuffers(uint sid, int numEntries, ref uint bids);

		// Token: 0x06004577 RID: 17783
		[SuppressUnmanagedCodeSecurity]
		[DllImport("openal32.dll", EntryPoint = "alSourceUnqueueBuffers")]
		public static extern void SourceUnqueueBuffers(int sid, int numEntries, ref int bids);

		// Token: 0x06004578 RID: 17784 RVA: 0x000BEDA8 File Offset: 0x000BCFA8
		public unsafe static int SourceUnqueueBuffer(int sid)
		{
			uint result;
			AL.SourceUnqueueBuffers((uint)sid, 1, &result);
			return (int)result;
		}

		// Token: 0x06004579 RID: 17785 RVA: 0x000BEDC0 File Offset: 0x000BCFC0
		public static int[] SourceUnqueueBuffers(int sid, int numEntries)
		{
			if (numEntries <= 0)
			{
				throw new ArgumentOutOfRangeException("numEntries", "Must be greater than zero.");
			}
			int[] array = new int[numEntries];
			AL.SourceUnqueueBuffers(sid, numEntries, array);
			return array;
		}

		// Token: 0x0600457A RID: 17786
		[SuppressUnmanagedCodeSecurity]
		[CLSCompliant(false)]
		[DllImport("openal32.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "alGenBuffers", ExactSpelling = true)]
		public unsafe static extern void GenBuffers(int n, [Out] uint* buffers);

		// Token: 0x0600457B RID: 17787
		[CLSCompliant(false)]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("openal32.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "alGenBuffers", ExactSpelling = true)]
		public unsafe static extern void GenBuffers(int n, [Out] int* buffers);

		// Token: 0x0600457C RID: 17788 RVA: 0x000BEDF4 File Offset: 0x000BCFF4
		[CLSCompliant(false)]
		public unsafe static void GenBuffers(int n, out uint buffers)
		{
			fixed (uint* ptr = &buffers)
			{
				AL.GenBuffers(n, ptr);
			}
		}

		// Token: 0x0600457D RID: 17789 RVA: 0x000BEE10 File Offset: 0x000BD010
		public unsafe static void GenBuffers(int n, out int buffers)
		{
			fixed (int* ptr = &buffers)
			{
				AL.GenBuffers(n, ptr);
			}
		}

		// Token: 0x0600457E RID: 17790 RVA: 0x000BEE2C File Offset: 0x000BD02C
		public static int[] GenBuffers(int n)
		{
			int[] array = new int[n];
			AL.GenBuffers(array.Length, out array[0]);
			return array;
		}

		// Token: 0x0600457F RID: 17791 RVA: 0x000BEE50 File Offset: 0x000BD050
		public static int GenBuffer()
		{
			int result;
			AL.GenBuffers(1, out result);
			return result;
		}

		// Token: 0x06004580 RID: 17792 RVA: 0x000BEE68 File Offset: 0x000BD068
		[CLSCompliant(false)]
		public static void GenBuffer(out uint buffer)
		{
			AL.GenBuffers(1, out buffer);
		}

		// Token: 0x06004581 RID: 17793
		[SuppressUnmanagedCodeSecurity]
		[CLSCompliant(false)]
		[DllImport("openal32.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "alDeleteBuffers", ExactSpelling = true)]
		public unsafe static extern void DeleteBuffers(int n, [In] uint* buffers);

		// Token: 0x06004582 RID: 17794
		[CLSCompliant(false)]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("openal32.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "alDeleteBuffers", ExactSpelling = true)]
		public unsafe static extern void DeleteBuffers(int n, [In] int* buffers);

		// Token: 0x06004583 RID: 17795 RVA: 0x000BEE74 File Offset: 0x000BD074
		[CLSCompliant(false)]
		public unsafe static void DeleteBuffers(int n, [In] ref uint buffers)
		{
			fixed (uint* ptr = &buffers)
			{
				AL.DeleteBuffers(n, ptr);
			}
		}

		// Token: 0x06004584 RID: 17796 RVA: 0x000BEE90 File Offset: 0x000BD090
		public unsafe static void DeleteBuffers(int n, [In] ref int buffers)
		{
			fixed (int* ptr = &buffers)
			{
				AL.DeleteBuffers(n, ptr);
			}
		}

		// Token: 0x06004585 RID: 17797 RVA: 0x000BEEAC File Offset: 0x000BD0AC
		[CLSCompliant(false)]
		public static void DeleteBuffers(uint[] buffers)
		{
			if (buffers == null)
			{
				throw new ArgumentNullException();
			}
			if (buffers.Length == 0)
			{
				throw new ArgumentOutOfRangeException();
			}
			AL.DeleteBuffers(buffers.Length, ref buffers[0]);
		}

		// Token: 0x06004586 RID: 17798 RVA: 0x000BEED4 File Offset: 0x000BD0D4
		public static void DeleteBuffers(int[] buffers)
		{
			if (buffers == null)
			{
				throw new ArgumentNullException();
			}
			if (buffers.Length == 0)
			{
				throw new ArgumentOutOfRangeException();
			}
			AL.DeleteBuffers(buffers.Length, ref buffers[0]);
		}

		// Token: 0x06004587 RID: 17799 RVA: 0x000BEEFC File Offset: 0x000BD0FC
		[CLSCompliant(false)]
		public static void DeleteBuffer(ref uint buffer)
		{
			AL.DeleteBuffers(1, ref buffer);
		}

		// Token: 0x06004588 RID: 17800 RVA: 0x000BEF08 File Offset: 0x000BD108
		public static void DeleteBuffer(int buffer)
		{
			AL.DeleteBuffers(1, ref buffer);
		}

		// Token: 0x06004589 RID: 17801
		[SuppressUnmanagedCodeSecurity]
		[CLSCompliant(false)]
		[DllImport("openal32.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "alIsBuffer", ExactSpelling = true)]
		public static extern bool IsBuffer(uint bid);

		// Token: 0x0600458A RID: 17802 RVA: 0x000BEF14 File Offset: 0x000BD114
		public static bool IsBuffer(int bid)
		{
			return AL.IsBuffer((uint)bid);
		}

		// Token: 0x0600458B RID: 17803
		[CLSCompliant(false)]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("openal32.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "alBufferData", ExactSpelling = true)]
		public static extern void BufferData(uint bid, ALFormat format, IntPtr buffer, int size, int freq);

		// Token: 0x0600458C RID: 17804 RVA: 0x000BEF2C File Offset: 0x000BD12C
		public static void BufferData(int bid, ALFormat format, IntPtr buffer, int size, int freq)
		{
			AL.BufferData((uint)bid, format, buffer, size, freq);
		}

		// Token: 0x0600458D RID: 17805 RVA: 0x000BEF3C File Offset: 0x000BD13C
		public static void BufferData<TBuffer>(int bid, ALFormat format, TBuffer[] buffer, int size, int freq) where TBuffer : struct
		{
			if (!BlittableValueType.Check<TBuffer>(buffer))
			{
				throw new ArgumentException("buffer");
			}
			GCHandle gchandle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
			try
			{
				AL.BufferData(bid, format, gchandle.AddrOfPinnedObject(), size, freq);
			}
			finally
			{
				gchandle.Free();
			}
		}

		// Token: 0x0600458E RID: 17806
		[CLSCompliant(false)]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("openal32.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "alGetBufferi", ExactSpelling = true)]
		public static extern void GetBuffer(uint bid, ALGetBufferi param, out int value);

		// Token: 0x0600458F RID: 17807 RVA: 0x000BEF90 File Offset: 0x000BD190
		public static void GetBuffer(int bid, ALGetBufferi param, out int value)
		{
			AL.GetBuffer((uint)bid, param, out value);
		}

		// Token: 0x06004590 RID: 17808
		[SuppressUnmanagedCodeSecurity]
		[DllImport("openal32.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "alDopplerFactor", ExactSpelling = true)]
		public static extern void DopplerFactor(float value);

		// Token: 0x06004591 RID: 17809
		[SuppressUnmanagedCodeSecurity]
		[DllImport("openal32.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "alDopplerVelocity", ExactSpelling = true)]
		public static extern void DopplerVelocity(float value);

		// Token: 0x06004592 RID: 17810
		[SuppressUnmanagedCodeSecurity]
		[DllImport("openal32.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "alSpeedOfSound", ExactSpelling = true)]
		public static extern void SpeedOfSound(float value);

		// Token: 0x06004593 RID: 17811
		[SuppressUnmanagedCodeSecurity]
		[DllImport("openal32.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "alDistanceModel", ExactSpelling = true)]
		public static extern void DistanceModel(ALDistanceModel distancemodel);

		// Token: 0x06004594 RID: 17812 RVA: 0x000BEF9C File Offset: 0x000BD19C
		[CLSCompliant(false)]
		public static ALSourceState GetSourceState(uint sid)
		{
			int result;
			AL.GetSource(sid, ALGetSourcei.SourceState, out result);
			return (ALSourceState)result;
		}

		// Token: 0x06004595 RID: 17813 RVA: 0x000BEFB8 File Offset: 0x000BD1B8
		public static ALSourceState GetSourceState(int sid)
		{
			int result;
			AL.GetSource(sid, ALGetSourcei.SourceState, out result);
			return (ALSourceState)result;
		}

		// Token: 0x06004596 RID: 17814 RVA: 0x000BEFD4 File Offset: 0x000BD1D4
		[CLSCompliant(false)]
		public static ALSourceType GetSourceType(uint sid)
		{
			int result;
			AL.GetSource(sid, ALGetSourcei.SourceType, out result);
			return (ALSourceType)result;
		}

		// Token: 0x06004597 RID: 17815 RVA: 0x000BEFF0 File Offset: 0x000BD1F0
		public static ALSourceType GetSourceType(int sid)
		{
			int result;
			AL.GetSource(sid, ALGetSourcei.SourceType, out result);
			return (ALSourceType)result;
		}

		// Token: 0x06004598 RID: 17816 RVA: 0x000BF00C File Offset: 0x000BD20C
		public static ALDistanceModel GetDistanceModel()
		{
			return (ALDistanceModel)AL.Get(ALGetInteger.DistanceModel);
		}

		// Token: 0x04005011 RID: 20497
		internal const string Lib = "openal32.dll";

		// Token: 0x04005012 RID: 20498
		private const CallingConvention Style = CallingConvention.Cdecl;
	}
}
