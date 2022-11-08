using System;
using System.Linq;
using SonicOrca.Core.Collision;
using SonicOrca.Core.Lighting;
using SonicOrca.Core.Objects.Metadata;
using SonicOrca.Geometry;
using SonicOrca.Graphics;
using SonicOrca.Resources;

namespace SonicOrca.Core
{
	// Token: 0x02000135 RID: 309
	public abstract class ActiveObject : IActiveObject
	{
		// Token: 0x170002F2 RID: 754
		// (get) Token: 0x06000C23 RID: 3107 RVA: 0x0002F76F File Offset: 0x0002D96F
		// (set) Token: 0x06000C24 RID: 3108 RVA: 0x0002F777 File Offset: 0x0002D977
		public string Name { get; set; }

		// Token: 0x170002F3 RID: 755
		// (get) Token: 0x06000C25 RID: 3109 RVA: 0x0002F780 File Offset: 0x0002D980
		// (set) Token: 0x06000C26 RID: 3110 RVA: 0x0002F788 File Offset: 0x0002D988
		public Guid Uid { get; set; }

		// Token: 0x170002F4 RID: 756
		// (get) Token: 0x06000C27 RID: 3111 RVA: 0x0002F791 File Offset: 0x0002D991
		// (set) Token: 0x06000C28 RID: 3112 RVA: 0x0002F799 File Offset: 0x0002D999
		public Level Level { get; private set; }

		// Token: 0x170002F5 RID: 757
		// (get) Token: 0x06000C29 RID: 3113 RVA: 0x0002F7A2 File Offset: 0x0002D9A2
		// (set) Token: 0x06000C2A RID: 3114 RVA: 0x0002F7AA File Offset: 0x0002D9AA
		public ObjectType Type { get; private set; }

		// Token: 0x170002F6 RID: 758
		// (get) Token: 0x06000C2B RID: 3115 RVA: 0x0002F7B3 File Offset: 0x0002D9B3
		// (set) Token: 0x06000C2C RID: 3116 RVA: 0x0002F7BB File Offset: 0x0002D9BB
		public ObjectEntry Entry { get; private set; }

		// Token: 0x170002F7 RID: 759
		// (get) Token: 0x06000C2D RID: 3117 RVA: 0x0002F7C4 File Offset: 0x0002D9C4
		// (set) Token: 0x06000C2E RID: 3118 RVA: 0x0002F7CC File Offset: 0x0002D9CC
		public LevelLayer Layer { get; set; }

		// Token: 0x170002F8 RID: 760
		// (get) Token: 0x06000C2F RID: 3119 RVA: 0x0002F7D5 File Offset: 0x0002D9D5
		// (set) Token: 0x06000C30 RID: 3120 RVA: 0x0002F7DD File Offset: 0x0002D9DD
		public int Priority { get; set; }

		// Token: 0x170002F9 RID: 761
		// (get) Token: 0x06000C31 RID: 3121 RVA: 0x0002F7E6 File Offset: 0x0002D9E6
		// (set) Token: 0x06000C32 RID: 3122 RVA: 0x0002F7EE File Offset: 0x0002D9EE
		public ActiveObject ParentObject { get; set; }

		// Token: 0x170002FA RID: 762
		// (get) Token: 0x06000C33 RID: 3123 RVA: 0x0002F7F7 File Offset: 0x0002D9F7
		// (set) Token: 0x06000C34 RID: 3124 RVA: 0x0002F7FF File Offset: 0x0002D9FF
		public CollisionVector[] CollisionVectors { get; set; }

		// Token: 0x170002FB RID: 763
		// (get) Token: 0x06000C35 RID: 3125 RVA: 0x0002F808 File Offset: 0x0002DA08
		// (set) Token: 0x06000C36 RID: 3126 RVA: 0x0002F810 File Offset: 0x0002DA10
		public CollisionRectangle[] CollisionRectangles { get; set; }

		// Token: 0x170002FC RID: 764
		// (get) Token: 0x06000C37 RID: 3127 RVA: 0x0002F819 File Offset: 0x0002DA19
		// (set) Token: 0x06000C38 RID: 3128 RVA: 0x0002F821 File Offset: 0x0002DA21
		public CameraProperties CameraProperties { get; set; }

		// Token: 0x170002FD RID: 765
		// (get) Token: 0x06000C39 RID: 3129 RVA: 0x0002F82A File Offset: 0x0002DA2A
		// (set) Token: 0x06000C3A RID: 3130 RVA: 0x0002F832 File Offset: 0x0002DA32
		public bool LockLifetime { get; set; }

		// Token: 0x170002FE RID: 766
		// (get) Token: 0x06000C3B RID: 3131 RVA: 0x0002F83B File Offset: 0x0002DA3B
		// (set) Token: 0x06000C3C RID: 3132 RVA: 0x0002F843 File Offset: 0x0002DA43
		public bool Finished { get; private set; }

