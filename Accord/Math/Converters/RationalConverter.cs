using System;
using System.ComponentModel;
using System.Globalization;

namespace Accord.Math.Converters
{
	// Token: 0x02000031 RID: 49
	public class RationalConverter : TypeConverter
	{
		// Token: 0x060001D9 RID: 473 RVA: 0x00005D34 File Offset: 0x00004D34
		public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
		{
			sourceType = RationalConverter.GetUnderlyingType(sourceType);
			return sourceType == typeof(Rational) || sourceType == typeof(string) || sourceType == typeof(int) || sourceType == typeof(double) || sourceType == typeof(long) || sourceType == typeof(short) || sourceType == typeof(uint) || sourceType == typeof(ulong) || sourceType == typeof(ushort) || sourceType == typeof(float) || sourceType == typeof(decimal) || sourceType == typeof(byte) || sourceType == typeof(sbyte) || sourceType == typeof(bool);
		}

		// Token: 0x060001DA RID: 474 RVA: 0x00005E58 File Offset: 0x00004E58
		public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
		{
			if (value == null)
			{
				return null;
			}
			if (value is Rational)
			{
				return (Rational)value;
			}
			if (value is string)
			{
				return Rational.Parse((string)value, culture);
			}
			if (value is int)
			{
				return new Rational((int)value);
			}
			if (value is double)
			{
				return Rational.FromDouble((double)value, 1E-06);
			}
			if (value is long)
			{
				return (long)value;
			}
			if (value is short)
			{
				return (short)value;
			}
			if (value is uint)
			{
				return (uint)value;
			}
			if (value is ulong)
			{
				return (ulong)value;
			}
			if (value is ushort)
			{
				return (ushort)value;
			}
			if (value is float)
			{
				return (Rational)((float)value);
			}
			if (value is byte)
			{
				return (byte)value;
			}
			if (value is sbyte)
			{
				return (sbyte)value;
			}
			if (value is bool)
			{
				return ((bool)value) ? Rational.One : Rational.Zero;
			}
			throw new ArgumentException("Inavlid value type: " + value.GetType().FullName, "value");
		}

		// Token: 0x060001DB RID: 475 RVA: 0x00005FDC File Offset: 0x00004FDC
		public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
		{
			destinationType = RationalConverter.GetUnderlyingType(destinationType);
			return destinationType == typeof(Rational) || destinationType == typeof(string) || destinationType == typeof(int) || destinationType == typeof(double) || destinationType == typeof(long) || destinationType == typeof(short) || destinationType == typeof(uint) || destinationType == typeof(ulong) || destinationType == typeof(ushort) || destinationType == typeof(float) || destinationType == typeof(decimal) || destinationType == typeof(byte) || destinationType == typeof(sbyte) || destinationType == typeof(bool);
		}

		// Token: 0x060001DC RID: 476 RVA: 0x00006100 File Offset: 0x00005100
		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
		{
			if (value == null)
			{
				if (RationalConverter.IsNullableType(destinationType))
				{
					return null;
				}
				throw new InvalidCastException("Cannot convert null to type " + destinationType.FullName);
			}
			else
			{
				if (!(value is Rational))
				{
					throw new ArgumentException("value must be a rational.", "value");
				}
				Rational rational = (Rational)value;
				if (destinationType == typeof(Rational))
				{
					return rational;
				}
				if (destinationType == typeof(string))
				{
					return rational.ToString(culture);
				}
				if (destinationType == typeof(int))
				{
					return Rational.Round(rational);
				}
				if (destinationType == typeof(double))
				{
					return rational.Value;
				}
				if (destinationType == typeof(long))
				{
					return (long)Rational.Round(rational);
				}
				if (destinationType == typeof(short))
				{
					return (short)Rational.Round(rational);
				}
				if (destinationType == typeof(uint))
				{
					return (uint)Rational.Round(rational);
				}
				if (destinationType == typeof(ulong))
				{
					return (ulong)((long)Rational.Round(rational));
				}
				if (destinationType == typeof(ushort))
				{
					return (ushort)Rational.Round(rational);
				}
				if (destinationType == typeof(float))
				{
					return (float)rational;
				}
				if (destinationType == typeof(byte))
				{
					return (byte)Rational.Round(rational);
				}
				if (destinationType == typeof(sbyte))
				{
					return (sbyte)Rational.Round(rational);
				}
				if (destinationType == typeof(bool))
				{
					return !Rational.IsZero(rational);
				}
				throw new ArgumentException("Inavlid destinationType: " + destinationType.FullName, "destinationType");
			}
		}

		// Token: 0x060001DD RID: 477 RVA: 0x00006302 File Offset: 0x00005302
		private static bool IsNullableType(Type t)
		{
			return t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>);
		}

		// Token: 0x060001DE RID: 478 RVA: 0x00006323 File Offset: 0x00005323
		private static Type GetUnderlyingType(Type t)
		{
			if (!RationalConverter.IsNullableType(t))
			{
				return t;
			}
			return Nullable.GetUnderlyingType(t);
		}
	}
}
