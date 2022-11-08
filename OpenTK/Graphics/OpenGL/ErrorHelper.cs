using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace OpenTK.Graphics.OpenGL
{
	// Token: 0x020004D0 RID: 1232
	internal struct ErrorHelper : IDisposable
	{
		// Token: 0x06003088 RID: 12424 RVA: 0x00082A3C File Offset: 0x00080C3C
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

		// Token: 0x06003089 RID: 12425 RVA: 0x00082AAC File Offset: 0x00080CAC
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

		// Token: 0x0600308A RID: 12426 RVA: 0x00082AC4 File Offset: 0x00080CC4
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

		// Token: 0x0600308B RID: 12427 RVA: 0x00082B90 File Offset: 0x00080D90
		public void Dispose()
		{
		}

		// Token: 0x04004AD9 RID: 19161
		private static readonly object SyncRoot = new object();

		// Token: 0x04004ADA RID: 19162
		private static readonly Dictionary<GraphicsContext, List<ErrorCode>> ContextErrors = new Dictionary<GraphicsContext, List<ErrorCode>>();

		// Token: 0x04004ADB RID: 19163
		private readonly GraphicsContext Context;
	}
}
