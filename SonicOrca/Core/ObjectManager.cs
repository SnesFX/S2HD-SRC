using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using SonicOrca.Core.Collision;
using SonicOrca.Core.Extensions;
using SonicOrca.Core.Objects;
using SonicOrca.Geometry;
using SonicOrca.Graphics;

namespace SonicOrca.Core
{
	// Token: 0x0200013D RID: 317
	public class ObjectManager
	{
		// Token: 0x1700032E RID: 814
		// (get) Token: 0x06000CB2 RID: 3250 RVA: 0x00030602 File Offset: 0x0002E802
		public IReadOnlyCollection<ObjectType> RegisteredTypes
		{
			get
			{
				return this._registeredTypes;
			}
		}

		// Token: 0x1700032F RID: 815
		// (get) Token: 0x06000CB3 RID: 3251 RVA: 0x0003060A File Offset: 0x0002E80A
		public ICollection<ActiveObject> ActiveObjects
		{
			get
			{
				return this._activeObjects;
			}
		}

		// Token: 0x17000330 RID: 816
		// (get) Token: 0x06000CB4 RID: 3252 RVA: 0x00030612 File Offset: 0x0002E812
		public ObjectEntryTable ObjectEntryTable
		{
			get
			{
				return this._objectEntryTable;
			}
		}

		// Token: 0x17000331 RID: 817
		// (get) Token: 0x06000CB5 RID: 3253 RVA: 0x0003061A File Offset: 0x0002E81A
		public IEnumerable<ICharacter> Characters
		{
			get
			{
				return (from x in this._activeObjects
				where x.Type.Classification == ObjectClassification.Character
				select x).Cast<ICharacter>();
			}
		}

		// Token: 0x06000CB6 RID: 3254 RVA: 0x0003064C File Offset: 0x0002E84C
		public ObjectManager(Level level)
		{
			this._level = level;
			this._objectEntryTable = new ObjectEntryTable(level);
		}

		// Token: 0x06000CB7 RID: 3255 RVA: 0x000306A9 File Offset: 0x0002E8A9
		public void Setup(LevelMap map)
		{
			Trace.WriteLine("Setting up object manager");
			Trace.Indent();
			Trace.WriteLine("Registering object types");
			this.RegisterObjectTypes();
			Trace.Unindent();
		}

		// Token: 0x06000CB8 RID: 3256 RVA: 0x000306D0 File Offset: 0x0002E8D0
		public void Bind(LevelBinding binding)
		{
			Trace.Indent();
			Trace.WriteLine("Clearing objects and object entries");
			this._activeObjects.Clear();
			this._objectEntryTable.Clear();
			Trace.WriteLine("Initialising object entry table");
			this._objectEntryTable.Initialise(binding);
			Trace.Unindent();
		}

		// Token: 0x06000CB9 RID: 3257 RVA: 0x0003071D File Offset: 0x0002E91D
		public void ResetLifetimeArea()
		{
			this._lifeTimeAreas.Clear();
		}

		// Token: 0x06000CBA RID: 3258 RVA: 0x0003072A File Offset: 0x0002E92A
		public void AddLifeArea(Rectanglei area)
		{
			this._lifeTimeAreas.Add(area);
		}

		// Token: 0x06000CBB RID: 3259 RVA: 0x00030738 File Offset: 0x0002E938
		public void Update()
		{
			this.ManageObjects();
			this.UpdateObjectTypes();
			this.UpdatePrepareActiveObjects();
			this.UpdateActiveObjects();
			this.UpdateCollisionActiveObjects();
			this.RemoveFinishedActiveObjects();
			this._activeObjects.AddRange(this._newActiveObjects);
			this._newActiveObjects.Clear();
			this._objectEntryTable.RemoveFinishedEntries();
		}

		// Token: 0x06000CBC RID: 3260 RVA: 0x00030790 File Offset: 0x0002E990
		public void UpdateEditor()
		{
			this.ManageObjects();
			this.UpdateEditorActiveObjects();
			this.RemoveFinishedActiveObjects();
			this._respawnPrevention.Clear();
			this._activeObjects.AddRange(this._newActiveObjects);
			this._newActiveObjects.Clear();
			this._objectEntryTable.RemoveFinishedEntries();
		}

