using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using System.Threading;
using <CppImplementationDetails>;
using <CrtImplementationDetails>;
using Accord.Math;
using Accord.Video;
using Accord.Video.FFMPEG;
using libffmpeg;
using std;

// Token: 0x02000001 RID: 1
internal class <Module>
{
	// Token: 0x06000001 RID: 1 RVA: 0x00001270 File Offset: 0x00000670
	internal unsafe static exception* {ctor}(exception* A_0, exception* _Other)
	{
		*A_0 = ref <Module>.??_7exception@std@@6B@;
		exception* ptr = A_0 + 8L;
		initblk(ptr, 0, 16L);
		<Module>.__std_exception_copy(_Other / sizeof(__std_exception_data) + 8L, ptr);
		return A_0;
	}

	// Token: 0x06000002 RID: 2 RVA: 0x0000129C File Offset: 0x0000069C
	internal unsafe static void {dtor}(exception* A_0)
	{
		*A_0 = ref <Module>.??_7exception@std@@6B@;
		<Module>.__std_exception_destroy(A_0 / sizeof(__std_exception_data) + 8L);
	}

	// Token: 0x06000003 RID: 3 RVA: 0x0000244C File Offset: 0x0000184C
	internal unsafe static sbyte* what(exception* A_0)
	{
		ulong num = (ulong)(*(A_0 + 8L));
		return (num != 0UL) ? num : ref <Module>.??_C@_0BC@EOODALEL@Unknown?5exception?$AA@;
	}

	// Token: 0x06000004 RID: 4 RVA: 0x000023F0 File Offset: 0x000017F0
	internal unsafe static void* __vecDelDtor(exception* A_0, uint A_0)
	{
		if ((A_0 & 2U) != 0U)
		{
			exception* ptr = A_0 - 8L;
			<Module>.__ehvec_dtor(A_0, 24UL, (ulong)(*ptr), ldftn(std.exception.{dtor}));
			if ((A_0 & 1U) != 0U)
			{
				exception* ptr2 = ptr;
				<Module>.delete[](ptr2, (ulong)(*ptr2 * 24L + 8L));
			}
			return ptr;
		}
		*A_0 = ref <Module>.??_7exception@std@@6B@;
		<Module>.__std_exception_destroy(A_0 / sizeof(__std_exception_data) + 8L);
		if ((A_0 & 1U) != 0U)
		{
			<Module>.delete(A_0);
		}
		return A_0;
	}

	// Token: 0x06000005 RID: 5 RVA: 0x000012BC File Offset: 0x000006BC
	internal unsafe static void {dtor}(exception_ptr* A_0)
	{
		<Module>.__ExceptionPtrDestroy(A_0);
	}

	// Token: 0x06000006 RID: 6 RVA: 0x000012D0 File Offset: 0x000006D0
	internal unsafe static exception_ptr* {ctor}(exception_ptr* A_0, exception_ptr* _Rhs)
	{
		<Module>.__ExceptionPtrCopy(A_0, _Rhs);
		return A_0;
	}

	// Token: 0x06000007 RID: 7 RVA: 0x00001310 File Offset: 0x00000710
	internal static long max()
	{
		return long.MaxValue;
	}

	// Token: 0x06000008 RID: 8 RVA: 0x00001328 File Offset: 0x00000728
	internal unsafe static void* @new(ulong _Size, void* _Where)
	{
		return _Where;
	}

	// Token: 0x06000009 RID: 9 RVA: 0x00001338 File Offset: 0x00000738
	internal unsafe static sbyte* copy(sbyte* _First1, sbyte* _First2, ulong _Count)
	{
		cpblk(_First1, _First2, _Count);
		return _First1;
	}

	// Token: 0x0600000A RID: 10 RVA: 0x00001350 File Offset: 0x00000750
	internal unsafe static void assign(sbyte* _Left, sbyte* _Right)
	{
		*_Left = (byte)(*_Right);
	}

	// Token: 0x0600000B RID: 11 RVA: 0x00001364 File Offset: 0x00000764
	internal unsafe static void _Orphan_all(_Container_base0* A_0)
	{
	}

	// Token: 0x0600000C RID: 12 RVA: 0x00001374 File Offset: 0x00000774
	internal unsafe static _Container_base12* {ctor}(_Container_base12* A_0, _Container_base12* A_0)
	{
		*A_0 = 0L;
		return A_0;
	}

	// Token: 0x0600000D RID: 13 RVA: 0x000020D8 File Offset: 0x000014D8
	internal unsafe static _Iterator_base12* {ctor}(_Iterator_base12* A_0, _Iterator_base12* _Right)
	{
		*A_0 = 0L;
		*(A_0 + 8L) = 0L;
		ulong num = (ulong)(*_Right);
		if (0UL != num)
		{
			_Container_base12* ptr = *num;
			if (ptr != null)
			{
				*A_0 = *(long*)ptr;
			}
		}
		return A_0;
	}

	// Token: 0x0600000E RID: 14 RVA: 0x00001A38 File Offset: 0x00000E38
	internal unsafe static _Iterator_base12* =(_Iterator_base12* A_0, _Iterator_base12* _Right)
	{
		ulong num = (ulong)(*_Right);
		if (*A_0 != (long)num && num != 0UL)
		{
			_Container_base12* ptr = *num;
			if (ptr != null)
			{
				*A_0 = *(long*)ptr;
			}
		}
		return A_0;
	}

	// Token: 0x0600000F RID: 15 RVA: 0x00001388 File Offset: 0x00000788
	internal unsafe static void _Adopt(_Iterator_base12* A_0, _Container_base12* _Parent)
	{
		if (_Parent != null)
		{
			*A_0 = *(long*)_Parent;
		}
	}

	// Token: 0x06000010 RID: 16 RVA: 0x0000139C File Offset: 0x0000079C
	internal unsafe static void* _Allocate(ulong _Count, ulong _Sz, [MarshalAs(UnmanagedType.U1)] bool _Try_aligned_allocation)
	{
		if (_Count == 0UL)
		{
			return 0L;
		}
		if (18446744073709551615UL / _Sz < _Count)
		{
			<Module>.std._Xbad_alloc();
		}
		ulong num = _Count * _Sz;
		void* ptr;
		if (_Try_aligned_allocation && 4096L <= num)
		{
			ulong num2 = num + 39L;
			if (num2 <= num)
			{
				<Module>.std._Xbad_alloc();
			}
			ulong num3 = <Module>.@new(num2);
			if (num3 == null)
			{
				<Module>._invalid_parameter_noinfo_noreturn();
			}
			ptr = (void*)(num3 + (byte*)39L & -32L);
			*(long*)((byte*)ptr - 8L) = num3;
			return ptr;
		}
		ptr = <Module>.@new(num);
		if (ptr == null)
		{
			<Module>._invalid_parameter_noinfo_noreturn();
		}
		return ptr;
	}

	// Token: 0x06000011 RID: 17 RVA: 0x00001418 File Offset: 0x00000818
	internal unsafe static void _Deallocate(void* _Ptr, ulong _Count, ulong _Sz)
	{
		ulong num;
		if (_Count <= 18446744073709551615UL / _Sz)
		{
			if (4096UL > _Count * _Sz)
			{
				goto IL_41;
			}
			if ((_Ptr & 31L) == null)
			{
				num = *(long*)((byte*)_Ptr - 8L);
				if (num < _Ptr)
				{
					ulong num2 = (byte*)_Ptr - num;
					if (8UL <= num2 && num2 <= 39UL)
					{
						goto IL_3E;
					}
				}
			}
		}
		<Module>._invalid_parameter_noinfo_noreturn();
		IL_3E:
		_Ptr = num;
		IL_41:
		<Module>.delete(_Ptr);
	}

	// Token: 0x06000012 RID: 18 RVA: 0x0000246C File Offset: 0x0000186C
	internal unsafe static void* __vecDelDtor(runtime_error* A_0, uint A_0)
	{
		if ((A_0 & 2U) != 0U)
		{
			runtime_error* ptr = A_0 - 8L;
			<Module>.__ehvec_dtor(A_0, 24UL, (ulong)(*ptr), ldftn(std.runtime_error.{dtor}));
			if ((A_0 & 1U) != 0U)
			{
				runtime_error* ptr2 = ptr;
				<Module>.delete[](ptr2, (ulong)(*ptr2 * 24L + 8L));
			}
			return ptr;
		}
		*A_0 = ref <Module>.??_7exception@std@@6B@;
		<Module>.__std_exception_destroy(A_0 / sizeof(__std_exception_data) + 8L);
		if ((A_0 & 1U) != 0U)
		{
			<Module>.delete(A_0, 24UL);
		}
		return A_0;
	}

	// Token: 0x06000013 RID: 19 RVA: 0x0000146C File Offset: 0x0000086C
	internal unsafe static void {dtor}(runtime_error* A_0)
	{
		*A_0 = ref <Module>.??_7exception@std@@6B@;
		<Module>.__std_exception_destroy(A_0 / sizeof(__std_exception_data) + 8L);
	}

	// Token: 0x06000014 RID: 20 RVA: 0x0000252C File Offset: 0x0000192C
	internal unsafe static void* __vecDelDtor(bad_cast* A_0, uint A_0)
	{
		if ((A_0 & 2U) != 0U)
		{
			bad_cast* ptr = A_0 - 8L;
			<Module>.__ehvec_dtor(A_0, 24UL, (ulong)(*ptr), ldftn(std.bad_cast.{dtor}));
			if ((A_0 & 1U) != 0U)
			{
				bad_cast* ptr2 = ptr;
				<Module>.delete[](ptr2, (ulong)(*ptr2 * 24L + 8L));
			}
			return ptr;
		}
		*A_0 = ref <Module>.??_7exception@std@@6B@;
		<Module>.__std_exception_destroy(A_0 / sizeof(__std_exception_data) + 8L);
		if ((A_0 & 1U) != 0U)
		{
			<Module>.delete(A_0, 24UL);
		}
		return A_0;
	}

	// Token: 0x06000015 RID: 21 RVA: 0x0000258C File Offset: 0x0000198C
	internal unsafe static void {dtor}(bad_cast* A_0)
	{
		*A_0 = ref <Module>.??_7exception@std@@6B@;
		<Module>.__std_exception_destroy(A_0 / sizeof(__std_exception_data) + 8L);
	}

	// Token: 0x06000016 RID: 22 RVA: 0x0000148C File Offset: 0x0000088C
	internal unsafe static runtime_error* {ctor}(runtime_error* A_0, runtime_error* A_0)
	{
		*A_0 = ref <Module>.??_7exception@std@@6B@;
		runtime_error* ptr = A_0 + 8L;
		initblk(ptr, 0, 16L);
		<Module>.__std_exception_copy(A_0 / sizeof(__std_exception_data) + 8L, ptr);
		try
		{
			*A_0 = ref <Module>.??_7runtime_error@std@@6B@;
		}
		catch
		{
			<Module>.___CxxCallUnwindDtor(ldftn(std.exception.{dtor}), A_0);
			throw;
		}
		return A_0;
	}

	// Token: 0x06000017 RID: 23 RVA: 0x000014EC File Offset: 0x000008EC
	internal unsafe static locale* {ctor}(locale* A_0, locale* _Right)
	{
		long num = *(_Right + 8L);
		*(A_0 + 8L) = num;
		long num2 = num;
		calli(System.Void modopt(System.Runtime.CompilerServices.CallConvCdecl)(System.IntPtr), num2, *(*num2 + 8L));
		return A_0;
	}

	// Token: 0x06000018 RID: 24 RVA: 0x000024CC File Offset: 0x000018CC
	internal unsafe static void* __vecDelDtor(_System_error* A_0, uint A_0)
	{
		if ((A_0 & 2U) != 0U)
		{
			_System_error* ptr = A_0 - 8L;
			<Module>.__ehvec_dtor(A_0, 40UL, (ulong)(*ptr), ldftn(std._System_error.{dtor}));
			if ((A_0 & 1U) != 0U)
			{
				_System_error* ptr2 = ptr;
				<Module>.delete[](ptr2, (ulong)(*ptr2 * 40L + 8L));
			}
			return ptr;
		}
		*A_0 = ref <Module>.??_7exception@std@@6B@;
		<Module>.__std_exception_destroy(A_0 / sizeof(__std_exception_data) + 8L);
		if ((A_0 & 1U) != 0U)
		{
			<Module>.delete(A_0, 40UL);
		}
		return A_0;
	}

	// Token: 0x06000019 RID: 25 RVA: 0x00001514 File Offset: 0x00000914
	internal unsafe static void {dtor}(_System_error* A_0)
	{
		*A_0 = ref <Module>.??_7exception@std@@6B@;
		<Module>.__std_exception_destroy(A_0 / sizeof(__std_exception_data) + 8L);
	}

	// Token: 0x0600001A RID: 26 RVA: 0x000025AC File Offset: 0x000019AC
	internal unsafe static void* __vecDelDtor(system_error* A_0, uint A_0)
	{
		if ((A_0 & 2U) != 0U)
		{
			system_error* ptr = A_0 - 8L;
			<Module>.__ehvec_dtor(A_0, 40UL, (ulong)(*ptr), ldftn(std.system_error.{dtor}));
			if ((A_0 & 1U) != 0U)
			{
				system_error* ptr2 = ptr;
				<Module>.delete[](ptr2, (ulong)(*ptr2 * 40L + 8L));
			}
			return ptr;
		}
		*A_0 = ref <Module>.??_7exception@std@@6B@;
		<Module>.__std_exception_destroy(A_0 / sizeof(__std_exception_data) + 8L);
		if ((A_0 & 1U) != 0U)
		{
			<Module>.delete(A_0, 40UL);
		}
		return A_0;
	}

	// Token: 0x0600001B RID: 27 RVA: 0x00001534 File Offset: 0x00000934
	internal unsafe static void {dtor}(system_error* A_0)
	{
		*A_0 = ref <Module>.??_7exception@std@@6B@;
		<Module>.__std_exception_destroy(A_0 / sizeof(__std_exception_data) + 8L);
	}

	// Token: 0x0600001C RID: 28 RVA: 0x0000264C File Offset: 0x00001A4C
	internal unsafe static void* __vecDelDtor(ios_base.failure* A_0, uint A_0)
	{
		if ((A_0 & 2U) != 0U)
		{
			ios_base.failure* ptr = A_0 - 8L;
			<Module>.__ehvec_dtor(A_0, 40UL, (ulong)(*ptr), ldftn(std.ios_base.failure.{dtor}));
			if ((A_0 & 1U) != 0U)
			{
				ios_base.failure* ptr2 = ptr;
				<Module>.delete[](ptr2, (ulong)(*ptr2 * 40L + 8L));
			}
			return ptr;
		}
		*A_0 = ref <Module>.??_7exception@std@@6B@;
		<Module>.__std_exception_destroy(A_0 / sizeof(__std_exception_data) + 8L);
		if ((A_0 & 1U) != 0U)
		{
			<Module>.delete(A_0, 40UL);
		}
		return A_0;
	}

	// Token: 0x0600001D RID: 29 RVA: 0x000026AC File Offset: 0x00001AAC
	internal unsafe static void {dtor}(ios_base.failure* A_0)
	{
		*A_0 = ref <Module>.??_7exception@std@@6B@;
		<Module>.__std_exception_destroy(A_0 / sizeof(__std_exception_data) + 8L);
	}

	// Token: 0x0600001E RID: 30 RVA: 0x00002104 File Offset: 0x00001504
	internal unsafe static ios_base.failure* {ctor}(ios_base.failure* A_0, ios_base.failure* A_0)
	{
		<Module>.std._System_error.{ctor}(A_0, A_0);
		try
		{
			*A_0 = ref <Module>.??_7system_error@std@@6B@;
		}
		catch
		{
			<Module>.___CxxCallUnwindDtor(ldftn(std._System_error.{dtor}), A_0);
			throw;
		}
		try
		{
			*A_0 = ref <Module>.??_7failure@ios_base@std@@6B@;
		}
		catch
		{
			<Module>.___CxxCallUnwindDtor(ldftn(std.system_error.{dtor}), A_0);
			throw;
		}
		return A_0;
	}

	// Token: 0x0600001F RID: 31 RVA: 0x00001A5C File Offset: 0x00000E5C
	internal unsafe static system_error* {ctor}(system_error* A_0, system_error* A_0)
	{
		<Module>.std._System_error.{ctor}(A_0, A_0);
		try
		{
			*A_0 = ref <Module>.??_7system_error@std@@6B@;
		}
		catch
		{
			<Module>.___CxxCallUnwindDtor(ldftn(std._System_error.{dtor}), A_0);
			throw;
		}
		return A_0;
	}

	// Token: 0x06000020 RID: 32 RVA: 0x00001554 File Offset: 0x00000954
	internal unsafe static _System_error* {ctor}(_System_error* A_0, _System_error* A_0)
	{
		*A_0 = ref <Module>.??_7exception@std@@6B@;
		_System_error* ptr = A_0 + 8L;
		initblk(ptr, 0, 16L);
		<Module>.__std_exception_copy(A_0 / sizeof(__std_exception_data) + 8L, ptr);
		try
		{
			*A_0 = ref <Module>.??_7runtime_error@std@@6B@;
		}
		catch
		{
			<Module>.___CxxCallUnwindDtor(ldftn(std.exception.{dtor}), A_0);
			throw;
		}
		try
		{
			*A_0 = ref <Module>.??_7_System_error@std@@6B@;
			cpblk(A_0 + 24L, A_0 + 24L, 16);
		}
		catch
		{
			<Module>.___CxxCallUnwindDtor(ldftn(std.runtime_error.{dtor}), A_0);
			throw;
		}
		return A_0;
	}

	// Token: 0x06000021 RID: 33 RVA: 0x00002280 File Offset: 0x00001680
	internal unsafe static void {dtor}(basic_string<char,std::char_traits<char>,std::allocator<char>\u0020>* A_0)
	{
		try
		{
			<Module>.std.basic_string<char,std::char_traits<char>,std::allocator<char>\u0020>._Tidy_deallocate(A_0);
		}
		catch
		{
			<Module>.___CxxCallUnwindDtor(ldftn(std._String_alloc<std::_String_base_types<char,std::allocator<char>\u0020>\u0020>.{dtor}), A_0);
			throw;
		}
	}

	// Token: 0x06000022 RID: 34 RVA: 0x000022C0 File Offset: 0x000016C0
	internal unsafe static basic_string<char,std::char_traits<char>,std::allocator<char>\u0020>* {ctor}(basic_string<char,std::char_traits<char>,std::allocator<char>\u0020>* A_0, basic_string<char,std::char_traits<char>,std::allocator<char>\u0020>* _Right)
	{
		try
		{
			*(A_0 + 16L) = 0L;
			*(A_0 + 24L) = 0L;
		}
		catch
		{
			<Module>.___CxxCallUnwindDtor(ldftn(std._String_val<std::_Simple_types<char>\u0020>._Bxty.{dtor}), A_0);
			throw;
		}
		try
		{
			<Module>.std.basic_string<char,std::char_traits<char>,std::allocator<char>\u0020>._Construct_lv_contents(A_0, _Right);
		}
		catch
		{
			<Module>.___CxxCallUnwindDtor(ldftn(std._String_alloc<std::_String_base_types<char,std::allocator<char>\u0020>\u0020>.{dtor}), A_0);
			throw;
		}
		return A_0;
	}

	// Token: 0x06000023 RID: 35 RVA: 0x00002270 File Offset: 0x00001670
	internal unsafe static void {dtor}(_String_alloc<std::_String_base_types<char,std::allocator<char>\u0020>\u0020>* A_0)
	{
	}

	// Token: 0x06000024 RID: 36 RVA: 0x0000217C File Offset: 0x0000157C
	internal unsafe static void {dtor}(_Compressed_pair<std::allocator<char>,std::_String_val<std::_Simple_types<char>\u0020>,1>* A_0)
	{
	}

	// Token: 0x06000025 RID: 37 RVA: 0x00001F2C File Offset: 0x0000132C
	internal unsafe static void {dtor}(_String_val<std::_Simple_types<char>\u0020>* A_0)
	{
	}

	// Token: 0x06000026 RID: 38 RVA: 0x000017F0 File Offset: 0x00000BF0
	internal unsafe static void {dtor}(_String_val<std::_Simple_types<char>\u0020>._Bxty* A_0)
	{
	}

	// Token: 0x06000027 RID: 39 RVA: 0x00001800 File Offset: 0x00000C00
	[return: MarshalAs(UnmanagedType.U1)]
	internal unsafe static bool _Large_string_engaged(_String_val<std::_Simple_types<char>\u0020>* A_0)
	{
		return (16L <= *(A_0 + 24L)) ? 1 : 0;
	}

