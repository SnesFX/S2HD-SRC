using System;
using System.Collections.Generic;
using System.Linq;
using SonicOrca.Core.Objects.Metadata;
using SonicOrca.Geometry;

namespace SonicOrca.Core.Objects.Base
{
	// Token: 0x02000173 RID: 371
	public class Platform : ActiveObject, IPlatform, IActiveObject
	{
		// Token: 0x17000454 RID: 1108
		// (get) Token: 0x06001060 RID: 4192 RVA: 0x00041B24 File Offset: 0x0003FD24
		// (set) Token: 0x06001061 RID: 4193 RVA: 0x00041B2C File Offset: 0x0003FD2C
		protected Vector2 _nextPositionPrecise { get; set; }

		// Token: 0x17000455 RID: 1109
		// (get) Token: 0x06001062 RID: 4194 RVA: 0x00041B35 File Offset: 0x0003FD35
		// (set) Token: 0x06001063 RID: 4195 RVA: 0x00041B3D File Offset: 0x0003FD3D
		[StateVariable]
		public Vector2 MovementRadius { get; protected set; }

		// Token: 0x17000456 RID: 1110
		// (get) Token: 0x06001064 RID: 4196 RVA: 0x00041B46 File Offset: 0x0003FD46
		// (set) Token: 0x06001065 RID: 4197 RVA: 0x00041B4E File Offset: 0x0003FD4E
		[StateVariable]
		protected int TimePeriod { get; set; }

		// Token: 0x17000457 RID: 1111
		// (get) Token: 0x06001066 RID: 4198 RVA: 0x00041B57 File Offset: 0x0003FD57
		// (set) Token: 0x06001067 RID: 4199 RVA: 0x00041B5F File Offset: 0x0003FD5F
		[StateVariable]
		protected int TimeOffset { get; set; }

		// Token: 0x17000458 RID: 1112
		// (get) Token: 0x06001068 RID: 4200 RVA: 0x00041B68 File Offset: 0x0003FD68
		// (set) Token: 0x06001069 RID: 4201 RVA: 0x00041B70 File Offset: 0x0003FD70
		[StateVariable]
		protected bool FallWhenStoodOn
		{
			get
			{
				return this._fallWhenStoodOn;
			}
			set
			{
				this._fallWhenStoodOn = value;
			}
		}

		// Token: 0x17000459 RID: 1113
		// (get) Token: 0x0600106A RID: 4202 RVA: 0x00041B79 File Offset: 0x0003FD79
		// (set) Token: 0x0600106B RID: 4203 RVA: 0x00041B81 File Offset: 0x0003FD81
		protected bool SagWhenStoodOn { get; set; }

		// Token: 0x1700045A RID: 1114
		// (get) Token: 0x0600106C RID: 4204 RVA: 0x00041B8A File Offset: 0x0003FD8A
		// (set) Token: 0x0600106D RID: 4205 RVA: 0x00041B92 File Offset: 0x0003FD92
		protected bool Linear { get; set; }

		// Token: 0x1700045B RID: 1115
		// (get) Token: 0x0600106E RID: 4206 RVA: 0x00041B9B File Offset: 0x0003FD9B
		// (set) Token: 0x0600106F RID: 4207 RVA: 0x00041BA3 File Offset: 0x0003FDA3
		public int CurrentTime { get; set; }

		// Token: 0x1700045C RID: 1116
		// (get) Token: 0x06001070 RID: 4208 RVA: 0x00041BAC File Offset: 0x0003FDAC
		// (set) Token: 0x06001071 RID: 4209 RVA: 0x00041BB4 File Offset: 0x0003FDB4
		public double CurrentT { get; set; }

		// Token: 0x1700045D RID: 1117
		// (get) Token: 0x06001072 RID: 4210 RVA: 0x00041BBD File Offset: 0x0003FDBD
		public Vector2 Velocity
		{
			get
			{
				return this._velocityBasedOnNextPosition;
			}
		}

		// Token: 0x1700045E RID: 1118
		// (get) Token: 0x06001073 RID: 4211 RVA: 0x00041BC5 File Offset: 0x0003FDC5
		// (set) Token: 0x06001074 RID: 4212 RVA: 0x00041BCD File Offset: 0x0003FDCD
		public Ellipse Area { get; set; }

		// Token: 0x06001075 RID: 4213 RVA: 0x00041BD6 File Offset: 0x0003FDD6
		protected override void OnStart()
		{
			this._initialPosition = base.Position;
			this._fallingDelay = 30;
		}

