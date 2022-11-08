using System;
using System.IO;
using System.Text;

namespace SonicOrca.Extensions
{
	// Token: 0x02000008 RID: 8
	public static class BinaryReaderWriterExtensions
	{
		// Token: 0x0600000E RID: 14 RVA: 0x0000218C File Offset: 0x0000038C
		public static string ReadNullTerminatedString(this BinaryReader br)
		{
			StringBuilder stringBuilder = new StringBuilder();
			byte value;
			while ((value = br.ReadByte()) != 0)
			{
				stringBuilder.Append((char)value);
			}
			return stringBuilder.ToString();
		}

		// Token: 0x0600000F RID: 15 RVA: 0x000021B9 File Offset: 0x000003B9
		public static void WriteNullTerminatedString(this BinaryWriter bw, string s)
		{
			if (!string.IsNullOrEmpty(s))
			{
				bw.Write(Encoding.ASCII.GetBytes(s));
			}
			bw.Write(0);
		}
	}
}
