using System;

namespace SonicOrca.Core.Collision
{
	// Token: 0x02000196 RID: 406
	public class CollisionEvent
	{
		// Token: 0x17000494 RID: 1172
		// (get) Token: 0x06001170 RID: 4464 RVA: 0x0004518C File Offset: 0x0004338C
		public ActiveObject ActiveObject
		{
			get
			{
				return this._object;
			}
		}

		// Token: 0x17000495 RID: 1173
		// (get) Token: 0x06001171 RID: 4465 RVA: 0x00045194 File Offset: 0x00043394
		// (set) Token: 0x06001172 RID: 4466 RVA: 0x0004519C File Offset: 0x0004339C
		public CollisionInfo CollisionInfo
		{
			get
			{
				return this._collisionInfo;
			}
			set
			{
				this._collisionInfo = value;
			}
		}

		// Token: 0x17000496 RID: 1174
		// (get) Token: 0x06001173 RID: 4467 RVA: 0x000451A5 File Offset: 0x000433A5
		public int Id
		{
			get
			{
				return this._id;
			}
		}

		// Token: 0x17000497 RID: 1175
		// (get) Token: 0x06001174 RID: 4468 RVA: 0x000451AD File Offset: 0x000433AD
		// (set) Token: 0x06001175 RID: 4469 RVA: 0x000451B5 File Offset: 0x000433B5
		public bool IgnoreCollision { get; set; }

		// Token: 0x17000498 RID: 1176
		// (get) Token: 0x06001176 RID: 4470 RVA: 0x000451BE File Offset: 0x000433BE
		// (set) Token: 0x06001177 RID: 4471 RVA: 0x000451C6 File Offset: 0x000433C6
		public bool MaintainVelocity { get; set; }

		// Token: 0x06001178 RID: 4472 RVA: 0x000451CF File Offset: 0x000433CF
		public CollisionEvent(ActiveObject obj, int id)
		{
			this._object = obj;
			this._id = id;
		}

		// Token: 0x06001179 RID: 4473 RVA: 0x000451E5 File Offset: 0x000433E5
		public CollisionEvent(ActiveObject obj, CollisionInfo collisionInfo)
		{
			this._object = obj;
			this._collisionInfo = collisionInfo;
			this._id = this._collisionInfo.Vector.Id;
		}

		// Token: 0x0600117A RID: 4474 RVA: 0x00045211 File Offset: 0x00043411
		public override string ToString()
		{
			return string.Format("CollisionEvent ({0} for #{1})", this._object, this._id);
		}

		// Token: 0x040009C6 RID: 2502
		private readonly ActiveObject _object;

		// Token: 0x040009C7 RID: 2503
		private CollisionInfo _collisionInfo;

		// Token: 0x040009C8 RID: 2504
		private readonly int _id;
	}
}
