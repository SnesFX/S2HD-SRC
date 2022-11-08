using System;
using System.IO;

namespace Hjg.Pngcs
{
	// Token: 0x02000032 RID: 50
	internal abstract class ProgressiveOutputStream : MemoryStream
	{
		// Token: 0x060001CC RID: 460 RVA: 0x00008A62 File Offset: 0x00006C62
		public ProgressiveOutputStream(int size_0)
		{
			this.size = size_0;
			if (this.size < 8)
			{
				throw new PngjException("bad size for ProgressiveOutputStream: " + this.size);
			}
		}

		// Token: 0x060001CD RID: 461 RVA: 0x00008A95 File Offset: 0x00006C95
		public override void Close()
		{
			this.Flush();
			base.Close();
		}

		// Token: 0x060001CE RID: 462 RVA: 0x00008AA3 File Offset: 0x00006CA3
		public override void Flush()
		{
			base.Flush();
			this.CheckFlushBuffer(true);
		}

		// Token: 0x060001CF RID: 463 RVA: 0x00008AB2 File Offset: 0x00006CB2
		public override void Write(byte[] b, int off, int len)
		{
			base.Write(b, off, len);
			this.CheckFlushBuffer(false);
		}

		// Token: 0x060001D0 RID: 464 RVA: 0x00008AC4 File Offset: 0x00006CC4
		public void Write(byte[] b)
		{
			this.Write(b, 0, b.Length);
			this.CheckFlushBuffer(false);
		}

		// Token: 0x060001D1 RID: 465 RVA: 0x00008AD8 File Offset: 0x00006CD8
		private void CheckFlushBuffer(bool forced)
		{
			int num = (int)this.Position;
			byte[] buffer = this.GetBuffer();
			while (forced || num >= this.size)
			{
				int num2 = this.size;
				if (num2 > num)
				{
					num2 = num;
				}
				if (num2 == 0)
				{
					return;
				}
				this.FlushBuffer(buffer, num2);
				this.countFlushed += (long)num2;
				int num3 = num - num2;
				num = num3;
				this.Position = (long)num;
				if (num3 > 0)
				{
					Array.Copy(buffer, num2, buffer, 0, num3);
				}
			}
		}

		// Token: 0x060001D2 RID: 466
		protected abstract void FlushBuffer(byte[] b, int n);

		// Token: 0x060001D3 RID: 467 RVA: 0x00008B46 File Offset: 0x00006D46
		public long GetCountFlushed()
		{
			return this.countFlushed;
		}

		// Token: 0x040000C6 RID: 198
		private readonly int size;

		// Token: 0x040000C7 RID: 199
		private long countFlushed;
	}
}
