using System;
using System.Linq;
using SonicOrca.Core;
using SonicOrca.Core.Collision;
using SonicOrca.Core.Objects;
using SonicOrca.Extensions;
using SonicOrca.Geometry;
using SonicOrca.Graphics;

namespace SONICORCA.OBJECTS.EHZBRIDGE
{
	// Token: 0x02000026 RID: 38
	public class EHZBridgeInstance : ActiveObject
	{
		// Token: 0x1700001C RID: 28
		// (get) Token: 0x060000CE RID: 206 RVA: 0x00007D73 File Offset: 0x00005F73
		private int TotalWidth
		{
			get
			{
				return this._logs * 64;
			}
		}

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x060000CF RID: 207 RVA: 0x00007D7E File Offset: 0x00005F7E
		// (set) Token: 0x060000D0 RID: 208 RVA: 0x00007D86 File Offset: 0x00005F86
		public int Logs
		{
			get
			{
				return this._logs;
			}
			set
			{
				this._logs = value;
			}
		}

		// Token: 0x060000D1 RID: 209 RVA: 0x00007D90 File Offset: 0x00005F90
		protected override void OnStart()
		{
			this._logAnimation = new AnimationInstance(base.ResourceTree, base.Type.GetAbsolutePath("/ANIGROUP"), 0);
			this._logAnimation.Index = 1;
			this._logPositions = new Vector2i[this._logs];
			int num = -(this.TotalWidth / 2);
			for (int i = 0; i < this._logs; i++)
			{
				this._logPositions[i] = new Vector2i(num, 0);
				num += 64;
			}
			this._depressedLogs = new bool[this._logs];
			base.DesignBounds = new Rectanglei(-this.TotalWidth / 2 - 32, -32, this.TotalWidth, 64);
			base.CollisionVectors = (from log in this._logPositions
			select new CollisionVector(this, new Vector2i(log.X - 32, log.Y - 32), new Vector2i(log.X + 32, log.Y - 32), uint.MaxValue, CollisionFlags.Conveyor | CollisionFlags.NoBalance)).ToArray<CollisionVector>();
		}

		// Token: 0x060000D2 RID: 210 RVA: 0x00007E64 File Offset: 0x00006064
		protected override void OnUpdate()
		{
			for (int i = 0; i < this._logs; i++)
			{
				this._depressedLogs[i] = false;
			}
			double num = (double)(base.Position.X + this._logPositions[1].X - 32);
			double num2 = (double)(base.Position.X + this._logPositions[this._logs - 2].X + 32);
			foreach (ICharacter character in base.Level.ObjectManager.Characters)
			{
				if (character.ObjectLink == this && (double)character.Position.X >= num && (double)character.Position.X < num2)
				{
					int num3 = (int)((double)(character.Position.X - (base.Position.X + (this._logPositions[0].X - 32))) / 64.0);
					if (num3 >= 0 && num3 < this._logs)
					{
						this._depressedLogs[num3] = true;
					}
				}
			}
			int num4 = -1;
			for (int j = 0; j < this._logs; j++)
			{
				if (this._depressedLogs[j] && Math.Abs(this._logs / 2 - j) < Math.Abs(this._logs / 2 - num4))
				{
					num4 = j;
				}
			}
			if (num4 != -1)
			{
				this.DepressLogs(num4);
			}
			else
			{
				for (int k = 0; k < this._logs; k++)
				{
					this._logPositions[k].Y = Math.Max(0, this._logPositions[k].Y - 4);
				}
			}
			for (int l = 0; l < this._logs; l++)
			{
				Vector2i vector2i = this._logPositions[l];
				CollisionVector collisionVector = base.CollisionVectors[l];
				collisionVector.RelativeA = new Vector2i(vector2i.X - 32, vector2i.Y - 32);
				collisionVector.RelativeB = new Vector2i(vector2i.X + 32, vector2i.Y - 32);
			}
			base.RegisterCollisionUpdate();
			int count = base.Level.Map.CollisionPathLayers.Count;
			for (int m = 0; m < this._logs; m++)
			{
				CollisionVector collisionVector2 = base.CollisionVectors[m];
				for (int n = 0; n < count; n++)
				{
					if (m > 0)
					{
						collisionVector2.SetConnectionA(n, base.CollisionVectors[m - 1]);
					}
					if (m < this._logs - 1)
					{
						collisionVector2.SetConnectionB(n, base.CollisionVectors[m + 1]);
					}
				}
			}
		}

		// Token: 0x060000D3 RID: 211 RVA: 0x00008148 File Offset: 0x00006348
		private void DepressLogs(int logIndex)
		{
			int num = (int)(Math.Sin((double)logIndex / (double)this._logs * 3.141592653589793) * 40.0);
			for (int i = 0; i < logIndex; i++)
			{
				int val = (int)(Math.Sin((double)i / (double)logIndex * 1.5707963267948966) * 40.0);
				this.UpdateLogY(i, Math.Min(val, num));
			}
			this.UpdateLogY(logIndex, num);
			for (int j = logIndex + 1; j < this._logs; j++)
			{
				int val2 = (int)(Math.Sin(1.5707963267948966 + (double)(j - logIndex) / (double)(this._logs - logIndex - 1) * 1.5707963267948966) * 40.0);
				this.UpdateLogY(j, Math.Min(val2, num));
			}
		}

		// Token: 0x060000D4 RID: 212 RVA: 0x00008214 File Offset: 0x00006414
		private void UpdateLogY(int i, int depress)
		{
			int num = this._logPositions[i].Y;
			if (num > depress)
			{
				num -= 4;
				if (num < depress)
				{
					num = depress;
				}
			}
			else
			{
				num += 4;
				if (num > depress)
				{
					num = depress;
				}
			}
			this._logPositions[i].Y = num;
		}

		// Token: 0x060000D5 RID: 213 RVA: 0x0000825F File Offset: 0x0000645F
		protected override void OnAnimate()
		{
			this._logAnimation.Animate();
		}

		// Token: 0x060000D6 RID: 214 RVA: 0x0000826C File Offset: 0x0000646C
		protected override void OnDraw(Renderer renderer, LayerViewOptions viewOptions)
		{
			IObjectRenderer objectRenderer = renderer.GetObjectRenderer();
			for (int i = 0; i < this._logs; i++)
			{
				objectRenderer.Render(this._logAnimation, this._logPositions[i], false, false);
			}
		}

		// Token: 0x040000F5 RID: 245
		private AnimationInstance _logAnimation;

		// Token: 0x040000F6 RID: 246
		private int _logs = 2;

		// Token: 0x040000F7 RID: 247
		private Vector2i[] _logPositions;

		// Token: 0x040000F8 RID: 248
		private bool[] _depressedLogs;
	}
}
