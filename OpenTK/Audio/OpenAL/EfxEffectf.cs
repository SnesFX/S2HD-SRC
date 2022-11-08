using System;

namespace OpenTK.Audio.OpenAL
{
	// Token: 0x02000569 RID: 1385
	public enum EfxEffectf
	{
		// Token: 0x04004F69 RID: 20329
		ReverbDensity = 1,
		// Token: 0x04004F6A RID: 20330
		ReverbDiffusion,
		// Token: 0x04004F6B RID: 20331
		ReverbGain,
		// Token: 0x04004F6C RID: 20332
		ReverbGainHF,
		// Token: 0x04004F6D RID: 20333
		ReverbDecayTime,
		// Token: 0x04004F6E RID: 20334
		ReverbDecayHFRatio,
		// Token: 0x04004F6F RID: 20335
		ReverbReflectionsGain,
		// Token: 0x04004F70 RID: 20336
		ReverbReflectionsDelay,
		// Token: 0x04004F71 RID: 20337
		ReverbLateReverbGain,
		// Token: 0x04004F72 RID: 20338
		ReverbLateReverbDelay,
		// Token: 0x04004F73 RID: 20339
		ReverbAirAbsorptionGainHF,
		// Token: 0x04004F74 RID: 20340
		ReverbRoomRolloffFactor,
		// Token: 0x04004F75 RID: 20341
		ChorusRate = 3,
		// Token: 0x04004F76 RID: 20342
		ChorusDepth,
		// Token: 0x04004F77 RID: 20343
		ChorusFeedback,
		// Token: 0x04004F78 RID: 20344
		ChorusDelay,
		// Token: 0x04004F79 RID: 20345
		DistortionEdge = 1,
		// Token: 0x04004F7A RID: 20346
		DistortionGain,
		// Token: 0x04004F7B RID: 20347
		DistortionLowpassCutoff,
		// Token: 0x04004F7C RID: 20348
		DistortionEQCenter,
		// Token: 0x04004F7D RID: 20349
		DistortionEQBandwidth,
		// Token: 0x04004F7E RID: 20350
		EchoDelay = 1,
		// Token: 0x04004F7F RID: 20351
		EchoLRDelay,
		// Token: 0x04004F80 RID: 20352
		EchoDamping,
		// Token: 0x04004F81 RID: 20353
		EchoFeedback,
		// Token: 0x04004F82 RID: 20354
		EchoSpread,
		// Token: 0x04004F83 RID: 20355
		FlangerRate = 3,
		// Token: 0x04004F84 RID: 20356
		FlangerDepth,
		// Token: 0x04004F85 RID: 20357
		FlangerFeedback,
		// Token: 0x04004F86 RID: 20358
		FlangerDelay,
		// Token: 0x04004F87 RID: 20359
		FrequencyShifterFrequency = 1,
		// Token: 0x04004F88 RID: 20360
		VocalMorpherRate = 6,
		// Token: 0x04004F89 RID: 20361
		RingModulatorFrequency = 1,
		// Token: 0x04004F8A RID: 20362
		RingModulatorHighpassCutoff,
		// Token: 0x04004F8B RID: 20363
		AutowahAttackTime = 1,
		// Token: 0x04004F8C RID: 20364
		AutowahReleaseTime,
		// Token: 0x04004F8D RID: 20365
		AutowahResonance,
		// Token: 0x04004F8E RID: 20366
		AutowahPeakGain,
		// Token: 0x04004F8F RID: 20367
		EqualizerLowGain = 1,
		// Token: 0x04004F90 RID: 20368
		EqualizerLowCutoff,
		// Token: 0x04004F91 RID: 20369
		EqualizerMid1Gain,
		// Token: 0x04004F92 RID: 20370
		EqualizerMid1Center,
		// Token: 0x04004F93 RID: 20371
		EqualizerMid1Width,
		// Token: 0x04004F94 RID: 20372
		EqualizerMid2Gain,
		// Token: 0x04004F95 RID: 20373
		EqualizerMid2Center,
		// Token: 0x04004F96 RID: 20374
		EqualizerMid2Width,
		// Token: 0x04004F97 RID: 20375
		EqualizerHighGain,
		// Token: 0x04004F98 RID: 20376
		EqualizerHighCutoff,
		// Token: 0x04004F99 RID: 20377
		EaxReverbDensity = 1,
		// Token: 0x04004F9A RID: 20378
		EaxReverbDiffusion,
		// Token: 0x04004F9B RID: 20379
		EaxReverbGain,
		// Token: 0x04004F9C RID: 20380
		EaxReverbGainHF,
		// Token: 0x04004F9D RID: 20381
		EaxReverbGainLF,
		// Token: 0x04004F9E RID: 20382
		EaxReverbDecayTime,
		// Token: 0x04004F9F RID: 20383
		EaxReverbDecayHFRatio,
		// Token: 0x04004FA0 RID: 20384
		EaxReverbDecayLFRatio,
		// Token: 0x04004FA1 RID: 20385
		EaxReverbReflectionsGain,
		// Token: 0x04004FA2 RID: 20386
		EaxReverbReflectionsDelay,
		// Token: 0x04004FA3 RID: 20387
		EaxReverbLateReverbGain = 12,
		// Token: 0x04004FA4 RID: 20388
		EaxReverbLateReverbDelay,
		// Token: 0x04004FA5 RID: 20389
		EaxReverbEchoTime = 15,
		// Token: 0x04004FA6 RID: 20390
		EaxReverbEchoDepth,
		// Token: 0x04004FA7 RID: 20391
		EaxReverbModulationTime,
		// Token: 0x04004FA8 RID: 20392
		EaxReverbModulationDepth,
		// Token: 0x04004FA9 RID: 20393
		EaxReverbAirAbsorptionGainHF,
		// Token: 0x04004FAA RID: 20394
		EaxReverbHFReference,
		// Token: 0x04004FAB RID: 20395
		EaxReverbLFReference,
		// Token: 0x04004FAC RID: 20396
		EaxReverbRoomRolloffFactor
	}
}
