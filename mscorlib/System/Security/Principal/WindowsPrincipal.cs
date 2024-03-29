﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security.Claims;
using System.Security.Permissions;
using Microsoft.Win32;
using Microsoft.Win32.SafeHandles;

namespace System.Security.Principal
{
	/// <summary>Enables code to check the Windows group membership of a Windows user.</summary>
	// Token: 0x02000306 RID: 774
	[ComVisible(true)]
	[HostProtection(SecurityAction.LinkDemand, SecurityInfrastructure = true)]
	[Serializable]
	public class WindowsPrincipal : ClaimsPrincipal
	{
		// Token: 0x060027CB RID: 10187 RVA: 0x000923A0 File Offset: 0x000905A0
		private WindowsPrincipal()
		{
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Security.Principal.WindowsPrincipal" /> class by using the specified <see cref="T:System.Security.Principal.WindowsIdentity" /> object.</summary>
		/// <param name="ntIdentity">The object from which to construct the new instance of <see cref="T:System.Security.Principal.WindowsPrincipal" />.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="ntIdentity" /> is <see langword="null" />.</exception>
		// Token: 0x060027CC RID: 10188 RVA: 0x000923A8 File Offset: 0x000905A8
		public WindowsPrincipal(WindowsIdentity ntIdentity) : base(ntIdentity)
		{
			if (ntIdentity == null)
			{
				throw new ArgumentNullException("ntIdentity");
			}
			this.m_identity = ntIdentity;
		}

		// Token: 0x060027CD RID: 10189 RVA: 0x000923C8 File Offset: 0x000905C8
		[OnDeserialized]
		[SecuritySafeCritical]
		private void OnDeserializedMethod(StreamingContext context)
		{
			ClaimsIdentity claimsIdentity = null;
			foreach (ClaimsIdentity claimsIdentity2 in base.Identities)
			{
				if (claimsIdentity2 != null)
				{
					claimsIdentity = claimsIdentity2;
					break;
				}
			}
			if (claimsIdentity == null)
			{
				base.AddIdentity(this.m_identity);
			}
		}

		/// <summary>Gets the identity of the current principal.</summary>
		/// <returns>The <see cref="T:System.Security.Principal.WindowsIdentity" /> object of the current principal.</returns>
		// Token: 0x1700053B RID: 1339
		// (get) Token: 0x060027CE RID: 10190 RVA: 0x00092428 File Offset: 0x00090628
		public override IIdentity Identity
		{
			get
			{
				return this.m_identity;
			}
		}

		/// <summary>Determines whether the current principal belongs to the Windows user group with the specified name.</summary>
		/// <param name="role">The name of the Windows user group for which to check membership.</param>
		/// <returns>
		///   <see langword="true" /> if the current principal is a member of the specified Windows user group; otherwise, <see langword="false" />.</returns>
		// Token: 0x060027CF RID: 10191 RVA: 0x00092430 File Offset: 0x00090630
		[SecuritySafeCritical]
		[SecurityPermission(SecurityAction.Demand, ControlPrincipal = true)]
		public override bool IsInRole(string role)
		{
			if (role == null || role.Length == 0)
			{
				return false;
			}
			NTAccount identity = new NTAccount(role);
			IdentityReferenceCollection identityReferenceCollection = NTAccount.Translate(new IdentityReferenceCollection(1)
			{
				identity
			}, typeof(SecurityIdentifier), false);
			SecurityIdentifier securityIdentifier = identityReferenceCollection[0] as SecurityIdentifier;
			return (securityIdentifier != null && this.IsInRole(securityIdentifier)) || base.IsInRole(role);
		}

		/// <summary>Gets all Windows user claims from this principal.</summary>
		/// <returns>A collection of all Windows user claims from this principal.</returns>
		// Token: 0x1700053C RID: 1340
		// (get) Token: 0x060027D0 RID: 10192 RVA: 0x0009249C File Offset: 0x0009069C
		public virtual IEnumerable<Claim> UserClaims
		{
			get
			{
				foreach (ClaimsIdentity claimsIdentity in this.Identities)
				{
					WindowsIdentity windowsIdentity = claimsIdentity as WindowsIdentity;
					if (windowsIdentity != null)
					{
						foreach (Claim claim in windowsIdentity.UserClaims)
						{
							yield return claim;
						}
						IEnumerator<Claim> enumerator2 = null;
					}
				}
				IEnumerator<ClaimsIdentity> enumerator = null;
				yield break;
				yield break;
			}
		}

		/// <summary>Gets all Windows device claims from this principal.</summary>
		/// <returns>A collection of all Windows device claims from this principal.</returns>
		// Token: 0x1700053D RID: 1341
		// (get) Token: 0x060027D1 RID: 10193 RVA: 0x000924BC File Offset: 0x000906BC
		public virtual IEnumerable<Claim> DeviceClaims
		{
			get
			{
				foreach (ClaimsIdentity claimsIdentity in this.Identities)
				{
					WindowsIdentity windowsIdentity = claimsIdentity as WindowsIdentity;
					if (windowsIdentity != null)
					{
						foreach (Claim claim in windowsIdentity.DeviceClaims)
						{
							yield return claim;
						}
						IEnumerator<Claim> enumerator2 = null;
					}
				}
				IEnumerator<ClaimsIdentity> enumerator = null;
				yield break;
				yield break;
			}
		}

		/// <summary>Determines whether the current principal belongs to the Windows user group with the specified <see cref="T:System.Security.Principal.WindowsBuiltInRole" />.</summary>
		/// <param name="role">One of the <see cref="T:System.Security.Principal.WindowsBuiltInRole" /> values.</param>
		/// <returns>
		///   <see langword="true" /> if the current principal is a member of the specified Windows user group; otherwise, <see langword="false" />.</returns>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="role" /> is not a valid <see cref="T:System.Security.Principal.WindowsBuiltInRole" /> value.</exception>
		// Token: 0x060027D2 RID: 10194 RVA: 0x000924D9 File Offset: 0x000906D9
		public virtual bool IsInRole(WindowsBuiltInRole role)
		{
			if (role < WindowsBuiltInRole.Administrator || role > WindowsBuiltInRole.Replicator)
			{
				throw new ArgumentException(Environment.GetResourceString("Arg_EnumIllegalVal", new object[]
				{
					(int)role
				}), "role");
			}
			return this.IsInRole((int)role);
		}

		/// <summary>Determines whether the current principal belongs to the Windows user group with the specified relative identifier (RID).</summary>
		/// <param name="rid">The RID of the Windows user group in which to check for the principal's membership status.</param>
		/// <returns>
		///   <see langword="true" /> if the current principal is a member of the specified Windows user group, that is, in a particular role; otherwise, <see langword="false" />.</returns>
		// Token: 0x060027D3 RID: 10195 RVA: 0x00092518 File Offset: 0x00090718
		public virtual bool IsInRole(int rid)
		{
			SecurityIdentifier sid = new SecurityIdentifier(IdentifierAuthority.NTAuthority, new int[]
			{
				32,
				rid
			});
			return this.IsInRole(sid);
		}

		/// <summary>Determines whether the current principal belongs to the Windows user group with the specified security identifier (SID).</summary>
		/// <param name="sid">A <see cref="T:System.Security.Principal.SecurityIdentifier" /> that uniquely identifies a Windows user group.</param>
		/// <returns>
		///   <see langword="true" /> if the current principal is a member of the specified Windows user group; otherwise, <see langword="false" />.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="sid" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.Security.SecurityException">Windows returned a Win32 error.</exception>
		// Token: 0x060027D4 RID: 10196 RVA: 0x00092544 File Offset: 0x00090744
		[SecuritySafeCritical]
		[ComVisible(false)]
		public virtual bool IsInRole(SecurityIdentifier sid)
		{
			if (sid == null)
			{
				throw new ArgumentNullException("sid");
			}
			if (this.m_identity.AccessToken.IsInvalid)
			{
				return false;
			}
			SafeAccessTokenHandle invalidHandle = SafeAccessTokenHandle.InvalidHandle;
			if (this.m_identity.ImpersonationLevel == TokenImpersonationLevel.None && !Win32Native.DuplicateTokenEx(this.m_identity.AccessToken, 8U, IntPtr.Zero, 2U, 2U, ref invalidHandle))
			{
				throw new SecurityException(Win32Native.GetMessage(Marshal.GetLastWin32Error()));
			}
			bool result = false;
			if (!Win32Native.CheckTokenMembership((this.m_identity.ImpersonationLevel != TokenImpersonationLevel.None) ? this.m_identity.AccessToken : invalidHandle, sid.BinaryForm, ref result))
			{
				throw new SecurityException(Win32Native.GetMessage(Marshal.GetLastWin32Error()));
			}
			invalidHandle.Dispose();
			return result;
		}

		// Token: 0x04000FD1 RID: 4049
		private WindowsIdentity m_identity;

		// Token: 0x04000FD2 RID: 4050
		private string[] m_roles;

		// Token: 0x04000FD3 RID: 4051
		private Hashtable m_rolesTable;

		// Token: 0x04000FD4 RID: 4052
		private bool m_rolesLoaded;
	}
}
