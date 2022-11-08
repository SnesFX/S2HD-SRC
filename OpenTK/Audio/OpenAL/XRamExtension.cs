using System;
using System.Runtime.InteropServices;

namespace OpenTK.Audio.OpenAL
{
	// Token: 0x02000573 RID: 1395
	[CLSCompliant(true)]
	public sealed class XRamExtension
	{
		// Token: 0x17000426 RID: 1062
		// (get) Token: 0x06004507 RID: 17671 RVA: 0x000BE548 File Offset: 0x000BC748
		public bool IsInitialized
		{
			get
			{
				return this._valid;
			}
		}

		// Token: 0x06004508 RID: 17672 RVA: 0x000BE550 File Offset: 0x000BC750
		public XRamExtension()
		{
			this._valid = false;
			if (!AL.IsExtensionPresent("EAX-RAM"))
			{
				return;
			}
			this.AL_EAX_RAM_SIZE = AL.GetEnumValue("AL_EAX_RAM_SIZE");
			this.AL_EAX_RAM_FREE = AL.GetEnumValue("AL_EAX_RAM_FREE");
			this.AL_STORAGE_AUTOMATIC = AL.GetEnumValue("AL_STORAGE_AUTOMATIC");
			this.AL_STORAGE_HARDWARE = AL.GetEnumValue("AL_STORAGE_HARDWARE");
			this.AL_STORAGE_ACCESSIBLE = AL.GetEnumValue("AL_STORAGE_ACCESSIBLE");
			if (this.AL_EAX_RAM_SIZE == 0 || this.AL_EAX_RAM_FREE == 0 || this.AL_STORAGE_AUTOMATIC == 0 || this.AL_STORAGE_HARDWARE == 0 || this.AL_STORAGE_ACCESSIBLE == 0)
			{
				return;
			}
			try
			{
				this.Imported_GetBufferMode = (XRamExtension.Delegate_GetBufferMode)Marshal.GetDelegateForFunctionPointer(AL.GetProcAddress("EAXGetBufferMode"), typeof(XRamExtension.Delegate_GetBufferMode));
				this.Imported_SetBufferMode = (XRamExtension.Delegate_SetBufferMode)Marshal.GetDelegateForFunctionPointer(AL.GetProcAddress("EAXSetBufferMode"), typeof(XRamExtension.Delegate_SetBufferMode));
			}
			catch (Exception)
			{
				return;
			}
			this._valid = true;
		}

		// Token: 0x17000427 RID: 1063
		// (get) Token: 0x06004509 RID: 17673 RVA: 0x000BE654 File Offset: 0x000BC854
		public int GetRamSize
		{
			get
			{
				return AL.Get((ALGetInteger)this.AL_EAX_RAM_SIZE);
			}
		}

		// Token: 0x17000428 RID: 1064
		// (get) Token: 0x0600450A RID: 17674 RVA: 0x000BE664 File Offset: 0x000BC864
		public int GetRamFree
		{
			get
			{
				return AL.Get((ALGetInteger)this.AL_EAX_RAM_FREE);
			}
		}

		// Token: 0x0600450B RID: 17675 RVA: 0x000BE674 File Offset: 0x000BC874
		[CLSCompliant(false)]
		public bool SetBufferMode(int n, ref uint buffer, XRamExtension.XRamStorage mode)
		{
			switch (mode)
			{
			case XRamExtension.XRamStorage.Hardware:
				return this.Imported_SetBufferMode(n, ref buffer, this.AL_STORAGE_HARDWARE);
			case XRamExtension.XRamStorage.Accessible:
				return this.Imported_SetBufferMode(n, ref buffer, this.AL_STORAGE_ACCESSIBLE);
			default:
				return this.Imported_SetBufferMode(n, ref buffer, this.AL_STORAGE_AUTOMATIC);
			}
		}

		// Token: 0x0600450C RID: 17676 RVA: 0x000BE6D0 File Offset: 0x000BC8D0
		[CLSCompliant(true)]
		public bool SetBufferMode(int n, ref int buffer, XRamExtension.XRamStorage mode)
		{
			uint num = (uint)buffer;
			return this.SetBufferMode(n, ref num, mode);
		}

		// Token: 0x0600450D RID: 17677 RVA: 0x000BE6EC File Offset: 0x000BC8EC
		[CLSCompliant(false)]
		public XRamExtension.XRamStorage GetBufferMode(ref uint buffer)
		{
			int num = this.Imported_GetBufferMode(buffer, IntPtr.Zero);
			if (num == this.AL_STORAGE_ACCESSIBLE)
			{
				return XRamExtension.XRamStorage.Accessible;
			}
			if (num == this.AL_STORAGE_HARDWARE)
			{
				return XRamExtension.XRamStorage.Hardware;
			}
			return XRamExtension.XRamStorage.Automatic;
		}

		// Token: 0x0600450E RID: 17678 RVA: 0x000BE724 File Offset: 0x000BC924
		[CLSCompliant(true)]
		public XRamExtension.XRamStorage GetBufferMode(ref int buffer)
		{
			uint num = (uint)buffer;
			return this.GetBufferMode(ref num);
		}

		// Token: 0x04005005 RID: 20485
		private bool _valid;

		// Token: 0x04005006 RID: 20486
		private XRamExtension.Delegate_SetBufferMode Imported_SetBufferMode;

		// Token: 0x04005007 RID: 20487
		private XRamExtension.Delegate_GetBufferMode Imported_GetBufferMode;

		// Token: 0x04005008 RID: 20488
		private int AL_EAX_RAM_SIZE;

		// Token: 0x04005009 RID: 20489
		private int AL_EAX_RAM_FREE;

		// Token: 0x0400500A RID: 20490
		private int AL_STORAGE_AUTOMATIC;

		// Token: 0x0400500B RID: 20491
		private int AL_STORAGE_HARDWARE;

		// Token: 0x0400500C RID: 20492
		private int AL_STORAGE_ACCESSIBLE;

		// Token: 0x02000574 RID: 1396
		// (Invoke) Token: 0x06004510 RID: 17680
		private delegate bool Delegate_SetBufferMode(int n, ref uint buffers, int value);

		// Token: 0x02000575 RID: 1397
		// (Invoke) Token: 0x06004514 RID: 17684
		private delegate int Delegate_GetBufferMode(uint buffer, IntPtr value);

		// Token: 0x02000576 RID: 1398
		public enum XRamStorage : byte
		{
			// Token: 0x0400500E RID: 20494
			Automatic,
			// Token: 0x0400500F RID: 20495
			Hardware,
			// Token: 0x04005010 RID: 20496
			Accessible
		}
	}
}
