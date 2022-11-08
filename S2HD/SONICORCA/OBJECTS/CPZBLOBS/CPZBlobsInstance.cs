using System;
using System.Collections.Generic;
using System.Linq;
using SonicOrca.Core;
using SonicOrca.Core.Collision;
using SonicOrca.Core.Objects.Base;
using SonicOrca.Core.Objects.Metadata;
using SonicOrca.Extensions;
using SonicOrca.Geometry;
using SonicOrca.Graphics;

namespace SONICORCA.OBJECTS.CPZBLOBS
{
	// Token: 0x0200007F RID: 127
	public class CPZBlobsInstance : ActiveObject
	{
		// Token: 0x17000048 RID: 72
		// (get) Token: 0x0600028B RID: 651 RVA: 0x000126B9 File Offset: 0x000108B9
		// (set) Token: 0x0600028C RID: 652 RVA: 0x000126C1 File Offset: 0x000108C1
		[StateVariable]
		private CPZBlobsInstance.ArrangementType Arrangement
		{
			get
			{
				return this._arrangementType;
			}
			set
			{
				this._arrangementType = value;
			}
		}

		// Token: 0x17000049 RID: 73
		// (get) Token: 0x0600028D RID: 653 RVA: 0x000126CA File Offset: 0x000108CA
		// (set) Token: 0x0600028E RID: 654 RVA: 0x000126D2 File Offset: 0x000108D2
		[StateVariable]
		private bool FlipX { get; set; }

		// Token: 0x0600028F RID: 655 RVA: 0x000126DC File Offset: 0x000108DC
		protected override void OnStart()
		{
			this._animationGroup = base.ResourceTree.GetLoadedResource<AnimationGroup>(base.Type.GetAbsolutePath("/ANIGROUP"));
			base.DesignBounds = new Rectanglei(-128, -128, 256, 256);
			this._children = new CPZBlobsInstance.Blob[6];
			for (int i = 5; i >= 0; i--)
			{
				CPZBlobsInstance.Blob blob = base.Level.ObjectManager.AddSubObject<CPZBlobsInstance.Blob>(this);
				blob.Initialise(base.Position, i, this.FlipX);
				this._children[i] = blob;
				this._children[i].Priority = i + 2;
			}
		}

		// Token: 0x06000290 RID: 656 RVA: 0x0000FD87 File Offset: 0x0000DF87
		protected override void OnUpdate()
		{
		}

		// Token: 0x1700004A RID: 74
		// (get) Token: 0x06000291 RID: 657 RVA: 0x00012779 File Offset: 0x00010979
		[HideInEditor]
		public List<AnimationInstance> BottomStartOverflowTriggeredAnimations
		{
			get
			{
				return this._bottomStartOverflowTriggeredAnimations;
			}
		}

		// Token: 0x1700004B RID: 75
		// (get) Token: 0x06000292 RID: 658 RVA: 0x00012781 File Offset: 0x00010981
		[HideInEditor]
		public Dictionary<AnimationInstance, Vector2> TriggeredAnimationsPositions
		{
			get
			{
				return this._triggeredAnimationsPositions;
			}
		}

		// Token: 0x1700004C RID: 76
		// (get) Token: 0x06000293 RID: 659 RVA: 0x00012789 File Offset: 0x00010989
		[HideInEditor]
		public Dictionary<AnimationInstance, Vector2> TriggeredAnimations
		{
			get
			{
				return this._triggeredAnimations;
			}
		}

