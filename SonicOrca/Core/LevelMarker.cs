using System;
using SonicOrca.Geometry;

namespace SonicOrca.Core
{
	// Token: 0x0200012B RID: 299
	public class LevelMarker
	{
		// Token: 0x170002CE RID: 718
		// (get) Token: 0x06000BC0 RID: 3008 RVA: 0x0002DB80 File Offset: 0x0002BD80
		// (set) Token: 0x06000BC1 RID: 3009 RVA: 0x0002DB88 File Offset: 0x0002BD88
		public string Name { get; set; }

		// Token: 0x170002CF RID: 719
		// (get) Token: 0x06000BC2 RID: 3010 RVA: 0x0002DB91 File Offset: 0x0002BD91
		// (set) Token: 0x06000BC3 RID: 3011 RVA: 0x0002DB99 File Offset: 0x0002BD99
		public string Tag
		{
			get
			{
				return this._tag;
			}
			set
			{
				this._tag = ((value == null) ? string.Empty : value);
			}
		}

		// Token: 0x170002D0 RID: 720
		// (get) Token: 0x06000BC4 RID: 3012 RVA: 0x0002DBAC File Offset: 0x0002BDAC
		// (set) Token: 0x06000BC5 RID: 3013 RVA: 0x0002DBB4 File Offset: 0x0002BDB4
		public Rectanglei Bounds { get; set; }

		// Token: 0x170002D1 RID: 721
		// (get) Token: 0x06000BC6 RID: 3014 RVA: 0x0002DBBD File Offset: 0x0002BDBD
		// (set) Token: 0x06000BC7 RID: 3015 RVA: 0x0002DBC5 File Offset: 0x0002BDC5
		public LevelLayer Layer { get; set; }

		// Token: 0x170002D2 RID: 722
		// (get) Token: 0x06000BC8 RID: 3016 RVA: 0x0002DBD0 File Offset: 0x0002BDD0
		// (set) Token: 0x06000BC9 RID: 3017 RVA: 0x0002DBEB File Offset: 0x0002BDEB
		public Vector2i Position
		{
			get
			{
				return this.Bounds.TopLeft;
			}
			set
			{
				this.Bounds = new Rectanglei(value.X, value.Y, 0, 0);
			}
		}

		// Token: 0x06000BCA RID: 3018 RVA: 0x0002DC08 File Offset: 0x0002BE08
		public LevelMarker(string name, string tag, Vector2i position, LevelLayer layer)
		{
			this.Name = name;
			this.Tag = tag;
			this.Bounds = new Rectanglei(position.X, position.Y, 0, 0);
			this.Layer = layer;
		}

		// Token: 0x06000BCB RID: 3019 RVA: 0x0002DC57 File Offset: 0x0002BE57
		public LevelMarker(string name, string tag, Rectanglei bounds, LevelLayer layer)
		{
			this.Name = name;
			this.Tag = tag;
			this.Bounds = bounds;
			this.Layer = layer;
		}

		// Token: 0x06000BCC RID: 3020 RVA: 0x0002DC87 File Offset: 0x0002BE87
		public override string ToString()
		{
			return this.Name;
		}

		// Token: 0x040006B1 RID: 1713
		private string _tag = "";
	}
}
