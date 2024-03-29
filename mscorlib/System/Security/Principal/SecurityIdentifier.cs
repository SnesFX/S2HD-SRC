﻿using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text;
using Microsoft.Win32;
using Microsoft.Win32.SafeHandles;

namespace System.Security.Principal
{
	/// <summary>Represents a security identifier (SID) and provides marshaling and comparison operations for SIDs.</summary>
	// Token: 0x0200030E RID: 782
	[ComVisible(false)]
	public sealed class SecurityIdentifier : IdentityReference, IComparable<SecurityIdentifier>
	{
		// Token: 0x06002801 RID: 10241 RVA: 0x000932B4 File Offset: 0x000914B4
		private void CreateFromParts(IdentifierAuthority identifierAuthority, int[] subAuthorities)
		{
			if (subAuthorities == null)
			{
				throw new ArgumentNullException("subAuthorities");
			}
			if (subAuthorities.Length > (int)SecurityIdentifier.MaxSubAuthorities)
			{
				throw new ArgumentOutOfRangeException("subAuthorities.Length", subAuthorities.Length, Environment.GetResourceString("IdentityReference_InvalidNumberOfSubauthorities", new object[]
				{
					SecurityIdentifier.MaxSubAuthorities
				}));
			}
			if (identifierAuthority < IdentifierAuthority.NullAuthority || identifierAuthority > (IdentifierAuthority)SecurityIdentifier.MaxIdentifierAuthority)
			{
				throw new ArgumentOutOfRangeException("identifierAuthority", identifierAuthority, Environment.GetResourceString("IdentityReference_IdentifierAuthorityTooLarge"));
			}
			this._IdentifierAuthority = identifierAuthority;
			this._SubAuthorities = new int[subAuthorities.Length];
			subAuthorities.CopyTo(this._SubAuthorities, 0);
			this._BinaryForm = new byte[8 + 4 * this.SubAuthorityCount];
			this._BinaryForm[0] = SecurityIdentifier.Revision;
			this._BinaryForm[1] = (byte)this.SubAuthorityCount;
			byte b;
			for (b = 0; b < 6; b += 1)
			{
				this._BinaryForm[(int)(2 + b)] = (byte)(this._IdentifierAuthority >> (int)((5 - b) * 8 & 63) & (IdentifierAuthority)255L);
			}
			b = 0;
			while ((int)b < this.SubAuthorityCount)
			{
				for (byte b2 = 0; b2 < 4; b2 += 1)
				{
					this._BinaryForm[(int)(8 + 4 * b + b2)] = (byte)((ulong)((long)this._SubAuthorities[(int)b]) >> (int)(b2 * 8));
				}
				b += 1;
			}
		}

