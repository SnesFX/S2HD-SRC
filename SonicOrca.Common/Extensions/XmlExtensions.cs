using System;
using System.Xml;

namespace SonicOrca.Extensions
{
	// Token: 0x02000010 RID: 16
	public static class XmlExtensions
	{
		// Token: 0x06000032 RID: 50 RVA: 0x0000282C File Offset: 0x00000A2C
		public static string GetNodeInnerText(this XmlNode node, string xpath, string defaultValue)
		{
			string result;
			if (!node.TryGetNodeInnerText(xpath, out result))
			{
				result = defaultValue;
			}
			return result;
		}

		// Token: 0x06000033 RID: 51 RVA: 0x00002848 File Offset: 0x00000A48
		public static bool TryGetNodeInnerText(this XmlNode node, string xpath, out string value)
		{
			XmlNode xmlNode = node.SelectSingleNode(xpath);
			if (xmlNode == null)
			{
				value = null;
				return false;
			}
			value = xmlNode.InnerText;
			return true;
		}

		// Token: 0x06000034 RID: 52 RVA: 0x00002870 File Offset: 0x00000A70
		public static bool TryGetAttributeValue(this XmlNode node, string name, out string value)
		{
			XmlAttribute xmlAttribute = node.Attributes[name];
			if (xmlAttribute == null)
			{
				value = null;
				return false;
			}
			value = xmlAttribute.Value;
			return true;
		}
	}
}
