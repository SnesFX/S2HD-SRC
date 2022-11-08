using System;
using System.Runtime.InteropServices;
using System.Security;
using OpenTK.Input;

namespace OpenTK.Platform.Windows
{
	// Token: 0x0200002F RID: 47
	internal class XInputJoystick : IGamePadDriver, IDisposable
	{
		// Token: 0x060004CD RID: 1229 RVA: 0x0001432C File Offset: 0x0001252C
		public GamePadState GetState(int index)
		{
			XInputJoystick.XInputState xinputState;
			XInputJoystick.XInputErrorCode xinputErrorCode = this.xinput.GetState((XInputJoystick.XInputUserIndex)index, out xinputState);
			GamePadState result = default(GamePadState);
			if (xinputErrorCode == XInputJoystick.XInputErrorCode.Success)
			{
				result.SetConnected(true);
				result.SetAxis(GamePadAxes.LeftX, xinputState.GamePad.ThumbLX);
				result.SetAxis(GamePadAxes.LeftY, xinputState.GamePad.ThumbLY);
				result.SetAxis(GamePadAxes.RightX, xinputState.GamePad.ThumbRX);
				result.SetAxis(GamePadAxes.RightY, xinputState.GamePad.ThumbRY);
				result.SetTriggers(xinputState.GamePad.LeftTrigger, xinputState.GamePad.RightTrigger);
				result.SetButton(this.TranslateButtons(xinputState.GamePad.Buttons), true);
			}
			return result;
		}

		// Token: 0x060004CE RID: 1230 RVA: 0x000143F0 File Offset: 0x000125F0
		public GamePadCapabilities GetCapabilities(int index)
		{
			XInputJoystick.XInputDeviceCapabilities xinputDeviceCapabilities;
			if (this.xinput.GetCapabilities((XInputJoystick.XInputUserIndex)index, XInputJoystick.XInputCapabilitiesFlags.Default, out xinputDeviceCapabilities) == XInputJoystick.XInputErrorCode.Success)
			{
				GamePadType type = this.TranslateSubType(xinputDeviceCapabilities.SubType);
				Buttons buttons = this.TranslateButtons(xinputDeviceCapabilities.GamePad.Buttons);
				GamePadAxes axes = this.TranslateAxes(ref xinputDeviceCapabilities.GamePad);
				return new GamePadCapabilities(type, axes, buttons, true);
			}
			return default(GamePadCapabilities);
		}

		// Token: 0x060004CF RID: 1231 RVA: 0x0001445C File Offset: 0x0001265C
		public string GetName(int index)
		{
			return string.Empty;
		}

		// Token: 0x060004D0 RID: 1232 RVA: 0x00014464 File Offset: 0x00012664
		public bool SetVibration(int index, float left, float right)
		{
			return false;
		}

		// Token: 0x060004D1 RID: 1233 RVA: 0x00014468 File Offset: 0x00012668
		private GamePadAxes TranslateAxes(ref XInputJoystick.XInputGamePad pad)
		{
			GamePadAxes gamePadAxes = (GamePadAxes)0;
			gamePadAxes |= ((pad.ThumbLX != 0) ? GamePadAxes.LeftX : ((GamePadAxes)0));
			gamePadAxes |= ((pad.ThumbLY != 0) ? GamePadAxes.LeftY : ((GamePadAxes)0));
			gamePadAxes |= ((pad.LeftTrigger != 0) ? GamePadAxes.LeftTrigger : ((GamePadAxes)0));
			gamePadAxes |= ((pad.ThumbRX != 0) ? GamePadAxes.RightX : ((GamePadAxes)0));
			gamePadAxes |= ((pad.ThumbRY != 0) ? GamePadAxes.RightY : ((GamePadAxes)0));
			return gamePadAxes | ((pad.RightTrigger != 0) ? GamePadAxes.RightTrigger : ((GamePadAxes)0));
		}

