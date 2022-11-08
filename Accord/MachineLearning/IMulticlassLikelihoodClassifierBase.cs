using System;

namespace Accord.MachineLearning
{
	// Token: 0x0200003C RID: 60
	public interface IMulticlassLikelihoodClassifierBase<TInput, TClasses> : IMulticlassScoreClassifierBase<TInput, TClasses>
	{
		// Token: 0x060001F1 RID: 497
		double[] Probability(TInput[] input, ref TClasses[] decision);

		// Token: 0x060001F2 RID: 498
		double[] Probability(TInput[] input, ref TClasses[] decision, double[] result);

		// Token: 0x060001F3 RID: 499
		double[] LogLikelihood(TInput[] input, ref TClasses[] decision);

		// Token: 0x060001F4 RID: 500
		double[] LogLikelihood(TInput[] input, ref TClasses[] decision, double[] result);
	}
}
