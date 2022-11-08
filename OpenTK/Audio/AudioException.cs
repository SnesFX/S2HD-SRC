using System;

namespace OpenTK.Audio
{
	// Token: 0x0200053E RID: 1342
	public class AudioException : Exception
	{
		// Token: 0x060043EC RID: 17388 RVA: 0x000B87A4 File Offset: 0x000B69A4
		public AudioException()
		{
		}

		// Token: 0x060043ED RID: 17389 RVA: 0x000B87AC File Offset: 0x000B69AC
		public AudioException(string message) : base(message)
		{
		}
	}
}
