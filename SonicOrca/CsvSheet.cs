using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SonicOrca
{
	// Token: 0x02000092 RID: 146
	public class CsvSheet
	{
		// Token: 0x060004C8 RID: 1224 RVA: 0x00018C85 File Offset: 0x00016E85
		public CsvSheet()
		{
		}

		// Token: 0x060004C9 RID: 1225 RVA: 0x00018C98 File Offset: 0x00016E98
		public CsvSheet(string filename)
		{
			using (FileStream fileStream = new FileStream(filename, FileMode.Open))
			{
				this.Load(fileStream);
			}
		}

		// Token: 0x060004CA RID: 1226 RVA: 0x00018CE4 File Offset: 0x00016EE4
		public CsvSheet(Stream stream)
		{
			this.Load(stream);
		}

		// Token: 0x060004CB RID: 1227 RVA: 0x00018D00 File Offset: 0x00016F00
		private void Load(Stream stream)
		{
			this.mRows = new List<List<string>>();
			using (StreamReader streamReader = new StreamReader(stream))
			{
				string line;
				while ((line = streamReader.ReadLine()) != null)
				{
					this.mRows.Add(new List<string>(this.ProcessLine(line)));
				}
			}
			this.CalculateColumns();
		}

		// Token: 0x060004CC RID: 1228 RVA: 0x00018D64 File Offset: 0x00016F64
		public void Save(string filename)
		{
			using (FileStream fileStream = new FileStream(filename, FileMode.Create))
			{
				this.Save(fileStream);
			}
		}

		// Token: 0x060004CD RID: 1229 RVA: 0x00018D9C File Offset: 0x00016F9C
		public void Save(Stream stream)
		{
			using (StreamWriter streamWriter = new StreamWriter(stream))
			{
				foreach (List<string> list in this.mRows)
				{
					for (int i = 0; i < list.Count - 1; i++)
					{
						streamWriter.Write("{0},", this.FormatAsCSV(list[i]));
					}
					if (list.Count > 0)
					{
						streamWriter.Write(this.FormatAsCSV(list[list.Count - 1]));
					}
					streamWriter.WriteLine();
				}
			}
		}

		// Token: 0x060004CE RID: 1230 RVA: 0x00018E5C File Offset: 0x0001705C
		private string FormatAsCSV(string cell)
		{
			if (cell.Contains('"'))
			{
				cell = cell.Replace("\"", "\"\"");
			}
			if (cell.Contains(",") || cell.StartsWith("\"") || cell.EndsWith("\""))
			{
				cell = string.Format("\"{0}\"", cell);
			}
			return cell;
		}

		// Token: 0x060004CF RID: 1231 RVA: 0x00018EBC File Offset: 0x000170BC
		private string Get(int x, int y)
		{
			if (x < 0 || y < 0)
			{
				throw new ArgumentOutOfRangeException();
			}
			if (y >= this.mRows.Count)
			{
				return string.Empty;
			}
			List<string> list = this.mRows[y];
			if (x >= list.Count)
			{
				return string.Empty;
			}
			return list[x];
		}

		// Token: 0x060004D0 RID: 1232 RVA: 0x00018F10 File Offset: 0x00017110
		private void Set(int x, int y, string value)
		{
			if (x < 0 || y < 0)
			{
				throw new ArgumentOutOfRangeException();
			}
			while (y >= this.mRows.Count)
			{
				this.mRows.Add(new List<string>());
			}
			List<string> list = this.mRows[y];
			while (x >= list.Count)
			{
				list.Add(string.Empty);
			}
			list[x] = value;
			this.CalculateColumns();
		}

		// Token: 0x060004D1 RID: 1233 RVA: 0x00018F7A File Offset: 0x0001717A
		private void CalculateColumns()
		{
			this.mColumns = this.mRows.Max((List<string> row) => row.Count);
		}

		// Token: 0x060004D2 RID: 1234 RVA: 0x00018FAC File Offset: 0x000171AC
		private string[] ProcessLine(string line)
		{
			List<string> list = new List<string>();
			using (StringReader stringReader = new StringReader(line))
			{
				string nextCell;
				while ((nextCell = this.GetNextCell(stringReader)) != null)
				{
					list.Add(nextCell);
				}
			}
			return list.ToArray();
		}

		// Token: 0x060004D3 RID: 1235 RVA: 0x00018FFC File Offset: 0x000171FC
		private string GetNextCell(StringReader sr)
		{
			if (sr.Peek() == -1)
			{
				return null;
			}
			int num = 0;
			bool flag = false;
			StringBuilder stringBuilder = new StringBuilder();
			while (sr.Peek() != -1)
			{
				char c = (char)sr.Read();
				if (!char.IsWhiteSpace(c) || flag || !string.IsNullOrEmpty(stringBuilder.ToString()))
				{
					if (c == ',' && !flag)
					{
						break;
					}
					if (c == ' ' && !flag)
					{
						num++;
					}
					else
					{
						stringBuilder.Append(new string(' ', num));
						num = 0;
						if (c == '"' && (ushort)sr.Peek() == 34)
						{
							sr.Read();
							stringBuilder.Append('"');
						}
						else if (c == '"')
						{
							flag = !flag;
						}
						else
						{
							stringBuilder.Append(c);
						}
					}
				}
			}
			return stringBuilder.ToString();
		}

		// Token: 0x1700008A RID: 138
		public string this[int x, int y]
		{
			get
			{
				return this.Get(x, y);
			}
			set
			{
				this.Set(x, y, value);
			}
		}

		// Token: 0x1700008B RID: 139
		// (get) Token: 0x060004D6 RID: 1238 RVA: 0x000190C4 File Offset: 0x000172C4
		public int Rows
		{
			get
			{
				return this.mRows.Count;
			}
		}

		// Token: 0x1700008C RID: 140
		// (get) Token: 0x060004D7 RID: 1239 RVA: 0x000190D1 File Offset: 0x000172D1
		public int Columns
		{
			get
			{
				return this.mColumns;
			}
		}

		// Token: 0x04000306 RID: 774
		private List<List<string>> mRows = new List<List<string>>();

		// Token: 0x04000307 RID: 775
		private int mColumns;
	}
}
