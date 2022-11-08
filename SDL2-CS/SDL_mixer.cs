using System;
using System.Runtime.InteropServices;

namespace SDL2
{
	// Token: 0x02000004 RID: 4
	public static class SDL_mixer
	{
		// Token: 0x060001F9 RID: 505 RVA: 0x000029E4 File Offset: 0x00000BE4
		public static void SDL_MIXER_VERSION(out SDL.SDL_version X)
		{
			X.major = 2;
			X.minor = 0;
			X.patch = 0;
		}

		// Token: 0x060001FA RID: 506
		[DllImport("SDL2_mixer.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "MIX_Linked_Version")]
		private static extern IntPtr INTERNAL_MIX_Linked_Version();

		// Token: 0x060001FB RID: 507 RVA: 0x00002A2C File Offset: 0x00000C2C
		public static SDL.SDL_version MIX_Linked_Version()
		{
			IntPtr ptr = SDL_mixer.INTERNAL_MIX_Linked_Version();
			return (SDL.SDL_version)Marshal.PtrToStructure(ptr, typeof(SDL.SDL_version));
		}

		// Token: 0x060001FC RID: 508
		[DllImport("SDL2_mixer.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int Mix_Init(SDL_mixer.MIX_InitFlags flags);

		// Token: 0x060001FD RID: 509
		[DllImport("SDL2_mixer.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void Mix_Quit();

		// Token: 0x060001FE RID: 510
		[DllImport("SDL2_mixer.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int Mix_OpenAudio(int frequency, ushort format, int channels, int chunksize);

		// Token: 0x060001FF RID: 511
		[DllImport("SDL2_mixer.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int Mix_AllocateChannels(int numchans);

		// Token: 0x06000200 RID: 512
		[DllImport("SDL2_mixer.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int Mix_QuerySpec(out int frequency, out ushort format, out int channels);

		// Token: 0x06000201 RID: 513
		[DllImport("SDL2_mixer.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr Mix_LoadWAV_RW(IntPtr src, int freesrc);

		// Token: 0x06000202 RID: 514 RVA: 0x00002A5C File Offset: 0x00000C5C
		public static IntPtr Mix_LoadWAV(string file)
		{
			IntPtr src = SDL.INTERNAL_SDL_RWFromFile(file, "rb");
			return SDL_mixer.Mix_LoadWAV_RW(src, 1);
		}

		// Token: 0x06000203 RID: 515
		[DllImport("SDL2_mixer.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr Mix_LoadMUS([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = SDL2.LPUtf8StrMarshaler)] [In] string file);

		// Token: 0x06000204 RID: 516
		[DllImport("SDL2_mixer.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr Mix_QuickLoad_WAV([MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1)] [In] byte[] mem);

		// Token: 0x06000205 RID: 517
		[DllImport("SDL2_mixer.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr Mix_QuickLoad_RAW([MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 1)] [In] byte[] mem, uint len);

		// Token: 0x06000206 RID: 518
		[DllImport("SDL2_mixer.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void Mix_FreeChunk(IntPtr chunk);

		// Token: 0x06000207 RID: 519
		[DllImport("SDL2_mixer.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void Mix_FreeMusic(IntPtr music);

		// Token: 0x06000208 RID: 520
		[DllImport("SDL2_mixer.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int Mix_GetNumChunkDecoders();

		// Token: 0x06000209 RID: 521
		[DllImport("SDL2_mixer.dll", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = SDL2.LPUtf8StrMarshaler, MarshalCookie = "LeaveAllocated")]
		public static extern string Mix_GetChunkDecoder(int index);

		// Token: 0x0600020A RID: 522
		[DllImport("SDL2_mixer.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int Mix_GetNumMusicDecoders();

		// Token: 0x0600020B RID: 523
		[DllImport("SDL2_mixer.dll", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = SDL2.LPUtf8StrMarshaler, MarshalCookie = "LeaveAllocated")]
		public static extern string Mix_GetMusicDecoder(int index);

		// Token: 0x0600020C RID: 524
		[DllImport("SDL2_mixer.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL_mixer.Mix_MusicType Mix_GetMusicType(IntPtr music);

		// Token: 0x0600020D RID: 525
		[DllImport("SDL2_mixer.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void Mix_SetPostMix(SDL_mixer.MixFuncDelegate mix_func, IntPtr arg);

		// Token: 0x0600020E RID: 526
		[DllImport("SDL2_mixer.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void Mix_HookMusic(SDL_mixer.MixFuncDelegate mix_func, IntPtr arg);

		// Token: 0x0600020F RID: 527
		[DllImport("SDL2_mixer.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void Mix_HookMusicFinished(SDL_mixer.MusicFinishedDelegate music_finished);

		// Token: 0x06000210 RID: 528
		[DllImport("SDL2_mixer.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr Mix_GetMusicHookData();

		// Token: 0x06000211 RID: 529
		[DllImport("SDL2_mixer.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void Mix_ChannelFinished(SDL_mixer.ChannelFinishedDelegate channel_finished);

		// Token: 0x06000212 RID: 530
		[DllImport("SDL2_mixer.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int Mix_RegisterEffect(int chan, SDL_mixer.Mix_EffectFunc_t f, SDL_mixer.Mix_EffectDone_t d, IntPtr arg);

		// Token: 0x06000213 RID: 531
		[DllImport("SDL2_mixer.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int Mix_UnregisterEffect(int channel, SDL_mixer.Mix_EffectFunc_t f);

		// Token: 0x06000214 RID: 532
		[DllImport("SDL2_mixer.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int Mix_UnregisterAllEffects(int channel);

		// Token: 0x06000215 RID: 533
		[DllImport("SDL2_mixer.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int Mix_SetPanning(int channel, byte left, byte right);

		// Token: 0x06000216 RID: 534
		[DllImport("SDL2_mixer.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int Mix_SetPosition(int channel, short angle, byte distance);

		// Token: 0x06000217 RID: 535
		[DllImport("SDL2_mixer.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int Mix_SetDistance(int channel, byte distance);

		// Token: 0x06000218 RID: 536
		[DllImport("SDL2_mixer.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int Mix_SetReverseStereo(int channel, int flip);

		// Token: 0x06000219 RID: 537
		[DllImport("SDL2_mixer.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int Mix_ReserveChannels(int num);

		// Token: 0x0600021A RID: 538
		[DllImport("SDL2_mixer.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int Mix_GroupChannel(int which, int tag);

		// Token: 0x0600021B RID: 539
		[DllImport("SDL2_mixer.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int Mix_GroupChannels(int from, int to, int tag);

		// Token: 0x0600021C RID: 540
		[DllImport("SDL2_mixer.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int Mix_GroupAvailable(int tag);

		// Token: 0x0600021D RID: 541
		[DllImport("SDL2_mixer.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int Mix_GroupCount(int tag);

		// Token: 0x0600021E RID: 542
		[DllImport("SDL2_mixer.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int Mix_GroupOldest(int tag);

		// Token: 0x0600021F RID: 543
		[DllImport("SDL2_mixer.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int Mix_GroupNewer(int tag);

		// Token: 0x06000220 RID: 544 RVA: 0x00002A84 File Offset: 0x00000C84
		public static int Mix_PlayChannel(int channel, IntPtr chunk, int loops)
		{
			return SDL_mixer.Mix_PlayChannelTimed(channel, chunk, loops, -1);
		}

		// Token: 0x06000221 RID: 545
		[DllImport("SDL2_mixer.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int Mix_PlayChannelTimed(int channel, IntPtr chunk, int loops, int ticks);

		// Token: 0x06000222 RID: 546
		[DllImport("SDL2_mixer.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int Mix_PlayMusic(IntPtr music, int loops);

		// Token: 0x06000223 RID: 547
		[DllImport("SDL2_mixer.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int Mix_FadeInMusic(IntPtr music, int loops, int ms);

		// Token: 0x06000224 RID: 548
		[DllImport("SDL2_mixer.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int Mix_FadeInMusicPos(IntPtr music, int loops, int ms, double position);

		// Token: 0x06000225 RID: 549 RVA: 0x00002AA0 File Offset: 0x00000CA0
		public static int Mix_FadeInChannel(int channel, IntPtr chunk, int loops, int ms)
		{
			return SDL_mixer.Mix_FadeInChannelTimed(channel, chunk, loops, ms, -1);
		}

		// Token: 0x06000226 RID: 550
		[DllImport("SDL2_mixer.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int Mix_FadeInChannelTimed(int channel, IntPtr chunk, int loops, int ms, int ticks);

		// Token: 0x06000227 RID: 551
		[DllImport("SDL2_mixer.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int Mix_Volume(int channel, int volume);

		// Token: 0x06000228 RID: 552
		[DllImport("SDL2_mixer.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int Mix_VolumeChunk(IntPtr chunk, int volume);

		// Token: 0x06000229 RID: 553
		[DllImport("SDL2_mixer.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int Mix_VolumeMusic(int volume);

		// Token: 0x0600022A RID: 554
		[DllImport("SDL2_mixer.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int Mix_HaltChannel(int channel);

		// Token: 0x0600022B RID: 555
		[DllImport("SDL2_mixer.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int Mix_HaltGroup(int tag);

		// Token: 0x0600022C RID: 556
		[DllImport("SDL2_mixer.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int Mix_HaltMusic();

		// Token: 0x0600022D RID: 557
		[DllImport("SDL2_mixer.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int Mix_ExpireChannel(int channel, int ticks);

		// Token: 0x0600022E RID: 558
		[DllImport("SDL2_mixer.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int Mix_FadeOutChannel(int which, int ms);

		// Token: 0x0600022F RID: 559
		[DllImport("SDL2_mixer.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int Mix_FadeOutGroup(int tag, int ms);

		// Token: 0x06000230 RID: 560
		[DllImport("SDL2_mixer.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int Mix_FadeOutMusic(int ms);

		// Token: 0x06000231 RID: 561
		[DllImport("SDL2_mixer.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL_mixer.Mix_Fading Mix_FadingMusic();

		// Token: 0x06000232 RID: 562
		[DllImport("SDL2_mixer.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL_mixer.Mix_Fading Mix_FadingChannel(int which);

		// Token: 0x06000233 RID: 563
		[DllImport("SDL2_mixer.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void Mix_Pause(int channel);

		// Token: 0x06000234 RID: 564
		[DllImport("SDL2_mixer.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void Mix_Resume(int channel);

		// Token: 0x06000235 RID: 565
		[DllImport("SDL2_mixer.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int Mix_Paused(int channel);

		// Token: 0x06000236 RID: 566
		[DllImport("SDL2_mixer.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void Mix_PauseMusic();

		// Token: 0x06000237 RID: 567
		[DllImport("SDL2_mixer.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void Mix_ResumeMusic();

		// Token: 0x06000238 RID: 568
		[DllImport("SDL2_mixer.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void Mix_RewindMusic();

		// Token: 0x06000239 RID: 569
		[DllImport("SDL2_mixer.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int Mix_PausedMusic();

		// Token: 0x0600023A RID: 570
		[DllImport("SDL2_mixer.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int Mix_SetMusicPosition(double position);

		// Token: 0x0600023B RID: 571
		[DllImport("SDL2_mixer.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int Mix_Playing(int channel);

		// Token: 0x0600023C RID: 572
		[DllImport("SDL2_mixer.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int Mix_PlayingMusic();

		// Token: 0x0600023D RID: 573
		[DllImport("SDL2_mixer.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int Mix_SetMusicCMD([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = SDL2.LPUtf8StrMarshaler)] [In] string command);

		// Token: 0x0600023E RID: 574
		[DllImport("SDL2_mixer.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int Mix_SetSynchroValue(int value);

		// Token: 0x0600023F RID: 575
		[DllImport("SDL2_mixer.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int Mix_GetSynchroValue();

		// Token: 0x06000240 RID: 576
		[DllImport("SDL2_mixer.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int Mix_SetSoundFonts([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = SDL2.LPUtf8StrMarshaler)] [In] string paths);

		// Token: 0x06000241 RID: 577
		[DllImport("SDL2_mixer.dll", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = SDL2.LPUtf8StrMarshaler, MarshalCookie = "LeaveAllocated")]
		public static extern string Mix_GetSoundFonts();

		// Token: 0x06000242 RID: 578
		[DllImport("SDL2_mixer.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int Mix_EachSoundFont(SDL_mixer.SoundFontDelegate function, IntPtr data);

		// Token: 0x06000243 RID: 579
		[DllImport("SDL2_mixer.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr Mix_GetChunk(int channel);

		// Token: 0x06000244 RID: 580
		[DllImport("SDL2_mixer.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void Mix_CloseAudio();

		// Token: 0x040000CF RID: 207
		private const string nativeLibName = "SDL2_mixer.dll";

		// Token: 0x040000D0 RID: 208
		public const int SDL_MIXER_MAJOR_VERSION = 2;

		// Token: 0x040000D1 RID: 209
		public const int SDL_MIXER_MINOR_VERSION = 0;

		// Token: 0x040000D2 RID: 210
		public const int SDL_MIXER_PATCHLEVEL = 0;

		// Token: 0x040000D3 RID: 211
		public const int MIX_CHANNELS = 8;

		// Token: 0x040000D4 RID: 212
		public static readonly int MIX_DEFAULT_FREQUENCY = 22050;

		// Token: 0x040000D5 RID: 213
		public static readonly ushort MIX_DEFAULT_FORMAT = BitConverter.IsLittleEndian ? 32784 : 36880;

		// Token: 0x040000D6 RID: 214
		public static readonly int MIX_DEFAULT_CHANNELS = 2;

		// Token: 0x040000D7 RID: 215
		public static readonly byte MIX_MAX_VOLUME = 128;

		// Token: 0x02000071 RID: 113
		[Flags]
		public enum MIX_InitFlags
		{
			// Token: 0x040005B5 RID: 1461
			MIX_INIT_FLAC = 1,
			// Token: 0x040005B6 RID: 1462
			MIX_INIT_MOD = 2,
			// Token: 0x040005B7 RID: 1463
			MIX_INIT_MP3 = 4,
			// Token: 0x040005B8 RID: 1464
			MIX_INIT_OGG = 8,
			// Token: 0x040005B9 RID: 1465
			MIX_INIT_FLUIDSYNTH = 16
		}

		// Token: 0x02000072 RID: 114
		public enum Mix_Fading
		{
			// Token: 0x040005BB RID: 1467
			MIX_NO_FADING,
			// Token: 0x040005BC RID: 1468
			MIX_FADING_OUT,
			// Token: 0x040005BD RID: 1469
			MIX_FADING_IN
		}

		// Token: 0x02000073 RID: 115
		public enum Mix_MusicType
		{
			// Token: 0x040005BF RID: 1471
			MUS_NONE,
			// Token: 0x040005C0 RID: 1472
			MUS_CMD,
			// Token: 0x040005C1 RID: 1473
			MUS_WAV,
			// Token: 0x040005C2 RID: 1474
			MUS_MOD,
			// Token: 0x040005C3 RID: 1475
			MUS_MID,
			// Token: 0x040005C4 RID: 1476
			MUS_OGG,
			// Token: 0x040005C5 RID: 1477
			MUS_MP3,
			// Token: 0x040005C6 RID: 1478
			MUS_MP3_MAD,
			// Token: 0x040005C7 RID: 1479
			MUS_FLAC,
			// Token: 0x040005C8 RID: 1480
			MUS_MODPLUG
		}

		// Token: 0x02000074 RID: 116
		// (Invoke) Token: 0x06000294 RID: 660
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void MixFuncDelegate(IntPtr udata, IntPtr stream, int len);

		// Token: 0x02000075 RID: 117
		// (Invoke) Token: 0x06000298 RID: 664
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void Mix_EffectFunc_t(int chan, IntPtr stream, int len, IntPtr udata);

		// Token: 0x02000076 RID: 118
		// (Invoke) Token: 0x0600029C RID: 668
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void Mix_EffectDone_t(int chan, IntPtr udata);

		// Token: 0x02000077 RID: 119
		// (Invoke) Token: 0x060002A0 RID: 672
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void MusicFinishedDelegate();

		// Token: 0x02000078 RID: 120
		// (Invoke) Token: 0x060002A4 RID: 676
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void ChannelFinishedDelegate(int channel);

		// Token: 0x02000079 RID: 121
		// (Invoke) Token: 0x060002A8 RID: 680
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate int SoundFontDelegate(IntPtr a, IntPtr b);
	}
}
