using System;

namespace OpenTK.Input
{
	// Token: 0x02000B00 RID: 2816
	internal struct GamePadConfigurationTarget
	{
		// Token: 0x0600597A RID: 22906 RVA: 0x000F3204 File Offset: 0x000F1404
		public GamePadConfigurationTarget(Buttons button)
		{
			this = default(GamePadConfigurationTarget);
			this.Type = ConfigurationType.Button;
			this.map_button = new Buttons?(button);
		}

		// Token: 0x0600597B RID: 22907 RVA: 0x000F3220 File Offset: 0x000F1420
		public GamePadConfigurationTarget(GamePadAxes axis)
		{
			this = default(GamePadConfigurationTarget);
			this.Type = ConfigurationType.Axis;
			this.map_axis = new GamePadAxes?(axis);
		}

		// Token: 0x17000482 RID: 1154
		// (get) Token: 0x0600597C RID: 22908 RVA: 0x000F323C File Offset: 0x000F143C
		// (set) Token: 0x0600597D RID: 22909 RVA: 0x000F3244 File Offset: 0x000F1444
		public ConfigurationType Type
		{
			get
			{
				return this.map_type;
			}
			private set
			{
				this.map_type = value;
			}
		}

		// Token: 0x17000483 RID: 1155
		// (get) Token: 0x0600597E RID: 22910 RVA: 0x000F3250 File Offset: 0x000F1450
		// (set) Token: 0x0600597F RID: 22911 RVA: 0x000F3260 File Offset: 0x000F1460
		public GamePadAxes Axis
		{
			get
			{
				return this.map_axis.Value;
			}
			private set
			{
				this.map_axis = new GamePadAxes?(value);
			}
		}

		// Token: 0x17000484 RID: 1156
		// (get) Token: 0x06005980 RID: 22912 RVA: 0x000F3270 File Offset: 0x000F1470
		// (set) Token: 0x06005981 RID: 22913 RVA: 0x000F3280 File Offset: 0x000F1480
		public Buttons Button
		{
			get
			{
				return this.map_button.Value;
			}
			private set
			{
				this.map_button = new Buttons?(value);
			}
		}

		// Token: 0x0400B4BC RID: 46268
		private ConfigurationType map_type;

		// Token: 0x0400B4BD RID: 46269
		private Buttons? map_button;

		// Token: 0x0400B4BE RID: 46270
		private GamePadAxes? map_axis;
	}
}
