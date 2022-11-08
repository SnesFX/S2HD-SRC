using System;

namespace SonicOrca.Graphics.V2.Animation
{
	// Token: 0x020000F5 RID: 245
	public class CompositionAsset
	{
		// Token: 0x170001CA RID: 458
		// (get) Token: 0x06000870 RID: 2160 RVA: 0x00021330 File Offset: 0x0001F530
		public string ID
		{
			get
			{
				return this._id;
			}
		}

		// Token: 0x170001CB RID: 459
		// (get) Token: 0x06000871 RID: 2161 RVA: 0x00021338 File Offset: 0x0001F538
		public int Width
		{
			get
			{
				return this._width;
			}
		}

		// Token: 0x170001CC RID: 460
		// (get) Token: 0x06000872 RID: 2162 RVA: 0x00021340 File Offset: 0x0001F540
		public int Height
		{
			get
			{
				return this._height;
			}
		}

		// Token: 0x170001CD RID: 461
		// (get) Token: 0x06000873 RID: 2163 RVA: 0x00021348 File Offset: 0x0001F548
		public string Path
		{
			get
			{
				return this._path;
			}
		}

		// Token: 0x170001CE RID: 462
		// (get) Token: 0x06000874 RID: 2164 RVA: 0x00021350 File Offset: 0x0001F550
		public string FileName
		{
			get
			{
				return this._fileName;
			}
		}

		// Token: 0x06000875 RID: 2165 RVA: 0x00021358 File Offset: 0x0001F558
		public CompositionAsset(string id, int width, int height, string path, string fileName)
		{
			this._id = id;
			this._width = width;
			this._height = height;
			this._path = path;
			this._fileName = fileName;
		}

		// Token: 0x04000524 RID: 1316
		private string _id;

		// Token: 0x04000525 RID: 1317
		private int _width;

		// Token: 0x04000526 RID: 1318
		private int _height;

		// Token: 0x04000527 RID: 1319
		private string _path;

		// Token: 0x04000528 RID: 1320
		private string _fileName;
	}
}
