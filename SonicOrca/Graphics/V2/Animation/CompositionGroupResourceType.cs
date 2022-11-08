using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using SonicOrca.Extensions;
using SonicOrca.Resources;

namespace SonicOrca.Graphics.V2.Animation
{
	// Token: 0x020000F8 RID: 248
	public class CompositionGroupResourceType : ResourceType
	{
		// Token: 0x06000889 RID: 2185 RVA: 0x00021528 File Offset: 0x0001F728
		public CompositionGroupResourceType() : base(ResourceTypeIdentifier.CompositionGroup)
		{
		}

		// Token: 0x170001D5 RID: 469
		// (get) Token: 0x0600088A RID: 2186 RVA: 0x00021535 File Offset: 0x0001F735
		public override string Name
		{
			get
			{
				return "composition, xml";
			}
		}

		// Token: 0x170001D6 RID: 470
		// (get) Token: 0x0600088B RID: 2187 RVA: 0x0002153C File Offset: 0x0001F73C
		public override string DefaultExtension
		{
			get
			{
				return ".composition.xml";
			}
		}

		// Token: 0x0600088C RID: 2188 RVA: 0x00021544 File Offset: 0x0001F744
		public override async Task<ILoadedResource> LoadAsync(ResourceLoadArgs e, CancellationToken ct = default(CancellationToken))
		{
			List<string> textureResourceKeys = new List<string>();
			List<CompositionAsset> assets = new List<CompositionAsset>();
			List<CompositionLayer> layers = new List<CompositionLayer>();
			List<Composition> compositions = new List<Composition>();
			XmlDocument xmlDocument = new XmlDocument();
			await Task.Run(delegate()
			{
				xmlDocument.Load(e.InputStream);
			});
			XmlNode xmlNode = xmlDocument.SelectSingleNode("root");
			string text = "";
			string s = "";
			string s2 = "";
			string s3 = "";
			string s4 = "";
			string s5 = "";
			string text2 = "";
			xmlNode.TryGetNodeInnerText("v", out text);
			xmlNode.TryGetNodeInnerText("fr", out s);
			xmlNode.TryGetNodeInnerText("ip", out s2);
			xmlNode.TryGetNodeInnerText("op", out s3);
			xmlNode.TryGetNodeInnerText("w", out s4);
			xmlNode.TryGetNodeInnerText("h", out s5);
			xmlNode.TryGetNodeInnerText("nm", out text2);
			foreach (XmlNode node in xmlNode.SelectNodes("assets").OfType<XmlNode>())
			{
				string id = "";
				string s6 = "";
				string s7 = "";
				string path = "";
				string fileName = "";
				node.TryGetNodeInnerText("id", out id);
				node.TryGetNodeInnerText("w", out s6);
				node.TryGetNodeInnerText("h", out s7);
				node.TryGetNodeInnerText("u", out path);
				node.TryGetNodeInnerText("p", out fileName);
				assets.Add(new CompositionAsset(id, int.Parse(s6), int.Parse(s7), path, fileName));
			}
			foreach (XmlNode xmlNode2 in xmlNode.SelectNodes("layers").OfType<XmlNode>())
			{
				string s8 = "";
				string s9 = "";
				string s10 = "";
				string text3 = "";
				string text4 = "";
				string text5 = "";
				string text6 = "";
				string s11 = "";
				string s12 = "";
				string s13 = "";
				xmlNode2.TryGetNodeInnerText("ind", out s8);
				xmlNode2.TryGetNodeInnerText("ty", out s9);
				xmlNode2.TryGetNodeInnerText("td", out s10);
				xmlNode2.TryGetNodeInnerText("nm", out text3);
				xmlNode2.TryGetNodeInnerText("bm", out s13);
				xmlNode2.TryGetNodeInnerText("cl", out text4);
				xmlNode2.TryGetNodeInnerText("refId", out text5);
				xmlNode2.TryGetNodeInnerText("sr", out text6);
				xmlNode2.TryGetNodeInnerText("ip", out s11);
				xmlNode2.TryGetNodeInnerText("op", out s12);
				uint index = uint.Parse(s8);
				uint layerType = uint.Parse(s9);
				uint layerSubType = 0U;
				uint.TryParse(s10, out layerSubType);
				uint layerBlendMode = 0U;
				uint.TryParse(s13, out layerBlendMode);
				string name = text3;
				string fileExtension = text4;
				string textureReference = text5;
				uint num = uint.Parse(s11);
				uint num2 = uint.Parse(s12);
				XmlNode xmlNode3 = xmlNode2.SelectSingleNode("ks");
				XmlNode transformNode = xmlNode3.SelectSingleNode("o");
				XmlNode xmlNode4 = xmlNode3.SelectSingleNode("r");
				XmlNode xmlNode5 = xmlNode3.SelectSingleNode("p");
				XmlNode xmlNode6 = xmlNode3.SelectSingleNode("s");
				xmlNode4.SelectNodes("k").OfType<XmlNode>();
				xmlNode5.SelectNodes("k").OfType<XmlNode>();
				xmlNode6.SelectNodes("k").OfType<XmlNode>();
				List<CompositionLayerTween> list = new List<CompositionLayerTween>();
				list.AddRange(this.ParseScalarTransform(transformNode, CompositionLayerTween.Type.OPACITY, num, num2));
				list.AddRange(this.ParseScalarTransform(xmlNode4, CompositionLayerTween.Type.ROTATION, num, num2));
				list.AddRange(this.ParseVectorTransform(xmlNode5, CompositionLayerTween.Type.POSITION, num, num2));
				list.AddRange(this.ParseVectorTransform(xmlNode6, CompositionLayerTween.Type.SCALE, num, num2));
				CompositionLayerAnimatableTransform compositionLayerAnimatableTransform = new CompositionLayerAnimatableTransform();
				foreach (CompositionLayerTween tween in list)
				{
					compositionLayerAnimatableTransform.AddKeyFrameTween(tween);
				}
				layers.Add(new CompositionLayer(index, layerType, layerSubType, layerBlendMode, name, fileExtension, textureReference, num, num2, compositionLayerAnimatableTransform));
			}
			layers = (from l in layers
			orderby l.Index
			select l).ToList<CompositionLayer>();
			string version = text;
			uint frameRate = uint.Parse(s);
			uint startFrame = uint.Parse(s2);
			uint endFrame = uint.Parse(s3);
			uint width = uint.Parse(s4);
			uint height = uint.Parse(s5);
			string name2 = text2;
			compositions.Add(new Composition(version, frameRate, startFrame, endFrame, width, height, name2, layers));
			string fullKeyPath = e.Resource.FullKeyPath;
			string str = fullKeyPath.Remove(fullKeyPath.LastIndexOf("/"));
			foreach (CompositionAsset compositionAsset in assets)
			{
				string text7 = compositionAsset.FileName.Remove(compositionAsset.FileName.LastIndexOf(".")).Replace('_', '/');
				textureResourceKeys.Add(str + "/" + compositionAsset.Path.ToUpper() + text7.ToUpper());
			}
			e.PushDependencies(textureResourceKeys);
			return new CompositionGroup(e.ResourceTree, textureResourceKeys, assets, compositions)
			{
				Resource = e.Resource
			};
		}

