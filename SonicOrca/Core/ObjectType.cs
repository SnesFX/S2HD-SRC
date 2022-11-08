using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Microsoft.CSharp.RuntimeBinder;
using SonicOrca.Core.Objects.Metadata;
using SonicOrca.Geometry;
using SonicOrca.Resources;

namespace SonicOrca.Core
{
	// Token: 0x0200013F RID: 319
	public abstract class ObjectType : ILoadedResource, IDisposable
	{
		// Token: 0x1700033A RID: 826
		// (get) Token: 0x06000CF6 RID: 3318 RVA: 0x00031DA8 File Offset: 0x0002FFA8
		// (set) Token: 0x06000CF7 RID: 3319 RVA: 0x00031DB0 File Offset: 0x0002FFB0
		public Resource Resource { get; set; }

		// Token: 0x1700033B RID: 827
		// (get) Token: 0x06000CF8 RID: 3320 RVA: 0x00031DBC File Offset: 0x0002FFBC
		public static IReadOnlyList<ObjectType> LoadedTypes
		{
			get
			{
				object sync = ObjectType.LoadedTypeList.Sync;
				IReadOnlyList<ObjectType> result;
				lock (sync)
				{
					result = ObjectType.LoadedTypeList.Instance.ToArray();
				}
				return result;
			}
		}

		// Token: 0x06000CF9 RID: 3321 RVA: 0x00031E0C File Offset: 0x0003000C
		public static void ClearLoadedTypes()
		{
			object sync = ObjectType.LoadedTypeList.Sync;
			lock (sync)
			{
				ObjectType.LoadedTypeList.Instance.Clear();
			}
		}

		// Token: 0x1700033C RID: 828
		// (get) Token: 0x06000CFA RID: 3322 RVA: 0x00031E5C File Offset: 0x0003005C
		// (set) Token: 0x06000CFB RID: 3323 RVA: 0x00031E64 File Offset: 0x00030064
		public Level Level { get; private set; }

		// Token: 0x1700033D RID: 829
		// (get) Token: 0x06000CFC RID: 3324 RVA: 0x00031E6D File Offset: 0x0003006D
		public string ResourceKey
		{
			get
			{
				return this.Resource.FullKeyPath;
			}
		}

		// Token: 0x1700033E RID: 830
		// (get) Token: 0x06000CFD RID: 3325 RVA: 0x00031E7A File Offset: 0x0003007A
		public string Name
		{
			get
			{
				return this._name;
			}
		}

		// Token: 0x1700033F RID: 831
		// (get) Token: 0x06000CFE RID: 3326 RVA: 0x00031E82 File Offset: 0x00030082
		public ObjectClassification Classification
		{
			get
			{
				return this._classification;
			}
		}

		// Token: 0x17000340 RID: 832
		// (get) Token: 0x06000CFF RID: 3327 RVA: 0x00031E8A File Offset: 0x0003008A
		public IReadOnlyCollection<string> Dependencies
		{
			get
			{
				return this._dependencies;
			}
		}

		// Token: 0x17000341 RID: 833
		// (get) Token: 0x06000D00 RID: 3328 RVA: 0x00031E92 File Offset: 0x00030092
		public IReadOnlyCollection<ObjectEditorProperty> EditorProperties
		{
			get
			{
				return this._editorProperties;
			}
		}

		// Token: 0x06000D01 RID: 3329 RVA: 0x00031E9C File Offset: 0x0003009C
		public ObjectType()
		{
			this._editorProperties = StateVariableAttribute.GetEditorProperties(this);
			NameAttribute nameAttribute = NameAttribute.FromObject(this);
			if (nameAttribute != null)
			{
				this._name = nameAttribute.Name;
			}
			DescriptionAttribute descriptionAttribute = DescriptionAttribute.FromObject(this);
			if (descriptionAttribute != null)
			{
				this._description = descriptionAttribute.Description;
			}
			ClassificationAttribute classificationAttribute = ClassificationAttribute.FromObject(this);
			if (classificationAttribute != null)
			{
				this._classification = classificationAttribute.Classification;
			}
			this._dependencies = SonicOrca.Core.Objects.Metadata.DependencyAttribute.GetDependencies(this).ToArray<string>();
		}

		// Token: 0x06000D02 RID: 3330 RVA: 0x00031F10 File Offset: 0x00030110
		public void OnLoaded()
		{
			object sync = ObjectType.LoadedTypeList.Sync;
			lock (sync)
			{
				if (!ObjectType.LoadedTypeList.Instance.Exists((ObjectType ot) => ot.GetType() == base.GetType()))
				{
					ObjectType.LoadedTypeList.Instance.Add(this);
				}
			}
		}

