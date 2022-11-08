using System;
using System.Collections.Generic;
using SonicOrca.Core;
using SonicOrca.Geometry;

namespace SONICORCA.OBJECTS.HTZRISINGGROUP
{
	// Token: 0x0200008F RID: 143
	public class HTZRisingGroupInstance : ActiveObject
	{
		// Token: 0x17000055 RID: 85
		// (get) Token: 0x060002E7 RID: 743 RVA: 0x00015524 File Offset: 0x00013724
		// (set) Token: 0x060002E8 RID: 744 RVA: 0x0001552C File Offset: 0x0001372C
		public ActiveObject SlotA { get; set; }

		// Token: 0x17000056 RID: 86
		// (get) Token: 0x060002E9 RID: 745 RVA: 0x00015535 File Offset: 0x00013735
		// (set) Token: 0x060002EA RID: 746 RVA: 0x0001553D File Offset: 0x0001373D
		public ActiveObject SlotB { get; set; }

		// Token: 0x17000057 RID: 87
		// (get) Token: 0x060002EB RID: 747 RVA: 0x00015546 File Offset: 0x00013746
		// (set) Token: 0x060002EC RID: 748 RVA: 0x0001554E File Offset: 0x0001374E
		public ActiveObject SlotC { get; set; }

		// Token: 0x17000058 RID: 88
		// (get) Token: 0x060002ED RID: 749 RVA: 0x00015557 File Offset: 0x00013757
		// (set) Token: 0x060002EE RID: 750 RVA: 0x00015560 File Offset: 0x00013760
		public Vector2i Size
		{
			get
			{
				return this._size;
			}
			set
			{
				this._size = value;
				base.DesignBounds = new Rectanglei(-(this._size.X / 2), -(this._size.Y / 2), this._size.X, this._size.Y);
			}
		}

		// Token: 0x060002EF RID: 751 RVA: 0x000155B4 File Offset: 0x000137B4
		public HTZRisingGroupInstance()
		{
			base.DesignBounds = new Rectanglei(-(this._size.X / 2), -(this._size.Y / 2), this._size.X, this._size.Y);
		}

		// Token: 0x060002F0 RID: 752 RVA: 0x00015624 File Offset: 0x00013824
		protected override void OnStart()
		{
			this._level = base.Level;
			int currentAct = this._level.CurrentAct;
			if (currentAct == 1)
			{
				this.Act1Events();
				return;
			}
			if (currentAct != 2)
			{
				return;
			}
			this.Act2Events();
		}

		// Token: 0x060002F1 RID: 753 RVA: 0x0001565F File Offset: 0x0001385F
		protected override void OnStop()
		{
			if (this.SlotA != null)
			{
				this.SlotA.LockLifetime = false;
			}
			if (this.SlotB != null)
			{
				this.SlotB.LockLifetime = false;
			}
			if (this.SlotC != null)
			{
				this.SlotC.LockLifetime = false;
			}
		}

		// Token: 0x060002F2 RID: 754 RVA: 0x000156A0 File Offset: 0x000138A0
		protected override void OnUpdate()
		{
			if (this.SlotA != null && !this._groupMembers.Contains(this.SlotA))
			{
				this.SlotA.LockLifetime = true;
				this._groupMembers.Add(this.SlotA);
				this.SlotA.Position = new Vector2i(this.SlotA.Position.X, this.SlotA.Position.Y + this._earthquakeUpperBound - this._earthquakeY);
			}
			if (this.SlotB != null && !this._groupMembers.Contains(this.SlotB))
			{
				this.SlotB.LockLifetime = true;
				this._groupMembers.Add(this.SlotB);
				this.SlotB.Position = new Vector2i(this.SlotB.Position.X, this.SlotB.Position.Y + this._earthquakeUpperBound - this._earthquakeY);
			}
			if (this.SlotC != null && !this._groupMembers.Contains(this.SlotC))
			{
				this.SlotC.LockLifetime = true;
				this._groupMembers.Add(this.SlotC);
				this.SlotC.Position = new Vector2i(this.SlotC.Position.X, this.SlotC.Position.Y + this._earthquakeUpperBound - this._earthquakeY);
			}
			int currentAct = this._level.CurrentAct;
			if (currentAct == 1)
			{
				this.Act1Events();
				return;
			}
			if (currentAct != 2)
			{
				return;
			}
			this.Act2Events();
		}

