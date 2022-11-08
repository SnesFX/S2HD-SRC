using System;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenTK.Platform.MacOS.Carbon
{
	// Token: 0x02000B4A RID: 2890
	internal class CF
	{
		// Token: 0x06005B01 RID: 23297
		[DllImport("/System/Library/Frameworks/ApplicationServices.framework/Versions/Current/ApplicationServices")]
		internal static extern int CFArrayGetCount(IntPtr theArray);

		// Token: 0x06005B02 RID: 23298
		[DllImport("/System/Library/Frameworks/ApplicationServices.framework/Versions/Current/ApplicationServices")]
		internal static extern IntPtr CFArrayGetValueAtIndex(IntPtr theArray, int idx);

		// Token: 0x06005B03 RID: 23299
		[DllImport("/System/Library/Frameworks/ApplicationServices.framework/Versions/Current/ApplicationServices")]
		internal static extern int CFDictionaryGetCount(IntPtr theDictionary);

		// Token: 0x06005B04 RID: 23300
		[DllImport("/System/Library/Frameworks/ApplicationServices.framework/Versions/Current/ApplicationServices")]
		internal static extern IntPtr CFDictionaryGetValue(IntPtr theDictionary, IntPtr theKey);

		// Token: 0x06005B05 RID: 23301
		[DllImport("/System/Library/Frameworks/ApplicationServices.framework/Versions/Current/ApplicationServices")]
		internal static extern void CFRelease(IntPtr cf);

		// Token: 0x06005B06 RID: 23302
		[DllImport("/System/Library/Frameworks/ApplicationServices.framework/Versions/Current/ApplicationServices")]
		private static extern IntPtr __CFStringMakeConstantString(string cStr);

		// Token: 0x06005B07 RID: 23303 RVA: 0x000F6980 File Offset: 0x000F4B80
		internal static IntPtr CFSTR(string cStr)
		{
			return CF.__CFStringMakeConstantString(cStr);
		}

		// Token: 0x06005B08 RID: 23304
		[DllImport("/System/Library/Frameworks/ApplicationServices.framework/Versions/Current/ApplicationServices")]
		internal static extern bool CFStringGetCString(IntPtr theString, byte[] buffer, IntPtr bufferSize, CF.CFStringEncoding encoding);

		// Token: 0x06005B09 RID: 23305 RVA: 0x000F6988 File Offset: 0x000F4B88
		internal static string CFStringGetCString(IntPtr cfstr)
		{
			IntPtr value = CF.CFStringGetLength(cfstr);
			if (value != IntPtr.Zero)
			{
				byte[] array = new byte[value.ToInt32() + 1];
				if (CF.CFStringGetCString(cfstr, array, new IntPtr(array.Length), CF.CFStringEncoding.UTF8))
				{
					return Encoding.UTF8.GetString(array);
				}
			}
			return string.Empty;
		}

		// Token: 0x06005B0A RID: 23306
		[DllImport("/System/Library/Frameworks/ApplicationServices.framework/Versions/Current/ApplicationServices")]
		internal static extern IntPtr CFStringGetLength(IntPtr theString);

		// Token: 0x06005B0B RID: 23307
		[DllImport("/System/Library/Frameworks/ApplicationServices.framework/Versions/Current/ApplicationServices")]
		internal static extern bool CFNumberGetValue(IntPtr number, CF.CFNumberType theType, out int valuePtr);

		// Token: 0x06005B0C RID: 23308
		[DllImport("/System/Library/Frameworks/ApplicationServices.framework/Versions/Current/ApplicationServices")]
		internal static extern bool CFNumberGetValue(IntPtr number, CF.CFNumberType theType, out long valuePtr);

		// Token: 0x06005B0D RID: 23309
		[DllImport("/System/Library/Frameworks/ApplicationServices.framework/Versions/Current/ApplicationServices")]
		internal static extern bool CFNumberGetValue(IntPtr number, CF.CFNumberType theType, out double valuePtr);

		// Token: 0x06005B0E RID: 23310
		[DllImport("/System/Library/Frameworks/ApplicationServices.framework/Versions/Current/ApplicationServices")]
		internal static extern IntPtr CFRunLoopGetCurrent();

		// Token: 0x06005B0F RID: 23311
		[DllImport("/System/Library/Frameworks/ApplicationServices.framework/Versions/Current/ApplicationServices")]
		internal static extern IntPtr CFRunLoopGetMain();

		// Token: 0x06005B10 RID: 23312
		[DllImport("/System/Library/Frameworks/ApplicationServices.framework/Versions/Current/ApplicationServices")]
		internal static extern CF.CFRunLoopExitReason CFRunLoopRunInMode(IntPtr cfstrMode, double interval, bool returnAfterSourceHandled);

		// Token: 0x06005B11 RID: 23313
		[DllImport("/System/Library/Frameworks/ApplicationServices.framework/Versions/Current/ApplicationServices", EntryPoint = "CFMachPortCreateRunLoopSource")]
		internal static extern IntPtr MachPortCreateRunLoopSource(IntPtr allocator, IntPtr port, IntPtr order);

		// Token: 0x06005B12 RID: 23314
		[DllImport("/System/Library/Frameworks/ApplicationServices.framework/Versions/Current/ApplicationServices", EntryPoint = "CFRunLoopAddSource")]
		internal static extern void RunLoopAddSource(IntPtr rl, IntPtr source, IntPtr mode);

		// Token: 0x0400B718 RID: 46872
		private const string appServices = "/System/Library/Frameworks/ApplicationServices.framework/Versions/Current/ApplicationServices";

		// Token: 0x0400B719 RID: 46873
		public static readonly IntPtr RunLoopModeDefault = CF.CFSTR("kCFRunLoopDefaultMode");

		// Token: 0x02000B4B RID: 2891
		internal enum CFNumberType
		{
			// Token: 0x0400B71B RID: 46875
			kCFNumberSInt8Type = 1,
			// Token: 0x0400B71C RID: 46876
			kCFNumberSInt16Type,
			// Token: 0x0400B71D RID: 46877
			kCFNumberSInt32Type,
			// Token: 0x0400B71E RID: 46878
			kCFNumberSInt64Type,
			// Token: 0x0400B71F RID: 46879
			kCFNumberFloat32Type,
			// Token: 0x0400B720 RID: 46880
			kCFNumberFloat64Type,
			// Token: 0x0400B721 RID: 46881
			kCFNumberCharType,
			// Token: 0x0400B722 RID: 46882
			kCFNumberShortType,
			// Token: 0x0400B723 RID: 46883
			kCFNumberIntType,
			// Token: 0x0400B724 RID: 46884
			kCFNumberLongType,
			// Token: 0x0400B725 RID: 46885
			kCFNumberLongLongType,
			// Token: 0x0400B726 RID: 46886
			kCFNumberFloatType,
			// Token: 0x0400B727 RID: 46887
			kCFNumberDoubleType,
			// Token: 0x0400B728 RID: 46888
			kCFNumberCFIndexType,
			// Token: 0x0400B729 RID: 46889
			kCFNumberNSIntegerType,
			// Token: 0x0400B72A RID: 46890
			kCFNumberCGFloatType,
			// Token: 0x0400B72B RID: 46891
			kCFNumberMaxType = 16
		}

		// Token: 0x02000B4C RID: 2892
		public enum CFRunLoopExitReason
		{
			// Token: 0x0400B72D RID: 46893
			Finished = 1,
			// Token: 0x0400B72E RID: 46894
			Stopped,
			// Token: 0x0400B72F RID: 46895
			TimedOut,
			// Token: 0x0400B730 RID: 46896
			HandledSource
		}

		// Token: 0x02000B4D RID: 2893
		public enum CFStringEncoding
		{
			// Token: 0x0400B732 RID: 46898
			MacRoman,
			// Token: 0x0400B733 RID: 46899
			WindowsLatin1 = 1280,
			// Token: 0x0400B734 RID: 46900
			ISOLatin1 = 513,
			// Token: 0x0400B735 RID: 46901
			NextStepLatin = 2817,
			// Token: 0x0400B736 RID: 46902
			ASCII = 1536,
			// Token: 0x0400B737 RID: 46903
			Unicode = 256,
			// Token: 0x0400B738 RID: 46904
			UTF8 = 134217984,
			// Token: 0x0400B739 RID: 46905
			NonLossyASCII = 3071,
			// Token: 0x0400B73A RID: 46906
			UTF16 = 256,
			// Token: 0x0400B73B RID: 46907
			UTF16BE = 268435712,
			// Token: 0x0400B73C RID: 46908
			UTF16LE = 335544576,
			// Token: 0x0400B73D RID: 46909
			UTF32 = 201326848,
			// Token: 0x0400B73E RID: 46910
			UTF32BE = 402653440,
			// Token: 0x0400B73F RID: 46911
			UTF32LE = 469762304
		}
	}
}
