using System;
using System.Reflection;
using SonicOrca.Resources;

namespace SonicOrca.Extensions
{
	// Token: 0x02000002 RID: 2
	public static class ResourceExtensions
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		public static string GetAbsolutePath(this ILoadedResource parentLoadedResource, string keyPath)
		{
			return parentLoadedResource.Resource.GetAbsolutePath(keyPath);
		}

		// Token: 0x06000002 RID: 2 RVA: 0x00002060 File Offset: 0x00000260
		public static void FullfillLoadedResourcesByAttribute(this ResourceTree tree, object instance)
		{
			foreach (MemberInfo memberInfo in instance.GetType().GetMembers(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
			{
				MemberTypes memberType = memberInfo.MemberType;
				if (memberType != MemberTypes.Field)
				{
					if (memberType == MemberTypes.Property)
					{
						ResourcePathAttribute customAttribute = memberInfo.GetCustomAttribute<ResourcePathAttribute>();
						if (customAttribute != null)
						{
							PropertyInfo propertyInfo = (PropertyInfo)memberInfo;
							string path = customAttribute.Path;
							ILoadedResource loadedResource = tree.GetLoadedResource(path);
							Type type = loadedResource.GetType();
							if (!propertyInfo.PropertyType.IsAssignableFrom(type))
							{
								throw new ResourceException(path + " doesn't have the correct resource type.");
							}
							propertyInfo.SetValue(instance, loadedResource);
						}
					}
				}
				else
				{
					ResourcePathAttribute customAttribute = memberInfo.GetCustomAttribute<ResourcePathAttribute>();
					if (customAttribute != null)
					{
						FieldInfo fieldInfo = (FieldInfo)memberInfo;
						string path2 = customAttribute.Path;
						ILoadedResource loadedResource2 = tree.GetLoadedResource(path2);
						if (!fieldInfo.FieldType.IsAssignableFrom(loadedResource2.GetType()))
						{
							throw new ResourceException(path2 + " doesn't have the correct resource type.");
						}
						fieldInfo.SetValue(instance, loadedResource2);
					}
				}
			}
		}

		// Token: 0x06000003 RID: 3 RVA: 0x00002154 File Offset: 0x00000354
		public static void PushDependenciesByAttribute(this ResourceSession session, object instance)
		{
			MemberInfo[] members = instance.GetType().GetMembers(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			for (int i = 0; i < members.Length; i++)
			{
				ResourcePathAttribute customAttribute = members[i].GetCustomAttribute<ResourcePathAttribute>();
				if (customAttribute != null)
				{
					session.PushDependency(customAttribute.Path);
				}
			}
		}
	}
}
