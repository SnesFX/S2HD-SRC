using System;
using System.Collections.Generic;

namespace Accord.Collections
{
	// Token: 0x0200006D RID: 109
	[Serializable]
	public class KeyValuePairComparer<TKey, TValue> : Comparer<KeyValuePair<TKey, TValue>>, IComparer<TKey>
	{
		// Token: 0x060002C9 RID: 713 RVA: 0x00006DCA File Offset: 0x00005DCA
		public KeyValuePairComparer(IComparer<TKey> keyComparer)
		{
			if (keyComparer == null)
			{
				throw new ArgumentNullException("keyComparer");
			}
			this.keyComparer = keyComparer;
		}

		// Token: 0x060002CA RID: 714 RVA: 0x00006DE7 File Offset: 0x00005DE7
		public KeyValuePairComparer()
		{
			this.keyComparer = Comparer<TKey>.Default;
		}

		// Token: 0x060002CB RID: 715 RVA: 0x00006DFA File Offset: 0x00005DFA
		public override int Compare(KeyValuePair<TKey, TValue> x, KeyValuePair<TKey, TValue> y)
		{
			return this.keyComparer.Compare(x.Key, y.Key);
		}

		// Token: 0x060002CC RID: 716 RVA: 0x00006E15 File Offset: 0x00005E15
		public int Compare(TKey x, TKey y)
		{
			return this.keyComparer.Compare(x, y);
		}

		// Token: 0x17000048 RID: 72
		// (get) Token: 0x060002CD RID: 717 RVA: 0x00006E24 File Offset: 0x00005E24
		public new static KeyValuePairComparer<TKey, TValue> Default
		{
			get
			{
				return new KeyValuePairComparer<TKey, TValue>();
			}
		}

		// Token: 0x04000042 RID: 66
		private readonly IComparer<TKey> keyComparer;
	}
}
