using System;
using SonicOrca.Audio;
using SonicOrca.Graphics;

namespace S2HD.Menu
{
	// Token: 0x020000C5 RID: 197
	internal interface ISettingUIResources
	{
		// Token: 0x170000AC RID: 172
		// (get) Token: 0x060004C8 RID: 1224
		Font Font { get; }

		// Token: 0x170000AD RID: 173
		// (get) Token: 0x060004C9 RID: 1225
		ITexture AudioSliderEmptyTexture { get; }

		// Token: 0x170000AE RID: 174
		// (get) Token: 0x060004CA RID: 1226
		ITexture AudioSliderSilverTexture { get; }

		// Token: 0x170000AF RID: 175
		// (get) Token: 0x060004CB RID: 1227
		ITexture AudioSliderGoldTexture { get; }

		// Token: 0x170000B0 RID: 176
		// (get) Token: 0x060004CC RID: 1228
		// (set) Token: 0x060004CD RID: 1229
		ITexture SelectionBar { get; set; }

		// Token: 0x170000B1 RID: 177
		// (get) Token: 0x060004CE RID: 1230
		// (set) Token: 0x060004CF RID: 1231
		Sample NavigateSample { get; set; }

		// Token: 0x170000B2 RID: 178
		// (get) Token: 0x060004D0 RID: 1232
		// (set) Token: 0x060004D1 RID: 1233
		Sample ConfirmSample { get; set; }

		// Token: 0x170000B3 RID: 179
		// (get) Token: 0x060004D2 RID: 1234
		// (set) Token: 0x060004D3 RID: 1235
		Sample CancelSample { get; set; }
	}
}
