using System;

namespace SonicOrca.Core
{
	// Token: 0x02000097 RID: 151
	internal class LevelInfo
	{
		// Token: 0x17000062 RID: 98
		// (get) Token: 0x06000358 RID: 856 RVA: 0x00018B38 File Offset: 0x00016D38
		public int GameIndex { get; }

		// Token: 0x17000063 RID: 99
		// (get) Token: 0x06000359 RID: 857 RVA: 0x00018B40 File Offset: 0x00016D40
		public string Mnemonic { get; }

		// Token: 0x17000064 RID: 100
		// (get) Token: 0x0600035A RID: 858 RVA: 0x00018B48 File Offset: 0x00016D48
		public string Name { get; }

		// Token: 0x17000065 RID: 101
		// (get) Token: 0x0600035B RID: 859 RVA: 0x00018B50 File Offset: 0x00016D50
		public int Acts { get; }

		// Token: 0x17000066 RID: 102
		// (get) Token: 0x0600035C RID: 860 RVA: 0x00018B58 File Offset: 0x00016D58
		public bool Unreleased { get; }

		// Token: 0x0600035D RID: 861 RVA: 0x00018B60 File Offset: 0x00016D60
		public LevelInfo(int gameIndex, string mnemonic, string name, int acts, bool unreleased = false)
		{
			this.GameIndex = gameIndex;
			this.Mnemonic = mnemonic;
			this.Name = name;
			this.Acts = acts;
			this.Unreleased = unreleased;
		}
	}
}
