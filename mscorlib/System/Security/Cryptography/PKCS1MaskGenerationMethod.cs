﻿using System;
using System.Runtime.InteropServices;

namespace System.Security.Cryptography
{
	/// <summary>Computes masks according to PKCS #1 for use by key exchange algorithms.</summary>
	// Token: 0x02000274 RID: 628
	[ComVisible(true)]
	public class PKCS1MaskGenerationMethod : MaskGenerationMethod
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Security.Cryptography.PKCS1MaskGenerationMethod" /> class.</summary>
		// Token: 0x06002241 RID: 8769 RVA: 0x000790BF File Offset: 0x000772BF
		public PKCS1MaskGenerationMethod()
		{
			this.HashNameValue = "SHA1";
		}

		/// <summary>Gets or sets the name of the hash algorithm type to use for generating the mask.</summary>
		/// <returns>The name of the type that implements the hash algorithm to use for computing the mask.</returns>
		// Token: 0x17000446 RID: 1094
		// (get) Token: 0x06002242 RID: 8770 RVA: 0x000790D2 File Offset: 0x000772D2
		// (set) Token: 0x06002243 RID: 8771 RVA: 0x000790DA File Offset: 0x000772DA
		public string HashName
		{
			get
			{
				return this.HashNameValue;
			}
			set
			{
				this.HashNameValue = value;
				if (this.HashNameValue == null)
				{
					this.HashNameValue = "SHA1";
				}
			}
		}

		/// <summary>Generates and returns a mask from the specified random seed of the specified length.</summary>
		/// <param name="rgbSeed">The random seed to use for computing the mask.</param>
		/// <param name="cbReturn">The length of the generated mask in bytes.</param>
		/// <returns>A randomly generated mask whose length is equal to the <paramref name="cbReturn" /> parameter.</returns>
		// Token: 0x06002244 RID: 8772 RVA: 0x000790F8 File Offset: 0x000772F8
		public override byte[] GenerateMask(byte[] rgbSeed, int cbReturn)
		{
			HashAlgorithm hashAlgorithm = (HashAlgorithm)CryptoConfig.CreateFromName(this.HashNameValue);
			byte[] inputBuffer = new byte[4];
			byte[] array = new byte[cbReturn];
			uint num = 0U;
			for (int i = 0; i < array.Length; i += hashAlgorithm.Hash.Length)
			{
				Utils.ConvertIntToByteArray(num++, ref inputBuffer);
				hashAlgorithm.TransformBlock(rgbSeed, 0, rgbSeed.Length, rgbSeed, 0);
				hashAlgorithm.TransformFinalBlock(inputBuffer, 0, 4);
				byte[] hash = hashAlgorithm.Hash;
				hashAlgorithm.Initialize();
				if (array.Length - i > hash.Length)
				{
					Buffer.BlockCopy(hash, 0, array, i, hash.Length);
				}
				else
				{
					Buffer.BlockCopy(hash, 0, array, i, array.Length - i);
				}
			}
			return array;
		}

		// Token: 0x04000C70 RID: 3184
		private string HashNameValue;
	}
}
