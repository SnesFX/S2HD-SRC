using System;
using System.Collections.Generic;
using OpenTK.Audio.OpenAL;

namespace OpenTK.Audio
{
	// Token: 0x02000545 RID: 1349
	public sealed class AudioContext : IDisposable
	{
		// Token: 0x060043FE RID: 17406 RVA: 0x000B8BFC File Offset: 0x000B6DFC
		static AudioContext()
		{
			bool isOpenALSupported = AudioDeviceEnumerator.IsOpenALSupported;
		}

		// Token: 0x060043FF RID: 17407 RVA: 0x000B8C18 File Offset: 0x000B6E18
		public AudioContext() : this(null, 0, 0, false, true, AudioContext.MaxAuxiliarySends.UseDriverDefault)
		{
		}

		// Token: 0x06004400 RID: 17408 RVA: 0x000B8C28 File Offset: 0x000B6E28
		public AudioContext(string device) : this(device, 0, 0, false, true, AudioContext.MaxAuxiliarySends.UseDriverDefault)
		{
		}

		// Token: 0x06004401 RID: 17409 RVA: 0x000B8C38 File Offset: 0x000B6E38
		public AudioContext(string device, int freq) : this(device, freq, 0, false, true, AudioContext.MaxAuxiliarySends.UseDriverDefault)
		{
		}

		// Token: 0x06004402 RID: 17410 RVA: 0x000B8C48 File Offset: 0x000B6E48
		public AudioContext(string device, int freq, int refresh) : this(device, freq, refresh, false, true, AudioContext.MaxAuxiliarySends.UseDriverDefault)
		{
		}

		// Token: 0x06004403 RID: 17411 RVA: 0x000B8C58 File Offset: 0x000B6E58
		public AudioContext(string device, int freq, int refresh, bool sync) : this(AudioDeviceEnumerator.AvailablePlaybackDevices[0], freq, refresh, sync, true)
		{
		}

		// Token: 0x06004404 RID: 17412 RVA: 0x000B8C70 File Offset: 0x000B6E70
		public AudioContext(string device, int freq, int refresh, bool sync, bool enableEfx)
		{
			this.CreateContext(device, freq, refresh, sync, enableEfx, AudioContext.MaxAuxiliarySends.UseDriverDefault);
		}

		// Token: 0x06004405 RID: 17413 RVA: 0x000B8C88 File Offset: 0x000B6E88
		public AudioContext(string device, int freq, int refresh, bool sync, bool enableEfx, AudioContext.MaxAuxiliarySends efxMaxAuxSends)
		{
			this.CreateContext(device, freq, refresh, sync, enableEfx, efxMaxAuxSends);
		}

		// Token: 0x06004406 RID: 17414 RVA: 0x000B8CA0 File Offset: 0x000B6EA0
		private void CreateContext(string device, int freq, int refresh, bool sync, bool enableEfx, AudioContext.MaxAuxiliarySends efxAuxiliarySends)
		{
			if (!AudioDeviceEnumerator.IsOpenALSupported)
			{
				throw new DllNotFoundException("openal32.dll");
			}
			if (AudioDeviceEnumerator.Version == AudioDeviceEnumerator.AlcVersion.Alc1_1 && AudioDeviceEnumerator.AvailablePlaybackDevices.Count == 0)
			{
				throw new NotSupportedException("No audio hardware is available.");
			}
			if (this.context_exists)
			{
				throw new NotSupportedException("Multiple AudioContexts are not supported.");
			}
			if (freq < 0)
			{
				throw new ArgumentOutOfRangeException("freq", freq, "Should be greater than zero.");
			}
			if (refresh < 0)
			{
				throw new ArgumentOutOfRangeException("refresh", refresh, "Should be greater than zero.");
			}
			if (!string.IsNullOrEmpty(device))
			{
				this.device_name = device;
				this.device_handle = Alc.OpenDevice(device);
			}
			if (this.device_handle == IntPtr.Zero)
			{
				this.device_name = "IntPtr.Zero (null string)";
				this.device_handle = Alc.OpenDevice(null);
			}
			if (this.device_handle == IntPtr.Zero)
			{
				this.device_name = AudioContext.DefaultDevice;
				this.device_handle = Alc.OpenDevice(AudioContext.DefaultDevice);
			}
			if (this.device_handle == IntPtr.Zero)
			{
				this.device_name = "None";
				throw new AudioDeviceException(string.Format("Audio device '{0}' does not exist or is tied up by another application.", string.IsNullOrEmpty(device) ? "default" : device));
			}
			this.CheckErrors();
			List<int> list = new List<int>();
			if (freq != 0)
			{
				list.Add(4103);
				list.Add(freq);
			}
			if (refresh != 0)
			{
				list.Add(4104);
				list.Add(refresh);
			}
			list.Add(4105);
			list.Add(sync ? 1 : 0);
			if (enableEfx && Alc.IsExtensionPresent(this.device_handle, "ALC_EXT_EFX"))
			{
				int item;
				switch (efxAuxiliarySends)
				{
				case AudioContext.MaxAuxiliarySends.One:
				case AudioContext.MaxAuxiliarySends.Two:
				case AudioContext.MaxAuxiliarySends.Three:
				case AudioContext.MaxAuxiliarySends.Four:
					item = (int)efxAuxiliarySends;
					goto IL_1C2;
				}
				Alc.GetInteger(this.device_handle, AlcGetInteger.EfxMaxAuxiliarySends, 1, out item);
				IL_1C2:
				list.Add(131075);
				list.Add(item);
			}
			list.Add(0);
			this.context_handle = Alc.CreateContext(this.device_handle, list.ToArray());
			if (this.context_handle == ContextHandle.Zero)
			{
				Alc.CloseDevice(this.device_handle);
				throw new AudioContextException("The audio context could not be created with the specified parameters.");
			}
			this.CheckErrors();
			if (AudioDeviceEnumerator.AvailablePlaybackDevices.Count > 0)
			{
				this.MakeCurrent();
			}
			this.CheckErrors();
			this.device_name = Alc.GetString(this.device_handle, AlcGetString.DeviceSpecifier);
			lock (AudioContext.audio_context_lock)
			{
				AudioContext.available_contexts.Add(this.context_handle, this);
				this.context_exists = true;
			}
		}