	// Token: 0x06000028 RID: 40 RVA: 0x00001F3C File Offset: 0x0000133C
	internal unsafe static sbyte* _Myptr(_String_val<std::_Simple_types<char>\u0020>* A_0)
	{
		sbyte* result = A_0;
		if (((16L <= *(A_0 + 24L)) ? 1 : 0) != 0)
		{
			result = *A_0;
		}
		return result;
	}

	// Token: 0x06000029 RID: 41 RVA: 0x00001820 File Offset: 0x00000C20
	internal unsafe static allocator<char>* select_on_container_copy_construction(allocator<char>* A_0, allocator<char>* _Al)
	{
		return A_0;
	}

	// Token: 0x0600002A RID: 42 RVA: 0x00001F64 File Offset: 0x00001364
	internal unsafe static _String_val<std::_Simple_types<char>\u0020>* _Get_data(_String_alloc<std::_String_base_types<char,std::allocator<char>\u0020>\u0020>* A_0)
	{
		return A_0;
	}

	// Token: 0x0600002B RID: 43 RVA: 0x00001F74 File Offset: 0x00001374
	internal unsafe static _String_val<std::_Simple_types<char>\u0020>* _Get_data(_String_alloc<std::_String_base_types<char,std::allocator<char>\u0020>\u0020>* A_0)
	{
		return A_0;
	}

	// Token: 0x0600002C RID: 44 RVA: 0x00001F84 File Offset: 0x00001384
	internal unsafe static allocator<char>* _Getal(_String_alloc<std::_String_base_types<char,std::allocator<char>\u0020>\u0020>* A_0)
	{
		return A_0;
	}

	// Token: 0x0600002D RID: 45 RVA: 0x00001F94 File Offset: 0x00001394
	internal unsafe static allocator<char>* _Getal(_String_alloc<std::_String_base_types<char,std::allocator<char>\u0020>\u0020>* A_0)
	{
		return A_0;
	}

	// Token: 0x0600002E RID: 46 RVA: 0x00001FA4 File Offset: 0x000013A4
	internal unsafe static void _Orphan_all(_String_alloc<std::_String_base_types<char,std::allocator<char>\u0020>\u0020>* A_0)
	{
	}

	// Token: 0x0600002F RID: 47 RVA: 0x00001FB4 File Offset: 0x000013B4
	internal unsafe static void _Tidy_deallocate(basic_string<char,std::char_traits<char>,std::allocator<char>\u0020>* A_0)
	{
		ulong num = (ulong)(*(A_0 + 24L));
		if (((16UL <= num) ? 1 : 0) != 0)
		{
			<Module>.std._Deallocate(*A_0, num + 1UL, 1UL);
		}
		*(A_0 + 16L) = 0L;
		*(A_0 + 24L) = 15L;
		*A_0 = 0;
	}

	// Token: 0x06000030 RID: 48 RVA: 0x00001FF8 File Offset: 0x000013F8
	internal unsafe static ulong max_size(basic_string<char,std::char_traits<char>,std::allocator<char>\u0020>* A_0)
	{
		return long.MaxValue;
	}

	// Token: 0x06000031 RID: 49 RVA: 0x00001830 File Offset: 0x00000C30
	internal unsafe static ulong* _Max_value<unsigned\u0020__int64>(ulong* _Left, ulong* _Right)
	{
		return (*_Left < *_Right) ? _Right : _Left;
	}

	// Token: 0x06000032 RID: 50 RVA: 0x0000218C File Offset: 0x0000158C
	internal unsafe static void _Construct_lv_contents(basic_string<char,std::char_traits<char>,std::allocator<char>\u0020>* A_0, basic_string<char,std::char_traits<char>,std::allocator<char>\u0020>* _Right)
	{
		ulong num = *(_Right + 16L);
		sbyte* ptr = _Right;
		if (((16L <= *(_Right + 24L)) ? 1 : 0) != 0)
		{
			ptr = *_Right;
		}
		if (num < 16L)
		{
			cpblk(A_0, ptr, 16L);
			*(A_0 + 16L) = num;
			*(A_0 + 24L) = 15L;
		}
		else
		{
			ulong num2 = <Module>.std.basic_string<char,std::char_traits<char>,std::allocator<char>\u0020>.max_size(A_0);
			ulong num3 = num | 15L;
			ulong num4 = num3;
			ulong num5 = *(ref (num2 < num3) ? ref num2 : ref num4);
			sbyte* ptr2 = <Module>.std._Allocate(num5 + 1L, 1UL, true);
			*A_0 = ptr2;
			cpblk(ptr2, ptr, num + 1L);
			*(A_0 + 16L) = num;
			*(A_0 + 24L) = num5;
		}
	}

	// Token: 0x06000033 RID: 51 RVA: 0x00001848 File Offset: 0x00000C48
	internal unsafe static sbyte* allocate(allocator<char>* A_0, ulong _Count)
	{
		return <Module>.std._Allocate(_Count, 1UL, true);
	}

	// Token: 0x06000034 RID: 52 RVA: 0x00001860 File Offset: 0x00000C60
	internal unsafe static void deallocate(allocator<char>* A_0, sbyte* _Ptr, ulong _Count)
	{
		<Module>.std._Deallocate(_Ptr, _Count, 1UL);
	}

	// Token: 0x06000035 RID: 53 RVA: 0x00001878 File Offset: 0x00000C78
	internal unsafe static _String_val<std::_Simple_types<char>\u0020>* _Get_second(_Compressed_pair<std::allocator<char>,std::_String_val<std::_Simple_types<char>\u0020>,1>* A_0)
	{
		return A_0;
	}

	// Token: 0x06000036 RID: 54 RVA: 0x00001888 File Offset: 0x00000C88
	internal unsafe static _String_val<std::_Simple_types<char>\u0020>* _Get_second(_Compressed_pair<std::allocator<char>,std::_String_val<std::_Simple_types<char>\u0020>,1>* A_0)
	{
		return A_0;
	}

	// Token: 0x06000037 RID: 55 RVA: 0x00001898 File Offset: 0x00000C98
	internal unsafe static allocator<char>* _Get_first(_Compressed_pair<std::allocator<char>,std::_String_val<std::_Simple_types<char>\u0020>,1>* A_0)
	{
		return A_0;
	}

	// Token: 0x06000038 RID: 56 RVA: 0x000018A8 File Offset: 0x00000CA8
	internal unsafe static allocator<char>* _Get_first(_Compressed_pair<std::allocator<char>,std::_String_val<std::_Simple_types<char>\u0020>,1>* A_0)
	{
		return A_0;
	}

	// Token: 0x06000039 RID: 57 RVA: 0x000018B8 File Offset: 0x00000CB8
	internal unsafe static ulong max_size(allocator<char>* A_0)
	{
		return -1L;
	}

	// Token: 0x0600003A RID: 58 RVA: 0x000018D0 File Offset: 0x00000CD0
	internal unsafe static ulong* _Min_value<unsigned\u0020__int64>(ulong* _Left, ulong* _Right)
	{
		return (*_Right < *_Left) ? _Right : _Left;
	}

	// Token: 0x0600003B RID: 59 RVA: 0x000018E8 File Offset: 0x00000CE8
	internal unsafe static sbyte* _Unfancy<char>(sbyte* _Ptr)
	{
		return _Ptr;
	}

	// Token: 0x0600003C RID: 60 RVA: 0x00002224 File Offset: 0x00001624
	internal unsafe static _String_alloc<std::_String_base_types<char,std::allocator<char>\u0020>\u0020>* {ctor}<class\u0020std::allocator<char>,void>(_String_alloc<std::_String_base_types<char,std::allocator<char>\u0020>\u0020>* A_0, allocator<char>* _Al)
	{
		try
		{
			*(A_0 + 16L) = 0L;
			*(A_0 + 24L) = 0L;
		}
		catch
		{
			<Module>.___CxxCallUnwindDtor(ldftn(std._String_val<std::_Simple_types<char>\u0020>._Bxty.{dtor}), A_0);
			throw;
		}
		return A_0;
	}

	// Token: 0x0600003D RID: 61 RVA: 0x000018F8 File Offset: 0x00000CF8
	internal unsafe static sbyte** addressof<char\u0020*>(sbyte** _Val)
	{
		return _Val;
	}

	// Token: 0x0600003E RID: 62 RVA: 0x00001908 File Offset: 0x00000D08
	internal unsafe static void destroy<char\u0020*>(allocator<char>* __unnamed000, sbyte** _Ptr)
	{
	}

	// Token: 0x0600003F RID: 63 RVA: 0x00002010 File Offset: 0x00001410
	internal unsafe static void construct<char\u0020*,char\u0020*\u0020const\u0020&>(allocator<char>* __unnamed000, sbyte** _Ptr, sbyte** <_Args_0>)
	{
		*_Ptr = *<_Args_0>;
	}

	// Token: 0x06000040 RID: 64 RVA: 0x00001918 File Offset: 0x00000D18
	internal unsafe static bad_cast* {ctor}(bad_cast* A_0, bad_cast* A_0)
	{
		*A_0 = ref <Module>.??_7exception@std@@6B@;
		bad_cast* ptr = A_0 + 8L;
		initblk(ptr, 0, 16L);
		<Module>.__std_exception_copy(A_0 / sizeof(__std_exception_data) + 8L, ptr);
		try
		{
			*A_0 = ref <Module>.??_7bad_cast@std@@6B@;
		}
		catch
		{
			<Module>.___CxxCallUnwindDtor(ldftn(std.exception.{dtor}), A_0);
			throw;
		}
		return A_0;
	}

	// Token: 0x06000041 RID: 65 RVA: 0x00002024 File Offset: 0x00001424
	internal unsafe static _String_val<std::_Simple_types<char>\u0020>* {ctor}(_String_val<std::_Simple_types<char>\u0020>* A_0)
	{
		try
		{
			*(A_0 + 16L) = 0L;
			*(A_0 + 24L) = 0L;
		}
		catch
		{
			<Module>.___CxxCallUnwindDtor(ldftn(std._String_val<std::_Simple_types<char>\u0020>._Bxty.{dtor}), A_0);
			throw;
		}
		return A_0;
	}

	// Token: 0x06000042 RID: 66 RVA: 0x00001978 File Offset: 0x00000D78
	internal unsafe static _String_val<std::_Simple_types<char>\u0020>._Bxty* {ctor}(_String_val<std::_Simple_types<char>\u0020>._Bxty* A_0)
	{
		return A_0;
	}

	// Token: 0x06000043 RID: 67 RVA: 0x00001988 File Offset: 0x00000D88
	internal unsafe static allocator<char>* forward<class\u0020std::allocator<char>\u0020>(allocator<char>* _Arg)
	{
		return _Arg;
	}

	// Token: 0x06000044 RID: 68 RVA: 0x00002070 File Offset: 0x00001470
	internal unsafe static _Compressed_pair<std::allocator<char>,std::_String_val<std::_Simple_types<char>\u0020>,1>* {ctor}<class\u0020std::allocator<char>\u0020>(_Compressed_pair<std::allocator<char>,std::_String_val<std::_Simple_types<char>\u0020>,1>* A_0, _One_then_variadic_args_t __unnamed000, allocator<char>* _Val1)
	{
		try
		{
			*(A_0 + 16L) = 0L;
			*(A_0 + 24L) = 0L;
		}
		catch
		{
			<Module>.___CxxCallUnwindDtor(ldftn(std._String_val<std::_Simple_types<char>\u0020>._Bxty.{dtor}), A_0);
			throw;
		}
		return A_0;
	}

	// Token: 0x06000045 RID: 69 RVA: 0x00001998 File Offset: 0x00000D98
	internal unsafe static sbyte** forward<char\u0020*\u0020const\u0020&>(sbyte** _Arg)
	{
		return _Arg;
	}

	// Token: 0x06000046 RID: 70 RVA: 0x00002CD4 File Offset: 0x000020D4
	internal unsafe static sbyte* av_make_error_string(sbyte* errbuf, ulong errbuf_size, int errnum)
	{
		<Module>.av_strerror(errnum, errbuf, errbuf_size);
		return errbuf;
	}

	// Token: 0x06000047 RID: 71 RVA: 0x00002D70 File Offset: 0x00002170
	internal unsafe static void write_video_frame(WriterPrivateData data)
	{
		AVCodecContext* ptr = *(long*)(data.VideoStream + 8L / (long)sizeof(AVStream));
		if ((*(*(long*)(data.FormatContext + 16L / (long)sizeof(AVFormatContext)) + 44L) & 32) != 0)
		{
			Console.WriteLine("Raw picture must be written");
		}
		else
		{
			AVPacket avpacket;
			<Module>.av_init_packet(&avpacket);
			*(ref avpacket + 24) = 0L;
			*(ref avpacket + 32) = 0;
			int num;
			if (<Module>.avcodec_encode_video2(ptr, &avpacket, (AVFrame*)data.VideoFrame, &num) < 0)
			{
				throw new VideoException("Error while encoding video frame");
			}
			if (num != 0)
			{
				if (*(ref avpacket + 8) != -9223372036854775808L)
				{
					*(ref avpacket + 8) = <Module>.av_rescale_q(*(ref avpacket + 8), *(AVRational*)(ptr + 140L / (long)sizeof(AVCodecContext)), *(AVRational*)(data.VideoStream + 48L / (long)sizeof(AVStream)));
				}
				if (*(ref avpacket + 16) != -9223372036854775808L)
				{
					*(ref avpacket + 16) = <Module>.av_rescale_q(*(ref avpacket + 16), *(AVRational*)(ptr + 140L / (long)sizeof(AVCodecContext)), *(AVRational*)(data.VideoStream + 48L / (long)sizeof(AVStream)));
				}
				if (*(*(long*)(ptr + 888L / (long)sizeof(AVCodecContext)) + 120L) != 0)
				{
					*(ref avpacket + 40) = (*(ref avpacket + 40) | 1);
				}
				*(ref avpacket + 36) = *(int*)data.VideoStream;
				Console.WriteLine("Stream: {0} PTS: {1} -> {1} bytes", *(ref avpacket + 36), *(ref avpacket + 8), *(ref avpacket + 32));
				if (<Module>.av_interleaved_write_frame(data.FormatContext, &avpacket) != null)
				{
					throw new VideoException("Error while writing video frame.");
				}
			}
		}
	}

	// Token: 0x06000048 RID: 72 RVA: 0x00002ED0 File Offset: 0x000022D0
	internal unsafe static AVFrame* alloc_picture(AVPixelFormat pix_fmt, int width, int height)
	{
		AVFrame* ptr = <Module>.av_frame_alloc();
		if (ptr == null)
		{
			return 0L;
		}
		void* ptr2 = <Module>.av_malloc((ulong)<Module>.avpicture_get_size(pix_fmt, width, height));
		if (ptr2 == null)
		{
			<Module>.av_free((void*)ptr);
			return 0L;
		}
		<Module>.avpicture_fill((AVPicture*)ptr, (byte*)ptr2, pix_fmt, width, height);
		return ptr;
	}

	// Token: 0x06000049 RID: 73 RVA: 0x00002F10 File Offset: 0x00002310
	internal unsafe static void add_video_stream(WriterPrivateData data, int width, int height, Rational frameRate, int bitRate, AVCodecID codecId, AVPixelFormat pixelFormat)
	{
		AVCodec* ptr = <Module>.avcodec_find_encoder(codecId);
		AVStream* ptr2 = <Module>.avformat_new_stream(data.FormatContext, (AVCodec*)ptr);
		data.VideoStream = ptr2;
		if (ptr2 == null)
		{
			throw new VideoException("Failed creating new video stream.");
		}
		AVCodecContext* ptr3 = *(long*)(ptr2 + 8L / (long)sizeof(AVStream));
		*(int*)(ptr3 + 56L / (long)sizeof(AVCodecContext)) = (int)codecId;
		*(int*)(ptr3 + 12L / (long)sizeof(AVCodecContext)) = 0;
		*(long*)(ptr3 + 96L / (long)sizeof(AVCodecContext)) = (long)bitRate;
		*(int*)(ptr3 + 156L / (long)sizeof(AVCodecContext)) = width;
		*(int*)(ptr3 + 160L / (long)sizeof(AVCodecContext)) = height;
		*(int*)(ptr3 + 140L / (long)sizeof(AVCodecContext)) = frameRate.Denominator;
		*(int*)(ptr3 + 144L / (long)sizeof(AVCodecContext)) = frameRate.Numerator;
		*(int*)(ptr3 + 172L / (long)sizeof(AVCodecContext)) = 12;
		*(int*)(ptr3 + 176L / (long)sizeof(AVCodecContext)) = (int)pixelFormat;
		int num = *(int*)(ptr3 + 56L / (long)sizeof(AVCodecContext));
		if (num == 1)
		{
			*(int*)(ptr3 + 344L / (long)sizeof(AVCodecContext)) = 2;
		}
		if (num == 28 || num == 174)
		{
			*(int*)(data.VideoStream + 268L / (long)sizeof(AVStream)) = 4;
			*(int*)(ptr3 + 636L / (long)sizeof(AVCodecContext)) = 1;
			*(int*)(ptr3 + 932L / (long)sizeof(AVCodecContext)) = 66;
			*(int*)(ptr3 + 180L / (long)sizeof(AVCodecContext)) = 7;
			*(int*)(ptr3 + 316L / (long)sizeof(AVCodecContext)) = 4;
			*(int*)(ptr3 + 152L / (long)sizeof(AVCodecContext)) = 0;
			*(int*)(ptr3 + 200L / (long)sizeof(AVCodecContext)) = 0;
			*(int*)(ptr3 + 424L / (long)sizeof(AVCodecContext)) = 3;
			*(int*)(ptr3 + 456L / (long)sizeof(AVCodecContext)) = 2;
		}
		if (*(int*)(ptr3 + 56L / (long)sizeof(AVCodecContext)) == 31)
		{
			*(int*)(ptr3 + 456L / (long)sizeof(AVCodecContext)) = 2;
		}
		if ((*(*(long*)(data.FormatContext + 16L / (long)sizeof(AVFormatContext)) + 44L) & 64) != 0)
		{
			*(int*)(ptr3 + 116L / (long)sizeof(AVCodecContext)) = (*(int*)(ptr3 + 116L / (long)sizeof(AVCodecContext)) | 4194304);
		}
	}

	// Token: 0x0600004A RID: 74 RVA: 0x0000306C File Offset: 0x0000246C
	internal unsafe static void open_video(WriterPrivateData data)
	{
		AVCodecContext* ptr = *(long*)(data.VideoStream + 8L / (long)sizeof(AVStream));
		AVCodec* ptr2 = <Module>.avcodec_find_encoder((AVCodecID)(*(int*)(ptr + 56L / (long)sizeof(AVCodecContext))));
		if (ptr2 == null)
		{
			throw new VideoException("Cannot find video codec.");
		}
		if (<Module>.avcodec_open2(ptr, (AVCodec*)ptr2, null) < 0)
		{
			throw new VideoException("Cannot open video codec.");
		}
		data.VideoOutputBuffer = null;
		if ((*(*(long*)(data.FormatContext + 16L / (long)sizeof(AVFormatContext)) + 44L) & 32) == 0)
		{
			int num = *(int*)(ptr + 160L / (long)sizeof(AVCodecContext)) * *(int*)(ptr + 156L / (long)sizeof(AVCodecContext)) * 6;
			data.VideoOutputBufferSize = num;
			data.VideoOutputBuffer = <Module>.av_malloc((ulong)((long)num));
		}
		AVFrame* ptr3 = <Module>.Accord.Video.FFMPEG.?A0xbc0632da.alloc_picture((AVPixelFormat)(*(int*)(ptr + 176L / (long)sizeof(AVCodecContext))), *(int*)(ptr + 156L / (long)sizeof(AVCodecContext)), *(int*)(ptr + 160L / (long)sizeof(AVCodecContext)));
		data.VideoFrame = ptr3;
		*(int*)(ptr3 + 104L / (long)sizeof(AVFrame)) = *(int*)(ptr + 156L / (long)sizeof(AVCodecContext));
		*(int*)(data.VideoFrame + 108L / (long)sizeof(AVFrame)) = *(int*)(ptr + 160L / (long)sizeof(AVCodecContext));
		*(int*)(data.VideoFrame + 116L / (long)sizeof(AVFrame)) = *(int*)(ptr + 176L / (long)sizeof(AVCodecContext));
		if (data.VideoFrame == null)
		{
			throw new VideoException("Cannot allocate video picture.");
		}
		int num2 = *(int*)(ptr + 160L / (long)sizeof(AVCodecContext));
		int num3 = *(int*)(ptr + 156L / (long)sizeof(AVCodecContext));
		data.ConvertContext = <Module>.sws_getContext(num3, num2, (AVPixelFormat)3, num3, num2, (AVPixelFormat)(*(int*)(ptr + 176L / (long)sizeof(AVCodecContext))), 4, null, null, null);
		int num4 = *(int*)(ptr + 160L / (long)sizeof(AVCodecContext));
		int num5 = *(int*)(ptr + 156L / (long)sizeof(AVCodecContext));
		SwsContext* ptr4 = <Module>.sws_getContext(num5, num4, (AVPixelFormat)8, num5, num4, (AVPixelFormat)(*(int*)(ptr + 176L / (long)sizeof(AVCodecContext))), 4, null, null, null);
		data.ConvertContextGrayscale = ptr4;
		if (data.ConvertContext == null || ptr4 == null)
		{
			throw new VideoException("Cannot initialize frames conversion context.");
		}
	}

