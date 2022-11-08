using System;

namespace SonicOrca.Core
{
	// Token: 0x02000139 RID: 313
	public class ObjectEditorPropertyInteger : ObjectEditorProperty
	{
		// Token: 0x17000318 RID: 792
		// (get) Token: 0x06000C81 RID: 3201 RVA: 0x0002FFB4 File Offset: 0x0002E1B4
		public int MinValue
		{
			get
			{
				return this._minValue;
			}
		}

		// Token: 0x17000319 RID: 793
		// (get) Token: 0x06000C82 RID: 3202 RVA: 0x0002FFBC File Offset: 0x0002E1BC
		public int MaxValue
		{
			get
			{
				return this._maxValue;
			}
		}

		// Token: 0x06000C83 RID: 3203 RVA: 0x0002FFC4 File Offset: 0x0002E1C4
		public ObjectEditorPropertyInteger(string name, string key, int minValue, int maxValue, int defaultValue = 0, string description = null) : base(name, key, typeof(int), defaultValue, description)
		{
			this._minValue = minValue;
			this._maxValue = maxValue;
		}

		// Token: 0x06000C84 RID: 3204 RVA: 0x0002FFF0 File Offset: 0x0002E1F0
		public override bool Validate(ref object value)
		{
			int value2;
			if (value is string)
			{
				if (!int.TryParse((string)value, out value2))
				{
					return false;
				}
			}
			else
			{
				if (!(value is int))
				{
					return false;
				}
				value2 = (int)value;
			}
			value = MathX.Clamp(this._minValue, value2, this._maxValue);
			return true;
		}

		// Token: 0x04000731 RID: 1841
		private readonly int _minValue;

		// Token: 0x04000732 RID: 1842
		private readonly int _maxValue;
	}
}
