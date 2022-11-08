using System;

namespace Hjg.Pngcs.Chunks
{
	// Token: 0x0200004B RID: 75
	public class PngChunkICCP : PngChunkSingle
	{
		// Token: 0x0600028B RID: 651 RVA: 0x0000A96F File Offset: 0x00008B6F
		public PngChunkICCP(ImageInfo info) : base("iCCP", info)
		{
		}

		// Token: 0x0600028C RID: 652 RVA: 0x00006340 File Offset: 0x00004540
		public override PngChunk.ChunkOrderingConstraint GetOrderingConstraint()
		{
			return PngChunk.ChunkOrderingConstraint.BEFORE_PLTE_AND_IDAT;
		}

		// Token: 0x0600028D RID: 653 RVA: 0x0000A980 File Offset: 0x00008B80
		public override ChunkRaw CreateRawChunk()
		{
			ChunkRaw chunkRaw = base.createEmptyChunk(this.profileName.Length + this.compressedProfile.Length + 2, true);
			Array.Copy(ChunkHelper.ToBytes(this.profileName), 0, chunkRaw.Data, 0, this.profileName.Length);
			chunkRaw.Data[this.profileName.Length] = 0;
			chunkRaw.Data[this.profileName.Length + 1] = 0;
			Array.Copy(this.compressedProfile, 0, chunkRaw.Data, this.profileName.Length + 2, this.compressedProfile.Length);
			return chunkRaw;
		}

		// Token: 0x0600028E RID: 654 RVA: 0x0000AA20 File Offset: 0x00008C20
		public override void ParseFromRaw(ChunkRaw chunk)
		{
			int num = ChunkHelper.PosNullByte(chunk.Data);
			this.profileName = PngHelperInternal.charsetLatin1.GetString(chunk.Data, 0, num);
			if ((chunk.Data[num + 1] & 255) != 0)
			{
				throw new Exception("bad compression for ChunkTypeICCP");
			}
			int num2 = chunk.Data.Length - (num + 2);
			this.compressedProfile = new byte[num2];
			Array.Copy(chunk.Data, num + 2, this.compressedProfile, 0, num2);
		}

		// Token: 0x0600028F RID: 655 RVA: 0x0000AAA0 File Offset: 0x00008CA0
		public override void CloneDataFromRead(PngChunk other)
		{
			PngChunkICCP pngChunkICCP = (PngChunkICCP)other;
			this.profileName = pngChunkICCP.profileName;
			this.compressedProfile = new byte[pngChunkICCP.compressedProfile.Length];
			Array.Copy(pngChunkICCP.compressedProfile, this.compressedProfile, this.compressedProfile.Length);
		}

		// Token: 0x06000290 RID: 656 RVA: 0x0000AAEC File Offset: 0x00008CEC
		public void SetProfileNameAndContent(string name, string profile)
		{
			this.SetProfileNameAndContent(name, ChunkHelper.ToBytes(this.profileName));
		}

		// Token: 0x06000291 RID: 657 RVA: 0x0000AB00 File Offset: 0x00008D00
		public void SetProfileNameAndContent(string name, byte[] profile)
		{
			this.profileName = name;
			this.compressedProfile = ChunkHelper.compressBytes(profile, true);
		}

		// Token: 0x06000292 RID: 658 RVA: 0x0000AB16 File Offset: 0x00008D16
		public string GetProfileName()
		{
			return this.profileName;
		}

		// Token: 0x06000293 RID: 659 RVA: 0x0000AB1E File Offset: 0x00008D1E
		public byte[] GetProfile()
		{
			return ChunkHelper.compressBytes(this.compressedProfile, false);
		}

		// Token: 0x06000294 RID: 660 RVA: 0x0000AB2C File Offset: 0x00008D2C
		public string GetProfileAsString()
		{
			return ChunkHelper.ToString(this.GetProfile());
		}

		// Token: 0x04000140 RID: 320
		public const string ID = "iCCP";

		// Token: 0x04000141 RID: 321
		private string profileName;

		// Token: 0x04000142 RID: 322
		private byte[] compressedProfile;
	}
}
