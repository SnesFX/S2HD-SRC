using System;

namespace OpenTK.Input
{
	// Token: 0x02000521 RID: 1313
	public class JoystickMoveEventArgs : JoystickEventArgs
	{
		// Token: 0x06003D94 RID: 15764 RVA: 0x000A1F14 File Offset: 0x000A0114
		public JoystickMoveEventArgs(JoystickAxis axis, float value, float delta)
		{
			this.axis = axis;
			this.value = value;
			this.delta = delta;
		}

		// Token: 0x17000296 RID: 662
		// (get) Token: 0x06003D95 RID: 15765 RVA: 0x000A1F34 File Offset: 0x000A0134
		// (set) Token: 0x06003D96 RID: 15766 RVA: 0x000A1F3C File Offset: 0x000A013C
		public JoystickAxis Axis
		{
			get
			{
				return this.axis;
			}
			internal set
			{
				this.axis = value;
			}
		}

		// Token: 0x17000297 RID: 663
		// (get) Token: 0x06003D97 RID: 15767 RVA: 0x000A1F48 File Offset: 0x000A0148
		// (set) Token: 0x06003D98 RID: 15768 RVA: 0x000A1F50 File Offset: 0x000A0150
		public float Value
		{
			get
			{
				return this.value;
			}
			internal set
			{
				this.value = value;
			}
		}

		// Token: 0x17000298 RID: 664
		// (get) Token: 0x06003D99 RID: 15769 RVA: 0x000A1F5C File Offset: 0x000A015C
		// (set) Token: 0x06003D9A RID: 15770 RVA: 0x000A1F64 File Offset: 0x000A0164
		public float Delta
		{
			get
			{
				return this.delta;
			}
			internal set
			{
				this.delta = value;
			}
		}

		// Token: 0x04004DC8 RID: 19912
		private JoystickAxis axis;

		// Token: 0x04004DC9 RID: 19913
		private float value;

		// Token: 0x04004DCA RID: 19914
		private float delta;
	}
}
