using System;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.InteropServices;
using Accord.Math.Converters;

namespace Accord.Math
{
	// Token: 0x0200002D RID: 45
	[TypeConverter(typeof(RationalConverter))]
	[Serializable]
	public struct Rational : IComparable, IComparable<Rational>, IEquatable<Rational>, IFormattable
	{
		// Token: 0x06000136 RID: 310 RVA: 0x00004376 File Offset: 0x00003376
		public static Rational Parse(string s)
		{
			return Rational.Parse(s, null);
		}

		// Token: 0x06000137 RID: 311 RVA: 0x0000437F File Offset: 0x0000337F
		public static Rational Parse(string s, NumberStyles style)
		{
			return Rational.Parse(s, style, null);
		}

		// Token: 0x06000138 RID: 312 RVA: 0x00004389 File Offset: 0x00003389
		public static Rational Parse(string s, IFormatProvider provider)
		{
			return Rational.Parse(s, NumberStyles.Any, null);
		}

		// Token: 0x06000139 RID: 313 RVA: 0x00004398 File Offset: 0x00003398
		public static Rational Parse(string s, NumberStyles style, IFormatProvider provider)
		{
			Rational result;
			Rational.TryParse(s, style, provider, true, out result);
			return result;
		}

		// Token: 0x0600013A RID: 314 RVA: 0x000043B2 File Offset: 0x000033B2
		public static bool TryParse(string s, out Rational result)
		{
			return Rational.TryParse(s, null, out result);
		}

		// Token: 0x0600013B RID: 315 RVA: 0x000043BC File Offset: 0x000033BC
		public static bool TryParse(string s, NumberStyles style, out Rational result)
		{
			return Rational.TryParse(s, style, null, out result);
		}

		// Token: 0x0600013C RID: 316 RVA: 0x000043C7 File Offset: 0x000033C7
		public static bool TryParse(string s, IFormatProvider provider, out Rational result)
		{
			return Rational.TryParse(s, NumberStyles.Any, provider, out result);
		}

		// Token: 0x0600013D RID: 317 RVA: 0x000043D6 File Offset: 0x000033D6
		public static bool TryParse(string s, NumberStyles style, IFormatProvider provider, out Rational result)
		{
			return Rational.TryParse(s, style, provider, false, out result);
		}

		// Token: 0x0600013E RID: 318 RVA: 0x000043E4 File Offset: 0x000033E4
		private static bool TryParse(string s, NumberStyles style, IFormatProvider provider, bool throwOnFailure, out Rational result)
		{
			if (string.IsNullOrWhiteSpace(s))
			{
				return Rational.ParseFailure(throwOnFailure, out result);
			}
			string[] array = s.Split(new char[]
			{
				'/'
			});
			if (array.Length > 2)
			{
				return Rational.ParseFailure(throwOnFailure, out result);
			}
			if (array.Length == 1)
			{
				int numerator;
				if (int.TryParse(s, style, provider, out numerator))
				{
					result = new Rational(numerator);
					return true;
				}
				double value;
				if (!double.TryParse(s, style, provider, out value))
				{
					return Rational.ParseFailure(throwOnFailure, out result);
				}
				result = Rational.FromDouble(value, 1E-06);
				return true;
			}
			else
			{
				string text = array[0].Trim();
				int num = text.LastIndexOf('-');
				if (num <= 0)
				{
					num = text.LastIndexOf(' ');
				}
				int num2 = 0;
				if (num > 0)
				{
					string s2 = text.Remove(num);
					text = text.Substring(num + 1);
					if (!Rational.TryParseInt(s2, style, provider, throwOnFailure, out num2))
					{
						result = Rational.Indeterminate;
						return false;
					}
				}
				int num3;
				int num4;
				if (!Rational.TryParseInt(text, style, provider, throwOnFailure, out num3) || !Rational.TryParseInt(array[1], style, provider, throwOnFailure, out num4))
				{
					result = Rational.Indeterminate;
					return false;
				}
				if (num2 < 0)
				{
					num3 *= -1;
				}
				result = new Rational(num2 * num4 + num3, num4);
				return true;
			}
		}

