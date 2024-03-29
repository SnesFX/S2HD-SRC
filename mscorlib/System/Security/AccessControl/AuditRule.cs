﻿using System;
using System.Security.Principal;

namespace System.Security.AccessControl
{
	/// <summary>Represents a combination of a user's identity and an access mask.</summary>
	/// <typeparam name="T">The type of the audit rule.</typeparam>
	// Token: 0x02000226 RID: 550
	public class AuditRule<T> : AuditRule where T : struct
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Security.AccessControl.AuditRule`1" /> class by using the specified values.</summary>
		/// <param name="identity">The identity to which this audit rule applies.</param>
		/// <param name="rights">The rights of the audit rule.</param>
		/// <param name="flags">The conditions for which the rule is audited.</param>
		// Token: 0x06001FC3 RID: 8131 RVA: 0x0006ED37 File Offset: 0x0006CF37
		public AuditRule(IdentityReference identity, T rights, AuditFlags flags) : this(identity, rights, InheritanceFlags.None, PropagationFlags.None, flags)
		{
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Security.AccessControl.AuditRule`1" /> class by using the specified values.</summary>
		/// <param name="identity">The identity to which the audit rule applies.</param>
		/// <param name="rights">The rights of the audit rule.</param>
		/// <param name="inheritanceFlags">The inheritance properties of the audit rule.</param>
		/// <param name="propagationFlags">Whether inherited audit rules are automatically propagated.</param>
		/// <param name="flags">The conditions for which the rule is audited.</param>
		// Token: 0x06001FC4 RID: 8132 RVA: 0x0006ED44 File Offset: 0x0006CF44
		public AuditRule(IdentityReference identity, T rights, InheritanceFlags inheritanceFlags, PropagationFlags propagationFlags, AuditFlags flags) : this(identity, (int)((object)rights), false, inheritanceFlags, propagationFlags, flags)
		{
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Security.AccessControl.AuditRule`1" /> class by using the specified values.</summary>
		/// <param name="identity">The identity to which the audit rule applies.</param>
		/// <param name="rights">The rights of the audit rule.</param>
		/// <param name="flags">The properties of the audit rule.</param>
		// Token: 0x06001FC5 RID: 8133 RVA: 0x0006ED5E File Offset: 0x0006CF5E
		public AuditRule(string identity, T rights, AuditFlags flags) : this(new NTAccount(identity), rights, InheritanceFlags.None, PropagationFlags.None, flags)
		{
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Security.AccessControl.AuditRule`1" /> class by using the specified values.</summary>
		/// <param name="identity">The identity to which the audit rule applies.</param>
		/// <param name="rights">The rights of the audit rule.</param>
		/// <param name="inheritanceFlags">The inheritance properties of the audit rule.</param>
		/// <param name="propagationFlags">Whether inherited audit rules are automatically propagated.</param>
		/// <param name="flags">The conditions for which the rule is audited.</param>
		// Token: 0x06001FC6 RID: 8134 RVA: 0x0006ED70 File Offset: 0x0006CF70
		public AuditRule(string identity, T rights, InheritanceFlags inheritanceFlags, PropagationFlags propagationFlags, AuditFlags flags) : this(new NTAccount(identity), (int)((object)rights), false, inheritanceFlags, propagationFlags, flags)
		{
		}

		// Token: 0x06001FC7 RID: 8135 RVA: 0x0006ED8F File Offset: 0x0006CF8F
		internal AuditRule(IdentityReference identity, int accessMask, bool isInherited, InheritanceFlags inheritanceFlags, PropagationFlags propagationFlags, AuditFlags flags) : base(identity, accessMask, isInherited, inheritanceFlags, propagationFlags, flags)
		{
		}

		/// <summary>Gets the rights of the audit rule.</summary>
		/// <returns>The rights of the audit rule.</returns>
		// Token: 0x170003B2 RID: 946
		// (get) Token: 0x06001FC8 RID: 8136 RVA: 0x0006EDA0 File Offset: 0x0006CFA0
		public T Rights
		{
			get
			{
				return (T)((object)base.AccessMask);
			}
		}
	}
}
