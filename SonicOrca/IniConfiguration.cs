using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using SonicOrca.Extensions;

namespace SonicOrca
{
	// Token: 0x02000098 RID: 152
	public class IniConfiguration
	{
		// Token: 0x0600051C RID: 1308 RVA: 0x000196A7 File Offset: 0x000178A7
		public IniConfiguration()
		{
			this._sections[string.Empty] = new IniConfiguration.Section();
		}

		// Token: 0x0600051D RID: 1309 RVA: 0x000196DC File Offset: 0x000178DC
		public IniConfiguration(string path) : this()
		{
			this._path = path;
			using (StreamReader streamReader = new StreamReader(new FileStream(path, FileMode.Open, FileAccess.Read)))
			{
				string item;
				while ((item = streamReader.ReadLine()) != null)
				{
					this._lines.Add(item);
				}
			}
			this.Parse();
		}

		// Token: 0x0600051E RID: 1310 RVA: 0x00019740 File Offset: 0x00017940
		public void Save()
		{
			this.Save(this._path);
		}

		// Token: 0x0600051F RID: 1311 RVA: 0x00019750 File Offset: 0x00017950
		public void Save(string path)
		{
			using (StreamWriter streamWriter = new StreamWriter(new FileStream(path, FileMode.Create, FileAccess.Write)))
			{
				foreach (string value in this._lines)
				{
					streamWriter.WriteLine(value);
				}
			}
		}

		// Token: 0x170000B1 RID: 177
		public string this[string sectionName, string propertyName]
		{
			get
			{
				return this.GetProperty(sectionName, propertyName, null);
			}
			set
			{
				this.SetProperty(sectionName, propertyName, value);
			}
		}

		// Token: 0x06000522 RID: 1314 RVA: 0x000197DE File Offset: 0x000179DE
		public bool PropertyExists(string sectionName, string propertyName)
		{
			return this._sections.ContainsKey(sectionName) && this._sections[sectionName].Properties.ContainsKey(propertyName);
		}

		// Token: 0x06000523 RID: 1315 RVA: 0x0001980C File Offset: 0x00017A0C
		public string GetProperty(string sectionName, string propertyName, string defaultValue = null)
		{
			if (!this._sections.ContainsKey(sectionName))
			{
				return defaultValue;
			}
			IDictionary<string, IniConfiguration.Property> properties = this._sections[sectionName].Properties;
			if (!properties.ContainsKey(propertyName))
			{
				return defaultValue;
			}
			return properties[propertyName].Value;
		}

		// Token: 0x06000524 RID: 1316 RVA: 0x00019854 File Offset: 0x00017A54
		public bool GetPropertyBoolean(string sectionName, string propertyName, bool defaultValue = false)
		{
			string property = this.GetProperty(sectionName, propertyName, null);
			if (property == null)
			{
				return defaultValue;
			}
			bool result;
			if (!bool.TryParse(property, out result))
			{
				return defaultValue;
			}
			return result;
		}

		// Token: 0x06000525 RID: 1317 RVA: 0x00019880 File Offset: 0x00017A80
		public double GetPropertyDouble(string sectionName, string propertyName, double defaultValue = 0.0)
		{
			if (!this._sections.ContainsKey(sectionName))
			{
				return defaultValue;
			}
			IDictionary<string, IniConfiguration.Property> properties = this._sections[sectionName].Properties;
			if (!properties.ContainsKey(propertyName))
			{
				return defaultValue;
			}
			double result;
			if (!double.TryParse(properties[propertyName].Value, NumberStyles.Any, CultureInfo.InvariantCulture, out result))
			{
				return defaultValue;
			}
			return result;
		}

		// Token: 0x06000526 RID: 1318 RVA: 0x000198DC File Offset: 0x00017ADC
		public void SetProperty(string sectionName, string propertyName, string value)
		{
			IniConfiguration.Section orAddSection = this.GetOrAddSection(sectionName);
			IniConfiguration.Property property;
			if (orAddSection.Properties.ContainsKey(propertyName))
			{
				property = orAddSection.Properties[propertyName];
				property.Value = value;
				int index = property.Lines.Last<int>();
				this._lines[index] = this.GetPropertySetValueLine(propertyName, value);
				return;
			}
			property = (orAddSection.Properties[propertyName] = new IniConfiguration.Property(propertyName));
			property.Value = value;
			if (orAddSection.Lines.Count > 0)
			{
				int num = orAddSection.Lines.Last<int>() + 1;
				this._lines.Insert(num, this.GetPropertySetValueLine(propertyName, value));
				property.Lines.Add(num);
				return;
			}
			if (this._lines.Count > 0 && !string.IsNullOrWhiteSpace(this._lines.Last<string>()))
			{
				this._lines.Add(string.Empty);
			}
			this._lines.Add(this.GetPropertySetValueLine(propertyName, value));
			property.Lines.Add(this._lines.Count - 1);
		}

