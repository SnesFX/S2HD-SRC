using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;

namespace Accord.Video
{
	// Token: 0x02000009 RID: 9
	public class JPEGStream : IVideoSource
	{
		// Token: 0x14000007 RID: 7
		// (add) Token: 0x06000063 RID: 99 RVA: 0x00002CD4 File Offset: 0x00001CD4
		// (remove) Token: 0x06000064 RID: 100 RVA: 0x00002D0C File Offset: 0x00001D0C
		public event NewFrameEventHandler NewFrame;

		// Token: 0x14000008 RID: 8
		// (add) Token: 0x06000065 RID: 101 RVA: 0x00002D44 File Offset: 0x00001D44
		// (remove) Token: 0x06000066 RID: 102 RVA: 0x00002D7C File Offset: 0x00001D7C
		public event VideoSourceErrorEventHandler VideoSourceError;

		// Token: 0x14000009 RID: 9
		// (add) Token: 0x06000067 RID: 103 RVA: 0x00002DB4 File Offset: 0x00001DB4
		// (remove) Token: 0x06000068 RID: 104 RVA: 0x00002DEC File Offset: 0x00001DEC
		public event PlayingFinishedEventHandler PlayingFinished;

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x06000069 RID: 105 RVA: 0x00002E21 File Offset: 0x00001E21
		// (set) Token: 0x0600006A RID: 106 RVA: 0x00002E29 File Offset: 0x00001E29
		public bool SeparateConnectionGroup
		{
			get
			{
				return this.useSeparateConnectionGroup;
			}
			set
			{
				this.useSeparateConnectionGroup = value;
			}
		}

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x0600006B RID: 107 RVA: 0x00002E32 File Offset: 0x00001E32
		// (set) Token: 0x0600006C RID: 108 RVA: 0x00002E3A File Offset: 0x00001E3A
		public bool PreventCaching
		{
			get
			{
				return this.preventCaching;
			}
			set
			{
				this.preventCaching = value;
			}
		}

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x0600006D RID: 109 RVA: 0x00002E43 File Offset: 0x00001E43
		// (set) Token: 0x0600006E RID: 110 RVA: 0x00002E4B File Offset: 0x00001E4B
		public int FrameInterval
		{
			get
			{
				return this.frameInterval;
			}
			set
			{
				this.frameInterval = value;
			}
		}

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x0600006F RID: 111 RVA: 0x00002E54 File Offset: 0x00001E54
		// (set) Token: 0x06000070 RID: 112 RVA: 0x00002E5C File Offset: 0x00001E5C
		public virtual string Source
		{
			get
			{
				return this.source;
			}
			set
			{
				this.source = value;
			}
		}

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x06000071 RID: 113 RVA: 0x00002E65 File Offset: 0x00001E65
		// (set) Token: 0x06000072 RID: 114 RVA: 0x00002E6D File Offset: 0x00001E6D
		public string Login
		{
			get
			{
				return this.login;
			}
			set
			{
				this.login = value;
			}
		}

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x06000073 RID: 115 RVA: 0x00002E76 File Offset: 0x00001E76
		// (set) Token: 0x06000074 RID: 116 RVA: 0x00002E7E File Offset: 0x00001E7E
		public string Password
		{
			get
			{
				return this.password;
			}
			set
			{
				this.password = value;
			}
		}

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x06000075 RID: 117 RVA: 0x00002E87 File Offset: 0x00001E87
		// (set) Token: 0x06000076 RID: 118 RVA: 0x00002E8F File Offset: 0x00001E8F
		public IWebProxy Proxy
		{
			get
			{
				return this.proxy;
			}
			set
			{
				this.proxy = value;
			}
		}

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x06000077 RID: 119 RVA: 0x00002E98 File Offset: 0x00001E98
		public int FramesReceived
		{
			get
			{
				int result = this.framesReceived;
				this.framesReceived = 0;
				return result;
			}
		}

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x06000078 RID: 120 RVA: 0x00002EB4 File Offset: 0x00001EB4
		public long BytesReceived
		{
			get
			{
				long result = this.bytesReceived;
				this.bytesReceived = 0L;
				return result;
			}
		}

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x06000079 RID: 121 RVA: 0x00002ED1 File Offset: 0x00001ED1
		// (set) Token: 0x0600007A RID: 122 RVA: 0x00002ED9 File Offset: 0x00001ED9
		public int RequestTimeout
		{
			get
			{
				return this.requestTimeout;
			}
			set
			{
				this.requestTimeout = value;
			}
		}

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x0600007B RID: 123 RVA: 0x00002EE2 File Offset: 0x00001EE2
		public bool IsRunning
		{
			get
			{
				if (this.thread != null)
				{
					if (!this.thread.Join(0))
					{
						return true;
					}
					this.Free();
				}
				return false;
			}
		}

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x0600007C RID: 124 RVA: 0x00002F03 File Offset: 0x00001F03
		// (set) Token: 0x0600007D RID: 125 RVA: 0x00002F0B File Offset: 0x00001F0B
		public bool ForceBasicAuthentication
		{
			get
			{
				return this.forceBasicAuthentication;
			}
			set
			{
				this.forceBasicAuthentication = value;
			}
		}