		// Token: 0x060004D2 RID: 1234 RVA: 0x000144DC File Offset: 0x000126DC
		private Buttons TranslateButtons(XInputJoystick.XInputButtons xbuttons)
		{
			Buttons buttons = (Buttons)0;
			buttons |= (((ushort)(xbuttons & XInputJoystick.XInputButtons.A) != 0) ? Buttons.A : ((Buttons)0));
			buttons |= (((ushort)(xbuttons & XInputJoystick.XInputButtons.B) != 0) ? Buttons.B : ((Buttons)0));
			buttons |= (((ushort)(xbuttons & XInputJoystick.XInputButtons.X) != 0) ? Buttons.X : ((Buttons)0));
			buttons |= (((ushort)(xbuttons & XInputJoystick.XInputButtons.Y) != 0) ? Buttons.Y : ((Buttons)0));
			buttons |= (((ushort)(xbuttons & XInputJoystick.XInputButtons.Start) != 0) ? Buttons.Start : ((Buttons)0));
			buttons |= (((ushort)(xbuttons & XInputJoystick.XInputButtons.Back) != 0) ? Buttons.Back : ((Buttons)0));
			buttons |= (((ushort)(xbuttons & XInputJoystick.XInputButtons.LeftShoulder) != 0) ? Buttons.LeftShoulder : ((Buttons)0));
			buttons |= (((ushort)(xbuttons & XInputJoystick.XInputButtons.RightShoulder) != 0) ? Buttons.RightShoulder : ((Buttons)0));
			buttons |= (((ushort)(xbuttons & XInputJoystick.XInputButtons.LeftThumb) != 0) ? Buttons.LeftStick : ((Buttons)0));
			buttons |= (((ushort)(xbuttons & XInputJoystick.XInputButtons.RightThumb) != 0) ? Buttons.RightStick : ((Buttons)0));
			buttons |= (((ushort)(xbuttons & XInputJoystick.XInputButtons.DPadDown) != 0) ? Buttons.DPadDown : ((Buttons)0));
			buttons |= (((ushort)(xbuttons & XInputJoystick.XInputButtons.DPadUp) != 0) ? Buttons.DPadUp : ((Buttons)0));
			buttons |= (((ushort)(xbuttons & XInputJoystick.XInputButtons.DPadLeft) != 0) ? Buttons.DPadLeft : ((Buttons)0));
			return buttons | (((ushort)(xbuttons & XInputJoystick.XInputButtons.DPadRight) != 0) ? Buttons.DPadRight : ((Buttons)0));
		}

		// Token: 0x060004D3 RID: 1235 RVA: 0x000145E0 File Offset: 0x000127E0
		private GamePadType TranslateSubType(XInputJoystick.XInputDeviceSubType xtype)
		{
			switch (xtype)
			{
			case XInputJoystick.XInputDeviceSubType.GamePad:
				return GamePadType.GamePad;
			case XInputJoystick.XInputDeviceSubType.Wheel:
				return GamePadType.Wheel;
			case XInputJoystick.XInputDeviceSubType.ArcadeStick:
				return GamePadType.ArcadeStick;
			case XInputJoystick.XInputDeviceSubType.FlightStick:
				return GamePadType.FlightStick;
			case XInputJoystick.XInputDeviceSubType.DancePad:
				return GamePadType.DancePad;
			case XInputJoystick.XInputDeviceSubType.Guitar:
				return GamePadType.Guitar;
			case XInputJoystick.XInputDeviceSubType.GuitarAlternate:
				return GamePadType.AlternateGuitar;
			case XInputJoystick.XInputDeviceSubType.DrumKit:
				return GamePadType.DrumKit;
			case XInputJoystick.XInputDeviceSubType.GuitarBass:
				return GamePadType.BassGuitar;
			case XInputJoystick.XInputDeviceSubType.ArcadePad:
				return GamePadType.ArcadePad;
			}
			return GamePadType.Unknown;
		}

		// Token: 0x060004D4 RID: 1236 RVA: 0x00014660 File Offset: 0x00012860
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x060004D5 RID: 1237 RVA: 0x00014670 File Offset: 0x00012870
		private void Dispose(bool manual)
		{
			if (manual)
			{
				this.xinput.Dispose();
			}
		}

		// Token: 0x040000C1 RID: 193
		private XInputJoystick.XInput xinput = new XInputJoystick.XInput();

		// Token: 0x02000030 RID: 48
		private enum XInputErrorCode
		{
			// Token: 0x040000C3 RID: 195
			Success,
			// Token: 0x040000C4 RID: 196
			DeviceNotConnected
		}

		// Token: 0x02000031 RID: 49
		private enum XInputDeviceType : byte
		{
			// Token: 0x040000C6 RID: 198
			GamePad
		}

		// Token: 0x02000032 RID: 50
		private enum XInputDeviceSubType : byte
		{
			// Token: 0x040000C8 RID: 200
			Unknown,
			// Token: 0x040000C9 RID: 201
			GamePad,
			// Token: 0x040000CA RID: 202
			Wheel,
			// Token: 0x040000CB RID: 203
			ArcadeStick,
			// Token: 0x040000CC RID: 204
			FlightStick,
			// Token: 0x040000CD RID: 205
			DancePad,
			// Token: 0x040000CE RID: 206
			Guitar,
			// Token: 0x040000CF RID: 207
			GuitarAlternate,
			// Token: 0x040000D0 RID: 208
			DrumKit,
			// Token: 0x040000D1 RID: 209
			GuitarBass = 11,
			// Token: 0x040000D2 RID: 210
			ArcadePad = 19
		}