		// Token: 0x0600088D RID: 2189 RVA: 0x00021594 File Offset: 0x0001F794
		private IEnumerable<CompositionLayerTween> ParseScalarTransform(XmlNode transformNode, CompositionLayerTween.Type tweenType, uint layerStartFrame, uint layerEndFrame)
		{
			List<CompositionLayerTween> list = new List<CompositionLayerTween>();
			if (this.TransformPropertyHasKeyFrames(transformNode))
			{
				list.AddRange(this.ParseScalarTweenKeySet(transformNode.SelectNodes("k").OfType<XmlNode>(), tweenType));
			}
			else
			{
				list.Add(this.ParseSimpleTweenTransform(transformNode, tweenType, layerStartFrame, layerEndFrame));
			}
			return list;
		}

		// Token: 0x0600088E RID: 2190 RVA: 0x000215E4 File Offset: 0x0001F7E4
		private IEnumerable<CompositionLayerTween> ParseVectorTransform(XmlNode transformNode, CompositionLayerTween.Type tweenType, uint layerStartFrame, uint layerEndFrame)
		{
			List<CompositionLayerTween> list = new List<CompositionLayerTween>();
			if (this.TransformPropertyHasKeyFrames(transformNode))
			{
				list.AddRange(this.ParseVectorTweenKeySet(transformNode.SelectNodes("k").OfType<XmlNode>(), tweenType));
			}
			else
			{
				list.Add(this.ParseSimpleTweenTransform(transformNode, tweenType, layerStartFrame, layerEndFrame));
			}
			return list;
		}

