using System;
using SonicOrca.Core.Objects.Base;
using SonicOrca.Geometry;

namespace SONICORCA.OBJECTS.DUST
{
	// Token: 0x0200003D RID: 61
	public class DustInstance : ParticleObject
	{
		// Token: 0x17000028 RID: 40
		// (get) Token: 0x0600013F RID: 319 RVA: 0x0000AADF File Offset: 0x00008CDF
		// (set) Token: 0x06000140 RID: 320 RVA: 0x0000AAE7 File Offset: 0x00008CE7
		public Vector2 Velocity { get; set; }

		// Token: 0x06000141 RID: 321 RVA: 0x0000A2BC File Offset: 0x000084BC
		public DustInstance() : base("/ANIGROUP", 0, 1)
		{
		}

		// Token: 0x06000142 RID: 322 RVA: 0x0000AAF0 File Offset: 0x00008CF0
		public void SetDustAnimationIndex(int index)
		{
			this._animationInstance.Index = index;
		}

		// Token: 0x06000143 RID: 323 RVA: 0x0000AAFE File Offset: 0x00008CFE
		protected override void OnUpdate()
		{
			base.MovePrecise(this.Velocity);
			base.OnUpdate();
		}
	}
}
