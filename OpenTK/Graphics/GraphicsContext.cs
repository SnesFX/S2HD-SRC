using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using OpenTK.Platform;
using OpenTK.Platform.Dummy;

namespace OpenTK.Graphics
{
	// Token: 0x020001BE RID: 446
	public sealed class GraphicsContext : IGraphicsContext, IDisposable, IGraphicsContextInternal
	{
		// Token: 0x06000C06 RID: 3078 RVA: 0x0002797C File Offset: 0x00025B7C
		public GraphicsContext(GraphicsMode mode, IWindowInfo window) : this(mode, window, 1, 0, GraphicsContextFlags.Default)
		{
		}

		// Token: 0x06000C07 RID: 3079 RVA: 0x0002798C File Offset: 0x00025B8C
		public GraphicsContext(GraphicsMode mode, IWindowInfo window, int major, int minor, GraphicsContextFlags flags)
		{
			this.check_errors = true;
			base..ctor();
			lock (GraphicsContext.SyncRoot)
			{
				bool flag = false;
				if (mode == null && window == null)
				{
					flag = true;
				}
				else
				{
					if (mode == null)
					{
						throw new ArgumentNullException("mode", "Must be a valid GraphicsMode.");
					}
					if (window == null)
					{
						throw new ArgumentNullException("window", "Must point to a valid window.");
					}
				}
				if (major <= 0)
				{
					major = 1;
				}
				if (minor < 0)
				{
					minor = 0;
				}
				IGraphicsContext shareContext = GraphicsContext.FindSharedContext();
				if (flag)
				{
					this.implementation = new DummyGLContext();
				}
				else
				{
					IPlatformFactory platformFactory = null;
					switch ((flags & GraphicsContextFlags.Embedded) == GraphicsContextFlags.Embedded)
					{
					case false:
						platformFactory = Factory.Default;
						break;
					case true:
						platformFactory = Factory.Embedded;
						break;
					}
					if (GraphicsContext.GetCurrentContext == null)
					{
						GraphicsContext.GetCurrentContext = platformFactory.CreateGetCurrentGraphicsContext();
					}
					this.implementation = platformFactory.CreateGLContext(mode, window, shareContext, GraphicsContext.direct_rendering, major, minor, flags);
					this.handle_cached = ((IGraphicsContextInternal)this.implementation).Context;
				}
				GraphicsContext.AddContext(this);
			}
		}

		// Token: 0x06000C08 RID: 3080 RVA: 0x00027A98 File Offset: 0x00025C98
		public GraphicsContext(ContextHandle handle, GraphicsContext.GetAddressDelegate getAddress, GraphicsContext.GetCurrentContextDelegate getCurrent)
		{
			this.check_errors = true;
			base..ctor();
			if (getAddress == null || getCurrent == null)
			{
				throw new ArgumentNullException();
			}
			Toolkit.Init();
			lock (GraphicsContext.SyncRoot)
			{
				if (handle == ContextHandle.Zero)
				{
					handle = getCurrent();
				}
				if (handle == ContextHandle.Zero)
				{
					throw new GraphicsContextMissingException();
				}
				if (GraphicsContext.available_contexts.ContainsKey(handle))
				{
					throw new InvalidOperationException("Context handle has already been added");
				}
				this.implementation = new DummyGLContext(handle, getAddress);
				GraphicsContext.GetCurrentContext = (getCurrent ?? GraphicsContext.GetCurrentContext);
				GraphicsContext.AddContext(this);
			}
			this.implementation.LoadAll();
		}

		// Token: 0x06000C09 RID: 3081 RVA: 0x00027B58 File Offset: 0x00025D58
		public GraphicsContext(ContextHandle handle, IWindowInfo window) : this(handle, window, null, 1, 0, GraphicsContextFlags.Default)
		{
		}

