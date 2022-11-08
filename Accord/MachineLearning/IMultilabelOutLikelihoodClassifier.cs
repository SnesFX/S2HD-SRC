using System;

namespace Accord.MachineLearning
{
	// Token: 0x0200004A RID: 74
	public interface IMultilabelOutLikelihoodClassifier<TInput, TClasses> : IMultilabelLikelihoodClassifierBase<TInput, TClasses>, IMultilabelScoreClassifierBase<TInput, TClasses>, IMultilabelOutScoreClassifier<TInput, TClasses>
	{
		// Token: 0x06000216 RID: 534
		double[] Probabilities(TInput input, out TClasses decision);

		// Token: 0x06000217 RID: 535
		double[] Probabilities(TInput input, out TClasses decision, double[] result);

		// Token: 0x06000218 RID: 536
		double[] LogLikelihoods(TInput input, out TClasses decision);

		// Token: 0x06000219 RID: 537
		double[] LogLikelihoods(TInput input, out TClasses decision, double[] result);
	}
}
