using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using SonicOrca.Extensions;
using SonicOrca.Geometry;
using SonicOrca.Resources;

namespace SonicOrca.Graphics
{
	// Token: 0x020000D4 RID: 212
	public class Font : ILoadedResource, IDisposable, IEnumerable<Font.CharacterDefinition>, IEnumerable
	{
		// Token: 0x17000145 RID: 325
		// (get) Token: 0x06000705 RID: 1797 RVA: 0x0001D942 File Offset: 0x0001BB42
		// (set) Token: 0x06000706 RID: 1798 RVA: 0x0001D94A File Offset: 0x0001BB4A
		public Resource Resource { get; set; }

		// Token: 0x17000146 RID: 326
		// (get) Token: 0x06000707 RID: 1799 RVA: 0x0001D953 File Offset: 0x0001BB53
		// (set) Token: 0x06000708 RID: 1800 RVA: 0x0001D95B File Offset: 0x0001BB5B
		public int DefaultWidth { get; private set; }

		// Token: 0x17000147 RID: 327
		// (get) Token: 0x06000709 RID: 1801 RVA: 0x0001D964 File Offset: 0x0001BB64
		// (set) Token: 0x0600070A RID: 1802 RVA: 0x0001D96C File Offset: 0x0001BB6C
		public int Height { get; private set; }

		// Token: 0x17000148 RID: 328
		// (get) Token: 0x0600070B RID: 1803 RVA: 0x0001D975 File Offset: 0x0001BB75
		// (set) Token: 0x0600070C RID: 1804 RVA: 0x0001D97D File Offset: 0x0001BB7D
		public int Tracking { get; private set; }

		// Token: 0x17000149 RID: 329
		// (get) Token: 0x0600070D RID: 1805 RVA: 0x0001D986 File Offset: 0x0001BB86
		// (set) Token: 0x0600070E RID: 1806 RVA: 0x0001D98E File Offset: 0x0001BB8E
		public Vector2i? DefaultShadow { get; private set; }

		// Token: 0x1700014A RID: 330
		// (get) Token: 0x0600070F RID: 1807 RVA: 0x0001D997 File Offset: 0x0001BB97
		public ITexture ShapeTexture
		{
			get
			{
				return this._shapeTexture;
			}
		}

		// Token: 0x1700014B RID: 331
		// (get) Token: 0x06000710 RID: 1808 RVA: 0x0001D99F File Offset: 0x0001BB9F
		public IReadOnlyList<ITexture> OverlayTextures
		{
			get
			{
				return this._overlayTextures;
			}
		}

		// Token: 0x1700014C RID: 332
		public Font.CharacterDefinition this[char key]
		{
			get
			{
				return this._characterDefinitions.GetValueOrDefault(key);
			}
		}

		// Token: 0x06000712 RID: 1810 RVA: 0x0001D9B8 File Offset: 0x0001BBB8
		public Font(ResourceTree resourceTree, string shapeResourceKey, IEnumerable<string> overlayResourceKeys, int defaultWidth, int height, int tracking, Vector2i? shadow, IEnumerable<Font.CharacterDefinition> characterDefinitions)
		{
			this._resourceTree = resourceTree;
			this._shapeResourceKey = shapeResourceKey;
			this._overlayResourceKeys = overlayResourceKeys.ToArray<string>();
			this.DefaultWidth = defaultWidth;
			this.Height = height;
			this.Tracking = tracking;
			this.DefaultShadow = shadow;
			this._characterDefinitions = characterDefinitions.ToDictionary((Font.CharacterDefinition x) => x.Key);
		}

		// Token: 0x06000713 RID: 1811 RVA: 0x0001DA34 File Offset: 0x0001BC34
		public Font(ITexture shapeTexture, IEnumerable<ITexture> overlayTextures, int defaultWidth, int height, int tracking, Vector2i? shadow, IEnumerable<Font.CharacterDefinition> characterDefinitions)
		{
			this._shapeTexture = shapeTexture;
			this._overlayTextures = overlayTextures.ToArray<ITexture>();
			this.DefaultWidth = defaultWidth;
			this.Height = height;
			this.Tracking = tracking;
			this.DefaultShadow = shadow;
			this._characterDefinitions = characterDefinitions.ToDictionary((Font.CharacterDefinition x) => x.Key);
		}

		// Token: 0x06000714 RID: 1812 RVA: 0x0001DAA8 File Offset: 0x0001BCA8
		public void OnLoaded()
		{
			if (this._resourceTree != null)
			{
				this._shapeTexture = this._resourceTree.GetLoadedResource<ITexture>(this._shapeResourceKey);
				this._overlayTextures = (from x in this._overlayResourceKeys
				select this._resourceTree.GetLoadedResource<ITexture>(x)).ToArray<ITexture>();
			}
		}

		// Token: 0x06000715 RID: 1813 RVA: 0x00006325 File Offset: 0x00004525
		public void Dispose()
		{
		}

		// Token: 0x06000716 RID: 1814 RVA: 0x0001DAF8 File Offset: 0x0001BCF8
		public Rectangle MeasureString(string text)
		{
			return this.MeasureString(text, default(Rectangle), FontAlignment.Left);
		}