	// Token: 0x0600004B RID: 75 RVA: 0x00003200 File Offset: 0x00002600
	internal unsafe static void add_audio_stream(WriterPrivateData data, AVCodecID codec_id)
	{
		AVStream* ptr = <Module>.avformat_new_stream(data.FormatContext, null);
		data.AudioStream = ptr;
		*(int*)(ptr + 4L / (long)sizeof(AVStream)) = 1;
		AVStream* audioStream = data.AudioStream;
		if (audioStream == null)
		{
			throw new VideoException("Failed creating new audio stream.");
		}
		AVCodecContext* ptr2 = *(long*)(audioStream + 8L / (long)sizeof(AVStream));
		*(int*)(ptr2 + 56L / (long)sizeof(AVCodecContext)) = (int)codec_id;
		*(int*)(ptr2 + 12L / (long)sizeof(AVCodecContext)) = 1;
		*(long*)(ptr2 + 96L / (long)sizeof(AVCodecContext)) = (long)data.BitRate;
		*(int*)(ptr2 + 472L / (long)sizeof(AVCodecContext)) = data.SampleRate;
		*(int*)(ptr2 + 476L / (long)sizeof(AVCodecContext)) = data.Channels;
		*(int*)(ptr2 + 480L / (long)sizeof(AVCodecContext)) = 1;
		*(int*)(ptr2 + 140L / (long)sizeof(AVCodecContext)) = 1;
		*(int*)(ptr2 + 144L / (long)sizeof(AVCodecContext)) = *(int*)(ptr2 + 472L / (long)sizeof(AVCodecContext));
		cpblk(data.AudioStream + 48L / (long)sizeof(AVStream), ptr2 + 140L / (long)sizeof(AVCodecContext), 8);
		data.AudioEncodeBufferSize = 524288;
		if (data.AudioEncodeBuffer == null)
		{
			data.AudioEncodeBuffer = <Module>.av_malloc(524288UL);
		}
		if ((*(*(long*)(data.FormatContext + 16L / (long)sizeof(AVFormatContext)) + 44L) & 64) != 0)
		{
			*(int*)(ptr2 + 116L / (long)sizeof(AVCodecContext)) = (*(int*)(ptr2 + 116L / (long)sizeof(AVCodecContext)) | 4194304);
		}
	}

	// Token: 0x0600004C RID: 76 RVA: 0x00003308 File Offset: 0x00002708
	internal unsafe static void open_audio(WriterPrivateData data)
	{
		AVCodecContext* ptr = *(long*)(data.AudioStream + 8L / (long)sizeof(AVStream));
		AVCodec* ptr2 = <Module>.avcodec_find_encoder((AVCodecID)(*(int*)(ptr + 56L / (long)sizeof(AVCodecContext))));
		if (ptr2 == null)
		{
			throw new VideoException("Cannot find audio codec.");
		}
		if (<Module>.avcodec_open2(ptr, (AVCodec*)ptr2, null) < 0)
		{
			throw new VideoException("Cannot open audio codec.");
		}
		int num = *(int*)(ptr + 484L / (long)sizeof(AVCodecContext));
		if (num <= 1)
		{
			int num2 = data.AudioEncodeBufferSize / *(int*)(ptr + 476L / (long)sizeof(AVCodecContext));
			data.AudioInputSampleSize = num2;
			if (*(int*)(ptr + 56L / (long)sizeof(AVCodecContext)) - 65536 <= 3)
			{
				data.AudioInputSampleSize = num2 >> 1;
			}
			*(int*)(ptr + 484L / (long)sizeof(AVCodecContext)) = data.AudioInputSampleSize;
		}
		else
		{
			data.AudioInputSampleSize = num;
		}
	}

	// Token: 0x0600004D RID: 77 RVA: 0x00005810 File Offset: 0x00004C10
	internal static void <CrtImplementationDetails>.ThrowNestedModuleLoadException(System.Exception innerException, System.Exception nestedException)
	{
		throw new ModuleLoadExceptionHandlerException("A nested exception occurred after the primary exception that caused the C++ module to fail to load.\n", innerException, nestedException);
	}

	// Token: 0x0600004E RID: 78 RVA: 0x000051CC File Offset: 0x000045CC
	internal static void <CrtImplementationDetails>.ThrowModuleLoadException(string errorMessage)
	{
		throw new ModuleLoadException(errorMessage);
	}

	// Token: 0x0600004F RID: 79 RVA: 0x000051E0 File Offset: 0x000045E0
	internal static void <CrtImplementationDetails>.ThrowModuleLoadException(string errorMessage, System.Exception innerException)
	{
		throw new ModuleLoadException(errorMessage, innerException);
	}

	// Token: 0x06000050 RID: 80 RVA: 0x000052FC File Offset: 0x000046FC
	internal static void <CrtImplementationDetails>.RegisterModuleUninitializer(EventHandler handler)
	{
		ModuleUninitializer._ModuleUninitializer.AddHandler(handler);
	}

	// Token: 0x06000051 RID: 81 RVA: 0x00005314 File Offset: 0x00004714
	[SecuritySafeCritical]
	internal unsafe static Guid <CrtImplementationDetails>.FromGUID(_GUID* guid)
	{
		Guid result = new Guid((uint)(*guid), *(guid + 4L), *(guid + 6L), *(guid + 8L), *(guid + 9L), *(guid + 10L), *(guid + 11L), *(guid + 12L), *(guid + 13L), *(guid + 14L), *(guid + 15L));
		return result;
	}

	// Token: 0x06000052 RID: 82 RVA: 0x00005364 File Offset: 0x00004764
	[SecurityCritical]
	internal unsafe static int __get_default_appdomain(IUnknown** ppUnk)
	{
		ICorRuntimeHost* ptr = null;
		int num;
		try
		{
			Guid riid = <Module>.<CrtImplementationDetails>.FromGUID(ref <Module>._GUID_cb2f6722_ab3a_11d2_9c40_00c04fa30a3e);
			ptr = (ICorRuntimeHost*)RuntimeEnvironment.GetRuntimeInterfaceAsIntPtr(<Module>.<CrtImplementationDetails>.FromGUID(ref <Module>._GUID_cb2f6723_ab3a_11d2_9c40_00c04fa30a3e), riid).ToPointer();
			goto IL_35;
		}
		catch (System.Exception e)
		{
			num = Marshal.GetHRForException(e);
		}
		if (num < 0)
		{
			return num;
		}
		IL_35:
		num = calli(System.Int32 modopt(System.Runtime.CompilerServices.IsLong) modopt(System.Runtime.CompilerServices.CallConvCdecl)(System.IntPtr,IUnknown**), ptr, ppUnk, *(*(long*)ptr + 104L));
		ICorRuntimeHost* ptr2 = ptr;
		object obj = calli(System.UInt32 modopt(System.Runtime.CompilerServices.IsLong) modopt(System.Runtime.CompilerServices.CallConvCdecl)(System.IntPtr), ptr2, *(*(long*)ptr2 + 16L));
		return num;
	}

	// Token: 0x06000053 RID: 83 RVA: 0x000053E0 File Offset: 0x000047E0
	internal unsafe static void __release_appdomain(IUnknown* ppUnk)
	{
		object obj = calli(System.UInt32 modopt(System.Runtime.CompilerServices.IsLong) modopt(System.Runtime.CompilerServices.CallConvCdecl)(System.IntPtr), ppUnk, *(*(long*)ppUnk + 16L));
	}

	// Token: 0x06000054 RID: 84 RVA: 0x000053FC File Offset: 0x000047FC
	[SecurityCritical]
	internal unsafe static AppDomain <CrtImplementationDetails>.GetDefaultDomain()
	{
		IUnknown* ptr = null;
		int num = <Module>.__get_default_appdomain(&ptr);
		if (num >= 0)
		{
			try
			{
				IntPtr pUnk = new IntPtr((void*)ptr);
				return (AppDomain)Marshal.GetObjectForIUnknown(pUnk);
			}
			finally
			{
				<Module>.__release_appdomain(ptr);
			}
		}
		Marshal.ThrowExceptionForHR(num);
		return null;
	}

	// Token: 0x06000055 RID: 85 RVA: 0x0000545C File Offset: 0x0000485C
	[SecurityCritical]
	internal unsafe static void <CrtImplementationDetails>.DoCallBackInDefaultDomain(method function, void* cookie)
	{
		Guid riid = <Module>.<CrtImplementationDetails>.FromGUID(ref <Module>._GUID_90f1a06c_7712_4762_86b5_7a5eba6bdb02);
		ICLRRuntimeHost* ptr = (ICLRRuntimeHost*)RuntimeEnvironment.GetRuntimeInterfaceAsIntPtr(<Module>.<CrtImplementationDetails>.FromGUID(ref <Module>._GUID_90f1a06e_7712_4762_86b5_7a5eba6bdb02), riid).ToPointer();
		try
		{
			AppDomain appDomain = <Module>.<CrtImplementationDetails>.GetDefaultDomain();
			int num = calli(System.Int32 modopt(System.Runtime.CompilerServices.IsLong) modopt(System.Runtime.CompilerServices.CallConvCdecl)(System.IntPtr,System.UInt32 modopt(System.Runtime.CompilerServices.IsLong),System.Int32 modopt(System.Runtime.CompilerServices.IsLong) modopt(System.Runtime.CompilerServices.CallConvCdecl) (System.Void*),System.Void*), ptr, appDomain.Id, function, cookie, *(*(long*)ptr + 64L));
			if (num < 0)
			{
				Marshal.ThrowExceptionForHR(num);
			}
		}
		finally
		{
			ICLRRuntimeHost* ptr2 = ptr;
			object obj = calli(System.UInt32 modopt(System.Runtime.CompilerServices.IsLong) modopt(System.Runtime.CompilerServices.CallConvCdecl)(System.IntPtr), ptr2, *(*(long*)ptr2 + 16L));
		}
	}

	// Token: 0x06000056 RID: 86 RVA: 0x00005510 File Offset: 0x00004910
	[return: MarshalAs(UnmanagedType.U1)]
	internal static bool __scrt_is_safe_for_managed_code()
	{
		return (<Module>.__scrt_native_dllmain_reason <= 1U) ? 0 : 1;
	}

	// Token: 0x06000057 RID: 87 RVA: 0x00005540 File Offset: 0x00004940
	[SecuritySafeCritical]
	internal unsafe static int <CrtImplementationDetails>.DefaultDomain.DoNothing(void* cookie)
	{
		GC.KeepAlive(int.MaxValue);
		return 0;
	}

	// Token: 0x06000058 RID: 88 RVA: 0x00005560 File Offset: 0x00004960
	[SecuritySafeCritical]
	[return: MarshalAs(UnmanagedType.U1)]
	internal unsafe static bool <CrtImplementationDetails>.DefaultDomain.HasPerProcess()
	{
		if (<Module>.?hasPerProcess@DefaultDomain@<CrtImplementationDetails>@@0W4TriBool@2@A == (TriBool)2)
		{
			void** ptr = (void**)(&<Module>.__xc_mp_a);
			if (ref <Module>.__xc_mp_a < ref <Module>.__xc_mp_z)
			{
				while (*(long*)ptr == 0L)
				{
					ptr += 8L / (long)sizeof(void*);
					if (ptr >= (void**)(&<Module>.__xc_mp_z))
					{
						goto IL_35;
					}
				}
				<Module>.?hasPerProcess@DefaultDomain@<CrtImplementationDetails>@@0W4TriBool@2@A = (TriBool)(-1);
				return 1;
			}
			IL_35:
			<Module>.?hasPerProcess@DefaultDomain@<CrtImplementationDetails>@@0W4TriBool@2@A = (TriBool)0;
			return 0;
		}
		return (<Module>.?hasPerProcess@DefaultDomain@<CrtImplementationDetails>@@0W4TriBool@2@A == (TriBool)(-1)) ? 1 : 0;
	}

	// Token: 0x06000059 RID: 89 RVA: 0x000055B4 File Offset: 0x000049B4
	[SecuritySafeCritical]
	[return: MarshalAs(UnmanagedType.U1)]
	internal unsafe static bool <CrtImplementationDetails>.DefaultDomain.HasNative()
	{
		if (<Module>.?hasNative@DefaultDomain@<CrtImplementationDetails>@@0W4TriBool@2@A == (TriBool)2)
		{
			void** ptr = (void**)(&<Module>.__xi_a);
			if (ref <Module>.__xi_a < ref <Module>.__xi_z)
			{
				while (*(long*)ptr == 0L)
				{
					ptr += 8L / (long)sizeof(void*);
					if (ptr >= (void**)(&<Module>.__xi_z))
					{
						goto IL_35;
					}
				}
				<Module>.?hasNative@DefaultDomain@<CrtImplementationDetails>@@0W4TriBool@2@A = (TriBool)(-1);
				return 1;
			}
			IL_35:
			void** ptr2 = (void**)(&<Module>.__xc_a);
			if (ref <Module>.__xc_a < ref <Module>.__xc_z)
			{
				while (*(long*)ptr2 == 0L)
				{
					ptr2 += 8L / (long)sizeof(void*);
					if (ptr2 >= (void**)(&<Module>.__xc_z))
					{
						goto IL_62;
					}
				}
				<Module>.?hasNative@DefaultDomain@<CrtImplementationDetails>@@0W4TriBool@2@A = (TriBool)(-1);
				return 1;
			}
			IL_62:
			<Module>.?hasNative@DefaultDomain@<CrtImplementationDetails>@@0W4TriBool@2@A = (TriBool)0;
			return 0;
		}
		return (<Module>.?hasNative@DefaultDomain@<CrtImplementationDetails>@@0W4TriBool@2@A == (TriBool)(-1)) ? 1 : 0;
	}

	// Token: 0x0600005A RID: 90 RVA: 0x00005634 File Offset: 0x00004A34
	[SecuritySafeCritical]
	[return: MarshalAs(UnmanagedType.U1)]
	internal static bool <CrtImplementationDetails>.DefaultDomain.NeedsInitialization()
	{
		int num;
		if ((<Module>.<CrtImplementationDetails>.DefaultDomain.HasPerProcess() != null && !<Module>.?InitializedPerProcess@DefaultDomain@<CrtImplementationDetails>@@2_NA) || (<Module>.<CrtImplementationDetails>.DefaultDomain.HasNative() != null && !<Module>.?InitializedNative@DefaultDomain@<CrtImplementationDetails>@@2_NA && <Module>.__scrt_current_native_startup_state == (__scrt_native_startup_state)0))
		{
			num = 1;
		}
		else
		{
			num = 0;
		}
		return (byte)num;
	}

	// Token: 0x0600005B RID: 91 RVA: 0x0000566C File Offset: 0x00004A6C
	[return: MarshalAs(UnmanagedType.U1)]
	internal static bool <CrtImplementationDetails>.DefaultDomain.NeedsUninitialization()
	{
		return <Module>.?Entered@DefaultDomain@<CrtImplementationDetails>@@2_NA;
	}

	// Token: 0x0600005C RID: 92 RVA: 0x00005680 File Offset: 0x00004A80
	[SecurityCritical]
	internal static void <CrtImplementationDetails>.DefaultDomain.Initialize()
	{
		<Module>.<CrtImplementationDetails>.DoCallBackInDefaultDomain(<Module>.__unep@?DoNothing@DefaultDomain@<CrtImplementationDetails>@@$$FCAJPEAX@Z, null);
	}

	// Token: 0x0600005D RID: 93 RVA: 0x00005864 File Offset: 0x00004C64
	[SecuritySafeCritical]
	[DebuggerStepThrough]
	internal unsafe static void <CrtImplementationDetails>.LanguageSupport.InitializeVtables(LanguageSupport* A_0)
	{
		<Module>.gcroot<System::String\u0020^>.=(A_0, "The C++ module failed to load during vtable initialization.\n");
		<Module>.?InitializedVtables@CurrentDomain@<CrtImplementationDetails>@@$$Q2W4Progress@2@A = (Progress)1;
		<Module>._initterm_m((method*)(&<Module>.__xi_vt_a), (method*)(&<Module>.__xi_vt_z));
		<Module>.?InitializedVtables@CurrentDomain@<CrtImplementationDetails>@@$$Q2W4Progress@2@A = (Progress)2;
	}

	// Token: 0x0600005E RID: 94 RVA: 0x00005898 File Offset: 0x00004C98
	[SecuritySafeCritical]
	internal unsafe static void <CrtImplementationDetails>.LanguageSupport.InitializeDefaultAppDomain(LanguageSupport* A_0)
	{
		<Module>.gcroot<System::String\u0020^>.=(A_0, "The C++ module failed to load while attempting to initialize the default appdomain.\n");
		<Module>.<CrtImplementationDetails>.DefaultDomain.Initialize();
	}

	// Token: 0x0600005F RID: 95 RVA: 0x000058B8 File Offset: 0x00004CB8
	[DebuggerStepThrough]
	[SecuritySafeCritical]
	internal unsafe static void <CrtImplementationDetails>.LanguageSupport.InitializeNative(LanguageSupport* A_0)
	{
		<Module>.gcroot<System::String\u0020^>.=(A_0, "The C++ module failed to load during native initialization.\n");
		<Module>.__security_init_cookie();
		<Module>.?InitializedNative@DefaultDomain@<CrtImplementationDetails>@@2_NA = true;
		if (<Module>.__scrt_is_safe_for_managed_code() == null)
		{
			<Module>.abort();
		}
		if (<Module>.__scrt_current_native_startup_state == (__scrt_native_startup_state)1)
		{
			<Module>.abort();
		}
		if (<Module>.__scrt_current_native_startup_state == (__scrt_native_startup_state)0)
		{
			<Module>.?InitializedNative@CurrentDomain@<CrtImplementationDetails>@@$$Q2W4Progress@2@A = (Progress)1;
			<Module>.__scrt_current_native_startup_state = (__scrt_native_startup_state)1;
			if (<Module>._initterm_e((method*)(&<Module>.__xi_a), (method*)(&<Module>.__xi_z)) != 0)
			{
				<Module>.<CrtImplementationDetails>.ThrowModuleLoadException(<Module>.gcroot<System::String\u0020^>..PE$AAVString@System@@(A_0));
			}
			<Module>._initterm((method*)(&<Module>.__xc_a), (method*)(&<Module>.__xc_z));
			<Module>.__scrt_current_native_startup_state = (__scrt_native_startup_state)2;
			<Module>.?InitializedNativeFromCCTOR@DefaultDomain@<CrtImplementationDetails>@@2_NA = true;
			<Module>.?InitializedNative@CurrentDomain@<CrtImplementationDetails>@@$$Q2W4Progress@2@A = (Progress)2;
		}
	}

	// Token: 0x06000060 RID: 96 RVA: 0x00005948 File Offset: 0x00004D48
	[SecurityCritical]
	[DebuggerStepThrough]
	internal unsafe static void <CrtImplementationDetails>.LanguageSupport.InitializePerProcess(LanguageSupport* A_0)
	{
		<Module>.gcroot<System::String\u0020^>.=(A_0, "The C++ module failed to load during process initialization.\n");
		<Module>.?InitializedPerProcess@CurrentDomain@<CrtImplementationDetails>@@$$Q2W4Progress@2@A = (Progress)1;
		<Module>._initatexit_m();
		<Module>._initterm_m((method*)(&<Module>.__xc_mp_a), (method*)(&<Module>.__xc_mp_z));
		<Module>.?InitializedPerProcess@CurrentDomain@<CrtImplementationDetails>@@$$Q2W4Progress@2@A = (Progress)2;
		<Module>.?InitializedPerProcess@DefaultDomain@<CrtImplementationDetails>@@2_NA = true;
	}