		// Token: 0x0600013F RID: 319 RVA: 0x00004511 File Offset: 0x00003511
		private static bool ParseFailure(bool throwOnFailure, out Rational result)
		{
			if (throwOnFailure)
			{
				throw new FormatException();
			}
			result = Rational.Indeterminate;
			return false;
		}

		// Token: 0x06000140 RID: 320 RVA: 0x00004528 File Offset: 0x00003528
		private static bool TryParseInt(string s, NumberStyles style, IFormatProvider provider, bool throwOnFailure, out int result)
		{
			if (throwOnFailure)
			{
				result = int.Parse(s, style, provider);
				return true;
			}
			return int.TryParse(s, style, provider, out result);
		}

		// Token: 0x06000141 RID: 321 RVA: 0x00004544 File Offset: 0x00003544
		public static Rational FromDouble(double value, double tolerance = 1E-06)
		{
			if (double.IsPositiveInfinity(value))
			{
				return Rational.PositiveInfinity;
			}
			if (double.IsNegativeInfinity(value))
			{
				return Rational.NegativeInfinity;
			}
			if (double.IsNaN(value))
			{
				return Rational.Indeterminate;
			}
			double num = value;
			if (value < 0.0)
			{
				value *= -1.0;
			}
			double num2 = 1.0;
			double num3 = value - Math.Truncate(value);
			int num4 = 0;
			while (!Rational.IsInteger(num3, tolerance) && num4 < 100)
			{
				value = 1.0 / num3;
				num2 *= value;
				num3 = value % 1.0;
				num4++;
			}
			num *= num2;
			return new Rational(Convert.ToInt32(num), Convert.ToInt32(num2));
		}

		// Token: 0x06000142 RID: 322 RVA: 0x000045F4 File Offset: 0x000035F4
		public static Rational FromDecimal(decimal value, [Optional] decimal tolerance = 0.000000000000001m)
		{
			decimal num = value;
			if (value < 0m)
			{
				value *= -1m;
			}
			decimal num2 = 1.0m;
			decimal num3 = value - Math.Truncate(value);
			int num4 = 0;
			while (!Rational.IsInteger(num3, tolerance) && num4 < 100)
			{
				value = 1.0m / num3;
				num2 *= value;
				num3 = value % 1.0m;
				num4++;
			}
			num *= num2;
			return new Rational(Convert.ToInt32(num), Convert.ToInt32(num2));
		}

		// Token: 0x06000143 RID: 323 RVA: 0x00004694 File Offset: 0x00003694
		public static Rational FromDoubleWithMaxDenominator(double value, int maxDenominator, double tolerance = 1E-06)
		{
			if (double.IsPositiveInfinity(value))
			{
				return Rational.PositiveInfinity;
			}
			if (double.IsNegativeInfinity(value))
			{
				return Rational.NegativeInfinity;
			}
			if (double.IsNaN(value))
			{
				return Rational.Indeterminate;
			}
			if (maxDenominator < 1)
			{
				throw new ArgumentOutOfRangeException("Maximum denominator base must be greater than or equal to 1.", "maxDenominator");
			}
			int num = 0;
			double num2 = 1.0;
			double num3;
			do
			{
				num++;
				num3 = value * (double)num;
				double num4 = Math.Abs(num3 % 1.0);
				if (num4 < num2)
				{
					num2 = num4;
				}
			}
			while (!Rational.IsInteger(num3, tolerance) && num < maxDenominator);
			return new Rational(Convert.ToInt32(num3), num);
		}

		// Token: 0x06000144 RID: 324 RVA: 0x0000472B File Offset: 0x0000372B
		public static Rational Abs(Rational value)
		{
			return new Rational(Math.Abs(value.Numerator), Math.Abs(value.Denominator));
		}

