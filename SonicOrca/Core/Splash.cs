using System;
using System.Linq;
using SonicOrca.Geometry;
using SonicOrca.Graphics;

namespace SonicOrca.Core
{
	// Token: 0x02000150 RID: 336
	internal class Splash
	{
		// Token: 0x17000379 RID: 889
		// (get) Token: 0x06000DF9 RID: 3577 RVA: 0x00035AE0 File Offset: 0x00033CE0
		// (set) Token: 0x06000DFA RID: 3578 RVA: 0x00035AE8 File Offset: 0x00033CE8
		public bool Finished { get; private set; }

		// Token: 0x06000DFB RID: 3579 RVA: 0x00035AF1 File Offset: 0x00033CF1
		public Splash(WaterManager waterManager, SplashType type, Vector2i position)
		{
			this._waterManager = waterManager;
			if (type == SplashType.Enter)
			{
				this._animation = new AnimationInstance(waterManager.SpashEnterAnimationGroup, 0);
			}
			else
			{
				this._animation = new AnimationInstance(waterManager.SpashExitAnimationGroup, 0);
			}
			this._position = position;
		}

		// Token: 0x06000DFC RID: 3580 RVA: 0x00035B30 File Offset: 0x00033D30
		public void Animate()
		{
			if (this._waterManager.WaterAreas.Count == 0)
			{
				this.Finished = true;
				return;
			}
			this._position.Y = this._waterManager.WaterAreas.First<Rectanglei>().Top;
			this._animation.Animate();
			if (this._animation.Cycles > 0)
			{
				this.Finished = true;
			}
		}

		// Token: 0x06000DFD RID: 3581 RVA: 0x00035B9C File Offset: 0x00033D9C
		public void Draw(I2dRenderer renderer)
		{
			int height = this._animation.CurrentFrame.Source.Height;
			Vector2i v = this._position + new Vector2i(0, -height / 2);
			this._animation.Draw(renderer, v, false, false);
		}

		// Token: 0x040007E0 RID: 2016
		private readonly WaterManager _waterManager;

		// Token: 0x040007E1 RID: 2017
		private readonly AnimationInstance _animation;

		// Token: 0x040007E2 RID: 2018
		private Vector2i _position;
	}
}
