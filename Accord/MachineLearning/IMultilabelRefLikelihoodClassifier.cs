using System;

namespace Accord.MachineLearning
{
	// Token: 0x0200004B RID: 75
	public interface IMultilabelRefLikelihoodClassifier<TInput, TClasses> : IMultilabelLikelihoodClassifierBase<TInput, TClasses>, IMultilabelScoreClassifierBase<TInput, TClasses>, IMultilabelRefScoreClassifier<TInput, TClasses>
	{
		// Token: 0x0600021A RID: 538
		double[] Probabilities(TInput input, ref TClasses decision);

		// Token: 0x0600021B RID: 539
		double[] Probabilities(TInput input, ref TClasses decision, double[] result);

		// Token: 0x0600021C RID: 540
		double[] LogLikelihoods(TInput input, ref TClasses decision);

		// Token: 0x0600021D RID: 541
		double[] LogLikelihoods(TInput input, ref TClasses decision, double[] result);
	}
}
