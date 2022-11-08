using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using SonicOrca.Resources;

namespace SonicOrca.Core
{
	// Token: 0x02000119 RID: 281
	public class CommonResources : IDisposable
	{
		// Token: 0x17000253 RID: 595
		// (get) Token: 0x06000A79 RID: 2681 RVA: 0x0002942D File Offset: 0x0002762D
		public string LoadedScheme
		{
			get
			{
				return this._loadedScheme;
			}
		}

		// Token: 0x06000A7A RID: 2682 RVA: 0x00029435 File Offset: 0x00027635
		public CommonResources(SonicOrcaGameContext gameContext)
		{
			this._gameContext = gameContext;
		}

		// Token: 0x06000A7B RID: 2683 RVA: 0x0002944F File Offset: 0x0002764F
		public void Dispose()
		{
			if (this._resourceSession != null)
			{
				this._resourceSession.Dispose();
			}
		}

		// Token: 0x06000A7C RID: 2684 RVA: 0x00029464 File Offset: 0x00027664
		public async Task LoadEntriesAsync(CancellationToken ct = default(CancellationToken))
		{
			ResourceTree resourceTree = this._gameContext.ResourceTree;
			using (ResourceSession resourceSession = new ResourceSession(resourceTree))
			{
				resourceSession.PushDependency("SONICORCA/LEVELS/COMMONRESOURCES");
				await resourceSession.LoadAsync(ct, false);
				XmlNode resourcesNode = this._gameContext.ResourceTree.GetLoadedResource<XmlLoadedResource>("SONICORCA/LEVELS/COMMONRESOURCES").XmlDocument.SelectSingleNode("resources");
				foreach (IGrouping<string, CommonResources.CommonResourceEntry> grouping in from x in this.ParseEntriesFromXmlNode(resourcesNode)
				group x by x.Scheme)
				{
					this._entries[grouping.Key] = grouping.ToArray<CommonResources.CommonResourceEntry>();
				}
			}
			ResourceSession resourceSession = null;
		}

		// Token: 0x06000A7D RID: 2685 RVA: 0x000294B1 File Offset: 0x000276B1
		private IEnumerable<CommonResources.CommonResourceEntry> ParseEntriesFromXmlNode(XmlNode resourcesNode)
		{
			foreach (object obj in resourcesNode.SelectNodes("resource"))
			{
				XmlNode xmlNode = (XmlNode)obj;
				string scheme = string.Empty;
				XmlAttribute xmlAttribute = xmlNode.Attributes["scheme"];
				if (xmlAttribute != null)
				{
					scheme = xmlAttribute.Value;
				}
				string value = xmlNode.Attributes["key"].Value;
				string value2 = xmlNode.Attributes["path"].Value;
				yield return new CommonResources.CommonResourceEntry(scheme, value, value2);
			}
			IEnumerator enumerator = null;
			yield break;
			yield break;
		}

		// Token: 0x06000A7E RID: 2686 RVA: 0x000294C1 File Offset: 0x000276C1
		public Task LoadSchemeAsync(LevelScheme scheme, CancellationToken ct = default(CancellationToken))
		{
			return this.LoadSchemeAsync(scheme.ToString().ToLower(), ct);
		}

		// Token: 0x06000A7F RID: 2687 RVA: 0x000294DC File Offset: 0x000276DC
		public async Task LoadSchemeAsync(string scheme, CancellationToken ct = default(CancellationToken))
		{
			if (!(this._loadedScheme == scheme))
			{
				if (this._resourceSession != null)
				{
					Trace.WriteLine("Unloading scheme " + this._loadedScheme);
					this._resourceSession.Unload();
				}
				Trace.WriteLine("Loading scheme " + scheme);
				ResourceSession newResourceSession = new ResourceSession(this._gameContext.ResourceTree);
				newResourceSession.PushDependencies(this.GetResourcePaths(scheme));
				await newResourceSession.LoadAsync(ct, false);
				this._resourceSession = newResourceSession;
				this._loadedScheme = scheme;
			}
		}

		// Token: 0x06000A80 RID: 2688 RVA: 0x00029531 File Offset: 0x00027731
		public void UnloadScheme()
		{
			if (this._resourceSession != null)
			{
				Trace.WriteLine("Unloading scheme " + this._loadedScheme);
				this._resourceSession.Unload();
				this._resourceSession = null;
				this._loadedScheme = null;
			}
		}

