using System;

namespace System.Diagnostics.CodeAnalysis
{
	// Token: 0x02000004 RID: 4
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Event, Inherited = false, AllowMultiple = false)]
	internal sealed class ExcludeFromCodeCoverageAttribute : Attribute
	{
	}
}
