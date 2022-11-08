using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using SonicOrca.Resources;

namespace SonicOrca.Graphics
{
	// Token: 0x020000D8 RID: 216
	public class AnimationGroup : ILoadedResource, IDisposable, IReadOnlyList<Animation>, IReadOnlyCollection<Animation>, IEnumerable<Animation>, IEnumerable
	{
		// Token: 0x17000154 RID: 340
		// (get) Token: 0x0600072D RID: 1837 RVA: 0x0001DEF5 File Offset: 0x0001C0F5
		// (set) Token: 0x0600072E RID: 1838 RVA: 0x0001DEFD File Offset: 0x0001C0FD
		public Resource Resource { get; set; }

		// Token: 0x17000155 RID: 341
		// (get) Token: 0x0600072F RID: 1839 RVA: 0x0001DF06 File Offset: 0x0001C106
		// (set) Token: 0x06000730 RID: 1840 RVA: 0x0001DF0E File Offset: 0x0001C10E
		public IReadOnlyList<ITexture> Textures { get; private set; }

		// Token: 0x06000731 RID: 1841 RVA: 0x0001DF17 File Offset: 0x0001C117
		public AnimationGroup(IEnumerable<ITexture> textures, IEnumerable<Animation> animations)
		{
			this.Textures = textures.ToArray<ITexture>();
			this._animations = animations.ToArray<Animation>();
		}

		// Token: 0x06000732 RID: 1842 RVA: 0x0001DF37 File Offset: 0x0001C137
		public AnimationGroup(ResourceTree resourceTree, IEnumerable<string> textureResourceKeys, IEnumerable<Animation> animations)
		{
			this._resourceTree = resourceTree;
			this._textureResourceKeys = textureResourceKeys.ToArray<string>();
			this._animations = animations.ToArray<Animation>();
		}

		// Token: 0x06000733 RID: 1843 RVA: 0x0001DF5E File Offset: 0x0001C15E
		public void OnLoaded()
		{
			this.Textures = (from x in this._textureResourceKeys
			select this._resourceTree.GetLoadedResource<ITexture>(x)).ToArray<ITexture>();
		}

		// Token: 0x06000734 RID: 1844 RVA: 0x00006325 File Offset: 0x00004525
		public void Dispose()
		{
		}

		// Token: 0x17000156 RID: 342
		public Animation this[int index]
		{
			get
			{
				return this._animations[index];
			}
		}

		// Token: 0x17000157 RID: 343
		// (get) Token: 0x06000736 RID: 1846 RVA: 0x0001DF90 File Offset: 0x0001C190
		public int Count
		{
			get
			{
				return this._animations.Count;
			}
		}

		// Token: 0x06000737 RID: 1847 RVA: 0x0001DF9D File Offset: 0x0001C19D
		public IEnumerator<Animation> GetEnumerator()
		{
			return this._animations.GetEnumerator();
		}

		// Token: 0x06000738 RID: 1848 RVA: 0x0001DFAA File Offset: 0x0001C1AA
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		// Token: 0x040004CC RID: 1228
		private readonly ResourceTree _resourceTree;

		// Token: 0x040004CD RID: 1229
		private readonly IReadOnlyList<string> _textureResourceKeys;

		// Token: 0x040004CE RID: 1230
		private readonly IReadOnlyList<Animation> _animations;
	}
}
