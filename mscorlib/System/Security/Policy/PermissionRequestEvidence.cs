﻿using System;
using System.Runtime.InteropServices;

namespace System.Security.Policy
{
	/// <summary>Defines evidence that represents permission requests. This class cannot be inherited.</summary>
	// Token: 0x02000335 RID: 821
	[ComVisible(true)]
	[Obsolete("Assembly level declarative security is obsolete and is no longer enforced by the CLR by default. See http://go.microsoft.com/fwlink/?LinkID=155570 for more information.")]
	[Serializable]
	public sealed class PermissionRequestEvidence : EvidenceBase
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Security.Policy.PermissionRequestEvidence" /> class with the permission request of a code assembly.</summary>
		/// <param name="request">The minimum permissions the code requires to run.</param>
		/// <param name="optional">The permissions the code can use if they are granted, but that are not required.</param>
		/// <param name="denied">The permissions the code explicitly asks not to be granted.</param>
		// Token: 0x060029A8 RID: 10664 RVA: 0x00099CA4 File Offset: 0x00097EA4
		public PermissionRequestEvidence(PermissionSet request, PermissionSet optional, PermissionSet denied)
		{
			if (request == null)
			{
				this.m_request = null;
			}
			else
			{
				this.m_request = request.Copy();
			}
			if (optional == null)
			{
				this.m_optional = null;
			}
			else
			{
				this.m_optional = optional.Copy();
			}
			if (denied == null)
			{
				this.m_denied = null;
				return;
			}
			this.m_denied = denied.Copy();
		}

		/// <summary>Gets the minimum permissions the code requires to run.</summary>
		/// <returns>The minimum permissions the code requires to run.</returns>
		// Token: 0x1700059F RID: 1439
		// (get) Token: 0x060029A9 RID: 10665 RVA: 0x00099CFE File Offset: 0x00097EFE
		public PermissionSet RequestedPermissions
		{
			get
			{
				return this.m_request;
			}
		}

		/// <summary>Gets the permissions the code can use if they are granted, but are not required.</summary>
		/// <returns>The permissions the code can use if they are granted, but are not required.</returns>
		// Token: 0x170005A0 RID: 1440
		// (get) Token: 0x060029AA RID: 10666 RVA: 0x00099D06 File Offset: 0x00097F06
		public PermissionSet OptionalPermissions
		{
			get
			{
				return this.m_optional;
			}
		}

		/// <summary>Gets the permissions the code explicitly asks not to be granted.</summary>
		/// <returns>The permissions the code explicitly asks not to be granted.</returns>
		// Token: 0x170005A1 RID: 1441
		// (get) Token: 0x060029AB RID: 10667 RVA: 0x00099D0E File Offset: 0x00097F0E
		public PermissionSet DeniedPermissions
		{
			get
			{
				return this.m_denied;
			}
		}

		/// <summary>Creates a new object that is a copy of the current instance.</summary>
		/// <returns>A new object that is a copy of this instance.</returns>
		// Token: 0x060029AC RID: 10668 RVA: 0x00099D16 File Offset: 0x00097F16
		public override EvidenceBase Clone()
		{
			return this.Copy();
		}

		/// <summary>Creates an equivalent copy of the current <see cref="T:System.Security.Policy.PermissionRequestEvidence" />.</summary>
		/// <returns>An equivalent copy of the current <see cref="T:System.Security.Policy.PermissionRequestEvidence" />.</returns>
		// Token: 0x060029AD RID: 10669 RVA: 0x00099D1E File Offset: 0x00097F1E
		public PermissionRequestEvidence Copy()
		{
			return new PermissionRequestEvidence(this.m_request, this.m_optional, this.m_denied);
		}

		// Token: 0x060029AE RID: 10670 RVA: 0x00099D38 File Offset: 0x00097F38
		internal SecurityElement ToXml()
		{
			SecurityElement securityElement = new SecurityElement("System.Security.Policy.PermissionRequestEvidence");
			securityElement.AddAttribute("version", "1");
			if (this.m_request != null)
			{
				SecurityElement securityElement2 = new SecurityElement("Request");
				securityElement2.AddChild(this.m_request.ToXml());
				securityElement.AddChild(securityElement2);
			}
			if (this.m_optional != null)
			{
				SecurityElement securityElement2 = new SecurityElement("Optional");
				securityElement2.AddChild(this.m_optional.ToXml());
				securityElement.AddChild(securityElement2);
			}
			if (this.m_denied != null)
			{
				SecurityElement securityElement2 = new SecurityElement("Denied");
				securityElement2.AddChild(this.m_denied.ToXml());
				securityElement.AddChild(securityElement2);
			}
			return securityElement;
		}

		/// <summary>Gets a string representation of the state of the <see cref="T:System.Security.Policy.PermissionRequestEvidence" />.</summary>
		/// <returns>A representation of the state of the <see cref="T:System.Security.Policy.PermissionRequestEvidence" />.</returns>
		// Token: 0x060029AF RID: 10671 RVA: 0x00099DE2 File Offset: 0x00097FE2
		public override string ToString()
		{
			return this.ToXml().ToString();
		}

		// Token: 0x040010B4 RID: 4276
		private PermissionSet m_request;

		// Token: 0x040010B5 RID: 4277
		private PermissionSet m_optional;

		// Token: 0x040010B6 RID: 4278
		private PermissionSet m_denied;

		// Token: 0x040010B7 RID: 4279
		private string m_strRequest;

		// Token: 0x040010B8 RID: 4280
		private string m_strOptional;

		// Token: 0x040010B9 RID: 4281
		private string m_strDenied;
	}
}
