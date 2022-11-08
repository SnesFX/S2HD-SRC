using System;
using System.Collections.Generic;
using SonicOrca.Extensions;

namespace S2HD
{
	// Token: 0x02000099 RID: 153
	internal class CommandLineArguments
	{
		// Token: 0x06000361 RID: 865 RVA: 0x00018D6E File Offset: 0x00016F6E
		public CommandLineArguments(IEnumerable<string> args) : this(args.AsArray<string>())
		{
		}

		// Token: 0x06000362 RID: 866 RVA: 0x00018D7C File Offset: 0x00016F7C
		public CommandLineArguments(string[] args)
		{
			List<string> list = new List<string>();
			this._commandLine = string.Join(" ", args);
			for (int i = 0; i < args.Length; i++)
			{
				string text = args[i];
				if (text.StartsWith("--"))
				{
					string key = text.Substring(2);
					list.Clear();
					for (i++; i < args.Length; i++)
					{
						text = args[i];
						if (text.StartsWith("-"))
						{
							i--;
							break;
						}
						list.Add(text);
					}
					this._options.Add(key, list.ToArray());
				}
				else if (text.StartsWith("-"))
				{
					foreach (char item in text.Substring(1))
					{
						this._flags.Add(item);
					}
				}
			}
		}

		// Token: 0x06000363 RID: 867 RVA: 0x00018E76 File Offset: 0x00017076
		public bool HasFlag(char c)
		{
			return this._flags.Contains(c);
		}

		// Token: 0x06000364 RID: 868 RVA: 0x00018E84 File Offset: 0x00017084
		public bool HasOption(string option)
		{
			return this._options.ContainsKey(option);
		}

		// Token: 0x06000365 RID: 869 RVA: 0x00018E94 File Offset: 0x00017094
		public string[] GetOptionValues(string option)
		{
			string[] result;
			if (!this._options.TryGetValue(option, out result))
			{
				result = new string[0];
			}
			return result;
		}

		// Token: 0x06000366 RID: 870 RVA: 0x00018EB9 File Offset: 0x000170B9
		public override string ToString()
		{
			return this._commandLine;
		}

		// Token: 0x04000419 RID: 1049
		private readonly HashSet<char> _flags = new HashSet<char>();

		// Token: 0x0400041A RID: 1050
		private readonly Dictionary<string, string[]> _options = new Dictionary<string, string[]>();

		// Token: 0x0400041B RID: 1051
		private readonly string _commandLine;
	}
}
