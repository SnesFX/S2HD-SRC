using System;
using System.Drawing;
using OpenTK.Graphics;
using OpenTK.Input;

namespace OpenTK.Platform
{
	// Token: 0x02000066 RID: 102
	[Obsolete]
	internal interface INativeGLWindow : IDisposable
	{
		// Token: 0x060006E0 RID: 1760
		void CreateWindow(int width, int height, GraphicsMode mode, int major, int minor, GraphicsContextFlags flags, out IGraphicsContext context);

		// Token: 0x060006E1 RID: 1761
		void DestroyWindow();

		// Token: 0x060006E2 RID: 1762
		void ProcessEvents();

		// Token: 0x060006E3 RID: 1763
		Point PointToClient(Point point);

		// Token: 0x060006E4 RID: 1764
		Point PointToScreen(Point point);

		// Token: 0x1700015D RID: 349
		// (get) Token: 0x060006E5 RID: 1765
		bool Exists { get; }

		// Token: 0x1700015E RID: 350
		// (get) Token: 0x060006E6 RID: 1766
		IWindowInfo WindowInfo { get; }

		// Token: 0x1700015F RID: 351
		// (get) Token: 0x060006E7 RID: 1767
		// (set) Token: 0x060006E8 RID: 1768
		string Title { get; set; }

		// Token: 0x17000160 RID: 352
		// (get) Token: 0x060006E9 RID: 1769
		// (set) Token: 0x060006EA RID: 1770
		bool Visible { get; set; }

		// Token: 0x17000161 RID: 353
		// (get) Token: 0x060006EB RID: 1771
		bool IsIdle { get; }

		// Token: 0x17000162 RID: 354
		// (get) Token: 0x060006EC RID: 1772
		IInputDriver InputDriver { get; }

		// Token: 0x17000163 RID: 355
		// (get) Token: 0x060006ED RID: 1773
		// (set) Token: 0x060006EE RID: 1774
		WindowState WindowState { get; set; }

		// Token: 0x17000164 RID: 356
		// (get) Token: 0x060006EF RID: 1775
		// (set) Token: 0x060006F0 RID: 1776
		WindowBorder WindowBorder { get; set; }

		// Token: 0x14000031 RID: 49
		// (add) Token: 0x060006F1 RID: 1777
		// (remove) Token: 0x060006F2 RID: 1778
		event CreateEvent Create;

		// Token: 0x14000032 RID: 50
		// (add) Token: 0x060006F3 RID: 1779
		// (remove) Token: 0x060006F4 RID: 1780
		event DestroyEvent Destroy;
	}
}
