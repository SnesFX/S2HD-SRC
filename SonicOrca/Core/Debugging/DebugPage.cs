using System;
using System.Collections.Generic;
using SonicOrca.Graphics;

namespace SonicOrca.Core.Debugging
{
	// Token: 0x02000192 RID: 402
	internal class DebugPage
	{
		// Token: 0x17000491 RID: 1169
		// (get) Token: 0x0600115F RID: 4447 RVA: 0x00044BAF File Offset: 0x00042DAF
		public string Name
		{
			get
			{
				return this._name;
			}
		}

		// Token: 0x17000492 RID: 1170
		// (get) Token: 0x06001160 RID: 4448 RVA: 0x00044BB7 File Offset: 0x00042DB7
		public IList<DebugOption> Options
		{
			get
			{
				return this._options;
			}
		}

		// Token: 0x06001161 RID: 4449 RVA: 0x00044BBF File Offset: 0x00042DBF
		public DebugPage(DebugContext context, string name)
		{
			this._context = context;
			this._name = name;
		}

		// Token: 0x06001162 RID: 4450 RVA: 0x00044BE0 File Offset: 0x00042DE0
		public DebugPage(DebugContext context, string name, IEnumerable<DebugOption> options)
		{
			this._context = context;
			this._name = name;
			this._options.AddRange(options);
		}

		// Token: 0x06001163 RID: 4451 RVA: 0x00044C10 File Offset: 0x00042E10
		public void Draw(Renderer renderer)
		{
			string text = string.Empty;
			I2dRenderer i2dRenderer = renderer.Get2dRenderer();
			using (i2dRenderer.BeginMatixState())
			{
				foreach (DebugOption debugOption in this._options)
				{
					if (debugOption.Category != text)
					{
						text = debugOption.Category;
						i2dRenderer.ModelMatrix = i2dRenderer.ModelMatrix.Translate(0.0, 32.0, 0.0);
						int num = (int)this._context.DrawText(renderer, text, FontAlignment.Left, 0.0, 0.0, 0.75, new int?(0));
						i2dRenderer.ModelMatrix = i2dRenderer.ModelMatrix.Translate(0.0, (double)(num + 16), 0.0);
					}
					i2dRenderer.ModelMatrix = i2dRenderer.ModelMatrix.Translate(0.0, (double)(debugOption.Draw(renderer) + 16), 0.0);
				}
			}
		}

		// Token: 0x040009BA RID: 2490
		private readonly DebugContext _context;

		// Token: 0x040009BB RID: 2491
		private readonly string _name;

		// Token: 0x040009BC RID: 2492
		private readonly List<DebugOption> _options = new List<DebugOption>();
	}
}
