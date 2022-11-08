using System;

namespace Accord.MachineLearning
{
	// Token: 0x02000045 RID: 69
	public interface IMultilabelRefScoreClassifier<TInput, TClasses> : IMultilabelScoreClassifierBase<TInput, TClasses>
	{
		// Token: 0x06000203 RID: 515
		double[] Scores(TInput input, ref TClasses decision);

		// Token: 0x06000204 RID: 516
		double[] Scores(TInput input, ref TClasses decision, double[] result);
	}
}
