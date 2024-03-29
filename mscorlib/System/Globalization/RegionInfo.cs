﻿using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security;

namespace System.Globalization
{
	/// <summary>Contains information about the country/region.</summary>
	// Token: 0x020003A2 RID: 930
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public class RegionInfo
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Globalization.RegionInfo" /> class based on the country/region or specific culture, specified by name.</summary>
		/// <param name="name">A string that contains a two-letter code defined in ISO 3166 for country/region.  
		///  -or-  
		///  A string that contains the culture name for a specific culture, custom culture, or Windows-only culture. If the culture name is not in RFC 4646 format, your application should specify the entire culture name instead of just the country/region.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="name" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="name" /> is not a valid country/region name or specific culture name.</exception>
		// Token: 0x06003026 RID: 12326 RVA: 0x000B8BE4 File Offset: 0x000B6DE4
		[SecuritySafeCritical]
		[__DynamicallyInvokable]
		public RegionInfo(string name)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			if (name.Length == 0)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_NoRegionInvariantCulture"));
			}
			this.m_cultureData = CultureData.GetCultureDataForRegion(name, true);
			if (this.m_cultureData == null)
			{
				throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("Argument_InvalidCultureName"), name), "name");
			}
			if (this.m_cultureData.IsNeutralCulture)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_InvalidNeutralRegionName", new object[]
				{
					name
				}), "name");
			}
			this.SetName(name);
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Globalization.RegionInfo" /> class based on the country/region associated with the specified culture identifier.</summary>
		/// <param name="culture">A culture identifier.</param>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="culture" /> specifies either an invariant, custom, or neutral culture.</exception>
		// Token: 0x06003027 RID: 12327 RVA: 0x000B8C88 File Offset: 0x000B6E88
		[SecuritySafeCritical]
		public RegionInfo(int culture)
		{
			if (culture == 127)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_NoRegionInvariantCulture"));
			}
			if (culture == 0)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_CultureIsNeutral", new object[]
				{
					culture
				}), "culture");
			}
			if (culture == 3072)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_CustomCultureCannotBePassedByNumber", new object[]
				{
					culture
				}), "culture");
			}
			this.m_cultureData = CultureData.GetCultureData(culture, true);
			this.m_name = this.m_cultureData.SREGIONNAME;
			if (this.m_cultureData.IsNeutralCulture)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_CultureIsNeutral", new object[]
				{
					culture
				}), "culture");
			}
			this.m_cultureId = culture;
		}

		// Token: 0x06003028 RID: 12328 RVA: 0x000B8D59 File Offset: 0x000B6F59
		[SecuritySafeCritical]
		internal RegionInfo(CultureData cultureData)
		{
			this.m_cultureData = cultureData;
			this.m_name = this.m_cultureData.SREGIONNAME;
		}

		// Token: 0x06003029 RID: 12329 RVA: 0x000B8D79 File Offset: 0x000B6F79
		[SecurityCritical]
		private void SetName(string name)
		{
			this.m_name = (name.Equals(this.m_cultureData.SREGIONNAME, StringComparison.OrdinalIgnoreCase) ? this.m_cultureData.SREGIONNAME : this.m_cultureData.CultureName);
		}

		// Token: 0x0600302A RID: 12330 RVA: 0x000B8DB0 File Offset: 0x000B6FB0
		[SecurityCritical]
		[OnDeserialized]
		private void OnDeserialized(StreamingContext ctx)
		{
			if (this.m_name == null)
			{
				this.m_cultureId = RegionInfo.IdFromEverettRegionInfoDataItem[this.m_dataItem];
			}
			if (this.m_cultureId == 0)
			{
				this.m_cultureData = CultureData.GetCultureDataForRegion(this.m_name, true);
			}
			else
			{
				this.m_cultureData = CultureData.GetCultureData(this.m_cultureId, true);
			}
			if (this.m_cultureData == null)
			{
				throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("Argument_InvalidCultureName"), this.m_name), "m_name");
			}
			if (this.m_cultureId == 0)
			{
				this.SetName(this.m_name);
				return;
			}
			this.m_name = this.m_cultureData.SREGIONNAME;
		}

		// Token: 0x0600302B RID: 12331 RVA: 0x000B8E58 File Offset: 0x000B7058
		[OnSerializing]
		private void OnSerializing(StreamingContext ctx)
		{
		}

		/// <summary>Gets the <see cref="T:System.Globalization.RegionInfo" /> that represents the country/region used by the current thread.</summary>
		/// <returns>The <see cref="T:System.Globalization.RegionInfo" /> that represents the country/region used by the current thread.</returns>
		// Token: 0x170006C2 RID: 1730
		// (get) Token: 0x0600302C RID: 12332 RVA: 0x000B8E5C File Offset: 0x000B705C
		[__DynamicallyInvokable]
		public static RegionInfo CurrentRegion
		{
			[SecuritySafeCritical]
			[__DynamicallyInvokable]
			get
			{
				RegionInfo regionInfo = RegionInfo.s_currentRegionInfo;
				if (regionInfo == null)
				{
					regionInfo = new RegionInfo(CultureInfo.CurrentCulture.m_cultureData);
					regionInfo.m_name = regionInfo.m_cultureData.SREGIONNAME;
					RegionInfo.s_currentRegionInfo = regionInfo;
				}
				return regionInfo;
			}
		}

		/// <summary>Gets the name or ISO 3166 two-letter country/region code for the current <see cref="T:System.Globalization.RegionInfo" /> object.</summary>
		/// <returns>The value specified by the <paramref name="name" /> parameter of the <see cref="M:System.Globalization.RegionInfo.#ctor(System.String)" /> constructor. The return value is in uppercase.  
		///  -or-  
		///  The two-letter code defined in ISO 3166 for the country/region specified by the <paramref name="culture" /> parameter of the <see cref="M:System.Globalization.RegionInfo.#ctor(System.Int32)" /> constructor. The return value is in uppercase.</returns>
		// Token: 0x170006C3 RID: 1731
		// (get) Token: 0x0600302D RID: 12333 RVA: 0x000B8E9E File Offset: 0x000B709E
		[__DynamicallyInvokable]
		public virtual string Name
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_name;
			}
		}

		/// <summary>Gets the full name of the country/region in English.</summary>
		/// <returns>The full name of the country/region in English.</returns>
		// Token: 0x170006C4 RID: 1732
		// (get) Token: 0x0600302E RID: 12334 RVA: 0x000B8EA6 File Offset: 0x000B70A6
		[__DynamicallyInvokable]
		public virtual string EnglishName
		{
			[SecuritySafeCritical]
			[__DynamicallyInvokable]
			get
			{
				return this.m_cultureData.SENGCOUNTRY;
			}
		}

		/// <summary>Gets the full name of the country/region in the language of the localized version of .NET Framework.</summary>
		/// <returns>The full name of the country/region in the language of the localized version of .NET Framework.</returns>
		// Token: 0x170006C5 RID: 1733
		// (get) Token: 0x0600302F RID: 12335 RVA: 0x000B8EB3 File Offset: 0x000B70B3
		[__DynamicallyInvokable]
		public virtual string DisplayName
		{
			[SecuritySafeCritical]
			[__DynamicallyInvokable]
			get
			{
				return this.m_cultureData.SLOCALIZEDCOUNTRY;
			}
		}

		/// <summary>Gets the name of a country/region formatted in the native language of the country/region.</summary>
		/// <returns>The native name of the country/region formatted in the language associated with the ISO 3166 country/region code.</returns>
		// Token: 0x170006C6 RID: 1734
		// (get) Token: 0x06003030 RID: 12336 RVA: 0x000B8EC0 File Offset: 0x000B70C0
		[ComVisible(false)]
		[__DynamicallyInvokable]
		public virtual string NativeName
		{
			[SecuritySafeCritical]
			[__DynamicallyInvokable]
			get
			{
				return this.m_cultureData.SNATIVECOUNTRY;
			}
		}

		/// <summary>Gets the two-letter code defined in ISO 3166 for the country/region.</summary>
		/// <returns>The two-letter code defined in ISO 3166 for the country/region.</returns>
		// Token: 0x170006C7 RID: 1735
		// (get) Token: 0x06003031 RID: 12337 RVA: 0x000B8ECD File Offset: 0x000B70CD
		[__DynamicallyInvokable]
		public virtual string TwoLetterISORegionName
		{
			[SecuritySafeCritical]
			[__DynamicallyInvokable]
			get
			{
				return this.m_cultureData.SISO3166CTRYNAME;
			}
		}

		/// <summary>Gets the three-letter code defined in ISO 3166 for the country/region.</summary>
		/// <returns>The three-letter code defined in ISO 3166 for the country/region.</returns>
		// Token: 0x170006C8 RID: 1736
		// (get) Token: 0x06003032 RID: 12338 RVA: 0x000B8EDA File Offset: 0x000B70DA
		public virtual string ThreeLetterISORegionName
		{
			[SecuritySafeCritical]
			get
			{
				return this.m_cultureData.SISO3166CTRYNAME2;
			}
		}

		/// <summary>Gets the three-letter code assigned by Windows to the country/region represented by this <see cref="T:System.Globalization.RegionInfo" />.</summary>
		/// <returns>The three-letter code assigned by Windows to the country/region represented by this <see cref="T:System.Globalization.RegionInfo" />.</returns>
		// Token: 0x170006C9 RID: 1737
		// (get) Token: 0x06003033 RID: 12339 RVA: 0x000B8EE7 File Offset: 0x000B70E7
		public virtual string ThreeLetterWindowsRegionName
		{
			[SecuritySafeCritical]
			get
			{
				return this.m_cultureData.SABBREVCTRYNAME;
			}
		}

		/// <summary>Gets a value indicating whether the country/region uses the metric system for measurements.</summary>
		/// <returns>
		///   <see langword="true" /> if the country/region uses the metric system for measurements; otherwise, <see langword="false" />.</returns>
		// Token: 0x170006CA RID: 1738
		// (get) Token: 0x06003034 RID: 12340 RVA: 0x000B8EF4 File Offset: 0x000B70F4
		[__DynamicallyInvokable]
		public virtual bool IsMetric
		{
			[__DynamicallyInvokable]
			get
			{
				int imeasure = this.m_cultureData.IMEASURE;
				return imeasure == 0;
			}
		}

		/// <summary>Gets a unique identification number for a geographical region, country, city, or location.</summary>
		/// <returns>A 32-bit signed number that uniquely identifies a geographical location.</returns>
		// Token: 0x170006CB RID: 1739
		// (get) Token: 0x06003035 RID: 12341 RVA: 0x000B8F11 File Offset: 0x000B7111
		[ComVisible(false)]
		public virtual int GeoId
		{
			get
			{
				return this.m_cultureData.IGEOID;
			}
		}

		/// <summary>Gets the name, in English, of the currency used in the country/region.</summary>
		/// <returns>The name, in English, of the currency used in the country/region.</returns>
		// Token: 0x170006CC RID: 1740
		// (get) Token: 0x06003036 RID: 12342 RVA: 0x000B8F1E File Offset: 0x000B711E
		[ComVisible(false)]
		public virtual string CurrencyEnglishName
		{
			[SecuritySafeCritical]
			get
			{
				return this.m_cultureData.SENGLISHCURRENCY;
			}
		}

		/// <summary>Gets the name of the currency used in the country/region, formatted in the native language of the country/region.</summary>
		/// <returns>The native name of the currency used in the country/region, formatted in the language associated with the ISO 3166 country/region code.</returns>
		// Token: 0x170006CD RID: 1741
		// (get) Token: 0x06003037 RID: 12343 RVA: 0x000B8F2B File Offset: 0x000B712B
		[ComVisible(false)]
		public virtual string CurrencyNativeName
		{
			[SecuritySafeCritical]
			get
			{
				return this.m_cultureData.SNATIVECURRENCY;
			}
		}

		/// <summary>Gets the currency symbol associated with the country/region.</summary>
		/// <returns>The currency symbol associated with the country/region.</returns>
		// Token: 0x170006CE RID: 1742
		// (get) Token: 0x06003038 RID: 12344 RVA: 0x000B8F38 File Offset: 0x000B7138
		[__DynamicallyInvokable]
		public virtual string CurrencySymbol
		{
			[SecuritySafeCritical]
			[__DynamicallyInvokable]
			get
			{
				return this.m_cultureData.SCURRENCY;
			}
		}

		/// <summary>Gets the three-character ISO 4217 currency symbol associated with the country/region.</summary>
		/// <returns>The three-character ISO 4217 currency symbol associated with the country/region.</returns>
		// Token: 0x170006CF RID: 1743
		// (get) Token: 0x06003039 RID: 12345 RVA: 0x000B8F45 File Offset: 0x000B7145
		[__DynamicallyInvokable]
		public virtual string ISOCurrencySymbol
		{
			[SecuritySafeCritical]
			[__DynamicallyInvokable]
			get
			{
				return this.m_cultureData.SINTLSYMBOL;
			}
		}

		/// <summary>Determines whether the specified object is the same instance as the current <see cref="T:System.Globalization.RegionInfo" />.</summary>
		/// <param name="value">The object to compare with the current <see cref="T:System.Globalization.RegionInfo" />.</param>
		/// <returns>
		///   <see langword="true" /> if the <paramref name="value" /> parameter is a <see cref="T:System.Globalization.RegionInfo" /> object and its <see cref="P:System.Globalization.RegionInfo.Name" /> property is the same as the <see cref="P:System.Globalization.RegionInfo.Name" /> property of the current <see cref="T:System.Globalization.RegionInfo" /> object; otherwise, <see langword="false" />.</returns>
		// Token: 0x0600303A RID: 12346 RVA: 0x000B8F54 File Offset: 0x000B7154
		[__DynamicallyInvokable]
		public override bool Equals(object value)
		{
			RegionInfo regionInfo = value as RegionInfo;
			return regionInfo != null && this.Name.Equals(regionInfo.Name);
		}

		/// <summary>Serves as a hash function for the current <see cref="T:System.Globalization.RegionInfo" />, suitable for hashing algorithms and data structures, such as a hash table.</summary>
		/// <returns>A hash code for the current <see cref="T:System.Globalization.RegionInfo" />.</returns>
		// Token: 0x0600303B RID: 12347 RVA: 0x000B8F7E File Offset: 0x000B717E
		[__DynamicallyInvokable]
		public override int GetHashCode()
		{
			return this.Name.GetHashCode();
		}

		/// <summary>Returns a string containing the culture name or ISO 3166 two-letter country/region codes specified for the current <see cref="T:System.Globalization.RegionInfo" />.</summary>
		/// <returns>A string containing the culture name or ISO 3166 two-letter country/region codes defined for the current <see cref="T:System.Globalization.RegionInfo" />.</returns>
		// Token: 0x0600303C RID: 12348 RVA: 0x000B8F8B File Offset: 0x000B718B
		[__DynamicallyInvokable]
		public override string ToString()
		{
			return this.Name;
		}

		// Token: 0x04001458 RID: 5208
		internal string m_name;

		// Token: 0x04001459 RID: 5209
		[NonSerialized]
		internal CultureData m_cultureData;

		// Token: 0x0400145A RID: 5210
		internal static volatile RegionInfo s_currentRegionInfo;

		// Token: 0x0400145B RID: 5211
		[OptionalField(VersionAdded = 2)]
		private int m_cultureId;

		// Token: 0x0400145C RID: 5212
		[OptionalField(VersionAdded = 2)]
		internal int m_dataItem;

		// Token: 0x0400145D RID: 5213
		private static readonly int[] IdFromEverettRegionInfoDataItem = new int[]
		{
			14337,
			1052,
			1067,
			11274,
			3079,
			3081,
			1068,
			2060,
			1026,
			15361,
			2110,
			16394,
			1046,
			1059,
			10249,
			3084,
			9225,
			2055,
			13322,
			2052,
			9226,
			5130,
			1029,
			1031,
			1030,
			7178,
			5121,
			12298,
			1061,
			3073,
			1027,
			1035,
			1080,
			1036,
			2057,
			1079,
			1032,
			4106,
			3076,
			18442,
			1050,
			1038,
			1057,
			6153,
			1037,
			1081,
			2049,
			1065,
			1039,
			1040,
			8201,
			11265,
			1041,
			1089,
			1088,
			1042,
			13313,
			1087,
			12289,
			5127,
			1063,
			4103,
			1062,
			4097,
			6145,
			6156,
			1071,
			1104,
			5124,
			1125,
			2058,
			1086,
			19466,
			1043,
			1044,
			5129,
			8193,
			6154,
			10250,
			13321,
			1056,
			1045,
			20490,
			2070,
			15370,
			16385,
			1048,
			1049,
			1025,
			1053,
			4100,
			1060,
			1051,
			2074,
			17418,
			1114,
			1054,
			7169,
			1055,
			11273,
			1028,
			1058,
			1033,
			14346,
			1091,
			8202,
			1066,
			9217,
			1078,
			12297
		};
	}
}
