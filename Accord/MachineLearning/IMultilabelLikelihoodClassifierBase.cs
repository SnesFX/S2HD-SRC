using System;

namespace Accord.MachineLearning
{
	// Token: 0x02000049 RID: 73
	public interface IMultilabelLikelihoodClassifierBase<TInput, TClasses> : IMultilabelScoreClassifierBase<TInput, TClasses>
	{
		// Token: 0x06000212 RID: 530
		double[][] Probabilities(TInput[] input, ref TClasses[] decision);

		// Token: 0x06000213 RID: 531
		double[][] Probabilities(TInput[] input, ref TClasses[] decision, double[][] result);

		// Token: 0x06000214 RID: 532
		double[][] LogLikelihoods(TInput[] input, ref TClasses[] decision);

		// Token: 0x06000215 RID: 533
		double[][] LogLikelihoods(TInput[] input, ref TClasses[] decision, double[][] result);
	}
}
