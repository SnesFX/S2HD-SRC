using System;

namespace SonicOrca.Drawing.LevelRendering
{
	// Token: 0x02000019 RID: 25
	internal class RenderingTileList
	{
		// Token: 0x17000053 RID: 83
		// (get) Token: 0x06000156 RID: 342 RVA: 0x000071C1 File Offset: 0x000053C1
		public int Count
		{
			get
			{
				return this._currentCount;
			}
		}

		// Token: 0x17000054 RID: 84
		public TileRenderInfo this[int index]
		{
			get
			{
				return this._buffer[index];
			}
		}

		// Token: 0x06000158 RID: 344 RVA: 0x000071D8 File Offset: 0x000053D8
		private void ExpandBuffer()
		{
			int num = this._buffer.Length * 2;
			this._buffer = new TileRenderInfo[num];
		}

		// Token: 0x06000159 RID: 345 RVA: 0x000071FC File Offset: 0x000053FC
		public void Clear()
		{
			this._currentCount = 0;
		}

		// Token: 0x0600015A RID: 346 RVA: 0x00007205 File Offset: 0x00005405
		public void AddTileRenderInfo(TileRenderInfo tileRenderInfo)
		{
			if (this._currentCount >= this._buffer.Length)
			{
				this.ExpandBuffer();
			}
			this._buffer[this._currentCount] = tileRenderInfo;
			this._currentCount++;
		}

		// Token: 0x040000DA RID: 218
		private const int InitialTileRenderInfoCapacity = 128;

		// Token: 0x040000DB RID: 219
		private TileRenderInfo[] _buffer = new TileRenderInfo[128];

		// Token: 0x040000DC RID: 220
		private int _currentCount;
	}
}