		// Token: 0x06000CBD RID: 3261 RVA: 0x000307E1 File Offset: 0x0002E9E1
		public void Animate()
		{
			this.AnimateObjectTypes();
			this.AnimateActiveObjects();
		}

		// Token: 0x06000CBE RID: 3262 RVA: 0x000307F0 File Offset: 0x0002E9F0
		public void Draw(Renderer renderer, Viewport viewport, LevelLayer layer, LayerViewOptions viewOptions, bool priority)
		{
			foreach (ActiveObject activeObject2 in from activeObject in this._activeObjects
			where activeObject.Layer == layer && activeObject.Priority != 0 && !(activeObject.Priority < 0 & priority) && (activeObject.Priority <= 0 || priority)
			select activeObject into x
			orderby x.Priority
			select x)
			{
				activeObject2.Draw(renderer, viewport, viewOptions);
			}
		}

		// Token: 0x06000CBF RID: 3263 RVA: 0x00030888 File Offset: 0x0002EA88
		public void DrawDebugInfo(Renderer renderer)
		{
			double num = 500.0;
			num += this._level.DebugContext.DrawText(renderer, string.Format("TOTAL OBJECTS: {0}", this._objectEntryTable.Count), FontAlignment.Left, 8.0, num, 0.75, new int?(0));
			num += this._level.DebugContext.DrawText(renderer, string.Format("ACTIVE OBJECTS: {0}", this._activeObjects.Count), FontAlignment.Left, 8.0, num, 0.75, new int?(0));
			num += this._level.DebugContext.DrawText(renderer, string.Format("RESPAWN PREVENTED OBJECTS: {0}", this._respawnPrevention.Count), FontAlignment.Left, 8.0, num, 0.75, new int?(0));
		}

		// Token: 0x06000CC0 RID: 3264 RVA: 0x00030977 File Offset: 0x0002EB77
		public void Start()
		{
			Trace.WriteLine("Registering more object types");
			this.RegisterObjectTypes();
			this.StartObjectTypes();
		}

		// Token: 0x06000CC1 RID: 3265 RVA: 0x00030990 File Offset: 0x0002EB90
		public void Stop()
		{
			this._objectEntryTable.Clear();
			foreach (ActiveObject activeObject in this._activeObjects.ToArray())
			{
				this.DeactivateObject(activeObject);
			}
			this.StopObjectTypes();
			this.UnregisterObjectTypes();
		}

		// Token: 0x06000CC2 RID: 3266 RVA: 0x000309DC File Offset: 0x0002EBDC
		public ActiveObject AddObject(ObjectPlacement objectPlacement)
		{
			ObjectEntry objectEntry = new ObjectEntry(this._level, objectPlacement);
			return this.ActivateObjectEntry(objectEntry);
		}

		// Token: 0x06000CC3 RID: 3267 RVA: 0x00030A00 File Offset: 0x0002EC00
		public void AddObjectEntry(ObjectEntry objectEntry)
		{
			if (string.IsNullOrEmpty(objectEntry.Name))
			{
				int num = (from e in this._objectEntryTable
				where e.Type == objectEntry.Type
				select e).Count<ObjectEntry>();
				objectEntry.Name = objectEntry.Type.Name + " " + num;
			}
			this._objectEntryTable.Add(objectEntry);
		}

		// Token: 0x06000CC4 RID: 3268 RVA: 0x00030A88 File Offset: 0x0002EC88
		public T AddSubObject<T>(ActiveObject parentObject) where T : ActiveObject
		{
			ObjectEntry objectEntry = new ObjectEntry(this._level, new ObjectPlacement(parentObject.Type.ResourceKey, this._level.Map.Layers.IndexOf(parentObject.Layer), parentObject.Position));
			return this.ActiveSubObject<T>(objectEntry, parentObject);
		}

