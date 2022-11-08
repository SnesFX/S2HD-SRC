using System;
using SonicOrca.Core;
using SonicOrca.Core.Objects.Metadata;
using SonicOrca.Geometry;

namespace SONICORCA.OBJECTS.LAYERSWITCH
{
	// Token: 0x02000014 RID: 20
	[Name("Layer switch")]
	[Description("Allow characters to switch layers.")]
	[Classification(ObjectClassification.General)]
	[ObjectInstance(typeof(LayerSwitchInstance))]
	public class LayerSwitchType : ObjectType
	{
		// Token: 0x06000070 RID: 112 RVA: 0x0000615B File Offset: 0x0000435B
		public Vector2 GetLifeRadius(LayerSwitchInstance state)
		{
			return new Vector2((double)(state.Width / 2), (double)(state.Height / 2));
		}
	}
}
