using System;
using System.Runtime.Serialization;

namespace Accord
{
	// Token: 0x02000005 RID: 5
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
	public sealed class SerializationBinderAttribute : Attribute
	{
		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000020 RID: 32 RVA: 0x0000229D File Offset: 0x0000129D
		// (set) Token: 0x06000021 RID: 33 RVA: 0x000022A5 File Offset: 0x000012A5
		public SerializationBinder Binder { get; private set; }

		// Token: 0x06000022 RID: 34 RVA: 0x000022AE File Offset: 0x000012AE
		public SerializationBinderAttribute(Type binderType)
		{
			this.Binder = (SerializationBinder)Activator.CreateInstance(binderType);
		}
	}
}
