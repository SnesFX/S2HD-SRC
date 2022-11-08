using System;
using System.Collections.Generic;
using SonicOrca.Core;
using SonicOrca.Core.Objects;
using SonicOrca.Core.Objects.Metadata;
using SonicOrca.Geometry;
using SonicOrca.Graphics;

namespace SONICORCA.OBJECTS.FORCESPINBALL
{
	// Token: 0x02000062 RID: 98
	public class ForceSpinballInstance : ActiveObject
	{
		// Token: 0x0600020B RID: 523 RVA: 0x0000FD87 File Offset: 0x0000DF87
		protected override void OnStart()
		{
		}

		// Token: 0x0600020C RID: 524 RVA: 0x0000FD8C File Offset: 0x0000DF8C
		protected override void OnUpdate()
		{
			foreach (ICharacter character in base.Level.ObjectManager.Characters)
			{
				this.UpdateCharacter(character);
			}
		}

		// Token: 0x0600020D RID: 525 RVA: 0x0000FDE4 File Offset: 0x0000DFE4
		private void UpdateCharacter(ICharacter character)
		{
			if (character.IsDebug)
			{
				return;
			}
			if (this._direction != 0 && this._direction != 2)
			{
				int num = (character.Position.X < base.Position.X) ? -1 : 1;
				if (this._characterTrace.ContainsKey(character) && this._characterTrace[character] != num && character.Position.Y >= base.Position.Y - 64 && character.Position.Y < base.Position.Y + 64)
				{
					if (num == -1)
					{
						character.ForceSpinball = (this._direction == 3);
					}
					else
					{
						character.ForceSpinball = (this._direction == 1);
					}
				}
				this._characterTrace[character] = num;
			}
		}

		// Token: 0x0600020E RID: 526 RVA: 0x0000FEC4 File Offset: 0x0000E0C4
		protected override void OnDraw(Renderer renderer, LayerViewOptions viewOptions)
		{
			if (!viewOptions.ShowObjectCollision && !base.Level.StateFlags.HasFlag(LevelStateFlags.Editing))
			{
				return;
			}
			renderer.Get2dRenderer().RenderRectangle(Colours.White, new Rectangle(-64.0, -64.0, 128.0, 128.0), 1.0);
		}

		// Token: 0x04000273 RID: 627
		private readonly Dictionary<ICharacter, int> _characterTrace = new Dictionary<ICharacter, int>();

		// Token: 0x04000274 RID: 628
		[StateVariable]
		private int _direction = 1;
	}
}
