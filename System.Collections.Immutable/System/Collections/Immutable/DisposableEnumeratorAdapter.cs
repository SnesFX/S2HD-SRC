using System;
using System.Collections.Generic;

namespace System.Collections.Immutable
{
	// Token: 0x0200000B RID: 11
	internal struct DisposableEnumeratorAdapter<T, TEnumerator> : IDisposable where TEnumerator : struct, IEnumerator<T>
	{
		// Token: 0x06000045 RID: 69 RVA: 0x00002BD8 File Offset: 0x00000DD8
		internal DisposableEnumeratorAdapter(TEnumerator enumerator)
		{
			this._enumeratorStruct = enumerator;
			this._enumeratorObject = null;
		}

		// Token: 0x06000046 RID: 70 RVA: 0x00002BE8 File Offset: 0x00000DE8
		internal DisposableEnumeratorAdapter(IEnumerator<T> enumerator)
		{
			this._enumeratorStruct = default(TEnumerator);
			this._enumeratorObject = enumerator;
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000047 RID: 71 RVA: 0x00002BFD File Offset: 0x00000DFD
		public T Current
		{
			get
			{
				if (this._enumeratorObject == null)
				{
					return this._enumeratorStruct.Current;
				}
				return this._enumeratorObject.Current;
			}
		}

		// Token: 0x06000048 RID: 72 RVA: 0x00002C24 File Offset: 0x00000E24
		public bool MoveNext()
		{
			if (this._enumeratorObject == null)
			{
				return this._enumeratorStruct.MoveNext();
			}
			return this._enumeratorObject.MoveNext();
		}

		// Token: 0x06000049 RID: 73 RVA: 0x00002C4B File Offset: 0x00000E4B
		public void Dispose()
		{
			if (this._enumeratorObject != null)
			{
				this._enumeratorObject.Dispose();
				return;
			}
			this._enumeratorStruct.Dispose();
		}

		// Token: 0x0600004A RID: 74 RVA: 0x00002C72 File Offset: 0x00000E72
		public DisposableEnumeratorAdapter<T, TEnumerator> GetEnumerator()
		{
			return this;
		}

		// Token: 0x04000007 RID: 7
		private readonly IEnumerator<T> _enumeratorObject;

		// Token: 0x04000008 RID: 8
		private TEnumerator _enumeratorStruct;
	}
}
