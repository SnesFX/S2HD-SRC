using System;
using System.Collections.Generic;

namespace SonicOrca.Graphics
{
	// Token: 0x020000BC RID: 188
	public interface IGraphicsContext
	{
		// Token: 0x17000108 RID: 264
		// (get) Token: 0x06000646 RID: 1606
		IReadOnlyCollection<ITexture> Textures { get; }

		// Token: 0x17000109 RID: 265
		// (get) Token: 0x06000647 RID: 1607
		IReadOnlyCollection<IShaderProgram> ShaderPrograms { get; }

		// Token: 0x1700010A RID: 266
		// (get) Token: 0x06000648 RID: 1608
		IReadOnlyCollection<VertexBuffer> VertexBuffers { get; }

		// Token: 0x1700010B RID: 267
		// (get) Token: 0x06000649 RID: 1609
		IReadOnlyCollection<IFramebuffer> RenderTargets { get; }

		// Token: 0x1700010C RID: 268
		// (get) Token: 0x0600064A RID: 1610
		// (set) Token: 0x0600064B RID: 1611
		bool DepthTesting { get; set; }

		// Token: 0x1700010D RID: 269
		// (get) Token: 0x0600064C RID: 1612
		// (set) Token: 0x0600064D RID: 1613
		BlendMode BlendMode { get; set; }

		// Token: 0x1700010E RID: 270
		// (get) Token: 0x0600064E RID: 1614
		// (set) Token: 0x0600064F RID: 1615
		PolygonMode PolygonMode { get; set; }

		// Token: 0x1700010F RID: 271
		// (get) Token: 0x06000650 RID: 1616
		IFramebuffer CurrentFramebuffer { get; }

		// Token: 0x06000651 RID: 1617
		IShader CreateShader(ShaderType type, string sourceCode);

		// Token: 0x06000652 RID: 1618
		IShaderProgram CreateShaderProgram(params IShader[] shaders);

		// Token: 0x06000653 RID: 1619
		IShaderProgram CreateShaderProgram(IEnumerable<IShader> shaders);

		// Token: 0x06000654 RID: 1620
		VertexBuffer CreateVertexBuffer(params int[] vectorCounts);

		// Token: 0x06000655 RID: 1621
		VertexBuffer CreateVertexBuffer(IEnumerable<int> vectorCounts);

		// Token: 0x06000656 RID: 1622
		VertexBuffer CreateVertexBuffer(IShaderProgram shaderProgram, IEnumerable<string> names, IEnumerable<int> vectorCounts);

		// Token: 0x06000657 RID: 1623
		ITexture CreateTexture(int width, int height);

		// Token: 0x06000658 RID: 1624
		ITexture CreateTexture(int width, int height, int channels, byte[] pixels, bool toCompress = false);

		// Token: 0x06000659 RID: 1625
		void SetTexture(ITexture texture);

		// Token: 0x0600065A RID: 1626
		void SetTexture(int index, ITexture texture);

		// Token: 0x0600065B RID: 1627
		void SetTextures(IEnumerable<ITexture> textures);

		// Token: 0x0600065C RID: 1628
		IFramebuffer CreateFrameBuffer(int width, int height, int numTextures = 1);

		// Token: 0x0600065D RID: 1629
		void RenderToBackBuffer();

		// Token: 0x0600065E RID: 1630
		void ClearBuffer();

		// Token: 0x0600065F RID: 1631
		void ClearDepthBuffer();

		// Token: 0x06000660 RID: 1632
		void ClearColourBuffer(int index);

		// Token: 0x06000661 RID: 1633
		IBuffer CreateBuffer();

		// Token: 0x06000662 RID: 1634
		IVertexArray CreateVertexArray();
	}
}