		// Token: 0x0600088F RID: 2191 RVA: 0x00021634 File Offset: 0x0001F834
		private IEnumerable<CompositionLayerTween> ParseScalarTweenKeySet(IEnumerable<XmlNode> tweenKeySet, CompositionLayerTween.Type tweenType)
		{
			if (tweenType != CompositionLayerTween.Type.OPACITY && tweenType != CompositionLayerTween.Type.ROTATION)
			{
				throw new NotImplementedException();
			}
			Type type = (tweenType == CompositionLayerTween.Type.OPACITY) ? typeof(CompositionLayerOpacityTween) : typeof(CompositionLayerRotationTween);
			List<CompositionLayerTween> list = new List<CompositionLayerTween>();
			XmlNode xmlNode = tweenKeySet.First<XmlNode>();
			XmlNode node = tweenKeySet.First<XmlNode>();
			string s = "";
			string text = "";
			string text2 = "";
			node.TryGetNodeInnerText("t", out s);
			node.TryGetNodeInnerText("s", out text);
			node.TryGetNodeInnerText("e", out text2);
			KeyValuePair<double, double> keyValuePair;
			if (!string.IsNullOrEmpty(text) && !string.IsNullOrEmpty(text2))
			{
				keyValuePair = new KeyValuePair<double, double>(double.Parse(text, NumberStyles.Float, CultureInfo.InvariantCulture), double.Parse(text2, NumberStyles.Float, CultureInfo.InvariantCulture));
			}
			else if (tweenType == CompositionLayerTween.Type.OPACITY)
			{
				keyValuePair = new KeyValuePair<double, double>(100.0, 100.0);
			}
			else
			{
				if (tweenType != CompositionLayerTween.Type.ROTATION)
				{
					throw new NotImplementedException();
				}
				keyValuePair = new KeyValuePair<double, double>(0.0, 0.0);
			}
			uint num = (uint)Math.Round(double.Parse(s, NumberStyles.Float, CultureInfo.InvariantCulture));
			CompositionLayerTween compositionLayerTween = (CompositionLayerTween)Activator.CreateInstance(type, new object[]
			{
				num,
				uint.MaxValue,
				keyValuePair
			});
			foreach (XmlNode xmlNode2 in tweenKeySet.Skip(1))
			{
				xmlNode = xmlNode2;
				string s2 = "";
				string text3 = "";
				string text4 = "";
				xmlNode2.TryGetNodeInnerText("t", out s2);
				xmlNode2.TryGetNodeInnerText("s", out text3);
				xmlNode2.TryGetNodeInnerText("e", out text4);
				KeyValuePair<double, double> keyValuePair2;
				if (!string.IsNullOrEmpty(text3) && !string.IsNullOrEmpty(text4))
				{
					keyValuePair2 = new KeyValuePair<double, double>(double.Parse(text3, NumberStyles.Float, CultureInfo.InvariantCulture), double.Parse(text4, NumberStyles.Float, CultureInfo.InvariantCulture));
				}
				else
				{
					if (tweenType != CompositionLayerTween.Type.OPACITY && tweenType != CompositionLayerTween.Type.ROTATION)
					{
						throw new NotImplementedException();
					}
					keyValuePair2 = new KeyValuePair<double, double>(compositionLayerTween.EndValues.First<KeyValuePair<string, double>>().Value, compositionLayerTween.EndValues.First<KeyValuePair<string, double>>().Value);
				}
				KeyValuePair<double, double> keyValuePair3 = new KeyValuePair<double, double>(compositionLayerTween.StartValues.First<KeyValuePair<string, double>>().Value, compositionLayerTween.EndValues.First<KeyValuePair<string, double>>().Value);
				uint num2 = (uint)Math.Round(double.Parse(s2, NumberStyles.Float, CultureInfo.InvariantCulture));
				compositionLayerTween = (CompositionLayerTween)Activator.CreateInstance(type, new object[]
				{
					compositionLayerTween.StartFrame,
					num2,
					keyValuePair3
				});
				list.Add(compositionLayerTween);
				if (xmlNode2 != tweenKeySet.Last<XmlNode>())
				{
					compositionLayerTween = (CompositionLayerTween)Activator.CreateInstance(type, new object[]
					{
						num2,
						uint.MaxValue,
						keyValuePair2
					});
				}
			}
			if (xmlNode == tweenKeySet.First<XmlNode>())
			{
				throw new NotSupportedException();
			}
			return list;
		}

