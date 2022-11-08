using System;
using System.Linq;
using SonicOrca.Core;
using SonicOrca.Core.Collision;
using SonicOrca.Core.Objects.Metadata;
using SonicOrca.Geometry;
using SonicOrca.Graphics;

namespace SONICORCA.OBJECTS.CAPSULE
{
	// Token: 0x0200003B RID: 59
	public class CapsuleInstance : ActiveObject
	{
		// Token: 0x17000027 RID: 39
		// (get) Token: 0x0600012F RID: 303 RVA: 0x0000A33B File Offset: 0x0000853B
		// (set) Token: 0x06000130 RID: 304 RVA: 0x0000A343 File Offset: 0x00008543
		[StateVariable]
		private bool Unlocked
		{
			get
			{
				return this._unlocked;
			}
			set
			{
				this._unlocked = value;
			}
		}

		// Token: 0x06000131 RID: 305 RVA: 0x0000A34C File Offset: 0x0000854C
		public CapsuleInstance()
		{
			base.DesignBounds = new Rectanglei(-128, -160, 256, 320);
		}

		// Token: 0x06000132 RID: 306 RVA: 0x0000A370 File Offset: 0x00008570
		protected override void OnStart()
		{
			AnimationGroup loadedResource = base.ResourceTree.GetLoadedResource<AnimationGroup>(base.Type, "/ANIGROUP");
			this._animationButton = new AnimationInstance(loadedResource, 7);
			this._animationMain = new AnimationInstance(loadedResource, 0);
			if ((base.Entry.State as CapsuleInstance).Unlocked)
			{
				this._buttonPressed = true;
				this._doorOpened = true;
				this._animationLights = null;
				this._animationDoorLights = null;
			}
			else
			{
				this._animationLights = new AnimationInstance(loadedResource, 1);
				this._animationDoor = new AnimationInstance(loadedResource, 2);
				this._animationDoorLights = new AnimationInstance(loadedResource, 4);
				this._animationMiddle = new AnimationInstance(loadedResource, 5);
			}
			this._lock = base.Level.ObjectManager.AddSubObject<CapsuleInstance.Lock>(this);
			this._lock.Position = base.Position + new Vector2i(0, -46);
			this._lock.LockLifetime = true;
			CollisionVector[] array = CollisionVector.FromRectangle(this, new Rectanglei(-64, this._buttonY - 158, 128, 64), uint.MaxValue, (CollisionFlags)0);
			array[1].Flags = CollisionFlags.Conveyor;
			base.CollisionVectors = new CollisionVector[]
			{
				new CollisionVector(this, new Vector2i(-128, -42), new Vector2i(-100, -64), uint.MaxValue, (CollisionFlags)0),
				new CollisionVector(this, new Vector2i(-100, -64), new Vector2i(-64, -82), uint.MaxValue, (CollisionFlags)0),
				new CollisionVector(this, new Vector2i(-64, -82), new Vector2i(-28, -94), uint.MaxValue, (CollisionFlags)0),
				new CollisionVector(this, new Vector2i(-28, -94), new Vector2i(28, -94), uint.MaxValue, (CollisionFlags)0),
				new CollisionVector(this, new Vector2i(28, -94), new Vector2i(64, -82), uint.MaxValue, (CollisionFlags)0),
				new CollisionVector(this, new Vector2i(64, -82), new Vector2i(100, -64), uint.MaxValue, (CollisionFlags)0),
				new CollisionVector(this, new Vector2i(100, -64), new Vector2i(128, -42), uint.MaxValue, (CollisionFlags)0),
				new CollisionVector(this, new Vector2i(128, -42), new Vector2i(128, 160), uint.MaxValue, (CollisionFlags)0),
				new CollisionVector(this, new Vector2i(128, 160), new Vector2i(-128, 160), uint.MaxValue, (CollisionFlags)0),
				new CollisionVector(this, new Vector2i(-128, 160), new Vector2i(-128, -42), uint.MaxValue, (CollisionFlags)0)
			}.Concat(array).ToArray<CollisionVector>();
			for (int i = 0; i < 10; i++)
			{
				base.CollisionVectors[i].Flags |= CollisionFlags.NoAngle;
			}
			base.CollisionVectors[7].Flags |= CollisionFlags.NoPathFollowing;
			base.CollisionVectors[9].Flags |= CollisionFlags.NoPathFollowing;
		}

		// Token: 0x06000133 RID: 307 RVA: 0x0000A630 File Offset: 0x00008830
		protected override void OnStop()
		{
			if (!this._buttonPressed)
			{
				this._lock.Finish();
			}
		}

		// Token: 0x06000134 RID: 308 RVA: 0x0000A645 File Offset: 0x00008845
		protected override void OnUpdate()
		{
			this.UpdateButton();
			this.UpdateDoor();
			this.UpdateButtonCollision();
		}

		// Token: 0x06000135 RID: 309 RVA: 0x0000A65C File Offset: 0x0000885C
		private void UpdateButtonCollision()
		{
			Vector2i b = new Vector2i(0, this._buttonY - this._lastButtonY);
			for (int i = 10; i < 14; i++)
			{
				CollisionVector collisionVector = base.CollisionVectors[i];
				collisionVector.RelativeA += b;
				collisionVector.RelativeB += b;
			}
		}

