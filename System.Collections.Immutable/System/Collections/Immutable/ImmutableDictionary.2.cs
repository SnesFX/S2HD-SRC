using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Threading;

namespace System.Collections.Immutable
{
	// Token: 0x0200001D RID: 29
	[DebuggerDisplay("Count = {Count}")]
	[DebuggerTypeProxy(typeof(ImmutableDictionaryDebuggerProxy<, >))]
	public sealed class ImmutableDictionary<TKey, TValue> : IImmutableDictionary<TKey, TValue>, IReadOnlyDictionary<TKey, TValue>, IReadOnlyCollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable, IImmutableDictionaryInternal<TKey, TValue>, IHashKeyCollection<TKey>, IDictionary<TKey, TValue>, ICollection<KeyValuePair<TKey, TValue>>, IDictionary, ICollection
	{
		// Token: 0x06000132 RID: 306 RVA: 0x00004629 File Offset: 0x00002829
		private ImmutableDictionary(SortedInt32KeyNode<ImmutableDictionary<TKey, TValue>.HashBucket> root, ImmutableDictionary<TKey, TValue>.Comparers comparers, int count) : this(Requires.NotNullPassthrough<ImmutableDictionary<TKey, TValue>.Comparers>(comparers, "comparers"))
		{
			Requires.NotNull<SortedInt32KeyNode<ImmutableDictionary<TKey, TValue>.HashBucket>>(root, "root");
			root.Freeze(ImmutableDictionary<TKey, TValue>.s_FreezeBucketAction);
			this._root = root;
			this._count = count;
		}

		// Token: 0x06000133 RID: 307 RVA: 0x00004660 File Offset: 0x00002860
		private ImmutableDictionary(ImmutableDictionary<TKey, TValue>.Comparers comparers = null)
		{
			this._comparers = (comparers ?? ImmutableDictionary<TKey, TValue>.Comparers.Get(EqualityComparer<TKey>.Default, EqualityComparer<TValue>.Default));
			this._root = SortedInt32KeyNode<ImmutableDictionary<TKey, TValue>.HashBucket>.EmptyNode;
		}

		// Token: 0x06000134 RID: 308 RVA: 0x0000468D File Offset: 0x0000288D
		public ImmutableDictionary<TKey, TValue> Clear()
		{
			if (!this.IsEmpty)
			{
				return ImmutableDictionary<TKey, TValue>.EmptyWithComparers(this._comparers);
			}
			return this;
		}

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x06000135 RID: 309 RVA: 0x000046A4 File Offset: 0x000028A4
		public int Count
		{
			get
			{
				return this._count;
			}
		}

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x06000136 RID: 310 RVA: 0x000046AC File Offset: 0x000028AC
		public bool IsEmpty
		{
			get
			{
				return this.Count == 0;
			}
		}

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x06000137 RID: 311 RVA: 0x000046B7 File Offset: 0x000028B7
		public IEqualityComparer<TKey> KeyComparer
		{
			get
			{
				return this._comparers.KeyComparer;
			}
		}

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x06000138 RID: 312 RVA: 0x000046C4 File Offset: 0x000028C4
		public IEqualityComparer<TValue> ValueComparer
		{
			get
			{
				return this._comparers.ValueComparer;
			}
		}

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x06000139 RID: 313 RVA: 0x000046D4 File Offset: 0x000028D4
		public IEnumerable<TKey> Keys
		{
			get
			{
				foreach (KeyValuePair<int, ImmutableDictionary<TKey, TValue>.HashBucket> keyValuePair in this._root)
				{
					foreach (KeyValuePair<TKey, TValue> keyValuePair2 in keyValuePair.Value)
					{
						yield return keyValuePair2.Key;
					}
					ImmutableDictionary<TKey, TValue>.HashBucket.Enumerator enumerator2 = default(ImmutableDictionary<TKey, TValue>.HashBucket.Enumerator);
				}
				SortedInt32KeyNode<ImmutableDictionary<TKey, TValue>.HashBucket>.Enumerator enumerator = default(SortedInt32KeyNode<ImmutableDictionary<TKey, TValue>.HashBucket>.Enumerator);
				yield break;
				yield break;
			}
		}

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x0600013A RID: 314 RVA: 0x000046F4 File Offset: 0x000028F4
		public IEnumerable<TValue> Values
		{
			get
			{
				foreach (KeyValuePair<int, ImmutableDictionary<TKey, TValue>.HashBucket> keyValuePair in this._root)
				{
					foreach (KeyValuePair<TKey, TValue> keyValuePair2 in keyValuePair.Value)
					{
						yield return keyValuePair2.Value;
					}
					ImmutableDictionary<TKey, TValue>.HashBucket.Enumerator enumerator2 = default(ImmutableDictionary<TKey, TValue>.HashBucket.Enumerator);
				}
				SortedInt32KeyNode<ImmutableDictionary<TKey, TValue>.HashBucket>.Enumerator enumerator = default(SortedInt32KeyNode<ImmutableDictionary<TKey, TValue>.HashBucket>.Enumerator);
				yield break;
				yield break;
			}
		}

		// Token: 0x0600013B RID: 315 RVA: 0x00004711 File Offset: 0x00002911
		[ExcludeFromCodeCoverage]
		IImmutableDictionary<TKey, TValue> IImmutableDictionary<!0, !1>.Clear()
		{
			return this.Clear();
		}

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x0600013C RID: 316 RVA: 0x00004719 File Offset: 0x00002919
		ICollection<TKey> IDictionary<!0, !1>.Keys
		{
			get
			{
				return new KeysCollectionAccessor<TKey, TValue>(this);
			}
		}

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x0600013D RID: 317 RVA: 0x00004721 File Offset: 0x00002921
		ICollection<TValue> IDictionary<!0, !1>.Values
		{
			get
			{
				return new ValuesCollectionAccessor<TKey, TValue>(this);
			}
		}

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x0600013E RID: 318 RVA: 0x00004729 File Offset: 0x00002929
		private ImmutableDictionary<TKey, TValue>.MutationInput Origin
		{
			get
			{
				return new ImmutableDictionary<TKey, TValue>.MutationInput(this);
			}
		}

		// Token: 0x1700003C RID: 60
		public TValue this[TKey key]
		{
			get
			{
				Requires.NotNullAllowStructs<TKey>(key, "key");
				TValue result;
				if (this.TryGetValue(key, out result))
				{
					return result;
				}
				throw new KeyNotFoundException();
			}
		}

		// Token: 0x1700003D RID: 61
		TValue IDictionary<!0, !1>.this[TKey key]
		{
			get
			{
				return this[key];
			}
			set
			{
				throw new NotSupportedException();
			}
		}

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x06000142 RID: 322 RVA: 0x00003182 File Offset: 0x00001382
		bool ICollection<KeyValuePair<!0, !1>>.IsReadOnly
		{
			get
			{
				return true;
			}
		}

		// Token: 0x06000143 RID: 323 RVA: 0x00004767 File Offset: 0x00002967
		public ImmutableDictionary<TKey, TValue>.Builder ToBuilder()
		{
			return new ImmutableDictionary<TKey, TValue>.Builder(this);
		}

		// Token: 0x06000144 RID: 324 RVA: 0x00004770 File Offset: 0x00002970
		public ImmutableDictionary<TKey, TValue> Add(TKey key, TValue value)
		{
			Requires.NotNullAllowStructs<TKey>(key, "key");
			return ImmutableDictionary<TKey, TValue>.Add(key, value, ImmutableDictionary<TKey, TValue>.KeyCollisionBehavior.ThrowIfValueDifferent, this.Origin).Finalize(this);
		}

		// Token: 0x06000145 RID: 325 RVA: 0x0000479F File Offset: 0x0000299F
		public ImmutableDictionary<TKey, TValue> AddRange(IEnumerable<KeyValuePair<TKey, TValue>> pairs)
		{
			Requires.NotNull<IEnumerable<KeyValuePair<TKey, TValue>>>(pairs, "pairs");
			return this.AddRange(pairs, false);
		}

		// Token: 0x06000146 RID: 326 RVA: 0x000047B4 File Offset: 0x000029B4
		public ImmutableDictionary<TKey, TValue> SetItem(TKey key, TValue value)
		{
			Requires.NotNullAllowStructs<TKey>(key, "key");
			return ImmutableDictionary<TKey, TValue>.Add(key, value, ImmutableDictionary<TKey, TValue>.KeyCollisionBehavior.SetValue, this.Origin).Finalize(this);
		}

		// Token: 0x06000147 RID: 327 RVA: 0x000047E4 File Offset: 0x000029E4
		public ImmutableDictionary<TKey, TValue> SetItems(IEnumerable<KeyValuePair<TKey, TValue>> items)
		{
			Requires.NotNull<IEnumerable<KeyValuePair<TKey, TValue>>>(items, "items");
			return ImmutableDictionary<TKey, TValue>.AddRange(items, this.Origin, ImmutableDictionary<TKey, TValue>.KeyCollisionBehavior.SetValue).Finalize(this);
		}

		// Token: 0x06000148 RID: 328 RVA: 0x00004814 File Offset: 0x00002A14
		public ImmutableDictionary<TKey, TValue> Remove(TKey key)
		{
			Requires.NotNullAllowStructs<TKey>(key, "key");
			return ImmutableDictionary<TKey, TValue>.Remove(key, this.Origin).Finalize(this);
		}

		// Token: 0x06000149 RID: 329 RVA: 0x00004844 File Offset: 0x00002A44
		public ImmutableDictionary<TKey, TValue> RemoveRange(IEnumerable<TKey> keys)
		{
			Requires.NotNull<IEnumerable<TKey>>(keys, "keys");
			int num = this._count;
			SortedInt32KeyNode<ImmutableDictionary<TKey, TValue>.HashBucket> sortedInt32KeyNode = this._root;
			foreach (TKey tkey in keys)
			{
				int hashCode = this.KeyComparer.GetHashCode(tkey);
				ImmutableDictionary<TKey, TValue>.HashBucket hashBucket;
				if (sortedInt32KeyNode.TryGetValue(hashCode, out hashBucket))
				{
					ImmutableDictionary<TKey, TValue>.OperationResult operationResult;
					ImmutableDictionary<TKey, TValue>.HashBucket newBucket = hashBucket.Remove(tkey, this._comparers.KeyOnlyComparer, out operationResult);
					sortedInt32KeyNode = ImmutableDictionary<TKey, TValue>.UpdateRoot(sortedInt32KeyNode, hashCode, newBucket, this._comparers.HashBucketEqualityComparer);
					if (operationResult == ImmutableDictionary<TKey, TValue>.OperationResult.SizeChanged)
					{
						num--;
					}
				}
			}
			return this.Wrap(sortedInt32KeyNode, num);
		}

