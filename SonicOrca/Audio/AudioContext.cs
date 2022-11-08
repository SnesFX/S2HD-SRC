using System;
using System.Collections.Generic;

namespace SonicOrca.Audio
{
	// Token: 0x0200019D RID: 413
	public abstract class AudioContext
	{
		// Token: 0x170004BE RID: 1214
		// (get) Token: 0x060011D8 RID: 4568 RVA: 0x00046E07 File Offset: 0x00045007
		// (set) Token: 0x060011D9 RID: 4569 RVA: 0x00046E0F File Offset: 0x0004500F
		public ISampleMixer Mixer { get; set; }

		// Token: 0x170004BF RID: 1215
		// (get) Token: 0x060011DA RID: 4570 RVA: 0x00046E18 File Offset: 0x00045018
		// (set) Token: 0x060011DB RID: 4571 RVA: 0x00046E20 File Offset: 0x00045020
		public double Volume { get; set; }

		// Token: 0x170004C0 RID: 1216
		// (get) Token: 0x060011DC RID: 4572 RVA: 0x00046E29 File Offset: 0x00045029
		// (set) Token: 0x060011DD RID: 4573 RVA: 0x00046E31 File Offset: 0x00045031
		public double MusicVolume { get; set; }

		// Token: 0x170004C1 RID: 1217
		// (get) Token: 0x060011DE RID: 4574 RVA: 0x00046E3A File Offset: 0x0004503A
		// (set) Token: 0x060011DF RID: 4575 RVA: 0x00046E42 File Offset: 0x00045042
		public double SoundVolume { get; set; }

		// Token: 0x060011E0 RID: 4576 RVA: 0x00046E4C File Offset: 0x0004504C
		protected AudioContext()
		{
			this.Volume = 1.0;
			this.MusicVolume = 0.3;
			this.SoundVolume = 1.0;
			this.Mixer = new BasicSampleMixer();
		}

		// Token: 0x060011E1 RID: 4577 RVA: 0x00006325 File Offset: 0x00004525
		public virtual void RegisterSampleProvider(ISampleProvider sampleProvider)
		{
		}

		// Token: 0x060011E2 RID: 4578 RVA: 0x00006325 File Offset: 0x00004525
		public virtual void UnregisterSampleProvider(ISampleProvider sampleProvider)
		{
		}

		// Token: 0x060011E3 RID: 4579 RVA: 0x00046EA2 File Offset: 0x000450A2
		public virtual void Update()
		{
			this._fireAndForgetSoundInstances.RemoveAll((SampleInstance x) => !x.Playing);
		}

		// Token: 0x060011E4 RID: 4580 RVA: 0x00046ED0 File Offset: 0x000450D0
		public void PlaySound(Sample sample)
		{
			SampleInstance sampleInstance = new SampleInstance(this, sample, null);
			sampleInstance.Play();
			this._fireAndForgetSoundInstances.Add(sampleInstance);
		}

		// Token: 0x060011E5 RID: 4581 RVA: 0x00046F00 File Offset: 0x00045100
		public void StopAll()
		{
			foreach (SampleInstance sampleInstance in this._fireAndForgetSoundInstances)
			{
				sampleInstance.Stop();
			}
		}

		// Token: 0x040009FE RID: 2558
		private readonly List<SampleInstance> _fireAndForgetSoundInstances = new List<SampleInstance>();
	}
}
