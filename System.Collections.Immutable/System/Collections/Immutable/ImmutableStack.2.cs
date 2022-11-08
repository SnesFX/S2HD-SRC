using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;

namespace System.Collections.Immutable
{
	// Token: 0x02000032 RID: 50
	[DebuggerDisplay("IsEmpty = {IsEmpty}; Top = {_head}")]
	[DebuggerTypeProxy(typeof(ImmutableEnumerableDebuggerProxy<>))]
	public sealed class ImmutableStack<T> : IImmutableStack<T>, IEnumerable<!0>, IEnumerable
	{
		// Token: 0x06000320 RID: 800 RVA: 0x0000895E File Offset: 0x00006B5E
		private ImmutableStack()
		{
		}

		// Token: 0x06000321 RID: 801 RVA: 0x00008966 File Offset: 0x00006B66
		private ImmutableStack(T head, ImmutableStack<T> tail)
		{
			this._head = head;
			this._tail = tail;
		}

		// Token: 0x17000085 RID: 133
		// (get) Token: 0x06000322 RID: 802 RVA: 0x0000897C File Offset: 0x00006B7C
		public static ImmutableStack<T> Empty
		{
			get
			{
				return ImmutableStack<T>.s_EmptyField;
			}
		}

		// Token: 0x06000323 RID: 803 RVA: 0x00008983 File Offset: 0x00006B83
		public ImmutableStack<T> Clear()
		{
			return ImmutableStack<T>.Empty;
		}

		// Token: 0x06000324 RID: 804 RVA: 0x0000898A File Offset: 0x00006B8A
		IImmutableStack<T> IImmutableStack<!0>.Clear()
		{
			return this.Clear();
		}

		// Token: 0x17000086 RID: 134
		// (get) Token: 0x06000325 RID: 805 RVA: 0x00008992 File Offset: 0x00006B92
		public bool IsEmpty
		{
			get
			{
				return this._tail == null;
			}
		}

		// Token: 0x06000326 RID: 806 RVA: 0x0000899D File Offset: 0x00006B9D
		public T Peek()
		{
			if (this.IsEmpty)
			{
				throw new InvalidOperationException(SR.InvalidEmptyOperation);
			}
			return this._head;
		}

		// Token: 0x06000327 RID: 807 RVA: 0x000089B8 File Offset: 0x00006BB8
		public ImmutableStack<T> Push(T value)
		{
			return new ImmutableStack<T>(value, this);
		}

		// Token: 0x06000328 RID: 808 RVA: 0x000089C1 File Offset: 0x00006BC1
		IImmutableStack<T> IImmutableStack<!0>.Push(T value)
		{
			return this.Push(value);
		}

		// Token: 0x06000329 RID: 809 RVA: 0x000089CA File Offset: 0x00006BCA
		public ImmutableStack<T> Pop()
		{
			if (this.IsEmpty)
			{
				throw new InvalidOperationException(SR.InvalidEmptyOperation);
			}
			return this._tail;
		}

		// Token: 0x0600032A RID: 810 RVA: 0x000089E5 File Offset: 0x00006BE5
		public ImmutableStack<T> Pop(out T value)
		{
			value = this.Peek();
			return this.Pop();
		}

		// Token: 0x0600032B RID: 811 RVA: 0x000089F9 File Offset: 0x00006BF9
		IImmutableStack<T> IImmutableStack<!0>.Pop()
		{
			return this.Pop();
		}

		// Token: 0x0600032C RID: 812 RVA: 0x00008A01 File Offset: 0x00006C01
		public ImmutableStack<T>.Enumerator GetEnumerator()
		{
			return new ImmutableStack<T>.Enumerator(this);
		}

		// Token: 0x0600032D RID: 813 RVA: 0x00008A09 File Offset: 0x00006C09
		IEnumerator<T> IEnumerable<!0>.GetEnumerator()
		{
			return new ImmutableStack<T>.EnumeratorObject(this);
		}

		// Token: 0x0600032E RID: 814 RVA: 0x00008A09 File Offset: 0x00006C09
		IEnumerator IEnumerable.GetEnumerator()
		{
			return new ImmutableStack<T>.EnumeratorObject(this);
		}

		// Token: 0x0600032F RID: 815 RVA: 0x00008A14 File Offset: 0x00006C14
		internal ImmutableStack<T> Reverse()
		{
			ImmutableStack<T> immutableStack = this.Clear();
			ImmutableStack<T> immutableStack2 = this;
			while (!immutableStack2.IsEmpty)
			{
				immutableStack = immutableStack.Push(immutableStack2.Peek());
				immutableStack2 = immutableStack2.Pop();
			}
			return immutableStack;
		}

