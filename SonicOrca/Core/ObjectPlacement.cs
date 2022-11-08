using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;
using SonicOrca.Core.Extensions;
using SonicOrca.Core.Objects.Metadata;
using SonicOrca.Geometry;

namespace SonicOrca.Core
{
	// Token: 0x0200013E RID: 318
	public class ObjectPlacement
	{
		// Token: 0x17000332 RID: 818
		// (get) Token: 0x06000CDE RID: 3294 RVA: 0x00031742 File Offset: 0x0002F942
		// (set) Token: 0x06000CDF RID: 3295 RVA: 0x0003174A File Offset: 0x0002F94A
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

		// Token: 0x17000333 RID: 819
		// (get) Token: 0x06000CE0 RID: 3296 RVA: 0x00031753 File Offset: 0x0002F953
		// (set) Token: 0x06000CE1 RID: 3297 RVA: 0x0003175B File Offset: 0x0002F95B
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

		// Token: 0x17000334 RID: 820
		// (get) Token: 0x06000CE2 RID: 3298 RVA: 0x00031764 File Offset: 0x0002F964
		// (set) Token: 0x06000CE3 RID: 3299 RVA: 0x0003176C File Offset: 0x0002F96C
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

		// Token: 0x17000335 RID: 821
		// (get) Token: 0x06000CE4 RID: 3300 RVA: 0x00031775 File Offset: 0x0002F975
		// (set) Token: 0x06000CE5 RID: 3301 RVA: 0x0003177D File Offset: 0x0002F97D
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

		// Token: 0x17000336 RID: 822
		// (get) Token: 0x06000CE6 RID: 3302 RVA: 0x00031786 File Offset: 0x0002F986
		// (set) Token: 0x06000CE7 RID: 3303 RVA: 0x0003178E File Offset: 0x0002F98E
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

		// Token: 0x17000337 RID: 823
		// (get) Token: 0x06000CE8 RID: 3304 RVA: 0x00031797 File Offset: 0x0002F997
		public IReadOnlyCollection<KeyValuePair<string, object>> Entry
		{
			get
			{
				return this._entry;
			}
		}

		// Token: 0x17000338 RID: 824
		// (get) Token: 0x06000CE9 RID: 3305 RVA: 0x0003179F File Offset: 0x0002F99F
		public IReadOnlyCollection<KeyValuePair<string, object>> Behaviour
		{
			get
			{
				return this._behaviour;
			}
		}

		// Token: 0x17000339 RID: 825
		// (get) Token: 0x06000CEA RID: 3306 RVA: 0x000317A7 File Offset: 0x0002F9A7
		// (set) Token: 0x06000CEB RID: 3307 RVA: 0x000317AF File Offset: 0x0002F9AF
		public IReadOnlyCollection<KeyValuePair<string, object>> Mappings
		{
			get
			{
				return this._mappings;
			}
			set
			{
				this._mappings = value;
			}
		}

		// Token: 0x06000CEC RID: 3308 RVA: 0x000317B8 File Offset: 0x0002F9B8
		public ObjectPlacement(string key, int layer, Vector2i position)
		{
			var <>f__AnonymousType = new
			{
				Key = key,
				Uid = Guid.NewGuid(),
				Name = "",
				Layer = layer,
				Position = new
				{
					position.X,
					position.Y
				}
			};
			<>f__AnonymousType2 state = new
			{

			};
			this._key = key;
			this._uid = <>f__AnonymousType.Uid;
			this._name = "";
			this._layer = layer;
			this._position = position;
			this.ParseProperties(<>f__AnonymousType, state);
		}

		// Token: 0x06000CED RID: 3309 RVA: 0x0003184C File Offset: 0x0002FA4C
		public ObjectPlacement(string key, int layer, Vector2i position, object state)
		{
			var <>f__AnonymousType = new
			{
				Key = key,
				Uid = Guid.NewGuid(),
				Name = "",
				Layer = layer,
				Position = new
				{
					position.X,
					position.Y
				}
			};
			this._key = key;
			this._uid = <>f__AnonymousType.Uid;
			this._name = "";
			this._layer = layer;
			this._position = position;
			this.ParseProperties(<>f__AnonymousType, state);
		}

