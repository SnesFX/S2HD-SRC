using System;
using SonicOrca.Geometry;

namespace SonicOrca.Core
{
	// Token: 0x0200012C RID: 300
	public class LevelPrepareSettings
	{
		// Token: 0x170002D3 RID: 723
		// (get) Token: 0x06000BCD RID: 3021 RVA: 0x0002DC8F File Offset: 0x0002BE8F
		// (set) Token: 0x06000BCE RID: 3022 RVA: 0x0002DC97 File Offset: 0x0002BE97
		public bool TimeTrial { get; set; }

		// Token: 0x170002D4 RID: 724
		// (get) Token: 0x06000BCF RID: 3023 RVA: 0x0002DCA0 File Offset: 0x0002BEA0
		// (set) Token: 0x06000BD0 RID: 3024 RVA: 0x0002DCA8 File Offset: 0x0002BEA8
		public CharacterType ProtagonistCharacter { get; set; }

		// Token: 0x170002D5 RID: 725
		// (get) Token: 0x06000BD1 RID: 3025 RVA: 0x0002DCB1 File Offset: 0x0002BEB1
		// (set) Token: 0x06000BD2 RID: 3026 RVA: 0x0002DCB9 File Offset: 0x0002BEB9
		public CharacterType SidekickCharacter { get; set; }

		// Token: 0x170002D6 RID: 726
		// (get) Token: 0x06000BD3 RID: 3027 RVA: 0x0002DCC2 File Offset: 0x0002BEC2
		// (set) Token: 0x06000BD4 RID: 3028 RVA: 0x0002DCCA File Offset: 0x0002BECA
		public string RecordedPlayReadPath { get; set; }

		// Token: 0x170002D7 RID: 727
		// (get) Token: 0x06000BD5 RID: 3029 RVA: 0x0002DCD3 File Offset: 0x0002BED3
		// (set) Token: 0x06000BD6 RID: 3030 RVA: 0x0002DCDB File Offset: 0x0002BEDB
		public string RecordedPlayWritePath { get; set; }

		// Token: 0x170002D8 RID: 728
		// (get) Token: 0x06000BD7 RID: 3031 RVA: 0x0002DCE4 File Offset: 0x0002BEE4
		// (set) Token: 0x06000BD8 RID: 3032 RVA: 0x0002DCEC File Offset: 0x0002BEEC
		public string RecordedPlayGhostReadPath { get; set; }

		// Token: 0x170002D9 RID: 729
		// (get) Token: 0x06000BD9 RID: 3033 RVA: 0x0002DCF5 File Offset: 0x0002BEF5
		// (set) Token: 0x06000BDA RID: 3034 RVA: 0x0002DCFD File Offset: 0x0002BEFD
		public byte[] RecordedPlayReadData { get; set; }

		// Token: 0x170002DA RID: 730
		// (get) Token: 0x06000BDB RID: 3035 RVA: 0x0002DD06 File Offset: 0x0002BF06
		// (set) Token: 0x06000BDC RID: 3036 RVA: 0x0002DD0E File Offset: 0x0002BF0E
		public int LevelNumber { get; set; }

		// Token: 0x170002DB RID: 731
		// (get) Token: 0x06000BDD RID: 3037 RVA: 0x0002DD17 File Offset: 0x0002BF17
		// (set) Token: 0x06000BDE RID: 3038 RVA: 0x0002DD1F File Offset: 0x0002BF1F
		public string AreaResourceKey { get; set; }

		// Token: 0x170002DC RID: 732
		// (get) Token: 0x06000BDF RID: 3039 RVA: 0x0002DD28 File Offset: 0x0002BF28
		// (set) Token: 0x06000BE0 RID: 3040 RVA: 0x0002DD30 File Offset: 0x0002BF30
		public int Act { get; set; }

		// Token: 0x170002DD RID: 733
		// (get) Token: 0x06000BE1 RID: 3041 RVA: 0x0002DD39 File Offset: 0x0002BF39
		// (set) Token: 0x06000BE2 RID: 3042 RVA: 0x0002DD41 File Offset: 0x0002BF41
		public Vector2i? StartPosition { get; set; }

		// Token: 0x170002DE RID: 734
		// (get) Token: 0x06000BE3 RID: 3043 RVA: 0x0002DD4A File Offset: 0x0002BF4A
		// (set) Token: 0x06000BE4 RID: 3044 RVA: 0x0002DD52 File Offset: 0x0002BF52
		public int StartPath { get; set; }

		// Token: 0x170002DF RID: 735
		// (get) Token: 0x06000BE5 RID: 3045 RVA: 0x0002DD5B File Offset: 0x0002BF5B
		// (set) Token: 0x06000BE6 RID: 3046 RVA: 0x0002DD63 File Offset: 0x0002BF63
		public bool Seamless { get; set; }

		// Token: 0x170002E0 RID: 736
		// (get) Token: 0x06000BE7 RID: 3047 RVA: 0x0002DD6C File Offset: 0x0002BF6C
		// (set) Token: 0x06000BE8 RID: 3048 RVA: 0x0002DD74 File Offset: 0x0002BF74
		public int Lives { get; set; }

		// Token: 0x170002E1 RID: 737
		// (get) Token: 0x06000BE9 RID: 3049 RVA: 0x0002DD7D File Offset: 0x0002BF7D
		// (set) Token: 0x06000BEA RID: 3050 RVA: 0x0002DD85 File Offset: 0x0002BF85
		public int Score { get; set; }

		// Token: 0x170002E2 RID: 738
		// (get) Token: 0x06000BEB RID: 3051 RVA: 0x0002DD8E File Offset: 0x0002BF8E
		// (set) Token: 0x06000BEC RID: 3052 RVA: 0x0002DD96 File Offset: 0x0002BF96
		public bool Debugging { get; set; }

		// Token: 0x170002E3 RID: 739
		// (get) Token: 0x06000BED RID: 3053 RVA: 0x0002DD9F File Offset: 0x0002BF9F
		// (set) Token: 0x06000BEE RID: 3054 RVA: 0x0002DDA7 File Offset: 0x0002BFA7
		public double NightMode { get; set; }

		// Token: 0x06000BEF RID: 3055 RVA: 0x0002DDB0 File Offset: 0x0002BFB0
		public LevelPrepareSettings()
		{
			this.Lives = 3;
		}
	}
}
