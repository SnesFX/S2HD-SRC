using System;
using System.Collections.Generic;
using System.Linq;
using SonicOrca.Graphics;

namespace SonicOrca.Core.Debugging
{
	// Token: 0x02000193 RID: 403
	internal class DiscreteDebugOption<T> : DebugOption
	{
		// Token: 0x17000493 RID: 1171
		// (get) Token: 0x06001164 RID: 4452 RVA: 0x00044D84 File Offset: 0x00042F84
		// (set) Token: 0x06001165 RID: 4453 RVA: 0x00044D9C File Offset: 0x00042F9C
		public T SelectedValue
		{
			get
			{
				return this._values[this._selectedIndex].Value;
			}
			set
			{
				for (int i = 0; i < this._values.Length; i++)
				{
					T value2 = this._values[i].Value;
					if (value2.Equals(value))
					{
						this._selectedIndex = i;
						return;
					}
				}
			}
		}

		// Token: 0x06001166 RID: 4454 RVA: 0x00044DEB File Offset: 0x00042FEB
		public DiscreteDebugOption(DebugContext context, string page, string category, string name, IEnumerable<KeyValuePair<string, T>> values) : base(context, page, category, true)
		{
			this._name = name;
			this._values = values.ToArray<KeyValuePair<string, T>>();
		}

		// Token: 0x06001167 RID: 4455 RVA: 0x00044E0C File Offset: 0x0004300C
		public override void OnPressLeft()
		{
			if (this._selectedIndex > 0)
			{
				this._selectedIndex--;
				this.OnChange();
				base.Context.PlayFocusSound();
			}
		}

		// Token: 0x06001168 RID: 4456 RVA: 0x00044E36 File Offset: 0x00043036
		public override void OnPressRight()
		{
			if (this._selectedIndex < this._values.Length - 1)
			{
				this._selectedIndex++;
				this.OnChange();
				base.Context.PlayFocusSound();
			}
		}

		// Token: 0x06001169 RID: 4457 RVA: 0x00006325 File Offset: 0x00004525
		public virtual void OnChange()
		{
		}

		// Token: 0x0600116A RID: 4458 RVA: 0x00044E6C File Offset: 0x0004306C
		public override int Draw(Renderer renderer)
		{
			base.Context.DrawText(renderer, this._name, FontAlignment.Left, 0.0, 0.0, 0.5, new int?((base.Context.CurrentOption == this) ? 1 : 0));
			int num = 1888;
			int num2 = this._values.Length - 1;
			foreach (KeyValuePair<string, T> keyValuePair in this._values.Reverse<KeyValuePair<string, T>>())
			{
				bool flag = num2 == this._selectedIndex;
				base.Context.DrawText(renderer, keyValuePair.Key, FontAlignment.Right, (double)num, 0.0, 0.5, new int?(flag ? 1 : 0));
				num += -(int)(base.Context.Font.MeasureString(keyValuePair.Key).Width * 0.5) - 16;
				num2--;
			}
			return (int)((double)base.Context.Font.Height * 0.5);
		}

		// Token: 0x040009BD RID: 2493
		private readonly string _name;

		// Token: 0x040009BE RID: 2494
		private readonly KeyValuePair<string, T>[] _values;

		// Token: 0x040009BF RID: 2495
		private int _selectedIndex;
	}
}
