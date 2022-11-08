using System;
using System.Collections.Generic;
using System.Linq;
using SonicOrca.Geometry;

namespace SonicOrca.Graphics
{
	// Token: 0x020000D2 RID: 210
	public abstract class VertexBuffer : IDisposable
	{
		// Token: 0x17000144 RID: 324
		// (get) Token: 0x060006F1 RID: 1777
		public abstract IReadOnlyList<int> VectorCounts { get; }

		// Token: 0x060006F2 RID: 1778 RVA: 0x0001D690 File Offset: 0x0001B890
		protected IEnumerable<int> SetAttributeLocations(IShaderProgram shaderProgram, IEnumerable<string> names, IEnumerable<int> vectorCounts)
		{
			string[] array = names.ToArray<string>();
			int[] array2 = vectorCounts.ToArray<int>();
			foreach (string text in array)
			{
				this._attributeLocations[text] = shaderProgram.GetAttributeLocation(text);
			}
			int[] array4 = new int[array2.Length];
			for (int j = 0; j < array4.Length; j++)
			{
				array4[this._attributeLocations[array[j]]] = array2[j];
			}
			return array4;
		}

		// Token: 0x060006F3 RID: 1779
		public abstract void Dispose();

		// Token: 0x060006F4 RID: 1780
		public abstract void SetBufferData(int index, IEnumerable<double> data);

		// Token: 0x060006F5 RID: 1781
		public abstract void Begin();

		// Token: 0x060006F6 RID: 1782
		public abstract void End();

		// Token: 0x060006F7 RID: 1783
		public abstract void Render(PrimitiveType type);

		// Token: 0x060006F8 RID: 1784
		public abstract void Render(PrimitiveType type, int index, int count);

		// Token: 0x060006F9 RID: 1785
		public abstract void AddValue(int index, double value);

		// Token: 0x060006FA RID: 1786 RVA: 0x0001D70B File Offset: 0x0001B90B
		public void AddValue(string name, double value)
		{
			this.AddValue(this._attributeLocations[name], value);
		}

		// Token: 0x060006FB RID: 1787 RVA: 0x0001D720 File Offset: 0x0001B920
		public void AddValue(string name, Vector2 value)
		{
			this.AddValue(this._attributeLocations[name], value);
		}

		// Token: 0x060006FC RID: 1788 RVA: 0x0001D735 File Offset: 0x0001B935
		public void AddValue(string name, Vector3 value)
		{
			this.AddValue(this._attributeLocations[name], value);
		}

		// Token: 0x060006FD RID: 1789 RVA: 0x0001D74A File Offset: 0x0001B94A
		public void AddValue(string name, Vector4 value)
		{
			this.AddValue(this._attributeLocations[name], value);
		}

		// Token: 0x060006FE RID: 1790 RVA: 0x0001D75F File Offset: 0x0001B95F
		public void AddValue(string name, Colour value)
		{
			this.AddValue(this._attributeLocations[name], value);
		}

		// Token: 0x060006FF RID: 1791 RVA: 0x0001D774 File Offset: 0x0001B974
		public void AddValue(int index, Vector2 value)
		{
			this.AddValue(index, value.X);
			this.AddValue(index, value.Y);
		}

		// Token: 0x06000700 RID: 1792 RVA: 0x0001D792 File Offset: 0x0001B992
		public void AddValue(int index, Vector3 value)
		{
			this.AddValue(index, value.X);
			this.AddValue(index, value.Y);
			this.AddValue(index, value.Z);
		}

		// Token: 0x06000701 RID: 1793 RVA: 0x0001D7BE File Offset: 0x0001B9BE
		public void AddValue(int index, Vector4 value)
		{
			this.AddValue(index, value.X);
			this.AddValue(index, value.Y);
			this.AddValue(index, value.Z);
			this.AddValue(index, value.W);
		}

		// Token: 0x06000702 RID: 1794 RVA: 0x0001D7F8 File Offset: 0x0001B9F8
		public void AddValue(int index, Colour value)
		{
			this.AddValue(index, (double)value.Red / 255.0);
			this.AddValue(index, (double)value.Green / 255.0);
			this.AddValue(index, (double)value.Blue / 255.0);
			this.AddValue(index, (double)value.Alpha / 255.0);
		}

		// Token: 0x06000703 RID: 1795 RVA: 0x0001D86C File Offset: 0x0001BA6C
		public void AddValues(params object[] values)
		{
			for (int i = 0; i < values.Length; i++)
			{
				if (values[i] is float || values[i] is double)
				{
					this.AddValue(i, (double)values[i]);
				}
				else if (values[i] is Vector2)
				{
					this.AddValue(i, (Vector2)values[i]);
				}
				else if (values[i] is Vector3)
				{
					this.AddValue(i, (Vector3)values[i]);
				}
				else if (values[i] is Vector4)
				{
					this.AddValue(i, (Vector4)values[i]);
				}
				else if (values[i] is Colour)
				{
					this.AddValue(i, (Colour)values[i]);
				}
				else
				{
					this.AddValue(i, (double)((float)((int)values[i])));
				}
			}
		}

		// Token: 0x040004AF RID: 1199
		private readonly Dictionary<string, int> _attributeLocations = new Dictionary<string, int>();
	}
}
