using System;
using System.IO;
using csogg;
using csvorbis;

namespace SonicOrca.HelperLibraries.OggVorbis
{
	// Token: 0x020000B4 RID: 180
	public class OggDecodeStream : Stream
	{
		// Token: 0x06000606 RID: 1542 RVA: 0x0001C491 File Offset: 0x0001A691
		public OggDecodeStream(Stream input, bool skipWavHeader)
		{
			if (input == null)
			{
				throw new ArgumentNullException("input");
			}
			this.decodedStream = this.DecodeStream(input, skipWavHeader);
		}

		// Token: 0x06000607 RID: 1543 RVA: 0x0001C4B5 File Offset: 0x0001A6B5
		public OggDecodeStream(Stream input) : this(input, false)
		{
		}

		// Token: 0x06000608 RID: 1544 RVA: 0x0001C4C0 File Offset: 0x0001A6C0
		private Stream DecodeStream(Stream input, bool skipWavHeader)
		{
			int num = 8192;
			byte[] array = new byte[num];
			TextWriter textWriter = new StringWriter();
			Stream stream = new MemoryStream();
			if (!skipWavHeader)
			{
				stream.Seek(36L, SeekOrigin.Begin);
			}
			SyncState syncState = new SyncState();
			StreamState streamState = new StreamState();
			Page page = new Page();
			Packet op = new Packet();
			Info info = new Info();
			Comment comment = new Comment();
			DspState dspState = new DspState();
			Block block = new Block(dspState);
			int num2 = 0;
			syncState.init();
			for (;;)
			{
				int num3 = 0;
				int offset = syncState.buffer(4096);
				byte[] data = syncState.data;
				try
				{
					num2 = input.Read(data, offset, 4096);
				}
				catch (Exception value)
				{
					textWriter.WriteLine(value);
				}
				syncState.wrote(num2);
				if (syncState.pageout(page) != 1)
				{
					if (num2 < 4096)
					{
						break;
					}
					textWriter.WriteLine("Input does not appear to be an Ogg bitstream.");
				}
				streamState.init(page.serialno());
				info.init();
				comment.init();
				if (streamState.pagein(page) < 0)
				{
					textWriter.WriteLine("Error reading first page of Ogg bitstream data.");
				}
				if (streamState.packetout(op) != 1)
				{
					textWriter.WriteLine("Error reading initial header packet.");
				}
				if (info.synthesis_headerin(comment, op) < 0)
				{
					textWriter.WriteLine("This Ogg bitstream does not contain Vorbis audio data.");
				}
				int i = 0;
				while (i < 2)
				{
					while (i < 2)
					{
						int num4 = syncState.pageout(page);
						if (num4 == 0)
						{
							break;
						}
						if (num4 == 1)
						{
							streamState.pagein(page);
							while (i < 2)
							{
								num4 = streamState.packetout(op);
								if (num4 == 0)
								{
									break;
								}
								if (num4 == -1)
								{
									textWriter.WriteLine("Corrupt secondary header.  Exiting.");
								}
								info.synthesis_headerin(comment, op);
								i++;
							}
						}
					}
					offset = syncState.buffer(4096);
					data = syncState.data;
					try
					{
						num2 = input.Read(data, offset, 4096);
					}
					catch (Exception value2)
					{
						textWriter.WriteLine(value2);
					}
					if (num2 == 0 && i < 2)
					{
						textWriter.WriteLine("End of file before finding all Vorbis headers!");
					}
					syncState.wrote(num2);
				}
				byte[][] user_comments = comment.user_comments;
				int num5 = 0;
				while (num5 < comment.user_comments.Length && user_comments[num5] != null)
				{
					textWriter.WriteLine(comment.getComment(num5));
					num5++;
				}
				textWriter.WriteLine(string.Concat(new object[]
				{
					"\nBitstream is ",
					info.channels,
					" channel, ",
					info.rate,
					"Hz"
				}));
				textWriter.WriteLine("Encoded by: " + comment.getVendor() + "\n");
				num = 4096 / info.channels;
				dspState.synthesis_init(info);
				block.init(dspState);
				float[][][] array2 = new float[1][][];
				int[] array3 = new int[info.channels];
				while (num3 == 0)
				{
					while (num3 == 0)
					{
						int num6 = syncState.pageout(page);
						if (num6 == 0)
						{
							break;
						}
						if (num6 == -1)
						{
							textWriter.WriteLine("Corrupt or missing data in bitstream; continuing...");
						}
						else
						{
							streamState.pagein(page);
							for (;;)
							{
								num6 = streamState.packetout(op);
								if (num6 == 0)
								{
									break;
								}
								if (num6 != -1)
								{
									if (block.synthesis(op) == 0)
									{
										dspState.synthesis_blockin(block);
									}
									int num7;
									while ((num7 = dspState.synthesis_pcmout(array2, array3)) > 0)
									{
										float[][] array4 = array2[0];
										int num8 = (num7 < num) ? num7 : num;
										for (i = 0; i < info.channels; i++)
										{
											int num9 = i * 2;
											int num10 = array3[i];
											for (int j = 0; j < num8; j++)
											{
												int num11 = (int)((double)array4[i][num10 + j] * 32767.0);
												if (num11 > 32767)
												{
													num11 = 32767;
												}
												if (num11 < -32768)
												{
													num11 = -32768;
												}
												if (num11 < 0)
												{
													num11 |= 32768;
												}
												array[num9] = (byte)num11;
												array[num9 + 1] = (byte)((uint)num11 >> 8);
												num9 += 2 * info.channels;
											}
										}
										stream.Write(array, 0, 2 * info.channels * num8);
										dspState.synthesis_read(num8);
									}
								}
							}
							if (page.eos() != 0)
							{
								num3 = 1;
							}
						}
					}
					if (num3 == 0)
					{
						offset = syncState.buffer(4096);
						data = syncState.data;
						try
						{
							num2 = input.Read(data, offset, 4096);
						}
						catch (Exception value3)
						{
							textWriter.WriteLine(value3);
						}
						syncState.wrote(num2);
						if (num2 == 0)
						{
							num3 = 1;
						}
					}
				}
				streamState.clear();
				block.clear();
				dspState.clear();
				info.clear();
			}
			syncState.clear();
			textWriter.WriteLine("Done.");
			stream.Seek(0L, SeekOrigin.Begin);
			if (!skipWavHeader)
			{
				this.WriteHeader(stream, (int)(stream.Length - 36L), info.rate, 16, (ushort)info.channels);
				stream.Seek(0L, SeekOrigin.Begin);
			}
			return stream;
		}

