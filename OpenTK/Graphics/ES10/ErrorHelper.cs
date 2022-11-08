using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace OpenTK.Graphics.ES10
{
	// Token: 0x020004FA RID: 1274
	internal struct ErrorHelper : IDisposable
	{
		// Token: 0x060031AC RID: 12716 RVA: 0x00084164 File Offset: 0x00082364
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

		// Token: 0x060031AD RID: 12717 RVA: 0x000841D4 File Offset: 0x000823D4
		[Conditional("DEBUG")]
		internal void ResetErrors()
		{
			if (this.Context.ErrorChecking)
			{
				while (GL.GetError() != All.False)
				{
				}
			}
		}

		// Token: 0x060031AE RID: 12718 RVA: 0x000841EC File Offset: 0x000823EC
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
					error = (ErrorCode)GL.GetError();
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

		// Token: 0x060031AF RID: 12719 RVA: 0x000842B8 File Offset: 0x000824B8
		public void Dispose()
		{
		}

		// Token: 0x04004CE0 RID: 19680
		private static readonly object SyncRoot = new object();

		// Token: 0x04004CE1 RID: 19681
		private static readonly Dictionary<GraphicsContext, List<ErrorCode>> ContextErrors = new Dictionary<GraphicsContext, List<ErrorCode>>();

		// Token: 0x04004CE2 RID: 19682
		private readonly GraphicsContext Context;
	}
}
