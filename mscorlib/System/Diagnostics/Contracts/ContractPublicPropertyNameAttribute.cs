﻿using System;

namespace System.Diagnostics.Contracts
{
	/// <summary>Specifies that a field can be used in method contracts when the field has less visibility than the method.</summary>
	// Token: 0x020003E4 RID: 996
	[Conditional("CONTRACTS_FULL")]
	[AttributeUsage(AttributeTargets.Field)]
	[__DynamicallyInvokable]
	public sealed class ContractPublicPropertyNameAttribute : Attribute
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Diagnostics.Contracts.ContractPublicPropertyNameAttribute" /> class.</summary>
		/// <param name="name">The property name to apply to the field.</param>
		// Token: 0x060032D7 RID: 13015 RVA: 0x000C1CCC File Offset: 0x000BFECC
		[__DynamicallyInvokable]
		public ContractPublicPropertyNameAttribute(string name)
		{
			this._publicName = name;
		}

		/// <summary>Gets the property name to be applied to the field.</summary>
		/// <returns>The property name to be applied to the field.</returns>
		// Token: 0x1700078D RID: 1933
		// (get) Token: 0x060032D8 RID: 13016 RVA: 0x000C1CDB File Offset: 0x000BFEDB
		[__DynamicallyInvokable]
		public string Name
		{
			[__DynamicallyInvokable]
			get
			{
				return this._publicName;
			}
		}

		// Token: 0x0400164F RID: 5711
		private string _publicName;
	}
}
