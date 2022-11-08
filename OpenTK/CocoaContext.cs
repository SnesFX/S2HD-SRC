using System;
using System.Collections.Generic;
using OpenTK.Graphics;
using OpenTK.Platform;
using OpenTK.Platform.MacOS;

namespace OpenTK
{
	// Token: 0x02000B0C RID: 2828
	internal class CocoaContext : DesktopGraphicsContext
	{
		// Token: 0x060059AD RID: 22957 RVA: 0x000F38F8 File Offset: 0x000F1AF8
		static CocoaContext()
		{
			Cocoa.Initialize();
		}

		// Token: 0x060059AE RID: 22958 RVA: 0x000F3978 File Offset: 0x000F1B78
		public CocoaContext(GraphicsMode mode, IWindowInfo window, IGraphicsContext shareContext, int majorVersion, int minorVersion)
		{
			this.cocoaWindow = (CocoaWindowInfo)window;
			if (shareContext is CocoaContext)
			{
				this.shareContextRef = ((CocoaContext)shareContext).Handle.Handle;
			}
			if (shareContext is GraphicsContext)
			{
				this.shareContextRef = ((shareContext != null) ? (shareContext as IGraphicsContextInternal).Context : ((ContextHandle)IntPtr.Zero)).Handle;
			}
			this.shareContextRef == IntPtr.Zero;
			this.CreateContext(mode, this.cocoaWindow, this.shareContextRef, majorVersion, minorVersion, true);
		}

		// Token: 0x060059AF RID: 22959 RVA: 0x000F3A10 File Offset: 0x000F1C10
		public CocoaContext(ContextHandle handle, IWindowInfo window, IGraphicsContext shareContext, int majorVersion, int minorVersion)
		{
			if (handle == ContextHandle.Zero)
			{
				throw new ArgumentException("handle");
			}
			if (window == null)
			{
				throw new ArgumentNullException("window");
			}
			this.Handle = handle;
			this.cocoaWindow = (CocoaWindowInfo)window;
		}

		// Token: 0x060059B0 RID: 22960 RVA: 0x000F3A5C File Offset: 0x000F1C5C
		private void AddPixelAttrib(List<NSOpenGLPixelFormatAttribute> attributes, NSOpenGLPixelFormatAttribute attribute)
		{
			attributes.Add(attribute);
		}

		// Token: 0x060059B1 RID: 22961 RVA: 0x000F3A68 File Offset: 0x000F1C68
		private void AddPixelAttrib(List<NSOpenGLPixelFormatAttribute> attributes, NSOpenGLPixelFormatAttribute attribute, int value)
		{
			attributes.Add(attribute);
			attributes.Add((NSOpenGLPixelFormatAttribute)value);
		}

		// Token: 0x060059B2 RID: 22962 RVA: 0x000F3A78 File Offset: 0x000F1C78
		private void CreateContext(GraphicsMode mode, CocoaWindowInfo cocoaWindow, IntPtr shareContextRef, int majorVersion, int minorVersion, bool fullscreen)
		{
			IntPtr intPtr = this.SelectPixelFormat(mode, majorVersion, minorVersion);
			if (intPtr == IntPtr.Zero)
			{
				throw new GraphicsException(string.Format("Failed to contruct NSOpenGLPixelFormat for GraphicsMode '{0}'", mode));
			}
			IntPtr intPtr2 = Cocoa.SendIntPtr(CocoaContext.NSOpenGLContext, Selector.Alloc);
			intPtr2 = Cocoa.SendIntPtr(intPtr2, Selector.Get("initWithFormat:shareContext:"), intPtr, shareContextRef);
			if (intPtr2 == IntPtr.Zero)
			{
				throw new GraphicsException(string.Format("Failed to construct NSOpenGLContext", mode));
			}
			Cocoa.SendVoid(intPtr, Selector.Release);
			intPtr = IntPtr.Zero;
			Cocoa.SendVoid(intPtr2, Selector.Get("setView:"), cocoaWindow.ViewHandle);
			Cocoa.SendVoid(cocoaWindow.ViewHandle, Selector.Get("setWantsBestResolutionOpenGLSurface:"), true);
			this.Handle = new ContextHandle(intPtr2);
			this.Mode = this.GetGraphicsMode(intPtr2);
			this.Update(cocoaWindow);
			this.MakeCurrent(cocoaWindow);
		}

