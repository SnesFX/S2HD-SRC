using System;

namespace Accord.MachineLearning
{
	// Token: 0x0200003A RID: 58
	public interface IMulticlassScoreClassifier<TInput, TClasses> : IMulticlassOutScoreClassifier<TInput, TClasses>, IMulticlassScoreClassifierBase<TInput, TClasses>, IMultilabelOutScoreClassifier<TInput, TClasses>, IMultilabelScoreClassifierBase<TInput, TClasses>, IMulticlassRefScoreClassifier<TInput, TClasses[]>, IMultilabelRefScoreClassifier<TInput, TClasses[]>, IMultilabelScoreClassifierBase<TInput, TClasses[]>, IClassifier<TInput, TClasses>, IClassifier, ITransform<TInput, TClasses>, ITransform
	{
	}
}
