using System;
using System.Collections.Generic;
using SonicOrca;
using SonicOrca.Core;
using SonicOrca.Core.Objects;
using SonicOrca.Core.Objects.Metadata;
using SonicOrca.Extensions;
using SonicOrca.Geometry;
using SonicOrca.Graphics;

namespace SONICORCA.OBJECTS.SIGNPOST
{
	// Token: 0x02000032 RID: 50
	public class SignpostInstance : ActiveObject
	{
		// Token: 0x17000024 RID: 36
		// (get) Token: 0x0600010F RID: 271 RVA: 0x00009687 File Offset: 0x00007887
		// (set) Token: 0x06000110 RID: 272 RVA: 0x0000968F File Offset: 0x0000788F
		[StateVariable]
		private bool Activated
		{
			get
			{
				return this._activated;
			}
			set
			{
				this._activated = value;
			}
		}

		// Token: 0x06000111 RID: 273 RVA: 0x00009698 File Offset: 0x00007898
		public SignpostInstance()
		{
			base.DesignBounds = new Rectanglei(-96, -96, 192, 192);
		}

		// Token: 0x06000112 RID: 274 RVA: 0x000096BC File Offset: 0x000078BC
		protected override void OnStart()
		{
			this._updater = new Updater(this.GetUpdates());
			this._animation = new AnimationInstance(base.ResourceTree, base.Type.GetAbsolutePath("/ANIGROUP"), 0);
			this._animation.Index = 2;
			if (this._activated)
			{
				this._animation.Index = this.GetAnimationIndexFromCharacter(this.GetProtagonistCharacterIndex()) + 1;
				this._activated = true;
				this._triggedEndGame = true;
			}
		}

		// Token: 0x06000113 RID: 275 RVA: 0x00009737 File Offset: 0x00007937
		protected override void OnUpdate()
		{
			this._updater.Update();
		}

		// Token: 0x06000114 RID: 276 RVA: 0x00009745 File Offset: 0x00007945
		private IEnumerable<UpdateResult> GetUpdates()
		{
			if (this._triggedEndGame)
			{
				yield break;
			}
			while (!this._activated)
			{
				foreach (ICharacter character in base.Level.ObjectManager.Characters)
				{
					if (!character.IsSidekick && !character.IsDebug && character.ShouldReactToLevel && character.Position.X >= base.Position.X && character.LastPosition.X < base.Position.X)
					{
						this.Activate(character);
					}
				}
				yield return UpdateResult.Next();
			}
			int minSpins = 10;
			int spins = 0;
			int characterIndex = 0;
			int targetCharacterIndex = this.GetProtagonistCharacterIndex();
			spins = 0;
			while (spins < minSpins || characterIndex != targetCharacterIndex)
			{
				AnimationInstance animation = this._animation;
				int num = animation.Index;
				animation.Index = num + 1;
				while (this._animation.Index != 0)
				{
					this.UpdateCamera();
					this.UpdateSparkles();
					yield return UpdateResult.Next();
				}
				characterIndex = (characterIndex + 1) % 3;
				int animationIndex = this.GetAnimationIndexFromCharacter(characterIndex);
				this._animation.Index = animationIndex;
				while (this._animation.Index != animationIndex + 1)
				{
					this.UpdateCamera();
					this.UpdateSparkles();
					yield return UpdateResult.Next();
				}
				num = spins;
				spins = num + 1;
			}
			Rectanglei bounds = base.Level.Bounds;
			while (bounds.Bottom != this._targetCameraBottom)
			{
				bounds.Bottom = MathX.GoTowards(bounds.Bottom, this._targetCameraBottom, 6);
				base.Level.Bounds = bounds;
				yield return UpdateResult.Next();
			}
			yield return UpdateResult.Wait(80);
			base.Level.CompleteLevel();
			this._triggedEndGame = true;
			yield break;
		}

		// Token: 0x06000115 RID: 277 RVA: 0x00009755 File Offset: 0x00007955
		private int GetAnimationIndexFromCharacter(int character)
		{
			switch (character)
			{
			default:
				return 1;
			case 1:
				return 4;
			case 2:
				return 7;
			}
		}

		// Token: 0x06000116 RID: 278 RVA: 0x00009770 File Offset: 0x00007970
		private int GetProtagonistCharacterIndex()
		{
			CharacterType protagonistCharacterType = base.Level.Player.ProtagonistCharacterType;
			if (protagonistCharacterType == CharacterType.Sonic || protagonistCharacterType != CharacterType.Tails)
			{
				return 1;
			}
			return 2;
		}

