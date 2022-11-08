using System;

namespace Accord.Video
{
	// Token: 0x02000008 RID: 8
	public interface IVideoSource
	{
		// Token: 0x14000004 RID: 4
		// (add) Token: 0x06000055 RID: 85
		// (remove) Token: 0x06000056 RID: 86
		event NewFrameEventHandler NewFrame;

		// Token: 0x14000005 RID: 5
		// (add) Token: 0x06000057 RID: 87
		// (remove) Token: 0x06000058 RID: 88
		event VideoSourceErrorEventHandler VideoSourceError;

		// Token: 0x14000006 RID: 6
		// (add) Token: 0x06000059 RID: 89
		// (remove) Token: 0x0600005A RID: 90
		event PlayingFinishedEventHandler PlayingFinished;

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x0600005B RID: 91
		string Source { get; }

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x0600005C RID: 92
		int FramesReceived { get; }

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x0600005D RID: 93
		long BytesReceived { get; }

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x0600005E RID: 94
		bool IsRunning { get; }

		// Token: 0x0600005F RID: 95
		void Start();

		// Token: 0x06000060 RID: 96
		void SignalToStop();

		// Token: 0x06000061 RID: 97
		void WaitForStop();

		// Token: 0x06000062 RID: 98
		void Stop();
	}
}
