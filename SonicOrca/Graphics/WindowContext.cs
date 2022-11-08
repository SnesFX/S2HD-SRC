using System;
using SonicOrca.Geometry;

namespace SonicOrca.Graphics
{
	// Token: 0x020000E6 RID: 230
	public abstract class WindowContext : IDisposable
	{
		// Token: 0x17000190 RID: 400
		// (get) Token: 0x060007E6 RID: 2022 RVA: 0x0001F4AF File Offset: 0x0001D6AF
		// (set) Token: 0x060007E7 RID: 2023 RVA: 0x0001F4B7 File Offset: 0x0001D6B7
		public virtual bool FullScreen { get; set; }

		// Token: 0x17000191 RID: 401
		// (get) Token: 0x060007E8 RID: 2024 RVA: 0x0001F4C0 File Offset: 0x0001D6C0
		// (set) Token: 0x060007E9 RID: 2025 RVA: 0x0001F4C8 File Offset: 0x0001D6C8
		public virtual VideoMode Mode { get; set; }

		// Token: 0x17000192 RID: 402
		// (get) Token: 0x060007EA RID: 2026 RVA: 0x0001F4D1 File Offset: 0x0001D6D1
		// (set) Token: 0x060007EB RID: 2027 RVA: 0x0001F4D9 File Offset: 0x0001D6D9
		public virtual string WindowTitle { get; set; }

		// Token: 0x17000193 RID: 403
		// (get) Token: 0x060007EC RID: 2028 RVA: 0x0001F4E2 File Offset: 0x0001D6E2
		// (set) Token: 0x060007ED RID: 2029 RVA: 0x0001F4EA File Offset: 0x0001D6EA
		public virtual Vector2i ClientSize { get; set; }

		// Token: 0x17000194 RID: 404
		// (get) Token: 0x060007EE RID: 2030 RVA: 0x0001F4F3 File Offset: 0x0001D6F3
		// (set) Token: 0x060007EF RID: 2031 RVA: 0x0001F4FB File Offset: 0x0001D6FB
		public virtual Vector2i AspectRatio { get; set; }

		// Token: 0x17000195 RID: 405
		// (get) Token: 0x060007F0 RID: 2032 RVA: 0x0001F504 File Offset: 0x0001D704
		// (set) Token: 0x060007F1 RID: 2033 RVA: 0x0001F50C File Offset: 0x0001D70C
		public virtual bool HideCursorIfIdle { get; set; }

		// Token: 0x17000196 RID: 406
		// (get) Token: 0x060007F2 RID: 2034 RVA: 0x0001F515 File Offset: 0x0001D715
		// (set) Token: 0x060007F3 RID: 2035 RVA: 0x0001F51D File Offset: 0x0001D71D
		public bool Finished { get; protected set; }

		// Token: 0x17000197 RID: 407
		// (get) Token: 0x060007F4 RID: 2036 RVA: 0x0000AB58 File Offset: 0x00008D58
		public virtual IGraphicsContext GraphicsContext
		{
			get
			{
				return null;
			}
		}

		// Token: 0x17000198 RID: 408
		// (get) Token: 0x060007F5 RID: 2037 RVA: 0x0001F528 File Offset: 0x0001D728
		public Rectanglei ClientBounds
		{
			get
			{
				Vector2i clientSize = this.ClientSize;
				return new Rectanglei(0, 0, clientSize.X, clientSize.Y);
			}
		}

		// Token: 0x060007F6 RID: 2038
		public abstract void Dispose();

		// Token: 0x060007F7 RID: 2039 RVA: 0x00006325 File Offset: 0x00004525
		public virtual void Update()
		{
		}

		// Token: 0x060007F8 RID: 2040 RVA: 0x00006325 File Offset: 0x00004525
		public virtual void BeginRender()
		{
		}

		// Token: 0x060007F9 RID: 2041 RVA: 0x00006325 File Offset: 0x00004525
		public virtual void EndRender()
		{
		}
	}
}
