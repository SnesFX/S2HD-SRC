using System;

namespace Accord.MachineLearning
{
	// Token: 0x02000053 RID: 83
	public interface ILikelihoodTagger<TInput> : ITransform<TInput[], double>, ITransform, IScoreTagger<TInput>, ITagger<TInput>, IMultilabelClassifier<TInput[], int[]>, IClassifier<TInput[], int[]>, IClassifier, ITransform<TInput[], int[]>
	{
		// Token: 0x06000238 RID: 568
		double Probability(TInput[] sequence);

		// Token: 0x06000239 RID: 569
		double Probability(TInput[] sequence, ref int[] decision);

		// Token: 0x0600023A RID: 570
		double[] Probability(TInput[][] sequences);

		// Token: 0x0600023B RID: 571
		double[] Probability(TInput[][] sequences, double[] result);

		// Token: 0x0600023C RID: 572
		double[] Probability(TInput[][] sequences, ref int[][] decision);

		// Token: 0x0600023D RID: 573
		double[] Probability(TInput[][] sequences, ref int[][] decision, double[] result);

		// Token: 0x0600023E RID: 574
		double LogLikelihood(TInput[] sequence);

		// Token: 0x0600023F RID: 575
		double LogLikelihood(TInput[] sequence, ref int[] decision);

		// Token: 0x06000240 RID: 576
		double[] LogLikelihood(TInput[][] sequences);

		// Token: 0x06000241 RID: 577
		double[] LogLikelihood(TInput[][] sequences, double[] result);

		// Token: 0x06000242 RID: 578
		double[] LogLikelihood(TInput[][] sequences, ref int[][] decision);

		// Token: 0x06000243 RID: 579
		double[] LogLikelihood(TInput[][] sequences, ref int[][] decision, double[] result);

		// Token: 0x06000244 RID: 580
		double[][] Probabilities(TInput[] sequence);

		// Token: 0x06000245 RID: 581
		double[][] Probabilities(TInput[] sequence, double[][] result);

		// Token: 0x06000246 RID: 582
		double[][] Probabilities(TInput[] sequence, ref int[] decision);

		// Token: 0x06000247 RID: 583
		double[][] Probabilities(TInput[] sequence, ref int[] decision, double[][] result);

		// Token: 0x06000248 RID: 584
		double[][] LogLikelihoods(TInput[] sequence);

		// Token: 0x06000249 RID: 585
		double[][] LogLikelihoods(TInput[] sequence, double[][] result);

		// Token: 0x0600024A RID: 586
		double[][] LogLikelihoods(TInput[] sequence, ref int[] decision);

		// Token: 0x0600024B RID: 587
		double[][] LogLikelihoods(TInput[] sequence, ref int[] decision, double[][] result);

		// Token: 0x0600024C RID: 588
		double[][][] Probabilities(TInput[][] sequences);

		// Token: 0x0600024D RID: 589
		double[][][] Probabilities(TInput[][] sequences, double[][][] result);

		// Token: 0x0600024E RID: 590
		double[][][] Probabilities(TInput[][] sequences, ref int[][] decision);

		// Token: 0x0600024F RID: 591
		double[][][] Probabilities(TInput[][] sequences, ref int[][] decision, double[][][] result);

		// Token: 0x06000250 RID: 592
		double[][][] LogLikelihoods(TInput[][] sequences);

		// Token: 0x06000251 RID: 593
		double[][][] LogLikelihoods(TInput[][] sequences, double[][][] result);

		// Token: 0x06000252 RID: 594
		double[][][] LogLikelihoods(TInput[][] sequences, ref int[][] decision);

		// Token: 0x06000253 RID: 595
		double[][][] LogLikelihoods(TInput[][] sequences, ref int[][] decision, double[][][] result);
	}
}