		// Token: 0x0600014A RID: 330 RVA: 0x000048F8 File Offset: 0x00002AF8
		public bool ContainsKey(TKey key)
		{
			Requires.NotNullAllowStructs<TKey>(key, "key");
			return ImmutableDictionary<TKey, TValue>.ContainsKey(key, this.Origin);
		}

		// Token: 0x0600014B RID: 331 RVA: 0x00004911 File Offset: 0x00002B11
		public bool Contains(KeyValuePair<TKey, TValue> pair)
		{
			return ImmutableDictionary<TKey, TValue>.Contains(pair, this.Origin);
		}

		// Token: 0x0600014C RID: 332 RVA: 0x0000491F File Offset: 0x00002B1F
		public bool TryGetValue(TKey key, out TValue value)
		{
			Requires.NotNullAllowStructs<TKey>(key, "key");
			return ImmutableDictionary<TKey, TValue>.TryGetValue(key, this.Origin, out value);
		}

		// Token: 0x0600014D RID: 333 RVA: 0x00004939 File Offset: 0x00002B39
		public bool TryGetKey(TKey equalKey, out TKey actualKey)
		{
			Requires.NotNullAllowStructs<TKey>(equalKey, "equalKey");
			return ImmutableDictionary<TKey, TValue>.TryGetKey(equalKey, this.Origin, out actualKey);
		}

		// Token: 0x0600014E RID: 334 RVA: 0x00004954 File Offset: 0x00002B54
		public ImmutableDictionary<TKey, TValue> WithComparers(IEqualityComparer<TKey> keyComparer, IEqualityComparer<TValue> valueComparer)
		{
			if (keyComparer == null)
			{
				keyComparer = EqualityComparer<TKey>.Default;
			}
			if (valueComparer == null)
			{
				valueComparer = EqualityComparer<TValue>.Default;
			}
			if (this.KeyComparer != keyComparer)
			{
				ImmutableDictionary<TKey, TValue>.Comparers comparers = ImmutableDictionary<TKey, TValue>.Comparers.Get(keyComparer, valueComparer);
				ImmutableDictionary<TKey, TValue> immutableDictionary = new ImmutableDictionary<TKey, TValue>(comparers);
				return immutableDictionary.AddRange(this, true);
			}
			if (this.ValueComparer == valueComparer)
			{
				return this;
			}
			ImmutableDictionary<TKey, TValue>.Comparers comparers2 = this._comparers.WithValueComparer(valueComparer);
			return new ImmutableDictionary<TKey, TValue>(this._root, comparers2, this._count);
		}

		// Token: 0x0600014F RID: 335 RVA: 0x000049C2 File Offset: 0x00002BC2
		public ImmutableDictionary<TKey, TValue> WithComparers(IEqualityComparer<TKey> keyComparer)
		{
			return this.WithComparers(keyComparer, this._comparers.ValueComparer);
		}

