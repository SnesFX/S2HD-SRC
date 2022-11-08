using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace System.Collections.Immutable
{
	// Token: 0x0200003C RID: 60
	internal static class Requires
	{
		// Token: 0x0600036F RID: 879 RVA: 0x000093CA File Offset: 0x000075CA
		[DebuggerStepThrough]
		public static void NotNull<T>([ValidatedNotNull] T value, string parameterName) where T : class
		{
			if (value == null)
			{
				Requires.FailArgumentNullException(parameterName);
			}
		}

		// Token: 0x06000370 RID: 880 RVA: 0x000093DA File Offset: 0x000075DA
		[DebuggerStepThrough]
		public static T NotNullPassthrough<T>([ValidatedNotNull] T value, string parameterName) where T : class
		{
			Requires.NotNull<T>(value, parameterName);
			return value;
		}

		// Token: 0x06000371 RID: 881 RVA: 0x000093E4 File Offset: 0x000075E4
		[DebuggerStepThrough]
		public static void NotNullAllowStructs<T>([ValidatedNotNull] T value, string parameterName)
		{
			if (value == null)
			{
				Requires.FailArgumentNullException(parameterName);
			}
		}

		// Token: 0x06000372 RID: 882 RVA: 0x000093F4 File Offset: 0x000075F4
		[DebuggerStepThrough]
		private static void FailArgumentNullException(string parameterName)
		{
			throw new ArgumentNullException(parameterName);
		}

		// Token: 0x06000373 RID: 883 RVA: 0x000093FC File Offset: 0x000075FC
		[DebuggerStepThrough]
		public static void Range(bool condition, string parameterName, string message = null)
		{
			if (!condition)
			{
				Requires.FailRange(parameterName, message);
			}
		}

		// Token: 0x06000374 RID: 884 RVA: 0x00009408 File Offset: 0x00007608
		[DebuggerStepThrough]
		public static void FailRange(string parameterName, string message = null)
		{
			if (string.IsNullOrEmpty(message))
			{
				throw new ArgumentOutOfRangeException(parameterName);
			}
			throw new ArgumentOutOfRangeException(parameterName, message);
		}

		// Token: 0x06000375 RID: 885 RVA: 0x00009420 File Offset: 0x00007620
		[DebuggerStepThrough]
		public static void Argument(bool condition, string parameterName, string message)
		{
			if (!condition)
			{
				throw new ArgumentException(message, parameterName);
			}
		}

		// Token: 0x06000376 RID: 886 RVA: 0x0000942D File Offset: 0x0000762D
		[DebuggerStepThrough]
		public static void Argument(bool condition)
		{
			if (!condition)
			{
				throw new ArgumentException();
			}
		}

		// Token: 0x06000377 RID: 887 RVA: 0x00009438 File Offset: 0x00007638
		[DebuggerStepThrough]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void FailObjectDisposed<TDisposed>(TDisposed disposed)
		{
			throw new ObjectDisposedException(disposed.GetType().FullName);
		}
	}
}
