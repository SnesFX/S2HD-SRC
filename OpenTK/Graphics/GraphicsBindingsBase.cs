using System;

namespace OpenTK.Graphics
{
	// Token: 0x020001AF RID: 431
	public abstract class GraphicsBindingsBase : BindingsBase
	{
		// Token: 0x06000B11 RID: 2833 RVA: 0x00026108 File Offset: 0x00024308
		protected override IntPtr GetAddress(string funcname)
		{
			IGraphicsContextInternal graphicsContextInternal = GraphicsContext.CurrentContext as IGraphicsContextInternal;
			if (graphicsContextInternal == null)
			{
				throw new GraphicsContextMissingException();
			}
			if (graphicsContextInternal == null)
			{
				return IntPtr.Zero;
			}
			return graphicsContextInternal.GetAddress(funcname);
		}

		// Token: 0x06000B12 RID: 2834 RVA: 0x0002613C File Offset: 0x0002433C
		internal unsafe override void LoadEntryPoints()
		{
			IGraphicsContext currentContext = GraphicsContext.CurrentContext;
			if (currentContext == null)
			{
				throw new GraphicsContextMissingException();
			}
			IGraphicsContextInternal graphicsContextInternal = currentContext as IGraphicsContextInternal;
			fixed (byte* entryPointNamesInstance = this._EntryPointNamesInstance)
			{
				for (int i = 0; i < this._EntryPointsInstance.Length; i++)
				{
					this._EntryPointsInstance[i] = graphicsContextInternal.GetAddress(new IntPtr((void*)((byte*)entryPointNamesInstance + this._EntryPointNameOffsetsInstance[i])));
				}
			}
		}

		// Token: 0x040011FD RID: 4605
		[Obsolete("Not used - this field remains for 1.1 API compatibility")]
		protected IntPtr[] EntryPointsInstance;

		// Token: 0x040011FE RID: 4606
		[Obsolete("Not used - this field remains for 1.1 API compatibility")]
		protected string[] EntryPointNamesInstance;

		// Token: 0x040011FF RID: 4607
		internal IntPtr[] _EntryPointsInstance;

		// Token: 0x04001200 RID: 4608
		internal byte[] _EntryPointNamesInstance;

		// Token: 0x04001201 RID: 4609
		internal int[] _EntryPointNameOffsetsInstance;
	}
}
