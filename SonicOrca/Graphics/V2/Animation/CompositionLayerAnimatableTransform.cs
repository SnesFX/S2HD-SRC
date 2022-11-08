using System;
using System.Collections.Generic;
using System.Linq;
using SonicOrca.Geometry;

namespace SonicOrca.Graphics.V2.Animation
{
	// Token: 0x020000EE RID: 238
	public class CompositionLayerAnimatableTransform
	{
		// Token: 0x170001B4 RID: 436
		// (get) Token: 0x06000842 RID: 2114 RVA: 0x00020870 File Offset: 0x0001EA70
		public List<CompositionLayerTween> Tweens
		{
			get
			{
				return this._tweens;
			}
		}

		// Token: 0x06000843 RID: 2115 RVA: 0x00020878 File Offset: 0x0001EA78
		private CompositionLayerTween GetCurrentTween(CompositionLayerTween.Type tweenType)
		{
			return (from t in this._tweens
			select t into t
			where t.TweenType == tweenType && this._ellapsedFrames >= t.StartFrame && this._ellapsedFrames <= t.EndFrame
			select t).LastOrDefault<CompositionLayerTween>();
		}

		// Token: 0x06000844 RID: 2116 RVA: 0x000208DC File Offset: 0x0001EADC
		public CompositionLayerTween GetFirstTween()
		{
			return (from t in this._tweens
			select t into t
			orderby t.StartFrame
			select t).First<CompositionLayerTween>();
		}

		// Token: 0x06000845 RID: 2117 RVA: 0x0002093C File Offset: 0x0001EB3C
		private CompositionLayerTween GetFirstTween(CompositionLayerTween.Type tweenType)
		{
			return (from t in this._tweens
			select t into t
			where t.TweenType == tweenType && this._ellapsedFrames <= t.StartFrame
			orderby t.StartFrame
			select t).FirstOrDefault<CompositionLayerTween>();
		}

		// Token: 0x06000846 RID: 2118 RVA: 0x000209C4 File Offset: 0x0001EBC4
		private CompositionLayerTween GetLastTween(CompositionLayerTween.Type tweenType)
		{
			return (from t in this._tweens
			select t into t
			where t.TweenType == tweenType
			orderby t.EndFrame
			select t).Last<CompositionLayerTween>();
		}

		// Token: 0x170001B5 RID: 437
		// (get) Token: 0x06000847 RID: 2119 RVA: 0x00020A44 File Offset: 0x0001EC44
		public double Opacity
		{
			get
			{
				CompositionLayerTween compositionLayerTween = this.GetCurrentTween(CompositionLayerTween.Type.OPACITY);
				if (compositionLayerTween == null)
				{
					compositionLayerTween = this.GetFirstTween(CompositionLayerTween.Type.OPACITY);
					if (compositionLayerTween == null)
					{
						compositionLayerTween = this.GetLastTween(CompositionLayerTween.Type.OPACITY);
					}
				}
				return compositionLayerTween.GetValueSet()["Opacity"];
			}
		}

		// Token: 0x170001B6 RID: 438
		// (get) Token: 0x06000848 RID: 2120 RVA: 0x00020A80 File Offset: 0x0001EC80
		public Vector2 Position
		{
			get
			{
				CompositionLayerTween compositionLayerTween = this.GetCurrentTween(CompositionLayerTween.Type.POSITION);
				if (compositionLayerTween == null)
				{
					compositionLayerTween = this.GetFirstTween(CompositionLayerTween.Type.POSITION);
					if (compositionLayerTween == null)
					{
						compositionLayerTween = this.GetLastTween(CompositionLayerTween.Type.POSITION);
					}
				}
				Dictionary<string, double> valueSet = compositionLayerTween.GetValueSet();
				return new Vector2(valueSet["X"], valueSet["Y"]);
			}
		}

		// Token: 0x170001B7 RID: 439
		// (get) Token: 0x06000849 RID: 2121 RVA: 0x00020AD0 File Offset: 0x0001ECD0
		public double Rotation
		{
			get
			{
				CompositionLayerTween compositionLayerTween = this.GetCurrentTween(CompositionLayerTween.Type.ROTATION);
				if (compositionLayerTween == null)
				{
					compositionLayerTween = this.GetFirstTween(CompositionLayerTween.Type.ROTATION);
					if (compositionLayerTween == null)
					{
						compositionLayerTween = this.GetLastTween(CompositionLayerTween.Type.ROTATION);
					}
				}
				return MathX.ToRadians(compositionLayerTween.GetValueSet()["Rotation"]);
			}
		}

		// Token: 0x170001B8 RID: 440
		// (get) Token: 0x0600084A RID: 2122 RVA: 0x00020B10 File Offset: 0x0001ED10
		public Vector2 Scale
		{
			get
			{
				CompositionLayerTween compositionLayerTween = this.GetCurrentTween(CompositionLayerTween.Type.SCALE);
				if (compositionLayerTween == null)
				{
					compositionLayerTween = this.GetFirstTween(CompositionLayerTween.Type.SCALE);
					if (compositionLayerTween == null)
					{
						compositionLayerTween = this.GetLastTween(CompositionLayerTween.Type.SCALE);
					}
				}
				Dictionary<string, double> valueSet = compositionLayerTween.GetValueSet();
				return new Vector2(valueSet["X"], valueSet["Y"]);
			}
		}

		// Token: 0x0600084B RID: 2123 RVA: 0x00020B60 File Offset: 0x0001ED60
		public void ResetFrame()
		{
			this._ellapsedFrames = 0U;
			foreach (CompositionLayerTween compositionLayerTween in this._tweens)
			{
				compositionLayerTween.ResetFrame();
			}
		}

		// Token: 0x0600084C RID: 2124 RVA: 0x00020BB8 File Offset: 0x0001EDB8
		public void Animate()
		{
			uint num = 0U;
			uint num2 = 0U;
			foreach (CompositionLayerTween compositionLayerTween in this._tweens)
			{
				if (this._ellapsedFrames <= compositionLayerTween.EndFrame)
				{
					compositionLayerTween.Animate();
				}
				if (compositionLayerTween.StartFrame <= num)
				{
					num = compositionLayerTween.StartFrame;
				}
				if (compositionLayerTween.EndFrame >= num2)
				{
					num2 = compositionLayerTween.EndFrame;
				}
			}
			if (this._ellapsedFrames <= num2)
			{
				this._ellapsedFrames += 1U;
			}
		}

		// Token: 0x0600084E RID: 2126 RVA: 0x00020C67 File Offset: 0x0001EE67
		public void AddKeyFrameTween(CompositionLayerTween tween)
		{
			this._tweens.Add(tween);
		}

		// Token: 0x0400050A RID: 1290
		private uint _ellapsedFrames;

		// Token: 0x0400050B RID: 1291
		private List<CompositionLayerTween> _tweens = new List<CompositionLayerTween>();
	}
}
