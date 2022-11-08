using System;
using SonicOrca.Extensions;
using SonicOrca.Geometry;
using SonicOrca.Graphics;

namespace SonicOrca.Core.Objects.Base
{
	// Token: 0x02000172 RID: 370
	public class ParticleObject : ActiveObject
	{
		// Token: 0x17000450 RID: 1104
		// (get) Token: 0x06001051 RID: 4177 RVA: 0x0004192F File Offset: 0x0003FB2F
		// (set) Token: 0x06001052 RID: 4178 RVA: 0x00041937 File Offset: 0x0003FB37
		protected bool AdditiveBlending { get; set; }

		// Token: 0x17000451 RID: 1105
		// (get) Token: 0x06001053 RID: 4179 RVA: 0x00041940 File Offset: 0x0003FB40
		// (set) Token: 0x06001054 RID: 4180 RVA: 0x00041948 File Offset: 0x0003FB48
		protected double FilterMultiplier { get; set; }

		// Token: 0x17000452 RID: 1106
		// (get) Token: 0x06001055 RID: 4181 RVA: 0x00041951 File Offset: 0x0003FB51
		// (set) Token: 0x06001056 RID: 4182 RVA: 0x00041959 File Offset: 0x0003FB59
		public bool FlipX { get; set; }

		// Token: 0x17000453 RID: 1107
		// (get) Token: 0x06001057 RID: 4183 RVA: 0x00041962 File Offset: 0x0003FB62
		// (set) Token: 0x06001058 RID: 4184 RVA: 0x0004196A File Offset: 0x0003FB6A
		public bool FlipY { get; set; }

		// Token: 0x06001059 RID: 4185 RVA: 0x00041973 File Offset: 0x0003FB73
		public ParticleObject(string animationGroupResourceKey, int animationIndex = 0, int animationCycles = 1)
		{
			this.FilterMultiplier = 1.0;
			this._animationGroupResourceKey = animationGroupResourceKey;
			this._animationIndex = animationIndex;
			this._animationCycles = animationCycles;
		}

		// Token: 0x0600105A RID: 4186 RVA: 0x0004199F File Offset: 0x0003FB9F
		protected override void OnStart()
		{
			this._animationInstance = new AnimationInstance(base.ResourceTree, base.Type.GetAbsolutePath(this._animationGroupResourceKey), this._animationIndex);
			base.Priority = 2048;
		}

		// Token: 0x0600105B RID: 4187 RVA: 0x00037DC0 File Offset: 0x00035FC0
		protected override void OnStop()
		{
			base.FinishForever();
		}

		// Token: 0x0600105C RID: 4188 RVA: 0x000419D4 File Offset: 0x0003FBD4
		protected override void OnUpdate()
		{
			if (this._animationCycles != 0 && this._animationInstance.Cycles >= this._animationCycles)
			{
				base.FinishForever();
			}
		}

		// Token: 0x0600105D RID: 4189 RVA: 0x000419F7 File Offset: 0x0003FBF7
		protected override void OnAnimate()
		{
			this._animationInstance.Animate();
		}

		// Token: 0x0600105E RID: 4190 RVA: 0x00041A04 File Offset: 0x0003FC04
		protected bool CanDraw()
		{
			return this._animationCycles == 0 || this._animationInstance.Cycles < this._animationCycles;
		}

		// Token: 0x0600105F RID: 4191 RVA: 0x00041A24 File Offset: 0x0003FC24
		protected override void OnDraw(Renderer renderer, LayerViewOptions viewOptions)
		{
			if (!this.CanDraw())
			{
				return;
			}
			IObjectRenderer objectRenderer = renderer.GetObjectRenderer();
			using (objectRenderer.BeginMatixState())
			{
				if (this.FlipX)
				{
					objectRenderer.ModelMatrix *= Matrix4.CreateScale(-1.0, 1.0, 1.0);
				}
				if (this.FlipY)
				{
					objectRenderer.ModelMatrix *= Matrix4.CreateScale(1.0, -1.0, 1.0);
				}
				if (this.FilterMultiplier == 0.0)
				{
					objectRenderer.Filter = 0;
				}
				else
				{
					objectRenderer.FilterAmount *= this.FilterMultiplier;
				}
				objectRenderer.BlendMode = (this.AdditiveBlending ? BlendMode.Additive : BlendMode.Alpha);
				objectRenderer.Render(this._animationInstance, false, false);
			}
		}

		// Token: 0x0400093B RID: 2363
		private readonly string _animationGroupResourceKey;

		// Token: 0x0400093C RID: 2364
		private readonly int _animationIndex;

		// Token: 0x0400093D RID: 2365
		private readonly int _animationCycles;

		// Token: 0x0400093E RID: 2366
		protected AnimationInstance _animationInstance;
	}
}
