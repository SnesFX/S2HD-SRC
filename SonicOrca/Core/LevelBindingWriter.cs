using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml;

namespace SonicOrca.Core
{
	// Token: 0x0200012A RID: 298
	public class LevelBindingWriter
	{
		// Token: 0x06000BBC RID: 3004 RVA: 0x0002D721 File Offset: 0x0002B921
		public LevelBindingWriter(LevelBinding binding)
		{
			this._binding = binding;
		}

		// Token: 0x06000BBD RID: 3005 RVA: 0x0002D730 File Offset: 0x0002B930
		public void Save(string path)
		{
			XmlWriterSettings settings = new XmlWriterSettings
			{
				Indent = true
			};
			using (XmlWriter xmlWriter = XmlWriter.Create(path, settings))
			{
				xmlWriter.WriteStartDocument();
				xmlWriter.WriteStartElement("Binding");
				int key = (from x in this._binding.ObjectPlacements
				group x by x.Layer into x
				orderby x.Count<ObjectPlacement>() descending
				select x).First<IGrouping<int, ObjectPlacement>>().Key;
				xmlWriter.WriteStartElement("Definitions");
				xmlWriter.WriteAttributeString("DefaultLayer", key.ToString());
				foreach (ObjectPlacement objectPlacement in this._binding.ObjectPlacements)
				{
					xmlWriter.WriteStartElement("Definition");
					xmlWriter.WriteStartElement("Common");
					xmlWriter.WriteStartElement("Key");
					xmlWriter.WriteString(objectPlacement.Key.ToString());
					xmlWriter.WriteEndElement();
					xmlWriter.WriteStartElement("Uid");
					xmlWriter.WriteString(objectPlacement.Uid.ToString());
					xmlWriter.WriteEndElement();
					xmlWriter.WriteStartElement("Name");
					xmlWriter.WriteString(objectPlacement.Name.ToString());
					xmlWriter.WriteEndElement();
					if (objectPlacement.Layer != key)
					{
						xmlWriter.WriteStartElement("Layer");
						xmlWriter.WriteString(objectPlacement.Layer.ToString());
						xmlWriter.WriteEndElement();
					}
					xmlWriter.WriteStartElement("Position");
					xmlWriter.WriteAttributeString("X", objectPlacement.Position.X.ToString());
					xmlWriter.WriteAttributeString("Y", objectPlacement.Position.Y.ToString());
					xmlWriter.WriteEndElement();
					xmlWriter.WriteEndElement();
					if (objectPlacement.Behaviour.Count > 0)
					{
						xmlWriter.WriteStartElement("Behaviour");
						this.WriteObjectBehaviour(xmlWriter, objectPlacement.Behaviour);
						xmlWriter.WriteEndElement();
					}
					if (objectPlacement.Mappings.Count > 0)
					{
						xmlWriter.WriteStartElement("Mappings");
						this.WriteObjectBehaviour(xmlWriter, objectPlacement.Mappings);
						xmlWriter.WriteEndElement();
					}
					xmlWriter.WriteEndElement();
				}
				xmlWriter.WriteEndElement();
				xmlWriter.WriteEndElement();
				xmlWriter.WriteEndDocument();
			}
		}

		// Token: 0x06000BBE RID: 3006 RVA: 0x0002D9E0 File Offset: 0x0002BBE0
		private void WriteObjectBehaviour(XmlWriter writer, IEnumerable<KeyValuePair<string, object>> behaviour)
		{
			foreach (KeyValuePair<string, object> keyValuePair in behaviour)
			{
				writer.WriteStartElement(keyValuePair.Key);
				if (keyValuePair.Value is IEnumerable<KeyValuePair<string, object>>)
				{
					this.WriteObjectBehaviour(writer, (IEnumerable<KeyValuePair<string, object>>)keyValuePair.Value);
				}
				else
				{
					writer.WriteString(Convert.ToString(keyValuePair.Value, CultureInfo.InvariantCulture));
				}
				writer.WriteEndElement();
			}
		}

		// Token: 0x06000BBF RID: 3007 RVA: 0x0002DA70 File Offset: 0x0002BC70
		public void ConvertObjectEntriesToPlacements()
		{
			this._binding.ObjectPlacements.Clear();
			foreach (ObjectEntry objectEntry in this._binding.Level.ObjectManager.ObjectEntryTable)
			{
				ObjectPlacement objectPlacement = new ObjectPlacement(objectEntry.Type.ResourceKey, objectEntry.Uid, objectEntry.Name, objectEntry.Layer, objectEntry.Position, objectEntry.State);
				foreach (ObjectMapping objectMapping in objectEntry.Mappings)
				{
					List<KeyValuePair<string, object>> list = objectPlacement.Mappings as List<KeyValuePair<string, object>>;
					KeyValuePair<string, object> item = new KeyValuePair<string, object>(objectMapping.Field, objectMapping.Target);
					list.Add(item);
				}
				this._binding.ObjectPlacements.Add(objectPlacement);
			}
		}

		// Token: 0x040006B0 RID: 1712
		private readonly LevelBinding _binding;
	}
}