		// Token: 0x06000C0A RID: 3082 RVA: 0x00027B68 File Offset: 0x00025D68
		public GraphicsContext(ContextHandle handle, IWindowInfo window, IGraphicsContext shareContext, int major, int minor, GraphicsContextFlags flags) : this(handle, Utilities.CreateGetAddress(), Factory.Default.CreateGetCurrentGraphicsContext())
		{
		}

		// Token: 0x06000C0B RID: 3083 RVA: 0x00027B80 File Offset: 0x00025D80
		public override string ToString()
		{
			return ((IGraphicsContextInternal)this).Context.ToString();
		}

		// Token: 0x06000C0C RID: 3084 RVA: 0x00027BA4 File Offset: 0x00025DA4
		public override int GetHashCode()
		{
			return ((IGraphicsContextInternal)this).Context.GetHashCode();
		}

		// Token: 0x06000C0D RID: 3085 RVA: 0x00027BC8 File Offset: 0x00025DC8
		public override bool Equals(object obj)
		{
			return obj is GraphicsContext && ((IGraphicsContextInternal)this).Context == (obj as IGraphicsContextInternal).Context;
		}

		// Token: 0x06000C0E RID: 3086 RVA: 0x00027BEC File Offset: 0x00025DEC
		private static void AddContext(IGraphicsContextInternal context)
		{
			ContextHandle context2 = context.Context;
			if (!GraphicsContext.available_contexts.ContainsKey(context2))
			{
				GraphicsContext.available_contexts.Add(context2, (IGraphicsContext)context);
				return;
			}
			GraphicsContext.available_contexts[context2] = (IGraphicsContext)context;
		}

		// Token: 0x06000C0F RID: 3087 RVA: 0x00027C30 File Offset: 0x00025E30
		private static void RemoveContext(IGraphicsContextInternal context)
		{
			ContextHandle context2 = context.Context;
			if (GraphicsContext.available_contexts.ContainsKey(context2))
			{
				GraphicsContext.available_contexts.Remove(context2);
			}
		}

		// Token: 0x06000C10 RID: 3088 RVA: 0x00027C60 File Offset: 0x00025E60
		private static IGraphicsContext FindSharedContext()
		{
			if (GraphicsContext.ShareContexts)
			{
				foreach (IGraphicsContext graphicsContext in GraphicsContext.available_contexts.Values)
				{
					if (graphicsContext != null)
					{
						return graphicsContext;
					}
				}
			}
			return null;
		}

		// Token: 0x06000C11 RID: 3089 RVA: 0x00027CC4 File Offset: 0x00025EC4
		[Obsolete("Use GraphicsContext(ContextHandle, IWindowInfo) constructor instead")]
		public static GraphicsContext CreateDummyContext()
		{
			ContextHandle contextHandle = GraphicsContext.GetCurrentContext();
			if (contextHandle == ContextHandle.Zero)
			{
				throw new InvalidOperationException("No GraphicsContext is current on the calling thread.");
			}
			return GraphicsContext.CreateDummyContext(contextHandle);
		}

		// Token: 0x06000C12 RID: 3090 RVA: 0x00027CFC File Offset: 0x00025EFC
		[Obsolete("Use GraphicsContext(ContextHandle, IWindowInfo) constructor instead")]
		public static GraphicsContext CreateDummyContext(ContextHandle handle)
		{
			if (handle == ContextHandle.Zero)
			{
				throw new ArgumentOutOfRangeException("handle");
			}
			return new GraphicsContext(handle, null);
		}

		// Token: 0x06000C13 RID: 3091 RVA: 0x00027D20 File Offset: 0x00025F20
		public static void Assert()
		{
			if (GraphicsContext.CurrentContext == null)
			{
				throw new GraphicsContextMissingException();
			}
		}

		// Token: 0x1700025E RID: 606
		// (get) Token: 0x06000C14 RID: 3092 RVA: 0x00027D30 File Offset: 0x00025F30
		public static IGraphicsContext CurrentContext
		{
			get
			{
				IGraphicsContext result;
				lock (GraphicsContext.SyncRoot)
				{
					if (GraphicsContext.available_contexts.Count > 0)
					{
						ContextHandle key = GraphicsContext.GetCurrentContext();
						if (key.Handle != IntPtr.Zero)
						{
							return GraphicsContext.available_contexts[key];
						}
					}
					result = null;
				}
				return result;
			}
		}

