using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace OpenTK.Platform.MacOS
{
	// Token: 0x02000B1E RID: 2846
	internal static class Class
	{
		// Token: 0x06005A72 RID: 23154
		[DllImport("/usr/lib/libobjc.dylib")]
		private static extern IntPtr class_getName(IntPtr handle);

		// Token: 0x06005A73 RID: 23155
		[DllImport("/usr/lib/libobjc.dylib")]
		private static extern bool class_addMethod(IntPtr classHandle, IntPtr selector, IntPtr method, string types);

		// Token: 0x06005A74 RID: 23156
		[DllImport("/usr/lib/libobjc.dylib")]
		private static extern IntPtr objc_getClass(string name);

		// Token: 0x06005A75 RID: 23157
		[DllImport("/usr/lib/libobjc.dylib")]
		private static extern IntPtr objc_allocateClassPair(IntPtr parentClass, string name, int extraBytes);

		// Token: 0x06005A76 RID: 23158
		[DllImport("/usr/lib/libobjc.dylib")]
		private static extern void objc_registerClassPair(IntPtr classToRegister);

		// Token: 0x06005A77 RID: 23159 RVA: 0x000F5E18 File Offset: 0x000F4018
		public static IntPtr Get(string name)
		{
			IntPtr intPtr = Class.objc_getClass(name);
			if (intPtr == IntPtr.Zero)
			{
				throw new ArgumentException("Unknown class: " + name);
			}
			return intPtr;
		}

		// Token: 0x06005A78 RID: 23160 RVA: 0x000F5E4C File Offset: 0x000F404C
		public static IntPtr AllocateClass(string className, string parentClass)
		{
			return Class.objc_allocateClassPair(Class.Get(parentClass), className, 0);
		}

		// Token: 0x06005A79 RID: 23161 RVA: 0x000F5E5C File Offset: 0x000F405C
		public static void RegisterClass(IntPtr handle)
		{
			Class.objc_registerClassPair(handle);
		}

		// Token: 0x06005A7A RID: 23162 RVA: 0x000F5E64 File Offset: 0x000F4064
		public static void RegisterMethod(IntPtr handle, Delegate d, string selector, string typeString)
		{
			IntPtr functionPointerForDelegate = Marshal.GetFunctionPointerForDelegate(d);
			if (!Class.class_addMethod(handle, Selector.Get(selector), functionPointerForDelegate, typeString))
			{
				throw new ArgumentException(string.Concat(new object[]
				{
					"Could not register method ",
					d,
					" in class + ",
					Class.class_getName(handle)
				}));
			}
			Class.storedDelegates.Add(d);
		}

		// Token: 0x0400B549 RID: 46409
		public static readonly IntPtr NSAutoreleasePool = Class.Get("NSAutoreleasePool");

		// Token: 0x0400B54A RID: 46410
		public static readonly IntPtr NSDictionary = Class.Get("NSDictionary");

		// Token: 0x0400B54B RID: 46411
		public static readonly IntPtr NSNumber = Class.Get("NSNumber");

		// Token: 0x0400B54C RID: 46412
		public static readonly IntPtr NSUserDefaults = Class.Get("NSUserDefaults");

		// Token: 0x0400B54D RID: 46413
		private static List<Delegate> storedDelegates = new List<Delegate>();
	}
}