		// Token: 0x06000145 RID: 325 RVA: 0x0000474A File Offset: 0x0000374A
		public static Rational Min(Rational val1, Rational val2)
		{
			if (!(val1 <= val2))
			{
				return val2;
			}
			return val1;
		}

		// Token: 0x06000146 RID: 326 RVA: 0x00004758 File Offset: 0x00003758
		public static Rational Max(Rational val1, Rational val2)
		{
			if (!(val1 >= val2))
			{
				return val2;
			}
			return val1;
		}

		// Token: 0x06000147 RID: 327 RVA: 0x00004766 File Offset: 0x00003766
		public static int Round(Rational x)
		{
			return (x.Numerator + x.Denominator / 2) / x.Denominator;
		}

		// Token: 0x06000148 RID: 328 RVA: 0x00004784 File Offset: 0x00003784
		public static Rational Pow(Rational baseValue, int exponent)
		{
			Rational rational = Rational.One;
			if (exponent < 0)
			{
				exponent *= -1;
				baseValue = baseValue.Inverse();
			}
			while (exponent > 0)
			{
				if ((exponent & 1) == 1)
				{
					rational *= baseValue;
				}
				exponent >>= 1;
				baseValue *= baseValue;
			}
			return rational;
		}

		// Token: 0x06000149 RID: 329 RVA: 0x000047CC File Offset: 0x000037CC
		public static int DivRem(Rational a, Rational b, out Rational remainder)
		{
			if (b._numerator == 0 || a._denominator == 0)
			{
				throw new DivideByZeroException();
			}
			if (b._denominator == 0)
			{
				remainder = a;
				return 0;
			}
			int a2 = a._numerator * b._denominator;
			int b2 = b._numerator * a._denominator;
			int denominator = a._denominator * b._denominator;
			int numerator;
			int result = Math.DivRem(a2, b2, out numerator);
			remainder = Rational.Simplify(numerator, denominator);
			return result;
		}

		// Token: 0x0600014A RID: 330 RVA: 0x00004844 File Offset: 0x00003844
		public static bool IsInfinity(Rational r)
		{
			return r._denominator == 0 && r._numerator != 0;
		}

		// Token: 0x0600014B RID: 331 RVA: 0x00004859 File Offset: 0x00003859
		public static bool IsPositiveInfinity(Rational r)
		{
			return r._denominator == 0 && r._numerator > 0;
		}

		// Token: 0x0600014C RID: 332 RVA: 0x0000486E File Offset: 0x0000386E
		public static bool IsNegativeInfinity(Rational r)
		{
			return r._denominator == 0 && r._numerator < 0;
		}

		// Token: 0x0600014D RID: 333 RVA: 0x00004883 File Offset: 0x00003883
		public static bool IsIndeterminate(Rational r)
		{
			return r._denominator == 0 && r._numerator == 0;
		}

		// Token: 0x0600014E RID: 334 RVA: 0x00004898 File Offset: 0x00003898
		public static bool IsZero(Rational r)
		{
			return r._numerator == 0 && r._denominator != 0;
		}

		// Token: 0x0600014F RID: 335 RVA: 0x000048AD File Offset: 0x000038AD
		public Rational(int numerator)
		{
			this = new Rational(numerator, 1);
		}

		// Token: 0x06000150 RID: 336 RVA: 0x000048B7 File Offset: 0x000038B7
		public Rational(int numerator, int denominator)
		{
			this._numerator = numerator;
			this._denominator = denominator;
		}

		// Token: 0x06000151 RID: 337 RVA: 0x000048C7 File Offset: 0x000038C7
		public Rational(double value)
		{
			this = Rational.FromDouble(value, 1E-06);
		}

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x06000152 RID: 338 RVA: 0x000048DE File Offset: 0x000038DE
		public int Numerator
		{
			get
			{
				return this._numerator;
			}
		}

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x06000153 RID: 339 RVA: 0x000048E6 File Offset: 0x000038E6
		public int Denominator
		{
			get
			{
				return this._denominator;
			}
		}

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x06000154 RID: 340 RVA: 0x000048EE File Offset: 0x000038EE
		public double Value
		{
			get
			{
				return (double)this.Numerator / (double)this.Denominator;
			}
		}

