﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Threading;

namespace System.Collections.Concurrent
{
	/// <summary>Represents a thread-safe last in-first out (LIFO) collection.</summary>
	/// <typeparam name="T">The type of the elements contained in the stack.</typeparam>
	// Token: 0x0200047D RID: 1149
	[DebuggerDisplay("Count = {Count}")]
	[DebuggerTypeProxy(typeof(SystemCollectionsConcurrent_ProducerConsumerCollectionDebugView<>))]
	[__DynamicallyInvokable]
	[HostProtection(SecurityAction.LinkDemand, Synchronization = true, ExternalThreading = true)]
	[Serializable]
	public class ConcurrentStack<T> : IProducerConsumerCollection<T>, IEnumerable<!0>, IEnumerable, ICollection, IReadOnlyCollection<T>
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Collections.Concurrent.ConcurrentStack`1" /> class.</summary>
		// Token: 0x060037E4 RID: 14308 RVA: 0x000D5B9B File Offset: 0x000D3D9B
		[__DynamicallyInvokable]
		public ConcurrentStack()
		{
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Collections.Concurrent.ConcurrentStack`1" /> class that contains elements copied from the specified collection</summary>
		/// <param name="collection">The collection whose elements are copied to the new <see cref="T:System.Collections.Concurrent.ConcurrentStack`1" />.</param>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="collection" /> argument is null.</exception>
		// Token: 0x060037E5 RID: 14309 RVA: 0x000D5BA3 File Offset: 0x000D3DA3
		[__DynamicallyInvokable]
		public ConcurrentStack(IEnumerable<T> collection)
		{
			if (collection == null)
			{
				throw new ArgumentNullException("collection");
			}
			this.InitializeFromCollection(collection);
		}

		// Token: 0x060037E6 RID: 14310 RVA: 0x000D5BC0 File Offset: 0x000D3DC0
		private void InitializeFromCollection(IEnumerable<T> collection)
		{
			ConcurrentStack<T>.Node node = null;
			foreach (T value in collection)
			{
				node = new ConcurrentStack<T>.Node(value)
				{
					m_next = node
				};
			}
			this.m_head = node;
		}

		// Token: 0x060037E7 RID: 14311 RVA: 0x000D5C1C File Offset: 0x000D3E1C
		[OnSerializing]
		private void OnSerializing(StreamingContext context)
		{
			this.m_serializationArray = this.ToArray();
		}

		// Token: 0x060037E8 RID: 14312 RVA: 0x000D5C2C File Offset: 0x000D3E2C
		[OnDeserialized]
		private void OnDeserialized(StreamingContext context)
		{
			ConcurrentStack<T>.Node node = null;
			ConcurrentStack<T>.Node head = null;
			for (int i = 0; i < this.m_serializationArray.Length; i++)
			{
				ConcurrentStack<T>.Node node2 = new ConcurrentStack<T>.Node(this.m_serializationArray[i]);
				if (node == null)
				{
					head = node2;
				}
				else
				{
					node.m_next = node2;
				}
				node = node2;
			}
			this.m_head = head;
			this.m_serializationArray = null;
		}

