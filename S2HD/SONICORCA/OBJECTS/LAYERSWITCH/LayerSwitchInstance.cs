using System;
using System.Collections.Generic;
using SonicOrca.Core;
using SonicOrca.Core.Objects;
using SonicOrca.Core.Objects.Metadata;
using SonicOrca.Geometry;
using SonicOrca.Graphics;

namespace SONICORCA.OBJECTS.LAYERSWITCH
{
	// Token: 0x02000015 RID: 21
	public class LayerSwitchInstance : ActiveObject
	{
		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000072 RID: 114 RVA: 0x00006174 File Offset: 0x00004374
		// (set) Token: 0x06000073 RID: 115 RVA: 0x0000617C File Offset: 0x0000437C
		[StateVariable]
		private bool AllowAirborne
		{
			get
			{
				return this._allowAirborne;
			}
			set
			{
				this._allowAirborne = value;
			}
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000074 RID: 116 RVA: 0x00006185 File Offset: 0x00004385
		// (set) Token: 0x06000075 RID: 117 RVA: 0x0000618D File Offset: 0x0000438D
		[StateVariable]
		private bool PathConstrained
		{
			get
			{
				return this._pathConstrained;
			}
			set
			{
				this._pathConstrained = value;
			}
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000076 RID: 118 RVA: 0x00006196 File Offset: 0x00004396
		// (set) Token: 0x06000077 RID: 119 RVA: 0x0000619E File Offset: 0x0000439E
		[StateVariable]
		private int Path
		{
			get
			{
				return this._path;
			}
			set
			{
				this._path = value;
			}
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000078 RID: 120 RVA: 0x000061A7 File Offset: 0x000043A7
		// (set) Token: 0x06000079 RID: 121 RVA: 0x000061AF File Offset: 0x000043AF
		[StateVariable]
		public int Width
		{
			get
			{
				return this._width;
			}
			set
			{
				this._width = value;
			}
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x0600007A RID: 122 RVA: 0x000061B8 File Offset: 0x000043B8
		// (set) Token: 0x0600007B RID: 123 RVA: 0x000061C0 File Offset: 0x000043C0
		[StateVariable]
		public int Height
		{
			get
			{
				return this._height;
			}
			set
			{
				this._height = value;
			}
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x0600007C RID: 124 RVA: 0x000061C9 File Offset: 0x000043C9
		// (set) Token: 0x0600007D RID: 125 RVA: 0x000061D1 File Offset: 0x000043D1
		[StateVariable]
		private int Above
		{
			get
			{
				return this._above;
			}
			set
			{
				this._above = value;
			}
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x0600007E RID: 126 RVA: 0x000061DA File Offset: 0x000043DA
		// (set) Token: 0x0600007F RID: 127 RVA: 0x000061E2 File Offset: 0x000043E2
		[StateVariable]
		private int Below
		{
			get
			{
				return this._below;
			}
			set
			{
				this._below = value;
			}
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000080 RID: 128 RVA: 0x000061EB File Offset: 0x000043EB
		// (set) Token: 0x06000081 RID: 129 RVA: 0x000061F3 File Offset: 0x000043F3
		[StateVariable]
		private int Left
		{
			get
			{
				return this._left;
			}
			set
			{
				this._left = value;
			}
		}

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000082 RID: 130 RVA: 0x000061FC File Offset: 0x000043FC
		// (set) Token: 0x06000083 RID: 131 RVA: 0x00006204 File Offset: 0x00004404
		[StateVariable]
		private int Right
		{
			get
			{
				return this._right;
			}
			set
			{
				this._right = value;
			}
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000084 RID: 132 RVA: 0x0000620D File Offset: 0x0000440D
		// (set) Token: 0x06000085 RID: 133 RVA: 0x00006215 File Offset: 0x00004415
		[StateVariable]
		private int AboveLayer
		{
			get
			{
				return this._aboveLayer;
			}
			set
			{
				this._aboveLayer = value;
			}
		}

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x06000086 RID: 134 RVA: 0x0000621E File Offset: 0x0000441E
		// (set) Token: 0x06000087 RID: 135 RVA: 0x00006226 File Offset: 0x00004426
		[StateVariable]
		private int BelowLayer
		{
			get
			{
				return this._belowLayer;
			}
			set
			{
				this._belowLayer = value;
			}
		}

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x06000088 RID: 136 RVA: 0x0000622F File Offset: 0x0000442F
		// (set) Token: 0x06000089 RID: 137 RVA: 0x00006237 File Offset: 0x00004437
		[StateVariable]
		private int LeftLayer
		{
			get
			{
				return this._leftLayer;
			}
			set
			{
				this._leftLayer = value;
			}
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x0600008A RID: 138 RVA: 0x00006240 File Offset: 0x00004440
		// (set) Token: 0x0600008B RID: 139 RVA: 0x00006248 File Offset: 0x00004448
		[StateVariable]
		private int RightLayer
		{
			get
			{
				return this._rightLayer;
			}
			set
			{
				this._rightLayer = value;
			}
		}

		// Token: 0x0600008C RID: 140 RVA: 0x00006254 File Offset: 0x00004454
		protected override void OnStart()
		{
			if (this._width != 0)
			{
				this._horizontal = true;
				this._pathA = this._above;
				this._pathB = this._below;
				this._layerA = this._aboveLayer;
				this._layerB = this._belowLayer;
				this._radius = this._width / 2;
				base.DesignBounds = new Rectanglei(-this._radius, -4, this._radius * 2, 8);
			}
			else
			{
				this._pathA = this._left;
				this._pathB = this._right;
				this._layerA = this._leftLayer;
				this._layerB = this._rightLayer;
				this._radius = this._height / 2;
				base.DesignBounds = new Rectanglei(-4, -this._radius, 8, this._radius * 2);
			}
			int index = base.Layer.Index;
			this._layerA += index;
			this._layerB += index;
		}

		// Token: 0x0600008D RID: 141 RVA: 0x00006350 File Offset: 0x00004550
		protected override void OnUpdate()
		{
			foreach (ICharacter character in base.Level.ObjectManager.Characters)
			{
				this.UpdateCharacter(character);
			}
		}

		// Token: 0x0600008E RID: 142 RVA: 0x000063A8 File Offset: 0x000045A8
		private void UpdateCharacter(ICharacter character)
		{
			if (character.IsDebug || !character.ShouldReactToLevel || character.IsObjectControlled)
			{
				return;
			}
			if (this._pathConstrained && character.Path != this._path)
			{
				return;
			}
			if (this._horizontal)
			{
				int num = (character.Position.Y < base.Position.Y) ? -1 : 1;
				if (this._characterTrace.ContainsKey(character))
				{
					int num2 = this._characterTrace[character];
					if ((this._allowAirborne || !character.IsAirborne) && num2 != num && character.Position.X >= base.Position.X - this._radius && character.Position.X < base.Position.X + this._radius)
					{
						if (num == -1)
						{
							character.Path = this._pathA;
							character.Layer = base.Level.Map.Layers[this._layerA];
						}
						else
						{
							character.Path = this._pathB;
							character.Layer = base.Level.Map.Layers[this._layerB];
						}
					}
				}
				this._characterTrace[character] = num;
				return;
			}
			int num3 = (character.Position.X < base.Position.X) ? -1 : 1;
			if (this._characterTrace.ContainsKey(character))
			{
				int num4 = this._characterTrace[character];
				if ((this._allowAirborne || !character.IsAirborne) && num4 != num3 && character.Position.Y >= base.Position.Y - this._radius && character.Position.Y < base.Position.Y + this._radius)
				{
					if (num3 == -1)
					{
						character.Path = this._pathA;
						character.Layer = base.Level.Map.Layers[this._layerA];
					}
					else
					{
						character.Path = this._pathB;
						character.Layer = base.Level.Map.Layers[this._layerB];
					}
				}
			}
			this._characterTrace[character] = num3;
		}

		// Token: 0x0600008F RID: 143 RVA: 0x00006620 File Offset: 0x00004820
		protected override void OnDraw(Renderer renderer, LayerViewOptions viewOptions)
		{
			if (!viewOptions.ShowObjectCollision && !base.Level.StateFlags.HasFlag(LevelStateFlags.Editing))
			{
				return;
			}
			I2dRenderer i2dRenderer = renderer.Get2dRenderer();
			if (this._horizontal)
			{
				i2dRenderer.RenderLine(new Colour(byte.MaxValue, byte.MaxValue, 0), new Vector2((double)(-(double)this._radius) * renderer.GetObjectRenderer().Scale.X, -2.0 * renderer.GetObjectRenderer().Scale.Y), new Vector2((double)this._radius * renderer.GetObjectRenderer().Scale.X, -2.0 * renderer.GetObjectRenderer().Scale.Y), 1.0);
				i2dRenderer.RenderLine(Colours.White, new Vector2((double)(-(double)this._radius) * renderer.GetObjectRenderer().Scale.X, 0.0 * renderer.GetObjectRenderer().Scale.Y), new Vector2((double)this._radius * renderer.GetObjectRenderer().Scale.X, 0.0 * renderer.GetObjectRenderer().Scale.Y), 1.0);
				i2dRenderer.RenderLine(new Colour(byte.MaxValue, byte.MaxValue, 0), new Vector2((double)(-(double)this._radius) * renderer.GetObjectRenderer().Scale.X, 2.0 * renderer.GetObjectRenderer().Scale.Y), new Vector2((double)this._radius * renderer.GetObjectRenderer().Scale.X, 2.0 * renderer.GetObjectRenderer().Scale.Y), 1.0);
				return;
			}
			i2dRenderer.RenderLine(new Colour(byte.MaxValue, byte.MaxValue, 0), new Vector2(-2.0 * renderer.GetObjectRenderer().Scale.X, (double)(-(double)this._radius) * renderer.GetObjectRenderer().Scale.Y), new Vector2(-2.0 * renderer.GetObjectRenderer().Scale.X, (double)this._radius * renderer.GetObjectRenderer().Scale.Y), 1.0);
			i2dRenderer.RenderLine(Colours.White, new Vector2(0.0, (double)(-(double)this._radius) * renderer.GetObjectRenderer().Scale.Y), new Vector2(0.0, (double)this._radius * renderer.GetObjectRenderer().Scale.Y), 1.0);
			i2dRenderer.RenderLine(new Colour(byte.MaxValue, byte.MaxValue, 0), new Vector2(2.0 * renderer.GetObjectRenderer().Scale.X, (double)(-(double)this._radius) * renderer.GetObjectRenderer().Scale.Y), new Vector2(2.0 * renderer.GetObjectRenderer().Scale.X, (double)this._radius * renderer.GetObjectRenderer().Scale.Y), 1.0);
		}

		// Token: 0x0400008E RID: 142
		private readonly Dictionary<ICharacter, int> _characterTrace = new Dictionary<ICharacter, int>();

		// Token: 0x0400008F RID: 143
		private bool _allowAirborne = true;

		// Token: 0x04000090 RID: 144
		private bool _pathConstrained;

		// Token: 0x04000091 RID: 145
		private int _path;

		// Token: 0x04000092 RID: 146
		private int _width;

		// Token: 0x04000093 RID: 147
		private int _height;

		// Token: 0x04000094 RID: 148
		private int _above;

		// Token: 0x04000095 RID: 149
		private int _below;

		// Token: 0x04000096 RID: 150
		private int _left;

		// Token: 0x04000097 RID: 151
		private int _right;

		// Token: 0x04000098 RID: 152
		private int _aboveLayer;

		// Token: 0x04000099 RID: 153
		private int _belowLayer;

		// Token: 0x0400009A RID: 154
		private int _leftLayer;

		// Token: 0x0400009B RID: 155
		private int _rightLayer;

		// Token: 0x0400009C RID: 156
		private bool _horizontal;

		// Token: 0x0400009D RID: 157
		private int _radius;

		// Token: 0x0400009E RID: 158
		private int _pathA;

		// Token: 0x0400009F RID: 159
		private int _pathB;

		// Token: 0x040000A0 RID: 160
		private int _layerA;

		// Token: 0x040000A1 RID: 161
		private int _layerB;
	}
}
