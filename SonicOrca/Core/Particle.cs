using System;
using SonicOrca.Geometry;
using SonicOrca.Graphics;

namespace SonicOrca.Core
{
	// Token: 0x02000131 RID: 305
	public class Particle
	{
		// Token: 0x170002E4 RID: 740
		// (get) Token: 0x06000BF3 RID: 3059 RVA: 0x0002E820 File Offset: 0x0002CA20
		// (set) Token: 0x06000BF4 RID: 3060 RVA: 0x0002E828 File Offset: 0x0002CA28
		public ParticleType Type { get; set; }

		// Token: 0x170002E5 RID: 741
		// (get) Token: 0x06000BF5 RID: 3061 RVA: 0x0002E831 File Offset: 0x0002CA31
		// (set) Token: 0x06000BF6 RID: 3062 RVA: 0x0002E839 File Offset: 0x0002CA39
		public LevelLayer Layer { get; set; }

		// Token: 0x170002E6 RID: 742
		// (get) Token: 0x06000BF7 RID: 3063 RVA: 0x0002E842 File Offset: 0x0002CA42
		// (set) Token: 0x06000BF8 RID: 3064 RVA: 0x0002E84A File Offset: 0x0002CA4A
		public Vector2 Position { get; set; }

		// Token: 0x170002E7 RID: 743
		// (get) Token: 0x06000BF9 RID: 3065 RVA: 0x0002E853 File Offset: 0x0002CA53
		// (set) Token: 0x06000BFA RID: 3066 RVA: 0x0002E85B File Offset: 0x0002CA5B
		public Vector2 Velocity { get; set; }

		// Token: 0x170002E8 RID: 744
		// (get) Token: 0x06000BFB RID: 3067 RVA: 0x0002E864 File Offset: 0x0002CA64
		// (set) Token: 0x06000BFC RID: 3068 RVA: 0x0002E86C File Offset: 0x0002CA6C
		public int Time { get; set; }

		// Token: 0x170002E9 RID: 745
		// (get) Token: 0x06000BFD RID: 3069 RVA: 0x0002E875 File Offset: 0x0002CA75
		// (set) Token: 0x06000BFE RID: 3070 RVA: 0x0002E87D File Offset: 0x0002CA7D
		public double Angle { get; set; }

		// Token: 0x170002EA RID: 746
		// (get) Token: 0x06000BFF RID: 3071 RVA: 0x0002E886 File Offset: 0x0002CA86
		// (set) Token: 0x06000C00 RID: 3072 RVA: 0x0002E88E File Offset: 0x0002CA8E
		public double AngularVelocity { get; set; }

		// Token: 0x170002EB RID: 747
		// (get) Token: 0x06000C01 RID: 3073 RVA: 0x0002E897 File Offset: 0x0002CA97
		// (set) Token: 0x06000C02 RID: 3074 RVA: 0x0002E89F File Offset: 0x0002CA9F
		public double Size { get; set; }

		// Token: 0x170002EC RID: 748
		// (get) Token: 0x06000C03 RID: 3075 RVA: 0x0002E8A8 File Offset: 0x0002CAA8
		// (set) Token: 0x06000C04 RID: 3076 RVA: 0x0002E8B0 File Offset: 0x0002CAB0
		public ITexture CustomTexture { get; set; }

		// Token: 0x06000C05 RID: 3077 RVA: 0x0002E8B9 File Offset: 0x0002CAB9
		public Particle()
		{
			this.Size = 1.0;
		}

		// Token: 0x06000C06 RID: 3078 RVA: 0x0002E8D0 File Offset: 0x0002CAD0
		public void Update()
		{
			this.Position += this.Velocity;
			this.Angle = MathX.WrapRadians(this.Angle + this.AngularVelocity);
			int time = this.Time;
			this.Time = time - 1;
		}

		// Token: 0x06000C07 RID: 3079 RVA: 0x0002E91C File Offset: 0x0002CB1C
		public override string ToString()
		{
			return string.Format("{0} particle, Time = {1} Position = {2} Velocity = {3}", new object[]
			{
				this.Time,
				this.Type,
				this.Position,
				this.Velocity
			});
		}
	}
}
