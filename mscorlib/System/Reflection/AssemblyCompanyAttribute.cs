﻿using System;
using System.Runtime.InteropServices;

namespace System.Reflection
{
	/// <summary>Defines a company name custom attribute for an assembly manifest.</summary>
	// Token: 0x0200058A RID: 1418
	[AttributeUsage(AttributeTargets.Assembly, Inherited = false)]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	public sealed class AssemblyCompanyAttribute : Attribute
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Reflection.AssemblyCompanyAttribute" /> class.</summary>
		/// <param name="company">The company name information.</param>
		// Token: 0x06004338 RID: 17208 RVA: 0x000F79AE File Offset: 0x000F5BAE
		[__DynamicallyInvokable]
		public AssemblyCompanyAttribute(string company)
		{
			this.m_company = company;
		}

		/// <summary>Gets company name information.</summary>
		/// <returns>A string containing the company name.</returns>
		// Token: 0x170009FB RID: 2555
		// (get) Token: 0x06004339 RID: 17209 RVA: 0x000F79BD File Offset: 0x000F5BBD
		[__DynamicallyInvokable]
		public string Company
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_company;
			}
		}

		// Token: 0x04001B45 RID: 6981
		private string m_company;
	}
}
