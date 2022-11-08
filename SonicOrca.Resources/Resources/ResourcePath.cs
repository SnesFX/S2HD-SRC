using System;
using System.IO;

namespace SonicOrca.Resources
{
	// Token: 0x0200000A RID: 10
	public static class ResourcePath
	{
		// Token: 0x06000037 RID: 55 RVA: 0x00002DD8 File Offset: 0x00000FD8
		public static string GetPathWithoutExtension(string path)
		{
			string directoryName = Path.GetDirectoryName(path);
			string fileName = Path.GetFileName(path);
			int num = fileName.IndexOf('.');
			if (num == -1)
			{
				return string.Empty;
			}
			return Path.Combine(directoryName, fileName.Substring(0, num));
		}

		// Token: 0x06000038 RID: 56 RVA: 0x00002E14 File Offset: 0x00001014
		public static string GetExtension(string path)
		{
			string fileName = Path.GetFileName(path);
			int num = fileName.IndexOf('.');
			if (num == -1)
			{
				return string.Empty;
			}
			return fileName.Substring(num);
		}

		// Token: 0x06000039 RID: 57 RVA: 0x00002E44 File Offset: 0x00001044
		internal static string GetRelativeFileResourceFromAbsolute(string parent, string relative)
		{
			if (parent.StartsWith("$"))
			{
				parent = parent.Substring(1);
			}
			if (relative.StartsWith("/"))
			{
				relative = relative.Substring(1);
			}
			string directoryName = Path.GetDirectoryName(parent);
			string searchPattern = ResourcePath.GetPathWithoutExtension(Path.GetFileName(parent)) + "_" + relative + ".*";
			string[] files = Directory.GetFiles(directoryName, searchPattern, SearchOption.TopDirectoryOnly);
			if (files.Length == 0)
			{
				throw new ResourceException(string.Format("There are one or more resources with the same key in {0}.", directoryName));
			}
			return "$" + files[0];
		}
	}
}
