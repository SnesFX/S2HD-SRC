using System;

namespace Accord.MachineLearning
{
	// Token: 0x02000047 RID: 71
	public interface IMultilabelScoreClassifier<TInput, TClasses> : IMultilabelOutScoreClassifier<TInput, TClasses>, IMultilabelScoreClassifierBase<TInput, TClasses>, IMultilabelRefScoreClassifier<TInput, TClasses[]>, IMultilabelScoreClassifierBase<TInput, TClasses[]>, IClassifier<TInput, TClasses>, IClassifier, ITransform<TInput, TClasses>, ITransform
	{
	}
}
