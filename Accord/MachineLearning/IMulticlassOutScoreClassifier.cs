using System;

namespace Accord.MachineLearning
{
	// Token: 0x02000038 RID: 56
	public interface IMulticlassOutScoreClassifier<TInput, TClasses> : IMulticlassScoreClassifierBase<TInput, TClasses>, IMultilabelOutScoreClassifier<TInput, TClasses>, IMultilabelScoreClassifierBase<TInput, TClasses>
	{
		// Token: 0x060001EA RID: 490
		double Score(TInput input, out TClasses decision);
	}
}
