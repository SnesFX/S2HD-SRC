using System;
using SonicOrca.Extensions;
using SonicOrca.Graphics;

namespace SonicOrca.Core.Objects.Base
{
	// Token: 0x02000174 RID: 372
	public class Scenery : ActiveObject
	{
		// Token: 0x1700045F RID: 1119
		// (get) Token: 0x0600107E RID: 4222 RVA: 0x00041F71 File Offset: 0x00040171
		// (set) Token: 0x0600107F RID: 4223 RVA: 0x00041F79 File Offset: 0x00040179
		protected bool AdditiveBlending { get; set; }

		// Token: 0x06001080 RID: 4224 RVA: 0x00041F82 File Offset: 0x00040182
		public Scenery(string animationGroupResourceKey)
		{
			this._animationGroupResourceKey = animationGroupResourceKey;
		}

		// Token: 0x06001081 RID: 4225 RVA: 0x00041F91 File Offset: 0x00040191
		protected override void OnStart()
		{
			this._animationInstance = new AnimationInstance(base.ResourceTree, base.Type.GetAbsolutePath(this._animationGroupResourceKey), 0);
		}

		// Token: 0x06001082 RID: 4226 RVA: 0x00041FB6 File Offset: 0x000401B6
		protected override void OnAnimate()
		{
			this._animationInstance.Animate();
		}

		// Token: 0x06001083 RID: 4227 RVA: 0x00041FC3 File Offset: 0x000401C3
		protected override void OnDraw(Renderer renderer, LayerViewOptions viewOptions)
		{
			IObjectRenderer objectRenderer = renderer.GetObjectRenderer();
			objectRenderer.BlendMode = (this.AdditiveBlending ? BlendMode.Additive : BlendMode.Alpha);
			objectRenderer.Render(this._animationInstance, false, false);
		}

		// Token: 0x04000954 RID: 2388
		private readonly string _animationGroupResourceKey;

		// Token: 0x04000955 RID: 2389
		private AnimationInstance _animationInstance;
	}
}
