using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Accord.Math
{
	// Token: 0x02000030 RID: 48
	[Serializable]
	public sealed class Sparse<T> : IEnumerable<!0>, IEnumerable, ICloneable, IList<T>, ICollection<!0>, IList, ICollection, IFormattable where T : IEquatable<T>
	{
		// Token: 0x17000021 RID: 33
		// (get) Token: 0x060001AA RID: 426 RVA: 0x000058B2 File Offset: 0x000048B2
		// (set) Token: 0x060001AB RID: 427 RVA: 0x000058BA File Offset: 0x000048BA
		public int[] Indices
		{
			get
			{
				return this.indices;
			}
			set
			{
				this.indices = value;
			}
		}

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x060001AC RID: 428 RVA: 0x000058C3 File Offset: 0x000048C3
		// (set) Token: 0x060001AD RID: 429 RVA: 0x000058CB File Offset: 0x000048CB
		public T[] Values
		{
			get
			{
				return this.values;
			}
			set
			{
				this.values = value;
			}
		}

		// Token: 0x060001AE RID: 430 RVA: 0x000058D4 File Offset: 0x000048D4
		public Sparse() : this(0)
		{
		}

		// Token: 0x060001AF RID: 431 RVA: 0x000058DD File Offset: 0x000048DD
		public Sparse(int length)
		{
			this.indices = new int[length];
			this.values = new T[length];
		}

		// Token: 0x060001B0 RID: 432 RVA: 0x000058FD File Offset: 0x000048FD
		public Sparse(int[] indices, T[] values)
		{
			this.indices = indices;
			this.values = values;
		}

		// Token: 0x060001B1 RID: 433 RVA: 0x00005913 File Offset: 0x00004913
		public T[] ToDense()
		{
			return this.ToDense(this.Indices.Max() + 1);
		}

		// Token: 0x060001B2 RID: 434 RVA: 0x00005928 File Offset: 0x00004928
		public T[] ToDense(int length)
		{
			T[] array = new T[length];
			for (int i = 0; i < this.Indices.Length; i++)
			{
				array[this.Indices[i]] = this.Values[i];
			}
			return array;
		}

		// Token: 0x060001B3 RID: 435 RVA: 0x0000596C File Offset: 0x0000496C
		public T[] ToSparse()
		{
			T[] array = new T[this.Indices.Length * 2];
			for (int i = 0; i < this.Indices.Length; i++)
			{
				array[2 * i] = (T)((object)Convert.ChangeType(this.Indices[i], typeof(T)));
				array[2 * i + 1] = this.Values[i];
			}
			return array;
		}

		// Token: 0x17000023 RID: 35
		public T this[int i]
		{
			get
			{
				int num = Array.IndexOf<int>(this.Indices, i);
				if (num >= 0)
				{
					return this.Values[num];
				}
				return default(T);
			}
			set
			{
				int num = Array.IndexOf<int>(this.Indices, i);
				if (num >= 0)
				{
					this.Values[num] = value;
					return;
				}
				T[] array = new T[this.Values.Length + 1];
				int[] array2 = new int[this.indices.Length + 1];
				int j = 0;
				while (j < this.indices.Length && this.indices[j] < i)
				{
					array2[j] = this.indices[j];
					array[j] = this.values[j];
					j++;
				}
				array2[j] = i;
				array[j] = value;
				for (j++; j < array2.Length; j++)
				{
					array2[j] = this.indices[j - 1];
					array[j] = this.values[j - 1];
				}
				this.indices = array2;
				this.values = array;
			}
		}

		// Token: 0x060001B6 RID: 438 RVA: 0x00005AE8 File Offset: 0x00004AE8
		public object Clone()
		{
			return new Sparse<T>((int[])this.indices.Clone(), (T[])this.values.Clone());
		}

		// Token: 0x060001B7 RID: 439 RVA: 0x00005B0F File Offset: 0x00004B0F
		public static implicit operator Array(Sparse<T> obj)
		{
			return obj.Values;
		}

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x060001B8 RID: 440 RVA: 0x00005B18 File Offset: 0x00004B18
		public int Length
		{
			get
			{
				T other = default(T);
				for (int i = this.Indices.Length - 1; i >= 0; i--)
				{
					if (!this.Values[i].Equals(other))
					{
						return this.Indices[i] + 1;
					}
				}
				return 0;
			}
		}

		// Token: 0x060001B9 RID: 441 RVA: 0x00005B6A File Offset: 0x00004B6A
		int IList<!0>.IndexOf(T item)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060001BA RID: 442 RVA: 0x00005B6A File Offset: 0x00004B6A
		void IList<!0>.Insert(int index, T item)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060001BB RID: 443 RVA: 0x00005B6A File Offset: 0x00004B6A
		void IList<!0>.RemoveAt(int index)
		{
			throw new NotImplementedException();
		}

		// Token: 0x17000025 RID: 37
		T IList<!0>.this[int index]
		{
			get
			{
				return this[index];
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x060001BE RID: 446 RVA: 0x00005B6A File Offset: 0x00004B6A
		void ICollection<!0>.Add(T item)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060001BF RID: 447 RVA: 0x00005B7A File Offset: 0x00004B7A
		void ICollection<!0>.Clear()
		{
			Array.Clear(this.values, 0, this.values.Length);
		}

		// Token: 0x060001C0 RID: 448 RVA: 0x00005B90 File Offset: 0x00004B90
		bool ICollection<!0>.Contains(T item)
		{
			return this.values.Contains(item);
		}

		// Token: 0x060001C1 RID: 449 RVA: 0x00005BA0 File Offset: 0x00004BA0
		public void CopyTo(T[] array, int arrayIndex)
		{
			for (int i = 0; i < this.indices.Length; i++)
			{
				array[arrayIndex + this.indices[i]] = this.values[i];
			}
		}

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x060001C2 RID: 450 RVA: 0x00005BDC File Offset: 0x00004BDC
		int ICollection<!0>.Count
		{
			get
			{
				return 0;
			}
		}

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x060001C3 RID: 451 RVA: 0x00005BDC File Offset: 0x00004BDC
		bool ICollection<!0>.IsReadOnly
		{
			get
			{
				return false;
			}
		}

		// Token: 0x060001C4 RID: 452 RVA: 0x00005B6A File Offset: 0x00004B6A
		bool ICollection<!0>.Remove(T item)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060001C5 RID: 453 RVA: 0x00005BDF File Offset: 0x00004BDF
		IEnumerator<T> IEnumerable<!0>.GetEnumerator()
		{
			foreach (T t in this.ToDense())
			{
				yield return t;
			}
			T[] array = null;
			yield break;
		}

		// Token: 0x060001C6 RID: 454 RVA: 0x00005BEE File Offset: 0x00004BEE
		IEnumerator IEnumerable.GetEnumerator()
		{
			foreach (T t in this.ToDense())
			{
				yield return t;
			}
			T[] array = null;
			yield break;
		}

		// Token: 0x060001C7 RID: 455 RVA: 0x00005B6A File Offset: 0x00004B6A
		int IList.Add(object value)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060001C8 RID: 456 RVA: 0x00005B7A File Offset: 0x00004B7A
		void IList.Clear()
		{
			Array.Clear(this.values, 0, this.values.Length);
		}

		// Token: 0x060001C9 RID: 457 RVA: 0x00005BFD File Offset: 0x00004BFD
		bool IList.Contains(object value)
		{
			return this.Values.Contains(value);
		}

		// Token: 0x060001CA RID: 458 RVA: 0x00005B6A File Offset: 0x00004B6A
		int IList.IndexOf(object value)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060001CB RID: 459 RVA: 0x00005B6A File Offset: 0x00004B6A
		void IList.Insert(int index, object value)
		{
			throw new NotImplementedException();
		}

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x060001CC RID: 460 RVA: 0x00005C0B File Offset: 0x00004C0B
		bool IList.IsFixedSize
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x060001CD RID: 461 RVA: 0x00005BDC File Offset: 0x00004BDC
		bool IList.IsReadOnly
		{
			get
			{
				return false;
			}
		}

		// Token: 0x060001CE RID: 462 RVA: 0x00005B6A File Offset: 0x00004B6A
		void IList.Remove(object value)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060001CF RID: 463 RVA: 0x00005B6A File Offset: 0x00004B6A
		void IList.RemoveAt(int index)
		{
			throw new NotImplementedException();
		}

		// Token: 0x1700002A RID: 42
		object IList.this[int index]
		{
			get
			{
				return this[index];
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x060001D2 RID: 466 RVA: 0x00005C1C File Offset: 0x00004C1C
		void ICollection.CopyTo(Array array, int index)
		{
			for (int i = 0; i < this.indices.Length; i++)
			{
				array.SetValue(this.values[i], index + this.indices[i]);
			}
		}

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x060001D3 RID: 467 RVA: 0x00005BDC File Offset: 0x00004BDC
		int ICollection.Count
		{
			get
			{
				return 0;
			}
		}

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x060001D4 RID: 468 RVA: 0x00005B6A File Offset: 0x00004B6A
		bool ICollection.IsSynchronized
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x060001D5 RID: 469 RVA: 0x00005B6A File Offset: 0x00004B6A
		object ICollection.SyncRoot
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x060001D6 RID: 470 RVA: 0x00005C5D File Offset: 0x00004C5D
		public override string ToString()
		{
			return this.ToString("g", CultureInfo.CurrentCulture);
		}

		// Token: 0x060001D7 RID: 471 RVA: 0x00005C70 File Offset: 0x00004C70
		public string ToString(string format, IFormatProvider formatProvider)
		{
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < this.Indices.Length; i++)
			{
				stringBuilder.Append(this.Indices[i] + 1);
				stringBuilder.Append(":");
				stringBuilder.AppendFormat(formatProvider, "{0:" + format + "}", new object[]
				{
					this.Values[i]
				});
				if (i < this.Indices.Length - 1)
				{
					stringBuilder.Append(" ");
				}
			}
			return stringBuilder.ToString();
		}

		// Token: 0x060001D8 RID: 472 RVA: 0x00005D04 File Offset: 0x00004D04
		public bool IsFull()
		{
			for (int i = 0; i < this.Indices.Length; i++)
			{
				if (this.Indices[i] != i)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x0400002D RID: 45
		private int[] indices;

		// Token: 0x0400002E RID: 46
		private T[] values;
	}
}