		// Token: 0x060059B3 RID: 22963 RVA: 0x000F3B54 File Offset: 0x000F1D54
		private unsafe IntPtr SelectPixelFormat(GraphicsMode mode, int majorVersion, int minorVersion)
		{
			List<NSOpenGLPixelFormatAttribute> list = new List<NSOpenGLPixelFormatAttribute>();
			NSOpenGLProfile value = NSOpenGLProfile.VersionLegacy;
			if (majorVersion > 3 || (majorVersion == 3 && minorVersion >= 2))
			{
				value = NSOpenGLProfile.Version3_2Core;
			}
			this.AddPixelAttrib(list, NSOpenGLPixelFormatAttribute.OpenGLProfile, (int)value);
			if (mode.ColorFormat.BitsPerPixel > 0)
			{
				this.AddPixelAttrib(list, NSOpenGLPixelFormatAttribute.ColorSize, mode.ColorFormat.BitsPerPixel);
			}
			if (mode.Depth > 0)
			{
				this.AddPixelAttrib(list, NSOpenGLPixelFormatAttribute.DepthSize, mode.Depth);
			}
			if (mode.Stencil > 0)
			{
				this.AddPixelAttrib(list, NSOpenGLPixelFormatAttribute.StencilSize, mode.Stencil);
			}
			if (mode.AccumulatorFormat.BitsPerPixel > 0)
			{
				this.AddPixelAttrib(list, NSOpenGLPixelFormatAttribute.AccumSize, mode.AccumulatorFormat.BitsPerPixel);
			}
			if (mode.Samples > 1)
			{
				this.AddPixelAttrib(list, NSOpenGLPixelFormatAttribute.SampleBuffers, 1);
				this.AddPixelAttrib(list, NSOpenGLPixelFormatAttribute.Samples, mode.Samples);
			}
			if (mode.Buffers > 1)
			{
				this.AddPixelAttrib(list, NSOpenGLPixelFormatAttribute.DoubleBuffer);
			}
			if (this.IsAccelerationSupported())
			{
				this.AddPixelAttrib(list, NSOpenGLPixelFormatAttribute.Accelerated);
			}
			this.AddPixelAttrib(list, (NSOpenGLPixelFormatAttribute)0);
			for (int i = 0; i < list.Count; i++)
			{
			}
			IntPtr intPtr = Cocoa.SendIntPtr(Class.Get("NSOpenGLPixelFormat"), Selector.Alloc);
			fixed (NSOpenGLPixelFormatAttribute* ptr = list.ToArray())
			{
				intPtr = Cocoa.SendIntPtr(intPtr, Selector.Get("initWithAttributes:"), (IntPtr)((void*)ptr));
			}
			return intPtr;
		}

		// Token: 0x060059B4 RID: 22964 RVA: 0x000F3CC0 File Offset: 0x000F1EC0
		private bool IsAccelerationSupported()
		{
			IntPtr zero = IntPtr.Zero;
			int num = 0;
			int[] array = new int[2];
			array[0] = 73;
			Cgl.ChoosePixelFormat(array, ref zero, ref num);
			if (zero != IntPtr.Zero)
			{
				Cgl.DestroyPixelFormat(zero);
			}
			return zero != IntPtr.Zero;
		}

