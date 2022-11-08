using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using SonicOrca.Core.Extensions;
using SonicOrca.Core.Objects.Metadata;
using SonicOrca.Geometry;

namespace SonicOrca.Core
{
	// Token: 0x0200013A RID: 314
	public class ObjectEntry
	{
		// Token: 0x1700031A RID: 794
		// (get) Token: 0x06000C85 RID: 3205 RVA: 0x00030047 File Offset: 0x0002E247
		// (set) Token: 0x06000C86 RID: 3206 RVA: 0x0003004F File Offset: 0x0002E24F
		public int Layer { get; set; }

		// Token: 0x1700031B RID: 795
		// (get) Token: 0x06000C87 RID: 3207 RVA: 0x00030058 File Offset: 0x0002E258
		// (set) Token: 0x06000C88 RID: 3208 RVA: 0x00030060 File Offset: 0x0002E260
		public Vector2i Position { get; set; }

		// Token: 0x1700031C RID: 796
		// (get) Token: 0x06000C89 RID: 3209 RVA: 0x00030069 File Offset: 0x0002E269
		// (set) Token: 0x06000C8A RID: 3210 RVA: 0x00030071 File Offset: 0x0002E271
		public bool FinishedForever { get; private set; }

		// Token: 0x1700031D RID: 797
		// (get) Token: 0x06000C8B RID: 3211 RVA: 0x0003007A File Offset: 0x0002E27A
		// (set) Token: 0x06000C8C RID: 3212 RVA: 0x00030082 File Offset: 0x0002E282
		public ActiveObject Active { get; set; }

		// Token: 0x1700031E RID: 798
		// (get) Token: 0x06000C8D RID: 3213 RVA: 0x0003008B File Offset: 0x0002E28B
		public Level Level
		{
			get
			{
				return this._level;
			}
		}

		// Token: 0x1700031F RID: 799
		// (get) Token: 0x06000C8E RID: 3214 RVA: 0x00030093 File Offset: 0x0002E293
		public ObjectType Type
		{
			get
			{
				return this._type;
			}
		}

		// Token: 0x17000320 RID: 800
		// (get) Token: 0x06000C8F RID: 3215 RVA: 0x0003009B File Offset: 0x0002E29B
		public ActiveObject State
		{
			get
			{
				return this._state;
			}
		}

		// Token: 0x17000321 RID: 801
		// (get) Token: 0x06000C90 RID: 3216 RVA: 0x000300A3 File Offset: 0x0002E2A3
		// (set) Token: 0x06000C91 RID: 3217 RVA: 0x000300AB File Offset: 0x0002E2AB
		public string Key
		{
			get
			{
				return this._key;
			}
			private set
			{
				this._key = value;
			}
		}

		// Token: 0x17000322 RID: 802
		// (get) Token: 0x06000C92 RID: 3218 RVA: 0x000300B4 File Offset: 0x0002E2B4
		// (set) Token: 0x06000C93 RID: 3219 RVA: 0x000300BC File Offset: 0x0002E2BC
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

		// Token: 0x17000323 RID: 803
		// (get) Token: 0x06000C94 RID: 3220 RVA: 0x000300C5 File Offset: 0x0002E2C5
		// (set) Token: 0x06000C95 RID: 3221 RVA: 0x000300CD File Offset: 0x0002E2CD
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

		// Token: 0x17000324 RID: 804
		// (get) Token: 0x06000C96 RID: 3222 RVA: 0x000300D6 File Offset: 0x0002E2D6
		public IList<ObjectMapping> Mappings
		{
			get
			{
				return this._mappings;
			}
		}

		// Token: 0x06000C97 RID: 3223 RVA: 0x000300E0 File Offset: 0x0002E2E0
		public ObjectEntry(Level level, ObjectType type, LevelLayer layer, Vector2i position, Guid uid = default(Guid))
		{
			this._level = level;
			this.Layer = this.Level.Map.Layers.IndexOf(layer);
			this.Position = position;
			this._type = type;
			this._uid = uid;
			throw new NotImplementedException();
		}

		// Token: 0x06000C98 RID: 3224 RVA: 0x00030140 File Offset: 0x0002E340
		public ObjectEntry(Level level, ObjectPlacement placement)
		{
			if (placement.Entry.Count > 0)
			{
				this.SetKeyValuePairReflection(placement.Entry, this);
			}
			else
			{
				this._uid = Guid.NewGuid();
			}
			this._level = level;
			this._type = level.GameContext.ResourceTree.GetLoadedResource<ObjectType>(this._key);
			this.CreateState();
			if (placement.Behaviour.Count > 0)
			{
				this.SetKeyValuePairReflection(placement.Behaviour, this._state);
			}
			if (placement.Mappings.Count > 0)
			{
				foreach (KeyValuePair<string, object> keyValuePair in placement.Mappings)
				{
					this.Mappings.Add(new ObjectMapping(keyValuePair.Key, Guid.Parse(keyValuePair.Value.ToString())));
				}
			}
		}

