using System;
using SonicOrca.Geometry;

namespace SonicOrca.Graphics
{
	// Token: 0x020000B8 RID: 184
	public static class TextRenderingHelpers
	{
		// Token: 0x06000627 RID: 1575 RVA: 0x0001CC58 File Offset: 0x0001AE58
		public static Rectangle RenderWith2d(I2dRenderer g, TextRenderInfo textRenderInfo)
		{
			if (string.IsNullOrEmpty(textRenderInfo.Text) || textRenderInfo.Colour.Alpha == 0)
			{
				return default(Rectangle);
			}
			if (textRenderInfo.Shadow != default(Vector2))
			{
				TextRenderInfo textRenderInfo2 = new TextRenderInfo();
				textRenderInfo2.Font = textRenderInfo.Font;
				textRenderInfo2.Bounds = textRenderInfo.Bounds.OffsetBy(textRenderInfo.Shadow);
				textRenderInfo2.Alignment = textRenderInfo.Alignment;
				textRenderInfo2.Colour = textRenderInfo.ShadowColour;
				textRenderInfo2.Overlay = textRenderInfo.ShadowOverlay;
				textRenderInfo2.Text = textRenderInfo.Text;
			}
			return TextRenderingHelpers.RenderWith2dInternal(g, textRenderInfo);
		}

		// Token: 0x06000628 RID: 1576 RVA: 0x0001CD08 File Offset: 0x0001AF08
		private static Rectangle RenderWith2dInternal(I2dRenderer g, TextRenderInfo textRenderInfo)
		{
			Font font = textRenderInfo.Font;
			string text = textRenderInfo.Text;
			Colour colour = textRenderInfo.Colour;
			int? overlay = textRenderInfo.Overlay;
			Rectangle result = font.MeasureString(text, textRenderInfo.Bounds, textRenderInfo.Alignment);
			FontAlignment fontAlignment = textRenderInfo.Alignment & FontAlignment.HorizontalMask;
			if (fontAlignment == FontAlignment.MiddleX)
			{
				result.X += result.Width * (double)textRenderInfo.SizeMultiplier / 2.0;
			}
			else if (fontAlignment == FontAlignment.Right)
			{
				result.X += result.Width * (double)textRenderInfo.SizeMultiplier;
			}
			FontAlignment fontAlignment2 = textRenderInfo.Alignment & FontAlignment.VerticalMask;
			if (fontAlignment2 == FontAlignment.MiddleY)
			{
				double num = (double)((float)font.Height * textRenderInfo.SizeMultiplier);
				result.Y += (result.Height - num) / 2.0;
			}
			else if (fontAlignment2 == FontAlignment.Bottom)
			{
				result.X += result.Height * (double)textRenderInfo.SizeMultiplier;
			}
			Vector2 destination = new Vector2(result.X, result.Y);
			foreach (char key in text)
			{
				Font.CharacterDefinition characterDefinition = font[key];
				if (characterDefinition == null)
				{
					destination.X += (double)((float)font.DefaultWidth * textRenderInfo.SizeMultiplier);
				}
				else
				{
					TextRenderingHelpers.RenderCharacter(g, font, characterDefinition, destination, colour, overlay, textRenderInfo.SizeMultiplier);
					destination.X += (double)((float)characterDefinition.Width * textRenderInfo.SizeMultiplier);
				}
				destination.X += (double)((float)font.Tracking * textRenderInfo.SizeMultiplier);
			}
			return result;
		}

		// Token: 0x06000629 RID: 1577 RVA: 0x0001CEC4 File Offset: 0x0001B0C4
		private static void RenderCharacter(I2dRenderer g, Font font, Font.CharacterDefinition characterDefinition, Vector2 destination, Colour colour, int? overlay, float sizeMultiplier)
		{
			ITexture[] array = new ITexture[2];
			array[0] = font.ShapeTexture;
			if (overlay != null)
			{
				array[1] = font.OverlayTextures[overlay.Value];
			}
			Rectangle source = characterDefinition.SourceRectangle;
			Rectangle destination2 = new Rectangle(destination.X + (double)((float)characterDefinition.Offset.X * sizeMultiplier), destination.Y + (double)((float)characterDefinition.Offset.Y * sizeMultiplier), source.Width * (double)sizeMultiplier, source.Height * (double)sizeMultiplier);
			g.BlendMode = BlendMode.Alpha;
			g.Colour = colour;
			if (overlay != null)
			{
				g.RenderTexture(array, source, destination2, false, false);
				return;
			}
			g.RenderTexture(array[0], source, destination2, false, false);
		}

		// Token: 0x0600062A RID: 1578 RVA: 0x0001CF90 File Offset: 0x0001B190
		public static Rectangle MeasureWith2d(I2dRenderer g, TextRenderInfo textRenderInfo)
		{
			Font font = textRenderInfo.Font;
			string text = textRenderInfo.Text;
			Colour colour = textRenderInfo.Colour;
			int? overlay = textRenderInfo.Overlay;
			Rectangle result = font.MeasureString(text, textRenderInfo.Bounds, textRenderInfo.Alignment);
			FontAlignment fontAlignment = textRenderInfo.Alignment & FontAlignment.HorizontalMask;
			if (fontAlignment == FontAlignment.MiddleX)
			{
				result.X += result.Width * (double)textRenderInfo.SizeMultiplier / 2.0;
			}
			else if (fontAlignment == FontAlignment.Right)
			{
				result.X += result.Width * (double)textRenderInfo.SizeMultiplier;
			}
			FontAlignment fontAlignment2 = textRenderInfo.Alignment & FontAlignment.VerticalMask;
			if (fontAlignment2 == FontAlignment.MiddleY)
			{
				result.Y += result.Height * (double)textRenderInfo.SizeMultiplier / 2.0;
			}
			else if (fontAlignment2 == FontAlignment.Right)
			{
				result.X += result.Height * (double)textRenderInfo.SizeMultiplier;
			}
			Vector2 vector = new Vector2(result.X, result.Y);
			foreach (char key in text)
			{
				Font.CharacterDefinition characterDefinition = font[key];
				if (characterDefinition == null)
				{
					vector.X += (double)((float)font.DefaultWidth * textRenderInfo.SizeMultiplier);
				}
				else
				{
					vector.X += (double)((float)characterDefinition.Width * textRenderInfo.SizeMultiplier);
				}
				vector.X += (double)((float)font.Tracking * textRenderInfo.SizeMultiplier);
			}
			return result;
		}
	}
}
