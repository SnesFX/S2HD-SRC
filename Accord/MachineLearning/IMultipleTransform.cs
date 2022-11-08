using System;

namespace Accord.MachineLearning
{
	// Token: 0x02000059 RID: 89
	public interface IMultipleTransform<in TInput, TOutput> : ITransform<TInput, TOutput>, ITransform
	{
		// Token: 0x06000267 RID: 615
		TOutput[] Transform(TInput[] input, TOutput result);
	}
}