		// Token: 0x06004407 RID: 17415 RVA: 0x000B8F3C File Offset: 0x000B713C
		private static void MakeCurrent(AudioContext context)
		{
			lock (AudioContext.audio_context_lock)
			{
				if (!Alc.MakeContextCurrent((context != null) ? context.context_handle : ContextHandle.Zero))
				{
					throw new AudioContextException(string.Format("ALC {0} error detected at {1}.", Alc.GetError((context != null) ? ((IntPtr)context.context_handle) : IntPtr.Zero).ToString(), (context != null) ? context.ToString() : "null"));
				}
			}
		}

		// Token: 0x17000414 RID: 1044
		// (get) Token: 0x06004408 RID: 17416 RVA: 0x000B8FCC File Offset: 0x000B71CC
		// (set) Token: 0x06004409 RID: 17417 RVA: 0x000B9018 File Offset: 0x000B7218
		internal bool IsCurrent
		{
			get
			{
				bool result;
				lock (AudioContext.audio_context_lock)
				{
					if (AudioContext.available_contexts.Count == 0)
					{
						result = false;
					}
					else
					{
						result = (AudioContext.CurrentContext == this);
					}
				}
				return result;
			}
			set
			{
				if (value)
				{
					AudioContext.MakeCurrent(this);
					return;
				}
				AudioContext.MakeCurrent(null);
			}
		}

		// Token: 0x17000415 RID: 1045
		// (get) Token: 0x0600440A RID: 17418 RVA: 0x000B902C File Offset: 0x000B722C
		private IntPtr Device
		{
			get
			{
				return this.device_handle;
			}
		}

		// Token: 0x0600440B RID: 17419 RVA: 0x000B9034 File Offset: 0x000B7234
		public void CheckErrors()
		{
			if (this.disposed)
			{
				throw new ObjectDisposedException(base.GetType().FullName);
			}
			new AudioDeviceErrorChecker(this.device_handle).Dispose();
		}

		// Token: 0x17000416 RID: 1046
		// (get) Token: 0x0600440C RID: 17420 RVA: 0x000B9070 File Offset: 0x000B7270
		public AlcError CurrentError
		{
			get
			{
				if (this.disposed)
				{
					throw new ObjectDisposedException(base.GetType().FullName);
				}
				return Alc.GetError(this.device_handle);
			}
		}

		// Token: 0x0600440D RID: 17421 RVA: 0x000B9098 File Offset: 0x000B7298
		public void MakeCurrent()
		{
			if (this.disposed)
			{
				throw new ObjectDisposedException(base.GetType().FullName);
			}
			AudioContext.MakeCurrent(this);
		}

		// Token: 0x17000417 RID: 1047
		// (get) Token: 0x0600440E RID: 17422 RVA: 0x000B90BC File Offset: 0x000B72BC
		// (set) Token: 0x0600440F RID: 17423 RVA: 0x000B90E0 File Offset: 0x000B72E0
		public bool IsProcessing
		{
			get
			{
				if (this.disposed)
				{
					throw new ObjectDisposedException(base.GetType().FullName);
				}
				return this.is_processing;
			}
			private set
			{
				this.is_processing = value;
			}
		}

		// Token: 0x17000418 RID: 1048
		// (get) Token: 0x06004410 RID: 17424 RVA: 0x000B90EC File Offset: 0x000B72EC
		// (set) Token: 0x06004411 RID: 17425 RVA: 0x000B9110 File Offset: 0x000B7310
		public bool IsSynchronized
		{
			get
			{
				if (this.disposed)
				{
					throw new ObjectDisposedException(base.GetType().FullName);
				}
				return this.is_synchronized;
			}
			private set
			{
				this.is_synchronized = value;
			}
		}

		// Token: 0x06004412 RID: 17426 RVA: 0x000B911C File Offset: 0x000B731C
		public void Process()
		{
			if (this.disposed)
			{
				throw new ObjectDisposedException(base.GetType().FullName);
			}
			Alc.ProcessContext(this.context_handle);
			this.IsProcessing = true;
		}

