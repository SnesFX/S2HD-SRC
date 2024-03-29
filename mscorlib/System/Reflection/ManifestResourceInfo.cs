﻿using System;
using System.Runtime.InteropServices;

namespace System.Reflection
{
	/// <summary>Provides access to manifest resources, which are XML files that describe application dependencies.</summary>
	// Token: 0x020005C6 RID: 1478
	[ComVisible(true)]
	[__DynamicallyInvokable]
	public class ManifestResourceInfo
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Reflection.ManifestResourceInfo" /> class for a resource that is contained by the specified assembly and file, and that has the specified location.</summary>
		/// <param name="containingAssembly">The assembly that contains the manifest resource.</param>
		/// <param name="containingFileName">The name of the file that contains the manifest resource, if the file is not the same as the manifest file.</param>
		/// <param name="resourceLocation">A bitwise combination of enumeration values that provides information about the location of the manifest resource.</param>
		// Token: 0x06004555 RID: 17749 RVA: 0x000FDD23 File Offset: 0x000FBF23
		[__DynamicallyInvokable]
		public ManifestResourceInfo(Assembly containingAssembly, string containingFileName, ResourceLocation resourceLocation)
		{
			this._containingAssembly = containingAssembly;
			this._containingFileName = containingFileName;
			this._resourceLocation = resourceLocation;
		}

		/// <summary>Gets the containing assembly for the manifest resource.</summary>
		/// <returns>The manifest resource's containing assembly.</returns>
		// Token: 0x17000A83 RID: 2691
		// (get) Token: 0x06004556 RID: 17750 RVA: 0x000FDD40 File Offset: 0x000FBF40
		[__DynamicallyInvokable]
		public virtual Assembly ReferencedAssembly
		{
			[__DynamicallyInvokable]
			get
			{
				return this._containingAssembly;
			}
		}

		/// <summary>Gets the name of the file that contains the manifest resource, if it is not the same as the manifest file.</summary>
		/// <returns>The manifest resource's file name.</returns>
		// Token: 0x17000A84 RID: 2692
		// (get) Token: 0x06004557 RID: 17751 RVA: 0x000FDD48 File Offset: 0x000FBF48
		[__DynamicallyInvokable]
		public virtual string FileName
		{
			[__DynamicallyInvokable]
			get
			{
				return this._containingFileName;
			}
		}

		/// <summary>Gets the manifest resource's location.</summary>
		/// <returns>A bitwise combination of <see cref="T:System.Reflection.ResourceLocation" /> flags that indicates the location of the manifest resource.</returns>
		// Token: 0x17000A85 RID: 2693
		// (get) Token: 0x06004558 RID: 17752 RVA: 0x000FDD50 File Offset: 0x000FBF50
		[__DynamicallyInvokable]
		public virtual ResourceLocation ResourceLocation
		{
			[__DynamicallyInvokable]
			get
			{
				return this._resourceLocation;
			}
		}

		// Token: 0x04001C1D RID: 7197
		private Assembly _containingAssembly;

		// Token: 0x04001C1E RID: 7198
		private string _containingFileName;

		// Token: 0x04001C1F RID: 7199
		private ResourceLocation _resourceLocation;
	}
}
