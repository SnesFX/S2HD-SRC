using System;

namespace Hjg.Pngcs.Chunks
{
	// Token: 0x0200005B RID: 91
	public abstract class PngChunkTextVar : PngChunkMultiple
	{
		// Token: 0x0600031C RID: 796 RVA: 0x0000BE88 File Offset: 0x0000A088
		protected internal PngChunkTextVar(string id, ImageInfo info) : base(id, info)
		{
		}

		// Token: 0x0600031D RID: 797 RVA: 0x0000225B File Offset: 0x0000045B
		public override PngChunk.ChunkOrderingConstraint GetOrderingConstraint()
		{
			return PngChunk.ChunkOrderingConstraint.NONE;
		}

		// Token: 0x0600031E RID: 798 RVA: 0x0000BE92 File Offset: 0x0000A092
		public string GetKey()
		{
			return this.key;
		}

		// Token: 0x0600031F RID: 799 RVA: 0x0000BE9A File Offset: 0x0000A09A
		public string GetVal()
		{
			return this.val;
		}

		// Token: 0x06000320 RID: 800 RVA: 0x0000BEA2 File Offset: 0x0000A0A2
		public void SetKeyVal(string key, string val)
		{
			this.key = key;
			this.val = val;
		}

		// Token: 0x0400016F RID: 367
		protected internal string key;

		// Token: 0x04000170 RID: 368
		protected internal string val;

		// Token: 0x04000171 RID: 369
		public const string KEY_Title = "Title";

		// Token: 0x04000172 RID: 370
		public const string KEY_Author = "Author";

		// Token: 0x04000173 RID: 371
		public const string KEY_Description = "Description";

		// Token: 0x04000174 RID: 372
		public const string KEY_Copyright = "Copyright";

		// Token: 0x04000175 RID: 373
		public const string KEY_Creation_Time = "Creation Time";

		// Token: 0x04000176 RID: 374
		public const string KEY_Software = "Software";

		// Token: 0x04000177 RID: 375
		public const string KEY_Disclaimer = "Disclaimer";

		// Token: 0x04000178 RID: 376
		public const string KEY_Warning = "Warning";

		// Token: 0x04000179 RID: 377
		public const string KEY_Source = "Source";

		// Token: 0x0400017A RID: 378
		public const string KEY_Comment = "Comment";

		// Token: 0x020001B1 RID: 433
		public class PngTxtInfo
		{
			// Token: 0x04000A4B RID: 2635
			public string title;

			// Token: 0x04000A4C RID: 2636
			public string author;

			// Token: 0x04000A4D RID: 2637
			public string description;

			// Token: 0x04000A4E RID: 2638
			public string creation_time;

			// Token: 0x04000A4F RID: 2639
			public string software;

			// Token: 0x04000A50 RID: 2640
			public string disclaimer;

			// Token: 0x04000A51 RID: 2641
			public string warning;

			// Token: 0x04000A52 RID: 2642
			public string source;

			// Token: 0x04000A53 RID: 2643
			public string comment;
		}
	}
}