		// Token: 0x06000155 RID: 341 RVA: 0x000048FF File Offset: 0x000038FF
		public Rational Inverse()
		{
			if (this.Numerator >= 0)
			{
				return new Rational(this.Denominator, this.Numerator);
			}
			return new Rational(-this.Denominator, -this.Numerator);
		}

		// Token: 0x06000156 RID: 342 RVA: 0x0000492F File Offset: 0x0000392F
		public Rational Negate()
		{
			return new Rational(-this.Numerator, this.Denominator);
		}

		// Token: 0x06000157 RID: 343 RVA: 0x00004944 File Offset: 0x00003944
		public static Rational Simplify(int numerator, int denominator)
		{
			if (denominator == 0)
			{
				return new Rational(Math.Sign(numerator), 0);
			}
			int num = Rational.Gcd(numerator, denominator);
			if (denominator < 0)
			{
				num *= -1;
			}
			return new Rational(numerator / num, denominator / num);
		}

		// Token: 0x06000158 RID: 344 RVA: 0x0000497C File Offset: 0x0000397C
		public static Rational Simplify(long numerator, long denominator)
		{
			if (denominator == 0L)
			{
				return new Rational(Math.Sign(numerator), 0);
			}
			long num = Rational.Gcd(numerator, denominator);
			if (denominator < 0L)
			{
				num *= -1L;
			}
			return new Rational((int)(numerator / num), (int)(denominator / num));
		}

		// Token: 0x06000159 RID: 345 RVA: 0x000049B8 File Offset: 0x000039B8
		public Rational Simplify()
		{
			return Rational.Simplify(this._numerator, this._denominator);
		}

		// Token: 0x0600015A RID: 346 RVA: 0x000049CB File Offset: 0x000039CB
		public double ToDouble()
		{
			return this.Value;
		}

		// Token: 0x0600015B RID: 347 RVA: 0x000049D4 File Offset: 0x000039D4
		public override string ToString()
		{
			return this.Numerator.ToString() + ((this.Denominator != 1) ? ("/" + this.Denominator.ToString()) : string.Empty);
		}

		// Token: 0x0600015C RID: 348 RVA: 0x00004A1C File Offset: 0x00003A1C
		public string ToString(IFormatProvider provider)
		{
			return this.Numerator.ToString(provider) + ((this.Denominator != 1) ? ("/" + this.Denominator.ToString(provider)) : string.Empty);
		}

		// Token: 0x0600015D RID: 349 RVA: 0x00004A66 File Offset: 0x00003A66
		public string ToMixedString()
		{
			return this.ToMixedString(" ");
		}

		// Token: 0x0600015E RID: 350 RVA: 0x00004A74 File Offset: 0x00003A74
		public string ToMixedString(string numberSeparator)
		{
			string text = string.Empty;
			Rational x = this;
			if (x < Rational.Zero)
			{
				text += "-";
				x = x.Negate();
			}
			else if (x.Numerator < 0)
			{
				x = new Rational(-x.Numerator, -x.Denominator);
			}
			bool flag = false;
			if (x.Numerator >= x.Denominator)
			{
				text += ((int)x).ToString();
				flag = true;
			}
			Rational rational = x % Rational.One;
			bool flag2 = rational.Numerator != 0;
			if (flag2)
			{
				if (flag)
				{
					text += numberSeparator;
				}
				text += rational.ToString();
			}
			else if (!flag)
			{
				text = "0";
			}
			return text;
		}

		// Token: 0x0600015F RID: 351 RVA: 0x00004B43 File Offset: 0x00003B43
		public override bool Equals(object obj)
		{
			return obj is Rational && this == (Rational)obj;
		}

		// Token: 0x06000160 RID: 352 RVA: 0x00004B60 File Offset: 0x00003B60
		public bool StrictlyEquals(Rational r)
		{
			return this.Numerator == r.Numerator && this.Denominator == r.Denominator;
		}