		// Token: 0x1700025F RID: 607
		// (get) Token: 0x06000C15 RID: 3093 RVA: 0x00027DA0 File Offset: 0x00025FA0
		// (set) Token: 0x06000C16 RID: 3094 RVA: 0x00027DA8 File Offset: 0x00025FA8
		public static bool ShareContexts
		{
			get
			{
				return GraphicsContext.share_contexts;
			}
			set
			{
				GraphicsContext.share_contexts = value;
			}
		}

		// Token: 0x17000260 RID: 608
		// (get) Token: 0x06000C17 RID: 3095 RVA: 0x00027DB0 File Offset: 0x00025FB0
		// (set) Token: 0x06000C18 RID: 3096 RVA: 0x00027DB8 File Offset: 0x00025FB8
		public static bool DirectRendering
		{
			get
			{
				return GraphicsContext.direct_rendering;
			}
			set
			{
				GraphicsContext.direct_rendering = value;
			}
		}

		// Token: 0x17000261 RID: 609
		// (get) Token: 0x06000C19 RID: 3097 RVA: 0x00027DC0 File Offset: 0x00025FC0
		// (set) Token: 0x06000C1A RID: 3098 RVA: 0x00027DC8 File Offset: 0x00025FC8
		public bool ErrorChecking
		{
			get
			{
				return this.check_errors;
			}
			set
			{
				this.check_errors = value;
			}
		}

		// Token: 0x06000C1B RID: 3099 RVA: 0x00027DD4 File Offset: 0x00025FD4
		public void SwapBuffers()
		{
			this.implementation.SwapBuffers();
		}

		// Token: 0x06000C1C RID: 3100 RVA: 0x00027DE4 File Offset: 0x00025FE4
		public void MakeCurrent(IWindowInfo window)
		{
			this.implementation.MakeCurrent(window);
		}

		// Token: 0x17000262 RID: 610
		// (get) Token: 0x06000C1D RID: 3101 RVA: 0x00027DF4 File Offset: 0x00025FF4
		public bool IsCurrent
		{
			get
			{
				return this.implementation.IsCurrent;
			}
		}

		// Token: 0x17000263 RID: 611
		// (get) Token: 0x06000C1E RID: 3102 RVA: 0x00027E04 File Offset: 0x00026004
		// (set) Token: 0x06000C1F RID: 3103 RVA: 0x00027E1C File Offset: 0x0002601C
		public bool IsDisposed
		{
			get
			{
				return this.disposed && this.implementation.IsDisposed;
			}
			private set
			{
				this.disposed = value;
			}
		}

		// Token: 0x17000264 RID: 612
		// (get) Token: 0x06000C20 RID: 3104 RVA: 0x00027E28 File Offset: 0x00026028
		// (set) Token: 0x06000C21 RID: 3105 RVA: 0x00027E38 File Offset: 0x00026038
		[Obsolete("Use SwapInterval property instead.")]
		public bool VSync
		{
			get
			{
				return this.implementation.VSync;
			}
			set
			{
				this.implementation.VSync = value;
			}
		}

		// Token: 0x17000265 RID: 613
		// (get) Token: 0x06000C22 RID: 3106 RVA: 0x00027E48 File Offset: 0x00026048
		// (set) Token: 0x06000C23 RID: 3107 RVA: 0x00027E58 File Offset: 0x00026058
		public int SwapInterval
		{
			get
			{
				return this.implementation.SwapInterval;
			}
			set
			{
				this.implementation.SwapInterval = value;
			}
		}

		// Token: 0x06000C24 RID: 3108 RVA: 0x00027E68 File Offset: 0x00026068
		public void Update(IWindowInfo window)
		{
			this.implementation.Update(window);
		}

