using System;

namespace SonicOrca.Graphics.V2.Video
{
	// Token: 0x020000EC RID: 236
	public class Film
	{
		// Token: 0x170001AE RID: 430
		// (get) Token: 0x0600082B RID: 2091 RVA: 0x0001FB00 File Offset: 0x0001DD00
		public string Path
		{
			get
			{
				return this._path;
			}
		}

		// Token: 0x0600082C RID: 2092 RVA: 0x0001FB08 File Offset: 0x0001DD08
		public Film(string path)
		{
			this._path = path;
		}

		// Token: 0x040004FF RID: 1279
		private string _path;
	}
}
