using System;
using System.Runtime.CompilerServices;

namespace System.Collections.Immutable
{
	// Token: 0x0200003A RID: 58
	internal class SecurePooledObject<T>
	{
		// Token: 0x0600034B RID: 843 RVA: 0x00008CF3 File Offset: 0x00006EF3
		internal SecurePooledObject(T newValue)
		{
			Requires.NotNullAllowStructs<T>(newValue, "newValue");
			this._value = newValue;
		}

		// Token: 0x1700008D RID: 141
		// (get) Token: 0x0600034C RID: 844 RVA: 0x00008D0D File Offset: 0x00006F0D
		// (set) Token: 0x0600034D RID: 845 RVA: 0x00008D15 File Offset: 0x00006F15
		internal int Owner
		{
			get
			{
				return this._owner;
			}
			set
			{
				this._owner = value;
			}
		}

		// Token: 0x0600034E RID: 846 RVA: 0x00008D1E File Offset: 0x00006F1E
		internal T Use<TCaller>(ref TCaller caller) where TCaller : struct, ISecurePooledObjectUser
		{
			if (!this.IsOwned<TCaller>(ref caller))
			{
				Requires.FailObjectDisposed<TCaller>(caller);
			}
			return this._value;
		}

		// Token: 0x0600034F RID: 847 RVA: 0x00008D3A File Offset: 0x00006F3A
		internal bool TryUse<TCaller>(ref TCaller caller, out T value) where TCaller : struct, ISecurePooledObjectUser
		{
			if (this.IsOwned<TCaller>(ref caller))
			{
				value = this._value;
				return true;
			}
			value = default(T);
			return false;
		}

		// Token: 0x06000350 RID: 848 RVA: 0x00008D5B File Offset: 0x00006F5B
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal bool IsOwned<TCaller>(ref TCaller caller) where TCaller : struct, ISecurePooledObjectUser
		{
			return caller.PoolUserId == this._owner;
		}

		// Token: 0x0400003A RID: 58
		private readonly T _value;

		// Token: 0x0400003B RID: 59
		private int _owner;
	}
}
