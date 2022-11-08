using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.CSharp.RuntimeBinder;
using SonicOrca.Extensions;
using SonicOrca.Geometry;
using SonicOrca.Resources;

namespace SonicOrca.Core
{
	// Token: 0x02000128 RID: 296
	public class LevelBindingResourceType : ResourceType
	{
		// Token: 0x170002C8 RID: 712
		// (get) Token: 0x06000BA0 RID: 2976 RVA: 0x0002CA09 File Offset: 0x0002AC09
		public override string Name
		{
			get
			{
				return "binding, xml";
			}
		}

		// Token: 0x170002C9 RID: 713
		// (get) Token: 0x06000BA1 RID: 2977 RVA: 0x0002CA10 File Offset: 0x0002AC10
		public override string DefaultExtension
		{
			get
			{
				return ".binding.xml";
			}
		}

		// Token: 0x170002CA RID: 714
		// (get) Token: 0x06000BA2 RID: 2978 RVA: 0x00006340 File Offset: 0x00004540
		public override bool CompressByDefault
		{
			get
			{
				return true;
			}
		}

		// Token: 0x06000BA3 RID: 2979 RVA: 0x0002CA17 File Offset: 0x0002AC17
		public LevelBindingResourceType() : base(ResourceTypeIdentifier.Binding)
		{
		}

		// Token: 0x06000BA4 RID: 2980 RVA: 0x0002CA24 File Offset: 0x0002AC24
		public override async Task<ILoadedResource> LoadAsync(ResourceLoadArgs e, CancellationToken ct = default(CancellationToken))
		{
			XmlDocument xmlDocument = new XmlDocument();
			await Task.Run(delegate()
			{
				xmlDocument.Load(e.InputStream);
			});
			LevelBinding levelBinding = new LevelBinding();
			levelBinding.Resource = e.Resource;
			XmlNode xmlNode = xmlDocument.SelectSingleNode("Binding/Definitions");
			int defaultLayerIndex;
			string s;
			if (!xmlNode.TryGetAttributeValue("DefaultLayer", out s) || !int.TryParse(s, out defaultLayerIndex))
			{
				defaultLayerIndex = 0;
			}
			levelBinding.ObjectPlacements.AddRange(from x in xmlNode.SelectNodes("Definition").OfType<XmlNode>()
			select this.GetObjectPlacementFromXmlNode(x, defaultLayerIndex));
			e.PushDependencies((from x in levelBinding.ObjectPlacements
			select x.Key).Distinct<string>());
			return levelBinding;
		}

		// Token: 0x06000BA5 RID: 2981 RVA: 0x0002CA74 File Offset: 0x0002AC74
		private ObjectPlacement GetObjectPlacementFromXmlNode(XmlNode node, int defaultLayerIndex)
		{
			XmlNode xmlNode = node.SelectSingleNode("Common");
			XmlNode xmlNode2 = node.SelectSingleNode("Behaviour");
			XmlNode xmlNode3 = node.SelectSingleNode("Mappings");
			XmlNode xmlNode4 = xmlNode.SelectSingleNode("Key");
			XmlNode xmlNode5 = xmlNode.SelectSingleNode("Uid");
			XmlNode xmlNode6 = xmlNode.SelectSingleNode("Name");
			XmlNode xmlNode7 = xmlNode.SelectSingleNode("Layer");
			XmlNode xmlNode8 = xmlNode.SelectSingleNode("Position");
			string s;
			int arg;
			if (xmlNode7 == null || !xmlNode.TryGetNodeInnerText("Layer", out s) || !int.TryParse(s, out arg))
			{
				arg = defaultLayerIndex;
			}
			Guid arg2 = default(Guid);
			Guid.TryParse(xmlNode5.InnerText, out arg2);
			object arg3 = new
			{

			};
			if (xmlNode2 != null && xmlNode2.HasChildNodes)
			{
				IEnumerable<KeyValuePair<string, object>> enumerable = this.ParseBehaviour(xmlNode2);
				ExpandoObject expandoObject = new ExpandoObject();
				ICollection<KeyValuePair<string, object>> collection = expandoObject;
				foreach (KeyValuePair<string, object> item in enumerable)
				{
					collection.Add(item);
				}
				arg3 = expandoObject;
			}
			if (LevelBindingResourceType.<>o__8.<>p__0 == null)
			{
				LevelBindingResourceType.<>o__8.<>p__0 = CallSite<Func<CallSite, Type, string, Guid, string, int, Vector2i, object, ObjectPlacement>>.Create(Binder.InvokeConstructor(CSharpBinderFlags.None, typeof(LevelBindingResourceType), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsStaticType, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
				}));
			}
			ObjectPlacement objectPlacement = LevelBindingResourceType.<>o__8.<>p__0.Target(LevelBindingResourceType.<>o__8.<>p__0, typeof(ObjectPlacement), xmlNode4.InnerText, arg2, xmlNode6.InnerText, arg, new Vector2i(int.Parse(xmlNode8.Attributes["X"].Value), int.Parse(xmlNode8.Attributes["Y"].Value)), arg3);
			if (xmlNode3 != null && xmlNode3.HasChildNodes)
			{
				objectPlacement.Mappings = new List<KeyValuePair<string, object>>(this.ParseBehaviour(xmlNode3));
			}
			return objectPlacement;
		}

