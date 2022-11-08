using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using SonicOrca.Core.Extensions;

namespace SonicOrca.Core.Objects.Metadata
{
	// Token: 0x02000163 RID: 355
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
	public class StateVariableAttribute : Attribute
	{
		// Token: 0x170003CD RID: 973
		// (get) Token: 0x06000ECC RID: 3788 RVA: 0x00037900 File Offset: 0x00035B00
		// (set) Token: 0x06000ECD RID: 3789 RVA: 0x0003791C File Offset: 0x00035B1C
		public string Name
		{
			get
			{
				if (this._type == null)
				{
					throw new TypeAccessException();
				}
				return this._name;
			}
			private set
			{
				if (this._type == null)
				{
					throw new TypeAccessException();
				}
				this._name = value;
			}
		}

		// Token: 0x170003CE RID: 974
		// (get) Token: 0x06000ECE RID: 3790 RVA: 0x00037939 File Offset: 0x00035B39
		// (set) Token: 0x06000ECF RID: 3791 RVA: 0x00037955 File Offset: 0x00035B55
		public object DefaultValue
		{
			get
			{
				if (this._type == null)
				{
					throw new TypeAccessException();
				}
				return this._defaultValue;
			}
			private set
			{
				if (this._type == null)
				{
					throw new TypeAccessException();
				}
				this._defaultValue = value;
			}
		}

		// Token: 0x170003CF RID: 975
		// (get) Token: 0x06000ED0 RID: 3792 RVA: 0x00037972 File Offset: 0x00035B72
		// (set) Token: 0x06000ED1 RID: 3793 RVA: 0x0003798E File Offset: 0x00035B8E
		public Type Type
		{
			get
			{
				if (this._type == null)
				{
					throw new TypeAccessException();
				}
				return this._type;
			}
			private set
			{
				this._type = value;
			}
		}

		// Token: 0x06000ED3 RID: 3795 RVA: 0x000379AA File Offset: 0x00035BAA
		public static IEnumerable<Tuple<MemberInfo, StateVariableAttribute>> GetStateVariables(Type type)
		{
			object instance = Activator.CreateInstance(type);
			IEnumerable<MemberInfo> publicDeclaredMembers = type.GetUnderlyingMembers(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public);
			foreach (MemberInfo memberInfo in publicDeclaredMembers)
			{
				if (memberInfo.GetCustomAttribute<HideInEditorAttribute>() == null)
				{
					yield return new Tuple<MemberInfo, StateVariableAttribute>(memberInfo, new StateVariableAttribute
					{
						Type = memberInfo.GetUnderlyingType(),
						Name = memberInfo.Name,
						DefaultValue = memberInfo.GetUnderlyingValue(instance)
					});
				}
			}
			IEnumerator<MemberInfo> enumerator = null;
			IEnumerable<MemberInfo> enumerable = type.GetUnderlyingMembers(BindingFlags.Instance | BindingFlags.Public).Except(publicDeclaredMembers);
			foreach (MemberInfo memberInfo2 in enumerable)
			{
				StateVariableAttribute customAttribute = memberInfo2.GetCustomAttribute<StateVariableAttribute>();
				if (customAttribute != null)
				{
					customAttribute.Type = memberInfo2.GetUnderlyingType();
					customAttribute.Name = memberInfo2.Name;
					customAttribute.DefaultValue = memberInfo2.GetUnderlyingValue(instance);
					yield return new Tuple<MemberInfo, StateVariableAttribute>(memberInfo2, customAttribute);
				}
			}
			enumerator = null;
			IEnumerable<MemberInfo> underlyingMembers = type.GetUnderlyingMembers(BindingFlags.Instance | BindingFlags.NonPublic);
			foreach (MemberInfo memberInfo3 in underlyingMembers)
			{
				StateVariableAttribute customAttribute2 = memberInfo3.GetCustomAttribute<StateVariableAttribute>();
				if (customAttribute2 != null)
				{
					customAttribute2.Type = memberInfo3.GetUnderlyingType();
					customAttribute2.Name = memberInfo3.Name;
					customAttribute2.DefaultValue = memberInfo3.GetUnderlyingValue(instance);
					yield return new Tuple<MemberInfo, StateVariableAttribute>(memberInfo3, customAttribute2);
				}
			}
			enumerator = null;
			yield break;
			yield break;
		}

		// Token: 0x06000ED4 RID: 3796 RVA: 0x000379BC File Offset: 0x00035BBC
		public static void SetObjectState(IActiveObject instance, IActiveObject state)
		{
			BindingFlags bindingAttr = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
			foreach (Tuple<MemberInfo, StateVariableAttribute> tuple in StateVariableAttribute.GetStateVariables(instance.GetType()))
			{
				MemberInfo item = tuple.Item1;
				MemberInfo memberInfo = state.GetType().GetMember(item.Name, bindingAttr).FirstOrDefault<MemberInfo>();
				if (memberInfo != null)
				{
					object underlyingValue = memberInfo.GetUnderlyingValue(state);
					item.SetUnderlyingValue(instance, underlyingValue);
				}
			}
		}

		// Token: 0x06000ED5 RID: 3797 RVA: 0x00037A44 File Offset: 0x00035C44
		private static bool EnumTryParse(Type enumType, string name, out object enumValue, bool ignoreCase = false)
		{
			enumValue = null;
			try
			{
				enumValue = Enum.Parse(enumType, name, ignoreCase);
				return true;
			}
			catch
			{
			}
			return false;
		}

		// Token: 0x06000ED6 RID: 3798 RVA: 0x00037A78 File Offset: 0x00035C78
		public static ObjectEditorProperty[] GetEditorProperties(ObjectType objType)
		{
			ObjectInstanceAttribute objectInstanceAttribute = ObjectInstanceAttribute.FromObject(objType);
			if (objectInstanceAttribute == null)
			{
				return new ObjectEditorProperty[0];
			}
			Type objectInstanceType = objectInstanceAttribute.ObjectInstanceType;
			List<ObjectEditorProperty> list = new List<ObjectEditorProperty>();
			foreach (Tuple<MemberInfo, StateVariableAttribute> tuple in StateVariableAttribute.GetStateVariables(objectInstanceType))
			{
				MemberInfo item = tuple.Item1;
				StateVariableAttribute item2 = tuple.Item2;
				list.Add(new ObjectEditorProperty(item2.Name, item2.Name, item2.Type, item2.DefaultValue, null));
			}
			return list.ToArray();
		}

		// Token: 0x0400084D RID: 2125
		private object _defaultValue;

		// Token: 0x0400084E RID: 2126
		private Type _type;

		// Token: 0x0400084F RID: 2127
		private string _name = "";
	}
}