		// Token: 0x06000117 RID: 279 RVA: 0x0000979C File Offset: 0x0000799C
		private void Activate(ICharacter character)
		{
			this._activated = true;
			this._targetCameraBottom = base.Position.Y + 340;
			Rectanglei bounds = base.Level.Bounds;
			bounds.Bottom = Math.Max(this._targetCameraBottom, (int)base.Level.Camera.Bounds.Bottom);
			base.Level.Bounds = bounds;
			base.Level.JustAboutToCompleteLevel();
			base.Level.SoundManager.PlaySound(this, base.Type.GetAbsolutePath("SONICORCA/SOUND/SIGNPOST"));
			(base.Entry.State as SignpostInstance).Activated = true;
		}

		// Token: 0x06000118 RID: 280 RVA: 0x00009850 File Offset: 0x00007A50
		private void UpdateCamera()
		{
			Rectanglei bounds = base.Level.Bounds;
			bounds.Bottom = MathX.GoTowards(bounds.Bottom, this._targetCameraBottom, 6);
			base.Level.Bounds = bounds;
		}

		// Token: 0x06000119 RID: 281 RVA: 0x00009890 File Offset: 0x00007A90
		private void UpdateSparkles()
		{
			this._sparkleDelay--;
			if (this._sparkleDelay <= 0)
			{
				this.CreateSparkles(SignpostInstance.SparklePositionOffsets[this._sparkleIndex]);
				this._sparkleDelay = 12;
				this._sparkleIndex = (this._sparkleIndex + 1) % SignpostInstance.SparklePositionOffsets.Length;
			}
		}

		// Token: 0x0600011A RID: 282 RVA: 0x000098E8 File Offset: 0x00007AE8
		private void CreateSparkles(Vector2i relativePosition)
		{
			Vector2i a = base.Position + relativePosition;
			int num = 0;
			foreach (Vector2i b in SignpostInstance.SparkleParticleOffsets)
			{
				ObjectPlacement objectPlacement = new ObjectPlacement(base.Type.GetAbsolutePath("SONICORCA/OBJECTS/RING/SPARKLE"), base.Level.Map.Layers.IndexOf(base.Layer), a + b);
				base.Level.SetInterval(num, delegate
				{
					this.Level.ObjectManager.AddObject(objectPlacement);
				});
				num += 2;
			}
		}

		// Token: 0x0600011B RID: 283 RVA: 0x000099A8 File Offset: 0x00007BA8
		protected override void OnAnimate()
		{
			this._animation.Animate();
		}

		// Token: 0x0600011C RID: 284 RVA: 0x000099B5 File Offset: 0x00007BB5
		protected override void OnDraw(Renderer renderer, LayerViewOptions viewOptions)
		{
			renderer.GetObjectRenderer().Render(this._animation, false, false);
		}

		// Token: 0x0400012D RID: 301
		private static readonly IReadOnlyList<Vector2i> SparkleParticleOffsets = new Vector2i[]
		{
			new Vector2i(16, 4),
			new Vector2i(-16, 12),
			new Vector2i(-12, -16),
			new Vector2i(20, -24)
		};

		// Token: 0x0400012E RID: 302
		private static Vector2i[] SparklePositionOffsets = new Vector2i[]
		{
			new Vector2i(-96, -64),
			new Vector2i(32, 32),
			new Vector2i(-64, 32),
			new Vector2i(96, -32),
			new Vector2i(0, -32),
			new Vector2i(64, 0),
			new Vector2i(-96, 32),
			new Vector2i(96, 16)
		};

		// Token: 0x0400012F RID: 303
		private const int AnimationSide = 0;

		// Token: 0x04000130 RID: 304
		private const int AnimationRobotnik = 1;

		// Token: 0x04000131 RID: 305
		private const int AnimationSonic = 4;

		// Token: 0x04000132 RID: 306
		private const int AnimationTails = 7;

		// Token: 0x04000133 RID: 307
		private const int OffsetToFront = 0;

		// Token: 0x04000134 RID: 308
		private const int OffsetFront = 1;

		// Token: 0x04000135 RID: 309
		private const int OffsetToSide = 2;

		// Token: 0x04000136 RID: 310
		private const int CharacterIndexRobotnik = 0;

		// Token: 0x04000137 RID: 311
		private const int CharacterIndexSonic = 1;

		// Token: 0x04000138 RID: 312
		private const int CharacterIndexTails = 2;

		// Token: 0x04000139 RID: 313
		private Updater _updater;

		// Token: 0x0400013A RID: 314
		private AnimationInstance _animation;

		// Token: 0x0400013B RID: 315
		private bool _activated;

		// Token: 0x0400013C RID: 316
		private bool _triggedEndGame;

		// Token: 0x0400013D RID: 317
		private int _sparkleIndex;

		// Token: 0x0400013E RID: 318
		private int _sparkleDelay;

		// Token: 0x0400013F RID: 319
		private int _targetCameraBottom;
	}
}
