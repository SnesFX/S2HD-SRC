using System;
using System.IO;
using System.Xml;

namespace SonicOrca.Resources
{
	// Token: 0x02000010 RID: 16
	public class XmlLoadedResource : ILoadedResource, IDisposable
	{
		// Token: 0x1700001C RID: 28
		// (get) Token: 0x0600006C RID: 108 RVA: 0x00003914 File Offset: 0x00001B14
		// (set) Token: 0x0600006D RID: 109 RVA: 0x0000391C File Offset: 0x00001B1C
		public Resource Resource { get; set; }

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x0600006E RID: 110 RVA: 0x00003925 File Offset: 0x00001B25
		public XmlDocument XmlDocument
		{
			get
			{
				return this._xmlDocument;
			}
		}

		// Token: 0x0600006F RID: 111 RVA: 0x0000392D File Offset: 0x00001B2D
		public XmlLoadedResource(Stream stream)
		{
			this._xmlDocument = new XmlDocument();
			this._xmlDocument.Load(stream);
		}

		// Token: 0x06000070 RID: 112 RVA: 0x0000394C File Offset: 0x00001B4C
		public virtual void OnLoaded()
		{
		}

		// Token: 0x06000071 RID: 113 RVA: 0x0000394C File Offset: 0x00001B4C
		public virtual void Dispose()
		{
		}

		// Token: 0x04000036 RID: 54
		private readonly XmlDocument _xmlDocument;
	}
}
