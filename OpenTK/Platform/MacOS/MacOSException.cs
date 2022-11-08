using System;

namespace OpenTK.Platform.MacOS
{
	// Token: 0x02000078 RID: 120
	internal class MacOSException : Exception
	{
		// Token: 0x06000778 RID: 1912 RVA: 0x00018BC4 File Offset: 0x00016DC4
		public MacOSException()
		{
		}

		// Token: 0x06000779 RID: 1913 RVA: 0x00018BCC File Offset: 0x00016DCC
		public MacOSException(OSStatus errorCode)
		{
			string str = "Error Code ";
			int num = (int)errorCode;
			base..ctor(str + num.ToString() + ": " + errorCode.ToString());
			this.errorCode = errorCode;
		}

		// Token: 0x0600077A RID: 1914 RVA: 0x00018C0C File Offset: 0x00016E0C
		public MacOSException(OSStatus errorCode, string message) : base(message)
		{
			this.errorCode = errorCode;
		}

		// Token: 0x0600077B RID: 1915 RVA: 0x00018C1C File Offset: 0x00016E1C
		internal MacOSException(int errorCode, string message) : base(message)
		{
			this.errorCode = (OSStatus)errorCode;
		}

		// Token: 0x1700016F RID: 367
		// (get) Token: 0x0600077C RID: 1916 RVA: 0x00018C2C File Offset: 0x00016E2C
		public OSStatus ErrorCode
		{
			get
			{
				return this.errorCode;
			}
		}

		// Token: 0x04000265 RID: 613
		private OSStatus errorCode;
	}
}
