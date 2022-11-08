using System;

namespace SonicOrca.Core.Objects.Base
{
	// Token: 0x0200016D RID: 365
	public class CharacterInputState
	{
		// Token: 0x1700043B RID: 1083
		// (get) Token: 0x0600101B RID: 4123 RVA: 0x00041480 File Offset: 0x0003F680
		// (set) Token: 0x0600101C RID: 4124 RVA: 0x00041488 File Offset: 0x0003F688
		private double _throttle { get; set; }

		// Token: 0x1700043C RID: 1084
		// (get) Token: 0x0600101D RID: 4125 RVA: 0x00041491 File Offset: 0x0003F691
		// (set) Token: 0x0600101E RID: 4126 RVA: 0x00041499 File Offset: 0x0003F699
		public double Throttle
		{
			get
			{
				return this._throttle;
			}
			set
			{
				this._throttle = MathX.Clamp(-1.0, value, 1.0);
			}
		}

		// Token: 0x1700043D RID: 1085
		// (get) Token: 0x0600101F RID: 4127 RVA: 0x000414B9 File Offset: 0x0003F6B9
		// (set) Token: 0x06001020 RID: 4128 RVA: 0x000414C6 File Offset: 0x0003F6C6
		public int HorizontalDirection
		{
			get
			{
				return Math.Sign(this.Throttle);
			}
			set
			{
				this.Throttle = (double)Math.Sign(value);
			}
		}

		// Token: 0x1700043E RID: 1086
		// (get) Token: 0x06001021 RID: 4129 RVA: 0x000414D5 File Offset: 0x0003F6D5
		// (set) Token: 0x06001022 RID: 4130 RVA: 0x000414DD File Offset: 0x0003F6DD
		public int VerticalDirection
		{
			get
			{
				return this._verticalDirection;
			}
			set
			{
				this._verticalDirection = Math.Sign(value);
			}
		}

		// Token: 0x1700043F RID: 1087
		// (get) Token: 0x06001023 RID: 4131 RVA: 0x000414EB File Offset: 0x0003F6EB
		// (set) Token: 0x06001024 RID: 4132 RVA: 0x000414F3 File Offset: 0x0003F6F3
		public CharacterInputButtonState A { get; set; }

		// Token: 0x17000440 RID: 1088
		// (get) Token: 0x06001025 RID: 4133 RVA: 0x000414FC File Offset: 0x0003F6FC
		// (set) Token: 0x06001026 RID: 4134 RVA: 0x00041504 File Offset: 0x0003F704
		public CharacterInputButtonState B { get; set; }

		// Token: 0x17000441 RID: 1089
		// (get) Token: 0x06001027 RID: 4135 RVA: 0x0004150D File Offset: 0x0003F70D
		// (set) Token: 0x06001028 RID: 4136 RVA: 0x00041515 File Offset: 0x0003F715
		public CharacterInputButtonState C { get; set; }

		// Token: 0x17000442 RID: 1090
		// (get) Token: 0x06001029 RID: 4137 RVA: 0x0004151E File Offset: 0x0003F71E
		public CharacterInputButtonState ABC
		{
			get
			{
				if (this.A == CharacterInputButtonState.Pressed || this.B == CharacterInputButtonState.Pressed || this.C == CharacterInputButtonState.Pressed)
				{
					return CharacterInputButtonState.Pressed;
				}
				return (this.A | this.B | this.C) & CharacterInputButtonState.Down;
			}
		}

		// Token: 0x0600102A RID: 4138 RVA: 0x00002248 File Offset: 0x00000448
		public CharacterInputState()
		{
		}

		// Token: 0x0600102B RID: 4139 RVA: 0x00041554 File Offset: 0x0003F754
		public CharacterInputState(CharacterInputState state)
		{
			this._throttle = state._throttle;
			this._verticalDirection = state._verticalDirection;
			this.A = state.A;
			this.B = state.B;
			this.C = state.C;
		}

		// Token: 0x0600102C RID: 4140 RVA: 0x000415A3 File Offset: 0x0003F7A3
		public void Clear()
		{
			this._throttle = 0.0;
			this._verticalDirection = 0;
			this.A = CharacterInputButtonState.Up;
			this.B = CharacterInputButtonState.Up;
			this.C = CharacterInputButtonState.Up;
		}

		// Token: 0x0400090B RID: 2315
		private int _verticalDirection;
	}
}
