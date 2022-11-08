using System;
using SonicOrca.Resources;

namespace SonicOrca.Audio
{
	// Token: 0x020001A6 RID: 422
	public class SampleInfo : ILoadedResource, IDisposable
	{
		// Token: 0x170004D7 RID: 1239
		// (get) Token: 0x06001224 RID: 4644 RVA: 0x00047911 File Offset: 0x00045B11
		// (set) Token: 0x06001225 RID: 4645 RVA: 0x00047919 File Offset: 0x00045B19
		public Resource Resource { get; set; }

		// Token: 0x170004D8 RID: 1240
		// (get) Token: 0x06001226 RID: 4646 RVA: 0x00047922 File Offset: 0x00045B22
		// (set) Token: 0x06001227 RID: 4647 RVA: 0x0004792A File Offset: 0x00045B2A
		public Sample Sample { get; private set; }

		// Token: 0x170004D9 RID: 1241
		// (get) Token: 0x06001228 RID: 4648 RVA: 0x00047934 File Offset: 0x00045B34
		public bool HasLoopPoint
		{
			get
			{
				return this._loopSampleIndex != null;
			}
		}

		// Token: 0x170004DA RID: 1242
		// (get) Token: 0x06001229 RID: 4649 RVA: 0x00047950 File Offset: 0x00045B50
		public int LoopSampleIndex
		{
			get
			{
				return this._loopSampleIndex.Value;
			}
		}

		// Token: 0x0600122A RID: 4650 RVA: 0x0004796B File Offset: 0x00045B6B
		public SampleInfo(Sample sample, int? loopSampleIndex = null)
		{
			this.Sample = sample;
			this._loopSampleIndex = loopSampleIndex;
		}

		// Token: 0x0600122B RID: 4651 RVA: 0x00047981 File Offset: 0x00045B81
		public SampleInfo(ResourceTree resourceTree, string sampleResourceKeyPath, int? loopSampleIndex = null)
		{
			this._resourceTree = resourceTree;
			this._sampleResourceKeyPath = sampleResourceKeyPath;
			this._loopSampleIndex = loopSampleIndex;
		}

		// Token: 0x0600122C RID: 4652 RVA: 0x0004799E File Offset: 0x00045B9E
		public void OnLoaded()
		{
			if (this._sampleResourceKeyPath != null)
			{
				this.Sample = this._resourceTree.GetLoadedResource<Sample>(this._sampleResourceKeyPath);
			}
		}

		// Token: 0x0600122D RID: 4653 RVA: 0x00006325 File Offset: 0x00004525
		public void Dispose()
		{
		}

		// Token: 0x04000A10 RID: 2576
		private readonly ResourceTree _resourceTree;

		// Token: 0x04000A11 RID: 2577
		private readonly string _sampleResourceKeyPath;

		// Token: 0x04000A12 RID: 2578
		private readonly int? _loopSampleIndex;
	}
}
