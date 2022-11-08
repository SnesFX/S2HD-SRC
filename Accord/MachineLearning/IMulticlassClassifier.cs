using System;

namespace Accord.MachineLearning
{
	// Token: 0x02000034 RID: 52
	public interface IMulticlassClassifier<in TInput, TClasses> : IClassifier<TInput, TClasses>, IClassifier, ITransform<TInput, TClasses>, ITransform
	{
	}
}
