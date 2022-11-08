using System;
using System.Threading.Tasks;

namespace SonicOrca.Extensions
{
	// Token: 0x0200000E RID: 14
	public static class TaskExtensions
	{
		// Token: 0x06000029 RID: 41 RVA: 0x000026F6 File Offset: 0x000008F6
		public static void RunSync(this Task task)
		{
			task.Wait();
		}

		// Token: 0x0600002A RID: 42 RVA: 0x000026FE File Offset: 0x000008FE
		public static T RunSync<T>(this Task<T> task)
		{
			task.Wait();
			return task.Result;
		}
	}
}
