using System;
using System.Collections.Generic;
using System.Linq;
using SonicOrca.Core.Collision;
using SonicOrca.Geometry;
using SonicOrca.Resources;

namespace SonicOrca.Core
{
	// Token: 0x02000127 RID: 295
	public class LevelMap : ILoadedResource, IDisposable
	{
		// Token: 0x170002BE RID: 702
		// (get) Token: 0x06000B8E RID: 2958 RVA: 0x0002C803 File Offset: 0x0002AA03
		// (set) Token: 0x06000B8F RID: 2959 RVA: 0x0002C80B File Offset: 0x0002AA0B
		public Resource Resource { get; set; }

		// Token: 0x170002BF RID: 703
		// (get) Token: 0x06000B90 RID: 2960 RVA: 0x0002C814 File Offset: 0x0002AA14
		public ILevelLayerTreeNode LayerTree
		{
			get
			{
				return this._layerTree;
			}
		}

		// Token: 0x170002C0 RID: 704
		// (get) Token: 0x06000B91 RID: 2961 RVA: 0x0002C81C File Offset: 0x0002AA1C
		public IList<LevelLayer> Layers
		{
			get
			{
				return this._layers;
			}
		}

		// Token: 0x170002C1 RID: 705
		// (get) Token: 0x06000B92 RID: 2962 RVA: 0x0002C824 File Offset: 0x0002AA24
		public IList<CollisionVector> CollisionVectors
		{
			get
			{
				return this._collisionVectors;
			}
		}

		// Token: 0x170002C2 RID: 706
		// (get) Token: 0x06000B93 RID: 2963 RVA: 0x0002C82C File Offset: 0x0002AA2C
		public IList<int> CollisionPathLayers
		{
			get
			{
				return this._collisionPathLayers;
			}
		}

		// Token: 0x170002C3 RID: 707
		// (get) Token: 0x06000B94 RID: 2964 RVA: 0x0002C834 File Offset: 0x0002AA34
		public IList<LevelMarker> Markers
		{
			get
			{
				return this._markers;
			}
		}

		// Token: 0x170002C4 RID: 708
		// (get) Token: 0x06000B95 RID: 2965 RVA: 0x0002C83C File Offset: 0x0002AA3C
		// (set) Token: 0x06000B96 RID: 2966 RVA: 0x0002C844 File Offset: 0x0002AA44
		public Level Level { get; set; }

		// Token: 0x170002C5 RID: 709
		// (get) Token: 0x06000B97 RID: 2967 RVA: 0x0002C84D File Offset: 0x0002AA4D
		public int MaxColumns
		{
			get
			{
				if (this.Layers.Count == 0)
				{
					return 0;
				}
				return this.Layers.Max((LevelLayer x) => x.Columns);
			}
		}

		// Token: 0x170002C6 RID: 710
		// (get) Token: 0x06000B98 RID: 2968 RVA: 0x0002C888 File Offset: 0x0002AA88
		public int MaxRows
		{
			get
			{
				if (this.Layers.Count == 0)
				{
					return 0;
				}
				return this.Layers.Max((LevelLayer x) => x.Rows);
			}
		}

		// Token: 0x170002C7 RID: 711
		// (get) Token: 0x06000B99 RID: 2969 RVA: 0x0002C8C3 File Offset: 0x0002AAC3
		public Rectanglei Bounds
		{
			get
			{
				return new Rectanglei(0, 0, this.MaxColumns * 64, this.MaxRows * 64);
			}
		}

		// Token: 0x06000B9B RID: 2971 RVA: 0x0002C938 File Offset: 0x0002AB38
		public void Update()
		{
			foreach (LevelLayer levelLayer in this._layers)
			{
				levelLayer.Update();
			}
		}

		// Token: 0x06000B9C RID: 2972 RVA: 0x0002C988 File Offset: 0x0002AB88
		public void Animate()
		{
			foreach (LevelLayer levelLayer in this._layers)
			{
				levelLayer.Animate();
			}
		}

		// Token: 0x06000B9D RID: 2973 RVA: 0x00006325 File Offset: 0x00004525
		public void OnLoaded()
		{
		}

		// Token: 0x06000B9E RID: 2974 RVA: 0x00006325 File Offset: 0x00004525
		public void Dispose()
		{
		}

		// Token: 0x06000B9F RID: 2975 RVA: 0x0002C9D8 File Offset: 0x0002ABD8
		public LevelLayer FindLayer(string name)
		{
			return this._layers.FirstOrDefault((LevelLayer x) => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
		}

		// Token: 0x040006A8 RID: 1704
		private readonly ILevelLayerTreeNode _layerTree = new LevelLayerGroup(null);

		// Token: 0x040006A9 RID: 1705
		private readonly List<LevelLayer> _layers = new List<LevelLayer>();

		// Token: 0x040006AA RID: 1706
		private readonly List<CollisionVector> _collisionVectors = new List<CollisionVector>();

		// Token: 0x040006AB RID: 1707
		private readonly List<int> _collisionPathLayers = new List<int>();

		// Token: 0x040006AC RID: 1708
		private readonly List<ObjectPlacement> _objectPlacements = new List<ObjectPlacement>();

		// Token: 0x040006AD RID: 1709
		private readonly List<LevelMarker> _markers = new List<LevelMarker>();
	}
}
