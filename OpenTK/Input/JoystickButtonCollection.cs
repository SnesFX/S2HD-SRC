using System;

namespace OpenTK.Input
{
	// Token: 0x02000522 RID: 1314
	public sealed class JoystickButtonCollection
	{
		// Token: 0x06003D9B RID: 15771 RVA: 0x000A1F70 File Offset: 0x000A0170
		internal JoystickButtonCollection(int numButtons)
		{
			if (numButtons < 0)
			{
				throw new ArgumentOutOfRangeException("numButtons");
			}
			this.button_state = new bool[numButtons];
		}

		// Token: 0x17000299 RID: 665
		public bool this[int index]
		{
			get
			{
				return this.button_state[index];
			}
			internal set
			{
				this.button_state[index] = value;
			}
		}

		// Token: 0x1700029A RID: 666
		public bool this[JoystickButton button]
		{
			get
			{
				return this.button_state[(int)button];
			}
			internal set
			{
				this.button_state[(int)button] = value;
			}
		}

		// Token: 0x1700029B RID: 667
		// (get) Token: 0x06003DA0 RID: 15776 RVA: 0x000A1FC4 File Offset: 0x000A01C4
		public int Count
		{
			get
			{
				return this.button_state.Length;
			}
		}

		// Token: 0x04004DCB RID: 19915
		private bool[] button_state;
	}
}
