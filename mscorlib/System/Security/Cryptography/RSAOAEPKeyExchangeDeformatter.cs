﻿using System;
using System.Runtime.InteropServices;

namespace System.Security.Cryptography
{
	/// <summary>Decrypts Optimal Asymmetric Encryption Padding (OAEP) key exchange data.</summary>
	// Token: 0x02000282 RID: 642
	[ComVisible(true)]
	public class RSAOAEPKeyExchangeDeformatter : AsymmetricKeyExchangeDeformatter
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Security.Cryptography.RSAOAEPKeyExchangeDeformatter" /> class.</summary>
		// Token: 0x060022E3 RID: 8931 RVA: 0x0007D495 File Offset: 0x0007B695
		public RSAOAEPKeyExchangeDeformatter()
		{
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Security.Cryptography.RSAOAEPKeyExchangeDeformatter" /> class with the specified key.</summary>
		/// <param name="key">The instance of the <see cref="T:System.Security.Cryptography.RSA" /> algorithm that holds the private key.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="key" /> is <see langword="null" />.</exception>
		// Token: 0x060022E4 RID: 8932 RVA: 0x0007D49D File Offset: 0x0007B69D
		public RSAOAEPKeyExchangeDeformatter(AsymmetricAlgorithm key)
		{
			if (key == null)
			{
				throw new ArgumentNullException("key");
			}
			this._rsaKey = (RSA)key;
		}

		/// <summary>Gets the parameters for the Optimal Asymmetric Encryption Padding (OAEP) key exchange.</summary>
		/// <returns>An XML string containing the parameters of the OAEP key exchange operation.</returns>
		// Token: 0x17000461 RID: 1121
		// (get) Token: 0x060022E5 RID: 8933 RVA: 0x0007D4BF File Offset: 0x0007B6BF
		// (set) Token: 0x060022E6 RID: 8934 RVA: 0x0007D4C2 File Offset: 0x0007B6C2
		public override string Parameters
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		/// <summary>Extracts secret information from the encrypted key exchange data.</summary>
		/// <param name="rgbData">The key exchange data within which the secret information is hidden.</param>
		/// <returns>The secret information derived from the key exchange data.</returns>
		/// <exception cref="T:System.Security.Cryptography.CryptographicException">The key exchange data verification has failed.</exception>
		/// <exception cref="T:System.Security.Cryptography.CryptographicUnexpectedOperationException">The key is missing.</exception>
		// Token: 0x060022E7 RID: 8935 RVA: 0x0007D4C4 File Offset: 0x0007B6C4
		[SecuritySafeCritical]
		public override byte[] DecryptKeyExchange(byte[] rgbData)
		{
			if (this._rsaKey == null)
			{
				throw new CryptographicUnexpectedOperationException(Environment.GetResourceString("Cryptography_MissingKey"));
			}
			if (this.OverridesDecrypt)
			{
				return this._rsaKey.Decrypt(rgbData, RSAEncryptionPadding.OaepSHA1);
			}
			return Utils.RsaOaepDecrypt(this._rsaKey, SHA1.Create(), new PKCS1MaskGenerationMethod(), rgbData);
		}

		/// <summary>Sets the private key to use for decrypting the secret information.</summary>
		/// <param name="key">The instance of the <see cref="T:System.Security.Cryptography.RSA" /> algorithm that holds the private key.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="key" /> is <see langword="null" />.</exception>
		// Token: 0x060022E8 RID: 8936 RVA: 0x0007D519 File Offset: 0x0007B719
		public override void SetKey(AsymmetricAlgorithm key)
		{
			if (key == null)
			{
				throw new ArgumentNullException("key");
			}
			this._rsaKey = (RSA)key;
			this._rsaOverridesDecrypt = null;
		}

		// Token: 0x17000462 RID: 1122
		// (get) Token: 0x060022E9 RID: 8937 RVA: 0x0007D544 File Offset: 0x0007B744
		private bool OverridesDecrypt
		{
			get
			{
				if (this._rsaOverridesDecrypt == null)
				{
					this._rsaOverridesDecrypt = new bool?(Utils.DoesRsaKeyOverride(this._rsaKey, "Decrypt", new Type[]
					{
						typeof(byte[]),
						typeof(RSAEncryptionPadding)
					}));
				}
				return this._rsaOverridesDecrypt.Value;
			}
		}

		// Token: 0x04000CAB RID: 3243
		private RSA _rsaKey;

		// Token: 0x04000CAC RID: 3244
		private bool? _rsaOverridesDecrypt;
	}
}
