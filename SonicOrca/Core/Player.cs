using System;
using SonicOrca.Core.Objects;
using SonicOrca.Geometry;

namespace SonicOrca.Core
{
	// Token: 0x02000140 RID: 320
	public class Player
	{
		// Token: 0x17000342 RID: 834
		// (get) Token: 0x06000D14 RID: 3348 RVA: 0x0003213C File Offset: 0x0003033C
		// (set) Token: 0x06000D15 RID: 3349 RVA: 0x00032144 File Offset: 0x00030344
		public int SpeedShoesTicks { get; private set; }

		// Token: 0x17000343 RID: 835
		// (get) Token: 0x06000D16 RID: 3350 RVA: 0x0003214D File Offset: 0x0003034D
		// (set) Token: 0x06000D17 RID: 3351 RVA: 0x00032155 File Offset: 0x00030355
		public int InvincibillityTicks { get; private set; }

		// Token: 0x17000344 RID: 836
		// (get) Token: 0x06000D18 RID: 3352 RVA: 0x0003215E File Offset: 0x0003035E
		// (set) Token: 0x06000D19 RID: 3353 RVA: 0x00032166 File Offset: 0x00030366
		public int TargetRingCountForNextLife { get; private set; }

		// Token: 0x17000345 RID: 837
		// (get) Token: 0x06000D1A RID: 3354 RVA: 0x0003216F File Offset: 0x0003036F
		// (set) Token: 0x06000D1B RID: 3355 RVA: 0x00032177 File Offset: 0x00030377
		public int TargetScoreForNextLife { get; private set; }

		// Token: 0x17000346 RID: 838
		// (get) Token: 0x06000D1C RID: 3356 RVA: 0x00032180 File Offset: 0x00030380
		// (set) Token: 0x06000D1D RID: 3357 RVA: 0x00032188 File Offset: 0x00030388
		public int StarpostIndex { get; set; }

		// Token: 0x17000347 RID: 839
		// (get) Token: 0x06000D1E RID: 3358 RVA: 0x00032191 File Offset: 0x00030391
		// (set) Token: 0x06000D1F RID: 3359 RVA: 0x00032199 File Offset: 0x00030399
		public Vector2i StarpostPosition { get; set; }

		// Token: 0x17000348 RID: 840
		// (get) Token: 0x06000D20 RID: 3360 RVA: 0x000321A2 File Offset: 0x000303A2
		// (set) Token: 0x06000D21 RID: 3361 RVA: 0x000321AA File Offset: 0x000303AA
		public int StarpostTime { get; set; }

		// Token: 0x17000349 RID: 841
		// (get) Token: 0x06000D22 RID: 3362 RVA: 0x000321B3 File Offset: 0x000303B3
		// (set) Token: 0x06000D23 RID: 3363 RVA: 0x000321BB File Offset: 0x000303BB
		public ICharacter Protagonist { get; set; }

		// Token: 0x1700034A RID: 842
		// (get) Token: 0x06000D24 RID: 3364 RVA: 0x000321C4 File Offset: 0x000303C4
		// (set) Token: 0x06000D25 RID: 3365 RVA: 0x000321CC File Offset: 0x000303CC
		public CharacterType ProtagonistCharacterType { get; set; }

		// Token: 0x1700034B RID: 843
		// (get) Token: 0x06000D26 RID: 3366 RVA: 0x000321D5 File Offset: 0x000303D5
		// (set) Token: 0x06000D27 RID: 3367 RVA: 0x000321DD File Offset: 0x000303DD
		public int ProtagonistGamepadIndex { get; set; }

		// Token: 0x1700034C RID: 844
		// (get) Token: 0x06000D28 RID: 3368 RVA: 0x000321E6 File Offset: 0x000303E6
		// (set) Token: 0x06000D29 RID: 3369 RVA: 0x000321EE File Offset: 0x000303EE
		public ICharacter Sidekick { get; set; }

		// Token: 0x1700034D RID: 845
		// (get) Token: 0x06000D2A RID: 3370 RVA: 0x000321F7 File Offset: 0x000303F7
		// (set) Token: 0x06000D2B RID: 3371 RVA: 0x000321FF File Offset: 0x000303FF
		public CharacterType SidekickCharacterType { get; set; }

