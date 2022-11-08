using System;
using SonicOrca.Core;
using SonicOrca.Core.Collision;
using SonicOrca.Core.Objects;
using SonicOrca.Core.Objects.Metadata;
using SonicOrca.Extensions;
using SonicOrca.Geometry;
using SonicOrca.Graphics;

namespace SONICORCA.OBJECTS.MONITOR
{
	// Token: 0x02000024 RID: 36
	public class MonitorInstance : ActiveObject
	{
		// Token: 0x060000BB RID: 187 RVA: 0x000075F4 File Offset: 0x000057F4
		private static int GetScreenContentsAnimationIndex(MonitorContents contents, int character)
		{
			switch (contents)
			{
			case MonitorContents.Life:
				return 5 + character - 1;
			case MonitorContents.Ring:
				return 8;
			case MonitorContents.SpeedShoes:
				return 9 + character - 1;
			case MonitorContents.Barrier:
				return 11;
			case MonitorContents.Invincibility:
				return 12;
			case MonitorContents.Robotnik:
				return 7;
			case MonitorContents.SwapPlaces:
				return 13;
			}
			return 14;
		}

		// Token: 0x060000BC RID: 188 RVA: 0x00007647 File Offset: 0x00005847
		private static int GetContentsAnimationIndex(MonitorContents contents, int character)
		{
			return MonitorInstance.GetScreenContentsAnimationIndex(contents, character);
		}

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x060000BD RID: 189 RVA: 0x00007650 File Offset: 0x00005850
		// (set) Token: 0x060000BE RID: 190 RVA: 0x00007658 File Offset: 0x00005858
		[StateVariable]
		private MonitorContents Contents
		{
			get
			{
				return this._contents;
			}
			set
			{
				this._contents = value;
			}
		}

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x060000BF RID: 191 RVA: 0x00007661 File Offset: 0x00005861
		// (set) Token: 0x060000C0 RID: 192 RVA: 0x00007669 File Offset: 0x00005869
		[StateVariable]
		private bool Broken
		{
			get
			{
				return this._broken;
			}
			set
			{
				this._broken = value;
			}
		}

		// Token: 0x060000C1 RID: 193 RVA: 0x00007672 File Offset: 0x00005872
		public MonitorInstance()
		{
			base.DesignBounds = new Rectanglei(-60, -60, 120, 120);
		}

		// Token: 0x060000C2 RID: 194 RVA: 0x00007690 File Offset: 0x00005890
		protected override void OnStart()
		{
			this._stationary = true;
			AnimationGroup loadedResource = base.ResourceTree.GetLoadedResource<AnimationGroup>(base.Type, "/ANIGROUP");
			this._shellAnimation = new AnimationInstance(loadedResource, 0);
			this._shellOverlayAnimation = new AnimationInstance(loadedResource, 0);
			this._screenAnimation = new AnimationInstance(loadedResource, 0);
			this._screenOverlayAnimation = new AnimationInstance(loadedResource, 0);
			this._shellAnimation.Index = (this._broken ? 2 : 0);
			this._shellOverlayAnimation.Index = (this._broken ? 3 : 1);
			this._screenAnimation.Index = MonitorInstance.GetScreenContentsAnimationIndex(this._contents, (int)base.Level.Player.ProtagonistCharacterType);
			this._screenOverlayAnimation.Index = 4;
			if (!this._broken)
			{
				this._contentsAnimation = new AnimationInstance(loadedResource, 0);
				this._contentsAnimation.Index = MonitorInstance.GetContentsAnimationIndex(this._contents, (int)base.Level.Player.ProtagonistCharacterType);
				base.CollisionVectors = CollisionVector.FromRectangle(this, new Rectangle(-60.0, -60.0, 120.0, 120.0), uint.MaxValue, (CollisionFlags)0);
				base.CollisionVectors[3].Id = 1;
			}
		}

		// Token: 0x060000C3 RID: 195 RVA: 0x000077D4 File Offset: 0x000059D4
		protected override void OnUpdate()
		{
			if (!this._stationary)
			{
				base.PositionPrecise += this._velocity;
				bool flag = false;
				foreach (CollisionInfo collisionInfo in CollisionVector.GetCollisions(this, 60, uint.MaxValue))
				{
					if (collisionInfo.Vector.Owner == null && !collisionInfo.Vector.IsWall)
					{
						base.PositionPrecise = new Vector2(base.PositionPrecise.X, base.PositionPrecise.Y + collisionInfo.Shift);
						flag = true;
					}
				}
				if (flag)
				{
					base.Entry.Position = base.Position;
					this._stationary = true;
				}
				else
				{
					this._velocity += new Vector2(0.0, 0.875);
				}
			}
			if (this._raisingContents)
			{
				this._contentsPosition += this._contentsVelocity;
				this._contentsVelocity.Y = this._contentsVelocity.Y + 0.375;
				if (this._contentsVelocity.Y >= 0.0)
				{
					this._raisingContents = false;
					this.InvokeContents();
				}
			}
		}

