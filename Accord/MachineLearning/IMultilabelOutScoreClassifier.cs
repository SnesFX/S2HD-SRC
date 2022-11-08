using System;

namespace Accord.MachineLearning
{
	// Token: 0x02000046 RID: 70
	public interface IMultilabelOutScoreClassifier<TInput, TClasses> : IMultilabelScoreClassifierBase<TInput, TClasses>
	{
		// Token: 0x06000205 RID: 517
		double[] Scores(TInput input, out TClasses decision);

		// Token: 0x06000206 RID: 518
		double[] Scores(TInput input, out TClasses decision, double[] result);
	}
}