		// Token: 0x02000033 RID: 51
		private enum XInputCapabilities
		{
			// Token: 0x040000D4 RID: 212
			ForceFeedback = 1,
			// Token: 0x040000D5 RID: 213
			Wireless,
			// Token: 0x040000D6 RID: 214
			Voice = 4,
			// Token: 0x040000D7 RID: 215
			PluginModules = 8,
			// Token: 0x040000D8 RID: 216
			NoNavigation = 16
		}

		// Token: 0x02000034 RID: 52
		private enum XInputButtons : ushort
		{
			// Token: 0x040000DA RID: 218
			DPadUp = 1,
			// Token: 0x040000DB RID: 219
			DPadDown,
			// Token: 0x040000DC RID: 220
			DPadLeft = 4,
			// Token: 0x040000DD RID: 221
			DPadRight = 8,
			// Token: 0x040000DE RID: 222
			Start = 16,
			// Token: 0x040000DF RID: 223
			Back = 32,
			// Token: 0x040000E0 RID: 224
			LeftThumb = 64,
			// Token: 0x040000E1 RID: 225
			RightThumb = 128,
			// Token: 0x040000E2 RID: 226
			LeftShoulder = 256,
			// Token: 0x040000E3 RID: 227
			RightShoulder = 512,
			// Token: 0x040000E4 RID: 228
			A = 4096,
			// Token: 0x040000E5 RID: 229
			B = 8192,
			// Token: 0x040000E6 RID: 230
			X = 16384,
			// Token: 0x040000E7 RID: 231
			Y = 32768
		}

		// Token: 0x02000035 RID: 53
		[Flags]
		private enum XInputCapabilitiesFlags
		{
			// Token: 0x040000E9 RID: 233
			Default = 0,
			// Token: 0x040000EA RID: 234
			GamePadOnly = 1
		}

		// Token: 0x02000036 RID: 54
		private enum XInputBatteryType : byte
		{
			// Token: 0x040000EC RID: 236
			Disconnected,
			// Token: 0x040000ED RID: 237
			Wired,
			// Token: 0x040000EE RID: 238
			Alkaline,
			// Token: 0x040000EF RID: 239
			NiMH,
			// Token: 0x040000F0 RID: 240
			Unknown = 255
		}

		// Token: 0x02000037 RID: 55
		private enum XInputBatteryLevel : byte
		{
			// Token: 0x040000F2 RID: 242
			Empty,
			// Token: 0x040000F3 RID: 243
			Low,
			// Token: 0x040000F4 RID: 244
			Medium,
			// Token: 0x040000F5 RID: 245
			Full
		}

		// Token: 0x02000038 RID: 56
		private enum XInputUserIndex
		{
			// Token: 0x040000F7 RID: 247
			First,
			// Token: 0x040000F8 RID: 248
			Second,
			// Token: 0x040000F9 RID: 249
			Third,
			// Token: 0x040000FA RID: 250
			Fourth,
			// Token: 0x040000FB RID: 251
			Any = 255
		}

		// Token: 0x02000039 RID: 57
		private struct XInputThresholds
		{
			// Token: 0x040000FC RID: 252
			public const int LeftThumbDeadzone = 7849;

			// Token: 0x040000FD RID: 253
			public const int RightThumbDeadzone = 8689;

			// Token: 0x040000FE RID: 254
			public const int TriggerThreshold = 30;
		}

		// Token: 0x0200003A RID: 58
		private struct XInputGamePad
		{
			// Token: 0x040000FF RID: 255
			public XInputJoystick.XInputButtons Buttons;

			// Token: 0x04000100 RID: 256
			public byte LeftTrigger;

			// Token: 0x04000101 RID: 257
			public byte RightTrigger;

			// Token: 0x04000102 RID: 258
			public short ThumbLX;

			// Token: 0x04000103 RID: 259
			public short ThumbLY;

			// Token: 0x04000104 RID: 260
			public short ThumbRX;

			// Token: 0x04000105 RID: 261
			public short ThumbRY;
		}

		// Token: 0x0200003B RID: 59
		private struct XInputState
		{
			// Token: 0x04000106 RID: 262
			public int PacketNumber;

			// Token: 0x04000107 RID: 263
			public XInputJoystick.XInputGamePad GamePad;
		}

		// Token: 0x0200003C RID: 60
		private struct XInputVibration
		{
			// Token: 0x04000108 RID: 264
			public short LeftMotorSpeed;

			// Token: 0x04000109 RID: 265
			public short RightMotorSpeed;
		}

		// Token: 0x0200003D RID: 61
		private struct XInputDeviceCapabilities
		{
			// Token: 0x0400010A RID: 266
			public XInputJoystick.XInputDeviceType Type;

