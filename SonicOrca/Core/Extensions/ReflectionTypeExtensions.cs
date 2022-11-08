using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace SonicOrca.Core.Extensions
{
	// Token: 0x0200018D RID: 397
	public static class ReflectionTypeExtensions
	{
		// Token: 0x06001138 RID: 4408 RVA: 0x00044198 File Offset: 0x00042398
		public static Type GetUnderlyingType(this MemberInfo member)
		{
			MemberTypes memberType = member.MemberType;
			if (memberType <= MemberTypes.Field)
			{
				if (memberType == MemberTypes.Event)
				{
					return ((EventInfo)member).EventHandlerType;
				}
				if (memberType == MemberTypes.Field)
				{
					return ((FieldInfo)member).FieldType;
				}
			}
			else
			{
				if (memberType == MemberTypes.Method)
				{
					return ((MethodInfo)member).ReturnType;
				}
				if (memberType == MemberTypes.Property)
				{
					return ((PropertyInfo)member).PropertyType;
				}
			}
			throw new ArgumentException("Input MemberInfo must be if type EventInfo, FieldInfo, MethodInfo, or PropertyInfo");
		}

		// Token: 0x06001139 RID: 4409 RVA: 0x00044200 File Offset: 0x00042400
		public static bool IsAssignableToGenericType(this Type givenType, Type genericType)
		{
			foreach (Type type in givenType.GetInterfaces())
			{
				if (type.IsGenericType && type.GetGenericTypeDefinition() == genericType)
				{
					return true;
				}
			}
			if (givenType.IsGenericType && givenType.GetGenericTypeDefinition() == genericType)
			{
				return true;
			}
			Type baseType = givenType.BaseType;
			return !(baseType == null) && baseType.IsAssignableToGenericType(genericType);
		}

		// Token: 0x0600113A RID: 4410 RVA: 0x00044270 File Offset: 0x00042470
		public static object GetUnderlyingValue(this MemberInfo member, object instance)
		{
			MemberTypes memberType = member.MemberType;
			if (memberType == MemberTypes.Field)
			{
				return ((FieldInfo)member).GetValue(instance);
			}
			if (memberType != MemberTypes.Property)
			{
				throw new ArgumentException("Input MemberInfo must be type FieldInfo, or PropertyInfo");
			}
			return ((PropertyInfo)member).GetValue(instance);
		}

		// Token: 0x0600113B RID: 4411 RVA: 0x000442B4 File Offset: 0x000424B4
		public static void SetUnderlyingValue(this MemberInfo member, object instance, object value)
		{
			MemberTypes memberType = member.MemberType;
			if (memberType == MemberTypes.Field)
			{
				((FieldInfo)member).SetValue(instance, value);
				return;
			}
			if (memberType != MemberTypes.Property)
			{
				throw new ArgumentException("Input MemberInfo must be type FieldInfo, or PropertyInfo");
			}
			((PropertyInfo)member).SetValue(instance, value);
		}

		// Token: 0x0600113C RID: 4412 RVA: 0x000442FC File Offset: 0x000424FC
		public static IEnumerable<MemberInfo> GetUnderlyingMembers(this Type type, BindingFlags bindingFlags)
		{
			IEnumerable<MemberInfo> first = type.GetFields(bindingFlags).Cast<MemberInfo>();
			IEnumerable<MemberInfo> second = type.GetProperties(bindingFlags).Cast<MemberInfo>();
			return first.Concat(second);
		}

		// Token: 0x0600113D RID: 4413 RVA: 0x00044328 File Offset: 0x00042528
		public static bool IsAnonymous(this Type type)
		{
			if (type == null)
			{
				throw new ArgumentNullException("type");
			}
			return Attribute.IsDefined(type, typeof(CompilerGeneratedAttribute), false) && type.Name.Contains("AnonymousType") && (type.Name.StartsWith("<>") || type.Name.StartsWith("VB$")) && (type.Attributes & TypeAttributes.NotPublic) == TypeAttributes.NotPublic;
		}
	}
}
