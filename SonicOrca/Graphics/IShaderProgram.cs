using System;
using SonicOrca.Geometry;

namespace SonicOrca.Graphics
{
	// Token: 0x020000C4 RID: 196
	public interface IShaderProgram : IDisposable
	{
		// Token: 0x060006AA RID: 1706
		void Activate();

		// Token: 0x060006AB RID: 1707
		int GetAttributeLocation(string name);

		// Token: 0x060006AC RID: 1708
		void SetUniform(string name, int value);

		// Token: 0x060006AD RID: 1709
		void SetUniform(string name, float value);

		// Token: 0x060006AE RID: 1710
		void SetUniform(string name, double value);

		// Token: 0x060006AF RID: 1711
		void SetUniform(string name, Vector2 value);

		// Token: 0x060006B0 RID: 1712
		void SetUniform(string name, Vector3 value);

		// Token: 0x060006B1 RID: 1713
		void SetUniform(string name, Vector4 value);

		// Token: 0x060006B2 RID: 1714
		void SetUniform(string name, Matrix4 value);

		// Token: 0x060006B3 RID: 1715
		void SetUniform(string name, Colour value);
	}
}
