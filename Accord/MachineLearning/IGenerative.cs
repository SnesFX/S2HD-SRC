using System;

namespace Accord.MachineLearning
{
	// Token: 0x0200005F RID: 95
	public interface IGenerative<TInput> : ITransform<TInput, double>, ITransform
	{
		// Token: 0x0600026B RID: 619
		double LogLikelihood(TInput input);
	}
}
