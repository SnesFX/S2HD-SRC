using System;
using System.Collections.Generic;

namespace S2HD.Menu
{
	// Token: 0x020000BF RID: 191
	internal class StandardOptionSetting : ISpinnerSetting, ISetting
	{
		// Token: 0x170000A1 RID: 161
		// (get) Token: 0x06000484 RID: 1156 RVA: 0x0001E3B4 File Offset: 0x0001C5B4
		public string Name { get; }

		// Token: 0x170000A2 RID: 162
		// (get) Token: 0x06000485 RID: 1157 RVA: 0x0001E3BC File Offset: 0x0001C5BC
		public IReadOnlyList<string> Values
		{
			get
			{
				return this._valueStrings;
			}
		}

		// Token: 0x170000A3 RID: 163
		// (get) Token: 0x06000486 RID: 1158 RVA: 0x0001E3C4 File Offset: 0x0001C5C4
		// (set) Token: 0x06000487 RID: 1159 RVA: 0x0001E3D1 File Offset: 0x0001C5D1
		public int SelectedIndex
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

		// Token: 0x06000488 RID: 1160 RVA: 0x0001E3DF File Offset: 0x0001C5DF
		public StandardOptionSetting(string name, string[] values, Func<int> getter, Action<int> setter)
		{
			this.Name = name;
			this._valueStrings = values;
			this._getter = getter;
			this._setter = setter;
		}

		// Token: 0x06000489 RID: 1161 RVA: 0x0001E404 File Offset: 0x0001C604
		public override string ToString()
		{
			return string.Format("{0}: {1}", this.Name, this.Values[this.SelectedIndex]);
		}

		// Token: 0x04000524 RID: 1316
		private readonly string[] _valueStrings;

		// Token: 0x04000525 RID: 1317
		private readonly Func<int> _getter;

		// Token: 0x04000526 RID: 1318
		private readonly Action<int> _setter;
	}
}
