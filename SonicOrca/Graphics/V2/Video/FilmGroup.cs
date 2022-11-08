using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using SonicOrca.Resources;

namespace SonicOrca.Graphics.V2.Video
{
	// Token: 0x020000EB RID: 235
	public class FilmGroup : ILoadedResource, IDisposable, IReadOnlyList<Film>, IReadOnlyCollection<Film>, IEnumerable<Film>, IEnumerable
	{
		// Token: 0x170001A9 RID: 425
		// (get) Token: 0x0600081D RID: 2077 RVA: 0x0001FA38 File Offset: 0x0001DC38
		// (set) Token: 0x0600081E RID: 2078 RVA: 0x0001FA40 File Offset: 0x0001DC40
		public Resource Resource { get; set; }

		// Token: 0x170001AA RID: 426
		// (get) Token: 0x0600081F RID: 2079 RVA: 0x0001FA49 File Offset: 0x0001DC49
		// (set) Token: 0x06000820 RID: 2080 RVA: 0x0001FA51 File Offset: 0x0001DC51
		public IReadOnlyList<IFilmBuffer> FilmBuffers { get; private set; }

		// Token: 0x170001AB RID: 427
		// (get) Token: 0x06000821 RID: 2081 RVA: 0x0001FA5A File Offset: 0x0001DC5A
		// (set) Token: 0x06000822 RID: 2082 RVA: 0x0001FA62 File Offset: 0x0001DC62
		public IReadOnlyList<string> FilmResourceKeys { get; private set; }

		// Token: 0x06000823 RID: 2083 RVA: 0x0001FA6B File Offset: 0x0001DC6B
		public FilmGroup(ResourceTree resourceTree, IEnumerable<string> filmResourceKeys, IEnumerable<Film> films)
		{
			this._resourceTree = resourceTree;
			this._filmResourceKeys = filmResourceKeys.ToArray<string>();
			this._films = films.ToArray<Film>();
		}

		// Token: 0x06000824 RID: 2084 RVA: 0x0001FA92 File Offset: 0x0001DC92
		public void OnLoaded()
		{
			this.FilmResourceKeys = this._filmResourceKeys;
			this.FilmBuffers = (from x in this._filmResourceKeys
			select this._resourceTree.GetLoadedResource<IFilmBuffer>(x)).ToArray<IFilmBuffer>();
		}

		// Token: 0x06000825 RID: 2085 RVA: 0x00006325 File Offset: 0x00004525
		public void Dispose()
		{
		}

		// Token: 0x170001AC RID: 428
		public Film this[int index]
		{
			get
			{
				return this._films[index];
			}
		}

		// Token: 0x170001AD RID: 429
		// (get) Token: 0x06000827 RID: 2087 RVA: 0x0001FAD0 File Offset: 0x0001DCD0
		public int Count
		{
			get
			{
				return this._films.Count;
			}
		}

		// Token: 0x06000828 RID: 2088 RVA: 0x0001FADD File Offset: 0x0001DCDD
		public IEnumerator<Film> GetEnumerator()
		{
			return this._films.GetEnumerator();
		}

		// Token: 0x06000829 RID: 2089 RVA: 0x0001FAEA File Offset: 0x0001DCEA
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		// Token: 0x040004F9 RID: 1273
		private readonly ResourceTree _resourceTree;

		// Token: 0x040004FA RID: 1274
		private readonly IReadOnlyList<string> _filmResourceKeys;

		// Token: 0x040004FB RID: 1275
		private readonly IReadOnlyList<Film> _films;
	}
}
