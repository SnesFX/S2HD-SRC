using System;

namespace Accord.MachineLearning
{
	// Token: 0x02000052 RID: 82
	public interface ITagger<in TInput> : IMultilabelClassifier<TInput[], int[]>, IClassifier<TInput[], int[]>, IClassifier, ITransform<TInput[], int[]>, ITransform
	{
	}
}
