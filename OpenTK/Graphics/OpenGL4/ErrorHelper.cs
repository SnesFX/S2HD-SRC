using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace OpenTK.Graphics.OpenGL4
{
	// Token: 0x020005FB RID: 1531
	internal struct ErrorHelper : IDisposable
	{
		// Token: 0x06005909 RID: 22793 RVA: 0x000F2358 File Offset: 0x000F0558
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

		// Token: 0x0600590A RID: 22794 RVA: 0x000F23C8 File Offset: 0x000F05C8
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

		// Token: 0x0600590B RID: 22795 RVA: 0x000F23E0 File Offset: 0x000F05E0
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

		// Token: 0x0600590C RID: 22796 RVA: 0x000F24AC File Offset: 0x000F06AC
		public void Dispose()
		{
		}

		// Token: 0x040055B2 RID: 21938
		private static readonly object SyncRoot = new object();

		// Token: 0x040055B3 RID: 21939
		private static readonly Dictionary<GraphicsContext, List<ErrorCode>> ContextErrors = new Dictionary<GraphicsContext, List<ErrorCode>>();

		// Token: 0x040055B4 RID: 21940
		private readonly GraphicsContext Context;
	}
}
