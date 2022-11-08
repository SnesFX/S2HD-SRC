using System;
using System.Collections.Generic;
using System.IO;
using SonicOrca.Geometry;

namespace SonicOrca.Original
{
	// Token: 0x020000A6 RID: 166
	public static class RingPositions
	{
		// Token: 0x06000572 RID: 1394 RVA: 0x0001B664 File Offset: 0x00019864
		public static IReadOnlyCollection<Vector2i> FromFile(string filename)
		{
			IReadOnlyCollection<Vector2i> result;
			using (FileStream fileStream = new FileStream(filename, FileMode.Open, FileAccess.Read))
			{
				result = RingPositions.FromStream(fileStream);
			}
			return result;
		}

		// Token: 0x06000573 RID: 1395 RVA: 0x0001B6A0 File Offset: 0x000198A0
		public static IReadOnlyCollection<Vector2i> FromStream(Stream stream)
		{
			List<Vector2i> list = new List<Vector2i>();
			byte[] array = new byte[4];
			while (stream.Read(array, 0, 2) == 2 && (array[0] != 255 || array[1] != 255) && stream.Read(array, 2, 2) == 2)
			{
				int num = (int)array[0] << 8 | (int)array[1];
				int num2 = (int)(array[2] & 15) << 8 | (int)array[3];
				int num3 = (array[2] >> 4 & 7) + 1;
				int num4 = array[2] >> 7;
				for (int i = 0; i < num3; i++)
				{
					list.Add(new Vector2i(num, num2));
					if (num4 == 0)
					{
						num += 24;
					}
					else if (num4 == 1)
					{
						num2 += 24;
					}
				}
			}
			return list.ToArray();
		}

		// Token: 0x0400033D RID: 829
		private const int Horizontal = 0;

		// Token: 0x0400033E RID: 830
		private const int Vertical = 1;
	}
}
