using System;
using System.Collections.Generic;
using System.Linq;
using SonicOrca.Core;
using SonicOrca.Core.Collision;
using SonicOrca.Core.Objects;
using SonicOrca.Core.Objects.Metadata;
using SonicOrca.Geometry;
using SonicOrca.Graphics;

namespace SONICORCA.OBJECTS.CPZSPINTUBE
{
	// Token: 0x02000071 RID: 113
	public class CPZSpinTubeInstance : ActiveObject
	{
		// Token: 0x0600023B RID: 571 RVA: 0x00010743 File Offset: 0x0000E943
		public CPZSpinTubeInstance()
		{
			base.DesignBounds = new Rectanglei(-64, -64, 128, 128);
		}

		// Token: 0x1700003D RID: 61
		// (get) Token: 0x0600023C RID: 572 RVA: 0x00010770 File Offset: 0x0000E970
		// (set) Token: 0x0600023D RID: 573 RVA: 0x00010778 File Offset: 0x0000E978
		[StateVariable]
		private string Path0 { get; set; }

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x0600023E RID: 574 RVA: 0x00010781 File Offset: 0x0000E981
		// (set) Token: 0x0600023F RID: 575 RVA: 0x00010789 File Offset: 0x0000E989
		[StateVariable]
		private string Path1 { get; set; }

		// Token: 0x06000240 RID: 576 RVA: 0x00010794 File Offset: 0x0000E994
		protected override void OnStart()
		{
			this._path[0] = CPZSpinTubeInstance.ReadPathElements(this.Path0);
			this._path[1] = CPZSpinTubeInstance.ReadPathElements(this.Path1);
			if (this._path[0] == null || this._path[0].Length == 0)
			{
				base.Finish();
				return;
			}
			base.CollisionRectangles = new CollisionRectangle[]
			{
				new CollisionRectangle(this, 0, this._path[0][0].Position.X - 64, this._path[0][0].Position.Y - 56, 128, 128)
			};
		}

		// Token: 0x06000241 RID: 577 RVA: 0x00010840 File Offset: 0x0000EA40
		private static CPZSpinTubeInstance.PathElement[] ReadPathElements(string pathDataString)
		{
			if (pathDataString == null)
			{
				pathDataString = string.Empty;
			}
			List<CPZSpinTubeInstance.PathElement> list = new List<CPZSpinTubeInstance.PathElement>();
			foreach (string text in pathDataString.Trim().Split(new char[]
			{
				'|'
			}))
			{
				bool spinNoise = false;
				string text2 = text.Trim();
				if (text2.Length >= 3)
				{
					if (text2[0] == '#')
					{
						spinNoise = true;
						text2 = text2.Substring(1);
					}
					string[] array2 = text2.Split(new char[]
					{
						','
					});
					int x;
					int y;
					if (array2.Length == 2 && int.TryParse(array2[0], out x) && int.TryParse(array2[1], out y))
					{
						list.Add(new CPZSpinTubeInstance.PathElement(new Vector2i(x, y), spinNoise));
					}
				}
			}
			return list.ToArray();
		}

		// Token: 0x06000242 RID: 578 RVA: 0x00010904 File Offset: 0x0000EB04
		protected override void OnCollision(CollisionEvent e)
		{
			if (e.ActiveObject.Type.Classification != ObjectClassification.Character)
			{
				return;
			}
			ICharacter character = (ICharacter)e.ActiveObject;
			if (character.ObjectLink == this)
			{
				return;
			}
			this.CharacterBegin(character);
		}

		// Token: 0x06000243 RID: 579 RVA: 0x00010944 File Offset: 0x0000EB44
		protected override void OnUpdate()
		{
			base.OnUpdate();
			ICharacter[] array = (from x in base.Level.ObjectManager.Characters
			where x.ObjectLink == this
			select x).ToArray<ICharacter>();
			if (array.Length == 0)
			{
				this._pathIndex = base.Level.Random.Next(0, 2);
				if (this._path[1] == null || this._path[1].Length == 0)
				{
					this._pathIndex = 0;
				}
			}
			foreach (ICharacter character in array)
			{
				if ((int)character.ObjectTag >= this._path[this._pathIndex].Length || character.IsDebug || character.IsDying || character.IsDead)
				{
					this.ReleaseCharacter(character);
				}
				else
				{
					this.CharacterContinue(character);
				}
			}
			base.LockLifetime = (array.Length != 0);
		}

		// Token: 0x06000244 RID: 580 RVA: 0x00010A1C File Offset: 0x0000EC1C
		private void CharacterBegin(ICharacter character)
		{
			character.IsAirborne = true;
			character.ForceSpinball = true;
			character.IsSpinball = true;
			character.Position = base.Position + this._path[this._pathIndex][0].Position;
			character.ObjectLink = this;
			character.ObjectTag = 1;
			character.IsObjectControlled = true;
			base.Level.SoundManager.PlaySound("SONICORCA/SOUND/SPINBALL");
			this._previousCharacterLayer = base.Level.Map.Layers.IndexOf(character.Layer);
			character.Layer = base.Level.Map.Layers.First((LevelLayer l) => l.Name == "pipes bottom");
		}

