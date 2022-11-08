using System;
using System.Collections.Generic;
using System.Linq;
using SonicOrca.Geometry;
using SonicOrca.Resources;

namespace SonicOrca.Core
{
	// Token: 0x02000117 RID: 279
	public abstract class Area : IDisposable, ILoadedResource
	{
		// Token: 0x1700024D RID: 589
		// (get) Token: 0x06000A66 RID: 2662 RVA: 0x000292FE File Offset: 0x000274FE
		// (set) Token: 0x06000A67 RID: 2663 RVA: 0x00029306 File Offset: 0x00027506
		public Resource Resource { get; set; }

		// Token: 0x1700024E RID: 590
		// (get) Token: 0x06000A68 RID: 2664 RVA: 0x0002930F File Offset: 0x0002750F
		public IReadOnlyCollection<string> Dependencies
		{
			get
			{
				return this._dependencies;
			}
		}

		// Token: 0x1700024F RID: 591
		// (get) Token: 0x06000A69 RID: 2665 RVA: 0x00029317 File Offset: 0x00027517
		public virtual IEnumerable<KeyValuePair<string, object>> StateVariables
		{
			get
			{
				return Enumerable.Empty<KeyValuePair<string, object>>();
			}
		}

		// Token: 0x06000A6A RID: 2666 RVA: 0x0002931E File Offset: 0x0002751E
		public Area(IEnumerable<string> dependencies)
		{
			this._dependencies = dependencies.ToArray<string>();
		}

		// Token: 0x06000A6B RID: 2667
		public abstract void Prepare(Level level, LevelPrepareSettings settings);

		// Token: 0x06000A6C RID: 2668 RVA: 0x00006325 File Offset: 0x00004525
		public virtual void OnStart()
		{
		}

		// Token: 0x06000A6D RID: 2669 RVA: 0x00006325 File Offset: 0x00004525
		public virtual void OnUpdate()
		{
		}

		// Token: 0x06000A6E RID: 2670 RVA: 0x00006325 File Offset: 0x00004525
		public virtual void OnComplete()
		{
		}

		// Token: 0x06000A6F RID: 2671 RVA: 0x00006325 File Offset: 0x00004525
		public virtual void OnPause()
		{
		}

		// Token: 0x06000A70 RID: 2672 RVA: 0x00006325 File Offset: 0x00004525
		public virtual void OnUnpause()
		{
		}

		// Token: 0x06000A71 RID: 2673 RVA: 0x00006325 File Offset: 0x00004525
		public void OnLoaded()
		{
		}

		// Token: 0x06000A72 RID: 2674 RVA: 0x00006325 File Offset: 0x00004525
		public virtual void Dispose()
		{
		}

		// Token: 0x06000A73 RID: 2675 RVA: 0x00029334 File Offset: 0x00027534
		protected void ExtendSeamlessLevelBounds(Level level, Rectanglei newRegion)
		{
			newRegion.Left = Math.Min(newRegion.Left, level.Bounds.Left);
			newRegion.Top = Math.Min(newRegion.Top, level.Bounds.Top);
			newRegion.Right = Math.Max(newRegion.Right, level.Bounds.Right);
			newRegion.Bottom = Math.Max(newRegion.Bottom, level.Bounds.Bottom);
			level.SeamlessNextBounds = newRegion;
		}

		// Token: 0x04000629 RID: 1577
		private readonly string[] _dependencies;
	}
}
