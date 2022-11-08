using System;

namespace SonicOrca.Core
{
	// Token: 0x0200013C RID: 316
	public class ObjectMapping
	{
		// Token: 0x1700032C RID: 812
		// (get) Token: 0x06000CAE RID: 3246 RVA: 0x000305D3 File Offset: 0x0002E7D3
		public string Field
		{
			get
			{
				return this._field;
			}
		}

		// Token: 0x1700032D RID: 813
		// (get) Token: 0x06000CAF RID: 3247 RVA: 0x000305DB File Offset: 0x0002E7DB
		// (set) Token: 0x06000CB0 RID: 3248 RVA: 0x000305E3 File Offset: 0x0002E7E3
		public Guid Target
		{
			get
			{
				return this._target;
			}
			set
			{
				this._target = value;
			}
		}

		// Token: 0x06000CB1 RID: 3249 RVA: 0x000305EC File Offset: 0x0002E7EC
		public ObjectMapping(string field, Guid target)
		{
			this._field = field;
			this._target = target;
		}

		// Token: 0x04000744 RID: 1860
		private readonly string _field;

		// Token: 0x04000745 RID: 1861
		private Guid _target;
	}
}