		// Token: 0x0600007E RID: 126 RVA: 0x00002F14 File Offset: 0x00001F14
		public JPEGStream()
		{
		}

		// Token: 0x0600007F RID: 127 RVA: 0x00002F2E File Offset: 0x00001F2E
		public JPEGStream(string source)
		{
			this.source = source;
		}

		// Token: 0x06000080 RID: 128 RVA: 0x00002F50 File Offset: 0x00001F50
		public void Start()
		{
			if (!this.IsRunning)
			{
				if (this.source == null || this.source == string.Empty)
				{
					throw new ArgumentException("Video source is not specified.");
				}
				this.framesReceived = 0;
				this.bytesReceived = 0L;
				this.stopEvent = new ManualResetEvent(false);
				this.thread = new Thread(new ThreadStart(this.WorkerThread));
				this.thread.Name = this.source;
				this.thread.Start();
			}
		}

		// Token: 0x06000081 RID: 129 RVA: 0x00002FD8 File Offset: 0x00001FD8
		public void SignalToStop()
		{
			if (this.thread != null)
			{
				this.stopEvent.Set();
			}
		}

		// Token: 0x06000082 RID: 130 RVA: 0x00002FEE File Offset: 0x00001FEE
		public void WaitForStop()
		{
			if (this.thread != null)
			{
				this.thread.Join();
				this.Free();
			}
		}

		// Token: 0x06000083 RID: 131 RVA: 0x00003009 File Offset: 0x00002009
		public void Stop()
		{
			if (this.IsRunning)
			{
				this.stopEvent.Set();
				this.thread.Abort();
				this.WaitForStop();
			}
		}

		// Token: 0x06000084 RID: 132 RVA: 0x00003030 File Offset: 0x00002030
		private void Free()
		{
			this.thread = null;
			this.stopEvent.Close();
			this.stopEvent = null;
		}

