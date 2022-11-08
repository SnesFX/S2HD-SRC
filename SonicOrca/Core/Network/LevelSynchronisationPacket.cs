using System;
using System.IO;

namespace SonicOrca.Core.Network
{
	// Token: 0x0200017E RID: 382
	internal class LevelSynchronisationPacket : Packet
	{
		// Token: 0x060010EF RID: 4335 RVA: 0x00043490 File Offset: 0x00041690
		public LevelSynchronisationPacket(Level level) : base(PacketType.LevelSynchronisation)
		{
			this._ticks = level.Ticks;
			this._time = level.Time;
		}

		// Token: 0x060010F0 RID: 4336 RVA: 0x000434B4 File Offset: 0x000416B4
		public LevelSynchronisationPacket(byte[] data) : base(PacketType.LevelSynchronisation)
		{
			using (MemoryStream memoryStream = new MemoryStream(data))
			{
				BinaryReader binaryReader = new BinaryReader(memoryStream);
				this._ticks = binaryReader.ReadInt32();
				this._time = binaryReader.ReadInt32();
			}
		}

		// Token: 0x060010F1 RID: 4337 RVA: 0x0004350C File Offset: 0x0004170C
		protected override byte[] SerialiseData()
		{
			byte[] result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
				binaryWriter.Write(this._ticks);
				binaryWriter.Write(this._time);
				result = memoryStream.ToArray();
			}
			return result;
		}

		// Token: 0x060010F2 RID: 4338 RVA: 0x00043560 File Offset: 0x00041760
		public void Apply(Level level)
		{
			level.Ticks = this._ticks;
			level.Time = this._time;
		}

		// Token: 0x060010F3 RID: 4339 RVA: 0x0004357A File Offset: 0x0004177A
		public override string ToString()
		{
			return string.Format("Packet = LevelSynchronisationPacket", new object[0]);
		}

		// Token: 0x04000984 RID: 2436
		private int _ticks;

		// Token: 0x04000985 RID: 2437
		private int _time;
	}
}