		// Token: 0x060000C4 RID: 196 RVA: 0x00007930 File Offset: 0x00005B30
		protected override void OnCollision(CollisionEvent e)
		{
			if (e.ActiveObject.Type.Classification != ObjectClassification.Character)
			{
				return;
			}
			ICharacter character = (ICharacter)e.ActiveObject;
			if (e.Id == 1)
			{
				this._stationary = false;
				this._velocity.Y = -6.0;
				character.Velocity = new Vector2(character.Velocity.X, character.Velocity.Y * -1.0);
				e.MaintainVelocity = true;
				return;
			}
			if (this.CanCharacterBreak(character))
			{
				this.Break(character);
				e.IgnoreCollision = true;
			}
		}

		// Token: 0x060000C5 RID: 197 RVA: 0x000079D4 File Offset: 0x00005BD4
		private bool CanCharacterBreak(ICharacter character)
		{
			return character.Velocity.Y >= 0.0 && !character.IsSidekick && character.IsSpinball;
		}

		// Token: 0x060000C6 RID: 198 RVA: 0x00007A14 File Offset: 0x00005C14
		private void Break(ICharacter character)
		{
			this._breaker = character;
			character.Velocity = new Vector2(character.Velocity.X, character.Velocity.Y * -1.0);
			if (character.Jumped)
			{
				character.IsJumping = true;
			}
			this._broken = true;
			(base.Entry.State as MonitorInstance).Broken = true;
			this._shellAnimation.Index = 2;
			this._shellOverlayAnimation.Index = 3;
			base.CollisionVectors = new CollisionVector[0];
			base.CollisionRectangles = new CollisionRectangle[0];
			base.RegisterCollisionUpdate();
			this.CreateExplosionObject();
			this.CreateRaisingContents();
			base.LockLifetime = true;
		}

		// Token: 0x060000C7 RID: 199 RVA: 0x00007AD0 File Offset: 0x00005CD0
		private void CreateExplosionObject()
		{
			base.Level.ObjectManager.AddObject(new ObjectPlacement(base.Type.GetAbsolutePath("SONICORCA/OBJECTS/EXPLOSION/BADNIK"), base.Level.Map.Layers.IndexOf(base.Layer), base.Position));
		}

		// Token: 0x060000C8 RID: 200 RVA: 0x00007B24 File Offset: 0x00005D24
		private void CreateRaisingContents()
		{
			this._contentsVelocity = new Vector2(0.0, -12.0);
			this._contentsPosition = new Vector2(0.0, -13.0);
			this._raisingContents = true;
		}

		// Token: 0x060000C9 RID: 201 RVA: 0x00007B74 File Offset: 0x00005D74
		private void InvokeContents()
		{
			base.LockLifetime = false;
			switch (this._contents)
			{
			case MonitorContents.None:
			case MonitorContents.Robotnik:
			case MonitorContents.SwapPlaces:
			case MonitorContents.Random:
				break;
			case MonitorContents.Life:
				this._breaker.Player.GainLives(1);
				return;
			case MonitorContents.Ring:
				this._breaker.Player.GainRings(10);
				base.Level.SoundManager.PlaySound(this._breaker, "SONICORCA/SOUND/RING");
				return;
			case MonitorContents.SpeedShoes:
				this._breaker.Player.GiveSpeedShoes();
				return;
			case MonitorContents.Barrier:
				this._breaker.Player.GiveBarrier(BarrierType.Classic);
				base.Level.SoundManager.PlaySound(this._breaker, "SONICORCA/SOUND/BARRIER");
				return;
			case MonitorContents.Invincibility:
				this._breaker.Player.GiveInvincibility();
				break;
			default:
				return;
			}
		}

		// Token: 0x060000CA RID: 202 RVA: 0x00007C48 File Offset: 0x00005E48
		protected override void OnAnimate()
		{
			this._shellAnimation.Animate();
			this._shellOverlayAnimation.Animate();
			if (!this._broken)
			{
				this._screenAnimation.Animate();
				this._screenOverlayAnimation.Animate();
			}
			if (this._raisingContents)
			{
				this._contentsAnimation.Animate();
			}
		}

