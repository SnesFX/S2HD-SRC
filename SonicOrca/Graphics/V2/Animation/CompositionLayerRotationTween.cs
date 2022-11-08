using System;
using System.Collections.Generic;

namespace SonicOrca.Graphics.V2.Animation
{
	// Token: 0x020000F2 RID: 242
	public class CompositionLayerRotationTween : CompositionLayerTween
	{
		// Token: 0x0600085D RID: 2141 RVA: 0x00020F7C File Offset: 0x0001F17C
		public CompositionLayerRotationTween(uint startFrame, uint endFrame, KeyValuePair<double, double> startEndValues) : base(startFrame, endFrame)
		{
			base.StartValues["Rotation"] = startEndValues.Key;
			base.EndValues["Rotation"] = startEndValues.Value;
			base.TweenType = CompositionLayerTween.Type.ROTATION;
			base.ValueKeys.Add("Rotation");
		}
	}
}
