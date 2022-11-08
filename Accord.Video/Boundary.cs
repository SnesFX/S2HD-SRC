using System;
using System.Net;
using System.Text;

namespace Accord.Video
{
	// Token: 0x02000005 RID: 5
	public class Boundary
	{
		// Token: 0x0600001D RID: 29 RVA: 0x00002551 File Offset: 0x00001551
		public Boundary()
		{
			this._builder = new StringBuilder();
		}

		// Token: 0x0600001E RID: 30 RVA: 0x00002564 File Offset: 0x00001564
		public Boundary(string boundary)
		{
			this._builder = new StringBuilder(boundary);
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x0600001F RID: 31 RVA: 0x00002578 File Offset: 0x00001578
		public string Content
		{
			get
			{
				return this._builder.ToString();
			}
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000020 RID: 32 RVA: 0x00002585 File Offset: 0x00001585
		public int Length
		{
			get
			{
				return this._builder.Length;
			}
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000021 RID: 33 RVA: 0x00002592 File Offset: 0x00001592
		public bool HasValue
		{
			get
			{
				return this.Length != 0;
			}
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000022 RID: 34 RVA: 0x0000259D File Offset: 0x0000159D
		// (set) Token: 0x06000023 RID: 35 RVA: 0x000025A5 File Offset: 0x000015A5
		public bool IsChecked
		{
			get
			{
				return this._isChecked;
			}
			set
			{
				this._isChecked = value;
			}
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000024 RID: 36 RVA: 0x000025AE File Offset: 0x000015AE
		public bool IsValid
		{
			get
			{
				return (this.IsChecked && this.HasValue) || !this.HasValue;
			}
		}

		// Token: 0x06000025 RID: 37 RVA: 0x000025CB File Offset: 0x000015CB
		public void Prepend(char c)
		{
			this._builder.Insert(0, c);
		}

		// Token: 0x06000026 RID: 38 RVA: 0x000025DC File Offset: 0x000015DC
		public void FixMalformedBoundary(MJPEGStreamParser streamParser)
		{
			byte[] content = streamParser.Content;
			int num = streamParser.FindImageBoundary();
			if (num != -1)
			{
				for (int i = num - 1; i >= 0; i--)
				{
					char c = (char)content[i];
					if (c == '\n' || c == '\r')
					{
						break;
					}
					this.Prepend(c);
				}
				this.IsChecked = true;
			}
		}

		// Token: 0x06000027 RID: 39 RVA: 0x00002628 File Offset: 0x00001628
		public static Boundary FromResponse(WebResponse response)
		{
			string contentType = response.ContentType;
			Boundary boundary = new Boundary();
			if (Boundary.IsMultipartContent(contentType))
			{
				int boundaryIndex = Boundary.GetBoundaryIndex(contentType);
				if (boundaryIndex != -1)
				{
					boundary = Boundary.TrimBoundary(contentType, boundaryIndex);
					boundary.IsChecked = false;
				}
			}
			else if (!Boundary.IsOctetStream(contentType))
			{
				throw new Exception("Invalid content type.");
			}
			return boundary;
		}

		// Token: 0x06000028 RID: 40 RVA: 0x0000267C File Offset: 0x0000167C
		private static int GetBoundaryIndex(string contentType)
		{
			int num = contentType.IndexOf("boundary", 0);
			if (num != -1)
			{
				num = contentType.IndexOf("=", num + 8);
			}
			return num;
		}

		// Token: 0x06000029 RID: 41 RVA: 0x000026AC File Offset: 0x000016AC
		private static Boundary TrimBoundary(string contentType, int boundaryIndex)
		{
			string text = contentType.Substring(boundaryIndex + 1);
			string boundary = text.Trim(new char[]
			{
				' ',
				'"'
			});
			return new Boundary(boundary);
		}

		// Token: 0x0600002A RID: 42 RVA: 0x000026E0 File Offset: 0x000016E0
		private static bool IsMultipartContent(string contentType)
		{
			return contentType.StartsWith("multipart") && contentType.Contains("mixed");
		}

		// Token: 0x0600002B RID: 43 RVA: 0x000026FC File Offset: 0x000016FC
		private static bool IsOctetStream(string contentType)
		{
			return contentType.StartsWith("application/octet-stream");
		}

		// Token: 0x0600002C RID: 44 RVA: 0x0000270C File Offset: 0x0000170C
		public static explicit operator string(Boundary boundary)
		{
			string result = null;
			if (boundary != null)
			{
				result = boundary.Content;
			}
			return result;
		}

		// Token: 0x0600002D RID: 45 RVA: 0x00002728 File Offset: 0x00001728
		public static explicit operator byte[](Boundary boundary)
		{
			byte[] result = null;
			if (boundary != null)
			{
				result = Boundary._encoding.GetBytes(boundary.Content);
			}
			return result;
		}

		// Token: 0x04000009 RID: 9
		private static readonly Encoding _encoding = Encoding.ASCII;

		// Token: 0x0400000A RID: 10
		private readonly StringBuilder _builder;

		// Token: 0x0400000B RID: 11
		private bool _isChecked;
	}
}