		// Token: 0x06001076 RID: 4214 RVA: 0x00041BEC File Offset: 0x0003FDEC
		protected override void OnUpdatePrepare()
		{
			Vector2 positionPrecise = base.PositionPrecise;
			this.UpdateMovement();
			this._nextPositionPrecise = base.PositionPrecise;
			this._velocityBasedOnNextPosition = this._nextPositionPrecise - positionPrecise;
			base.PositionPrecise = positionPrecise;
		}

		// Token: 0x06001077 RID: 4215 RVA: 0x00041C2B File Offset: 0x0003FE2B
		protected override void OnUpdate()
		{
			base.PositionPrecise = this._nextPositionPrecise;
		}

		// Token: 0x06001078 RID: 4216 RVA: 0x00041C3C File Offset: 0x0003FE3C
		protected virtual void UpdateMovement()
		{
			this.UpdateTime();
			if (!this._falling)
			{
				this.UpdateOscillationPosition();
				if (!this.IsCharacterInteractingWithPlatform())
				{
					if (this.MovementRadius.Y == 0.0 && !this._fallWhenStoodOn && this.SagWhenStoodOn)
					{
						this._sagOffset = Math.Max(0, this._sagOffset - 2);
					}
				}
				else
				{
					if (this.MovementRadius.Y == 0.0 && !this._fallWhenStoodOn && this.SagWhenStoodOn)
					{
						this._sagOffset = Math.Min(16, this._sagOffset + 2);
					}
					if (this._fallWhenStoodOn)
					{
						this._falling = true;
					}
				}
				base.PositionPrecise += new Vector2(0.0, (double)this._sagOffset);
				return;
			}
			if (this._fallingDelay > 0)
			{
				this._fallingDelay--;
				return;
			}
			this._fallingVelocity.Y = this._fallingVelocity.Y + 0.875;
			base.PositionPrecise += this._fallingVelocity;
		}

		// Token: 0x06001079 RID: 4217 RVA: 0x00041D64 File Offset: 0x0003FF64
		private void UpdateTime()
		{
			if (this.TimePeriod > 0)
			{
				this.CurrentTime = (base.Level.Ticks + this.TimeOffset) % this.TimePeriod;
				this.CurrentT = (double)this.CurrentTime / (double)this.TimePeriod;
				return;
			}
			this.CurrentTime = 0;
			this.CurrentT = 0.0;
		}

		// Token: 0x0600107A RID: 4218 RVA: 0x00041DC8 File Offset: 0x0003FFC8
		private void UpdateOscillationPosition()
		{
			if (this.TimePeriod == 0)
			{
				return;
			}
			double num = this.CurrentT;
			double num2;
			double num3;
			if (this.Linear)
			{
				if (num <= 0.25)
				{
					num /= 0.25;
				}
				else if (num <= 0.5)
				{
					num = 1.0 - (num - 0.25) / 0.25;
				}
				else if (num <= 0.75)
				{
					num = -((num - 0.5) / 0.25);
				}
				else
				{
					num = -1.0 + (num - 0.75) / 0.25;
				}
				num2 = num;
				num3 = num;
			}
			else
			{
				double num4 = num * 6.283185307179586;
				if (this.MovementRadius.X == 0.0 || this.MovementRadius.Y == 0.0)
				{
					num2 = Math.Sin(num4);
					num3 = Math.Sin(num4);
				}
				else
				{
					num2 = Math.Cos(num4);
					num3 = Math.Sin(num4);
				}
			}
			base.PositionPrecise = new Vector2((double)this._initialPosition.X + num2 * this.MovementRadius.X, (double)this._initialPosition.Y + num3 * this.MovementRadius.Y + (double)this._sagOffset);
		}

		// Token: 0x0600107B RID: 4219 RVA: 0x00041F30 File Offset: 0x00040130
		protected bool IsCharacterInteractingWithPlatform()
		{
			return base.Level.ObjectManager.Characters.Any((ICharacter x) => x.ObjectLink == this);
		}

		// Token: 0x04000943 RID: 2371
		private readonly List<ICharacter> _charactersOnPlatform = new List<ICharacter>();

		// Token: 0x04000944 RID: 2372
		private Vector2i _initialPosition;

		// Token: 0x04000945 RID: 2373
		private int _sagOffset;

		// Token: 0x04000946 RID: 2374
		private bool _fallWhenStoodOn;

		// Token: 0x04000947 RID: 2375
		private bool _falling;

		// Token: 0x04000948 RID: 2376
		private int _fallingDelay;

		// Token: 0x04000949 RID: 2377
		private Vector2 _fallingVelocity;

		// Token: 0x0400094B RID: 2379
		protected Vector2 _velocityBasedOnNextPosition;
	}
}