			// Token: 0x0400010B RID: 267
			public XInputJoystick.XInputDeviceSubType SubType;

			// Token: 0x0400010C RID: 268
			public short Flags;

			// Token: 0x0400010D RID: 269
			public XInputJoystick.XInputGamePad GamePad;

			// Token: 0x0400010E RID: 270
			public XInputJoystick.XInputVibration Vibration;
		}

		// Token: 0x0200003E RID: 62
		private struct XInputBatteryInformation
		{
			// Token: 0x0400010F RID: 271
			public XInputJoystick.XInputBatteryType Type;

			// Token: 0x04000110 RID: 272
			public XInputJoystick.XInputBatteryLevel Level;
		}

		// Token: 0x0200003F RID: 63
		private class XInput : IDisposable
		{
			// Token: 0x060004D7 RID: 1239 RVA: 0x00014694 File Offset: 0x00012894
			internal XInput()
			{
				this.dll = Functions.LoadLibrary("XINPUT1_4");
				if (this.dll == IntPtr.Zero)
				{
					this.dll = Functions.LoadLibrary("XINPUT1_3");
				}
				if (this.dll == IntPtr.Zero)
				{
					this.dll = Functions.LoadLibrary("XINPUT1_2");
				}
				if (this.dll == IntPtr.Zero)
				{
					this.dll = Functions.LoadLibrary("XINPUT1_1");
				}
				if (this.dll == IntPtr.Zero)
				{
					this.dll = Functions.LoadLibrary("XINPUT9_1_0");
				}
				if (this.dll == IntPtr.Zero)
				{
					throw new NotSupportedException("XInput was not found on this platform");
				}
				this.GetCapabilities = (XInputJoystick.XInput.XInputGetCapabilities)this.Load("XInputGetCapabilities", typeof(XInputJoystick.XInput.XInputGetCapabilities));
				this.GetState = (XInputJoystick.XInput.XInputGetState)this.Load("XInputGetState", typeof(XInputJoystick.XInput.XInputGetState));
				this.SetState = (XInputJoystick.XInput.XInputSetState)this.Load("XInputSetState", typeof(XInputJoystick.XInput.XInputSetState));
			}

			// Token: 0x060004D8 RID: 1240 RVA: 0x000147BC File Offset: 0x000129BC
			private Delegate Load(string name, Type type)
			{
				IntPtr procAddress = Functions.GetProcAddress(this.dll, name);
				if (procAddress != IntPtr.Zero)
				{
					return Marshal.GetDelegateForFunctionPointer(procAddress, type);
				}
				return null;
			}

			// Token: 0x060004D9 RID: 1241 RVA: 0x000147EC File Offset: 0x000129EC
			public void Dispose()
			{
				this.Dispose(true);
				GC.SuppressFinalize(this);
			}

			// Token: 0x060004DA RID: 1242 RVA: 0x000147FC File Offset: 0x000129FC
			private void Dispose(bool manual)
			{
				if (manual && this.dll != IntPtr.Zero)
				{
					Functions.FreeLibrary(this.dll);
					this.dll = IntPtr.Zero;
				}
			}

			// Token: 0x04000111 RID: 273
			private IntPtr dll;

			// Token: 0x04000112 RID: 274
			internal XInputJoystick.XInput.XInputGetCapabilities GetCapabilities;

			// Token: 0x04000113 RID: 275
			internal XInputJoystick.XInput.XInputGetState GetState;

			// Token: 0x04000114 RID: 276
			internal XInputJoystick.XInput.XInputSetState SetState;

			// Token: 0x02000040 RID: 64
			// (Invoke) Token: 0x060004DC RID: 1244
			[SuppressUnmanagedCodeSecurity]
			internal delegate XInputJoystick.XInputErrorCode XInputGetCapabilities(XInputJoystick.XInputUserIndex dwUserIndex, XInputJoystick.XInputCapabilitiesFlags dwFlags, out XInputJoystick.XInputDeviceCapabilities pCapabilities);

			// Token: 0x02000041 RID: 65
			// (Invoke) Token: 0x060004E0 RID: 1248
			[SuppressUnmanagedCodeSecurity]
			internal delegate XInputJoystick.XInputErrorCode XInputGetState(XInputJoystick.XInputUserIndex dwUserIndex, out XInputJoystick.XInputState pState);

			// Token: 0x02000042 RID: 66
			// (Invoke) Token: 0x060004E4 RID: 1252
			[SuppressUnmanagedCodeSecurity]
			internal delegate XInputJoystick.XInputErrorCode XInputSetState(XInputJoystick.XInputUserIndex dwUserIndex, ref XInputJoystick.XInputVibration pVibration);
		}
	}
}
