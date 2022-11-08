using System;
using SonicOrca.Geometry;
using SonicOrca.Input;

namespace SonicOrca
{
	// Token: 0x02000091 RID: 145
	public class Controller
	{
		// Token: 0x17000080 RID: 128
		// (get) Token: 0x060004B3 RID: 1203 RVA: 0x0001877B File Offset: 0x0001697B
		// (set) Token: 0x060004B4 RID: 1204 RVA: 0x00018782 File Offset: 0x00016982
		public static bool IsDebug { get; set; }

		// Token: 0x17000081 RID: 129
		// (get) Token: 0x060004B5 RID: 1205 RVA: 0x0001878A File Offset: 0x0001698A
		// (set) Token: 0x060004B6 RID: 1206 RVA: 0x00018792 File Offset: 0x00016992
		public Vector2 DirectionLeft { get; private set; }

		// Token: 0x17000082 RID: 130
		// (get) Token: 0x060004B7 RID: 1207 RVA: 0x0001879B File Offset: 0x0001699B
		// (set) Token: 0x060004B8 RID: 1208 RVA: 0x000187A3 File Offset: 0x000169A3
		public Vector2 DirectionRight { get; private set; }

		// Token: 0x17000083 RID: 131
		// (get) Token: 0x060004B9 RID: 1209 RVA: 0x000187AC File Offset: 0x000169AC
		// (set) Token: 0x060004BA RID: 1210 RVA: 0x000187B4 File Offset: 0x000169B4
		public bool Start { get; private set; }

		// Token: 0x17000084 RID: 132
		// (get) Token: 0x060004BB RID: 1211 RVA: 0x000187BD File Offset: 0x000169BD
		// (set) Token: 0x060004BC RID: 1212 RVA: 0x000187C5 File Offset: 0x000169C5
		public bool Action1 { get; private set; }

		// Token: 0x17000085 RID: 133
		// (get) Token: 0x060004BD RID: 1213 RVA: 0x000187CE File Offset: 0x000169CE
		// (set) Token: 0x060004BE RID: 1214 RVA: 0x000187D6 File Offset: 0x000169D6
		public bool Action2 { get; private set; }

		// Token: 0x17000086 RID: 134
		// (get) Token: 0x060004BF RID: 1215 RVA: 0x000187DF File Offset: 0x000169DF
		// (set) Token: 0x060004C0 RID: 1216 RVA: 0x000187E7 File Offset: 0x000169E7
		public bool Action3 { get; private set; }

		// Token: 0x17000087 RID: 135
		// (get) Token: 0x060004C1 RID: 1217 RVA: 0x000187F0 File Offset: 0x000169F0
		// (set) Token: 0x060004C2 RID: 1218 RVA: 0x000187F8 File Offset: 0x000169F8
		public double LeftTrigger { get; private set; }

		// Token: 0x17000088 RID: 136
		// (get) Token: 0x060004C3 RID: 1219 RVA: 0x00018801 File Offset: 0x00016A01
		// (set) Token: 0x060004C4 RID: 1220 RVA: 0x00018809 File Offset: 0x00016A09
		public double RightTrigger { get; private set; }

		// Token: 0x17000089 RID: 137
		// (get) Token: 0x060004C5 RID: 1221 RVA: 0x00018812 File Offset: 0x00016A12
		public int Index
		{
			get
			{
				return this._index;
			}
		}

		// Token: 0x060004C6 RID: 1222 RVA: 0x0001881A File Offset: 0x00016A1A
		public Controller(SonicOrcaGameContext gameContext, int index, InputStateEventType eventType)
		{
			this._gameContext = gameContext;
			this._index = index;
			this._eventType = eventType;
		}

		// Token: 0x060004C7 RID: 1223 RVA: 0x00018838 File Offset: 0x00016A38
		public void Update()
		{
			GamePadInputState gamePadInputState = this._gameContext.Input.GetInputState(this._eventType).GamePad[this._index];
			if (this._index == 0)
			{
				KeyboardState keyboard = this._gameContext.Input.GetInputState(this._eventType).Keyboard;
				Vector2 vector = default(Vector2);
				if (keyboard.Keys[80])
				{
					vector.X = -1.0;
				}
				else if (keyboard.Keys[79])
				{
					vector.X = 1.0;
				}
				if (keyboard.Keys[82])
				{
					vector.Y = -1.0;
				}
				else if (keyboard.Keys[81])
				{
					vector.Y = 1.0;
				}
				if (vector == default(Vector2))
				{
					if (gamePadInputState.LeftAxis == default(Vector2))
					{
						vector = gamePadInputState.POV;
					}
					else
					{
						vector = gamePadInputState.LeftAxis;
					}
				}
				this.DirectionLeft = vector;
				this.Action1 = (gamePadInputState.West || gamePadInputState.North);
				this.Action2 = gamePadInputState.South;
				this.Action3 = gamePadInputState.East;
				this.Action1 = (this.Action1 || keyboard.Keys[4]);
				this.Action2 = (this.Action2 || keyboard.Keys[22]);
				this.Action3 = (this.Action3 || keyboard.Keys[7]);
				this.Start = gamePadInputState.Start;
				this.Start = (this.Start || keyboard.Keys[40]);
				this.LeftTrigger = gamePadInputState.LeftTrigger;
				this.RightTrigger = gamePadInputState.RightTrigger;
				this.DirectionRight = gamePadInputState.RightAxis;
			}
			else if (this._index == 1)
			{
				KeyboardState keyboard2 = this._gameContext.Input.GetInputState(this._eventType).Keyboard;
				Vector2 vector2 = default(Vector2);
				if (keyboard2.Keys[13])
				{
					vector2.X = -1.0;
				}
				else if (keyboard2.Keys[15])
				{
					vector2.X = 1.0;
				}
				if (keyboard2.Keys[12])
				{
					vector2.Y = -1.0;
				}
				else if (keyboard2.Keys[14])
				{
					vector2.Y = 1.0;
				}
				if (vector2 == default(Vector2))
				{
					if (gamePadInputState.LeftAxis == default(Vector2))
					{
						vector2 = gamePadInputState.POV;
					}
					else
					{
						vector2 = gamePadInputState.LeftAxis;
					}
				}
				this.DirectionLeft = vector2;
				this.Action1 = (gamePadInputState.West || gamePadInputState.North);
				this.Action2 = gamePadInputState.South;
				this.Action3 = gamePadInputState.East;
				this.DirectionLeft = vector2;
				this.Action1 = (gamePadInputState.West || gamePadInputState.North);
				this.Action2 = gamePadInputState.South;
				this.Action3 = gamePadInputState.East;
				this.Action1 = (this.Action1 || keyboard2.Keys[20]);
				this.Action2 = (this.Action2 || keyboard2.Keys[26]);
				this.Action3 = (this.Action3 || keyboard2.Keys[8]);
				this.Start = gamePadInputState.Start;
				this.Start = (this.Start || keyboard2.Keys[40]);
				this.LeftTrigger = gamePadInputState.LeftTrigger;
				this.RightTrigger = gamePadInputState.RightTrigger;
				this.DirectionRight = gamePadInputState.RightAxis;
			}
			if (!Controller.IsDebug)
			{
				this.Action1 = (this.Action1 || this.Action2 || this.Action3);
			}
		}

		// Token: 0x040002FA RID: 762
		private readonly int _index;

		// Token: 0x040002FB RID: 763
		private readonly SonicOrcaGameContext _gameContext;

		// Token: 0x040002FC RID: 764
		private readonly InputStateEventType _eventType;
	}
}
