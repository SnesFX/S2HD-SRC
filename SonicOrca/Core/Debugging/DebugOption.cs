using System;
using SonicOrca.Graphics;

namespace SonicOrca.Core.Debugging
{
	// Token: 0x02000190 RID: 400
	public class DebugOption
	{
		// Token: 0x1700048D RID: 1165
		// (get) Token: 0x06001156 RID: 4438 RVA: 0x00044A7F File Offset: 0x00042C7F
		public DebugContext Context
		{
			get
			{
				return this._context;
			}
		}

		// Token: 0x1700048E RID: 1166
		// (get) Token: 0x06001157 RID: 4439 RVA: 0x00044A87 File Offset: 0x00042C87
		public string Page
		{
			get
			{
				return this._page;
			}
		}

		// Token: 0x1700048F RID: 1167
		// (get) Token: 0x06001158 RID: 4440 RVA: 0x00044A8F File Offset: 0x00042C8F
		public string Category
		{
			get
			{
				return this._category;
			}
		}

		// Token: 0x17000490 RID: 1168
		// (get) Token: 0x06001159 RID: 4441 RVA: 0x00044A97 File Offset: 0x00042C97
		public bool Selectable
		{
			get
			{
				return this._selectable;
			}
		}

		// Token: 0x0600115A RID: 4442 RVA: 0x00044A9F File Offset: 0x00042C9F
		public DebugOption(DebugContext context, string page, string category, bool selectable = true)
		{
			this._context = context;
			this._page = page;
			this._category = category;
			this._selectable = selectable;
		}

		// Token: 0x0600115B RID: 4443 RVA: 0x00006325 File Offset: 0x00004525
		public virtual void OnPressLeft()
		{
		}

		// Token: 0x0600115C RID: 4444 RVA: 0x00006325 File Offset: 0x00004525
		public virtual void OnPressRight()
		{
		}

		// Token: 0x0600115D RID: 4445 RVA: 0x00044AC4 File Offset: 0x00042CC4
		public virtual int Draw(Renderer renderer)
		{
			return 32;
		}

		// Token: 0x040009B6 RID: 2486
		private readonly DebugContext _context;

		// Token: 0x040009B7 RID: 2487
		private readonly string _page;

		// Token: 0x040009B8 RID: 2488
		private readonly string _category;

		// Token: 0x040009B9 RID: 2489
		private readonly bool _selectable;
	}
}
