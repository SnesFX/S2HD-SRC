using System;
using SonicOrca.Geometry;
using SonicOrca.Graphics;

namespace SonicOrca.Menu
{
	// Token: 0x020000A7 RID: 167
	public class FadeTransition
	{
		// Token: 0x170000BA RID: 186
		// (get) Token: 0x06000574 RID: 1396 RVA: 0x0001B74D File Offset: 0x0001994D
		// (set) Token: 0x06000575 RID: 1397 RVA: 0x0001B755 File Offset: 0x00019955
		public double Opacity { get; private set; }

		// Token: 0x170000BB RID: 187
		// (get) Token: 0x06000576 RID: 1398 RVA: 0x0001B75E File Offset: 0x0001995E
		// (set) Token: 0x06000577 RID: 1399 RVA: 0x0001B766 File Offset: 0x00019966
		public Colour Colour { get; set; }

		// Token: 0x170000BC RID: 188
		// (get) Token: 0x06000578 RID: 1400 RVA: 0x0001B76F File Offset: 0x0001996F
		// (set) Token: 0x06000579 RID: 1401 RVA: 0x0001B777 File Offset: 0x00019977
		public int Duration { get; set; }

		// Token: 0x170000BD RID: 189
		// (get) Token: 0x0600057A RID: 1402 RVA: 0x0001B780 File Offset: 0x00019980
		// (set) Token: 0x0600057B RID: 1403 RVA: 0x0001B788 File Offset: 0x00019988
		public int UpdatesRemaining { get; set; }

		// Token: 0x170000BE RID: 190
		// (get) Token: 0x0600057C RID: 1404 RVA: 0x0001B791 File Offset: 0x00019991
		public bool Finished
		{
			get
			{
				return this.UpdatesRemaining <= 0;
			}
		}

		// Token: 0x0600057D RID: 1405 RVA: 0x0001B79F File Offset: 0x0001999F
		public FadeTransition(int duration) : this(Colours.Black, duration)
		{
		}

		// Token: 0x0600057E RID: 1406 RVA: 0x0001B7AD File Offset: 0x000199AD
		public FadeTransition(Colour colour, int duration)
		{
			this.Colour = colour;
			this.Duration = duration;
		}

		// Token: 0x0600057F RID: 1407 RVA: 0x0001B7C3 File Offset: 0x000199C3
		public void Clear()
		{
			this.Opacity = 0.0;
			this.UpdatesRemaining = 0;
		}

		// Token: 0x06000580 RID: 1408 RVA: 0x0001B7DB File Offset: 0x000199DB
		public void Set()
		{
			this.Opacity = 1.0;
			this.UpdatesRemaining = 0;
		}

		// Token: 0x06000581 RID: 1409 RVA: 0x0001B7F3 File Offset: 0x000199F3
		public void BeginFadeIn()
		{
			this._decreasingOpacity = true;
			this.UpdatesRemaining = this.Duration;
			this.Update();
		}

		// Token: 0x06000582 RID: 1410 RVA: 0x0001B80E File Offset: 0x00019A0E
		public void BeginFadeOut()
		{
			this._decreasingOpacity = false;
			this.UpdatesRemaining = this.Duration;
			this.Update();
		}

		// Token: 0x06000583 RID: 1411 RVA: 0x0001B82C File Offset: 0x00019A2C
		public void Update()
		{
			if (this.UpdatesRemaining <= 0)
			{
				return;
			}
			this.Opacity = (double)((float)this.UpdatesRemaining / (float)this.Duration);
			if (!this._decreasingOpacity)
			{
				this.Opacity = 1.0 - this.Opacity;
			}
			int updatesRemaining = this.UpdatesRemaining;
			this.UpdatesRemaining = updatesRemaining - 1;
		}

		// Token: 0x06000584 RID: 1412 RVA: 0x0001B888 File Offset: 0x00019A88
		public void Draw(Renderer renderer)
		{
			I2dRenderer i2dRenderer = renderer.Get2dRenderer();
			Colour colour = this.Colour;
			colour.Alpha = (byte)(this.Opacity * 255.0);
			i2dRenderer.BlendMode = BlendMode.Alpha;
			i2dRenderer.RenderQuad(colour, new Rectangle(0.0, 0.0, 1920.0, 1080.0));
		}

		// Token: 0x0400033F RID: 831
		private bool _decreasingOpacity;
	}
}
