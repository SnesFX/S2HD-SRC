using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using SonicOrca.Resources;

namespace SonicOrca.Graphics.V2.Video
{
	// Token: 0x020000E7 RID: 231
	public class FilmGroupResourceType : ResourceType
	{
		// Token: 0x060007FB RID: 2043 RVA: 0x0001F551 File Offset: 0x0001D751
		public FilmGroupResourceType() : base(ResourceTypeIdentifier.FilmGroup)
		{
		}

		// Token: 0x17000199 RID: 409
		// (get) Token: 0x060007FC RID: 2044 RVA: 0x0001F55E File Offset: 0x0001D75E
		public override string Name
		{
			get
			{
				return "film, xml";
			}
		}

		// Token: 0x1700019A RID: 410
		// (get) Token: 0x060007FD RID: 2045 RVA: 0x0001F565 File Offset: 0x0001D765
		public override string DefaultExtension
		{
			get
			{
				return ".film.xml";
			}
		}

		// Token: 0x060007FE RID: 2046 RVA: 0x0001F56C File Offset: 0x0001D76C
		public override async Task<ILoadedResource> LoadAsync(ResourceLoadArgs e, CancellationToken ct = default(CancellationToken))
		{
			List<string> filmResourceKeys = new List<string>();
			List<Film> films = new List<Film>();
			XmlDocument xmlDocument = new XmlDocument();
			await Task.Run(delegate()
			{
				xmlDocument.Load(e.InputStream);
			});
			IEnumerable<XmlNode> enumerable = xmlDocument.SelectSingleNode("root").SelectNodes("video").OfType<XmlNode>();
			List<string> list = new List<string>();
			foreach (XmlNode xmlNode in enumerable)
			{
				list.Add(xmlNode.InnerText);
			}
			string fullKeyPath = e.Resource.FullKeyPath;
			string text = fullKeyPath.Remove(fullKeyPath.LastIndexOf("/"));
			text = text.Remove(text.LastIndexOf("/"));
			foreach (string text2 in list)
			{
				string text3 = text + "/" + text2.ToUpper();
				filmResourceKeys.Add(text3);
				films.Add(new Film(text3));
			}
			e.PushDependencies(filmResourceKeys);
			return new FilmGroup(e.ResourceTree, filmResourceKeys, films)
			{
				Resource = e.Resource
			};
		}
	}
}
