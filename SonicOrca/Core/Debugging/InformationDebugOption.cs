using System;
using System.Collections.Generic;
using System.Linq;
using SonicOrca.Geometry;
using SonicOrca.Graphics;

namespace SonicOrca.Core.Debugging
{
	// Token: 0x02000194 RID: 404
	internal class InformationDebugOption : DebugOption
	{
		// Token: 0x0600116B RID: 4459 RVA: 0x00044FA4 File Offset: 0x000431A4
		public InformationDebugOption(DebugContext context, string page, string category) : base(context, page, category, false)
		{
		}

		// Token: 0x0600116C RID: 4460 RVA: 0x00044FB0 File Offset: 0x000431B0
		protected virtual IEnumerable<IEnumerable<KeyValuePair<string, object>>> GetInformation()
		{
			yield return new KeyValuePair<string, object>[]
			{
				new KeyValuePair<string, object>("UNDEFINED", "INFORMATION")
			};
			yield break;
		}

		// Token: 0x0600116D RID: 4461 RVA: 0x00044FBC File Offset: 0x000431BC
		public override int Draw(Renderer renderer)
		{
			int num = (int)((double)base.Context.Font.Height * 0.5);
			Rectangle r = new Rectangle(0.0, 0.0, 1888.0, (double)num);
			foreach (IEnumerable<KeyValuePair<string, object>> source in this.GetInformation())
			{
				this.Draw(renderer, r, source.ToArray<KeyValuePair<string, object>>());
				r.Y += (double)(num + 16);
			}
			return (int)r.Y - 16;
		}

		// Token: 0x0600116E RID: 4462 RVA: 0x00045074 File Offset: 0x00043274
		private void Draw(Renderer renderer, Rectanglei bounds, KeyValuePair<string, object>[] horizontalInfos)
		{
			if (horizontalInfos.Length == 0)
			{
				return;
			}
			int num = bounds.Width / horizontalInfos.Length;
			for (int i = 0; i < horizontalInfos.Length; i++)
			{
				int num2 = (i != horizontalInfos.Length - 1) ? 32 : 0;
				int num3 = (i != 0) ? 32 : 0;
				Rectanglei bounds2 = new Rectanglei(bounds.X + num * i + num3, bounds.Y, num - num3 - num2, bounds.Height);
				this.Draw(renderer, bounds2, horizontalInfos[i]);
			}
		}

		// Token: 0x0600116F RID: 4463 RVA: 0x000450F0 File Offset: 0x000432F0
		private void Draw(Renderer renderer, Rectanglei bounds, KeyValuePair<string, object> kvp)
		{
			if (!string.IsNullOrEmpty(kvp.Key))
			{
				base.Context.DrawText(renderer, kvp.Key.ToUpper() + ":", FontAlignment.Left, (double)bounds.Left, (double)bounds.Top, 0.5, new int?(0));
			}
			base.Context.DrawText(renderer, kvp.Value.ToString().ToUpper(), FontAlignment.Right, (double)bounds.Right, (double)bounds.Top, 0.5, new int?(0));
		}
	}
}
