using System;
using System.Globalization;

namespace Accord.Math
{
	// Token: 0x0200002E RID: 46
	public struct Hyperrectangle : ICloneable, IEquatable<Hyperrectangle>, IFormattable
	{
		// Token: 0x1700001E RID: 30
		// (get) Token: 0x06000194 RID: 404 RVA: 0x000052F1 File Offset: 0x000042F1
		public double[] Min
		{
			get
			{
				return this.min;
			}
		}

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x06000195 RID: 405 RVA: 0x000052F9 File Offset: 0x000042F9
		public double[] Max
		{
			get
			{
				return this.max;
			}
		}

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x06000196 RID: 406 RVA: 0x00005301 File Offset: 0x00004301
		public int NumberOfDimensions
		{
			get
			{
				return this.min.Length;
			}
		}

		// Token: 0x06000197 RID: 407 RVA: 0x0000530C File Offset: 0x0000430C
		public double[] GetLength()
		{
			double[] array = new double[this.min.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = this.max[i] - this.min[i];
			}
			return array;
		}

		// Token: 0x06000198 RID: 408 RVA: 0x0000534A File Offset: 0x0000434A
		public Hyperrectangle(double x, double y, double width, double height)
		{
			this.min = new double[]
			{
				x,
				y
			};
			this.max = new double[]
			{
				x + width,
				y + height
			};
		}

		// Token: 0x06000199 RID: 409 RVA: 0x0000537C File Offset: 0x0000437C
		public Hyperrectangle(double[] min, double[] max, bool copy = true)
		{
			if (min.Length != max.Length)
			{
				throw new DimensionMismatchException("max");
			}
			if (copy)
			{
				this.min = (double[])min.Clone();
				this.max = (double[])max.Clone();
				return;
			}
			this.min = min;
			this.max = max;
		}

		// Token: 0x0600019A RID: 410 RVA: 0x000053D0 File Offset: 0x000043D0
		public static Hyperrectangle FromMinAndMax(double[] min, double[] max, bool copy = true)
		{
			return new Hyperrectangle(min, max, copy);
		}

		// Token: 0x0600019B RID: 411 RVA: 0x000053DC File Offset: 0x000043DC
		public static Hyperrectangle FromMinAndLength(double[] min, double[] size, bool copy = true)
		{
			if (copy)
			{
				min = (double[])min.Clone();
				size = (double[])size.Clone();
			}
			for (int i = 0; i < size.Length; i++)
			{
				size[i] = min[i] + size[i];
			}
			return new Hyperrectangle(min, size, false);
		}

		// Token: 0x0600019C RID: 412 RVA: 0x00005428 File Offset: 0x00004428
		public bool IntersectsWith(Hyperrectangle rect)
		{
			for (int i = 0; i < this.min.Length; i++)
			{
				double num = this.min[i];
				double num2 = this.max[i];
				double num3 = rect.min[i];
				double num4 = rect.max[i];
				if (num >= num4 || num2 < num3)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x0600019D RID: 413 RVA: 0x0000547C File Offset: 0x0000447C
		public bool Contains(params double[] point)
		{
			for (int i = 0; i < point.Length; i++)
			{
				double num = this.min[i];
				double num2 = this.max[i];
				double num3 = point[i];
				if (num3 < num || num3 >= num2)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x0600019E RID: 414 RVA: 0x000054B8 File Offset: 0x000044B8
		public bool Equals(Hyperrectangle other)
		{
			if (this.min.Length != other.min.Length)
			{
				return false;
			}
			for (int i = 0; i < this.min.Length; i++)
			{
				if (this.min[i] != other.min[i])
				{
					return false;
				}
				if (this.max[i] != other.max[i])
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x0600019F RID: 415 RVA: 0x00005515 File Offset: 0x00004515
		public object Clone()
		{
			return new Hyperrectangle((double[])this.min.Clone(), (double[])this.max.Clone(), true);
		}

		// Token: 0x060001A0 RID: 416 RVA: 0x00005542 File Offset: 0x00004542
		public override string ToString()
		{
			return this.ToString("G", null);
		}

		// Token: 0x060001A1 RID: 417 RVA: 0x00005550 File Offset: 0x00004550
		public string ToString(string format, IFormatProvider formatProvider = null)
		{
			if (formatProvider == null)
			{
				formatProvider = CultureInfo.CurrentCulture;
			}
			if (this.NumberOfDimensions == 2)
			{
				return string.Format(formatProvider, format, new object[]
				{
					"X = {0} Y = {1} Width = {2} Height = {3}",
					this.min[0],
					this.min[1],
					this.max[0] - this.min[0],
					this.max[1] - this.min[1]
				});
			}
			return string.Format(formatProvider, format, new object[]
			{
				"Min = {0} Max = {1} (Length = {2})",
				this.min,
				this.max,
				this.GetLength()
			});
		}

		// Token: 0x0400002B RID: 43
		private double[] min;

		// Token: 0x0400002C RID: 44
		private double[] max;
	}
}
