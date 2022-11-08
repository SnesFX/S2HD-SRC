using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using OpenTK.Audio.OpenAL;

namespace OpenTK.Audio
{
	// Token: 0x02000547 RID: 1351
	public sealed class AudioCapture : IDisposable
	{
		// Token: 0x0600441F RID: 17439 RVA: 0x000B9328 File Offset: 0x000B7528
		static AudioCapture()
		{
			bool isOpenALSupported = AudioDeviceEnumerator.IsOpenALSupported;
		}

		// Token: 0x06004420 RID: 17440 RVA: 0x000B9330 File Offset: 0x000B7530
		public AudioCapture() : this(AudioCapture.DefaultDevice, 22050, ALFormat.Mono16, 4096)
		{
		}

		// Token: 0x06004421 RID: 17441 RVA: 0x000B934C File Offset: 0x000B754C
		public AudioCapture(string deviceName, int frequency, ALFormat sampleFormat, int bufferSize)
		{
			if (!AudioDeviceEnumerator.IsOpenALSupported)
			{
				throw new DllNotFoundException("openal32.dll");
			}
			if (frequency <= 0)
			{
				throw new ArgumentOutOfRangeException("frequency");
			}
			if (bufferSize <= 0)
			{
				throw new ArgumentOutOfRangeException("bufferSize");
			}
			this.device_name = deviceName;
			this.Handle = Alc.CaptureOpenDevice(deviceName, frequency, sampleFormat, bufferSize);
			if (this.Handle == IntPtr.Zero)
			{
				this.device_name = "IntPtr.Zero";
				this.Handle = Alc.CaptureOpenDevice(null, frequency, sampleFormat, bufferSize);
			}
			if (this.Handle == IntPtr.Zero)
			{
				this.device_name = AudioDeviceEnumerator.DefaultRecordingDevice;
				this.Handle = Alc.CaptureOpenDevice(AudioDeviceEnumerator.DefaultRecordingDevice, frequency, sampleFormat, bufferSize);
			}
			if (this.Handle == IntPtr.Zero)
			{
				this.device_name = "None";
				throw new AudioDeviceException("All attempts to open capture devices returned IntPtr.Zero. See debug log for verbose list.");
			}
			this.CheckErrors();
			this.SampleFormat = sampleFormat;
			this.SampleFrequency = frequency;
		}

		// Token: 0x1700041D RID: 1053
		// (get) Token: 0x06004422 RID: 17442 RVA: 0x000B9444 File Offset: 0x000B7644
		public string CurrentDevice
		{
			get
			{
				return this.device_name;
			}
		}

		// Token: 0x1700041E RID: 1054
		// (get) Token: 0x06004423 RID: 17443 RVA: 0x000B944C File Offset: 0x000B764C
		public static IList<string> AvailableDevices
		{
			get
			{
				return AudioDeviceEnumerator.AvailableRecordingDevices;
			}
		}

		// Token: 0x1700041F RID: 1055
		// (get) Token: 0x06004424 RID: 17444 RVA: 0x000B9454 File Offset: 0x000B7654
		public static string DefaultDevice
		{
			get
			{
				return AudioDeviceEnumerator.DefaultRecordingDevice;
			}
		}

		// Token: 0x06004425 RID: 17445 RVA: 0x000B945C File Offset: 0x000B765C
		public void CheckErrors()
		{
			new AudioDeviceErrorChecker(this.Handle).Dispose();
		}

		// Token: 0x17000420 RID: 1056
		// (get) Token: 0x06004426 RID: 17446 RVA: 0x000B947C File Offset: 0x000B767C
		public AlcError CurrentError
		{
			get
			{
				return Alc.GetError(this.Handle);
			}
		}

		// Token: 0x06004427 RID: 17447 RVA: 0x000B948C File Offset: 0x000B768C
		public void Start()
		{
			Alc.CaptureStart(this.Handle);
			this._isrecording = true;
		}

		// Token: 0x06004428 RID: 17448 RVA: 0x000B94A0 File Offset: 0x000B76A0
		public void Stop()
		{
			Alc.CaptureStop(this.Handle);
			this._isrecording = false;
		}

		// Token: 0x17000421 RID: 1057
		// (get) Token: 0x06004429 RID: 17449 RVA: 0x000B94B4 File Offset: 0x000B76B4
		public int AvailableSamples
		{
			get
			{
				int result;
				Alc.GetInteger(this.Handle, AlcGetInteger.CaptureSamples, 1, out result);
				return result;
			}
		}

		// Token: 0x0600442A RID: 17450 RVA: 0x000B94D8 File Offset: 0x000B76D8
		public void ReadSamples(IntPtr buffer, int sampleCount)
		{
			Alc.CaptureSamples(this.Handle, buffer, sampleCount);
		}

		// Token: 0x0600442B RID: 17451 RVA: 0x000B94E8 File Offset: 0x000B76E8
		public void ReadSamples<TBuffer>(TBuffer[] buffer, int sampleCount) where TBuffer : struct
		{
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer");
			}
			int num = BlittableValueType<TBuffer>.Stride * buffer.Length;
			if (sampleCount * AudioCapture.GetSampleSize(this.SampleFormat) > num)
			{
				throw new ArgumentOutOfRangeException("sampleCount");
			}
			GCHandle gchandle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
			try
			{
				this.ReadSamples(gchandle.AddrOfPinnedObject(), sampleCount);
			}
			finally
			{
				gchandle.Free();
			}
		}

