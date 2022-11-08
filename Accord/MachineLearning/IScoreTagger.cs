using System;

namespace Accord.MachineLearning
{
	// Token: 0x02000054 RID: 84
	public interface IScoreTagger<in TInput> : ITagger<TInput>, IMultilabelClassifier<TInput[], int[]>, IClassifier<TInput[], int[]>, IClassifier, ITransform<TInput[], int[]>, ITransform
	{
		// Token: 0x06000254 RID: 596
		double[][] Scores(TInput[] sequence);

		// Token: 0x06000255 RID: 597
		double[][] Scores(TInput[] sequence, double[][] result);

		// Token: 0x06000256 RID: 598
		double[][] Scores(TInput[] sequence, ref int[] decision);

		// Token: 0x06000257 RID: 599
		double[][] Scores(TInput[] sequence, ref int[] decision, double[][] result);

		// Token: 0x06000258 RID: 600
		double[][][] Scores(TInput[][] sequences);

		// Token: 0x06000259 RID: 601
		double[][][] Scores(TInput[][] sequences, double[][][] result);

		// Token: 0x0600025A RID: 602
		double[][][] Scores(TInput[][] sequences, ref int[][] decision);

		// Token: 0x0600025B RID: 603
		double[][][] Scores(TInput[][] sequences, ref int[][] decision, double[][][] result);
	}
}
