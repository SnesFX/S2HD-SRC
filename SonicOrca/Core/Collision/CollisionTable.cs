using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using SonicOrca.Geometry;

namespace SonicOrca.Core.Collision
{
	// Token: 0x0200019B RID: 411
	public class CollisionTable
	{
		// Token: 0x170004A1 RID: 1185
		// (get) Token: 0x0600118A RID: 4490 RVA: 0x00045514 File Offset: 0x00043714
		public QuadTree<CollisionVector> InternalTree
		{
			get
			{
				return this._newCollisionQuadTree;
			}
		}

		// Token: 0x170004A2 RID: 1186
		// (get) Token: 0x0600118B RID: 4491 RVA: 0x0004551C File Offset: 0x0004371C
		public int Count
		{
			get
			{
				return this._newCollisionQuadTree.Count;
			}
		}

		// Token: 0x0600118C RID: 4492 RVA: 0x00045529 File Offset: 0x00043729
		public CollisionTable(Level level)
		{
			this._level = level;
		}

		// Token: 0x0600118D RID: 4493 RVA: 0x00045538 File Offset: 0x00043738
		public void Initialise(LevelMap map)
		{
			Trace.WriteLine("Initialising collision table");
			IEnumerable<CollisionVector> collisionVectors = map.CollisionVectors;
			this._newCollisionQuadTree = new QuadTree<CollisionVector>(collisionVectors, 4096, 4);
			foreach (CollisionVector collisionVector in collisionVectors)
			{
				collisionVector.UpdateDerrivedFields();
			}
			this.UpdateAllConnections();
		}

		// Token: 0x0600118E RID: 4494 RVA: 0x000455A8 File Offset: 0x000437A8
		public IEnumerable<CollisionVector> GetVectorConnections(CollisionVector v)
		{
			HashSet<CollisionVector> results = new HashSet<CollisionVector>();
			int numPaths = this._level.Map.CollisionPathLayers.Count;
			int num;
			for (int i = 0; i < numPaths; i = num + 1)
			{
				CollisionVector connectionA = v.GetConnectionA(i);
				CollisionVector connectionB = v.GetConnectionB(i);
				if (connectionA != null && results.Add(connectionA))
				{
					yield return connectionA;
				}
				if (connectionB != null && results.Add(connectionB))
				{
					yield return connectionB;
				}
				connectionB = null;
				num = i;
			}
			yield break;
		}

		// Token: 0x0600118F RID: 4495 RVA: 0x000455C0 File Offset: 0x000437C0
		public void UpdateConnectionsFast(IEnumerable<CollisionVector> vectors)
		{
			int count = this._level.Map.CollisionPathLayers.Count;
			Queue<CollisionVector> queue = new Queue<CollisionVector>(vectors);
			HashSet<CollisionVector> hashSet = new HashSet<CollisionVector>();
			while (queue.Count > 0)
			{
				CollisionVector collisionVector = queue.Dequeue();
				if (hashSet.Add(collisionVector))
				{
					foreach (CollisionVector item in this.GetVectorConnections(collisionVector))
					{
						queue.Enqueue(item);
					}
					Rectanglei bounds = collisionVector.Bounds.Inflate(new Vector2i(8, 8));
					foreach (CollisionVector collisionVector2 in this.GetPossibleCollisionIntersections(bounds, true, false))
					{
						if (collisionVector2.AbsoluteA == collisionVector.AbsoluteA || collisionVector2.AbsoluteA == collisionVector.AbsoluteB || collisionVector2.AbsoluteB == collisionVector.AbsoluteA || collisionVector2.AbsoluteB == collisionVector.AbsoluteB)
						{
							queue.Enqueue(collisionVector2);
						}
					}
				}
			}
			this.UpdateConnections(hashSet.ToArray<CollisionVector>());
		}

		// Token: 0x06001190 RID: 4496 RVA: 0x00045718 File Offset: 0x00043918
		public void UpdateAllConnections()
		{
			this.UpdateConnections(this._level.Map.CollisionVectors);
		}