		// Token: 0x17000422 RID: 1058
		// (get) Token: 0x0600442C RID: 17452 RVA: 0x000B9558 File Offset: 0x000B7758
		// (set) Token: 0x0600442D RID: 17453 RVA: 0x000B9560 File Offset: 0x000B7760
		public ALFormat SampleFormat
		{
			get
			{
				return this.sample_format;
			}
			private set
			{
				this.sample_format = value;
			}
		}

		// Token: 0x17000423 RID: 1059
		// (get) Token: 0x0600442E RID: 17454 RVA: 0x000B956C File Offset: 0x000B776C
		// (set) Token: 0x0600442F RID: 17455 RVA: 0x000B9574 File Offset: 0x000B7774
		public int SampleFrequency
		{
			get
			{
				return this.sample_frequency;
			}
			private set
			{
				this.sample_frequency = value;
			}
		}

		// Token: 0x17000424 RID: 1060
		// (get) Token: 0x06004430 RID: 17456 RVA: 0x000B9580 File Offset: 0x000B7780
		public bool IsRunning
		{
			get
			{
				return this._isrecording;
			}
		}

		// Token: 0x06004431 RID: 17457 RVA: 0x000B9588 File Offset: 0x000B7788
		private static int GetSampleSize(ALFormat format)
		{
			switch (format)
			{
			case ALFormat.Mono8:
				return 1;
			case ALFormat.Mono16:
				return 2;
			case ALFormat.Stereo8:
				return 2;
			case ALFormat.Stereo16:
				return 4;
			default:
				switch (format)
				{
				case ALFormat.MultiQuad8Ext:
					return 4;
				case ALFormat.MultiQuad16Ext:
					return 8;
				case ALFormat.MultiQuad32Ext:
					return 16;
				case ALFormat.MultiRear8Ext:
					return 1;
				case ALFormat.MultiRear16Ext:
					return 2;
				case ALFormat.MultiRear32Ext:
					return 4;
				case ALFormat.Multi51Chn8Ext:
					return 6;
				case ALFormat.Multi51Chn16Ext:
					return 12;
				case ALFormat.Multi51Chn32Ext:
					return 24;
				case ALFormat.Multi61Chn8Ext:
					return 7;
				case ALFormat.Multi61Chn16Ext:
				case ALFormat.Multi61Chn32Ext:
				case ALFormat.Multi71Chn8Ext:
					break;
				case ALFormat.Multi71Chn16Ext:
					return 14;
				case ALFormat.Multi71Chn32Ext:
					return 28;
				default:
					switch (format)
					{
					case ALFormat.MonoFloat32Ext:
						return 4;
					case ALFormat.StereoFloat32Ext:
						return 8;
					case ALFormat.MonoDoubleExt:
						return 8;
					case ALFormat.StereoDoubleExt:
						return 16;
					}
					break;
				}
				return 1;
			}
		}

		// Token: 0x06004432 RID: 17458 RVA: 0x000B9648 File Offset: 0x000B7848
		private string ErrorMessage(string devicename, int frequency, ALFormat bufferformat, int buffersize)
		{
			AlcError currentError = this.CurrentError;
			string text;
			switch (currentError)
			{
			case AlcError.InvalidValue:
				text = currentError.ToString() + ": One of the parameters has an invalid value.";
				break;
			case AlcError.OutOfMemory:
				text = currentError.ToString() + ": The specified device is invalid, or can not capture audio.";
				break;
			default:
				text = currentError.ToString();
				break;
			}
			return string.Concat(new object[]
			{
				"The handle returned by Alc.CaptureOpenDevice is null.\nAlc Error: ",
				text,
				"\nDevice Name: ",
				devicename,
				"\nCapture frequency: ",
				frequency,
				"\nBuffer format: ",
				bufferformat,
				"\nBuffer Size: ",
				buffersize
			});
		}

		// Token: 0x06004433 RID: 17459 RVA: 0x000B970C File Offset: 0x000B790C
		~AudioCapture()
		{
			this.Dispose();
		}

		// Token: 0x06004434 RID: 17460 RVA: 0x000B9738 File Offset: 0x000B7938
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x06004435 RID: 17461 RVA: 0x000B9748 File Offset: 0x000B7948
		private void Dispose(bool manual)
		{
			if (!this.IsDisposed)
			{
				if (this.Handle != IntPtr.Zero)
				{
					if (this._isrecording)
					{
						this.Stop();
					}
					Alc.CaptureCloseDevice(this.Handle);
				}
				this.IsDisposed = true;
			}
		}

		// Token: 0x04004E85 RID: 20101
		private IntPtr Handle;

		// Token: 0x04004E86 RID: 20102
		private bool _isrecording;

		// Token: 0x04004E87 RID: 20103
		private ALFormat sample_format;

		// Token: 0x04004E88 RID: 20104
		private int sample_frequency;

		// Token: 0x04004E89 RID: 20105
		private string device_name;

		// Token: 0x04004E8A RID: 20106
		private bool IsDisposed;
	}
}
