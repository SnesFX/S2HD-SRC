using System;
using System.Collections.Generic;

namespace SonicOrca
{
	// Token: 0x0200009C RID: 156
	public class Updater
	{
		// Token: 0x0600054D RID: 1357 RVA: 0x0001A1C7 File Offset: 0x000183C7
		public Updater(IEnumerable<UpdateResult> updateMethod)
		{
			this._updateStateEnumerator = updateMethod.GetEnumerator();
		}

		// Token: 0x0600054E RID: 1358 RVA: 0x0001A1DC File Offset: 0x000183DC
		public bool Update()
		{
			if (this._updateStateWaitTicks > 0)
			{
				this._updateStateWaitTicks--;
				return true;
			}
			if (!this._updateStateEnumerator.MoveNext())
			{
				return false;
			}
			UpdateResult updateResult = this._updateStateEnumerator.Current;
			UpdateResultType type = updateResult.Type;
			if (type == UpdateResultType.Next || type != UpdateResultType.Wait)
			{
				return true;
			}
			this._updateStateWaitTicks = updateResult.WaitTicks;
			return true;
		}

		// Token: 0x0400032E RID: 814
		private readonly IEnumerator<UpdateResult> _updateStateEnumerator;

		// Token: 0x0400032F RID: 815
		private int _updateStateWaitTicks;
	}
}