		// Token: 0x060059B5 RID: 22965 RVA: 0x000F3D0C File Offset: 0x000F1F0C
		private GraphicsMode GetGraphicsMode(IntPtr context)
		{
			IntPtr context2 = Cocoa.SendIntPtr(context, Selector.Get("CGLContextObj"));
			IntPtr pixelFormat = Cgl.GetPixelFormat(context2);
			int value = 0;
			int bpp;
			Cgl.DescribePixelFormat(pixelFormat, 0, Cgl.PixelFormatInt.ColorSize, out bpp);
			int depth;
			Cgl.DescribePixelFormat(pixelFormat, 0, Cgl.PixelFormatInt.DepthSize, out depth);
			int stencil;
			Cgl.DescribePixelFormat(pixelFormat, 0, Cgl.PixelFormatInt.StencilSize, out stencil);
			int samples;
			Cgl.DescribePixelFormat(pixelFormat, 0, Cgl.PixelFormatInt.Samples, out samples);
			int bpp2;
			Cgl.DescribePixelFormat(pixelFormat, 0, Cgl.PixelFormatInt.AccumSize, out bpp2);
			bool flag;
			Cgl.DescribePixelFormat(pixelFormat, 0, Cgl.PixelFormatBool.Doublebuffer, out flag);
			bool stereo;
			Cgl.DescribePixelFormat(pixelFormat, 0, Cgl.PixelFormatBool.Stereo, out stereo);
			return new GraphicsMode(new IntPtr?((IntPtr)value), bpp, depth, stencil, samples, bpp2, flag ? 2 : 1, stereo);
		}

		// Token: 0x060059B6 RID: 22966 RVA: 0x000F3DB4 File Offset: 0x000F1FB4
		public override void SwapBuffers()
		{
			Cocoa.SendVoid(this.Handle.Handle, CocoaContext.selFlushBuffer);
		}

		// Token: 0x060059B7 RID: 22967 RVA: 0x000F3DCC File Offset: 0x000F1FCC
		public override void MakeCurrent(IWindowInfo window)
		{
			Cocoa.SendVoid(this.Handle.Handle, CocoaContext.selMakeCurrentContext);
		}

		// Token: 0x17000497 RID: 1175
		// (get) Token: 0x060059B8 RID: 22968 RVA: 0x000F3DE4 File Offset: 0x000F1FE4
		public override bool IsCurrent
		{
			get
			{
				return this.Handle.Handle == CocoaContext.CurrentContext;
			}
		}

		// Token: 0x17000498 RID: 1176
		// (get) Token: 0x060059B9 RID: 22969 RVA: 0x000F3DFC File Offset: 0x000F1FFC
		public static IntPtr CurrentContext
		{
			get
			{
				return Cocoa.SendIntPtr(CocoaContext.NSOpenGLContext, CocoaContext.selCurrentContext);
			}
		}

		// Token: 0x060059BA RID: 22970 RVA: 0x000F3E10 File Offset: 0x000F2010
		private unsafe void SetContextValue(int val, NSOpenGLContextParameter par)
		{
			int* value = &val;
			Cocoa.SendVoid(this.Handle.Handle, Selector.Get("setValues:forParameter:"), (IntPtr)((void*)value), (int)par);
		}

		// Token: 0x060059BB RID: 22971 RVA: 0x000F3E44 File Offset: 0x000F2044
		private unsafe int GetContextValue(NSOpenGLContextParameter par)
		{
			int result;
			int* value = &result;
			Cocoa.SendVoid(this.Handle.Handle, Selector.Get("getValues:forParameter:"), (IntPtr)((void*)value), (int)par);
			return result;
		}

		// Token: 0x17000499 RID: 1177
		// (get) Token: 0x060059BC RID: 22972 RVA: 0x000F3E78 File Offset: 0x000F2078
		// (set) Token: 0x060059BD RID: 22973 RVA: 0x000F3E88 File Offset: 0x000F2088
		public override int SwapInterval
		{
			get
			{
				return this.GetContextValue(NSOpenGLContextParameter.SwapInterval);
			}
			set
			{
				if (value < 0)
				{
					value = 1;
				}
				this.SetContextValue(value, NSOpenGLContextParameter.SwapInterval);
			}
		}

