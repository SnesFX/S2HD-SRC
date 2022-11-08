using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace std
{
	// Token: 0x020001C1 RID: 449
	[NativeCppClass]
	[UnsafeValueType]
	[StructLayout(LayoutKind.Sequential, Size = 32)]
	internal struct basic_string<char,std::char_traits<char>,std::allocator<char>\u0020>
	{
		// Token: 0x060000E3 RID: 227 RVA: 0x00002338 File Offset: 0x00001738
		public unsafe static void <MarshalCopy>(basic_string<char,std::char_traits<char>,std::allocator<char>\u0020>* A_0, basic_string<char,std::char_traits<char>,std::allocator<char>\u0020>* A_1)
		{
			try
			{
				*(long*)(A_0 + 16L / (long)sizeof(basic_string<char,std::char_traits<char>,std::allocator<char>\u0020>)) = 0L;
				*(long*)(A_0 + 24L / (long)sizeof(basic_string<char,std::char_traits<char>,std::allocator<char>\u0020>)) = 0L;
			}
			catch
			{
				<Module>.___CxxCallUnwindDtor(ldftn(std._String_val<std::_Simple_types<char>\u0020>._Bxty.{dtor}), (void*)A_0);
				throw;
			}
			try
			{
				<Module>.std.basic_string<char,std::char_traits<char>,std::allocator<char>\u0020>._Construct_lv_contents(A_0, A_1);
			}
			catch
			{
				<Module>.___CxxCallUnwindDtor(ldftn(std._String_alloc<std::_String_base_types<char,std::allocator<char>\u0020>\u0020>.{dtor}), (void*)A_0);
				throw;
			}
		}

		// Token: 0x060000E4 RID: 228 RVA: 0x000023B0 File Offset: 0x000017B0
		public unsafe static void <MarshalDestroy>(basic_string<char,std::char_traits<char>,std::allocator<char>\u0020>* A_0)
		{
			try
			{
				<Module>.std.basic_string<char,std::char_traits<char>,std::allocator<char>\u0020>._Tidy_deallocate(A_0);
			}
			catch
			{
				<Module>.___CxxCallUnwindDtor(ldftn(std._String_alloc<std::_String_base_types<char,std::allocator<char>\u0020>\u0020>.{dtor}), (void*)A_0);
				throw;
			}
		}

		// Token: 0x0400028D RID: 653
		private long <alignment\u0020member>;
	}
}
