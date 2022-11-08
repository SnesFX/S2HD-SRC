using System;
using System.Collections.Generic;
using System.IO;

namespace Hjg.Pngcs.Chunks
{
	// Token: 0x02000046 RID: 70
	public abstract class PngChunk
	{
		// Token: 0x17000065 RID: 101
		// (get) Token: 0x0600024F RID: 591 RVA: 0x00009D66 File Offset: 0x00007F66
		// (set) Token: 0x06000250 RID: 592 RVA: 0x00009D6E File Offset: 0x00007F6E
		public bool Priority { get; set; }

		// Token: 0x17000066 RID: 102
		// (get) Token: 0x06000251 RID: 593 RVA: 0x00009D77 File Offset: 0x00007F77
		// (set) Token: 0x06000252 RID: 594 RVA: 0x00009D7F File Offset: 0x00007F7F
		public int ChunkGroup { get; set; }

		// Token: 0x17000067 RID: 103
		// (get) Token: 0x06000253 RID: 595 RVA: 0x00009D88 File Offset: 0x00007F88
		// (set) Token: 0x06000254 RID: 596 RVA: 0x00009D90 File Offset: 0x00007F90
		public int Length { get; set; }

		// Token: 0x17000068 RID: 104
		// (get) Token: 0x06000255 RID: 597 RVA: 0x00009D99 File Offset: 0x00007F99
		// (set) Token: 0x06000256 RID: 598 RVA: 0x00009DA1 File Offset: 0x00007FA1
		public long Offset { get; set; }

		// Token: 0x06000257 RID: 599 RVA: 0x00009DAC File Offset: 0x00007FAC
		protected PngChunk(string id, ImageInfo imgInfo)
		{
			this.Id = id;
			this.ImgInfo = imgInfo;
			this.Crit = ChunkHelper.IsCritical(id);
			this.Pub = ChunkHelper.IsPublic(id);
			this.Safe = ChunkHelper.IsSafeToCopy(id);
			this.Priority = false;
			this.ChunkGroup = -1;
			this.Length = -1;
			this.Offset = 0L;
		}

		// Token: 0x06000258 RID: 600 RVA: 0x00009E10 File Offset: 0x00008010
		private static Dictionary<string, Type> initFactory()
		{
			return new Dictionary<string, Type>
			{
				{
					"IDAT",
					typeof(PngChunkIDAT)
				},
				{
					"IHDR",
					typeof(PngChunkIHDR)
				},
				{
					"PLTE",
					typeof(PngChunkPLTE)
				},
				{
					"IEND",
					typeof(PngChunkIEND)
				},
				{
					"tEXt",
					typeof(PngChunkTEXT)
				},
				{
					"iTXt",
					typeof(PngChunkITXT)
				},
				{
					"zTXt",
					typeof(PngChunkZTXT)
				},
				{
					"bKGD",
					typeof(PngChunkBKGD)
				},
				{
					"gAMA",
					typeof(PngChunkGAMA)
				},
				{
					"pHYs",
					typeof(PngChunkPHYS)
				},
				{
					"iCCP",
					typeof(PngChunkICCP)
				},
				{
					"tIME",
					typeof(PngChunkTIME)
				},
				{
					"tRNS",
					typeof(PngChunkTRNS)
				},
				{
					"cHRM",
					typeof(PngChunkCHRM)
				},
				{
					"sBIT",
					typeof(PngChunkSBIT)
				},
				{
					"sRGB",
					typeof(PngChunkSRGB)
				},
				{
					"hIST",
					typeof(PngChunkHIST)
				},
				{
					"sPLT",
					typeof(PngChunkSPLT)
				},
				{
					"oFFs",
					typeof(PngChunkOFFS)
				},
				{
					"sTER",
					typeof(PngChunkSTER)
				}
			};
		}

		// Token: 0x06000259 RID: 601 RVA: 0x00009FC6 File Offset: 0x000081C6
		public static void FactoryRegister(string chunkId, Type type)
		{
			PngChunk.factoryMap.Add(chunkId, type);
		}

		// Token: 0x0600025A RID: 602 RVA: 0x00009FD4 File Offset: 0x000081D4
		internal static bool isKnown(string id)
		{
			return PngChunk.factoryMap.ContainsKey(id);
		}

		// Token: 0x0600025B RID: 603 RVA: 0x00009FE1 File Offset: 0x000081E1
		internal bool mustGoBeforePLTE()
		{
			return this.GetOrderingConstraint() == PngChunk.ChunkOrderingConstraint.BEFORE_PLTE_AND_IDAT;
		}

		// Token: 0x0600025C RID: 604 RVA: 0x00009FEC File Offset: 0x000081EC
		internal bool mustGoBeforeIDAT()
		{
			PngChunk.ChunkOrderingConstraint orderingConstraint = this.GetOrderingConstraint();
			return orderingConstraint == PngChunk.ChunkOrderingConstraint.BEFORE_IDAT || orderingConstraint == PngChunk.ChunkOrderingConstraint.BEFORE_PLTE_AND_IDAT || orderingConstraint == PngChunk.ChunkOrderingConstraint.AFTER_PLTE_BEFORE_IDAT;
		}