		// Token: 0x06000136 RID: 310 RVA: 0x0000A6B8 File Offset: 0x000088B8
		private void UpdateButton()
		{
			this._lastButtonY = this._buttonY;
			if (base.Level.ObjectManager.IsCharacterStandingOn(base.CollisionVectors[11]))
			{
				int num = this._buttonY;
				this._buttonY = Math.Min(this._buttonY + 8, 24);
				num = this._buttonY - num;
				if (this._buttonY == 24 && !this._buttonPressed)
				{
					this.OnButtonPress();
					return;
				}
			}
			else
			{
				this._buttonY = Math.Max(0, this._buttonY - 8);
			}
		}

		// Token: 0x06000137 RID: 311 RVA: 0x0000A740 File Offset: 0x00008940
		private void OnButtonPress()
		{
			base.Level.JustAboutToCompleteLevel();
			(base.Entry.State as CapsuleInstance).Unlocked = true;
			this._animationLights = null;
			this._animationDoorLights = null;
			this._lock.Break();
			this._lock.LockLifetime = false;
			this._buttonPressed = true;
			this._openDoorDelay = 60;
			base.LockLifetime = true;
		}

		// Token: 0x06000138 RID: 312 RVA: 0x0000A7AC File Offset: 0x000089AC
		private void UpdateDoor()
		{
			if (!this._doorOpened)
			{
				if (this._buttonPressed && this._openDoorDelay > 0)
				{
					this._openDoorDelay--;
					if (this._openDoorDelay == 0)
					{
						this.OpenDoor();
						return;
					}
				}
			}
			else if (this._completeLevelDelay > 0)
			{
				this._completeLevelDelay--;
				if (this._completeLevelDelay == 0)
				{
					base.Level.CompleteLevel();
					base.LockLifetime = false;
				}
			}
		}

		// Token: 0x06000139 RID: 313 RVA: 0x0000A820 File Offset: 0x00008A20
		private void OpenDoor()
		{
			this._doorOpened = true;
			this._animationDoor.Index = 3;
			this._animationMiddle.Index = 6;
			this._animationDoor.Cycles = 0;
			this._animationMiddle.Cycles = 0;
			this.CreateAnimals();
		}

		// Token: 0x0600013A RID: 314 RVA: 0x0000A860 File Offset: 0x00008A60
		private void CreateAnimals()
		{
			int[] array = (from x in Enumerable.Range(0, 32)
			select (int)((double)x * 6.0) - 96 into x
			orderby base.Level.Random.Next()
			select x).ToArray<int>();
			int num = 60;
			for (int i = 0; i < 32; i++)
			{
				Vector2i b = new Vector2i(array[i], 32);
				base.Level.CreateRandomAnimalObject(base.Level.Map.Layers.IndexOf(base.Layer), base.Position + b, (b.X <= 0) ? -1 : 1, num);
				num += base.Level.Random.Next(5, 10);
			}
			this._completeLevelDelay = num + 120;
		}

		// Token: 0x0600013B RID: 315 RVA: 0x0000A930 File Offset: 0x00008B30
		protected override void OnAnimate()
		{
			this._animationButton.Animate();
			this._animationMain.Animate();
			if (this._animationLights != null)
			{
				this._animationLights.Animate();
			}
			if (this._animationDoor != null)
			{
				this._animationDoor.Animate();
			}
			if (this._animationDoorLights != null)
			{
				this._animationDoorLights.Animate();
			}
			if (this._animationMiddle != null)
			{
				this._animationMiddle.Animate();
			}
		}

		// Token: 0x0600013C RID: 316 RVA: 0x0000A9A0 File Offset: 0x00008BA0
		protected override void OnDraw(Renderer renderer, LayerViewOptions viewOptions)
		{
			IObjectRenderer objectRenderer = renderer.GetObjectRenderer();
			objectRenderer.Render(this._animationButton, new Vector2(0.0, (double)(-128 + this._buttonY)), false, false);
			objectRenderer.Render(this._animationMain, false, false);
			if (!viewOptions.Shadows && this._animationLights != null)
			{
				objectRenderer.Render(this._animationLights, false, false);
			}
			if ((this._animationDoor != null && this._animationDoor.Cycles == 0) || !this._doorOpened)
			{
				objectRenderer.Render(this._animationDoor, new Vector2(0.0, 16.0), false, false);
			}
			if (!viewOptions.Shadows && this._animationDoorLights != null)
			{
				objectRenderer.EmitsLight = true;
				objectRenderer.Render(this._animationDoorLights, new Vector2(0.0, 16.0), false, false);
				objectRenderer.EmitsLight = false;
			}
			if ((this._animationMiddle != null && this._animationMiddle.Cycles == 0) || !this._doorOpened)
			{
				objectRenderer.Render(this._animationMiddle, new Vector2(0.0, 16.0), false, false);
			}
		}

		// Token: 0x04000155 RID: 341
		private const int AnimationMain = 0;

