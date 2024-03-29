﻿using System;
using System.Runtime.InteropServices;

namespace System.Diagnostics
{
	/// <summary>Determines how a class or field is displayed in the debugger variable windows.</summary>
	// Token: 0x020003C2 RID: 962
	[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Delegate, AllowMultiple = true)]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	public sealed class DebuggerDisplayAttribute : Attribute
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Diagnostics.DebuggerDisplayAttribute" /> class.</summary>
		/// <param name="value">The string to be displayed in the value column for instances of the type; an empty string ("") causes the value column to be hidden.</param>
		// Token: 0x060031F8 RID: 12792 RVA: 0x000C0253 File Offset: 0x000BE453
		[__DynamicallyInvokable]
		public DebuggerDisplayAttribute(string value)
		{
			if (value == null)
			{
				this.value = "";
			}
			else
			{
				this.value = value;
			}
			this.name = "";
			this.type = "";
		}

		/// <summary>Gets the string to display in the value column of the debugger variable windows.</summary>
		/// <returns>The string to display in the value column of the debugger variable.</returns>
		// Token: 0x17000762 RID: 1890
		// (get) Token: 0x060031F9 RID: 12793 RVA: 0x000C0288 File Offset: 0x000BE488
		[__DynamicallyInvokable]
		public string Value
		{
			[__DynamicallyInvokable]
			get
			{
				return this.value;
			}
		}

		/// <summary>Gets or sets the name to display in the debugger variable windows.</summary>
		/// <returns>The name to display in the debugger variable windows.</returns>
		// Token: 0x17000763 RID: 1891
		// (get) Token: 0x060031FA RID: 12794 RVA: 0x000C0290 File Offset: 0x000BE490
		// (set) Token: 0x060031FB RID: 12795 RVA: 0x000C0298 File Offset: 0x000BE498
		[__DynamicallyInvokable]
		public string Name
		{
			[__DynamicallyInvokable]
			get
			{
				return this.name;
			}
			[__DynamicallyInvokable]
			set
			{
				this.name = value;
			}
		}

		/// <summary>Gets or sets the string to display in the type column of the debugger variable windows.</summary>
		/// <returns>The string to display in the type column of the debugger variable windows.</returns>
		// Token: 0x17000764 RID: 1892
		// (get) Token: 0x060031FC RID: 12796 RVA: 0x000C02A1 File Offset: 0x000BE4A1
		// (set) Token: 0x060031FD RID: 12797 RVA: 0x000C02A9 File Offset: 0x000BE4A9
		[__DynamicallyInvokable]
		public string Type
		{
			[__DynamicallyInvokable]
			get
			{
				return this.type;
			}
			[__DynamicallyInvokable]
			set
			{
				this.type = value;
			}
		}

		/// <summary>Gets or sets the type of the attribute's target.</summary>
		/// <returns>The attribute's target type.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <see cref="P:System.Diagnostics.DebuggerDisplayAttribute.Target" /> is set to <see langword="null" />.</exception>
		// Token: 0x17000765 RID: 1893
		// (get) Token: 0x060031FF RID: 12799 RVA: 0x000C02DB File Offset: 0x000BE4DB
		// (set) Token: 0x060031FE RID: 12798 RVA: 0x000C02B2 File Offset: 0x000BE4B2
		[__DynamicallyInvokable]
		public Type Target
		{
			[__DynamicallyInvokable]
			get
			{
				return this.target;
			}
			[__DynamicallyInvokable]
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				this.targetName = value.AssemblyQualifiedName;
				this.target = value;
			}
		}

		/// <summary>Gets or sets the type name of the attribute's target.</summary>
		/// <returns>The name of the attribute's target type.</returns>
		// Token: 0x17000766 RID: 1894
		// (get) Token: 0x06003200 RID: 12800 RVA: 0x000C02E3 File Offset: 0x000BE4E3
		// (set) Token: 0x06003201 RID: 12801 RVA: 0x000C02EB File Offset: 0x000BE4EB
		[__DynamicallyInvokable]
		public string TargetTypeName
		{
			[__DynamicallyInvokable]
			get
			{
				return this.targetName;
			}
			[__DynamicallyInvokable]
			set
			{
				this.targetName = value;
			}
		}

		// Token: 0x040015F0 RID: 5616
		private string name;

		// Token: 0x040015F1 RID: 5617
		private string value;

		// Token: 0x040015F2 RID: 5618
		private string type;

		// Token: 0x040015F3 RID: 5619
		private string targetName;

		// Token: 0x040015F4 RID: 5620
		private Type target;
	}
}
