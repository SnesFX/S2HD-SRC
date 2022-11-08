using System;
using System.Runtime.InteropServices;

namespace OpenTK.Audio.OpenAL
{
	// Token: 0x0200054E RID: 1358
	public class EffectsExtension
	{
		// Token: 0x0600445B RID: 17499 RVA: 0x000B9998 File Offset: 0x000B7B98
		[CLSCompliant(false)]
		public static void GetEaxFromEfxEax(ref EffectsExtension.EaxReverb input, out EffectsExtension.EfxEaxReverb output)
		{
			output.AirAbsorptionGainHF = 0.995f;
			output.RoomRolloffFactor = input.RoomRolloffFactor;
			output.Density = 1f;
			output.Diffusion = 1f;
			output.DecayTime = input.DecayTime;
			output.DecayHFLimit = 1;
			output.DecayHFRatio = input.DecayHFRatio;
			output.DecayLFRatio = input.DecayLFRatio;
			output.EchoDepth = input.EchoDepth;
			output.EchoTime = input.EchoTime;
			output.Gain = 0.32f;
			output.GainHF = 0.89f;
			output.GainLF = 1f;
			output.LFReference = input.LFReference;
			output.HFReference = input.HFReference;
			output.LateReverbDelay = input.ReverbDelay;
			output.LateReverbGain = 1.26f;
			output.LateReverbPan = input.ReverbPan;
			output.ModulationDepth = input.ModulationDepth;
			output.ModulationTime = input.ModulationTime;
			output.ReflectionsDelay = input.ReflectionsDelay;
			output.ReflectionsGain = 0.05f;
			output.ReflectionsPan = input.ReflectionsPan;
		}

		// Token: 0x0600445C RID: 17500 RVA: 0x000B9AAC File Offset: 0x000B7CAC
		[CLSCompliant(false)]
		public void BindEffect(uint eid, EfxEffectType type)
		{
			this.Imported_alEffecti(eid, EfxEffecti.EffectType, (int)type);
		}

		// Token: 0x0600445D RID: 17501 RVA: 0x000B9AC0 File Offset: 0x000B7CC0
		public void BindEffect(int eid, EfxEffectType type)
		{
			this.Imported_alEffecti((uint)eid, EfxEffecti.EffectType, (int)type);
		}

		// Token: 0x0600445E RID: 17502 RVA: 0x000B9AD4 File Offset: 0x000B7CD4
		[CLSCompliant(false)]
		public void BindFilterToSource(uint source, uint filter)
		{
			AL.Source(source, ALSourcei.EfxDirectFilter, (int)filter);
		}

		// Token: 0x0600445F RID: 17503 RVA: 0x000B9AE4 File Offset: 0x000B7CE4
		public void BindFilterToSource(int source, int filter)
		{
			AL.Source((uint)source, ALSourcei.EfxDirectFilter, filter);
		}

		// Token: 0x06004460 RID: 17504 RVA: 0x000B9AF4 File Offset: 0x000B7CF4
		[CLSCompliant(false)]
		public void BindEffectToAuxiliarySlot(uint auxiliaryeffectslot, uint effect)
		{
			this.AuxiliaryEffectSlot(auxiliaryeffectslot, EfxAuxiliaryi.EffectslotEffect, (int)effect);
		}

		// Token: 0x06004461 RID: 17505 RVA: 0x000B9B00 File Offset: 0x000B7D00
		public void BindEffectToAuxiliarySlot(int auxiliaryeffectslot, int effect)
		{
			this.AuxiliaryEffectSlot((uint)auxiliaryeffectslot, EfxAuxiliaryi.EffectslotEffect, effect);
		}

		// Token: 0x06004462 RID: 17506 RVA: 0x000B9B0C File Offset: 0x000B7D0C
		[CLSCompliant(false)]
		public void BindSourceToAuxiliarySlot(uint source, uint slot, int slotnumber, uint filter)
		{
			AL.Source(source, ALSource3i.EfxAuxiliarySendFilter, (int)slot, slotnumber, (int)filter);
		}

		// Token: 0x06004463 RID: 17507 RVA: 0x000B9B20 File Offset: 0x000B7D20
		public void BindSourceToAuxiliarySlot(int source, int slot, int slotnumber, int filter)
		{
			AL.Source((uint)source, ALSource3i.EfxAuxiliarySendFilter, slot, slotnumber, filter);
		}

		// Token: 0x06004464 RID: 17508 RVA: 0x000B9B34 File Offset: 0x000B7D34
		[CLSCompliant(false)]
		public unsafe void GenEffects(int n, out uint effects)
		{
			fixed (uint* ptr = &effects)
			{
				this.Imported_alGenEffects(n, ptr);
				effects = *ptr;
			}
		}

		// Token: 0x06004465 RID: 17509 RVA: 0x000B9B5C File Offset: 0x000B7D5C
		public unsafe void GenEffects(int n, out int effects)
		{
			fixed (int* ptr = &effects)
			{
				this.Imported_alGenEffects(n, (uint*)ptr);
				effects = *ptr;
			}
		}

		// Token: 0x06004466 RID: 17510 RVA: 0x000B9B84 File Offset: 0x000B7D84
		public int[] GenEffects(int n)
		{
			if (n <= 0)
			{
				throw new ArgumentOutOfRangeException("n", "Must be higher than 0.");
			}
			int[] array = new int[n];
			this.GenEffects(n, out array[0]);
			return array;
		}

		// Token: 0x06004467 RID: 17511 RVA: 0x000B9BBC File Offset: 0x000B7DBC
		public int GenEffect()
		{
			int result;
			this.GenEffects(1, out result);
			return result;
		}

		// Token: 0x06004468 RID: 17512 RVA: 0x000B9BD4 File Offset: 0x000B7DD4
		[CLSCompliant(false)]
		public unsafe void GenEffect(out uint effect)
		{
			fixed (uint* ptr = &effect)
			{
				this.Imported_alGenEffects(1, ptr);
				effect = *ptr;
			}
		}

		// Token: 0x06004469 RID: 17513 RVA: 0x000B9BFC File Offset: 0x000B7DFC
		[CLSCompliant(false)]
		public unsafe void DeleteEffects(int n, ref uint effects)
		{
			fixed (uint* ptr = &effects)
			{
				this.Imported_alDeleteEffects(n, ptr);
			}
		}

		// Token: 0x0600446A RID: 17514 RVA: 0x000B9C1C File Offset: 0x000B7E1C
		public unsafe void DeleteEffects(int n, ref int effects)
		{
			fixed (int* ptr = &effects)
			{
				this.Imported_alDeleteEffects(n, (uint*)ptr);
			}
		}

		// Token: 0x0600446B RID: 17515 RVA: 0x000B9C3C File Offset: 0x000B7E3C
		public void DeleteEffects(int[] effects)
		{
			if (effects == null)
			{
				throw new ArgumentNullException("effects");
			}
			this.DeleteEffects(effects.Length, ref effects[0]);
		}

		// Token: 0x0600446C RID: 17516 RVA: 0x000B9C5C File Offset: 0x000B7E5C
		[CLSCompliant(false)]
		public void DeleteEffects(uint[] effects)
		{
			if (effects == null)
			{
				throw new ArgumentNullException("effects");
			}
			this.DeleteEffects(effects.Length, ref effects[0]);
		}

		// Token: 0x0600446D RID: 17517 RVA: 0x000B9C7C File Offset: 0x000B7E7C
		public void DeleteEffect(int effect)
		{
			this.DeleteEffects(1, ref effect);
		}

		// Token: 0x0600446E RID: 17518 RVA: 0x000B9C88 File Offset: 0x000B7E88
		[CLSCompliant(false)]
		public unsafe void DeleteEffect(ref uint effect)
		{
			fixed (uint* ptr = &effect)
			{
				this.Imported_alDeleteEffects(1, ptr);
			}
		}

		// Token: 0x0600446F RID: 17519 RVA: 0x000B9CA8 File Offset: 0x000B7EA8
		[CLSCompliant(false)]
		public bool IsEffect(uint eid)
		{
			return this.Imported_alIsEffect(eid);
		}

		// Token: 0x06004470 RID: 17520 RVA: 0x000B9CB8 File Offset: 0x000B7EB8
		public bool IsEffect(int eid)
		{
			return this.Imported_alIsEffect((uint)eid);
		}

		// Token: 0x06004471 RID: 17521 RVA: 0x000B9CC8 File Offset: 0x000B7EC8
		[CLSCompliant(false)]
		public void Effect(uint eid, EfxEffecti param, int value)
		{
			this.Imported_alEffecti(eid, param, value);
		}

		// Token: 0x06004472 RID: 17522 RVA: 0x000B9CD8 File Offset: 0x000B7ED8
		public void Effect(int eid, EfxEffecti param, int value)
		{
			this.Imported_alEffecti((uint)eid, param, value);
		}

		// Token: 0x06004473 RID: 17523 RVA: 0x000B9CE8 File Offset: 0x000B7EE8
		[CLSCompliant(false)]
		public void Effect(uint eid, EfxEffectf param, float value)
		{
			this.Imported_alEffectf(eid, param, value);
		}

		// Token: 0x06004474 RID: 17524 RVA: 0x000B9CF8 File Offset: 0x000B7EF8
		public void Effect(int eid, EfxEffectf param, float value)
		{
			this.Imported_alEffectf((uint)eid, param, value);
		}

		// Token: 0x06004475 RID: 17525 RVA: 0x000B9D08 File Offset: 0x000B7F08
		[CLSCompliant(false)]
		public unsafe void Effect(uint eid, EfxEffect3f param, ref Vector3 values)
		{
			fixed (float* ptr = &values.X)
			{
				this.Imported_alEffectfv(eid, param, ptr);
			}
		}

		// Token: 0x06004476 RID: 17526 RVA: 0x000B9D30 File Offset: 0x000B7F30
		public void Effect(int eid, EfxEffect3f param, ref Vector3 values)
		{
			this.Effect((uint)eid, param, ref values);
		}

		// Token: 0x06004477 RID: 17527 RVA: 0x000B9D3C File Offset: 0x000B7F3C
		[CLSCompliant(false)]
		public unsafe void GetEffect(uint eid, EfxEffecti pname, out int value)
		{
			fixed (int* ptr = &value)
			{
				this.Imported_alGetEffecti(eid, pname, ptr);
			}
		}

		// Token: 0x06004478 RID: 17528 RVA: 0x000B9D60 File Offset: 0x000B7F60
		public void GetEffect(int eid, EfxEffecti pname, out int value)
		{
			this.GetEffect((uint)eid, pname, out value);
		}

		// Token: 0x06004479 RID: 17529 RVA: 0x000B9D6C File Offset: 0x000B7F6C
		[CLSCompliant(false)]
		public unsafe void GetEffect(uint eid, EfxEffectf pname, out float value)
		{
			fixed (float* ptr = &value)
			{
				this.Imported_alGetEffectf(eid, pname, ptr);
			}
		}

		// Token: 0x0600447A RID: 17530 RVA: 0x000B9D90 File Offset: 0x000B7F90
		public void GetEffect(int eid, EfxEffectf pname, out float value)
		{
			this.GetEffect((uint)eid, pname, out value);
		}

		// Token: 0x0600447B RID: 17531 RVA: 0x000B9D9C File Offset: 0x000B7F9C
		[CLSCompliant(false)]
		public unsafe void GetEffect(uint eid, EfxEffect3f param, out Vector3 values)
		{
			fixed (float* ptr = &values.X)
			{
				this.Imported_alGetEffectfv(eid, param, ptr);
				values.X = *ptr;
				values.Y = ptr[1];
				values.Z = ptr[2];
			}
		}

		// Token: 0x0600447C RID: 17532 RVA: 0x000B9DE4 File Offset: 0x000B7FE4
		public void GetEffect(int eid, EfxEffect3f param, out Vector3 values)
		{
			this.GetEffect((uint)eid, param, out values);
		}

		// Token: 0x0600447D RID: 17533 RVA: 0x000B9DF0 File Offset: 0x000B7FF0
		[CLSCompliant(false)]
		public unsafe void GenFilters(int n, out uint filters)
		{
			fixed (uint* ptr = &filters)
			{
				this.Imported_alGenFilters(n, ptr);
				filters = *ptr;
			}
		}

		// Token: 0x0600447E RID: 17534 RVA: 0x000B9E18 File Offset: 0x000B8018
		public unsafe void GenFilters(int n, out int filters)
		{
			fixed (int* ptr = &filters)
			{
				this.Imported_alGenFilters(n, (uint*)ptr);
				filters = *ptr;
			}
		}