		// Token: 0x06004413 RID: 17427 RVA: 0x000B914C File Offset: 0x000B734C
		public void Suspend()
		{
			if (this.disposed)
			{
				throw new ObjectDisposedException(base.GetType().FullName);
			}
			Alc.SuspendContext(this.context_handle);
			this.IsProcessing = false;
		}

		// Token: 0x06004414 RID: 17428 RVA: 0x000B917C File Offset: 0x000B737C
		public bool SupportsExtension(string extension)
		{
			if (this.disposed)
			{
				throw new ObjectDisposedException(base.GetType().FullName);
			}
			return Alc.IsExtensionPresent(this.Device, extension);
		}

		// Token: 0x17000419 RID: 1049
		// (get) Token: 0x06004415 RID: 17429 RVA: 0x000B91A4 File Offset: 0x000B73A4
		public string CurrentDevice
		{
			get
			{
				if (this.disposed)
				{
					throw new ObjectDisposedException(base.GetType().FullName);
				}
				return this.device_name;
			}
		}

		// Token: 0x1700041A RID: 1050
		// (get) Token: 0x06004416 RID: 17430 RVA: 0x000B91C8 File Offset: 0x000B73C8
		public static AudioContext CurrentContext
		{
			get
			{
				AudioContext result;
				lock (AudioContext.audio_context_lock)
				{
					if (AudioContext.available_contexts.Count == 0)
					{
						result = null;
					}
					else
					{
						AudioContext audioContext;
						AudioContext.available_contexts.TryGetValue(Alc.GetCurrentContext(), out audioContext);
						result = audioContext;
					}
				}
				return result;
			}
		}

		// Token: 0x1700041B RID: 1051
		// (get) Token: 0x06004417 RID: 17431 RVA: 0x000B9220 File Offset: 0x000B7420
		public static IList<string> AvailableDevices
		{
			get
			{
				return AudioDeviceEnumerator.AvailablePlaybackDevices;
			}
		}

		// Token: 0x1700041C RID: 1052
		// (get) Token: 0x06004418 RID: 17432 RVA: 0x000B9228 File Offset: 0x000B7428
		public static string DefaultDevice
		{
			get
			{
				return AudioDeviceEnumerator.DefaultPlaybackDevice;
			}
		}

		// Token: 0x06004419 RID: 17433 RVA: 0x000B9230 File Offset: 0x000B7430
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x0600441A RID: 17434 RVA: 0x000B9240 File Offset: 0x000B7440
		private void Dispose(bool manual)
		{
			if (!this.disposed)
			{
				if (this.IsCurrent)
				{
					this.IsCurrent = false;
				}
				if (this.context_handle != ContextHandle.Zero)
				{
					AudioContext.available_contexts.Remove(this.context_handle);
					Alc.DestroyContext(this.context_handle);
				}
				if (this.device_handle != IntPtr.Zero)
				{
					Alc.CloseDevice(this.device_handle);
				}
				this.disposed = true;
			}
		}

		// Token: 0x0600441B RID: 17435 RVA: 0x000B92BC File Offset: 0x000B74BC
		~AudioContext()
		{
			this.Dispose(false);
		}

		// Token: 0x0600441C RID: 17436 RVA: 0x000B92EC File Offset: 0x000B74EC
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		// Token: 0x0600441D RID: 17437 RVA: 0x000B92F4 File Offset: 0x000B74F4
		public override bool Equals(object obj)
		{
			return base.Equals(obj);
		}

		// Token: 0x0600441E RID: 17438 RVA: 0x000B9300 File Offset: 0x000B7500
		public override string ToString()
		{
			return string.Format("{0} (handle: {1}, device: {2})", this.device_name, this.context_handle, this.device_handle);
		}

		// Token: 0x04004E76 RID: 20086
		private bool disposed;

		// Token: 0x04004E77 RID: 20087
		private bool is_processing;

		// Token: 0x04004E78 RID: 20088
		private bool is_synchronized;

		// Token: 0x04004E79 RID: 20089
		private IntPtr device_handle;

		// Token: 0x04004E7A RID: 20090
		private ContextHandle context_handle;

		// Token: 0x04004E7B RID: 20091
		private bool context_exists;

		// Token: 0x04004E7C RID: 20092
		private string device_name;

		// Token: 0x04004E7D RID: 20093
		private static object audio_context_lock = new object();

		// Token: 0x04004E7E RID: 20094
		private static Dictionary<ContextHandle, AudioContext> available_contexts = new Dictionary<ContextHandle, AudioContext>();

		// Token: 0x02000546 RID: 1350
		public enum MaxAuxiliarySends
		{
			// Token: 0x04004E80 RID: 20096
			UseDriverDefault,
			// Token: 0x04004E81 RID: 20097
			One,
			// Token: 0x04004E82 RID: 20098
			Two,
			// Token: 0x04004E83 RID: 20099
			Three,
			// Token: 0x04004E84 RID: 20100
			Four
		}
	}
}
