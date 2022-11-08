using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenTK
{
	// Token: 0x02000053 RID: 83
	public abstract class BindingsBase
	{
		// Token: 0x06000611 RID: 1553 RVA: 0x0001653C File Offset: 0x0001473C
		public BindingsBase()
		{
		}

		// Token: 0x1700013A RID: 314
		// (get) Token: 0x06000612 RID: 1554 RVA: 0x0001654C File Offset: 0x0001474C
		// (set) Token: 0x06000613 RID: 1555 RVA: 0x00016554 File Offset: 0x00014754
		protected bool RebuildExtensionList
		{
			get
			{
				return this.rebuildExtensionList;
			}
			set
			{
				this.rebuildExtensionList = value;
			}
		}

		// Token: 0x06000614 RID: 1556
		protected abstract IntPtr GetAddress(string funcname);

		// Token: 0x1700013B RID: 315
		// (get) Token: 0x06000615 RID: 1557
		protected abstract object SyncRoot { get; }

		// Token: 0x06000616 RID: 1558 RVA: 0x00016560 File Offset: 0x00014760
		protected static void MarshalPtrToStringBuilder(IntPtr ptr, StringBuilder sb)
		{
			if (ptr == IntPtr.Zero)
			{
				throw new ArgumentException("ptr");
			}
			if (sb == null)
			{
				throw new ArgumentNullException("sb");
			}
			sb.Length = 0;
			int num = 0;
			for (;;)
			{
				byte b = Marshal.ReadByte(ptr, num);
				if (b == 0)
				{
					break;
				}
				sb.Append((char)b);
				num++;
			}
		}

		// Token: 0x06000617 RID: 1559 RVA: 0x000165B8 File Offset: 0x000147B8
		protected unsafe static IntPtr MarshalStringToPtr(string str)
		{
			if (string.IsNullOrEmpty(str))
			{
				return IntPtr.Zero;
			}
			int num = Encoding.ASCII.GetMaxByteCount(str.Length) + 1;
			IntPtr intPtr = Marshal.AllocHGlobal(num);
			if (intPtr == IntPtr.Zero)
			{
				throw new OutOfMemoryException();
			}
			IntPtr intPtr3;
			IntPtr intPtr2 = intPtr3 = str;
			if (intPtr2 != 0)
			{
				intPtr3 = (IntPtr)((int)intPtr2 + RuntimeHelpers.OffsetToStringData);
			}
			char* chars = intPtr3;
			int bytes = Encoding.ASCII.GetBytes(chars, str.Length, (byte*)((void*)intPtr), num);
			Marshal.WriteByte(intPtr, bytes, 0);
			return intPtr;
		}

		// Token: 0x06000618 RID: 1560 RVA: 0x00016638 File Offset: 0x00014838
		protected static void FreeStringPtr(IntPtr ptr)
		{
			Marshal.FreeHGlobal(ptr);
		}

		// Token: 0x06000619 RID: 1561 RVA: 0x00016640 File Offset: 0x00014840
		protected static IntPtr MarshalStringArrayToPtr(string[] str_array)
		{
			IntPtr intPtr = IntPtr.Zero;
			if (str_array != null && str_array.Length != 0)
			{
				intPtr = Marshal.AllocHGlobal(str_array.Length * IntPtr.Size);
				if (intPtr == IntPtr.Zero)
				{
					throw new OutOfMemoryException();
				}
				int i = 0;
				try
				{
					for (i = 0; i < str_array.Length; i++)
					{
						IntPtr val = BindingsBase.MarshalStringToPtr(str_array[i]);
						Marshal.WriteIntPtr(intPtr, i * IntPtr.Size, val);
					}
				}
				catch (OutOfMemoryException)
				{
					for (i--; i >= 0; i--)
					{
						Marshal.FreeHGlobal(Marshal.ReadIntPtr(intPtr, i * IntPtr.Size));
					}
					Marshal.FreeHGlobal(intPtr);
					throw;
				}
			}
			return intPtr;
		}

		// Token: 0x0600061A RID: 1562 RVA: 0x000166E0 File Offset: 0x000148E0
		protected static void FreeStringArrayPtr(IntPtr ptr, int length)
		{
			for (int i = 0; i < length; i++)
			{
				Marshal.FreeHGlobal(Marshal.ReadIntPtr(ptr, i * IntPtr.Size));
			}
			Marshal.FreeHGlobal(ptr);
		}

		// Token: 0x0600061B RID: 1563
		internal abstract void LoadEntryPoints();

		// Token: 0x0400018B RID: 395
		[Obsolete("Not used")]
		protected readonly Type DelegatesClass;

		// Token: 0x0400018C RID: 396
		[Obsolete("Not used")]
		protected readonly Type CoreClass;

		// Token: 0x0400018D RID: 397
		[Obsolete("Not used")]
		protected readonly SortedList<string, MethodInfo> CoreFunctionMap;

		// Token: 0x0400018E RID: 398
		private bool rebuildExtensionList = true;
	}
}
