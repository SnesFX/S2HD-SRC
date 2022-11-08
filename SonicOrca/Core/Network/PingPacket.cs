using System;
using System.IO;

namespace SonicOrca.Core.Network
{
	// Token: 0x02000180 RID: 384
	internal class PingPacket : Packet
	{
		// Token: 0x17000478 RID: 1144
		// (get) Token: 0x060010F7 RID: 4343 RVA: 0x000435B4 File Offset: 0x000417B4
		public int Id
		{
			get
			{
				return this._id;
			}
		}

		// Token: 0x17000479 RID: 1145
		// (get) Token: 0x060010F8 RID: 4344 RVA: 0x000435BC File Offset: 0x000417BC
		public int RoundTripTime
		{
			get
			{
				return this._roundTripTime;
			}
		}

		// Token: 0x060010F9 RID: 4345 RVA: 0x000435C4 File Offset: 0x000417C4
		public PingPacket(int id, int roundTripTime) : base(PacketType.Ping)
		{
			this._id = id;
			this._roundTripTime = roundTripTime;
		}

		// Token: 0x060010FA RID: 4346 RVA: 0x000435DC File Offset: 0x000417DC
		public PingPacket(byte[] data) : base(PacketType.Ping)
		{
			using (MemoryStream memoryStream = new MemoryStream(data))
			{
				BinaryReader binaryReader = new BinaryReader(memoryStream);
				this._id = binaryReader.ReadInt32();
				this._roundTripTime = binaryReader.ReadInt32();
			}
		}

		// Token: 0x060010FB RID: 4347 RVA: 0x00043634 File Offset: 0x00041834
		protected override byte[] SerialiseData()
		{
			byte[] result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
				binaryWriter.Write(this._id);
				binaryWriter.Write(this._roundTripTime);
				result = memoryStream.ToArray();
			}
			return result;
		}

		// Token: 0x060010FC RID: 4348 RVA: 0x00043688 File Offset: 0x00041888
		public override string ToString()
		{
			return string.Format("Packet = Ping, RTT = {0}", this._roundTripTime);
		}

		// Token: 0x04000986 RID: 2438
		private readonly int _id;

		// Token: 0x04000987 RID: 2439
		private readonly int _roundTripTime;
	}
}
