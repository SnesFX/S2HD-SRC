using System;
using System.Threading;

namespace OpenTK.Graphics
{
	// Token: 0x020001BD RID: 445
	public class GraphicsContextMissingException : GraphicsContextException
	{
		// Token: 0x06000C05 RID: 3077 RVA: 0x00027958 File Offset: 0x00025B58
		public GraphicsContextMissingException() : base(string.Format("No context is current in the calling thread (ThreadId: {0}).", Thread.CurrentThread.ManagedThreadId))
		{
		}
	}
}