		// Token: 0x06000CC5 RID: 3269 RVA: 0x00030ADC File Offset: 0x0002ECDC
		private void MapInstancesOf(ActiveObject activeObject)
		{
			ObjectEntry entry = (from e in this._objectEntryTable
			select e into e
			where e.Uid == activeObject.Uid
			select e).FirstOrDefault<ObjectEntry>();
			IEnumerable<ActiveObject> source = this._activeObjects.Concat(this._newActiveObjects);
			if (entry == null)
			{
				return;
			}
			using (IEnumerator<ObjectMapping> enumerator = entry.Mappings.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					ObjectMapping mapping = enumerator.Current;
					ActiveObject activeObject2 = (from e in source
					select e into e
					where e.Uid == mapping.Target
					select e).FirstOrDefault<ActiveObject>();
					if (activeObject2 != null)
					{
						BindingFlags bindingAttr = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
						MemberInfo memberInfo = activeObject.GetType().GetMember(mapping.Field, bindingAttr).First<MemberInfo>();
						if (memberInfo != null)
						{
							memberInfo.SetUnderlyingValue(activeObject, activeObject2);
						}
					}
				}
			}
			Func<ObjectMapping, bool> <>9__6;
			foreach (ActiveObject activeObject3 in (from ao in source
			select ao).Where(delegate(ActiveObject ao)
			{
				IEnumerable<ObjectMapping> mappings = ao.Entry.Mappings;
				Func<ObjectMapping, bool> predicate;
				if ((predicate = <>9__6) == null)
				{
					predicate = (<>9__6 = ((ObjectMapping m) => m.Target == entry.Uid));
				}
				return mappings.FirstOrDefault(predicate) != null;
			}))
			{
				foreach (ObjectMapping objectMapping in activeObject3.Entry.Mappings)
				{
					if (objectMapping.Target == activeObject.Uid)
					{
						BindingFlags bindingAttr2 = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
						MemberInfo memberInfo2 = activeObject3.GetType().GetMember(objectMapping.Field, bindingAttr2).First<MemberInfo>();
						if (memberInfo2 != null)
						{
							memberInfo2.SetUnderlyingValue(activeObject3, activeObject);
						}
					}
				}
			}
		}

		// Token: 0x06000CC6 RID: 3270 RVA: 0x00030D28 File Offset: 0x0002EF28
		private void UnMapInstancesOf(ActiveObject activeObject)
		{
			ObjectEntry entry = (from e in this._objectEntryTable
			select e into e
			where e.Uid == activeObject.Uid
			select e).FirstOrDefault<ObjectEntry>();
			if (entry == null)
			{
				return;
			}
			if (entry != null)
			{
				foreach (ObjectMapping objectMapping in entry.Mappings)
				{
					BindingFlags bindingAttr = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
					MemberInfo memberInfo = activeObject.GetType().GetMember(objectMapping.Field, bindingAttr).First<MemberInfo>();
					if (memberInfo != null)
					{
						memberInfo.SetUnderlyingValue(activeObject, null);
					}
				}
			}
			Func<ObjectMapping, bool> <>9__4;
			foreach (ActiveObject activeObject2 in (from ao in this._activeObjects
			select ao).Where(delegate(ActiveObject ao)
			{
				IEnumerable<ObjectMapping> mappings = ao.Entry.Mappings;
				Func<ObjectMapping, bool> predicate;
				if ((predicate = <>9__4) == null)
				{
					predicate = (<>9__4 = ((ObjectMapping m) => m.Target == entry.Uid));
				}
				return mappings.FirstOrDefault(predicate) != null;
			}))
			{
				foreach (ObjectMapping objectMapping2 in activeObject2.Entry.Mappings)
				{
					if (objectMapping2.Target == activeObject.Uid)
					{
						BindingFlags bindingAttr2 = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
						MemberInfo memberInfo2 = activeObject2.GetType().GetMember(objectMapping2.Field, bindingAttr2).First<MemberInfo>();
						if (memberInfo2 != null)
						{
							memberInfo2.SetUnderlyingValue(activeObject2, null);
						}
					}
				}
			}
		}

		// Token: 0x06000CC7 RID: 3271 RVA: 0x00030F10 File Offset: 0x0002F110
		public ActiveObject ActivateObjectEntry(ObjectEntry objectEntry)
		{
			ActiveObject activeObject = objectEntry.CreateActiveObject();
			this._newActiveObjects.Add(activeObject);
			this.MapInstancesOf(activeObject);
			activeObject.Start();
			return activeObject;
		}

		// Token: 0x06000CC8 RID: 3272 RVA: 0x00030F40 File Offset: 0x0002F140
		public T ActiveSubObject<T>(ObjectEntry objectEntry, ActiveObject parentObject) where T : ActiveObject
		{
			T t = objectEntry.CreateSubObject<T>();
			this._newActiveObjects.Add(t);
			t.ParentObject = parentObject;
			t.Start();
			return t;
		}

