using System;
using SonicOrca.Core.Objects;
using SonicOrca.Core.Objects.Base;

namespace SonicOrca.Core
{
	// Token: 0x0200010B RID: 267
	public static class CharacterIntelligence
	{
		// Token: 0x060009E4 RID: 2532 RVA: 0x00025CB0 File Offset: 0x00023EB0
		public static void SimpleMoveRightJumpObsticals(ICharacter character)
		{
			CharacterInputState characterInputState = new CharacterInputState();
			characterInputState.HorizontalDirection = 1;
			if (character.IsAirborne)
			{
				characterInputState.A = CharacterInputButtonState.Down;
			}
			else if (!character.IsAirborne && character.IsPushing)
			{
				characterInputState.A = CharacterInputButtonState.Pressed;
			}
			character.Input = characterInputState;
		}
	}
}
