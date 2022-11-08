using System;

namespace Accord.MachineLearning
{
	// Token: 0x02000041 RID: 65
	public interface IMultilabelClassifier<in TInput, TClasses> : IClassifier<TInput, TClasses>, IClassifier, ITransform<TInput, TClasses>, ITransform
	{
		// Token: 0x06000200 RID: 512
		TClasses Decide(TInput input, TClasses result);
	}
}