		// Token: 0x06000CC9 RID: 3273 RVA: 0x00030F80 File Offset: 0x0002F180
		public void DeactivateObject(ActiveObject activeObject)
		{
			activeObject.Finish();
			activeObject.Stop();
			ObjectEntry entry = activeObject.Entry;
			entry.Active = null;
			if (entry.FinishedForever)
			{
				this._objectEntryTable.Remove(entry);
			}
			else
			{
				this._respawnPrevention.Add(entry);
			}
			this.UnMapInstancesOf(activeObject);
			this._activeObjects.Remove(activeObject);
		}

		// Token: 0x06000CCA RID: 3274 RVA: 0x00030FE0 File Offset: 0x0002F1E0
		public bool IsInLifetimeArea(Rectanglei rect)
		{
			return this._lifeTimeAreas.Any((Rectanglei r) => rect.IntersectsWith(r));
		}

		// Token: 0x06000CCB RID: 3275 RVA: 0x00031014 File Offset: 0x0002F214
		private void ManageObjects()
		{
			IEnumerable<ObjectEntry> other = (from x in this._respawnPrevention
			where !this.IsInLifetimeArea(x.LifetimeArea)
			select x).ToArray<ObjectEntry>();
			this._respawnPrevention.ExceptWith(other);
			foreach (ActiveObject activeObject in ((IEnumerable<ActiveObject>)(from x in this._activeObjects
			where !x.LockLifetime && !this.IsInLifetimeArea(x.LifetimeArea) && (!this.IsInLifetimeArea(x.Entry.LifetimeArea) || x.IsSubObject)
			select x).ToArray<ActiveObject>()))
			{
				this.DeactivateObject(activeObject);
				this._respawnPrevention.Remove(activeObject.Entry);
			}
			List<ObjectEntry> list = new List<ObjectEntry>();
			foreach (Rectanglei region in this._lifeTimeAreas)
			{
				list.AddRange(this._objectEntryTable.GetAllInRegion(region));
			}
			foreach (ObjectEntry objectEntry in list)
			{
				if (objectEntry.Active == null && !this._respawnPrevention.Contains(objectEntry))
				{
					this.ActivateObjectEntry(objectEntry);
				}
			}
		}

		// Token: 0x06000CCC RID: 3276 RVA: 0x00031164 File Offset: 0x0002F364
		public void RegisterObjectTypes()
		{
			foreach (ObjectType objectType in ObjectType.LoadedTypes.Except(this._registeredTypes).ToArray<ObjectType>())
			{
				this._registeredTypes.Add(objectType);
				objectType.Register(this._level);
			}
		}

		// Token: 0x06000CCD RID: 3277 RVA: 0x000311B4 File Offset: 0x0002F3B4
		public void UnregisterObjectTypes()
		{
			foreach (ObjectType objectType in this._registeredTypes)
			{
				objectType.Unregister();
			}
			this._registeredTypes.Clear();
		}

		// Token: 0x06000CCE RID: 3278 RVA: 0x00031210 File Offset: 0x0002F410
		private void StartObjectTypes()
		{
			foreach (ObjectType objectType in this._registeredTypes)
			{
				objectType.Start();
			}
		}

		// Token: 0x06000CCF RID: 3279 RVA: 0x00031260 File Offset: 0x0002F460
		private void StopObjectTypes()
		{
			foreach (ObjectType objectType in this._registeredTypes)
			{
				objectType.Stop();
			}
		}

		// Token: 0x06000CD0 RID: 3280 RVA: 0x000312B0 File Offset: 0x0002F4B0
		private void UpdateObjectTypes()
		{
			foreach (ObjectType objectType in this._registeredTypes)
			{
				objectType.Update();
			}
		}

		// Token: 0x06000CD1 RID: 3281 RVA: 0x00031300 File Offset: 0x0002F500
		private void AnimateObjectTypes()
		{
			foreach (ObjectType objectType in this._registeredTypes)
			{
				objectType.Animate();
			}
		}

		// Token: 0x06000CD2 RID: 3282 RVA: 0x00031350 File Offset: 0x0002F550
		private void UpdateEditorActiveObjects()
		{
			foreach (ActiveObject activeObject in this._activeObjects)
			{
				activeObject.UpdateEditor();
			}
		}

