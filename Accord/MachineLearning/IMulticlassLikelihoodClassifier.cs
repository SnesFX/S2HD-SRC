using System;

namespace Accord.MachineLearning
{
	// Token: 0x0200003F RID: 63
	public interface IMulticlassLikelihoodClassifier<TInput, TClasses> : IMulticlassOutLikelihoodClassifier<TInput, TClasses>, IMulticlassOutScoreClassifier<TInput, TClasses>, IMulticlassScoreClassifierBase<TInput, TClasses>, IMultilabelOutScoreClassifier<TInput, TClasses>, IMultilabelScoreClassifierBase<TInput, TClasses>, IMultilabelOutLikelihoodClassifier<TInput, TClasses>, IMultilabelLikelihoodClassifierBase<TInput, TClasses>, IMulticlassLikelihoodClassifierBase<TInput, TClasses>, IMulticlassRefLikelihoodClassifier<TInput, TClasses[]>, IMulticlassRefScoreClassifier<TInput, TClasses[]>, IMultilabelRefScoreClassifier<TInput, TClasses[]>, IMultilabelScoreClassifierBase<TInput, TClasses[]>, IMultilabelRefLikelihoodClassifier<TInput, TClasses[]>, IMultilabelLikelihoodClassifierBase<TInput, TClasses[]>, IMulticlassScoreClassifier<TInput, TClasses>, IClassifier<TInput, TClasses>, IClassifier, ITransform<TInput, TClasses>, ITransform
	{
	}
}