		// Token: 0x06000294 RID: 660 RVA: 0x00012794 File Offset: 0x00010994
		protected override void OnDraw(Renderer renderer, LayerViewOptions viewOptions)
		{
			base.OnDraw(renderer, viewOptions);
			IObjectRenderer objectRenderer = renderer.GetObjectRenderer();
			List<AnimationInstance> list = new List<AnimationInstance>();
			foreach (KeyValuePair<AnimationInstance, Vector2> keyValuePair in this.TriggeredAnimations)
			{
				keyValuePair.Key.Animate();
				if (keyValuePair.Key.Cycles > 0)
				{
					list.Add(keyValuePair.Key);
				}
			}
			foreach (AnimationInstance animationInstance in list)
			{
				animationInstance.ResetFrame();
				animationInstance.Cycles = 0;
				if (animationInstance.Index == 4 || this.BottomStartOverflowTriggeredAnimations.Contains(animationInstance))
				{
					CPZBlobsInstance.OverflowInstance overflowInstance = base.Level.ObjectManager.AddSubObject<CPZBlobsInstance.OverflowInstance>(this);
					overflowInstance.InitOverflow();
					overflowInstance.Layer = base.Level.Map.Layers.Last<LevelLayer>();
					Vector2 vector = this.TriggeredAnimationsPositions[animationInstance];
					if (this.BottomStartOverflowTriggeredAnimations.Contains(animationInstance))
					{
						if (this._arrangementType == CPZBlobsInstance.ArrangementType.Arc)
						{
							overflowInstance.PositionPrecise = new Vector2(vector.X, vector.Y - 40.0);
						}
						else
						{
							overflowInstance.PositionPrecise = new Vector2(vector.X, vector.Y - 40.0);
						}
					}
					else if (this._arrangementType == CPZBlobsInstance.ArrangementType.Arc)
					{
						overflowInstance.PositionPrecise = new Vector2(vector.X, vector.Y - 15.0);
					}
					else
					{
						overflowInstance.PositionPrecise = new Vector2(vector.X, vector.Y - 23.0);
					}
				}
				if (this.BottomStartOverflowTriggeredAnimations.Contains(animationInstance))
				{
					this.BottomStartOverflowTriggeredAnimations.Remove(animationInstance);
				}
				this.TriggeredAnimations.Remove(animationInstance);
				this.TriggeredAnimationsPositions.Remove(animationInstance);
			}
			foreach (KeyValuePair<AnimationInstance, Vector2> keyValuePair2 in this.TriggeredAnimations)
			{
				Vector2 a = this.TriggeredAnimationsPositions[keyValuePair2.Key];
				objectRenderer.Render(keyValuePair2.Key, a - base.PositionPrecise + keyValuePair2.Value, false, false);
			}
		}

		// Token: 0x040002E2 RID: 738
		private const int AnimationBlob = 0;

		// Token: 0x040002E3 RID: 739
		private const int AnimationTopSplashStart = 1;

		// Token: 0x040002E4 RID: 740
		private const int AnimationTopSplashEnd = 2;

		// Token: 0x040002E5 RID: 741
		private const int AnimationBottomSplashStart = 3;

		// Token: 0x040002E6 RID: 742
		private const int AnimationBottomSplashEnd = 4;

		// Token: 0x040002E7 RID: 743
		private const int AnimationBottomOverflow = 5;

		// Token: 0x040002E8 RID: 744
		private AnimationGroup _animationGroup;

		// Token: 0x040002E9 RID: 745
		private CPZBlobsInstance.ArrangementType _arrangementType;

		// Token: 0x040002EB RID: 747
		private CPZBlobsInstance.Blob[] _children;

		// Token: 0x040002EC RID: 748
		private List<AnimationInstance> _bottomStartOverflowTriggeredAnimations = new List<AnimationInstance>();

		// Token: 0x040002ED RID: 749
		private Dictionary<AnimationInstance, Vector2> _triggeredAnimations = new Dictionary<AnimationInstance, Vector2>();

		// Token: 0x040002EE RID: 750
		private Dictionary<AnimationInstance, Vector2> _triggeredAnimationsPositions = new Dictionary<AnimationInstance, Vector2>();

		// Token: 0x020000EE RID: 238
		private enum ArrangementType
		{
			// Token: 0x04000631 RID: 1585
			Arc,
			// Token: 0x04000632 RID: 1586
			Straight
		}

		// Token: 0x020000EF RID: 239
		private class Blob : Enemy
		{
			// Token: 0x170000EC RID: 236
			// (get) Token: 0x060005D1 RID: 1489 RVA: 0x000228E6 File Offset: 0x00020AE6
			// (set) Token: 0x060005D2 RID: 1490 RVA: 0x000228EE File Offset: 0x00020AEE
			public int Delay { get; set; }

			// Token: 0x170000ED RID: 237
			// (get) Token: 0x060005D3 RID: 1491 RVA: 0x000228F7 File Offset: 0x00020AF7
			public CPZBlobsInstance Host
			{
				get
				{
					return base.ParentObject as CPZBlobsInstance;
				}
			}

