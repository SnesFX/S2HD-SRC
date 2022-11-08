using System;

namespace Accord.MachineLearning
{
	// Token: 0x02000042 RID: 66
	public interface IMultilabelClassifier<in TInput> : IMultilabelClassifier<TInput, int[]>, IClassifier<TInput, int[]>, IClassifier, ITransform<TInput, int[]>, ITransform, IMultilabelClassifier<TInput, bool[]>, IClassifier<TInput, bool[]>, ITransform<TInput, bool[]>, IMultilabelClassifier<TInput, double[]>, IClassifier<TInput, double[]>, ITransform<TInput, double[]>
	{
	}
}