		// Token: 0x06000161 RID: 353 RVA: 0x00004B84 File Offset: 0x00003B84
		public override int GetHashCode()
		{
			Rational rational = this.Simplify();
			return Rational.FnvCombine(new int[]
			{
				rational.Numerator.GetHashCode(),
				rational.Denominator.GetHashCode()
			});
		}

		// Token: 0x06000162 RID: 354 RVA: 0x00004BC8 File Offset: 0x00003BC8
		private static int FnvCombine(params int[] hashes)
		{
			uint num = 2166136261U;
			foreach (int num2 in hashes)
			{
				num = (num * 16777619U ^ (uint)num2);
			}
			return (int)num;
		}

		// Token: 0x06000163 RID: 355 RVA: 0x00004BFA File Offset: 0x00003BFA
		public static bool operator ==(Rational x, Rational y)
		{
			return x.CompareTo(y) == 0;
		}

		// Token: 0x06000164 RID: 356 RVA: 0x00004C07 File Offset: 0x00003C07
		public static bool operator !=(Rational x, Rational y)
		{
			return !(x == y);
		}

		// Token: 0x06000165 RID: 357 RVA: 0x00004C13 File Offset: 0x00003C13
		public static bool operator >(Rational x, Rational y)
		{
			return x.CompareTo(y) > 0;
		}

		// Token: 0x06000166 RID: 358 RVA: 0x00004C20 File Offset: 0x00003C20
		public static bool operator >=(Rational x, Rational y)
		{
			return !(x < y);
		}

		// Token: 0x06000167 RID: 359 RVA: 0x00004C2C File Offset: 0x00003C2C
		public static bool operator <(Rational x, Rational y)
		{
			return x.CompareTo(y) < 0;
		}

		// Token: 0x06000168 RID: 360 RVA: 0x00004C39 File Offset: 0x00003C39
		public static bool operator <=(Rational x, Rational y)
		{
			return !(x > y);
		}

		// Token: 0x06000169 RID: 361 RVA: 0x00004C45 File Offset: 0x00003C45
		public static Rational operator +(Rational x)
		{
			return x;
		}

		// Token: 0x0600016A RID: 362 RVA: 0x00004C48 File Offset: 0x00003C48
		public static Rational operator -(Rational x)
		{
			if (x.Denominator < 0)
			{
				return new Rational(x.Numerator, -x.Denominator);
			}
			return new Rational(-x.Numerator, x.Denominator);
		}

		// Token: 0x0600016B RID: 363 RVA: 0x00004C80 File Offset: 0x00003C80
		public static Rational operator +(Rational x, Rational y)
		{
			if (x.Denominator == 0)
			{
				if (y.Denominator == 0 && Math.Sign(x.Numerator) != Math.Sign(y.Numerator))
				{
					return Rational.Indeterminate;
				}
				return new Rational(Math.Sign(x.Numerator), 0);
			}
			else
			{
				if (y.Denominator != 0)
				{
					int num = Rational.Lcm(x.Denominator, y.Denominator);
					int num2 = num / x.Denominator;
					int num3 = num / y.Denominator;
					int numerator = x.Numerator * num2 + y.Numerator * num3;
					return Rational.Simplify(numerator, num);
				}
				if (y.Numerator == 0)
				{
					return Rational.Indeterminate;
				}
				return new Rational(Math.Sign(y.Numerator), 0);
			}
		}

		// Token: 0x0600016C RID: 364 RVA: 0x00004D40 File Offset: 0x00003D40
		public static Rational operator -(Rational x, Rational y)
		{
			if (x.Denominator == 0)
			{
				if (y.Denominator == 0 && Math.Sign(x.Numerator) != -Math.Sign(y.Numerator))
				{
					return Rational.Indeterminate;
				}
				return new Rational(Math.Sign(x.Numerator), 0);
			}
			else
			{
				if (y.Denominator != 0)
				{
					int num = Rational.Lcm(x.Denominator, y.Denominator);
					int num2 = num / x.Denominator;
					int num3 = num / y.Denominator;
					int numerator = x.Numerator * num2 - y.Numerator * num3;
					return Rational.Simplify(numerator, num);
				}
				if (y.Numerator == 0)
				{
					return Rational.Indeterminate;
				}
				return new Rational(-Math.Sign(y.Numerator), 0);
			}
		}

