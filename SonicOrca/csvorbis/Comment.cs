using System;
using System.Text;
using csogg;

namespace csvorbis
{
	// Token: 0x02000065 RID: 101
	public class Comment
	{
		// Token: 0x0600036F RID: 879 RVA: 0x0000D76A File Offset: 0x0000B96A
		public void init()
		{
			this.user_comments = null;
			this.comments = 0;
			this.vendor = null;
		}

		// Token: 0x06000370 RID: 880 RVA: 0x0000D784 File Offset: 0x0000B984
		public void add(string comment)
		{
			byte[] bytes = Encoding.UTF8.GetBytes(comment);
			this.add(bytes);
		}

		// Token: 0x06000371 RID: 881 RVA: 0x0000D7A4 File Offset: 0x0000B9A4
		private void add(byte[] comment)
		{
			byte[][] destinationArray = new byte[this.comments + 2][];
			if (this.user_comments != null)
			{
				Array.Copy(this.user_comments, 0, destinationArray, 0, this.comments);
			}
			this.user_comments = destinationArray;
			int[] destinationArray2 = new int[this.comments + 2];
			if (this.comment_lengths != null)
			{
				Array.Copy(this.comment_lengths, 0, destinationArray2, 0, this.comments);
			}
			this.comment_lengths = destinationArray2;
			byte[] array = new byte[comment.Length + 1];
			Array.Copy(comment, 0, array, 0, comment.Length);
			this.user_comments[this.comments] = array;
			this.comment_lengths[this.comments] = comment.Length;
			this.comments++;
			this.user_comments[this.comments] = null;
		}

		// Token: 0x06000372 RID: 882 RVA: 0x0000D864 File Offset: 0x0000BA64
		public void add_tag(string tag, string contents)
		{
			if (contents == null)
			{
				contents = "";
			}
			this.add(tag + "=" + contents);
		}