		// Token: 0x06000CEE RID: 3310 RVA: 0x000318DC File Offset: 0x0002FADC
		public ObjectPlacement(string key, Guid uid, string name, int layer, Vector2i position, object state)
		{
			var entry = new
			{
				Key = key,
				Uid = uid,
				Name = name,
				Layer = layer,
				Position = new
				{
					position.X,
					position.Y
				}
			};
			this._key = key;
			this._uid = uid;
			this._name = name;
			this._layer = layer;
			this._position = position;
			this.ParseProperties(entry, state);
		}

		// Token: 0x06000CEF RID: 3311 RVA: 0x0003195C File Offset: 0x0002FB5C
		private void ParseProperties(object entry, object state)
		{
			this._entry = ObjectPlacement.BehaviourToKeyPairs(entry).ToArray<KeyValuePair<string, object>>();
			if (state == null)
			{
				throw new Exception();
			}
			if (state.GetType().IsAnonymous() || state.GetType() == typeof(ExpandoObject))
			{
				this._behaviour = ObjectPlacement.BehaviourToKeyPairs(state).ToArray<KeyValuePair<string, object>>();
				return;
			}
			this._behaviour = ObjectPlacement.StateToKeyPairs(state).ToArray<KeyValuePair<string, object>>();
		}

		// Token: 0x06000CF0 RID: 3312 RVA: 0x000319CC File Offset: 0x0002FBCC
		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendFormat("Key = {0} X = {1} Y = {2}", this._key, this._position.X, this._position.Y);
			if (this._behaviour.Count > 0)
			{
				stringBuilder.Append(" Entry = ");
				ObjectPlacement.WriteBehaviourString(stringBuilder, this._entry);
				stringBuilder.Append(" Behaviour = ");
				ObjectPlacement.WriteBehaviourString(stringBuilder, this._behaviour);
			}
			return stringBuilder.ToString();
		}

		// Token: 0x06000CF1 RID: 3313 RVA: 0x00031A58 File Offset: 0x0002FC58
		private static void WriteBehaviourString(StringBuilder sb, IEnumerable<KeyValuePair<string, object>> behaviourObject)
		{
			sb.Append("{ ");
			foreach (KeyValuePair<string, object> keyValuePair in behaviourObject)
			{
				sb.Append(keyValuePair.Key);
				sb.Append(" = ");
				if (keyValuePair.Value is IEnumerable<KeyValuePair<string, object>>)
				{
					ObjectPlacement.WriteBehaviourString(sb, behaviourObject);
				}
				else
				{
					sb.Append(keyValuePair.Value);
				}
				sb.Append(" ");
			}
			sb.Append("}");
		}

		// Token: 0x06000CF2 RID: 3314 RVA: 0x00031AFC File Offset: 0x0002FCFC
		private static IEnumerable<KeyValuePair<string, object>> StateToKeyPairs(object obj)
		{
			IEnumerable<Tuple<MemberInfo, StateVariableAttribute>> stateVariables = StateVariableAttribute.GetStateVariables(obj.GetType());
			object defaultState = Activator.CreateInstance(obj.GetType()) as ActiveObject;
			Type defaultType = defaultState.GetType();
			BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
			foreach (Tuple<MemberInfo, StateVariableAttribute> tuple in stateVariables)
			{
				MemberInfo item = tuple.Item1;
				Type underlyingType = item.GetUnderlyingType();
				string name = item.Name;
				object value = ObjectPlacement.ParseStateValue(item.GetUnderlyingValue(obj), underlyingType);
				MemberInfo member = defaultType.GetMember(item.Name, bindingFlags).First<MemberInfo>();
				member.GetUnderlyingType();
				object underlyingValue = item.GetUnderlyingValue(obj);
				object underlyingValue2 = member.GetUnderlyingValue(defaultState);
				if (!ObjectPlacement.StateValueEquals(underlyingValue, underlyingValue2, underlyingType))
				{
					yield return new KeyValuePair<string, object>(name, value);
				}
			}
			IEnumerator<Tuple<MemberInfo, StateVariableAttribute>> enumerator = null;
			yield break;
			yield break;
		}

