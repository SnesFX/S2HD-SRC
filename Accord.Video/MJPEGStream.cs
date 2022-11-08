using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;

namespace Accord.Video
{
	// Token: 0x0200000A RID: 10
	public class MJPEGStream : IVideoSource
	{
		// Token: 0x1400000A RID: 10
		// (add) Token: 0x06000086 RID: 134 RVA: 0x0000338C File Offset: 0x0000238C
		// (remove) Token: 0x06000087 RID: 135 RVA: 0x000033C4 File Offset: 0x000023C4
		public event NewFrameEventHandler NewFrame;

		// Token: 0x1400000B RID: 11
		// (add) Token: 0x06000088 RID: 136 RVA: 0x000033FC File Offset: 0x000023FC
		// (remove) Token: 0x06000089 RID: 137 RVA: 0x00003434 File Offset: 0x00002434
		public event VideoSourceErrorEventHandler VideoSourceError;

		// Token: 0x1400000C RID: 12
		// (add) Token: 0x0600008A RID: 138 RVA: 0x0000346C File Offset: 0x0000246C
		// (remove) Token: 0x0600008B RID: 139 RVA: 0x000034A4 File Offset: 0x000024A4
		public event PlayingFinishedEventHandler PlayingFinished;

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x0600008C RID: 140 RVA: 0x000034D9 File Offset: 0x000024D9
		// (set) Token: 0x0600008D RID: 141 RVA: 0x000034E1 File Offset: 0x000024E1
		public bool SeparateConnectionGroup
		{
			get
			{
				return this._useSeparateConnectionGroup;
			}
			set
			{
				this._useSeparateConnectionGroup = value;
			}
		}

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x0600008E RID: 142 RVA: 0x000034EA File Offset: 0x000024EA
		// (set) Token: 0x0600008F RID: 143 RVA: 0x000034F2 File Offset: 0x000024F2
		public string Source
		{
			get
			{
				return this._source;
			}
			set
			{
				this._source = value;
				this.ReloadThread();
			}
		}

		// Token: 0x06000090 RID: 144 RVA: 0x00003501 File Offset: 0x00002501
		private void ReloadThread()
		{
			if (this._thread != null)
			{
				this._reloadEvent.Set();
			}
		}

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x06000091 RID: 145 RVA: 0x00003517 File Offset: 0x00002517
		// (set) Token: 0x06000092 RID: 146 RVA: 0x0000351F File Offset: 0x0000251F
		public string Login
		{
			get
			{
				return this._userName;
			}
			set
			{
				this._userName = value;
			}
		}

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x06000093 RID: 147 RVA: 0x00003528 File Offset: 0x00002528
		// (set) Token: 0x06000094 RID: 148 RVA: 0x00003530 File Offset: 0x00002530
		public string Password
		{
			get
			{
				return this._password;
			}
			set
			{
				this._password = value;
			}
		}

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x06000095 RID: 149 RVA: 0x00003539 File Offset: 0x00002539
		// (set) Token: 0x06000096 RID: 150 RVA: 0x00003541 File Offset: 0x00002541
		public IWebProxy Proxy
		{
			get
			{
				return this._proxy;
			}
			set
			{
				this._proxy = value;
			}
		}

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x06000097 RID: 151 RVA: 0x0000354A File Offset: 0x0000254A
		// (set) Token: 0x06000098 RID: 152 RVA: 0x00003552 File Offset: 0x00002552
		public string HttpUserAgent
		{
			get
			{
				return this._userAgent;
			}
			set
			{
				this._userAgent = value;
			}
		}

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x06000099 RID: 153 RVA: 0x0000355C File Offset: 0x0000255C
		public int FramesReceived
		{
			get
			{
				int framesReceived = this._framesReceived;
				this._framesReceived = 0;
				return framesReceived;
			}
		}

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x0600009A RID: 154 RVA: 0x00003578 File Offset: 0x00002578
		public long BytesReceived
		{
			get
			{
				long bytesReceived = this._bytesReceived;
				this._bytesReceived = 0L;
				return bytesReceived;
			}
		}

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x0600009B RID: 155 RVA: 0x00003595 File Offset: 0x00002595
		// (set) Token: 0x0600009C RID: 156 RVA: 0x0000359D File Offset: 0x0000259D
		public int RequestTimeout
		{
			get
			{
				return this._requestTimeout;
			}
			set
			{
				this._requestTimeout = value;
			}
		}

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x0600009D RID: 157 RVA: 0x000035A6 File Offset: 0x000025A6
		public bool IsRunning
		{
			get
			{
				return this.IsThreadRunning();
			}
		}

