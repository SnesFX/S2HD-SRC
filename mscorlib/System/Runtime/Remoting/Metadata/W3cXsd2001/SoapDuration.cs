﻿using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;

namespace System.Runtime.Remoting.Metadata.W3cXsd2001
{
	/// <summary>Provides static methods for the serialization and deserialization of <see cref="T:System.TimeSpan" /> to a string that is formatted as XSD <see langword="duration" />.</summary>
	// Token: 0x020007B2 RID: 1970
	[ComVisible(true)]
	public sealed class SoapDuration
	{
		/// <summary>Gets the XML Schema definition language (XSD) of the current SOAP type.</summary>
		/// <returns>A <see cref="T:System.String" /> that indicates the XSD of the current SOAP type.</returns>
		// Token: 0x17000E4A RID: 3658
		// (get) Token: 0x06005605 RID: 22021 RVA: 0x0013076E File Offset: 0x0012E96E
		public static string XsdType
		{
			get
			{
				return "duration";
			}
		}

		// Token: 0x06005606 RID: 22022 RVA: 0x00130778 File Offset: 0x0012E978
		private static void CarryOver(int inDays, out int years, out int months, out int days)
		{
			years = inDays / 360;
			int num = years * 360;
			months = Math.Max(0, inDays - num) / 30;
			int num2 = months * 30;
			days = Math.Max(0, inDays - (num + num2));
			days = inDays % 30;
		}

		/// <summary>Returns the specified <see cref="T:System.TimeSpan" /> object as a <see cref="T:System.String" />.</summary>
		/// <param name="timeSpan">The <see cref="T:System.TimeSpan" /> object to convert.</param>
		/// <returns>A <see cref="T:System.String" /> representation of <paramref name="timeSpan" /> in the format "PxxYxxDTxxHxxMxx.xxxS" or "PxxYxxDTxxHxxMxxS". The "PxxYxxDTxxHxxMxx.xxxS" is used if <see cref="P:System.TimeSpan.Milliseconds" /> does not equal zero.</returns>
		// Token: 0x06005607 RID: 22023 RVA: 0x001307C0 File Offset: 0x0012E9C0
		[SecuritySafeCritical]
		public static string ToString(TimeSpan timeSpan)
		{
			StringBuilder stringBuilder = new StringBuilder(10);
			stringBuilder.Length = 0;
			if (TimeSpan.Compare(timeSpan, TimeSpan.Zero) < 1)
			{
				stringBuilder.Append('-');
			}
			int value = 0;
			int value2 = 0;
			int value3 = 0;
			SoapDuration.CarryOver(Math.Abs(timeSpan.Days), out value, out value2, out value3);
			stringBuilder.Append('P');
			stringBuilder.Append(value);
			stringBuilder.Append('Y');
			stringBuilder.Append(value2);
			stringBuilder.Append('M');
			stringBuilder.Append(value3);
			stringBuilder.Append("DT");
			stringBuilder.Append(Math.Abs(timeSpan.Hours));
			stringBuilder.Append('H');
			stringBuilder.Append(Math.Abs(timeSpan.Minutes));
			stringBuilder.Append('M');
			stringBuilder.Append(Math.Abs(timeSpan.Seconds));
			long num = Math.Abs(timeSpan.Ticks % 864000000000L);
			int num2 = (int)(num % 10000000L);
			if (num2 != 0)
			{
				string value4 = ParseNumbers.IntToString(num2, 10, 7, '0', 0);
				stringBuilder.Append('.');
				stringBuilder.Append(value4);
			}
			stringBuilder.Append('S');
			return stringBuilder.ToString();
		}

		/// <summary>Converts the specified <see cref="T:System.String" /> into a <see cref="T:System.TimeSpan" /> object.</summary>
		/// <param name="value">The <see cref="T:System.String" /> to convert.</param>
		/// <returns>A <see cref="T:System.TimeSpan" /> object that is obtained from <paramref name="value" />.</returns>
		/// <exception cref="T:System.Runtime.Remoting.RemotingException">
		///   <paramref name="value" /> does not contain a date and time that corresponds to any of the recognized format patterns.</exception>
		// Token: 0x06005608 RID: 22024 RVA: 0x001308F4 File Offset: 0x0012EAF4
		public static TimeSpan Parse(string value)
		{
			int num = 1;
			TimeSpan result;
			try
			{
				if (value == null)
				{
					result = TimeSpan.Zero;
				}
				else
				{
					if (value[0] == '-')
					{
						num = -1;
					}
					char[] array = value.ToCharArray();
					int[] array2 = new int[7];
					string s = "0";
					string s2 = "0";
					string s3 = "0";
					string s4 = "0";
					string s5 = "0";
					string str = "0";
					string str2 = "0";
					bool flag = false;
					bool flag2 = false;
					int num2 = 0;
					for (int i = 0; i < array.Length; i++)
					{
						char c = array[i];
						if (c <= 'H')
						{
							if (c != '.')
							{
								if (c != 'D')
								{
									if (c == 'H')
									{
										s4 = new string(array, num2, i - num2);
										num2 = i + 1;
									}
								}
								else
								{
									s3 = new string(array, num2, i - num2);
									num2 = i + 1;
								}
							}
							else
							{
								flag2 = true;
								str = new string(array, num2, i - num2);
								num2 = i + 1;
							}
						}
						else if (c <= 'T')
						{
							if (c != 'M')
							{
								switch (c)
								{
								case 'P':
									num2 = i + 1;
									break;
								case 'S':
									if (!flag2)
									{
										str = new string(array, num2, i - num2);
									}
									else
									{
										str2 = new string(array, num2, i - num2);
									}
									break;
								case 'T':
									flag = true;
									num2 = i + 1;
									break;
								}
							}
							else
							{
								if (flag)
								{
									s5 = new string(array, num2, i - num2);
								}
								else
								{
									s2 = new string(array, num2, i - num2);
								}
								num2 = i + 1;
							}
						}
						else if (c != 'Y')
						{
							if (c != 'Z')
							{
							}
						}
						else
						{
							s = new string(array, num2, i - num2);
							num2 = i + 1;
						}
					}
					long ticks = (long)num * ((long.Parse(s, CultureInfo.InvariantCulture) * 360L + long.Parse(s2, CultureInfo.InvariantCulture) * 30L + long.Parse(s3, CultureInfo.InvariantCulture)) * 864000000000L + long.Parse(s4, CultureInfo.InvariantCulture) * 36000000000L + long.Parse(s5, CultureInfo.InvariantCulture) * 600000000L + Convert.ToInt64(double.Parse(str + "." + str2, CultureInfo.InvariantCulture) * 10000000.0));
					result = new TimeSpan(ticks);
				}
			}
			catch (Exception)
			{
				throw new RemotingException(string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("Remoting_SOAPInteropxsdInvalid"), "xsd:duration", value));
			}
			return result;
		}
	}
}
