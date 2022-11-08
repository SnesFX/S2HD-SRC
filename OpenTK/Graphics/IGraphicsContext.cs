using System;
using OpenTK.Platform;

namespace OpenTK.Graphics
{
	// Token: 0x02000026 RID: 38
	public interface IGraphicsContext : IDisposable
	{
		// Token: 0x06000476 RID: 1142
		void SwapBuffers();

		// Token: 0x06000477 RID: 1143
		void MakeCurrent(IWindowInfo window);

		// Token: 0x170000ED RID: 237
		// (get) Token: 0x06000478 RID: 1144
		bool IsCurrent { get; }

		// Token: 0x170000EE RID: 238
		// (get) Token: 0x06000479 RID: 1145
		bool IsDisposed { get; }

		// Token: 0x170000EF RID: 239
		// (get) Token: 0x0600047A RID: 1146
		// (set) Token: 0x0600047B RID: 1147
		[Obsolete("Use SwapInterval property instead.")]
		bool VSync { get; set; }

		// Token: 0x170000F0 RID: 240
		// (get) Token: 0x0600047C RID: 1148
		// (set) Token: 0x0600047D RID: 1149
		int SwapInterval { get; set; }

		// Token: 0x0600047E RID: 1150
		void Update(IWindowInfo window);

		// Token: 0x170000F1 RID: 241
		// (get) Token: 0x0600047F RID: 1151
		GraphicsMode GraphicsMode { get; }

		// Token: 0x170000F2 RID: 242
		// (get) Token: 0x06000480 RID: 1152
		// (set) Token: 0x06000481 RID: 1153
		bool ErrorChecking { get; set; }

		// Token: 0x06000482 RID: 1154
		void LoadAll();
	}
}
