using System;

namespace OpenTK.Input
{
	// Token: 0x02000011 RID: 17
	public struct JoystickCapabilities : IEquatable<JoystickCapabilities>
	{
		// Token: 0x06000049 RID: 73 RVA: 0x00002894 File Offset: 0x00000A94
		internal JoystickCapabilities(int axis_count, int button_count, int hat_count, bool is_connected)
		{
			if (axis_count < 0 || axis_count > 11)
			{
				throw new ArgumentOutOfRangeException("axis_count");
			}
			if (button_count < 0 || button_count > 32)
			{
				throw new ArgumentOutOfRangeException("axis_count");
			}
			if (hat_count < 0 || hat_count > 4)
			{
				throw new ArgumentOutOfRangeException("hat_count");
			}
			this.axis_count = (byte)axis_count;
			this.button_count = (byte)button_count;
			this.hat_count = (byte)hat_count;
			this.is_connected = is_connected;
		}

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x0600004A RID: 74 RVA: 0x000028FC File Offset: 0x00000AFC
		public int AxisCount
		{
			get
			{
				return (int)this.axis_count;
			}
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x0600004B RID: 75 RVA: 0x00002904 File Offset: 0x00000B04
		public int ButtonCount
		{
			get
			{
				return (int)this.button_count;
			}
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x0600004C RID: 76 RVA: 0x0000290C File Offset: 0x00000B0C
		public int HatCount
		{
			get
			{
				return (int)this.hat_count;
			}
		}

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x0600004D RID: 77 RVA: 0x00002914 File Offset: 0x00000B14
		public bool IsConnected
		{
			get
			{
				return this.is_connected;
			}
		}

		// Token: 0x0600004E RID: 78 RVA: 0x0000291C File Offset: 0x00000B1C
		public override string ToString()
		{
			return string.Format("{{Axes: {0}; Buttons: {1}; Hats: {2}; IsConnected: {2}}}", new object[]
			{
				this.AxisCount,
				this.ButtonCount,
				this.HatCount,
				this.IsConnected
			});
		}

		// Token: 0x0600004F RID: 79 RVA: 0x00002974 File Offset: 0x00000B74
		public override int GetHashCode()
		{
			return this.AxisCount.GetHashCode() ^ this.ButtonCount.GetHashCode() ^ this.HatCount.GetHashCode() ^ this.IsConnected.GetHashCode();
		}

		// Token: 0x06000050 RID: 80 RVA: 0x000029BC File Offset: 0x00000BBC
		public override bool Equals(object obj)
		{
			return obj is JoystickCapabilities && this.Equals((JoystickCapabilities)obj);
		}

		// Token: 0x06000051 RID: 81 RVA: 0x000029D4 File Offset: 0x00000BD4
		public bool Equals(JoystickCapabilities other)
		{
			return this.AxisCount == other.AxisCount && this.ButtonCount == other.ButtonCount && this.HatCount == other.HatCount && this.IsConnected == other.IsConnected;
		}

		// Token: 0x0400005D RID: 93
		private byte axis_count;

		// Token: 0x0400005E RID: 94
		private byte button_count;

		// Token: 0x0400005F RID: 95
		private byte hat_count;

		// Token: 0x04000060 RID: 96
		private bool is_connected;
	}
}
