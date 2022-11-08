using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using SonicOrca.Geometry;
using SonicOrca.Graphics;
using SonicOrca.Resources;

namespace SonicOrca.Core
{
	// Token: 0x0200014C RID: 332
	public class TileSet : IReadOnlyDictionary<int, ITile>, IReadOnlyCollection<KeyValuePair<int, ITile>>, IEnumerable<KeyValuePair<int, ITile>>, IEnumerable, ILoadedResource, IDisposable
	{
		// Token: 0x17000364 RID: 868
		// (get) Token: 0x06000DB4 RID: 3508 RVA: 0x0003465D File Offset: 0x0003285D
		// (set) Token: 0x06000DB5 RID: 3509 RVA: 0x00034665 File Offset: 0x00032865
		public Resource Resource { get; set; }

		// Token: 0x17000365 RID: 869
		// (get) Token: 0x06000DB6 RID: 3510 RVA: 0x0003466E File Offset: 0x0003286E
		// (set) Token: 0x06000DB7 RID: 3511 RVA: 0x00034676 File Offset: 0x00032876
		public IReadOnlyList<ITexture> Textures { get; private set; }

		// Token: 0x06000DB8 RID: 3512 RVA: 0x0003467F File Offset: 0x0003287F
		public TileSet()
		{
		}

		// Token: 0x06000DB9 RID: 3513 RVA: 0x000346A2 File Offset: 0x000328A2
		public TileSet(ResourceTree resourceTree, IEnumerable<string> textureKeys)
		{
			this._resourceTree = resourceTree;
			this._textureKeys = textureKeys.ToArray<string>();
		}

		// Token: 0x17000366 RID: 870
		public ITile this[int id]
		{
			get
			{
				if (id >= this._tiles.Length)
				{
					return null;
				}
				return this._tiles[id];
			}
			set
			{
				if (this._tiles.Length <= id)
				{
					int num = this._tiles.Length;
					do
					{
						num *= 2;
					}
					while (num <= id);
					Array.Resize<ITile>(ref this._tiles, num);
				}
				this._tiles[id] = value;
				this._tileIds.Add(id);
			}
		}

		// Token: 0x06000DBC RID: 3516 RVA: 0x0003473C File Offset: 0x0003293C
		public void Animate()
		{
			foreach (int num in this._tileIds)
			{
				this._tiles[num].Animate();
			}
		}

		// Token: 0x06000DBD RID: 3517 RVA: 0x00034798 File Offset: 0x00032998
		public void DrawTile(Renderer renderer, int index, int x, int y)
		{
			this.DrawTile(renderer, index, new Rectanglei(x, y, 64, 64));
		}

		// Token: 0x06000DBE RID: 3518 RVA: 0x000347AE File Offset: 0x000329AE
		public void DrawTile(Renderer renderer, int index, Rectanglei destination)
		{
			this.DrawTile(renderer, index, new Rectanglei(0, 0, destination.Width, destination.Height), destination);
		}

		// Token: 0x06000DBF RID: 3519 RVA: 0x000347D0 File Offset: 0x000329D0
		public void DrawTile(Renderer renderer, int index, Rectanglei source, Rectanglei destination)
		{
			ITile tile;
			if (this.TryGetValue(index, out tile))
			{
				tile.Draw(renderer, index, source, destination);
			}
		}

		// Token: 0x06000DC0 RID: 3520 RVA: 0x000347F3 File Offset: 0x000329F3
		public void OnLoaded()
		{
			this.Textures = (from x in this._textureKeys
			select this._resourceTree.GetLoadedResource<ITexture>(x)).ToArray<ITexture>();
		}

		// Token: 0x06000DC1 RID: 3521 RVA: 0x00006325 File Offset: 0x00004525
		public void Dispose()
		{
		}

		// Token: 0x06000DC2 RID: 3522 RVA: 0x00034817 File Offset: 0x00032A17
		public bool ContainsKey(int key)
		{
			return this[key] != null;
		}

		// Token: 0x17000367 RID: 871
		// (get) Token: 0x06000DC3 RID: 3523 RVA: 0x00034823 File Offset: 0x00032A23
		public IEnumerable<int> Keys
		{
			get
			{
				return this._tileIds;
			}
		}

		// Token: 0x06000DC4 RID: 3524 RVA: 0x0003482B File Offset: 0x00032A2B
		public bool TryGetValue(int tile, out ITile value)
		{
			value = this[tile & 4095];
			return value != null;
		}

		// Token: 0x17000368 RID: 872
		// (get) Token: 0x06000DC5 RID: 3525 RVA: 0x00034841 File Offset: 0x00032A41
		public IEnumerable<ITile> Values
		{
			get
			{
				return from i in this._tileIds
				select this._tiles[i];
			}
		}

		// Token: 0x17000369 RID: 873
		// (get) Token: 0x06000DC6 RID: 3526 RVA: 0x0003485A File Offset: 0x00032A5A
		public int Count
		{
			get
			{
				return this._tileIds.Count;
			}
		}

		// Token: 0x06000DC7 RID: 3527 RVA: 0x00034867 File Offset: 0x00032A67
		public IEnumerator<KeyValuePair<int, ITile>> GetEnumerator()
		{
			return (from i in this._tileIds
			select new KeyValuePair<int, ITile>(i, this._tiles[i])).GetEnumerator();
		}

		// Token: 0x06000DC8 RID: 3528 RVA: 0x00034885 File Offset: 0x00032A85
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		// Token: 0x040007C6 RID: 1990
		public const int InitialTileCapacity = 4096;

		// Token: 0x040007C7 RID: 1991
		private ITile[] _tiles = new ITile[4096];

		// Token: 0x040007C8 RID: 1992
		private readonly HashSet<int> _tileIds = new HashSet<int>();

		// Token: 0x040007C9 RID: 1993
		private readonly ResourceTree _resourceTree;

		// Token: 0x040007CA RID: 1994
		private readonly IReadOnlyList<string> _textureKeys;
	}
}
