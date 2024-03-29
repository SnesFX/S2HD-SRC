﻿using System;

namespace System.Diagnostics.Tracing
{
	/// <summary>The <see cref="T:System.Diagnostics.Tracing.EventFieldAttribute" /> is placed on fields of user-defined types that are passed as <see cref="T:System.Diagnostics.Tracing.EventSource" /> payloads.</summary>
	// Token: 0x02000416 RID: 1046
	[AttributeUsage(AttributeTargets.Property)]
	[__DynamicallyInvokable]
	public class EventFieldAttribute : Attribute
	{
		/// <summary>Gets or sets the user-defined <see cref="T:System.Diagnostics.Tracing.EventFieldTags" /> value that is required for fields that contain data that isn't one of the supported types.</summary>
		/// <returns>Returns <see cref="T:System.Diagnostics.Tracing.EventFieldTags" />.</returns>
		// Token: 0x170007E4 RID: 2020
		// (get) Token: 0x060034E5 RID: 13541 RVA: 0x000CD9EE File Offset: 0x000CBBEE
		// (set) Token: 0x060034E6 RID: 13542 RVA: 0x000CD9F6 File Offset: 0x000CBBF6
		[__DynamicallyInvokable]
		public EventFieldTags Tags { [__DynamicallyInvokable] get; [__DynamicallyInvokable] set; }

		// Token: 0x170007E5 RID: 2021
		// (get) Token: 0x060034E7 RID: 13543 RVA: 0x000CD9FF File Offset: 0x000CBBFF
		// (set) Token: 0x060034E8 RID: 13544 RVA: 0x000CDA07 File Offset: 0x000CBC07
		internal string Name { get; set; }

		/// <summary>Gets or sets the value that specifies how to format the value of a user-defined type.</summary>
		/// <returns>The value that specifies how to format the value of a user-defined type.</returns>
		// Token: 0x170007E6 RID: 2022
		// (get) Token: 0x060034E9 RID: 13545 RVA: 0x000CDA10 File Offset: 0x000CBC10
		// (set) Token: 0x060034EA RID: 13546 RVA: 0x000CDA18 File Offset: 0x000CBC18
		[__DynamicallyInvokable]
		public EventFieldFormat Format { [__DynamicallyInvokable] get; [__DynamicallyInvokable] set; }

		/// <summary>Initializes a new instance of the <see cref="T:System.Diagnostics.Tracing.EventFieldAttribute" /> class.</summary>
		// Token: 0x060034EB RID: 13547 RVA: 0x000CDA21 File Offset: 0x000CBC21
		[__DynamicallyInvokable]
		public EventFieldAttribute()
		{
		}
	}
}
