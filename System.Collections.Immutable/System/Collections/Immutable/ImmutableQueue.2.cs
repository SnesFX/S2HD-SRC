using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;

namespace System.Collections.Immutable
{
	// Token: 0x0200002A RID: 42
	[DebuggerDisplay("IsEmpty = {IsEmpty}")]
	[DebuggerTypeProxy(typeof(ImmutableEnumerableDebuggerProxy<>))]
	public sealed class ImmutableQueue<T> : IImmutableQueue<T>, IEnumerable<!0>, IEnumerable
	{
		// Token: 0x06000262 RID: 610 RVA: 0x000072E8 File Offset: 0x000054E8
		internal ImmutableQueue(ImmutableStack<T> forwards, ImmutableStack<T> backwards)
		{
			this._forwards = forwards;
			this._backwards = backwards;
		}

		// Token: 0x06000263 RID: 611 RVA: 0x000072FE File Offset: 0x000054FE
		public ImmutableQueue<T> Clear()
		{
			return ImmutableQueue<T>.Empty;
		}

		// Token: 0x1700005F RID: 95
		// (get) Token: 0x06000264 RID: 612 RVA: 0x00007305 File Offset: 0x00005505
		public bool IsEmpty
		{
			get
			{
				return this._forwards.IsEmpty;
			}
		}

		// Token: 0x17000060 RID: 96
		// (get) Token: 0x06000265 RID: 613 RVA: 0x00007312 File Offset: 0x00005512
		public static ImmutableQueue<T> Empty
		{
			get
			{
				return ImmutableQueue<T>.s_EmptyField;
			}
		}

		// Token: 0x06000266 RID: 614 RVA: 0x00007319 File Offset: 0x00005519
		IImmutableQueue<T> IImmutableQueue<!0>.Clear()
		{
			return this.Clear();
		}

		// Token: 0x17000061 RID: 97
		// (get) Token: 0x06000267 RID: 615 RVA: 0x00007321 File Offset: 0x00005521
		private ImmutableStack<T> BackwardsReversed
		{
			get
			{
				if (this._backwardsReversed == null)
				{
					this._backwardsReversed = this._backwards.Reverse();
				}
				return this._backwardsReversed;
			}
		}

		// Token: 0x06000268 RID: 616 RVA: 0x00007342 File Offset: 0x00005542
		public T Peek()
		{
			if (this.IsEmpty)
			{
				throw new InvalidOperationException(SR.InvalidEmptyOperation);
			}
			return this._forwards.Peek();
		}

		// Token: 0x06000269 RID: 617 RVA: 0x00007362 File Offset: 0x00005562
		public ImmutableQueue<T> Enqueue(T value)
		{
			if (this.IsEmpty)
			{
				return new ImmutableQueue<T>(ImmutableStack.Create<T>(value), ImmutableStack<T>.Empty);
			}
			return new ImmutableQueue<T>(this._forwards, this._backwards.Push(value));
		}

		// Token: 0x0600026A RID: 618 RVA: 0x00007394 File Offset: 0x00005594
		IImmutableQueue<T> IImmutableQueue<!0>.Enqueue(T value)
		{
			return this.Enqueue(value);
		}

		// Token: 0x0600026B RID: 619 RVA: 0x000073A0 File Offset: 0x000055A0
		public ImmutableQueue<T> Dequeue()
		{
			if (this.IsEmpty)
			{
				throw new InvalidOperationException(SR.InvalidEmptyOperation);
			}
			ImmutableStack<T> immutableStack = this._forwards.Pop();
			if (!immutableStack.IsEmpty)
			{
				return new ImmutableQueue<T>(immutableStack, this._backwards);
			}
			if (this._backwards.IsEmpty)
			{
				return ImmutableQueue<T>.Empty;
			}
			return new ImmutableQueue<T>(this.BackwardsReversed, ImmutableStack<T>.Empty);
		}

		// Token: 0x0600026C RID: 620 RVA: 0x00007404 File Offset: 0x00005604
		public ImmutableQueue<T> Dequeue(out T value)
		{
			value = this.Peek();
			return this.Dequeue();
		}

		// Token: 0x0600026D RID: 621 RVA: 0x00007418 File Offset: 0x00005618
		IImmutableQueue<T> IImmutableQueue<!0>.Dequeue()
		{
			return this.Dequeue();
		}

		// Token: 0x0600026E RID: 622 RVA: 0x00007420 File Offset: 0x00005620
		public ImmutableQueue<T>.Enumerator GetEnumerator()
		{
			return new ImmutableQueue<T>.Enumerator(this);
		}

		// Token: 0x0600026F RID: 623 RVA: 0x00007428 File Offset: 0x00005628
		IEnumerator<T> IEnumerable<!0>.GetEnumerator()
		{
			return new ImmutableQueue<T>.EnumeratorObject(this);
		}

		// Token: 0x06000270 RID: 624 RVA: 0x00007428 File Offset: 0x00005628
		IEnumerator IEnumerable.GetEnumerator()
		{
			return new ImmutableQueue<T>.EnumeratorObject(this);
		}

		// Token: 0x04000021 RID: 33
		private static readonly ImmutableQueue<T> s_EmptyField = new ImmutableQueue<T>(ImmutableStack<T>.Empty, ImmutableStack<T>.Empty);

		// Token: 0x04000022 RID: 34
		private readonly ImmutableStack<T> _backwards;

		// Token: 0x04000023 RID: 35
		private readonly ImmutableStack<T> _forwards;