		// Token: 0x0600016D RID: 365 RVA: 0x00004E02 File Offset: 0x00003E02
		public static Rational operator *(Rational x, Rational y)
		{
			return Rational.Simplify(x.Numerator * y.Numerator, x.Denominator * y.Denominator);
		}

		// Token: 0x0600016E RID: 366 RVA: 0x00004E27 File Offset: 0x00003E27
		public static Rational operator /(Rational x, Rational y)
		{
			return Rational.Simplify(x.Numerator * y.Denominator, x.Denominator * y.Numerator);
		}

		// Token: 0x0600016F RID: 367 RVA: 0x00004E4C File Offset: 0x00003E4C
		public static Rational operator %(Rational x, Rational y)
		{
			if (y.Denominator == 0)
			{
				if (x.Denominator != 0 && y.Numerator != 0)
				{
					return x.Simplify();
				}
				return Rational.Indeterminate;
			}
			else
			{
				if (x.Denominator == 0)
				{
					return x.Simplify();
				}
				if (x.Numerator == 0 || y.Numerator == 0)
				{
					return Rational.Zero;
				}
				long num = Math.BigMul(x.Numerator, y.Denominator);
				long num2 = Math.BigMul(y.Numerator, x.Denominator);
				int denominator = x.Denominator * y.Denominator;
				return Rational.Simplify((int)(num % num2), denominator);
			}
		}

		// Token: 0x06000170 RID: 368 RVA: 0x00004EED File Offset: 0x00003EED
		public static Rational operator ++(Rational x)
		{
			return x + Rational.One;
		}

		// Token: 0x06000171 RID: 369 RVA: 0x00004EFA File Offset: 0x00003EFA
		public static Rational operator --(Rational x)
		{
			return x - Rational.One;
		}

		// Token: 0x06000172 RID: 370 RVA: 0x00004F07 File Offset: 0x00003F07
		public static implicit operator Rational(int x)
		{
			return new Rational(x);
		}

		// Token: 0x06000173 RID: 371 RVA: 0x00004F0F File Offset: 0x00003F0F
		public static explicit operator int(Rational x)
		{
			return x.Numerator / x.Denominator;
		}

		// Token: 0x06000174 RID: 372 RVA: 0x00004F20 File Offset: 0x00003F20
		public static implicit operator Rational(uint x)
		{
			return new Rational(x);
		}

		// Token: 0x06000175 RID: 373 RVA: 0x00004F0F File Offset: 0x00003F0F
		public static explicit operator uint(Rational x)
		{
			return (uint)(x.Numerator / x.Denominator);
		}

		// Token: 0x06000176 RID: 374 RVA: 0x00004F07 File Offset: 0x00003F07
		public static implicit operator Rational(short x)
		{
			return new Rational((int)x);
		}

		// Token: 0x06000177 RID: 375 RVA: 0x00004F2A File Offset: 0x00003F2A
		public static explicit operator short(Rational x)
		{
			return (short)(x.Numerator / x.Denominator);
		}

		// Token: 0x06000178 RID: 376 RVA: 0x00004F07 File Offset: 0x00003F07
		public static implicit operator Rational(ushort x)
		{
			return new Rational((int)x);
		}

		// Token: 0x06000179 RID: 377 RVA: 0x00004F3C File Offset: 0x00003F3C
		public static explicit operator ushort(Rational x)
		{
			return (ushort)(x.Numerator / x.Denominator);
		}

		// Token: 0x0600017A RID: 378 RVA: 0x00004F4E File Offset: 0x00003F4E
		public static implicit operator Rational(long x)
		{
			return new Rational((double)x);
		}