		// Token: 0x060002F3 RID: 755 RVA: 0x00015844 File Offset: 0x00013A44
		private void Act1Events()
		{
			Rectanglei rectanglei = this._level.Camera.Bounds;
			LevelMarker marker = this._level.GetMarker("eq_1_left_reset");
			LevelMarker marker2 = this._level.GetMarker("eq_1_left_begin");
			LevelMarker marker3 = this._level.GetMarker("eq_1_right_begin");
			LevelMarker marker4 = this._level.GetMarker("eq_1_right_reset");
			switch (this._state)
			{
			case 0:
				this._level.EarthquakeActive = false;
				if (rectanglei.X >= marker.Position.X)
				{
					this._earthquakeUpperBound = 1280;
					this._earthquakeLowerBound = 896;
					this._earthquakeY = this._earthquakeUpperBound;
					this._earthquakeTimer = 0;
					this._state = 1;
				}
				break;
			case 1:
				if (rectanglei.X >= marker2.Position.X && rectanglei.X < marker3.Position.X)
				{
					if (this._earthquakeDirection)
					{
						if (this._earthquakeY == this._earthquakeLowerBound)
						{
							this._earthquakeTimer--;
							if (this._earthquakeTimer < 0)
							{
								this._earthquakeTimer = 120;
								this._earthquakeDirection = !this._earthquakeDirection;
							}
							this._level.EarthquakeActive = false;
						}
						else if (this._level.Ticks % 4 == 0)
						{
							this._earthquakeY -= 4;
							this._level.EarthquakeActive = true;
						}
					}
					else if (this._earthquakeY == this._earthquakeUpperBound)
					{
						this._earthquakeTimer--;
						if (this._earthquakeTimer < 0)
						{
							this._earthquakeTimer = 120;
							this._earthquakeDirection = !this._earthquakeDirection;
						}
						this._level.EarthquakeActive = false;
					}
					else if (this._level.Ticks % 4 == 0)
					{
						this._earthquakeY += 4;
						this._level.EarthquakeActive = true;
					}
				}
				if (rectanglei.X < marker.Position.X)
				{
					this._earthquakeDirection = false;
					this._state = 0;
				}
				else if (rectanglei.X >= marker4.Position.X)
				{
					this._earthquakeDirection = false;
					this._state = 2;
				}
				break;
			case 2:
				this._level.EarthquakeActive = false;
				if (rectanglei.X < marker4.Position.X)
				{
					this._earthquakeY = this._earthquakeUpperBound;
					this._earthquakeTimer = 0;
					this._state = 1;
				}
				break;
			}
			this.UpdateGroupPositions();
		}

