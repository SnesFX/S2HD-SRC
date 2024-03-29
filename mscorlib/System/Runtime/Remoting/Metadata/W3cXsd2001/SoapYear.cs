﻿using System;
using System.Globalization;
using System.Runtime.InteropServices;

namespace System.Runtime.Remoting.Metadata.W3cXsd2001
{
	/// <summary>Wraps an XSD <see langword="gYear" /> type.</summary>
	// Token: 0x020007B6 RID: 1974
	[ComVisible(true)]
	[Serializable]
	public sealed class SoapYear : ISoapXsd
	{
		/// <summary>Gets the XML Schema definition language (XSD) of the current SOAP type.</summary>
		/// <returns>A <see cref="T:System.String" /> that indicates the XSD of the current SOAP type.</returns>
		// Token: 0x17000E53 RID: 3667
		// (get) Token: 0x0600562B RID: 22059 RVA: 0x00130FD4 File Offset: 0x0012F1D4
		public static string XsdType
		{
			get
			{
				return "gYear";
			}
		}

		/// <summary>Returns the XML Schema definition language (XSD) of the current SOAP type.</summary>
		/// <returns>A <see cref="T:System.String" /> that indicates the XSD of the current SOAP type.</returns>
		// Token: 0x0600562C RID: 22060 RVA: 0x00130FDB File Offset: 0x0012F1DB
		public string GetXsdType()
		{
			return SoapYear.XsdType;
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.Remoting.Metadata.W3cXsd2001.SoapYear" /> class.</summary>
		// Token: 0x0600562D RID: 22061 RVA: 0x00130FE2 File Offset: 0x0012F1E2
		public SoapYear()
		{
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.Remoting.Metadata.W3cXsd2001.SoapYear" /> class with a specified <see cref="T:System.DateTime" /> object.</summary>
		/// <param name="value">A <see cref="T:System.DateTime" /> object to initialize the current instance.</param>
		// Token: 0x0600562E RID: 22062 RVA: 0x00130FF5 File Offset: 0x0012F1F5
		public SoapYear(DateTime value)
		{
			this._value = value;
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.Remoting.Metadata.W3cXsd2001.SoapYear" /> class with a specified <see cref="T:System.DateTime" /> object and an integer that indicates whether <see cref="P:System.Runtime.Remoting.Metadata.W3cXsd2001.SoapYear.Value" /> is a positive or negative value.</summary>
		/// <param name="value">A <see cref="T:System.DateTime" /> object to initialize the current instance.</param>
		/// <param name="sign">An integer that indicates whether <paramref name="value" /> is positive.</param>
		// Token: 0x0600562F RID: 22063 RVA: 0x0013100F File Offset: 0x0012F20F
		public SoapYear(DateTime value, int sign)
		{
			this._value = value;
			this._sign = sign;
		}

		/// <summary>Gets or sets the date and time of the current instance.</summary>
		/// <returns>The <see cref="T:System.DateTime" /> object that contains the date and time of the current instance.</returns>
		// Token: 0x17000E54 RID: 3668
		// (get) Token: 0x06005630 RID: 22064 RVA: 0x00131030 File Offset: 0x0012F230
		// (set) Token: 0x06005631 RID: 22065 RVA: 0x00131038 File Offset: 0x0012F238
		public DateTime Value
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

		/// <summary>Gets or sets whether the date and time of the current instance is positive or negative.</summary>
		/// <returns>An integer that indicates whether <see cref="P:System.Runtime.Remoting.Metadata.W3cXsd2001.SoapYear.Value" /> is positive or negative.</returns>
		// Token: 0x17000E55 RID: 3669
		// (get) Token: 0x06005632 RID: 22066 RVA: 0x00131041 File Offset: 0x0012F241
		// (set) Token: 0x06005633 RID: 22067 RVA: 0x00131049 File Offset: 0x0012F249
		public int Sign
		{
			get
			{
				return this._sign;
			}
			set
			{
				this._sign = value;
			}
		}

		/// <summary>Returns <see cref="P:System.Runtime.Remoting.Metadata.W3cXsd2001.SoapYear.Value" /> as a <see cref="T:System.String" />.</summary>
		/// <returns>A <see cref="T:System.String" /> that is obtained from <see cref="P:System.Runtime.Remoting.Metadata.W3cXsd2001.SoapYear.Value" /> in the format "yyyy" or "-yyyy" if <see cref="P:System.Runtime.Remoting.Metadata.W3cXsd2001.SoapYear.Sign" /> is negative.</returns>
		// Token: 0x06005634 RID: 22068 RVA: 0x00131052 File Offset: 0x0012F252
		public override string ToString()
		{
			if (this._sign < 0)
			{
				return this._value.ToString("'-'yyyy", CultureInfo.InvariantCulture);
			}
			return this._value.ToString("yyyy", CultureInfo.InvariantCulture);
		}

		/// <summary>Converts the specified <see cref="T:System.String" /> into a <see cref="T:System.Runtime.Remoting.Metadata.W3cXsd2001.SoapYear" /> object.</summary>
		/// <param name="value">The <see cref="T:System.String" /> to convert.</param>
		/// <returns>A <see cref="T:System.Runtime.Remoting.Metadata.W3cXsd2001.SoapYear" /> object that is obtained from <paramref name="value" />.</returns>
		/// <exception cref="T:System.Runtime.Remoting.RemotingException">
		///   <paramref name="value" /> does not contain a date and time that corresponds to any of the recognized format patterns.</exception>
		// Token: 0x06005635 RID: 22069 RVA: 0x00131088 File Offset: 0x0012F288
		public static SoapYear Parse(string value)
		{
			int sign = 0;
			if (value[0] == '-')
			{
				sign = -1;
			}
			return new SoapYear(DateTime.ParseExact(value, SoapYear.formats, CultureInfo.InvariantCulture, DateTimeStyles.None), sign);
		}

		// Token: 0x04002753 RID: 10067
		private DateTime _value = DateTime.MinValue;

		// Token: 0x04002754 RID: 10068
		private int _sign;

		// Token: 0x04002755 RID: 10069
		private static string[] formats = new string[]
		{
			"yyyy",
			"'+'yyyy",
			"'-'yyyy",
			"yyyyzzz",
			"'+'yyyyzzz",
			"'-'yyyyzzz"
		};
	}
}