		// Token: 0x06000C99 RID: 3225 RVA: 0x00030240 File Offset: 0x0002E440
		private void CreateState()
		{
			ObjectInstanceAttribute objectInstanceAttribute = ObjectInstanceAttribute.FromObject(this._type);
			if (objectInstanceAttribute == null)
			{
				throw new Exception();
			}
			Type objectInstanceType = objectInstanceAttribute.ObjectInstanceType;
			this._state = (Activator.CreateInstance(objectInstanceType) as ActiveObject);
		}

		// Token: 0x06000C9A RID: 3226 RVA: 0x00006325 File Offset: 0x00004525
		private void RebindState()
		{
		}

		// Token: 0x06000C9B RID: 3227 RVA: 0x00030278 File Offset: 0x0002E478
		public void Finish()
		{
			if (this.Active != null)
			{
				this.Active.Finish();
			}
		}

		// Token: 0x06000C9C RID: 3228 RVA: 0x0003028D File Offset: 0x0002E48D
		public void FinishForever()
		{
			this.FinishedForever = true;
		}

		// Token: 0x06000C9D RID: 3229 RVA: 0x00030296 File Offset: 0x0002E496
		public ActiveObject CreateActiveObject()
		{
			this.Active = this.Type.CreateInstance();
			this.Active.Initialise(this);
			return this.Active;
		}

		// Token: 0x06000C9E RID: 3230 RVA: 0x000302BB File Offset: 0x0002E4BB
		public T CreateSubObject<T>() where T : ActiveObject
		{
			this.Active = Activator.CreateInstance<T>();
			this.Active.Initialise(this);
			return (T)((object)this.Active);
		}

		// Token: 0x17000325 RID: 805
		// (get) Token: 0x06000C9F RID: 3231 RVA: 0x000302E4 File Offset: 0x0002E4E4
		public Rectanglei LifetimeArea
		{
			get
			{
				Vector2 lifeRadius = this._type.GetLifeRadius(this._state);
				Vector2 vector = new Vector2((double)this.Position.X - lifeRadius.X, (double)this.Position.Y - lifeRadius.Y);
				return new Rectangle(vector.X, vector.Y, lifeRadius.X * 2.0, lifeRadius.Y * 2.0);
			}
		}

		// Token: 0x06000CA0 RID: 3232 RVA: 0x00030374 File Offset: 0x0002E574
		private object SetKeyValuePairReflection(IEnumerable<KeyValuePair<string, object>> behaviour, object targetObject)
		{
			BindingFlags bindingAttr = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
			using (IEnumerator<KeyValuePair<string, object>> enumerator = behaviour.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					KeyValuePair<string, object> kvp = enumerator.Current;
					if (kvp.Value is IEnumerable<KeyValuePair<string, object>>)
					{
						MemberInfo memberInfo = (from m in targetObject.GetType().GetMembers(bindingAttr)
						select m into m
						where m.Name == kvp.Key
						select m).FirstOrDefault<MemberInfo>();
						if (!(memberInfo != null))
						{
							throw new Exception();
						}
						object obj = memberInfo.GetUnderlyingValue(targetObject);
						if (!memberInfo.GetUnderlyingType().IsSubclassOf(typeof(ActiveObject)) && !(memberInfo.GetUnderlyingType() == typeof(IActiveObject)))
						{
							obj = this.SetKeyValuePairReflection((IEnumerable<KeyValuePair<string, object>>)kvp.Value, obj);
							memberInfo.SetUnderlyingValue(targetObject, obj);
						}
					}
					else
					{
						MemberInfo memberInfo2 = (from m in targetObject.GetType().GetMembers(bindingAttr)
						select m into m
						where m.Name == kvp.Key
						select m).FirstOrDefault<MemberInfo>();
						if (!(memberInfo2 != null))
						{
							throw new Exception();
						}
						string value = Convert.ToString(kvp.Value, CultureInfo.InvariantCulture);
						memberInfo2.SetUnderlyingValue(targetObject, LevelBindingResourceType.ParseBehaviourValue(value, memberInfo2.GetUnderlyingType()));
					}
				}
			}
			return targetObject;
		}

		// Token: 0x06000CA1 RID: 3233 RVA: 0x00030534 File Offset: 0x0002E734
		public override string ToString()
		{
			return this.Name;
		}

		// Token: 0x04000733 RID: 1843
		private readonly Level _level;

		// Token: 0x04000734 RID: 1844
		private readonly ObjectType _type;

		// Token: 0x04000735 RID: 1845
		private string _key;

		// Token: 0x04000736 RID: 1846
		private ActiveObject _state;

		// Token: 0x04000737 RID: 1847
		private Guid _uid;

		// Token: 0x04000738 RID: 1848
		private string _name;

		// Token: 0x04000739 RID: 1849
		private List<ObjectMapping> _mappings = new List<ObjectMapping>();
	}
}
