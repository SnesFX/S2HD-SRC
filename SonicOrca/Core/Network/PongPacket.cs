using System;
using System.IO;

namespace SonicOrca.Core.Network
{
	// Token: 0x02000182 RID: 386
	internal class PongPacket : Packet
	{
		// Token: 0x1700047D RID: 1149
		// (get) Token: 0x06001104 RID: 4356 RVA: 0x000437F1 File Offset: 0x000419F1
		public int Id
		{
			get
			{
				return this._id;
			}
		}

		// Token: 0x06001105 RID: 4357 RVA: 0x000437F9 File Offset: 0x000419F9
		public PongPacket(int id) : base(PacketType.Pong)
		{
			this._id = id;
		}

		// Token: 0x06001106 RID: 4358 RVA: 0x0004380C File Offset: 0x00041A0C
		public PongPacket(byte[] data) : base(PacketType.Pong)
		{
			using (MemoryStream memoryStream = new MemoryStream(data))
			{
				BinaryReader binaryReader = new BinaryReader(memoryStream);
				this._id = binaryReader.ReadInt32();
			}
		}

		// Token: 0x06001107 RID: 4359 RVA: 0x00043858 File Offset: 0x00041A58
		protected override byte[] SerialiseData()
		{
			byte[] result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				new BinaryWriter(memoryStream).Write(this._id);
				result = memoryStream.ToArray();
			}
			return result;
		}

		// Token: 0x06001108 RID: 4360 RVA: 0x000438A0 File Offset: 0x00041AA0
		public override string ToString()
		{
			return string.Format("Packet = Pong", new object[0]);
		}

		// Token: 0x0400098B RID: 2443
		private readonly int _id;
	}
}