		// Token: 0x04000024 RID: 36
		private ImmutableStack<T> _backwardsReversed;

		// Token: 0x02000060 RID: 96
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public struct Enumerator
		{
			// Token: 0x06000520 RID: 1312 RVA: 0x0000DCB1 File Offset: 0x0000BEB1
			internal Enumerator(ImmutableQueue<T> queue)
			{
				this._originalQueue = queue;
				this._remainingForwardsStack = null;
				this._remainingBackwardsStack = null;
			}

			// Token: 0x170000FB RID: 251
			// (get) Token: 0x06000521 RID: 1313 RVA: 0x0000DCC8 File Offset: 0x0000BEC8
			public T Current
			{
				get
				{
					if (this._remainingForwardsStack == null)
					{
						throw new InvalidOperationException();
					}
					if (!this._remainingForwardsStack.IsEmpty)
					{
						return this._remainingForwardsStack.Peek();
					}
					if (!this._remainingBackwardsStack.IsEmpty)
					{
						return this._remainingBackwardsStack.Peek();
					}
					throw new InvalidOperationException();
				}
			}

			// Token: 0x06000522 RID: 1314 RVA: 0x0000DD1C File Offset: 0x0000BF1C
			public bool MoveNext()
			{
				if (this._remainingForwardsStack == null)
				{
					this._remainingForwardsStack = this._originalQueue._forwards;
					this._remainingBackwardsStack = this._originalQueue.BackwardsReversed;
				}
				else if (!this._remainingForwardsStack.IsEmpty)
				{
					this._remainingForwardsStack = this._remainingForwardsStack.Pop();
				}
				else if (!this._remainingBackwardsStack.IsEmpty)
				{
					this._remainingBackwardsStack = this._remainingBackwardsStack.Pop();
				}
				return !this._remainingForwardsStack.IsEmpty || !this._remainingBackwardsStack.IsEmpty;
			}

			// Token: 0x040000B9 RID: 185
			private readonly ImmutableQueue<T> _originalQueue;

			// Token: 0x040000BA RID: 186
			private ImmutableStack<T> _remainingForwardsStack;

			// Token: 0x040000BB RID: 187
			private ImmutableStack<T> _remainingBackwardsStack;
		}

		// Token: 0x02000061 RID: 97
		private class EnumeratorObject : IEnumerator<!0>, IEnumerator, IDisposable
		{
			// Token: 0x06000523 RID: 1315 RVA: 0x0000DDB0 File Offset: 0x0000BFB0
			internal EnumeratorObject(ImmutableQueue<T> queue)
			{
				this._originalQueue = queue;
			}

			// Token: 0x170000FC RID: 252
			// (get) Token: 0x06000524 RID: 1316 RVA: 0x0000DDC0 File Offset: 0x0000BFC0
			public T Current
			{
				get
				{
					this.ThrowIfDisposed();
					if (this._remainingForwardsStack == null)
					{
						throw new InvalidOperationException();
					}
					if (!this._remainingForwardsStack.IsEmpty)
					{
						return this._remainingForwardsStack.Peek();
					}
					if (!this._remainingBackwardsStack.IsEmpty)
					{
						return this._remainingBackwardsStack.Peek();
					}
					throw new InvalidOperationException();
				}
			}

			// Token: 0x170000FD RID: 253
			// (get) Token: 0x06000525 RID: 1317 RVA: 0x0000DE18 File Offset: 0x0000C018
			object IEnumerator.Current
			{
				get
				{
					return this.Current;
				}
			}

			// Token: 0x06000526 RID: 1318 RVA: 0x0000DE28 File Offset: 0x0000C028
			public bool MoveNext()
			{
				this.ThrowIfDisposed();
				if (this._remainingForwardsStack == null)
				{
					this._remainingForwardsStack = this._originalQueue._forwards;
					this._remainingBackwardsStack = this._originalQueue.BackwardsReversed;
				}
				else if (!this._remainingForwardsStack.IsEmpty)
				{
					this._remainingForwardsStack = this._remainingForwardsStack.Pop();
				}
				else if (!this._remainingBackwardsStack.IsEmpty)
				{
					this._remainingBackwardsStack = this._remainingBackwardsStack.Pop();
				}
				return !this._remainingForwardsStack.IsEmpty || !this._remainingBackwardsStack.IsEmpty;
			}

			// Token: 0x06000527 RID: 1319 RVA: 0x0000DEC2 File Offset: 0x0000C0C2
			public void Reset()
			{
				this.ThrowIfDisposed();
				this._remainingBackwardsStack = null;
				this._remainingForwardsStack = null;
			}

			// Token: 0x06000528 RID: 1320 RVA: 0x0000DED8 File Offset: 0x0000C0D8
			public void Dispose()
			{
				this._disposed = true;
			}

			// Token: 0x06000529 RID: 1321 RVA: 0x0000DEE1 File Offset: 0x0000C0E1
			private void ThrowIfDisposed()
			{
				if (this._disposed)
				{
					Requires.FailObjectDisposed<ImmutableQueue<T>.EnumeratorObject>(this);
				}
			}

			// Token: 0x040000BC RID: 188
			private readonly ImmutableQueue<T> _originalQueue;

			// Token: 0x040000BD RID: 189
			private ImmutableStack<T> _remainingForwardsStack;

			// Token: 0x040000BE RID: 190
			private ImmutableStack<T> _remainingBackwardsStack;

			// Token: 0x040000BF RID: 191
			private bool _disposed;
		}
	}
}
