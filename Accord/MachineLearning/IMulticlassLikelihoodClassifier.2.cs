using System;

namespace Accord.MachineLearning
{
	// Token: 0x02000040 RID: 64
	public interface IMulticlassLikelihoodClassifier<TInput> : IMulticlassLikelihoodClassifier<TInput, int>, IMulticlassOutLikelihoodClassifier<TInput, int>, IMulticlassOutScoreClassifier<TInput, int>, IMulticlassScoreClassifierBase<TInput, int>, IMultilabelOutScoreClassifier<TInput, int>, IMultilabelScoreClassifierBase<TInput, int>, IMultilabelOutLikelihoodClassifier<TInput, int>, IMultilabelLikelihoodClassifierBase<TInput, int>, IMulticlassLikelihoodClassifierBase<TInput, int>, IMulticlassRefLikelihoodClassifier<TInput, int[]>, IMulticlassRefScoreClassifier<TInput, int[]>, IMultilabelRefScoreClassifier<TInput, int[]>, IMultilabelScoreClassifierBase<TInput, int[]>, IMultilabelRefLikelihoodClassifier<TInput, int[]>, IMultilabelLikelihoodClassifierBase<TInput, int[]>, IMulticlassScoreClassifier<TInput, int>, IClassifier<TInput, int>, IClassifier, ITransform<TInput, int>, ITransform, IMulticlassLikelihoodClassifier<TInput, double>, IMulticlassOutLikelihoodClassifier<TInput, double>, IMulticlassOutScoreClassifier<TInput, double>, IMulticlassScoreClassifierBase<TInput, double>, IMultilabelOutScoreClassifier<TInput, double>, IMultilabelScoreClassifierBase<TInput, double>, IMultilabelOutLikelihoodClassifier<TInput, double>, IMultilabelLikelihoodClassifierBase<TInput, double>, IMulticlassLikelihoodClassifierBase<TInput, double>, IMulticlassRefLikelihoodClassifier<TInput, double[]>, IMulticlassRefScoreClassifier<TInput, double[]>, IMultilabelRefScoreClassifier<TInput, double[]>, IMultilabelScoreClassifierBase<TInput, double[]>, IMultilabelRefLikelihoodClassifier<TInput, double[]>, IMultilabelLikelihoodClassifierBase<TInput, double[]>, IMulticlassScoreClassifier<TInput, double>, IClassifier<TInput, double>, ITransform<TInput, double>, IMulticlassRefLikelihoodClassifier<TInput, bool[]>, IMulticlassRefScoreClassifier<TInput, bool[]>, IMultilabelRefScoreClassifier<TInput, bool[]>, IMultilabelScoreClassifierBase<TInput, bool[]>, IMultilabelRefLikelihoodClassifier<TInput, bool[]>, IMultilabelLikelihoodClassifierBase<TInput, bool[]>, IMulticlassScoreClassifier<TInput>, IMultilabelScoreClassifier<TInput>, IMultilabelScoreClassifier<TInput, int>, IMultilabelScoreClassifier<TInput, double>, IMultilabelClassifier<TInput>, IMultilabelClassifier<TInput, int[]>, IClassifier<TInput, int[]>, ITransform<TInput, int[]>, IMultilabelClassifier<TInput, bool[]>, IClassifier<TInput, bool[]>, ITransform<TInput, bool[]>, IMultilabelClassifier<TInput, double[]>, IClassifier<TInput, double[]>, ITransform<TInput, double[]>, IMulticlassClassifier<TInput>, IMulticlassClassifier<TInput, int>, IMulticlassClassifier<TInput, double>, IMultilabelLikelihoodClassifier<TInput>, IMultilabelLikelihoodClassifier<TInput, int>, IMultilabelLikelihoodClassifier<TInput, double>
	{
		// Token: 0x060001F7 RID: 503
		int Decide(TInput input);

		// Token: 0x060001F8 RID: 504
		int[] Decide(TInput[] input);

		// Token: 0x060001F9 RID: 505
		double Probability(TInput input);

		// Token: 0x060001FA RID: 506
		double[] Probability(TInput[] input);

		// Token: 0x060001FB RID: 507
		double[] Probability(TInput[] input, double[] result);

		// Token: 0x060001FC RID: 508
		double LogLikelihood(TInput input);

		// Token: 0x060001FD RID: 509
		double[] LogLikelihood(TInput[] input);

		// Token: 0x060001FE RID: 510
		double[] LogLikelihood(TInput[] input, double[] result);

		// Token: 0x060001FF RID: 511
		IMultilabelLikelihoodClassifier<TInput> ToMultilabel();
	}
}
