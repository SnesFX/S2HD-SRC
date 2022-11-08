using System;

namespace Accord.MachineLearning
{
	// Token: 0x02000033 RID: 51
	public interface IClassifier<in TInput, TClasses> : IClassifier, ITransform<TInput, TClasses>, ITransform
	{
		// Token: 0x060001E2 RID: 482
		TClasses Decide(TInput input);

		// Token: 0x060001E3 RID: 483
		TClasses[] Decide(TInput[] input);

		// Token: 0x060001E4 RID: 484
		TClasses[] Decide(TInput[] input, TClasses[] result);
	}
}