		// Token: 0x0600447F RID: 17535 RVA: 0x000B9E40 File Offset: 0x000B8040
		public int[] GenFilters(int n)
		{
			if (n <= 0)
			{
				throw new ArgumentOutOfRangeException("n", "Must be higher than 0.");
			}
			int[] array = new int[n];
			this.GenFilters(array.Length, out array[0]);
			return array;
		}

		// Token: 0x06004480 RID: 17536 RVA: 0x000B9E7C File Offset: 0x000B807C
		public int GenFilter()
		{
			int result;
			this.GenFilters(1, out result);
			return result;
		}

		// Token: 0x06004481 RID: 17537 RVA: 0x000B9E94 File Offset: 0x000B8094
		[CLSCompliant(false)]
		public unsafe void GenFilter(out uint filter)
		{
			fixed (uint* ptr = &filter)
			{
				this.Imported_alGenFilters(1, ptr);
				filter = *ptr;
			}
		}

		// Token: 0x06004482 RID: 17538 RVA: 0x000B9EBC File Offset: 0x000B80BC
		[CLSCompliant(false)]
		public unsafe void DeleteFilters(int n, ref uint filters)
		{
			fixed (uint* ptr = &filters)
			{
				this.Imported_alDeleteFilters(n, ptr);
			}
		}

		// Token: 0x06004483 RID: 17539 RVA: 0x000B9EDC File Offset: 0x000B80DC
		public unsafe void DeleteFilters(int n, ref int filters)
		{
			fixed (int* ptr = &filters)
			{
				this.Imported_alDeleteFilters(n, (uint*)ptr);
			}
		}

		// Token: 0x06004484 RID: 17540 RVA: 0x000B9EFC File Offset: 0x000B80FC
		[CLSCompliant(false)]
		public void DeleteFilters(uint[] filters)
		{
			if (filters == null)
			{
				throw new ArgumentNullException("filters");
			}
			this.DeleteFilters(filters.Length, ref filters[0]);
		}

		// Token: 0x06004485 RID: 17541 RVA: 0x000B9F1C File Offset: 0x000B811C
		public void DeleteFilters(int[] filters)
		{
			if (filters == null)
			{
				throw new ArgumentNullException("filters");
			}
			this.DeleteFilters(filters.Length, ref filters[0]);
		}

		// Token: 0x06004486 RID: 17542 RVA: 0x000B9F3C File Offset: 0x000B813C
		public void DeleteFilter(int filter)
		{
			this.DeleteFilters(1, ref filter);
		}

		// Token: 0x06004487 RID: 17543 RVA: 0x000B9F48 File Offset: 0x000B8148
		[CLSCompliant(false)]
		public unsafe void DeleteFilter(ref uint filter)
		{
			fixed (uint* ptr = &filter)
			{
				this.Imported_alDeleteFilters(1, ptr);
			}
		}

		// Token: 0x06004488 RID: 17544 RVA: 0x000B9F68 File Offset: 0x000B8168
		[CLSCompliant(false)]
		public bool IsFilter(uint fid)
		{
			return this.Imported_alIsFilter(fid);
		}

		// Token: 0x06004489 RID: 17545 RVA: 0x000B9F78 File Offset: 0x000B8178
		public bool IsFilter(int fid)
		{
			return this.Imported_alIsFilter((uint)fid);
		}

		// Token: 0x0600448A RID: 17546 RVA: 0x000B9F88 File Offset: 0x000B8188
		[CLSCompliant(false)]
		public void Filter(uint fid, EfxFilteri param, int value)
		{
			this.Imported_alFilteri(fid, param, value);
		}

		// Token: 0x0600448B RID: 17547 RVA: 0x000B9F98 File Offset: 0x000B8198
		public void Filter(int fid, EfxFilteri param, int value)
		{
			this.Imported_alFilteri((uint)fid, param, value);
		}

		// Token: 0x0600448C RID: 17548 RVA: 0x000B9FA8 File Offset: 0x000B81A8
		[CLSCompliant(false)]
		public void Filter(uint fid, EfxFilterf param, float value)
		{
			this.Imported_alFilterf(fid, param, value);
		}

		// Token: 0x0600448D RID: 17549 RVA: 0x000B9FB8 File Offset: 0x000B81B8
		public void Filter(int fid, EfxFilterf param, float value)
		{
			this.Imported_alFilterf((uint)fid, param, value);
		}

		// Token: 0x0600448E RID: 17550 RVA: 0x000B9FC8 File Offset: 0x000B81C8
		[CLSCompliant(false)]
		public unsafe void GetFilter(uint fid, EfxFilteri pname, out int value)
		{
			fixed (int* ptr = &value)
			{
				this.Imported_alGetFilteri(fid, pname, ptr);
			}
		}

		// Token: 0x0600448F RID: 17551 RVA: 0x000B9FEC File Offset: 0x000B81EC
		public void GetFilter(int fid, EfxFilteri pname, out int value)
		{
			this.GetFilter((uint)fid, pname, out value);
		}

		// Token: 0x06004490 RID: 17552 RVA: 0x000B9FF8 File Offset: 0x000B81F8
		[CLSCompliant(false)]
		public unsafe void GetFilter(uint fid, EfxFilterf pname, out float value)
		{
			fixed (float* ptr = &value)
			{
				this.Imported_alGetFilterf(fid, pname, ptr);
			}
		}

		// Token: 0x06004491 RID: 17553 RVA: 0x000BA01C File Offset: 0x000B821C
		public void GetFilter(int fid, EfxFilterf pname, out float value)
		{
			this.GetFilter((uint)fid, pname, out value);
		}

		// Token: 0x06004492 RID: 17554 RVA: 0x000BA028 File Offset: 0x000B8228
		[CLSCompliant(false)]
		public unsafe void GenAuxiliaryEffectSlots(int n, out uint slots)
		{
			fixed (uint* ptr = &slots)
			{
				this.Imported_alGenAuxiliaryEffectSlots(n, ptr);
				slots = *ptr;
			}
		}

		// Token: 0x06004493 RID: 17555 RVA: 0x000BA050 File Offset: 0x000B8250
		public unsafe void GenAuxiliaryEffectSlots(int n, out int slots)
		{
			fixed (int* ptr = &slots)
			{
				this.Imported_alGenAuxiliaryEffectSlots(n, (uint*)ptr);
				slots = *ptr;
			}
		}

		// Token: 0x06004494 RID: 17556 RVA: 0x000BA078 File Offset: 0x000B8278
		public int[] GenAuxiliaryEffectSlots(int n)
		{
			if (n <= 0)
			{
				throw new ArgumentOutOfRangeException("n", "Must be higher than 0.");
			}
			int[] array = new int[n];
			this.GenAuxiliaryEffectSlots(array.Length, out array[0]);
			return array;
		}

		// Token: 0x06004495 RID: 17557 RVA: 0x000BA0B4 File Offset: 0x000B82B4
		public int GenAuxiliaryEffectSlot()
		{
			int result;
			this.GenAuxiliaryEffectSlots(1, out result);
			return result;
		}

		// Token: 0x06004496 RID: 17558 RVA: 0x000BA0CC File Offset: 0x000B82CC
		[CLSCompliant(false)]
		public unsafe void GenAuxiliaryEffectSlot(out uint slot)
		{
			fixed (uint* ptr = &slot)
			{
				this.Imported_alGenAuxiliaryEffectSlots(1, ptr);
				slot = *ptr;
			}
		}

		// Token: 0x06004497 RID: 17559 RVA: 0x000BA0F4 File Offset: 0x000B82F4
		[CLSCompliant(false)]
		public unsafe void DeleteAuxiliaryEffectSlots(int n, ref uint slots)
		{
			fixed (uint* ptr = &slots)
			{
				this.Imported_alDeleteAuxiliaryEffectSlots(n, ptr);
			}
		}

		// Token: 0x06004498 RID: 17560 RVA: 0x000BA114 File Offset: 0x000B8314
		public unsafe void DeleteAuxiliaryEffectSlots(int n, ref int slots)
		{
			fixed (int* ptr = &slots)
			{
				this.Imported_alDeleteAuxiliaryEffectSlots(n, (uint*)ptr);
			}
		}

		// Token: 0x06004499 RID: 17561 RVA: 0x000BA134 File Offset: 0x000B8334
		public void DeleteAuxiliaryEffectSlots(int[] slots)
		{
			if (slots == null)
			{
				throw new ArgumentNullException("slots");
			}
			this.DeleteAuxiliaryEffectSlots(slots.Length, ref slots[0]);
		}

		// Token: 0x0600449A RID: 17562 RVA: 0x000BA154 File Offset: 0x000B8354
		[CLSCompliant(false)]
		public void DeleteAuxiliaryEffectSlots(uint[] slots)
		{
			if (slots == null)
			{
				throw new ArgumentNullException("slots");
			}
			this.DeleteAuxiliaryEffectSlots(slots.Length, ref slots[0]);
		}

		// Token: 0x0600449B RID: 17563 RVA: 0x000BA174 File Offset: 0x000B8374
		public void DeleteAuxiliaryEffectSlot(int slot)
		{
			this.DeleteAuxiliaryEffectSlots(1, ref slot);
		}

		// Token: 0x0600449C RID: 17564 RVA: 0x000BA180 File Offset: 0x000B8380
		[CLSCompliant(false)]
		public unsafe void DeleteAuxiliaryEffectSlot(ref uint slot)
		{
			fixed (uint* ptr = &slot)
			{
				this.Imported_alDeleteAuxiliaryEffectSlots(1, ptr);
			}
		}

		// Token: 0x0600449D RID: 17565 RVA: 0x000BA1A0 File Offset: 0x000B83A0
		[CLSCompliant(false)]
		public bool IsAuxiliaryEffectSlot(uint slot)
		{
			return this.Imported_alIsAuxiliaryEffectSlot(slot);
		}

		// Token: 0x0600449E RID: 17566 RVA: 0x000BA1B0 File Offset: 0x000B83B0
		public bool IsAuxiliaryEffectSlot(int slot)
		{
			return this.Imported_alIsAuxiliaryEffectSlot((uint)slot);
		}

		// Token: 0x0600449F RID: 17567 RVA: 0x000BA1C0 File Offset: 0x000B83C0
		[CLSCompliant(false)]
		public void AuxiliaryEffectSlot(uint asid, EfxAuxiliaryi param, int value)
		{
			this.Imported_alAuxiliaryEffectSloti(asid, param, value);
		}

		// Token: 0x060044A0 RID: 17568 RVA: 0x000BA1D0 File Offset: 0x000B83D0
		public void AuxiliaryEffectSlot(int asid, EfxAuxiliaryi param, int value)
		{
			this.Imported_alAuxiliaryEffectSloti((uint)asid, param, value);
		}

		// Token: 0x060044A1 RID: 17569 RVA: 0x000BA1E0 File Offset: 0x000B83E0
		[CLSCompliant(false)]
		public void AuxiliaryEffectSlot(uint asid, EfxAuxiliaryf param, float value)
		{
			this.Imported_alAuxiliaryEffectSlotf(asid, param, value);
		}

		// Token: 0x060044A2 RID: 17570 RVA: 0x000BA1F0 File Offset: 0x000B83F0
		public void AuxiliaryEffectSlot(int asid, EfxAuxiliaryf param, float value)
		{
			this.Imported_alAuxiliaryEffectSlotf((uint)asid, param, value);
		}

		// Token: 0x060044A3 RID: 17571 RVA: 0x000BA200 File Offset: 0x000B8400
		[CLSCompliant(false)]
		public unsafe void GetAuxiliaryEffectSlot(uint asid, EfxAuxiliaryi pname, out int value)
		{
			fixed (int* ptr = &value)
			{
				this.Imported_alGetAuxiliaryEffectSloti(asid, pname, ptr);
			}
		}

		// Token: 0x060044A4 RID: 17572 RVA: 0x000BA224 File Offset: 0x000B8424
		public void GetAuxiliaryEffectSlot(int asid, EfxAuxiliaryi pname, out int value)
		{
			this.GetAuxiliaryEffectSlot((uint)asid, pname, out value);
		}

		// Token: 0x060044A5 RID: 17573 RVA: 0x000BA230 File Offset: 0x000B8430
		[CLSCompliant(false)]
		public unsafe void GetAuxiliaryEffectSlot(uint asid, EfxAuxiliaryf pname, out float value)
		{
			fixed (float* ptr = &value)
			{
				this.Imported_alGetAuxiliaryEffectSlotf(asid, pname, ptr);
			}
		}