		// Token: 0x060059BE RID: 22974 RVA: 0x000F3EA0 File Offset: 0x000F20A0
		public override void Update(IWindowInfo window)
		{
			Cocoa.SendVoid(this.Handle.Handle, CocoaContext.selUpdate);
		}

		// Token: 0x060059BF RID: 22975 RVA: 0x000F3EB8 File Offset: 0x000F20B8
		~CocoaContext()
		{
			this.Dispose(false);
		}

		// Token: 0x060059C0 RID: 22976 RVA: 0x000F3EE8 File Offset: 0x000F20E8
		public override void Dispose()
		{
			this.Dispose(true);
		}

		// Token: 0x060059C1 RID: 22977 RVA: 0x000F3EF4 File Offset: 0x000F20F4
		private void Dispose(bool disposing)
		{
			if (base.IsDisposed || this.Handle.Handle == IntPtr.Zero)
			{
				return;
			}
			Cocoa.SendVoid(CocoaContext.NSOpenGLContext, Selector.Get("clearCurrentContext"));
			Cocoa.SendVoid(this.Handle.Handle, Selector.Get("clearDrawable"));
			Cocoa.SendVoid(this.Handle.Handle, Selector.Get("release"));
			this.Handle = ContextHandle.Zero;
			base.IsDisposed = true;
		}

		// Token: 0x060059C2 RID: 22978 RVA: 0x000F3F7C File Offset: 0x000F217C
		public unsafe override IntPtr GetAddress(IntPtr function)
		{
			byte* ptr = stackalloc byte[(UIntPtr)128];
			byte* ptr2 = ptr;
			byte* ptr3 = (byte*)function.ToPointer();
			int num = 0;
			*(ptr2++) = 95;
			while (*ptr3 != 0 && ++num < 128)
			{
				*(ptr2++) = *(ptr3++);
			}
			IntPtr result = IntPtr.Zero;
			IntPtr intPtr = IntPtr.Zero;
			if (CocoaContext.opengl != IntPtr.Zero)
			{
				intPtr = NS.LookupSymbolInImage(CocoaContext.opengl, new IntPtr((void*)ptr), SymbolLookupFlags.ReturnOnError);
			}
			if (intPtr == IntPtr.Zero && CocoaContext.opengles != IntPtr.Zero)
			{
				intPtr = NS.LookupSymbolInImage(CocoaContext.opengles, new IntPtr((void*)ptr), SymbolLookupFlags.ReturnOnError);
			}
			if (intPtr != IntPtr.Zero)
			{
				result = NS.AddressOfSymbol(intPtr);
			}
			return result;
		}

		// Token: 0x0400B4E8 RID: 46312
		private CocoaWindowInfo cocoaWindow;

		// Token: 0x0400B4E9 RID: 46313
		private IntPtr shareContextRef;

		// Token: 0x0400B4EA RID: 46314
		private static readonly IntPtr NSOpenGLContext = Class.Get("NSOpenGLContext");

		// Token: 0x0400B4EB RID: 46315
		private static readonly IntPtr selCurrentContext = Selector.Get("currentContext");

		// Token: 0x0400B4EC RID: 46316
		private static readonly IntPtr selFlushBuffer = Selector.Get("flushBuffer");

		// Token: 0x0400B4ED RID: 46317
		private static readonly IntPtr selMakeCurrentContext = Selector.Get("makeCurrentContext");

		// Token: 0x0400B4EE RID: 46318
		private static readonly IntPtr selUpdate = Selector.Get("update");

		// Token: 0x0400B4EF RID: 46319
		private static readonly IntPtr opengl = NS.AddImage("/System/Library/Frameworks/OpenGL.framework/OpenGL", AddImageFlags.ReturnOnError);

		// Token: 0x0400B4F0 RID: 46320
		private static readonly IntPtr opengles = NS.AddImage("/System/Library/Frameworks/OpenGL.framework/OpenGLES", AddImageFlags.ReturnOnError);
	}
}
