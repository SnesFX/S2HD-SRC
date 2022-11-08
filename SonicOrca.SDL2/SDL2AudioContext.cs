using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using SDL2;
using SonicOrca.Audio;

namespace SonicOrca.SDL2
{
	// Token: 0x02000008 RID: 8
	public class SDL2AudioContext : AudioContext, IDisposable
	{
		// Token: 0x0600004B RID: 75 RVA: 0x00002C0C File Offset: 0x00000E0C
		public SDL2AudioContext(SDL2Platform platform)
		{
			this._platform = platform;
			Trace.WriteLine("Initialising SDL2 audio");
			if (SDL.SDL_InitSubSystem(16U) != 0)
			{
				throw SDL2Exception.FromError("Unable to initialise an audio driver.");
			}
			SDL.SDL_AudioSpec sdl_AudioSpec = new SDL.SDL_AudioSpec
			{
				channels = 2,
				format = 32784,
				freq = 44100,
				samples = 2048,
				callback = new SDL.SDL_AudioCallback(this.ReadDataCallback)
			};
			this._outputDevice = SDL.SDL_OpenAudioDevice(null, 0, ref sdl_AudioSpec, out this._outputAudioSpec, 0);
			if (this._outputDevice == 0U)
			{
				throw SDL2Exception.FromError("Unable to create output buffer.");
			}
			SDL.SDL_PauseAudioDevice(this._outputDevice, 0);
		}

		// Token: 0x0600004C RID: 76 RVA: 0x00002CD2 File Offset: 0x00000ED2
		public void Dispose()
		{
			SDL.SDL_CloseAudioDevice(this._outputDevice);
			Trace.WriteLine("Quitting SDL2 video");
			SDL.SDL_QuitSubSystem(16U);
		}

		// Token: 0x0600004D RID: 77 RVA: 0x00002CF0 File Offset: 0x00000EF0
		public override void RegisterSampleProvider(ISampleProvider sampleProvider)
		{
			object sync = this._registeredSampleProviders.Sync;
			lock (sync)
			{
				this._registeredSampleProviders.Instance.Add(sampleProvider);
			}
		}

		// Token: 0x0600004E RID: 78 RVA: 0x00002D40 File Offset: 0x00000F40
		public override void UnregisterSampleProvider(ISampleProvider sampleProvider)
		{
			object sync = this._registeredSampleProviders.Sync;
			lock (sync)
			{
				this._registeredSampleProviders.Instance.Remove(sampleProvider);
			}
		}

		// Token: 0x0600004F RID: 79 RVA: 0x00002D94 File Offset: 0x00000F94
		private void ReadDataCallback(IntPtr userdata, IntPtr stream, int length)
		{
			byte[] array = new byte[length];
			if (base.Mixer != null)
			{
				object sync = this._registeredSampleProviders.Sync;
				ISampleProvider[] channels;
				lock (sync)
				{
					channels = this._registeredSampleProviders.Instance.ToArray();
				}
				base.Mixer.Mix(array, 0, length, channels);
			}
			Marshal.Copy(array, 0, stream, length);
		}

		// Token: 0x0400001E RID: 30
		private readonly SDL2Platform _platform;

		// Token: 0x0400001F RID: 31
		private readonly Lockable<List<ISampleProvider>> _registeredSampleProviders = new Lockable<List<ISampleProvider>>(new List<ISampleProvider>());

		// Token: 0x04000020 RID: 32
		private uint _outputDevice;

		// Token: 0x04000021 RID: 33
		private SDL.SDL_AudioSpec _outputAudioSpec;
	}
}
