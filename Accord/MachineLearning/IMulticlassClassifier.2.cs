using System;

namespace Accord.MachineLearning
{
	// Token: 0x02000035 RID: 53
	public interface IMulticlassClassifier<in TInput> : IMultilabelClassifier<TInput>, IMultilabelClassifier<TInput, int[]>, IClassifier<TInput, int[]>, IClassifier, ITransform<TInput, int[]>, ITransform, IMultilabelClassifier<TInput, bool[]>, IClassifier<TInput, bool[]>, ITransform<TInput, bool[]>, IMultilabelClassifier<TInput, double[]>, IClassifier<TInput, double[]>, ITransform<TInput, double[]>, IMulticlassClassifier<TInput, int>, IClassifier<TInput, int>, ITransform<TInput, int>, IMulticlassClassifier<TInput, double>, IClassifier<TInput, double>, ITransform<TInput, double>
	{
		// Token: 0x060001E5 RID: 485
		int Decide(TInput input);

		// Token: 0x060001E6 RID: 486
		int[] Decide(TInput[] input);

		// Token: 0x060001E7 RID: 487
		IMultilabelClassifier<TInput> ToMultilabel();
	}
}