		// Token: 0x06000085 RID: 133 RVA: 0x0000304C File Offset: 0x0000204C
		private void WorkerThread()
		{
			byte[] buffer = new byte[1048576];
			HttpWebRequest httpWebRequest = null;
			WebResponse webResponse = null;
			Stream stream = null;
			Random random = new Random((int)DateTime.Now.Ticks);
			while (!this.stopEvent.WaitOne(0, false))
			{
				int num = 0;
				try
				{
					DateTime now = DateTime.Now;
					if (!this.preventCaching)
					{
						httpWebRequest = (HttpWebRequest)WebRequest.Create(this.source);
					}
					else
					{
						httpWebRequest = (HttpWebRequest)WebRequest.Create(this.source + ((this.source.IndexOf('?') == -1) ? '?' : '&').ToString() + "fake=" + random.Next().ToString());
					}
					if (this.proxy != null)
					{
						httpWebRequest.Proxy = this.proxy;
					}
					httpWebRequest.Timeout = this.requestTimeout;
					if (this.login != null && this.password != null && this.login != string.Empty)
					{
						httpWebRequest.Credentials = new NetworkCredential(this.login, this.password);
					}
					if (this.useSeparateConnectionGroup)
					{
						httpWebRequest.ConnectionGroupName = this.GetHashCode().ToString();
					}
					if (this.forceBasicAuthentication)
					{
						string text = string.Format("{0}:{1}", this.login, this.password);
						text = Convert.ToBase64String(Encoding.Default.GetBytes(text));
						httpWebRequest.Headers["Authorization"] = "Basic " + text;
					}
					webResponse = httpWebRequest.GetResponse();
					stream = webResponse.GetResponseStream();
					stream.ReadTimeout = this.requestTimeout;
					while (!this.stopEvent.WaitOne(0, false))
					{
						if (num > 1047552)
						{
							num = 0;
						}
						int num2;
						if ((num2 = stream.Read(buffer, num, 1024)) == 0)
						{
							break;
						}
						num += num2;
						this.bytesReceived += (long)num2;
					}
					if (!this.stopEvent.WaitOne(0, false))
					{
						this.framesReceived++;
						if (this.NewFrame != null)
						{
							Bitmap bitmap = (Bitmap)Image.FromStream(new MemoryStream(buffer, 0, num));
							this.NewFrame(this, new NewFrameEventArgs(bitmap));
							bitmap.Dispose();
						}
					}
					if (this.frameInterval > 0)
					{
						TimeSpan timeSpan = DateTime.Now.Subtract(now);
						int num3 = this.frameInterval - (int)timeSpan.TotalMilliseconds;
						if (num3 > 0 && this.stopEvent.WaitOne(num3, false))
						{
							break;
						}
					}
				}
				catch (ThreadAbortException)
				{
					break;
				}
				catch (Exception ex)
				{
					if (this.VideoSourceError != null)
					{
						this.VideoSourceError(this, new VideoSourceErrorEventArgs(ex.Message));
					}
					Thread.Sleep(250);
				}
				finally
				{
					if (httpWebRequest != null)
					{
						httpWebRequest.Abort();
						httpWebRequest = null;
					}
					if (stream != null)
					{
						stream.Close();
						stream = null;
					}
					if (webResponse != null)
					{
						webResponse.Close();
						webResponse = null;
					}
				}
				if (this.stopEvent.WaitOne(0, false))
				{
					break;
				}
			}
			if (this.PlayingFinished != null)
			{
				this.PlayingFinished(this, ReasonToFinishPlaying.StoppedByUser);
			}
		}

		// Token: 0x0400001B RID: 27
		private string source;

		// Token: 0x0400001C RID: 28
		private string login;

		// Token: 0x0400001D RID: 29
		private string password;

		// Token: 0x0400001E RID: 30
		private IWebProxy proxy;

		// Token: 0x0400001F RID: 31
		private int framesReceived;

		// Token: 0x04000020 RID: 32
		private long bytesReceived;

		// Token: 0x04000021 RID: 33
		private bool useSeparateConnectionGroup;

		// Token: 0x04000022 RID: 34
		private bool preventCaching = true;

		// Token: 0x04000023 RID: 35
		private int frameInterval;

		// Token: 0x04000024 RID: 36
		private int requestTimeout = 10000;

		// Token: 0x04000025 RID: 37
		private bool forceBasicAuthentication;

		// Token: 0x04000026 RID: 38
		private const int bufferSize = 1048576;

		// Token: 0x04000027 RID: 39
		private const int readSize = 1024;

		// Token: 0x04000028 RID: 40
		private Thread thread;

		// Token: 0x04000029 RID: 41
		private ManualResetEvent stopEvent;
	}
}