		// Token: 0x06000A81 RID: 2689 RVA: 0x00029569 File Offset: 0x00027769
		private IEnumerable<string> GetResourcePaths(string scheme)
		{
			IEnumerable<CommonResources.CommonResourceEntry> enumerable;
			if (this._entries.TryGetValue(string.Empty, out enumerable))
			{
				foreach (CommonResources.CommonResourceEntry commonResourceEntry in enumerable)
				{
					yield return commonResourceEntry.Path;
				}
				IEnumerator<CommonResources.CommonResourceEntry> enumerator = null;
			}
			if (this._entries.TryGetValue(scheme, out enumerable))
			{
				foreach (CommonResources.CommonResourceEntry commonResourceEntry2 in enumerable)
				{
					yield return commonResourceEntry2.Path;
				}
				IEnumerator<CommonResources.CommonResourceEntry> enumerator = null;
			}
			yield break;
			yield break;
		}

		// Token: 0x06000A82 RID: 2690 RVA: 0x00029580 File Offset: 0x00027780
		public string GetResourcePath(string key)
		{
			return this.GetResourcePath(this._loadedScheme, key);
		}

		// Token: 0x06000A83 RID: 2691 RVA: 0x00029590 File Offset: 0x00027790
		public string GetResourcePath(string scheme, string key)
		{
			IEnumerable<CommonResources.CommonResourceEntry> source;
			CommonResources.CommonResourceEntry commonResourceEntry;
			if (this._entries.TryGetValue(scheme, out source) && (commonResourceEntry = source.FirstOrDefault((CommonResources.CommonResourceEntry x) => x.Key == key)) != null)
			{
				return commonResourceEntry.Path;
			}
			if (this._entries.TryGetValue(string.Empty, out source) && (commonResourceEntry = source.FirstOrDefault((CommonResources.CommonResourceEntry x) => x.Key == key)) != null)
			{
				return commonResourceEntry.Path;
			}
			throw new ResourceException(key + " not found in the level common resources.");
		}

		// Token: 0x0400062B RID: 1579
		private const string EntriesResourcePath = "SONICORCA/LEVELS/COMMONRESOURCES";

		// Token: 0x0400062C RID: 1580
		private readonly Dictionary<string, IEnumerable<CommonResources.CommonResourceEntry>> _entries = new Dictionary<string, IEnumerable<CommonResources.CommonResourceEntry>>();

		// Token: 0x0400062D RID: 1581
		private readonly SonicOrcaGameContext _gameContext;

		// Token: 0x0400062E RID: 1582
		private ResourceSession _resourceSession;

		// Token: 0x0400062F RID: 1583
		private string _loadedScheme;

		// Token: 0x020001FD RID: 509
		private class CommonResourceEntry
		{
			// Token: 0x1700051F RID: 1311
			// (get) Token: 0x06001365 RID: 4965 RVA: 0x0004B582 File Offset: 0x00049782
			public string Scheme
			{
				get
				{
					return this._scheme;
				}
			}

			// Token: 0x17000520 RID: 1312
			// (get) Token: 0x06001366 RID: 4966 RVA: 0x0004B58A File Offset: 0x0004978A
			public string Key
			{
				get
				{
					return this._key;
				}
			}

			// Token: 0x17000521 RID: 1313
			// (get) Token: 0x06001367 RID: 4967 RVA: 0x0004B592 File Offset: 0x00049792
			public string Path
			{
				get
				{
					return this._path;
				}
			}

			// Token: 0x06001368 RID: 4968 RVA: 0x0004B59A File Offset: 0x0004979A
			public CommonResourceEntry(string scheme, string key, string path)
			{
				this._scheme = scheme.ToLower();
				this._key = key.ToLower();
				this._path = path.ToUpper();
			}

			// Token: 0x06001369 RID: 4969 RVA: 0x0004B5C6 File Offset: 0x000497C6
			public override string ToString()
			{
				return string.Format("{0}.{1} = {2}", this._scheme, this._key, this._path);
			}

			// Token: 0x04000B77 RID: 2935
			private readonly string _scheme;

			// Token: 0x04000B78 RID: 2936
			private readonly string _key;

			// Token: 0x04000B79 RID: 2937
			private readonly string _path;
		}
	}
}