		// Token: 0x060044A6 RID: 17574 RVA: 0x000BA254 File Offset: 0x000B8454
		public void GetAuxiliaryEffectSlot(int asid, EfxAuxiliaryf pname, out float value)
		{
			this.GetAuxiliaryEffectSlot((uint)asid, pname, out value);
		}

		// Token: 0x17000425 RID: 1061
		// (get) Token: 0x060044A7 RID: 17575 RVA: 0x000BA260 File Offset: 0x000B8460
		public bool IsInitialized
		{
			get
			{
				return this._valid;
			}
		}

		// Token: 0x060044A8 RID: 17576 RVA: 0x000BA268 File Offset: 0x000B8468
		public EffectsExtension()
		{
			this._valid = false;
			if (AudioContext.CurrentContext == null)
			{
				throw new InvalidOperationException("AL.LoadAll() needs a current AudioContext.");
			}
			if (!AudioContext.CurrentContext.SupportsExtension("ALC_EXT_EFX"))
			{
				return;
			}
			try
			{
				this.Imported_alGenEffects = (EffectsExtension.Delegate_alGenEffects)Marshal.GetDelegateForFunctionPointer(AL.GetProcAddress("alGenEffects"), typeof(EffectsExtension.Delegate_alGenEffects));
				this.Imported_alDeleteEffects = (EffectsExtension.Delegate_alDeleteEffects)Marshal.GetDelegateForFunctionPointer(AL.GetProcAddress("alDeleteEffects"), typeof(EffectsExtension.Delegate_alDeleteEffects));
				this.Imported_alIsEffect = (EffectsExtension.Delegate_alIsEffect)Marshal.GetDelegateForFunctionPointer(AL.GetProcAddress("alIsEffect"), typeof(EffectsExtension.Delegate_alIsEffect));
				this.Imported_alEffecti = (EffectsExtension.Delegate_alEffecti)Marshal.GetDelegateForFunctionPointer(AL.GetProcAddress("alEffecti"), typeof(EffectsExtension.Delegate_alEffecti));
				this.Imported_alEffectf = (EffectsExtension.Delegate_alEffectf)Marshal.GetDelegateForFunctionPointer(AL.GetProcAddress("alEffectf"), typeof(EffectsExtension.Delegate_alEffectf));
				this.Imported_alEffectfv = (EffectsExtension.Delegate_alEffectfv)Marshal.GetDelegateForFunctionPointer(AL.GetProcAddress("alEffectfv"), typeof(EffectsExtension.Delegate_alEffectfv));
				this.Imported_alGetEffecti = (EffectsExtension.Delegate_alGetEffecti)Marshal.GetDelegateForFunctionPointer(AL.GetProcAddress("alGetEffecti"), typeof(EffectsExtension.Delegate_alGetEffecti));
				this.Imported_alGetEffectf = (EffectsExtension.Delegate_alGetEffectf)Marshal.GetDelegateForFunctionPointer(AL.GetProcAddress("alGetEffectf"), typeof(EffectsExtension.Delegate_alGetEffectf));
				this.Imported_alGetEffectfv = (EffectsExtension.Delegate_alGetEffectfv)Marshal.GetDelegateForFunctionPointer(AL.GetProcAddress("alGetEffectfv"), typeof(EffectsExtension.Delegate_alGetEffectfv));
			}
			catch (Exception)
			{
				return;
			}
			try
			{
				this.Imported_alGenFilters = (EffectsExtension.Delegate_alGenFilters)Marshal.GetDelegateForFunctionPointer(AL.GetProcAddress("alGenFilters"), typeof(EffectsExtension.Delegate_alGenFilters));
				this.Imported_alDeleteFilters = (EffectsExtension.Delegate_alDeleteFilters)Marshal.GetDelegateForFunctionPointer(AL.GetProcAddress("alDeleteFilters"), typeof(EffectsExtension.Delegate_alDeleteFilters));
				this.Imported_alIsFilter = (EffectsExtension.Delegate_alIsFilter)Marshal.GetDelegateForFunctionPointer(AL.GetProcAddress("alIsFilter"), typeof(EffectsExtension.Delegate_alIsFilter));
				this.Imported_alFilteri = (EffectsExtension.Delegate_alFilteri)Marshal.GetDelegateForFunctionPointer(AL.GetProcAddress("alFilteri"), typeof(EffectsExtension.Delegate_alFilteri));
				this.Imported_alFilterf = (EffectsExtension.Delegate_alFilterf)Marshal.GetDelegateForFunctionPointer(AL.GetProcAddress("alFilterf"), typeof(EffectsExtension.Delegate_alFilterf));
				this.Imported_alGetFilteri = (EffectsExtension.Delegate_alGetFilteri)Marshal.GetDelegateForFunctionPointer(AL.GetProcAddress("alGetFilteri"), typeof(EffectsExtension.Delegate_alGetFilteri));
				this.Imported_alGetFilterf = (EffectsExtension.Delegate_alGetFilterf)Marshal.GetDelegateForFunctionPointer(AL.GetProcAddress("alGetFilterf"), typeof(EffectsExtension.Delegate_alGetFilterf));
			}
			catch (Exception)
			{
				return;
			}
			try
			{
				this.Imported_alGenAuxiliaryEffectSlots = (EffectsExtension.Delegate_alGenAuxiliaryEffectSlots)Marshal.GetDelegateForFunctionPointer(AL.GetProcAddress("alGenAuxiliaryEffectSlots"), typeof(EffectsExtension.Delegate_alGenAuxiliaryEffectSlots));
				this.Imported_alDeleteAuxiliaryEffectSlots = (EffectsExtension.Delegate_alDeleteAuxiliaryEffectSlots)Marshal.GetDelegateForFunctionPointer(AL.GetProcAddress("alDeleteAuxiliaryEffectSlots"), typeof(EffectsExtension.Delegate_alDeleteAuxiliaryEffectSlots));
				this.Imported_alIsAuxiliaryEffectSlot = (EffectsExtension.Delegate_alIsAuxiliaryEffectSlot)Marshal.GetDelegateForFunctionPointer(AL.GetProcAddress("alIsAuxiliaryEffectSlot"), typeof(EffectsExtension.Delegate_alIsAuxiliaryEffectSlot));
				this.Imported_alAuxiliaryEffectSloti = (EffectsExtension.Delegate_alAuxiliaryEffectSloti)Marshal.GetDelegateForFunctionPointer(AL.GetProcAddress("alAuxiliaryEffectSloti"), typeof(EffectsExtension.Delegate_alAuxiliaryEffectSloti));
				this.Imported_alAuxiliaryEffectSlotf = (EffectsExtension.Delegate_alAuxiliaryEffectSlotf)Marshal.GetDelegateForFunctionPointer(AL.GetProcAddress("alAuxiliaryEffectSlotf"), typeof(EffectsExtension.Delegate_alAuxiliaryEffectSlotf));
				this.Imported_alGetAuxiliaryEffectSloti = (EffectsExtension.Delegate_alGetAuxiliaryEffectSloti)Marshal.GetDelegateForFunctionPointer(AL.GetProcAddress("alGetAuxiliaryEffectSloti"), typeof(EffectsExtension.Delegate_alGetAuxiliaryEffectSloti));
				this.Imported_alGetAuxiliaryEffectSlotf = (EffectsExtension.Delegate_alGetAuxiliaryEffectSlotf)Marshal.GetDelegateForFunctionPointer(AL.GetProcAddress("alGetAuxiliaryEffectSlotf"), typeof(EffectsExtension.Delegate_alGetAuxiliaryEffectSlotf));
			}
			catch (Exception)
			{
				return;
			}
			this._valid = true;
		}

		// Token: 0x04004EB0 RID: 20144
		private EffectsExtension.Delegate_alGenEffects Imported_alGenEffects;

		// Token: 0x04004EB1 RID: 20145
		private EffectsExtension.Delegate_alDeleteEffects Imported_alDeleteEffects;

		// Token: 0x04004EB2 RID: 20146
		private EffectsExtension.Delegate_alIsEffect Imported_alIsEffect;

		// Token: 0x04004EB3 RID: 20147
		private EffectsExtension.Delegate_alEffecti Imported_alEffecti;

		// Token: 0x04004EB4 RID: 20148
		private EffectsExtension.Delegate_alEffectf Imported_alEffectf;

		// Token: 0x04004EB5 RID: 20149
		private EffectsExtension.Delegate_alEffectfv Imported_alEffectfv;

		// Token: 0x04004EB6 RID: 20150
		private EffectsExtension.Delegate_alGetEffecti Imported_alGetEffecti;

		// Token: 0x04004EB7 RID: 20151
		private EffectsExtension.Delegate_alGetEffectf Imported_alGetEffectf;

		// Token: 0x04004EB8 RID: 20152
		private EffectsExtension.Delegate_alGetEffectfv Imported_alGetEffectfv;

		// Token: 0x04004EB9 RID: 20153
		private EffectsExtension.Delegate_alGenFilters Imported_alGenFilters;

		// Token: 0x04004EBA RID: 20154
		private EffectsExtension.Delegate_alDeleteFilters Imported_alDeleteFilters;

		// Token: 0x04004EBB RID: 20155
		private EffectsExtension.Delegate_alIsFilter Imported_alIsFilter;

		// Token: 0x04004EBC RID: 20156
		private EffectsExtension.Delegate_alFilteri Imported_alFilteri;

		// Token: 0x04004EBD RID: 20157
		private EffectsExtension.Delegate_alFilterf Imported_alFilterf;

		// Token: 0x04004EBE RID: 20158
		private EffectsExtension.Delegate_alGetFilteri Imported_alGetFilteri;

		// Token: 0x04004EBF RID: 20159
		private EffectsExtension.Delegate_alGetFilterf Imported_alGetFilterf;

		// Token: 0x04004EC0 RID: 20160
		private EffectsExtension.Delegate_alGenAuxiliaryEffectSlots Imported_alGenAuxiliaryEffectSlots;

		// Token: 0x04004EC1 RID: 20161
		private EffectsExtension.Delegate_alDeleteAuxiliaryEffectSlots Imported_alDeleteAuxiliaryEffectSlots;

		// Token: 0x04004EC2 RID: 20162
		private EffectsExtension.Delegate_alIsAuxiliaryEffectSlot Imported_alIsAuxiliaryEffectSlot;

		// Token: 0x04004EC3 RID: 20163
		private EffectsExtension.Delegate_alAuxiliaryEffectSloti Imported_alAuxiliaryEffectSloti;

		// Token: 0x04004EC4 RID: 20164
		private EffectsExtension.Delegate_alAuxiliaryEffectSlotf Imported_alAuxiliaryEffectSlotf;

		// Token: 0x04004EC5 RID: 20165
		private EffectsExtension.Delegate_alGetAuxiliaryEffectSloti Imported_alGetAuxiliaryEffectSloti;

		// Token: 0x04004EC6 RID: 20166
		private EffectsExtension.Delegate_alGetAuxiliaryEffectSlotf Imported_alGetAuxiliaryEffectSlotf;

		// Token: 0x04004EC7 RID: 20167
		private bool _valid;

		// Token: 0x0200054F RID: 1359
		[CLSCompliant(false)]
		public struct EaxReverb
		{
			// Token: 0x060044A9 RID: 17577 RVA: 0x000BA64C File Offset: 0x000B884C
			public EaxReverb(uint environment, float environmentSize, float environmentDiffusion, int room, int roomHF, int roomLF, float decayTime, float decayHFRatio, float decayLFRatio, int reflections, float reflectionsDelay, float reflectionsPanX, float reflectionsPanY, float reflectionsPanZ, int reverb, float reverbDelay, float reverbPanX, float reverbPanY, float reverbPanZ, float echoTime, float echoDepth, float modulationTime, float modulationDepth, float airAbsorptionHF, float hfReference, float lfReference, float roomRolloffFactor, uint flags)
			{
				this.Environment = environment;
				this.EnvironmentSize = environmentSize;
				this.EnvironmentDiffusion = environmentDiffusion;
				this.Room = room;
				this.RoomHF = roomHF;
				this.RoomLF = roomLF;
				this.DecayTime = decayTime;
				this.DecayHFRatio = decayHFRatio;
				this.DecayLFRatio = decayLFRatio;
				this.Reflections = reflections;
				this.ReflectionsDelay = reflectionsDelay;
				this.ReflectionsPan = new Vector3(reflectionsPanX, reflectionsPanY, reflectionsPanZ);
				this.Reverb = reverb;
				this.ReverbDelay = reverbDelay;
				this.ReverbPan = new Vector3(reverbPanX, reverbPanY, reverbPanZ);
				this.EchoTime = echoTime;
				this.EchoDepth = echoDepth;
				this.ModulationTime = modulationTime;
				this.ModulationDepth = modulationDepth;
				this.AirAbsorptionHF = airAbsorptionHF;
				this.HFReference = hfReference;
				this.LFReference = lfReference;
				this.RoomRolloffFactor = roomRolloffFactor;
				this.Flags = flags;
			}

