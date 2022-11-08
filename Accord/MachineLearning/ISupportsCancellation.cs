using System;
using System.Threading;

namespace Accord.MachineLearning
{
	// Token: 0x02000056 RID: 86
	public interface ISupportsCancellation
	{
		// Token: 0x17000030 RID: 48
		// (get) Token: 0x0600025E RID: 606
		// (set) Token: 0x0600025F RID: 607
		CancellationToken Token { get; set; }
	}
}
