using System;
using System.Collections.Generic;

namespace SonicOrca.Graphics.V2.Animation
{
	// Token: 0x020000F1 RID: 241
	public class CompositionLayerOpacityTween : CompositionLayerTween
	{
		// Token: 0x0600085C RID: 2140 RVA: 0x00020F20 File Offset: 0x0001F120
		public CompositionLayerOpacityTween(uint startFrame, uint endFrame, KeyValuePair<double, double> startEndValues) : base(startFrame, endFrame)
		{
			base.StartValues["Opacity"] = startEndValues.Key;
			base.EndValues["Opacity"] = startEndValues.Value;
			base.TweenType = CompositionLayerTween.Type.OPACITY;
			base.ValueKeys.Add("Opacity");
		}
	}
}