			// Token: 0x04004EC8 RID: 20168
			public uint Environment;

			// Token: 0x04004EC9 RID: 20169
			public float EnvironmentSize;

			// Token: 0x04004ECA RID: 20170
			public float EnvironmentDiffusion;

			// Token: 0x04004ECB RID: 20171
			public int Room;

			// Token: 0x04004ECC RID: 20172
			public int RoomHF;

			// Token: 0x04004ECD RID: 20173
			public int RoomLF;

			// Token: 0x04004ECE RID: 20174
			public float DecayTime;

			// Token: 0x04004ECF RID: 20175
			public float DecayHFRatio;

			// Token: 0x04004ED0 RID: 20176
			public float DecayLFRatio;

			// Token: 0x04004ED1 RID: 20177
			public int Reflections;

			// Token: 0x04004ED2 RID: 20178
			public float ReflectionsDelay;

			// Token: 0x04004ED3 RID: 20179
			public Vector3 ReflectionsPan;

			// Token: 0x04004ED4 RID: 20180
			public int Reverb;

			// Token: 0x04004ED5 RID: 20181
			public float ReverbDelay;

			// Token: 0x04004ED6 RID: 20182
			public Vector3 ReverbPan;

			// Token: 0x04004ED7 RID: 20183
			public float EchoTime;

			// Token: 0x04004ED8 RID: 20184
			public float EchoDepth;

			// Token: 0x04004ED9 RID: 20185
			public float ModulationTime;

			// Token: 0x04004EDA RID: 20186
			public float ModulationDepth;

			// Token: 0x04004EDB RID: 20187
			public float AirAbsorptionHF;

			// Token: 0x04004EDC RID: 20188
			public float HFReference;

			// Token: 0x04004EDD RID: 20189
			public float LFReference;

			// Token: 0x04004EDE RID: 20190
			public float RoomRolloffFactor;

			// Token: 0x04004EDF RID: 20191
			public uint Flags;
		}

		// Token: 0x02000550 RID: 1360
		public struct EfxEaxReverb
		{
			// Token: 0x04004EE0 RID: 20192
			public float Density;

			// Token: 0x04004EE1 RID: 20193
			public float Diffusion;

			// Token: 0x04004EE2 RID: 20194
			public float Gain;

			// Token: 0x04004EE3 RID: 20195
			public float GainHF;

			// Token: 0x04004EE4 RID: 20196
			public float GainLF;

			// Token: 0x04004EE5 RID: 20197
			public float DecayTime;

			// Token: 0x04004EE6 RID: 20198
			public float DecayHFRatio;

			// Token: 0x04004EE7 RID: 20199
			public float DecayLFRatio;

			// Token: 0x04004EE8 RID: 20200
			public float ReflectionsGain;

			// Token: 0x04004EE9 RID: 20201
			public float ReflectionsDelay;

			// Token: 0x04004EEA RID: 20202
			public Vector3 ReflectionsPan;

			// Token: 0x04004EEB RID: 20203
			public float LateReverbGain;

			// Token: 0x04004EEC RID: 20204
			public float LateReverbDelay;

			// Token: 0x04004EED RID: 20205
			public Vector3 LateReverbPan;

			// Token: 0x04004EEE RID: 20206
			public float EchoTime;

			// Token: 0x04004EEF RID: 20207
			public float EchoDepth;

			// Token: 0x04004EF0 RID: 20208
			public float ModulationTime;

			// Token: 0x04004EF1 RID: 20209
			public float ModulationDepth;

			// Token: 0x04004EF2 RID: 20210
			public float AirAbsorptionGainHF;

			// Token: 0x04004EF3 RID: 20211
			public float HFReference;

			// Token: 0x04004EF4 RID: 20212
			public float LFReference;

			// Token: 0x04004EF5 RID: 20213
			public float RoomRolloffFactor;

			// Token: 0x04004EF6 RID: 20214
			public int DecayHFLimit;
		}

		// Token: 0x02000551 RID: 1361
		[CLSCompliant(false)]
		public static class ReverbPresets
		{
			// Token: 0x04004EF7 RID: 20215
			public static EffectsExtension.EaxReverb CastleSmallRoom = new EffectsExtension.EaxReverb(26U, 8.3f, 0.89f, -1000, -800, -2000, 1.22f, 0.83f, 0.31f, -100, 0.022f, 0f, 0f, 0f, 600, 0.011f, 0f, 0f, 0f, 0.138f, 0.08f, 0.25f, 0f, -5f, 5168.6f, 139.5f, 0f, 32U);

			// Token: 0x04004EF8 RID: 20216
			public static EffectsExtension.EaxReverb CastleShortPassage = new EffectsExtension.EaxReverb(26U, 8.3f, 0.89f, -1000, -1000, -2000, 2.32f, 0.83f, 0.31f, -100, 0.007f, 0f, 0f, 0f, 200, 0.023f, 0f, 0f, 0f, 0.138f, 0.08f, 0.25f, 0f, -5f, 5168.6f, 139.5f, 0f, 32U);

			// Token: 0x04004EF9 RID: 20217
			public static EffectsExtension.EaxReverb CastleMediumroom = new EffectsExtension.EaxReverb(26U, 8.3f, 0.93f, -1000, -1100, -2000, 2.04f, 0.83f, 0.46f, -400, 0.022f, 0f, 0f, 0f, 400, 0.011f, 0f, 0f, 0f, 0.155f, 0.03f, 0.25f, 0f, -5f, 5168.6f, 139.5f, 0f, 32U);

			// Token: 0x04004EFA RID: 20218
			public static EffectsExtension.EaxReverb CastleLongpassage = new EffectsExtension.EaxReverb(26U, 8.3f, 0.89f, -1000, -800, -2000, 3.42f, 0.83f, 0.31f, -100, 0.007f, 0f, 0f, 0f, 300, 0.023f, 0f, 0f, 0f, 0.138f, 0.08f, 0.25f, 0f, -5f, 5168.6f, 139.5f, 0f, 32U);

			// Token: 0x04004EFB RID: 20219
			public static EffectsExtension.EaxReverb CastleLargeroom = new EffectsExtension.EaxReverb(26U, 8.3f, 0.82f, -1000, -1100, -1800, 2.53f, 0.83f, 0.5f, -700, 0.034f, 0f, 0f, 0f, 200, 0.016f, 0f, 0f, 0f, 0.185f, 0.07f, 0.25f, 0f, -5f, 5168.6f, 139.5f, 0f, 32U);

			// Token: 0x04004EFC RID: 20220
			public static EffectsExtension.EaxReverb CastleHall = new EffectsExtension.EaxReverb(26U, 8.3f, 0.81f, -1000, -1100, -1500, 3.14f, 0.79f, 0.62f, -1500, 0.056f, 0f, 0f, 0f, 100, 0.024f, 0f, 0f, 0f, 0.25f, 0f, 0.25f, 0f, -5f, 5168.6f, 139.5f, 0f, 32U);

			// Token: 0x04004EFD RID: 20221
			public static EffectsExtension.EaxReverb CastleCupboard = new EffectsExtension.EaxReverb(26U, 8.3f, 0.89f, -1000, -1100, -2000, 0.67f, 0.87f, 0.31f, 300, 0.01f, 0f, 0f, 0f, 1100, 0.007f, 0f, 0f, 0f, 0.138f, 0.08f, 0.25f, 0f, -5f, 5168.6f, 139.5f, 0f, 32U);

			// Token: 0x04004EFE RID: 20222
			public static EffectsExtension.EaxReverb CastleCourtyard = new EffectsExtension.EaxReverb(26U, 8.3f, 0.42f, -1000, -700, -1400, 2.13f, 0.61f, 0.23f, -1300, 0.16f, 0f, 0f, 0f, -300, 0.036f, 0f, 0f, 0f, 0.25f, 0.37f, 0.25f, 0f, -5f, 5000f, 250f, 0f, 31U);

			// Token: 0x04004EFF RID: 20223
			public static EffectsExtension.EaxReverb CastleAlcove = new EffectsExtension.EaxReverb(26U, 8.3f, 0.89f, -1000, -600, -2000, 1.64f, 0.87f, 0.31f, 0, 0.007f, 0f, 0f, 0f, 300, 0.034f, 0f, 0f, 0f, 0.138f, 0.08f, 0.25f, 0f, -5f, 5168.6f, 139.5f, 0f, 32U);

			// Token: 0x04004F00 RID: 20224
			public static EffectsExtension.EaxReverb FactoryAlcove = new EffectsExtension.EaxReverb(26U, 1.8f, 0.59f, -1200, -200, -600, 3.14f, 0.65f, 1.31f, 300, 0.01f, 0f, 0f, 0f, 0, 0.038f, 0f, 0f, 0f, 0.114f, 0.1f, 0.25f, 0f, -5f, 3762.6f, 362.5f, 0f, 32U);

			// Token: 0x04004F01 RID: 20225
			public static EffectsExtension.EaxReverb FactoryShortpassage = new EffectsExtension.EaxReverb(26U, 1.8f, 0.64f, -1200, -200, -600, 2.53f, 0.65f, 1.31f, 0, 0.01f, 0f, 0f, 0f, 200, 0.038f, 0f, 0f, 0f, 0.135f, 0.23f, 0.25f, 0f, -5f, 3762.6f, 362.5f, 0f, 32U);

			// Token: 0x04004F02 RID: 20226
			public static EffectsExtension.EaxReverb FactoryMediumroom = new EffectsExtension.EaxReverb(26U, 1.9f, 0.82f, -1200, -200, -600, 2.76f, 0.65f, 1.31f, -1100, 0.022f, 0f, 0f, 0f, 300, 0.023f, 0f, 0f, 0f, 0.174f, 0.07f, 0.25f, 0f, -5f, 3762.6f, 362.5f, 0f, 32U);

			// Token: 0x04004F03 RID: 20227
			public static EffectsExtension.EaxReverb FactoryLongpassage = new EffectsExtension.EaxReverb(26U, 1.8f, 0.64f, -1200, -200, -600, 4.06f, 0.65f, 1.31f, 0, 0.02f, 0f, 0f, 0f, 200, 0.037f, 0f, 0f, 0f, 0.135f, 0.23f, 0.25f, 0f, -5f, 3762.6f, 362.5f, 0f, 32U);

			// Token: 0x04004F04 RID: 20228
			public static EffectsExtension.EaxReverb FactoryLargeroom = new EffectsExtension.EaxReverb(26U, 1.9f, 0.75f, -1200, -300, -400, 4.24f, 0.51f, 1.31f, -1500, 0.039f, 0f, 0f, 0f, 100, 0.023f, 0f, 0f, 0f, 0.231f, 0.07f, 0.25f, 0f, -5f, 3762.6f, 362.5f, 0f, 32U);

			// Token: 0x04004F05 RID: 20229
			public static EffectsExtension.EaxReverb FactoryHall = new EffectsExtension.EaxReverb(26U, 1.9f, 0.75f, -1000, -300, -400, 7.43f, 0.51f, 1.31f, -2400, 0.073f, 0f, 0f, 0f, -100, 0.027f, 0f, 0f, 0f, 0.25f, 0.07f, 0.25f, 0f, -5f, 3762.6f, 362.5f, 0f, 32U);

			// Token: 0x04004F06 RID: 20230
			public static EffectsExtension.EaxReverb FactoryCupboard = new EffectsExtension.EaxReverb(26U, 1.7f, 0.63f, -1200, -200, -600, 0.49f, 0.65f, 1.31f, 200, 0.01f, 0f, 0f, 0f, 600, 0.032f, 0f, 0f, 0f, 0.107f, 0.07f, 0.25f, 0f, -5f, 3762.6f, 362.5f, 0f, 32U);

			// Token: 0x04004F07 RID: 20231
			public static EffectsExtension.EaxReverb FactoryCourtyard = new EffectsExtension.EaxReverb(26U, 1.7f, 0.57f, -1000, -1000, -400, 2.32f, 0.29f, 0.56f, -1300, 0.14f, 0f, 0f, 0f, -800, 0.039f, 0f, 0f, 0f, 0.25f, 0.29f, 0.25f, 0f, -5f, 3762.6f, 362.5f, 0f, 32U);

