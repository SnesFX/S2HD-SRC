using System;
using System.Collections.Generic;

namespace SonicOrca.Graphics.V2.Animation
{
	// Token: 0x020000F3 RID: 243
	public class CompositionLayerScaleTween : CompositionLayerTween
	{
		// Token: 0x0600085E RID: 2142 RVA: 0x00020FD8 File Offset: 0x0001F1D8
		public CompositionLayerScaleTween(uint startFrame, uint endFrame, KeyValuePair<double, double> startEndValuesX, KeyValuePair<double, double> startEndValuesY, KeyValuePair<double, double> startEndValuesZ) : base(startFrame, endFrame)
		{
			base.StartValues["X"] = startEndValuesX.Key;
			base.StartValues["Y"] = startEndValuesY.Key;
			base.StartValues["Z"] = startEndValuesZ.Key;
			base.EndValues["X"] = startEndValuesX.Value;
			base.EndValues["Y"] = startEndValuesY.Value;
			base.EndValues["Z"] = startEndValuesZ.Value;
			base.TweenType = CompositionLayerTween.Type.SCALE;
			base.ValueKeys.Add("X");
			base.ValueKeys.Add("Y");
			base.ValueKeys.Add("Z");
		}

		// Token: 0x0600085F RID: 2143 RVA: 0x000210B0 File Offset: 0x0001F2B0
		public CompositionLayerScaleTween(uint startFrame, uint endFrame, KeyValuePair<double, double> startEndValuesX, KeyValuePair<double, double> startEndValuesY) : base(startFrame, endFrame)
		{
			base.StartValues["X"] = startEndValuesX.Key;
			base.StartValues["Y"] = startEndValuesY.Key;
			base.EndValues["X"] = startEndValuesX.Value;
			base.EndValues["Y"] = startEndValuesY.Value;
			base.TweenType = CompositionLayerTween.Type.SCALE;
			base.ValueKeys.Add("X");
			base.ValueKeys.Add("Y");
		}
	}
}
