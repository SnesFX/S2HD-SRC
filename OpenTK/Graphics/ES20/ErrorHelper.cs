using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace OpenTK.Graphics.ES20
{
	// Token: 0x02000503 RID: 1283
	internal struct ErrorHelper : IDisposable
	{
		// Token: 0x060035EC RID: 13804 RVA: 0x0008DAB8 File Offset: 0x0008BCB8
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

		// Token: 0x060035ED RID: 13805 RVA: 0x0008DB28 File Offset: 0x0008BD28
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

		// Token: 0x060035EE RID: 13806 RVA: 0x0008DB40 File Offset: 0x0008BD40
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

		// Token: 0x060035EF RID: 13807 RVA: 0x0008DC0C File Offset: 0x0008BE0C
		public void Dispose()
		{
		}

		// Token: 0x04004CEB RID: 19691
		private static readonly object SyncRoot = new object();

		// Token: 0x04004CEC RID: 19692
		private static readonly Dictionary<GraphicsContext, List<ErrorCode>> ContextErrors = new Dictionary<GraphicsContext, List<ErrorCode>>();

		// Token: 0x04004CED RID: 19693
		private readonly GraphicsContext Context;
	}
}
