using System;
using System.Threading.Tasks;

namespace Accord.MachineLearning
{
	// Token: 0x02000055 RID: 85
	public interface IParallel : ISupportsCancellation
	{
		// Token: 0x1700002F RID: 47
		// (get) Token: 0x0600025C RID: 604
		// (set) Token: 0x0600025D RID: 605
		ParallelOptions ParallelOptions { get; set; }
	}
}
