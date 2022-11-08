using System;
using SonicOrca.Geometry;

namespace SonicOrca.Input
{
	// Token: 0x020000AB RID: 171
	public struct GamePadInputState
	{
		// Token: 0x170000C7 RID: 199
		// (get) Token: 0x0600059F RID: 1439 RVA: 0x0001B9C5 File Offset: 0x00019BC5
		// (set) Token: 0x060005A0 RID: 1440 RVA: 0x0001B9CD File Offset: 0x00019BCD
		public Vector2i POV { get; set; }

		// Token: 0x170000C8 RID: 200
		// (get) Token: 0x060005A1 RID: 1441 RVA: 0x0001B9D6 File Offset: 0x00019BD6
		// (set) Token: 0x060005A2 RID: 1442 RVA: 0x0001B9DE File Offset: 0x00019BDE
		public Vector2 LeftAxis { get; set; }

		// Token: 0x170000C9 RID: 201
		// (get) Token: 0x060005A3 RID: 1443 RVA: 0x0001B9E7 File Offset: 0x00019BE7
		// (set) Token: 0x060005A4 RID: 1444 RVA: 0x0001B9EF File Offset: 0x00019BEF
		public Vector2 RightAxis { get; set; }

		// Token: 0x170000CA RID: 202
		// (get) Token: 0x060005A5 RID: 1445 RVA: 0x0001B9F8 File Offset: 0x00019BF8
		// (set) Token: 0x060005A6 RID: 1446 RVA: 0x0001BA00 File Offset: 0x00019C00
		public bool LeftAxisButton { get; set; }

		// Token: 0x170000CB RID: 203
		// (get) Token: 0x060005A7 RID: 1447 RVA: 0x0001BA09 File Offset: 0x00019C09
		// (set) Token: 0x060005A8 RID: 1448 RVA: 0x0001BA11 File Offset: 0x00019C11
		public bool RightAxisButton { get; set; }

		// Token: 0x170000CC RID: 204
		// (get) Token: 0x060005A9 RID: 1449 RVA: 0x0001BA1A File Offset: 0x00019C1A
		// (set) Token: 0x060005AA RID: 1450 RVA: 0x0001BA22 File Offset: 0x00019C22
		public bool North { get; set; }

		// Token: 0x170000CD RID: 205
		// (get) Token: 0x060005AB RID: 1451 RVA: 0x0001BA2B File Offset: 0x00019C2B
		// (set) Token: 0x060005AC RID: 1452 RVA: 0x0001BA33 File Offset: 0x00019C33
		public bool East { get; set; }

		// Token: 0x170000CE RID: 206
		// (get) Token: 0x060005AD RID: 1453 RVA: 0x0001BA3C File Offset: 0x00019C3C
		// (set) Token: 0x060005AE RID: 1454 RVA: 0x0001BA44 File Offset: 0x00019C44
		public bool South { get; set; }

		// Token: 0x170000CF RID: 207
		// (get) Token: 0x060005AF RID: 1455 RVA: 0x0001BA4D File Offset: 0x00019C4D
		// (set) Token: 0x060005B0 RID: 1456 RVA: 0x0001BA55 File Offset: 0x00019C55
		public bool West { get; set; }

		// Token: 0x170000D0 RID: 208
		// (get) Token: 0x060005B1 RID: 1457 RVA: 0x0001BA5E File Offset: 0x00019C5E
		// (set) Token: 0x060005B2 RID: 1458 RVA: 0x0001BA66 File Offset: 0x00019C66
		public bool Start { get; set; }

		// Token: 0x170000D1 RID: 209
		// (get) Token: 0x060005B3 RID: 1459 RVA: 0x0001BA6F File Offset: 0x00019C6F
		// (set) Token: 0x060005B4 RID: 1460 RVA: 0x0001BA77 File Offset: 0x00019C77
		public bool Select { get; set; }

		// Token: 0x170000D2 RID: 210
		// (get) Token: 0x060005B5 RID: 1461 RVA: 0x0001BA80 File Offset: 0x00019C80
		// (set) Token: 0x060005B6 RID: 1462 RVA: 0x0001BA88 File Offset: 0x00019C88
		public bool LeftBumper { get; set; }

		// Token: 0x170000D3 RID: 211
		// (get) Token: 0x060005B7 RID: 1463 RVA: 0x0001BA91 File Offset: 0x00019C91
		// (set) Token: 0x060005B8 RID: 1464 RVA: 0x0001BA99 File Offset: 0x00019C99
		public bool RightBumper { get; set; }

