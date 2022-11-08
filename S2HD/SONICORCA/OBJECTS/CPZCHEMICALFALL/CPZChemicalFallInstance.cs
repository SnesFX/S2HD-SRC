using System;
using SonicOrca.Core;
using SonicOrca.Core.Objects.Base;
using SonicOrca.Extensions;
using SonicOrca.Geometry;
using SonicOrca.Graphics;

namespace SONICORCA.OBJECTS.CPZCHEMICALFALL
{
	// Token: 0x02000091 RID: 145
	public class CPZChemicalFallInstance : ActiveObject
	{
		// Token: 0x060002F8 RID: 760 RVA: 0x0001607C File Offset: 0x0001427C
		protected override void OnStart()
		{
			AnimationGroup loadedResource = base.ResourceTree.GetLoadedResource<AnimationGroup>(base.Type.GetAbsolutePath("/ANIGROUP"));
			this._animationCorner = new AnimationInstance(loadedResource, 0);
			this._animationVertical = new AnimationInstance(loadedResource, 1);
			base.DesignBounds = new Rectanglei(-32, -32, 64, 128);
			base.Priority = -64;
		}

		// Token: 0x060002F9 RID: 761 RVA: 0x000160DD File Offset: 0x000142DD
		protected override void OnUpdateEditor()
		{
			this.UpdateBottom();
		}

		// Token: 0x060002FA RID: 762 RVA: 0x000160E5 File Offset: 0x000142E5
		protected override void OnUpdate()
		{
			this.UpdateBottom();
			this.CreateDrops();
		}

		// Token: 0x060002FB RID: 763 RVA: 0x000160F3 File Offset: 0x000142F3
		protected override void OnAnimate()
		{
			this._animationCorner.Animate();
			this._animationVertical.Animate();
		}

		// Token: 0x060002FC RID: 764 RVA: 0x0001610C File Offset: 0x0001430C
		protected override void OnDraw(Renderer renderer, LayerViewOptions viewOptions)
		{
			IObjectRenderer objectRenderer = renderer.GetObjectRenderer();
			objectRenderer.Render(this._animationCorner, new Vector2(0.0, 0.0), false, false);
			objectRenderer.Texture = this._animationVertical.CurrentTexture;
			int y = this._animationCorner.CurrentFrame.Source.Height / 2;
			Rectanglei source = this._animationVertical.CurrentFrame.Source;
			Rectanglei r = new Rectanglei(-source.Width / 2, y, source.Width, source.Height);
			int num = this._bottom - base.Position.Y;
			while (r.Y < num)
			{
				int num2 = r.Bottom - num;
				source.Height -= num2;
				r.Height -= num2;
				objectRenderer.Render(source, r, false, false);
				r.Y += 64;
			}
		}

		// Token: 0x060002FD RID: 765 RVA: 0x00016220 File Offset: 0x00014420
		private void UpdateBottom()
		{
			int y = base.Position.Y;
			int num = base.Position.X - 32;
			int num2 = base.Position.Y + 32;
			int num3 = base.Level.Map.Bounds.Height;
			foreach (Rectanglei rectanglei in base.Level.WaterManager.WaterAreas)
			{
				if (rectanglei.Left <= num2 && rectanglei.Right >= num && rectanglei.Bottom >= y)
				{
					num3 = Math.Min(num3, rectanglei.Top);
				}
			}
			this._bottom = num3;
		}

		// Token: 0x060002FE RID: 766 RVA: 0x000162FC File Offset: 0x000144FC
		private void CreateDrops()
		{
			if (base.Level.Ticks % 30 != 0)
			{
				return;
			}
			Random random = base.Level.Random;
			int i = base.Position.Y + 64;
			int bottom = this._bottom;
			int num = 30;
			while (i < bottom)
			{
				int x = base.Position.X + num;
				if (random.Next(0, 4) == 0)
				{
					this.CreateDrop(x, i);
				}
				i += 32;
				num *= -1;
			}
		}

		// Token: 0x060002FF RID: 767 RVA: 0x00016378 File Offset: 0x00014578
		private void CreateDrop(int x, int y)
		{
			ObjectManager objectManager = base.Level.ObjectManager;
			Rectanglei rect = new Rectanglei(x - 16, y - 16, 32, 32);
			if (!objectManager.IsInLifetimeArea(rect))
			{
				return;
			}
			objectManager.AddSubObject<CPZChemicalFallInstance.Drop>(this).Position = new Vector2i(x, y);
		}

		// Token: 0x040003BE RID: 958
		private const int AnimationCorner = 0;

		// Token: 0x040003BF RID: 959
		private const int AnimationVertical = 1;

		// Token: 0x040003C0 RID: 960
		private const int AnimationDrop = 2;

		// Token: 0x040003C1 RID: 961
		private AnimationInstance _animationCorner;

		// Token: 0x040003C2 RID: 962
		private AnimationInstance _animationVertical;

		// Token: 0x040003C3 RID: 963
		private int _bottom;

		// Token: 0x02000101 RID: 257
		private class Drop : ParticleObject
		{
			// Token: 0x06000646 RID: 1606 RVA: 0x00025DA3 File Offset: 0x00023FA3
			public Drop() : base("/ANIGROUP", 2, 1)
			{
			}
		}
	}
}
