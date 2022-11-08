using System;
using System.Collections.Generic;
using System.Linq;

namespace SonicOrca.Core
{
	// Token: 0x02000098 RID: 152
	internal static class Levels
	{
		// Token: 0x0600035E RID: 862 RVA: 0x00018B90 File Offset: 0x00016D90
		public static string GetAreaResourceKey(string mnemonic)
		{
			if ((from x in Levels.LevelList
			where x.GameIndex == 2
			select x).FirstOrDefault((LevelInfo x) => x.Mnemonic.Equals(mnemonic, StringComparison.OrdinalIgnoreCase)) != null)
			{
				return string.Format("SONICORCA/LEVELS/{0}/AREA", mnemonic.ToUpper());
			}
			return null;
		}

		// Token: 0x0600035F RID: 863 RVA: 0x00018C00 File Offset: 0x00016E00
		public static int GetLevelIndex(string mnemonic)
		{
			int num = 1;
			foreach (LevelInfo levelInfo in Levels.LevelList)
			{
				if (levelInfo.GameIndex == 2)
				{
					if (levelInfo.Mnemonic == mnemonic)
					{
						return num;
					}
					num++;
				}
			}
			return -1;
		}

		// Token: 0x04000414 RID: 1044
		public const int Sonic1 = 1;

		// Token: 0x04000415 RID: 1045
		public const int Sonic2 = 2;

		// Token: 0x04000416 RID: 1046
		public const int Sonic3 = 3;

		// Token: 0x04000417 RID: 1047
		public const int SonicSK = 4;

		// Token: 0x04000418 RID: 1048
		public static readonly IReadOnlyList<LevelInfo> LevelList = new LevelInfo[]
		{
			new LevelInfo(2, "ehz", "Emerald Hill Zone", 2, false),
			new LevelInfo(2, "cpz", "Chemical Plant Zone", 2, false),
			new LevelInfo(2, "arz", "Aquatic Ruin Zone", 2, true),
			new LevelInfo(2, "cnz", "Casino Night Zone", 2, true),
			new LevelInfo(2, "htz", "Hill Top Zone", 2, false),
			new LevelInfo(2, "mcz", "Mystic Cave Zone", 2, true),
			new LevelInfo(2, "ooz", "Oil Ocean Zone", 2, true),
			new LevelInfo(2, "mtz", "Metropolis Zone", 3, true),
			new LevelInfo(2, "scz", "Sky Chase Zone", 1, true),
			new LevelInfo(2, "wfz", "Wing Fortress Zone", 1, true),
			new LevelInfo(2, "dez", "Death Egg Zone", 1, true)
		};
	}
}