			// Token: 0x04004F08 RID: 20232
			public static EffectsExtension.EaxReverb FactorySmallroom = new EffectsExtension.EaxReverb(26U, 1.8f, 0.82f, -1000, -200, -600, 1.72f, 0.65f, 1.31f, -300, 0.01f, 0f, 0f, 0f, 500, 0.024f, 0f, 0f, 0f, 0.119f, 0.07f, 0.25f, 0f, -5f, 3762.6f, 362.5f, 0f, 32U);

			// Token: 0x04004F09 RID: 20233
			public static EffectsExtension.EaxReverb IcepalaceAlcove = new EffectsExtension.EaxReverb(26U, 2.7f, 0.84f, -1000, -500, -1100, 2.76f, 1.46f, 0.28f, 100, 0.01f, 0f, 0f, 0f, -100, 0.03f, 0f, 0f, 0f, 0.161f, 0.09f, 0.25f, 0f, -5f, 12428.5f, 99.6f, 0f, 32U);

			// Token: 0x04004F0A RID: 20234
			public static EffectsExtension.EaxReverb IcepalaceShortpassage = new EffectsExtension.EaxReverb(26U, 2.7f, 0.75f, -1000, -500, -1100, 1.79f, 1.46f, 0.28f, -600, 0.01f, 0f, 0f, 0f, 100, 0.019f, 0f, 0f, 0f, 0.177f, 0.09f, 0.25f, 0f, -5f, 12428.5f, 99.6f, 0f, 32U);

			// Token: 0x04004F0B RID: 20235
			public static EffectsExtension.EaxReverb IcepalaceMediumroom = new EffectsExtension.EaxReverb(26U, 2.7f, 0.87f, -1000, -500, -700, 2.22f, 1.53f, 0.32f, -800, 0.039f, 0f, 0f, 0f, 100, 0.027f, 0f, 0f, 0f, 0.186f, 0.12f, 0.25f, 0f, -5f, 12428.5f, 99.6f, 0f, 32U);

			// Token: 0x04004F0C RID: 20236
			public static EffectsExtension.EaxReverb IcepalaceLongpassage = new EffectsExtension.EaxReverb(26U, 2.7f, 0.77f, -1000, -500, -800, 3.01f, 1.46f, 0.28f, -200, 0.012f, 0f, 0f, 0f, 200, 0.025f, 0f, 0f, 0f, 0.186f, 0.04f, 0.25f, 0f, -5f, 12428.5f, 99.6f, 0f, 32U);

			// Token: 0x04004F0D RID: 20237
			public static EffectsExtension.EaxReverb IcepalaceLargeroom = new EffectsExtension.EaxReverb(26U, 2.9f, 0.81f, -1000, -500, -700, 3.14f, 1.53f, 0.32f, -1200, 0.039f, 0f, 0f, 0f, 0, 0.027f, 0f, 0f, 0f, 0.214f, 0.11f, 0.25f, 0f, -5f, 12428.5f, 99.6f, 0f, 32U);

			// Token: 0x04004F0E RID: 20238
			public static EffectsExtension.EaxReverb IcepalaceHall = new EffectsExtension.EaxReverb(26U, 2.9f, 0.76f, -1000, -700, -500, 5.49f, 1.53f, 0.38f, -1900, 0.054f, 0f, 0f, 0f, -400, 0.052f, 0f, 0f, 0f, 0.226f, 0.11f, 0.25f, 0f, -5f, 12428.5f, 99.6f, 0f, 32U);

			// Token: 0x04004F0F RID: 20239
			public static EffectsExtension.EaxReverb IcepalaceCupboard = new EffectsExtension.EaxReverb(26U, 2.7f, 0.83f, -1000, -600, -1300, 0.76f, 1.53f, 0.26f, 100, 0.012f, 0f, 0f, 0f, 600, 0.016f, 0f, 0f, 0f, 0.143f, 0.08f, 0.25f, 0f, -5f, 12428.5f, 99.6f, 0f, 32U);

			// Token: 0x04004F10 RID: 20240
			public static EffectsExtension.EaxReverb IcepalaceCourtyard = new EffectsExtension.EaxReverb(26U, 2.9f, 0.59f, -1000, -1100, -1000, 2.04f, 1.2f, 0.38f, -1000, 0.173f, 0f, 0f, 0f, -1000, 0.043f, 0f, 0f, 0f, 0.235f, 0.48f, 0.25f, 0f, -5f, 12428.5f, 99.6f, 0f, 32U);

			// Token: 0x04004F11 RID: 20241
			public static EffectsExtension.EaxReverb IcepalaceSmallroom = new EffectsExtension.EaxReverb(26U, 2.7f, 0.84f, -1000, -500, -1100, 1.51f, 1.53f, 0.27f, -100, 0.01f, 0f, 0f, 0f, 300, 0.011f, 0f, 0f, 0f, 0.164f, 0.14f, 0.25f, 0f, -5f, 12428.5f, 99.6f, 0f, 32U);

			// Token: 0x04004F12 RID: 20242
			public static EffectsExtension.EaxReverb SpacestationAlcove = new EffectsExtension.EaxReverb(26U, 1.5f, 0.78f, -1000, -300, -100, 1.16f, 0.81f, 0.55f, 300, 0.007f, 0f, 0f, 0f, 0, 0.018f, 0f, 0f, 0f, 0.192f, 0.21f, 0.25f, 0f, -5f, 3316.1f, 458.2f, 0f, 32U);

			// Token: 0x04004F13 RID: 20243
			public static EffectsExtension.EaxReverb SpacestationMediumroom = new EffectsExtension.EaxReverb(26U, 1.5f, 0.75f, -1000, -400, -100, 3.01f, 0.5f, 0.55f, -800, 0.034f, 0f, 0f, 0f, 100, 0.035f, 0f, 0f, 0f, 0.209f, 0.31f, 0.25f, 0f, -5f, 3316.1f, 458.2f, 0f, 32U);

			// Token: 0x04004F14 RID: 20244
			public static EffectsExtension.EaxReverb SpacestationShortpassage = new EffectsExtension.EaxReverb(26U, 1.5f, 0.87f, -1000, -400, -100, 3.57f, 0.5f, 0.55f, 0, 0.012f, 0f, 0f, 0f, 100, 0.016f, 0f, 0f, 0f, 0.172f, 0.2f, 0.25f, 0f, -5f, 3316.1f, 458.2f, 0f, 32U);

			// Token: 0x04004F15 RID: 20245
			public static EffectsExtension.EaxReverb SpacestationLongpassage = new EffectsExtension.EaxReverb(26U, 1.9f, 0.82f, -1000, -400, -100, 4.62f, 0.62f, 0.55f, 0, 0.012f, 0f, 0f, 0f, 200, 0.031f, 0f, 0f, 0f, 0.25f, 0.23f, 0.25f, 0f, -5f, 3316.1f, 458.2f, 0f, 32U);

			// Token: 0x04004F16 RID: 20246
			public static EffectsExtension.EaxReverb SpacestationLargeroom = new EffectsExtension.EaxReverb(26U, 1.8f, 0.81f, -1000, -400, -100, 3.89f, 0.38f, 0.61f, -1000, 0.056f, 0f, 0f, 0f, -100, 0.035f, 0f, 0f, 0f, 0.233f, 0.28f, 0.25f, 0f, -5f, 3316.1f, 458.2f, 0f, 32U);

			// Token: 0x04004F17 RID: 20247
			public static EffectsExtension.EaxReverb SpacestationHall = new EffectsExtension.EaxReverb(26U, 1.9f, 0.87f, -1000, -400, -100, 7.11f, 0.38f, 0.61f, -1500, 0.1f, 0f, 0f, 0f, -400, 0.047f, 0f, 0f, 0f, 0.25f, 0.25f, 0.25f, 0f, -5f, 3316.1f, 458.2f, 0f, 32U);

			// Token: 0x04004F18 RID: 20248
			public static EffectsExtension.EaxReverb SpacestationCupboard = new EffectsExtension.EaxReverb(26U, 1.4f, 0.56f, -1000, -300, -100, 0.79f, 0.81f, 0.55f, 300, 0.007f, 0f, 0f, 0f, 500, 0.018f, 0f, 0f, 0f, 0.181f, 0.31f, 0.25f, 0f, -5f, 3316.1f, 458.2f, 0f, 32U);

			// Token: 0x04004F19 RID: 20249
			public static EffectsExtension.EaxReverb SpacestationSmallroom = new EffectsExtension.EaxReverb(26U, 1.5f, 0.7f, -1000, -300, -100, 1.72f, 0.82f, 0.55f, -200, 0.007f, 0f, 0f, 0f, 300, 0.013f, 0f, 0f, 0f, 0.188f, 0.26f, 0.25f, 0f, -5f, 3316.1f, 458.2f, 0f, 32U);

			// Token: 0x04004F1A RID: 20250
			public static EffectsExtension.EaxReverb WoodenAlcove = new EffectsExtension.EaxReverb(26U, 7.5f, 1f, -1000, -1800, -1000, 1.22f, 0.62f, 0.91f, 100, 0.012f, 0f, 0f, 0f, -300, 0.024f, 0f, 0f, 0f, 0.25f, 0f, 0.25f, 0f, -5f, 4705f, 99.6f, 0f, 63U);

			// Token: 0x04004F1B RID: 20251
			public static EffectsExtension.EaxReverb WoodenShortpassage = new EffectsExtension.EaxReverb(26U, 7.5f, 1f, -1000, -1800, -1000, 1.75f, 0.5f, 0.87f, -100, 0.012f, 0f, 0f, 0f, -400, 0.024f, 0f, 0f, 0f, 0.25f, 0f, 0.25f, 0f, -5f, 4705f, 99.6f, 0f, 63U);

			// Token: 0x04004F1C RID: 20252
			public static EffectsExtension.EaxReverb WoodenMediumroom = new EffectsExtension.EaxReverb(26U, 7.5f, 1f, -1000, -2000, -1100, 1.47f, 0.42f, 0.82f, -100, 0.049f, 0f, 0f, 0f, -100, 0.029f, 0f, 0f, 0f, 0.25f, 0f, 0.25f, 0f, -5f, 4705f, 99.6f, 0f, 63U);

			// Token: 0x04004F1D RID: 20253
			public static EffectsExtension.EaxReverb WoodenLongpassage = new EffectsExtension.EaxReverb(26U, 7.5f, 1f, -1000, -2000, -1000, 1.99f, 0.4f, 0.79f, 0, 0.02f, 0f, 0f, 0f, -700, 0.036f, 0f, 0f, 0f, 0.25f, 0f, 0.25f, 0f, -5f, 4705f, 99.6f, 0f, 63U);

			// Token: 0x04004F1E RID: 20254
			public static EffectsExtension.EaxReverb WoodenLargeroom = new EffectsExtension.EaxReverb(26U, 7.5f, 1f, -1000, -2100, -1100, 2.65f, 0.33f, 0.82f, -100, 0.066f, 0f, 0f, 0f, -200, 0.049f, 0f, 0f, 0f, 0.25f, 0f, 0.25f, 0f, -5f, 4705f, 99.6f, 0f, 63U);

			// Token: 0x04004F1F RID: 20255
			public static EffectsExtension.EaxReverb WoodenHall = new EffectsExtension.EaxReverb(26U, 7.5f, 1f, -1000, -2200, -1100, 3.45f, 0.3f, 0.82f, -100, 0.088f, 0f, 0f, 0f, -200, 0.063f, 0f, 0f, 0f, 0.25f, 0f, 0.25f, 0f, -5f, 4705f, 99.6f, 0f, 63U);

			// Token: 0x04004F20 RID: 20256
			public static EffectsExtension.EaxReverb WoodenCupboard = new EffectsExtension.EaxReverb(26U, 7.5f, 1f, -1000, -1700, -1000, 0.56f, 0.46f, 0.91f, 100, 0.012f, 0f, 0f, 0f, 100, 0.028f, 0f, 0f, 0f, 0.25f, 0f, 0.25f, 0f, -5f, 4705f, 99.6f, 0f, 63U);

			// Token: 0x04004F21 RID: 20257
			public static EffectsExtension.EaxReverb WoodenSmallroom = new EffectsExtension.EaxReverb(26U, 7.5f, 1f, -1000, -1900, -1000, 0.79f, 0.32f, 0.87f, 0, 0.032f, 0f, 0f, 0f, -100, 0.029f, 0f, 0f, 0f, 0.25f, 0f, 0.25f, 0f, -5f, 4705f, 99.6f, 0f, 63U);

