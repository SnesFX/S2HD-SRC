using System;
using System.Collections.Generic;

namespace SonicOrca
{
	// Token: 0x02000095 RID: 149
	public interface IGameState : IDisposable
	{
		// Token: 0x060004E0 RID: 1248
		IEnumerable<UpdateResult> Update();

		// Token: 0x060004E1 RID: 1249
		void Draw();
	}
}