		// Token: 0x170002FF RID: 767
		// (get) Token: 0x06000C3D RID: 3133 RVA: 0x0002F84C File Offset: 0x0002DA4C
		// (set) Token: 0x06000C3E RID: 3134 RVA: 0x0002F854 File Offset: 0x0002DA54
		public Rectanglei DesignBounds { get; protected set; }

		// Token: 0x17000300 RID: 768
		// (get) Token: 0x06000C3F RID: 3135 RVA: 0x0002F85D File Offset: 0x0002DA5D
		// (set) Token: 0x06000C40 RID: 3136 RVA: 0x0002F865 File Offset: 0x0002DA65
		public float Brightness { get; set; }

		// Token: 0x17000301 RID: 769
		// (get) Token: 0x06000C41 RID: 3137 RVA: 0x0002F86E File Offset: 0x0002DA6E
		// (set) Token: 0x06000C42 RID: 3138 RVA: 0x0002F876 File Offset: 0x0002DA76
		public ShadowInfo ShadowInfo { get; set; }

		// Token: 0x17000302 RID: 770
		// (get) Token: 0x06000C43 RID: 3139 RVA: 0x0002F87F File Offset: 0x0002DA7F
		// (set) Token: 0x06000C44 RID: 3140 RVA: 0x0002F887 File Offset: 0x0002DA87
		public Vector2i Position
		{
			get
			{
				return this._position;
			}
			set
			{
				this._position = value;
				this._positionPrecise = value;
			}
		}

		// Token: 0x17000303 RID: 771
		// (get) Token: 0x06000C45 RID: 3141 RVA: 0x0002F89C File Offset: 0x0002DA9C
		// (set) Token: 0x06000C46 RID: 3142 RVA: 0x0002F8A4 File Offset: 0x0002DAA4
		public Vector2 PositionPrecise
		{
			get
			{
				return this._positionPrecise;
			}
			set
			{
				this._position = (Vector2i)value;
				this._positionPrecise = value;
			}
		}

		// Token: 0x17000304 RID: 772
		// (get) Token: 0x06000C47 RID: 3143 RVA: 0x0002F8B9 File Offset: 0x0002DAB9
		public Vector2i LastPosition
		{
			get
			{
				return this._lastPosition;
			}
		}

		// Token: 0x17000305 RID: 773
		// (get) Token: 0x06000C48 RID: 3144 RVA: 0x0002F8C1 File Offset: 0x0002DAC1
		public Vector2 LastPositionPrecise
		{
			get
			{
				return this._lastPositionPrecise;
			}
		}

		// Token: 0x17000306 RID: 774
		// (get) Token: 0x06000C49 RID: 3145 RVA: 0x0002F8CC File Offset: 0x0002DACC
		public Rectanglei LifetimeArea
		{
			get
			{
				Vector2 lifeRadius = this.Type.GetLifeRadius(this.Entry.State);
				Vector2 vector = new Vector2((double)this.Position.X - lifeRadius.X, (double)this.Position.Y - lifeRadius.Y);
				return new Rectangle(vector.X, vector.Y, lifeRadius.X * 2.0, lifeRadius.Y * 2.0);
			}
		}

		// Token: 0x17000307 RID: 775
		// (get) Token: 0x06000C4A RID: 3146 RVA: 0x0002F95F File Offset: 0x0002DB5F
		public bool IsSubObject
		{
			get
			{
				return this.ParentObject != null;
			}
		}

		// Token: 0x17000308 RID: 776
		// (get) Token: 0x06000C4B RID: 3147 RVA: 0x0002F96A File Offset: 0x0002DB6A
		public ResourceTree ResourceTree
		{
			get
			{
				return this.Level.GameContext.ResourceTree;
			}
		}

		// Token: 0x06000C4C RID: 3148 RVA: 0x0002F97C File Offset: 0x0002DB7C
		public ActiveObject()
		{
			this.CollisionVectors = new CollisionVector[0];
			this.CollisionRectangles = new CollisionRectangle[0];
			this.DesignBounds = new Rectangle(-32.0, -32.0, 64.0, 64.0);
		}

