using System;

namespace Accord.MachineLearning
{
	// Token: 0x02000057 RID: 87
	public interface ITransform
	{
		// Token: 0x17000031 RID: 49
		// (get) Token: 0x06000260 RID: 608
		// (set) Token: 0x06000261 RID: 609
		int NumberOfInputs { get; set; }

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x06000262 RID: 610
		// (set) Token: 0x06000263 RID: 611
		int NumberOfOutputs { get; set; }
	}
}
