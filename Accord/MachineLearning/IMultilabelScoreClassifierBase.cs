using System;

namespace Accord.MachineLearning
{
	// Token: 0x02000044 RID: 68
	public interface IMultilabelScoreClassifierBase<in TInput, TClasses>
	{
		// Token: 0x06000201 RID: 513
		double[][] Scores(TInput[] input, ref TClasses[] decision);

		// Token: 0x06000202 RID: 514
		double[][] Scores(TInput[] input, ref TClasses[] decision, double[][] result);
	}
}
