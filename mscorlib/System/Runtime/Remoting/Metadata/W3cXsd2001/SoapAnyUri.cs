﻿using System;
using System.Runtime.InteropServices;

namespace System.Runtime.Remoting.Metadata.W3cXsd2001
{
	/// <summary>Wraps an XSD <see langword="anyURI" /> type.</summary>
	// Token: 0x020007C1 RID: 1985
	[ComVisible(true)]
	[Serializable]
	public sealed class SoapAnyUri : ISoapXsd
	{
		/// <summary>Gets the XML Schema definition language (XSD) of the current SOAP type.</summary>
		/// <returns>A <see cref="T:System.String" /> that indicates the XSD of the current SOAP type.</returns>
		// Token: 0x17000E6A RID: 3690
		// (get) Token: 0x0600568C RID: 22156 RVA: 0x0013194D File Offset: 0x0012FB4D
		public static string XsdType
		{
			get
			{
				return "anyURI";
			}
		}

		/// <summary>Returns the XML Schema definition language (XSD) of the current SOAP type.</summary>
		/// <returns>A <see cref="T:System.String" /> that indicates the XSD of the current SOAP type.</returns>
		// Token: 0x0600568D RID: 22157 RVA: 0x00131954 File Offset: 0x0012FB54
		public string GetXsdType()
		{
			return SoapAnyUri.XsdType;
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.Remoting.Metadata.W3cXsd2001.SoapAnyUri" /> class.</summary>
		// Token: 0x0600568E RID: 22158 RVA: 0x0013195B File Offset: 0x0012FB5B
		public SoapAnyUri()
		{
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.Remoting.Metadata.W3cXsd2001.SoapAnyUri" /> class with the specified URI.</summary>
		/// <param name="value">A <see cref="T:System.String" /> that contains a URI.</param>
		// Token: 0x0600568F RID: 22159 RVA: 0x00131963 File Offset: 0x0012FB63
		public SoapAnyUri(string value)
		{
			this._value = value;
		}

		/// <summary>Gets or sets a URI.</summary>
		/// <returns>A <see cref="T:System.String" /> that contains a URI.</returns>
		// Token: 0x17000E6B RID: 3691
		// (get) Token: 0x06005690 RID: 22160 RVA: 0x00131972 File Offset: 0x0012FB72
		// (set) Token: 0x06005691 RID: 22161 RVA: 0x0013197A File Offset: 0x0012FB7A
		public string Value
		{
			get
			{
				return this._value;
			}
			set
			{
				this._value = value;
			}
		}

		/// <summary>Returns <see cref="P:System.Runtime.Remoting.Metadata.W3cXsd2001.SoapAnyUri.Value" /> as a <see cref="T:System.String" />.</summary>
		/// <returns>A <see cref="T:System.String" /> that is obtained from <see cref="P:System.Runtime.Remoting.Metadata.W3cXsd2001.SoapAnyUri.Value" />.</returns>
		// Token: 0x06005692 RID: 22162 RVA: 0x00131983 File Offset: 0x0012FB83
		public override string ToString()
		{
			return this._value;
		}

		/// <summary>Converts the specified <see cref="T:System.String" /> into a <see cref="T:System.Runtime.Remoting.Metadata.W3cXsd2001.SoapAnyUri" /> object.</summary>
		/// <param name="value">The <see cref="T:System.String" /> to convert.</param>
		/// <returns>A <see cref="T:System.Runtime.Remoting.Metadata.W3cXsd2001.SoapAnyUri" /> object that is obtained from <paramref name="value" />.</returns>
		// Token: 0x06005693 RID: 22163 RVA: 0x0013198B File Offset: 0x0012FB8B
		public static SoapAnyUri Parse(string value)
		{
			return new SoapAnyUri(value);
		}

		// Token: 0x04002764 RID: 10084
		private string _value;
	}
}