		// Token: 0x06000C4D RID: 3149 RVA: 0x0002F9DC File Offset: 0x0002DBDC
		public void Initialise(ObjectEntry entry)
		{
			this.Entry = entry;
			this.Level = entry.Level;
			this.Type = entry.Type;
			this.Layer = this.Level.Map.Layers[entry.Layer];
			this.Position = entry.Position;
			this.Name = entry.Name;
			this.Uid = entry.Uid;
			this._activeLayers = (from x in Enumerable.Range(0, this.Level.Map.Layers.Count)
			select true).ToArray<bool>();
			this.Priority = 256;
			this.CameraProperties = new CameraProperties();
			this.CameraProperties.Box = new Rectangle(-64.0, -192.0, 64.0, 256.0);
			this.CameraProperties.Delay = new Vector2i(0, 0);
			this.CameraProperties.MaxVelocity = new Vector2(64.0, 64.0);
			this.CameraProperties.Offset = new Vector2(0.0, 0.0);
			StateVariableAttribute.SetObjectState(this, this.Entry.State);
			this.ShadowInfo = new ShadowInfo
			{
				OcclusionSize = new Vector2i(16),
				MaxShadowOffset = new Vector2i(int.MaxValue)
			};
		}

		// Token: 0x06000C4E RID: 3150 RVA: 0x0002FB70 File Offset: 0x0002DD70
		public void Finish()
		{
			this.Finished = true;
		}

		// Token: 0x06000C4F RID: 3151 RVA: 0x0002FB79 File Offset: 0x0002DD79
		public void FinishForever()
		{
			this.Finish();
			this.Entry.FinishForever();
		}

		// Token: 0x06000C50 RID: 3152 RVA: 0x0002FB8C File Offset: 0x0002DD8C
		public void Start()
		{
			this.OnStart();
			this.RegisterCollisionUpdate();
		}

		// Token: 0x06000C51 RID: 3153 RVA: 0x0002FB9A File Offset: 0x0002DD9A
		public void UpdateEditor()
		{
			this.OnUpdateEditor();
		}

		// Token: 0x06000C52 RID: 3154 RVA: 0x0002FBA2 File Offset: 0x0002DDA2
		public void UpdatePrepare()
		{
			this._lastPosition = this._position;
			this._lastPositionPrecise = this._positionPrecise;
			this.OnUpdatePrepare();
		}

		// Token: 0x06000C53 RID: 3155 RVA: 0x0002FBC2 File Offset: 0x0002DDC2
		public void Update()
		{
			this.OnUpdate();
		}

		// Token: 0x06000C54 RID: 3156 RVA: 0x0002FBCA File Offset: 0x0002DDCA
		public void UpdateCollision()
		{
			this.OnUpdateCollision();
		}

		// Token: 0x06000C55 RID: 3157 RVA: 0x0002FBD2 File Offset: 0x0002DDD2
		public void Collision(CollisionEvent e)
		{
			this.OnCollision(e);
		}

		// Token: 0x06000C56 RID: 3158 RVA: 0x0002FBDB File Offset: 0x0002DDDB
		public void Animate()
		{
			this.OnAnimate();
		}

		// Token: 0x06000C57 RID: 3159 RVA: 0x0002FBE4 File Offset: 0x0002DDE4
		public void Draw(Renderer renderer, Viewport viewport, LayerViewOptions viewOptions)
		{
			Vector2i a = default(Vector2i);
			if (viewOptions.Shadows)
			{
				IShadowInfo shadowInfo = this.ShadowInfo;
				if (shadowInfo == null)
				{
					return;
				}
				a = this.Level.LightingManager.GetShadowOffset(this.Position, shadowInfo);
				if (a == default(Vector2i))
				{
					return;
				}
			}
			I2dRenderer i2dRenderer = renderer.Get2dRenderer();
			using (i2dRenderer.BeginMatixState())
			{
				i2dRenderer.ModelMatrix *= Matrix4.CreateTranslation((double)(this._position.X - viewport.Bounds.X + a.X) * viewport.Scale.X, (double)(this._position.Y - viewport.Bounds.Y + a.Y) * viewport.Scale.Y, 0.0);
				IObjectRenderer objectRenderer = renderer.GetObjectRenderer();
				objectRenderer.ClipRectangle = viewport.Destination;
				objectRenderer.ModelMatrix = i2dRenderer.ModelMatrix;
				objectRenderer.SetDefault();
				objectRenderer.Shadow = viewOptions.Shadows;
				objectRenderer.Filter = viewOptions.Filter;
				objectRenderer.FilterAmount = viewOptions.FilterAmount;
				objectRenderer.Scale = viewport.Scale;
				if (viewOptions.ShowObjects)
				{
					this.OnDraw(renderer, viewOptions);
				}
			}
		}

		// Token: 0x06000C58 RID: 3160 RVA: 0x0002FD54 File Offset: 0x0002DF54
		public void DrawCollision(Renderer renderer, Viewport viewport)
		{
			CollisionVector[] collisionVectors = this.CollisionVectors;
			for (int i = 0; i < collisionVectors.Length; i++)
			{
				collisionVectors[i].Draw(renderer, viewport);
			}
			CollisionRectangle[] collisionRectangles = this.CollisionRectangles;
			for (int i = 0; i < collisionRectangles.Length; i++)
			{
				collisionRectangles[i].Draw(renderer, viewport);
			}
		}

