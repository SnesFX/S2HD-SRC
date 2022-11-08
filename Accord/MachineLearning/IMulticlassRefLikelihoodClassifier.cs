using System;

namespace Accord.MachineLearning
{
	// Token: 0x0200003E RID: 62
	public interface IMulticlassRefLikelihoodClassifier<TInput, TClasses> : IMulticlassRefScoreClassifier<TInput, TClasses>, IMultilabelRefScoreClassifier<TInput, TClasses>, IMultilabelScoreClassifierBase<TInput, TClasses>, IMultilabelRefLikelihoodClassifier<TInput, TClasses>, IMultilabelLikelihoodClassifierBase<TInput, TClasses>
	{
	}
}
