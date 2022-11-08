using System;

namespace OpenTK.Platform
{
	// Token: 0x0200004D RID: 77
	public interface IGameWindow : INativeWindow, IDisposable
	{
		// Token: 0x0600055C RID: 1372
		void Run();

		// Token: 0x0600055D RID: 1373
		void Run(double updateRate);

		// Token: 0x0600055E RID: 1374
		void MakeCurrent();

		// Token: 0x0600055F RID: 1375
		void SwapBuffers();

		// Token: 0x14000015 RID: 21
		// (add) Token: 0x06000560 RID: 1376
		// (remove) Token: 0x06000561 RID: 1377
		event EventHandler<EventArgs> Load;

		// Token: 0x14000016 RID: 22
		// (add) Token: 0x06000562 RID: 1378
		// (remove) Token: 0x06000563 RID: 1379
		event EventHandler<EventArgs> Unload;

		// Token: 0x14000017 RID: 23
		// (add) Token: 0x06000564 RID: 1380
		// (remove) Token: 0x06000565 RID: 1381
		event EventHandler<FrameEventArgs> UpdateFrame;

		// Token: 0x14000018 RID: 24
		// (add) Token: 0x06000566 RID: 1382
		// (remove) Token: 0x06000567 RID: 1383
		event EventHandler<FrameEventArgs> RenderFrame;
	}
}