		// Token: 0x06000D03 RID: 3331 RVA: 0x00031F7C File Offset: 0x0003017C
		public void Dispose()
		{
			object sync = ObjectType.LoadedTypeList.Sync;
			lock (sync)
			{
				if (ObjectType.LoadedTypeList.Instance.Exists((ObjectType ot) => ot.GetType() == base.GetType()))
				{
					ObjectType.LoadedTypeList.Instance.Remove(this);
				}
			}
		}

		// Token: 0x06000D04 RID: 3332 RVA: 0x00031FE8 File Offset: 0x000301E8
		public void Register(Level level)
		{
			this.Level = level;
		}

		// Token: 0x06000D05 RID: 3333 RVA: 0x00031FF1 File Offset: 0x000301F1
		public void Unregister()
		{
			this.Level = null;
		}

		// Token: 0x06000D06 RID: 3334 RVA: 0x00031FFA File Offset: 0x000301FA
		public void Start()
		{
			this.OnStart();
		}

		// Token: 0x06000D07 RID: 3335 RVA: 0x00032002 File Offset: 0x00030202
		public void Update()
		{
			this.OnUpdate();
		}

		// Token: 0x06000D08 RID: 3336 RVA: 0x0003200A File Offset: 0x0003020A
		public void Animate()
		{
			this.OnAnimate();
		}

		// Token: 0x06000D09 RID: 3337 RVA: 0x00032012 File Offset: 0x00030212
		public void Stop()
		{
			this.OnStop();
		}

		// Token: 0x06000D0A RID: 3338 RVA: 0x0003201A File Offset: 0x0003021A
		public virtual ActiveObject CreateInstance()
		{
			ObjectInstanceAttribute objectInstanceAttribute = ObjectInstanceAttribute.FromObject(this);
			if (objectInstanceAttribute == null)
			{
				throw new Exception();
			}
			return (ActiveObject)Activator.CreateInstance(objectInstanceAttribute.ObjectInstanceType);
		}

		// Token: 0x06000D0B RID: 3339 RVA: 0x0003203C File Offset: 0x0003023C
		public Vector2 GetLifeRadius(IActiveObject state)
		{
			if (state.GetType() == typeof(IActiveObject))
			{
				throw new InvalidOperationException();
			}
			if (ObjectType.<>o__41.<>p__1 == null)
			{
				ObjectType.<>o__41.<>p__1 = CallSite<Func<CallSite, object, Vector2>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(Vector2), typeof(ObjectType)));
			}
			Func<CallSite, object, Vector2> target = ObjectType.<>o__41.<>p__1.Target;
			CallSite <>p__ = ObjectType.<>o__41.<>p__1;
			if (ObjectType.<>o__41.<>p__0 == null)
			{
				ObjectType.<>o__41.<>p__0 = CallSite<Func<CallSite, object, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "GetLifeRadius", null, typeof(ObjectType), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
				}));
			}
			return target(<>p__, ObjectType.<>o__41.<>p__0.Target(ObjectType.<>o__41.<>p__0, this, state));
		}

		// Token: 0x06000D0C RID: 3340 RVA: 0x000320FF File Offset: 0x000302FF
		public Vector2 GetLifeRadius(ActiveObject state)
		{
			return new Vector2(0.0, 0.0);
		}

		// Token: 0x06000D0D RID: 3341 RVA: 0x00006325 File Offset: 0x00004525
		protected virtual void OnStart()
		{
		}

		// Token: 0x06000D0E RID: 3342 RVA: 0x00006325 File Offset: 0x00004525
		protected virtual void OnUpdate()
		{
		}

		// Token: 0x06000D0F RID: 3343 RVA: 0x00006325 File Offset: 0x00004525
		protected virtual void OnAnimate()
		{
		}

		// Token: 0x06000D10 RID: 3344 RVA: 0x00006325 File Offset: 0x00004525
		protected virtual void OnStop()
		{
		}

		// Token: 0x04000755 RID: 1877
		public const string AnimalClass = "animal";

		// Token: 0x04000756 RID: 1878
		public const string CharacterClass = "character";

		// Token: 0x04000757 RID: 1879
		public const string ParticleClass = "particle";

		// Token: 0x04000758 RID: 1880
		public const string RingClass = "ring";

		// Token: 0x04000759 RID: 1881
		private static readonly Lockable<List<ObjectType>> LoadedTypeList = new Lockable<List<ObjectType>>(new List<ObjectType>());

		// Token: 0x0400075B RID: 1883
		private readonly string _name;

		// Token: 0x0400075C RID: 1884
		private readonly string _description;

		// Token: 0x0400075D RID: 1885
		private readonly ObjectClassification _classification;

		// Token: 0x0400075E RID: 1886
		private readonly string[] _dependencies;

		// Token: 0x0400075F RID: 1887
		private readonly IReadOnlyCollection<ObjectEditorProperty> _editorProperties;
	}
}
