using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SonicOrca.Core.Objects;
using SonicOrca.Core.Objects.Base;
using SonicOrca.Geometry;

namespace SonicOrca.Core.Network
{
	// Token: 0x0200017C RID: 380
	internal class CharacterSynchronisationPacket : Packet
	{
		// Token: 0x17000475 RID: 1141
		// (get) Token: 0x060010E3 RID: 4323 RVA: 0x000430FF File Offset: 0x000412FF
		public IReadOnlyList<CharacterSynchronisationPacket.CharacterStateInfo> CharacterStates
		{
			get
			{
				return this._characterStates;
			}
		}

		// Token: 0x060010E4 RID: 4324 RVA: 0x00043107 File Offset: 0x00041307
		public CharacterSynchronisationPacket(IEnumerable<ICharacter> characters) : base(PacketType.CharacterSynchronisation)
		{
			this._characterStates = (from x in characters
			select new CharacterSynchronisationPacket.CharacterStateInfo(x.StateFlags, x.PositionPrecise, x.Velocity)).ToArray<CharacterSynchronisationPacket.CharacterStateInfo>();
		}

		// Token: 0x060010E5 RID: 4325 RVA: 0x00043140 File Offset: 0x00041340
		public CharacterSynchronisationPacket(byte[] data) : base(PacketType.CharacterSynchronisation)
		{
			using (MemoryStream memoryStream = new MemoryStream(data))
			{
				BinaryReader binaryReader = new BinaryReader(memoryStream);
				int num = (int)binaryReader.ReadByte();
				CharacterSynchronisationPacket.CharacterStateInfo[] array = new CharacterSynchronisationPacket.CharacterStateInfo[num];
				for (int i = 0; i < num; i++)
				{
					array[i] = new CharacterSynchronisationPacket.CharacterStateInfo((CharacterState)binaryReader.ReadInt32(), new Vector2(binaryReader.ReadDouble(), binaryReader.ReadDouble()), new Vector2(binaryReader.ReadDouble(), binaryReader.ReadDouble()));
				}
				this._characterStates = array;
			}
		}

		// Token: 0x060010E6 RID: 4326 RVA: 0x000431D4 File Offset: 0x000413D4
		protected override byte[] SerialiseData()
		{
			byte[] result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
				binaryWriter.Write((byte)this._characterStates.Count);
				foreach (CharacterSynchronisationPacket.CharacterStateInfo characterStateInfo in this._characterStates)
				{
					binaryWriter.Write((int)characterStateInfo.StateFlags);
					binaryWriter.Write(characterStateInfo.PositionPrecise.X);
					binaryWriter.Write(characterStateInfo.PositionPrecise.Y);
					binaryWriter.Write(characterStateInfo.Velocity.X);
					binaryWriter.Write(characterStateInfo.Velocity.Y);
				}
				result = memoryStream.ToArray();
			}
			return result;
		}

		// Token: 0x060010E7 RID: 4327 RVA: 0x000432BC File Offset: 0x000414BC
		public void Apply(IReadOnlyList<ICharacter> characters, int roundTripTime)
		{
			int num = 0;
			foreach (CharacterSynchronisationPacket.CharacterStateInfo characterStateInfo in this._characterStates)
			{
				if (characters.Count > num)
				{
					characters[num].StateFlags = characterStateInfo.StateFlags;
					characters[num].PositionPrecise = characterStateInfo.PositionPrecise;
					characters[num].Velocity = characterStateInfo.Velocity;
					double num2 = (double)roundTripTime / 16.666666666666668;
					characters[num].PositionPrecise += characterStateInfo.Velocity * (num2 / 2.0);
				}
				num++;
			}
		}

		// Token: 0x060010E8 RID: 4328 RVA: 0x00043388 File Offset: 0x00041588
		public override string ToString()
		{
			return string.Format("Packet = CharacterSynchronisation Characters = {0}", this._characterStates.Count);
		}

		// Token: 0x04000981 RID: 2433
		private readonly IReadOnlyList<CharacterSynchronisationPacket.CharacterStateInfo> _characterStates;

		// Token: 0x02000256 RID: 598
		public class CharacterStateInfo
		{
			// Token: 0x17000549 RID: 1353
			// (get) Token: 0x060014B5 RID: 5301 RVA: 0x0004F96A File Offset: 0x0004DB6A
			public CharacterState StateFlags
			{
				get
				{
					return this._state;
				}
			}

			// Token: 0x1700054A RID: 1354
			// (get) Token: 0x060014B6 RID: 5302 RVA: 0x0004F972 File Offset: 0x0004DB72
			public Vector2 PositionPrecise
			{
				get
				{
					return this._position;
				}
			}

			// Token: 0x1700054B RID: 1355
			// (get) Token: 0x060014B7 RID: 5303 RVA: 0x0004F97A File Offset: 0x0004DB7A
			public Vector2 Velocity
			{
				get
				{
					return this._velocity;
				}
			}

			// Token: 0x060014B8 RID: 5304 RVA: 0x0004F982 File Offset: 0x0004DB82
			public CharacterStateInfo(CharacterState stateFlags, Vector2 position, Vector2 velocity)
			{
				this._state = stateFlags;
				this._position = position;
				this._velocity = velocity;
			}

			// Token: 0x04000CC1 RID: 3265
			private readonly CharacterState _state;

			// Token: 0x04000CC2 RID: 3266
			private readonly Vector2 _position;

			// Token: 0x04000CC3 RID: 3267
			private readonly Vector2 _velocity;
		}
	}
}
