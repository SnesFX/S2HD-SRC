﻿using System;
using System.Runtime.CompilerServices;
using System.Security;

namespace System
{
	/// <summary>Represents a variable-length argument list; that is, the parameters of a function that takes a variable number of arguments.</summary>
	// Token: 0x020000A9 RID: 169
	public struct ArgIterator
	{
		// Token: 0x060009B0 RID: 2480
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern ArgIterator(IntPtr arglist);

		/// <summary>Initializes a new instance of the <see cref="T:System.ArgIterator" /> structure using the specified argument list.</summary>
		/// <param name="arglist">An argument list consisting of mandatory and optional arguments.</param>
		// Token: 0x060009B1 RID: 2481 RVA: 0x0001F5D2 File Offset: 0x0001D7D2
		[SecuritySafeCritical]
		public ArgIterator(RuntimeArgumentHandle arglist)
		{
			this = new ArgIterator(arglist.Value);
		}

		// Token: 0x060009B2 RID: 2482
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private unsafe extern ArgIterator(IntPtr arglist, void* ptr);

		/// <summary>Initializes a new instance of the <see cref="T:System.ArgIterator" /> structure using the specified argument list and a pointer to an item in the list.</summary>
		/// <param name="arglist">An argument list consisting of mandatory and optional arguments.</param>
		/// <param name="ptr">A pointer to the argument in <paramref name="arglist" /> to access first, or the first mandatory argument in <paramref name="arglist" /> if <paramref name="ptr" /> is <see langword="null" />.</param>
		// Token: 0x060009B3 RID: 2483 RVA: 0x0001F5E1 File Offset: 0x0001D7E1
		[SecurityCritical]
		[CLSCompliant(false)]
		public unsafe ArgIterator(RuntimeArgumentHandle arglist, void* ptr)
		{
			this = new ArgIterator(arglist.Value, ptr);
		}

		/// <summary>Returns the next argument in a variable-length argument list.</summary>
		/// <returns>The next argument as a <see cref="T:System.TypedReference" /> object.</returns>
		/// <exception cref="T:System.InvalidOperationException">An attempt was made to read beyond the end of the list.</exception>
		// Token: 0x060009B4 RID: 2484 RVA: 0x0001F5F4 File Offset: 0x0001D7F4
		[SecuritySafeCritical]
		[CLSCompliant(false)]
		public unsafe TypedReference GetNextArg()
		{
			TypedReference result = default(TypedReference);
			this.FCallGetNextArg((void*)(&result));
			return result;
		}

		// Token: 0x060009B5 RID: 2485
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private unsafe extern void FCallGetNextArg(void* result);

		/// <summary>Returns the next argument in a variable-length argument list that has a specified type.</summary>
		/// <param name="rth">A runtime type handle that identifies the type of the argument to retrieve.</param>
		/// <returns>The next argument as a <see cref="T:System.TypedReference" /> object.</returns>
		/// <exception cref="T:System.InvalidOperationException">An attempt was made to read beyond the end of the list.</exception>
		/// <exception cref="T:System.ArgumentNullException">The pointer to the remaining arguments is zero.</exception>
		// Token: 0x060009B6 RID: 2486 RVA: 0x0001F614 File Offset: 0x0001D814
		[SecuritySafeCritical]
		[CLSCompliant(false)]
		public unsafe TypedReference GetNextArg(RuntimeTypeHandle rth)
		{
			if (this.sigPtr != IntPtr.Zero)
			{
				return this.GetNextArg();
			}
			if (this.ArgPtr == IntPtr.Zero)
			{
				throw new ArgumentNullException();
			}
			TypedReference result = default(TypedReference);
			this.InternalGetNextArg((void*)(&result), rth.GetRuntimeType());
			return result;
		}

		// Token: 0x060009B7 RID: 2487
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private unsafe extern void InternalGetNextArg(void* result, RuntimeType rt);

		/// <summary>Concludes processing of the variable-length argument list represented by this instance.</summary>
		// Token: 0x060009B8 RID: 2488 RVA: 0x0001F66B File Offset: 0x0001D86B
		public void End()
		{
		}

		/// <summary>Returns the number of arguments remaining in the argument list.</summary>
		/// <returns>The number of remaining arguments.</returns>
		// Token: 0x060009B9 RID: 2489
		[SecuritySafeCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern int GetRemainingCount();

		// Token: 0x060009BA RID: 2490
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private unsafe extern void* _GetNextArgType();

		/// <summary>Returns the type of the next argument.</summary>
		/// <returns>The type of the next argument.</returns>
		// Token: 0x060009BB RID: 2491 RVA: 0x0001F66D File Offset: 0x0001D86D
		[SecuritySafeCritical]
		public RuntimeTypeHandle GetNextArgType()
		{
			return new RuntimeTypeHandle(Type.GetTypeFromHandleUnsafe((IntPtr)this._GetNextArgType()));
		}

		/// <summary>Returns the hash code of this object.</summary>
		/// <returns>A 32-bit signed integer hash code.</returns>
		// Token: 0x060009BC RID: 2492 RVA: 0x0001F684 File Offset: 0x0001D884
		public override int GetHashCode()
		{
			return ValueType.GetHashCodeOfPtr(this.ArgCookie);
		}

		/// <summary>This method is not supported, and always throws <see cref="T:System.NotSupportedException" />.</summary>
		/// <param name="o">An object to be compared to this instance.</param>
		/// <returns>This comparison is not supported. No value is returned.</returns>
		/// <exception cref="T:System.NotSupportedException">This method is not supported.</exception>
		// Token: 0x060009BD RID: 2493 RVA: 0x0001F691 File Offset: 0x0001D891
		public override bool Equals(object o)
		{
			throw new NotSupportedException(Environment.GetResourceString("NotSupported_NYI"));
		}

		// Token: 0x040003D0 RID: 976
		private IntPtr ArgCookie;

		// Token: 0x040003D1 RID: 977
		private IntPtr sigPtr;

		// Token: 0x040003D2 RID: 978
		private IntPtr sigPtrLen;

		// Token: 0x040003D3 RID: 979
		private IntPtr ArgPtr;

		// Token: 0x040003D4 RID: 980
		private int RemainingArgs;
	}
}