		// Token: 0x06002802 RID: 10242 RVA: 0x000933F0 File Offset: 0x000915F0
		private void CreateFromBinaryForm(byte[] binaryForm, int offset)
		{
			if (binaryForm == null)
			{
				throw new ArgumentNullException("binaryForm");
			}
			if (offset < 0)
			{
				throw new ArgumentOutOfRangeException("offset", offset, Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
			}
			if (binaryForm.Length - offset < SecurityIdentifier.MinBinaryLength)
			{
				throw new ArgumentOutOfRangeException("binaryForm", Environment.GetResourceString("ArgumentOutOfRange_ArrayTooSmall"));
			}
			if (binaryForm[offset] != SecurityIdentifier.Revision)
			{
				throw new ArgumentException(Environment.GetResourceString("IdentityReference_InvalidSidRevision"), "binaryForm");
			}
			if (binaryForm[offset + 1] > SecurityIdentifier.MaxSubAuthorities)
			{
				throw new ArgumentException(Environment.GetResourceString("IdentityReference_InvalidNumberOfSubauthorities", new object[]
				{
					SecurityIdentifier.MaxSubAuthorities
				}), "binaryForm");
			}
			int num = (int)(8 + 4 * binaryForm[offset + 1]);
			if (binaryForm.Length - offset < num)
			{
				throw new ArgumentException(Environment.GetResourceString("ArgumentOutOfRange_ArrayTooSmall"), "binaryForm");
			}
			IdentifierAuthority identifierAuthority = (IdentifierAuthority)(((ulong)binaryForm[offset + 2] << 40) + ((ulong)binaryForm[offset + 3] << 32) + ((ulong)binaryForm[offset + 4] << 24) + ((ulong)binaryForm[offset + 5] << 16) + ((ulong)binaryForm[offset + 6] << 8) + (ulong)binaryForm[offset + 7]);
			int[] array = new int[(int)binaryForm[offset + 1]];
			for (byte b = 0; b < binaryForm[offset + 1]; b += 1)
			{
				array[(int)b] = (int)binaryForm[offset + 8 + (int)(4 * b)] + ((int)binaryForm[offset + 8 + (int)(4 * b) + 1] << 8) + ((int)binaryForm[offset + 8 + (int)(4 * b) + 2] << 16) + ((int)binaryForm[offset + 8 + (int)(4 * b) + 3] << 24);
			}
			this.CreateFromParts(identifierAuthority, array);
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Security.Principal.SecurityIdentifier" /> class by using the specified security identifier (SID) in Security Descriptor Definition Language (SDDL) format.</summary>
		/// <param name="sddlForm">SDDL string for the SID used to create the <see cref="T:System.Security.Principal.SecurityIdentifier" /> object.</param>
		// Token: 0x06002803 RID: 10243 RVA: 0x0009355C File Offset: 0x0009175C
		[SecuritySafeCritical]
		public SecurityIdentifier(string sddlForm)
		{
			if (sddlForm == null)
			{
				throw new ArgumentNullException("sddlForm");
			}
			byte[] binaryForm;
			int num = Win32.CreateSidFromString(sddlForm, out binaryForm);
			if (num == 1337)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_InvalidValue"), "sddlForm");
			}
			if (num == 8)
			{
				throw new OutOfMemoryException();
			}
			if (num != 0)
			{
				throw new SystemException(Win32Native.GetMessage(num));
			}
			this.CreateFromBinaryForm(binaryForm, 0);
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Security.Principal.SecurityIdentifier" /> class by using a specified binary representation of a security identifier (SID).</summary>
		/// <param name="binaryForm">The byte array that represents the SID.</param>
		/// <param name="offset">The byte offset to use as the starting index in <paramref name="binaryForm" />.</param>
		// Token: 0x06002804 RID: 10244 RVA: 0x000935C4 File Offset: 0x000917C4
		public SecurityIdentifier(byte[] binaryForm, int offset)
		{
			this.CreateFromBinaryForm(binaryForm, offset);
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Security.Principal.SecurityIdentifier" /> class by using an integer that represents the binary form of a security identifier (SID).</summary>
		/// <param name="binaryForm">An integer that represents the binary form of a SID.</param>
		// Token: 0x06002805 RID: 10245 RVA: 0x000935D4 File Offset: 0x000917D4
		[SecuritySafeCritical]
		[SecurityPermission(SecurityAction.Demand, UnmanagedCode = true)]
		public SecurityIdentifier(IntPtr binaryForm) : this(binaryForm, true)
		{
		}

		// Token: 0x06002806 RID: 10246 RVA: 0x000935DE File Offset: 0x000917DE
		[SecurityCritical]
		internal SecurityIdentifier(IntPtr binaryForm, bool noDemand) : this(Win32.ConvertIntPtrSidToByteArraySid(binaryForm), 0)
		{
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Security.Principal.SecurityIdentifier" /> class by using the specified well known security identifier (SID) type and domain SID.</summary>
		/// <param name="sidType">One of the enumeration values. This value must not be <see cref="F:System.Security.Principal.WellKnownSidType.LogonIdsSid" />.</param>
		/// <param name="domainSid">The domain SID. This value is required for the following <see cref="T:System.Security.Principal.WellKnownSidType" /> values. This parameter is ignored for any other <see cref="T:System.Security.Principal.WellKnownSidType" /> values.  
		///  - <see cref="F:System.Security.Principal.WellKnownSidType.AccountAdministratorSid" />  
		///  - <see cref="F:System.Security.Principal.WellKnownSidType.AccountGuestSid" />  
		///  - <see cref="F:System.Security.Principal.WellKnownSidType.AccountKrbtgtSid" />  
		///  - <see cref="F:System.Security.Principal.WellKnownSidType.AccountDomainAdminsSid" />  
		///  - <see cref="F:System.Security.Principal.WellKnownSidType.AccountDomainUsersSid" />  
		///  - <see cref="F:System.Security.Principal.WellKnownSidType.AccountDomainGuestsSid" />  
		///  - <see cref="F:System.Security.Principal.WellKnownSidType.AccountComputersSid" />  
		///  - <see cref="F:System.Security.Principal.WellKnownSidType.AccountControllersSid" />  
		///  - <see cref="F:System.Security.Principal.WellKnownSidType.AccountCertAdminsSid" />  
		///  - <see cref="F:System.Security.Principal.WellKnownSidType.AccountSchemaAdminsSid" />  
		///  - <see cref="F:System.Security.Principal.WellKnownSidType.AccountEnterpriseAdminsSid" />  
		///  - <see cref="F:System.Security.Principal.WellKnownSidType.AccountPolicyAdminsSid" />  
		///  - <see cref="F:System.Security.Principal.WellKnownSidType.AccountRasAndIasServersSid" /></param>
		// Token: 0x06002807 RID: 10247 RVA: 0x000935F0 File Offset: 0x000917F0
		[SecuritySafeCritical]
		public SecurityIdentifier(WellKnownSidType sidType, SecurityIdentifier domainSid)
		{
			if (sidType == WellKnownSidType.LogonIdsSid)
			{
				throw new ArgumentException(Environment.GetResourceString("IdentityReference_CannotCreateLogonIdsSid"), "sidType");
			}
			if (!Win32.WellKnownSidApisSupported)
			{
				throw new PlatformNotSupportedException(Environment.GetResourceString("PlatformNotSupported_RequiresW2kSP3"));
			}
			if (sidType < WellKnownSidType.NullSid || sidType > WellKnownSidType.WinBuiltinTerminalServerLicenseServersSid)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_InvalidValue"), "sidType");
			}
			if (sidType >= WellKnownSidType.AccountAdministratorSid && sidType <= WellKnownSidType.AccountRasAndIasServersSid)
			{
				if (domainSid == null)
				{
					throw new ArgumentNullException("domainSid", Environment.GetResourceString("IdentityReference_DomainSidRequired", new object[]
					{
						sidType
					}));
				}
				SecurityIdentifier left;
				int windowsAccountDomainSid = Win32.GetWindowsAccountDomainSid(domainSid, out left);
				if (windowsAccountDomainSid == 122)
				{
					throw new OutOfMemoryException();
				}
				if (windowsAccountDomainSid == 1257)
				{
					throw new ArgumentException(Environment.GetResourceString("IdentityReference_NotAWindowsDomain"), "domainSid");
				}
				if (windowsAccountDomainSid != 0)
				{
					throw new SystemException(Win32Native.GetMessage(windowsAccountDomainSid));
				}
				if (left != domainSid)
				{
					throw new ArgumentException(Environment.GetResourceString("IdentityReference_NotAWindowsDomain"), "domainSid");
				}
			}
			byte[] binaryForm;
			int num = Win32.CreateWellKnownSid(sidType, domainSid, out binaryForm);
			if (num == 87)
			{
				throw new ArgumentException(Win32Native.GetMessage(num), "sidType/domainSid");
			}
			if (num != 0)
			{
				throw new SystemException(Win32Native.GetMessage(num));
			}
			this.CreateFromBinaryForm(binaryForm, 0);
		}

		// Token: 0x06002808 RID: 10248 RVA: 0x00093724 File Offset: 0x00091924
		internal SecurityIdentifier(SecurityIdentifier domainSid, uint rid)
		{
			int[] array = new int[domainSid.SubAuthorityCount + 1];
			int i;
			for (i = 0; i < domainSid.SubAuthorityCount; i++)
			{
				array[i] = domainSid.GetSubAuthority(i);
			}
			array[i] = (int)rid;
			this.CreateFromParts(domainSid.IdentifierAuthority, array);
		}

		// Token: 0x06002809 RID: 10249 RVA: 0x00093771 File Offset: 0x00091971
		internal SecurityIdentifier(IdentifierAuthority identifierAuthority, int[] subAuthorities)
		{
			this.CreateFromParts(identifierAuthority, subAuthorities);
		}

		// Token: 0x17000546 RID: 1350
		// (get) Token: 0x0600280A RID: 10250 RVA: 0x00093781 File Offset: 0x00091981
		internal static byte Revision
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x17000547 RID: 1351
		// (get) Token: 0x0600280B RID: 10251 RVA: 0x00093784 File Offset: 0x00091984
		internal byte[] BinaryForm
		{
			get
			{
				return this._BinaryForm;
			}
		}

		// Token: 0x17000548 RID: 1352
		// (get) Token: 0x0600280C RID: 10252 RVA: 0x0009378C File Offset: 0x0009198C
		internal IdentifierAuthority IdentifierAuthority
		{
			get
			{
				return this._IdentifierAuthority;
			}
		}

		// Token: 0x17000549 RID: 1353
		// (get) Token: 0x0600280D RID: 10253 RVA: 0x00093794 File Offset: 0x00091994
		internal int SubAuthorityCount
		{
			get
			{
				return this._SubAuthorities.Length;
			}
		}

		/// <summary>Returns the length, in bytes, of the security identifier (SID) represented by the <see cref="T:System.Security.Principal.SecurityIdentifier" /> object.</summary>
		/// <returns>The length, in bytes, of the SID represented by the <see cref="T:System.Security.Principal.SecurityIdentifier" /> object.</returns>
		// Token: 0x1700054A RID: 1354
		// (get) Token: 0x0600280E RID: 10254 RVA: 0x0009379E File Offset: 0x0009199E
		public int BinaryLength
		{
			get
			{
				return this._BinaryForm.Length;
			}
		}

		/// <summary>Returns the account domain security identifier (SID) portion from the SID represented by the <see cref="T:System.Security.Principal.SecurityIdentifier" /> object if the SID represents a Windows account SID. If the SID does not represent a Windows account SID, this property returns <see cref="T:System.ArgumentNullException" />.</summary>
		/// <returns>The account domain SID portion from the SID represented by the <see cref="T:System.Security.Principal.SecurityIdentifier" /> object if the SID represents a Windows account SID; otherwise, it returns <see cref="T:System.ArgumentNullException" />.</returns>
		// Token: 0x1700054B RID: 1355
		// (get) Token: 0x0600280F RID: 10255 RVA: 0x000937A8 File Offset: 0x000919A8
		public SecurityIdentifier AccountDomainSid
		{
			[SecuritySafeCritical]
			get
			{
				if (!this._AccountDomainSidInitialized)
				{
					this._AccountDomainSid = this.GetAccountDomainSid();
					this._AccountDomainSidInitialized = true;
				}
				return this._AccountDomainSid;
			}
		}

		/// <summary>Returns a value that indicates whether this <see cref="T:System.Security.Principal.SecurityIdentifier" /> object is equal to a specified object.</summary>
		/// <param name="o">An object to compare with this <see cref="T:System.Security.Principal.SecurityIdentifier" /> object, or <see langword="null" />.</param>
		/// <returns>
		///   <see langword="true" /> if <paramref name="o" /> is an object with the same underlying type and value as this <see cref="T:System.Security.Principal.SecurityIdentifier" /> object; otherwise, <see langword="false" />.</returns>
		// Token: 0x06002810 RID: 10256 RVA: 0x000937CC File Offset: 0x000919CC
		public override bool Equals(object o)
		{
			if (o == null)
			{
				return false;
			}
			SecurityIdentifier securityIdentifier = o as SecurityIdentifier;
			return !(securityIdentifier == null) && this == securityIdentifier;
		}

		/// <summary>Indicates whether the specified <see cref="T:System.Security.Principal.SecurityIdentifier" /> object is equal to the current <see cref="T:System.Security.Principal.SecurityIdentifier" /> object.</summary>
		/// <param name="sid">The object to compare with the current object.</param>
		/// <returns>
		///   <see langword="true" /> if the value of <paramref name="sid" /> is equal to the value of the current <see cref="T:System.Security.Principal.SecurityIdentifier" /> object.</returns>
		// Token: 0x06002811 RID: 10257 RVA: 0x000937F7 File Offset: 0x000919F7
		public bool Equals(SecurityIdentifier sid)
		{
			return !(sid == null) && this == sid;
		}

		/// <summary>Serves as a hash function for the current <see cref="T:System.Security.Principal.SecurityIdentifier" /> object. The <see cref="M:System.Security.Principal.SecurityIdentifier.GetHashCode" /> method is suitable for hashing algorithms and data structures like a hash table.</summary>
		/// <returns>A hash value for the current <see cref="T:System.Security.Principal.SecurityIdentifier" /> object.</returns>
		// Token: 0x06002812 RID: 10258 RVA: 0x0009380C File Offset: 0x00091A0C
		public override int GetHashCode()
		{
			int num = ((long)this.IdentifierAuthority).GetHashCode();
			for (int i = 0; i < this.SubAuthorityCount; i++)
			{
				num ^= this.GetSubAuthority(i);
			}
			return num;
		}

		/// <summary>Returns the security identifier (SID), in Security Descriptor Definition Language (SDDL) format, for the account represented by the <see cref="T:System.Security.Principal.SecurityIdentifier" /> object. An example of the SDDL format is S-1-5-9.</summary>
		/// <returns>The SID, in SDDL format, for the account represented by the <see cref="T:System.Security.Principal.SecurityIdentifier" /> object.</returns>
		// Token: 0x06002813 RID: 10259 RVA: 0x00093844 File Offset: 0x00091A44
		public override string ToString()
		{
			if (this._SddlForm == null)
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.AppendFormat("S-1-{0}", (long)this._IdentifierAuthority);
				for (int i = 0; i < this.SubAuthorityCount; i++)
				{
					stringBuilder.AppendFormat("-{0}", (uint)this._SubAuthorities[i]);
				}
				this._SddlForm = stringBuilder.ToString();
			}
			return this._SddlForm;
		}

		/// <summary>Returns an uppercase Security Descriptor Definition Language (SDDL) string for the security identifier (SID) represented by this <see cref="T:System.Security.Principal.SecurityIdentifier" /> object.</summary>
		/// <returns>An uppercase SDDL string for the SID represented by the <see cref="T:System.Security.Principal.SecurityIdentifier" /> object.</returns>
		// Token: 0x1700054C RID: 1356
		// (get) Token: 0x06002814 RID: 10260 RVA: 0x000938B2 File Offset: 0x00091AB2
		public override string Value
		{
			get
			{
				return this.ToString().ToUpper(CultureInfo.InvariantCulture);
			}
		}

		// Token: 0x06002815 RID: 10261 RVA: 0x000938C4 File Offset: 0x00091AC4
		internal static bool IsValidTargetTypeStatic(Type targetType)
		{
			return targetType == typeof(NTAccount) || targetType == typeof(SecurityIdentifier);
		}

		/// <summary>Returns a value that indicates whether the specified type is a valid translation type for the <see cref="T:System.Security.Principal.SecurityIdentifier" /> class.</summary>
		/// <param name="targetType">The type being queried for validity to serve as a conversion from <see cref="T:System.Security.Principal.SecurityIdentifier" />. The following target types are valid:  
		///  - <see cref="T:System.Security.Principal.NTAccount" />  
		///  - <see cref="T:System.Security.Principal.SecurityIdentifier" /></param>
		/// <returns>
		///   <see langword="true" /> if <paramref name="targetType" /> is a valid translation type for the <see cref="T:System.Security.Principal.SecurityIdentifier" /> class; otherwise, <see langword="false" />.</returns>
		// Token: 0x06002816 RID: 10262 RVA: 0x000938EF File Offset: 0x00091AEF
		public override bool IsValidTargetType(Type targetType)
		{
			return SecurityIdentifier.IsValidTargetTypeStatic(targetType);
		}

		// Token: 0x06002817 RID: 10263 RVA: 0x000938F8 File Offset: 0x00091AF8
		[SecurityCritical]
		internal SecurityIdentifier GetAccountDomainSid()
		{
			SecurityIdentifier result;
			int windowsAccountDomainSid = Win32.GetWindowsAccountDomainSid(this, out result);
			if (windowsAccountDomainSid == 122)
			{
				throw new OutOfMemoryException();
			}
			if (windowsAccountDomainSid == 1257)
			{
				result = null;
			}
			else if (windowsAccountDomainSid != 0)
			{
				throw new SystemException(Win32Native.GetMessage(windowsAccountDomainSid));
			}
			return result;
		}

		/// <summary>Returns a value that indicates whether the security identifier (SID) represented by this <see cref="T:System.Security.Principal.SecurityIdentifier" /> object is a valid Windows account SID.</summary>
		/// <returns>
		///   <see langword="true" /> if the SID represented by this <see cref="T:System.Security.Principal.SecurityIdentifier" /> object is a valid Windows account SID; otherwise, <see langword="false" />.</returns>
		// Token: 0x06002818 RID: 10264 RVA: 0x00093935 File Offset: 0x00091B35
		[SecuritySafeCritical]
		public bool IsAccountSid()
		{
			if (!this._AccountDomainSidInitialized)
			{
				this._AccountDomainSid = this.GetAccountDomainSid();
				this._AccountDomainSidInitialized = true;
			}
			return !(this._AccountDomainSid == null);
		}

		/// <summary>Translates the account name represented by the <see cref="T:System.Security.Principal.SecurityIdentifier" /> object into another <see cref="T:System.Security.Principal.IdentityReference" />-derived type.</summary>
		/// <param name="targetType">The target type for the conversion from <see cref="T:System.Security.Principal.SecurityIdentifier" />. The target type must be a type that is considered valid by the <see cref="M:System.Security.Principal.SecurityIdentifier.IsValidTargetType(System.Type)" /> method.</param>
		/// <returns>The converted identity.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="targetType" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="targetType" /> is not an <see cref="T:System.Security.Principal.IdentityReference" /> type.</exception>
		/// <exception cref="T:System.Security.Principal.IdentityNotMappedException">Some or all identity references could not be translated.</exception>
		/// <exception cref="T:System.SystemException">A Win32 error code was returned.</exception>
		// Token: 0x06002819 RID: 10265 RVA: 0x00093964 File Offset: 0x00091B64
		[SecuritySafeCritical]
		[SecurityPermission(SecurityAction.Demand, ControlPrincipal = true)]
		public override IdentityReference Translate(Type targetType)
		{
			if (targetType == null)
			{
				throw new ArgumentNullException("targetType");
			}
			if (targetType == typeof(SecurityIdentifier))
			{
				return this;
			}
			if (targetType == typeof(NTAccount))
			{
				IdentityReferenceCollection identityReferenceCollection = SecurityIdentifier.Translate(new IdentityReferenceCollection(1)
				{
					this
				}, targetType, true);
				return identityReferenceCollection[0];
			}
			throw new ArgumentException(Environment.GetResourceString("IdentityReference_MustBeIdentityReference"), "targetType");
		}

		/// <summary>Compares two <see cref="T:System.Security.Principal.SecurityIdentifier" /> objects to determine whether they are equal. They are considered equal if they have the same canonical representation as the one returned by the <see cref="P:System.Security.Principal.SecurityIdentifier.Value" /> property or if they are both <see langword="null" />.</summary>
		/// <param name="left">The left operand to use for the equality comparison. This parameter can be <see langword="null" />.</param>
		/// <param name="right">The right operand to use for the equality comparison. This parameter can be <see langword="null" />.</param>
		/// <returns>
		///   <see langword="true" /> if <paramref name="left" /> and <paramref name="right" /> are equal; otherwise, <see langword="false" />.</returns>
		// Token: 0x0600281A RID: 10266 RVA: 0x000939E0 File Offset: 0x00091BE0
		public static bool operator ==(SecurityIdentifier left, SecurityIdentifier right)
		{
			return (left == null && right == null) || (left != null && right != null && left.CompareTo(right) == 0);
		}

		/// <summary>Compares two <see cref="T:System.Security.Principal.SecurityIdentifier" /> objects to determine whether they are not equal. They are considered not equal if they have different canonical name representations than the one returned by the <see cref="P:System.Security.Principal.SecurityIdentifier.Value" /> property or if one of the objects is <see langword="null" /> and the other is not.</summary>
		/// <param name="left">The left operand to use for the inequality comparison. This parameter can be <see langword="null" />.</param>
		/// <param name="right">The right operand to use for the inequality comparison. This parameter can be <see langword="null" />.</param>
		/// <returns>
		///   <see langword="true" /> if <paramref name="left" /> and <paramref name="right" /> are not equal; otherwise, <see langword="false" />.</returns>
		// Token: 0x0600281B RID: 10267 RVA: 0x00093A0B File Offset: 0x00091C0B
		public static bool operator !=(SecurityIdentifier left, SecurityIdentifier right)
		{
			return !(left == right);
		}

		/// <summary>Compares the current <see cref="T:System.Security.Principal.SecurityIdentifier" /> object with the specified <see cref="T:System.Security.Principal.SecurityIdentifier" /> object.</summary>
		/// <param name="sid">The object to compare with the current object.</param>
		/// <returns>A signed number indicating the relative values of this instance and <paramref name="sid" />.  
		///   Return Value  
		///
		///   Description  
		///
		///   Less than zero  
		///
		///   This instance is less than <paramref name="sid" />.  
		///
		///   Zero  
		///
		///   This instance is equal to <paramref name="sid" />.  
		///
		///   Greater than zero  
		///
		///   This instance is greater than <paramref name="sid" />.</returns>
		// Token: 0x0600281C RID: 10268 RVA: 0x00093A18 File Offset: 0x00091C18
		public int CompareTo(SecurityIdentifier sid)
		{
			if (sid == null)
			{
				throw new ArgumentNullException("sid");
			}
			if (this.IdentifierAuthority < sid.IdentifierAuthority)
			{
				return -1;
			}
			if (this.IdentifierAuthority > sid.IdentifierAuthority)
			{
				return 1;
			}
			if (this.SubAuthorityCount < sid.SubAuthorityCount)
			{
				return -1;
			}
			if (this.SubAuthorityCount > sid.SubAuthorityCount)
			{
				return 1;
			}
			for (int i = 0; i < this.SubAuthorityCount; i++)
			{
				int num = this.GetSubAuthority(i) - sid.GetSubAuthority(i);
				if (num != 0)
				{
					return num;
				}
			}
			return 0;
		}

		// Token: 0x0600281D RID: 10269 RVA: 0x00093AA0 File Offset: 0x00091CA0
		internal int GetSubAuthority(int index)
		{
			return this._SubAuthorities[index];
		}

		/// <summary>Returns a value that indicates whether the <see cref="T:System.Security.Principal.SecurityIdentifier" /> object matches the specified well known security identifier (SID) type.</summary>
		/// <param name="type">A value to compare with the <see cref="T:System.Security.Principal.SecurityIdentifier" /> object.</param>
		/// <returns>
		///   <see langword="true" /> if <paramref name="type" /> is the SID type for the <see cref="T:System.Security.Principal.SecurityIdentifier" /> object; otherwise, <see langword="false" />.</returns>
		// Token: 0x0600281E RID: 10270 RVA: 0x00093AAA File Offset: 0x00091CAA
		[SecuritySafeCritical]
		public bool IsWellKnown(WellKnownSidType type)
		{
			return Win32.IsWellKnownSid(this, type);
		}

		/// <summary>Copies the binary representation of the specified security identifier (SID) represented by the <see cref="T:System.Security.Principal.SecurityIdentifier" /> class to a byte array.</summary>
		/// <param name="binaryForm">The byte array to receive the copied SID.</param>
		/// <param name="offset">The byte offset to use as the starting index in <paramref name="binaryForm" />.</param>
		// Token: 0x0600281F RID: 10271 RVA: 0x00093AB3 File Offset: 0x00091CB3
		public void GetBinaryForm(byte[] binaryForm, int offset)
		{
			this._BinaryForm.CopyTo(binaryForm, offset);
		}

		/// <summary>Returns a value that indicates whether the security identifier (SID) represented by this <see cref="T:System.Security.Principal.SecurityIdentifier" /> object is from the same domain as the specified SID.</summary>
		/// <param name="sid">The SID to compare with this <see cref="T:System.Security.Principal.SecurityIdentifier" /> object.</param>
		/// <returns>
		///   <see langword="true" /> if the SID represented by this <see cref="T:System.Security.Principal.SecurityIdentifier" /> object is in the same domain as the <paramref name="sid" /> SID; otherwise, <see langword="false" />.</returns>
		// Token: 0x06002820 RID: 10272 RVA: 0x00093AC2 File Offset: 0x00091CC2
		[SecuritySafeCritical]
		public bool IsEqualDomainSid(SecurityIdentifier sid)
		{
			return Win32.IsEqualDomainSid(this, sid);
		}

		// Token: 0x06002821 RID: 10273 RVA: 0x00093ACC File Offset: 0x00091CCC
		[SecurityCritical]
		private static IdentityReferenceCollection TranslateToNTAccounts(IdentityReferenceCollection sourceSids, out bool someFailed)
		{
			if (sourceSids == null)
			{
				throw new ArgumentNullException("sourceSids");
			}
			if (sourceSids.Count == 0)
			{
				throw new ArgumentException(Environment.GetResourceString("Arg_EmptyCollection"), "sourceSids");
			}
			IntPtr[] array = new IntPtr[sourceSids.Count];
			GCHandle[] array2 = new GCHandle[sourceSids.Count];
			SafeLsaPolicyHandle safeLsaPolicyHandle = SafeLsaPolicyHandle.InvalidHandle;
			SafeLsaMemoryHandle invalidHandle = SafeLsaMemoryHandle.InvalidHandle;
			SafeLsaMemoryHandle invalidHandle2 = SafeLsaMemoryHandle.InvalidHandle;
			IdentityReferenceCollection result;
			try
			{
				int num = 0;
				foreach (IdentityReference identityReference in sourceSids)
				{
					SecurityIdentifier securityIdentifier = identityReference as SecurityIdentifier;
					if (securityIdentifier == null)
					{
						throw new ArgumentException(Environment.GetResourceString("Argument_ImproperType"), "sourceSids");
					}
					array2[num] = GCHandle.Alloc(securityIdentifier.BinaryForm, GCHandleType.Pinned);
					array[num] = array2[num].AddrOfPinnedObject();
					num++;
				}
				safeLsaPolicyHandle = Win32.LsaOpenPolicy(null, PolicyRights.POLICY_LOOKUP_NAMES);
				someFailed = false;
				uint num2 = Win32Native.LsaLookupSids(safeLsaPolicyHandle, sourceSids.Count, array, ref invalidHandle, ref invalidHandle2);
				if (num2 == 3221225495U || num2 == 3221225626U)
				{
					throw new OutOfMemoryException();
				}
				if (num2 == 3221225506U)
				{
					throw new UnauthorizedAccessException();
				}
				if (num2 == 3221225587U || num2 == 263U)
				{
					someFailed = true;
				}
				else if (num2 != 0U)
				{
					int errorCode = Win32Native.LsaNtStatusToWinError((int)num2);
					throw new SystemException(Win32Native.GetMessage(errorCode));
				}
				invalidHandle2.Initialize((uint)sourceSids.Count, (uint)Marshal.SizeOf(typeof(Win32Native.LSA_TRANSLATED_NAME)));
				Win32.InitializeReferencedDomainsPointer(invalidHandle);
				IdentityReferenceCollection identityReferenceCollection = new IdentityReferenceCollection(sourceSids.Count);
				if (num2 == 0U || num2 == 263U)
				{
					Win32Native.LSA_REFERENCED_DOMAIN_LIST lsa_REFERENCED_DOMAIN_LIST = invalidHandle.Read<Win32Native.LSA_REFERENCED_DOMAIN_LIST>(0UL);
					string[] array3 = new string[lsa_REFERENCED_DOMAIN_LIST.Entries];
					for (int i = 0; i < lsa_REFERENCED_DOMAIN_LIST.Entries; i++)
					{
						Win32Native.LSA_TRUST_INFORMATION lsa_TRUST_INFORMATION = (Win32Native.LSA_TRUST_INFORMATION)Marshal.PtrToStructure(new IntPtr((long)lsa_REFERENCED_DOMAIN_LIST.Domains + (long)(i * Marshal.SizeOf(typeof(Win32Native.LSA_TRUST_INFORMATION)))), typeof(Win32Native.LSA_TRUST_INFORMATION));
						array3[i] = Marshal.PtrToStringUni(lsa_TRUST_INFORMATION.Name.Buffer, (int)(lsa_TRUST_INFORMATION.Name.Length / 2));
					}
					Win32Native.LSA_TRANSLATED_NAME[] array4 = new Win32Native.LSA_TRANSLATED_NAME[sourceSids.Count];
					invalidHandle2.ReadArray<Win32Native.LSA_TRANSLATED_NAME>(0UL, array4, 0, array4.Length);
					int j = 0;
					while (j < sourceSids.Count)
					{
						Win32Native.LSA_TRANSLATED_NAME lsa_TRANSLATED_NAME = array4[j];
						switch (lsa_TRANSLATED_NAME.Use)
						{
						case 1:
						case 2:
						case 4:
						case 5:
						case 9:
						{
							string accountName = Marshal.PtrToStringUni(lsa_TRANSLATED_NAME.Name.Buffer, (int)(lsa_TRANSLATED_NAME.Name.Length / 2));
							string domainName = array3[lsa_TRANSLATED_NAME.DomainIndex];
							identityReferenceCollection.Add(new NTAccount(domainName, accountName));
							break;
						}
						case 3:
						case 6:
						case 7:
						case 8:
							goto IL_2C4;
						default:
							goto IL_2C4;
						}
						IL_2D6:
						j++;
						continue;
						IL_2C4:
						someFailed = true;
						identityReferenceCollection.Add(sourceSids[j]);
						goto IL_2D6;
					}
				}
				else
				{
					for (int k = 0; k < sourceSids.Count; k++)
					{
						identityReferenceCollection.Add(sourceSids[k]);
					}
				}
				result = identityReferenceCollection;
			}
			finally
			{
				for (int l = 0; l < sourceSids.Count; l++)
				{
					if (array2[l].IsAllocated)
					{
						array2[l].Free();
					}
				}
				safeLsaPolicyHandle.Dispose();
				invalidHandle.Dispose();
				invalidHandle2.Dispose();
			}
			return result;
		}

		// Token: 0x06002822 RID: 10274 RVA: 0x00093E6C File Offset: 0x0009206C
		[SecurityCritical]
		internal static IdentityReferenceCollection Translate(IdentityReferenceCollection sourceSids, Type targetType, bool forceSuccess)
		{
			bool flag = false;
			IdentityReferenceCollection identityReferenceCollection = SecurityIdentifier.Translate(sourceSids, targetType, out flag);
			if (forceSuccess && flag)
			{
				IdentityReferenceCollection identityReferenceCollection2 = new IdentityReferenceCollection();
				foreach (IdentityReference identityReference in identityReferenceCollection)
				{
					if (identityReference.GetType() != targetType)
					{
						identityReferenceCollection2.Add(identityReference);
					}
				}
				throw new IdentityNotMappedException(Environment.GetResourceString("IdentityReference_IdentityNotMapped"), identityReferenceCollection2);
			}
			return identityReferenceCollection;
		}

		// Token: 0x06002823 RID: 10275 RVA: 0x00093EF0 File Offset: 0x000920F0
		[SecurityCritical]
		internal static IdentityReferenceCollection Translate(IdentityReferenceCollection sourceSids, Type targetType, out bool someFailed)
		{
			if (sourceSids == null)
			{
				throw new ArgumentNullException("sourceSids");
			}
			if (targetType == typeof(NTAccount))
			{
				return SecurityIdentifier.TranslateToNTAccounts(sourceSids, out someFailed);
			}
			throw new ArgumentException(Environment.GetResourceString("IdentityReference_MustBeIdentityReference"), "targetType");
		}

		// Token: 0x0400102F RID: 4143
		internal static readonly long MaxIdentifierAuthority = 281474976710655L;

		// Token: 0x04001030 RID: 4144
		internal static readonly byte MaxSubAuthorities = 15;

		/// <summary>Returns the minimum size, in bytes, of the binary representation of the security identifier.</summary>
		// Token: 0x04001031 RID: 4145
		public static readonly int MinBinaryLength = 8;

		/// <summary>Returns the maximum size, in bytes, of the binary representation of the security identifier.</summary>
		// Token: 0x04001032 RID: 4146
		public static readonly int MaxBinaryLength = (int)(8 + SecurityIdentifier.MaxSubAuthorities * 4);

		// Token: 0x04001033 RID: 4147
		private IdentifierAuthority _IdentifierAuthority;

		// Token: 0x04001034 RID: 4148
		private int[] _SubAuthorities;

		// Token: 0x04001035 RID: 4149
		private byte[] _BinaryForm;

		// Token: 0x04001036 RID: 4150
		private SecurityIdentifier _AccountDomainSid;

		// Token: 0x04001037 RID: 4151
		private bool _AccountDomainSidInitialized;

		// Token: 0x04001038 RID: 4152
		private string _SddlForm;
	}
}
