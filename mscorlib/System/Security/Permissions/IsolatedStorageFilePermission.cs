﻿using System;
using System.Runtime.InteropServices;

namespace System.Security.Permissions
{
	/// <summary>Specifies the allowed usage of a private virtual file system. This class cannot be inherited.</summary>
	// Token: 0x020002BF RID: 703
	[ComVisible(true)]
	[Serializable]
	public sealed class IsolatedStorageFilePermission : IsolatedStoragePermission, IBuiltInPermission
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Security.Permissions.IsolatedStorageFilePermission" /> class with either fully restricted or unrestricted permission as specified.</summary>
		/// <param name="state">One of the <see cref="T:System.Security.Permissions.PermissionState" /> values.</param>
		/// <exception cref="T:System.ArgumentException">The <paramref name="state" /> parameter is not a valid value of <see cref="T:System.Security.Permissions.PermissionState" />.</exception>
		// Token: 0x0600252C RID: 9516 RVA: 0x00087576 File Offset: 0x00085776
		public IsolatedStorageFilePermission(PermissionState state) : base(state)
		{
		}

		// Token: 0x0600252D RID: 9517 RVA: 0x0008757F File Offset: 0x0008577F
		internal IsolatedStorageFilePermission(IsolatedStorageContainment UsageAllowed, long ExpirationDays, bool PermanentData) : base(UsageAllowed, ExpirationDays, PermanentData)
		{
		}

