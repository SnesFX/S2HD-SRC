using System;
using System.Collections.Generic;
using System.IO;

namespace SonicOrca.Original
{
	// Token: 0x020000A1 RID: 161
	public static class Kosinski
	{
		// Token: 0x0600055C RID: 1372 RVA: 0x0001A5C8 File Offset: 0x000187C8
		public static byte[] Decompress(byte[] input)
		{
			byte[] result;
			using (MemoryStream memoryStream = new MemoryStream(input))
			{
				result = Kosinski.Decompress(memoryStream);
			}
			return result;
		}

		// Token: 0x0600055D RID: 1373 RVA: 0x0001A600 File Offset: 0x00018800
		public static byte[] Decompress(Stream input)
		{
			byte[] result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				Kosinski.Decompress(input, memoryStream);
				result = memoryStream.ToArray();
			}
			return result;
		}

		// Token: 0x0600055E RID: 1374 RVA: 0x0001A640 File Offset: 0x00018840
		public static int Decompress(Stream input, Stream output)
		{
			BitReader bitReader = new BitReader(input, 2);
			BinaryReader binaryReader = new BinaryReader(input);
			List<byte> list = new List<byte>();
			for (;;)
			{
				if (bitReader.ReadBit())
				{
					byte b = binaryReader.ReadByte();
					output.WriteByte(b);
					list.Add(b);
				}
				else
				{
					int num3;
					int num4;
					if (bitReader.ReadBit())
					{
						int num = (int)binaryReader.ReadByte();
						int num2 = (int)binaryReader.ReadByte();
						num3 = (num2 & 7);
						if (num3 == 0)
						{
							num3 = (int)binaryReader.ReadByte();
							if (num3 == 0)
							{
								break;
							}
							if (num3 == 1)
							{
								continue;
							}
						}
						else
						{
							num3++;
						}
						num4 = (int)((short)(57344 | (num2 & 248) << 5 | num));
					}
					else
					{
						int num5 = bitReader.ReadBit() ? 1 : 0;
						int num6 = bitReader.ReadBit() ? 1 : 0;
						num3 = (num5 << 1 | num6) + 1;
						num4 = (int)((short)(65280 | (int)binaryReader.ReadByte()));
					}
					num3++;
					int num7 = list.Count + num4;
					for (int i = 0; i < num3; i++)
					{
						output.WriteByte(list[num7]);
						list.Add(list[num7]);
						num7++;
					}
				}
			}
			return list.Count;
		}
	}
}
