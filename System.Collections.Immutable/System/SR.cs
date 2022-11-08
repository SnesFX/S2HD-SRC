using System;
using System.Resources;
using System.Runtime.CompilerServices;
using FxResources.System.Collections.Immutable;

namespace System
{
	// Token: 0x02000003 RID: 3
	internal static class SR
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		private static ResourceManager ResourceManager
		{
			get
			{
				ResourceManager result;
				if ((result = System.SR.s_resourceManager) == null)
				{
					result = (System.SR.s_resourceManager = new ResourceManager(System.SR.ResourceType));
				}
				return result;
			}
		}

		// Token: 0x06000002 RID: 2 RVA: 0x0000206B File Offset: 0x0000026B
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static bool UsingResourceKeys()
		{
			return false;
		}

		// Token: 0x06000003 RID: 3 RVA: 0x00002070 File Offset: 0x00000270
		internal static string GetResourceString(string resourceKey, string defaultString)
		{
			string text = null;
			try
			{
				text = System.SR.ResourceManager.GetString(resourceKey);
			}
			catch (MissingManifestResourceException)
			{
			}
			if (defaultString != null && resourceKey.Equals(text, StringComparison.Ordinal))
			{
				return defaultString;
			}
			return text;
		}

		// Token: 0x06000004 RID: 4 RVA: 0x000020B0 File Offset: 0x000002B0
		internal static string Format(string resourceFormat, params object[] args)
		{
			if (args == null)
			{
				return resourceFormat;
			}
			if (System.SR.UsingResourceKeys())
			{
				return resourceFormat + string.Join(", ", args);
			}
			return string.Format(resourceFormat, args);
		}

		// Token: 0x06000005 RID: 5 RVA: 0x000020D7 File Offset: 0x000002D7
		internal static string Format(string resourceFormat, object p1)
		{
			if (System.SR.UsingResourceKeys())
			{
				return string.Join(", ", new object[]
				{
					resourceFormat,
					p1
				});
			}
			return string.Format(resourceFormat, new object[]
			{
				p1
			});
		}

		// Token: 0x06000006 RID: 6 RVA: 0x00002109 File Offset: 0x00000309
		internal static string Format(string resourceFormat, object p1, object p2)
		{
			if (System.SR.UsingResourceKeys())
			{
				return string.Join(", ", new object[]
				{
					resourceFormat,
					p1,
					p2
				});
			}
			return string.Format(resourceFormat, new object[]
			{
				p1,
				p2
			});
		}

		// Token: 0x06000007 RID: 7 RVA: 0x00002144 File Offset: 0x00000344
		internal static string Format(string resourceFormat, object p1, object p2, object p3)
		{
			if (System.SR.UsingResourceKeys())
			{
				return string.Join(", ", new object[]
				{
					resourceFormat,
					p1,
					p2,
					p3
				});
			}
			return string.Format(resourceFormat, new object[]
			{
				p1,
				p2,
				p3
			});
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000008 RID: 8 RVA: 0x00002191 File Offset: 0x00000391
		internal static string ArrayInitializedStateNotEqual
		{
			get
			{
				return System.SR.GetResourceString("ArrayInitializedStateNotEqual", null);
			}
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000009 RID: 9 RVA: 0x0000219E File Offset: 0x0000039E
		internal static string ArrayLengthsNotEqual
		{
			get
			{
				return System.SR.GetResourceString("ArrayLengthsNotEqual", null);
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x0600000A RID: 10 RVA: 0x000021AB File Offset: 0x000003AB
		internal static string CannotFindOldValue
		{
			get
			{
				return System.SR.GetResourceString("CannotFindOldValue", null);
			}
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600000B RID: 11 RVA: 0x000021B8 File Offset: 0x000003B8
		internal static string CapacityMustBeGreaterThanOrEqualToCount
		{
			get
			{
				return System.SR.GetResourceString("CapacityMustBeGreaterThanOrEqualToCount", null);
			}
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600000C RID: 12 RVA: 0x000021C5 File Offset: 0x000003C5
		internal static string CapacityMustEqualCountOnMove
		{
			get
			{
				return System.SR.GetResourceString("CapacityMustEqualCountOnMove", null);
			}
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x0600000D RID: 13 RVA: 0x000021D2 File Offset: 0x000003D2
		internal static string CollectionModifiedDuringEnumeration
		{
			get
			{
				return System.SR.GetResourceString("CollectionModifiedDuringEnumeration", null);
			}
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x0600000E RID: 14 RVA: 0x000021DF File Offset: 0x000003DF
		internal static string DuplicateKey
		{
			get
			{
				return System.SR.GetResourceString("DuplicateKey", null);
			}
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x0600000F RID: 15 RVA: 0x000021EC File Offset: 0x000003EC
		internal static string InvalidEmptyOperation
		{
			get
			{
				return System.SR.GetResourceString("InvalidEmptyOperation", null);
			}
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000010 RID: 16 RVA: 0x000021F9 File Offset: 0x000003F9
		internal static string InvalidOperationOnDefaultArray
		{
			get
			{
				return System.SR.GetResourceString("InvalidOperationOnDefaultArray", null);
			}
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000011 RID: 17 RVA: 0x00002206 File Offset: 0x00000406
		internal static Type ResourceType
		{
			get
			{
				return typeof(FxResources.System.Collections.Immutable.SR);
			}
		}

		// Token: 0x04000001 RID: 1
		private static ResourceManager s_resourceManager;

		// Token: 0x04000002 RID: 2
		private const string s_resourcesName = "FxResources.System.Collections.Immutable.SR";
	}
}
