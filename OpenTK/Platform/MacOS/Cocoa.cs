using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace OpenTK.Platform.MacOS
{
	// Token: 0x02000B1D RID: 2845
	internal static class Cocoa
	{
		// Token: 0x06005A45 RID: 23109
		[DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
		public static extern IntPtr SendIntPtr(IntPtr receiver, IntPtr selector);

		// Token: 0x06005A46 RID: 23110
		[DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
		public static extern IntPtr SendIntPtr(IntPtr receiver, IntPtr selector, ulong ulong1);

		// Token: 0x06005A47 RID: 23111
		[DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
		public static extern IntPtr SendIntPtr(IntPtr receiver, IntPtr selector, NSSize size);

		// Token: 0x06005A48 RID: 23112
		[DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
		public static extern IntPtr SendIntPtr(IntPtr receiver, IntPtr selector, IntPtr intPtr1);

		// Token: 0x06005A49 RID: 23113
		[DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
		public static extern IntPtr SendIntPtr(IntPtr receiver, IntPtr selector, IntPtr intPtr1, int int1);

		// Token: 0x06005A4A RID: 23114
		[DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
		public static extern IntPtr SendIntPtr(IntPtr receiver, IntPtr selector, IntPtr intPtr1, IntPtr intPtr2);

		// Token: 0x06005A4B RID: 23115
		[DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
		public static extern IntPtr SendIntPtr(IntPtr receiver, IntPtr selector, IntPtr intPtr1, IntPtr intPtr2, IntPtr intPtr3);

		// Token: 0x06005A4C RID: 23116
		[DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
		public static extern IntPtr SendIntPtr(IntPtr receiver, IntPtr selector, IntPtr intPtr1, IntPtr intPtr2, IntPtr intPtr3, IntPtr intPtr4, IntPtr intPtr5);

		// Token: 0x06005A4D RID: 23117
		[DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
		public static extern IntPtr SendIntPtr(IntPtr receiver, IntPtr selector, IntPtr p1, NSPoint p2);

		// Token: 0x06005A4E RID: 23118
		[DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
		public static extern IntPtr SendIntPtr(IntPtr receiver, IntPtr selector, bool p1);

		// Token: 0x06005A4F RID: 23119
		[DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
		public static extern IntPtr SendIntPtr(IntPtr receiver, IntPtr selector, NSPoint p1);

		// Token: 0x06005A50 RID: 23120
		[DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
		public static extern IntPtr SendIntPtr(IntPtr receiver, IntPtr selector, NSRect rectangle1);

		// Token: 0x06005A51 RID: 23121
		[DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
		public static extern IntPtr SendIntPtr(IntPtr receiver, IntPtr selector, NSRect rectangle1, int int1, int int2, bool bool1);

		// Token: 0x06005A52 RID: 23122
		[DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
		public static extern IntPtr SendIntPtr(IntPtr receiver, IntPtr selector, uint uint1, IntPtr intPtr1, IntPtr intPtr2, bool bool1);

		// Token: 0x06005A53 RID: 23123
		[DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
		public static extern IntPtr SendIntPtr(IntPtr receiver, IntPtr selector, NSRect rectangle1, int int1, IntPtr intPtr1, IntPtr intPtr2);

		// Token: 0x06005A54 RID: 23124
		[DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
		public static extern IntPtr SendIntPtr(IntPtr receiver, IntPtr selector, IntPtr p1, int p2, int p3, int p4, int p5, int p6, int p7, IntPtr p8, NSBitmapFormat p9, int p10, int p11);

		// Token: 0x06005A55 RID: 23125
		[DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
		public static extern bool SendBool(IntPtr receiver, IntPtr selector);

		// Token: 0x06005A56 RID: 23126
		[DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
		public static extern bool SendBool(IntPtr receiver, IntPtr selector, int int1);

		// Token: 0x06005A57 RID: 23127
		[DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
		public static extern void SendVoid(IntPtr receiver, IntPtr selector);

		// Token: 0x06005A58 RID: 23128
		[DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
		public static extern void SendVoid(IntPtr receiver, IntPtr selector, uint uint1);

		// Token: 0x06005A59 RID: 23129
		[DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
		public static extern void SendVoid(IntPtr receiver, IntPtr selector, IntPtr intPtr1);

		// Token: 0x06005A5A RID: 23130
		[DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
		public static extern void SendVoid(IntPtr receiver, IntPtr selector, IntPtr intPtr1, int int1);

		// Token: 0x06005A5B RID: 23131
		[DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
		public static extern void SendVoid(IntPtr receiver, IntPtr selector, IntPtr intPtr1, IntPtr intPtr2);

		// Token: 0x06005A5C RID: 23132
		[DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
		public static extern void SendVoid(IntPtr receiver, IntPtr selector, int int1);

		// Token: 0x06005A5D RID: 23133
		[DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
		public static extern void SendVoid(IntPtr receiver, IntPtr selector, bool bool1);

		// Token: 0x06005A5E RID: 23134
		[DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
		public static extern void SendVoid(IntPtr receiver, IntPtr selector, NSPoint point1);

		// Token: 0x06005A5F RID: 23135
		[DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
		public static extern void SendVoid(IntPtr receiver, IntPtr selector, NSRect rect1, bool bool1);

		// Token: 0x06005A60 RID: 23136
		[DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
		public static extern void SendVoid(IntPtr receiver, IntPtr selector, NSRect rect1, IntPtr intPtr1);

		// Token: 0x06005A61 RID: 23137
		[DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
		public static extern int SendInt(IntPtr receiver, IntPtr selector);

		// Token: 0x06005A62 RID: 23138
		[DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
		public static extern uint SendUint(IntPtr receiver, IntPtr selector);

		// Token: 0x06005A63 RID: 23139
		[DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
		public static extern ushort SendUshort(IntPtr receiver, IntPtr selector);

		// Token: 0x06005A64 RID: 23140
		[DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend_fpret")]
		private static extern float SendFloat_i386(IntPtr receiver, IntPtr selector);

		// Token: 0x06005A65 RID: 23141
		[DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
		private static extern float SendFloat_normal(IntPtr receiver, IntPtr selector);

		// Token: 0x06005A66 RID: 23142 RVA: 0x000F5BF4 File Offset: 0x000F3DF4
		public static float SendFloat(IntPtr receiver, IntPtr selector)
		{
			if (IntPtr.Size == 4)
			{
				return Cocoa.SendFloat_i386(receiver, selector);
			}
			return Cocoa.SendFloat_normal(receiver, selector);
		}

		// Token: 0x06005A67 RID: 23143
		[DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
		public static extern NSPoint SendPoint(IntPtr receiver, IntPtr selector);

		// Token: 0x06005A68 RID: 23144
		[DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend_stret")]
		private static extern void SendRect(out NSRect retval, IntPtr receiver, IntPtr selector);

		// Token: 0x06005A69 RID: 23145
		[DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend_stret")]
		private static extern void SendRect(out NSRect retval, IntPtr receiver, IntPtr selector, NSRect rect1);

		// Token: 0x06005A6A RID: 23146 RVA: 0x000F5C10 File Offset: 0x000F3E10
		public static NSRect SendRect(IntPtr receiver, IntPtr selector)
		{
			NSRect result;
			Cocoa.SendRect(out result, receiver, selector);
			return result;
		}

		// Token: 0x06005A6B RID: 23147 RVA: 0x000F5C28 File Offset: 0x000F3E28
		public static NSRect SendRect(IntPtr receiver, IntPtr selector, NSRect rect1)
		{
			NSRect result;
			Cocoa.SendRect(out result, receiver, selector, rect1);
			return result;
		}

		// Token: 0x06005A6C RID: 23148 RVA: 0x000F5C40 File Offset: 0x000F3E40
		public unsafe static IntPtr ToNSString(string str)
		{
			if (str == null)
			{
				return IntPtr.Zero;
			}
			IntPtr intPtr2;
			IntPtr intPtr = intPtr2 = str;
			if (intPtr != 0)
			{
				intPtr2 = (IntPtr)((int)intPtr + RuntimeHelpers.OffsetToStringData);
			}
			char* value = intPtr2;
			IntPtr receiver = Cocoa.SendIntPtr(Class.Get("NSString"), Selector.Alloc);
			return Cocoa.SendIntPtr(receiver, Selector.Get("initWithCharacters:length:"), (IntPtr)((void*)value), str.Length);
		}

		// Token: 0x06005A6D RID: 23149 RVA: 0x000F5C9C File Offset: 0x000F3E9C
		public static string FromNSString(IntPtr handle)
		{
			return Marshal.PtrToStringAuto(Cocoa.SendIntPtr(handle, Cocoa.selUTF8String));
		}

		// Token: 0x06005A6E RID: 23150 RVA: 0x000F5CB0 File Offset: 0x000F3EB0
		public unsafe static IntPtr ToNSImage(Image img)
		{
			IntPtr result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				img.Save(memoryStream, ImageFormat.Png);
				byte[] array = memoryStream.ToArray();
				try
				{
					fixed (byte* ptr = array)
					{
						IntPtr intPtr = Cocoa.SendIntPtr(Cocoa.SendIntPtr(Cocoa.SendIntPtr(Class.Get("NSData"), Selector.Alloc), Selector.Get("initWithBytes:length:"), (IntPtr)((void*)ptr), array.Length), Selector.Autorelease);
						IntPtr intPtr2 = Cocoa.SendIntPtr(Cocoa.SendIntPtr(Cocoa.SendIntPtr(Class.Get("NSImage"), Selector.Alloc), Selector.Get("initWithData:"), intPtr), Selector.Autorelease);
						result = intPtr2;
					}
				}
				finally
				{
					byte* ptr = null;
				}
			}
			return result;
		}

		// Token: 0x06005A6F RID: 23151 RVA: 0x000F5D8C File Offset: 0x000F3F8C
		public static IntPtr GetStringConstant(IntPtr handle, string symbol)
		{
			IntPtr symbol2 = NS.GetSymbol(handle, symbol);
			if (symbol2 == IntPtr.Zero)
			{
				return IntPtr.Zero;
			}
			IntPtr intPtr = Marshal.ReadIntPtr(symbol2);
			if (intPtr == IntPtr.Zero)
			{
				return IntPtr.Zero;
			}
			return intPtr;
		}

		// Token: 0x06005A70 RID: 23152 RVA: 0x000F5DD0 File Offset: 0x000F3FD0
		public static void Initialize()
		{
			if (Cocoa.AppKitLibrary != IntPtr.Zero)
			{
				return;
			}
			Cocoa.AppKitLibrary = NS.LoadLibrary("/System/Library/Frameworks/AppKit.framework/AppKit");
			Cocoa.FoundationLibrary = NS.LoadLibrary("/System/Library/Frameworks/Foundation.framework/Foundation");
		}

		// Token: 0x0400B545 RID: 46405
		internal const string LibObjC = "/usr/lib/libobjc.dylib";

		// Token: 0x0400B546 RID: 46406
		private static readonly IntPtr selUTF8String = Selector.Get("UTF8String");

		// Token: 0x0400B547 RID: 46407
		public static IntPtr AppKitLibrary;

		// Token: 0x0400B548 RID: 46408
		public static IntPtr FoundationLibrary;
	}
}
