using System;
using System.Collections.Generic;
using System.Diagnostics;
using OpenTK.Audio.OpenAL;

namespace OpenTK.Audio
{
	// Token: 0x02000542 RID: 1346
	internal static class AudioDeviceEnumerator
	{
		// Token: 0x1700040E RID: 1038
		// (get) Token: 0x060043F4 RID: 17396 RVA: 0x000B87F4 File Offset: 0x000B69F4
		internal static IList<string> AvailablePlaybackDevices
		{
			get
			{
				return AudioDeviceEnumerator.available_playback_devices.AsReadOnly();
			}
		}

		// Token: 0x1700040F RID: 1039
		// (get) Token: 0x060043F5 RID: 17397 RVA: 0x000B8800 File Offset: 0x000B6A00
		internal static IList<string> AvailableRecordingDevices
		{
			get
			{
				return AudioDeviceEnumerator.available_recording_devices.AsReadOnly();
			}
		}

		// Token: 0x17000410 RID: 1040
		// (get) Token: 0x060043F6 RID: 17398 RVA: 0x000B880C File Offset: 0x000B6A0C
		internal static string DefaultPlaybackDevice
		{
			get
			{
				return AudioDeviceEnumerator.default_playback_device;
			}
		}

		// Token: 0x17000411 RID: 1041
		// (get) Token: 0x060043F7 RID: 17399 RVA: 0x000B8814 File Offset: 0x000B6A14
		internal static string DefaultRecordingDevice
		{
			get
			{
				return AudioDeviceEnumerator.default_recording_device;
			}
		}

		// Token: 0x17000412 RID: 1042
		// (get) Token: 0x060043F8 RID: 17400 RVA: 0x000B881C File Offset: 0x000B6A1C
		internal static bool IsOpenALSupported
		{
			get
			{
				return AudioDeviceEnumerator.openal_supported;
			}
		}

		// Token: 0x17000413 RID: 1043
		// (get) Token: 0x060043F9 RID: 17401 RVA: 0x000B8824 File Offset: 0x000B6A24
		internal static AudioDeviceEnumerator.AlcVersion Version
		{
			get
			{
				return AudioDeviceEnumerator.version;
			}
		}

		// Token: 0x060043FA RID: 17402 RVA: 0x000B882C File Offset: 0x000B6A2C
		static AudioDeviceEnumerator()
		{
			IntPtr intPtr = IntPtr.Zero;
			ContextHandle contextHandle = ContextHandle.Zero;
			try
			{
				intPtr = Alc.OpenDevice(null);
				contextHandle = Alc.CreateContext(intPtr, null);
				bool flag = Alc.MakeContextCurrent(contextHandle);
				AlcError error = Alc.GetError(intPtr);
				if (!flag || error != AlcError.NoError)
				{
					throw new AudioContextException(string.Concat(new string[]
					{
						"Failed to create dummy Context. Device (",
						intPtr.ToString(),
						") Context (",
						contextHandle.Handle.ToString(),
						") MakeContextCurrent ",
						flag ? "succeeded" : "failed",
						", Alc Error (",
						error.ToString(),
						") ",
						Alc.GetString(IntPtr.Zero, (AlcGetString)error)
					}));
				}
				if (Alc.IsExtensionPresent(IntPtr.Zero, "ALC_ENUMERATION_EXT"))
				{
					AudioDeviceEnumerator.version = AudioDeviceEnumerator.AlcVersion.Alc1_1;
					if (Alc.IsExtensionPresent(IntPtr.Zero, "ALC_ENUMERATE_ALL_EXT"))
					{
						AudioDeviceEnumerator.available_playback_devices.AddRange(Alc.GetString(IntPtr.Zero, AlcGetStringList.AllDevicesSpecifier));
						AudioDeviceEnumerator.default_playback_device = Alc.GetString(IntPtr.Zero, AlcGetString.DefaultAllDevicesSpecifier);
					}
					else
					{
						AudioDeviceEnumerator.available_playback_devices.AddRange(Alc.GetString(IntPtr.Zero, AlcGetStringList.DeviceSpecifier));
						AudioDeviceEnumerator.default_playback_device = Alc.GetString(IntPtr.Zero, AlcGetString.DefaultDeviceSpecifier);
					}
				}
				else
				{
					AudioDeviceEnumerator.version = AudioDeviceEnumerator.AlcVersion.Alc1_0;
				}
				AlcError error2 = Alc.GetError(intPtr);
				if (error2 != AlcError.NoError)
				{
					throw new AudioContextException("Alc Error occured when querying available playback devices. " + error2.ToString());
				}
				if (AudioDeviceEnumerator.version == AudioDeviceEnumerator.AlcVersion.Alc1_1 && Alc.IsExtensionPresent(IntPtr.Zero, "ALC_EXT_CAPTURE"))
				{
					AudioDeviceEnumerator.available_recording_devices.AddRange(Alc.GetString(IntPtr.Zero, AlcGetStringList.CaptureDeviceSpecifier));
					AudioDeviceEnumerator.default_recording_device = Alc.GetString(IntPtr.Zero, AlcGetString.CaptureDefaultDeviceSpecifier);
				}
				AlcError error3 = Alc.GetError(intPtr);
				if (error3 != AlcError.NoError)
				{
					throw new AudioContextException("Alc Error occured when querying available recording devices. " + error3.ToString());
				}
			}
			catch (DllNotFoundException ex)
			{
				Trace.WriteLine(ex.ToString());
				AudioDeviceEnumerator.openal_supported = false;
			}
			catch (AudioContextException ex2)
			{
				Trace.WriteLine(ex2.ToString());
				AudioDeviceEnumerator.openal_supported = false;
			}
			finally
			{
				Alc.MakeContextCurrent(ContextHandle.Zero);
				if (contextHandle != ContextHandle.Zero && contextHandle.Handle != IntPtr.Zero)
				{
					Alc.DestroyContext(contextHandle);
				}
				if (intPtr != IntPtr.Zero)
				{
					Alc.CloseDevice(intPtr);
				}
			}
		}

		// Token: 0x04004E6B RID: 20075
		private static readonly List<string> available_playback_devices = new List<string>();

		// Token: 0x04004E6C RID: 20076
		private static readonly List<string> available_recording_devices = new List<string>();

		// Token: 0x04004E6D RID: 20077
		private static string default_playback_device;

		// Token: 0x04004E6E RID: 20078
		private static string default_recording_device;

		// Token: 0x04004E6F RID: 20079
		private static bool openal_supported = true;

		// Token: 0x04004E70 RID: 20080
		private static AudioDeviceEnumerator.AlcVersion version;

		// Token: 0x02000543 RID: 1347
		internal enum AlcVersion
		{
			// Token: 0x04004E72 RID: 20082
			Alc1_0,
			// Token: 0x04004E73 RID: 20083
			Alc1_1
		}
	}
}