	// Token: 0x06000061 RID: 97 RVA: 0x00005988 File Offset: 0x00004D88
	[DebuggerStepThrough]
	[SecurityCritical]
	internal unsafe static void <CrtImplementationDetails>.LanguageSupport.InitializePerAppDomain(LanguageSupport* A_0)
	{
		<Module>.gcroot<System::String\u0020^>.=(A_0, "The C++ module failed to load during appdomain initialization.\n");
		<Module>.?InitializedPerAppDomain@CurrentDomain@<CrtImplementationDetails>@@$$Q2W4Progress@2@A = (Progress)1;
		<Module>._initatexit_app_domain();
		<Module>._initterm_m((method*)(&<Module>.__xc_ma_a), (method*)(&<Module>.__xc_ma_z));
		<Module>.?InitializedPerAppDomain@CurrentDomain@<CrtImplementationDetails>@@$$Q2W4Progress@2@A = (Progress)2;
	}

	// Token: 0x06000062 RID: 98 RVA: 0x000059C4 File Offset: 0x00004DC4
	[DebuggerStepThrough]
	[SecurityCritical]
	internal unsafe static void <CrtImplementationDetails>.LanguageSupport.InitializeUninitializer(LanguageSupport* A_0)
	{
		<Module>.gcroot<System::String\u0020^>.=(A_0, "The C++ module failed to load during registration for the unload events.\n");
		<Module>.<CrtImplementationDetails>.RegisterModuleUninitializer(new EventHandler(<Module>.<CrtImplementationDetails>.LanguageSupport.DomainUnload));
	}

	// Token: 0x06000063 RID: 99 RVA: 0x000059F0 File Offset: 0x00004DF0
	[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
	[DebuggerStepThrough]
	[SecurityCritical]
	internal unsafe static void <CrtImplementationDetails>.LanguageSupport._Initialize(LanguageSupport* A_0)
	{
		<Module>.?IsDefaultDomain@CurrentDomain@<CrtImplementationDetails>@@$$Q2_NA = AppDomain.CurrentDomain.IsDefaultAppDomain();
		<Module>.?Entered@DefaultDomain@<CrtImplementationDetails>@@2_NA = (<Module>.?IsDefaultDomain@CurrentDomain@<CrtImplementationDetails>@@$$Q2_NA || <Module>.?Entered@DefaultDomain@<CrtImplementationDetails>@@2_NA);
		void* ptr = <Module>._getFiberPtrId();
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		RuntimeHelpers.PrepareConstrainedRegions();
		try
		{
			while (num2 == 0)
			{
				try
				{
				}
				finally
				{
					void* ptr2 = Interlocked.CompareExchange(ref <Module>.__scrt_native_startup_lock, ptr, 0L);
					if (ptr2 == null)
					{
						num2 = 1;
					}
					else if (ptr2 == ptr)
					{
						num = 1;
						num2 = 1;
					}
				}
				if (num2 == 0)
				{
					<Module>.Sleep(1000);
				}
			}
			<Module>.<CrtImplementationDetails>.LanguageSupport.InitializeVtables(A_0);
			if (<Module>.?IsDefaultDomain@CurrentDomain@<CrtImplementationDetails>@@$$Q2_NA)
			{
				<Module>.<CrtImplementationDetails>.LanguageSupport.InitializeNative(A_0);
				<Module>.<CrtImplementationDetails>.LanguageSupport.InitializePerProcess(A_0);
			}
			else
			{
				num3 = ((<Module>.<CrtImplementationDetails>.DefaultDomain.NeedsInitialization() != 0) ? 1 : num3);
			}
		}
		finally
		{
			if (num == 0)
			{
				Interlocked.Exchange(ref <Module>.__scrt_native_startup_lock, 0L);
			}
		}
		if (num3 != 0)
		{
			<Module>.<CrtImplementationDetails>.LanguageSupport.InitializeDefaultAppDomain(A_0);
		}
		<Module>.<CrtImplementationDetails>.LanguageSupport.InitializePerAppDomain(A_0);
		<Module>.?Initialized@CurrentDomain@<CrtImplementationDetails>@@$$Q2HA = 1;
		<Module>.<CrtImplementationDetails>.LanguageSupport.InitializeUninitializer(A_0);
	}

	// Token: 0x06000064 RID: 100 RVA: 0x0000569C File Offset: 0x00004A9C
	[SecurityCritical]
	internal static void <CrtImplementationDetails>.LanguageSupport.UninitializeAppDomain()
	{
		<Module>._app_exit_callback();
	}

	// Token: 0x06000065 RID: 101 RVA: 0x000056B0 File Offset: 0x00004AB0
	[SecurityCritical]
	internal unsafe static int <CrtImplementationDetails>.LanguageSupport._UninitializeDefaultDomain(void* cookie)
	{
		<Module>._exit_callback();
		<Module>.?InitializedPerProcess@DefaultDomain@<CrtImplementationDetails>@@2_NA = false;
		if (<Module>.?InitializedNativeFromCCTOR@DefaultDomain@<CrtImplementationDetails>@@2_NA)
		{
			<Module>._cexit();
			<Module>.__scrt_current_native_startup_state = (__scrt_native_startup_state)0;
			<Module>.?InitializedNativeFromCCTOR@DefaultDomain@<CrtImplementationDetails>@@2_NA = false;
		}
		<Module>.?InitializedNative@DefaultDomain@<CrtImplementationDetails>@@2_NA = false;
		return 0;
	}

	// Token: 0x06000066 RID: 102 RVA: 0x000056E8 File Offset: 0x00004AE8
	[SecurityCritical]
	internal static void <CrtImplementationDetails>.LanguageSupport.UninitializeDefaultDomain()
	{
		if (<Module>.<CrtImplementationDetails>.DefaultDomain.NeedsUninitialization() != null)
		{
			if (AppDomain.CurrentDomain.IsDefaultAppDomain())
			{
				<Module>.<CrtImplementationDetails>.LanguageSupport._UninitializeDefaultDomain(null);
			}
			else
			{
				<Module>.<CrtImplementationDetails>.DoCallBackInDefaultDomain(<Module>.__unep@?_UninitializeDefaultDomain@LanguageSupport@<CrtImplementationDetails>@@$$FCAJPEAX@Z, null);
			}
		}
	}

	// Token: 0x06000067 RID: 103 RVA: 0x00005720 File Offset: 0x00004B20
	[PrePrepareMethod]
	[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
	[SecurityCritical]
	internal static void <CrtImplementationDetails>.LanguageSupport.DomainUnload(object A_0, EventArgs A_1)
	{
		if (<Module>.?Initialized@CurrentDomain@<CrtImplementationDetails>@@$$Q2HA != 0 && Interlocked.Exchange(ref <Module>.?Uninitialized@CurrentDomain@<CrtImplementationDetails>@@$$Q2HA, 1) == 0)
		{
			byte b = (Interlocked.Decrement(ref <Module>.?Count@AllDomains@<CrtImplementationDetails>@@2HA) == 0) ? 1 : 0;
			<Module>.<CrtImplementationDetails>.LanguageSupport.UninitializeAppDomain();
			if (b != 0)
			{
				<Module>.<CrtImplementationDetails>.LanguageSupport.UninitializeDefaultDomain();
			}
		}
	}

	// Token: 0x06000068 RID: 104 RVA: 0x00005AF4 File Offset: 0x00004EF4
	[SecurityCritical]
	[DebuggerStepThrough]
	[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
	internal unsafe static void <CrtImplementationDetails>.LanguageSupport.Cleanup(LanguageSupport* A_0, System.Exception innerException)
	{
		try
		{
			bool flag = ((Interlocked.Decrement(ref <Module>.?Count@AllDomains@<CrtImplementationDetails>@@2HA) == 0) ? 1 : 0) != 0;
			<Module>.<CrtImplementationDetails>.LanguageSupport.UninitializeAppDomain();
			if (flag)
			{
				<Module>.<CrtImplementationDetails>.LanguageSupport.UninitializeDefaultDomain();
			}
		}
		catch (System.Exception nestedException)
		{
			<Module>.<CrtImplementationDetails>.ThrowNestedModuleLoadException(innerException, nestedException);
		}
		catch (object obj)
		{
			<Module>.<CrtImplementationDetails>.ThrowNestedModuleLoadException(innerException, null);
		}
	}

	// Token: 0x06000069 RID: 105 RVA: 0x00005B68 File Offset: 0x00004F68
	[SecurityCritical]
	internal unsafe static LanguageSupport* <CrtImplementationDetails>.LanguageSupport.{ctor}(LanguageSupport* A_0)
	{
		<Module>.gcroot<System::String\u0020^>.{ctor}(A_0);
		return A_0;
	}

	// Token: 0x0600006A RID: 106 RVA: 0x00005B80 File Offset: 0x00004F80
	[SecurityCritical]
	internal unsafe static void <CrtImplementationDetails>.LanguageSupport.{dtor}(LanguageSupport* A_0)
	{
		<Module>.gcroot<System::String\u0020^>.{dtor}(A_0);
	}

	// Token: 0x0600006B RID: 107 RVA: 0x00005B94 File Offset: 0x00004F94
	[SecurityCritical]
	[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
	[DebuggerStepThrough]
	internal unsafe static void <CrtImplementationDetails>.LanguageSupport.Initialize(LanguageSupport* A_0)
	{
		bool flag = false;
		RuntimeHelpers.PrepareConstrainedRegions();
		try
		{
			<Module>.gcroot<System::String\u0020^>.=(A_0, "The C++ module failed to load.\n");
			RuntimeHelpers.PrepareConstrainedRegions();
			try
			{
			}
			finally
			{
				Interlocked.Increment(ref <Module>.?Count@AllDomains@<CrtImplementationDetails>@@2HA);
				flag = true;
			}
			<Module>.<CrtImplementationDetails>.LanguageSupport._Initialize(A_0);
		}
		catch (System.Exception innerException)
		{
			if (flag)
			{
				<Module>.<CrtImplementationDetails>.LanguageSupport.Cleanup(A_0, innerException);
			}
			<Module>.<CrtImplementationDetails>.ThrowModuleLoadException(<Module>.gcroot<System::String\u0020^>..PE$AAVString@System@@(A_0), innerException);
		}
		catch (object obj)
		{
			if (flag)
			{
				<Module>.<CrtImplementationDetails>.LanguageSupport.Cleanup(A_0, null);
			}
			<Module>.<CrtImplementationDetails>.ThrowModuleLoadException(<Module>.gcroot<System::String\u0020^>..PE$AAVString@System@@(A_0), null);
		}
	}

	// Token: 0x0600006C RID: 108 RVA: 0x00005C50 File Offset: 0x00005050
	[DebuggerStepThrough]
	[SecurityCritical]
	static unsafe <Module>()
	{
		LanguageSupport languageSupport;
		<Module>.<CrtImplementationDetails>.LanguageSupport.{ctor}(ref languageSupport);
		try
		{
			<Module>.<CrtImplementationDetails>.LanguageSupport.Initialize(ref languageSupport);
		}
		catch
		{
			<Module>.___CxxCallUnwindDtor(ldftn(<CrtImplementationDetails>.LanguageSupport.{dtor}), (void*)(&languageSupport));
			throw;
		}
		<Module>.<CrtImplementationDetails>.LanguageSupport.{dtor}(ref languageSupport);
	}

	// Token: 0x0600006D RID: 109 RVA: 0x0000575C File Offset: 0x00004B5C
	[SecuritySafeCritical]
	internal unsafe static string PE$AAVString@System@@(gcroot<System::String\u0020^>* A_0)
	{
		IntPtr value = new IntPtr(*A_0);
		return ((GCHandle)value).Target;
	}

	// Token: 0x0600006E RID: 110 RVA: 0x00005780 File Offset: 0x00004B80
	[SecurityCritical]
	[DebuggerStepThrough]
	internal unsafe static gcroot<System::String\u0020^>* =(gcroot<System::String\u0020^>* A_0, string t)
	{
		IntPtr value = new IntPtr(*A_0);
		((GCHandle)value).Target = t;
		return A_0;
	}

	// Token: 0x0600006F RID: 111 RVA: 0x000057A8 File Offset: 0x00004BA8
	[SecurityCritical]
	[DebuggerStepThrough]
	internal unsafe static void {dtor}(gcroot<System::String\u0020^>* A_0)
	{
		IntPtr value = new IntPtr(*A_0);
		((GCHandle)value).Free();
		*A_0 = 0L;
	}

	// Token: 0x06000070 RID: 112 RVA: 0x000057D0 File Offset: 0x00004BD0
	[DebuggerStepThrough]
	[SecuritySafeCritical]
	internal unsafe static gcroot<System::String\u0020^>* {ctor}(gcroot<System::String\u0020^>* A_0)
	{
		*A_0 = ((IntPtr)GCHandle.Alloc(null)).ToPointer();
		return A_0;
	}

	// Token: 0x06000071 RID: 113 RVA: 0x00005CC4 File Offset: 0x000050C4
	[HandleProcessCorruptedStateExceptions]
	[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
	[SecurityCritical]
	[SecurityPermission(SecurityAction.Assert, UnmanagedCode = true)]
	internal unsafe static void ___CxxCallUnwindDtor(method pDtor, void* pThis)
	{
		try
		{
			calli(System.Void(System.Void*), pThis, pDtor);
		}
		catch when (endfilter(<Module>.__FrameUnwindFilter(Marshal.GetExceptionPointers()) != null))
		{
		}
	}

	// Token: 0x06000072 RID: 114 RVA: 0x00005D08 File Offset: 0x00005108
	[SecurityCritical]
	[HandleProcessCorruptedStateExceptions]
	[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
	[SecurityPermission(SecurityAction.Assert, UnmanagedCode = true)]
	internal unsafe static void ___CxxCallUnwindDelDtor(method pDtor, void* pThis)
	{
		try
		{
			calli(System.Void(System.Void*), pThis, pDtor);
		}
		catch when (endfilter(<Module>.__FrameUnwindFilter(Marshal.GetExceptionPointers()) != null))
		{
		}
	}

	// Token: 0x06000073 RID: 115 RVA: 0x00005D4C File Offset: 0x0000514C
	[SecurityCritical]
	[HandleProcessCorruptedStateExceptions]
	[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
	[SecurityPermission(SecurityAction.Assert, UnmanagedCode = true)]
	internal unsafe static void ___CxxCallUnwindVecDtor(method pVecDtor, void* ptr, ulong size, int count, method pDtor)
	{
		try
		{
			calli(System.Void(System.Void*,System.UInt64,System.Int32,System.Void (System.Void*)), ptr, size, count, pDtor, pVecDtor);
		}
		catch when (endfilter(<Module>.__FrameUnwindFilter(Marshal.GetExceptionPointers()) != null))
		{
		}
	}

	// Token: 0x06000074 RID: 116 RVA: 0x00005E0C File Offset: 0x0000520C
	[HandleProcessCorruptedStateExceptions]
	[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
	[SecurityCritical]
	internal unsafe static void __ehvec_dtor(void* ptr, ulong size, ulong count, method destructor)
	{
		bool flag = false;
		ptr = (void*)(size * count + (byte*)ptr);
		try
		{
			for (;;)
			{
				long num = (long)count;
				count -= 1UL;
				if (num == 0L)
				{
					break;
				}
				ptr = (void*)((byte*)ptr - size);
				calli(System.Void(System.Void*), ptr, destructor);
			}
			flag = true;
		}
		finally
		{
			if (!flag)
			{
				<Module>.__ArrayUnwind(ptr, size, count, destructor);
			}
		}
	}

	// Token: 0x06000075 RID: 117 RVA: 0x00005D94 File Offset: 0x00005194
	[SecurityCritical]
	[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
	[SecurityPermission(SecurityAction.Assert, UnmanagedCode = true)]
	internal unsafe static int ArrayUnwindFilter(_EXCEPTION_POINTERS* pExPtrs)
	{
		if (*(*(long*)pExPtrs) != -529697949)
		{
			return 0;
		}
		<Module>.terminate();
		return 0;
	}

	// Token: 0x06000076 RID: 118 RVA: 0x00005DB4 File Offset: 0x000051B4
	[HandleProcessCorruptedStateExceptions]
	[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
	[SecurityCritical]
	internal unsafe static void __ArrayUnwind(void* ptr, ulong size, ulong count, method destructor)
	{
		try
		{
			for (ulong num = 0UL; num != count; num += 1UL)
			{
				ptr = (void*)((byte*)ptr - size);
				calli(System.Void(System.Void*), ptr, destructor);
			}
		}
		catch when (endfilter(<Module>.?A0x20579cfd.ArrayUnwindFilter(Marshal.GetExceptionPointers()) != null))
		{
		}
	}

	// Token: 0x06000077 RID: 119 RVA: 0x00005E68 File Offset: 0x00005268
	[SecurityCritical]
	[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
	internal unsafe static void __ehvec_dtor(void* ptr, ulong size, int count, method destructor)
	{
		<Module>.__ehvec_dtor(ptr, size, (ulong)((long)count), destructor);
	}

	// Token: 0x06000078 RID: 120 RVA: 0x00005E80 File Offset: 0x00005280
	[SecurityCritical]
	[DebuggerStepThrough]
	internal static ValueType <CrtImplementationDetails>.AtExitLock._handle()
	{
		if (<Module>.?_lock@AtExitLock@<CrtImplementationDetails>@@$$Q0PEAXEA != null)
		{
			IntPtr value = new IntPtr(<Module>.?_lock@AtExitLock@<CrtImplementationDetails>@@$$Q0PEAXEA);
			return GCHandle.FromIntPtr(value);
		}
		return null;
	}

	// Token: 0x06000079 RID: 121 RVA: 0x00006378 File Offset: 0x00005778
	[DebuggerStepThrough]
	[SecurityCritical]
	internal static void <CrtImplementationDetails>.AtExitLock._lock_Construct(object value)
	{
		<Module>.?_lock@AtExitLock@<CrtImplementationDetails>@@$$Q0PEAXEA = null;
		<Module>.<CrtImplementationDetails>.AtExitLock._lock_Set(value);
	}

	// Token: 0x0600007A RID: 122 RVA: 0x00005EB0 File Offset: 0x000052B0
	[DebuggerStepThrough]
	[SecurityCritical]
	internal static void <CrtImplementationDetails>.AtExitLock._lock_Set(object value)
	{
		ValueType valueType = <Module>.<CrtImplementationDetails>.AtExitLock._handle();
		if (valueType == null)
		{
			valueType = GCHandle.Alloc(value);
			<Module>.?_lock@AtExitLock@<CrtImplementationDetails>@@$$Q0PEAXEA = GCHandle.ToIntPtr((GCHandle)valueType).ToPointer();
		}
		else
		{
			((GCHandle)valueType).Target = value;
		}
	}

	// Token: 0x0600007B RID: 123 RVA: 0x00005F00 File Offset: 0x00005300
	[DebuggerStepThrough]
	[SecurityCritical]
	internal static object <CrtImplementationDetails>.AtExitLock._lock_Get()
	{
		ValueType valueType = <Module>.<CrtImplementationDetails>.AtExitLock._handle();
		if (valueType != null)
		{
			return ((GCHandle)valueType).Target;
		}
		return null;
	}

	// Token: 0x0600007C RID: 124 RVA: 0x00005F24 File Offset: 0x00005324
	[DebuggerStepThrough]
	[SecurityCritical]
	internal static void <CrtImplementationDetails>.AtExitLock._lock_Destruct()
	{
		ValueType valueType = <Module>.<CrtImplementationDetails>.AtExitLock._handle();
		if (valueType != null)
		{
			((GCHandle)valueType).Free();
			<Module>.?_lock@AtExitLock@<CrtImplementationDetails>@@$$Q0PEAXEA = null;
		}
	}

	// Token: 0x0600007D RID: 125 RVA: 0x00005F4C File Offset: 0x0000534C
	[SecurityCritical]
	[DebuggerStepThrough]
	[return: MarshalAs(UnmanagedType.U1)]
	internal static bool <CrtImplementationDetails>.AtExitLock.IsInitialized()
	{
		return (<Module>.<CrtImplementationDetails>.AtExitLock._lock_Get() != null) ? 1 : 0;
	}

	// Token: 0x0600007E RID: 126 RVA: 0x00006394 File Offset: 0x00005794
	[DebuggerStepThrough]
	[SecurityCritical]
	internal static void <CrtImplementationDetails>.AtExitLock.AddRef()
	{
		if (<Module>.<CrtImplementationDetails>.AtExitLock.IsInitialized() == null)
		{
			<Module>.<CrtImplementationDetails>.AtExitLock._lock_Construct(new object());
			<Module>.?_ref_count@AtExitLock@<CrtImplementationDetails>@@$$Q0HA = 0;
		}
		<Module>.?_ref_count@AtExitLock@<CrtImplementationDetails>@@$$Q0HA++;
	}

	// Token: 0x0600007F RID: 127 RVA: 0x00005F68 File Offset: 0x00005368
	[SecurityCritical]
	[DebuggerStepThrough]
	internal static void <CrtImplementationDetails>.AtExitLock.RemoveRef()
	{
		<Module>.?_ref_count@AtExitLock@<CrtImplementationDetails>@@$$Q0HA += -1;
		if (<Module>.?_ref_count@AtExitLock@<CrtImplementationDetails>@@$$Q0HA == 0)
		{
			<Module>.<CrtImplementationDetails>.AtExitLock._lock_Destruct();
		}
	}

	// Token: 0x06000080 RID: 128 RVA: 0x00005F90 File Offset: 0x00005390
	[SecurityCritical]
	[DebuggerStepThrough]
	internal static void <CrtImplementationDetails>.AtExitLock.Enter()
	{
		Monitor.Enter(<Module>.<CrtImplementationDetails>.AtExitLock._lock_Get());
	}

	// Token: 0x06000081 RID: 129 RVA: 0x00005FA8 File Offset: 0x000053A8
	[DebuggerStepThrough]
	[SecurityCritical]
	internal static void <CrtImplementationDetails>.AtExitLock.Exit()
	{
		Monitor.Exit(<Module>.<CrtImplementationDetails>.AtExitLock._lock_Get());
	}

	// Token: 0x06000082 RID: 130 RVA: 0x00005FC0 File Offset: 0x000053C0
	[SecurityCritical]
	[DebuggerStepThrough]
	[return: MarshalAs(UnmanagedType.U1)]
	internal static bool __global_lock()
	{
		bool result = false;
		if (<Module>.<CrtImplementationDetails>.AtExitLock.IsInitialized() != null)
		{
			<Module>.<CrtImplementationDetails>.AtExitLock.Enter();
			result = true;
		}
		return result;
	}

	// Token: 0x06000083 RID: 131 RVA: 0x00005FE0 File Offset: 0x000053E0
	[SecurityCritical]
	[DebuggerStepThrough]
	[return: MarshalAs(UnmanagedType.U1)]
	internal static bool __global_unlock()
	{
		bool result = false;
		if (<Module>.<CrtImplementationDetails>.AtExitLock.IsInitialized() != null)
		{
			<Module>.<CrtImplementationDetails>.AtExitLock.Exit();
			result = true;
		}
		return result;
	}

	// Token: 0x06000084 RID: 132 RVA: 0x000063C4 File Offset: 0x000057C4
	[SecurityCritical]
	[DebuggerStepThrough]
	[return: MarshalAs(UnmanagedType.U1)]
	internal static bool __alloc_global_lock()
	{
		<Module>.<CrtImplementationDetails>.AtExitLock.AddRef();
		return <Module>.<CrtImplementationDetails>.AtExitLock.IsInitialized();
	}

	// Token: 0x06000085 RID: 133 RVA: 0x00006000 File Offset: 0x00005400
	[DebuggerStepThrough]
	[SecurityCritical]
	internal static void __dealloc_global_lock()
	{
		<Module>.<CrtImplementationDetails>.AtExitLock.RemoveRef();
	}

	// Token: 0x06000086 RID: 134 RVA: 0x00006014 File Offset: 0x00005414
	[SecurityCritical]
	internal unsafe static int _atexit_helper(method func, ulong* __pexit_list_size, method** __ponexitend_e, method** __ponexitbegin_e)
	{
		method system.Void_u0020() = 0L;
		if (func == null)
		{
			return -1;
		}
		if (<Module>.?A0x3afc5bc2.__global_lock() == 1)
		{
			try
			{
				method* ptr = (method*)<Module>.DecodePointer(*(long*)__ponexitbegin_e);
				method* ptr2 = (method*)<Module>.DecodePointer(*(long*)__ponexitend_e);
				long num = (long)(ptr2 - ptr);
				if (*__pexit_list_size - 1UL < (ulong)num >> 3)
				{
					try
					{
						ulong num2 = *__pexit_list_size * 8UL;
						ulong num3 = (num2 < 4096UL) ? num2 : 4096UL;
						IntPtr cb = new IntPtr((int)(num2 + num3));
						IntPtr pv = new IntPtr((void*)ptr);
						IntPtr intPtr = Marshal.ReAllocHGlobal(pv, cb);
						ptr2 = (method*)((byte*)intPtr.ToPointer() + num);
						ptr = (method*)intPtr.ToPointer();
						ulong num4 = *__pexit_list_size;
						ulong num5 = (512UL < num4) ? 512UL : num4;
						*__pexit_list_size = num4 + num5;
					}
					catch (OutOfMemoryException)
					{
						IntPtr cb2 = new IntPtr((int)(*__pexit_list_size * 8UL + 12UL));
						IntPtr pv2 = new IntPtr((void*)ptr);
						IntPtr intPtr2 = Marshal.ReAllocHGlobal(pv2, cb2);
						ptr2 = (intPtr2.ToPointer() - ptr) / (IntPtr)sizeof(method) + ptr2;
						ptr = (method*)intPtr2.ToPointer();
						*__pexit_list_size += 4UL;
					}
				}
				*(long*)ptr2 = func;
				ptr2 += 8L / (long)sizeof(method);
				system.Void_u0020() = func;
				*(long*)__ponexitbegin_e = <Module>.EncodePointer((void*)ptr);
				*(long*)__ponexitend_e = <Module>.EncodePointer((void*)ptr2);
			}
			catch (OutOfMemoryException)
			{
			}
			finally
			{
				<Module>.?A0x3afc5bc2.__global_unlock();
			}
			if (system.Void_u0020() != null)
			{
				return 0;
			}
		}
		return -1;
	}

	// Token: 0x06000087 RID: 135 RVA: 0x0000618C File Offset: 0x0000558C
	[SecurityCritical]
	internal unsafe static void _exit_callback()
	{
		if (<Module>.?A0x3afc5bc2.__exit_list_size != 0UL)
		{
			method* ptr = (method*)<Module>.DecodePointer((void*)<Module>.?A0x3afc5bc2.__onexitbegin_m);
			method* ptr2 = (method*)<Module>.DecodePointer((void*)<Module>.?A0x3afc5bc2.__onexitend_m);
			if (ptr != -1L && ptr != null && ptr2 != null)
			{
				method* ptr3 = ptr;
				method* ptr4 = ptr2;
				for (;;)
				{
					ptr2 -= 8L / (long)sizeof(method);
					if (ptr2 < ptr)
					{
						break;
					}
					if (*(long*)ptr2 != <Module>.EncodePointer(null))
					{
						void* ptr5 = <Module>.DecodePointer(*(long*)ptr2);
						*(long*)ptr2 = <Module>.EncodePointer(null);
						calli(System.Void(), ptr5);
						method* ptr6 = (method*)<Module>.DecodePointer((void*)<Module>.?A0x3afc5bc2.__onexitbegin_m);
						method* ptr7 = (method*)<Module>.DecodePointer((void*)<Module>.?A0x3afc5bc2.__onexitend_m);
						if (ptr3 != ptr6 || ptr4 != ptr7)
						{
							ptr3 = ptr6;
							ptr = ptr6;
							ptr4 = ptr7;
							ptr2 = ptr7;
						}
					}
				}
				IntPtr hglobal = new IntPtr((void*)ptr);
				Marshal.FreeHGlobal(hglobal);
			}
			<Module>.?A0x3afc5bc2.__dealloc_global_lock();
		}
	}

	// Token: 0x06000088 RID: 136 RVA: 0x000063DC File Offset: 0x000057DC
	[DebuggerStepThrough]
	[SecurityCritical]
	internal unsafe static int _initatexit_m()
	{
		int result = 0;
		if (<Module>.?A0x3afc5bc2.__alloc_global_lock() == 1)
		{
			<Module>.?A0x3afc5bc2.__onexitbegin_m = (method*)<Module>.EncodePointer(Marshal.AllocHGlobal(256).ToPointer());
			<Module>.?A0x3afc5bc2.__onexitend_m = <Module>.?A0x3afc5bc2.__onexitbegin_m;
			<Module>.?A0x3afc5bc2.__exit_list_size = 32UL;
			result = 1;
		}
		return result;
	}

	// Token: 0x06000089 RID: 137 RVA: 0x00006424 File Offset: 0x00005824
	internal static method _onexit_m(method _Function)
	{
		return (<Module>._atexit_m(_Function) == -1) ? 0L : _Function;
	}

	// Token: 0x0600008A RID: 138 RVA: 0x0000623C File Offset: 0x0000563C
	[SecurityCritical]
	internal unsafe static int _atexit_m(method func)
	{
		return <Module>._atexit_helper(<Module>.EncodePointer(func), &<Module>.?A0x3afc5bc2.__exit_list_size, &<Module>.?A0x3afc5bc2.__onexitend_m, &<Module>.?A0x3afc5bc2.__onexitbegin_m);
	}

	// Token: 0x0600008B RID: 139 RVA: 0x00006440 File Offset: 0x00005840
	[SecurityCritical]
	[DebuggerStepThrough]
	internal unsafe static int _initatexit_app_domain()
	{
		if (<Module>.?A0x3afc5bc2.__alloc_global_lock() == 1)
		{
			<Module>.__onexitbegin_app_domain = (method*)<Module>.EncodePointer(Marshal.AllocHGlobal(256).ToPointer());
			<Module>.__onexitend_app_domain = <Module>.__onexitbegin_app_domain;
			<Module>.__exit_list_size_app_domain = 32UL;
		}
		return 1;
	}

	// Token: 0x0600008C RID: 140 RVA: 0x00006264 File Offset: 0x00005664
	[SecurityCritical]
	[HandleProcessCorruptedStateExceptions]
	internal unsafe static void _app_exit_callback()
	{
		if (<Module>.__exit_list_size_app_domain != 0UL)
		{
			method* ptr = (method*)<Module>.DecodePointer((void*)<Module>.__onexitbegin_app_domain);
			method* ptr2 = (method*)<Module>.DecodePointer((void*)<Module>.__onexitend_app_domain);
			try
			{
				if (ptr != -1L && ptr != null && ptr2 != null)
				{
					method* ptr3 = ptr;
					method* ptr4 = ptr2;
					for (;;)
					{
						do
						{
							ptr2 -= 8L / (long)sizeof(method);
						}
						while (ptr2 >= ptr && *(long*)ptr2 == <Module>.EncodePointer(null));
						if (ptr2 < ptr)
						{
							break;
						}
						method system.Void_u0020() = <Module>.DecodePointer(*(long*)ptr2);
						*(long*)ptr2 = <Module>.EncodePointer(null);
						calli(System.Void(), system.Void_u0020());
						method* ptr5 = (method*)<Module>.DecodePointer((void*)<Module>.__onexitbegin_app_domain);
						method* ptr6 = (method*)<Module>.DecodePointer((void*)<Module>.__onexitend_app_domain);
						if (ptr3 != ptr5 || ptr4 != ptr6)
						{
							ptr3 = ptr5;
							ptr = ptr5;
							ptr4 = ptr6;
							ptr2 = ptr6;
						}
					}
				}
			}
			finally
			{
				IntPtr hglobal = new IntPtr((void*)ptr);
				Marshal.FreeHGlobal(hglobal);
				<Module>.?A0x3afc5bc2.__dealloc_global_lock();
			}
		}
	}

	// Token: 0x0600008D RID: 141 RVA: 0x00006484 File Offset: 0x00005884
	[SecurityCritical]
	internal static method _onexit_m_appdomain(method _Function)
	{
		return (<Module>._atexit_m_appdomain(_Function) == -1) ? 0L : _Function;
	}

	// Token: 0x0600008E RID: 142 RVA: 0x00006350 File Offset: 0x00005750
	[DebuggerStepThrough]
	[SecurityCritical]
	internal unsafe static int _atexit_m_appdomain(method func)
	{
		return <Module>._atexit_helper(<Module>.EncodePointer(func), &<Module>.__exit_list_size_app_domain, &<Module>.__onexitend_app_domain, &<Module>.__onexitbegin_app_domain);
	}

	// Token: 0x0600008F RID: 143
	[SecurityCritical]
	[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("KERNEL32.dll")]
	public unsafe static extern void* DecodePointer(void* _Ptr);

	// Token: 0x06000090 RID: 144
	[SecurityCritical]
	[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
	[SuppressUnmanagedCodeSecurity]
	[DllImport("KERNEL32.dll")]
	public unsafe static extern void* EncodePointer(void* _Ptr);

	// Token: 0x06000091 RID: 145 RVA: 0x000064A0 File Offset: 0x000058A0
	[SecurityCritical]
	[DebuggerStepThrough]
	internal unsafe static int _initterm_e(method* pfbegin, method* pfend)
	{
		int num = 0;
		if (pfbegin < pfend)
		{
			while (num == 0)
			{
				ulong num2 = (ulong)(*(long*)pfbegin);
				if (num2 != 0UL)
				{
					num = calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvCdecl)(), num2);
				}
				pfbegin += 8L / (long)sizeof(method);
				if (pfbegin >= pfend)
				{
					break;
				}
			}
		}
		return num;
	}

	// Token: 0x06000092 RID: 146 RVA: 0x000064D0 File Offset: 0x000058D0
	[DebuggerStepThrough]
	[SecurityCritical]
	internal unsafe static void _initterm(method* pfbegin, method* pfend)
	{
		if (pfbegin < pfend)
		{
			do
			{
				ulong num = (ulong)(*(long*)pfbegin);
				if (num != 0UL)
				{
					calli(System.Void modopt(System.Runtime.CompilerServices.CallConvCdecl)(), num);
				}
				pfbegin += 8L / (long)sizeof(method);
			}
			while (pfbegin < pfend);
		}
	}

	// Token: 0x06000093 RID: 147 RVA: 0x000064F8 File Offset: 0x000058F8
	[DebuggerStepThrough]
	internal static ModuleHandle <CrtImplementationDetails>.ThisModule.Handle()
	{
		return typeof(ThisModule).Module.ModuleHandle;
	}

	// Token: 0x06000094 RID: 148 RVA: 0x00006548 File Offset: 0x00005948
	[SecurityCritical]
	[DebuggerStepThrough]
	[SecurityPermission(SecurityAction.Assert, UnmanagedCode = true)]
	internal unsafe static void _initterm_m(method* pfbegin, method* pfend)
	{
		if (pfbegin < pfend)
		{
			do
			{
				ulong num = (ulong)(*(long*)pfbegin);
				if (num != 0UL)
				{
					object obj = calli(System.Void modopt(System.Runtime.CompilerServices.IsConst)*(), <Module>.<CrtImplementationDetails>.ThisModule.ResolveMethod<void\u0020const\u0020*\u0020__clrcall(void)>(num));
				}
				pfbegin += 8L / (long)sizeof(method);
			}
			while (pfbegin < pfend);
		}
	}

	// Token: 0x06000095 RID: 149 RVA: 0x0000651C File Offset: 0x0000591C
	[SecurityCritical]
	[DebuggerStepThrough]
	internal static method <CrtImplementationDetails>.ThisModule.ResolveMethod<void\u0020const\u0020*\u0020__clrcall(void)>(method methodToken)
	{
		return <Module>.<CrtImplementationDetails>.ThisModule.Handle().ResolveMethodHandle(methodToken).GetFunctionPointer().ToPointer();
	}

	// Token: 0x06000096 RID: 150 RVA: 0x00002610 File Offset: 0x00001A10
	[SuppressUnmanagedCodeSecurity]
	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig)]
	internal unsafe static extern AVFormatContext* open_file(sbyte*);

	// Token: 0x06000097 RID: 151 RVA: 0x000066D1 File Offset: 0x00005AD1
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal static extern void _invalid_parameter_noinfo_noreturn();

	// Token: 0x06000098 RID: 152 RVA: 0x000066BF File Offset: 0x00005ABF
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern int WideCharToMultiByte(uint, uint, char*, int, sbyte*, int, sbyte*, int*);

	// Token: 0x06000099 RID: 153 RVA: 0x00006698 File Offset: 0x00005A98
	[SuppressUnmanagedCodeSecurity]
	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig)]
	internal unsafe static extern void* new[](ulong);

	// Token: 0x0600009A RID: 154 RVA: 0x000066AD File Offset: 0x00005AAD
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern void __ExceptionPtrDestroy(void*);

	// Token: 0x0600009B RID: 155 RVA: 0x0000447C File Offset: 0x0000387C
	[SuppressUnmanagedCodeSecurity]
	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig)]
	internal unsafe static extern void delete(void*, ulong);

	// Token: 0x0600009C RID: 156 RVA: 0x00004DF0 File Offset: 0x000041F0
	[SuppressUnmanagedCodeSecurity]
	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig)]
	internal unsafe static extern void delete(void*);

	// Token: 0x0600009D RID: 157 RVA: 0x000065CF File Offset: 0x000059CF
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern void __std_exception_copy(__std_exception_data*, __std_exception_data*);

	// Token: 0x0600009E RID: 158 RVA: 0x000066B9 File Offset: 0x00005AB9
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal static extern void _Xbad_alloc();

	// Token: 0x0600009F RID: 159 RVA: 0x000066B3 File Offset: 0x00005AB3
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern void __ExceptionPtrCopy(void*, void*);

	// Token: 0x060000A0 RID: 160 RVA: 0x0000665C File Offset: 0x00005A5C
	[SuppressUnmanagedCodeSecurity]
	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig)]
	internal unsafe static extern void* @new(ulong);