		// Token: 0x06000C59 RID: 3161 RVA: 0x0002FD9F File Offset: 0x0002DF9F
		public void Stop()
		{
			this.OnStop();
		}

		// Token: 0x06000C5A RID: 3162 RVA: 0x0002FDA8 File Offset: 0x0002DFA8
		protected void RegisterCollisionUpdate()
		{
			CollisionVector[] collisionVectors = this.CollisionVectors;
			for (int i = 0; i < collisionVectors.Length; i++)
			{
				collisionVectors[i].UpdateDerrivedFields();
			}
			int count = this.Level.Map.CollisionPathLayers.Count;
			foreach (CollisionVector collisionVector in this.CollisionVectors)
			{
				foreach (CollisionVector collisionVector2 in this.CollisionVectors)
				{
					if (collisionVector != collisionVector2)
					{
						if (collisionVector.AbsoluteA == collisionVector2.AbsoluteB && CollisionVector.TestConnection(collisionVector, collisionVector2))
						{
							for (int k = 0; k < count; k++)
							{
								if (collisionVector2.HasPath(k))
								{
									collisionVector.SetConnectionA(k, collisionVector2);
								}
								if (collisionVector.HasPath(k))
								{
									collisionVector2.SetConnectionB(k, collisionVector);
								}
							}
						}
						if (collisionVector.AbsoluteB == collisionVector2.AbsoluteA && CollisionVector.TestConnection(collisionVector, collisionVector2))
						{
							for (int l = 0; l < count; l++)
							{
								if (collisionVector2.HasPath(l))
								{
									collisionVector.SetConnectionB(l, collisionVector2);
								}
								if (collisionVector.HasPath(l))
								{
									collisionVector2.SetConnectionA(l, collisionVector);
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x06000C5B RID: 3163 RVA: 0x0002FEE5 File Offset: 0x0002E0E5
		public void Move(int x, int y)
		{
			this.Position += new Vector2i(x, y);
		}

		// Token: 0x06000C5C RID: 3164 RVA: 0x0002FEFF File Offset: 0x0002E0FF
		public void Move(Vector2i offset)
		{
			this.Position += offset;
		}

		// Token: 0x06000C5D RID: 3165 RVA: 0x0002FF13 File Offset: 0x0002E113
		public void MovePrecise(double x, double y)
		{
			this.PositionPrecise += new Vector2(x, y);
		}

		// Token: 0x06000C5E RID: 3166 RVA: 0x0002FF2D File Offset: 0x0002E12D
		public void MovePrecise(Vector2 offset)
		{
			this.PositionPrecise += offset;
		}

		// Token: 0x06000C5F RID: 3167 RVA: 0x00006325 File Offset: 0x00004525
		protected virtual void OnStart()
		{
		}

		// Token: 0x06000C60 RID: 3168 RVA: 0x00006325 File Offset: 0x00004525
		protected virtual void OnUpdateEditor()
		{
		}

		// Token: 0x06000C61 RID: 3169 RVA: 0x00006325 File Offset: 0x00004525
		protected virtual void OnUpdatePrepare()
		{
		}

		// Token: 0x06000C62 RID: 3170 RVA: 0x00006325 File Offset: 0x00004525
		protected virtual void OnUpdate()
		{
		}

		// Token: 0x06000C63 RID: 3171 RVA: 0x00006325 File Offset: 0x00004525
		protected virtual void OnUpdateCollision()
		{
		}

		// Token: 0x06000C64 RID: 3172 RVA: 0x00006325 File Offset: 0x00004525
		protected virtual void OnCollision(CollisionEvent e)
		{
		}

		// Token: 0x06000C65 RID: 3173 RVA: 0x00006325 File Offset: 0x00004525
		protected virtual void OnAnimate()
		{
		}

		// Token: 0x06000C66 RID: 3174 RVA: 0x00006325 File Offset: 0x00004525
		protected virtual void OnDraw(Renderer renderer, LayerViewOptions viewOptions)
		{
		}

		// Token: 0x06000C67 RID: 3175 RVA: 0x00006325 File Offset: 0x00004525
		protected virtual void OnStop()
		{
		}

		// Token: 0x0400070B RID: 1803
		private Vector2i _position;

		// Token: 0x0400070C RID: 1804
		private Vector2 _positionPrecise;

		// Token: 0x0400070D RID: 1805
		private Vector2i _lastPosition;

		// Token: 0x0400070E RID: 1806
		private Vector2 _lastPositionPrecise;

		// Token: 0x0400070F RID: 1807
		private bool[] _activeLayers;
	}
}
