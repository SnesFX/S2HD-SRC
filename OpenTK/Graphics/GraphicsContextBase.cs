using System;
using OpenTK.Platform;

namespace OpenTK.Graphics
{
	// Token: 0x02000028 RID: 40
	internal abstract class GraphicsContextBase : IGraphicsContext, IDisposable, IGraphicsContextInternal
	{
		// Token: 0x06000488 RID: 1160
		public abstract void SwapBuffers();

		// Token: 0x06000489 RID: 1161
		public abstract void MakeCurrent(IWindowInfo window);

		// Token: 0x170000F5 RID: 245
		// (get) Token: 0x0600048A RID: 1162
		public abstract bool IsCurrent { get; }

		// Token: 0x170000F6 RID: 246
		// (get) Token: 0x0600048B RID: 1163 RVA: 0x000136A4 File Offset: 0x000118A4
		// (set) Token: 0x0600048C RID: 1164 RVA: 0x000136AC File Offset: 0x000118AC
		public bool IsDisposed
		{
			get
			{
				return this.disposed;
			}
			protected set
			{
				this.disposed = value;
			}
		}

		// Token: 0x170000F7 RID: 247
		// (get) Token: 0x0600048D RID: 1165 RVA: 0x000136B8 File Offset: 0x000118B8
		// (set) Token: 0x0600048E RID: 1166 RVA: 0x000136C4 File Offset: 0x000118C4
		public bool VSync
		{
			get
			{
				return this.SwapInterval > 0;
			}
			set
			{
				if (value && this.SwapInterval <= 0)
				{
					this.SwapInterval = 1;
					return;
				}
				if (!value && this.SwapInterval > 0)
				{
					this.SwapInterval = 0;
				}
			}
		}

		// Token: 0x170000F8 RID: 248
		// (get) Token: 0x0600048F RID: 1167
		// (set) Token: 0x06000490 RID: 1168
		public abstract int SwapInterval { get; set; }

		// Token: 0x06000491 RID: 1169 RVA: 0x000136F0 File Offset: 0x000118F0
		public virtual void Update(IWindowInfo window)
		{
		}

		// Token: 0x170000F9 RID: 249
		// (get) Token: 0x06000492 RID: 1170 RVA: 0x000136F4 File Offset: 0x000118F4
		public GraphicsMode GraphicsMode
		{
			get
			{
				return this.Mode;
			}
		}

		// Token: 0x170000FA RID: 250
		// (get) Token: 0x06000493 RID: 1171 RVA: 0x000136FC File Offset: 0x000118FC
		// (set) Token: 0x06000494 RID: 1172 RVA: 0x00013704 File Offset: 0x00011904
		public bool ErrorChecking
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x170000FB RID: 251
		// (get) Token: 0x06000495 RID: 1173 RVA: 0x0001370C File Offset: 0x0001190C
		public IGraphicsContext Implementation
		{
			get
			{
				return this;
			}
		}

		// Token: 0x06000496 RID: 1174
		public abstract void LoadAll();

		// Token: 0x170000FC RID: 252
		// (get) Token: 0x06000497 RID: 1175 RVA: 0x00013710 File Offset: 0x00011910
		public ContextHandle Context
		{
			get
			{
				return this.Handle;
			}
		}

		// Token: 0x06000498 RID: 1176 RVA: 0x00013718 File Offset: 0x00011918
		public IntPtr GetAddress(string function)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000499 RID: 1177
		public abstract IntPtr GetAddress(IntPtr function);

		// Token: 0x0600049A RID: 1178
		public abstract void Dispose();

		// Token: 0x040000AD RID: 173
		private bool disposed;

		// Token: 0x040000AE RID: 174
		protected ContextHandle Handle;

		// Token: 0x040000AF RID: 175
		protected GraphicsMode Mode;
	}
}