		// Token: 0x1700034E RID: 846
		// (get) Token: 0x06000D2C RID: 3372 RVA: 0x00032208 File Offset: 0x00030408
		// (set) Token: 0x06000D2D RID: 3373 RVA: 0x00032210 File Offset: 0x00030410
		public int SidekickGamepadIndex { get; set; }

		// Token: 0x1700034F RID: 847
		// (get) Token: 0x06000D2E RID: 3374 RVA: 0x00032219 File Offset: 0x00030419
		// (set) Token: 0x06000D2F RID: 3375 RVA: 0x00032221 File Offset: 0x00030421
		public int Score { get; set; }

		// Token: 0x17000350 RID: 848
		// (get) Token: 0x06000D30 RID: 3376 RVA: 0x0003222A File Offset: 0x0003042A
		// (set) Token: 0x06000D31 RID: 3377 RVA: 0x00032232 File Offset: 0x00030432
		public int Lives { get; set; }

		// Token: 0x17000351 RID: 849
		// (get) Token: 0x06000D32 RID: 3378 RVA: 0x0003223B File Offset: 0x0003043B
		// (set) Token: 0x06000D33 RID: 3379 RVA: 0x00032243 File Offset: 0x00030443
		public int TotalRings { get; set; }

		// Token: 0x17000352 RID: 850
		// (get) Token: 0x06000D34 RID: 3380 RVA: 0x0003224C File Offset: 0x0003044C
		// (set) Token: 0x06000D35 RID: 3381 RVA: 0x00032254 File Offset: 0x00030454
		public int CurrentRings { get; set; }

		// Token: 0x06000D36 RID: 3382 RVA: 0x0003225D File Offset: 0x0003045D
		public Player(Level level)
		{
			this._level = level;
			this.TargetRingCountForNextLife = 100;
			this.TargetScoreForNextLife = 50000;
			this.StarpostIndex = -1;
			this.Lives = 3;
		}

		// Token: 0x06000D37 RID: 3383 RVA: 0x00032290 File Offset: 0x00030490
		public void Update()
		{
			if (this.SpeedShoesTicks > 0)
			{
				int num = this.SpeedShoesTicks;
				this.SpeedShoesTicks = num - 1;
				if (this.SpeedShoesTicks == 0)
				{
					this.RemoveSpeedShoes();
				}
			}
			if (this.InvincibillityTicks > 0)
			{
				int num = this.InvincibillityTicks;
				this.InvincibillityTicks = num - 1;
				if (this.InvincibillityTicks == 0)
				{
					this.RemoveInvincibility();
				}
			}
		}

		// Token: 0x06000D38 RID: 3384 RVA: 0x000322EB File Offset: 0x000304EB
		public void GainScore(int points)
		{
			this.Score += points;
			if (this.Score >= this.TargetScoreForNextLife)
			{
				this.TargetScoreForNextLife += 50000;
				this.GainLives(1);
			}
		}

		// Token: 0x06000D39 RID: 3385 RVA: 0x00032324 File Offset: 0x00030524
		public void GainRings(int count = 1)
		{
			this.TotalRings += count;
			this.CurrentRings = Math.Min(this.CurrentRings + count, 999);
			if (this.CurrentRings >= this.TargetRingCountForNextLife)
			{
				this.TargetRingCountForNextLife += 100;
				this.GainLives(1);
			}
		}

		// Token: 0x06000D3A RID: 3386 RVA: 0x0003237B File Offset: 0x0003057B
		public void GainLives(int count = 1)
		{
			if (this.Lives >= 0)
			{
				this.Lives = Math.Min(this.Lives + count, 999);
			}
			this._level.SoundManager.PlayJingle(JingleType.Life);
		}

		// Token: 0x06000D3B RID: 3387 RVA: 0x000323AF File Offset: 0x000305AF
		public void LoseAllRings()
		{
			this.TargetRingCountForNextLife = 100;
			this.CurrentRings = 0;
		}