		// Token: 0x06000150 RID: 336 RVA: 0x000049D8 File Offset: 0x00002BD8
		public bool ContainsValue(TValue value)
		{
			foreach (KeyValuePair<TKey, TValue> keyValuePair in this)
			{
				if (this.ValueComparer.Equals(value, keyValuePair.Value))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000151 RID: 337 RVA: 0x00004A3C File Offset: 0x00002C3C
		public ImmutableDictionary<TKey, TValue>.Enumerator GetEnumerator()
		{
			return new ImmutableDictionary<TKey, TValue>.Enumerator(this._root, null);
		}

		// Token: 0x06000152 RID: 338 RVA: 0x00004A4A File Offset: 0x00002C4A
		[ExcludeFromCodeCoverage]
		IImmutableDictionary<TKey, TValue> IImmutableDictionary<!0, !1>.Add(TKey key, TValue value)
		{
			return this.Add(key, value);
		}

		// Token: 0x06000153 RID: 339 RVA: 0x00004A54 File Offset: 0x00002C54
		[ExcludeFromCodeCoverage]
		IImmutableDictionary<TKey, TValue> IImmutableDictionary<!0, !1>.SetItem(TKey key, TValue value)
		{
			return this.SetItem(key, value);
		}

		// Token: 0x06000154 RID: 340 RVA: 0x00004A5E File Offset: 0x00002C5E
		IImmutableDictionary<TKey, TValue> IImmutableDictionary<!0, !1>.SetItems(IEnumerable<KeyValuePair<TKey, TValue>> items)
		{
			return this.SetItems(items);
		}

		// Token: 0x06000155 RID: 341 RVA: 0x00004A67 File Offset: 0x00002C67
		[ExcludeFromCodeCoverage]
		IImmutableDictionary<TKey, TValue> IImmutableDictionary<!0, !1>.AddRange(IEnumerable<KeyValuePair<TKey, TValue>> pairs)
		{
			return this.AddRange(pairs);
		}

		// Token: 0x06000156 RID: 342 RVA: 0x00004A70 File Offset: 0x00002C70
		[ExcludeFromCodeCoverage]
		IImmutableDictionary<TKey, TValue> IImmutableDictionary<!0, !1>.RemoveRange(IEnumerable<TKey> keys)
		{
			return this.RemoveRange(keys);
		}

		// Token: 0x06000157 RID: 343 RVA: 0x00004A79 File Offset: 0x00002C79
		[ExcludeFromCodeCoverage]
		IImmutableDictionary<TKey, TValue> IImmutableDictionary<!0, !1>.Remove(TKey key)
		{
			return this.Remove(key);
		}

		// Token: 0x06000158 RID: 344 RVA: 0x0000317B File Offset: 0x0000137B
		void IDictionary<!0, !1>.Add(TKey key, TValue value)
		{
			throw new NotSupportedException();
		}

		// Token: 0x06000159 RID: 345 RVA: 0x0000317B File Offset: 0x0000137B
		bool IDictionary<!0, !1>.Remove(TKey key)
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600015A RID: 346 RVA: 0x0000317B File Offset: 0x0000137B
		void ICollection<KeyValuePair<!0, !1>>.Add(KeyValuePair<TKey, TValue> item)
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600015B RID: 347 RVA: 0x0000317B File Offset: 0x0000137B
		void ICollection<KeyValuePair<!0, !1>>.Clear()
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600015C RID: 348 RVA: 0x0000317B File Offset: 0x0000137B
		bool ICollection<KeyValuePair<!0, !1>>.Remove(KeyValuePair<TKey, TValue> item)
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600015D RID: 349 RVA: 0x00004A84 File Offset: 0x00002C84
		void ICollection<KeyValuePair<!0, !1>>.CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
		{
			Requires.NotNull<KeyValuePair<TKey, TValue>[]>(array, "array");
			Requires.Range(arrayIndex >= 0, "arrayIndex", null);
			Requires.Range(array.Length >= arrayIndex + this.Count, "arrayIndex", null);
			foreach (KeyValuePair<TKey, TValue> keyValuePair in this)
			{
				array[arrayIndex++] = keyValuePair;
			}
		}

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x0600015E RID: 350 RVA: 0x00003182 File Offset: 0x00001382
		bool IDictionary.IsFixedSize
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x0600015F RID: 351 RVA: 0x00003182 File Offset: 0x00001382
		bool IDictionary.IsReadOnly
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17000041 RID: 65
		// (get) Token: 0x06000160 RID: 352 RVA: 0x00004719 File Offset: 0x00002919
		ICollection IDictionary.Keys
		{
			get
			{
				return new KeysCollectionAccessor<TKey, TValue>(this);
			}
		}

		// Token: 0x17000042 RID: 66
		// (get) Token: 0x06000161 RID: 353 RVA: 0x00004721 File Offset: 0x00002921
		ICollection IDictionary.Values
		{
			get
			{
				return new ValuesCollectionAccessor<TKey, TValue>(this);
			}
		}

		// Token: 0x17000043 RID: 67
		// (get) Token: 0x06000162 RID: 354 RVA: 0x00004B10 File Offset: 0x00002D10
		internal SortedInt32KeyNode<ImmutableDictionary<TKey, TValue>.HashBucket> Root
		{
			get
			{
				return this._root;
			}
		}

		// Token: 0x06000163 RID: 355 RVA: 0x0000317B File Offset: 0x0000137B
		void IDictionary.Add(object key, object value)
		{
			throw new NotSupportedException();
		}

		// Token: 0x06000164 RID: 356 RVA: 0x00004B18 File Offset: 0x00002D18
		bool IDictionary.Contains(object key)
		{
			return this.ContainsKey((TKey)((object)key));
		}

		// Token: 0x06000165 RID: 357 RVA: 0x00004B26 File Offset: 0x00002D26
		IDictionaryEnumerator IDictionary.GetEnumerator()
		{
			return new DictionaryEnumerator<TKey, TValue>(this.GetEnumerator());
		}

		// Token: 0x06000166 RID: 358 RVA: 0x0000317B File Offset: 0x0000137B
		void IDictionary.Remove(object key)
		{
			throw new NotSupportedException();
		}

		// Token: 0x17000044 RID: 68
		object IDictionary.this[object key]
		{
			get
			{
				return this[(TKey)((object)key)];
			}
			set
			{
				throw new NotSupportedException();
			}
		}

		// Token: 0x06000169 RID: 361 RVA: 0x0000317B File Offset: 0x0000137B
		void IDictionary.Clear()
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600016A RID: 362 RVA: 0x00004B4C File Offset: 0x00002D4C
		void ICollection.CopyTo(Array array, int arrayIndex)
		{
			Requires.NotNull<Array>(array, "array");
			Requires.Range(arrayIndex >= 0, "arrayIndex", null);
			Requires.Range(array.Length >= arrayIndex + this.Count, "arrayIndex", null);
			foreach (KeyValuePair<TKey, TValue> keyValuePair in this)
			{
				array.SetValue(new DictionaryEntry(keyValuePair.Key, keyValuePair.Value), new int[]
				{
					arrayIndex++
				});
			}
		}

		// Token: 0x17000045 RID: 69
		// (get) Token: 0x0600016B RID: 363 RVA: 0x00004C08 File Offset: 0x00002E08
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		object ICollection.SyncRoot
		{
			get
			{
				return this;
			}
		}

		// Token: 0x17000046 RID: 70
		// (get) Token: 0x0600016C RID: 364 RVA: 0x00003182 File Offset: 0x00001382
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		bool ICollection.IsSynchronized
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600016D RID: 365 RVA: 0x00004C0B File Offset: 0x00002E0B
		IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<!0, !1>>.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		// Token: 0x0600016E RID: 366 RVA: 0x00004C0B File Offset: 0x00002E0B
		[ExcludeFromCodeCoverage]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		// Token: 0x0600016F RID: 367 RVA: 0x00004C18 File Offset: 0x00002E18
		private static ImmutableDictionary<TKey, TValue> EmptyWithComparers(ImmutableDictionary<TKey, TValue>.Comparers comparers)
		{
			Requires.NotNull<ImmutableDictionary<TKey, TValue>.Comparers>(comparers, "comparers");
			if (ImmutableDictionary<TKey, TValue>.Empty._comparers != comparers)
			{
				return new ImmutableDictionary<TKey, TValue>(comparers);
			}
			return ImmutableDictionary<TKey, TValue>.Empty;
		}

		// Token: 0x06000170 RID: 368 RVA: 0x00004C40 File Offset: 0x00002E40
		private static bool TryCastToImmutableMap(IEnumerable<KeyValuePair<TKey, TValue>> sequence, out ImmutableDictionary<TKey, TValue> other)
		{
			other = (sequence as ImmutableDictionary<TKey, TValue>);
			if (other != null)
			{
				return true;
			}
			ImmutableDictionary<TKey, TValue>.Builder builder = sequence as ImmutableDictionary<TKey, TValue>.Builder;
			if (builder != null)
			{
				other = builder.ToImmutable();
				return true;
			}
			return false;
		}

		// Token: 0x06000171 RID: 369 RVA: 0x00004C70 File Offset: 0x00002E70
		private static bool ContainsKey(TKey key, ImmutableDictionary<TKey, TValue>.MutationInput origin)
		{
			int hashCode = origin.KeyComparer.GetHashCode(key);
			ImmutableDictionary<TKey, TValue>.HashBucket hashBucket;
			TValue tvalue;
			return origin.Root.TryGetValue(hashCode, out hashBucket) && hashBucket.TryGetValue(key, origin.KeyOnlyComparer, out tvalue);
		}

		// Token: 0x06000172 RID: 370 RVA: 0x00004CB0 File Offset: 0x00002EB0
		private static bool Contains(KeyValuePair<TKey, TValue> keyValuePair, ImmutableDictionary<TKey, TValue>.MutationInput origin)
		{
			int hashCode = origin.KeyComparer.GetHashCode(keyValuePair.Key);
			ImmutableDictionary<TKey, TValue>.HashBucket hashBucket;
			TValue x;
			return origin.Root.TryGetValue(hashCode, out hashBucket) && hashBucket.TryGetValue(keyValuePair.Key, origin.KeyOnlyComparer, out x) && origin.ValueComparer.Equals(x, keyValuePair.Value);
		}

		// Token: 0x06000173 RID: 371 RVA: 0x00004D14 File Offset: 0x00002F14
		private static bool TryGetValue(TKey key, ImmutableDictionary<TKey, TValue>.MutationInput origin, out TValue value)
		{
			int hashCode = origin.KeyComparer.GetHashCode(key);
			ImmutableDictionary<TKey, TValue>.HashBucket hashBucket;
			if (origin.Root.TryGetValue(hashCode, out hashBucket))
			{
				return hashBucket.TryGetValue(key, origin.KeyOnlyComparer, out value);
			}
			value = default(TValue);
			return false;
		}

		// Token: 0x06000174 RID: 372 RVA: 0x00004D5C File Offset: 0x00002F5C
		private static bool TryGetKey(TKey equalKey, ImmutableDictionary<TKey, TValue>.MutationInput origin, out TKey actualKey)
		{
			int hashCode = origin.KeyComparer.GetHashCode(equalKey);
			ImmutableDictionary<TKey, TValue>.HashBucket hashBucket;
			if (origin.Root.TryGetValue(hashCode, out hashBucket))
			{
				return hashBucket.TryGetKey(equalKey, origin.KeyOnlyComparer, out actualKey);
			}
			actualKey = equalKey;
			return false;
		}

		// Token: 0x06000175 RID: 373 RVA: 0x00004DA4 File Offset: 0x00002FA4
		private static ImmutableDictionary<TKey, TValue>.MutationResult Add(TKey key, TValue value, ImmutableDictionary<TKey, TValue>.KeyCollisionBehavior behavior, ImmutableDictionary<TKey, TValue>.MutationInput origin)
		{
			Requires.NotNullAllowStructs<TKey>(key, "key");
			int hashCode = origin.KeyComparer.GetHashCode(key);
			ImmutableDictionary<TKey, TValue>.OperationResult operationResult;
			ImmutableDictionary<TKey, TValue>.HashBucket newBucket = origin.Root.GetValueOrDefault(hashCode).Add(key, value, origin.KeyOnlyComparer, origin.ValueComparer, behavior, out operationResult);
			if (operationResult == ImmutableDictionary<TKey, TValue>.OperationResult.NoChangeRequired)
			{
				return new ImmutableDictionary<TKey, TValue>.MutationResult(origin);
			}
			SortedInt32KeyNode<ImmutableDictionary<TKey, TValue>.HashBucket> root = ImmutableDictionary<TKey, TValue>.UpdateRoot(origin.Root, hashCode, newBucket, origin.HashBucketComparer);
			return new ImmutableDictionary<TKey, TValue>.MutationResult(root, (operationResult == ImmutableDictionary<TKey, TValue>.OperationResult.SizeChanged) ? 1 : 0);
		}

		// Token: 0x06000176 RID: 374 RVA: 0x00004E24 File Offset: 0x00003024
		private static ImmutableDictionary<TKey, TValue>.MutationResult AddRange(IEnumerable<KeyValuePair<TKey, TValue>> items, ImmutableDictionary<TKey, TValue>.MutationInput origin, ImmutableDictionary<TKey, TValue>.KeyCollisionBehavior collisionBehavior = ImmutableDictionary<TKey, TValue>.KeyCollisionBehavior.ThrowIfValueDifferent)
		{
			Requires.NotNull<IEnumerable<KeyValuePair<TKey, TValue>>>(items, "items");
			int num = 0;
			SortedInt32KeyNode<ImmutableDictionary<TKey, TValue>.HashBucket> sortedInt32KeyNode = origin.Root;
			foreach (KeyValuePair<TKey, TValue> keyValuePair in items)
			{
				int hashCode = origin.KeyComparer.GetHashCode(keyValuePair.Key);
				ImmutableDictionary<TKey, TValue>.OperationResult operationResult;
				ImmutableDictionary<TKey, TValue>.HashBucket newBucket = sortedInt32KeyNode.GetValueOrDefault(hashCode).Add(keyValuePair.Key, keyValuePair.Value, origin.KeyOnlyComparer, origin.ValueComparer, collisionBehavior, out operationResult);
				sortedInt32KeyNode = ImmutableDictionary<TKey, TValue>.UpdateRoot(sortedInt32KeyNode, hashCode, newBucket, origin.HashBucketComparer);
				if (operationResult == ImmutableDictionary<TKey, TValue>.OperationResult.SizeChanged)
				{
					num++;
				}
			}
			return new ImmutableDictionary<TKey, TValue>.MutationResult(sortedInt32KeyNode, num);
		}

		// Token: 0x06000177 RID: 375 RVA: 0x00004EE4 File Offset: 0x000030E4
		private static ImmutableDictionary<TKey, TValue>.MutationResult Remove(TKey key, ImmutableDictionary<TKey, TValue>.MutationInput origin)
		{
			int hashCode = origin.KeyComparer.GetHashCode(key);
			ImmutableDictionary<TKey, TValue>.HashBucket hashBucket;
			if (origin.Root.TryGetValue(hashCode, out hashBucket))
			{
				ImmutableDictionary<TKey, TValue>.OperationResult operationResult;
				SortedInt32KeyNode<ImmutableDictionary<TKey, TValue>.HashBucket> root = ImmutableDictionary<TKey, TValue>.UpdateRoot(origin.Root, hashCode, hashBucket.Remove(key, origin.KeyOnlyComparer, out operationResult), origin.HashBucketComparer);
				return new ImmutableDictionary<TKey, TValue>.MutationResult(root, (operationResult == ImmutableDictionary<TKey, TValue>.OperationResult.SizeChanged) ? -1 : 0);
			}
			return new ImmutableDictionary<TKey, TValue>.MutationResult(origin);
		}

		// Token: 0x06000178 RID: 376 RVA: 0x00004F4C File Offset: 0x0000314C
		private static SortedInt32KeyNode<ImmutableDictionary<TKey, TValue>.HashBucket> UpdateRoot(SortedInt32KeyNode<ImmutableDictionary<TKey, TValue>.HashBucket> root, int hashCode, ImmutableDictionary<TKey, TValue>.HashBucket newBucket, IEqualityComparer<ImmutableDictionary<TKey, TValue>.HashBucket> hashBucketComparer)
		{
			bool flag;
			if (newBucket.IsEmpty)
			{
				return root.Remove(hashCode, out flag);
			}
			bool flag2;
			return root.SetItem(hashCode, newBucket, hashBucketComparer, out flag2, out flag);
		}

		// Token: 0x06000179 RID: 377 RVA: 0x00004F79 File Offset: 0x00003179
		private static ImmutableDictionary<TKey, TValue> Wrap(SortedInt32KeyNode<ImmutableDictionary<TKey, TValue>.HashBucket> root, ImmutableDictionary<TKey, TValue>.Comparers comparers, int count)
		{
			Requires.NotNull<SortedInt32KeyNode<ImmutableDictionary<TKey, TValue>.HashBucket>>(root, "root");
			Requires.NotNull<ImmutableDictionary<TKey, TValue>.Comparers>(comparers, "comparers");
			Requires.Range(count >= 0, "count", null);
			return new ImmutableDictionary<TKey, TValue>(root, comparers, count);
		}

		// Token: 0x0600017A RID: 378 RVA: 0x00004FAB File Offset: 0x000031AB
		private ImmutableDictionary<TKey, TValue> Wrap(SortedInt32KeyNode<ImmutableDictionary<TKey, TValue>.HashBucket> root, int adjustedCountIfDifferentRoot)
		{
			if (root == null)
			{
				return this.Clear();
			}
			if (this._root == root)
			{
				return this;
			}
			if (!root.IsEmpty)
			{
				return new ImmutableDictionary<TKey, TValue>(root, this._comparers, adjustedCountIfDifferentRoot);
			}
			return this.Clear();
		}

		// Token: 0x0600017B RID: 379 RVA: 0x00004FE0 File Offset: 0x000031E0
		private ImmutableDictionary<TKey, TValue> AddRange(IEnumerable<KeyValuePair<TKey, TValue>> pairs, bool avoidToHashMap)
		{
			Requires.NotNull<IEnumerable<KeyValuePair<TKey, TValue>>>(pairs, "pairs");
			ImmutableDictionary<TKey, TValue> immutableDictionary;
			if (this.IsEmpty && !avoidToHashMap && ImmutableDictionary<TKey, TValue>.TryCastToImmutableMap(pairs, out immutableDictionary))
			{
				return immutableDictionary.WithComparers(this.KeyComparer, this.ValueComparer);
			}
			return ImmutableDictionary<TKey, TValue>.AddRange(pairs, this.Origin, ImmutableDictionary<TKey, TValue>.KeyCollisionBehavior.ThrowIfValueDifferent).Finalize(this);
		}

		// Token: 0x0400000D RID: 13
		public static readonly ImmutableDictionary<TKey, TValue> Empty = new ImmutableDictionary<TKey, TValue>(null);

		// Token: 0x0400000E RID: 14
		private static readonly Action<KeyValuePair<int, ImmutableDictionary<TKey, TValue>.HashBucket>> s_FreezeBucketAction = delegate(KeyValuePair<int, ImmutableDictionary<TKey, TValue>.HashBucket> kv)
		{
			kv.Value.Freeze();
		};

		// Token: 0x0400000F RID: 15
		private readonly int _count;

		// Token: 0x04000010 RID: 16
		private readonly SortedInt32KeyNode<ImmutableDictionary<TKey, TValue>.HashBucket> _root;

		// Token: 0x04000011 RID: 17
		private readonly ImmutableDictionary<TKey, TValue>.Comparers _comparers;

		// Token: 0x02000047 RID: 71
		[DebuggerDisplay("Count = {Count}")]
		[DebuggerTypeProxy(typeof(ImmutableDictionaryBuilderDebuggerProxy<, >))]
		public sealed class Builder : IDictionary<!0, !1>, ICollection<KeyValuePair<!0, !1>>, IEnumerable<KeyValuePair<!0, !1>>, IEnumerable, IReadOnlyDictionary<TKey, TValue>, IReadOnlyCollection<KeyValuePair<TKey, TValue>>, IDictionary, ICollection
		{
			// Token: 0x060003C5 RID: 965 RVA: 0x0000A0FC File Offset: 0x000082FC
			internal Builder(ImmutableDictionary<TKey, TValue> map)
			{
				Requires.NotNull<ImmutableDictionary<TKey, TValue>>(map, "map");
				this._root = map._root;
				this._count = map._count;
				this._comparers = map._comparers;
				this._immutable = map;
			}

			// Token: 0x170000A2 RID: 162
			// (get) Token: 0x060003C6 RID: 966 RVA: 0x0000A150 File Offset: 0x00008350
			// (set) Token: 0x060003C7 RID: 967 RVA: 0x0000A160 File Offset: 0x00008360
			public IEqualityComparer<TKey> KeyComparer
			{
				get
				{
					return this._comparers.KeyComparer;
				}
				set
				{
					Requires.NotNull<IEqualityComparer<TKey>>(value, "value");
					if (value != this.KeyComparer)
					{
						ImmutableDictionary<TKey, TValue>.Comparers comparers = ImmutableDictionary<TKey, TValue>.Comparers.Get(value, this.ValueComparer);
						ImmutableDictionary<TKey, TValue>.MutationInput origin = new ImmutableDictionary<TKey, TValue>.MutationInput(SortedInt32KeyNode<ImmutableDictionary<TKey, TValue>.HashBucket>.EmptyNode, comparers, 0);
						ImmutableDictionary<TKey, TValue>.MutationResult mutationResult = ImmutableDictionary<TKey, TValue>.AddRange(this, origin, ImmutableDictionary<TKey, TValue>.KeyCollisionBehavior.ThrowIfValueDifferent);
						this._immutable = null;
						this._comparers = comparers;
						this._count = mutationResult.CountAdjustment;
						this.Root = mutationResult.Root;
					}
				}
			}

			// Token: 0x170000A3 RID: 163
			// (get) Token: 0x060003C8 RID: 968 RVA: 0x0000A1CD File Offset: 0x000083CD
			// (set) Token: 0x060003C9 RID: 969 RVA: 0x0000A1DA File Offset: 0x000083DA
			public IEqualityComparer<TValue> ValueComparer
			{
				get
				{
					return this._comparers.ValueComparer;
				}
				set
				{
					Requires.NotNull<IEqualityComparer<TValue>>(value, "value");
					if (value != this.ValueComparer)
					{
						this._comparers = this._comparers.WithValueComparer(value);
						this._immutable = null;
					}
				}
			}

			// Token: 0x170000A4 RID: 164
			// (get) Token: 0x060003CA RID: 970 RVA: 0x0000A209 File Offset: 0x00008409
			public int Count
			{
				get
				{
					return this._count;
				}
			}

			// Token: 0x170000A5 RID: 165
			// (get) Token: 0x060003CB RID: 971 RVA: 0x0000206B File Offset: 0x0000026B
			bool ICollection<KeyValuePair<!0, !1>>.IsReadOnly
			{
				get
				{
					return false;
				}
			}

			// Token: 0x170000A6 RID: 166
			// (get) Token: 0x060003CC RID: 972 RVA: 0x0000A214 File Offset: 0x00008414
			public IEnumerable<TKey> Keys
			{
				get
				{
					foreach (KeyValuePair<TKey, TValue> keyValuePair in this)
					{
						yield return keyValuePair.Key;
					}
					ImmutableDictionary<TKey, TValue>.Enumerator enumerator = default(ImmutableDictionary<TKey, TValue>.Enumerator);
					yield break;
					yield break;
				}
			}

			// Token: 0x170000A7 RID: 167
			// (get) Token: 0x060003CD RID: 973 RVA: 0x0000A231 File Offset: 0x00008431
			ICollection<TKey> IDictionary<!0, !1>.Keys
			{
				get
				{
					return this.Keys.ToArray(this.Count);
				}
			}

			// Token: 0x170000A8 RID: 168
			// (get) Token: 0x060003CE RID: 974 RVA: 0x0000A244 File Offset: 0x00008444
			public IEnumerable<TValue> Values
			{
				get
				{
					foreach (KeyValuePair<TKey, TValue> keyValuePair in this)
					{
						yield return keyValuePair.Value;
					}
					ImmutableDictionary<TKey, TValue>.Enumerator enumerator = default(ImmutableDictionary<TKey, TValue>.Enumerator);
					yield break;
					yield break;
				}
			}

			// Token: 0x170000A9 RID: 169
			// (get) Token: 0x060003CF RID: 975 RVA: 0x0000A261 File Offset: 0x00008461
			ICollection<TValue> IDictionary<!0, !1>.Values
			{
				get
				{
					return this.Values.ToArray(this.Count);
				}
			}

			// Token: 0x170000AA RID: 170
			// (get) Token: 0x060003D0 RID: 976 RVA: 0x0000206B File Offset: 0x0000026B
			bool IDictionary.IsFixedSize
			{
				get
				{
					return false;
				}
			}

			// Token: 0x170000AB RID: 171
			// (get) Token: 0x060003D1 RID: 977 RVA: 0x0000206B File Offset: 0x0000026B
			bool IDictionary.IsReadOnly
			{
				get
				{
					return false;
				}
			}

			// Token: 0x170000AC RID: 172
			// (get) Token: 0x060003D2 RID: 978 RVA: 0x0000A231 File Offset: 0x00008431
			ICollection IDictionary.Keys
			{
				get
				{
					return this.Keys.ToArray(this.Count);
				}
			}

			// Token: 0x170000AD RID: 173
			// (get) Token: 0x060003D3 RID: 979 RVA: 0x0000A261 File Offset: 0x00008461
			ICollection IDictionary.Values
			{
				get
				{
					return this.Values.ToArray(this.Count);
				}
			}

			// Token: 0x170000AE RID: 174
			// (get) Token: 0x060003D4 RID: 980 RVA: 0x0000A274 File Offset: 0x00008474
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			object ICollection.SyncRoot
			{
				get
				{
					if (this._syncRoot == null)
					{
						Interlocked.CompareExchange<object>(ref this._syncRoot, new object(), null);
					}
					return this._syncRoot;
				}
			}

			// Token: 0x170000AF RID: 175
			// (get) Token: 0x060003D5 RID: 981 RVA: 0x0000206B File Offset: 0x0000026B
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			bool ICollection.IsSynchronized
			{
				get
				{
					return false;
				}
			}

			// Token: 0x060003D6 RID: 982 RVA: 0x0000A296 File Offset: 0x00008496
			void IDictionary.Add(object key, object value)
			{
				this.Add((TKey)((object)key), (TValue)((object)value));
			}

			// Token: 0x060003D7 RID: 983 RVA: 0x0000A2AA File Offset: 0x000084AA
			bool IDictionary.Contains(object key)
			{
				return this.ContainsKey((TKey)((object)key));
			}

			// Token: 0x060003D8 RID: 984 RVA: 0x0000A2B8 File Offset: 0x000084B8
			IDictionaryEnumerator IDictionary.GetEnumerator()
			{
				return new DictionaryEnumerator<TKey, TValue>(this.GetEnumerator());
			}

			// Token: 0x060003D9 RID: 985 RVA: 0x0000A2CA File Offset: 0x000084CA
			void IDictionary.Remove(object key)
			{
				this.Remove((TKey)((object)key));
			}

			// Token: 0x170000B0 RID: 176
			object IDictionary.this[object key]
			{
				get
				{
					return this[(TKey)((object)key)];
				}
				set
				{
					this[(TKey)((object)key)] = (TValue)((object)value);
				}
			}

			// Token: 0x060003DC RID: 988 RVA: 0x0000A300 File Offset: 0x00008500
			void ICollection.CopyTo(Array array, int arrayIndex)
			{
				Requires.NotNull<Array>(array, "array");
				Requires.Range(arrayIndex >= 0, "arrayIndex", null);
				Requires.Range(array.Length >= arrayIndex + this.Count, "arrayIndex", null);
				foreach (KeyValuePair<TKey, TValue> keyValuePair in this)
				{
					array.SetValue(new DictionaryEntry(keyValuePair.Key, keyValuePair.Value), new int[]
					{
						arrayIndex++
					});
				}
			}

			// Token: 0x170000B1 RID: 177
			// (get) Token: 0x060003DD RID: 989 RVA: 0x0000A3BC File Offset: 0x000085BC
			internal int Version
			{
				get
				{
					return this._version;
				}
			}

			// Token: 0x170000B2 RID: 178
			// (get) Token: 0x060003DE RID: 990 RVA: 0x0000A3C4 File Offset: 0x000085C4
			private ImmutableDictionary<TKey, TValue>.MutationInput Origin
			{
				get
				{
					return new ImmutableDictionary<TKey, TValue>.MutationInput(this.Root, this._comparers, this._count);
				}
			}

			// Token: 0x170000B3 RID: 179
			// (get) Token: 0x060003DF RID: 991 RVA: 0x0000A3DD File Offset: 0x000085DD
			// (set) Token: 0x060003E0 RID: 992 RVA: 0x0000A3E5 File Offset: 0x000085E5
			private SortedInt32KeyNode<ImmutableDictionary<TKey, TValue>.HashBucket> Root
			{
				get
				{
					return this._root;
				}
				set
				{
					this._version++;
					if (this._root != value)
					{
						this._root = value;
						this._immutable = null;
					}
				}
			}

			// Token: 0x170000B4 RID: 180
			public TValue this[TKey key]
			{
				get
				{
					TValue result;
					if (this.TryGetValue(key, out result))
					{
						return result;
					}
					throw new KeyNotFoundException();
				}
				set
				{
					ImmutableDictionary<TKey, TValue>.MutationResult result = ImmutableDictionary<TKey, TValue>.Add(key, value, ImmutableDictionary<TKey, TValue>.KeyCollisionBehavior.SetValue, this.Origin);
					this.Apply(result);
				}
			}

			// Token: 0x060003E3 RID: 995 RVA: 0x0000A450 File Offset: 0x00008650
			public void AddRange(IEnumerable<KeyValuePair<TKey, TValue>> items)
			{
				ImmutableDictionary<TKey, TValue>.MutationResult result = ImmutableDictionary<TKey, TValue>.AddRange(items, this.Origin, ImmutableDictionary<TKey, TValue>.KeyCollisionBehavior.ThrowIfValueDifferent);
				this.Apply(result);
			}

			// Token: 0x060003E4 RID: 996 RVA: 0x0000A474 File Offset: 0x00008674
			public void RemoveRange(IEnumerable<TKey> keys)
			{
				Requires.NotNull<IEnumerable<TKey>>(keys, "keys");
				foreach (TKey key in keys)
				{
					this.Remove(key);
				}
			}

			// Token: 0x060003E5 RID: 997 RVA: 0x0000A4C8 File Offset: 0x000086C8
			public ImmutableDictionary<TKey, TValue>.Enumerator GetEnumerator()
			{
				return new ImmutableDictionary<TKey, TValue>.Enumerator(this._root, this);
			}

			// Token: 0x060003E6 RID: 998 RVA: 0x0000A4D8 File Offset: 0x000086D8
			public TValue GetValueOrDefault(TKey key)
			{
				return this.GetValueOrDefault(key, default(TValue));
			}

			// Token: 0x060003E7 RID: 999 RVA: 0x0000A4F8 File Offset: 0x000086F8
			public TValue GetValueOrDefault(TKey key, TValue defaultValue)
			{
				Requires.NotNullAllowStructs<TKey>(key, "key");
				TValue result;
				if (this.TryGetValue(key, out result))
				{
					return result;
				}
				return defaultValue;
			}

			// Token: 0x060003E8 RID: 1000 RVA: 0x0000A51E File Offset: 0x0000871E
			public ImmutableDictionary<TKey, TValue> ToImmutable()
			{
				if (this._immutable == null)
				{
					this._immutable = ImmutableDictionary<TKey, TValue>.Wrap(this._root, this._comparers, this._count);
				}
				return this._immutable;
			}

			// Token: 0x060003E9 RID: 1001 RVA: 0x0000A54C File Offset: 0x0000874C
			public void Add(TKey key, TValue value)
			{
				ImmutableDictionary<TKey, TValue>.MutationResult result = ImmutableDictionary<TKey, TValue>.Add(key, value, ImmutableDictionary<TKey, TValue>.KeyCollisionBehavior.ThrowIfValueDifferent, this.Origin);
				this.Apply(result);
			}

			// Token: 0x060003EA RID: 1002 RVA: 0x0000A570 File Offset: 0x00008770
			public bool ContainsKey(TKey key)
			{
				return ImmutableDictionary<TKey, TValue>.ContainsKey(key, this.Origin);
			}

			// Token: 0x060003EB RID: 1003 RVA: 0x0000A580 File Offset: 0x00008780
			public bool ContainsValue(TValue value)
			{
				foreach (KeyValuePair<TKey, TValue> keyValuePair in this)
				{
					if (this.ValueComparer.Equals(value, keyValuePair.Value))
					{
						return true;
					}
				}
				return false;
			}

			// Token: 0x060003EC RID: 1004 RVA: 0x0000A5E4 File Offset: 0x000087E4
			public bool Remove(TKey key)
			{
				ImmutableDictionary<TKey, TValue>.MutationResult result = ImmutableDictionary<TKey, TValue>.Remove(key, this.Origin);
				return this.Apply(result);
			}

			// Token: 0x060003ED RID: 1005 RVA: 0x0000A605 File Offset: 0x00008805
			public bool TryGetValue(TKey key, out TValue value)
			{
				return ImmutableDictionary<TKey, TValue>.TryGetValue(key, this.Origin, out value);
			}

			// Token: 0x060003EE RID: 1006 RVA: 0x0000A614 File Offset: 0x00008814
			public bool TryGetKey(TKey equalKey, out TKey actualKey)
			{
				return ImmutableDictionary<TKey, TValue>.TryGetKey(equalKey, this.Origin, out actualKey);
			}

			// Token: 0x060003EF RID: 1007 RVA: 0x0000A623 File Offset: 0x00008823
			public void Add(KeyValuePair<TKey, TValue> item)
			{
				this.Add(item.Key, item.Value);
			}

			// Token: 0x060003F0 RID: 1008 RVA: 0x0000A639 File Offset: 0x00008839
			public void Clear()
			{
				this.Root = SortedInt32KeyNode<ImmutableDictionary<TKey, TValue>.HashBucket>.EmptyNode;
				this._count = 0;
			}

			// Token: 0x060003F1 RID: 1009 RVA: 0x0000A64D File Offset: 0x0000884D
			public bool Contains(KeyValuePair<TKey, TValue> item)
			{
				return ImmutableDictionary<TKey, TValue>.Contains(item, this.Origin);
			}

			// Token: 0x060003F2 RID: 1010 RVA: 0x0000A65C File Offset: 0x0000885C
			void ICollection<KeyValuePair<!0, !1>>.CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
			{
				Requires.NotNull<KeyValuePair<TKey, TValue>[]>(array, "array");
				foreach (KeyValuePair<TKey, TValue> keyValuePair in this)
				{
					array[arrayIndex++] = keyValuePair;
				}
			}

			// Token: 0x060003F3 RID: 1011 RVA: 0x0000A6BC File Offset: 0x000088BC
			public bool Remove(KeyValuePair<TKey, TValue> item)
			{
				return this.Contains(item) && this.Remove(item.Key);
			}

			// Token: 0x060003F4 RID: 1012 RVA: 0x0000A6D6 File Offset: 0x000088D6
			IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<!0, !1>>.GetEnumerator()
			{
				return this.GetEnumerator();
			}

			// Token: 0x060003F5 RID: 1013 RVA: 0x0000A6D6 File Offset: 0x000088D6
			IEnumerator IEnumerable.GetEnumerator()
			{
				return this.GetEnumerator();
			}

			// Token: 0x060003F6 RID: 1014 RVA: 0x0000A6E3 File Offset: 0x000088E3
			private bool Apply(ImmutableDictionary<TKey, TValue>.MutationResult result)
			{
				this.Root = result.Root;
				this._count += result.CountAdjustment;
				return result.CountAdjustment != 0;
			}

			// Token: 0x0400005D RID: 93
			private SortedInt32KeyNode<ImmutableDictionary<TKey, TValue>.HashBucket> _root = SortedInt32KeyNode<ImmutableDictionary<TKey, TValue>.HashBucket>.EmptyNode;

			// Token: 0x0400005E RID: 94
			private ImmutableDictionary<TKey, TValue>.Comparers _comparers;

			// Token: 0x0400005F RID: 95
			private int _count;

			// Token: 0x04000060 RID: 96
			private ImmutableDictionary<TKey, TValue> _immutable;

			// Token: 0x04000061 RID: 97
			private int _version;

			// Token: 0x04000062 RID: 98
			private object _syncRoot;
		}

		// Token: 0x02000048 RID: 72
		internal class Comparers : IEqualityComparer<ImmutableDictionary<TKey, TValue>.HashBucket>, IEqualityComparer<KeyValuePair<TKey, TValue>>
		{
			// Token: 0x060003F7 RID: 1015 RVA: 0x0000A710 File Offset: 0x00008910
			internal Comparers(IEqualityComparer<TKey> keyComparer, IEqualityComparer<TValue> valueComparer)
			{
				Requires.NotNull<IEqualityComparer<TKey>>(keyComparer, "keyComparer");
				Requires.NotNull<IEqualityComparer<TValue>>(valueComparer, "valueComparer");
				this._keyComparer = keyComparer;
				this._valueComparer = valueComparer;
			}

			// Token: 0x170000B5 RID: 181
			// (get) Token: 0x060003F8 RID: 1016 RVA: 0x0000A73C File Offset: 0x0000893C
			internal IEqualityComparer<TKey> KeyComparer
			{
				get
				{
					return this._keyComparer;
				}
			}

			// Token: 0x170000B6 RID: 182
			// (get) Token: 0x060003F9 RID: 1017 RVA: 0x00004C08 File Offset: 0x00002E08
			internal IEqualityComparer<KeyValuePair<TKey, TValue>> KeyOnlyComparer
			{
				get
				{
					return this;
				}
			}

			// Token: 0x170000B7 RID: 183
			// (get) Token: 0x060003FA RID: 1018 RVA: 0x0000A744 File Offset: 0x00008944
			internal IEqualityComparer<TValue> ValueComparer
			{
				get
				{
					return this._valueComparer;
				}
			}

			// Token: 0x170000B8 RID: 184
			// (get) Token: 0x060003FB RID: 1019 RVA: 0x00004C08 File Offset: 0x00002E08
			internal IEqualityComparer<ImmutableDictionary<TKey, TValue>.HashBucket> HashBucketEqualityComparer
			{
				get
				{
					return this;
				}
			}

			// Token: 0x060003FC RID: 1020 RVA: 0x0000A74C File Offset: 0x0000894C
			public bool Equals(ImmutableDictionary<TKey, TValue>.HashBucket x, ImmutableDictionary<TKey, TValue>.HashBucket y)
			{
				return x.AdditionalElements == y.AdditionalElements && this.KeyComparer.Equals(x.FirstValue.Key, y.FirstValue.Key) && this.ValueComparer.Equals(x.FirstValue.Value, y.FirstValue.Value);
			}

			// Token: 0x060003FD RID: 1021 RVA: 0x0000A7C0 File Offset: 0x000089C0
			public int GetHashCode(ImmutableDictionary<TKey, TValue>.HashBucket obj)
			{
				return this.KeyComparer.GetHashCode(obj.FirstValue.Key);
			}

			// Token: 0x060003FE RID: 1022 RVA: 0x0000A7E7 File Offset: 0x000089E7
			bool IEqualityComparer<KeyValuePair<!0, !1>>.Equals(KeyValuePair<TKey, TValue> x, KeyValuePair<TKey, TValue> y)
			{
				return this._keyComparer.Equals(x.Key, y.Key);
			}

			// Token: 0x060003FF RID: 1023 RVA: 0x0000A802 File Offset: 0x00008A02
			int IEqualityComparer<KeyValuePair<!0, !1>>.GetHashCode(KeyValuePair<TKey, TValue> obj)
			{
				return this._keyComparer.GetHashCode(obj.Key);
			}

			// Token: 0x06000400 RID: 1024 RVA: 0x0000A816 File Offset: 0x00008A16
			internal static ImmutableDictionary<TKey, TValue>.Comparers Get(IEqualityComparer<TKey> keyComparer, IEqualityComparer<TValue> valueComparer)
			{
				Requires.NotNull<IEqualityComparer<TKey>>(keyComparer, "keyComparer");
				Requires.NotNull<IEqualityComparer<TValue>>(valueComparer, "valueComparer");
				if (keyComparer != ImmutableDictionary<TKey, TValue>.Comparers.Default.KeyComparer || valueComparer != ImmutableDictionary<TKey, TValue>.Comparers.Default.ValueComparer)
				{
					return new ImmutableDictionary<TKey, TValue>.Comparers(keyComparer, valueComparer);
				}
				return ImmutableDictionary<TKey, TValue>.Comparers.Default;
			}

			// Token: 0x06000401 RID: 1025 RVA: 0x0000A855 File Offset: 0x00008A55
			internal ImmutableDictionary<TKey, TValue>.Comparers WithValueComparer(IEqualityComparer<TValue> valueComparer)
			{
				Requires.NotNull<IEqualityComparer<TValue>>(valueComparer, "valueComparer");
				if (this._valueComparer != valueComparer)
				{
					return ImmutableDictionary<TKey, TValue>.Comparers.Get(this.KeyComparer, valueComparer);
				}
				return this;
			}

			// Token: 0x04000063 RID: 99
			internal static readonly ImmutableDictionary<TKey, TValue>.Comparers Default = new ImmutableDictionary<TKey, TValue>.Comparers(EqualityComparer<TKey>.Default, EqualityComparer<TValue>.Default);

			// Token: 0x04000064 RID: 100
			private readonly IEqualityComparer<TKey> _keyComparer;

			// Token: 0x04000065 RID: 101
			private readonly IEqualityComparer<TValue> _valueComparer;
		}

		// Token: 0x02000049 RID: 73
		public struct Enumerator : IEnumerator<KeyValuePair<TKey, TValue>>, IEnumerator, IDisposable
		{
			// Token: 0x06000403 RID: 1027 RVA: 0x0000A88F File Offset: 0x00008A8F
			internal Enumerator(SortedInt32KeyNode<ImmutableDictionary<TKey, TValue>.HashBucket> root, ImmutableDictionary<TKey, TValue>.Builder builder = null)
			{
				this._builder = builder;
				this._mapEnumerator = new SortedInt32KeyNode<ImmutableDictionary<TKey, TValue>.HashBucket>.Enumerator(root);
				this._bucketEnumerator = default(ImmutableDictionary<TKey, TValue>.HashBucket.Enumerator);
				this._enumeratingBuilderVersion = ((builder != null) ? builder.Version : -1);
			}

			// Token: 0x170000B9 RID: 185
			// (get) Token: 0x06000404 RID: 1028 RVA: 0x0000A8C2 File Offset: 0x00008AC2
			public KeyValuePair<TKey, TValue> Current
			{
				get
				{
					this._mapEnumerator.ThrowIfDisposed();
					return this._bucketEnumerator.Current;
				}
			}

			// Token: 0x170000BA RID: 186
			// (get) Token: 0x06000405 RID: 1029 RVA: 0x0000A8DA File Offset: 0x00008ADA
			object IEnumerator.Current
			{
				get
				{
					return this.Current;
				}
			}

			// Token: 0x06000406 RID: 1030 RVA: 0x0000A8E8 File Offset: 0x00008AE8
			public bool MoveNext()
			{
				this.ThrowIfChanged();
				if (this._bucketEnumerator.MoveNext())
				{
					return true;
				}
				if (this._mapEnumerator.MoveNext())
				{
					KeyValuePair<int, ImmutableDictionary<TKey, TValue>.HashBucket> keyValuePair = this._mapEnumerator.Current;
					this._bucketEnumerator = new ImmutableDictionary<TKey, TValue>.HashBucket.Enumerator(keyValuePair.Value);
					return this._bucketEnumerator.MoveNext();
				}
				return false;
			}

			// Token: 0x06000407 RID: 1031 RVA: 0x0000A942 File Offset: 0x00008B42
			public void Reset()
			{
				this._enumeratingBuilderVersion = ((this._builder != null) ? this._builder.Version : -1);
				this._mapEnumerator.Reset();
				this._bucketEnumerator.Dispose();
				this._bucketEnumerator = default(ImmutableDictionary<TKey, TValue>.HashBucket.Enumerator);
			}

			// Token: 0x06000408 RID: 1032 RVA: 0x0000A982 File Offset: 0x00008B82
			public void Dispose()
			{
				this._mapEnumerator.Dispose();
				this._bucketEnumerator.Dispose();
			}

			// Token: 0x06000409 RID: 1033 RVA: 0x0000A99A File Offset: 0x00008B9A
			private void ThrowIfChanged()
			{
				if (this._builder != null && this._builder.Version != this._enumeratingBuilderVersion)
				{
					throw new InvalidOperationException(SR.CollectionModifiedDuringEnumeration);
				}
			}

			// Token: 0x04000066 RID: 102
			private readonly ImmutableDictionary<TKey, TValue>.Builder _builder;

			// Token: 0x04000067 RID: 103
			private SortedInt32KeyNode<ImmutableDictionary<TKey, TValue>.HashBucket>.Enumerator _mapEnumerator;

			// Token: 0x04000068 RID: 104
			private ImmutableDictionary<TKey, TValue>.HashBucket.Enumerator _bucketEnumerator;

			// Token: 0x04000069 RID: 105
			private int _enumeratingBuilderVersion;
		}

		// Token: 0x0200004A RID: 74
		internal struct HashBucket : IEnumerable<KeyValuePair<!0, !1>>, IEnumerable, IEquatable<ImmutableDictionary<TKey, TValue>.HashBucket>
		{
			// Token: 0x0600040A RID: 1034 RVA: 0x0000A9C2 File Offset: 0x00008BC2
			private HashBucket(KeyValuePair<TKey, TValue> firstElement, ImmutableList<KeyValuePair<TKey, TValue>>.Node additionalElements = null)
			{
				this._firstValue = firstElement;
				this._additionalElements = (additionalElements ?? ImmutableList<KeyValuePair<TKey, TValue>>.Node.EmptyNode);
			}

			// Token: 0x170000BB RID: 187
			// (get) Token: 0x0600040B RID: 1035 RVA: 0x0000A9DB File Offset: 0x00008BDB
			internal bool IsEmpty
			{
				get
				{
					return this._additionalElements == null;
				}
			}

			// Token: 0x170000BC RID: 188
			// (get) Token: 0x0600040C RID: 1036 RVA: 0x0000A9E6 File Offset: 0x00008BE6
			internal KeyValuePair<TKey, TValue> FirstValue
			{
				get
				{
					if (this.IsEmpty)
					{
						throw new InvalidOperationException();
					}
					return this._firstValue;
				}
			}

			// Token: 0x170000BD RID: 189
			// (get) Token: 0x0600040D RID: 1037 RVA: 0x0000A9FC File Offset: 0x00008BFC
			internal ImmutableList<KeyValuePair<TKey, TValue>>.Node AdditionalElements
			{
				get
				{
					return this._additionalElements;
				}
			}

			// Token: 0x0600040E RID: 1038 RVA: 0x0000AA04 File Offset: 0x00008C04
			public ImmutableDictionary<TKey, TValue>.HashBucket.Enumerator GetEnumerator()
			{
				return new ImmutableDictionary<TKey, TValue>.HashBucket.Enumerator(this);
			}

			// Token: 0x0600040F RID: 1039 RVA: 0x0000AA11 File Offset: 0x00008C11
			IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<!0, !1>>.GetEnumerator()
			{
				return this.GetEnumerator();
			}

			// Token: 0x06000410 RID: 1040 RVA: 0x0000AA11 File Offset: 0x00008C11
			IEnumerator IEnumerable.GetEnumerator()
			{
				return this.GetEnumerator();
			}

			// Token: 0x06000411 RID: 1041 RVA: 0x0000317B File Offset: 0x0000137B
			bool IEquatable<ImmutableDictionary<!0, !1>.HashBucket>.Equals(ImmutableDictionary<TKey, TValue>.HashBucket other)
			{
				throw new NotSupportedException();
			}

			// Token: 0x06000412 RID: 1042 RVA: 0x0000AA20 File Offset: 0x00008C20
			internal ImmutableDictionary<TKey, TValue>.HashBucket Add(TKey key, TValue value, IEqualityComparer<KeyValuePair<TKey, TValue>> keyOnlyComparer, IEqualityComparer<TValue> valueComparer, ImmutableDictionary<TKey, TValue>.KeyCollisionBehavior behavior, out ImmutableDictionary<TKey, TValue>.OperationResult result)
			{
				KeyValuePair<TKey, TValue> keyValuePair = new KeyValuePair<TKey, TValue>(key, value);
				if (this.IsEmpty)
				{
					result = ImmutableDictionary<TKey, TValue>.OperationResult.SizeChanged;
					return new ImmutableDictionary<TKey, TValue>.HashBucket(keyValuePair, null);
				}
				if (keyOnlyComparer.Equals(keyValuePair, this._firstValue))
				{
					switch (behavior)
					{
					case ImmutableDictionary<TKey, TValue>.KeyCollisionBehavior.SetValue:
						result = ImmutableDictionary<TKey, TValue>.OperationResult.AppliedWithoutSizeChange;
						return new ImmutableDictionary<TKey, TValue>.HashBucket(keyValuePair, this._additionalElements);
					case ImmutableDictionary<TKey, TValue>.KeyCollisionBehavior.Skip:
						result = ImmutableDictionary<TKey, TValue>.OperationResult.NoChangeRequired;
						return this;
					case ImmutableDictionary<TKey, TValue>.KeyCollisionBehavior.ThrowIfValueDifferent:
						if (!valueComparer.Equals(this._firstValue.Value, value))
						{
							throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, SR.DuplicateKey, new object[]
							{
								key
							}));
						}
						result = ImmutableDictionary<TKey, TValue>.OperationResult.NoChangeRequired;
						return this;
					case ImmutableDictionary<TKey, TValue>.KeyCollisionBehavior.ThrowAlways:
						throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, SR.DuplicateKey, new object[]
						{
							key
						}));
					default:
						throw new InvalidOperationException();
					}
				}
				else
				{
					int num = this._additionalElements.IndexOf(keyValuePair, keyOnlyComparer);
					if (num < 0)
					{
						result = ImmutableDictionary<TKey, TValue>.OperationResult.SizeChanged;
						return new ImmutableDictionary<TKey, TValue>.HashBucket(this._firstValue, this._additionalElements.Add(keyValuePair));
					}
					switch (behavior)
					{
					case ImmutableDictionary<TKey, TValue>.KeyCollisionBehavior.SetValue:
						result = ImmutableDictionary<TKey, TValue>.OperationResult.AppliedWithoutSizeChange;
						return new ImmutableDictionary<TKey, TValue>.HashBucket(this._firstValue, this._additionalElements.ReplaceAt(num, keyValuePair));
					case ImmutableDictionary<TKey, TValue>.KeyCollisionBehavior.Skip:
						result = ImmutableDictionary<TKey, TValue>.OperationResult.NoChangeRequired;
						return this;
					case ImmutableDictionary<TKey, TValue>.KeyCollisionBehavior.ThrowIfValueDifferent:
						if (!valueComparer.Equals(this._additionalElements[num].Value, value))
						{
							throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, SR.DuplicateKey, new object[]
							{
								key
							}));
						}
						result = ImmutableDictionary<TKey, TValue>.OperationResult.NoChangeRequired;
						return this;
					case ImmutableDictionary<TKey, TValue>.KeyCollisionBehavior.ThrowAlways:
						throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, SR.DuplicateKey, new object[]
						{
							key
						}));
					default:
						throw new InvalidOperationException();
					}
				}
			}

			// Token: 0x06000413 RID: 1043 RVA: 0x0000ABF0 File Offset: 0x00008DF0
			internal ImmutableDictionary<TKey, TValue>.HashBucket Remove(TKey key, IEqualityComparer<KeyValuePair<TKey, TValue>> keyOnlyComparer, out ImmutableDictionary<TKey, TValue>.OperationResult result)
			{
				if (this.IsEmpty)
				{
					result = ImmutableDictionary<TKey, TValue>.OperationResult.NoChangeRequired;
					return this;
				}
				KeyValuePair<TKey, TValue> keyValuePair = new KeyValuePair<TKey, TValue>(key, default(TValue));
				if (keyOnlyComparer.Equals(this._firstValue, keyValuePair))
				{
					if (this._additionalElements.IsEmpty)
					{
						result = ImmutableDictionary<TKey, TValue>.OperationResult.SizeChanged;
						return default(ImmutableDictionary<TKey, TValue>.HashBucket);
					}
					int count = this._additionalElements.Left.Count;
					result = ImmutableDictionary<TKey, TValue>.OperationResult.SizeChanged;
					return new ImmutableDictionary<TKey, TValue>.HashBucket(this._additionalElements.Key, this._additionalElements.RemoveAt(count));
				}
				else
				{
					int num = this._additionalElements.IndexOf(keyValuePair, keyOnlyComparer);
					if (num < 0)
					{
						result = ImmutableDictionary<TKey, TValue>.OperationResult.NoChangeRequired;
						return this;
					}
					result = ImmutableDictionary<TKey, TValue>.OperationResult.SizeChanged;
					return new ImmutableDictionary<TKey, TValue>.HashBucket(this._firstValue, this._additionalElements.RemoveAt(num));
				}
			}

			// Token: 0x06000414 RID: 1044 RVA: 0x0000ACB4 File Offset: 0x00008EB4
			internal bool TryGetValue(TKey key, IEqualityComparer<KeyValuePair<TKey, TValue>> keyOnlyComparer, out TValue value)
			{
				if (this.IsEmpty)
				{
					value = default(TValue);
					return false;
				}
				KeyValuePair<TKey, TValue> keyValuePair = new KeyValuePair<TKey, TValue>(key, default(TValue));
				if (keyOnlyComparer.Equals(this._firstValue, keyValuePair))
				{
					value = this._firstValue.Value;
					return true;
				}
				int num = this._additionalElements.IndexOf(keyValuePair, keyOnlyComparer);
				if (num < 0)
				{
					value = default(TValue);
					return false;
				}
				value = this._additionalElements[num].Value;
				return true;
			}

			// Token: 0x06000415 RID: 1045 RVA: 0x0000AD40 File Offset: 0x00008F40
			internal bool TryGetKey(TKey equalKey, IEqualityComparer<KeyValuePair<TKey, TValue>> keyOnlyComparer, out TKey actualKey)
			{
				if (this.IsEmpty)
				{
					actualKey = equalKey;
					return false;
				}
				KeyValuePair<TKey, TValue> keyValuePair = new KeyValuePair<TKey, TValue>(equalKey, default(TValue));
				if (keyOnlyComparer.Equals(this._firstValue, keyValuePair))
				{
					actualKey = this._firstValue.Key;
					return true;
				}
				int num = this._additionalElements.IndexOf(keyValuePair, keyOnlyComparer);
				if (num < 0)
				{
					actualKey = equalKey;
					return false;
				}
				actualKey = this._additionalElements[num].Key;
				return true;
			}

			// Token: 0x06000416 RID: 1046 RVA: 0x0000ADCA File Offset: 0x00008FCA
			internal void Freeze()
			{
				if (this._additionalElements != null)
				{
					this._additionalElements.Freeze();
				}
			}

			// Token: 0x0400006A RID: 106
			private readonly KeyValuePair<TKey, TValue> _firstValue;

			// Token: 0x0400006B RID: 107
			private readonly ImmutableList<KeyValuePair<TKey, TValue>>.Node _additionalElements;

			// Token: 0x02000071 RID: 113
			internal struct Enumerator : IEnumerator<KeyValuePair<TKey, TValue>>, IEnumerator, IDisposable
			{
				// Token: 0x06000621 RID: 1569 RVA: 0x000109D7 File Offset: 0x0000EBD7
				internal Enumerator(ImmutableDictionary<TKey, TValue>.HashBucket bucket)
				{
					this._bucket = bucket;
					this._currentPosition = ImmutableDictionary<TKey, TValue>.HashBucket.Enumerator.Position.BeforeFirst;
					this._additionalEnumerator = default(ImmutableList<KeyValuePair<TKey, TValue>>.Enumerator);
				}

				// Token: 0x17000148 RID: 328
				// (get) Token: 0x06000622 RID: 1570 RVA: 0x000109F3 File Offset: 0x0000EBF3
				object IEnumerator.Current
				{
					get
					{
						return this.Current;
					}
				}

				// Token: 0x17000149 RID: 329
				// (get) Token: 0x06000623 RID: 1571 RVA: 0x00010A00 File Offset: 0x0000EC00
				public KeyValuePair<TKey, TValue> Current
				{
					get
					{
						ImmutableDictionary<TKey, TValue>.HashBucket.Enumerator.Position currentPosition = this._currentPosition;
						if (currentPosition == ImmutableDictionary<TKey, TValue>.HashBucket.Enumerator.Position.First)
						{
							return this._bucket._firstValue;
						}
						if (currentPosition != ImmutableDictionary<TKey, TValue>.HashBucket.Enumerator.Position.Additional)
						{
							throw new InvalidOperationException();
						}
						return this._additionalEnumerator.Current;
					}
				}

				// Token: 0x06000624 RID: 1572 RVA: 0x00010A3C File Offset: 0x0000EC3C
				public bool MoveNext()
				{
					if (this._bucket.IsEmpty)
					{
						this._currentPosition = ImmutableDictionary<TKey, TValue>.HashBucket.Enumerator.Position.End;
						return false;
					}
					switch (this._currentPosition)
					{
					case ImmutableDictionary<TKey, TValue>.HashBucket.Enumerator.Position.BeforeFirst:
						this._currentPosition = ImmutableDictionary<TKey, TValue>.HashBucket.Enumerator.Position.First;
						return true;
					case ImmutableDictionary<TKey, TValue>.HashBucket.Enumerator.Position.First:
						if (this._bucket._additionalElements.IsEmpty)
						{
							this._currentPosition = ImmutableDictionary<TKey, TValue>.HashBucket.Enumerator.Position.End;
							return false;
						}
						this._currentPosition = ImmutableDictionary<TKey, TValue>.HashBucket.Enumerator.Position.Additional;
						this._additionalEnumerator = new ImmutableList<KeyValuePair<TKey, TValue>>.Enumerator(this._bucket._additionalElements, null, -1, -1, false);
						return this._additionalEnumerator.MoveNext();
					case ImmutableDictionary<TKey, TValue>.HashBucket.Enumerator.Position.Additional:
						return this._additionalEnumerator.MoveNext();
					case ImmutableDictionary<TKey, TValue>.HashBucket.Enumerator.Position.End:
						return false;
					default:
						throw new InvalidOperationException();
					}
				}

				// Token: 0x06000625 RID: 1573 RVA: 0x00010AE5 File Offset: 0x0000ECE5
				public void Reset()
				{
					this._additionalEnumerator.Dispose();
					this._currentPosition = ImmutableDictionary<TKey, TValue>.HashBucket.Enumerator.Position.BeforeFirst;
				}

				// Token: 0x06000626 RID: 1574 RVA: 0x00010AF9 File Offset: 0x0000ECF9
				public void Dispose()
				{
					this._additionalEnumerator.Dispose();
				}

				// Token: 0x04000109 RID: 265
				private readonly ImmutableDictionary<TKey, TValue>.HashBucket _bucket;

				// Token: 0x0400010A RID: 266
				private ImmutableDictionary<TKey, TValue>.HashBucket.Enumerator.Position _currentPosition;

				// Token: 0x0400010B RID: 267
				private ImmutableList<KeyValuePair<TKey, TValue>>.Enumerator _additionalEnumerator;

				// Token: 0x02000074 RID: 116
				private enum Position
				{
					// Token: 0x04000114 RID: 276
					BeforeFirst,
					// Token: 0x04000115 RID: 277
					First,
					// Token: 0x04000116 RID: 278
					Additional,
					// Token: 0x04000117 RID: 279
					End
				}
			}
		}

		// Token: 0x0200004B RID: 75
		private struct MutationInput
		{
			// Token: 0x06000417 RID: 1047 RVA: 0x0000ADDF File Offset: 0x00008FDF
			internal MutationInput(SortedInt32KeyNode<ImmutableDictionary<TKey, TValue>.HashBucket> root, ImmutableDictionary<TKey, TValue>.Comparers comparers, int count)
			{
				this._root = root;
				this._comparers = comparers;
				this._count = count;
			}

			// Token: 0x06000418 RID: 1048 RVA: 0x0000ADF6 File Offset: 0x00008FF6
			internal MutationInput(ImmutableDictionary<TKey, TValue> map)
			{
				this._root = map._root;
				this._comparers = map._comparers;
				this._count = map._count;
			}

			// Token: 0x170000BE RID: 190
			// (get) Token: 0x06000419 RID: 1049 RVA: 0x0000AE1C File Offset: 0x0000901C
			internal SortedInt32KeyNode<ImmutableDictionary<TKey, TValue>.HashBucket> Root
			{
				get
				{
					return this._root;
				}
			}

			// Token: 0x170000BF RID: 191
			// (get) Token: 0x0600041A RID: 1050 RVA: 0x0000AE24 File Offset: 0x00009024
			internal IEqualityComparer<TKey> KeyComparer
			{
				get
				{
					return this._comparers.KeyComparer;
				}
			}

			// Token: 0x170000C0 RID: 192
			// (get) Token: 0x0600041B RID: 1051 RVA: 0x0000AE31 File Offset: 0x00009031
			internal IEqualityComparer<KeyValuePair<TKey, TValue>> KeyOnlyComparer
			{
				get
				{
					return this._comparers.KeyOnlyComparer;
				}
			}

			// Token: 0x170000C1 RID: 193
			// (get) Token: 0x0600041C RID: 1052 RVA: 0x0000AE3E File Offset: 0x0000903E
			internal IEqualityComparer<TValue> ValueComparer
			{
				get
				{
					return this._comparers.ValueComparer;
				}
			}

			// Token: 0x170000C2 RID: 194
			// (get) Token: 0x0600041D RID: 1053 RVA: 0x0000AE4B File Offset: 0x0000904B
			internal IEqualityComparer<ImmutableDictionary<TKey, TValue>.HashBucket> HashBucketComparer
			{
				get
				{
					return this._comparers.HashBucketEqualityComparer;
				}
			}

			// Token: 0x170000C3 RID: 195
			// (get) Token: 0x0600041E RID: 1054 RVA: 0x0000AE58 File Offset: 0x00009058
			internal int Count
			{
				get
				{
					return this._count;
				}
			}

			// Token: 0x0400006C RID: 108
			private readonly SortedInt32KeyNode<ImmutableDictionary<TKey, TValue>.HashBucket> _root;

			// Token: 0x0400006D RID: 109
			private readonly ImmutableDictionary<TKey, TValue>.Comparers _comparers;

			// Token: 0x0400006E RID: 110
			private readonly int _count;
		}

		// Token: 0x0200004C RID: 76
		private struct MutationResult
		{
			// Token: 0x0600041F RID: 1055 RVA: 0x0000AE60 File Offset: 0x00009060
			internal MutationResult(ImmutableDictionary<TKey, TValue>.MutationInput unchangedInput)
			{
				this._root = unchangedInput.Root;
				this._countAdjustment = 0;
			}

			// Token: 0x06000420 RID: 1056 RVA: 0x0000AE76 File Offset: 0x00009076
			internal MutationResult(SortedInt32KeyNode<ImmutableDictionary<TKey, TValue>.HashBucket> root, int countAdjustment)
			{
				Requires.NotNull<SortedInt32KeyNode<ImmutableDictionary<TKey, TValue>.HashBucket>>(root, "root");
				this._root = root;
				this._countAdjustment = countAdjustment;
			}

			// Token: 0x170000C4 RID: 196
			// (get) Token: 0x06000421 RID: 1057 RVA: 0x0000AE91 File Offset: 0x00009091
			internal SortedInt32KeyNode<ImmutableDictionary<TKey, TValue>.HashBucket> Root
			{
				get
				{
					return this._root;
				}
			}

			// Token: 0x170000C5 RID: 197
			// (get) Token: 0x06000422 RID: 1058 RVA: 0x0000AE99 File Offset: 0x00009099
			internal int CountAdjustment
			{
				get
				{
					return this._countAdjustment;
				}
			}

			// Token: 0x06000423 RID: 1059 RVA: 0x0000AEA1 File Offset: 0x000090A1
			internal ImmutableDictionary<TKey, TValue> Finalize(ImmutableDictionary<TKey, TValue> priorMap)
			{
				Requires.NotNull<ImmutableDictionary<TKey, TValue>>(priorMap, "priorMap");
				return priorMap.Wrap(this.Root, priorMap._count + this.CountAdjustment);
			}

			// Token: 0x0400006F RID: 111
			private readonly SortedInt32KeyNode<ImmutableDictionary<TKey, TValue>.HashBucket> _root;

			// Token: 0x04000070 RID: 112
			private readonly int _countAdjustment;
		}

		// Token: 0x0200004D RID: 77
		internal enum KeyCollisionBehavior
		{
			// Token: 0x04000072 RID: 114
			SetValue,
			// Token: 0x04000073 RID: 115
			Skip,
			// Token: 0x04000074 RID: 116
			ThrowIfValueDifferent,
			// Token: 0x04000075 RID: 117
			ThrowAlways
		}

		// Token: 0x0200004E RID: 78
		internal enum OperationResult
		{
			// Token: 0x04000077 RID: 119
			AppliedWithoutSizeChange,
			// Token: 0x04000078 RID: 120
			SizeChanged,
			// Token: 0x04000079 RID: 121
			NoChangeRequired
		}
	}
}
