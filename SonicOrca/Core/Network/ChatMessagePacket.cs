using System;
using System.IO;

namespace SonicOrca.Core.Network
{
	// Token: 0x0200017D RID: 381
	internal class ChatMessagePacket : Packet
	{
		// Token: 0x17000476 RID: 1142
		// (get) Token: 0x060010E9 RID: 4329 RVA: 0x000433A4 File Offset: 0x000415A4
		public string Sender
		{
			get
			{
				return this._sender;
			}
		}

		// Token: 0x17000477 RID: 1143
		// (get) Token: 0x060010EA RID: 4330 RVA: 0x000433AC File Offset: 0x000415AC
		public string Message
		{
			get
			{
				return this._message;
			}
		}

		// Token: 0x060010EB RID: 4331 RVA: 0x000433B4 File Offset: 0x000415B4
		public ChatMessagePacket(string sender, string message) : base(PacketType.ChatMessage)
		{
			this._sender = sender;
			this._message = message;
		}

		// Token: 0x060010EC RID: 4332 RVA: 0x000433CC File Offset: 0x000415CC
		public ChatMessagePacket(byte[] data) : base(PacketType.ChatMessage)
		{
			using (MemoryStream memoryStream = new MemoryStream(data))
			{
				BinaryReader binaryReader = new BinaryReader(memoryStream);
				this._sender = binaryReader.ReadString();
				this._message = binaryReader.ReadString();
			}
		}

		// Token: 0x060010ED RID: 4333 RVA: 0x00043424 File Offset: 0x00041624
		protected override byte[] SerialiseData()
		{
			byte[] result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
				binaryWriter.Write(this._sender);
				binaryWriter.Write(this._message);
				result = memoryStream.ToArray();
			}
			return result;
		}

		// Token: 0x060010EE RID: 4334 RVA: 0x00043478 File Offset: 0x00041678
		public override string ToString()
		{
			return string.Format("{0}: {1}", this._sender, this._message);
		}

		// Token: 0x04000982 RID: 2434
		private readonly string _sender;

		// Token: 0x04000983 RID: 2435
		private readonly string _message;
	}
}
