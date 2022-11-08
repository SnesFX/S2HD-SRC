using System;

namespace Accord.MachineLearning
{
	// Token: 0x0200004D RID: 77
	public interface IMultilabelLikelihoodClassifier<TInput> : IMultilabelLikelihoodClassifier<TInput, int>, IMultilabelOutLikelihoodClassifier<TInput, int>, IMultilabelLikelihoodClassifierBase<TInput, int>, IMultilabelScoreClassifierBase<TInput, int>, IMultilabelOutScoreClassifier<TInput, int>, IMultilabelRefLikelihoodClassifier<TInput, int[]>, IMultilabelLikelihoodClassifierBase<TInput, int[]>, IMultilabelScoreClassifierBase<TInput, int[]>, IMultilabelRefScoreClassifier<TInput, int[]>, IMultilabelLikelihoodClassifier<TInput, double>, IMultilabelOutLikelihoodClassifier<TInput, double>, IMultilabelLikelihoodClassifierBase<TInput, double>, IMultilabelScoreClassifierBase<TInput, double>, IMultilabelOutScoreClassifier<TInput, double>, IMultilabelRefLikelihoodClassifier<TInput, double[]>, IMultilabelLikelihoodClassifierBase<TInput, double[]>, IMultilabelScoreClassifierBase<TInput, double[]>, IMultilabelRefScoreClassifier<TInput, double[]>, IMultilabelRefLikelihoodClassifier<TInput, bool[]>, IMultilabelLikelihoodClassifierBase<TInput, bool[]>, IMultilabelScoreClassifierBase<TInput, bool[]>, IMultilabelRefScoreClassifier<TInput, bool[]>, IMultilabelScoreClassifier<TInput>, IMultilabelScoreClassifier<TInput, int>, IClassifier<TInput, int>, IClassifier, ITransform<TInput, int>, ITransform, IMultilabelScoreClassifier<TInput, double>, IClassifier<TInput, double>, ITransform<TInput, double>, IMultilabelClassifier<TInput>, IMultilabelClassifier<TInput, int[]>, IClassifier<TInput, int[]>, ITransform<TInput, int[]>, IMultilabelClassifier<TInput, bool[]>, IClassifier<TInput, bool[]>, ITransform<TInput, bool[]>, IMultilabelClassifier<TInput, double[]>, IClassifier<TInput, double[]>, ITransform<TInput, double[]>
	{
		// Token: 0x0600021E RID: 542
		double Probability(TInput input, int classIndex);

		// Token: 0x0600021F RID: 543
		double[] Probability(TInput[] input, int[] classIndex);

		// Token: 0x06000220 RID: 544
		double[] Probability(TInput[] input, int[] classIndex, double[] result);

		// Token: 0x06000221 RID: 545
		double[] Probability(TInput[] input, int classIndex);

		// Token: 0x06000222 RID: 546
		double[] Probability(TInput[] input, int classIndex, double[] result);

		// Token: 0x06000223 RID: 547
		double LogLikelihood(TInput input, int classIndex);

		// Token: 0x06000224 RID: 548
		double[] LogLikelihood(TInput[] input, int[] classIndex);

		// Token: 0x06000225 RID: 549
		double[] LogLikelihood(TInput[] input, int[] classIndex, double[] result);

		// Token: 0x06000226 RID: 550
		double[] LogLikelihood(TInput[] input, int classIndex);

		// Token: 0x06000227 RID: 551
		double[] LogLikelihood(TInput[] input, int classIndex, double[] result);

		// Token: 0x06000228 RID: 552
		double[] LogLikelihoods(TInput input);

		// Token: 0x06000229 RID: 553
		double[] LogLikelihoods(TInput input, double[] result);

		// Token: 0x0600022A RID: 554
		double[][] LogLikelihoods(TInput[] input);

		// Token: 0x0600022B RID: 555
		double[][] LogLikelihoods(TInput[] input, double[][] result);

		// Token: 0x0600022C RID: 556
		double[] Probabilities(TInput input);

		// Token: 0x0600022D RID: 557
		double[] Probabilities(TInput input, double[] result);

		// Token: 0x0600022E RID: 558
		double[][] Probabilities(TInput[] input);

		// Token: 0x0600022F RID: 559
		double[][] Probabilities(TInput[] input, double[][] result);

		// Token: 0x06000230 RID: 560
		IMulticlassLikelihoodClassifier<TInput> ToMulticlass();

		// Token: 0x06000231 RID: 561
		IMulticlassLikelihoodClassifier<TInput, T> ToMulticlass<T>();
	}
}
