using System;

namespace SonicOrca
{
	// Token: 0x02000090 RID: 144
	public struct ComplexNumber : IEquatable<ComplexNumber>
	{
		// Token: 0x1700007D RID: 125
		// (get) Token: 0x060004A9 RID: 1193 RVA: 0x0001869D File Offset: 0x0001689D
		// (set) Token: 0x060004AA RID: 1194 RVA: 0x000186A5 File Offset: 0x000168A5
		public double Real { get; set; }

		// Token: 0x1700007E RID: 126
		// (get) Token: 0x060004AB RID: 1195 RVA: 0x000186AE File Offset: 0x000168AE
		// (set) Token: 0x060004AC RID: 1196 RVA: 0x000186B6 File Offset: 0x000168B6
		public double Imaginary { get; set; }

		// Token: 0x1700007F RID: 127
		// (get) Token: 0x060004AD RID: 1197 RVA: 0x000186BF File Offset: 0x000168BF
		public double Magnitude
		{
			get
			{
				return Math.Sqrt(this.Real * this.Real + this.Imaginary * this.Imaginary);
			}
		}

		// Token: 0x060004AE RID: 1198 RVA: 0x000186E1 File Offset: 0x000168E1
		public ComplexNumber(double real, double imaginary)
		{
			this = default(ComplexNumber);
			this.Real = real;
			this.Imaginary = imaginary;
		}

		// Token: 0x060004AF RID: 1199 RVA: 0x000186F8 File Offset: 0x000168F8
		public override bool Equals(object obj)
		{
			return this.Equals((ComplexNumber)obj);
		}

		// Token: 0x060004B0 RID: 1200 RVA: 0x00018706 File Offset: 0x00016906
		public bool Equals(ComplexNumber other)
		{
			return this.Real == other.Real && this.Imaginary == other.Imaginary;
		}

		// Token: 0x060004B1 RID: 1201 RVA: 0x00018728 File Offset: 0x00016928
		public override int GetHashCode()
		{
			return (13 * 7 + this.Real.GetHashCode()) * 7 + this.Imaginary.GetHashCode();
		}

		// Token: 0x060004B2 RID: 1202 RVA: 0x00018759 File Offset: 0x00016959
		public override string ToString()
		{
			return string.Format("{0} + {1}i", this.Real, this.Imaginary);
		}
	}
}
