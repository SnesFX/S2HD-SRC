using System;
using System.IO;

namespace Hjg.Pngcs.Chunks
{
	// Token: 0x02000057 RID: 87
	public class PngChunkSPLT : PngChunkMultiple
	{
		// Token: 0x17000078 RID: 120
		// (get) Token: 0x060002FE RID: 766 RVA: 0x0000B917 File Offset: 0x00009B17
		// (set) Token: 0x060002FF RID: 767 RVA: 0x0000B91F File Offset: 0x00009B1F
		public string PalName { get; set; }

		// Token: 0x17000079 RID: 121
		// (get) Token: 0x06000300 RID: 768 RVA: 0x0000B928 File Offset: 0x00009B28
		// (set) Token: 0x06000301 RID: 769 RVA: 0x0000B930 File Offset: 0x00009B30
		public int SampleDepth { get; set; }

		// Token: 0x1700007A RID: 122
		// (get) Token: 0x06000302 RID: 770 RVA: 0x0000B939 File Offset: 0x00009B39
		// (set) Token: 0x06000303 RID: 771 RVA: 0x0000B941 File Offset: 0x00009B41
		public int[] Palette { get; set; }

		// Token: 0x06000304 RID: 772 RVA: 0x0000B94A File Offset: 0x00009B4A
		public PngChunkSPLT(ImageInfo info) : base("sPLT", info)
		{
			this.PalName = "";
		}

		// Token: 0x06000305 RID: 773 RVA: 0x0000B057 File Offset: 0x00009257
		public override PngChunk.ChunkOrderingConstraint GetOrderingConstraint()
		{
			return PngChunk.ChunkOrderingConstraint.BEFORE_IDAT;
		}

		// Token: 0x06000306 RID: 774 RVA: 0x0000B964 File Offset: 0x00009B64
		public override ChunkRaw CreateRawChunk()
		{
			MemoryStream memoryStream = new MemoryStream();
			ChunkHelper.WriteBytesToStream(memoryStream, ChunkHelper.ToBytes(this.PalName));
			memoryStream.WriteByte(0);
			memoryStream.WriteByte((byte)this.SampleDepth);
			int nentries = this.GetNentries();
			for (int i = 0; i < nentries; i++)
			{
				for (int j = 0; j < 4; j++)
				{
					if (this.SampleDepth == 8)
					{
						PngHelperInternal.WriteByte(memoryStream, (byte)this.Palette[i * 5 + j]);
					}
					else
					{
						PngHelperInternal.WriteInt2(memoryStream, this.Palette[i * 5 + j]);
					}
				}
				PngHelperInternal.WriteInt2(memoryStream, this.Palette[i * 5 + 4]);
			}
			byte[] array = memoryStream.ToArray();
			ChunkRaw chunkRaw = base.createEmptyChunk(array.Length, false);
			chunkRaw.Data = array;
			return chunkRaw;
		}

		// Token: 0x06000307 RID: 775 RVA: 0x0000BA1C File Offset: 0x00009C1C
		public override void ParseFromRaw(ChunkRaw c)
		{
			int num = -1;
			for (int i = 0; i < c.Data.Length; i++)
			{
				if (c.Data[i] == 0)
				{
					num = i;
					break;
				}
			}
			if (num <= 0 || num > c.Data.Length - 2)
			{
				throw new PngjException("bad sPLT chunk: no separator found");
			}
			this.PalName = ChunkHelper.ToString(c.Data, 0, num);
			this.SampleDepth = PngHelperInternal.ReadInt1fromByte(c.Data, num + 1);
			num += 2;
			int num2 = (c.Data.Length - num) / ((this.SampleDepth == 8) ? 6 : 10);
			this.Palette = new int[num2 * 5];
			int num3 = 0;
			for (int j = 0; j < num2; j++)
			{
				int num4;
				int num5;
				int num6;
				int num7;
				if (this.SampleDepth == 8)
				{
					num4 = PngHelperInternal.ReadInt1fromByte(c.Data, num++);
					num5 = PngHelperInternal.ReadInt1fromByte(c.Data, num++);
					num6 = PngHelperInternal.ReadInt1fromByte(c.Data, num++);
					num7 = PngHelperInternal.ReadInt1fromByte(c.Data, num++);
				}
				else
				{
					num4 = PngHelperInternal.ReadInt2fromBytes(c.Data, num);
					num += 2;
					num5 = PngHelperInternal.ReadInt2fromBytes(c.Data, num);
					num += 2;
					num6 = PngHelperInternal.ReadInt2fromBytes(c.Data, num);
					num += 2;
					num7 = PngHelperInternal.ReadInt2fromBytes(c.Data, num);
					num += 2;
				}
				int num8 = PngHelperInternal.ReadInt2fromBytes(c.Data, num);
				num += 2;
				this.Palette[num3++] = num4;
				this.Palette[num3++] = num5;
				this.Palette[num3++] = num6;
				this.Palette[num3++] = num7;
				this.Palette[num3++] = num8;
			}
		}

		// Token: 0x06000308 RID: 776 RVA: 0x0000BBD4 File Offset: 0x00009DD4
		public override void CloneDataFromRead(PngChunk other)
		{
			PngChunkSPLT pngChunkSPLT = (PngChunkSPLT)other;
			this.PalName = pngChunkSPLT.PalName;
			this.SampleDepth = pngChunkSPLT.SampleDepth;
			this.Palette = new int[pngChunkSPLT.Palette.Length];
			Array.Copy(pngChunkSPLT.Palette, 0, this.Palette, 0, this.Palette.Length);
		}

		// Token: 0x06000309 RID: 777 RVA: 0x0000BC2E File Offset: 0x00009E2E
		public int GetNentries()
		{
			return this.Palette.Length / 5;
		}

		// Token: 0x04000162 RID: 354
		public const string ID = "sPLT";
	}
}
