using System;
using System.Linq;
using System.Xml;

namespace SonicOrca.Core
{
	// Token: 0x0200011C RID: 284
	public class LevelDependenciesWriter
	{
		// Token: 0x06000A90 RID: 2704 RVA: 0x0002962E File Offset: 0x0002782E
		public LevelDependenciesWriter(LevelBinding binding)
		{
			this._binding = binding;
		}

		// Token: 0x06000A91 RID: 2705 RVA: 0x00029640 File Offset: 0x00027840
		public void Save(string path)
		{
			XmlWriterSettings settings = new XmlWriterSettings
			{
				Indent = true
			};
			using (XmlWriter xmlWriter = XmlWriter.Create(path, settings))
			{
				xmlWriter.WriteStartDocument();
				xmlWriter.WriteStartElement("Dependencies");
				foreach (string text in (from p in this._binding.ObjectPlacements
				select p.Key).Distinct<string>())
				{
					xmlWriter.WriteStartElement("Dependency");
					xmlWriter.WriteStartElement("Key");
					xmlWriter.WriteString(text.ToString());
					xmlWriter.WriteEndElement();
					xmlWriter.WriteEndElement();
				}
				xmlWriter.WriteEndElement();
				xmlWriter.WriteEndDocument();
			}
		}

		// Token: 0x04000631 RID: 1585
		private readonly LevelBinding _binding;
	}
}
