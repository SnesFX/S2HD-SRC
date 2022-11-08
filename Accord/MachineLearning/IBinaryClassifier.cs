using System;

namespace Accord.MachineLearning
{
	// Token: 0x0200004E RID: 78
	public interface IBinaryClassifier<in TInput> : IMulticlassClassifier<TInput>, IMultilabelClassifier<TInput>, IMultilabelClassifier<TInput, int[]>, IClassifier<TInput, int[]>, IClassifier, ITransform<TInput, int[]>, ITransform, IMultilabelClassifier<TInput, bool[]>, IClassifier<TInput, bool[]>, ITransform<TInput, bool[]>, IMultilabelClassifier<TInput, double[]>, IClassifier<TInput, double[]>, ITransform<TInput, double[]>, IMulticlassClassifier<TInput, int>, IClassifier<TInput, int>, ITransform<TInput, int>, IMulticlassClassifier<TInput, double>, IClassifier<TInput, double>, ITransform<TInput, double>, IClassifier<TInput, bool>, ITransform<TInput, bool>
	{
		// Token: 0x06000232 RID: 562
		IMulticlassClassifier<TInput> ToMulticlass();

		// Token: 0x06000233 RID: 563
		IMulticlassClassifier<TInput, T> ToMulticlass<T>();
	}
}
