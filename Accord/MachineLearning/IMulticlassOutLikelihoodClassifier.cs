using System;

namespace Accord.MachineLearning
{
	// Token: 0x0200003D RID: 61
	public interface IMulticlassOutLikelihoodClassifier<TInput, TClasses> : IMulticlassOutScoreClassifier<TInput, TClasses>, IMulticlassScoreClassifierBase<TInput, TClasses>, IMultilabelOutScoreClassifier<TInput, TClasses>, IMultilabelScoreClassifierBase<TInput, TClasses>, IMultilabelOutLikelihoodClassifier<TInput, TClasses>, IMultilabelLikelihoodClassifierBase<TInput, TClasses>, IMulticlassLikelihoodClassifierBase<TInput, TClasses>
	{
		// Token: 0x060001F5 RID: 501
		double Probability(TInput input, out TClasses decision);

		// Token: 0x060001F6 RID: 502
		double LogLikelihood(TInput input, out TClasses decision);
	}
}
