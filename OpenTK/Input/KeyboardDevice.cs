using System;

namespace OpenTK.Input
{
	// Token: 0x02000519 RID: 1305
	public sealed class KeyboardDevice : IInputDevice
	{
		// Token: 0x06003D51 RID: 15697 RVA: 0x000A1738 File Offset: 0x0009F938
		internal KeyboardDevice()
		{
		}

		// Token: 0x17000283 RID: 643
		public bool this[Key key]
		{
			get
			{
				return this.state[key];
			}
		}

		// Token: 0x17000284 RID: 644
		[CLSCompliant(false)]
		public bool this[uint scancode]
		{
			get
			{
				return scancode < 131U && this.state[(Key)scancode];
			}
		}

		// Token: 0x17000285 RID: 645
		// (get) Token: 0x06003D54 RID: 15700 RVA: 0x000A17BC File Offset: 0x0009F9BC
		// (set) Token: 0x06003D55 RID: 15701 RVA: 0x000A17C4 File Offset: 0x0009F9C4
		public int NumberOfKeys
		{
			get
			{
				return this.numKeys;
			}
			internal set
			{
				this.numKeys = value;
			}
		}

		// Token: 0x17000286 RID: 646
		// (get) Token: 0x06003D56 RID: 15702 RVA: 0x000A17D0 File Offset: 0x0009F9D0
		// (set) Token: 0x06003D57 RID: 15703 RVA: 0x000A17D8 File Offset: 0x0009F9D8
		public int NumberOfFunctionKeys
		{
			get
			{
				return this.numFKeys;
			}
			internal set
			{
				this.numFKeys = value;
			}
		}

		// Token: 0x17000287 RID: 647
		// (get) Token: 0x06003D58 RID: 15704 RVA: 0x000A17E4 File Offset: 0x0009F9E4
		// (set) Token: 0x06003D59 RID: 15705 RVA: 0x000A17EC File Offset: 0x0009F9EC
		public int NumberOfLeds
		{
			get
			{
				return this.numLeds;
			}
			internal set
			{
				this.numLeds = value;
			}
		}

		// Token: 0x17000288 RID: 648
		// (get) Token: 0x06003D5A RID: 15706 RVA: 0x000A17F8 File Offset: 0x0009F9F8
		// (set) Token: 0x06003D5B RID: 15707 RVA: 0x000A1800 File Offset: 0x0009FA00
		public IntPtr DeviceID
		{
			get
			{
				return this.devID;
			}
			internal set
			{
				this.devID = value;
			}
		}

		// Token: 0x17000289 RID: 649
		// (get) Token: 0x06003D5C RID: 15708 RVA: 0x000A180C File Offset: 0x0009FA0C
		// (set) Token: 0x06003D5D RID: 15709 RVA: 0x000A1814 File Offset: 0x0009FA14
		public bool KeyRepeat
		{
			get
			{
				return this.repeat;
			}
			set
			{
				this.repeat = value;
			}
		}

		// Token: 0x1400004B RID: 75
		// (add) Token: 0x06003D5E RID: 15710 RVA: 0x000A1820 File Offset: 0x0009FA20
		// (remove) Token: 0x06003D5F RID: 15711 RVA: 0x000A1858 File Offset: 0x0009FA58
		public event EventHandler<KeyboardKeyEventArgs> KeyDown = delegate(object param0, KeyboardKeyEventArgs param1)
		{
		};

		// Token: 0x1400004C RID: 76
		// (add) Token: 0x06003D60 RID: 15712 RVA: 0x000A1890 File Offset: 0x0009FA90
		// (remove) Token: 0x06003D61 RID: 15713 RVA: 0x000A18C8 File Offset: 0x0009FAC8
		public event EventHandler<KeyboardKeyEventArgs> KeyUp = delegate(object param0, KeyboardKeyEventArgs param1)
		{
		};

		// Token: 0x1700028A RID: 650
		// (get) Token: 0x06003D62 RID: 15714 RVA: 0x000A1900 File Offset: 0x0009FB00
		// (set) Token: 0x06003D63 RID: 15715 RVA: 0x000A1908 File Offset: 0x0009FB08
		public string Description
		{
			get
			{
				return this.description;
			}
			internal set
			{
				this.description = value;
			}
		}

		// Token: 0x1700028B RID: 651
		// (get) Token: 0x06003D64 RID: 15716 RVA: 0x000A1914 File Offset: 0x0009FB14
		public InputDeviceType DeviceType
		{
			get
			{
				return InputDeviceType.Keyboard;
			}
		}

		// Token: 0x06003D65 RID: 15717 RVA: 0x000A1918 File Offset: 0x0009FB18
		public override int GetHashCode()
		{
			return this.numKeys ^ this.numFKeys ^ this.numLeds ^ this.devID.GetHashCode() ^ this.description.GetHashCode();
		}

		// Token: 0x06003D66 RID: 15718 RVA: 0x000A194C File Offset: 0x0009FB4C
		public override string ToString()
		{
			return string.Format("ID: {0} ({1}). Keys: {2}, Function keys: {3}, Leds: {4}", new object[]
			{
				this.DeviceID,
				this.Description,
				this.NumberOfKeys,
				this.NumberOfFunctionKeys,
				this.NumberOfLeds
			});
		}

		// Token: 0x06003D67 RID: 15719 RVA: 0x000A19AC File Offset: 0x0009FBAC
		internal void HandleKeyDown(object sender, KeyboardKeyEventArgs e)
		{
			this.state = e.Keyboard;
			this.KeyDown(this, e);
		}

		// Token: 0x06003D68 RID: 15720 RVA: 0x000A19C8 File Offset: 0x0009FBC8
		internal void HandleKeyUp(object sender, KeyboardKeyEventArgs e)
		{
			this.state = e.Keyboard;
			this.KeyUp(this, e);
		}

		// Token: 0x04004D9B RID: 19867
		private string description;

		// Token: 0x04004D9C RID: 19868
		private int numKeys;

		// Token: 0x04004D9D RID: 19869
		private int numFKeys;

		// Token: 0x04004D9E RID: 19870
		private int numLeds;

		// Token: 0x04004D9F RID: 19871
		private IntPtr devID;

		// Token: 0x04004DA0 RID: 19872
		private bool repeat;

		// Token: 0x04004DA1 RID: 19873
		private KeyboardState state;
	}
}
