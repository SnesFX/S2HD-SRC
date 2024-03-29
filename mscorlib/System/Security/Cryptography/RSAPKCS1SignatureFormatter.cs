﻿using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace System.Security.Cryptography
{
	/// <summary>Creates an <see cref="T:System.Security.Cryptography.RSA" /> PKCS #1 version 1.5 signature.</summary>
	// Token: 0x02000287 RID: 647
	[ComVisible(true)]
	public class RSAPKCS1SignatureFormatter : AsymmetricSignatureFormatter
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Security.Cryptography.RSAPKCS1SignatureFormatter" /> class.</summary>
		// Token: 0x0600230D RID: 8973 RVA: 0x0007DBC6 File Offset: 0x0007BDC6
		public RSAPKCS1SignatureFormatter()
		{
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Security.Cryptography.RSAPKCS1SignatureFormatter" /> class with the specified key.</summary>
		/// <param name="key">The instance of the <see cref="T:System.Security.Cryptography.RSA" /> algorithm that holds the private key.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="key" /> is <see langword="null" />.</exception>
		// Token: 0x0600230E RID: 8974 RVA: 0x0007DBCE File Offset: 0x0007BDCE
		public RSAPKCS1SignatureFormatter(AsymmetricAlgorithm key)
		{
			if (key == null)
			{
				throw new ArgumentNullException("key");
			}
			this._rsaKey = (RSA)key;
		}

		/// <summary>Sets the private key to use for creating the signature.</summary>
		/// <param name="key">The instance of the <see cref="T:System.Security.Cryptography.RSA" /> algorithm that holds the private key.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="key" /> is <see langword="null" />.</exception>
		// Token: 0x0600230F RID: 8975 RVA: 0x0007DBF0 File Offset: 0x0007BDF0
		public override void SetKey(AsymmetricAlgorithm key)
		{
			if (key == null)
			{
				throw new ArgumentNullException("key");
			}
			this._rsaKey = (RSA)key;
			this._rsaOverridesSignHash = null;
		}

		/// <summary>Sets the hash algorithm to use for creating the signature.</summary>
		/// <param name="strName">The name of the hash algorithm to use for creating the signature.</param>
		// Token: 0x06002310 RID: 8976 RVA: 0x0007DC18 File Offset: 0x0007BE18
		public override void SetHashAlgorithm(string strName)
		{
			this._strOID = CryptoConfig.MapNameToOID(strName, OidGroup.HashAlgorithm);
		}

		/// <summary>Creates the <see cref="T:System.Security.Cryptography.RSA" /> PKCS #1 signature for the specified data.</summary>
		/// <param name="rgbHash">The data to be signed.</param>
		/// <returns>The digital signature for <paramref name="rgbHash" />.</returns>
		/// <exception cref="T:System.Security.Cryptography.CryptographicUnexpectedOperationException">The key is <see langword="null" />.  
		///  -or-  
		///  The hash algorithm is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="rgbHash" /> parameter is <see langword="null" />.</exception>
		// Token: 0x06002311 RID: 8977 RVA: 0x0007DC28 File Offset: 0x0007BE28
		[SecuritySafeCritical]
		public override byte[] CreateSignature(byte[] rgbHash)
		{
			if (rgbHash == null)
			{
				throw new ArgumentNullException("rgbHash");
			}
			if (this._strOID == null)
			{
				throw new CryptographicUnexpectedOperationException(Environment.GetResourceString("Cryptography_MissingOID"));
			}
			if (this._rsaKey == null)
			{
				throw new CryptographicUnexpectedOperationException(Environment.GetResourceString("Cryptography_MissingKey"));
			}
			if (this._rsaKey is RSACryptoServiceProvider)
			{
				int algIdFromOid = X509Utils.GetAlgIdFromOid(this._strOID, OidGroup.HashAlgorithm);
				return ((RSACryptoServiceProvider)this._rsaKey).SignHash(rgbHash, algIdFromOid);
			}
			if (this.OverridesSignHash)
			{
				HashAlgorithmName hashAlgorithm = Utils.OidToHashAlgorithmName(this._strOID);
				return this._rsaKey.SignHash(rgbHash, hashAlgorithm, RSASignaturePadding.Pkcs1);
			}
			byte[] rgb = Utils.RsaPkcs1Padding(this._rsaKey, CryptoConfig.EncodeOID(this._strOID), rgbHash);
			return this._rsaKey.DecryptValue(rgb);
		}

		// Token: 0x1700046E RID: 1134
		// (get) Token: 0x06002312 RID: 8978 RVA: 0x0007DCEC File Offset: 0x0007BEEC
		private bool OverridesSignHash
		{
			get
			{
				if (this._rsaOverridesSignHash == null)
				{
					this._rsaOverridesSignHash = new bool?(Utils.DoesRsaKeyOverride(this._rsaKey, "SignHash", new Type[]
					{
						typeof(byte[]),
						typeof(HashAlgorithmName),
						typeof(RSASignaturePadding)
					}));
				}
				return this._rsaOverridesSignHash.Value;
			}
		}

		// Token: 0x04000CBA RID: 3258
		private RSA _rsaKey;

		// Token: 0x04000CBB RID: 3259
		private string _strOID;

		// Token: 0x04000CBC RID: 3260
		private bool? _rsaOverridesSignHash;
	}
}
