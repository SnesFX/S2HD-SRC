using System;
using System.Collections.Generic;
using System.Linq;
using SonicOrca.Geometry;

namespace SonicOrca.Core
{
	// Token: 0x0200013B RID: 315
	public class ObjectDefinition
	{
		// Token: 0x17000326 RID: 806
		// (get) Token: 0x06000CA2 RID: 3234 RVA: 0x0003053C File Offset: 0x0002E73C
		// (set) Token: 0x06000CA3 RID: 3235 RVA: 0x00030544 File Offset: 0x0002E744
		public string Key
		{
			get
			{
				return this._key;
			}
			set
			{
				this._key = value;
			}
		}

		// Token: 0x17000327 RID: 807
		// (get) Token: 0x06000CA4 RID: 3236 RVA: 0x0003054D File Offset: 0x0002E74D
		// (set) Token: 0x06000CA5 RID: 3237 RVA: 0x00030555 File Offset: 0x0002E755
		public Guid Uid
		{
			get
			{
				return this._uid;
			}
			set
			{
				this._uid = value;
			}
		}

		// Token: 0x17000328 RID: 808
		// (get) Token: 0x06000CA6 RID: 3238 RVA: 0x0003055E File Offset: 0x0002E75E
		// (set) Token: 0x06000CA7 RID: 3239 RVA: 0x00030566 File Offset: 0x0002E766
		public string Name
		{
			get
			{
				return this._name;
			}
			set
			{
				this._name = value;
			}
		}

		// Token: 0x17000329 RID: 809
		// (get) Token: 0x06000CA8 RID: 3240 RVA: 0x0003056F File Offset: 0x0002E76F
		// (set) Token: 0x06000CA9 RID: 3241 RVA: 0x00030577 File Offset: 0x0002E777
		public int Layer
		{
			get
			{
				return this._layer;
			}
			set
			{
				this._layer = value;
			}
		}

		// Token: 0x1700032A RID: 810
		// (get) Token: 0x06000CAA RID: 3242 RVA: 0x00030580 File Offset: 0x0002E780
		// (set) Token: 0x06000CAB RID: 3243 RVA: 0x00030588 File Offset: 0x0002E788
		public Vector2i Position
		{
			get
			{
				return this._position;
			}
			set
			{
				this._position = value;
			}
		}

		// Token: 0x1700032B RID: 811
		// (get) Token: 0x06000CAC RID: 3244 RVA: 0x00030591 File Offset: 0x0002E791
		public IReadOnlyCollection<KeyValuePair<string, object>> Behaviour
		{
			get
			{
				return this._behaviour;
			}
		}

		// Token: 0x06000CAD RID: 3245 RVA: 0x00030599 File Offset: 0x0002E799
		public ObjectDefinition(string key, Guid uid, string name, int layer, Vector2i position, IEnumerable<KeyValuePair<string, object>> behaviour)
		{
			this._key = key;
			this._uid = uid;
			this._name = name;
			this._layer = layer;
			this._position = position;
			this._behaviour = behaviour.ToArray<KeyValuePair<string, object>>();
		}

		// Token: 0x0400073E RID: 1854
		private string _key;

		// Token: 0x0400073F RID: 1855
		private Guid _uid;

		// Token: 0x04000740 RID: 1856
		private string _name;

		// Token: 0x04000741 RID: 1857
		private int _layer;

		// Token: 0x04000742 RID: 1858
		private Vector2i _position;

		// Token: 0x04000743 RID: 1859
		private readonly IReadOnlyCollection<KeyValuePair<string, object>> _behaviour;
	}
}
