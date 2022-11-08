using System;
using SonicOrca.Geometry;

namespace SonicOrca.Core.Objects.Base
{
	// Token: 0x0200016B RID: 363
	public class CharacterHistoryItem
	{
		// Token: 0x17000437 RID: 1079
		// (get) Token: 0x06001016 RID: 4118 RVA: 0x0004143E File Offset: 0x0003F63E
		public Vector2i Position
		{
			get
			{
				return (Vector2i)this._positionPrecise;
			}
		}

		// Token: 0x17000438 RID: 1080
		// (get) Token: 0x06001017 RID: 4119 RVA: 0x0004144B File Offset: 0x0003F64B
		public Vector2 PositionPrecise
		{
			get
			{
				return this._positionPrecise;
			}
		}

		// Token: 0x17000439 RID: 1081
		// (get) Token: 0x06001018 RID: 4120 RVA: 0x00041453 File Offset: 0x0003F653
		public CharacterState State
		{
			get
			{
				return this._state;
			}
		}

		// Token: 0x1700043A RID: 1082
		// (get) Token: 0x06001019 RID: 4121 RVA: 0x0004145B File Offset: 0x0003F65B
		public CharacterInputState Input
		{
			get
			{
				return this._input;
			}
		}

		// Token: 0x0600101A RID: 4122 RVA: 0x00041463 File Offset: 0x0003F663
		public CharacterHistoryItem(Vector2 positionPrecise, CharacterState state, CharacterInputState input)
		{
			this._positionPrecise = positionPrecise;
			this._state = state;
			this._input = input;
		}

		// Token: 0x04000902 RID: 2306
		private readonly Vector2 _positionPrecise;

		// Token: 0x04000903 RID: 2307
		private readonly CharacterState _state;

		// Token: 0x04000904 RID: 2308
		private readonly CharacterInputState _input;
	}
}
