using System;
using SonicOrca.Core;
using SonicOrca.Extensions;
using SonicOrca.Graphics;

namespace SONICORCA.OBJECTS.BUBBLEGENERATOR
{
	// Token: 0x02000066 RID: 102
	public class BubbleGeneratorInstance : ActiveObject
	{
		// Token: 0x0600021B RID: 539 RVA: 0x000101CC File Offset: 0x0000E3CC
		protected override void OnStart()
		{
			this._animation = new AnimationInstance(base.ResourceTree, base.Type.GetAbsolutePath("/ANIGROUP"), 0);
		}

		// Token: 0x0600021C RID: 540 RVA: 0x000101F0 File Offset: 0x0000E3F0
		protected override void OnUpdate()
		{
			int num = this._nextLargeBubbleTime;
			this._nextLargeBubbleTime = num - 1;
			if (num <= 0)
			{
				this._nextLargeBubbleTime = 960;
				base.Level.WaterManager.CreateBubble(base.Level.Map.Layers.IndexOf(base.Layer), base.Position, 2);
			}
			num = this._nextSmallBubbleTime;
			this._nextSmallBubbleTime = num - 1;
			if (num <= 0)
			{
				this._nextSmallBubbleTime = base.Level.Random.Next(64, 128);
				base.Level.WaterManager.CreateBubble(base.Level.Map.Layers.IndexOf(base.Layer), base.Position, base.Level.Random.Next(0, 2));
			}
		}

		// Token: 0x0600021D RID: 541 RVA: 0x000102C2 File Offset: 0x0000E4C2
		protected override void OnAnimate()
		{
			this._animation.Animate();
		}

		// Token: 0x0600021E RID: 542 RVA: 0x000102CF File Offset: 0x0000E4CF
		protected override void OnDraw(Renderer renderer, LayerViewOptions viewOptions)
		{
			renderer.GetObjectRenderer().Render(this._animation, false, false);
		}

		// Token: 0x0400027D RID: 637
		private AnimationInstance _animation;

		// Token: 0x0400027E RID: 638
		private int _nextLargeBubbleTime;

		// Token: 0x0400027F RID: 639
		private int _nextSmallBubbleTime;
	}
}
