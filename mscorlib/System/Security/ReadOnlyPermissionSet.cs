﻿using System;
using System.Collections;
using System.Runtime.Serialization;

namespace System.Security
{
	/// <summary>Represents a read-only collection that can contain many different types of permissions.</summary>
	// Token: 0x020001E6 RID: 486
	[Serializable]
	public sealed class ReadOnlyPermissionSet : PermissionSet
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Security.ReadOnlyPermissionSet" /> class.</summary>
		/// <param name="permissionSetXml">The XML element from which to take the value of the new <see cref="T:System.Security.ReadOnlyPermissionSet" />.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="permissionSetXml" /> is <see langword="null" />.</exception>
		// Token: 0x06001D79 RID: 7545 RVA: 0x00066C20 File Offset: 0x00064E20
		public ReadOnlyPermissionSet(SecurityElement permissionSetXml)
		{
			if (permissionSetXml == null)
			{
				throw new ArgumentNullException("permissionSetXml");
			}
			this.m_originXml = permissionSetXml.Copy();
			base.FromXml(this.m_originXml);
		}

		// Token: 0x06001D7A RID: 7546 RVA: 0x00066C4E File Offset: 0x00064E4E
		[OnDeserializing]
		private void OnDeserializing(StreamingContext ctx)
		{
			this.m_deserializing = true;
		}

		// Token: 0x06001D7B RID: 7547 RVA: 0x00066C57 File Offset: 0x00064E57
		[OnDeserialized]
		private void OnDeserialized(StreamingContext ctx)
		{
			this.m_deserializing = false;
		}

		/// <summary>Gets a value that indicates whether the collection is read-only.</summary>
		/// <returns>Always <see langword="true" />.</returns>
		// Token: 0x17000346 RID: 838
		// (get) Token: 0x06001D7C RID: 7548 RVA: 0x00066C60 File Offset: 0x00064E60
		public override bool IsReadOnly
		{
			get
			{
				return true;
			}
		}

		/// <summary>Creates a copy of the <see cref="T:System.Security.ReadOnlyPermissionSet" />.</summary>
		/// <returns>A copy of the read-only permission set.</returns>
		// Token: 0x06001D7D RID: 7549 RVA: 0x00066C63 File Offset: 0x00064E63
		public override PermissionSet Copy()
		{
			return new ReadOnlyPermissionSet(this.m_originXml);
		}

		/// <summary>Creates an XML encoding of the security object and its current state.</summary>
		/// <returns>An XML encoding of the security object, including any state information.</returns>
		// Token: 0x06001D7E RID: 7550 RVA: 0x00066C70 File Offset: 0x00064E70
		public override SecurityElement ToXml()
		{
			return this.m_originXml.Copy();
		}

		// Token: 0x06001D7F RID: 7551 RVA: 0x00066C7D File Offset: 0x00064E7D
		protected override IEnumerator GetEnumeratorImpl()
		{
			return new ReadOnlyPermissionSetEnumerator(base.GetEnumeratorImpl());
		}

		// Token: 0x06001D80 RID: 7552 RVA: 0x00066C8C File Offset: 0x00064E8C
		protected override IPermission GetPermissionImpl(Type permClass)
		{
			IPermission permissionImpl = base.GetPermissionImpl(permClass);
			if (permissionImpl == null)
			{
				return null;
			}
			return permissionImpl.Copy();
		}

		// Token: 0x06001D81 RID: 7553 RVA: 0x00066CAC File Offset: 0x00064EAC
		protected override IPermission AddPermissionImpl(IPermission perm)
		{
			throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_ModifyROPermSet"));
		}

		/// <summary>Reconstructs a security object with a specified state from an XML encoding.</summary>
		/// <param name="et">The XML encoding to use to reconstruct the security object.</param>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="et" /> parameter is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">The <paramref name="et" /> parameter is not a valid permission element.  
		///  -or-  
		///  The <paramref name="et" /> parameter's version number is not supported.</exception>
		/// <exception cref="T:System.InvalidOperationException">The object is not being deserialized; that is, <see cref="T:System.Security.PermissionSet" /> did not call back into <see cref="M:System.Security.ReadOnlyPermissionSet.FromXml(System.Security.SecurityElement)" /> during deserialization.</exception>
		// Token: 0x06001D82 RID: 7554 RVA: 0x00066CBD File Offset: 0x00064EBD
		public override void FromXml(SecurityElement et)
		{
			if (this.m_deserializing)
			{
				base.FromXml(et);
				return;
			}
			throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_ModifyROPermSet"));
		}

		// Token: 0x06001D83 RID: 7555 RVA: 0x00066CDE File Offset: 0x00064EDE
		protected override IPermission RemovePermissionImpl(Type permClass)
		{
			throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_ModifyROPermSet"));
		}

		// Token: 0x06001D84 RID: 7556 RVA: 0x00066CEF File Offset: 0x00064EEF
		protected override IPermission SetPermissionImpl(IPermission perm)
		{
			throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_ModifyROPermSet"));
		}

		// Token: 0x04000A46 RID: 2630
		private SecurityElement m_originXml;

		// Token: 0x04000A47 RID: 2631
		[NonSerialized]
		private bool m_deserializing;
	}
}
