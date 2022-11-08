using System;
using System.ComponentModel;
using System.Drawing;
using OpenTK.Input;
using OpenTK.Platform;

namespace OpenTK
{
	// Token: 0x0200004C RID: 76
	public interface INativeWindow : IDisposable
	{
		// Token: 0x1700010A RID: 266
		// (get) Token: 0x0600050C RID: 1292
		// (set) Token: 0x0600050D RID: 1293
		Icon Icon { get; set; }

		// Token: 0x1700010B RID: 267
		// (get) Token: 0x0600050E RID: 1294
		// (set) Token: 0x0600050F RID: 1295
		string Title { get; set; }

		// Token: 0x1700010C RID: 268
		// (get) Token: 0x06000510 RID: 1296
		bool Focused { get; }

		// Token: 0x1700010D RID: 269
		// (get) Token: 0x06000511 RID: 1297
		// (set) Token: 0x06000512 RID: 1298
		bool Visible { get; set; }

		// Token: 0x1700010E RID: 270
		// (get) Token: 0x06000513 RID: 1299
		bool Exists { get; }

		// Token: 0x1700010F RID: 271
		// (get) Token: 0x06000514 RID: 1300
		IWindowInfo WindowInfo { get; }

		// Token: 0x17000110 RID: 272
		// (get) Token: 0x06000515 RID: 1301
		// (set) Token: 0x06000516 RID: 1302
		WindowState WindowState { get; set; }

		// Token: 0x17000111 RID: 273
		// (get) Token: 0x06000517 RID: 1303
		// (set) Token: 0x06000518 RID: 1304
		WindowBorder WindowBorder { get; set; }

		// Token: 0x17000112 RID: 274
		// (get) Token: 0x06000519 RID: 1305
		// (set) Token: 0x0600051A RID: 1306
		Rectangle Bounds { get; set; }

		// Token: 0x17000113 RID: 275
		// (get) Token: 0x0600051B RID: 1307
		// (set) Token: 0x0600051C RID: 1308
		Point Location { get; set; }

		// Token: 0x17000114 RID: 276
		// (get) Token: 0x0600051D RID: 1309
		// (set) Token: 0x0600051E RID: 1310
		Size Size { get; set; }

		// Token: 0x17000115 RID: 277
		// (get) Token: 0x0600051F RID: 1311
		// (set) Token: 0x06000520 RID: 1312
		int X { get; set; }

		// Token: 0x17000116 RID: 278
		// (get) Token: 0x06000521 RID: 1313
		// (set) Token: 0x06000522 RID: 1314
		int Y { get; set; }

		// Token: 0x17000117 RID: 279
		// (get) Token: 0x06000523 RID: 1315
		// (set) Token: 0x06000524 RID: 1316
		int Width { get; set; }

		// Token: 0x17000118 RID: 280
		// (get) Token: 0x06000525 RID: 1317
		// (set) Token: 0x06000526 RID: 1318
		int Height { get; set; }

		// Token: 0x17000119 RID: 281
		// (get) Token: 0x06000527 RID: 1319
		// (set) Token: 0x06000528 RID: 1320
		Rectangle ClientRectangle { get; set; }

		// Token: 0x1700011A RID: 282
		// (get) Token: 0x06000529 RID: 1321
		// (set) Token: 0x0600052A RID: 1322
		Size ClientSize { get; set; }

		// Token: 0x1700011B RID: 283
		// (get) Token: 0x0600052B RID: 1323
		[Obsolete("Use OpenTK.Input.Mouse/Keyboard/Joystick/GamePad instead.")]
		IInputDriver InputDriver { get; }

		// Token: 0x1700011C RID: 284
		// (get) Token: 0x0600052C RID: 1324
		// (set) Token: 0x0600052D RID: 1325
		MouseCursor Cursor { get; set; }

		// Token: 0x1700011D RID: 285
		// (get) Token: 0x0600052E RID: 1326
		// (set) Token: 0x0600052F RID: 1327
		bool CursorVisible { get; set; }

		// Token: 0x06000530 RID: 1328
		void Close();

		// Token: 0x06000531 RID: 1329
		void ProcessEvents();

		// Token: 0x06000532 RID: 1330
		Point PointToClient(Point point);

		// Token: 0x06000533 RID: 1331
		Point PointToScreen(Point point);

