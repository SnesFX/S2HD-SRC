using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Accord.Math
{
	// Token: 0x0200002F RID: 47
	public static class Sparse
	{
		// Token: 0x060001A2 RID: 418 RVA: 0x00005608 File Offset: 0x00004608
		public static Sparse<double> Parse(string values, double? insertValueAtBeginning = null)
		{
			return Sparse.Parse(values.Split(new char[]
			{
				' '
			}), insertValueAtBeginning);
		}

		// Token: 0x060001A3 RID: 419 RVA: 0x00005624 File Offset: 0x00004624
		public static Sparse<double> Parse(string[] values, double? insertValueAtBeginning = null)
		{
			bool flag = insertValueAtBeginning != null && insertValueAtBeginning.Value != 0.0;
			int num = flag ? 1 : 0;
			Sparse<double> sparse = new Sparse<double>(values.Length + num);
			for (int i = 0; i < values.Length; i++)
			{
				string[] array = values[i].Split(new char[]
				{
					':'
				});
				int num2 = int.Parse(array[0], CultureInfo.InvariantCulture);
				if (num2 <= 0)
				{
					throw new FormatException("The given string contains 0 or negative indices (indices of sparse vectors in LibSVM format should begin at 1).");
				}
				int num3 = num2 - 1;
				double num4 = double.Parse(array[1], CultureInfo.InvariantCulture);
				sparse.Indices[i + num] = num3 + num;
				sparse.Values[i + num] = num4;
			}
			if (flag)
			{
				sparse.Values[0] = insertValueAtBeginning.Value;
			}
			return sparse;
		}

		// Token: 0x060001A4 RID: 420 RVA: 0x000056EC File Offset: 0x000046EC
		public static T[][] ToDense<T>(this Sparse<T>[] vectors) where T : IEquatable<T>
		{
			return vectors.ToDense(vectors.Columns<T>());
		}

		// Token: 0x060001A5 RID: 421 RVA: 0x000056FC File Offset: 0x000046FC
		public static T[][] ToDense<T>(this Sparse<T>[] vectors, int length) where T : IEquatable<T>
		{
			T[][] array = new T[vectors.Length][];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = vectors[i].ToDense(length);
			}
			return array;
		}

		// Token: 0x060001A6 RID: 422 RVA: 0x00005730 File Offset: 0x00004730
		public static Sparse<T> FromDense<T>(T[] dense, bool removeZeros = true) where T : IEquatable<T>
		{
			if (removeZeros)
			{
				T t = default(T);
				int num = 0;
				for (int i = 0; i < dense.Length; i++)
				{
					if (!t.Equals(dense[i]))
					{
						num++;
					}
				}
				int[] array = new int[num];
				T[] array2 = new T[num];
				int j = 0;
				int num2 = 0;
				while (j < dense.Length)
				{
					if (!t.Equals(dense[j]))
					{
						array[num2] = j;
						array2[num2] = dense[j];
						num2++;
					}
					j++;
				}
				return new Sparse<T>(array, array2);
			}
			int[] array3 = new int[dense.Length];
			for (int k = 0; k < array3.Length; k++)
			{
				array3[k] = k;
			}
			return new Sparse<T>(array3, dense);
		}

		// Token: 0x060001A7 RID: 423 RVA: 0x00005804 File Offset: 0x00004804
		public static Sparse<T>[] FromDense<T>(T[][] dense, bool removeZeros = true) where T : IEquatable<T>
		{
			Sparse<T>[] array = new Sparse<T>[dense.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = Sparse.FromDense<T>(dense[i], removeZeros);
			}
			return array;
		}

		// Token: 0x060001A8 RID: 424 RVA: 0x00005838 File Offset: 0x00004838
		public static int Columns<T>(this Sparse<T>[] inputs) where T : IEquatable<T>
		{
			int num = 0;
			for (int i = 0; i < inputs.Length; i++)
			{
				int length = inputs[i].Length;
				if (length > num)
				{
					num = length;
				}
			}
			return num;
		}

		// Token: 0x060001A9 RID: 425 RVA: 0x00005868 File Offset: 0x00004868
		public static Sparse<double> FromDictionary(IDictionary<int, int> dictionary)
		{
			int[] array = dictionary.Keys.ToArray<int>();
			Array.Sort<int>(array);
			double[] array2 = new double[array.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array2[i] = (double)dictionary[array[i]];
			}
			return new Sparse<double>(array, array2);
		}
	}
}
