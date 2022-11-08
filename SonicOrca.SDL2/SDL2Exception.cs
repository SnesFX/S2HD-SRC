using System;
using System.Runtime.Serialization;
using SDL2;

namespace SonicOrca.SDL2
{
	// Token: 0x02000009 RID: 9
	[Serializable]
	public class SDL2Exception : Exception
	{
		// Token: 0x06000050 RID: 80 RVA: 0x00002E0C File Offset: 0x0000100C
		public SDL2Exception()
		{
		}

		// Token: 0x06000051 RID: 81 RVA: 0x00002E14 File Offset: 0x00001014
		public SDL2Exception(string message) : base(message)
		{
		}

		// Token: 0x06000052 RID: 82 RVA: 0x00002E1D File Offset: 0x0000101D
		public SDL2Exception(string message, Exception inner) : base(message, inner)
		{
		}

		// Token: 0x06000053 RID: 83 RVA: 0x00002E27 File Offset: 0x00001027
		protected SDL2Exception(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}

		// Token: 0x06000054 RID: 84 RVA: 0x00002E31 File Offset: 0x00001031
		public static SDL2Exception FromError()
		{
			return new SDL2Exception(SDL.SDL_GetError());
		}

		// Token: 0x06000055 RID: 85 RVA: 0x00002E3D File Offset: 0x0000103D
		public static SDL2Exception FromError(string basicMessage)
		{
			return new SDL2Exception(basicMessage + Environment.NewLine + SDL.SDL_GetError());
		}
	}
}
