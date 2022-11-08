using System;

namespace OpenTK.Input
{
	// Token: 0x02000523 RID: 1315
	public sealed class JoystickAxisCollection
	{
		// Token: 0x06003DA1 RID: 15777 RVA: 0x000A1FD0 File Offset: 0x000A01D0
		internal JoystickAxisCollection(int numAxes)
		{
			if (numAxes < 0)
			{
				throw new ArgumentOutOfRangeException("numAxes");
			}
			this.axis_state = new float[numAxes];
		}

		// Token: 0x1700029C RID: 668
		public float this[int index]
		{
			get
			{
				return this.axis_state[index];
			}
			internal set
			{
				this.axis_state[index] = value;
			}
		}

		// Token: 0x1700029D RID: 669
		public float this[JoystickAxis axis]
		{
			get
			{
				return this.axis_state[(int)axis];
			}
			internal set
			{
				this.axis_state[(int)axis] = value;
			}
		}

		// Token: 0x1700029E RID: 670
		// (get) Token: 0x06003DA6 RID: 15782 RVA: 0x000A2024 File Offset: 0x000A0224
		public int Count
		{
			get
			{
				return this.axis_state.Length;
			}
		}

		// Token: 0x04004DCC RID: 19916
		private float[] axis_state;
	}
}
