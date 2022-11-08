using System;

namespace S2HD.Menu
{
	// Token: 0x020000BE RID: 190
	internal class AudioSliderOptionSetting : IAudioSliderSetting, ISetting
	{
		// Token: 0x1700009F RID: 159
		// (get) Token: 0x06000480 RID: 1152 RVA: 0x0001E385 File Offset: 0x0001C585
		public string Name { get; }

		// Token: 0x170000A0 RID: 160
		// (get) Token: 0x06000481 RID: 1153 RVA: 0x0001E38D File Offset: 0x0001C58D
		// (set) Token: 0x06000482 RID: 1154 RVA: 0x0001E395 File Offset: 0x0001C595
		public double Value { get; set; }

		// Token: 0x06000483 RID: 1155 RVA: 0x0001E39E File Offset: 0x0001C59E
		public AudioSliderOptionSetting(string name, double value)
		{
			this.Name = name;
			this.Value = value;
		}
	}
}
