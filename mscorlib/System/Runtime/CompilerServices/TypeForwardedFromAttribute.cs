﻿using System;

namespace System.Runtime.CompilerServices
{
	/// <summary>Specifies a source <see cref="T:System.Type" /> in another assembly.</summary>
	// Token: 0x020008B4 RID: 2228
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Interface | AttributeTargets.Delegate, Inherited = false, AllowMultiple = false)]
	[__DynamicallyInvokable]
	public sealed class TypeForwardedFromAttribute : Attribute
	{
		// Token: 0x06005CBE RID: 23742 RVA: 0x00144ED4 File Offset: 0x001430D4
		private TypeForwardedFromAttribute()
		{
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.CompilerServices.TypeForwardedFromAttribute" /> class.</summary>
		/// <param name="assemblyFullName">The source <see cref="T:System.Type" /> in another assembly.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="assemblyFullName" /> is <see langword="null" /> or empty.</exception>
		// Token: 0x06005CBF RID: 23743 RVA: 0x00144EDC File Offset: 0x001430DC
		[__DynamicallyInvokable]
		public TypeForwardedFromAttribute(string assemblyFullName)
		{
			if (string.IsNullOrEmpty(assemblyFullName))
			{
				throw new ArgumentNullException("assemblyFullName");
			}
			this.assemblyFullName = assemblyFullName;
		}

		/// <summary>Gets the assembly-qualified name of the source type.</summary>
		/// <returns>The assembly-qualified name of the source type.</returns>
		// Token: 0x17001007 RID: 4103
		// (get) Token: 0x06005CC0 RID: 23744 RVA: 0x00144EFE File Offset: 0x001430FE
		[__DynamicallyInvokable]
		public string AssemblyFullName
		{
			[__DynamicallyInvokable]
			get
			{
				return this.assemblyFullName;
			}
		}

		// Token: 0x0400297F RID: 10623
		private string assemblyFullName;
	}
}
