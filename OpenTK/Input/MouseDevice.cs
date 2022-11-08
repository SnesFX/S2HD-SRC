using System;
using System.Drawing;

namespace OpenTK.Input
{
	// Token: 0x02000514 RID: 1300
	public sealed class MouseDevice : IInputDevice
	{
		// Token: 0x17000274 RID: 628
		// (get) Token: 0x06003D29 RID: 15657 RVA: 0x000A1260 File Offset: 0x0009F460
		// (set) Token: 0x06003D2A RID: 15658 RVA: 0x000A1268 File Offset: 0x0009F468
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

		// Token: 0x17000275 RID: 629
		// (get) Token: 0x06003D2B RID: 15659 RVA: 0x000A1274 File Offset: 0x0009F474
		public InputDeviceType DeviceType
		{
			get
			{
				return InputDeviceType.Mouse;
			}
		}

		// Token: 0x17000276 RID: 630
		// (get) Token: 0x06003D2C RID: 15660 RVA: 0x000A1278 File Offset: 0x0009F478
		// (set) Token: 0x06003D2D RID: 15661 RVA: 0x000A1280 File Offset: 0x0009F480
		public int NumberOfButtons
		{
			get
			{
				return this.numButtons;
			}
			internal set
			{
				this.numButtons = value;
			}
		}

		// Token: 0x17000277 RID: 631
		// (get) Token: 0x06003D2E RID: 15662 RVA: 0x000A128C File Offset: 0x0009F48C
		// (set) Token: 0x06003D2F RID: 15663 RVA: 0x000A1294 File Offset: 0x0009F494
		public int NumberOfWheels
		{
			get
			{
				return this.numWheels;
			}
			internal set
			{
				this.numWheels = value;
			}
		}

		// Token: 0x17000278 RID: 632
		// (get) Token: 0x06003D30 RID: 15664 RVA: 0x000A12A0 File Offset: 0x0009F4A0
		// (set) Token: 0x06003D31 RID: 15665 RVA: 0x000A12A8 File Offset: 0x0009F4A8
		public IntPtr DeviceID
		{
			get
			{
				return this.id;
			}
			internal set
			{
				this.id = value;
			}
		}

		// Token: 0x17000279 RID: 633
		// (get) Token: 0x06003D32 RID: 15666 RVA: 0x000A12B4 File Offset: 0x0009F4B4
		public int Wheel
		{
			get
			{
				return this.state.Wheel;
			}
		}

		// Token: 0x1700027A RID: 634
		// (get) Token: 0x06003D33 RID: 15667 RVA: 0x000A12C4 File Offset: 0x0009F4C4
		public float WheelPrecise
		{
			get
			{
				return this.state.WheelPrecise;
			}
		}

		// Token: 0x1700027B RID: 635
		// (get) Token: 0x06003D34 RID: 15668 RVA: 0x000A12D4 File Offset: 0x0009F4D4
		public int X
		{
			get
			{
				return this.state.X;
			}
		}

		// Token: 0x1700027C RID: 636
		// (get) Token: 0x06003D35 RID: 15669 RVA: 0x000A12E4 File Offset: 0x0009F4E4
		public int Y
		{
			get
			{
				return this.state.Y;
			}
		}

		// Token: 0x1700027D RID: 637
		public bool this[MouseButton button]
		{
			get
			{
				return this.state[button];
			}
			internal set
			{
				this.state[button] = value;
			}
		}

		// Token: 0x06003D38 RID: 15672 RVA: 0x000A1314 File Offset: 0x0009F514
		internal void HandleMouseDown(object sender, MouseButtonEventArgs e)
		{
			this.state = e.Mouse;
			this.ButtonDown(this, e);
		}

		// Token: 0x06003D39 RID: 15673 RVA: 0x000A1330 File Offset: 0x0009F530
		internal void HandleMouseUp(object sender, MouseButtonEventArgs e)
		{
			this.state = e.Mouse;
			this.ButtonUp(this, e);
		}

		// Token: 0x06003D3A RID: 15674 RVA: 0x000A134C File Offset: 0x0009F54C
		internal void HandleMouseMove(object sender, MouseMoveEventArgs e)
		{
			this.state = e.Mouse;
			this.Move(this, e);
		}

		// Token: 0x06003D3B RID: 15675 RVA: 0x000A1368 File Offset: 0x0009F568
		internal void HandleMouseWheel(object sender, MouseWheelEventArgs e)
		{
			this.state = e.Mouse;
			this.WheelChanged(this, e);
		}

