using System;
using System.IO;
using SonicOrca.Geometry;

namespace SonicOrca.Core.Network
{
	// Token: 0x02000181 RID: 385
	internal class PlayInputPacket : Packet
	{
		// Token: 0x1700047A RID: 1146
		// (get) Token: 0x060010FD RID: 4349 RVA: 0x0004369F File Offset: 0x0004189F
		public int CharacterId
		{
			get
			{
				return this._characterId;
			}
		}

		// Token: 0x1700047B RID: 1147
		// (get) Token: 0x060010FE RID: 4350 RVA: 0x000436A7 File Offset: 0x000418A7
		public Vector2 Direction
		{
			get
			{
				return this._direction;
			}
		}

		// Token: 0x1700047C RID: 1148
		// (get) Token: 0x060010FF RID: 4351 RVA: 0x000436AF File Offset: 0x000418AF
		public bool Action
		{
			get
			{
				return this._action;
			}
		}

		// Token: 0x06001100 RID: 4352 RVA: 0x000436B7 File Offset: 0x000418B7
		public PlayInputPacket(int characterId, Vector2 direction, bool action) : base(PacketType.PlayInput)
		{
			this._characterId = characterId;
			this._direction = direction;
			this._action = action;
		}

		// Token: 0x06001101 RID: 4353 RVA: 0x000436D8 File Offset: 0x000418D8
		public PlayInputPacket(byte[] data) : base(PacketType.PlayInput)
		{
			using (MemoryStream memoryStream = new MemoryStream(data))
			{
				BinaryReader binaryReader = new BinaryReader(memoryStream);
				this._characterId = binaryReader.ReadInt32();
				this._direction = new Vector2(binaryReader.ReadDouble(), binaryReader.ReadDouble());
				this._action = binaryReader.ReadBoolean();
			}
		}

		// Token: 0x06001102 RID: 4354 RVA: 0x00043748 File Offset: 0x00041948
		protected override byte[] SerialiseData()
		{
			byte[] result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
				binaryWriter.Write(this._characterId);
				binaryWriter.Write(this._direction.X);
				binaryWriter.Write(this._direction.Y);
				binaryWriter.Write(this._action);
				result = memoryStream.ToArray();
			}
			return result;
		}

		// Token: 0x06001103 RID: 4355 RVA: 0x000437C4 File Offset: 0x000419C4
		public override string ToString()
		{
			return string.Format("Packet = PlayInput CharacterId = {0} Direction = {1} Action = {2}", this._characterId, this._direction, this._action);
		}

		// Token: 0x04000988 RID: 2440
		private readonly int _characterId;

		// Token: 0x04000989 RID: 2441
		private readonly Vector2 _direction;

		// Token: 0x0400098A RID: 2442
		private readonly bool _action;
	}
}