			// Token: 0x170000EE RID: 238
			// (get) Token: 0x060005D4 RID: 1492 RVA: 0x00022904 File Offset: 0x00020B04
			public Vector2 Velocity
			{
				get
				{
					return this._velocity;
				}
			}

			// Token: 0x060005D5 RID: 1493 RVA: 0x0002290C File Offset: 0x00020B0C
			protected override void OnStart()
			{
				base.OnStart();
				this._animationBlob = new AnimationInstance(this.Host._animationGroup, 0);
				this._animationTopSplashStart = new AnimationInstance(this.Host._animationGroup, 1);
				this._animationTopSplashEnd = new AnimationInstance(this.Host._animationGroup, 2);
				this._animationBottomSplashStart = new AnimationInstance(this.Host._animationGroup, 3);
				this._animationBottomSplashEnd = new AnimationInstance(this.Host._animationGroup, 4);
				this._animationBottomOverflow = new AnimationInstance(this.Host._animationGroup, 5);
				base.Priority = -128;
				base.CollisionRectangles = new CollisionRectangle[]
				{
					new CollisionRectangle(this, 0, -16, -16, 32, 32)
				};
			}

			// Token: 0x060005D6 RID: 1494 RVA: 0x000229D0 File Offset: 0x00020BD0
			public void Initialise(Vector2i position, int index, bool flipX)
			{
				this._index = index;
				if (this.Host._arrangementType == CPZBlobsInstance.ArrangementType.Arc)
				{
					this._upVelocity = -17.55;
				}
				else
				{
					this._upVelocity = -9.0;
				}
				this._velocity = new Vector2(0.0, this._upVelocity);
				base.Position = position;
				if (this.Host._arrangementType == CPZBlobsInstance.ArrangementType.Arc)
				{
					this._originalY = position.Y + 8;
				}
				else
				{
					this._originalY = position.Y;
				}
				if (flipX)
				{
					this._leftToRight = false;
					this._upX = position.X;
					this._downX = position.X + 384;
					this._currentAngle = 3.141592653589793;
				}
				else
				{
					this._leftToRight = true;
					this._upX = position.X + 384;
					this._downX = position.X;
					this._currentAngle = 0.0;
				}
				if (this.Host._arrangementType == CPZBlobsInstance.ArrangementType.Arc)
				{
					this.Delay = index * 5;
				}
				else
				{
					this.Delay = index * 4;
				}
				base.LockLifetime = true;
			}

			// Token: 0x060005D7 RID: 1495 RVA: 0x00022AF8 File Offset: 0x00020CF8
			protected override void OnUpdate()
			{
				base.OnUpdate();
				if (this.Host.Finished)
				{
					base.Finish();
					return;
				}
				if (this.Delay > 0)
				{
					int delay = this.Delay;
					this.Delay = delay - 1;
					return;
				}
				if (this.Host._arrangementType == CPZBlobsInstance.ArrangementType.Arc)
				{
					this.UpdateArc();
					return;
				}
				this.UpdateStraight();
			}

			// Token: 0x060005D8 RID: 1496 RVA: 0x00022B54 File Offset: 0x00020D54
			private void UpdateArc()
			{
				if (this.Host._arrangementType == CPZBlobsInstance.ArrangementType.Arc)
				{
					this.ArcPrepareTriggers();
				}
				if (this._leftToRight && this._currentAngle <= 0.0)
				{
					this.PlayGloopSound();
				}
				if (!this._leftToRight && this._currentAngle >= 3.141592653589793)
				{
					this.PlayGloopSound();
				}
				Vector2 relative = new Vector2((double)(this._downX + this._upX) * 0.5, (double)this._originalY);
				double num = Vector2.GetDistance(new Vector2((double)this._downX, 0.0), new Vector2((double)this._upX, 0.0)) * 0.5;
				double x = relative.X - num;
				if (this._leftToRight)
				{
					this._currentAngle += 0.03193952531149623;
				}
				else
				{
					this._currentAngle -= 0.03193952531149623;
				}
				base.PositionPrecise += this._velocity;
				if (this._leftToRight)
				{
					Vector2 point = new Vector2(x, (double)this._originalY);
					base.PositionPrecise = new Vector2(Vector2.GetPointRotatedFromRelative(relative, point, this._currentAngle).X, base.PositionPrecise.Y);
				}
				else
				{
					Vector2 point2 = new Vector2(x, (double)this._originalY);
					base.PositionPrecise = new Vector2(Vector2.GetPointRotatedFromRelative(relative, point2, this._currentAngle).X, base.PositionPrecise.Y);
				}
				this._velocity.Y = this._velocity.Y + 0.375;
				if (base.PositionPrecise.Y >= (double)this._originalY && !this._directionChange)
				{
					this._directionChange = true;
					this.Delay = 72;
				}
				if (this._directionChange)
				{
					this._velocity.Y = this._upVelocity;
					this._directionChange = false;
					this._leftToRight = !this._leftToRight;
					if (this._leftToRight)
					{
						this._currentAngle = 0.0;
					}
					if (!this._leftToRight)
					{
						this._currentAngle = 3.141592653589793;
					}
					base.PositionPrecise = new Vector2((double)(this._leftToRight ? this._downX : this._upX), (double)this._originalY);
				}
			}

