using System;
using System.Collections.Generic;
using System.Linq;
using SonicOrca.Core;
using SonicOrca.Geometry;

namespace SonicOrca.Drawing.LevelRendering
{
	// Token: 0x02000016 RID: 22
	internal class RenderingLayer
	{
		// Token: 0x17000046 RID: 70
		// (get) Token: 0x06000138 RID: 312 RVA: 0x00006ECC File Offset: 0x000050CC
		public int LayerIndex { get; }

		// Token: 0x17000047 RID: 71
		// (get) Token: 0x06000139 RID: 313 RVA: 0x00006ED4 File Offset: 0x000050D4
		public LevelLayer Layer { get; }

		// Token: 0x17000048 RID: 72
		// (get) Token: 0x0600013A RID: 314 RVA: 0x00006EDC File Offset: 0x000050DC
		// (set) Token: 0x0600013B RID: 315 RVA: 0x00006EE4 File Offset: 0x000050E4
		public int RenderTileIndex { get; private set; }

		// Token: 0x17000049 RID: 73
		// (get) Token: 0x0600013C RID: 316 RVA: 0x00006EED File Offset: 0x000050ED
		// (set) Token: 0x0600013D RID: 317 RVA: 0x00006EF5 File Offset: 0x000050F5
		public int RenderTileCount { get; private set; }

		// Token: 0x1700004A RID: 74
		// (get) Token: 0x0600013E RID: 318 RVA: 0x00006EFE File Offset: 0x000050FE
		// (set) Token: 0x0600013F RID: 319 RVA: 0x00006F06 File Offset: 0x00005106
		public List<ActiveObject> LowObjects { get; private set; }

		// Token: 0x1700004B RID: 75
		// (get) Token: 0x06000140 RID: 320 RVA: 0x00006F0F File Offset: 0x0000510F
		// (set) Token: 0x06000141 RID: 321 RVA: 0x00006F17 File Offset: 0x00005117
		public List<ActiveObject> HighObjects { get; private set; }

		// Token: 0x1700004C RID: 76
		// (get) Token: 0x06000142 RID: 322 RVA: 0x00006F20 File Offset: 0x00005120
		// (set) Token: 0x06000143 RID: 323 RVA: 0x00006F28 File Offset: 0x00005128
		public bool HasShadows { get; private set; }

		// Token: 0x06000144 RID: 324 RVA: 0x00006F34 File Offset: 0x00005134
		public RenderingLayer(Level level, int layerIndex, IVideoSettings videoSettings)
		{
			this._level = level;
			this._videoSettings = videoSettings;
			this.LayerIndex = layerIndex;
			this.Layer = this._level.Map.Layers[layerIndex];
		}

		// Token: 0x06000145 RID: 325 RVA: 0x00006F84 File Offset: 0x00005184
		public void Clear()
		{
			this.HasShadows = (this.Layer.Shadows.Count > 0 && this._videoSettings.EnableShadows);
			List<ActiveObject> lowObjects = this.LowObjects;
			if (lowObjects != null)
			{
				lowObjects.Clear();
			}
			List<ActiveObject> highObjects = this.HighObjects;
			if (highObjects == null)
			{
				return;
			}
			highObjects.Clear();
		}

		// Token: 0x06000146 RID: 326 RVA: 0x00006FD9 File Offset: 0x000051D9
		public void SetRenderTileRange(int index, int count)
		{
			this.RenderTileIndex = index;
			this.RenderTileCount = count;
		}

		// Token: 0x06000147 RID: 327 RVA: 0x00006FE9 File Offset: 0x000051E9
		public void AddLowObject(ActiveObject obj)
		{
			if (this.LowObjects == null)
			{
				this.LowObjects = new List<ActiveObject>();
			}
			this.LowObjects.Add(obj);
		}

		// Token: 0x06000148 RID: 328 RVA: 0x0000700A File Offset: 0x0000520A
		public void AddHighObject(ActiveObject obj)
		{
			if (this.HighObjects == null)
			{
				this.HighObjects = new List<ActiveObject>();
			}
			this.HighObjects.Add(obj);
		}

		// Token: 0x06000149 RID: 329 RVA: 0x0000702C File Offset: 0x0000522C
		public void UpdateClippingMarkers()
		{
			this._clippingMarkers = (from m in this._level.Map.Markers
			where string.Equals(m.Tag, "clipping", StringComparison.OrdinalIgnoreCase)
			where m.Layer == this.Layer
			select m).ToArray<LevelMarker>();
		}

		// Token: 0x0600014A RID: 330 RVA: 0x0000708C File Offset: 0x0000528C
		public bool IsAreaClipped(Viewport viewport, Rectanglei area)
		{
			if (this._clippingMarkers.Length != 0)
			{
				foreach (LevelMarker levelMarker in this._clippingMarkers)
				{
					if (new Rectangle((double)(levelMarker.Bounds.X - viewport.Bounds.X) * viewport.Scale.X, (double)(levelMarker.Bounds.Y - viewport.Bounds.Y) * viewport.Scale.Y, (double)levelMarker.Bounds.Width * viewport.Scale.X, (double)levelMarker.Bounds.Height * viewport.Scale.Y).IntersectsWith(area))
					{
						return false;
					}
				}
				return true;
			}
			return false;
		}

		// Token: 0x040000CD RID: 205
		private readonly Level _level;

		// Token: 0x040000CE RID: 206
		private readonly IVideoSettings _videoSettings;

		// Token: 0x040000CF RID: 207
		private LevelMarker[] _clippingMarkers = new LevelMarker[0];
	}
}