		// Token: 0x04000156 RID: 342
		private const int AnimationLights = 1;

		// Token: 0x04000157 RID: 343
		private const int AnimationDoor = 2;

		// Token: 0x04000158 RID: 344
		private const int AnimationDoorOpening = 3;

		// Token: 0x04000159 RID: 345
		private const int AnimationDoorLights = 4;

		// Token: 0x0400015A RID: 346
		private const int AnimationMiddle = 5;

		// Token: 0x0400015B RID: 347
		private const int AnimationMiddleOpening = 6;

		// Token: 0x0400015C RID: 348
		private const int AnimationButton = 7;

		// Token: 0x0400015D RID: 349
		private const int AnimationLock = 8;

		// Token: 0x0400015E RID: 350
		private const int AnimationLockLight = 9;

		// Token: 0x0400015F RID: 351
		private const int AnimationLockBroken = 10;

		// Token: 0x04000160 RID: 352
		private AnimationInstance _animationButton;

		// Token: 0x04000161 RID: 353
		private AnimationInstance _animationMain;

		// Token: 0x04000162 RID: 354
		private AnimationInstance _animationLights;

		// Token: 0x04000163 RID: 355
		private AnimationInstance _animationDoor;

		// Token: 0x04000164 RID: 356
		private AnimationInstance _animationDoorLights;

		// Token: 0x04000165 RID: 357
		private AnimationInstance _animationMiddle;

		// Token: 0x04000166 RID: 358
		private int _lastButtonY;

		// Token: 0x04000167 RID: 359
		private int _buttonY;

		// Token: 0x04000168 RID: 360
		private bool _buttonPressed;

		// Token: 0x04000169 RID: 361
		private CapsuleInstance.Lock _lock;

		// Token: 0x0400016A RID: 362
		private bool _doorOpened;

		// Token: 0x0400016B RID: 363
		private int _openDoorDelay;

		// Token: 0x0400016C RID: 364
		private int _completeLevelDelay;

		// Token: 0x0400016D RID: 365
		private bool _unlocked;

		// Token: 0x020000D0 RID: 208
		private class Lock : ActiveObject
		{
			// Token: 0x06000507 RID: 1287 RVA: 0x00020044 File Offset: 0x0001E244
			protected override void OnStart()
			{
				AnimationGroup loadedResource = base.ResourceTree.GetLoadedResource<AnimationGroup>(base.Type, "/ANIGROUP");
				this._animation = new AnimationInstance(loadedResource, 8);
				this._animationLight = new AnimationInstance(loadedResource, 9);
			}

			// Token: 0x06000508 RID: 1288 RVA: 0x00020084 File Offset: 0x0001E284
			protected override void OnUpdate()
			{
				base.OnUpdate();
				if (this._broken)
				{
					base.PositionPrecise += this._velocity;
					this._velocity += new Vector2(0.0, 0.875);
				}
			}

			// Token: 0x06000509 RID: 1289 RVA: 0x000200DE File Offset: 0x0001E2DE
			public void Break()
			{
				this._broken = true;
				this._animation.Index = 10;
				this.CreateExplosionObject();
			}

			// Token: 0x0600050A RID: 1290 RVA: 0x000200FC File Offset: 0x0001E2FC
			private void CreateExplosionObject()
			{
				base.Level.ObjectManager.AddObject(new ObjectPlacement(base.Level.CommonResources.GetResourcePath("badnikexplosionobject"), base.Level.Map.Layers.IndexOf(base.Layer), base.Position));
			}

			// Token: 0x0600050B RID: 1291 RVA: 0x00020155 File Offset: 0x0001E355
			protected override void OnAnimate()
			{
				this._animation.Animate();
				this._animationLight.Animate();
				if (this._broken)
				{
					this._rotation += 0.09817477042468103;
				}
			}

			// Token: 0x0600050C RID: 1292 RVA: 0x0002018C File Offset: 0x0001E38C
			protected override void OnDraw(Renderer renderer, LayerViewOptions viewOptions)
			{
				IObjectRenderer objectRenderer = renderer.GetObjectRenderer();
				using (objectRenderer.BeginMatixState())
				{
					if (this._rotation != 0.0)
					{
						objectRenderer.ModelMatrix = objectRenderer.ModelMatrix.RotateZ(this._rotation);
					}
					objectRenderer.Render(this._animation, new Vector2i(-2, 0), false, false);
					if (!viewOptions.Shadows && !this._broken)
					{
						objectRenderer.EmitsLight = true;
						objectRenderer.Render(this._animationLight, new Vector2i(-2, 0), false, false);
					}
				}
			}

			// Token: 0x040005A2 RID: 1442
			private AnimationInstance _animation;

			// Token: 0x040005A3 RID: 1443
			private AnimationInstance _animationLight;

			// Token: 0x040005A4 RID: 1444
			private Vector2 _velocity = new Vector2(32.0, -16.0);

			// Token: 0x040005A5 RID: 1445
			private double _rotation;

			// Token: 0x040005A6 RID: 1446
			private bool _broken;
		}
	}
}
