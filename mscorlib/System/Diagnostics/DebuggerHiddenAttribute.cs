﻿using System;
using System.Runtime.InteropServices;

namespace System.Diagnostics
{
	/// <summary>Specifies the <see cref="T:System.Diagnostics.DebuggerHiddenAttribute" />. This class cannot be inherited.</summary>
	// Token: 0x020003BC RID: 956
	[AttributeUsage(AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Property, Inherited = false)]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public sealed class DebuggerHiddenAttribute : Attribute
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Diagnostics.DebuggerHiddenAttribute" /> class.</summary>
		// Token: 0x060031E8 RID: 12776 RVA: 0x000C012E File Offset: 0x000BE32E
		[__DynamicallyInvokable]
		public DebuggerHiddenAttribute()
		{
		}
	}
}
