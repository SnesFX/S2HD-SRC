﻿using System;
using System.Runtime.InteropServices;

namespace System.Runtime.CompilerServices
{
	/// <summary>Controls the strictness of the code generated by the common language runtime's just-in-time (JIT) compiler.</summary>
	// Token: 0x02000887 RID: 2183
	[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Module | AttributeTargets.Class | AttributeTargets.Method)]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public class CompilationRelaxationsAttribute : Attribute
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.CompilerServices.CompilationRelaxationsAttribute" /> class with the specified compilation relaxations.</summary>
		/// <param name="relaxations">The compilation relaxations.</param>
		// Token: 0x06005C88 RID: 23688 RVA: 0x00144C54 File Offset: 0x00142E54
		[__DynamicallyInvokable]
		public CompilationRelaxationsAttribute(int relaxations)
		{
			this.m_relaxations = relaxations;
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.CompilerServices.CompilationRelaxationsAttribute" /> class with the specified <see cref="T:System.Runtime.CompilerServices.CompilationRelaxations" /> value.</summary>
		/// <param name="relaxations">One of the <see cref="T:System.Runtime.CompilerServices.CompilationRelaxations" /> values.</param>
		// Token: 0x06005C89 RID: 23689 RVA: 0x00144C63 File Offset: 0x00142E63
		public CompilationRelaxationsAttribute(CompilationRelaxations relaxations)
		{
			this.m_relaxations = (int)relaxations;
		}

		/// <summary>Gets the compilation relaxations specified when the current object was constructed.</summary>
		/// <returns>The compilation relaxations specified when the current object was constructed.  
		///  Use the <see cref="T:System.Runtime.CompilerServices.CompilationRelaxations" /> enumeration with the <see cref="P:System.Runtime.CompilerServices.CompilationRelaxationsAttribute.CompilationRelaxations" /> property.</returns>
		// Token: 0x17000FFC RID: 4092
		// (get) Token: 0x06005C8A RID: 23690 RVA: 0x00144C72 File Offset: 0x00142E72
		[__DynamicallyInvokable]
		public int CompilationRelaxations
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_relaxations;
			}
		}

		// Token: 0x0400295A RID: 10586
		private int m_relaxations;
	}
}