using System;

namespace SonicOrca.Audio
{
	// Token: 0x020001AB RID: 427
	public class WaveSampleGenerator : SampleGenerator
	{
		// Token: 0x170004ED RID: 1261
		// (get) Token: 0x0600125E RID: 4702 RVA: 0x00047F3B File Offset: 0x0004613B
		// (set) Token: 0x0600125F RID: 4703 RVA: 0x00047F43 File Offset: 0x00046143
		public WaveSampleGenerator.WaveFunction Function { get; set; }

		// Token: 0x170004EE RID: 1262
		// (get) Token: 0x06001260 RID: 4704 RVA: 0x00047F4C File Offset: 0x0004614C
		// (set) Token: 0x06001261 RID: 4705 RVA: 0x00047F54 File Offset: 0x00046154
		public double Amplitude { get; set; }

		// Token: 0x170004EF RID: 1263
		// (get) Token: 0x06001262 RID: 4706 RVA: 0x00047F5D File Offset: 0x0004615D
		// (set) Token: 0x06001263 RID: 4707 RVA: 0x00047F65 File Offset: 0x00046165
		public double Frequency { get; set; }

		// Token: 0x06001264 RID: 4708 RVA: 0x00047F6E File Offset: 0x0004616E
		public WaveSampleGenerator(AudioContext audioAdapter) : base(audioAdapter)
		{
			this.Function = WaveSampleGenerator.WaveFunction.Sine;
			this.Amplitude = 1.0;
			this.Frequency = 256.0;
		}

		// Token: 0x06001265 RID: 4709 RVA: 0x00047F9C File Offset: 0x0004619C
		protected override double GetNextSample()
		{
			this._angle = MathX.WrapRadians(this._angle + 0.00014247585730565955 * this.Frequency);
			switch (this.Function)
			{
			case WaveSampleGenerator.WaveFunction.Sine:
				return Math.Sin(this._angle) * this.Amplitude;
			case WaveSampleGenerator.WaveFunction.Square:
				return (double)Math.Sign(this._angle / 3.141592653589793) * this.Amplitude;
			case WaveSampleGenerator.WaveFunction.Triangle:
				return 2.0 * this.Amplitude / 3.141592653589793 * Math.Asin(Math.Sin(this._angle));
			case WaveSampleGenerator.WaveFunction.Sawtooth:
				return 2.0 * this.Amplitude / 3.141592653589793 * Math.Atan(Math.Cos(this._angle) / Math.Sin(this._angle));
			default:
				return 0.0;
			}
		}

		// Token: 0x04000A29 RID: 2601
		private double _angle;

		// Token: 0x02000281 RID: 641
		public enum WaveFunction
		{
			// Token: 0x04000D27 RID: 3367
			Sine,
			// Token: 0x04000D28 RID: 3368
			Square,
			// Token: 0x04000D29 RID: 3369
			Triangle,
			// Token: 0x04000D2A RID: 3370
			Sawtooth
		}
	}
}