		// Token: 0x14000047 RID: 71
		// (add) Token: 0x06003D3C RID: 15676 RVA: 0x000A1384 File Offset: 0x0009F584
		// (remove) Token: 0x06003D3D RID: 15677 RVA: 0x000A13BC File Offset: 0x0009F5BC
		public event EventHandler<MouseMoveEventArgs> Move = delegate(object param0, MouseMoveEventArgs param1)
		{
		};

		// Token: 0x14000048 RID: 72
		// (add) Token: 0x06003D3E RID: 15678 RVA: 0x000A13F4 File Offset: 0x0009F5F4
		// (remove) Token: 0x06003D3F RID: 15679 RVA: 0x000A142C File Offset: 0x0009F62C
		public event EventHandler<MouseButtonEventArgs> ButtonDown = delegate(object param0, MouseButtonEventArgs param1)
		{
		};

		// Token: 0x14000049 RID: 73
		// (add) Token: 0x06003D40 RID: 15680 RVA: 0x000A1464 File Offset: 0x0009F664
		// (remove) Token: 0x06003D41 RID: 15681 RVA: 0x000A149C File Offset: 0x0009F69C
		public event EventHandler<MouseButtonEventArgs> ButtonUp = delegate(object param0, MouseButtonEventArgs param1)
		{
		};

		// Token: 0x1400004A RID: 74
		// (add) Token: 0x06003D42 RID: 15682 RVA: 0x000A14D4 File Offset: 0x0009F6D4
		// (remove) Token: 0x06003D43 RID: 15683 RVA: 0x000A150C File Offset: 0x0009F70C
		public event EventHandler<MouseWheelEventArgs> WheelChanged = delegate(object param0, MouseWheelEventArgs param1)
		{
		};

		// Token: 0x06003D44 RID: 15684 RVA: 0x000A1544 File Offset: 0x0009F744
		public override int GetHashCode()
		{
			return this.numButtons ^ this.numWheels ^ this.id.GetHashCode() ^ this.description.GetHashCode();
		}

		// Token: 0x06003D45 RID: 15685 RVA: 0x000A1574 File Offset: 0x0009F774
		public override string ToString()
		{
			return string.Format("ID: {0} ({1}). Buttons: {2}, Wheels: {3}", new object[]
			{
				this.DeviceID,
				this.Description,
				this.NumberOfButtons,
				this.NumberOfWheels
			});
		}

		// Token: 0x1700027E RID: 638
		// (get) Token: 0x06003D46 RID: 15686 RVA: 0x000A15C8 File Offset: 0x0009F7C8
		[Obsolete("WheelDelta is only defined for a single WheelChanged event.  Use the OpenTK.Input.MouseWheelEventArgs::Delta property with the OpenTK.Input.MouseDevice::WheelChanged event.", false)]
		public int WheelDelta
		{
			get
			{
				int result = (int)Math.Round((double)(this.state.WheelPrecise - (float)this.wheel_last_accessed), MidpointRounding.AwayFromZero);
				this.wheel_last_accessed = this.state.Wheel;
				return result;
			}
		}

		// Token: 0x1700027F RID: 639
		// (get) Token: 0x06003D47 RID: 15687 RVA: 0x000A1604 File Offset: 0x0009F804
		[Obsolete("XDelta is only defined for a single Move event.  Use the OpenTK.Input.MouseMoveEventArgs::Delta property with the OpenTK.Input.MouseDevice::Move event.", false)]
		public int XDelta
		{
			get
			{
				int result = this.state.X - this.pos_last_accessed.X;
				this.pos_last_accessed.X = this.state.X;
				return result;
			}
		}

		// Token: 0x17000280 RID: 640
		// (get) Token: 0x06003D48 RID: 15688 RVA: 0x000A1640 File Offset: 0x0009F840
		[Obsolete("YDelta is only defined for a single Move event.  Use the OpenTK.Input.MouseMoveEventArgs::Delta property with the OpenTK.Input.MouseDevice::Move event.", false)]
		public int YDelta
		{
			get
			{
				int result = this.state.Y - this.pos_last_accessed.Y;
				this.pos_last_accessed.Y = this.state.Y;
				return result;
			}
		}

		// Token: 0x04004CF8 RID: 19704
		private string description;

		// Token: 0x04004CF9 RID: 19705
		private IntPtr id;

		// Token: 0x04004CFA RID: 19706
		private int numButtons;

		// Token: 0x04004CFB RID: 19707
		private int numWheels;

		// Token: 0x04004CFC RID: 19708
		private MouseState state;

		// Token: 0x04004CFD RID: 19709
		private int wheel_last_accessed;

		// Token: 0x04004CFE RID: 19710
		private Point pos_last_accessed = default(Point);
	}
}
