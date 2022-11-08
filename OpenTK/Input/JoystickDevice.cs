using System;

namespace OpenTK.Input
{
	// Token: 0x0200051D RID: 1309
	public abstract class JoystickDevice : IInputDevice
	{
		// Token: 0x06003D80 RID: 15744 RVA: 0x000A1C84 File Offset: 0x0009FE84
		internal JoystickDevice(int id, int axes, int buttons)
		{
			if (axes < 0)
			{
				throw new ArgumentOutOfRangeException("axes");
			}
			if (buttons < 0)
			{
				throw new ArgumentOutOfRangeException("buttons");
			}
			this.Id = id;
			this.axis_collection = new JoystickAxisCollection(axes);
			this.button_collection = new JoystickButtonCollection(buttons);
		}

		// Token: 0x1700028F RID: 655
		// (get) Token: 0x06003D81 RID: 15745 RVA: 0x000A1D60 File Offset: 0x0009FF60
		public JoystickAxisCollection Axis
		{
			get
			{
				return this.axis_collection;
			}
		}

		// Token: 0x17000290 RID: 656
		// (get) Token: 0x06003D82 RID: 15746 RVA: 0x000A1D68 File Offset: 0x0009FF68
		public JoystickButtonCollection Button
		{
			get
			{
				return this.button_collection;
			}
		}

		// Token: 0x17000291 RID: 657
		// (get) Token: 0x06003D83 RID: 15747 RVA: 0x000A1D70 File Offset: 0x0009FF70
		// (set) Token: 0x06003D84 RID: 15748 RVA: 0x000A1D78 File Offset: 0x0009FF78
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

		// Token: 0x17000292 RID: 658
		// (get) Token: 0x06003D85 RID: 15749 RVA: 0x000A1D84 File Offset: 0x0009FF84
		public InputDeviceType DeviceType
		{
			get
			{
				return InputDeviceType.Hid;
			}
		}

		// Token: 0x17000293 RID: 659
		// (get) Token: 0x06003D86 RID: 15750 RVA: 0x000A1D88 File Offset: 0x0009FF88
		// (set) Token: 0x06003D87 RID: 15751 RVA: 0x000A1D90 File Offset: 0x0009FF90
		internal int Id
		{
			get
			{
				return this.id;
			}
			set
			{
				this.id = value;
			}
		}

		// Token: 0x06003D88 RID: 15752 RVA: 0x000A1D9C File Offset: 0x0009FF9C
		internal void SetAxis(JoystickAxis axis, float value)
		{
			if (axis < (JoystickAxis)this.axis_collection.Count)
			{
				this.move_args.Axis = axis;
				this.move_args.Delta = this.move_args.Value - value;
				JoystickAxisCollection joystickAxisCollection = this.axis_collection;
				this.move_args.Value = value;
				joystickAxisCollection[axis] = value;
				this.Move(this, this.move_args);
			}
		}

		// Token: 0x06003D89 RID: 15753 RVA: 0x000A1E08 File Offset: 0x000A0008
		internal void SetButton(JoystickButton button, bool value)
		{
			if (button < (JoystickButton)this.button_collection.Count && this.button_collection[button] != value)
			{
				this.button_args.Button = button;
				JoystickButtonCollection joystickButtonCollection = this.button_collection;
				this.button_args.Pressed = value;
				joystickButtonCollection[button] = value;
				if (value)
				{
					this.ButtonDown(this, this.button_args);
					return;
				}
				this.ButtonUp(this, this.button_args);
			}
		}

		// Token: 0x04004DB9 RID: 19897
		private int id;

		// Token: 0x04004DBA RID: 19898
		private string description;

		// Token: 0x04004DBB RID: 19899
		private JoystickAxisCollection axis_collection;

		// Token: 0x04004DBC RID: 19900
		private JoystickButtonCollection button_collection;

		// Token: 0x04004DBD RID: 19901
		private JoystickMoveEventArgs move_args = new JoystickMoveEventArgs(JoystickAxis.Axis0, 0f, 0f);

		// Token: 0x04004DBE RID: 19902
		private JoystickButtonEventArgs button_args = new JoystickButtonEventArgs(JoystickButton.Button0, false);

		// Token: 0x04004DBF RID: 19903
		public EventHandler<JoystickMoveEventArgs> Move = delegate(object sender, JoystickMoveEventArgs e)
		{
		};

		// Token: 0x04004DC0 RID: 19904
		public EventHandler<JoystickButtonEventArgs> ButtonDown = delegate(object sender, JoystickButtonEventArgs e)
		{
		};

		// Token: 0x04004DC1 RID: 19905
		public EventHandler<JoystickButtonEventArgs> ButtonUp = delegate(object sender, JoystickButtonEventArgs e)
		{
		};
	}
}
