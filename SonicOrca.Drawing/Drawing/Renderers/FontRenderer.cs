using System;
using System.Collections.Generic;
using SonicOrca.Geometry;
using SonicOrca.Graphics;

namespace SonicOrca.Drawing.Renderers
{
	// Token: 0x02000007 RID: 7
	public class FontRenderer : IFontRenderer
	{
		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000049 RID: 73 RVA: 0x00002C13 File Offset: 0x00000E13
		// (set) Token: 0x0600004A RID: 74 RVA: 0x00002C1B File Offset: 0x00000E1B
		public Font Font { get; set; }

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x0600004B RID: 75 RVA: 0x00002C24 File Offset: 0x00000E24
		// (set) Token: 0x0600004C RID: 76 RVA: 0x00002C2C File Offset: 0x00000E2C
		public Colour Colour { get; set; }

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x0600004D RID: 77 RVA: 0x00002C35 File Offset: 0x00000E35
		// (set) Token: 0x0600004E RID: 78 RVA: 0x00002C3D File Offset: 0x00000E3D
		public Rectangle Boundary { get; set; }

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x0600004F RID: 79 RVA: 0x00002C46 File Offset: 0x00000E46
		// (set) Token: 0x06000050 RID: 80 RVA: 0x00002C4E File Offset: 0x00000E4E
		public FontAlignment Alignment { get; set; }

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x06000051 RID: 81 RVA: 0x00002C57 File Offset: 0x00000E57
		// (set) Token: 0x06000052 RID: 82 RVA: 0x00002C5F File Offset: 0x00000E5F
		public Vector2 Shadow { get; set; }

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x06000053 RID: 83 RVA: 0x00002C68 File Offset: 0x00000E68
		// (set) Token: 0x06000054 RID: 84 RVA: 0x00002C70 File Offset: 0x00000E70
		public int Overlay { get; set; }

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x06000055 RID: 85 RVA: 0x00002C79 File Offset: 0x00000E79
		// (set) Token: 0x06000056 RID: 86 RVA: 0x00002C81 File Offset: 0x00000E81
		public string Text { get; set; }

		// Token: 0x06000057 RID: 87 RVA: 0x00002C8A File Offset: 0x00000E8A
		public static FontRenderer FromRenderer(Renderer renderer)
		{
			if (!FontRenderer.RendererDictionary.ContainsKey(renderer))
			{
				FontRenderer.RendererDictionary.Add(renderer, new FontRenderer(renderer));
			}
			return FontRenderer.RendererDictionary[renderer];
		}

		// Token: 0x06000058 RID: 88 RVA: 0x00002CB5 File Offset: 0x00000EB5
		public FontRenderer(Renderer renderer)
		{
			this._renderer = renderer;
		}

		// Token: 0x06000059 RID: 89 RVA: 0x00002CD0 File Offset: 0x00000ED0
		public Rectangle Measure()
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600005A RID: 90 RVA: 0x00002CD7 File Offset: 0x00000ED7
		public void RenderString(string text, Rectangle boundary, FontAlignment fontAlignment, Font font, int overlay)
		{
			this.RenderString(text, boundary, fontAlignment, font, Colours.White, new int?(overlay));
		}

		// Token: 0x0600005B RID: 91 RVA: 0x00002CF0 File Offset: 0x00000EF0
		public void RenderString(string text, Rectangle boundary, FontAlignment fontAlignment, Font font, Colour colour, int? overlay = null)
		{
			this.RenderStringWithShadow(text, boundary, fontAlignment, font, colour, overlay, null, Colours.Black, null);
		}

		// Token: 0x0600005C RID: 92 RVA: 0x00002D24 File Offset: 0x00000F24
		public void RenderStringWithShadow(string text, Rectangle boundary, FontAlignment fontAlignment, Font font, int overlay)
		{
			this.RenderStringWithShadow(text, boundary, fontAlignment, font, Colours.White, new int?(overlay), font.DefaultShadow, Colours.Black, null);
		}

		// Token: 0x0600005D RID: 93 RVA: 0x00002D60 File Offset: 0x00000F60
		public void RenderStringWithShadow(string text, Rectangle boundary, FontAlignment fontAlignment, Font font, Colour colour, int? overlay = null)
		{
			this.RenderStringWithShadow(text, boundary, fontAlignment, font, colour, overlay, font.DefaultShadow, new Colour(colour.Alpha, 0, 0, 0), null);
		}

		// Token: 0x0600005E RID: 94 RVA: 0x00002D9C File Offset: 0x00000F9C
		public void RenderStringWithShadow(string text, Rectangle boundary, FontAlignment fontAlignment, Font font, Colour colour, int? overlay, Vector2i? shadow, Colour shadowColour, int? shadowOverlay)
		{
			SimpleRenderer g = SimpleRenderer.FromRenderer(this._renderer);
			Rectangle rectangle = font.MeasureString(text, boundary, fontAlignment);
			Vector2 destination = new Vector2(rectangle.X, rectangle.Y);
			if (shadow != null)
			{
				this.RenderStringWithShadow(text, boundary + shadow.Value, fontAlignment, font, shadowColour, shadowOverlay, null, default(Colour), null);
			}
			foreach (char key in text)
			{
				Font.CharacterDefinition characterDefinition = font[key];
				if (characterDefinition == null)
				{
					destination.X += (double)font.DefaultWidth;
				}
				else
				{
					this.RenderCharacter(g, font, characterDefinition, destination, colour, overlay);
					destination.X += (double)characterDefinition.Width;
				}
				destination.X += (double)font.Tracking;
			}
		}

		// Token: 0x0600005F RID: 95 RVA: 0x00002EA4 File Offset: 0x000010A4
		private void RenderCharacter(SimpleRenderer g, Font font, Font.CharacterDefinition characterDefinition, Vector2 destination, Colour colour, int? overlay)
		{
			this.textures[0] = font.ShapeTexture;
			if (overlay != null)
			{
				this.textures[1] = font.OverlayTextures[overlay.Value];
			}
			Rectangle source = characterDefinition.SourceRectangle;
			Rectangle destination2 = new Rectangle(destination.X + (double)characterDefinition.Offset.X, destination.Y + (double)characterDefinition.Offset.Y, source.Width, source.Height);
			destination2.X *= this._renderer.GetObjectRenderer().Scale.X;
			destination2.Y *= this._renderer.GetObjectRenderer().Scale.Y;
			destination2.Width *= this._renderer.GetObjectRenderer().Scale.X;
			destination2.Height *= this._renderer.GetObjectRenderer().Scale.Y;
			g.BlendMode = BlendMode.Alpha;
			g.Colour = colour;
			if (overlay != null)
			{
				g.RenderTexture(this.textures, source, destination2, false, false);
				return;
			}
			g.RenderTexture(this.textures[0], source, destination2, false, false);
		}

		// Token: 0x06000060 RID: 96 RVA: 0x00003004 File Offset: 0x00001204
		public void Render()
		{
			SimpleRenderer.FromRenderer(this._renderer);
		}

		// Token: 0x04000017 RID: 23
		private static readonly Dictionary<Renderer, FontRenderer> RendererDictionary = new Dictionary<Renderer, FontRenderer>();

		// Token: 0x04000018 RID: 24
		private readonly Renderer _renderer;

		// Token: 0x04000020 RID: 32
		private ITexture[] textures = new ITexture[2];
	}
}