		/// <summary>Gets a value that indicates whether the <see cref="T:System.Collections.Concurrent.ConcurrentStack`1" /> is empty.</summary>
		/// <returns>
		///   <see langword="true" /> if the <see cref="T:System.Collections.Concurrent.ConcurrentStack`1" /> is empty; otherwise, <see langword="false" />.</returns>
		// Token: 0x17000872 RID: 2162
		// (get) Token: 0x060037E9 RID: 14313 RVA: 0x000D5C82 File Offset: 0x000D3E82
		[__DynamicallyInvokable]
		public bool IsEmpty
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_head == null;
			}
		}

		/// <summary>Gets the number of elements contained in the <see cref="T:System.Collections.Concurrent.ConcurrentStack`1" />.</summary>
		/// <returns>The number of elements contained in the <see cref="T:System.Collections.Concurrent.ConcurrentStack`1" />.</returns>
		// Token: 0x17000873 RID: 2163
		// (get) Token: 0x060037EA RID: 14314 RVA: 0x000D5C90 File Offset: 0x000D3E90
		[__DynamicallyInvokable]
		public int Count
		{
			[__DynamicallyInvokable]
			get
			{
				int num = 0;
				for (ConcurrentStack<T>.Node node = this.m_head; node != null; node = node.m_next)
				{
					num++;
				}
				return num;
			}
		}

		/// <summary>Gets a value indicating whether access to the <see cref="T:System.Collections.ICollection" /> is synchronized with the SyncRoot.</summary>
		/// <returns>Always returns <see langword="false" /> to indicate access is not synchronized.</returns>
		// Token: 0x17000874 RID: 2164
		// (get) Token: 0x060037EB RID: 14315 RVA: 0x000D5CB9 File Offset: 0x000D3EB9
		[__DynamicallyInvokable]
		bool ICollection.IsSynchronized
		{
			[__DynamicallyInvokable]
			get
			{
				return false;
			}
		}

		/// <summary>Gets an object that can be used to synchronize access to the <see cref="T:System.Collections.ICollection" />. This property is not supported.</summary>
		/// <returns>Returns null (Nothing in Visual Basic).</returns>
		/// <exception cref="T:System.NotSupportedException">The SyncRoot property is not supported</exception>
		// Token: 0x17000875 RID: 2165
		// (get) Token: 0x060037EC RID: 14316 RVA: 0x000D5CBC File Offset: 0x000D3EBC
		[__DynamicallyInvokable]
		object ICollection.SyncRoot
		{
			[__DynamicallyInvokable]
			get
			{
				throw new NotSupportedException(Environment.GetResourceString("ConcurrentCollection_SyncRoot_NotSupported"));
			}
		}

		/// <summary>Removes all objects from the <see cref="T:System.Collections.Concurrent.ConcurrentStack`1" />.</summary>
		// Token: 0x060037ED RID: 14317 RVA: 0x000D5CCD File Offset: 0x000D3ECD
		[__DynamicallyInvokable]
		public void Clear()
		{
			this.m_head = null;
		}

		/// <summary>Copies the elements of the <see cref="T:System.Collections.ICollection" /> to an <see cref="T:System.Array" />, starting at a particular <see cref="T:System.Array" /> index.</summary>
		/// <param name="array">The one-dimensional <see cref="T:System.Array" /> that is the destination of the elements copied from the <see cref="T:System.Collections.Concurrent.ConcurrentStack`1" />. The <see cref="T:System.Array" /> must have zero-based indexing.</param>
		/// <param name="index">The zero-based index in <paramref name="array" /> at which copying begins.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="array" /> is a null reference (Nothing in Visual Basic).</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="index" /> is less than zero.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="array" /> is multidimensional. -or- <paramref name="array" /> does not have zero-based indexing. -or- <paramref name="index" /> is equal to or greater than the length of the <paramref name="array" /> -or- The number of elements in the source <see cref="T:System.Collections.ICollection" /> is greater than the available space from <paramref name="index" /> to the end of the destination <paramref name="array" />. -or- The type of the source <see cref="T:System.Collections.ICollection" /> cannot be cast automatically to the type of the destination <paramref name="array" />.</exception>
		// Token: 0x060037EE RID: 14318 RVA: 0x000D5CD8 File Offset: 0x000D3ED8
		[__DynamicallyInvokable]
		void ICollection.CopyTo(Array array, int index)
		{
			if (array == null)
			{
				throw new ArgumentNullException("array");
			}
			((ICollection)this.ToList()).CopyTo(array, index);
		}

		/// <summary>Copies the <see cref="T:System.Collections.Concurrent.ConcurrentStack`1" /> elements to an existing one-dimensional <see cref="T:System.Array" />, starting at the specified array index.</summary>
		/// <param name="array">The one-dimensional <see cref="T:System.Array" /> that is the destination of the elements copied from the <see cref="T:System.Collections.Concurrent.ConcurrentStack`1" />. The <see cref="T:System.Array" /> must have zero-based indexing.</param>
		/// <param name="index">The zero-based index in <paramref name="array" /> at which copying begins.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="array" /> is a null reference (Nothing in Visual Basic).</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="index" /> is less than zero.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="index" /> is equal to or greater than the length of the <paramref name="array" /> -or- The number of elements in the source <see cref="T:System.Collections.Concurrent.ConcurrentStack`1" /> is greater than the available space from <paramref name="index" /> to the end of the destination <paramref name="array" />.</exception>
		// Token: 0x060037EF RID: 14319 RVA: 0x000D5CF5 File Offset: 0x000D3EF5
		[__DynamicallyInvokable]
		public void CopyTo(T[] array, int index)
		{
			if (array == null)
			{
				throw new ArgumentNullException("array");
			}
			this.ToList().CopyTo(array, index);
		}

		/// <summary>Inserts an object at the top of the <see cref="T:System.Collections.Concurrent.ConcurrentStack`1" />.</summary>
		/// <param name="item">The object to push onto the <see cref="T:System.Collections.Concurrent.ConcurrentStack`1" />. The value can be a null reference (Nothing in Visual Basic) for reference types.</param>
		// Token: 0x060037F0 RID: 14320 RVA: 0x000D5D14 File Offset: 0x000D3F14
		[__DynamicallyInvokable]
		public void Push(T item)
		{
			ConcurrentStack<T>.Node node = new ConcurrentStack<T>.Node(item);
			node.m_next = this.m_head;
			if (Interlocked.CompareExchange<ConcurrentStack<T>.Node>(ref this.m_head, node, node.m_next) == node.m_next)
			{
				return;
			}
			this.PushCore(node, node);
		}

		/// <summary>Inserts multiple objects at the top of the <see cref="T:System.Collections.Concurrent.ConcurrentStack`1" /> atomically.</summary>
		/// <param name="items">The objects to push onto the <see cref="T:System.Collections.Concurrent.ConcurrentStack`1" />.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="items" /> is a null reference (Nothing in Visual Basic).</exception>
		// Token: 0x060037F1 RID: 14321 RVA: 0x000D5D59 File Offset: 0x000D3F59
		[__DynamicallyInvokable]
		public void PushRange(T[] items)
		{
			if (items == null)
			{
				throw new ArgumentNullException("items");
			}
			this.PushRange(items, 0, items.Length);
		}

		/// <summary>Inserts multiple objects at the top of the <see cref="T:System.Collections.Concurrent.ConcurrentStack`1" /> atomically.</summary>
		/// <param name="items">The objects to push onto the <see cref="T:System.Collections.Concurrent.ConcurrentStack`1" />.</param>
		/// <param name="startIndex">The zero-based offset in <paramref name="items" /> at which to begin inserting elements onto the top of the <see cref="T:System.Collections.Concurrent.ConcurrentStack`1" />.</param>
		/// <param name="count">The number of elements to be inserted onto the top of the <see cref="T:System.Collections.Concurrent.ConcurrentStack`1" />.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="items" /> is a null reference (Nothing in Visual Basic).</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="startIndex" /> or <paramref name="count" /> is negative. Or <paramref name="startIndex" /> is greater than or equal to the length of <paramref name="items" />.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="startIndex" /> + <paramref name="count" /> is greater than the length of <paramref name="items" />.</exception>
		// Token: 0x060037F2 RID: 14322 RVA: 0x000D5D74 File Offset: 0x000D3F74
		[__DynamicallyInvokable]
		public void PushRange(T[] items, int startIndex, int count)
		{
			this.ValidatePushPopRangeInput(items, startIndex, count);
			if (count == 0)
			{
				return;
			}
			ConcurrentStack<T>.Node node2;
			ConcurrentStack<T>.Node node = node2 = new ConcurrentStack<T>.Node(items[startIndex]);
			for (int i = startIndex + 1; i < startIndex + count; i++)
			{
				node2 = new ConcurrentStack<T>.Node(items[i])
				{
					m_next = node2
				};
			}
			node.m_next = this.m_head;
			if (Interlocked.CompareExchange<ConcurrentStack<T>.Node>(ref this.m_head, node2, node.m_next) == node.m_next)
			{
				return;
			}
			this.PushCore(node2, node);
		}

		// Token: 0x060037F3 RID: 14323 RVA: 0x000D5DF4 File Offset: 0x000D3FF4
		private void PushCore(ConcurrentStack<T>.Node head, ConcurrentStack<T>.Node tail)
		{
			SpinWait spinWait = default(SpinWait);
			do
			{
				spinWait.SpinOnce();
				tail.m_next = this.m_head;
			}
			while (Interlocked.CompareExchange<ConcurrentStack<T>.Node>(ref this.m_head, head, tail.m_next) != tail.m_next);
			if (CDSCollectionETWBCLProvider.Log.IsEnabled())
			{
				CDSCollectionETWBCLProvider.Log.ConcurrentStack_FastPushFailed(spinWait.Count);
			}
		}

		// Token: 0x060037F4 RID: 14324 RVA: 0x000D5E58 File Offset: 0x000D4058
		private void ValidatePushPopRangeInput(T[] items, int startIndex, int count)
		{
			if (items == null)
			{
				throw new ArgumentNullException("items");
			}
			if (count < 0)
			{
				throw new ArgumentOutOfRangeException("count", Environment.GetResourceString("ConcurrentStack_PushPopRange_CountOutOfRange"));
			}
			int num = items.Length;
			if (startIndex >= num || startIndex < 0)
			{
				throw new ArgumentOutOfRangeException("startIndex", Environment.GetResourceString("ConcurrentStack_PushPopRange_StartOutOfRange"));
			}
			if (num - count < startIndex)
			{
				throw new ArgumentException(Environment.GetResourceString("ConcurrentStack_PushPopRange_InvalidCount"));
			}
		}

		// Token: 0x060037F5 RID: 14325 RVA: 0x000D5EC3 File Offset: 0x000D40C3
		[__DynamicallyInvokable]
		bool IProducerConsumerCollection<!0>.TryAdd(T item)
		{
			this.Push(item);
			return true;
		}

		/// <summary>Attempts to return an object from the top of the <see cref="T:System.Collections.Concurrent.ConcurrentStack`1" /> without removing it.</summary>
		/// <param name="result">When this method returns, <paramref name="result" /> contains an object from the top of the <see cref="T:System.Collections.Concurrent.ConcurrentStack`1" /> or an unspecified value if the operation failed.</param>
		/// <returns>true if and object was returned successfully; otherwise, false.</returns>
		// Token: 0x060037F6 RID: 14326 RVA: 0x000D5ED0 File Offset: 0x000D40D0
		[__DynamicallyInvokable]
		public bool TryPeek(out T result)
		{
			ConcurrentStack<T>.Node head = this.m_head;
			if (head == null)
			{
				result = default(T);
				return false;
			}
			result = head.m_value;
			return true;
		}

		/// <summary>Attempts to pop and return the object at the top of the <see cref="T:System.Collections.Concurrent.ConcurrentStack`1" />.</summary>
		/// <param name="result">When this method returns, if the operation was successful, <paramref name="result" /> contains the object removed. If no object was available to be removed, the value is unspecified.</param>
		/// <returns>true if an element was removed and returned from the top of the <see cref="T:System.Collections.Concurrent.ConcurrentStack`1" /> successfully; otherwise, false.</returns>
		// Token: 0x060037F7 RID: 14327 RVA: 0x000D5F00 File Offset: 0x000D4100
		[__DynamicallyInvokable]
		public bool TryPop(out T result)
		{
			ConcurrentStack<T>.Node head = this.m_head;
			if (head == null)
			{
				result = default(T);
				return false;
			}
			if (Interlocked.CompareExchange<ConcurrentStack<T>.Node>(ref this.m_head, head.m_next, head) == head)
			{
				result = head.m_value;
				return true;
			}
			return this.TryPopCore(out result);
		}

		/// <summary>Attempts to pop and return multiple objects from the top of the <see cref="T:System.Collections.Concurrent.ConcurrentStack`1" /> atomically.</summary>
		/// <param name="items">The <see cref="T:System.Array" /> to which objects popped from the top of the <see cref="T:System.Collections.Concurrent.ConcurrentStack`1" /> will be added.</param>
		/// <returns>The number of objects successfully popped from the top of the <see cref="T:System.Collections.Concurrent.ConcurrentStack`1" /> and inserted in <paramref name="items" />.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="items" /> is a null argument (Nothing in Visual Basic).</exception>
		// Token: 0x060037F8 RID: 14328 RVA: 0x000D5F4C File Offset: 0x000D414C
		[__DynamicallyInvokable]
		public int TryPopRange(T[] items)
		{
			if (items == null)
			{
				throw new ArgumentNullException("items");
			}
			return this.TryPopRange(items, 0, items.Length);
		}

		/// <summary>Attempts to pop and return multiple objects from the top of the <see cref="T:System.Collections.Concurrent.ConcurrentStack`1" /> atomically.</summary>
		/// <param name="items">The <see cref="T:System.Array" /> to which objects popped from the top of the <see cref="T:System.Collections.Concurrent.ConcurrentStack`1" /> will be added.</param>
		/// <param name="startIndex">The zero-based offset in <paramref name="items" /> at which to begin inserting elements from the top of the <see cref="T:System.Collections.Concurrent.ConcurrentStack`1" />.</param>
		/// <param name="count">The number of elements to be popped from top of the <see cref="T:System.Collections.Concurrent.ConcurrentStack`1" /> and inserted into <paramref name="items" />.</param>
		/// <returns>The number of objects successfully popped from the top of the stack and inserted in <paramref name="items" />.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="items" /> is a null reference (Nothing in Visual Basic).</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="startIndex" /> or <paramref name="count" /> is negative. Or <paramref name="startIndex" /> is greater than or equal to the length of <paramref name="items" />.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="startIndex" /> + <paramref name="count" /> is greater than the length of <paramref name="items" />.</exception>
		// Token: 0x060037F9 RID: 14329 RVA: 0x000D5F68 File Offset: 0x000D4168
		[__DynamicallyInvokable]
		public int TryPopRange(T[] items, int startIndex, int count)
		{
			this.ValidatePushPopRangeInput(items, startIndex, count);
			if (count == 0)
			{
				return 0;
			}
			ConcurrentStack<T>.Node head;
			int num = this.TryPopCore(count, out head);
			if (num > 0)
			{
				this.CopyRemovedItems(head, items, startIndex, num);
			}
			return num;
		}

		// Token: 0x060037FA RID: 14330 RVA: 0x000D5F9C File Offset: 0x000D419C
		private bool TryPopCore(out T result)
		{
			ConcurrentStack<T>.Node node;
			if (this.TryPopCore(1, out node) == 1)
			{
				result = node.m_value;
				return true;
			}
			result = default(T);
			return false;
		}

		// Token: 0x060037FB RID: 14331 RVA: 0x000D5FCC File Offset: 0x000D41CC
		private int TryPopCore(int count, out ConcurrentStack<T>.Node poppedHead)
		{
			SpinWait spinWait = default(SpinWait);
			int num = 1;
			Random random = new Random(Environment.TickCount & int.MaxValue);
			ConcurrentStack<T>.Node head;
			int num2;
			for (;;)
			{
				head = this.m_head;
				if (head == null)
				{
					break;
				}
				ConcurrentStack<T>.Node node = head;
				num2 = 1;
				while (num2 < count && node.m_next != null)
				{
					node = node.m_next;
					num2++;
				}
				if (Interlocked.CompareExchange<ConcurrentStack<T>.Node>(ref this.m_head, node.m_next, head) == head)
				{
					goto Block_5;
				}
				for (int i = 0; i < num; i++)
				{
					spinWait.SpinOnce();
				}
				num = (spinWait.NextSpinWillYield ? random.Next(1, 8) : (num * 2));
			}
			if (count == 1 && CDSCollectionETWBCLProvider.Log.IsEnabled())
			{
				CDSCollectionETWBCLProvider.Log.ConcurrentStack_FastPopFailed(spinWait.Count);
			}
			poppedHead = null;
			return 0;
			Block_5:
			if (count == 1 && CDSCollectionETWBCLProvider.Log.IsEnabled())
			{
				CDSCollectionETWBCLProvider.Log.ConcurrentStack_FastPopFailed(spinWait.Count);
			}
			poppedHead = head;
			return num2;
		}

		// Token: 0x060037FC RID: 14332 RVA: 0x000D60B8 File Offset: 0x000D42B8
		private void CopyRemovedItems(ConcurrentStack<T>.Node head, T[] collection, int startIndex, int nodesCount)
		{
			ConcurrentStack<T>.Node node = head;
			for (int i = startIndex; i < startIndex + nodesCount; i++)
			{
				collection[i] = node.m_value;
				node = node.m_next;
			}
		}

		// Token: 0x060037FD RID: 14333 RVA: 0x000D60EA File Offset: 0x000D42EA
		[__DynamicallyInvokable]
		bool IProducerConsumerCollection<!0>.TryTake(out T item)
		{
			return this.TryPop(out item);
		}

		/// <summary>Copies the items stored in the <see cref="T:System.Collections.Concurrent.ConcurrentStack`1" /> to a new array.</summary>
		/// <returns>A new array containing a snapshot of elements copied from the <see cref="T:System.Collections.Concurrent.ConcurrentStack`1" />.</returns>
		// Token: 0x060037FE RID: 14334 RVA: 0x000D60F3 File Offset: 0x000D42F3
		[__DynamicallyInvokable]
		public T[] ToArray()
		{
			return this.ToList().ToArray();
		}

		// Token: 0x060037FF RID: 14335 RVA: 0x000D6100 File Offset: 0x000D4300
		private List<T> ToList()
		{
			List<T> list = new List<T>();
			for (ConcurrentStack<T>.Node node = this.m_head; node != null; node = node.m_next)
			{
				list.Add(node.m_value);
			}
			return list;
		}

		/// <summary>Returns an enumerator that iterates through the <see cref="T:System.Collections.Concurrent.ConcurrentStack`1" />.</summary>
		/// <returns>An enumerator for the <see cref="T:System.Collections.Concurrent.ConcurrentStack`1" />.</returns>
		// Token: 0x06003800 RID: 14336 RVA: 0x000D6135 File Offset: 0x000D4335
		[__DynamicallyInvokable]
		public IEnumerator<T> GetEnumerator()
		{
			return this.GetEnumerator(this.m_head);
		}

		// Token: 0x06003801 RID: 14337 RVA: 0x000D6145 File Offset: 0x000D4345
		private IEnumerator<T> GetEnumerator(ConcurrentStack<T>.Node head)
		{
			for (ConcurrentStack<T>.Node current = head; current != null; current = current.m_next)
			{
				yield return current.m_value;
			}
			yield break;
		}

		/// <summary>Returns an enumerator that iterates through a collection.</summary>
		/// <returns>An <see cref="T:System.Collections.IEnumerator" /> that can be used to iterate through the collection.</returns>
		// Token: 0x06003802 RID: 14338 RVA: 0x000D6154 File Offset: 0x000D4354
		[__DynamicallyInvokable]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<!0>)this).GetEnumerator();
		}

		// Token: 0x04001855 RID: 6229
		[NonSerialized]
		private volatile ConcurrentStack<T>.Node m_head;

		// Token: 0x04001856 RID: 6230
		private T[] m_serializationArray;

		// Token: 0x04001857 RID: 6231
		private const int BACKOFF_MAX_YIELDS = 8;

		// Token: 0x02000B8B RID: 2955
		private class Node
		{
			// Token: 0x06006D3D RID: 27965 RVA: 0x001783C0 File Offset: 0x001765C0
			internal Node(T value)
			{
				this.m_value = value;
				this.m_next = null;
			}

			// Token: 0x040034A5 RID: 13477
			internal readonly T m_value;

			// Token: 0x040034A6 RID: 13478
			internal ConcurrentStack<T>.Node m_next;
		}
	}
}
