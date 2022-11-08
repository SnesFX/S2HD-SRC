using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace SonicOrca
{
	// Token: 0x02000002 RID: 2
	public static class AttributeHelpers
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		public static string GetDescription(object value)
		{
			DescriptionAttribute attribute = AttributeHelpers.GetAttribute<DescriptionAttribute>(value);
			if (attribute != null)
			{
				return attribute.Description;
			}
			return null;
		}

		// Token: 0x06000002 RID: 2 RVA: 0x00002070 File Offset: 0x00000270
		public static T GetAttribute<T>(object value) where T : Attribute
		{
			Type type = value as Type;
			if (!(type == null))
			{
				return type.GetCustomAttribute<T>();
			}
			type = value.GetType();
			if (!type.IsEnum)
			{
				throw new ArgumentException("Value must be a Type or Enum value.", "value");
			}
			return type.GetMember(value.ToString()).First<MemberInfo>().GetCustomAttribute<T>();
		}
	}
}
