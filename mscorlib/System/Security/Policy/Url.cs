﻿using System;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Security.Util;

namespace System.Security.Policy
{
	/// <summary>Provides the URL from which a code assembly originates as evidence for policy evaluation. This class cannot be inherited.</summary>
	// Token: 0x02000342 RID: 834
	[ComVisible(true)]
	[Serializable]
	public sealed class Url : EvidenceBase, IIdentityPermissionFactory
	{
		// Token: 0x06002A5F RID: 10847 RVA: 0x0009DA26 File Offset: 0x0009BC26
		internal Url(string name, bool parsed)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			this.m_url = new URLString(name, parsed);
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Security.Policy.Url" /> class with the URL from which a code assembly originates.</summary>
		/// <param name="name">The URL of origin for the associated code assembly.</param>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="name" /> parameter is <see langword="null" />.</exception>
		// Token: 0x06002A60 RID: 10848 RVA: 0x0009DA49 File Offset: 0x0009BC49
		public Url(string name)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			this.m_url = new URLString(name);
		}

		// Token: 0x06002A61 RID: 10849 RVA: 0x0009DA6B File Offset: 0x0009BC6B
		private Url(Url url)
		{
			this.m_url = url.m_url;
		}

		/// <summary>Gets the URL from which the code assembly originates.</summary>
		/// <returns>The URL from which the code assembly originates.</returns>
		// Token: 0x170005BB RID: 1467
		// (get) Token: 0x06002A62 RID: 10850 RVA: 0x0009DA7F File Offset: 0x0009BC7F
		public string Value
		{
			get
			{
				return this.m_url.ToString();
			}
		}

		// Token: 0x06002A63 RID: 10851 RVA: 0x0009DA8C File Offset: 0x0009BC8C
		internal URLString GetURLString()
		{
			return this.m_url;
		}

		/// <summary>Creates an identity permission corresponding to the current instance of the <see cref="T:System.Security.Policy.Url" /> evidence class.</summary>
		/// <param name="evidence">The evidence set from which to construct the identity permission.</param>
		/// <returns>A <see cref="T:System.Security.Permissions.UrlIdentityPermission" /> for the specified <see cref="T:System.Security.Policy.Url" /> evidence.</returns>
		// Token: 0x06002A64 RID: 10852 RVA: 0x0009DA94 File Offset: 0x0009BC94
		public IPermission CreateIdentityPermission(Evidence evidence)
		{
			return new UrlIdentityPermission(this.m_url);
		}

		/// <summary>Compares the current <see cref="T:System.Security.Policy.Url" /> evidence object to the specified object for equivalence.</summary>
		/// <param name="o">The <see cref="T:System.Security.Policy.Url" /> evidence object to test for equivalence with the current object.</param>
		/// <returns>
		///   <see langword="true" /> if the two <see cref="T:System.Security.Policy.Url" /> objects are equal; otherwise, <see langword="false" />.</returns>
		// Token: 0x06002A65 RID: 10853 RVA: 0x0009DAA4 File Offset: 0x0009BCA4
		public override bool Equals(object o)
		{
			Url url = o as Url;
			return url != null && url.m_url.Equals(this.m_url);
		}

		/// <summary>Gets the hash code of the current URL.</summary>
		/// <returns>The hash code of the current URL.</returns>
		// Token: 0x06002A66 RID: 10854 RVA: 0x0009DACE File Offset: 0x0009BCCE
		public override int GetHashCode()
		{
			return this.m_url.GetHashCode();
		}

		/// <summary>Creates a new object that is a copy of the current instance.</summary>
		/// <returns>A new object that is a copy of this instance.</returns>
		// Token: 0x06002A67 RID: 10855 RVA: 0x0009DADB File Offset: 0x0009BCDB
		public override EvidenceBase Clone()
		{
			return new Url(this);
		}

		/// <summary>Creates a new copy of the evidence object.</summary>
		/// <returns>A new, identical copy of the evidence object.</returns>
		// Token: 0x06002A68 RID: 10856 RVA: 0x0009DAE3 File Offset: 0x0009BCE3
		public object Copy()
		{
			return this.Clone();
		}

		// Token: 0x06002A69 RID: 10857 RVA: 0x0009DAEC File Offset: 0x0009BCEC
		internal SecurityElement ToXml()
		{
			SecurityElement securityElement = new SecurityElement("System.Security.Policy.Url");
			securityElement.AddAttribute("version", "1");
			if (this.m_url != null)
			{
				securityElement.AddChild(new SecurityElement("Url", this.m_url.ToString()));
			}
			return securityElement;
		}

		/// <summary>Returns a string representation of the current <see cref="T:System.Security.Policy.Url" />.</summary>
		/// <returns>A representation of the current <see cref="T:System.Security.Policy.Url" />.</returns>
		// Token: 0x06002A6A RID: 10858 RVA: 0x0009DB38 File Offset: 0x0009BD38
		public override string ToString()
		{
			return this.ToXml().ToString();
		}

		// Token: 0x06002A6B RID: 10859 RVA: 0x0009DB45 File Offset: 0x0009BD45
		internal object Normalize()
		{
			return this.m_url.NormalizeUrl();
		}

		// Token: 0x040010EC RID: 4332
		private URLString m_url;
	}
}
