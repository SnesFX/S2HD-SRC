﻿using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Security.Util;

namespace System.Security.Permissions
{
	/// <summary>Represents the identity of a software publisher. This class cannot be inherited.</summary>
	// Token: 0x020002EC RID: 748
	[ComVisible(true)]
	[Serializable]
	public sealed class PublisherIdentityPermission : CodeAccessPermission, IBuiltInPermission
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Security.Permissions.PublisherIdentityPermission" /> class with the specified <see cref="T:System.Security.Permissions.PermissionState" />.</summary>
		/// <param name="state">One of the <see cref="T:System.Security.Permissions.PermissionState" /> values.</param>
		/// <exception cref="T:System.ArgumentException">The <paramref name="state" /> parameter is not a valid value of <see cref="T:System.Security.Permissions.PermissionState" />.</exception>
		// Token: 0x060026D2 RID: 9938 RVA: 0x0008CCC6 File Offset: 0x0008AEC6
		public PublisherIdentityPermission(PermissionState state)
		{
			if (state == PermissionState.Unrestricted)
			{
				this.m_unrestricted = true;
				return;
			}
			if (state == PermissionState.None)
			{
				this.m_unrestricted = false;
				return;
			}
			throw new ArgumentException(Environment.GetResourceString("Argument_InvalidPermissionState"));
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Security.Permissions.PublisherIdentityPermission" /> class with the specified Authenticode X.509v3 certificate.</summary>
		/// <param name="certificate">An X.509 certificate representing the software publisher's identity.</param>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="certificate" /> parameter is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">The <paramref name="certificate" /> parameter is not a valid certificate.</exception>
		// Token: 0x060026D3 RID: 9939 RVA: 0x0008CCF4 File Offset: 0x0008AEF4
		public PublisherIdentityPermission(X509Certificate certificate)
		{
			this.Certificate = certificate;
		}

		/// <summary>Gets or sets an Authenticode X.509v3 certificate that represents the identity of the software publisher.</summary>
		/// <returns>An X.509 certificate representing the identity of the software publisher.</returns>
		/// <exception cref="T:System.ArgumentNullException">The <see cref="P:System.Security.Permissions.PublisherIdentityPermission.Certificate" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">The <see cref="P:System.Security.Permissions.PublisherIdentityPermission.Certificate" /> is not a valid certificate.</exception>
		/// <exception cref="T:System.NotSupportedException">The property cannot be set because the identity is ambiguous.</exception>
		// Token: 0x17000507 RID: 1287
		// (get) Token: 0x060026D5 RID: 9941 RVA: 0x0008CD2C File Offset: 0x0008AF2C
		// (set) Token: 0x060026D4 RID: 9940 RVA: 0x0008CD03 File Offset: 0x0008AF03
		public X509Certificate Certificate
		{
			get
			{
				if (this.m_certs == null || this.m_certs.Length < 1)
				{
					return null;
				}
				if (this.m_certs.Length > 1)
				{
					throw new NotSupportedException(Environment.GetResourceString("NotSupported_AmbiguousIdentity"));
				}
				if (this.m_certs[0] == null)
				{
					return null;
				}
				return new X509Certificate(this.m_certs[0]);
			}
			set
			{
				PublisherIdentityPermission.CheckCertificate(value);
				this.m_unrestricted = false;
				this.m_certs = new X509Certificate[1];
				this.m_certs[0] = new X509Certificate(value);
			}
		}

		// Token: 0x060026D6 RID: 9942 RVA: 0x0008CD82 File Offset: 0x0008AF82
		private static void CheckCertificate(X509Certificate certificate)
		{
			if (certificate == null)
			{
				throw new ArgumentNullException("certificate");
			}
			if (certificate.GetRawCertData() == null)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_UninitializedCertificate"));
			}
		}

		/// <summary>Creates and returns an identical copy of the current permission.</summary>
		/// <returns>A copy of the current permission.</returns>
		// Token: 0x060026D7 RID: 9943 RVA: 0x0008CDAC File Offset: 0x0008AFAC
		public override IPermission Copy()
		{
			PublisherIdentityPermission publisherIdentityPermission = new PublisherIdentityPermission(PermissionState.None);
			publisherIdentityPermission.m_unrestricted = this.m_unrestricted;
			if (this.m_certs != null)
			{
				publisherIdentityPermission.m_certs = new X509Certificate[this.m_certs.Length];
				for (int i = 0; i < this.m_certs.Length; i++)
				{
					publisherIdentityPermission.m_certs[i] = ((this.m_certs[i] == null) ? null : new X509Certificate(this.m_certs[i]));
				}
			}
			return publisherIdentityPermission;
		}