		// Token: 0x06000CF3 RID: 3315 RVA: 0x00031B0C File Offset: 0x0002FD0C
		private static object ParseStateValue(object value, Type type)
		{
			if (value == null)
			{
				return value;
			}
			if (type.IsSubclassOf(typeof(ActiveObject)) || type == typeof(ActiveObject))
			{
				return new KeyValuePair<string, object>("Target", (value as ActiveObject).Uid.ToString());
			}
			if (type == typeof(Vector2))
			{
				List<KeyValuePair<string, object>> list = new List<KeyValuePair<string, object>>();
				KeyValuePair<string, object> item = new KeyValuePair<string, object>("X", ((Vector2)value).X);
				KeyValuePair<string, object> item2 = new KeyValuePair<string, object>("Y", ((Vector2)value).Y);
				list.Add(item);
				list.Add(item2);
				return list;
			}
			if (type == typeof(Vector2i))
			{
				List<KeyValuePair<string, object>> list2 = new List<KeyValuePair<string, object>>();
				KeyValuePair<string, object> item3 = new KeyValuePair<string, object>("X", ((Vector2i)value).X);
				KeyValuePair<string, object> item4 = new KeyValuePair<string, object>("Y", ((Vector2i)value).Y);
				list2.Add(item3);
				list2.Add(item4);
				return list2;
			}
			return value.ToString();
		}

		// Token: 0x06000CF4 RID: 3316 RVA: 0x00031C40 File Offset: 0x0002FE40
		private static bool StateValueEquals(object value1, object value2, Type type)
		{
			if (value1 == null || value2 == null)
			{
				return value1 == null && value2 == null;
			}
			if (type.IsSubclassOf(typeof(ActiveObject)) || type == typeof(ActiveObject))
			{
				return (value1 as ActiveObject).Uid.ToString() == (value2 as ActiveObject).Uid.ToString();
			}
			if (type == typeof(Vector2))
			{
				return ((Vector2)value1).Equals((Vector2)value2);
			}
			if (type == typeof(Vector2i))
			{
				return ((Vector2i)value1).Equals((Vector2i)value2);
			}
			return value1.ToString() == value2.ToString();
		}

		// Token: 0x06000CF5 RID: 3317 RVA: 0x00031D18 File Offset: 0x0002FF18
		private static IEnumerable<KeyValuePair<string, object>> BehaviourToKeyPairs(object behaviour)
		{
			if (behaviour.GetType() == typeof(ExpandoObject))
			{
				return behaviour as IDictionary<string, object>;
			}
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			foreach (object obj in TypeDescriptor.GetProperties(behaviour))
			{
				PropertyDescriptor propertyDescriptor = (PropertyDescriptor)obj;
				object value = propertyDescriptor.GetValue(behaviour);
				dictionary.Add(propertyDescriptor.Name, value);
			}
			return dictionary;
		}

		// Token: 0x0400074D RID: 1869
		private string _key;

		// Token: 0x0400074E RID: 1870
		private Guid _uid;

		// Token: 0x0400074F RID: 1871
		private string _name;

		// Token: 0x04000750 RID: 1872
		private int _layer;

		// Token: 0x04000751 RID: 1873
		private Vector2i _position;

		// Token: 0x04000752 RID: 1874
		private IReadOnlyCollection<KeyValuePair<string, object>> _entry = new List<KeyValuePair<string, object>>();

		// Token: 0x04000753 RID: 1875
		private IReadOnlyCollection<KeyValuePair<string, object>> _behaviour = new List<KeyValuePair<string, object>>();

		// Token: 0x04000754 RID: 1876
		private IReadOnlyCollection<KeyValuePair<string, object>> _mappings = new List<KeyValuePair<string, object>>();
	}
}