		// Token: 0x06000609 RID: 1545 RVA: 0x0001C9EC File Offset: 0x0001ABEC
		private void WriteHeader(Stream stream, int length, int audioSampleRate, ushort audioBitsPerSample, ushort audioChannels)
		{
			BinaryWriter binaryWriter = new BinaryWriter(stream);
			binaryWriter.Write(new char[]
			{
				'R',
				'I',
				'F',
				'F'
			});
			int value = 36 + length;
			binaryWriter.Write(value);
			binaryWriter.Write(new char[]
			{
				'W',
				'A',
				'V',
				'E',
				'f',
				'm',
				't',
				' '
			});
			binaryWriter.Write(16);
			binaryWriter.Write(1);
			binaryWriter.Write((short)audioChannels);
			binaryWriter.Write(audioSampleRate);
			binaryWriter.Write(audioSampleRate * (int)(audioBitsPerSample * audioChannels / 8));
			binaryWriter.Write((short)(audioBitsPerSample * audioChannels / 8));
			binaryWriter.Write((short)audioBitsPerSample);
			binaryWriter.Write(new char[]
			{
				'd',
				'a',
				't',
				'a'
			});
			binaryWriter.Write(length);
		}

		// Token: 0x170000F1 RID: 241
		// (get) Token: 0x0600060A RID: 1546 RVA: 0x00006340 File Offset: 0x00004540
		public override bool CanRead
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170000F2 RID: 242
		// (get) Token: 0x0600060B RID: 1547 RVA: 0x00006340 File Offset: 0x00004540
		public override bool CanSeek
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170000F3 RID: 243
		// (get) Token: 0x0600060C RID: 1548 RVA: 0x0000225B File Offset: 0x0000045B
		public override bool CanWrite
		{
			get
			{
				return false;
			}
		}

		// Token: 0x0600060D RID: 1549 RVA: 0x00008CA1 File Offset: 0x00006EA1
		public override void Flush()
		{
			throw new NotImplementedException();
		}

		// Token: 0x170000F4 RID: 244
		// (get) Token: 0x0600060E RID: 1550 RVA: 0x0001CA9D File Offset: 0x0001AC9D
		public override long Length
		{
			get
			{
				return this.decodedStream.Length;
			}
		}

		// Token: 0x170000F5 RID: 245
		// (get) Token: 0x0600060F RID: 1551 RVA: 0x0001CAAA File Offset: 0x0001ACAA
		// (set) Token: 0x06000610 RID: 1552 RVA: 0x0001CAB7 File Offset: 0x0001ACB7
		public override long Position
		{
			get
			{
				return this.decodedStream.Position;
			}
			set
			{
				this.decodedStream.Position = value;
			}
		}

		// Token: 0x06000611 RID: 1553 RVA: 0x0001CAC5 File Offset: 0x0001ACC5
		public override int Read(byte[] buffer, int offset, int count)
		{
			return this.decodedStream.Read(buffer, offset, count);
		}

		// Token: 0x06000612 RID: 1554 RVA: 0x0001CAD5 File Offset: 0x0001ACD5
		public override long Seek(long offset, SeekOrigin origin)
		{
			return this.Seek(offset, origin);
		}

		// Token: 0x06000613 RID: 1555 RVA: 0x00008CA1 File Offset: 0x00006EA1
		public override void SetLength(long value)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000614 RID: 1556 RVA: 0x00008CA1 File Offset: 0x00006EA1
		public override void Write(byte[] buffer, int offset, int count)
		{
			throw new NotImplementedException();
		}

		// Token: 0x04000471 RID: 1137
		private Stream decodedStream;

		// Token: 0x04000472 RID: 1138
		private const int HEADER_SIZE = 36;
	}
}
