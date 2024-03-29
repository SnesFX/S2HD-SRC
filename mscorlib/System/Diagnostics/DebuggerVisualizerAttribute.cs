﻿using System;
using System.Runtime.InteropServices;

namespace System.Diagnostics
{
	/// <summary>Specifies that the type has a visualizer. This class cannot be inherited.</summary>
	// Token: 0x020003C3 RID: 963
	[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = true)]
	[ComVisible(true)]
	public sealed class DebuggerVisualizerAttribute : Attribute
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Diagnostics.DebuggerVisualizerAttribute" /> class, specifying the type name of the visualizer.</summary>
		/// <param name="visualizerTypeName">The fully qualified type name of the visualizer.</param>
		// Token: 0x06003202 RID: 12802 RVA: 0x000C02F4 File Offset: 0x000BE4F4
		public DebuggerVisualizerAttribute(string visualizerTypeName)
		{
			this.visualizerName = visualizerTypeName;
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Diagnostics.DebuggerVisualizerAttribute" /> class, specifying the type name of the visualizer and the type name of the visualizer object source.</summary>
		/// <param name="visualizerTypeName">The fully qualified type name of the visualizer.</param>
		/// <param name="visualizerObjectSourceTypeName">The fully qualified type name of the visualizer object source.</param>
		// Token: 0x06003203 RID: 12803 RVA: 0x000C0303 File Offset: 0x000BE503
		public DebuggerVisualizerAttribute(string visualizerTypeName, string visualizerObjectSourceTypeName)
		{
			this.visualizerName = visualizerTypeName;
			this.visualizerObjectSourceName = visualizerObjectSourceTypeName;
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Diagnostics.DebuggerVisualizerAttribute" /> class, specifying the type name of the visualizer and the type of the visualizer object source.</summary>
		/// <param name="visualizerTypeName">The fully qualified type name of the visualizer.</param>
		/// <param name="visualizerObjectSource">The type of the visualizer object source.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="visualizerObjectSource" /> is <see langword="null" />.</exception>
		// Token: 0x06003204 RID: 12804 RVA: 0x000C0319 File Offset: 0x000BE519
		public DebuggerVisualizerAttribute(string visualizerTypeName, Type visualizerObjectSource)
		{
			if (visualizerObjectSource == null)
			{
				throw new ArgumentNullException("visualizerObjectSource");
			}
			this.visualizerName = visualizerTypeName;
			this.visualizerObjectSourceName = visualizerObjectSource.AssemblyQualifiedName;
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Diagnostics.DebuggerVisualizerAttribute" /> class, specifying the type of the visualizer.</summary>
		/// <param name="visualizer">The type of the visualizer.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="visualizer" /> is <see langword="null" />.</exception>
		// Token: 0x06003205 RID: 12805 RVA: 0x000C0348 File Offset: 0x000BE548
		public DebuggerVisualizerAttribute(Type visualizer)
		{
			if (visualizer == null)
			{
				throw new ArgumentNullException("visualizer");
			}
			this.visualizerName = visualizer.AssemblyQualifiedName;
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Diagnostics.DebuggerVisualizerAttribute" /> class, specifying the type of the visualizer and the type of the visualizer object source.</summary>
		/// <param name="visualizer">The type of the visualizer.</param>
		/// <param name="visualizerObjectSource">The type of the visualizer object source.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="visualizerObjectSource" /> is <see langword="null" />.</exception>
		// Token: 0x06003206 RID: 12806 RVA: 0x000C0370 File Offset: 0x000BE570
		public DebuggerVisualizerAttribute(Type visualizer, Type visualizerObjectSource)
		{
			if (visualizer == null)
			{
				throw new ArgumentNullException("visualizer");
			}
			if (visualizerObjectSource == null)
			{
				throw new ArgumentNullException("visualizerObjectSource");
			}
			this.visualizerName = visualizer.AssemblyQualifiedName;
			this.visualizerObjectSourceName = visualizerObjectSource.AssemblyQualifiedName;
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Diagnostics.DebuggerVisualizerAttribute" /> class, specifying the type of the visualizer and the type name of the visualizer object source.</summary>
		/// <param name="visualizer">The type of the visualizer.</param>
		/// <param name="visualizerObjectSourceTypeName">The fully qualified type name of the visualizer object source.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="visualizer" /> is <see langword="null" />.</exception>
		// Token: 0x06003207 RID: 12807 RVA: 0x000C03C3 File Offset: 0x000BE5C3
		public DebuggerVisualizerAttribute(Type visualizer, string visualizerObjectSourceTypeName)
		{
			if (visualizer == null)
			{
				throw new ArgumentNullException("visualizer");
			}
			this.visualizerName = visualizer.AssemblyQualifiedName;
			this.visualizerObjectSourceName = visualizerObjectSourceTypeName;
		}

		/// <summary>Gets the fully qualified type name of the visualizer object source.</summary>
		/// <returns>The fully qualified type name of the visualizer object source.</returns>
		// Token: 0x17000767 RID: 1895
		// (get) Token: 0x06003208 RID: 12808 RVA: 0x000C03F2 File Offset: 0x000BE5F2
		public string VisualizerObjectSourceTypeName
		{
			get
			{
				return this.visualizerObjectSourceName;
			}
		}

		/// <summary>Gets the fully qualified type name of the visualizer.</summary>
		/// <returns>The fully qualified visualizer type name.</returns>
		// Token: 0x17000768 RID: 1896
		// (get) Token: 0x06003209 RID: 12809 RVA: 0x000C03FA File Offset: 0x000BE5FA
		public string VisualizerTypeName
		{
			get
			{
				return this.visualizerName;
			}
		}

		/// <summary>Gets or sets the description of the visualizer.</summary>
		/// <returns>The description of the visualizer.</returns>
		// Token: 0x17000769 RID: 1897
		// (get) Token: 0x0600320A RID: 12810 RVA: 0x000C0402 File Offset: 0x000BE602
		// (set) Token: 0x0600320B RID: 12811 RVA: 0x000C040A File Offset: 0x000BE60A
		public string Description
		{
			get
			{
				return this.description;
			}
			set
			{
				this.description = value;
			}
		}

		/// <summary>Gets or sets the target type when the attribute is applied at the assembly level.</summary>
		/// <returns>The type that is the target of the visualizer.</returns>
		/// <exception cref="T:System.ArgumentNullException">The value cannot be set because it is <see langword="null" />.</exception>
		// Token: 0x1700076A RID: 1898
		// (get) Token: 0x0600320D RID: 12813 RVA: 0x000C043C File Offset: 0x000BE63C
		// (set) Token: 0x0600320C RID: 12812 RVA: 0x000C0413 File Offset: 0x000BE613
		public Type Target
		{
			get
			{
				return this.target;
			}
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				this.targetName = value.AssemblyQualifiedName;
				this.target = value;
			}
		}

		/// <summary>Gets or sets the fully qualified type name when the attribute is applied at the assembly level.</summary>
		/// <returns>The fully qualified type name of the target type.</returns>
		// Token: 0x1700076B RID: 1899
		// (get) Token: 0x0600320F RID: 12815 RVA: 0x000C044D File Offset: 0x000BE64D
		// (set) Token: 0x0600320E RID: 12814 RVA: 0x000C0444 File Offset: 0x000BE644
		public string TargetTypeName
		{
			get
			{
				return this.targetName;
			}
			set
			{
				this.targetName = value;
			}
		}

		// Token: 0x040015F5 RID: 5621
		private string visualizerObjectSourceName;

		// Token: 0x040015F6 RID: 5622
		private string visualizerName;

		// Token: 0x040015F7 RID: 5623
		private string description;

		// Token: 0x040015F8 RID: 5624
		private string targetName;

		// Token: 0x040015F9 RID: 5625
		private Type target;
	}
}