		// Token: 0x060002F4 RID: 756 RVA: 0x00015AEC File Offset: 0x00013CEC
		private void Act2Events()
		{
			Rectanglei rectanglei = this._level.Camera.Bounds;
			LevelMarker marker = this._level.GetMarker("eq_2_split");
			LevelMarker marker2 = this._level.GetMarker("eq_2a_left_reset");
			LevelMarker marker3 = this._level.GetMarker("eq_2a_left_begin");
			LevelMarker marker4 = this._level.GetMarker("eq_2a_right_begin");
			LevelMarker marker5 = this._level.GetMarker("eq_2a_right_reset");
			switch (this._state)
			{
			case 0:
				this._level.EarthquakeActive = false;
				if (rectanglei.X >= marker2.Position.X)
				{
					if (rectanglei.Y < marker.Position.Y)
					{
						this._earthquakeUpperBound = 3328;
						this._earthquakeLowerBound = 0;
						this._earthquakeY = this._earthquakeUpperBound;
						this._state = 1;
					}
					else
					{
						this._earthquakeUpperBound = 3072;
						this._earthquakeLowerBound = 0;
						this._earthquakeY = this._earthquakeUpperBound;
						this._state = 4;
					}
				}
				break;
			case 1:
				if (rectanglei.X >= marker3.Position.X && rectanglei.X < marker4.Position.X)
				{
					if (this._earthquakeDirection)
					{
						if (this._earthquakeY == this._earthquakeLowerBound)
						{
							this._earthquakeTimer--;
							if (this._earthquakeTimer < 0)
							{
								this._earthquakeTimer = 120;
								this._earthquakeDirection = !this._earthquakeDirection;
							}
							this._level.EarthquakeActive = false;
						}
						else if (this._level.Ticks % 4 == 0)
						{
							this._earthquakeY -= 4;
							this._level.EarthquakeActive = true;
						}
					}
					else if (this._earthquakeY == this._earthquakeUpperBound)
					{
						this._earthquakeTimer--;
						if (this._earthquakeTimer < 0)
						{
							this._earthquakeTimer = 120;
							this._earthquakeDirection = !this._earthquakeDirection;
						}
						this._level.EarthquakeActive = false;
					}
					else if (this._level.Ticks % 4 == 0)
					{
						this._earthquakeY += 4;
						this._level.EarthquakeActive = true;
					}
				}
				if (rectanglei.X < marker2.Position.X)
				{
					this._earthquakeDirection = false;
					this._state = 0;
				}
				else if (rectanglei.X >= marker5.Position.X)
				{
					this._earthquakeDirection = false;
					this._state = 2;
				}
				break;
			case 2:
				this._level.EarthquakeActive = false;
				if (rectanglei.X < marker5.Position.X)
				{
					this._earthquakeY = this._earthquakeUpperBound;
					this._earthquakeTimer = 0;
					this._state = 1;
				}
				break;
			case 4:
				if (rectanglei.X >= marker3.Position.X && rectanglei.X < marker4.Position.X)
				{
					if (this._earthquakeDirection)
					{
						if (this._earthquakeY == this._earthquakeLowerBound)
						{
							this._earthquakeTimer--;
							if (this._earthquakeTimer < 0)
							{
								this._earthquakeTimer = 120;
								this._earthquakeDirection = !this._earthquakeDirection;
							}
							this._level.EarthquakeActive = false;
						}
						else if (this._level.Ticks % 4 == 0)
						{
							this._earthquakeY -= 4;
							this._level.EarthquakeActive = true;
						}
					}
					else if (this._earthquakeY == this._earthquakeUpperBound)
					{
						this._earthquakeTimer--;
						if (this._earthquakeTimer < 0)
						{
							this._earthquakeTimer = 120;
							this._earthquakeDirection = !this._earthquakeDirection;
						}
						this._level.EarthquakeActive = false;
					}
					else if (this._level.Ticks % 4 == 0)
					{
						this._earthquakeY += 4;
						this._level.EarthquakeActive = true;
					}
				}
				if (rectanglei.X < marker2.Position.X)
				{
					this._earthquakeDirection = false;
					this._state = 0;
				}
				else if (rectanglei.X >= marker5.Position.X)
				{
					this._earthquakeDirection = false;
					this._state = 5;
				}
				break;
			case 5:
				this._level.EarthquakeActive = false;
				if (rectanglei.X < marker5.Position.X)
				{
					this._earthquakeY = this._earthquakeUpperBound;
					this._earthquakeTimer = 0;
					this._state = 4;
				}
				break;
			}
			this.UpdateGroupPositions();
		}

		// Token: 0x060002F5 RID: 757 RVA: 0x00015FB8 File Offset: 0x000141B8
		private void UpdateGroupPositions()
		{
			if (this._level.EarthquakeActive)
			{
				int num = this._earthquakeDirection ? -4 : 4;
				if (this._level.Ticks % 4 == 0)
				{
					foreach (ActiveObject activeObject in this._groupMembers)
					{
						Vector2i position = activeObject.Position;
						position.Y += num;
						activeObject.Position = position;
					}
				}
			}
		}

		// Token: 0x040003B1 RID: 945
		private Vector2i _size = new Vector2i(2048, 512);

		// Token: 0x040003B5 RID: 949
		private List<ActiveObject> _groupMembers = new List<ActiveObject>();

		// Token: 0x040003B6 RID: 950
		private Level _level;

		// Token: 0x040003B7 RID: 951
		private int _state;

		// Token: 0x040003B8 RID: 952
		private int _earthquakeY;

		// Token: 0x040003B9 RID: 953
		private int _earthquakeTimer;

		// Token: 0x040003BA RID: 954
		private bool _earthquakeDirection;

		// Token: 0x040003BB RID: 955
		private int _earthquakeUpperBound;

		// Token: 0x040003BC RID: 956
		private int _earthquakeLowerBound;
	}
}
