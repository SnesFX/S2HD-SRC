using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace SonicOrca.Extensions
{
	// Token: 0x0200000F RID: 15
	public static class TextReaderExtensions
	{
		// Token: 0x0600002B RID: 43 RVA: 0x0000270C File Offset: 0x0000090C
		public static bool TryPeek(this TextReader reader, out char c)
		{
			int num = reader.Peek();
			if (num == -1)
			{
				c = '\0';
				return false;
			}
			c = (char)num;
			return true;
		}

		// Token: 0x0600002C RID: 44 RVA: 0x00002730 File Offset: 0x00000930
		public static bool TryRead(this TextReader reader, out char c)
		{
			int num = reader.Read();
			if (num == -1)
			{
				c = '\0';
				return false;
			}
			c = (char)num;
			return true;
		}

		// Token: 0x0600002D RID: 45 RVA: 0x00002754 File Offset: 0x00000954
		public static string ReadToWhitespace(this TextReader reader)
		{
			StringBuilder stringBuilder = new StringBuilder();
			char c;
			while (reader.TryPeek(out c) && !char.IsWhiteSpace(c))
			{
				reader.Read();
				stringBuilder.Append(c);
			}
			return stringBuilder.ToString();
		}

		// Token: 0x0600002E RID: 46 RVA: 0x00002790 File Offset: 0x00000990
		public static void SkipWhitespace(this TextReader reader)
		{
			char c;
			while (reader.TryPeek(out c) && char.IsWhiteSpace(c))
			{
				reader.Read();
			}
		}

		// Token: 0x0600002F RID: 47 RVA: 0x000027B8 File Offset: 0x000009B8
		public static string ReadRegex(this TextReader reader, string regex)
		{
			return reader.ReadRegex(new Regex(regex));
		}

		// Token: 0x06000030 RID: 48 RVA: 0x000027C8 File Offset: 0x000009C8
		public static string ReadRegex(this TextReader reader, Regex regex)
		{
			StringBuilder stringBuilder = new StringBuilder();
			char value;
			while (reader.TryPeek(out value))
			{
				stringBuilder.Append(value);
				string text = stringBuilder.ToString();
				if (!regex.IsMatch(text))
				{
					return text.Remove(text.Length - 1);
				}
				reader.Read();
			}
			return stringBuilder.ToString();
		}

		// Token: 0x06000031 RID: 49 RVA: 0x0000281B File Offset: 0x00000A1B
		public static bool CanRead(this TextReader reader)
		{
			return reader.Peek() != -1;
		}
	}
}