	// Token: 0x060000A1 RID: 161 RVA: 0x00001030 File Offset: 0x00000430
	[SuppressUnmanagedCodeSecurity]
	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig)]
	internal unsafe static extern int avcodec_decode_video2(AVCodecContext*, AVFrame*, int*, AVPacket*);

	// Token: 0x060000A2 RID: 162 RVA: 0x000010D8 File Offset: 0x000004D8
	[SuppressUnmanagedCodeSecurity]
	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig)]
	internal unsafe static extern AVFrame* av_frame_alloc();

	// Token: 0x060000A3 RID: 163 RVA: 0x00001080 File Offset: 0x00000480
	[SuppressUnmanagedCodeSecurity]
	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig)]
	internal unsafe static extern int avformat_find_stream_info(AVFormatContext*, AVDictionary**);

	// Token: 0x060000A4 RID: 164 RVA: 0x00001100 File Offset: 0x00000500
	[SuppressUnmanagedCodeSecurity]
	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig)]
	internal unsafe static extern void sws_freeContext(SwsContext*);

	// Token: 0x060000A5 RID: 165 RVA: 0x00001070 File Offset: 0x00000470
	[SuppressUnmanagedCodeSecurity]
	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig)]
	internal static extern void av_register_all();

	// Token: 0x060000A6 RID: 166 RVA: 0x00001088 File Offset: 0x00000488
	[SuppressUnmanagedCodeSecurity]
	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig)]
	internal unsafe static extern AVRational av_stream_get_r_frame_rate(AVStream*);

	// Token: 0x060000A7 RID: 167 RVA: 0x00001018 File Offset: 0x00000418
	[SuppressUnmanagedCodeSecurity]
	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig)]
	internal unsafe static extern void av_free_packet(AVPacket*);

	// Token: 0x060000A8 RID: 168 RVA: 0x00001010 File Offset: 0x00000410
	[SuppressUnmanagedCodeSecurity]
	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig)]
	internal unsafe static extern int avcodec_close(AVCodecContext*);

	// Token: 0x060000A9 RID: 169 RVA: 0x00001028 File Offset: 0x00000428
	[SuppressUnmanagedCodeSecurity]
	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig)]
	internal unsafe static extern int avcodec_open2(AVCodecContext*, AVCodec*, AVDictionary**);

	// Token: 0x060000AA RID: 170 RVA: 0x00001078 File Offset: 0x00000478
	[SuppressUnmanagedCodeSecurity]
	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig)]
	internal unsafe static extern void avformat_close_input(AVFormatContext**);

	// Token: 0x060000AB RID: 171 RVA: 0x00001108 File Offset: 0x00000508
	[SuppressUnmanagedCodeSecurity]
	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig)]
	internal unsafe static extern int sws_scale(SwsContext*, byte**, int*, int, int, byte**, int*);

	// Token: 0x060000AC RID: 172 RVA: 0x00001110 File Offset: 0x00000510
	[SuppressUnmanagedCodeSecurity]
	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig)]
	internal unsafe static extern SwsContext* sws_getContext(int, int, AVPixelFormat, int, int, AVPixelFormat, int, SwsFilter*, SwsFilter*, double*);

	// Token: 0x060000AD RID: 173 RVA: 0x000010D0 File Offset: 0x000004D0
	[SuppressUnmanagedCodeSecurity]
	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig)]
	internal unsafe static extern void av_free(void*);

	// Token: 0x060000AE RID: 174 RVA: 0x00001090 File Offset: 0x00000490
	[SuppressUnmanagedCodeSecurity]
	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig)]
	internal unsafe static extern int av_read_frame(AVFormatContext*, AVPacket*);

	// Token: 0x060000AF RID: 175 RVA: 0x00001020 File Offset: 0x00000420
	[SuppressUnmanagedCodeSecurity]
	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig)]
	internal unsafe static extern AVCodec* avcodec_find_decoder(AVCodecID);

	// Token: 0x060000B0 RID: 176 RVA: 0x000066A0 File Offset: 0x00005AA0
	[SuppressUnmanagedCodeSecurity]
	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig)]
	internal unsafe static extern void delete[](void*, ulong);

	// Token: 0x060000B1 RID: 177 RVA: 0x000065D5 File Offset: 0x000059D5
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern void __std_exception_destroy(__std_exception_data*);

	// Token: 0x060000B2 RID: 178 RVA: 0x000010F8 File Offset: 0x000004F8
	[SuppressUnmanagedCodeSecurity]
	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig)]
	internal unsafe static extern void av_freep(void*);

	// Token: 0x060000B3 RID: 179 RVA: 0x000010B8 File Offset: 0x000004B8
	[SuppressUnmanagedCodeSecurity]
	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig)]
	internal unsafe static extern AVOutputFormat* av_guess_format(sbyte*, sbyte*, sbyte*);

	// Token: 0x060000B4 RID: 180 RVA: 0x000010A8 File Offset: 0x000004A8
	[SuppressUnmanagedCodeSecurity]
	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig)]
	internal unsafe static extern int av_write_trailer(AVFormatContext*);

	// Token: 0x060000B5 RID: 181 RVA: 0x00001048 File Offset: 0x00000448
	[SuppressUnmanagedCodeSecurity]
	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig)]
	internal static extern int avpicture_get_size(AVPixelFormat, int, int);

	// Token: 0x060000B6 RID: 182 RVA: 0x000010A0 File Offset: 0x000004A0
	[SuppressUnmanagedCodeSecurity]
	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig)]
	internal unsafe static extern AVStream* avformat_new_stream(AVFormatContext*, AVCodec*);

	// Token: 0x060000B7 RID: 183 RVA: 0x000010C0 File Offset: 0x000004C0
	[SuppressUnmanagedCodeSecurity]
	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig)]
	internal unsafe static extern int avio_open(AVIOContext**, sbyte*, int);

	// Token: 0x060000B8 RID: 184 RVA: 0x000010C8 File Offset: 0x000004C8
	[SuppressUnmanagedCodeSecurity]
	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig)]
	internal unsafe static extern int avformat_write_header(AVFormatContext*, AVDictionary**);

	// Token: 0x060000B9 RID: 185 RVA: 0x00001050 File Offset: 0x00000450
	[SuppressUnmanagedCodeSecurity]
	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig)]
	internal unsafe static extern int avpicture_fill(AVPicture*, byte*, AVPixelFormat, int, int);

	// Token: 0x060000BA RID: 186 RVA: 0x00001000 File Offset: 0x00000400
	[SuppressUnmanagedCodeSecurity]
	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig)]
	internal unsafe static extern AVFormatContext* avformat_alloc_context();

	// Token: 0x060000BB RID: 187 RVA: 0x00001068 File Offset: 0x00000468
	[SuppressUnmanagedCodeSecurity]
	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig)]
	internal unsafe static extern int avcodec_encode_audio2(AVCodecContext*, AVPacket*, AVFrame*, int*);

	// Token: 0x060000BC RID: 188 RVA: 0x00001058 File Offset: 0x00000458
	[SuppressUnmanagedCodeSecurity]
	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig)]
	internal unsafe static extern AVCodec* avcodec_find_encoder(AVCodecID);

	// Token: 0x060000BD RID: 189 RVA: 0x00001038 File Offset: 0x00000438
	[SuppressUnmanagedCodeSecurity]
	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig)]
	internal unsafe static extern void av_init_packet(AVPacket*);

	// Token: 0x060000BE RID: 190 RVA: 0x000010E0 File Offset: 0x000004E0
	[SuppressUnmanagedCodeSecurity]
	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig)]
	internal unsafe static extern int av_strerror(int, sbyte*, ulong);

	// Token: 0x060000BF RID: 191 RVA: 0x00001098 File Offset: 0x00000498
	[SuppressUnmanagedCodeSecurity]
	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig)]
	internal unsafe static extern int av_interleaved_write_frame(AVFormatContext*, AVPacket*);

	// Token: 0x060000C0 RID: 192 RVA: 0x000010F0 File Offset: 0x000004F0
	[SuppressUnmanagedCodeSecurity]
	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig)]
	internal unsafe static extern void* av_malloc(ulong);

	// Token: 0x060000C1 RID: 193 RVA: 0x00001040 File Offset: 0x00000440
	[SuppressUnmanagedCodeSecurity]
	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig)]
	internal unsafe static extern int avcodec_encode_video2(AVCodecContext*, AVPacket*, AVFrame*, int*);

	// Token: 0x060000C2 RID: 194 RVA: 0x000010E8 File Offset: 0x000004E8
	[SuppressUnmanagedCodeSecurity]
	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig)]
	internal static extern long av_rescale_q(long, AVRational, AVRational);

	// Token: 0x060000C3 RID: 195 RVA: 0x000010B0 File Offset: 0x000004B0
	[SuppressUnmanagedCodeSecurity]
	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig)]
	internal unsafe static extern int avio_close(AVIOContext*);

	// Token: 0x060000C4 RID: 196 RVA: 0x00001060 File Offset: 0x00000460
	[SuppressUnmanagedCodeSecurity]
	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig)]
	internal unsafe static extern void avcodec_flush_buffers(AVCodecContext*);

	// Token: 0x060000C5 RID: 197 RVA: 0x000066A8 File Offset: 0x00005AA8
	[SuppressUnmanagedCodeSecurity]
	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig)]
	internal unsafe static extern void delete[](void*);

	// Token: 0x060000C6 RID: 198 RVA: 0x00005530 File Offset: 0x00004930
	[SuppressUnmanagedCodeSecurity]
	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig)]
	internal unsafe static extern void* _getFiberPtrId();

	// Token: 0x060000C7 RID: 199 RVA: 0x0000662F File Offset: 0x00005A2F
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal static extern void _cexit();

	// Token: 0x060000C8 RID: 200 RVA: 0x000066C5 File Offset: 0x00005AC5
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal static extern void Sleep(uint);

	// Token: 0x060000C9 RID: 201 RVA: 0x000066D7 File Offset: 0x00005AD7
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal static extern void abort();

	// Token: 0x060000CA RID: 202 RVA: 0x000044F0 File Offset: 0x000038F0
	[SuppressUnmanagedCodeSecurity]
	[MethodImpl(MethodImplOptions.Unmanaged | MethodImplOptions.PreserveSig)]
	internal static extern void __security_init_cookie();

	// Token: 0x060000CB RID: 203 RVA: 0x000066CB File Offset: 0x00005ACB
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal unsafe static extern int __FrameUnwindFilter(_EXCEPTION_POINTERS*);

	// Token: 0x060000CC RID: 204 RVA: 0x00006635 File Offset: 0x00005A35
	[SuppressUnmanagedCodeSecurity]
	[DllImport("", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
	[MethodImpl(MethodImplOptions.Unmanaged)]
	internal static extern void terminate();

	// Token: 0x04000001 RID: 1 RVA: 0x0002200C File Offset: 0x0002020C
	internal static int AUDIO_CODECS_COUNT;

	// Token: 0x04000002 RID: 2 RVA: 0x00022000 File Offset: 0x00020200
	internal static $ArrayType$$$BY02H audio_codecs;

	// Token: 0x04000003 RID: 3 RVA: 0x00022010 File Offset: 0x00020210
	internal static $ArrayType$$$BY0BA@H video_codecs;

	// Token: 0x04000004 RID: 4 RVA: 0x00022090 File Offset: 0x00020290
	internal static int CODECS_COUNT;

	// Token: 0x04000005 RID: 5 RVA: 0x00022050 File Offset: 0x00020250
	internal static $ArrayType$$$BY0BA@H pixel_formats;

	// Token: 0x04000006 RID: 6 RVA: 0x000083A8 File Offset: 0x00006BA8
	internal static $ArrayType$$$BY0BC@$$CBD ??_C@_0BC@EOODALEL@Unknown?5exception?$AA@;

	// Token: 0x04000007 RID: 7 RVA: 0x00022BA8 File Offset: 0x00020DA8
	internal static $_TypeDescriptor$_extraBytes_27 ??_R0?AVfailure@ios_base@std@@@8;

	// Token: 0x04000008 RID: 8 RVA: 0x00022B08 File Offset: 0x00020D08
	internal static $_TypeDescriptor$_extraBytes_24 ??_R0?AVruntime_error@std@@@8;

	// Token: 0x04000009 RID: 9 RVA: 0x000201C0 File Offset: 0x0001E9C0
	internal static _s__RTTICompleteObjectLocator2 ??_R4exception@std@@6B@;

	// Token: 0x0400000A RID: 10 RVA: 0x00020398 File Offset: 0x0001EB98
	internal static $_s__RTTIBaseClassArray$_extraBytes_32 ??_R2system_error@std@@8;

	// Token: 0x0400000B RID: 11 RVA: 0x00020370 File Offset: 0x0001EB70
	internal static _s__RTTIBaseClassDescriptor2 ??_R1A@?0A@EA@system_error@std@@8;

	// Token: 0x0400000C RID: 12 RVA: 0x00020240 File Offset: 0x0001EA40
	internal static _s__RTTICompleteObjectLocator2 ??_R4runtime_error@std@@6B@;

	// Token: 0x0400000D RID: 13 RVA: 0x000202C8 File Offset: 0x0001EAC8
	internal static _s__RTTICompleteObjectLocator2 ??_R4_System_error@std@@6B@;

	// Token: 0x0400000E RID: 14 RVA: 0x000202F0 File Offset: 0x0001EAF0
	internal static _s__RTTIBaseClassDescriptor2 ??_R1A@?0A@EA@bad_cast@std@@8;

	// Token: 0x0400000F RID: 15 RVA: 0x000201E8 File Offset: 0x0001E9E8
	internal static _s__RTTIBaseClassDescriptor2 ??_R1A@?0A@EA@runtime_error@std@@8;

	// Token: 0x04000010 RID: 16 RVA: 0x00020290 File Offset: 0x0001EA90
	internal static $_s__RTTIBaseClassArray$_extraBytes_24 ??_R2_System_error@std@@8;

	// Token: 0x04000011 RID: 17 RVA: 0x00022B80 File Offset: 0x00020D80
	internal static $_TypeDescriptor$_extraBytes_23 ??_R0?AVsystem_error@std@@@8;

	// Token: 0x04000012 RID: 18 RVA: 0x00020170 File Offset: 0x0001E970
	internal static _s__RTTIBaseClassDescriptor2 ??_R1A@?0A@EA@exception@std@@8;

	// Token: 0x04000013 RID: 19 RVA: 0x000203D8 File Offset: 0x0001EBD8
	internal static _s__RTTICompleteObjectLocator2 ??_R4system_error@std@@6B@;

	// Token: 0x04000014 RID: 20 RVA: 0x000202B0 File Offset: 0x0001EAB0
	internal static _s__RTTIClassHierarchyDescriptor ??_R3_System_error@std@@8;

	// Token: 0x04000015 RID: 21 RVA: 0x00020318 File Offset: 0x0001EB18
	internal static $_s__RTTIBaseClassArray$_extraBytes_16 ??_R2bad_cast@std@@8;

	// Token: 0x04000016 RID: 22 RVA: 0x00020198 File Offset: 0x0001E998
	internal static $_s__RTTIBaseClassArray$_extraBytes_8 ??_R2exception@std@@8;

	// Token: 0x04000017 RID: 23 RVA: 0x00020470 File Offset: 0x0001EC70
	internal static _s__RTTICompleteObjectLocator2 ??_R4failure@ios_base@std@@6B@;

	// Token: 0x04000018 RID: 24 RVA: 0x00022168 File Offset: 0x00020368
	internal static $ArrayType$$$BY02Q6AXXZ ??_7bad_cast@std@@6B@;

	// Token: 0x04000019 RID: 25 RVA: 0x00022B58 File Offset: 0x00020D58
	internal static $_TypeDescriptor$_extraBytes_19 ??_R0?AVbad_cast@std@@@8;

	// Token: 0x0400001A RID: 26 RVA: 0x00020428 File Offset: 0x0001EC28
	internal static $_s__RTTIBaseClassArray$_extraBytes_40 ??_R2failure@ios_base@std@@8;

	// Token: 0x0400001B RID: 27 RVA: 0x00020458 File Offset: 0x0001EC58
	internal static _s__RTTIClassHierarchyDescriptor ??_R3failure@ios_base@std@@8;

	// Token: 0x0400001C RID: 28 RVA: 0x000220A0 File Offset: 0x000202A0
	internal static $ArrayType$$$BY02Q6AXXZ ??_7exception@std@@6B@;

	// Token: 0x0400001D RID: 29 RVA: 0x000201A8 File Offset: 0x0001E9A8
	internal static _s__RTTIClassHierarchyDescriptor ??_R3exception@std@@8;

	// Token: 0x0400001E RID: 30 RVA: 0x00022108 File Offset: 0x00020308
	internal static $ArrayType$$$BY02Q6AXXZ ??_7runtime_error@std@@6B@;

	// Token: 0x0400001F RID: 31 RVA: 0x00022140 File Offset: 0x00020340
	internal static $ArrayType$$$BY02Q6AXXZ ??_7_System_error@std@@6B@;

	// Token: 0x04000020 RID: 32 RVA: 0x00020400 File Offset: 0x0001EC00
	internal static _s__RTTIBaseClassDescriptor2 ??_R1A@?0A@EA@failure@ios_base@std@@8;

	// Token: 0x04000021 RID: 33 RVA: 0x00020268 File Offset: 0x0001EA68
	internal static _s__RTTIBaseClassDescriptor2 ??_R1A@?0A@EA@_System_error@std@@8;

	// Token: 0x04000022 RID: 34 RVA: 0x00020330 File Offset: 0x0001EB30
	internal static _s__RTTIClassHierarchyDescriptor ??_R3bad_cast@std@@8;

	// Token: 0x04000023 RID: 35 RVA: 0x00020348 File Offset: 0x0001EB48
	internal static _s__RTTICompleteObjectLocator2 ??_R4bad_cast@std@@6B@;

	// Token: 0x04000024 RID: 36 RVA: 0x00020210 File Offset: 0x0001EA10
	internal static $_s__RTTIBaseClassArray$_extraBytes_16 ??_R2runtime_error@std@@8;

	// Token: 0x04000025 RID: 37 RVA: 0x00022B30 File Offset: 0x00020D30
	internal static $_TypeDescriptor$_extraBytes_24 ??_R0?AV_System_error@std@@@8;

	// Token: 0x04000026 RID: 38 RVA: 0x000203C0 File Offset: 0x0001EBC0
	internal static _s__RTTIClassHierarchyDescriptor ??_R3system_error@std@@8;

	// Token: 0x04000027 RID: 39 RVA: 0x00022AE0 File Offset: 0x00020CE0
	internal static $_TypeDescriptor$_extraBytes_20 ??_R0?AVexception@std@@@8;

	// Token: 0x04000028 RID: 40 RVA: 0x00022190 File Offset: 0x00020390
	internal static $ArrayType$$$BY02Q6AXXZ ??_7system_error@std@@6B@;

	// Token: 0x04000029 RID: 41 RVA: 0x00020228 File Offset: 0x0001EA28
	internal static _s__RTTIClassHierarchyDescriptor ??_R3runtime_error@std@@8;

	// Token: 0x0400002A RID: 42 RVA: 0x000221C8 File Offset: 0x000203C8
	internal static $ArrayType$$$BY02Q6AXXZ ??_7failure@ios_base@std@@6B@;

	// Token: 0x0400002B RID: 43 RVA: 0x000220B0 File Offset: 0x000202B0
	public static method __m2mep@??0exception@std@@$$FQEAA@AEBV01@@Z;

	// Token: 0x0400002C RID: 44 RVA: 0x00022238 File Offset: 0x00020438
	public static method __m2mep@??1exception@std@@$$FUEAA@XZ;

	// Token: 0x0400002D RID: 45 RVA: 0x00022228 File Offset: 0x00020428
	public static method __m2mep@?what@exception@std@@$$FUEBAPEBDXZ;

	// Token: 0x0400002E RID: 46 RVA: 0x00022218 File Offset: 0x00020418
	public static method __m2mep@??_Eexception@std@@$$FUEAAPEAXI@Z;

	// Token: 0x0400002F RID: 47 RVA: 0x00022248 File Offset: 0x00020448
	public static method __m2mep@??1exception_ptr@std@@$$FQEAA@XZ;

	// Token: 0x04000030 RID: 48 RVA: 0x000220C0 File Offset: 0x000202C0
	public static method __m2mep@??0exception_ptr@std@@$$FQEAA@AEBV01@@Z;

	// Token: 0x04000031 RID: 49 RVA: 0x000220D0 File Offset: 0x000202D0
	public static method __m2mep@?<MarshalCopy>@exception_ptr@std@@$$FSMXPEAV12@0@Z;

	// Token: 0x04000032 RID: 50 RVA: 0x000220E0 File Offset: 0x000202E0
	public static method __m2mep@?<MarshalDestroy>@exception_ptr@std@@$$FSMXPEAV12@@Z;

	// Token: 0x04000033 RID: 51 RVA: 0x00022258 File Offset: 0x00020458
	public static method __m2mep@?max@?$numeric_limits@_J@std@@$$FSA_JXZ;

	// Token: 0x04000034 RID: 52 RVA: 0x00022268 File Offset: 0x00020468
	public static method __m2mep@??2@$$FYAPEAX_KPEAX@Z;

	// Token: 0x04000035 RID: 53 RVA: 0x00022278 File Offset: 0x00020478
	public static method __m2mep@?copy@?$char_traits@D@std@@$$FSAPEADQEADQEBD_K@Z;

	// Token: 0x04000036 RID: 54 RVA: 0x00022288 File Offset: 0x00020488
	public static method __m2mep@?assign@?$char_traits@D@std@@$$FSAXAEADAEBD@Z;

	// Token: 0x04000037 RID: 55 RVA: 0x00022298 File Offset: 0x00020498
	public static method __m2mep@?_Orphan_all@_Container_base0@std@@$$FQEAAXXZ;

	// Token: 0x04000038 RID: 56 RVA: 0x000220F0 File Offset: 0x000202F0
	public static method __m2mep@??0_Container_base12@std@@$$FQEAA@AEBU01@@Z;

	// Token: 0x04000039 RID: 57 RVA: 0x000221B0 File Offset: 0x000203B0
	public static method __m2mep@??0_Iterator_base12@std@@$$FQEAA@AEBU01@@Z;

	// Token: 0x0400003A RID: 58 RVA: 0x00022458 File Offset: 0x00020658
	public static method __m2mep@??4_Iterator_base12@std@@$$FQEAAAEAU01@AEBU01@@Z;

	// Token: 0x0400003B RID: 59 RVA: 0x000222A8 File Offset: 0x000204A8
	public static method __m2mep@?_Adopt@_Iterator_base12@std@@$$FQEAAXPEBU_Container_base12@2@@Z;

	// Token: 0x0400003C RID: 60 RVA: 0x000222B8 File Offset: 0x000204B8
	public static method __m2mep@?_Allocate@std@@$$FYAPEAX_K0_N@Z;

	// Token: 0x0400003D RID: 61 RVA: 0x000222C8 File Offset: 0x000204C8
	public static method __m2mep@?_Deallocate@std@@$$FYAXPEAX_K1@Z;

	// Token: 0x0400003E RID: 62 RVA: 0x000222E8 File Offset: 0x000204E8
	public static method __m2mep@??_Eruntime_error@std@@$$FUEAAPEAXI@Z;

	// Token: 0x0400003F RID: 63 RVA: 0x000222D8 File Offset: 0x000204D8
	public static method __m2mep@??1runtime_error@std@@$$FUEAA@XZ;

	// Token: 0x04000040 RID: 64 RVA: 0x00022418 File Offset: 0x00020618
	public static method __m2mep@??_Ebad_cast@std@@$$FUEAAPEAXI@Z;

	// Token: 0x04000041 RID: 65 RVA: 0x00022598 File Offset: 0x00020798
	public static method __m2mep@??1bad_cast@std@@$$FUEAA@XZ;

	// Token: 0x04000042 RID: 66 RVA: 0x00022118 File Offset: 0x00020318
	public static method __m2mep@??0runtime_error@std@@$$FQEAA@AEBV01@@Z;

	// Token: 0x04000043 RID: 67 RVA: 0x00022128 File Offset: 0x00020328
	public static method __m2mep@??0locale@std@@$$FQEAA@AEBV01@@Z;

	// Token: 0x04000044 RID: 68 RVA: 0x000221F8 File Offset: 0x000203F8
	public static method __m2mep@?<MarshalCopy>@?$basic_string@DU?$char_traits@D@std@@V?$allocator@D@2@@std@@$$FSMXPEAV12@0@Z;

	// Token: 0x04000045 RID: 69 RVA: 0x00022208 File Offset: 0x00020408
	public static method __m2mep@?<MarshalDestroy>@?$basic_string@DU?$char_traits@D@std@@V?$allocator@D@2@@std@@$$FSMXPEAV12@@Z;

	// Token: 0x04000046 RID: 70 RVA: 0x00022318 File Offset: 0x00020518
	public static method __m2mep@??_E_System_error@std@@$$FUEAAPEAXI@Z;

	// Token: 0x04000047 RID: 71 RVA: 0x000222F8 File Offset: 0x000204F8
	public static method __m2mep@??1_System_error@std@@$$FUEAA@XZ;

	// Token: 0x04000048 RID: 72 RVA: 0x00022468 File Offset: 0x00020668
	public static method __m2mep@??_Esystem_error@std@@$$FUEAAPEAXI@Z;

	// Token: 0x04000049 RID: 73 RVA: 0x00022308 File Offset: 0x00020508
	public static method __m2mep@??1system_error@std@@$$FUEAA@XZ;

	// Token: 0x0400004A RID: 74 RVA: 0x00022538 File Offset: 0x00020738
	public static method __m2mep@??_Efailure@ios_base@std@@$$FUEAAPEAXI@Z;

	// Token: 0x0400004B RID: 75 RVA: 0x000225A8 File Offset: 0x000207A8
	public static method __m2mep@??1failure@ios_base@std@@$$FUEAA@XZ;

	// Token: 0x0400004C RID: 76 RVA: 0x000221D8 File Offset: 0x000203D8
	public static method __m2mep@??0failure@ios_base@std@@$$FQEAA@AEBV012@@Z;

	// Token: 0x0400004D RID: 77 RVA: 0x000221A0 File Offset: 0x000203A0
	public static method __m2mep@??0system_error@std@@$$FQEAA@AEBV01@@Z;

	// Token: 0x0400004E RID: 78 RVA: 0x00022150 File Offset: 0x00020350
	public static method __m2mep@??0_System_error@std@@$$FQEAA@AEBV01@@Z;

	// Token: 0x0400004F RID: 79 RVA: 0x00022588 File Offset: 0x00020788
	public static method __m2mep@??1?$basic_string@DU?$char_traits@D@std@@V?$allocator@D@2@@std@@$$FQEAA@XZ;

	// Token: 0x04000050 RID: 80 RVA: 0x000221E8 File Offset: 0x000203E8
	public static method __m2mep@??0?$basic_string@DU?$char_traits@D@std@@V?$allocator@D@2@@std@@$$FQEAA@AEBV01@@Z;

	// Token: 0x04000051 RID: 81 RVA: 0x00022578 File Offset: 0x00020778
	public static method __m2mep@??1?$_String_alloc@U?$_String_base_types@DV?$allocator@D@std@@@std@@@std@@$$FQEAA@XZ;

	// Token: 0x04000052 RID: 82 RVA: 0x00022548 File Offset: 0x00020748
	public static method __m2mep@??1?$_Compressed_pair@V?$allocator@D@std@@V?$_String_val@U?$_Simple_types@D@std@@@2@$00@std@@$$FQEAA@XZ;

	// Token: 0x04000053 RID: 83 RVA: 0x00022478 File Offset: 0x00020678
	public static method __m2mep@??1?$_String_val@U?$_Simple_types@D@std@@@std@@$$FQEAA@XZ;

	// Token: 0x04000054 RID: 84 RVA: 0x00022328 File Offset: 0x00020528
	public static method __m2mep@??1_Bxty@?$_String_val@U?$_Simple_types@D@std@@@std@@$$FQEAA@XZ;

	// Token: 0x04000055 RID: 85 RVA: 0x00022338 File Offset: 0x00020538
	public static method __m2mep@?_Large_string_engaged@?$_String_val@U?$_Simple_types@D@std@@@std@@$$FQEBA_NXZ;

	// Token: 0x04000056 RID: 86 RVA: 0x00022488 File Offset: 0x00020688
	public static method __m2mep@?_Myptr@?$_String_val@U?$_Simple_types@D@std@@@std@@$$FQEBAPEBDXZ;

	// Token: 0x04000057 RID: 87 RVA: 0x00022348 File Offset: 0x00020548
	public static method __m2mep@?select_on_container_copy_construction@?$_Default_allocator_traits@V?$allocator@D@std@@@std@@$$FSA?AV?$allocator@D@2@AEBV32@@Z;

	// Token: 0x04000058 RID: 88 RVA: 0x00022498 File Offset: 0x00020698
	public static method __m2mep@?_Get_data@?$_String_alloc@U?$_String_base_types@DV?$allocator@D@std@@@std@@@std@@$$FQEBAAEBV?$_String_val@U?$_Simple_types@D@std@@@2@XZ;

	// Token: 0x04000059 RID: 89 RVA: 0x000224A8 File Offset: 0x000206A8
	public static method __m2mep@?_Get_data@?$_String_alloc@U?$_String_base_types@DV?$allocator@D@std@@@std@@@std@@$$FQEAAAEAV?$_String_val@U?$_Simple_types@D@std@@@2@XZ;

	// Token: 0x0400005A RID: 90 RVA: 0x000224B8 File Offset: 0x000206B8
	public static method __m2mep@?_Getal@?$_String_alloc@U?$_String_base_types@DV?$allocator@D@std@@@std@@@std@@$$FQEBAAEBV?$allocator@D@2@XZ;

	// Token: 0x0400005B RID: 91 RVA: 0x000224C8 File Offset: 0x000206C8
	public static method __m2mep@?_Getal@?$_String_alloc@U?$_String_base_types@DV?$allocator@D@std@@@std@@@std@@$$FQEAAAEAV?$allocator@D@2@XZ;

	// Token: 0x0400005C RID: 92 RVA: 0x000224D8 File Offset: 0x000206D8
	public static method __m2mep@?_Orphan_all@?$_String_alloc@U?$_String_base_types@DV?$allocator@D@std@@@std@@@std@@$$FQEAAXXZ;

	// Token: 0x0400005D RID: 93 RVA: 0x000224E8 File Offset: 0x000206E8
	public static method __m2mep@?_Tidy_deallocate@?$basic_string@DU?$char_traits@D@std@@V?$allocator@D@2@@std@@$$FQEAAXXZ;

	// Token: 0x0400005E RID: 94 RVA: 0x000224F8 File Offset: 0x000206F8
	public static method __m2mep@?max_size@?$basic_string@DU?$char_traits@D@std@@V?$allocator@D@2@@std@@$$FQEBA_KXZ;

	// Token: 0x0400005F RID: 95 RVA: 0x00022358 File Offset: 0x00020558
	public static method __m2mep@??$_Max_value@_K@std@@$$FYAAEB_KAEB_K0@Z;

	// Token: 0x04000060 RID: 96 RVA: 0x00022558 File Offset: 0x00020758
	public static method __m2mep@?_Construct_lv_contents@?$basic_string@DU?$char_traits@D@std@@V?$allocator@D@2@@std@@$$FQEAAXAEBV12@@Z;

	// Token: 0x04000061 RID: 97 RVA: 0x00022368 File Offset: 0x00020568
	public static method __m2mep@?allocate@?$allocator@D@std@@$$FQEAAPEAD_K@Z;

	// Token: 0x04000062 RID: 98 RVA: 0x00022378 File Offset: 0x00020578
	public static method __m2mep@?deallocate@?$allocator@D@std@@$$FQEAAXQEAD_K@Z;

	// Token: 0x04000063 RID: 99 RVA: 0x00022388 File Offset: 0x00020588
	public static method __m2mep@?_Get_second@?$_Compressed_pair@V?$allocator@D@std@@V?$_String_val@U?$_Simple_types@D@std@@@2@$00@std@@$$FQEBAAEBV?$_String_val@U?$_Simple_types@D@std@@@2@XZ;

	// Token: 0x04000064 RID: 100 RVA: 0x00022398 File Offset: 0x00020598
	public static method __m2mep@?_Get_second@?$_Compressed_pair@V?$allocator@D@std@@V?$_String_val@U?$_Simple_types@D@std@@@2@$00@std@@$$FQEAAAEAV?$_String_val@U?$_Simple_types@D@std@@@2@XZ;

	// Token: 0x04000065 RID: 101 RVA: 0x000223A8 File Offset: 0x000205A8
	public static method __m2mep@?_Get_first@?$_Compressed_pair@V?$allocator@D@std@@V?$_String_val@U?$_Simple_types@D@std@@@2@$00@std@@$$FQEBAAEBV?$allocator@D@2@XZ;

	// Token: 0x04000066 RID: 102 RVA: 0x000223B8 File Offset: 0x000205B8
	public static method __m2mep@?_Get_first@?$_Compressed_pair@V?$allocator@D@std@@V?$_String_val@U?$_Simple_types@D@std@@@2@$00@std@@$$FQEAAAEAV?$allocator@D@2@XZ;

	// Token: 0x04000067 RID: 103 RVA: 0x000223C8 File Offset: 0x000205C8
	public static method __m2mep@?max_size@?$_Default_allocator_traits@V?$allocator@D@std@@@std@@$$FSA_KAEBV?$allocator@D@2@@Z;

	// Token: 0x04000068 RID: 104 RVA: 0x000223D8 File Offset: 0x000205D8
	public static method __m2mep@??$_Min_value@_K@std@@$$FYAAEB_KAEB_K0@Z;

	// Token: 0x04000069 RID: 105 RVA: 0x000223E8 File Offset: 0x000205E8
	public static method __m2mep@??$_Unfancy@D@std@@$$FYAPEADPEAD@Z;

	// Token: 0x0400006A RID: 106 RVA: 0x00022568 File Offset: 0x00020768
	public static method __m2mep@??$?0V?$allocator@D@std@@X@?$_String_alloc@U?$_String_base_types@DV?$allocator@D@std@@@std@@@std@@$$FQEAA@$$QEAV?$allocator@D@1@@Z;

	// Token: 0x0400006B RID: 107 RVA: 0x000223F8 File Offset: 0x000205F8
	public static method __m2mep@??$addressof@PEAD@std@@$$FYAPEAPEADAEAPEAD@Z;

	// Token: 0x0400006C RID: 108 RVA: 0x00022408 File Offset: 0x00020608
	public static method __m2mep@??$destroy@PEAD@?$_Default_allocator_traits@V?$allocator@D@std@@@std@@$$FSAXAEAV?$allocator@D@1@QEAPEAD@Z;

	// Token: 0x0400006D RID: 109 RVA: 0x00022508 File Offset: 0x00020708
	public static method __m2mep@??$construct@PEADAEBQEAD@?$_Default_allocator_traits@V?$allocator@D@std@@@std@@$$FSAXAEAV?$allocator@D@1@QEAPEADAEBQEAD@Z;

	// Token: 0x0400006E RID: 110 RVA: 0x00022178 File Offset: 0x00020378
	public static method __m2mep@??0bad_cast@std@@$$FQEAA@AEBV01@@Z;

	// Token: 0x0400006F RID: 111 RVA: 0x00022518 File Offset: 0x00020718
	public static method __m2mep@??0?$_String_val@U?$_Simple_types@D@std@@@std@@$$FQEAA@XZ;

	// Token: 0x04000070 RID: 112 RVA: 0x00022428 File Offset: 0x00020628
	public static method __m2mep@??0_Bxty@?$_String_val@U?$_Simple_types@D@std@@@std@@$$FQEAA@XZ;

	// Token: 0x04000071 RID: 113 RVA: 0x00022438 File Offset: 0x00020638
	public static method __m2mep@??$forward@V?$allocator@D@std@@@std@@$$FYA$$QEAV?$allocator@D@0@AEAV10@@Z;

	// Token: 0x04000072 RID: 114 RVA: 0x00022528 File Offset: 0x00020728
	public static method __m2mep@??$?0V?$allocator@D@std@@$$V@?$_Compressed_pair@V?$allocator@D@std@@V?$_String_val@U?$_Simple_types@D@std@@@2@$00@std@@$$FQEAA@U_One_then_variadic_args_t@1@$$QEAV?$allocator@D@1@@Z;

	// Token: 0x04000073 RID: 115 RVA: 0x00022448 File Offset: 0x00020648
	public static method __m2mep@??$forward@AEBQEAD@std@@$$FYAAEBQEADAEBQEAD@Z;

	// Token: 0x04000074 RID: 116 RVA: 0x000083C0 File Offset: 0x00006BC0
	internal static $ArrayType$$$BY08$$CBD ??_C@_08KMNKOELM@matroska?$AA@;

	// Token: 0x04000075 RID: 117 RVA: 0x00022608 File Offset: 0x00020808
	public static method __m2mep@?av_make_error_string@?A0xbc0632da@@$$J0YAPEADPEAD_KH@Z;

	// Token: 0x04000076 RID: 118 RVA: 0x000225B8 File Offset: 0x000207B8
	public static method __m2mep@?write_video_frame@FFMPEG@Video@Accord@@$$FYMXPE$AAUWriterPrivateData@123@@Z;

	// Token: 0x04000077 RID: 119 RVA: 0x00022618 File Offset: 0x00020818
	public static method __m2mep@?alloc_picture@?A0xbc0632da@FFMPEG@Video@Accord@@$$FYAPEAUAVFrame@libffmpeg@@W4AVPixelFormat@6@HH@Z;

	// Token: 0x04000078 RID: 120 RVA: 0x000225C8 File Offset: 0x000207C8
	public static method __m2mep@?add_video_stream@FFMPEG@Video@Accord@@$$FYMXPE$AAUWriterPrivateData@123@HHVRational@Math@3@HW4AVCodecID@libffmpeg@@W4AVPixelFormat@8@@Z;

	// Token: 0x04000079 RID: 121 RVA: 0x000225D8 File Offset: 0x000207D8
	public static method __m2mep@?open_video@FFMPEG@Video@Accord@@$$FYMXPE$AAUWriterPrivateData@123@@Z;

	// Token: 0x0400007A RID: 122 RVA: 0x000225E8 File Offset: 0x000207E8
	public static method __m2mep@?add_audio_stream@FFMPEG@Video@Accord@@$$FYMXPE$AAUWriterPrivateData@123@W4AVCodecID@libffmpeg@@@Z;

	// Token: 0x0400007B RID: 123 RVA: 0x000225F8 File Offset: 0x000207F8
	public static method __m2mep@?open_audio@FFMPEG@Video@Accord@@$$FYMXPE$AAUWriterPrivateData@123@@Z;

	// Token: 0x0400007C RID: 124 RVA: 0x00008450 File Offset: 0x00006C50
	internal static __s_GUID _GUID_cb2f6723_ab3a_11d2_9c40_00c04fa30a3e;

	// Token: 0x0400007D RID: 125 RVA: 0x00008440 File Offset: 0x00006C40
	internal static __s_GUID _GUID_cb2f6722_ab3a_11d2_9c40_00c04fa30a3e;

	// Token: 0x0400007E RID: 126 RVA: 0x00008460 File Offset: 0x00006C60
	internal static __s_GUID _GUID_90f1a06c_7712_4762_86b5_7a5eba6bdb02;

	// Token: 0x0400007F RID: 127 RVA: 0x00008470 File Offset: 0x00006C70
	internal static __s_GUID _GUID_90f1a06e_7712_4762_86b5_7a5eba6bdb02;

	// Token: 0x04000080 RID: 128 RVA: 0x00022CDC File Offset: 0x00020EDC
	internal static int ?Uninitialized@CurrentDomain@<CrtImplementationDetails>@@$$Q2HA;

	// Token: 0x04000081 RID: 129 RVA: 0x00022CF0 File Offset: 0x00020EF0
	internal static Progress ?InitializedPerAppDomain@CurrentDomain@<CrtImplementationDetails>@@$$Q2W4Progress@2@A;

	// Token: 0x04000082 RID: 130 RVA: 0x00022CD4 File Offset: 0x00020ED4
	internal static bool ?Entered@DefaultDomain@<CrtImplementationDetails>@@2_NA;

	// Token: 0x04000083 RID: 131 RVA: 0x00022664 File Offset: 0x00020864
	internal static TriBool ?hasNative@DefaultDomain@<CrtImplementationDetails>@@0W4TriBool@2@A;

	// Token: 0x04000084 RID: 132 RVA: 0x00022CD7 File Offset: 0x00020ED7
	internal static bool ?InitializedPerProcess@DefaultDomain@<CrtImplementationDetails>@@2_NA;

	// Token: 0x04000085 RID: 133 RVA: 0x00022CD0 File Offset: 0x00020ED0
	internal static int ?Count@AllDomains@<CrtImplementationDetails>@@2HA;

	// Token: 0x04000086 RID: 134 RVA: 0x00022CD8 File Offset: 0x00020ED8
	internal static int ?Initialized@CurrentDomain@<CrtImplementationDetails>@@$$Q2HA;

	// Token: 0x04000087 RID: 135 RVA: 0x00022CE8 File Offset: 0x00020EE8
	internal static Progress ?InitializedNative@CurrentDomain@<CrtImplementationDetails>@@$$Q2W4Progress@2@A;

	// Token: 0x04000088 RID: 136 RVA: 0x00022CD6 File Offset: 0x00020ED6
	internal static bool ?InitializedNativeFromCCTOR@DefaultDomain@<CrtImplementationDetails>@@2_NA;

	// Token: 0x04000089 RID: 137 RVA: 0x00022CE0 File Offset: 0x00020EE0
	internal static bool ?IsDefaultDomain@CurrentDomain@<CrtImplementationDetails>@@$$Q2_NA;

	// Token: 0x0400008A RID: 138 RVA: 0x00022CE4 File Offset: 0x00020EE4
	internal static Progress ?InitializedVtables@CurrentDomain@<CrtImplementationDetails>@@$$Q2W4Progress@2@A;

	// Token: 0x0400008B RID: 139 RVA: 0x00022CD5 File Offset: 0x00020ED5
	internal static bool ?InitializedNative@DefaultDomain@<CrtImplementationDetails>@@2_NA;

	// Token: 0x0400008C RID: 140 RVA: 0x00022CEC File Offset: 0x00020EEC
	internal static Progress ?InitializedPerProcess@CurrentDomain@<CrtImplementationDetails>@@$$Q2W4Progress@2@A;

	// Token: 0x0400008D RID: 141 RVA: 0x00022660 File Offset: 0x00020860
	internal static TriBool ?hasPerProcess@DefaultDomain@<CrtImplementationDetails>@@0W4TriBool@2@A;

	// Token: 0x0400008E RID: 142 RVA: 0x00008348 File Offset: 0x00006B48
	internal static $ArrayType$$$BY00Q6MPEBXXZ __xc_mp_z;

	// Token: 0x0400008F RID: 143 RVA: 0x00008358 File Offset: 0x00006B58
	internal static $ArrayType$$$BY00Q6MPEBXXZ __xi_vt_z;

	// Token: 0x04000090 RID: 144 RVA: 0x00008330 File Offset: 0x00006B30
	internal static $ArrayType$$$BY00Q6MPEBXXZ __xc_ma_a;

	// Token: 0x04000091 RID: 145 RVA: 0x00008338 File Offset: 0x00006B38
	internal static $ArrayType$$$BY00Q6MPEBXXZ __xc_ma_z;

	// Token: 0x04000092 RID: 146 RVA: 0x00008350 File Offset: 0x00006B50
	internal static $ArrayType$$$BY00Q6MPEBXXZ __xi_vt_a;

	// Token: 0x04000093 RID: 147 RVA: 0x00008340 File Offset: 0x00006B40
	internal static $ArrayType$$$BY00Q6MPEBXXZ __xc_mp_a;

	// Token: 0x04000094 RID: 148 RVA: 0x000227E8 File Offset: 0x000209E8
	public static method __m2mep@?ThrowNestedModuleLoadException@<CrtImplementationDetails>@@$$FYMXPE$AAVException@System@@0@Z;

	// Token: 0x04000095 RID: 149 RVA: 0x00022678 File Offset: 0x00020878
	public static method __m2mep@?ThrowModuleLoadException@<CrtImplementationDetails>@@$$FYMXPE$AAVString@System@@@Z;

	// Token: 0x04000096 RID: 150 RVA: 0x00022688 File Offset: 0x00020888
	public static method __m2mep@?ThrowModuleLoadException@<CrtImplementationDetails>@@$$FYMXPE$AAVString@System@@PE$AAVException@3@@Z;

	// Token: 0x04000097 RID: 151 RVA: 0x00022698 File Offset: 0x00020898
	public static method __m2mep@?RegisterModuleUninitializer@<CrtImplementationDetails>@@$$FYMXPE$AAVEventHandler@System@@@Z;

	// Token: 0x04000098 RID: 152 RVA: 0x000226A8 File Offset: 0x000208A8
	public static method __m2mep@?FromGUID@<CrtImplementationDetails>@@$$FYM?AVGuid@System@@AEBU_GUID@@@Z;

	// Token: 0x04000099 RID: 153 RVA: 0x000226B8 File Offset: 0x000208B8
	public static method __m2mep@?__get_default_appdomain@@$$FYAJPEAPEAUIUnknown@@@Z;

	// Token: 0x0400009A RID: 154 RVA: 0x000226C8 File Offset: 0x000208C8
	public static method __m2mep@?__release_appdomain@@$$FYAXPEAUIUnknown@@@Z;

	// Token: 0x0400009B RID: 155 RVA: 0x000226D8 File Offset: 0x000208D8
	public static method __m2mep@?GetDefaultDomain@<CrtImplementationDetails>@@$$FYMPE$AAVAppDomain@System@@XZ;

	// Token: 0x0400009C RID: 156 RVA: 0x000226E8 File Offset: 0x000208E8
	public static method __m2mep@?DoCallBackInDefaultDomain@<CrtImplementationDetails>@@$$FYAXP6AJPEAX@Z0@Z;

	// Token: 0x0400009D RID: 157 RVA: 0x000226F8 File Offset: 0x000208F8
	public static method __m2mep@?__scrt_is_safe_for_managed_code@@$$FYA_NXZ;

	// Token: 0x0400009E RID: 158 RVA: 0x00022708 File Offset: 0x00020908
	public static method __m2mep@?DoNothing@DefaultDomain@<CrtImplementationDetails>@@$$FCAJPEAX@Z;

	// Token: 0x0400009F RID: 159 RVA: 0x00022718 File Offset: 0x00020918
	public static method __m2mep@?HasPerProcess@DefaultDomain@<CrtImplementationDetails>@@$$FSA_NXZ;

	// Token: 0x040000A0 RID: 160 RVA: 0x00022728 File Offset: 0x00020928
	public static method __m2mep@?HasNative@DefaultDomain@<CrtImplementationDetails>@@$$FSA_NXZ;

	// Token: 0x040000A1 RID: 161 RVA: 0x00022738 File Offset: 0x00020938
	public static method __m2mep@?NeedsInitialization@DefaultDomain@<CrtImplementationDetails>@@$$FSA_NXZ;

	// Token: 0x040000A2 RID: 162 RVA: 0x00022748 File Offset: 0x00020948
	public static method __m2mep@?NeedsUninitialization@DefaultDomain@<CrtImplementationDetails>@@$$FSA_NXZ;

	// Token: 0x040000A3 RID: 163 RVA: 0x00022758 File Offset: 0x00020958
	public static method __m2mep@?Initialize@DefaultDomain@<CrtImplementationDetails>@@$$FSAXXZ;

	// Token: 0x040000A4 RID: 164 RVA: 0x000227F8 File Offset: 0x000209F8
	public static method __m2mep@?InitializeVtables@LanguageSupport@<CrtImplementationDetails>@@$$FAEAAXXZ;

	// Token: 0x040000A5 RID: 165 RVA: 0x00022808 File Offset: 0x00020A08
	public static method __m2mep@?InitializeDefaultAppDomain@LanguageSupport@<CrtImplementationDetails>@@$$FAEAAXXZ;

	// Token: 0x040000A6 RID: 166 RVA: 0x00022818 File Offset: 0x00020A18
	public static method __m2mep@?InitializeNative@LanguageSupport@<CrtImplementationDetails>@@$$FAEAAXXZ;

	// Token: 0x040000A7 RID: 167 RVA: 0x00022828 File Offset: 0x00020A28
	public static method __m2mep@?InitializePerProcess@LanguageSupport@<CrtImplementationDetails>@@$$FAEAAXXZ;

	// Token: 0x040000A8 RID: 168 RVA: 0x00022838 File Offset: 0x00020A38
	public static method __m2mep@?InitializePerAppDomain@LanguageSupport@<CrtImplementationDetails>@@$$FAEAAXXZ;

	// Token: 0x040000A9 RID: 169 RVA: 0x00022848 File Offset: 0x00020A48
	public static method __m2mep@?InitializeUninitializer@LanguageSupport@<CrtImplementationDetails>@@$$FAEAAXXZ;

	// Token: 0x040000AA RID: 170 RVA: 0x00022858 File Offset: 0x00020A58
	public static method __m2mep@?_Initialize@LanguageSupport@<CrtImplementationDetails>@@$$FAEAAXXZ;

	// Token: 0x040000AB RID: 171 RVA: 0x00022768 File Offset: 0x00020968
	public static method __m2mep@?UninitializeAppDomain@LanguageSupport@<CrtImplementationDetails>@@$$FCAXXZ;

	// Token: 0x040000AC RID: 172 RVA: 0x00022778 File Offset: 0x00020978
	public static method __m2mep@?_UninitializeDefaultDomain@LanguageSupport@<CrtImplementationDetails>@@$$FCAJPEAX@Z;

	// Token: 0x040000AD RID: 173 RVA: 0x00022788 File Offset: 0x00020988
	public static method __m2mep@?UninitializeDefaultDomain@LanguageSupport@<CrtImplementationDetails>@@$$FCAXXZ;

	// Token: 0x040000AE RID: 174 RVA: 0x00022798 File Offset: 0x00020998
	public static method __m2mep@?DomainUnload@LanguageSupport@<CrtImplementationDetails>@@$$FCMXPE$AAVObject@System@@PE$AAVEventArgs@4@@Z;

	// Token: 0x040000AF RID: 175 RVA: 0x00022868 File Offset: 0x00020A68
	public static method __m2mep@?Cleanup@LanguageSupport@<CrtImplementationDetails>@@$$FAEAMXPE$AAVException@System@@@Z;

	// Token: 0x040000B0 RID: 176 RVA: 0x00022878 File Offset: 0x00020A78
	public static method __m2mep@??0LanguageSupport@<CrtImplementationDetails>@@$$FQEAA@XZ;

	// Token: 0x040000B1 RID: 177 RVA: 0x00022888 File Offset: 0x00020A88
	public static method __m2mep@??1LanguageSupport@<CrtImplementationDetails>@@$$FQEAA@XZ;

	// Token: 0x040000B2 RID: 178 RVA: 0x00022898 File Offset: 0x00020A98
	public static method __m2mep@?Initialize@LanguageSupport@<CrtImplementationDetails>@@$$FQEAAXXZ;

	// Token: 0x040000B3 RID: 179 RVA: 0x00022668 File Offset: 0x00020868
	public static method cctor@@$$FYMXXZ;

	// Token: 0x040000B4 RID: 180 RVA: 0x000227A8 File Offset: 0x000209A8
	public static method __m2mep@??B?$gcroot@PE$AAVString@System@@@@$$FQEBMPE$AAVString@System@@XZ;

	// Token: 0x040000B5 RID: 181 RVA: 0x000227B8 File Offset: 0x000209B8
	public static method __m2mep@??4?$gcroot@PE$AAVString@System@@@@$$FQEAMAEAU0@PE$AAVString@System@@@Z;

	// Token: 0x040000B6 RID: 182 RVA: 0x000227C8 File Offset: 0x000209C8
	public static method __m2mep@??1?$gcroot@PE$AAVString@System@@@@$$FQEAA@XZ;

	// Token: 0x040000B7 RID: 183 RVA: 0x000227D8 File Offset: 0x000209D8
	public static method __m2mep@??0?$gcroot@PE$AAVString@System@@@@$$FQEAA@XZ;

	// Token: 0x040000B8 RID: 184 RVA: 0x00008480 File Offset: 0x00006C80
	public unsafe static int** __unep@?DoNothing@DefaultDomain@<CrtImplementationDetails>@@$$FCAJPEAX@Z;

	// Token: 0x040000B9 RID: 185 RVA: 0x00008488 File Offset: 0x00006C88
	public unsafe static int** __unep@?_UninitializeDefaultDomain@LanguageSupport@<CrtImplementationDetails>@@$$FCAJPEAX@Z;

	// Token: 0x040000BA RID: 186 RVA: 0x000228A8 File Offset: 0x00020AA8
	public static method __m2mep@?___CxxCallUnwindDtor@@$$J0YMXP6MXPEAX@Z0@Z;

	// Token: 0x040000BB RID: 187 RVA: 0x000228B8 File Offset: 0x00020AB8
	public static method __m2mep@?___CxxCallUnwindDelDtor@@$$J0YMXP6MXPEAX@Z0@Z;

	// Token: 0x040000BC RID: 188 RVA: 0x000228C8 File Offset: 0x00020AC8
	public static method __m2mep@?___CxxCallUnwindVecDtor@@$$J0YMXP6MXPEAX_KHP6MX0@Z@Z01H2@Z;

	// Token: 0x040000BD RID: 189 RVA: 0x000228E8 File Offset: 0x00020AE8
	public static method __m2mep@??_M@$$FYMXPEAX_K1P6MX0@Z@Z;

	// Token: 0x040000BE RID: 190 RVA: 0x00022908 File Offset: 0x00020B08
	public static method __m2mep@?ArrayUnwindFilter@?A0x20579cfd@@$$FYAHPEAU_EXCEPTION_POINTERS@@@Z;

	// Token: 0x040000BF RID: 191 RVA: 0x000228D8 File Offset: 0x00020AD8
	public static method __m2mep@?__ArrayUnwind@@$$FYMXPEAX_K1P6MX0@Z@Z;

	// Token: 0x040000C0 RID: 192 RVA: 0x000228F8 File Offset: 0x00020AF8
	public static method __m2mep@??_M@$$FYMXPEAX_KHP6MX0@Z@Z;

	// Token: 0x040000C1 RID: 193 RVA: 0x00022E08 File Offset: 0x00021008
	internal unsafe static method* __onexitbegin_m;

	// Token: 0x040000C2 RID: 194 RVA: 0x00022E18 File Offset: 0x00021018
	internal static ulong __exit_list_size;

	// Token: 0x040000C3 RID: 195
	[FixedAddressValueType]
	internal unsafe static method* __onexitend_app_domain;

	// Token: 0x040000C4 RID: 196 RVA: 0x00022DE8 File Offset: 0x00020FE8
	internal unsafe static void* ?_lock@AtExitLock@<CrtImplementationDetails>@@$$Q0PEAXEA;

	// Token: 0x040000C5 RID: 197 RVA: 0x00022DF0 File Offset: 0x00020FF0
	internal static int ?_ref_count@AtExitLock@<CrtImplementationDetails>@@$$Q0HA;

	// Token: 0x040000C6 RID: 198 RVA: 0x00022E10 File Offset: 0x00021010
	internal unsafe static method* __onexitend_m;

	// Token: 0x040000C7 RID: 199
	[FixedAddressValueType]
	internal static ulong __exit_list_size_app_domain;

	// Token: 0x040000C8 RID: 200
	[FixedAddressValueType]
	internal unsafe static method* __onexitbegin_app_domain;

	// Token: 0x040000C9 RID: 201 RVA: 0x000229A8 File Offset: 0x00020BA8
	public static method __m2mep@?_handle@AtExitLock@<CrtImplementationDetails>@@$$FCMPE$AA__ZVGCHandle@InteropServices@Runtime@System@@XZ;

	// Token: 0x040000CA RID: 202 RVA: 0x00022A58 File Offset: 0x00020C58
	public static method __m2mep@?_lock_Construct@AtExitLock@<CrtImplementationDetails>@@$$FCMXPE$AAVObject@System@@@Z;

	// Token: 0x040000CB RID: 203 RVA: 0x000229B8 File Offset: 0x00020BB8
	public static method __m2mep@?_lock_Set@AtExitLock@<CrtImplementationDetails>@@$$FCMXPE$AAVObject@System@@@Z;

	// Token: 0x040000CC RID: 204 RVA: 0x000229C8 File Offset: 0x00020BC8
	public static method __m2mep@?_lock_Get@AtExitLock@<CrtImplementationDetails>@@$$FCMPE$AAVObject@System@@XZ;

	// Token: 0x040000CD RID: 205 RVA: 0x000229D8 File Offset: 0x00020BD8
	public static method __m2mep@?_lock_Destruct@AtExitLock@<CrtImplementationDetails>@@$$FCAXXZ;

	// Token: 0x040000CE RID: 206 RVA: 0x000229E8 File Offset: 0x00020BE8
	public static method __m2mep@?IsInitialized@AtExitLock@<CrtImplementationDetails>@@$$FSA_NXZ;

	// Token: 0x040000CF RID: 207 RVA: 0x00022A68 File Offset: 0x00020C68
	public static method __m2mep@?AddRef@AtExitLock@<CrtImplementationDetails>@@$$FSAXXZ;

	// Token: 0x040000D0 RID: 208 RVA: 0x000229F8 File Offset: 0x00020BF8
	public static method __m2mep@?RemoveRef@AtExitLock@<CrtImplementationDetails>@@$$FSAXXZ;

	// Token: 0x040000D1 RID: 209 RVA: 0x00022A08 File Offset: 0x00020C08
	public static method __m2mep@?Enter@AtExitLock@<CrtImplementationDetails>@@$$FSAXXZ;

	// Token: 0x040000D2 RID: 210 RVA: 0x00022A18 File Offset: 0x00020C18
	public static method __m2mep@?Exit@AtExitLock@<CrtImplementationDetails>@@$$FSAXXZ;

	// Token: 0x040000D3 RID: 211 RVA: 0x00022A28 File Offset: 0x00020C28
	public static method __m2mep@?__global_lock@?A0x3afc5bc2@@$$FYA_NXZ;

	// Token: 0x040000D4 RID: 212 RVA: 0x00022A38 File Offset: 0x00020C38
	public static method __m2mep@?__global_unlock@?A0x3afc5bc2@@$$FYA_NXZ;

	// Token: 0x040000D5 RID: 213 RVA: 0x00022A78 File Offset: 0x00020C78
	public static method __m2mep@?__alloc_global_lock@?A0x3afc5bc2@@$$FYA_NXZ;

	// Token: 0x040000D6 RID: 214 RVA: 0x00022A48 File Offset: 0x00020C48
	public static method __m2mep@?__dealloc_global_lock@?A0x3afc5bc2@@$$FYAXXZ;

	// Token: 0x040000D7 RID: 215 RVA: 0x00022918 File Offset: 0x00020B18
	public static method __m2mep@?_atexit_helper@@$$J0YMHP6MXXZPEA_KPEAPEAP6MXXZ2@Z;

	// Token: 0x040000D8 RID: 216 RVA: 0x00022928 File Offset: 0x00020B28
	public static method __m2mep@?_exit_callback@@$$J0YMXXZ;

	// Token: 0x040000D9 RID: 217 RVA: 0x00022968 File Offset: 0x00020B68
	public static method __m2mep@?_initatexit_m@@$$J0YMHXZ;

	// Token: 0x040000DA RID: 218 RVA: 0x00022978 File Offset: 0x00020B78
	public static method __m2mep@?_onexit_m@@$$J0YMP6MHXZP6MHXZ@Z;

	// Token: 0x040000DB RID: 219 RVA: 0x00022938 File Offset: 0x00020B38
	public static method __m2mep@?_atexit_m@@$$J0YMHP6MXXZ@Z;

	// Token: 0x040000DC RID: 220 RVA: 0x00022988 File Offset: 0x00020B88
	public static method __m2mep@?_initatexit_app_domain@@$$J0YMHXZ;

	// Token: 0x040000DD RID: 221 RVA: 0x00022948 File Offset: 0x00020B48
	public static method __m2mep@?_app_exit_callback@@$$J0YMXXZ;

	// Token: 0x040000DE RID: 222 RVA: 0x00022998 File Offset: 0x00020B98
	public static method __m2mep@?_onexit_m_appdomain@@$$J0YMP6MHXZP6MHXZ@Z;

	// Token: 0x040000DF RID: 223 RVA: 0x00022958 File Offset: 0x00020B58
	public static method __m2mep@?_atexit_m_appdomain@@$$J0YMHP6MXXZ@Z;

	// Token: 0x040000E0 RID: 224 RVA: 0x00022A88 File Offset: 0x00020C88
	public static method __m2mep@?_initterm_e@@$$FYMHPEAP6AHXZ0@Z;

	// Token: 0x040000E1 RID: 225 RVA: 0x00022A98 File Offset: 0x00020C98
	public static method __m2mep@?_initterm@@$$FYMXPEAP6AXXZ0@Z;

	// Token: 0x040000E2 RID: 226 RVA: 0x00022AB8 File Offset: 0x00020CB8
	public static method __m2mep@?Handle@ThisModule@<CrtImplementationDetails>@@$$FCM?AVModuleHandle@System@@XZ;

	// Token: 0x040000E3 RID: 227 RVA: 0x00022AA8 File Offset: 0x00020CA8
	public static method __m2mep@?_initterm_m@@$$FYMXPEBQ6MPEBXXZ0@Z;

	// Token: 0x040000E4 RID: 228 RVA: 0x00022AC8 File Offset: 0x00020CC8
	public static method __m2mep@??$ResolveMethod@$$A6MPEBXXZ@ThisModule@<CrtImplementationDetails>@@$$FSMP6MPEBXXZP6MPEBXXZ@Z;

	// Token: 0x040000E5 RID: 229 RVA: 0x000083D8 File Offset: 0x00006BD8
	internal static $ArrayType$$$BY01Q6AXXZ ??_7type_info@@6B@;

	// Token: 0x040000E6 RID: 230 RVA: 0x00022010 File Offset: 0x00020210
	internal static $ArrayType$$$BY0A@H video_codecs;

	// Token: 0x040000E7 RID: 231 RVA: 0x00022050 File Offset: 0x00020250
	internal static $ArrayType$$$BY0A@H pixel_formats;

	// Token: 0x040000E8 RID: 232 RVA: 0x00022000 File Offset: 0x00020200
	internal static $ArrayType$$$BY0A@H audio_codecs;

	// Token: 0x040000E9 RID: 233 RVA: 0x00008308 File Offset: 0x00006B08
	internal static $ArrayType$$$BY0A@P6AHXZ __xi_z;

	// Token: 0x040000EA RID: 234 RVA: 0x00022C80 File Offset: 0x00020E80
	internal static __scrt_native_startup_state __scrt_current_native_startup_state;

	// Token: 0x040000EB RID: 235 RVA: 0x00022C88 File Offset: 0x00020E88
	internal unsafe static void* __scrt_native_startup_lock;

	// Token: 0x040000EC RID: 236 RVA: 0x000082F0 File Offset: 0x00006AF0
	internal static $ArrayType$$$BY0A@P6AXXZ __xc_a;

	// Token: 0x040000ED RID: 237 RVA: 0x00008300 File Offset: 0x00006B00
	internal static $ArrayType$$$BY0A@P6AHXZ __xi_a;

	// Token: 0x040000EE RID: 238 RVA: 0x00022634 File Offset: 0x00020834
	internal static uint __scrt_native_dllmain_reason;

	// Token: 0x040000EF RID: 239 RVA: 0x000082F8 File Offset: 0x00006AF8
	internal static $ArrayType$$$BY0A@P6AXXZ __xc_z;
}
