using System;

namespace Accord
{
	// Token: 0x02000015 RID: 21
	[Obsolete("Prefer the use of ThreadLocal over shared Random objects.")]
	public sealed class ThreadSafeRandom : Random
	{
		// Token: 0x060000C6 RID: 198 RVA: 0x00003411 File Offset: 0x00002411
		public ThreadSafeRandom()
		{
		}

		// Token: 0x060000C7 RID: 199 RVA: 0x00003424 File Offset: 0x00002424
		public ThreadSafeRandom(int seed) : base(seed)
		{
		}

		// Token: 0x060000C8 RID: 200 RVA: 0x00003438 File Offset: 0x00002438
		public override int Next()
		{
			object obj = this.sync;
			int result;
			lock (obj)
			{
				result = base.Next();
			}
			return result;
		}

		// Token: 0x060000C9 RID: 201 RVA: 0x0000347C File Offset: 0x0000247C
		public override int Next(int maxValue)
		{
			object obj = this.sync;
			int result;
			lock (obj)
			{
				result = base.Next(maxValue);
			}
			return result;
		}

		// Token: 0x060000CA RID: 202 RVA: 0x000034C0 File Offset: 0x000024C0
		public override int Next(int minValue, int maxValue)
		{
			object obj = this.sync;
			int result;
			lock (obj)
			{
				result = base.Next(minValue, maxValue);
			}
			return result;
		}

		// Token: 0x060000CB RID: 203 RVA: 0x00003504 File Offset: 0x00002504
		public override void NextBytes(byte[] buffer)
		{
			object obj = this.sync;
			lock (obj)
			{
				base.NextBytes(buffer);
			}
		}

		// Token: 0x060000CC RID: 204 RVA: 0x00003548 File Offset: 0x00002548
		public override double NextDouble()
		{
			object obj = this.sync;
			double result;
			lock (obj)
			{
				result = base.NextDouble();
			}
			return result;
		}

		// Token: 0x04000014 RID: 20
		private object sync = new object();
	}
}