		// Token: 0x0600009E RID: 158 RVA: 0x000035B0 File Offset: 0x000025B0
		private bool IsThreadRunning()
		{
			bool result = false;
			if (this._thread != null)
			{
				if (!this._thread.Join(0))
				{
					result = true;
				}
				else
				{
					this.FreeThreadResources();
				}
			}
			return result;
		}

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x0600009F RID: 159 RVA: 0x000035E0 File Offset: 0x000025E0
		private bool IsReloadRequested
		{
			get
			{
				return this._reloadEvent.WaitOne(0, false);
			}
		}

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x060000A0 RID: 160 RVA: 0x000035EF File Offset: 0x000025EF
		private bool IsStopRequested
		{
			get
			{
				return this._stopEvent.WaitOne(0, false);
			}
		}

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x060000A1 RID: 161 RVA: 0x000035FE File Offset: 0x000025FE
		// (set) Token: 0x060000A2 RID: 162 RVA: 0x00003606 File Offset: 0x00002606
		public bool ForceBasicAuthentication
		{
			get
			{
				return this._forceBasicAuthentication;
			}
			set
			{
				this._forceBasicAuthentication = value;
			}
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x0000360F File Offset: 0x0000260F
		public MJPEGStream()
		{
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x00003634 File Offset: 0x00002634
		public MJPEGStream(string source)
		{
			this._source = source;
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x00003660 File Offset: 0x00002660
		public void Start()
		{
			if (!this.IsRunning)
			{
				if (this._source == null || this._source == string.Empty)
				{
					throw new ArgumentException("Video source is not specified.");
				}
				this._framesReceived = 0;
				this._bytesReceived = 0L;
				this._stopEvent = new ManualResetEvent(false);
				this._reloadEvent = new ManualResetEvent(false);
				this._thread = new Thread(new ThreadStart(this.WorkerThread))
				{
					Name = this._source
				};
				this._thread.Start();
			}
		}

		// Token: 0x060000A6 RID: 166 RVA: 0x000036EF File Offset: 0x000026EF
		public void SignalToStop()
		{
			if (this._thread != null)
			{
				this._stopEvent.Set();
			}
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x00003705 File Offset: 0x00002705
		public void WaitForStop()
		{
			if (this._thread != null)
			{
				this._thread.Join();
				this.FreeThreadResources();
			}
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x00003720 File Offset: 0x00002720
		public void Stop()
		{
			if (this.IsRunning)
			{
				this._stopEvent.Set();
				this._thread.Abort();
				this.WaitForStop();
			}
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x00003747 File Offset: 0x00002747
		private void FreeThreadResources()
		{
			this._thread = null;
			this._stopEvent.Close();
			this._stopEvent = null;
			this._reloadEvent.Close();
			this._reloadEvent = null;
		}

		// Token: 0x060000AA RID: 170 RVA: 0x00003774 File Offset: 0x00002774
		private void WorkerThread()
		{
			while (!this.IsStopRequested)
			{
				WebResponse webResponse = null;
				this._reloadEvent.Reset();
				try
				{
					webResponse = this.GetResponse();
					Boundary boundary = Boundary.FromResponse(webResponse);
					MJPEGStreamParser mjpegstreamParser = new MJPEGStreamParser(boundary, MJPEGStream.JPEG_HEADER_BYTES, 1048576);
					using (Stream responseStream = this.GetResponseStream(webResponse))
					{
						while (!this.IsStopRequested && !this.IsReloadRequested)
						{
							this._bytesReceived += (long)mjpegstreamParser.Read(responseStream);
							if (boundary.HasValue && !boundary.IsChecked)
							{
								boundary.FixMalformedBoundary(mjpegstreamParser);
							}
							if (boundary.IsValid)
							{
								mjpegstreamParser.DetectFrame();
								if (mjpegstreamParser.HasFrame)
								{
									this._framesReceived++;
									if (this.NewFrame != null && !this.IsStopRequested)
									{
										using (Bitmap frame = mjpegstreamParser.GetFrame())
										{
											this.NewFrame(this, new NewFrameEventArgs(frame));
										}
										mjpegstreamParser.RemoveFrame();
									}
								}
							}
						}
					}
				}
				catch (ApplicationException)
				{
					Thread.Sleep(250);
				}
				catch (ThreadAbortException)
				{
					break;
				}
				catch (Exception ex)
				{
					if (this.VideoSourceError != null)
					{
						this.VideoSourceError(this, new VideoSourceErrorEventArgs(ex.Message, ex));
					}
					Thread.Sleep(250);
				}
				finally
				{
					if (webResponse != null)
					{
						webResponse.Close();
					}
				}
				if (this.IsStopRequested)
				{
					break;
				}
			}
			if (this.PlayingFinished != null)
			{
				this.PlayingFinished(this, ReasonToFinishPlaying.StoppedByUser);
			}
		}

		// Token: 0x060000AB RID: 171 RVA: 0x00003978 File Offset: 0x00002978
		private WebResponse GetResponse()
		{
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(this._source);
			WebResponse response;
			try
			{
				this.SetUserAgent(httpWebRequest);
				this.SetProxy(httpWebRequest);
				this.SetRequestTimeout(httpWebRequest);
				this.SetCredentials(httpWebRequest);
				this.SetConnectionGroupName(httpWebRequest);
				if (this._forceBasicAuthentication)
				{
					this.SetBasicAuthentication(httpWebRequest);
				}
				response = httpWebRequest.GetResponse();
			}
			catch (WebException)
			{
				if (httpWebRequest != null)
				{
					httpWebRequest.Abort();
				}
				throw;
			}
			return response;
		}

		// Token: 0x060000AC RID: 172 RVA: 0x000039F0 File Offset: 0x000029F0
		private void SetUserAgent(HttpWebRequest request)
		{
			if (this._userAgent != null)
			{
				request.UserAgent = this._userAgent;
			}
		}

		// Token: 0x060000AD RID: 173 RVA: 0x00003A06 File Offset: 0x00002A06
		private void SetProxy(HttpWebRequest request)
		{
			if (this._proxy != null)
			{
				request.Proxy = this._proxy;
			}
		}

		// Token: 0x060000AE RID: 174 RVA: 0x00003A1C File Offset: 0x00002A1C
		private void SetRequestTimeout(HttpWebRequest request)
		{
			request.Timeout = this._requestTimeout;
		}

		// Token: 0x060000AF RID: 175 RVA: 0x00003A2A File Offset: 0x00002A2A
		private void SetCredentials(HttpWebRequest request)
		{
			if (!string.IsNullOrEmpty(this._userName) && this._password != null)
			{
				request.Credentials = new NetworkCredential(this._userName, this._password);
			}
		}

		// Token: 0x060000B0 RID: 176 RVA: 0x00003A58 File Offset: 0x00002A58
		private void SetConnectionGroupName(HttpWebRequest request)
		{
			if (this._useSeparateConnectionGroup)
			{
				request.ConnectionGroupName = this.GetHashCode().ToString();
			}
		}

		// Token: 0x060000B1 RID: 177 RVA: 0x00003A84 File Offset: 0x00002A84
		private void SetBasicAuthentication(HttpWebRequest request)
		{
			string s = string.Format("{0}:{1}", this._userName, this._password);
			byte[] bytes = Encoding.Default.GetBytes(s);
			string arg = Convert.ToBase64String(bytes);
			request.Headers["Authorization"] = string.Format("{0} {1}", "Basic", arg);
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x00003ADC File Offset: 0x00002ADC
		private Stream GetResponseStream(WebResponse response)
		{
			Stream stream = response.GetResponseStream();
			if (!stream.CanTimeout)
			{
				stream = new TimeoutStream(stream);
			}
			this.SetTimeout(stream);
			return stream;
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x00003B07 File Offset: 0x00002B07
		private void SetTimeout(Stream stream)
		{
			if (stream.CanTimeout)
			{
				stream.ReadTimeout = this._requestTimeout;
			}
		}

		// Token: 0x0400002D RID: 45
		private string _source;

		// Token: 0x0400002E RID: 46
		private string _userName;

		// Token: 0x0400002F RID: 47
		private string _password;

		// Token: 0x04000030 RID: 48
		private IWebProxy _proxy;

		// Token: 0x04000031 RID: 49
		private int _framesReceived;

		// Token: 0x04000032 RID: 50
		private long _bytesReceived;

		// Token: 0x04000033 RID: 51
		private bool _useSeparateConnectionGroup = true;

		// Token: 0x04000034 RID: 52
		private int _requestTimeout = 10000;

		// Token: 0x04000035 RID: 53
		private bool _forceBasicAuthentication;

		// Token: 0x04000036 RID: 54
		private Thread _thread;

		// Token: 0x04000037 RID: 55
		private ManualResetEvent _stopEvent;

		// Token: 0x04000038 RID: 56
		private ManualResetEvent _reloadEvent;

		// Token: 0x04000039 RID: 57
		private string _userAgent = "Mozilla/5.0";

		// Token: 0x0400003A RID: 58
		private static readonly byte[] JPEG_HEADER_BYTES = new byte[]
		{
			byte.MaxValue,
			216,
			byte.MaxValue
		};
	}
}