		// Token: 0x06000D3C RID: 3388 RVA: 0x000323C0 File Offset: 0x000305C0
		public void ResetRings()
		{
			this.TargetRingCountForNextLife = 100;
			this.CurrentRings = 0;
			this.TotalRings = 0;
		}

		// Token: 0x06000D3D RID: 3389 RVA: 0x000323D8 File Offset: 0x000305D8
		public int AwardChainedScore()
		{
			int num = (this._scoreChainIndex >= 16) ? 10000 : Player.ChainScores[Math.Min(this._scoreChainIndex, Player.ChainScores.Length - 1)];
			this._scoreChainIndex++;
			this.GainScore(num);
			return num;
		}

		// Token: 0x06000D3E RID: 3390 RVA: 0x00032427 File Offset: 0x00030627
		public void ResetScoreChain()
		{
			this._scoreChainIndex = 0;
		}

		// Token: 0x06000D3F RID: 3391 RVA: 0x00032430 File Offset: 0x00030630
		public void GiveBarrier(BarrierType type)
		{
			this.Protagonist.Barrier = type;
		}

		// Token: 0x06000D40 RID: 3392 RVA: 0x0003243E File Offset: 0x0003063E
		public void GiveSpeedShoes()
		{
			this.SpeedShoesTicks = 1200;
			this.Protagonist.HasSpeedShoes = true;
			this._level.SoundManager.PlayJingle(JingleType.SpeedShoes);
		}

		// Token: 0x06000D41 RID: 3393 RVA: 0x00032468 File Offset: 0x00030668
		public void RemoveSpeedShoes()
		{
			if (this.Protagonist != null)
			{
				this.Protagonist.HasSpeedShoes = false;
			}
			this._level.SoundManager.StopJingle(JingleType.SpeedShoes);
		}

		// Token: 0x06000D42 RID: 3394 RVA: 0x0003248F File Offset: 0x0003068F
		public void GiveInvincibility()
		{
			this.InvincibillityTicks = 1200;
			this.Protagonist.IsInvincible = true;
			this._level.SoundManager.PlayJingle(JingleType.Invincibility);
		}

		// Token: 0x06000D43 RID: 3395 RVA: 0x000324B9 File Offset: 0x000306B9
		public void RemoveInvincibility()
		{
			if (this.Protagonist != null)
			{
				this.Protagonist.IsInvincible = false;
			}
			this._level.SoundManager.StopJingle(JingleType.Invincibility);
		}

		// Token: 0x06000D44 RID: 3396 RVA: 0x000324E0 File Offset: 0x000306E0
		public void RemovePowerups()
		{
			this.RemoveInvincibility();
			this.RemoveSpeedShoes();
		}

		// Token: 0x06000D45 RID: 3397 RVA: 0x000324EE File Offset: 0x000306EE
		public bool IsStarpostActivated(int index)
		{
			return index <= this.StarpostIndex;
		}

		// Token: 0x06000D46 RID: 3398 RVA: 0x000324FC File Offset: 0x000306FC
		public void ActivateStarpost(int index, Vector2i position)
		{
			this.StarpostIndex = index;
			this.StarpostPosition = position;
			this.StarpostTime = this._level.Time;
		}

		// Token: 0x04000761 RID: 1889
		private const int RingsForLife = 100;

		// Token: 0x04000762 RID: 1890
		private const int ScoreForLife = 50000;

		// Token: 0x04000763 RID: 1891
		private const int MaxLives = 999;

		// Token: 0x04000764 RID: 1892
		private const int MaxRings = 999;

		// Token: 0x04000765 RID: 1893
		private const int BigChainSize = 16;

		// Token: 0x04000766 RID: 1894
		private const int BigChainScore = 10000;

		// Token: 0x04000767 RID: 1895
		private static readonly int[] ChainScores = new int[]
		{
			100,
			200,
			500,
			1000
		};

		// Token: 0x04000768 RID: 1896
		public const int UndefinedStarpostIndex = -1;

		// Token: 0x04000769 RID: 1897
		private readonly Level _level;

		// Token: 0x04000771 RID: 1905
		private int _scoreChainIndex;
	}
}