		// Token: 0x06000890 RID: 2192 RVA: 0x00021964 File Offset: 0x0001FB64
		private IEnumerable<CompositionLayerTween> ParseVectorTweenKeySet(IEnumerable<XmlNode> tweenKeySet, CompositionLayerTween.Type tweenType)
		{
			if (tweenType != CompositionLayerTween.Type.POSITION && tweenType != CompositionLayerTween.Type.SCALE)
			{
				throw new NotImplementedException();
			}
			Type type = (tweenType == CompositionLayerTween.Type.POSITION) ? typeof(CompositionLayerPositionTween) : typeof(CompositionLayerScaleTween);
			List<CompositionLayerTween> list = new List<CompositionLayerTween>();
			XmlNode xmlNode = tweenKeySet.First<XmlNode>();
			XmlNode xmlNode2 = tweenKeySet.First<XmlNode>();
			string s = "";
			List<string> list2 = new List<string>();
			List<string> list3 = new List<string>();
			xmlNode2.TryGetNodeInnerText("t", out s);
			IEnumerable<XmlNode> source = xmlNode2.SelectNodes("s").OfType<XmlNode>();
			IEnumerable<XmlNode> source2 = xmlNode2.SelectNodes("e").OfType<XmlNode>();
			if (source.Count<XmlNode>() == 3 && source2.Count<XmlNode>() == 3)
			{
				list2.Add(source.ElementAt(0).InnerText);
				list2.Add(source.ElementAt(1).InnerText);
				list2.Add(source.ElementAt(2).InnerText);
				list3.Add(source2.ElementAt(0).InnerText);
				list3.Add(source2.ElementAt(1).InnerText);
				list3.Add(source2.ElementAt(2).InnerText);
			}
			else if (source.Count<XmlNode>() != 0 && source2.Count<XmlNode>() != 0)
			{
				throw new NotImplementedException();
			}
			List<KeyValuePair<double, double>> list4 = new List<KeyValuePair<double, double>>();
			if (list2.All((string v) => !string.IsNullOrEmpty(v)))
			{
				if (list3.All((string v) => !string.IsNullOrEmpty(v)) && list2.Count > 0 && list3.Count > 0)
				{
					for (int i = 0; i < 3; i++)
					{
						list4.Add(new KeyValuePair<double, double>(double.Parse(list2[i], NumberStyles.Float, CultureInfo.InvariantCulture), double.Parse(list3[i], NumberStyles.Float, CultureInfo.InvariantCulture)));
					}
					goto IL_257;
				}
			}
			if (tweenType == CompositionLayerTween.Type.SCALE)
			{
				for (int j = 0; j < 3; j++)
				{
					list4.Add(new KeyValuePair<double, double>(100.0, 100.0));
				}
			}
			else
			{
				if (tweenType != CompositionLayerTween.Type.POSITION)
				{
					throw new NotImplementedException();
				}
				for (int k = 0; k < 3; k++)
				{
					list4.Add(new KeyValuePair<double, double>(0.0, 0.0));
				}
			}
			IL_257:
			uint num = (uint)Math.Round(double.Parse(s, NumberStyles.Float, CultureInfo.InvariantCulture));
			CompositionLayerTween compositionLayerTween = (CompositionLayerTween)Activator.CreateInstance(type, new object[]
			{
				num,
				uint.MaxValue,
				list4[0],
				list4[1],
				list4[2]
			});
			foreach (XmlNode xmlNode3 in tweenKeySet.Skip(1))
			{
				xmlNode = xmlNode3;
				string s2 = "";
				List<string> list5 = new List<string>();
				List<string> list6 = new List<string>();
				xmlNode3.TryGetNodeInnerText("t", out s2);
				IEnumerable<XmlNode> source3 = xmlNode3.SelectNodes("s").OfType<XmlNode>();
				IEnumerable<XmlNode> source4 = xmlNode3.SelectNodes("e").OfType<XmlNode>();
				if (source3.Count<XmlNode>() == 3 && source4.Count<XmlNode>() == 3)
				{
					list5.Add(source3.ElementAt(0).InnerText);
					list5.Add(source3.ElementAt(1).InnerText);
					list5.Add(source3.ElementAt(2).InnerText);
					list6.Add(source4.ElementAt(0).InnerText);
					list6.Add(source4.ElementAt(1).InnerText);
					list6.Add(source4.ElementAt(2).InnerText);
				}
				else if (source3.Count<XmlNode>() != 0 && source4.Count<XmlNode>() != 0)
				{
					throw new NotImplementedException();
				}
				List<KeyValuePair<double, double>> list7 = new List<KeyValuePair<double, double>>();
				if (!list5.All((string v) => !string.IsNullOrEmpty(v)))
				{
					goto IL_493;
				}
				if (!list6.All((string v) => !string.IsNullOrEmpty(v)) || list5.Count <= 0 || list6.Count <= 0)
				{
					goto IL_493;
				}
				for (int l = 0; l < 3; l++)
				{
					list7.Add(new KeyValuePair<double, double>(double.Parse(list5[l], NumberStyles.Float, CultureInfo.InvariantCulture), double.Parse(list6[l], NumberStyles.Float, CultureInfo.InvariantCulture)));
				}
				IL_4EB:
				List<KeyValuePair<double, double>> list8 = new List<KeyValuePair<double, double>>();
				for (int m = 0; m < 3; m++)
				{
					KeyValuePair<double, double> item = new KeyValuePair<double, double>(compositionLayerTween.StartValues.ElementAt(m).Value, compositionLayerTween.EndValues.ElementAt(m).Value);
					list8.Add(item);
				}
				uint num2 = (uint)Math.Round(double.Parse(s2, NumberStyles.Float, CultureInfo.InvariantCulture));
				compositionLayerTween = (CompositionLayerTween)Activator.CreateInstance(type, new object[]
				{
					compositionLayerTween.StartFrame,
					num2,
					list8[0],
					list8[1],
					list8[2]
				});
				list.Add(compositionLayerTween);
				if (xmlNode3 != tweenKeySet.Last<XmlNode>())
				{
					compositionLayerTween = (CompositionLayerTween)Activator.CreateInstance(type, new object[]
					{
						num2,
						uint.MaxValue,
						list7[0],
						list7[1],
						list7[2]
					});
					continue;
				}
				continue;
				IL_493:
				if (tweenType == CompositionLayerTween.Type.POSITION || tweenType == CompositionLayerTween.Type.SCALE)
				{
					for (int n = 0; n < 3; n++)
					{
						list7.Add(new KeyValuePair<double, double>(compositionLayerTween.EndValues.ElementAt(n).Value, compositionLayerTween.EndValues.ElementAt(n).Value));
					}
					goto IL_4EB;
				}
				throw new NotImplementedException();
			}
			if (xmlNode == tweenKeySet.First<XmlNode>())
			{
				throw new NotSupportedException();
			}
			return list;
		}

