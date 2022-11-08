using System;

namespace Accord.MachineLearning
{
	// Token: 0x02000058 RID: 88
	public interface ITransform<in TInput, TOutput> : ITransform
	{
		// Token: 0x06000264 RID: 612
		TOutput Transform(TInput input);

		// Token: 0x06000265 RID: 613
		TOutput[] Transform(TInput[] input);

		// Token: 0x06000266 RID: 614
		TOutput[] Transform(TInput[] input, TOutput[] result);
	}
}
