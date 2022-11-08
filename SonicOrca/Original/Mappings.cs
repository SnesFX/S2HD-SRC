using System;
using System.IO;
using SonicOrca.Core;

namespace SonicOrca.Original
{
	// Token: 0x020000A2 RID: 162
	public static class Mappings
	{
		// Token: 0x0600055F RID: 1375 RVA: 0x0001A75C File Offset: 0x0001895C
		public static void Export(string tilesFilename, string chunksFilename, string layoutFilename, string outputFilename)
		{
			byte[] array = Kosinski.Decompress(File.ReadAllBytes(chunksFilename));
			int[][,] array2 = new int[256][,];
			for (int i = 0; i < 256; i++)
			{
				array2[i] = Mappings.GetChunk(array, i * 128);
			}
			array = Kosinski.Decompress(File.ReadAllBytes(layoutFilename));
			byte[,] backgroundLayout = Mappings.GetBackgroundLayout(array);
			byte[,] foregroundLayout = Mappings.GetForegroundLayout(array);
			int[,] array3 = new int[1024, 128];
			int[,] array4 = new int[1024, 128];
			for (int j = 0; j < 128; j++)
			{
				for (int k = 0; k < 1024; k++)
				{
					int[,] array5 = array2[(int)backgroundLayout[k / 8, j / 8]];
					array3[k, j] = array5[k % 8, j % 8];
					array5 = array2[(int)foregroundLayout[k / 8, j / 8]];
					array4[k, j] = array5[k % 8, j % 8];
				}
			}
			LevelMap levelMap = new LevelMap();
			levelMap.Layers.Add(new LevelLayer(levelMap));
			levelMap.Layers.Add(new LevelLayer(levelMap));
			levelMap.Layers[0].Resize(1024, 128);
			for (int l = 0; l < levelMap.Layers[0].Rows; l++)
			{
				for (int m = 0; m < levelMap.Layers[0].Columns; m++)
				{
					levelMap.Layers[0].Tiles[m, l] = array3[m, l];
				}
			}
			levelMap.Layers[1].Resize(1024, 128);
			for (int n = 0; n < levelMap.Layers[1].Rows; n++)
			{
				for (int num = 0; num < levelMap.Layers[1].Columns; num++)
				{
					levelMap.Layers[1].Tiles[num, n] = array4[num, n] + 2048;
				}
			}
			new LevelMapWriter(levelMap).Save(outputFilename);
		}

		// Token: 0x06000560 RID: 1376 RVA: 0x0001A9AC File Offset: 0x00018BAC
		private static int[,] GetChunk(byte[] chunks, int index)
		{
			int[,] array = new int[8, 8];
			for (int i = 0; i < 8; i++)
			{
				for (int j = 0; j < 8; j++)
				{
					int num = (int)chunks[index + i * 16 + j * 2];
					byte b = chunks[index + i * 16 + j * 2 + 1];
					int num2 = num << 8 | (int)b;
					array[j, i] = (num2 & 1023);
					if ((num2 & 1024) != 0)
					{
						array[j, i] |= 16384;
					}
					if ((num2 & 2048) != 0)
					{
						array[j, i] |= 32768;
					}
				}
			}
			return array;
		}

		// Token: 0x06000561 RID: 1377 RVA: 0x0001AA44 File Offset: 0x00018C44
		private static byte[,] GetBackgroundLayout(byte[] layout)
		{
			byte[,] array = new byte[128, 16];
			for (int i = 0; i < 16; i++)
			{
				for (int j = 0; j < 128; j++)
				{
					array[j, i] = layout[256 * i + j + 128];
				}
			}
			return array;
		}

		// Token: 0x06000562 RID: 1378 RVA: 0x0001AA98 File Offset: 0x00018C98
		private static byte[,] GetForegroundLayout(byte[] layout)
		{
			byte[,] array = new byte[128, 16];
			for (int i = 0; i < 16; i++)
			{
				for (int j = 0; j < 128; j++)
				{
					array[j, i] = layout[256 * i + j];
				}
			}
			return array;
		}
	}
}
