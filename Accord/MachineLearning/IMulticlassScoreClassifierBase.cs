using System;

namespace Accord.MachineLearning
{
	// Token: 0x02000037 RID: 55
	public interface IMulticlassScoreClassifierBase<in TInput, TClasses>
	{
		// Token: 0x060001E8 RID: 488
		double[] Score(TInput[] input, ref TClasses[] decision);

		// Token: 0x060001E9 RID: 489
		double[] Score(TInput[] input, ref TClasses[] decision, double[] result);
	}
}
