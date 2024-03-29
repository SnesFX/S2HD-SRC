﻿using System;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;

namespace System.Threading
{
	/// <summary>Defines a lock that supports single writers and multiple readers.</summary>
	// Token: 0x020004E3 RID: 1251
	[ComVisible(true)]
	[HostProtection(SecurityAction.LinkDemand, Synchronization = true, ExternalThreading = true)]
	public sealed class ReaderWriterLock : CriticalFinalizerObject
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Threading.ReaderWriterLock" /> class.</summary>
		// Token: 0x06003BD2 RID: 15314 RVA: 0x000E152A File Offset: 0x000DF72A
		[SecuritySafeCritical]
		public ReaderWriterLock()
		{
			this.PrivateInitialize();
		}

		/// <summary>Ensures that resources are freed and other cleanup operations are performed when the garbage collector reclaims the <see cref="T:System.Threading.ReaderWriterLock" /> object.</summary>
		// Token: 0x06003BD3 RID: 15315 RVA: 0x000E1538 File Offset: 0x000DF738
		[SecuritySafeCritical]
		~ReaderWriterLock()
		{
			this.PrivateDestruct();
		}

		/// <summary>Gets a value indicating whether the current thread holds a reader lock.</summary>
		/// <returns>
		///   <see langword="true" /> if the current thread holds a reader lock; otherwise, <see langword="false" />.</returns>
		// Token: 0x1700090C RID: 2316
		// (get) Token: 0x06003BD4 RID: 15316 RVA: 0x000E1564 File Offset: 0x000DF764
		public bool IsReaderLockHeld
		{
			[SecuritySafeCritical]
			[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
			get
			{
				return this.PrivateGetIsReaderLockHeld();
			}
		}

		/// <summary>Gets a value indicating whether the current thread holds the writer lock.</summary>
		/// <returns>
		///   <see langword="true" /> if the current thread holds the writer lock; otherwise, <see langword="false" />.</returns>
		// Token: 0x1700090D RID: 2317
		// (get) Token: 0x06003BD5 RID: 15317 RVA: 0x000E156C File Offset: 0x000DF76C
		public bool IsWriterLockHeld
		{
			[SecuritySafeCritical]
			[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
			get
			{
				return this.PrivateGetIsWriterLockHeld();
			}
		}

		/// <summary>Gets the current sequence number.</summary>
		/// <returns>The current sequence number.</returns>
		// Token: 0x1700090E RID: 2318
		// (get) Token: 0x06003BD6 RID: 15318 RVA: 0x000E1574 File Offset: 0x000DF774
		public int WriterSeqNum
		{
			[SecuritySafeCritical]
			get
			{
				return this.PrivateGetWriterSeqNum();
			}
		}

		// Token: 0x06003BD7 RID: 15319
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void AcquireReaderLockInternal(int millisecondsTimeout);

		/// <summary>Acquires a reader lock, using an <see cref="T:System.Int32" /> value for the time-out.</summary>
		/// <param name="millisecondsTimeout">The time-out in milliseconds.</param>
		/// <exception cref="T:System.ApplicationException">
		///   <paramref name="millisecondsTimeout" /> expires before the lock request is granted.</exception>
		// Token: 0x06003BD8 RID: 15320 RVA: 0x000E157C File Offset: 0x000DF77C
		[SecuritySafeCritical]
		public void AcquireReaderLock(int millisecondsTimeout)
		{
			this.AcquireReaderLockInternal(millisecondsTimeout);
		}

		/// <summary>Acquires a reader lock, using a <see cref="T:System.TimeSpan" /> value for the time-out.</summary>
		/// <param name="timeout">A <see langword="TimeSpan" /> specifying the time-out period.</param>
		/// <exception cref="T:System.ApplicationException">
		///   <paramref name="timeout" /> expires before the lock request is granted.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="timeout" /> specifies a negative value other than -1 milliseconds.</exception>
		// Token: 0x06003BD9 RID: 15321 RVA: 0x000E1588 File Offset: 0x000DF788
		[SecuritySafeCritical]
		public void AcquireReaderLock(TimeSpan timeout)
		{
			long num = (long)timeout.TotalMilliseconds;
			if (num < -1L || num > 2147483647L)
			{
				throw new ArgumentOutOfRangeException("timeout", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegOrNegative1"));
			}
			this.AcquireReaderLockInternal((int)num);
		}

		// Token: 0x06003BDA RID: 15322
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void AcquireWriterLockInternal(int millisecondsTimeout);

		/// <summary>Acquires the writer lock, using an <see cref="T:System.Int32" /> value for the time-out.</summary>
		/// <param name="millisecondsTimeout">The time-out in milliseconds.</param>
		/// <exception cref="T:System.ApplicationException">
		///   <paramref name="timeout" /> expires before the lock request is granted.</exception>
		// Token: 0x06003BDB RID: 15323 RVA: 0x000E15C9 File Offset: 0x000DF7C9
		[SecuritySafeCritical]
		public void AcquireWriterLock(int millisecondsTimeout)
		{
			this.AcquireWriterLockInternal(millisecondsTimeout);
		}

		/// <summary>Acquires the writer lock, using a <see cref="T:System.TimeSpan" /> value for the time-out.</summary>
		/// <param name="timeout">The <see langword="TimeSpan" /> specifying the time-out period.</param>
		/// <exception cref="T:System.ApplicationException">
		///   <paramref name="timeout" /> expires before the lock request is granted.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="timeout" /> specifies a negative value other than -1 milliseconds.</exception>
		// Token: 0x06003BDC RID: 15324 RVA: 0x000E15D4 File Offset: 0x000DF7D4
		[SecuritySafeCritical]
		public void AcquireWriterLock(TimeSpan timeout)
		{
			long num = (long)timeout.TotalMilliseconds;
			if (num < -1L || num > 2147483647L)
			{
				throw new ArgumentOutOfRangeException("timeout", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegOrNegative1"));
			}
			this.AcquireWriterLockInternal((int)num);
		}

		// Token: 0x06003BDD RID: 15325
		[SecurityCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void ReleaseReaderLockInternal();

		/// <summary>Decrements the lock count.</summary>
		/// <exception cref="T:System.ApplicationException">The thread does not have any reader or writer locks.</exception>
		// Token: 0x06003BDE RID: 15326 RVA: 0x000E1615 File Offset: 0x000DF815
		[SecuritySafeCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		public void ReleaseReaderLock()
		{
			this.ReleaseReaderLockInternal();
		}

		// Token: 0x06003BDF RID: 15327
		[SecurityCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void ReleaseWriterLockInternal();

		/// <summary>Decrements the lock count on the writer lock.</summary>
		/// <exception cref="T:System.ApplicationException">The thread does not have the writer lock.</exception>
		// Token: 0x06003BE0 RID: 15328 RVA: 0x000E161D File Offset: 0x000DF81D
		[SecuritySafeCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		public void ReleaseWriterLock()
		{
			this.ReleaseWriterLockInternal();
		}

		/// <summary>Upgrades a reader lock to the writer lock, using an <see langword="Int32" /> value for the time-out.</summary>
		/// <param name="millisecondsTimeout">The time-out in milliseconds.</param>
		/// <returns>A <see cref="T:System.Threading.LockCookie" /> value.</returns>
		/// <exception cref="T:System.ApplicationException">
		///   <paramref name="millisecondsTimeout" /> expires before the lock request is granted.</exception>
		// Token: 0x06003BE1 RID: 15329 RVA: 0x000E1628 File Offset: 0x000DF828
		[SecuritySafeCritical]
		public LockCookie UpgradeToWriterLock(int millisecondsTimeout)
		{
			LockCookie result = default(LockCookie);
			this.FCallUpgradeToWriterLock(ref result, millisecondsTimeout);
			return result;
		}

		// Token: 0x06003BE2 RID: 15330
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void FCallUpgradeToWriterLock(ref LockCookie result, int millisecondsTimeout);

		/// <summary>Upgrades a reader lock to the writer lock, using a <see langword="TimeSpan" /> value for the time-out.</summary>
		/// <param name="timeout">The <see langword="TimeSpan" /> specifying the time-out period.</param>
		/// <returns>A <see cref="T:System.Threading.LockCookie" /> value.</returns>
		/// <exception cref="T:System.ApplicationException">
		///   <paramref name="timeout" /> expires before the lock request is granted.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="timeout" /> specifies a negative value other than -1 milliseconds.</exception>
		// Token: 0x06003BE3 RID: 15331 RVA: 0x000E1648 File Offset: 0x000DF848
		public LockCookie UpgradeToWriterLock(TimeSpan timeout)
		{
			long num = (long)timeout.TotalMilliseconds;
			if (num < -1L || num > 2147483647L)
			{
				throw new ArgumentOutOfRangeException("timeout", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegOrNegative1"));
			}
			return this.UpgradeToWriterLock((int)num);
		}

		// Token: 0x06003BE4 RID: 15332
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void DowngradeFromWriterLockInternal(ref LockCookie lockCookie);

		/// <summary>Restores the lock status of the thread to what it was before <see cref="M:System.Threading.ReaderWriterLock.UpgradeToWriterLock(System.Int32)" /> was called.</summary>
		/// <param name="lockCookie">A <see cref="T:System.Threading.LockCookie" /> returned by <see cref="M:System.Threading.ReaderWriterLock.UpgradeToWriterLock(System.Int32)" />.</param>
		/// <exception cref="T:System.ApplicationException">The thread does not have the writer lock.</exception>
		/// <exception cref="T:System.NullReferenceException">The address of <paramref name="lockCookie" /> is a null pointer.</exception>
		// Token: 0x06003BE5 RID: 15333 RVA: 0x000E1689 File Offset: 0x000DF889
		[SecuritySafeCritical]
		public void DowngradeFromWriterLock(ref LockCookie lockCookie)
		{
			this.DowngradeFromWriterLockInternal(ref lockCookie);
		}

		/// <summary>Releases the lock, regardless of the number of times the thread acquired the lock.</summary>
		/// <returns>A <see cref="T:System.Threading.LockCookie" /> value representing the released lock.</returns>
		// Token: 0x06003BE6 RID: 15334 RVA: 0x000E1694 File Offset: 0x000DF894
		[SecuritySafeCritical]
		public LockCookie ReleaseLock()
		{
			LockCookie result = default(LockCookie);
			this.FCallReleaseLock(ref result);
			return result;
		}

		// Token: 0x06003BE7 RID: 15335
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void FCallReleaseLock(ref LockCookie result);

		// Token: 0x06003BE8 RID: 15336
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void RestoreLockInternal(ref LockCookie lockCookie);

		/// <summary>Restores the lock status of the thread to what it was before calling <see cref="M:System.Threading.ReaderWriterLock.ReleaseLock" />.</summary>
		/// <param name="lockCookie">A <see cref="T:System.Threading.LockCookie" /> returned by <see cref="M:System.Threading.ReaderWriterLock.ReleaseLock" />.</param>
		/// <exception cref="T:System.NullReferenceException">The address of <paramref name="lockCookie" /> is a null pointer.</exception>
		// Token: 0x06003BE9 RID: 15337 RVA: 0x000E16B2 File Offset: 0x000DF8B2
		[SecuritySafeCritical]
		public void RestoreLock(ref LockCookie lockCookie)
		{
			this.RestoreLockInternal(ref lockCookie);
		}

		// Token: 0x06003BEA RID: 15338
		[SecurityCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern bool PrivateGetIsReaderLockHeld();

		// Token: 0x06003BEB RID: 15339
		[SecurityCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern bool PrivateGetIsWriterLockHeld();

		// Token: 0x06003BEC RID: 15340
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern int PrivateGetWriterSeqNum();

		/// <summary>Indicates whether the writer lock has been granted to any thread since the sequence number was obtained.</summary>
		/// <param name="seqNum">The sequence number.</param>
		/// <returns>
		///   <see langword="true" /> if the writer lock has been granted to any thread since the sequence number was obtained; otherwise, <see langword="false" />.</returns>
		// Token: 0x06003BED RID: 15341
		[SecuritySafeCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern bool AnyWritersSince(int seqNum);

		// Token: 0x06003BEE RID: 15342
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void PrivateInitialize();

		// Token: 0x06003BEF RID: 15343
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void PrivateDestruct();

		// Token: 0x0400191F RID: 6431
		private IntPtr _hWriterEvent;

		// Token: 0x04001920 RID: 6432
		private IntPtr _hReaderEvent;

		// Token: 0x04001921 RID: 6433
		private IntPtr _hObjectHandle;

		// Token: 0x04001922 RID: 6434
		private int _dwState;

		// Token: 0x04001923 RID: 6435
		private int _dwULockID;

		// Token: 0x04001924 RID: 6436
		private int _dwLLockID;

		// Token: 0x04001925 RID: 6437
		private int _dwWriterID;

		// Token: 0x04001926 RID: 6438
		private int _dwWriterSeqNum;

		// Token: 0x04001927 RID: 6439
		private short _wWriterLevel;
	}
}
