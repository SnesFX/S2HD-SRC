using System;
using System.Collections.Generic;
using SonicOrca;

namespace S2HD
{
	// Token: 0x0200009C RID: 156
	internal class EffectEventManager
	{
		// Token: 0x06000373 RID: 883 RVA: 0x00019188 File Offset: 0x00017388
		public void Clear()
		{
			this._runningEvents.Clear();
		}

		// Token: 0x06000374 RID: 884 RVA: 0x00019198 File Offset: 0x00017398
		public void BeginEvent(IEnumerable<UpdateResult> eventMethod)
		{
			Updater updater = new Updater(eventMethod);
			if (updater.Update())
			{
				this._runningEvents.Add(updater);
			}
		}

		// Token: 0x06000375 RID: 885 RVA: 0x000191C0 File Offset: 0x000173C0
		public void Update()
		{
			int i = 0;
			while (i < this._runningEvents.Count)
			{
				if (this._runningEvents[i].Update())
				{
					i++;
				}
				else
				{
					this._runningEvents.RemoveAt(i);
				}
			}
		}

		// Token: 0x04000428 RID: 1064
		private List<Updater> _runningEvents = new List<Updater>();
	}
}