		// Token: 0x0600025D RID: 605 RVA: 0x0000A00E File Offset: 0x0000820E
		internal bool mustGoAfterPLTE()
		{
			return this.GetOrderingConstraint() == PngChunk.ChunkOrderingConstraint.AFTER_PLTE_BEFORE_IDAT;
		}

		// Token: 0x0600025E RID: 606 RVA: 0x0000A019 File Offset: 0x00008219
		internal static PngChunk Factory(ChunkRaw chunk, ImageInfo info)
		{
			PngChunk pngChunk = PngChunk.FactoryFromId(ChunkHelper.ToString(chunk.IdBytes), info);
			pngChunk.Length = chunk.Length;
			pngChunk.ParseFromRaw(chunk);
			return pngChunk;
		}

		// Token: 0x0600025F RID: 607 RVA: 0x0000A040 File Offset: 0x00008240
		internal static PngChunk FactoryFromId(string cid, ImageInfo info)
		{
			PngChunk pngChunk = null;
			if (PngChunk.factoryMap == null)
			{
				PngChunk.initFactory();
			}
			if (PngChunk.isKnown(cid))
			{
				Type type = PngChunk.factoryMap[cid];
				if (type == null)
				{
					Console.Error.WriteLine("What?? " + cid);
				}
				pngChunk = (PngChunk)type.GetConstructor(new Type[]
				{
					typeof(ImageInfo)
				}).Invoke(new object[]
				{
					info
				});
			}
			if (pngChunk == null)
			{
				pngChunk = new PngChunkUNKNOWN(cid, info);
			}
			return pngChunk;
		}

		// Token: 0x06000260 RID: 608 RVA: 0x0000A0C6 File Offset: 0x000082C6
		public ChunkRaw createEmptyChunk(int len, bool alloc)
		{
			return new ChunkRaw(len, ChunkHelper.ToBytes(this.Id), alloc);
		}

		// Token: 0x06000261 RID: 609 RVA: 0x0000A0DC File Offset: 0x000082DC
		public static T CloneChunk<T>(T chunk, ImageInfo info) where T : PngChunk
		{
			PngChunk pngChunk = PngChunk.FactoryFromId(chunk.Id, info);
			if (pngChunk.GetType() != chunk.GetType())
			{
				throw new PngjException(string.Concat(new object[]
				{
					"bad class cloning chunk: ",
					pngChunk.GetType(),
					" ",
					chunk.GetType()
				}));
			}
			pngChunk.CloneDataFromRead(chunk);
			return (T)((object)pngChunk);
		}

		// Token: 0x06000262 RID: 610 RVA: 0x0000A158 File Offset: 0x00008358
		internal void write(Stream os)
		{
			ChunkRaw chunkRaw = this.CreateRawChunk();
			if (chunkRaw == null)
			{
				throw new PngjException("null chunk ! creation failed for " + this);
			}
			chunkRaw.WriteChunk(os);
		}

		// Token: 0x06000263 RID: 611 RVA: 0x0000A17C File Offset: 0x0000837C
		public override string ToString()
		{
			return string.Concat(new object[]
			{
				"chunk id= ",
				this.Id,
				" (len=",
				this.Length,
				" off=",
				this.Offset,
				") c=",
				base.GetType().Name
			});
		}

		// Token: 0x06000264 RID: 612
		public abstract ChunkRaw CreateRawChunk();

		// Token: 0x06000265 RID: 613
		public abstract void ParseFromRaw(ChunkRaw c);

		// Token: 0x06000266 RID: 614
		public abstract void CloneDataFromRead(PngChunk other);

		// Token: 0x06000267 RID: 615
		public abstract bool AllowsMultiple();

		// Token: 0x06000268 RID: 616
		public abstract PngChunk.ChunkOrderingConstraint GetOrderingConstraint();

		// Token: 0x04000123 RID: 291
		public readonly string Id;

		// Token: 0x04000124 RID: 292
		public readonly bool Crit;

		// Token: 0x04000125 RID: 293
		public readonly bool Pub;

		// Token: 0x04000126 RID: 294
		public readonly bool Safe;

		// Token: 0x04000127 RID: 295
		protected readonly ImageInfo ImgInfo;

		// Token: 0x0400012C RID: 300
		private static Dictionary<string, Type> factoryMap = PngChunk.initFactory();

		// Token: 0x020001B0 RID: 432
		public enum ChunkOrderingConstraint
		{
			// Token: 0x04000A46 RID: 2630
			NONE,
			// Token: 0x04000A47 RID: 2631
			BEFORE_PLTE_AND_IDAT,
			// Token: 0x04000A48 RID: 2632
			AFTER_PLTE_BEFORE_IDAT,
			// Token: 0x04000A49 RID: 2633
			BEFORE_IDAT,
			// Token: 0x04000A4A RID: 2634
			NA
		}
	}
}
