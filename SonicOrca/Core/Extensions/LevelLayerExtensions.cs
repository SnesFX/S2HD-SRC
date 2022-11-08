using System;
using System.Collections.Generic;

namespace SonicOrca.Core.Extensions
{
	// Token: 0x0200018E RID: 398
	public static class LevelLayerExtensions
	{
		// Token: 0x0600113E RID: 4414 RVA: 0x0004439F File Offset: 0x0004259F
		public static IEnumerable<ILevelLayerTreeNode> GetDescendantsOrdered(this ILevelLayerTreeNode node)
		{
			IList<ILevelLayerTreeNode> children = node.Children;
			if (children == null)
			{
				yield break;
			}
			foreach (ILevelLayerTreeNode child in children)
			{
				yield return child;
				foreach (ILevelLayerTreeNode levelLayerTreeNode in child.GetDescendantsOrdered())
				{
					yield return levelLayerTreeNode;
				}
				IEnumerator<ILevelLayerTreeNode> enumerator2 = null;
				child = null;
			}
			IEnumerator<ILevelLayerTreeNode> enumerator = null;
			yield break;
			yield break;
		}
	}
}
