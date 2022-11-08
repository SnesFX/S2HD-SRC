using System;

namespace Accord.MachineLearning
{
	// Token: 0x02000048 RID: 72
	public interface IMultilabelScoreClassifier<TInput> : IMultilabelScoreClassifier<TInput, int>, IMultilabelOutScoreClassifier<TInput, int>, IMultilabelScoreClassifierBase<TInput, int>, IMultilabelRefScoreClassifier<TInput, int[]>, IMultilabelScoreClassifierBase<TInput, int[]>, IClassifier<TInput, int>, IClassifier, ITransform<TInput, int>, ITransform, IMultilabelScoreClassifier<TInput, double>, IMultilabelOutScoreClassifier<TInput, double>, IMultilabelScoreClassifierBase<TInput, double>, IMultilabelRefScoreClassifier<TInput, double[]>, IMultilabelScoreClassifierBase<TInput, double[]>, IClassifier<TInput, double>, ITransform<TInput, double>, IMultilabelRefScoreClassifier<TInput, bool[]>, IMultilabelScoreClassifierBase<TInput, bool[]>, IMultilabelClassifier<TInput>, IMultilabelClassifier<TInput, int[]>, IClassifier<TInput, int[]>, ITransform<TInput, int[]>, IMultilabelClassifier<TInput, bool[]>, IClassifier<TInput, bool[]>, ITransform<TInput, bool[]>, IMultilabelClassifier<TInput, double[]>, IClassifier<TInput, double[]>, ITransform<TInput, double[]>
	{
		// Token: 0x06000207 RID: 519
		double Score(TInput input, int classIndex);

		// Token: 0x06000208 RID: 520
		double[] Score(TInput[] input, int[] classIndex);

		// Token: 0x06000209 RID: 521
		double[] Score(TInput[] input, int[] classIndex, double[] result);

		// Token: 0x0600020A RID: 522
		double[] Score(TInput[] input, int classIndex);

		// Token: 0x0600020B RID: 523
		double[] Score(TInput[] input, int classIndex, double[] result);

		// Token: 0x0600020C RID: 524
		double[] Scores(TInput input);

		// Token: 0x0600020D RID: 525
		double[] Scores(TInput input, double[] result);

		// Token: 0x0600020E RID: 526
		double[][] Scores(TInput[] input);

		// Token: 0x0600020F RID: 527
		double[][] Scores(TInput[] input, double[][] result);

		// Token: 0x06000210 RID: 528
		IMulticlassScoreClassifier<TInput> ToMulticlass();

		// Token: 0x06000211 RID: 529
		IMulticlassScoreClassifier<TInput, T> ToMulticlass<T>();
	}
}
