using System;
using System.Collections.Generic;

namespace SonicOrca.Graphics.V2.Animation
{
	// Token: 0x020000F0 RID: 240
	public class CompositionLayerPositionTween : CompositionLayerTween
	{
		// Token: 0x0600085A RID: 2138 RVA: 0x00020DB0 File Offset: 0x0001EFB0
		public CompositionLayerPositionTween(uint startFrame, uint endFrame, KeyValuePair<double, double> startEndValuesX, KeyValuePair<double, double> startEndValuesY, KeyValuePair<double, double> startEndValuesZ) : base(startFrame, endFrame)
		{
			base.StartValues["X"] = startEndValuesX.Key;
			base.StartValues["Y"] = startEndValuesY.Key;
			base.StartValues["Z"] = startEndValuesZ.Key;
			base.EndValues["X"] = startEndValuesX.Value;
			base.EndValues["Y"] = startEndValuesY.Value;
			base.EndValues["Z"] = startEndValuesZ.Value;
			base.TweenType = CompositionLayerTween.Type.POSITION;
			base.ValueKeys.Add("X");
			base.ValueKeys.Add("Y");
			base.ValueKeys.Add("Z");
		}

		// Token: 0x0600085B RID: 2139 RVA: 0x00020E88 File Offset: 0x0001F088
		public CompositionLayerPositionTween(uint startFrame, uint endFrame, KeyValuePair<double, double> startEndValuesX, KeyValuePair<double, double> startEndValuesY) : base(startFrame, endFrame)
		{
			base.StartValues["X"] = startEndValuesX.Key;
			base.StartValues["Y"] = startEndValuesY.Key;
			base.EndValues["X"] = startEndValuesX.Value;
			base.EndValues["Y"] = startEndValuesY.Value;
			base.TweenType = CompositionLayerTween.Type.POSITION;
			base.ValueKeys.Add("X");
			base.ValueKeys.Add("Y");
		}
	}
}
