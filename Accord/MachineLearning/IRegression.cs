using System;

namespace Accord.MachineLearning
{
	// Token: 0x0200005D RID: 93
	public interface IRegression<TInput, TOutput> : ITransform<TInput, TOutput>, ITransform
	{
		// Token: 0x06000268 RID: 616
		TOutput Regress(TInput input);

		// Token: 0x06000269 RID: 617
		TOutput[] Regress(TInput[] input);

		// Token: 0x0600026A RID: 618
		TOutput[] Regress(TInput[] input, TOutput[] result);
	}
}