		// Token: 0x06000C25 RID: 3109 RVA: 0x00027E78 File Offset: 0x00026078
		public void LoadAll()
		{
			if (GraphicsContext.CurrentContext != this)
			{
				throw new GraphicsContextException();
			}
			this.implementation.LoadAll();
		}

		// Token: 0x17000266 RID: 614
		// (get) Token: 0x06000C26 RID: 3110 RVA: 0x00027E94 File Offset: 0x00026094
		IGraphicsContext IGraphicsContextInternal.Implementation
		{
			get
			{
				return this.implementation;
			}
		}

		// Token: 0x17000267 RID: 615
		// (get) Token: 0x06000C27 RID: 3111 RVA: 0x00027E9C File Offset: 0x0002609C
		ContextHandle IGraphicsContextInternal.Context
		{
			get
			{
				if (this.implementation != null)
				{
					this.handle_cached = ((IGraphicsContextInternal)this.implementation).Context;
				}
				return this.handle_cached;
			}
		}

		// Token: 0x17000268 RID: 616
		// (get) Token: 0x06000C28 RID: 3112 RVA: 0x00027EC4 File Offset: 0x000260C4
		public GraphicsMode GraphicsMode
		{
			get
			{
				return this.implementation.GraphicsMode;
			}
		}

		// Token: 0x06000C29 RID: 3113 RVA: 0x00027ED4 File Offset: 0x000260D4
		IntPtr IGraphicsContextInternal.GetAddress(string function)
		{
			IntPtr intPtr = Marshal.StringToHGlobalAnsi(function);
			IntPtr address = (this.implementation as IGraphicsContextInternal).GetAddress(intPtr);
			Marshal.FreeHGlobal(intPtr);
			return address;
		}

		// Token: 0x06000C2A RID: 3114 RVA: 0x00027F04 File Offset: 0x00026104
		IntPtr IGraphicsContextInternal.GetAddress(IntPtr function)
		{
			return (this.implementation as IGraphicsContextInternal).GetAddress(function);
		}

		// Token: 0x06000C2B RID: 3115 RVA: 0x00027F18 File Offset: 0x00026118
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x06000C2C RID: 3116 RVA: 0x00027F28 File Offset: 0x00026128
		private void Dispose(bool manual)
		{
			if (!this.IsDisposed)
			{
				lock (GraphicsContext.SyncRoot)
				{
					GraphicsContext.RemoveContext(this);
				}
				if (manual && this.implementation != null)
				{
					this.implementation.Dispose();
				}
				this.IsDisposed = true;
			}
		}

		// Token: 0x06000C2D RID: 3117 RVA: 0x00027F88 File Offset: 0x00026188
		~GraphicsContext()
		{
			this.Dispose(false);
		}

		// Token: 0x0400121E RID: 4638
		private IGraphicsContext implementation;

		// Token: 0x0400121F RID: 4639
		private bool disposed;

		// Token: 0x04001220 RID: 4640
		private bool check_errors;

		// Token: 0x04001221 RID: 4641
		private ContextHandle handle_cached;

		// Token: 0x04001222 RID: 4642
		private static bool share_contexts = true;

		// Token: 0x04001223 RID: 4643
		private static bool direct_rendering = true;

		// Token: 0x04001224 RID: 4644
		private static readonly object SyncRoot = new object();

		// Token: 0x04001225 RID: 4645
		private static readonly Dictionary<ContextHandle, IGraphicsContext> available_contexts = new Dictionary<ContextHandle, IGraphicsContext>();

		// Token: 0x04001226 RID: 4646
		internal static GraphicsContext.GetCurrentContextDelegate GetCurrentContext;

		// Token: 0x020001BF RID: 447
		// (Invoke) Token: 0x06000C30 RID: 3120
		public delegate IntPtr GetAddressDelegate(string function);

		// Token: 0x020001C0 RID: 448
		// (Invoke) Token: 0x06000C34 RID: 3124
		public delegate ContextHandle GetCurrentContextDelegate();
	}
}
