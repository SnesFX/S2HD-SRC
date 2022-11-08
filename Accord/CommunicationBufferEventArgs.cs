using System;

namespace Accord
{
	// Token: 0x02000009 RID: 9
	public class CommunicationBufferEventArgs : EventArgs
	{
		// Token: 0x17000009 RID: 9
		// (get) Token: 0x0600004E RID: 78 RVA: 0x00002779 File Offset: 0x00001779
		public int MessageLength
		{
			get
			{
				return this.length;
			}
		}

		// Token: 0x0600004F RID: 79 RVA: 0x00002781 File Offset: 0x00001781
		public CommunicationBufferEventArgs(byte[] message)
		{
			this.message = message;
			this.index = 0;
			this.length = message.Length;
		}

		// Token: 0x06000050 RID: 80 RVA: 0x000027A0 File Offset: 0x000017A0
		public CommunicationBufferEventArgs(byte[] buffer, int index, int length)
		{
			this.message = buffer;
			this.index = index;
			this.length = length;
		}

		// Token: 0x06000051 RID: 81 RVA: 0x000027C0 File Offset: 0x000017C0
		public byte[] GetMessage()
		{
			byte[] array = new byte[this.length];
			Array.Copy(this.message, this.index, array, 0, this.length);
			return array;
		}

		// Token: 0x06000052 RID: 82 RVA: 0x000027F3 File Offset: 0x000017F3
		public string GetMessageString()
		{
			return BitConverter.ToString(this.message, this.index, this.length);
		}

		// Token: 0x04000009 RID: 9
		private readonly byte[] message;

		// Token: 0x0400000A RID: 10
		private readonly int index;

		// Token: 0x0400000B RID: 11
		private readonly int length;
	}
}
