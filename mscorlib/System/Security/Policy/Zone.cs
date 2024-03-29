﻿using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace System.Security.Policy
{
	/// <summary>Provides the security zone of a code assembly as evidence for policy evaluation. This class cannot be inherited.</summary>
	// Token: 0x02000344 RID: 836
	[ComVisible(true)]
	[Serializable]
	public sealed class Zone : EvidenceBase, IIdentityPermissionFactory
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Security.Policy.Zone" /> class with the zone from which a code assembly originates.</summary>
		/// <param name="zone">The zone of origin for the associated code assembly.</param>
		/// <exception cref="T:System.ArgumentException">The <paramref name="zone" /> parameter is not a valid <see cref="T:System.Security.SecurityZone" />.</exception>
		// Token: 0x06002A7B RID: 10875 RVA: 0x0009DF3D File Offset: 0x0009C13D
		public Zone(SecurityZone zone)
		{
			if (zone < SecurityZone.NoZone || zone > SecurityZone.Untrusted)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_IllegalZone"));
			}
			this.m_zone = zone;
		}

		// Token: 0x06002A7C RID: 10876 RVA: 0x0009DF64 File Offset: 0x0009C164
		private Zone(Zone zone)
		{
			this.m_url = zone.m_url;
			this.m_zone = zone.m_zone;
		}

		// Token: 0x06002A7D RID: 10877 RVA: 0x0009DF84 File Offset: 0x0009C184
		private Zone(string url)
		{
			this.m_url = url;
			this.m_zone = SecurityZone.NoZone;
		}

		/// <summary>Creates a new zone with the specified URL.</summary>
		/// <param name="url">The URL from which to create the zone.</param>
		/// <returns>A new zone with the specified URL.</returns>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="url" /> parameter is <see langword="null" />.</exception>
		// Token: 0x06002A7E RID: 10878 RVA: 0x0009DF9A File Offset: 0x0009C19A
		public static Zone CreateFromUrl(string url)
		{
			if (url == null)
			{
				throw new ArgumentNullException("url");
			}
			return new Zone(url);
		}

		// Token: 0x06002A7F RID: 10879
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		private static extern SecurityZone _CreateFromUrl(string url);

		/// <summary>Creates an identity permission that corresponds to the current instance of the <see cref="T:System.Security.Policy.Zone" /> evidence class.</summary>
		/// <param name="evidence">The evidence set from which to construct the identity permission.</param>
		/// <returns>A <see cref="T:System.Security.Permissions.ZoneIdentityPermission" /> for the specified <see cref="T:System.Security.Policy.Zone" /> evidence.</returns>
		// Token: 0x06002A80 RID: 10880 RVA: 0x0009DFB0 File Offset: 0x0009C1B0
		public IPermission CreateIdentityPermission(Evidence evidence)
		{
			return new ZoneIdentityPermission(this.SecurityZone);
		}

		/// <summary>Gets the zone from which the code assembly originates.</summary>
		/// <returns>The zone from which the code assembly originates.</returns>
		// Token: 0x170005BD RID: 1469
		// (get) Token: 0x06002A81 RID: 10881 RVA: 0x0009DFBD File Offset: 0x0009C1BD
		public SecurityZone SecurityZone
		{
			[SecuritySafeCritical]
			get
			{
				if (this.m_url != null)
				{
					this.m_zone = Zone._CreateFromUrl(this.m_url);
				}
				return this.m_zone;
			}
		}

		/// <summary>Compares the current <see cref="T:System.Security.Policy.Zone" /> evidence object to the specified object for equivalence.</summary>
		/// <param name="o">The <see cref="T:System.Security.Policy.Zone" /> evidence object to test for equivalence with the current object.</param>
		/// <returns>
		///   <see langword="true" /> if the two <see cref="T:System.Security.Policy.Zone" /> objects are equal; otherwise, <see langword="false" />.</returns>
		/// <exception cref="T:System.ArgumentException">The <paramref name="o" /> parameter is not a <see cref="T:System.Security.Policy.Zone" /> object.</exception>
		// Token: 0x06002A82 RID: 10882 RVA: 0x0009DFE0 File Offset: 0x0009C1E0
		public override bool Equals(object o)
		{
			Zone zone = o as Zone;
			return zone != null && this.SecurityZone == zone.SecurityZone;
		}

		/// <summary>Gets the hash code of the current zone.</summary>
		/// <returns>The hash code of the current zone.</returns>
		// Token: 0x06002A83 RID: 10883 RVA: 0x0009E007 File Offset: 0x0009C207
		public override int GetHashCode()
		{
			return (int)this.SecurityZone;
		}

		/// <summary>Creates a new object that is a copy of the current instance.</summary>
		/// <returns>A new object that is a copy of this instance.</returns>
		// Token: 0x06002A84 RID: 10884 RVA: 0x0009E00F File Offset: 0x0009C20F
		public override EvidenceBase Clone()
		{
			return new Zone(this);
		}

		/// <summary>Creates an equivalent copy of the evidence object.</summary>
		/// <returns>A new, identical copy of the evidence object.</returns>
		// Token: 0x06002A85 RID: 10885 RVA: 0x0009E017 File Offset: 0x0009C217
		public object Copy()
		{
			return this.Clone();
		}

		// Token: 0x06002A86 RID: 10886 RVA: 0x0009E020 File Offset: 0x0009C220
		internal SecurityElement ToXml()
		{
			SecurityElement securityElement = new SecurityElement("System.Security.Policy.Zone");
			securityElement.AddAttribute("version", "1");
			if (this.SecurityZone != SecurityZone.NoZone)
			{
				securityElement.AddChild(new SecurityElement("Zone", Zone.s_names[(int)this.SecurityZone]));
			}
			else
			{
				securityElement.AddChild(new SecurityElement("Zone", Zone.s_names[Zone.s_names.Length - 1]));
			}
			return securityElement;
		}

		/// <summary>Returns a string representation of the current <see cref="T:System.Security.Policy.Zone" />.</summary>
		/// <returns>A representation of the current <see cref="T:System.Security.Policy.Zone" />.</returns>
		// Token: 0x06002A87 RID: 10887 RVA: 0x0009E08F File Offset: 0x0009C28F
		public override string ToString()
		{
			return this.ToXml().ToString();
		}

		// Token: 0x06002A88 RID: 10888 RVA: 0x0009E09C File Offset: 0x0009C29C
		internal object Normalize()
		{
			return Zone.s_names[(int)this.SecurityZone];
		}

		// Token: 0x040010EF RID: 4335
		[OptionalField(VersionAdded = 2)]
		private string m_url;

		// Token: 0x040010F0 RID: 4336
		private SecurityZone m_zone;

		// Token: 0x040010F1 RID: 4337
		private static readonly string[] s_names = new string[]
		{
			"MyComputer",
			"Intranet",
			"Trusted",
			"Internet",
			"Untrusted",
			"NoZone"
		};
	}
}