			// Token: 0x04004F22 RID: 20258
			public static EffectsExtension.EaxReverb WoodenCourtyard = new EffectsExtension.EaxReverb(26U, 7.5f, 0.65f, -1000, -2200, -1000, 1.79f, 0.35f, 0.79f, -500, 0.123f, 0f, 0f, 0f, -2000, 0.032f, 0f, 0f, 0f, 0.25f, 0f, 0.25f, 0f, -5f, 4705f, 99.6f, 0f, 63U);

			// Token: 0x04004F23 RID: 20259
			public static EffectsExtension.EaxReverb SportEmptystadium = new EffectsExtension.EaxReverb(26U, 7.2f, 1f, -1000, -700, -200, 6.26f, 0.51f, 1.1f, -2400, 0.183f, 0f, 0f, 0f, -800, 0.038f, 0f, 0f, 0f, 0.25f, 0f, 0.25f, 0f, -5f, 5000f, 250f, 0f, 32U);

			// Token: 0x04004F24 RID: 20260
			public static EffectsExtension.EaxReverb SportSquashcourt = new EffectsExtension.EaxReverb(26U, 7.5f, 0.75f, -1000, -1000, -200, 2.22f, 0.91f, 1.16f, -700, 0.007f, 0f, 0f, 0f, -200, 0.011f, 0f, 0f, 0f, 0.126f, 0.19f, 0.25f, 0f, -5f, 7176.9f, 211.2f, 0f, 32U);

			// Token: 0x04004F25 RID: 20261
			public static EffectsExtension.EaxReverb SportSmallswimmingpool = new EffectsExtension.EaxReverb(26U, 36.2f, 0.7f, -1000, -200, -100, 2.76f, 1.25f, 1.14f, -400, 0.02f, 0f, 0f, 0f, -200, 0.03f, 0f, 0f, 0f, 0.179f, 0.15f, 0.895f, 0.19f, -5f, 5000f, 250f, 0f, 0U);

			// Token: 0x04004F26 RID: 20262
			public static EffectsExtension.EaxReverb SportLargeswimmingpool = new EffectsExtension.EaxReverb(26U, 36.2f, 0.82f, -1000, -200, 0, 5.49f, 1.31f, 1.14f, -700, 0.039f, 0f, 0f, 0f, -600, 0.049f, 0f, 0f, 0f, 0.222f, 0.55f, 1.159f, 0.21f, -5f, 5000f, 250f, 0f, 0U);

			// Token: 0x04004F27 RID: 20263
			public static EffectsExtension.EaxReverb SportGymnasium = new EffectsExtension.EaxReverb(26U, 7.5f, 0.81f, -1000, -700, -100, 3.14f, 1.06f, 1.35f, -800, 0.029f, 0f, 0f, 0f, -500, 0.045f, 0f, 0f, 0f, 0.146f, 0.14f, 0.25f, 0f, -5f, 7176.9f, 211.2f, 0f, 32U);

			// Token: 0x04004F28 RID: 20264
			public static EffectsExtension.EaxReverb SportFullstadium = new EffectsExtension.EaxReverb(26U, 7.2f, 1f, -1000, -2300, -200, 5.25f, 0.17f, 0.8f, -2000, 0.188f, 0f, 0f, 0f, -1100, 0.038f, 0f, 0f, 0f, 0.25f, 0f, 0.25f, 0f, -5f, 5000f, 250f, 0f, 32U);

			// Token: 0x04004F29 RID: 20265
			public static EffectsExtension.EaxReverb SportStadimtannoy = new EffectsExtension.EaxReverb(26U, 3f, 0.78f, -1000, -500, -600, 2.53f, 0.88f, 0.68f, -1100, 0.23f, 0f, 0f, 0f, -600, 0.063f, 0f, 0f, 0f, 0.25f, 0.2f, 0.25f, 0f, -5f, 5000f, 250f, 0f, 32U);

			// Token: 0x04004F2A RID: 20266
			public static EffectsExtension.EaxReverb PrefabWorkshop = new EffectsExtension.EaxReverb(26U, 1.9f, 1f, -1000, -1700, -800, 0.76f, 1f, 1f, 0, 0.012f, 0f, 0f, 0f, 100, 0.012f, 0f, 0f, 0f, 0.25f, 0f, 0.25f, 0f, -5f, 5000f, 250f, 0f, 0U);

			// Token: 0x04004F2B RID: 20267
			public static EffectsExtension.EaxReverb PrefabSchoolroom = new EffectsExtension.EaxReverb(26U, 1.86f, 0.69f, -1000, -400, -600, 0.98f, 0.45f, 0.18f, 300, 0.017f, 0f, 0f, 0f, 300, 0.015f, 0f, 0f, 0f, 0.095f, 0.14f, 0.25f, 0f, -5f, 7176.9f, 211.2f, 0f, 32U);

			// Token: 0x04004F2C RID: 20268
			public static EffectsExtension.EaxReverb PrefabPractiseroom = new EffectsExtension.EaxReverb(26U, 1.86f, 0.87f, -1000, -800, -600, 1.12f, 0.56f, 0.18f, 200, 0.01f, 0f, 0f, 0f, 300, 0.011f, 0f, 0f, 0f, 0.095f, 0.14f, 0.25f, 0f, -5f, 7176.9f, 211.2f, 0f, 32U);

			// Token: 0x04004F2D RID: 20269
			public static EffectsExtension.EaxReverb PrefabOuthouse = new EffectsExtension.EaxReverb(26U, 80.3f, 0.82f, -1000, -1900, -1600, 1.38f, 0.38f, 0.35f, -100, 0.024f, 0f, 0f, --0f, -400, 0.044f, 0f, 0f, 0f, 0.121f, 0.17f, 0.25f, 0f, -5f, 2854.4f, 107.5f, 0f, 0U);

			// Token: 0x04004F2E RID: 20270
			public static EffectsExtension.EaxReverb PrefabCaravan = new EffectsExtension.EaxReverb(26U, 8.3f, 1f, -1000, -2100, -1800, 0.43f, 1.5f, 1f, 0, 0.012f, 0f, 0f, 0f, 600, 0.012f, 0f, 0f, 0f, 0.25f, 0f, 0.25f, 0f, -5f, 5000f, 250f, 0f, 31U);

			// Token: 0x04004F2F RID: 20271
			public static EffectsExtension.EaxReverb DomeTomb = new EffectsExtension.EaxReverb(26U, 51.8f, 0.79f, -1000, -900, -1300, 4.18f, 0.21f, 0.1f, -825, 0.03f, 0f, 0f, 0f, 450, 0.022f, 0f, 0f, 0f, 0.177f, 0.19f, 0.25f, 0f, -5f, 2854.4f, 20f, 0f, 0U);

			// Token: 0x04004F30 RID: 20272
			public static EffectsExtension.EaxReverb DomeSaintPauls = new EffectsExtension.EaxReverb(26U, 50.3f, 0.87f, -1000, -900, -1300, 10.48f, 0.19f, 0.1f, -1500, 0.09f, 0f, 0f, 0f, 200, 0.042f, 0f, 0f, 0f, 0.25f, 0.12f, 0.25f, 0f, -5f, 2854.4f, 20f, 0f, 63U);

			// Token: 0x04004F31 RID: 20273
			public static EffectsExtension.EaxReverb PipeSmall = new EffectsExtension.EaxReverb(26U, 50.3f, 1f, -1000, -900, -1300, 5.04f, 0.1f, 0.1f, -600, 0.032f, 0f, 0f, 0f, 800, 0.015f, 0f, 0f, 0f, 0.25f, 0f, 0.25f, 0f, -5f, 2854.4f, 20f, 0f, 63U);

			// Token: 0x04004F32 RID: 20274
			public static EffectsExtension.EaxReverb PipeLongthin = new EffectsExtension.EaxReverb(26U, 1.6f, 0.91f, -1000, -700, -1100, 9.21f, 0.18f, 0.1f, -300, 0.01f, 0f, 0f, 0f, -300, 0.022f, 0f, 0f, 0f, 0.25f, 0f, 0.25f, 0f, -5f, 2854.4f, 20f, 0f, 0U);

			// Token: 0x04004F33 RID: 20275
			public static EffectsExtension.EaxReverb PipeLarge = new EffectsExtension.EaxReverb(26U, 50.3f, 1f, -1000, -900, -1300, 8.45f, 0.1f, 0.1f, -800, 0.046f, 0f, 0f, 0f, 400, 0.032f, 0f, 0f, 0f, 0.25f, 0f, 0.25f, 0f, -5f, 2854.4f, 20f, 0f, 63U);

			// Token: 0x04004F34 RID: 20276
			public static EffectsExtension.EaxReverb PipeResonant = new EffectsExtension.EaxReverb(26U, 1.3f, 0.91f, -1000, -700, -1100, 6.81f, 0.18f, 0.1f, -300, 0.01f, 0f, 0f, 0f, 0, 0.022f, 0f, 0f, 0f, 0.25f, 0f, 0.25f, 0f, -5f, 2854.4f, 20f, 0f, 0U);

			// Token: 0x04004F35 RID: 20277
			public static EffectsExtension.EaxReverb OutdoorsBackyard = new EffectsExtension.EaxReverb(26U, 80.3f, 0.45f, -1000, -1200, -600, 1.12f, 0.34f, 0.46f, -700, 0.069f, 0f, 0f, --0f, -300, 0.023f, 0f, 0f, 0f, 0.218f, 0.34f, 0.25f, 0f, -5f, 4399.1f, 242.9f, 0f, 0U);

			// Token: 0x04004F36 RID: 20278
			public static EffectsExtension.EaxReverb OutdoorsRollingplains = new EffectsExtension.EaxReverb(26U, 80.3f, 0f, -1000, -3900, -400, 2.13f, 0.21f, 0.46f, -1500, 0.3f, 0f, 0f, --0f, -700, 0.019f, 0f, 0f, 0f, 0.25f, 1f, 0.25f, 0f, -5f, 4399.1f, 242.9f, 0f, 0U);

			// Token: 0x04004F37 RID: 20279
			public static EffectsExtension.EaxReverb OutdoorsDeepcanyon = new EffectsExtension.EaxReverb(26U, 80.3f, 0.74f, -1000, -1500, -400, 3.89f, 0.21f, 0.46f, -1000, 0.223f, 0f, 0f, --0f, -900, 0.019f, 0f, 0f, 0f, 0.25f, 1f, 0.25f, 0f, -5f, 4399.1f, 242.9f, 0f, 0U);

			// Token: 0x04004F38 RID: 20280
			public static EffectsExtension.EaxReverb OutdoorsCreek = new EffectsExtension.EaxReverb(26U, 80.3f, 0.35f, -1000, -1500, -600, 2.13f, 0.21f, 0.46f, -800, 0.115f, 0f, 0f, --0f, -1400, 0.031f, 0f, 0f, 0f, 0.218f, 0.34f, 0.25f, 0f, -5f, 4399.1f, 242.9f, 0f, 0U);

			// Token: 0x04004F39 RID: 20281
			public static EffectsExtension.EaxReverb OutdoorsValley = new EffectsExtension.EaxReverb(26U, 80.3f, 0.28f, -1000, -3100, -1600, 2.88f, 0.26f, 0.35f, -1700, 0.263f, 0f, 0f, --0f, -800, 0.1f, 0f, 0f, 0f, 0.25f, 0.34f, 0.25f, 0f, -5f, 2854.4f, 107.5f, 0f, 0U);

			// Token: 0x04004F3A RID: 20282
			public static EffectsExtension.EaxReverb MoodHeaven = new EffectsExtension.EaxReverb(26U, 19.6f, 0.94f, -1000, -200, -700, 5.04f, 1.12f, 0.56f, -1230, 0.02f, 0f, 0f, 0f, 200, 0.029f, 0f, 0f, 0f, 0.25f, 0.08f, 2.742f, 0.05f, -2f, 5000f, 250f, 0f, 63U);

			// Token: 0x04004F3B RID: 20283
			public static EffectsExtension.EaxReverb MoodHell = new EffectsExtension.EaxReverb(26U, 100f, 0.57f, -1000, -900, -700, 3.57f, 0.49f, 2f, -10000, 0.02f, 0f, 0f, 0f, 300, 0.03f, 0f, 0f, 0f, 0.11f, 0.04f, 2.109f, 0.52f, -5f, 5000f, 139.5f, 0f, 64U);

