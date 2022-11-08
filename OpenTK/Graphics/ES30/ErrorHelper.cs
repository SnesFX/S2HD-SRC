using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace OpenTK.Graphics.ES30
{
	// Token: 0x020005E7 RID: 1511
	internal struct ErrorHelper : IDisposable
	{
		// Token: 0x06004705 RID: 18181 RVA: 0x000C3CE4 File Offset: 0x000C1EE4
		public ErrorHelper(IGraphicsContext context)
		{
			if (context == null)
			{
				throw new GraphicsContextMissingException();
			}
			this.Context = (GraphicsContext)context;
			lock (ErrorHelper.SyncRoot)
			{
				if (!ErrorHelper.ContextErrors.ContainsKey(this.Context))
				{
					ErrorHelper.ContextErrors.Add(this.Context, new List<ErrorCode>());
				}
			}
		}

		// Token: 0x06004706 RID: 18182 RVA: 0x000C3D54 File Offset: 0x000C1F54
		[Conditional("DEBUG")]
		internal void ResetErrors()
		{
			if (this.Context.ErrorChecking)
			{
				while (GL.GetError() != ErrorCode.NoError)
				{
				}
			}
		}

		// Token: 0x06004707 RID: 18183 RVA: 0x000C3D6C File Offset: 0x000C1F6C
		[Conditional("DEBUG")]
		internal void CheckErrors()
		{
			if (this.Context.ErrorChecking)
			{
				List<ErrorCode> list = ErrorHelper.ContextErrors[this.Context];
				list.Clear();
				ErrorCode error;
				do
				{
					error = GL.GetError();
					list.Add(error);
				}
				while (error != ErrorCode.NoError);
				if (list.Count != 1)
				{
					StringBuilder stringBuilder = new StringBuilder();
					foreach (ErrorCode errorCode in list)
					{
						if (errorCode == ErrorCode.NoError)
						{
							break;
						}
						stringBuilder.Append(errorCode.ToString());
						stringBuilder.Append(", ");
					}
					stringBuilder.Remove(stringBuilder.Length - 2, 2);
					throw new GraphicsErrorException(stringBuilder.ToString());
				}
			}
		}

		// Token: 0x06004708 RID: 18184 RVA: 0x000C3E38 File Offset: 0x000C2038
		public void Dispose()
		{
		}

		// Token: 0x040055A5 RID: 21925
		private static readonly object SyncRoot = new object();

		// Token: 0x040055A6 RID: 21926
		private static readonly Dictionary<GraphicsContext, List<ErrorCode>> ContextErrors = new Dictionary<GraphicsContext, List<ErrorCode>>();

		// Token: 0x040055A7 RID: 21927
		private readonly GraphicsContext Context;
	}
}