		// Token: 0x0600017B RID: 379 RVA: 0x00004F57 File Offset: 0x00003F57
		public static explicit operator long(Rational x)
		{
			return (long)(x.Numerator / x.Denominator);
		}

		// Token: 0x0600017C RID: 380 RVA: 0x00004F20 File Offset: 0x00003F20
		public static implicit operator Rational(ulong x)
		{
			return new Rational(x);
		}

		// Token: 0x0600017D RID: 381 RVA: 0x00004F57 File Offset: 0x00003F57
		public static explicit operator ulong(Rational x)
		{
			return (ulong)((long)(x.Numerator / x.Denominator));
		}

		// Token: 0x0600017E RID: 382 RVA: 0x00004F07 File Offset: 0x00003F07
		public static implicit operator Rational(sbyte x)
		{
			return new Rational((int)x);
		}

		// Token: 0x0600017F RID: 383 RVA: 0x00004F69 File Offset: 0x00003F69
		public static explicit operator sbyte(Rational x)
		{
			return (sbyte)(x.Numerator / x.Denominator);
		}

		// Token: 0x06000180 RID: 384 RVA: 0x00004F07 File Offset: 0x00003F07
		public static implicit operator Rational(byte x)
		{
			return new Rational((int)x);
		}

		// Token: 0x06000181 RID: 385 RVA: 0x00004F7B File Offset: 0x00003F7B
		public static explicit operator byte(Rational x)
		{
			return (byte)(x.Numerator / x.Denominator);
		}

		// Token: 0x06000182 RID: 386 RVA: 0x00004F8D File Offset: 0x00003F8D
		public static explicit operator Rational(float x)
		{
			return Rational.FromDouble((double)x, 0.001);
		}

		// Token: 0x06000183 RID: 387 RVA: 0x00004F9F File Offset: 0x00003F9F
		public static explicit operator float(Rational x)
		{
			return (float)x.Value;
		}

		// Token: 0x06000184 RID: 388 RVA: 0x00004FA9 File Offset: 0x00003FA9
		public static explicit operator Rational(double x)
		{
			return new Rational(x);
		}

		// Token: 0x06000185 RID: 389 RVA: 0x00004FB1 File Offset: 0x00003FB1
		public static explicit operator double(Rational x)
		{
			return x.Value;
		}

		// Token: 0x06000186 RID: 390 RVA: 0x00004FBA File Offset: 0x00003FBA
		public static explicit operator Rational(decimal x)
		{
			return Rational.FromDecimal(x, 0.000000000000001m);
		}

		// Token: 0x06000187 RID: 391 RVA: 0x00004FCD File Offset: 0x00003FCD
		public static explicit operator decimal(Rational x)
		{
			return x.Numerator / x.Denominator;
		}

		// Token: 0x06000188 RID: 392 RVA: 0x00004FEC File Offset: 0x00003FEC
		public int CompareTo(object obj)
		{
			if (obj is Rational)
			{
				Rational other = (Rational)obj;
				return this.CompareTo(other);
			}
			double value = this.Value;
			double value2 = Convert.ToDouble(obj);
			return value.CompareTo(value2);
		}

		// Token: 0x06000189 RID: 393 RVA: 0x00005028 File Offset: 0x00004028
		public int CompareTo(Rational other)
		{
			if (this.Denominator == 0)
			{
				if (other.Denominator == 0)
				{
					return Math.Sign(this.Numerator).CompareTo(Math.Sign(other.Numerator));
				}
				if (this.Numerator != 0)
				{
					return Math.Sign(this.Numerator);
				}
				return -1;
			}
			else
			{
				if (other.Denominator != 0)
				{
					long num = Math.BigMul(this.Numerator, other.Denominator);
					long value = Math.BigMul(this.Denominator, other.Numerator);
					return num.CompareTo(value);
				}
				if (other.Numerator != 0)
				{
					return -Math.Sign(other.Numerator);
				}
				return 1;
			}
		}