		// Token: 0x14000001 RID: 1
		// (add) Token: 0x06000534 RID: 1332
		// (remove) Token: 0x06000535 RID: 1333
		event EventHandler<EventArgs> Move;

		// Token: 0x14000002 RID: 2
		// (add) Token: 0x06000536 RID: 1334
		// (remove) Token: 0x06000537 RID: 1335
		event EventHandler<EventArgs> Resize;

		// Token: 0x14000003 RID: 3
		// (add) Token: 0x06000538 RID: 1336
		// (remove) Token: 0x06000539 RID: 1337
		event EventHandler<CancelEventArgs> Closing;

		// Token: 0x14000004 RID: 4
		// (add) Token: 0x0600053A RID: 1338
		// (remove) Token: 0x0600053B RID: 1339
		event EventHandler<EventArgs> Closed;

		// Token: 0x14000005 RID: 5
		// (add) Token: 0x0600053C RID: 1340
		// (remove) Token: 0x0600053D RID: 1341
		event EventHandler<EventArgs> Disposed;

		// Token: 0x14000006 RID: 6
		// (add) Token: 0x0600053E RID: 1342
		// (remove) Token: 0x0600053F RID: 1343
		event EventHandler<EventArgs> IconChanged;

		// Token: 0x14000007 RID: 7
		// (add) Token: 0x06000540 RID: 1344
		// (remove) Token: 0x06000541 RID: 1345
		event EventHandler<EventArgs> TitleChanged;

		// Token: 0x14000008 RID: 8
		// (add) Token: 0x06000542 RID: 1346
		// (remove) Token: 0x06000543 RID: 1347
		event EventHandler<EventArgs> VisibleChanged;

		// Token: 0x14000009 RID: 9
		// (add) Token: 0x06000544 RID: 1348
		// (remove) Token: 0x06000545 RID: 1349
		event EventHandler<EventArgs> FocusedChanged;

		// Token: 0x1400000A RID: 10
		// (add) Token: 0x06000546 RID: 1350
		// (remove) Token: 0x06000547 RID: 1351
		event EventHandler<EventArgs> WindowBorderChanged;

		// Token: 0x1400000B RID: 11
		// (add) Token: 0x06000548 RID: 1352
		// (remove) Token: 0x06000549 RID: 1353
		event EventHandler<EventArgs> WindowStateChanged;

		// Token: 0x1400000C RID: 12
		// (add) Token: 0x0600054A RID: 1354
		// (remove) Token: 0x0600054B RID: 1355
		event EventHandler<KeyboardKeyEventArgs> KeyDown;

		// Token: 0x1400000D RID: 13
		// (add) Token: 0x0600054C RID: 1356
		// (remove) Token: 0x0600054D RID: 1357
		event EventHandler<KeyPressEventArgs> KeyPress;

		// Token: 0x1400000E RID: 14
		// (add) Token: 0x0600054E RID: 1358
		// (remove) Token: 0x0600054F RID: 1359
		event EventHandler<KeyboardKeyEventArgs> KeyUp;

		// Token: 0x1400000F RID: 15
		// (add) Token: 0x06000550 RID: 1360
		// (remove) Token: 0x06000551 RID: 1361
		event EventHandler<EventArgs> MouseLeave;

		// Token: 0x14000010 RID: 16
		// (add) Token: 0x06000552 RID: 1362
		// (remove) Token: 0x06000553 RID: 1363
		event EventHandler<EventArgs> MouseEnter;

		// Token: 0x14000011 RID: 17
		// (add) Token: 0x06000554 RID: 1364
		// (remove) Token: 0x06000555 RID: 1365
		event EventHandler<MouseButtonEventArgs> MouseDown;

		// Token: 0x14000012 RID: 18
		// (add) Token: 0x06000556 RID: 1366
		// (remove) Token: 0x06000557 RID: 1367
		event EventHandler<MouseButtonEventArgs> MouseUp;

		// Token: 0x14000013 RID: 19
		// (add) Token: 0x06000558 RID: 1368
		// (remove) Token: 0x06000559 RID: 1369
		event EventHandler<MouseMoveEventArgs> MouseMove;

		// Token: 0x14000014 RID: 20
		// (add) Token: 0x0600055A RID: 1370
		// (remove) Token: 0x0600055B RID: 1371
		event EventHandler<MouseWheelEventArgs> MouseWheel;
	}
}
