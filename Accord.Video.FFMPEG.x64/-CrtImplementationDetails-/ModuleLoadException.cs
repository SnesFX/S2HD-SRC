using System;
using System.Runtime.Serialization;

namespace <CrtImplementationDetails>
{
	// Token: 0x02000292 RID: 658
	[Serializable]
	internal class ModuleLoadException : Exception
	{
		// Token: 0x0600011D RID: 285 RVA: 0x00005080 File Offset: 0x00004480
		protected ModuleLoadException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}

		// Token: 0x0600011E RID: 286 RVA: 0x00005068 File Offset: 0x00004468
		public ModuleLoadException(string message, Exception innerException) : base(message, innerException)
		{
		}

		// Token: 0x0600011F RID: 287 RVA: 0x00005054 File Offset: 0x00004454
		public ModuleLoadException(string message) : base(message)
		{
		}

		// Token: 0x0400034B RID: 843
		public const string Nested = "A nested exception occurred after the primary exception that caused the C++ module to fail to load.\n";
	}
}