		/// <summary>Determines whether the current permission is a subset of the specified permission.</summary>
		/// <param name="target">A permission that is to be tested for the subset relationship. This permission must be of the same type as the current permission.</param>
		/// <returns>
		///   <see langword="true" /> if the current permission is a subset of the specified permission; otherwise, <see langword="false" />.</returns>
		/// <exception cref="T:System.ArgumentException">The <paramref name="target" /> parameter is not <see langword="null" /> and is not of the same type as the current permission.</exception>
		// Token: 0x060026D8 RID: 9944 RVA: 0x0008CE20 File Offset: 0x0008B020
		public override bool IsSubsetOf(IPermission target)
		{
			if (target == null)
			{
				return !this.m_unrestricted && (this.m_certs == null || this.m_certs.Length == 0);
			}
			PublisherIdentityPermission publisherIdentityPermission = target as PublisherIdentityPermission;
			if (publisherIdentityPermission == null)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_WrongType", new object[]
				{
					base.GetType().FullName
				}));
			}
			if (publisherIdentityPermission.m_unrestricted)
			{
				return true;
			}
			if (this.m_unrestricted)
			{
				return false;
			}
			if (this.m_certs != null)
			{
				foreach (X509Certificate x509Certificate in this.m_certs)
				{
					bool flag = false;
					if (publisherIdentityPermission.m_certs != null)
					{
						foreach (X509Certificate other in publisherIdentityPermission.m_certs)
						{
							if (x509Certificate.Equals(other))
							{
								flag = true;
								break;
							}
						}
					}
					if (!flag)
					{
						return false;
					}
				}
			}
			return true;
		}

		/// <summary>Creates and returns a permission that is the intersection of the current permission and the specified permission.</summary>
		/// <param name="target">A permission to intersect with the current permission. It must be of the same type as the current permission.</param>
		/// <returns>A new permission that represents the intersection of the current permission and the specified permission. This new permission is <see langword="null" /> if the intersection is empty.</returns>
		/// <exception cref="T:System.ArgumentException">The <paramref name="target" /> parameter is not <see langword="null" /> and is not of the same type as the current permission.</exception>
		// Token: 0x060026D9 RID: 9945 RVA: 0x0008CEF8 File Offset: 0x0008B0F8
		public override IPermission Intersect(IPermission target)
		{
			if (target == null)
			{
				return null;
			}
			PublisherIdentityPermission publisherIdentityPermission = target as PublisherIdentityPermission;
			if (publisherIdentityPermission == null)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_WrongType", new object[]
				{
					base.GetType().FullName
				}));
			}
			if (this.m_unrestricted && publisherIdentityPermission.m_unrestricted)
			{
				return new PublisherIdentityPermission(PermissionState.None)
				{
					m_unrestricted = true
				};
			}
			if (this.m_unrestricted)
			{
				return publisherIdentityPermission.Copy();
			}
			if (publisherIdentityPermission.m_unrestricted)
			{
				return this.Copy();
			}
			if (this.m_certs == null || publisherIdentityPermission.m_certs == null || this.m_certs.Length == 0 || publisherIdentityPermission.m_certs.Length == 0)
			{
				return null;
			}
			ArrayList arrayList = new ArrayList();
			foreach (X509Certificate x509Certificate in this.m_certs)
			{
				foreach (X509Certificate other in publisherIdentityPermission.m_certs)
				{
					if (x509Certificate.Equals(other))
					{
						arrayList.Add(new X509Certificate(x509Certificate));
					}
				}
			}
			if (arrayList.Count == 0)
			{
				return null;
			}
			return new PublisherIdentityPermission(PermissionState.None)
			{
				m_certs = (X509Certificate[])arrayList.ToArray(typeof(X509Certificate))
			};
		}

		/// <summary>Creates a permission that is the union of the current permission and the specified permission.</summary>
		/// <param name="target">A permission to combine with the current permission. It must be of the same type as the current permission.</param>
		/// <returns>A new permission that represents the union of the current permission and the specified permission.</returns>
		/// <exception cref="T:System.ArgumentException">The <paramref name="target" /> parameter is not <see langword="null" /> and is not of the same type as the current permission.  
		///  -or-  
		///  The two permissions are not equal.</exception>
		// Token: 0x060026DA RID: 9946 RVA: 0x0008D02C File Offset: 0x0008B22C
		public override IPermission Union(IPermission target)
		{
			if (target == null)
			{
				if ((this.m_certs == null || this.m_certs.Length == 0) && !this.m_unrestricted)
				{
					return null;
				}
				return this.Copy();
			}
			else
			{
				PublisherIdentityPermission publisherIdentityPermission = target as PublisherIdentityPermission;
				if (publisherIdentityPermission == null)
				{
					throw new ArgumentException(Environment.GetResourceString("Argument_WrongType", new object[]
					{
						base.GetType().FullName
					}));
				}
				if (this.m_unrestricted || publisherIdentityPermission.m_unrestricted)
				{
					return new PublisherIdentityPermission(PermissionState.None)
					{
						m_unrestricted = true
					};
				}
				if (this.m_certs == null || this.m_certs.Length == 0)
				{
					if (publisherIdentityPermission.m_certs == null || publisherIdentityPermission.m_certs.Length == 0)
					{
						return null;
					}
					return publisherIdentityPermission.Copy();
				}
				else
				{
					if (publisherIdentityPermission.m_certs == null || publisherIdentityPermission.m_certs.Length == 0)
					{
						return this.Copy();
					}
					ArrayList arrayList = new ArrayList();
					foreach (X509Certificate value in this.m_certs)
					{
						arrayList.Add(value);
					}
					foreach (X509Certificate x509Certificate in publisherIdentityPermission.m_certs)
					{
						bool flag = false;
						foreach (object obj in arrayList)
						{
							X509Certificate other = (X509Certificate)obj;
							if (x509Certificate.Equals(other))
							{
								flag = true;
								break;
							}
						}
						if (!flag)
						{
							arrayList.Add(x509Certificate);
						}
					}
					return new PublisherIdentityPermission(PermissionState.None)
					{
						m_certs = (X509Certificate[])arrayList.ToArray(typeof(X509Certificate))
					};
				}
			}
		}

		/// <summary>Reconstructs a permission with a specified state from an XML encoding.</summary>
		/// <param name="esd">The XML encoding to use to reconstruct the permission.</param>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="esd" /> parameter is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">The <paramref name="esd" /> parameter is not a valid permission element.  
		///  -or-  
		///  The <paramref name="esd" /> parameter's version number is not valid.</exception>
		// Token: 0x060026DB RID: 9947 RVA: 0x0008D1D0 File Offset: 0x0008B3D0
		public override void FromXml(SecurityElement esd)
		{
			this.m_unrestricted = false;
			this.m_certs = null;
			CodeAccessPermission.ValidateElement(esd, this);
			string text = esd.Attribute("Unrestricted");
			if (text != null && string.Compare(text, "true", StringComparison.OrdinalIgnoreCase) == 0)
			{
				this.m_unrestricted = true;
				return;
			}
			string text2 = esd.Attribute("X509v3Certificate");
			ArrayList arrayList = new ArrayList();
			if (text2 != null)
			{
				arrayList.Add(new X509Certificate(Hex.DecodeHexString(text2)));
			}
			ArrayList children = esd.Children;
			if (children != null)
			{
				foreach (object obj in children)
				{
					SecurityElement securityElement = (SecurityElement)obj;
					text2 = securityElement.Attribute("X509v3Certificate");
					if (text2 != null)
					{
						arrayList.Add(new X509Certificate(Hex.DecodeHexString(text2)));
					}
				}
			}
			if (arrayList.Count != 0)
			{
				this.m_certs = (X509Certificate[])arrayList.ToArray(typeof(X509Certificate));
			}
		}

		/// <summary>Creates an XML encoding of the permission and its current state.</summary>
		/// <returns>An XML encoding of the permission, including any state information.</returns>
		// Token: 0x060026DC RID: 9948 RVA: 0x0008D2D8 File Offset: 0x0008B4D8
		public override SecurityElement ToXml()
		{
			SecurityElement securityElement = CodeAccessPermission.CreatePermissionElement(this, "System.Security.Permissions.PublisherIdentityPermission");
			if (this.m_unrestricted)
			{
				securityElement.AddAttribute("Unrestricted", "true");
			}
			else if (this.m_certs != null)
			{
				if (this.m_certs.Length == 1)
				{
					securityElement.AddAttribute("X509v3Certificate", this.m_certs[0].GetRawCertDataString());
				}
				else
				{
					for (int i = 0; i < this.m_certs.Length; i++)
					{
						SecurityElement securityElement2 = new SecurityElement("Cert");
						securityElement2.AddAttribute("X509v3Certificate", this.m_certs[i].GetRawCertDataString());
						securityElement.AddChild(securityElement2);
					}
				}
			}
			return securityElement;
		}

		// Token: 0x060026DD RID: 9949 RVA: 0x0008D376 File Offset: 0x0008B576
		int IBuiltInPermission.GetTokenIndex()
		{
			return PublisherIdentityPermission.GetTokenIndex();
		}

		// Token: 0x060026DE RID: 9950 RVA: 0x0008D37D File Offset: 0x0008B57D
		internal static int GetTokenIndex()
		{
			return 10;
		}

		// Token: 0x04000EBA RID: 3770
		private bool m_unrestricted;

		// Token: 0x04000EBB RID: 3771
		private X509Certificate[] m_certs;
	}
}
