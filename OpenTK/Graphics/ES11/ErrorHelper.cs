using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace OpenTK.Graphics.ES11
{
	// Token: 0x020004FB RID: 1275
	internal struct ErrorHelper : IDisposable
	{
		// Token: 0x060031B1 RID: 12721 RVA: 0x000842D4 File Offset: 0x000824D4
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

		// Token: 0x060031B2 RID: 12722 RVA: 0x00084344 File Offset: 0x00082544
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

		// Token: 0x060031B3 RID: 12723 RVA: 0x0008435C File Offset: 0x0008255C
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

		// Token: 0x060031B4 RID: 12724 RVA: 0x00084428 File Offset: 0x00082628
		public void Dispose()
		{
		}

		// Token: 0x04004CE3 RID: 19683
		private static readonly object SyncRoot = new object();

		// Token: 0x04004CE4 RID: 19684
		private static readonly Dictionary<GraphicsContext, List<ErrorCode>> ContextErrors = new Dictionary<GraphicsContext, List<ErrorCode>>();

		// Token: 0x04004CE5 RID: 19685
		private readonly GraphicsContext Context;
	}
}
