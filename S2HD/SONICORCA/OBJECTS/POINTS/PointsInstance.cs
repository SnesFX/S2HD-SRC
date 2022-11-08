using System;
using SonicOrca.Core;
using SonicOrca.Core.Objects.Metadata;
using SonicOrca.Geometry;
using SonicOrca.Graphics;

namespace SONICORCA.OBJECTS.POINTS
{
	// Token: 0x0200001B RID: 27
	public class PointsInstance : ActiveObject
	{
		// Token: 0x17000019 RID: 25
		// (get) Token: 0x060000AA RID: 170 RVA: 0x00007310 File Offset: 0x00005510
		// (set) Token: 0x060000AB RID: 171 RVA: 0x00007318 File Offset: 0x00005518
		[StateVariable]
		public int Value
		{
			get
			{
				return this._value;
			}
			set
			{
				this._value = value;
			}
		}

		// Token: 0x060000AC RID: 172 RVA: 0x00007324 File Offset: 0x00005524
		protected override void OnStart()
		{
			this._font = base.Level.GameContext.ResourceTree.GetLoadedResource<Font>(base.Type, "SONICORCA/FONTS/POINTS");
			this._velocityY = -12.0;
			base.Priority = 2304;
		}

		// Token: 0x060000AD RID: 173 RVA: 0x00007374 File Offset: 0x00005574
		protected override void OnUpdate()
		{
			if (this._velocityY >= 0.0)
			{
				base.FinishForever();
				return;
			}
			base.PositionPrecise += new Vector2(0.0, this._velocityY);
			this._velocityY += 0.375;
		}

		// Token: 0x060000AE RID: 174 RVA: 0x000073D4 File Offset: 0x000055D4
		protected override void OnDraw(Renderer renderer, LayerViewOptions viewOptions)
		{
			renderer.GetFontRenderer().RenderStringWithShadow(this._value.ToString(), default(Rectangle), FontAlignment.Centre, this._font, Colours.White, null);
		}

		// Token: 0x040000B4 RID: 180
		private Font _font;

		// Token: 0x040000B5 RID: 181
		private int _value;

		// Token: 0x040000B6 RID: 182
		private double _velocityY;
	}
}
