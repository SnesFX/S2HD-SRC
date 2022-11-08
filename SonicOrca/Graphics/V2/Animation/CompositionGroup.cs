using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using SonicOrca.Resources;

namespace SonicOrca.Graphics.V2.Animation
{
	// Token: 0x020000F6 RID: 246
	public class CompositionGroup : ILoadedResource, IDisposable, IReadOnlyList<Composition>, IReadOnlyCollection<Composition>, IEnumerable<Composition>, IEnumerable
	{
		// Token: 0x170001CF RID: 463
		// (get) Token: 0x06000876 RID: 2166 RVA: 0x00021385 File Offset: 0x0001F585
		// (set) Token: 0x06000877 RID: 2167 RVA: 0x0002138D File Offset: 0x0001F58D
		public Resource Resource { get; set; }

		// Token: 0x170001D0 RID: 464
		// (get) Token: 0x06000878 RID: 2168 RVA: 0x00021396 File Offset: 0x0001F596
		// (set) Token: 0x06000879 RID: 2169 RVA: 0x0002139E File Offset: 0x0001F59E
		public IReadOnlyList<ITexture> Textures { get; private set; }

		// Token: 0x170001D1 RID: 465
		// (get) Token: 0x0600087A RID: 2170 RVA: 0x000213A7 File Offset: 0x0001F5A7
		// (set) Token: 0x0600087B RID: 2171 RVA: 0x000213AF File Offset: 0x0001F5AF
		public IReadOnlyList<string> TextureResourceKeys { get; private set; }

		// Token: 0x170001D2 RID: 466
		// (get) Token: 0x0600087C RID: 2172 RVA: 0x000213B8 File Offset: 0x0001F5B8
		// (set) Token: 0x0600087D RID: 2173 RVA: 0x000213C0 File Offset: 0x0001F5C0
		public IReadOnlyList<CompositionAsset> Assets { get; private set; }

		// Token: 0x0600087E RID: 2174 RVA: 0x000213C9 File Offset: 0x0001F5C9
		public CompositionGroup(ResourceTree resourceTree, IEnumerable<string> textureResourceKeys, IEnumerable<CompositionAsset> assets, IEnumerable<Composition> compositions)
		{
			this._resourceTree = resourceTree;
			this._textureResourceKeys = textureResourceKeys.ToArray<string>();
			this._assets = assets.ToArray<CompositionAsset>();
			this._compositions = compositions.ToArray<Composition>();
		}

		// Token: 0x0600087F RID: 2175 RVA: 0x000213FD File Offset: 0x0001F5FD
		public void OnLoaded()
		{
			this.TextureResourceKeys = this._textureResourceKeys;
			this.Textures = (from x in this._textureResourceKeys
			select this._resourceTree.GetLoadedResource<ITexture>(x)).ToArray<ITexture>();
			this.Assets = this._assets;
		}

		// Token: 0x06000880 RID: 2176 RVA: 0x00006325 File Offset: 0x00004525
		public void Dispose()
		{
		}

		// Token: 0x170001D3 RID: 467
		public Composition this[int index]
		{
			get
			{
				return this._compositions[index];
			}
		}

		// Token: 0x170001D4 RID: 468
		// (get) Token: 0x06000882 RID: 2178 RVA: 0x00021447 File Offset: 0x0001F647
		public int Count
		{
			get
			{
				return this._compositions.Count;
			}
		}

		// Token: 0x06000883 RID: 2179 RVA: 0x00021454 File Offset: 0x0001F654
		public IEnumerator<Composition> GetEnumerator()
		{
			return this._compositions.GetEnumerator();
		}

		// Token: 0x06000884 RID: 2180 RVA: 0x00021461 File Offset: 0x0001F661
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		// Token: 0x04000529 RID: 1321
		private readonly ResourceTree _resourceTree;

		// Token: 0x0400052A RID: 1322
		private readonly IReadOnlyList<string> _textureResourceKeys;

		// Token: 0x0400052B RID: 1323
		private readonly IReadOnlyList<CompositionAsset> _assets;

		// Token: 0x0400052C RID: 1324
		private readonly IReadOnlyList<Composition> _compositions;
	}
}
