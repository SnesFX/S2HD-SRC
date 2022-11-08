using System;
using System.IO;

namespace SonicOrca.Original
{
	// Token: 0x020000A4 RID: 164
	public static class Nemesis
	{
		// Token: 0x06000567 RID: 1383 RVA: 0x0001AAF0 File Offset: 0x00018CF0
		public static byte[] Decompress(byte[] input)
		{
			byte[] result;
			using (MemoryStream memoryStream = new MemoryStream(input))
			{
				result = Nemesis.Decompress(memoryStream);
			}
			return result;
		}

		// Token: 0x06000568 RID: 1384 RVA: 0x0001AB28 File Offset: 0x00018D28
		public static byte[] Decompress(Stream input)
		{
			byte[] result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				Nemesis.Decompress(input, memoryStream);
				result = memoryStream.ToArray();
			}
			return result;
		}

		// Token: 0x06000569 RID: 1385 RVA: 0x0001AB68 File Offset: 0x00018D68
		public static int Decompress(Stream input, Stream output)
		{
			byte[] array = new byte[4];
			MemoryStream memoryStream = new MemoryStream();
			Nemesis.CodeTreeNode codeTree = new Nemesis.CodeTreeNode();
			int num = (int)((byte)input.ReadByte()) << 8;
			num |= (int)((byte)input.ReadByte());
			int num2 = ((num & 32768) == 0) ? 0 : 1;
			num &= -32769;
			Nemesis.ReadHeader(input, memoryStream, codeTree);
			Nemesis.ReadInternal(input, memoryStream, codeTree, (ushort)num, num2);
			int num3 = (int)memoryStream.Length;
			memoryStream.Position = 0L;
			if (num2 != 0)
			{
				Array.Clear(array, 0, array.Length);
				for (int i = 0; i < num3; i++)
				{
					byte[] array2 = array;
					int num4 = i % 4;
					array2[num4] ^= (byte)memoryStream.ReadByte();
					output.WriteByte(array[i % 4]);
				}
			}
			else
			{
				memoryStream.CopyTo(output);
			}
			return num3;
		}

		// Token: 0x0600056A RID: 1386 RVA: 0x0001AC28 File Offset: 0x00018E28
		private static void ReadHeader(Stream input, Stream output, Nemesis.CodeTreeNode codeTree)
		{
			byte nibble = 0;
			byte b;
			while ((b = (byte)input.ReadByte()) != 255)
			{
				if ((b & 128) != 0)
				{
					nibble = (b & 15);
					b = (byte)input.ReadByte();
				}
				Nemesis.SetCode(codeTree, (byte)input.ReadByte(), (int)(b & 15), new Nemesis.NibbleRun(nibble, (byte)(((b & 112) >> 4) + 1)));
			}
			Nemesis.SetCode(codeTree, 63, 6, new Nemesis.NibbleRun(0, byte.MaxValue));
		}

		// Token: 0x0600056B RID: 1387 RVA: 0x0001AC94 File Offset: 0x00018E94
		private static void ReadInternal(Stream input, Stream output, Nemesis.CodeTreeNode codeTree, ushort numTiles, int xorOutput)
		{
			BitReader bitReader = new BitReader(input, 1);
			BitWriter output2 = new BitWriter(output, 1);
			int num = (int)numTiles << 8;
			int i = 0;
			Nemesis.CodeTreeNode codeTreeNode = codeTree;
			while (i < num)
			{
				Nemesis.NibbleRun nibbleRun = codeTreeNode.NibbleRun;
				if (nibbleRun.Count == 255)
				{
					byte count = (byte)(bitReader.ReadBits(3) + 1);
					byte nibble = (byte)bitReader.ReadBits(4);
					Nemesis.WriteNibbleRun(output2, count, nibble, ref i);
					codeTreeNode = codeTree;
				}
				else if (nibbleRun.Count != 0)
				{
					Nemesis.WriteNibbleRun(output2, nibbleRun.Count, nibbleRun.Nibble, ref i);
					codeTreeNode = codeTree;
				}
				else
				{
					if (bitReader.ReadBit())
					{
						codeTreeNode = codeTreeNode.Set;
					}
					else
					{
						codeTreeNode = codeTreeNode.Clear;
					}
					if (codeTreeNode == null)
					{
						throw new NemesisException("Invalid code.");
					}
				}
			}
		}

