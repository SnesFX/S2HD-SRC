using System;
using SonicOrca.Geometry;
using SonicOrca.Graphics;

namespace SonicOrca.Core.Objects.Base
{
	// Token: 0x02000171 RID: 369
	public class Fragment : ActiveObject
	{
		// Token: 0x17000443 RID: 1091
		// (get) Token: 0x06001030 RID: 4144 RVA: 0x00041635 File Offset: 0x0003F835
		// (set) Token: 0x06001031 RID: 4145 RVA: 0x0004163D File Offset: 0x0003F83D
		public AnimationGroup AnimationGroup { get; set; }

		// Token: 0x17000444 RID: 1092
		// (get) Token: 0x06001032 RID: 4146 RVA: 0x00041646 File Offset: 0x0003F846
		// (set) Token: 0x06001033 RID: 4147 RVA: 0x0004164E File Offset: 0x0003F84E
		public string AnimationGroupResourceKey { get; set; }

		// Token: 0x17000445 RID: 1093
		// (get) Token: 0x06001034 RID: 4148 RVA: 0x00041657 File Offset: 0x0003F857
		// (set) Token: 0x06001035 RID: 4149 RVA: 0x0004165F File Offset: 0x0003F85F
		public int AnimationIndex { get; set; }

		// Token: 0x17000446 RID: 1094
		// (get) Token: 0x06001036 RID: 4150 RVA: 0x00041668 File Offset: 0x0003F868
		// (set) Token: 0x06001037 RID: 4151 RVA: 0x00041670 File Offset: 0x0003F870
		public int AnimationCycles { get; set; }

		// Token: 0x17000447 RID: 1095
		// (get) Token: 0x06001038 RID: 4152 RVA: 0x00041679 File Offset: 0x0003F879
		// (set) Token: 0x06001039 RID: 4153 RVA: 0x00041681 File Offset: 0x0003F881
		protected bool AdditiveBlending { get; set; }

		// Token: 0x17000448 RID: 1096
		// (get) Token: 0x0600103A RID: 4154 RVA: 0x0004168A File Offset: 0x0003F88A
		// (set) Token: 0x0600103B RID: 4155 RVA: 0x00041692 File Offset: 0x0003F892
		protected double FilterMultiplier { get; set; }

		// Token: 0x17000449 RID: 1097
		// (get) Token: 0x0600103C RID: 4156 RVA: 0x0004169B File Offset: 0x0003F89B
		// (set) Token: 0x0600103D RID: 4157 RVA: 0x000416A3 File Offset: 0x0003F8A3
		public bool FlipX { get; set; }

		// Token: 0x1700044A RID: 1098
		// (get) Token: 0x0600103E RID: 4158 RVA: 0x000416AC File Offset: 0x0003F8AC
		// (set) Token: 0x0600103F RID: 4159 RVA: 0x000416B4 File Offset: 0x0003F8B4
		public bool FlipY { get; set; }

		// Token: 0x1700044B RID: 1099
		// (get) Token: 0x06001040 RID: 4160 RVA: 0x000416BD File Offset: 0x0003F8BD
		// (set) Token: 0x06001041 RID: 4161 RVA: 0x000416C5 File Offset: 0x0003F8C5
		public double Angle { get; set; }

		// Token: 0x1700044C RID: 1100
		// (get) Token: 0x06001042 RID: 4162 RVA: 0x000416CE File Offset: 0x0003F8CE
		// (set) Token: 0x06001043 RID: 4163 RVA: 0x000416D6 File Offset: 0x0003F8D6
		public double Scale { get; set; }

		// Token: 0x1700044D RID: 1101
		// (get) Token: 0x06001044 RID: 4164 RVA: 0x000416DF File Offset: 0x0003F8DF
		// (set) Token: 0x06001045 RID: 4165 RVA: 0x000416E7 File Offset: 0x0003F8E7
		public double AngularVelocity { get; set; }