		// Token: 0x06000BA6 RID: 2982 RVA: 0x0002CC88 File Offset: 0x0002AE88
		private IEnumerable<KeyValuePair<string, object>> ParseBehaviour(XmlNode entryNode)
		{
			foreach (object obj in entryNode.Attributes)
			{
				XmlAttribute xmlAttribute = (XmlAttribute)obj;
				string name = xmlAttribute.Name;
				object value = LevelBindingResourceType.ParseBehaviourValue(xmlAttribute.Value);
				yield return new KeyValuePair<string, object>(name, value);
			}
			IEnumerator enumerator = null;
			foreach (object obj2 in entryNode)
			{
				XmlNode xmlNode = (XmlNode)obj2;
				if (xmlNode.NodeType == XmlNodeType.Element)
				{
					string name2 = xmlNode.Name;
					(from x in xmlNode.ChildNodes.OfType<XmlNode>()
					where x.NodeType == XmlNodeType.Element
					select x).ToArray<XmlNode>();
					KeyValuePair<string, object>[] array = this.ParseBehaviour(xmlNode).ToArray<KeyValuePair<string, object>>();
					object value2 = (array.Length == 0) ? LevelBindingResourceType.ParseBehaviourValue(xmlNode.InnerText) : array;
					yield return new KeyValuePair<string, object>(name2, value2);
				}
			}
			enumerator = null;
			yield break;
			yield break;
		}

		// Token: 0x06000BA7 RID: 2983 RVA: 0x0002CCA0 File Offset: 0x0002AEA0
		public static object ParseBehaviourValue(string value)
		{
			int num;
			if (int.TryParse(value, out num))
			{
				return num;
			}
			double num2;
			if (double.TryParse(value, NumberStyles.Float, CultureInfo.InvariantCulture, out num2))
			{
				return num2;
			}
			bool flag;
			if (bool.TryParse(value, out flag))
			{
				return flag;
			}
			Guid guid;
			if (Guid.TryParse(value, out guid))
			{
				return guid;
			}
			return value;
		}

		// Token: 0x06000BA8 RID: 2984 RVA: 0x0002CCFC File Offset: 0x0002AEFC
		public static object ParseBehaviourValue(string value, Type type)
		{
			if (type == typeof(int))
			{
				int num;
				if (int.TryParse(value, out num))
				{
					return num;
				}
				return 0;
			}
			else if (type == typeof(uint))
			{
				uint num2;
				if (uint.TryParse(value, out num2))
				{
					return num2;
				}
				return 0U;
			}
			else if (type == typeof(double))
			{
				double num3;
				if (double.TryParse(value, NumberStyles.Float, CultureInfo.InvariantCulture, out num3))
				{
					return num3;
				}
				return 0.0;
			}
			else if (type == typeof(bool))
			{
				bool flag;
				if (bool.TryParse(value, out flag))
				{
					return flag;
				}
				return false;
			}
			else
			{
				if (type == typeof(Vector2))
				{
					string s = value.Trim(new char[]
					{
						'{',
						'}',
						' '
					}).Replace(" ", "").Split(new char[]
					{
						','
					})[0].Split(new char[]
					{
						'='
					})[1];
					string s2 = value.Trim(new char[]
					{
						'{',
						'}',
						' '
					}).Replace(" ", "").Split(new char[]
					{
						','
					})[1].Split(new char[]
					{
						'='
					})[1];
					double x;
					double.TryParse(s, NumberStyles.Float, CultureInfo.InvariantCulture, out x);
					double y;
					double.TryParse(s2, NumberStyles.Float, CultureInfo.InvariantCulture, out y);
					return new Vector2(x, y);
				}
				if (type == typeof(Vector2i))
				{
					string s3 = value.Trim(new char[]
					{
						'{',
						'}',
						' '
					}).Replace(" ", "").Split(new char[]
					{
						','
					})[0].Split(new char[]
					{
						'='
					})[1];
					string s4 = value.Trim(new char[]
					{
						'{',
						'}',
						' '
					}).Replace(" ", "").Split(new char[]
					{
						','
					})[1].Split(new char[]
					{
						'='
					})[1];
					int x2;
					int.TryParse(s3, out x2);
					int y2;
					int.TryParse(s4, out y2);
					return new Vector2i(x2, y2);
				}
				if (type == typeof(Guid))
				{
					Guid guid;
					if (Guid.TryParse(value, out guid))
					{
						return guid;
					}
					return default(Guid);
				}
				else
				{
					if (type.IsEnum)
					{
						return Enum.Parse(type, value, true);
					}
					return value;
				}
			}
		}
	}
}
