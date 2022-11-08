using System;
using SonicOrca.Geometry;

namespace SonicOrca.Input
{
	// Token: 0x020000B1 RID: 177
	public struct MouseState
	{
		// Token: 0x170000E6 RID: 230
		// (get) Token: 0x060005EB RID: 1515 RVA: 0x0001C246 File Offset: 0x0001A446
		// (set) Token: 0x060005EC RID: 1516 RVA: 0x0001C24E File Offset: 0x0001A44E
		public int X { get; set; }

		// Token: 0x170000E7 RID: 231
		// (get) Token: 0x060005ED RID: 1517 RVA: 0x0001C257 File Offset: 0x0001A457
		// (set) Token: 0x060005EE RID: 1518 RVA: 0x0001C25F File Offset: 0x0001A45F
		public int Y { get; set; }

		// Token: 0x170000E8 RID: 232
		// (get) Token: 0x060005EF RID: 1519 RVA: 0x0001C268 File Offset: 0x0001A468
		// (set) Token: 0x060005F0 RID: 1520 RVA: 0x0001C270 File Offset: 0x0001A470
		public double Wheel { get; set; }

		// Token: 0x170000E9 RID: 233
		// (get) Token: 0x060005F1 RID: 1521 RVA: 0x0001C279 File Offset: 0x0001A479
		// (set) Token: 0x060005F2 RID: 1522 RVA: 0x0001C281 File Offset: 0x0001A481
		public bool Left { get; set; }

		// Token: 0x170000EA RID: 234
		// (get) Token: 0x060005F3 RID: 1523 RVA: 0x0001C28A File Offset: 0x0001A48A
		// (set) Token: 0x060005F4 RID: 1524 RVA: 0x0001C292 File Offset: 0x0001A492
		public bool Middle { get; set; }

		// Token: 0x170000EB RID: 235
		// (get) Token: 0x060005F5 RID: 1525 RVA: 0x0001C29B File Offset: 0x0001A49B
		// (set) Token: 0x060005F6 RID: 1526 RVA: 0x0001C2A3 File Offset: 0x0001A4A3
		public bool Right { get; set; }

		// Token: 0x170000EC RID: 236
		// (get) Token: 0x060005F7 RID: 1527 RVA: 0x0001C2AC File Offset: 0x0001A4AC
		public Vector2i Position
		{
			get
			{
				return new Vector2i(this.X, this.Y);
			}
		}

		// Token: 0x060005F8 RID: 1528 RVA: 0x0001C2C0 File Offset: 0x0001A4C0
		public static MouseState GetPressed(MouseState previousState, MouseState nextState)
		{
			MouseState result = nextState;
			result.Left = (!previousState.Left && nextState.Left);
			result.Middle = (!previousState.Middle && nextState.Middle);
			result.Right = (!previousState.Right && nextState.Right);
			return result;
		}

		// Token: 0x060005F9 RID: 1529 RVA: 0x0001C320 File Offset: 0x0001A520
		public static MouseState GetReleased(MouseState previousState, MouseState nextState)
		{
			MouseState result = nextState;
			result.Left = (previousState.Left && !nextState.Left);
			result.Middle = (previousState.Middle && !nextState.Middle);
			result.Right = (previousState.Right && !nextState.Right);
			return result;
		}
	}
}