		// Token: 0x06000527 RID: 1319 RVA: 0x000199E7 File Offset: 0x00017BE7
		private string GetPropertySetValueLine(string propertyName, string value)
		{
			return propertyName + " = " + value;
		}

		// Token: 0x06000528 RID: 1320 RVA: 0x000199F8 File Offset: 0x00017BF8
		private void InsertLine(int index, string line)
		{
			foreach (IniConfiguration.Section section in this._sections.Values)
			{
				foreach (IniConfiguration.Property property in section.Properties.Values)
				{
					for (int i = 0; i < property.Lines.Count; i++)
					{
						if (property.Lines[i] <= index)
						{
							IList<int> lines = property.Lines;
							int index2 = i;
							int num = lines[index2];
							lines[index2] = num + 1;
						}
					}
				}
			}
			this._lines.Insert(index, line);
		}

		// Token: 0x06000529 RID: 1321 RVA: 0x00019AD4 File Offset: 0x00017CD4
		private IniConfiguration.Section GetOrAddSection(string sectionName)
		{
			if (this._sections.ContainsKey(sectionName))
			{
				return this._sections[sectionName];
			}
			IniConfiguration.Section section = new IniConfiguration.Section(sectionName);
			if (this._lines.Count > 0 && !string.IsNullOrWhiteSpace(this._lines.Last<string>()))
			{
				this._lines.Add(string.Empty);
			}
			this._lines.Add("[" + sectionName + "]");
			section.Lines.Add(this._lines.Count - 1);
			return this._sections[sectionName] = section;
		}

		// Token: 0x0600052A RID: 1322 RVA: 0x00019B78 File Offset: 0x00017D78
		private IniConfiguration.Property GetOrAddProperty(string sectionName, string propertyName)
		{
			IDictionary<string, IniConfiguration.Property> properties = this._sections[sectionName].Properties;
			if (!properties.ContainsKey(propertyName))
			{
				return properties[propertyName] = new IniConfiguration.Property(propertyName);
			}
			return properties[propertyName];
		}

		// Token: 0x0600052B RID: 1323 RVA: 0x00019BB8 File Offset: 0x00017DB8
		private void Parse()
		{
			string empty = string.Empty;
			for (int i = 0; i < this._lines.Count; i++)
			{
				try
				{
					this.Parse(i, this._lines[i], ref empty);
				}
				catch
				{
				}
			}
		}

		// Token: 0x0600052C RID: 1324 RVA: 0x00019C0C File Offset: 0x00017E0C
		private void Parse(int lineIndex, string line, ref string currentSectionName)
		{
			StringReader reader = new StringReader(line);
			reader.SkipWhitespace();
			char c;
			if (!reader.TryRead(out c))
			{
				return;
			}
			if (c != '[')
			{
				if (c != ';' && c != '#')
				{
					StringBuilder stringBuilder = new StringBuilder();
					stringBuilder.Append(c);
					while (reader.TryRead(out c) && c != '=' && c != ':')
					{
						stringBuilder.Append(c);
					}
					if (c != '=' && c != ':')
					{
						throw new Exception("Expected = or : after property name");
					}
					string propertyName = stringBuilder.ToString().Trim();
					string value = this.ReadPropertyValue(reader);
					IniConfiguration.Property orAddProperty = this.GetOrAddProperty(currentSectionName, propertyName);
					orAddProperty.Value = value;
					orAddProperty.Lines.Add(lineIndex);
				}
				return;
			}
			StringBuilder stringBuilder2 = new StringBuilder();
			while (reader.TryRead(out c) && c != ']')
			{
				stringBuilder2.Append(c);
			}
			if (c != ']')
			{
				throw new Exception("Invalid section name");
			}
			currentSectionName = stringBuilder2.ToString().Trim();
			IniConfiguration.Section section;
			if (!this._sections.TryGetValue(currentSectionName, out section))
			{
				section = new IniConfiguration.Section(currentSectionName);
				this._sections.Add(currentSectionName, section);
			}
			section.Lines.Add(lineIndex);
		}

