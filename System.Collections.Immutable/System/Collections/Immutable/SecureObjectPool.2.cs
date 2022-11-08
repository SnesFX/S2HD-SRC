using System;

namespace System.Collections.Immutable
{
	// Token: 0x02000038 RID: 56
	internal class SecureObjectPool<T, TCaller> where TCaller : ISecurePooledObjectUser
	{
		// Token: 0x06000346 RID: 838 RVA: 0x00008C65 File Offset: 0x00006E65
		public void TryAdd(TCaller caller, SecurePooledObject<T> item)
		{
			if (caller.PoolUserId == item.Owner)
			{
				item.Owner = -1;
				AllocFreeConcurrentStack<SecurePooledObject<T>>.TryAdd(item);
			}
		}

		// Token: 0x06000347 RID: 839 RVA: 0x00008C89 File Offset: 0x00006E89
		public bool TryTake(TCaller caller, out SecurePooledObject<T> item)
		{
			if (caller.PoolUserId != -1 && AllocFreeConcurrentStack<SecurePooledObject<T>>.TryTake(out item))
			{
				item.Owner = caller.PoolUserId;
				return true;
			}
			item = null;
			return false;
		}

		// Token: 0x06000348 RID: 840 RVA: 0x00008CC0 File Offset: 0x00006EC0
		public SecurePooledObject<T> PrepNew(TCaller caller, T newValue)
		{
			Requires.NotNullAllowStructs<T>(newValue, "newValue");
			return new SecurePooledObject<T>(newValue)
			{
				Owner = caller.PoolUserId
			};
		}
	}
}
