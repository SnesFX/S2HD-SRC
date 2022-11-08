using System;
using OpenTK.Audio.OpenAL;

namespace OpenTK.Audio
{
	// Token: 0x02000544 RID: 1348
	internal struct AudioDeviceErrorChecker : IDisposable
	{
		// Token: 0x060043FB RID: 17403 RVA: 0x000B8B0C File Offset: 0x000B6D0C
		public AudioDeviceErrorChecker(IntPtr device)
		{
			if (device == IntPtr.Zero)
			{
				throw new AudioDeviceException();
			}
			this.Device = device;
		}

		// Token: 0x060043FC RID: 17404 RVA: 0x000B8B28 File Offset: 0x000B6D28
		public void Dispose()
		{
			AlcError error = Alc.GetError(this.Device);
			AlcError alcError = error;
			if (alcError != AlcError.NoError)
			{
				switch (alcError)
				{
				case AlcError.InvalidDevice:
					throw new AudioDeviceException(string.Format(AudioDeviceErrorChecker.ErrorString, this.Device, error));
				case AlcError.InvalidContext:
					throw new AudioContextException(string.Format(AudioDeviceErrorChecker.ErrorString, this.Device, error));
				case AlcError.InvalidEnum:
					break;
				case AlcError.InvalidValue:
					throw new AudioValueException(string.Format(AudioDeviceErrorChecker.ErrorString, this.Device, error));
				case AlcError.OutOfMemory:
					throw new OutOfMemoryException(string.Format(AudioDeviceErrorChecker.ErrorString, this.Device, error));
				default:
					return;
				}
			}
		}

		// Token: 0x04004E74 RID: 20084
		private readonly IntPtr Device;

		// Token: 0x04004E75 RID: 20085
		private static readonly string ErrorString = "Device {0} reported {1}.";
	}
}