			// Token: 0x060005D9 RID: 1497 RVA: 0x00022DC4 File Offset: 0x00020FC4
			private void UpdateStraight()
			{
				base.PositionPrecise += this._velocity;
				if (this._directionChange)
				{
					this._velocity.Y = this._upVelocity * (double)this._directionChangeNormal;
					this._directionChange = false;
				}
				if (base.Position.Y > this._originalY && this._velocity.Y > 0.0)
				{
					this.PlayGloopSound();
					this.Delay = 72;
					this._directionChange = true;
					this._velocity.Y = 0.0;
					this._directionChangeNormal = 1;
				}
				else if (base.Position.Y < this._originalY - 324 && this._velocity.Y < 0.0)
				{
					this.PlayGloopSound();
					this.Delay = 9;
					this._directionChange = true;
					this._velocity.Y = 0.0;
					this._directionChangeNormal = -1;
				}
				base.PositionPrecise = new Vector2((double)((this._velocity.Y >= 0.0) ? this._downX : this._upX), base.PositionPrecise.Y);
			}

			// Token: 0x060005DA RID: 1498 RVA: 0x00022F0E File Offset: 0x0002110E
			private void PlayGloopSound()
			{
				base.Level.SoundManager.PlaySoundVisibleOnly("SONICORCA/SOUND/BLOB", base.Position);
			}

			// Token: 0x060005DB RID: 1499 RVA: 0x00022F2B File Offset: 0x0002112B
			protected override void OnAnimate()
			{
				if (this._startAnimation)
				{
					this._animationBlob.Animate();
				}
			}

			// Token: 0x060005DC RID: 1500 RVA: 0x00022F40 File Offset: 0x00021140
			private void TriggerAnimation(AnimationInstance animation, Vector2 position, bool isFinal = false)
			{
				if (this._lastTriggeredAnimation != animation || isFinal)
				{
					this._lastTriggeredAnimation = animation;
					if (isFinal)
					{
						this._lastTriggeredAnimation = null;
					}
					if (!this.Host.TriggeredAnimations.Any((KeyValuePair<AnimationInstance, Vector2> a) => a.Key.Index == animation.Index) && !this.Host.TriggeredAnimationsPositions.Any((KeyValuePair<AnimationInstance, Vector2> p) => p.Value == base.PositionPrecise))
					{
						animation.ResetFrame();
						animation.Cycles = 0;
						this.Host.TriggeredAnimations.Add(animation, position);
						this.Host.TriggeredAnimationsPositions.Add(animation, base.PositionPrecise);
					}
					if (this._index == 5 && animation.Index == 3 && this.Host._arrangementType == CPZBlobsInstance.ArrangementType.Straight)
					{
						KeyValuePair<AnimationInstance, Vector2> keyValuePair = this.Host.TriggeredAnimations.LastOrDefault((KeyValuePair<AnimationInstance, Vector2> a) => a.Key.Index == 3);
						if (keyValuePair.Key != null)
						{
							this.Host.BottomStartOverflowTriggeredAnimations.Add(keyValuePair.Key);
							return;
						}
					}
					else if (this._index == 5 && animation.Index == 3 && this.Host._arrangementType == CPZBlobsInstance.ArrangementType.Arc && this._velocity.Y < 0.0 && this.Host.BottomStartOverflowTriggeredAnimations.Count == 0)
					{
						KeyValuePair<AnimationInstance, Vector2> keyValuePair2 = this.Host.TriggeredAnimations.LastOrDefault((KeyValuePair<AnimationInstance, Vector2> a) => a.Key.Index == 3);
						if (keyValuePair2.Key != null)
						{
							this.Host.BottomStartOverflowTriggeredAnimations.Add(keyValuePair2.Key);
						}
					}
				}
			}

