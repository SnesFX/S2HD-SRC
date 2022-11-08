using System;

namespace Accord.MachineLearning
{
	// Token: 0x0200003B RID: 59
	public interface IMulticlassScoreClassifier<TInput> : IMulticlassScoreClassifier<TInput, int>, IMulticlassOutScoreClassifier<TInput, int>, IMulticlassScoreClassifierBase<TInput, int>, IMultilabelOutScoreClassifier<TInput, int>, IMultilabelScoreClassifierBase<TInput, int>, IMulticlassRefScoreClassifier<TInput, int[]>, IMultilabelRefScoreClassifier<TInput, int[]>, IMultilabelScoreClassifierBase<TInput, int[]>, IClassifier<TInput, int>, IClassifier, ITransform<TInput, int>, ITransform, IMulticlassScoreClassifier<TInput, double>, IMulticlassOutScoreClassifier<TInput, double>, IMulticlassScoreClassifierBase<TInput, double>, IMultilabelOutScoreClassifier<TInput, double>, IMultilabelScoreClassifierBase<TInput, double>, IMulticlassRefScoreClassifier<TInput, double[]>, IMultilabelRefScoreClassifier<TInput, double[]>, IMultilabelScoreClassifierBase<TInput, double[]>, IClassifier<TInput, double>, ITransform<TInput, double>, IMulticlassRefScoreClassifier<TInput, bool[]>, IMultilabelRefScoreClassifier<TInput, bool[]>, IMultilabelScoreClassifierBase<TInput, bool[]>, IMultilabelScoreClassifier<TInput>, IMultilabelScoreClassifier<TInput, int>, IMultilabelScoreClassifier<TInput, double>, IMultilabelClassifier<TInput>, IMultilabelClassifier<TInput, int[]>, IClassifier<TInput, int[]>, ITransform<TInput, int[]>, IMultilabelClassifier<TInput, bool[]>, IClassifier<TInput, bool[]>, ITransform<TInput, bool[]>, IMultilabelClassifier<TInput, double[]>, IClassifier<TInput, double[]>, ITransform<TInput, double[]>, IMulticlassClassifier<TInput>, IMulticlassClassifier<TInput, int>, IMulticlassClassifier<TInput, double>
	{
		// Token: 0x060001EB RID: 491
		int Decide(TInput input);

		// Token: 0x060001EC RID: 492
		int[] Decide(TInput[] input);

		// Token: 0x060001ED RID: 493
		double Score(TInput input);

		// Token: 0x060001EE RID: 494
		double[] Score(TInput[] input);

		// Token: 0x060001EF RID: 495
		double[] Score(TInput[] input, double[] result);

		// Token: 0x060001F0 RID: 496
		IMultilabelScoreClassifier<TInput> ToMultilabel();
	}
}
