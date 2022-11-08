using System;

namespace Accord.MachineLearning
{
	// Token: 0x0200004C RID: 76
	public interface IMultilabelLikelihoodClassifier<TInput, TClasses> : IMultilabelOutLikelihoodClassifier<TInput, TClasses>, IMultilabelLikelihoodClassifierBase<TInput, TClasses>, IMultilabelScoreClassifierBase<TInput, TClasses>, IMultilabelOutScoreClassifier<TInput, TClasses>, IMultilabelRefLikelihoodClassifier<TInput, TClasses[]>, IMultilabelLikelihoodClassifierBase<TInput, TClasses[]>, IMultilabelScoreClassifierBase<TInput, TClasses[]>, IMultilabelRefScoreClassifier<TInput, TClasses[]>
	{
	}
}
