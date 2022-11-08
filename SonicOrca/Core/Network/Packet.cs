using System;
using System.IO;
using System.Threading.Tasks;

namespace SonicOrca.Core.Network
{
	// Token: 0x0200017B RID: 379
	internal abstract class Packet
	{
		// Token: 0x17000474 RID: 1140
		// (get) Token: 0x060010DB RID: 4315 RVA: 0x00042F40 File Offset: 0x00041140
		public PacketType Type
		{
			get
			{
				return this._type;
			}
		}

		// Token: 0x060010DC RID: 4316 RVA: 0x00042F48 File Offset: 0x00041148
		protected Packet(PacketType type)
		{
			this._type = type;
		}

		// Token: 0x060010DD RID: 4317
		protected abstract byte[] SerialiseData();

		// Token: 0x060010DE RID: 4318 RVA: 0x00042F58 File Offset: 0x00041158
		public byte[] Serialise()
		{
			byte[] array = this.SerialiseData();
			byte[] result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
				binaryWriter.Write((byte)this._type);
				binaryWriter.Write(array.Length);
				binaryWriter.Write(array);
				result = memoryStream.ToArray();
			}
			return result;
		}

		// Token: 0x060010DF RID: 4319 RVA: 0x00042FB8 File Offset: 0x000411B8
		public static async Task<Packet> FromStreamAsync(Stream stream)
		{
			Packet result;
			try
			{
				byte[] header = new byte[5];
				await stream.ReadAsync(header, 0, header.Length);
				PacketType packetType = (PacketType)header[0];
				int num = BitConverter.ToInt32(header, 1);
				byte[] data = new byte[num];
				if (num > 0)
				{
					await stream.ReadAsync(data, 0, num);
				}
				result = Packet.CreateSpecialisedPacket(packetType, data);
			}
			catch (NetworkException)
			{
				throw;
			}
			catch (Exception inner)
			{
				throw new NetworkException("Error reading packet from network stream.", inner);
			}
			return result;
		}

		// Token: 0x060010E0 RID: 4320 RVA: 0x00043000 File Offset: 0x00041200
		public static Packet FromBuffer(byte[] buffer)
		{
			Packet result;
			try
			{
				byte[] array = new byte[5];
				Array.Copy(buffer, array, array.Length);
				PacketType packetType = (PacketType)array[0];
				int num = BitConverter.ToInt32(array, 1);
				byte[] array2 = new byte[num];
				if (num > 0)
				{
					Array.Copy(buffer, array.Length, array2, 0, num);
				}
				result = Packet.CreateSpecialisedPacket(packetType, array2);
			}
			catch (NetworkException)
			{
				throw;
			}
			catch (Exception inner)
			{
				throw new NetworkException("Error reading packet from buffer.", inner);
			}
			return result;
		}

		// Token: 0x060010E1 RID: 4321 RVA: 0x00043078 File Offset: 0x00041278
		private static Packet CreateSpecialisedPacket(PacketType packetType, byte[] data)
		{
			switch (packetType)
			{
			case PacketType.Ping:
				return new PingPacket(data);
			case PacketType.Pong:
				return new PongPacket(data);
			case PacketType.ChatMessage:
				return new ChatMessagePacket(data);
			case PacketType.PlayInput:
				return new PlayInputPacket(data);
			case PacketType.CharacterSynchronisation:
				return new CharacterSynchronisationPacket(data);
			case PacketType.LevelSynchronisation:
				return new LevelSynchronisationPacket(data);
			}
			return new NotifyPacket(packetType);
		}

		// Token: 0x060010E2 RID: 4322 RVA: 0x000430DB File Offset: 0x000412DB
		public override string ToString()
		{
			return string.Format("Packet = {0} Length = {1}", this.Type, this.Serialise().Length);
		}

		// Token: 0x04000980 RID: 2432
		private readonly PacketType _type;
	}
}