		// Token: 0x06000373 RID: 883 RVA: 0x0000D884 File Offset: 0x0000BA84
		private static bool tagcompare(byte[] s1, byte[] s2, int n)
		{
			for (int i = 0; i < n; i++)
			{
				byte b = s1[i];
				byte b2 = s2[i];
				if (b >= 65)
				{
					b = b - 65 + 97;
				}
				if (b2 >= 65)
				{
					b2 = b2 - 65 + 97;
				}
				if (b != b2)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06000374 RID: 884 RVA: 0x0000D8C8 File Offset: 0x0000BAC8
		public string query(string tag)
		{
			return this.query(tag, 0);
		}

		// Token: 0x06000375 RID: 885 RVA: 0x0000D8D4 File Offset: 0x0000BAD4
		public string query(string tag, int count)
		{
			Encoding utf = Encoding.UTF8;
			byte[] bytes = utf.GetBytes(tag);
			int num = this.query(bytes, count);
			if (num == -1)
			{
				return null;
			}
			byte[] array = this.user_comments[num];
			for (int i = 0; i < this.comment_lengths[num]; i++)
			{
				if (array[i] == 61)
				{
					return new string(utf.GetChars(array), i + 1, this.comment_lengths[num] - (i + 1));
				}
			}
			return null;
		}

		// Token: 0x06000376 RID: 886 RVA: 0x0000D948 File Offset: 0x0000BB48
		private int query(byte[] tag, int count)
		{
			int num = 0;
			int num2 = tag.Length;
			byte[] array = new byte[num2 + 2];
			Array.Copy(tag, 0, array, 0, tag.Length);
			array[tag.Length] = 61;
			for (int i = 0; i < this.comments; i++)
			{
				if (Comment.tagcompare(this.user_comments[i], array, num2))
				{
					if (count == num)
					{
						return i;
					}
					num++;
				}
			}
			return -1;
		}

		// Token: 0x06000377 RID: 887 RVA: 0x0000D9A8 File Offset: 0x0000BBA8
		internal int unpack(csBuffer opb)
		{
			int num = opb.read(32);
			if (num < 0)
			{
				this.clear();
				return -1;
			}
			this.vendor = new byte[num + 1];
			opb.read(this.vendor, num);
			this.comments = opb.read(32);
			if (this.comments < 0)
			{
				this.clear();
				return -1;
			}
			this.user_comments = new byte[this.comments + 1][];
			this.comment_lengths = new int[this.comments + 1];
			for (int i = 0; i < this.comments; i++)
			{
				int num2 = opb.read(32);
				if (num2 < 0)
				{
					this.clear();
					return -1;
				}
				this.comment_lengths[i] = num2;
				this.user_comments[i] = new byte[num2 + 1];
				opb.read(this.user_comments[i], num2);
			}
			if (opb.read(1) != 1)
			{
				this.clear();
				return -1;
			}
			return 0;
		}

		// Token: 0x06000378 RID: 888 RVA: 0x0000DA8C File Offset: 0x0000BC8C
		private int pack(csBuffer opb)
		{
			string text = "Xiphophorus libVorbis I 20000508";
			Encoding utf = Encoding.UTF8;
			byte[] bytes = utf.GetBytes(text);
			byte[] bytes2 = utf.GetBytes(Comment._vorbis);
			opb.write(3, 8);
			opb.write(bytes2);
			opb.write(text.Length, 32);
			opb.write(bytes);
			opb.write(this.comments, 32);
			if (this.comments != 0)
			{
				for (int i = 0; i < this.comments; i++)
				{
					if (this.user_comments[i] != null)
					{
						opb.write(this.comment_lengths[i], 32);
						opb.write(this.user_comments[i]);
					}
					else
					{
						opb.write(0, 32);
					}
				}
			}
			opb.write(1, 1);
			return 0;
		}

		// Token: 0x06000379 RID: 889 RVA: 0x0000DB40 File Offset: 0x0000BD40
		public int header_out(Packet op)
		{
			csBuffer csBuffer = new csBuffer();
			csBuffer.writeinit();
			if (this.pack(csBuffer) != 0)
			{
				return Comment.OV_EIMPL;
			}
			op.packet_base = new byte[csBuffer.bytes()];
			op.packet = 0;
			op.bytes = csBuffer.bytes();
			Array.Copy(csBuffer.buf(), 0, op.packet_base, 0, op.bytes);
			op.b_o_s = 0;
			op.e_o_s = 0;
			op.granulepos = 0L;
			return 0;
		}

		// Token: 0x0600037A RID: 890 RVA: 0x0000DBBC File Offset: 0x0000BDBC
		internal void clear()
		{
			for (int i = 0; i < this.comments; i++)
			{
				this.user_comments[i] = null;
			}
			this.user_comments = null;
			this.vendor = null;
		}

		// Token: 0x0600037B RID: 891 RVA: 0x0000DBF1 File Offset: 0x0000BDF1
		public string getVendor()
		{
			return new string(Encoding.UTF8.GetChars(this.vendor));
		}

		// Token: 0x0600037C RID: 892 RVA: 0x0000DC08 File Offset: 0x0000BE08
		public string getComment(int i)
		{
			Encoding utf = Encoding.UTF8;
			if (this.comments <= i)
			{
				return null;
			}
			return new string(utf.GetChars(this.user_comments[i]));
		}

		// Token: 0x0600037D RID: 893 RVA: 0x0000DC3C File Offset: 0x0000BE3C
		public string toString()
		{
			Encoding utf = Encoding.UTF8;
			string str = "Vendor: " + new string(utf.GetChars(this.vendor));
			for (int i = 0; i < this.comments; i++)
			{
				str = str + "\nComment: " + new string(utf.GetChars(this.user_comments[i]));
			}
			return str + "\n";
		}

		// Token: 0x040001A8 RID: 424
		private static string _vorbis = "vorbis";

		// Token: 0x040001A9 RID: 425
		private static int OV_EIMPL = -130;

		// Token: 0x040001AA RID: 426
		public byte[][] user_comments;

		// Token: 0x040001AB RID: 427
		public int[] comment_lengths;

		// Token: 0x040001AC RID: 428
		public int comments;

		// Token: 0x040001AD RID: 429
		public byte[] vendor;
	}
}
