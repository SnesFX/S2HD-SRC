using System;
using SonicOrca.Audio;
using SonicOrca.Extensions;
using SonicOrca.Graphics;
using SonicOrca.Resources;

namespace S2HD.Menu
{
	// Token: 0x020000C6 RID: 198
	internal class SettingUIResources : IControlResources, ISettingUIResources
	{
		// Token: 0x170000B4 RID: 180
		// (get) Token: 0x060004D4 RID: 1236 RVA: 0x0001FA25 File Offset: 0x0001DC25
		// (set) Token: 0x060004D5 RID: 1237 RVA: 0x0001FA2D File Offset: 0x0001DC2D
		[ResourcePath("SONICORCA/FONTS/IMPACT/REGULAR")]
		public Font Font { get; set; }

		// Token: 0x170000B5 RID: 181
		// (get) Token: 0x060004D6 RID: 1238 RVA: 0x0001FA36 File Offset: 0x0001DC36
		// (set) Token: 0x060004D7 RID: 1239 RVA: 0x0001FA3E File Offset: 0x0001DC3E
		[ResourcePath("SONICORCA/MENU/OPTIONS/AUDIOSLIDER/EMPTY")]
		public ITexture AudioSliderEmptyTexture { get; set; }

		// Token: 0x170000B6 RID: 182
		// (get) Token: 0x060004D8 RID: 1240 RVA: 0x0001FA47 File Offset: 0x0001DC47
		// (set) Token: 0x060004D9 RID: 1241 RVA: 0x0001FA4F File Offset: 0x0001DC4F
		[ResourcePath("SONICORCA/MENU/OPTIONS/AUDIOSLIDER/SILVER")]
		public ITexture AudioSliderSilverTexture { get; set; }

		// Token: 0x170000B7 RID: 183
		// (get) Token: 0x060004DA RID: 1242 RVA: 0x0001FA58 File Offset: 0x0001DC58
		// (set) Token: 0x060004DB RID: 1243 RVA: 0x0001FA60 File Offset: 0x0001DC60
		[ResourcePath("SONICORCA/MENU/OPTIONS/AUDIOSLIDER/GOLD")]
		public ITexture AudioSliderGoldTexture { get; set; }

		// Token: 0x170000B8 RID: 184
		// (get) Token: 0x060004DC RID: 1244 RVA: 0x0001FA69 File Offset: 0x0001DC69
		// (set) Token: 0x060004DD RID: 1245 RVA: 0x0001FA71 File Offset: 0x0001DC71
		[ResourcePath("SONICORCA/SOUND/NAVIGATE/CURSOR")]
		public Sample NavigateSample { get; set; }

		// Token: 0x170000B9 RID: 185
		// (get) Token: 0x060004DE RID: 1246 RVA: 0x0001FA7A File Offset: 0x0001DC7A
		// (set) Token: 0x060004DF RID: 1247 RVA: 0x0001FA82 File Offset: 0x0001DC82
		[ResourcePath("SONICORCA/SOUND/NAVIGATE/YES")]
		public Sample ConfirmSample { get; set; }

		// Token: 0x170000BA RID: 186
		// (get) Token: 0x060004E0 RID: 1248 RVA: 0x0001FA8B File Offset: 0x0001DC8B
		// (set) Token: 0x060004E1 RID: 1249 RVA: 0x0001FA93 File Offset: 0x0001DC93
		[ResourcePath("SONICORCA/SOUND/NAVIGATE/NO")]
		public Sample CancelSample { get; set; }

		// Token: 0x170000BB RID: 187
		// (get) Token: 0x060004E2 RID: 1250 RVA: 0x0001FA9C File Offset: 0x0001DC9C
		// (set) Token: 0x060004E3 RID: 1251 RVA: 0x0001FAA4 File Offset: 0x0001DCA4
		[ResourcePath("SONICORCA/MENU/GAMEPAD/A")]
		public ITexture ButtonA { get; set; }

		// Token: 0x170000BC RID: 188
		// (get) Token: 0x060004E4 RID: 1252 RVA: 0x0001FAAD File Offset: 0x0001DCAD
		// (set) Token: 0x060004E5 RID: 1253 RVA: 0x0001FAB5 File Offset: 0x0001DCB5
		[ResourcePath("SONICORCA/MENU/GAMEPAD/B")]
		public ITexture ButtonB { get; set; }

		// Token: 0x170000BD RID: 189
		// (get) Token: 0x060004E6 RID: 1254 RVA: 0x0001FABE File Offset: 0x0001DCBE
		// (set) Token: 0x060004E7 RID: 1255 RVA: 0x0001FAC6 File Offset: 0x0001DCC6
		[ResourcePath("SONICORCA/MENU/OPTIONS/V2/UI/SELECTION/BAR")]
		public ITexture SelectionBar { get; set; }

		// Token: 0x060004E8 RID: 1256 RVA: 0x0001FACF File Offset: 0x0001DCCF
		public void PushDependencies(ResourceSession resourceSession)
		{
			resourceSession.PushDependenciesByAttribute(this);
		}

		// Token: 0x060004E9 RID: 1257 RVA: 0x0001FAD8 File Offset: 0x0001DCD8
		public void FetchResources(ResourceTree resourceTree)
		{
			resourceTree.FullfillLoadedResourcesByAttribute(this);
		}
	}
}
