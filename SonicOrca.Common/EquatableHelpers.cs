using System;

namespace SonicOrca
{
	// Token: 0x02000005 RID: 5
	public static class EquatableHelpers
	{
		// Token: 0x06000007 RID: 7 RVA: 0x000020FF File Offset: 0x000002FF
		public static bool ReferenceThenValueEquals<T>(T a, T b) where T : IEquatable<T>
		{
			return a == b || (a != null && b != null && a.Equals(b));
		}
	}
}
