using System;
using SonicOrca.Core;
using SonicOrca.Core.Objects.Metadata;
using SonicOrca.Extensions;
using SonicOrca.Graphics;
using SonicOrca.Resources;

namespace SONICORCA.OBJECTS.RING
{
	// Token: 0x02000016 RID: 22
	[Name("Ring")]
	[Description("Ring from Sonic 1")]
	[Classification(ObjectClassification.Ring)]
	[ObjectInstance(typeof(RingInstance))]
	public class RingType : ObjectType
	{
		// Token: 0x17000015 RID: 21
		// (get) Token: 0x06000091 RID: 145 RVA: 0x000069E2 File Offset: 0x00004BE2
		// (set) Token: 0x06000092 RID: 146 RVA: 0x000069EA File Offset: 0x00004BEA
		public AnimationInstance AnimationInstance { get; private set; }

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x06000093 RID: 147 RVA: 0x000069F3 File Offset: 0x00004BF3
		// (set) Token: 0x06000094 RID: 148 RVA: 0x000069FB File Offset: 0x00004BFB
		public int LastAnimationTick { get; set; }

		// Token: 0x06000095 RID: 149 RVA: 0x00006A04 File Offset: 0x00004C04
		protected override void OnStart()
		{
			ResourceTree resourceTree = base.Level.GameContext.ResourceTree;
			this.AnimationInstance = new AnimationInstance(resourceTree, this.GetAbsolutePath("/ANIGROUP"), 0);
		}

		// Token: 0x06000096 RID: 150 RVA: 0x00006A3A File Offset: 0x00004C3A
		protected override void OnAnimate()
		{
			this.AnimationInstance.Animate();
		}

		// Token: 0x040000A2 RID: 162
		[Dependency]
		public const string AnimationGroupResourceKey = "/ANIGROUP";

		// Token: 0x040000A3 RID: 163
		[Dependency]
		public const string SparkleObjectResourceKey = "/SPARKLE";

		// Token: 0x040000A4 RID: 164
		[Dependency]
		public const string CollectSoundResourceKey = "SONICORCA/SOUND/RING";

		// Token: 0x040000A5 RID: 165
		[Dependency]
		public const string GlowParticleResourceKey = "SONICORCA/PARTICLE/GLOW";

		// Token: 0x040000A6 RID: 166
		[Dependency]
		public const string PerfectSoundResourceKey = "SONICORCA/SOUND/PERFECT";
	}
}
