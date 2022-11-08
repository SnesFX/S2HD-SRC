using System;
using SonicOrca.Graphics;

namespace SonicOrca
{
	// Token: 0x02000096 RID: 150
	public interface IVideoSettings
	{
		// Token: 0x17000091 RID: 145
		// (get) Token: 0x060004E2 RID: 1250
		VideoMode Mode { get; }

		// Token: 0x17000092 RID: 146
		// (get) Token: 0x060004E3 RID: 1251
		Resolution Resolution { get; }

		// Token: 0x17000093 RID: 147
		// (get) Token: 0x060004E4 RID: 1252
		bool EnableShadows { get; }

		// Token: 0x17000094 RID: 148
		// (get) Token: 0x060004E5 RID: 1253
		bool EnableHeatEffects { get; }

		// Token: 0x17000095 RID: 149
		// (get) Token: 0x060004E6 RID: 1254
		bool EnableWaterEffects { get; }
	}
}