		// Token: 0x0600018A RID: 394 RVA: 0x000050CC File Offset: 0x000040CC
		public string ToString(string format, IFormatProvider formatProvider)
		{
			return this.Numerator.ToString(format, formatProvider) + ((this.Denominator != 1) ? ("/" + this.Denominator.ToString(format, formatProvider)) : string.Empty);
		}

		// Token: 0x0600018B RID: 395 RVA: 0x00005118 File Offset: 0x00004118
		public bool Equals(Rational other)
		{
			return this == other;
		}

		// Token: 0x0600018C RID: 396 RVA: 0x00005128 File Offset: 0x00004128
		private static bool IsInteger(decimal x, [Optional] decimal tolerance = 0.000000000000001m)
		{
			decimal d = Math.Abs(x % 1.0m);
			return d < tolerance || d > 1m - tolerance;
		}

		// Token: 0x0600018D RID: 397 RVA: 0x00005168 File Offset: 0x00004168
		private static bool IsInteger(float x, float tolerance = 1E-06f)
		{
			double num = Math.Abs((double)x % 1.0);
			return num < (double)tolerance || num > (double)(1f - tolerance);
		}

		// Token: 0x0600018E RID: 398 RVA: 0x0000519C File Offset: 0x0000419C
		private static bool IsInteger(double x, double tolerance = 1E-06)
		{
			double num = Math.Abs(x % 1.0);
			return num < tolerance || num > 1.0 - tolerance;
		}

		// Token: 0x0600018F RID: 399 RVA: 0x000051D0 File Offset: 0x000041D0
		private static int Gcd(int x, int y)
		{
			x = Math.Abs(x);
			int num;
			for (y = Math.Abs(y); y != 0; y = num)
			{
				num = x % y;
				x = y;
			}
			return x;
		}

		// Token: 0x06000190 RID: 400 RVA: 0x00005200 File Offset: 0x00004200
		private static long Gcd(long x, long y)
		{
			x = Math.Abs(x);
			long num;
			for (y = Math.Abs(y); y != 0L; y = num)
			{
				num = x % y;
				x = y;
			}
			return x;
		}

		// Token: 0x06000191 RID: 401 RVA: 0x00005230 File Offset: 0x00004230
		private static int Lcm(int x, int y)
		{
			int num = Rational.Gcd(x, y);
			return x / num * y;
		}

		// Token: 0x06000192 RID: 402 RVA: 0x0000524C File Offset: 0x0000424C
		private static long Lcm(long x, long y)
		{
			long num = Rational.Gcd(x, y);
			return x / num * y;
		}

		// Token: 0x0400001E RID: 30
		private const double DEFAULT_TOLERANCE = 1E-06;

		// Token: 0x0400001F RID: 31
		private const decimal DEFAULT_DECIMAL_TOLERANCE = 0.000000000000001m;

		// Token: 0x04000020 RID: 32
		private const float DEFAULT_FLOAT_TOLERANCE = 1E-06f;

		// Token: 0x04000021 RID: 33
		private readonly int _numerator;

		// Token: 0x04000022 RID: 34
		private readonly int _denominator;

		// Token: 0x04000023 RID: 35
		public static readonly Rational Zero = new Rational(0, 1);

		// Token: 0x04000024 RID: 36
		public static readonly Rational One = new Rational(1, 1);

		// Token: 0x04000025 RID: 37
		public static readonly Rational MinValue = new Rational(int.MinValue, 1);

		// Token: 0x04000026 RID: 38
		public static readonly Rational MaxValue = new Rational(int.MaxValue, 1);

		// Token: 0x04000027 RID: 39
		public static readonly Rational Indeterminate = new Rational(0, 0);

		// Token: 0x04000028 RID: 40
		public static readonly Rational PositiveInfinity = new Rational(1, 0);

		// Token: 0x04000029 RID: 41
		public static readonly Rational NegativeInfinity = new Rational(-1, 0);

		// Token: 0x0400002A RID: 42
		public static readonly Rational Epsilon = new Rational(1, int.MaxValue);
	}
}