		// Token: 0x1700044E RID: 1102
		// (get) Token: 0x06001046 RID: 4166 RVA: 0x000416F0 File Offset: 0x0003F8F0
		// (set) Token: 0x06001047 RID: 4167 RVA: 0x000416F8 File Offset: 0x0003F8F8
		public Vector2 Velocity { get; set; }

		// Token: 0x1700044F RID: 1103
		// (get) Token: 0x06001048 RID: 4168 RVA: 0x00041701 File Offset: 0x0003F901
		// (set) Token: 0x06001049 RID: 4169 RVA: 0x00041709 File Offset: 0x0003F909
		public double Gravity { get; set; }

		// Token: 0x0600104A RID: 4170 RVA: 0x00041712 File Offset: 0x0003F912
		public Fragment()
		{
			this.FilterMultiplier = 1.0;
			this.Gravity = 0.875;
			this.Scale = 1.0;
		}

		// Token: 0x0600104B RID: 4171 RVA: 0x00041747 File Offset: 0x0003F947
		protected override void OnStart()
		{
			base.Priority = 2048;
		}

		// Token: 0x0600104C RID: 4172 RVA: 0x00037DC0 File Offset: 0x00035FC0
		protected override void OnStop()
		{
			base.FinishForever();
		}

		// Token: 0x0600104D RID: 4173 RVA: 0x00041754 File Offset: 0x0003F954
		public void Initialise()
		{
			if (this.AnimationGroup == null)
			{
				this.AnimationGroup = base.ResourceTree.GetLoadedResource<AnimationGroup>(this.AnimationGroupResourceKey);
			}
			this._animationInstance = new AnimationInstance(this.AnimationGroup, this.AnimationIndex);
		}

		// Token: 0x0600104E RID: 4174 RVA: 0x0004178C File Offset: 0x0003F98C
		protected override void OnUpdate()
		{
			if (this._animationInstance == null)
			{
				this.Initialise();
			}
			if (this.AnimationCycles != 0 && this._animationInstance.Cycles >= this.AnimationCycles)
			{
				base.FinishForever();
				return;
			}
			base.MovePrecise(this.Velocity);
			this.Velocity += new Vector2(0.0, this.Gravity);
			this.Angle += this.AngularVelocity;
		}

		// Token: 0x0600104F RID: 4175 RVA: 0x0004180D File Offset: 0x0003FA0D
		protected override void OnAnimate()
		{
			if (this._animationInstance == null)
			{
				return;
			}
			this._animationInstance.Animate();
		}

		// Token: 0x06001050 RID: 4176 RVA: 0x00041824 File Offset: 0x0003FA24
		protected override void OnDraw(Renderer renderer, LayerViewOptions viewOptions)
		{
			if (this._animationInstance == null)
			{
				return;
			}
			if (this.AnimationCycles != 0 && this._animationInstance.Cycles >= this.AnimationCycles)
			{
				return;
			}
			IObjectRenderer objectRenderer = renderer.GetObjectRenderer();
			if (this.FilterMultiplier == 0.0)
			{
				objectRenderer.Filter = 0;
			}
			else
			{
				objectRenderer.FilterAmount *= this.FilterMultiplier;
			}
			objectRenderer.BlendMode = (this.AdditiveBlending ? BlendMode.Additive : BlendMode.Alpha);
			objectRenderer.ModelMatrix = objectRenderer.ModelMatrix.RotateZ(this.Angle);
			Rectanglei source = this._animationInstance.CurrentFrame.Source;
			int num = (int)((double)source.Width * this.Scale);
			int num2 = (int)((double)source.Height * this.Scale);
			Rectanglei r = new Rectanglei(-num / 2, -num2 / 2, num, num2);
			objectRenderer.Texture = this._animationInstance.CurrentTexture;
			objectRenderer.Render(source, r, this.FlipX, this.FlipY);
		}

		// Token: 0x04000931 RID: 2353
		private AnimationInstance _animationInstance;
	}
}
