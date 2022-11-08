using System;
using SonicOrca.Core;
using SonicOrca.Core.Objects.Metadata;
using SonicOrca.Extensions;
using SonicOrca.Geometry;
using SonicOrca.Graphics;

namespace SONICORCA.OBJECTS.HTZVINELIFT.PILLAR
{
	// Token: 0x02000047 RID: 71
	public class HTZVineLiftPillarInstance : ActiveObject
	{
		// Token: 0x1700002C RID: 44
		// (get) Token: 0x06000169 RID: 361 RVA: 0x0000B6F4 File Offset: 0x000098F4
		// (set) Token: 0x0600016A RID: 362 RVA: 0x0000B6FC File Offset: 0x000098FC
		[StateVariable]
		private bool FlipX
		{
			get
			{
				return this._flipX;
			}
			set
			{
				this._flipX = value;
			}
		}

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x0600016B RID: 363 RVA: 0x0000B705 File Offset: 0x00009905
		// (set) Token: 0x0600016C RID: 364 RVA: 0x0000B70D File Offset: 0x0000990D
		[StateVariable]
		private bool Bottom
		{
			get
			{
				return this._bottom;
			}
			set
			{
				this._bottom = value;
			}
		}

		// Token: 0x0600016D RID: 365 RVA: 0x0000B716 File Offset: 0x00009916
		public HTZVineLiftPillarInstance()
		{
			base.DesignBounds = new Rectanglei(-64, -170, 128, 340);
		}

		// Token: 0x0600016E RID: 366 RVA: 0x0000B73A File Offset: 0x0000993A
		protected override void OnStart()
		{
			base.OnStart();
			this._animation = new AnimationInstance(base.ResourceTree, base.Type.GetAbsolutePath("//ANIGROUP"), this._bottom ? 3 : 2);
			base.Priority = -256;
		}

		// Token: 0x0600016F RID: 367 RVA: 0x0000B77A File Offset: 0x0000997A
		protected override void OnAnimate()
		{
			this._animation.Animate();
		}

		// Token: 0x06000170 RID: 368 RVA: 0x0000B787 File Offset: 0x00009987
		protected override void OnDraw(Renderer renderer, LayerViewOptions viewOptions)
		{
			renderer.GetObjectRenderer().Render(this._animation, this._flipX, false);
		}

		// Token: 0x04000184 RID: 388
		private const int TopAnimationIndex = 2;

		// Token: 0x04000185 RID: 389
		private const int BottomAnimationIndex = 3;

		// Token: 0x04000186 RID: 390
		private AnimationInstance _animation;

		// Token: 0x04000187 RID: 391
		private bool _flipX;

		// Token: 0x04000188 RID: 392
		private bool _bottom;
	}
}
