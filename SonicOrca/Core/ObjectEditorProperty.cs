using System;

namespace SonicOrca.Core
{
	// Token: 0x02000138 RID: 312
	public class ObjectEditorProperty
	{
		// Token: 0x17000313 RID: 787
		// (get) Token: 0x06000C79 RID: 3193 RVA: 0x0002FF41 File Offset: 0x0002E141
		public string Name
		{
			get
			{
				return this._name;
			}
		}

		// Token: 0x17000314 RID: 788
		// (get) Token: 0x06000C7A RID: 3194 RVA: 0x0002FF49 File Offset: 0x0002E149
		public string Key
		{
			get
			{
				return this._key;
			}
		}

		// Token: 0x17000315 RID: 789
		// (get) Token: 0x06000C7B RID: 3195 RVA: 0x0002FF51 File Offset: 0x0002E151
		public Type Type
		{
			get
			{
				return this._type;
			}
		}

		// Token: 0x17000316 RID: 790
		// (get) Token: 0x06000C7C RID: 3196 RVA: 0x0002FF59 File Offset: 0x0002E159
		public object DefaultValue
		{
			get
			{
				return this._defaultValue;
			}
		}

		// Token: 0x17000317 RID: 791
		// (get) Token: 0x06000C7D RID: 3197 RVA: 0x0002FF61 File Offset: 0x0002E161
		public string Description
		{
			get
			{
				return this._description;
			}
		}

		// Token: 0x06000C7E RID: 3198 RVA: 0x0002FF69 File Offset: 0x0002E169
		public ObjectEditorProperty(string name, string key, Type type, object defaultValue, string description = null)
		{
			this._name = name;
			this._key = key;
			this._type = type;
			this._defaultValue = defaultValue;
			this._description = description;
		}

		// Token: 0x06000C7F RID: 3199 RVA: 0x00006340 File Offset: 0x00004540
		public virtual bool Validate(ref object value)
		{
			return true;
		}

		// Token: 0x06000C80 RID: 3200 RVA: 0x0002FF96 File Offset: 0x0002E196
		public override string ToString()
		{
			return string.Format("{0} [{1} : {2}]", this._name, this._key, this._type);
		}

		// Token: 0x0400072C RID: 1836
		private readonly string _name;

		// Token: 0x0400072D RID: 1837
		private readonly string _key;

		// Token: 0x0400072E RID: 1838
		private readonly Type _type;

		// Token: 0x0400072F RID: 1839
		private readonly object _defaultValue;

		// Token: 0x04000730 RID: 1840
		private readonly string _description;
	}
}
