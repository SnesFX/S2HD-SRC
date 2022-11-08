using System;
using System.Collections.Generic;
using System.Linq;

namespace SonicOrca.Input
{
	// Token: 0x020000AE RID: 174
	public class InputState
	{
		// Token: 0x170000DF RID: 223
		// (get) Token: 0x060005DA RID: 1498 RVA: 0x0001BFC1 File Offset: 0x0001A1C1
		public MouseState Mouse
		{
			get
			{
				return this._mouseState;
			}
		}

		// Token: 0x170000E0 RID: 224
		// (get) Token: 0x060005DB RID: 1499 RVA: 0x0001BFC9 File Offset: 0x0001A1C9
		public KeyboardState Keyboard
		{
			get
			{
				return this._keyboardState;
			}
		}

		// Token: 0x170000E1 RID: 225
		// (get) Token: 0x060005DC RID: 1500 RVA: 0x0001BFD1 File Offset: 0x0001A1D1
		public IReadOnlyList<GamePadInputState> GamePad
		{
			get
			{
				return this._gamePadInputState;
			}
		}

		// Token: 0x060005DD RID: 1501 RVA: 0x0001BFDC File Offset: 0x0001A1DC
		public InputState()
		{
			this._mouseState = default(MouseState);
			this._keyboardState = new KeyboardState();
			this._gamePadInputState = (from x in Enumerable.Range(0, 4)
			select default(GamePadInputState)).ToArray<GamePadInputState>();
		}

		// Token: 0x060005DE RID: 1502 RVA: 0x0001C03C File Offset: 0x0001A23C
		public InputState(MouseState mouseState, KeyboardState keyboardState, GamePadInputState[] gamepadInputState)
		{
			this._mouseState = mouseState;
			this._keyboardState = keyboardState;
			this._gamePadInputState = gamepadInputState;
		}

		// Token: 0x060005DF RID: 1503 RVA: 0x0001C05C File Offset: 0x0001A25C
		public static InputState GetPressed(InputState previousState, InputState nextState)
		{
			return new InputState(MouseState.GetPressed(previousState.Mouse, nextState.Mouse), KeyboardState.GetPressed(previousState.Keyboard, nextState.Keyboard), (from x in Enumerable.Range(0, 4)
			select GamePadInputState.GetPressed(previousState.GamePad[x], nextState.GamePad[x])).ToArray<GamePadInputState>());
		}

		// Token: 0x060005E0 RID: 1504 RVA: 0x0001C0D8 File Offset: 0x0001A2D8
		public static InputState GetReleased(InputState previousState, InputState nextState)
		{
			return new InputState(MouseState.GetReleased(previousState.Mouse, nextState.Mouse), KeyboardState.GetReleased(previousState.Keyboard, nextState.Keyboard), (from x in Enumerable.Range(0, 4)
			select GamePadInputState.GetReleased(previousState.GamePad[x], nextState.GamePad[x])).ToArray<GamePadInputState>());
		}

		// Token: 0x04000371 RID: 881
		private readonly MouseState _mouseState;

		// Token: 0x04000372 RID: 882
		private readonly KeyboardState _keyboardState;

		// Token: 0x04000373 RID: 883
		private readonly GamePadInputState[] _gamePadInputState;
	}
}