		// Token: 0x170000D4 RID: 212
		// (get) Token: 0x060005B9 RID: 1465 RVA: 0x0001BAA2 File Offset: 0x00019CA2
		// (set) Token: 0x060005BA RID: 1466 RVA: 0x0001BAAA File Offset: 0x00019CAA
		public double LeftTrigger { get; set; }

		// Token: 0x170000D5 RID: 213
		// (get) Token: 0x060005BB RID: 1467 RVA: 0x0001BAB3 File Offset: 0x00019CB3
		// (set) Token: 0x060005BC RID: 1468 RVA: 0x0001BABB File Offset: 0x00019CBB
		public double RightTrigger { get; set; }

		// Token: 0x060005BD RID: 1469 RVA: 0x0001BAC4 File Offset: 0x00019CC4
		public static GamePadInputState GetPressed(GamePadInputState prev, GamePadInputState next)
		{
			GamePadInputState result = next;
			result.POV = GamePadInputState.GetAxisStateChanged(prev.POV, next.POV);
			result.LeftAxis = GamePadInputState.GetAxisStateChanged(prev.LeftAxis, next.LeftAxis);
			result.RightAxis = GamePadInputState.GetAxisStateChanged(prev.RightAxis, next.RightAxis);
			result.LeftAxisButton = (!prev.LeftAxisButton && next.LeftAxisButton);
			result.RightAxisButton = (!prev.RightAxisButton && next.RightAxisButton);
			result.North = (!prev.North && next.North);
			result.East = (!prev.East && next.East);
			result.South = (!prev.South && next.South);
			result.West = (!prev.West && next.West);
			result.Start = (!prev.Start && next.Start);
			result.Select = (!prev.Select && next.Select);
			result.LeftBumper = (!prev.LeftBumper && next.LeftBumper);
			result.RightBumper = (!prev.RightBumper && next.RightBumper);
			return result;
		}

		// Token: 0x060005BE RID: 1470 RVA: 0x0001BC28 File Offset: 0x00019E28
		public static GamePadInputState GetReleased(GamePadInputState prev, GamePadInputState next)
		{
			GamePadInputState result = next;
			result.POV = GamePadInputState.GetAxisStateChanged(prev.POV, next.POV);
			result.LeftAxis = GamePadInputState.GetAxisStateChanged(prev.LeftAxis, next.LeftAxis);
			result.RightAxis = GamePadInputState.GetAxisStateChanged(prev.RightAxis, next.RightAxis);
			result.LeftAxisButton = (prev.LeftAxisButton && !next.LeftAxisButton);
			result.RightAxisButton = (prev.RightAxisButton && !next.RightAxisButton);
			result.North = (prev.North && !next.North);
			result.East = (prev.East && !next.East);
			result.West = (prev.West && !next.West);
			result.Start = (prev.Start && !next.Start);
			result.Select = (prev.Select && !next.Select);
			result.LeftBumper = (prev.LeftBumper && !next.LeftBumper);
			result.RightBumper = (prev.RightBumper && !next.RightBumper);
			return result;
		}

		// Token: 0x060005BF RID: 1471 RVA: 0x0001BD8C File Offset: 0x00019F8C
		private static Vector2i GetAxisStateChanged(Vector2i prev, Vector2i next)
		{
			Vector2i result = next;
			if (prev.X == next.X)
			{
				result.X = 0;
			}
			if (prev.Y == next.Y)
			{
				result.Y = 0;
			}
			return result;
		}

		// Token: 0x060005C0 RID: 1472 RVA: 0x0001BDCC File Offset: 0x00019FCC
		private static Vector2 GetAxisStateChanged(Vector2 prev, Vector2 next)
		{
			int direction = GamePadInputState.GetDirection(prev.X);
			int direction2 = GamePadInputState.GetDirection(prev.Y);
			int direction3 = GamePadInputState.GetDirection(next.X);
			int direction4 = GamePadInputState.GetDirection(next.Y);
			Vector2 result = next;
			if (direction == direction3)
			{
				result.X = 0.0;
			}
			if (direction2 == direction4)
			{
				result.Y = 0.0;
			}
			return result;
		}

		// Token: 0x060005C1 RID: 1473 RVA: 0x0001BE36 File Offset: 0x0001A036
		private static int GetDirection(double value)
		{
			if (value <= -0.2)
			{
				return -1;
			}
			if (value >= 0.2)
			{
				return 1;
			}
			return 0;
		}
	}
}