			// Token: 0x060005DD RID: 1501 RVA: 0x0002312C File Offset: 0x0002132C
			protected override void OnDraw(Renderer renderer, LayerViewOptions viewOptions)
			{
				if (this.Host._arrangementType == CPZBlobsInstance.ArrangementType.Straight)
				{
					this.StraightPrepareTriggers();
				}
				IObjectRenderer objectRenderer = renderer.GetObjectRenderer();
				if (this.Host._arrangementType == CPZBlobsInstance.ArrangementType.Arc)
				{
					this.DrawArc(objectRenderer, viewOptions);
					return;
				}
				this.DrawStraight(objectRenderer, viewOptions);
			}

			// Token: 0x060005DE RID: 1502 RVA: 0x00023174 File Offset: 0x00021374
			private void ArcPrepareTriggers()
			{
				Rectanglei absoluteBounds = base.CollisionRectangles[0].AbsoluteBounds;
				Rectangle r = Rectangle.FromLTRB((double)this._downX - (double)absoluteBounds.Width * 0.5, (double)(this._originalY - absoluteBounds.Height), (double)this._downX + (double)absoluteBounds.Width * 0.5, (double)this._originalY + (double)absoluteBounds.Height * 0.5);
				Rectangle r2 = Rectangle.FromLTRB((double)this._upX - (double)absoluteBounds.Width * 0.5, (double)(this._originalY - absoluteBounds.Height), (double)this._upX + (double)absoluteBounds.Width * 0.5, (double)this._originalY + (double)absoluteBounds.Height * 0.5);
				if (absoluteBounds.IntersectsWith(r2) && !this._leftToRight)
				{
					this._startAnimation = true;
					this.TriggerAnimation(this._animationBottomSplashStart, new Vector2((double)(this._upX - base.Position.X), (double)(this._originalY - 112 - base.Position.Y)), true);
				}
				if (absoluteBounds.IntersectsWith(r) && this._leftToRight)
				{
					this._startAnimation = true;
					this.TriggerAnimation(this._animationBottomSplashStart, new Vector2((double)(this._downX - base.Position.X), (double)(this._originalY - 112 - base.Position.Y)), false);
				}
				if (absoluteBounds.IntersectsWith(r2) && this._leftToRight)
				{
					if (this._index == 5)
					{
						this.TriggerAnimation(this._animationBottomSplashEnd, new Vector2((double)(this._upX - base.Position.X), (double)(this._originalY - 120 - base.Position.Y)), true);
					}
					else
					{
						this.TriggerAnimation(this._animationBottomSplashStart, new Vector2((double)(this._upX - base.Position.X), (double)(this._originalY - 112 - base.Position.Y)), true);
					}
				}
				if (absoluteBounds.IntersectsWith(r) && !this._leftToRight)
				{
					if (this._index == 5)
					{
						this.TriggerAnimation(this._animationBottomSplashEnd, new Vector2((double)(this._downX - base.Position.X), (double)(this._originalY - 120 - base.Position.Y)), true);
						return;
					}
					this.TriggerAnimation(this._animationBottomSplashStart, new Vector2((double)(this._downX - base.Position.X), (double)(this._originalY - 112 - base.Position.Y)), true);
				}
			}

