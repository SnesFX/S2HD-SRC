using System;
using SonicOrca.Geometry;
using SonicOrca.Graphics.V2.Animation;

namespace SonicOrca.Graphics
{
	// Token: 0x020000E1 RID: 225
	public interface IObjectRenderer : IRenderer, IDisposable
	{
		// Token: 0x1700017E RID: 382
		// (get) Token: 0x060007A9 RID: 1961
		// (set) Token: 0x060007AA RID: 1962
		Colour AdditiveColour { get; set; }

		// Token: 0x1700017F RID: 383
		// (get) Token: 0x060007AB RID: 1963
		// (set) Token: 0x060007AC RID: 1964
		Colour MultiplyColour { get; set; }

		// Token: 0x17000180 RID: 384
		// (get) Token: 0x060007AD RID: 1965
		// (set) Token: 0x060007AE RID: 1966
		BlendMode BlendMode { get; set; }

		// Token: 0x17000181 RID: 385
		// (get) Token: 0x060007AF RID: 1967
		// (set) Token: 0x060007B0 RID: 1968
		Rectangle ClipRectangle { get; set; }

		// Token: 0x17000182 RID: 386
		// (get) Token: 0x060007B1 RID: 1969
		// (set) Token: 0x060007B2 RID: 1970
		Matrix4 ModelMatrix { get; set; }

		// Token: 0x17000183 RID: 387
		// (get) Token: 0x060007B3 RID: 1971
		// (set) Token: 0x060007B4 RID: 1972
		bool EmitsLight { get; set; }

		// Token: 0x17000184 RID: 388
		// (get) Token: 0x060007B5 RID: 1973
		// (set) Token: 0x060007B6 RID: 1974
		bool Shadow { get; set; }

		// Token: 0x17000185 RID: 389
		// (get) Token: 0x060007B7 RID: 1975
		// (set) Token: 0x060007B8 RID: 1976
		int Filter { get; set; }

		// Token: 0x17000186 RID: 390
		// (get) Token: 0x060007B9 RID: 1977
		// (set) Token: 0x060007BA RID: 1978
		double FilterAmount { get; set; }

		// Token: 0x17000187 RID: 391
		// (get) Token: 0x060007BB RID: 1979
		// (set) Token: 0x060007BC RID: 1980
		ITexture Texture { get; set; }

		// Token: 0x17000188 RID: 392
		// (get) Token: 0x060007BD RID: 1981
		// (set) Token: 0x060007BE RID: 1982
		Vector2 Scale { get; set; }

		// Token: 0x060007BF RID: 1983
		IDisposable BeginMatixState();

		// Token: 0x060007C0 RID: 1984
		void SetDefault();

		// Token: 0x060007C1 RID: 1985
		void Render(AnimationInstance animationInstance, bool flipX = false, bool flipY = false);

		// Token: 0x060007C2 RID: 1986
		void Render(AnimationInstance animationInstance, Vector2 destination, bool flipX = false, bool flipY = false);

		// Token: 0x060007C3 RID: 1987
		void Render(CompositionInstance compositionInstance, Vector2 destination, bool flipX = false, bool flipY = false);

		// Token: 0x060007C4 RID: 1988
		void Render(Vector2 destination = default(Vector2), bool flipX = false, bool flipY = false);

		// Token: 0x060007C5 RID: 1989
		void Render(Rectangle destination, bool flipX = false, bool flipY = false);

		// Token: 0x060007C6 RID: 1990
		void Render(Rectangle source, Vector2 destination, bool flipX = false, bool flipY = false);

		// Token: 0x060007C7 RID: 1991
		void Render(Rectangle source, Rectangle destination, bool flipX = false, bool flipY = false);
	}
}
