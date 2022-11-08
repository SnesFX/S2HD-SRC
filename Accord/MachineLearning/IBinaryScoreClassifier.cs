using System;

namespace Accord.MachineLearning
{
	// Token: 0x02000050 RID: 80
	public interface IBinaryScoreClassifier<TInput> : IBinaryClassifier<TInput>, IMulticlassClassifier<TInput>, IMultilabelClassifier<TInput>, IMultilabelClassifier<TInput, int[]>, IClassifier<TInput, int[]>, IClassifier, ITransform<TInput, int[]>, ITransform, IMultilabelClassifier<TInput, bool[]>, IClassifier<TInput, bool[]>, ITransform<TInput, bool[]>, IMultilabelClassifier<TInput, double[]>, IClassifier<TInput, double[]>, ITransform<TInput, double[]>, IMulticlassClassifier<TInput, int>, IClassifier<TInput, int>, ITransform<TInput, int>, IMulticlassClassifier<TInput, double>, IClassifier<TInput, double>, ITransform<TInput, double>, IClassifier<TInput, bool>, ITransform<TInput, bool>, IMulticlassOutScoreClassifier<TInput, bool>, IMulticlassScoreClassifierBase<TInput, bool>, IMultilabelOutScoreClassifier<TInput, bool>, IMultilabelScoreClassifierBase<TInput, bool>, IMulticlassScoreClassifier<TInput>, IMulticlassScoreClassifier<TInput, int>, IMulticlassOutScoreClassifier<TInput, int>, IMulticlassScoreClassifierBase<TInput, int>, IMultilabelOutScoreClassifier<TInput, int>, IMultilabelScoreClassifierBase<TInput, int>, IMulticlassRefScoreClassifier<TInput, int[]>, IMultilabelRefScoreClassifier<TInput, int[]>, IMultilabelScoreClassifierBase<TInput, int[]>, IMulticlassScoreClassifier<TInput, double>, IMulticlassOutScoreClassifier<TInput, double>, IMulticlassScoreClassifierBase<TInput, double>, IMultilabelOutScoreClassifier<TInput, double>, IMultilabelScoreClassifierBase<TInput, double>, IMulticlassRefScoreClassifier<TInput, double[]>, IMultilabelRefScoreClassifier<TInput, double[]>, IMultilabelScoreClassifierBase<TInput, double[]>, IMulticlassRefScoreClassifier<TInput, bool[]>, IMultilabelRefScoreClassifier<TInput, bool[]>, IMultilabelScoreClassifierBase<TInput, bool[]>, IMultilabelScoreClassifier<TInput>, IMultilabelScoreClassifier<TInput, int>, IMultilabelScoreClassifier<TInput, double>
	{
		// Token: 0x06000234 RID: 564
		IMulticlassScoreClassifier<TInput> ToMulticlass();

		// Token: 0x06000235 RID: 565
		IMulticlassScoreClassifier<TInput, T> ToMulticlass<T>();
	}
}