		// Token: 0x060000CB RID: 203 RVA: 0x00007C9C File Offset: 0x00005E9C
		protected override void OnDraw(Renderer renderer, LayerViewOptions viewOptions)
		{
			IObjectRenderer objectRenderer = renderer.GetObjectRenderer();
			objectRenderer.Render(this._shellAnimation, false, false);
			if (!viewOptions.Shadows)
			{
				objectRenderer.FilterAmount *= 0.25;
				if (!this._broken)
				{
					objectRenderer.Render(this._screenAnimation, new Vector2(2.0, -10.0), false, false);
					objectRenderer.Render(this._screenOverlayAnimation, new Vector2(0.0, -13.0), false, false);
				}
				objectRenderer.Render(this._shellOverlayAnimation, false, false);
				if (this._raisingContents)
				{
					objectRenderer.Render(this._contentsAnimation, this._contentsPosition, false, false);
				}
			}
		}

		// Token: 0x040000CE RID: 206
		private const int AnimationShell = 0;

		// Token: 0x040000CF RID: 207
		private const int AnimationShellOverlay = 1;

		// Token: 0x040000D0 RID: 208
		private const int AnimationBrokenShell = 2;

		// Token: 0x040000D1 RID: 209
		private const int AnimationBrokenShellOverlay = 3;

		// Token: 0x040000D2 RID: 210
		private const int AnimationScreenOverlay = 4;

		// Token: 0x040000D3 RID: 211
		private const int AnimationScreenContentsLifeSonic = 5;

		// Token: 0x040000D4 RID: 212
		private const int AnimationScreenContentsLifeTails = 6;

		// Token: 0x040000D5 RID: 213
		private const int AnimationScreenContentsRobotnik = 7;

		// Token: 0x040000D6 RID: 214
		private const int AnimationScreenContentsRing = 8;

		// Token: 0x040000D7 RID: 215
		private const int AnimationScreenContentsSpeedShoesSonic = 9;

		// Token: 0x040000D8 RID: 216
		private const int AnimationScreenContentsSpeedShoesTails = 10;

		// Token: 0x040000D9 RID: 217
		private const int AnimationScreenContentsBarrier = 11;

		// Token: 0x040000DA RID: 218
		private const int AnimationScreenContentsInvincibility = 12;

		// Token: 0x040000DB RID: 219
		private const int AnimationScreenContentsSwapPlaces = 13;

		// Token: 0x040000DC RID: 220
		private const int AnimationScreenContentsRandom = 14;

		// Token: 0x040000DD RID: 221
		private const int AnimationContentsLifeSonic = 15;

		// Token: 0x040000DE RID: 222
		private const int AnimationContentsLifeTails = 16;

		// Token: 0x040000DF RID: 223
		private const int AnimationContentsRobotnik = 17;

		// Token: 0x040000E0 RID: 224
		private const int AnimationContentsRing = 18;

		// Token: 0x040000E1 RID: 225
		private const int AnimationContentsSpeedShoesSonic = 19;

		// Token: 0x040000E2 RID: 226
		private const int AnimationContentsSpeedShoesTails = 20;

		// Token: 0x040000E3 RID: 227
		private const int AnimationContentsBarrier = 21;

		// Token: 0x040000E4 RID: 228
		private const int AnimationContentsInvincibility = 22;

		// Token: 0x040000E5 RID: 229
		private const int AnimationContentsSwapPlaces = 23;

		// Token: 0x040000E6 RID: 230
		private const int AnimationContentsRandom = 24;

		// Token: 0x040000E7 RID: 231
		private MonitorContents _contents;

		// Token: 0x040000E8 RID: 232
		private bool _broken;

		// Token: 0x040000E9 RID: 233
		private AnimationInstance _shellAnimation;

		// Token: 0x040000EA RID: 234
		private AnimationInstance _shellOverlayAnimation;

		// Token: 0x040000EB RID: 235
		private AnimationInstance _screenAnimation;

		// Token: 0x040000EC RID: 236
		private AnimationInstance _screenOverlayAnimation;

		// Token: 0x040000ED RID: 237
		private bool _stationary;

		// Token: 0x040000EE RID: 238
		private Vector2 _velocity;

		// Token: 0x040000EF RID: 239
		private AnimationInstance _contentsAnimation;

		// Token: 0x040000F0 RID: 240
		private Vector2 _contentsVelocity;

		// Token: 0x040000F1 RID: 241
		private Vector2 _contentsPosition;

		// Token: 0x040000F2 RID: 242
		private bool _raisingContents;

		// Token: 0x040000F3 RID: 243
		private ICharacter _breaker;
	}
}
