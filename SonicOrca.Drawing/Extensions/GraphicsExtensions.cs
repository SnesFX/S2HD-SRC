using System;
using System.Reflection;
using System.Runtime.InteropServices;
using SonicOrca.Geometry;
using SonicOrca.Graphics;

namespace SonicOrca.Extensions
{
	// Token: 0x02000002 RID: 2
	public static class GraphicsExtensions
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		public static Matrix4 CreateOrthographic(this IFramebuffer renderTarget)
		{
			return Matrix4.CreateOrthographicOffCenter(0.0, (double)renderTarget.Width, (double)renderTarget.Height, 0.0, 0.0, 1.0);
		}

		// Token: 0x06000002 RID: 2 RVA: 0x00002089 File Offset: 0x00000289
		public static void SetData<T>(this IBuffer vbo, T[] data)
		{
			vbo.SetData<T>(data, 0, data.Length);
		}

		// Token: 0x06000003 RID: 3 RVA: 0x00002098 File Offset: 0x00000298
		public static void DefineAttributes(this IVertexArray vao, IShaderProgram program, IBuffer vbo, Type vertexType)
		{
			vao.Bind();
			vbo.Bind();
			int stride = Marshal.SizeOf(vertexType);
			foreach (FieldInfo fieldInfo in vertexType.GetFields())
			{
				VertexAttributeAttribute customAttribute = fieldInfo.GetCustomAttribute<VertexAttributeAttribute>();
				if (customAttribute != null)
				{
					Type fieldType = fieldInfo.FieldType;
					VertexAttributeTypeAttribute vertexAttributeTypeAttribute = fieldType.GetCustomAttribute<VertexAttributeTypeAttribute>();
					if (vertexAttributeTypeAttribute == null)
					{
						if (fieldType == typeof(float))
						{
							vertexAttributeTypeAttribute = new VertexAttributeTypeAttribute(VertexAttributePointerType.Float, 1);
						}
						else if (fieldType == typeof(int))
						{
							vertexAttributeTypeAttribute = new VertexAttributeTypeAttribute(VertexAttributePointerType.Int, 1);
						}
					}
					int offset = (int)Marshal.OffsetOf(vertexType, fieldInfo.Name);
					vao.DefineAttribute(program.GetAttributeLocation(customAttribute.Name), vertexAttributeTypeAttribute.Type, vertexAttributeTypeAttribute.Size, stride, offset);
				}
			}
		}

		// Token: 0x06000004 RID: 4 RVA: 0x00002174 File Offset: 0x00000374
		public static void Render<T>(this IVertexArray vao, PrimitiveType type, T[] vertices)
		{
			vao.Render(type, 0, vertices.Length);
		}
	}
}
