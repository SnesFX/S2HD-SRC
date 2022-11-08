using System;

namespace OpenTK
{
	// Token: 0x0200005C RID: 92
	public class ContextExistsException : ApplicationException
	{
		// Token: 0x0600068F RID: 1679 RVA: 0x000178E4 File Offset: 0x00015AE4
		public ContextExistsException(string message)
		{
			this.msg = message;
		}

		// Token: 0x17000158 RID: 344
		// (get) Token: 0x06000690 RID: 1680 RVA: 0x000178F4 File Offset: 0x00015AF4
		public override string Message
		{
			get
			{
				return this.msg;
			}
		}

		// Token: 0x040001C3 RID: 451
		private string msg;
	}
}
