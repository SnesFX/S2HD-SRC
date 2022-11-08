using System;

namespace Accord.MachineLearning
{
	// Token: 0x0200005B RID: 91
	public interface IMultipleRegression<TInput, TOutput> : IRegression<TInput, TOutput[]>, ITransform<TInput, TOutput[]>, ITransform
	{
	}
}