		// Token: 0x06000891 RID: 2193 RVA: 0x00021FD0 File Offset: 0x000201D0
		private CompositionLayerTween ParseSimpleTweenTransform(XmlNode tweenKey, CompositionLayerTween.Type tweenType, uint layerStartFrame, uint layerEndFrame)
		{
			Type type = null;
			switch (tweenType)
			{
			case CompositionLayerTween.Type.OPACITY:
				type = typeof(CompositionLayerOpacityTween);
				break;
			case CompositionLayerTween.Type.POSITION:
				type = typeof(CompositionLayerPositionTween);
				break;
			case CompositionLayerTween.Type.ROTATION:
				type = typeof(CompositionLayerRotationTween);
				break;
			case CompositionLayerTween.Type.SCALE:
				type = typeof(CompositionLayerScaleTween);
				break;
			}
			CompositionLayerTween compositionLayerTween;
			if (tweenType == CompositionLayerTween.Type.OPACITY || tweenType == CompositionLayerTween.Type.ROTATION)
			{
				double num = double.Parse(tweenKey.SelectSingleNode("k").InnerText, NumberStyles.Float, CultureInfo.InvariantCulture);
				KeyValuePair<double, double> keyValuePair = new KeyValuePair<double, double>(num, num);
				compositionLayerTween = (CompositionLayerTween)Activator.CreateInstance(type, new object[]
				{
					layerStartFrame,
					layerEndFrame,
					keyValuePair
				});
			}
			else
			{
				IEnumerable<XmlNode> source = tweenKey.SelectNodes("k").OfType<XmlNode>();
				if (source.Count<XmlNode>() != 3)
				{
					throw new NotSupportedException();
				}
				string innerText = source.ElementAt(0).InnerText;
				string innerText2 = source.ElementAt(1).InnerText;
				double num2 = double.Parse(innerText, NumberStyles.Float, CultureInfo.InvariantCulture);
				double num3 = double.Parse(innerText2, NumberStyles.Float, CultureInfo.InvariantCulture);
				KeyValuePair<double, double> keyValuePair2 = new KeyValuePair<double, double>(num2, num2);
				KeyValuePair<double, double> keyValuePair3 = new KeyValuePair<double, double>(num3, num3);
				compositionLayerTween = (CompositionLayerTween)Activator.CreateInstance(type, new object[]
				{
					layerStartFrame,
					layerEndFrame,
					keyValuePair2,
					keyValuePair3
				});
			}
			compositionLayerTween.HasKeyFrames = false;
			return compositionLayerTween;
		}

		// Token: 0x06000892 RID: 2194 RVA: 0x0002215B File Offset: 0x0002035B
		private bool TransformPropertyHasKeyFrames(XmlNode node)
		{
			return node.SelectSingleNode("k").SelectSingleNode("t") != null;
		}
	}
}