		// Token: 0x0600052D RID: 1325 RVA: 0x00019D28 File Offset: 0x00017F28
		private string ReadPropertyValue(TextReader reader)
		{
			reader.SkipWhitespace();
			StringBuilder stringBuilder = new StringBuilder();
			bool flag = false;
			bool flag2 = false;
			bool flag3 = false;
			char c;
			if (!reader.TryRead(out c))
			{
				return null;
			}
			if (c == '\'')
			{
				flag3 = (flag = true);
			}
			else if (c == '"')
			{
				flag3 = (flag2 = true);
			}
			else
			{
				stringBuilder.Append(c);
			}
			while (reader.TryRead(out c))
			{
				if (c == '\\')
				{
					stringBuilder.Append(this.ReadEscapedCharacter(reader));
				}
				else
				{
					if ((c == ';' || c == '#') && !flag3)
					{
						break;
					}
					if (c == '\'' && flag)
					{
						flag = false;
						break;
					}
					if (c == '"' && flag2)
					{
						flag2 = false;
						break;
					}
					stringBuilder.Append(c);
				}
			}
			if (flag || flag2)
			{
				throw new Exception("No end quote(s)");
			}
			if (!flag3)
			{
				return stringBuilder.ToString().TrimEnd(new char[0]);
			}
			return stringBuilder.ToString();
		}

		// Token: 0x0600052E RID: 1326 RVA: 0x00019DF8 File Offset: 0x00017FF8
		private char ReadEscapedCharacter(TextReader reader)
		{
			char c;
			if (!reader.TryRead(out c))
			{
				throw new Exception("Expected escape character");
			}
			if (c <= 'n')
			{
				if (c == '0')
				{
					return '\0';
				}
				if (c == 'n')
				{
					return '\n';
				}
			}
			else
			{
				if (c == 'r')
				{
					return '\r';
				}
				if (c == 't')
				{
					return '\t';
				}
				if (c == 'x')
				{
					char[] array = new char[4];
					if (reader.ReadBlock(array, 0, 4) != 4)
					{
						throw new Exception("Wrong format for escaped unicode character.");
					}
					return (char)int.Parse(new string(array), NumberStyles.AllowHexSpecifier);
				}
			}
			return c;
		}

		// Token: 0x04000327 RID: 807
		private readonly List<string> _lines = new List<string>();

		// Token: 0x04000328 RID: 808
		private readonly Dictionary<string, IniConfiguration.Section> _sections = new Dictionary<string, IniConfiguration.Section>();

		// Token: 0x04000329 RID: 809
		private string _path;

		// Token: 0x020001B7 RID: 439
		private class Section
		{
			// Token: 0x170004F5 RID: 1269
			// (get) Token: 0x0600127B RID: 4731 RVA: 0x00048199 File Offset: 0x00046399
			public IList<int> Lines
			{
				get
				{
					return this._lines;
				}
			}

			// Token: 0x170004F6 RID: 1270
			// (get) Token: 0x0600127C RID: 4732 RVA: 0x000481A1 File Offset: 0x000463A1
			public IDictionary<string, IniConfiguration.Property> Properties
			{
				get
				{
					return this._properties;
				}
			}

			// Token: 0x0600127D RID: 4733 RVA: 0x000481A9 File Offset: 0x000463A9
			public Section() : this(string.Empty)
			{
			}

			// Token: 0x0600127E RID: 4734 RVA: 0x000481B6 File Offset: 0x000463B6
			public Section(string name)
			{
				this._name = name;
			}

			// Token: 0x04000A5E RID: 2654
			private readonly string _name;

			// Token: 0x04000A5F RID: 2655
			private readonly List<int> _lines = new List<int>();

			// Token: 0x04000A60 RID: 2656
			private readonly Dictionary<string, IniConfiguration.Property> _properties = new Dictionary<string, IniConfiguration.Property>();
		}

		// Token: 0x020001B8 RID: 440
		private class Property
		{
			// Token: 0x170004F7 RID: 1271
			// (get) Token: 0x0600127F RID: 4735 RVA: 0x000481DB File Offset: 0x000463DB
			// (set) Token: 0x06001280 RID: 4736 RVA: 0x000481E3 File Offset: 0x000463E3
			public string Value { get; set; }

			// Token: 0x170004F8 RID: 1272
			// (get) Token: 0x06001281 RID: 4737 RVA: 0x000481EC File Offset: 0x000463EC
			public IList<int> Lines
			{
				get
				{
					return this._lines;
				}
			}

			// Token: 0x06001282 RID: 4738 RVA: 0x000481F4 File Offset: 0x000463F4
			public Property(string name)
			{
				this._name = name;
			}

			// Token: 0x04000A61 RID: 2657
			private readonly string _name;

			// Token: 0x04000A62 RID: 2658
			private readonly List<int> _lines = new List<int>();
		}
	}
}