		// Token: 0x06000245 RID: 581 RVA: 0x00010AF4 File Offset: 0x0000ECF4
		private void CharacterContinue(ICharacter character)
		{
			int num = (int)character.ObjectTag;
			Vector2i vector2i = base.Position + this._path[this._pathIndex][num].Position;
			Vector2i position = character.Position;
			Vector2 vector = vector2i - position;
			if (vector.Length <= 32.0)
			{
				character.Position = vector2i;
				character.ObjectTag = num + 1;
			}
			else
			{
				character.Position = (Vector2i)(position + vector.Normalised * 32.0);
			}
			character.IsAirborne = true;
			character.ForceSpinball = false;
			character.Velocity = ((vector.X == 0.0 && vector.Y == 0.0) ? character.Velocity.Normalised : vector.Normalised) * 0.001;
			character.CheckCollision = false;
			if (this._path[this._pathIndex][num].SpinNoise)
			{
				base.Level.SoundManager.PlaySound("SONICORCA/SOUND/SPINBALL");
			}
		}

		// Token: 0x06000246 RID: 582 RVA: 0x00010C30 File Offset: 0x0000EE30
		private void ReleaseCharacter(ICharacter character)
		{
			character.ObjectLink = null;
			character.ObjectTag = null;
			character.ForceSpinball = false;
			character.CheckCollision = true;
			character.IsObjectControlled = false;
			character.IsRollJumping = false;
			if (!character.IsDebug && !character.IsDying && !character.IsDead)
			{
				character.IsAirborne = true;
				character.IsSpinball = true;
				character.Velocity = new Vector2(0.0, -32.0);
				base.Level.SoundManager.PlaySound("SONICORCA/SOUND/SPINDASH/RELEASE");
			}
			character.Layer = base.Level.Map.Layers[this._previousCharacterLayer];
		}

		// Token: 0x06000247 RID: 583 RVA: 0x00010CE0 File Offset: 0x0000EEE0
		protected override void OnDraw(Renderer renderer, LayerViewOptions viewOptions)
		{
			if (!viewOptions.ShowObjectCollision && !base.Level.StateFlags.HasFlag(LevelStateFlags.Editing))
			{
				return;
			}
			I2dRenderer i2dRenderer = renderer.Get2dRenderer();
			Rectanglei rectanglei = base.DesignBounds.OffsetBy(this._path[0][0].Position);
			i2dRenderer.RenderQuad(Colours.White, new Rectangle((double)rectanglei.X * renderer.GetObjectRenderer().Scale.X, (double)rectanglei.Y * renderer.GetObjectRenderer().Scale.Y, (double)rectanglei.Width * renderer.GetObjectRenderer().Scale.X, (double)rectanglei.Height * renderer.GetObjectRenderer().Scale.Y));
			for (int i = 0; i < 2; i++)
			{
				CPZSpinTubeInstance.PathElement[] array = this._path[i];
				if (array != null && array.Length != 0)
				{
					Vector2 vector = array[0].Position;
					foreach (Vector2i v in from x in array.Skip(1)
					select x.Position)
					{
						Vector2 vector2 = v;
						i2dRenderer.RenderLine(Colours.Yellow, new Vector2(vector.X * renderer.GetObjectRenderer().Scale.X, vector.Y * renderer.GetObjectRenderer().Scale.Y), new Vector2(vector2.X * renderer.GetObjectRenderer().Scale.X, vector2.Y * renderer.GetObjectRenderer().Scale.Y), 2.0);
						vector = vector2;
					}
				}
			}
		}

		// Token: 0x04000290 RID: 656
		private int _previousCharacterLayer;

		// Token: 0x04000291 RID: 657
		private CPZSpinTubeInstance.PathElement[][] _path = new CPZSpinTubeInstance.PathElement[2][];

		// Token: 0x04000292 RID: 658
		private int _pathIndex;

		// Token: 0x020000E8 RID: 232
		private struct PathElement
		{
			// Token: 0x170000EA RID: 234
			// (get) Token: 0x060005C4 RID: 1476 RVA: 0x000227DB File Offset: 0x000209DB
			// (set) Token: 0x060005C5 RID: 1477 RVA: 0x000227E3 File Offset: 0x000209E3
			public Vector2i Position { get; set; }

			// Token: 0x170000EB RID: 235
			// (get) Token: 0x060005C6 RID: 1478 RVA: 0x000227EC File Offset: 0x000209EC
			// (set) Token: 0x060005C7 RID: 1479 RVA: 0x000227F4 File Offset: 0x000209F4
			public bool SpinNoise { get; set; }

			// Token: 0x060005C8 RID: 1480 RVA: 0x000227FD File Offset: 0x000209FD
			public PathElement(Vector2i position, bool spinNoise)
			{
				this = default(CPZSpinTubeInstance.PathElement);
				this.Position = position;
				this.SpinNoise = spinNoise;
			}

			// Token: 0x060005C9 RID: 1481 RVA: 0x00022814 File Offset: 0x00020A14
			public override string ToString()
			{
				return string.Format("{0}, Spin = {1}", this.Position, this.SpinNoise);
			}
		}
	}
}
