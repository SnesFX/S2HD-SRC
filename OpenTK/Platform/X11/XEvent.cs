using System;
using System.Reflection;
using System.Runtime.InteropServices;

namespace OpenTK.Platform.X11
{
	// Token: 0x02000157 RID: 343
	[StructLayout(LayoutKind.Explicit)]
	internal struct XEvent
	{
		// Token: 0x06000B08 RID: 2824 RVA: 0x00025FB4 File Offset: 0x000241B4
		public override string ToString()
		{
			XEventName xeventName = this.type;
			if (xeventName == XEventName.ConfigureNotify)
			{
				return XEvent.ToString(this.ConfigureEvent);
			}
			if (xeventName == XEventName.ResizeRequest)
			{
				return XEvent.ToString(this.ResizeRequestEvent);
			}
			if (xeventName == XEventName.PropertyNotify)
			{
				return XEvent.ToString(this.PropertyEvent);
			}
			return this.type.ToString();
		}

		// Token: 0x06000B09 RID: 2825 RVA: 0x0002601C File Offset: 0x0002421C
		public static string ToString(object ev)
		{
			string text = string.Empty;
			Type type = ev.GetType();
			FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
			for (int i = 0; i < fields.Length; i++)
			{
				if (text != string.Empty)
				{
					text += ", ";
				}
				object value = fields[i].GetValue(ev);
				text = text + fields[i].Name + "=" + ((value == null) ? "<null>" : value.ToString());
			}
			return type.Name + " (" + text + ")";
		}

		// Token: 0x04000DA2 RID: 3490
		[FieldOffset(0)]
		public XEventName type;

		// Token: 0x04000DA3 RID: 3491
		[FieldOffset(0)]
		public XAnyEvent AnyEvent;

		// Token: 0x04000DA4 RID: 3492
		[FieldOffset(0)]
		public XKeyEvent KeyEvent;

		// Token: 0x04000DA5 RID: 3493
		[FieldOffset(0)]
		public XButtonEvent ButtonEvent;

		// Token: 0x04000DA6 RID: 3494
		[FieldOffset(0)]
		public XMotionEvent MotionEvent;

		// Token: 0x04000DA7 RID: 3495
		[FieldOffset(0)]
		public XCrossingEvent CrossingEvent;

		// Token: 0x04000DA8 RID: 3496
		[FieldOffset(0)]
		public XFocusChangeEvent FocusChangeEvent;

		// Token: 0x04000DA9 RID: 3497
		[FieldOffset(0)]
		public XExposeEvent ExposeEvent;

		// Token: 0x04000DAA RID: 3498
		[FieldOffset(0)]
		public XGraphicsExposeEvent GraphicsExposeEvent;

		// Token: 0x04000DAB RID: 3499
		[FieldOffset(0)]
		public XNoExposeEvent NoExposeEvent;

		// Token: 0x04000DAC RID: 3500
		[FieldOffset(0)]
		public XVisibilityEvent VisibilityEvent;

		// Token: 0x04000DAD RID: 3501
		[FieldOffset(0)]
		public XCreateWindowEvent CreateWindowEvent;

		// Token: 0x04000DAE RID: 3502
		[FieldOffset(0)]
		public XDestroyWindowEvent DestroyWindowEvent;

		// Token: 0x04000DAF RID: 3503
		[FieldOffset(0)]
		public XUnmapEvent UnmapEvent;

		// Token: 0x04000DB0 RID: 3504
		[FieldOffset(0)]
		public XMapEvent MapEvent;

		// Token: 0x04000DB1 RID: 3505
		[FieldOffset(0)]
		public XMapRequestEvent MapRequestEvent;

		// Token: 0x04000DB2 RID: 3506
		[FieldOffset(0)]
		public XReparentEvent ReparentEvent;

		// Token: 0x04000DB3 RID: 3507
		[FieldOffset(0)]
		public XConfigureEvent ConfigureEvent;

		// Token: 0x04000DB4 RID: 3508
		[FieldOffset(0)]
		public XGravityEvent GravityEvent;

		// Token: 0x04000DB5 RID: 3509
		[FieldOffset(0)]
		public XResizeRequestEvent ResizeRequestEvent;

		// Token: 0x04000DB6 RID: 3510
		[FieldOffset(0)]
		public XConfigureRequestEvent ConfigureRequestEvent;

		// Token: 0x04000DB7 RID: 3511
		[FieldOffset(0)]
		public XCirculateEvent CirculateEvent;

		// Token: 0x04000DB8 RID: 3512
		[FieldOffset(0)]
		public XCirculateRequestEvent CirculateRequestEvent;

		// Token: 0x04000DB9 RID: 3513
		[FieldOffset(0)]
		public XPropertyEvent PropertyEvent;

		// Token: 0x04000DBA RID: 3514
		[FieldOffset(0)]
		public XSelectionClearEvent SelectionClearEvent;

		// Token: 0x04000DBB RID: 3515
		[FieldOffset(0)]
		public XSelectionRequestEvent SelectionRequestEvent;

		// Token: 0x04000DBC RID: 3516
		[FieldOffset(0)]
		public XSelectionEvent SelectionEvent;

		// Token: 0x04000DBD RID: 3517
		[FieldOffset(0)]
		public XColormapEvent ColormapEvent;

		// Token: 0x04000DBE RID: 3518
		[FieldOffset(0)]
		public XClientMessageEvent ClientMessageEvent;

		// Token: 0x04000DBF RID: 3519
		[FieldOffset(0)]
		public XMappingEvent MappingEvent;

		// Token: 0x04000DC0 RID: 3520
		[FieldOffset(0)]
		public XErrorEvent ErrorEvent;

		// Token: 0x04000DC1 RID: 3521
		[FieldOffset(0)]
		public XKeymapEvent KeymapEvent;

		// Token: 0x04000DC2 RID: 3522
		[FieldOffset(0)]
		public XGenericEvent GenericEvent;

		// Token: 0x04000DC3 RID: 3523
		[FieldOffset(0)]
		public XGenericEventCookie GenericEventCookie;

		// Token: 0x04000DC4 RID: 3524
		[FieldOffset(0)]
		public XEventPad Pad;
	}
}