			// Token: 0x060005DF RID: 1503 RVA: 0x00023468 File Offset: 0x00021668
			private void StraightPrepareTriggers()
			{
				if (this._velocity.Y > 0.0 && base.Position.Y > this._originalY - 224 && base.Position.Y < this._originalY - 14)
				{
					this._startAnimation = true;
					this.TriggerAnimation(this._animationTopSplashStart, new Vector2((double)(this._downX - base.Position.X), (double)(this._originalY - 224 - base.Position.Y)), false);
				}
				if (this._velocity.Y > 0.0 && base.Position.Y > this._originalY - 14)
				{
					if (this._index == 5)
					{
						this.TriggerAnimation(this._animationBottomSplashEnd, new Vector2((double)(this._downX - base.Position.X), (double)(this._originalY - 120 - base.Position.Y)), false);
					}
					else
					{
						this.TriggerAnimation(this._animationBottomSplashStart, new Vector2((double)(this._downX - base.Position.X), (double)(this._originalY - 112 - base.Position.Y)), true);
					}
				}
				if (this._velocity.Y < 0.0 && base.Position.Y < this._originalY - 224 - 60)
				{
					if (this._index == 5)
					{
						this.TriggerAnimation(this._animationTopSplashEnd, new Vector2((double)(this._upX - base.Position.X), (double)(this._originalY - 224 - base.Position.Y + 24)), true);
					}
					else
					{
						this.TriggerAnimation(this._animationTopSplashStart, new Vector2((double)(this._upX - base.Position.X), (double)(this._originalY - 224 - base.Position.Y + 24)), true);
					}
				}
				if (this._velocity.Y < 0.0 && base.Position.Y > this._originalY - 14 && base.Position.Y > this._originalY - 224 - 60)
				{
					this.TriggerAnimation(this._animationBottomSplashStart, new Vector2((double)(this._upX - base.Position.X), (double)(this._originalY - 112 - base.Position.Y)), false);
				}
			}

			// Token: 0x060005E0 RID: 1504 RVA: 0x00023734 File Offset: 0x00021934
			private void DrawArc(IObjectRenderer or, LayerViewOptions viewOptions)
			{
				Rectanglei r = or.ClipRectangle;
				or.ClipRectangle = new Rectangle(or.ClipRectangle.X, (double)(this._originalY - 288 - 256 - (int)base.Level.Camera.Bounds.Y), or.ClipRectangle.Width, 512.0);
				or.Render(this._animationBlob, false, false);
				or.ClipRectangle = r;
			}

			// Token: 0x060005E1 RID: 1505 RVA: 0x000237C4 File Offset: 0x000219C4
			private void DrawStraight(IObjectRenderer or, LayerViewOptions viewOptions)
			{
				Rectangle clipRectangle = or.ClipRectangle;
				int num = Math.Min(this._downX, this._upX);
				or.ClipRectangle = new Rectangle((double)(num - 64 - (int)base.Level.Camera.Bounds.X), (double)(this._originalY - 288 - (int)base.Level.Camera.Bounds.Y), 512.0, 256.0);
				or.Render(this._animationBlob, false, false);
				or.ClipRectangle = clipRectangle;
			}

			// Token: 0x04000633 RID: 1587
			private AnimationInstance _animationBlob;

			// Token: 0x04000634 RID: 1588
			private AnimationInstance _animationTopSplashStart;

			// Token: 0x04000635 RID: 1589
			private AnimationInstance _animationTopSplashEnd;

			// Token: 0x04000636 RID: 1590
			private AnimationInstance _animationBottomSplashStart;

			// Token: 0x04000637 RID: 1591
			private AnimationInstance _animationBottomSplashEnd;

			// Token: 0x04000638 RID: 1592
			private AnimationInstance _animationBottomOverflow;

			// Token: 0x0400063A RID: 1594
			private int _index;

			// Token: 0x0400063B RID: 1595
			private int _originalY;

			// Token: 0x0400063C RID: 1596
			private Vector2 _velocity;

			// Token: 0x0400063D RID: 1597
			private double _upVelocity;

			// Token: 0x0400063E RID: 1598
			private int _upX;

			// Token: 0x0400063F RID: 1599
			private int _downX;

			// Token: 0x04000640 RID: 1600
			private bool _leftToRight;

			// Token: 0x04000641 RID: 1601
			private AnimationInstance _lastTriggeredAnimation;

			// Token: 0x04000642 RID: 1602
			private bool _directionChange;

			// Token: 0x04000643 RID: 1603
			private int _directionChangeNormal;

			// Token: 0x04000644 RID: 1604
			private bool _startAnimation;

			// Token: 0x04000645 RID: 1605
			private double _currentAngle;
		}

		// Token: 0x020000F0 RID: 240
		public class OverflowInstance : ParticleObject
		{
			// Token: 0x060005E4 RID: 1508 RVA: 0x0000A2BC File Offset: 0x000084BC
			public OverflowInstance() : base("/ANIGROUP", 0, 1)
			{
			}

			// Token: 0x060005E5 RID: 1509 RVA: 0x00023876 File Offset: 0x00021A76
			public void InitOverflow()
			{
				this._animationInstance.Index = 5;
			}
		}
	}
}
