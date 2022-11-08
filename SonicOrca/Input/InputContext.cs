using System;

namespace SonicOrca.Input
{
	// Token: 0x020000AD RID: 173
	public abstract class InputContext
	{
		// Token: 0x170000D8 RID: 216
		// (get) Token: 0x060005C6 RID: 1478 RVA: 0x0001BE77 File Offset: 0x0001A077
		// (set) Token: 0x060005C7 RID: 1479 RVA: 0x0001BE7F File Offset: 0x0001A07F
		public InputState LastState { get; protected set; }

		// Token: 0x170000D9 RID: 217
		// (get) Token: 0x060005C8 RID: 1480 RVA: 0x0001BE88 File Offset: 0x0001A088
		// (set) Token: 0x060005C9 RID: 1481 RVA: 0x0001BE90 File Offset: 0x0001A090
		public InputState CurrentState { get; protected set; }

		// Token: 0x170000DA RID: 218
		// (get) Token: 0x060005CA RID: 1482 RVA: 0x0001BE99 File Offset: 0x0001A099
		// (set) Token: 0x060005CB RID: 1483 RVA: 0x0001BEA1 File Offset: 0x0001A0A1
		public InputState Pressed { get; private set; }

		// Token: 0x170000DB RID: 219
		// (get) Token: 0x060005CC RID: 1484 RVA: 0x0001BEAA File Offset: 0x0001A0AA
		// (set) Token: 0x060005CD RID: 1485 RVA: 0x0001BEB2 File Offset: 0x0001A0B2
		public InputState Released { get; private set; }

		// Token: 0x170000DC RID: 220
		// (get) Token: 0x060005CE RID: 1486 RVA: 0x0001BEBB File Offset: 0x0001A0BB
		// (set) Token: 0x060005CF RID: 1487 RVA: 0x0001BEC3 File Offset: 0x0001A0C3
		public OutputState OutputState { get; set; }

		// Token: 0x170000DD RID: 221
		// (get) Token: 0x060005D0 RID: 1488 RVA: 0x0001BECC File Offset: 0x0001A0CC
		// (set) Token: 0x060005D1 RID: 1489 RVA: 0x0001BED4 File Offset: 0x0001A0D4
		public bool IsVibrationEnabled { get; set; }

		// Token: 0x170000DE RID: 222
		// (get) Token: 0x060005D2 RID: 1490 RVA: 0x0001BEDD File Offset: 0x0001A0DD
		// (set) Token: 0x060005D3 RID: 1491 RVA: 0x0001BEE5 File Offset: 0x0001A0E5
		public string TextInput { get; protected set; }

		// Token: 0x060005D4 RID: 1492 RVA: 0x0001BEEE File Offset: 0x0001A0EE
		protected InputContext()
		{
			this.LastState = new InputState();
			this.CurrentState = new InputState();
			this.Pressed = new InputState();
			this.Released = new InputState();
			this.OutputState = new OutputState();
		}

		// Token: 0x060005D5 RID: 1493 RVA: 0x00006325 File Offset: 0x00004525
		public virtual void UpdateCurrentState()
		{
		}

		// Token: 0x060005D6 RID: 1494 RVA: 0x0001BF2D File Offset: 0x0001A12D
		public void Update()
		{
			this.CurrentState = new InputState();
			this.UpdateCurrentState();
			this.OutputState = new OutputState();
		}

		// Token: 0x060005D7 RID: 1495 RVA: 0x0001BF4B File Offset: 0x0001A14B
		public void UpdatePressedReleased()
		{
			this.Pressed = InputState.GetPressed(this.LastState, this.CurrentState);
			this.Released = InputState.GetReleased(this.LastState, this.CurrentState);
			this.LastState = this.CurrentState;
		}

		// Token: 0x060005D8 RID: 1496 RVA: 0x0001BF87 File Offset: 0x0001A187
		public InputState GetInputState(InputStateEventType eventType)
		{
			switch (eventType)
			{
			case InputStateEventType.Current:
				return this.CurrentState;
			case InputStateEventType.Pressed:
				return this.Pressed;
			case InputStateEventType.Released:
				return this.Released;
			default:
				throw new ArgumentException("Invalid event type", "eventType");
			}
		}

		// Token: 0x060005D9 RID: 1497
		public abstract char GetKeyCode(int scancode);
	}
}