			// Token: 0x04004F3C RID: 20284
			public static EffectsExtension.EaxReverb MoodMemory = new EffectsExtension.EaxReverb(26U, 8f, 0.85f, -1000, -400, -900, 4.06f, 0.82f, 0.56f, -2800, 0f, 0f, 0f, 0f, 100, 0f, 0f, 0f, 0f, 0.25f, 0f, 0.474f, 0.45f, -10f, 5000f, 250f, 0f, 0U);

			// Token: 0x04004F3D RID: 20285
			public static EffectsExtension.EaxReverb DrivingCommentator = new EffectsExtension.EaxReverb(26U, 3f, 0f, 1000, -500, -600, 2.42f, 0.88f, 0.68f, -1400, 0.093f, 0f, 0f, 0f, -1200, 0.017f, 0f, 0f, 0f, 0.25f, 1f, 0.25f, 0f, -10f, 5000f, 250f, 0f, 32U);

			// Token: 0x04004F3E RID: 20286
			public static EffectsExtension.EaxReverb DrivingPitgarage = new EffectsExtension.EaxReverb(26U, 1.9f, 0.59f, -1000, -300, -500, 1.72f, 0.93f, 0.87f, -500, 0f, 0f, 0f, 0f, 200, 0.016f, 0f, 0f, 0f, 0.25f, 0.11f, 0.25f, 0f, -5f, 5000f, 250f, 0f, 0U);

			// Token: 0x04004F3F RID: 20287
			public static EffectsExtension.EaxReverb DrivingIncarRacer = new EffectsExtension.EaxReverb(26U, 1.1f, 0.8f, -1000, 0, -200, 0.17f, 2f, 0.41f, 500, 0.007f, 0f, 0f, 0f, -300, 0.015f, 0f, 0f, 0f, 0.25f, 0f, 0.25f, 0f, -5f, 10268.2f, 251f, 0f, 32U);

			// Token: 0x04004F40 RID: 20288
			public static EffectsExtension.EaxReverb DrivingIncarSports = new EffectsExtension.EaxReverb(26U, 1.1f, 0.8f, -1000, -400, 0, 0.17f, 0.75f, 0.41f, 0, 0.01f, 0f, 0f, 0f, -500, 0f, 0f, 0f, 0f, 0.25f, 0f, 0.25f, 0f, -5f, 10268.2f, 251f, 0f, 32U);

			// Token: 0x04004F41 RID: 20289
			public static EffectsExtension.EaxReverb DrivingIncarLuxury = new EffectsExtension.EaxReverb(26U, 1.6f, 1f, -1000, -2000, -600, 0.13f, 0.41f, 0.46f, -200, 0.01f, 0f, 0f, 0f, 400, 0.01f, 0f, 0f, 0f, 0.25f, 0f, 0.25f, 0f, -5f, 10268.2f, 251f, 0f, 32U);

			// Token: 0x04004F42 RID: 20290
			public static EffectsExtension.EaxReverb DrivingFullgrandstand = new EffectsExtension.EaxReverb(26U, 8.3f, 1f, -1000, -1100, -400, 3.01f, 1.37f, 1.28f, -900, 0.09f, 0f, 0f, 0f, -1500, 0.049f, 0f, 0f, 0f, 0.25f, 0f, 0.25f, 0f, -5f, 10420.2f, 250f, 0f, 31U);

			// Token: 0x04004F43 RID: 20291
			public static EffectsExtension.EaxReverb DrivingEmptygrandstand = new EffectsExtension.EaxReverb(26U, 8.3f, 1f, -1000, 0, -200, 4.62f, 1.75f, 1.4f, -1363, 0.09f, 0f, 0f, 0f, -1200, 0.049f, 0f, 0f, 0f, 0.25f, 0f, 0.25f, 0f, -5f, 10420.2f, 250f, 0f, 31U);

			// Token: 0x04004F44 RID: 20292
			public static EffectsExtension.EaxReverb DrivingTunnel = new EffectsExtension.EaxReverb(26U, 3.1f, 0.81f, -1000, -800, -100, 3.42f, 0.94f, 1.31f, -300, 0.051f, 0f, 0f, 0f, -300, 0.047f, 0f, 0f, 0f, 0.214f, 0.05f, 0.25f, 0f, -5f, 5000f, 155.3f, 0f, 32U);

			// Token: 0x04004F45 RID: 20293
			public static EffectsExtension.EaxReverb CityStreets = new EffectsExtension.EaxReverb(26U, 3f, 0.78f, -1000, -300, -100, 1.79f, 1.12f, 0.91f, -1100, 0.046f, 0f, 0f, 0f, -1400, 0.028f, 0f, 0f, 0f, 0.25f, 0.2f, 0.25f, 0f, -5f, 5000f, 250f, 0f, 32U);

			// Token: 0x04004F46 RID: 20294
			public static EffectsExtension.EaxReverb CitySubway = new EffectsExtension.EaxReverb(26U, 3f, 0.74f, -1000, -300, -100, 3.01f, 1.23f, 0.91f, -300, 0.046f, 0f, 0f, 0f, 200, 0.028f, 0f, 0f, 0f, 0.125f, 0.21f, 0.25f, 0f, -5f, 5000f, 250f, 0f, 32U);

			// Token: 0x04004F47 RID: 20295
			public static EffectsExtension.EaxReverb CityMuseum = new EffectsExtension.EaxReverb(26U, 80.3f, 0.82f, -1000, -1500, -1500, 3.28f, 1.4f, 0.57f, -1200, 0.039f, 0f, 0f, --0f, -100, 0.034f, 0f, 0f, 0f, 0.13f, 0.17f, 0.25f, 0f, -5f, 2854.4f, 107.5f, 0f, 0U);

			// Token: 0x04004F48 RID: 20296
			public static EffectsExtension.EaxReverb CityLibrary = new EffectsExtension.EaxReverb(26U, 80.3f, 0.82f, -1000, -1100, -2100, 2.76f, 0.89f, 0.41f, -900, 0.029f, 0f, 0f, --0f, -100, 0.02f, 0f, 0f, 0f, 0.13f, 0.17f, 0.25f, 0f, -5f, 2854.4f, 107.5f, 0f, 0U);

			// Token: 0x04004F49 RID: 20297
			public static EffectsExtension.EaxReverb CityUnderpass = new EffectsExtension.EaxReverb(26U, 3f, 0.82f, -1000, -700, -100, 3.57f, 1.12f, 0.91f, -800, 0.059f, 0f, 0f, 0f, -100, 0.037f, 0f, 0f, 0f, 0.25f, 0.14f, 0.25f, 0f, -7f, 5000f, 250f, 0f, 32U);

			// Token: 0x04004F4A RID: 20298
			public static EffectsExtension.EaxReverb CityAbandoned = new EffectsExtension.EaxReverb(26U, 3f, 0.69f, -1000, -200, -100, 3.28f, 1.17f, 0.91f, -700, 0.044f, 0f, 0f, 0f, -1100, 0.024f, 0f, 0f, 0f, 0.25f, 0.2f, 0.25f, 0f, -3f, 5000f, 250f, 0f, 32U);

			// Token: 0x04004F4B RID: 20299
			public static EffectsExtension.EaxReverb Generic = new EffectsExtension.EaxReverb(0U, 7.5f, 1f, -1000, -100, 0, 1.49f, 0.83f, 1f, -2602, 0.007f, 0f, 0f, 0f, 200, 0.011f, 0f, 0f, 0f, 0.25f, 0f, 0.25f, 0f, -5f, 5000f, 250f, 0f, 63U);

			// Token: 0x04004F4C RID: 20300
			public static EffectsExtension.EaxReverb Paddedcell = new EffectsExtension.EaxReverb(1U, 1.4f, 1f, -1000, -6000, 0, 0.17f, 0.1f, 1f, -1204, 0.001f, 0f, 0f, 0f, 207, 0.002f, 0f, 0f, 0f, 0.25f, 0f, 0.25f, 0f, -5f, 5000f, 250f, 0f, 63U);

			// Token: 0x04004F4D RID: 20301
			public static EffectsExtension.EaxReverb Room = new EffectsExtension.EaxReverb(2U, 1.9f, 1f, -1000, -454, 0, 0.4f, 0.83f, 1f, -1646, 0.002f, 0f, 0f, 0f, 53, 0.003f, 0f, 0f, 0f, 0.25f, 0f, 0.25f, 0f, -5f, 5000f, 250f, 0f, 63U);

			// Token: 0x04004F4E RID: 20302
			public static EffectsExtension.EaxReverb Bathroom = new EffectsExtension.EaxReverb(3U, 1.4f, 1f, -1000, -1200, 0, 1.49f, 0.54f, 1f, -370, 0.007f, 0f, 0f, 0f, 1030, 0.011f, 0f, 0f, 0f, 0.25f, 0f, 0.25f, 0f, -5f, 5000f, 250f, 0f, 63U);

			// Token: 0x04004F4F RID: 20303
			public static EffectsExtension.EaxReverb Livingroom = new EffectsExtension.EaxReverb(4U, 2.5f, 1f, -1000, -6000, 0, 0.5f, 0.1f, 1f, -1376, 0.003f, 0f, 0f, 0f, -1104, 0.004f, 0f, 0f, 0f, 0.25f, 0f, 0.25f, 0f, -5f, 5000f, 250f, 0f, 63U);

			// Token: 0x04004F50 RID: 20304
			public static EffectsExtension.EaxReverb Stoneroom = new EffectsExtension.EaxReverb(5U, 11.6f, 1f, -1000, -300, 0, 2.31f, 0.64f, 1f, -711, 0.012f, 0f, 0f, 0f, 83, 0.017f, 0f, 0f, 0f, 0.25f, 0f, 0.25f, 0f, -5f, 5000f, 250f, 0f, 63U);

			// Token: 0x04004F51 RID: 20305
			public static EffectsExtension.EaxReverb Auditorium = new EffectsExtension.EaxReverb(6U, 21.6f, 1f, -1000, -476, 0, 4.32f, 0.59f, 1f, -789, 0.02f, 0f, 0f, 0f, -289, 0.03f, 0f, 0f, 0f, 0.25f, 0f, 0.25f, 0f, -5f, 5000f, 250f, 0f, 63U);

			// Token: 0x04004F52 RID: 20306
			public static EffectsExtension.EaxReverb Concerthall = new EffectsExtension.EaxReverb(7U, 19.6f, 1f, -1000, -500, 0, 3.92f, 0.7f, 1f, -1230, 0.02f, 0f, 0f, 0f, -2, 0.029f, 0f, 0f, 0f, 0.25f, 0f, 0.25f, 0f, -5f, 5000f, 250f, 0f, 63U);

			// Token: 0x04004F53 RID: 20307
			public static EffectsExtension.EaxReverb Cave = new EffectsExtension.EaxReverb(8U, 14.6f, 1f, -1000, 0, 0, 2.91f, 1.3f, 1f, -602, 0.015f, 0f, 0f, 0f, -302, 0.022f, 0f, 0f, 0f, 0.25f, 0f, 0.25f, 0f, -5f, 5000f, 250f, 0f, 31U);

			// Token: 0x04004F54 RID: 20308
			public static EffectsExtension.EaxReverb Arena = new EffectsExtension.EaxReverb(9U, 36.2f, 1f, -1000, -698, 0, 7.24f, 0.33f, 1f, -1166, 0.02f, 0f, 0f, 0f, 16, 0.03f, 0f, 0f, 0f, 0.25f, 0f, 0.25f, 0f, -5f, 5000f, 250f, 0f, 63U);

			// Token: 0x04004F55 RID: 20309
			public static EffectsExtension.EaxReverb Hangar = new EffectsExtension.EaxReverb(10U, 50.3f, 1f, -1000, -1000, 0, 10.05f, 0.23f, 1f, -602, 0.02f, 0f, 0f, 0f, 198, 0.03f, 0f, 0f, 0f, 0.25f, 0f, 0.25f, 0f, -5f, 5000f, 250f, 0f, 63U);

			// Token: 0x04004F56 RID: 20310
			public static EffectsExtension.EaxReverb Carpettedhallway = new EffectsExtension.EaxReverb(11U, 1.9f, 1f, -1000, -4000, 0, 0.3f, 0.1f, 1f, -1831, 0.002f, 0f, 0f, 0f, -1630, 0.03f, 0f, 0f, 0f, 0.25f, 0f, 0.25f, 0f, -5f, 5000f, 250f, 0f, 63U);

