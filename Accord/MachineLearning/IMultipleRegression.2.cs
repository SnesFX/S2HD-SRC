using System;

namespace Accord.MachineLearning
{
	// Token: 0x0200005C RID: 92
	public interface IMultipleRegression<TInput> : IMultipleRegression<TInput, double>, IRegression<TInput, double[]>, ITransform<TInput, double[]>, ITransform, IMultipleRegression<TInput, float>, IRegression<TInput, float[]>, ITransform<TInput, float[]>
	{
	}
}
