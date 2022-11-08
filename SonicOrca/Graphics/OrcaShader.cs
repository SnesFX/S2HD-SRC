using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SonicOrca.Graphics
{
	// Token: 0x020000C8 RID: 200
	public static class OrcaShader
	{
		// Token: 0x060006CB RID: 1739 RVA: 0x0001D1B4 File Offset: 0x0001B3B4
		public static ManagedShaderProgram CreateFromFile(IGraphicsContext context, string path)
		{
			string vertexSourceCode;
			string fragmentSourceCode;
			OrcaShader.Parse(OrcaShader.ParseShaderFileWithIncludes(path), out vertexSourceCode, out fragmentSourceCode);
			return new ManagedShaderProgram(context, vertexSourceCode, fragmentSourceCode);
		}

		// Token: 0x060006CC RID: 1740 RVA: 0x0001D1D8 File Offset: 0x0001B3D8
		public static ManagedShaderProgram Create(IGraphicsContext context, string input)
		{
			string vertexSourceCode;
			string fragmentSourceCode;
			OrcaShader.Parse(input, out vertexSourceCode, out fragmentSourceCode);
			return new ManagedShaderProgram(context, vertexSourceCode, fragmentSourceCode);
		}

		// Token: 0x060006CD RID: 1741 RVA: 0x0001D1F8 File Offset: 0x0001B3F8
		private static string ParseShaderFileWithIncludes(string path)
		{
			if (!File.Exists(path))
			{
				path = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), path);
			}
			StringBuilder stringBuilder = new StringBuilder();
			StreamReader streamReader = new StreamReader(path);
			string text;
			while ((text = streamReader.ReadLine()) != null)
			{
				string text2 = text.TrimStart(new char[0]);
				if (text2.StartsWith("@include"))
				{
					text2 = text2.Substring(8);
					if (text2.Length > 0 && char.IsWhiteSpace(text2[0]))
					{
						text2 = text2.Trim();
						if (!text2.StartsWith("\"") || !text2.EndsWith("\""))
						{
							throw new InvalidDataException("include syntax error");
						}
						text2 = text2.Substring(1, text2.Length - 2);
						text2 = Path.Combine(Path.GetDirectoryName(path), text2);
						if (!File.Exists(text2))
						{
							throw new FileNotFoundException(text2 + " not found.", text2);
						}
						stringBuilder.AppendLine(OrcaShader.ParseShaderFileWithIncludes(text2));
						continue;
					}
				}
				stringBuilder.AppendLine(text);
			}
			return stringBuilder.ToString();
		}

		// Token: 0x060006CE RID: 1742 RVA: 0x0001D304 File Offset: 0x0001B504
		public static void Parse(string input, out string vertexOuput, out string fragmentOutput)
		{
			IDictionary<string, string> blocks = OrcaShader.GetBlocks(input).ToDictionary((KeyValuePair<string, string> x) => x.Key, (KeyValuePair<string, string> x) => x.Value);
			vertexOuput = OrcaShader.ConcatenateBlocks(blocks, new string[]
			{
				string.Empty,
				"uniform",
				"vertex_input",
				"vertex_output",
				"vertex"
			});
			fragmentOutput = OrcaShader.ConcatenateBlocks(blocks, new string[]
			{
				string.Empty,
				"uniform",
				"fragment_input",
				"fragment_output",
				"fragment"
			});
		}

		// Token: 0x060006CF RID: 1743 RVA: 0x0001D3C8 File Offset: 0x0001B5C8
		private static string ConcatenateBlocks(IDictionary<string, string> blocks, IEnumerable<string> blockNames)
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (string text in blockNames)
			{
				string value;
				if (blocks.TryGetValue(text, out value))
				{
					if (!string.IsNullOrEmpty(text))
					{
						stringBuilder.AppendLine("//" + text + ":");
					}
					stringBuilder.Append(value);
				}
			}
			return stringBuilder.ToString();
		}

		// Token: 0x060006D0 RID: 1744 RVA: 0x0001D448 File Offset: 0x0001B648
		private static IReadOnlyCollection<KeyValuePair<string, string>> GetBlocks(string input)
		{
			string key = string.Empty;
			StringBuilder stringBuilder = new StringBuilder();
			List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();
			StringReader stringReader = new StringReader(input);
			string text;
			while ((text = stringReader.ReadLine()) != null)
			{
				if (text.TrimStart(new char[0]).StartsWith("@"))
				{
					string text2 = text.Substring(text.IndexOf("@") + 1);
					int num = text2.IndexOf(":");
					if (num != -1)
					{
						list.Add(new KeyValuePair<string, string>(key, stringBuilder.ToString()));
						key = text2.Remove(num);
						stringBuilder.Clear();
						continue;
					}
				}
				stringBuilder.AppendLine(text);
			}
			list.Add(new KeyValuePair<string, string>(key, stringBuilder.ToString()));
			return list.ToArray();
		}
	}
}