		/// <summary>Creates a permission that is the union of the current permission and the specified permission.</summary>
		/// <param name="target">A permission to combine with the current permission. It must be of the same type as the current permission.</param>
		/// <returns>A new permission that represents the union of the current permission and the specified permission.</returns>
		/// <exception cref="T:System.ArgumentException">The <paramref name="target" /> parameter is not <see langword="null" /> and is not of the same type as the current permission.</exception>
		// Token: 0x0600252E RID: 9518 RVA: 0x0008758C File Offset: 0x0008578C
		public override IPermission Union(IPermission target)
		{
			if (target == null)
			{
				return this.Copy();
			}
			if (!base.VerifyType(target))
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_WrongType", new object[]
				{
					base.GetType().FullName
				}));
			}
			IsolatedStorageFilePermission isolatedStorageFilePermission = (IsolatedStorageFilePermission)target;
			if (base.IsUnrestricted() || isolatedStorageFilePermission.IsUnrestricted())
			{
				return new IsolatedStorageFilePermission(PermissionState.Unrestricted);
			}
			return new IsolatedStorageFilePermission(PermissionState.None)
			{
				m_userQuota = IsolatedStoragePermission.max(this.m_userQuota, isolatedStorageFilePermission.m_userQuota),
				m_machineQuota = IsolatedStoragePermission.max(this.m_machineQuota, isolatedStorageFilePermission.m_machineQuota),
				m_expirationDays = IsolatedStoragePermission.max(this.m_expirationDays, isolatedStorageFilePermission.m_expirationDays),
				m_permanentData = (this.m_permanentData || isolatedStorageFilePermission.m_permanentData),
				m_allowed = (IsolatedStorageContainment)IsolatedStoragePermission.max((long)this.m_allowed, (long)isolatedStorageFilePermission.m_allowed)
			};
		}

		/// <summary>Determines whether the current permission is a subset of the specified permission.</summary>
		/// <param name="target">A permission that is to be tested for the subset relationship. This permission must be of the same type as the current permission.</param>
		/// <returns>
		///   <see langword="true" /> if the current permission is a subset of the specified permission; otherwise, <see langword="false" />.</returns>
		/// <exception cref="T:System.ArgumentException">The <paramref name="target" /> parameter is not <see langword="null" /> and is not of the same type as the current permission.</exception>
		// Token: 0x0600252F RID: 9519 RVA: 0x0008766C File Offset: 0x0008586C
		public override bool IsSubsetOf(IPermission target)
		{
			if (target == null)
			{
				return this.m_userQuota == 0L && this.m_machineQuota == 0L && this.m_expirationDays == 0L && !this.m_permanentData && this.m_allowed == IsolatedStorageContainment.None;
			}
			bool result;
			try
			{
				IsolatedStorageFilePermission isolatedStorageFilePermission = (IsolatedStorageFilePermission)target;
				if (isolatedStorageFilePermission.IsUnrestricted())
				{
					result = true;
				}
				else
				{
					result = (isolatedStorageFilePermission.m_userQuota >= this.m_userQuota && isolatedStorageFilePermission.m_machineQuota >= this.m_machineQuota && isolatedStorageFilePermission.m_expirationDays >= this.m_expirationDays && (isolatedStorageFilePermission.m_permanentData || !this.m_permanentData) && isolatedStorageFilePermission.m_allowed >= this.m_allowed);
				}
			}
			catch (InvalidCastException)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_WrongType", new object[]
				{
					base.GetType().FullName
				}));
			}
			return result;
		}

		/// <summary>Creates and returns a permission that is the intersection of the current permission and the specified permission.</summary>
		/// <param name="target">A permission to intersect with the current permission object. It must be of the same type as the current permission.</param>
		/// <returns>A new permission that represents the intersection of the current permission and the specified permission. This new permission is <see langword="null" /> if the intersection is empty.</returns>
		/// <exception cref="T:System.ArgumentException">The <paramref name="target" /> parameter is not <see langword="null" /> and is not of the same type as the current permission.</exception>
		// Token: 0x06002530 RID: 9520 RVA: 0x00087744 File Offset: 0x00085944
		public override IPermission Intersect(IPermission target)
		{
			if (target == null)
			{
				return null;
			}
			if (!base.VerifyType(target))
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_WrongType", new object[]
				{
					base.GetType().FullName
				}));
			}
			IsolatedStorageFilePermission isolatedStorageFilePermission = (IsolatedStorageFilePermission)target;
			if (isolatedStorageFilePermission.IsUnrestricted())
			{
				return this.Copy();
			}
			if (base.IsUnrestricted())
			{
				return target.Copy();
			}
			IsolatedStorageFilePermission isolatedStorageFilePermission2 = new IsolatedStorageFilePermission(PermissionState.None);
			isolatedStorageFilePermission2.m_userQuota = IsolatedStoragePermission.min(this.m_userQuota, isolatedStorageFilePermission.m_userQuota);
			isolatedStorageFilePermission2.m_machineQuota = IsolatedStoragePermission.min(this.m_machineQuota, isolatedStorageFilePermission.m_machineQuota);
			isolatedStorageFilePermission2.m_expirationDays = IsolatedStoragePermission.min(this.m_expirationDays, isolatedStorageFilePermission.m_expirationDays);
			isolatedStorageFilePermission2.m_permanentData = (this.m_permanentData && isolatedStorageFilePermission.m_permanentData);
			isolatedStorageFilePermission2.m_allowed = (IsolatedStorageContainment)IsolatedStoragePermission.min((long)this.m_allowed, (long)isolatedStorageFilePermission.m_allowed);
			if (isolatedStorageFilePermission2.m_userQuota == 0L && isolatedStorageFilePermission2.m_machineQuota == 0L && isolatedStorageFilePermission2.m_expirationDays == 0L && !isolatedStorageFilePermission2.m_permanentData && isolatedStorageFilePermission2.m_allowed == IsolatedStorageContainment.None)
			{
				return null;
			}
			return isolatedStorageFilePermission2;
		}

		/// <summary>Creates and returns an identical copy of the current permission.</summary>
		/// <returns>A copy of the current permission.</returns>
		// Token: 0x06002531 RID: 9521 RVA: 0x00087850 File Offset: 0x00085A50
		public override IPermission Copy()
		{
			IsolatedStorageFilePermission isolatedStorageFilePermission = new IsolatedStorageFilePermission(PermissionState.Unrestricted);
			if (!base.IsUnrestricted())
			{
				isolatedStorageFilePermission.m_userQuota = this.m_userQuota;
				isolatedStorageFilePermission.m_machineQuota = this.m_machineQuota;
				isolatedStorageFilePermission.m_expirationDays = this.m_expirationDays;
				isolatedStorageFilePermission.m_permanentData = this.m_permanentData;
				isolatedStorageFilePermission.m_allowed = this.m_allowed;
			}
			return isolatedStorageFilePermission;
		}

		// Token: 0x06002532 RID: 9522 RVA: 0x000878A9 File Offset: 0x00085AA9
		int IBuiltInPermission.GetTokenIndex()
		{
			return IsolatedStorageFilePermission.GetTokenIndex();
		}

		// Token: 0x06002533 RID: 9523 RVA: 0x000878B0 File Offset: 0x00085AB0
		internal static int GetTokenIndex()
		{
			return 3;
		}

		/// <summary>Creates an XML encoding of the permission and its current state.</summary>
		/// <returns>An XML encoding of the permission, including any state information.</returns>
		// Token: 0x06002534 RID: 9524 RVA: 0x000878B3 File Offset: 0x00085AB3
		[ComVisible(false)]
		public override SecurityElement ToXml()
		{
			return base.ToXml("System.Security.Permissions.IsolatedStorageFilePermission");
		}
	}
}
