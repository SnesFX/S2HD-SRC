using System;
using System.Collections.Generic;

namespace S2HD.Menu
{
	// Token: 0x020000C0 RID: 192
	internal class OnOffOptionSetting : ISpinnerSetting, ISetting
	{
		// Token: 0x170000A4 RID: 164
		// (get) Token: 0x0600048A RID: 1162 RVA: 0x0001E427 File Offset: 0x0001C627
		public string Name { get; }

		// Token: 0x170000A5 RID: 165
		// (get) Token: 0x0600048B RID: 1163 RVA: 0x0001E42F File Offset: 0x0001C62F
		public IReadOnlyList<string> Values
		{
			get
			{
				return OnOffOptionSetting.ValueStrings;
			}
		}

		// Token: 0x170000A6 RID: 166
		// (get) Token: 0x0600048C RID: 1164 RVA: 0x0001E436 File Offset: 0x0001C636
		// (set) Token: 0x0600048D RID: 1165 RVA: 0x0001E443 File Offset: 0x0001C643
		public int SelectedIndex
		{
			get
			{
				if (!this.Value)
				{
					return 0;
				}
				return 1;
			}
			set
			{
				this.Value = (value != 0);
			}
		}

		// Token: 0x170000A7 RID: 167
		// (get) Token: 0x0600048E RID: 1166 RVA: 0x0001E44F File Offset: 0x0001C64F
		// (set) Token: 0x0600048F RID: 1167 RVA: 0x0001E45C File Offset: 0x0001C65C
		public bool Value
		{
			get
			{
				return this._getter();
			}
			set
			{
				this._setter(value);
			}
		}

		// Token: 0x06000490 RID: 1168 RVA: 0x0001E46A File Offset: 0x0001C66A
		public OnOffOptionSetting(string name, Func<bool> getter, Action<bool> setter)
		{
			this.Name = name;
			this._getter = getter;
			this._setter = setter;
		}

		// Token: 0x06000491 RID: 1169 RVA: 0x0001E487 File Offset: 0x0001C687
		public override string ToString()
		{
			return string.Format("{0}: {1}", this.Name, this.Values[this.SelectedIndex]);
		}

		// Token: 0x04000528 RID: 1320
		private static readonly string[] ValueStrings = new string[]
		{
			"OFF",
			"ON"
		};

		// Token: 0x04000529 RID: 1321
		private readonly Func<bool> _getter;

		// Token: 0x0400052A RID: 1322
		private readonly Action<bool> _setter;
	}
}
