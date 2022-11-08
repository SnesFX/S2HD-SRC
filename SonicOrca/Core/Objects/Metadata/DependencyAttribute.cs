using System;
using System.Collections.Generic;
using System.Reflection;

namespace SonicOrca.Core.Objects.Metadata
{
	// Token: 0x0200015E RID: 350
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Field, AllowMultiple = true)]
	public class DependencyAttribute : Attribute
	{
		// Token: 0x170003C9 RID: 969
		// (get) Token: 0x06000EBE RID: 3774 RVA: 0x00037865 File Offset: 0x00035A65
		public string ResourceKey
		{
			get
			{
				return this._resourceKey;
			}
		}

		// Token: 0x06000EBF RID: 3775 RVA: 0x0003786D File Offset: 0x00035A6D
		public DependencyAttribute()
		{
		}

		// Token: 0x06000EC0 RID: 3776 RVA: 0x00037875 File Offset: 0x00035A75
		public DependencyAttribute(string resourceKey)
		{
			this._resourceKey = resourceKey;
		}

		// Token: 0x06000EC1 RID: 3777 RVA: 0x00037884 File Offset: 0x00035A84
		public static IEnumerable<string> GetDependencies(object obj)
		{
			Type objType = obj.GetType();
			foreach (DependencyAttribute dependencyAttribute in objType.GetCustomAttributes<DependencyAttribute>())
			{
				yield return dependencyAttribute.ResourceKey;
			}
			IEnumerator<DependencyAttribute> enumerator = null;
			MemberInfo[] members = objType.GetMembers(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
			foreach (MemberInfo memberInfo in members)
			{
				if (memberInfo.GetCustomAttribute<DependencyAttribute>() != null)
				{
					string text = null;
					if (memberInfo.MemberType == MemberTypes.Field)
					{
						FieldInfo fieldInfo = (FieldInfo)memberInfo;
						if (fieldInfo.FieldType == typeof(string))
						{
							text = (string)fieldInfo.GetValue(obj);
						}
					}
					else if (memberInfo.MemberType == MemberTypes.Property)
					{
						PropertyInfo propertyInfo = (PropertyInfo)memberInfo;
						if (propertyInfo.PropertyType == typeof(string) && propertyInfo.CanRead)
						{
							text = (string)propertyInfo.GetValue(obj);
						}
					}
					yield return text;
				}
			}
			MemberInfo[] array = null;
			yield break;
			yield break;
		}

		// Token: 0x04000849 RID: 2121
		private readonly string _resourceKey;
	}
}
