using System;
using System.Collections.Generic;

namespace SonicOrca.Extensions
{
	// Token: 0x0200000A RID: 10
	public static class DictionaryExtensions
	{
		// Token: 0x06000013 RID: 19 RVA: 0x000022C8 File Offset: 0x000004C8
		public static Tvalue GetValueOrDefault<Tkey, Tvalue>(this IDictionary<Tkey, Tvalue> dictionary, Tkey key)
		{
			Tvalue result;
			if (!dictionary.TryGetValue(key, out result))
			{
				return default(Tvalue);
			}
			return result;
		}

		// Token: 0x06000014 RID: 20 RVA: 0x000022EC File Offset: 0x000004EC
		public static Tvalue GetValueOrDefault<Tkey, Tvalue>(this IDictionary<Tkey, Tvalue> dictionary, Tkey key, Tvalue defaultValue)
		{
			Tvalue result;
			if (!dictionary.TryGetValue(key, out result))
			{
				return defaultValue;
			}
			return result;
		}
	}
}