			// Token: 0x04004F57 RID: 20311
			public static EffectsExtension.EaxReverb Hallway = new EffectsExtension.EaxReverb(12U, 1.8f, 1f, -1000, -300, 0, 1.49f, 0.59f, 1f, -1219, 0.007f, 0f, 0f, 0f, 441, 0.011f, 0f, 0f, 0f, 0.25f, 0f, 0.25f, 0f, -5f, 5000f, 250f, 0f, 63U);

			// Token: 0x04004F58 RID: 20312
			public static EffectsExtension.EaxReverb Stonecorridor = new EffectsExtension.EaxReverb(13U, 13.5f, 1f, -1000, -237, 0, 2.7f, 0.79f, 1f, -1214, 0.013f, 0f, 0f, 0f, 395, 0.02f, 0f, 0f, 0f, 0.25f, 0f, 0.25f, 0f, -5f, 5000f, 250f, 0f, 63U);

			// Token: 0x04004F59 RID: 20313
			public static EffectsExtension.EaxReverb Alley = new EffectsExtension.EaxReverb(14U, 7.5f, 0.3f, -1000, -270, 0, 1.49f, 0.86f, 1f, -1204, 0.007f, 0f, 0f, 0f, -4, 0.011f, 0f, 0f, 0f, 0.125f, 0.95f, 0.25f, 0f, -5f, 5000f, 250f, 0f, 63U);

			// Token: 0x04004F5A RID: 20314
			public static EffectsExtension.EaxReverb Forest = new EffectsExtension.EaxReverb(15U, 38f, 0.3f, -1000, -3300, 0, 1.49f, 0.54f, 1f, -2560, 0.162f, 0f, 0f, 0f, -229, 0.088f, 0f, 0f, 0f, 0.125f, 1f, 0.25f, 0f, -5f, 5000f, 250f, 0f, 63U);

			// Token: 0x04004F5B RID: 20315
			public static EffectsExtension.EaxReverb City = new EffectsExtension.EaxReverb(16U, 7.5f, 0.5f, -1000, -800, 0, 1.49f, 0.67f, 1f, -2273, 0.007f, 0f, 0f, 0f, -1691, 0.011f, 0f, 0f, 0f, 0.25f, 0f, 0.25f, 0f, -5f, 5000f, 250f, 0f, 63U);

			// Token: 0x04004F5C RID: 20316
			public static EffectsExtension.EaxReverb Mountains = new EffectsExtension.EaxReverb(17U, 100f, 0.27f, -1000, -2500, 0, 1.49f, 0.21f, 1f, -2780, 0.3f, 0f, 0f, 0f, -1434, 0.1f, 0f, 0f, 0f, 0.25f, 1f, 0.25f, 0f, -5f, 5000f, 250f, 0f, 31U);

			// Token: 0x04004F5D RID: 20317
			public static EffectsExtension.EaxReverb Quarry = new EffectsExtension.EaxReverb(18U, 17.5f, 1f, -1000, -1000, 0, 1.49f, 0.83f, 1f, -10000, 0.061f, 0f, 0f, 0f, 500, 0.025f, 0f, 0f, 0f, 0.125f, 0.7f, 0.25f, 0f, -5f, 5000f, 250f, 0f, 63U);

			// Token: 0x04004F5E RID: 20318
			public static EffectsExtension.EaxReverb Plain = new EffectsExtension.EaxReverb(19U, 42.5f, 0.21f, -1000, -2000, 0, 1.49f, 0.5f, 1f, -2466, 0.179f, 0f, 0f, 0f, -1926, 0.1f, 0f, 0f, 0f, 0.25f, 1f, 0.25f, 0f, -5f, 5000f, 250f, 0f, 63U);

			// Token: 0x04004F5F RID: 20319
			public static EffectsExtension.EaxReverb Parkinglot = new EffectsExtension.EaxReverb(20U, 8.3f, 1f, -1000, 0, 0, 1.65f, 1.5f, 1f, -1363, 0.008f, 0f, 0f, 0f, -1153, 0.012f, 0f, 0f, 0f, 0.25f, 0f, 0.25f, 0f, -5f, 5000f, 250f, 0f, 31U);

			// Token: 0x04004F60 RID: 20320
			public static EffectsExtension.EaxReverb Sewerpipe = new EffectsExtension.EaxReverb(21U, 1.7f, 0.8f, -1000, -1000, 0, 2.81f, 0.14f, 1f, 429, 0.014f, 0f, 0f, 0f, 1023, 0.021f, 0f, 0f, 0f, 0.25f, 0f, 0.25f, 0f, -5f, 5000f, 250f, 0f, 63U);

			// Token: 0x04004F61 RID: 20321
			public static EffectsExtension.EaxReverb Underwater = new EffectsExtension.EaxReverb(22U, 1.8f, 1f, -1000, -4000, 0, 1.49f, 0.1f, 1f, -449, 0.007f, 0f, 0f, 0f, 1700, 0.011f, 0f, 0f, 0f, 0.25f, 0f, 1.18f, 0.348f, -5f, 5000f, 250f, 0f, 63U);

			// Token: 0x04004F62 RID: 20322
			public static EffectsExtension.EaxReverb Drugged = new EffectsExtension.EaxReverb(23U, 1.9f, 0.5f, -1000, 0, 0, 8.39f, 1.39f, 1f, -115, 0.002f, 0f, 0f, 0f, 985, 0.03f, 0f, 0f, 0f, 0.25f, 0f, 0.25f, 1f, -5f, 5000f, 250f, 0f, 31U);

			// Token: 0x04004F63 RID: 20323
			public static EffectsExtension.EaxReverb Dizzy = new EffectsExtension.EaxReverb(24U, 1.8f, 0.6f, -1000, -400, 0, 17.23f, 0.56f, 1f, -1713, 0.02f, 0f, 0f, 0f, -613, 0.03f, 0f, 0f, 0f, 0.25f, 1f, 0.81f, 0.31f, -5f, 5000f, 250f, 0f, 31U);

			// Token: 0x04004F64 RID: 20324
			public static EffectsExtension.EaxReverb Psychotic = new EffectsExtension.EaxReverb(25U, 1f, 0.5f, -1000, -151, 0, 7.56f, 0.91f, 1f, -626, 0.02f, 0f, 0f, 0f, 774, 0.03f, 0f, 0f, 0f, 0.25f, 0f, 4f, 1f, -5f, 5000f, 250f, 0f, 31U);

			// Token: 0x04004F65 RID: 20325
			public static EffectsExtension.EaxReverb Dustyroom = new EffectsExtension.EaxReverb(26U, 1.8f, 0.56f, -1000, -200, -300, 1.79f, 0.38f, 0.21f, -600, 0.002f, 0f, 0f, 0f, 200, 0.006f, 0f, 0f, 0f, 0.202f, 0.05f, 0.25f, 0f, -10f, 13046f, 163.3f, 0f, 32U);

			// Token: 0x04004F66 RID: 20326
			public static EffectsExtension.EaxReverb Chapel = new EffectsExtension.EaxReverb(26U, 19.6f, 0.84f, -1000, -500, 0, 4.62f, 0.64f, 1.23f, -700, 0.032f, 0f, 0f, 0f, -200, 0.049f, 0f, 0f, 0f, 0.25f, 0f, 0.25f, 0.11f, -5f, 5000f, 250f, 0f, 63U);

			// Token: 0x04004F67 RID: 20327
			public static EffectsExtension.EaxReverb Smallwaterroom = new EffectsExtension.EaxReverb(26U, 36.2f, 0.7f, -1000, -698, 0, 1.51f, 1.25f, 1.14f, -100, 0.02f, 0f, 0f, 0f, 300, 0.03f, 0f, 0f, 0f, 0.179f, 0.15f, 0.895f, 0.19f, -7f, 5000f, 250f, 0f, 0U);
		}

		// Token: 0x02000552 RID: 1362
		// (Invoke) Token: 0x060044AC RID: 17580
		private unsafe delegate void Delegate_alGenEffects(int n, [Out] uint* effects);

		// Token: 0x02000553 RID: 1363
		// (Invoke) Token: 0x060044B0 RID: 17584
		private unsafe delegate void Delegate_alDeleteEffects(int n, [In] uint* effects);

		// Token: 0x02000554 RID: 1364
		// (Invoke) Token: 0x060044B4 RID: 17588
		private delegate bool Delegate_alIsEffect(uint eid);

		// Token: 0x02000555 RID: 1365
		// (Invoke) Token: 0x060044B8 RID: 17592
		private delegate void Delegate_alEffecti(uint eid, EfxEffecti param, int value);

		// Token: 0x02000556 RID: 1366
		// (Invoke) Token: 0x060044BC RID: 17596
		private delegate void Delegate_alEffectf(uint eid, EfxEffectf param, float value);

		// Token: 0x02000557 RID: 1367
		// (Invoke) Token: 0x060044C0 RID: 17600
		private unsafe delegate void Delegate_alEffectfv(uint eid, EfxEffect3f param, [In] float* values);

		// Token: 0x02000558 RID: 1368
		// (Invoke) Token: 0x060044C4 RID: 17604
		private unsafe delegate void Delegate_alGetEffecti(uint eid, EfxEffecti pname, [Out] int* value);

		// Token: 0x02000559 RID: 1369
		// (Invoke) Token: 0x060044C8 RID: 17608
		private unsafe delegate void Delegate_alGetEffectf(uint eid, EfxEffectf pname, [Out] float* value);

		// Token: 0x0200055A RID: 1370
		// (Invoke) Token: 0x060044CC RID: 17612
		private unsafe delegate void Delegate_alGetEffectfv(uint eid, EfxEffect3f param, [Out] float* values);

		// Token: 0x0200055B RID: 1371
		// (Invoke) Token: 0x060044D0 RID: 17616
		private unsafe delegate void Delegate_alGenFilters(int n, [Out] uint* filters);

		// Token: 0x0200055C RID: 1372
		// (Invoke) Token: 0x060044D4 RID: 17620
		private unsafe delegate void Delegate_alDeleteFilters(int n, [In] uint* filters);

		// Token: 0x0200055D RID: 1373
		// (Invoke) Token: 0x060044D8 RID: 17624
		private delegate bool Delegate_alIsFilter(uint fid);

		// Token: 0x0200055E RID: 1374
		// (Invoke) Token: 0x060044DC RID: 17628
		private delegate void Delegate_alFilteri(uint fid, EfxFilteri param, int value);

		// Token: 0x0200055F RID: 1375
		// (Invoke) Token: 0x060044E0 RID: 17632
		private delegate void Delegate_alFilterf(uint fid, EfxFilterf param, float value);

		// Token: 0x02000560 RID: 1376
		// (Invoke) Token: 0x060044E4 RID: 17636
		private unsafe delegate void Delegate_alGetFilteri(uint fid, EfxFilteri pname, [Out] int* value);

		// Token: 0x02000561 RID: 1377
		// (Invoke) Token: 0x060044E8 RID: 17640
		private unsafe delegate void Delegate_alGetFilterf(uint fid, EfxFilterf pname, [Out] float* value);

		// Token: 0x02000562 RID: 1378
		// (Invoke) Token: 0x060044EC RID: 17644
		private unsafe delegate void Delegate_alGenAuxiliaryEffectSlots(int n, [Out] uint* slots);

		// Token: 0x02000563 RID: 1379
		// (Invoke) Token: 0x060044F0 RID: 17648
		private unsafe delegate void Delegate_alDeleteAuxiliaryEffectSlots(int n, [In] uint* slots);

		// Token: 0x02000564 RID: 1380
		// (Invoke) Token: 0x060044F4 RID: 17652
		private delegate bool Delegate_alIsAuxiliaryEffectSlot(uint slot);

		// Token: 0x02000565 RID: 1381
		// (Invoke) Token: 0x060044F8 RID: 17656
		private delegate void Delegate_alAuxiliaryEffectSloti(uint asid, EfxAuxiliaryi param, int value);

		// Token: 0x02000566 RID: 1382
		// (Invoke) Token: 0x060044FC RID: 17660
		private delegate void Delegate_alAuxiliaryEffectSlotf(uint asid, EfxAuxiliaryf param, float value);

		// Token: 0x02000567 RID: 1383
		// (Invoke) Token: 0x06004500 RID: 17664
		private unsafe delegate void Delegate_alGetAuxiliaryEffectSloti(uint asid, EfxAuxiliaryi pname, [Out] int* value);

		// Token: 0x02000568 RID: 1384
		// (Invoke) Token: 0x06004504 RID: 17668
		private unsafe delegate void Delegate_alGetAuxiliaryEffectSlotf(uint asid, EfxAuxiliaryf pname, [Out] float* value);
	}
}