		// Token: 0x06000717 RID: 1815 RVA: 0x0001DB18 File Offset: 0x0001BD18
		public Rectangle MeasureString(string text, Rectangle boundary, FontAlignment alignment)
		{
			double num = 0.0;
			double num2 = (double)this.Height;
			foreach (char key in text)
			{
				Font.CharacterDefinition characterDefinition;
				num += (double)(this._characterDefinitions.TryGetValue(key, out characterDefinition) ? characterDefinition.Width : this.DefaultWidth);
				num += (double)this.Tracking;
			}
			if (text.Length > 0)
			{
				num -= (double)this.Tracking;
			}
			double x = 0.0;
			double y = 0.0;
			FontAlignment fontAlignment = alignment & FontAlignment.HorizontalMask;
			FontAlignment fontAlignment2 = alignment & FontAlignment.VerticalMask;
			switch (fontAlignment)
			{
			case FontAlignment.Left:
				x = boundary.X;
				break;
			case FontAlignment.MiddleX:
				x = boundary.X + (boundary.Width - num) / 2.0;
				break;
			case FontAlignment.Right:
				x = boundary.Right - num;
				break;
			}
			if (fontAlignment2 != FontAlignment.Left)
			{
				if (fontAlignment2 != FontAlignment.MiddleY)
				{
					if (fontAlignment2 == FontAlignment.Bottom)
					{
						y = boundary.Bottom - num2;
					}
				}
				else
				{
					y = boundary.Y + (boundary.Height - num2) / 2.0;
				}
			}
			else
			{
				y = boundary.Y;
			}
			return new Rectangle(x, y, num, num2);
		}

		// Token: 0x06000718 RID: 1816 RVA: 0x0001DC4D File Offset: 0x0001BE4D
		public override string ToString()
		{
			return string.Format("{0} defined characters", this._characterDefinitions.Count);
		}

		// Token: 0x06000719 RID: 1817 RVA: 0x0001DC69 File Offset: 0x0001BE69
		public IEnumerator<Font.CharacterDefinition> GetEnumerator()
		{
			return this._characterDefinitions.Values.GetEnumerator();
		}

		// Token: 0x0600071A RID: 1818 RVA: 0x0001DC80 File Offset: 0x0001BE80
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		// Token: 0x040004B5 RID: 1205
		private readonly Dictionary<char, Font.CharacterDefinition> _characterDefinitions;

		// Token: 0x040004B6 RID: 1206
		private readonly ResourceTree _resourceTree;

		// Token: 0x040004B7 RID: 1207
		private readonly string _shapeResourceKey;

		// Token: 0x040004B8 RID: 1208
		private readonly IEnumerable<string> _overlayResourceKeys;

		// Token: 0x040004B9 RID: 1209
		private ITexture _shapeTexture;

		// Token: 0x040004BA RID: 1210
		private IReadOnlyList<ITexture> _overlayTextures;

		// Token: 0x020001CE RID: 462
		public class CharacterDefinition
		{
			// Token: 0x1700050E RID: 1294
			// (get) Token: 0x060012D4 RID: 4820 RVA: 0x00048F40 File Offset: 0x00047140
			public char Key
			{
				get
				{
					return this._key;
				}
			}

			// Token: 0x1700050F RID: 1295
			// (get) Token: 0x060012D5 RID: 4821 RVA: 0x00048F48 File Offset: 0x00047148
			public Rectanglei SourceRectangle
			{
				get
				{
					return this._sourceRectangle;
				}
			}

			// Token: 0x17000510 RID: 1296
			// (get) Token: 0x060012D6 RID: 4822 RVA: 0x00048F50 File Offset: 0x00047150
			public Vector2i Offset
			{
				get
				{
					return this._offset;
				}
			}

			// Token: 0x17000511 RID: 1297
			// (get) Token: 0x060012D7 RID: 4823 RVA: 0x00048F58 File Offset: 0x00047158
			public int Width
			{
				get
				{
					return this._width;
				}
			}

			// Token: 0x060012D8 RID: 4824 RVA: 0x00048F60 File Offset: 0x00047160
			public CharacterDefinition(char key, Rectanglei sourceRectangle, Vector2i offset) : this(key, sourceRectangle, offset, sourceRectangle.Width)
			{
			}

			// Token: 0x060012D9 RID: 4825 RVA: 0x00048F72 File Offset: 0x00047172
			public CharacterDefinition(char key, Rectanglei sourceRectangle, Vector2i offset, int width)
			{
				this._key = key;
				this._sourceRectangle = sourceRectangle;
				this._offset = offset;
				this._width = width;
			}

			// Token: 0x060012DA RID: 4826 RVA: 0x00048F98 File Offset: 0x00047198
			public override string ToString()
			{
				return this._key.ToString();
			}

			// Token: 0x04000AB0 RID: 2736
			private readonly char _key;

			// Token: 0x04000AB1 RID: 2737
			private readonly Rectanglei _sourceRectangle;

			// Token: 0x04000AB2 RID: 2738
			private readonly Vector2i _offset;

			// Token: 0x04000AB3 RID: 2739
			private readonly int _width;
		}
	}
}
