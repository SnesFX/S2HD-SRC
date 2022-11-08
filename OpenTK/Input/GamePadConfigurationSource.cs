using System;

namespace OpenTK.Input
{
	// Token: 0x02000B02 RID: 2818
	internal struct GamePadConfigurationSource
	{
		// Token: 0x06005982 RID: 22914 RVA: 0x000F3290 File Offset: 0x000F1490
		public GamePadConfigurationSource(JoystickAxis axis)
		{
			this = default(GamePadConfigurationSource);
			this.Type = ConfigurationType.Axis;
			this.Axis = axis;
		}

		// Token: 0x06005983 RID: 22915 RVA: 0x000F32A8 File Offset: 0x000F14A8
		public GamePadConfigurationSource(JoystickButton button)
		{
			this = default(GamePadConfigurationSource);
			this.Type = ConfigurationType.Button;
			this.Button = button;
		}

		// Token: 0x17000485 RID: 1157
		// (get) Token: 0x06005984 RID: 22916 RVA: 0x000F32C0 File Offset: 0x000F14C0
		// (set) Token: 0x06005985 RID: 22917 RVA: 0x000F32C8 File Offset: 0x000F14C8
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

		// Token: 0x17000486 RID: 1158
		// (get) Token: 0x06005986 RID: 22918 RVA: 0x000F32D4 File Offset: 0x000F14D4
		// (set) Token: 0x06005987 RID: 22919 RVA: 0x000F32E4 File Offset: 0x000F14E4
		public JoystickAxis Axis
		{
			get
			{
				return this.map_axis.Value;
			}
			private set
			{
				this.map_axis = new JoystickAxis?(value);
			}
		}

		// Token: 0x17000487 RID: 1159
		// (get) Token: 0x06005988 RID: 22920 RVA: 0x000F32F4 File Offset: 0x000F14F4
		// (set) Token: 0x06005989 RID: 22921 RVA: 0x000F3304 File Offset: 0x000F1504
		public JoystickButton Button
		{
			get
			{
				return this.map_button.Value;
			}
			private set
			{
				this.map_button = new JoystickButton?(value);
			}
		}

		// Token: 0x0400B4C3 RID: 46275
		private ConfigurationType map_type;

		// Token: 0x0400B4C4 RID: 46276
		private JoystickButton? map_button;

		// Token: 0x0400B4C5 RID: 46277
		private JoystickAxis? map_axis;
	}
}