		// Token: 0x06000CD3 RID: 3283 RVA: 0x000313A0 File Offset: 0x0002F5A0
		private void UpdatePrepareActiveObjects()
		{
			foreach (ActiveObject activeObject in this._activeObjects)
			{
				activeObject.UpdatePrepare();
			}
		}

		// Token: 0x06000CD4 RID: 3284 RVA: 0x000313F0 File Offset: 0x0002F5F0
		private void UpdateActiveObjects()
		{
			foreach (ActiveObject activeObject in this._activeObjects)
			{
				activeObject.Update();
			}
		}

		// Token: 0x06000CD5 RID: 3285 RVA: 0x00031440 File Offset: 0x0002F640
		private void UpdateCollisionActiveObjects()
		{
			foreach (ActiveObject activeObject in this._activeObjects)
			{
				activeObject.UpdateCollision();
			}
		}

		// Token: 0x06000CD6 RID: 3286 RVA: 0x00031490 File Offset: 0x0002F690
		private void AnimateActiveObjects()
		{
			foreach (ActiveObject activeObject in this._activeObjects)
			{
				activeObject.Animate();
			}
		}

		// Token: 0x06000CD7 RID: 3287 RVA: 0x000314E0 File Offset: 0x0002F6E0
		public void RemoveFinishedActiveObjects()
		{
			foreach (ActiveObject activeObject in (from x in this._activeObjects
			where x.Finished
			select x).ToArray<ActiveObject>())
			{
				this.DeactivateObject(activeObject);
			}
		}

		// Token: 0x06000CD8 RID: 3288 RVA: 0x00031536 File Offset: 0x0002F736
		public void RemoveFinishedEntries()
		{
			this._objectEntryTable.RemoveFinishedEntries();
		}

		// Token: 0x06000CD9 RID: 3289 RVA: 0x00031544 File Offset: 0x0002F744
		public ICharacter GetClosestCharacterTo(Vector2 position)
		{
			IEnumerable<ICharacter> enumerable = from x in this._activeObjects
			where x.Type.Classification == ObjectClassification.Character
			select (ICharacter)x into x
			where !x.IsDead && !x.IsDebug && !x.IsDying
			select x;
			ICharacter character = null;
			double num = double.NaN;
			foreach (ICharacter character2 in enumerable)
			{
				double length = (position - character2.Position).Length;
				if (character == null || length < num)
				{
					character = character2;
					num = length;
				}
			}
			return character;
		}

		// Token: 0x06000CDA RID: 3290 RVA: 0x0003162C File Offset: 0x0002F82C
		public void FinishSubObjects(ActiveObject parent)
		{
			IEnumerable<ActiveObject> activeObjects = this._activeObjects;
			Func<ActiveObject, bool> <>9__0;
			Func<ActiveObject, bool> predicate;
			if ((predicate = <>9__0) == null)
			{
				predicate = (<>9__0 = ((ActiveObject x) => x.ParentObject == parent));
			}
			foreach (ActiveObject activeObject in activeObjects.Where(predicate))
			{
				activeObject.Finish();
			}
		}

		// Token: 0x06000CDB RID: 3291 RVA: 0x000316A8 File Offset: 0x0002F8A8
		public bool IsCharacterStandingOn(CollisionVector v)
		{
			using (IEnumerator<ICharacter> enumerator = this.Characters.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.GroundVector == v)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x04000746 RID: 1862
		private readonly List<ObjectType> _registeredTypes = new List<ObjectType>();

		// Token: 0x04000747 RID: 1863
		private readonly ObjectEntryTable _objectEntryTable;

		// Token: 0x04000748 RID: 1864
		private readonly List<ActiveObject> _activeObjects = new List<ActiveObject>();

		// Token: 0x04000749 RID: 1865
		private readonly List<ActiveObject> _newActiveObjects = new List<ActiveObject>();

		// Token: 0x0400074A RID: 1866
		private readonly HashSet<ObjectEntry> _respawnPrevention = new HashSet<ObjectEntry>();

		// Token: 0x0400074B RID: 1867
		private readonly List<Rectanglei> _lifeTimeAreas = new List<Rectanglei>();

		// Token: 0x0400074C RID: 1868
		private readonly Level _level;
	}
}
