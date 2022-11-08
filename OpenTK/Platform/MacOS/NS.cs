using System;
using System.Runtime.InteropServices;

namespace OpenTK.Platform.MacOS
{
	// Token: 0x02000AF8 RID: 2808
	internal class NS
	{
		// Token: 0x06005910 RID: 22800
		[DllImport("libdl.dylib", EntryPoint = "NSAddImage")]
		internal static extern IntPtr AddImage(string s, AddImageFlags flags);

		// Token: 0x06005911 RID: 22801
		[DllImport("libdl.dylib", EntryPoint = "NSAddressOfSymbol")]
		internal static extern IntPtr AddressOfSymbol(IntPtr symbol);

		// Token: 0x06005912 RID: 22802
		[DllImport("libdl.dylib", EntryPoint = "NSIsSymbolNameDefined")]
		internal static extern bool IsSymbolNameDefined(string s);

		// Token: 0x06005913 RID: 22803
		[DllImport("libdl.dylib", EntryPoint = "NSIsSymbolNameDefined")]
		internal static extern bool IsSymbolNameDefined(IntPtr s);

		// Token: 0x06005914 RID: 22804
		[DllImport("libdl.dylib", EntryPoint = "NSLookupAndBindSymbol")]
		internal static extern IntPtr LookupAndBindSymbol(string s);

		// Token: 0x06005915 RID: 22805
		[DllImport("libdl.dylib", EntryPoint = "NSLookupAndBindSymbol")]
		internal static extern IntPtr LookupAndBindSymbol(IntPtr s);

		// Token: 0x06005916 RID: 22806
		[DllImport("libdl.dylib", EntryPoint = "NSLookupSymbolInImage")]
		internal static extern IntPtr LookupSymbolInImage(IntPtr image, IntPtr symbolName, SymbolLookupFlags options);

		// Token: 0x06005917 RID: 22807
		[DllImport("libdl.dylib")]
		internal static extern IntPtr dlopen(string fileName, int flags);

		// Token: 0x06005918 RID: 22808
		[DllImport("libdl.dylib")]
		internal static extern int dlclose(IntPtr handle);

		// Token: 0x06005919 RID: 22809
		[DllImport("libdl.dylib")]
		internal static extern IntPtr dlsym(IntPtr handle, string symbol);

		// Token: 0x0600591A RID: 22810
		[DllImport("libdl.dylib")]
		internal static extern IntPtr dlsym(IntPtr handle, IntPtr symbol);

		// Token: 0x0600591B RID: 22811 RVA: 0x000F24E8 File Offset: 0x000F06E8
		public static IntPtr GetAddress(string function)
		{
			IntPtr intPtr = Marshal.AllocHGlobal(function.Length + 2);
			IntPtr result;
			try
			{
				Marshal.WriteByte(intPtr, 95);
				for (int i = 0; i < function.Length; i++)
				{
					Marshal.WriteByte(intPtr, i + 1, (byte)function[i]);
				}
				Marshal.WriteByte(intPtr, function.Length + 1, 0);
				IntPtr addressInternal = NS.GetAddressInternal(intPtr);
				result = addressInternal;
			}
			finally
			{
				Marshal.FreeHGlobal(intPtr);
			}
			return result;
		}

		// Token: 0x0600591C RID: 22812 RVA: 0x000F2560 File Offset: 0x000F0760
		public unsafe static IntPtr GetAddress(IntPtr function)
		{
			byte* ptr = stackalloc byte[(UIntPtr)64];
			byte* ptr2 = ptr;
			byte* ptr3 = (byte*)function.ToPointer();
			int num = 0;
			*(ptr2++) = 95;
			while (*ptr3 != 0 && ++num < 64)
			{
				*(ptr2++) = *(ptr3++);
			}
			if (num >= 63)
			{
				throw new NotSupportedException(string.Format("Function {0} is too long. Please report a bug at https://github.com/opentk/issues/issues", Marshal.PtrToStringAnsi(function)));
			}
			return NS.GetAddressInternal(new IntPtr((void*)ptr));
		}

		// Token: 0x0600591D RID: 22813 RVA: 0x000F25CC File Offset: 0x000F07CC
		private static IntPtr GetAddressInternal(IntPtr function)
		{
			IntPtr intPtr = IntPtr.Zero;
			if (NS.IsSymbolNameDefined(function))
			{
				intPtr = NS.LookupAndBindSymbol(function);
				if (intPtr != IntPtr.Zero)
				{
					intPtr = NS.AddressOfSymbol(intPtr);
				}
			}
			return intPtr;
		}

		// Token: 0x0600591E RID: 22814 RVA: 0x000F2604 File Offset: 0x000F0804
		public static IntPtr GetSymbol(IntPtr handle, string symbol)
		{
			return NS.dlsym(handle, symbol);
		}

		// Token: 0x0600591F RID: 22815 RVA: 0x000F2610 File Offset: 0x000F0810
		public static IntPtr GetSymbol(IntPtr handle, IntPtr symbol)
		{
			return NS.dlsym(handle, symbol);
		}

		// Token: 0x06005920 RID: 22816 RVA: 0x000F261C File Offset: 0x000F081C
		public static IntPtr LoadLibrary(string fileName)
		{
			return NS.dlopen(fileName, 2);
		}

		// Token: 0x06005921 RID: 22817 RVA: 0x000F2628 File Offset: 0x000F0828
		public static void FreeLibrary(IntPtr handle)
		{
			NS.dlclose(handle);
		}

		// Token: 0x0400B490 RID: 46224
		private const string Library = "libdl.dylib";
	}
}
