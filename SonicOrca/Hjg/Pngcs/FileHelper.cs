using System;
using System.IO;

namespace Hjg.Pngcs
{
	// Token: 0x0200001E RID: 30
	public class FileHelper
	{
		// Token: 0x060000A6 RID: 166 RVA: 0x00004175 File Offset: 0x00002375
		public static Stream OpenFileForReading(string file)
		{
			if (file == null || !File.Exists(file))
			{
				throw new PngjInputException("Cannot open file for reading (" + file + ")");
			}
			return new FileStream(file, FileMode.Open);
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x0000419F File Offset: 0x0000239F
		public static Stream OpenFileForWriting(string file, bool allowOverwrite)
		{
			if (File.Exists(file) && !allowOverwrite)
			{
				throw new PngjOutputException("File already exists (" + file + ") and overwrite=false");
			}
			return new FileStream(file, FileMode.Create);
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x000041C9 File Offset: 0x000023C9
		public static PngWriter CreatePngWriter(string fileName, ImageInfo imgInfo, bool allowOverwrite)
		{
			return new PngWriter(FileHelper.OpenFileForWriting(fileName, allowOverwrite), imgInfo, fileName);
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x000041D9 File Offset: 0x000023D9
		public static PngReader CreatePngReader(string fileName)
		{
			return new PngReader(FileHelper.OpenFileForReading(fileName), fileName);
		}
	}
}