		// Token: 0x06001191 RID: 4497 RVA: 0x00045730 File Offset: 0x00043930
		public void UpdateConnections(IEnumerable<CollisionVector> vectors)
		{
			int count = this._level.Map.CollisionPathLayers.Count;
			foreach (CollisionVector collisionVector in vectors)
			{
				collisionVector.ResetConnections();
			}
			foreach (CollisionVector collisionVector2 in vectors)
			{
				foreach (CollisionVector collisionVector3 in vectors)
				{
					if (collisionVector2 != collisionVector3)
					{
						if (collisionVector2.AbsoluteA == collisionVector3.AbsoluteB && CollisionVector.TestConnection(collisionVector2, collisionVector3))
						{
							for (int i = 0; i < count; i++)
							{
								if (collisionVector3.HasPath(i))
								{
									collisionVector2.SetConnectionA(i, collisionVector3);
								}
								if (collisionVector2.HasPath(i))
								{
									collisionVector3.SetConnectionB(i, collisionVector2);
								}
							}
						}
						if (collisionVector2.AbsoluteB == collisionVector3.AbsoluteA && CollisionVector.TestConnection(collisionVector2, collisionVector3))
						{
							for (int j = 0; j < count; j++)
							{
								if (collisionVector3.HasPath(j))
								{
									collisionVector2.SetConnectionB(j, collisionVector3);
								}
								if (collisionVector2.HasPath(j))
								{
									collisionVector3.SetConnectionA(j, collisionVector2);
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x06001192 RID: 4498 RVA: 0x000458B0 File Offset: 0x00043AB0
		public void UpdateConnectionsForVector(CollisionVector v1)
		{
			IEnumerable<CollisionVector> collisionVectors = this._level.Map.CollisionVectors;
			int count = this._level.Map.CollisionPathLayers.Count;
			foreach (CollisionVector collisionVector in collisionVectors)
			{
				if (v1 != collisionVector)
				{
					if (v1.AbsoluteA == collisionVector.AbsoluteB && CollisionVector.TestConnection(v1, collisionVector))
					{
						for (int i = 0; i < count; i++)
						{
							if (collisionVector.HasPath(i))
							{
								v1.SetConnectionA(i, collisionVector);
							}
							if (v1.HasPath(i))
							{
								collisionVector.SetConnectionB(i, v1);
							}
						}
					}
					if (v1.AbsoluteB == collisionVector.AbsoluteA && CollisionVector.TestConnection(v1, collisionVector))
					{
						for (int j = 0; j < count; j++)
						{
							if (collisionVector.HasPath(j))
							{
								v1.SetConnectionB(j, collisionVector);
							}
							if (v1.HasPath(j))
							{
								collisionVector.SetConnectionA(j, v1);
							}
						}
					}
				}
			}
		}

		// Token: 0x06001193 RID: 4499 RVA: 0x000459C0 File Offset: 0x00043BC0
		public IEnumerable<CollisionVector> GetPossibleCollisionIntersections(Rectanglei bounds, bool landscape = true, bool objects = true)
		{
			if (objects)
			{
				foreach (CollisionVector collisionVector in this._level.ObjectManager.ActiveObjects.SelectMany((ActiveObject x) => x.CollisionVectors))
				{
					yield return collisionVector;
				}
				IEnumerator<CollisionVector> enumerator = null;
			}
			if (landscape)
			{
				foreach (CollisionVector collisionVector2 in this._newCollisionQuadTree.Query(bounds))
				{
					yield return collisionVector2;
				}
				IEnumerator<CollisionVector> enumerator = null;
			}
			yield break;
			yield break;
		}

		// Token: 0x06001194 RID: 4500 RVA: 0x000459E5 File Offset: 0x00043BE5
		public override string ToString()
		{
			return string.Format("{0} collision vectors", this._newCollisionQuadTree.Count);
		}

		// Token: 0x040009E8 RID: 2536
		private readonly Level _level;

		// Token: 0x040009E9 RID: 2537
		private QuadTree<CollisionVector> _newCollisionQuadTree;
	}
}
