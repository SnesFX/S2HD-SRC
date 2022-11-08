using System;

namespace Accord.MachineLearning
{
	// Token: 0x0200005E RID: 94
	public interface IRegression<TInput> : IRegression<TInput, double>, ITransform<TInput, double>, ITransform, IRegression<TInput, float>, ITransform<TInput, float>
	{
	}
}