		// Token: 0x04000032 RID: 50
		private static readonly ImmutableStack<T> s_EmptyField = new ImmutableStack<T>();

		// Token: 0x04000033 RID: 51
		private readonly T _head;

		// Token: 0x04000034 RID: 52
		private readonly ImmutableStack<T> _tail;

		// Token: 0x0200006A RID: 106
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public struct Enumerator
		{
			// Token: 0x060005EC RID: 1516 RVA: 0x0001013C File Offset: 0x0000E33C
			internal Enumerator(ImmutableStack<T> stack)
			{
				Requires.NotNull<ImmutableStack<T>>(stack, "stack");
				this._originalStack = stack;
				this._remainingStack = null;
			}

			// Token: 0x1700013A RID: 314
			// (get) Token: 0x060005ED RID: 1517 RVA: 0x00010157 File Offset: 0x0000E357
			public T Current
			{
				get
				{
					if (this._remainingStack == null || this._remainingStack.IsEmpty)
					{
						throw new InvalidOperationException();
					}
					return this._remainingStack.Peek();
				}
			}

			// Token: 0x060005EE RID: 1518 RVA: 0x00010180 File Offset: 0x0000E380
			public bool MoveNext()
			{
				if (this._remainingStack == null)
				{
					this._remainingStack = this._originalStack;
				}
				else if (!this._remainingStack.IsEmpty)
				{
					this._remainingStack = this._remainingStack.Pop();
				}
				return !this._remainingStack.IsEmpty;
			}

			// Token: 0x040000EC RID: 236
			private readonly ImmutableStack<T> _originalStack;

			// Token: 0x040000ED RID: 237
			private ImmutableStack<T> _remainingStack;
		}

		// Token: 0x0200006B RID: 107
		private class EnumeratorObject : IEnumerator<!0>, IEnumerator, IDisposable
		{
			// Token: 0x060005EF RID: 1519 RVA: 0x000101CF File Offset: 0x0000E3CF
			internal EnumeratorObject(ImmutableStack<T> stack)
			{
				Requires.NotNull<ImmutableStack<T>>(stack, "stack");
				this._originalStack = stack;
			}

			// Token: 0x1700013B RID: 315
			// (get) Token: 0x060005F0 RID: 1520 RVA: 0x000101E9 File Offset: 0x0000E3E9
			public T Current
			{
				get
				{
					this.ThrowIfDisposed();
					if (this._remainingStack == null || this._remainingStack.IsEmpty)
					{
						throw new InvalidOperationException();
					}
					return this._remainingStack.Peek();
				}
			}

			// Token: 0x1700013C RID: 316
			// (get) Token: 0x060005F1 RID: 1521 RVA: 0x00010217 File Offset: 0x0000E417
			object IEnumerator.Current
			{
				get
				{
					return this.Current;
				}
			}

			// Token: 0x060005F2 RID: 1522 RVA: 0x00010224 File Offset: 0x0000E424
			public bool MoveNext()
			{
				this.ThrowIfDisposed();
				if (this._remainingStack == null)
				{
					this._remainingStack = this._originalStack;
				}
				else if (!this._remainingStack.IsEmpty)
				{
					this._remainingStack = this._remainingStack.Pop();
				}
				return !this._remainingStack.IsEmpty;
			}

			// Token: 0x060005F3 RID: 1523 RVA: 0x00010279 File Offset: 0x0000E479
			public void Reset()
			{
				this.ThrowIfDisposed();
				this._remainingStack = null;
			}

			// Token: 0x060005F4 RID: 1524 RVA: 0x00010288 File Offset: 0x0000E488
			public void Dispose()
			{
				this._disposed = true;
			}

			// Token: 0x060005F5 RID: 1525 RVA: 0x00010291 File Offset: 0x0000E491
			private void ThrowIfDisposed()
			{
				if (this._disposed)
				{
					Requires.FailObjectDisposed<ImmutableStack<T>.EnumeratorObject>(this);
				}
			}

			// Token: 0x040000EE RID: 238
			private readonly ImmutableStack<T> _originalStack;

			// Token: 0x040000EF RID: 239
			private ImmutableStack<T> _remainingStack;

			// Token: 0x040000F0 RID: 240
			private bool _disposed;
		}
	}
}