		// Token: 0x0600056C RID: 1388 RVA: 0x0001AD53 File Offset: 0x00018F53
		private static void WriteNibbleRun(BitWriter output, byte count, byte nibble, ref int bitsWritten)
		{
			bitsWritten += (int)(count * 4);
			if ((count & 1) != 0)
			{
				output.WriteBits((int)nibble, 4);
			}
			count = (byte)(count >> 1);
			nibble |= (byte)(nibble << 4);
			for (;;)
			{
				byte b = count;
				count = b - 1;
				if (b == 0)
				{
					break;
				}
				output.WriteBits((int)nibble, 8);
			}
		}

		// Token: 0x0600056D RID: 1389 RVA: 0x0001AD8C File Offset: 0x00018F8C
		private static void SetCode(Nemesis.CodeTreeNode codeTree, byte code, int length, Nemesis.NibbleRun nibbleRun)
		{
			if (length == 0)
			{
				if (codeTree.Clear != null || codeTree.Set != null)
				{
					throw new NemesisException("Code already used as prefix.");
				}
				codeTree.NibbleRun = nibbleRun;
				return;
			}
			else
			{
				if (codeTree.NibbleRun.Count != 0)
				{
					throw new NemesisException("Prefix already used as code.");
				}
				length--;
				if (((int)code & 1 << length) == 0)
				{
					if (codeTree.Clear == null)
					{
						codeTree.Clear = new Nemesis.CodeTreeNode();
					}
					Nemesis.SetCode(codeTree.Clear, code, length, nibbleRun);
					return;
				}
				if (codeTree.Set == null)
				{
					codeTree.Set = new Nemesis.CodeTreeNode();
				}
				Nemesis.SetCode(codeTree.Set, (byte)((int)code & (1 << length) - 1), length, nibbleRun);
				return;
			}
		}

		// Token: 0x020001B9 RID: 441
		private struct NibbleRun
		{
			// Token: 0x170004F9 RID: 1273
			// (get) Token: 0x06001283 RID: 4739 RVA: 0x0004820E File Offset: 0x0004640E
			// (set) Token: 0x06001284 RID: 4740 RVA: 0x00048216 File Offset: 0x00046416
			public byte Nibble { get; set; }

			// Token: 0x170004FA RID: 1274
			// (get) Token: 0x06001285 RID: 4741 RVA: 0x0004821F File Offset: 0x0004641F
			// (set) Token: 0x06001286 RID: 4742 RVA: 0x00048227 File Offset: 0x00046427
			public byte Count { get; set; }

			// Token: 0x06001287 RID: 4743 RVA: 0x00048230 File Offset: 0x00046430
			public NibbleRun(byte nibble, byte count)
			{
				this = default(Nemesis.NibbleRun);
				this.Nibble = nibble;
				this.Count = count;
			}

			// Token: 0x06001288 RID: 4744 RVA: 0x00048247 File Offset: 0x00046447
			public override string ToString()
			{
				return string.Format("{0} x{1}", this.Nibble, this.Count);
			}
		}

		// Token: 0x020001BA RID: 442
		private class CodeTreeNode
		{
			// Token: 0x170004FB RID: 1275
			// (get) Token: 0x06001289 RID: 4745 RVA: 0x00048269 File Offset: 0x00046469
			// (set) Token: 0x0600128A RID: 4746 RVA: 0x00048271 File Offset: 0x00046471
			public Nemesis.CodeTreeNode Clear { get; set; }

			// Token: 0x170004FC RID: 1276
			// (get) Token: 0x0600128B RID: 4747 RVA: 0x0004827A File Offset: 0x0004647A
			// (set) Token: 0x0600128C RID: 4748 RVA: 0x00048282 File Offset: 0x00046482
			public Nemesis.CodeTreeNode Set { get; set; }

			// Token: 0x170004FD RID: 1277
			// (get) Token: 0x0600128D RID: 4749 RVA: 0x0004828B File Offset: 0x0004648B
			// (set) Token: 0x0600128E RID: 4750 RVA: 0x00048293 File Offset: 0x00046493
			public Nemesis.NibbleRun NibbleRun { get; set; }

			// Token: 0x0600128F RID: 4751 RVA: 0x0004829C File Offset: 0x0004649C
			public override string ToString()
			{
				if (this.Clear == null && this.Set == null)
				{
					return "Leaf";
				}
				return "Node";
			}
		}
	}
}
