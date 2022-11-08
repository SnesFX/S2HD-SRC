using System;

namespace SonicOrca.Core.Network
{
	// Token: 0x02000184 RID: 388
	internal enum PacketType
	{
		// Token: 0x0400098F RID: 2447
		Undefined,
		// Token: 0x04000990 RID: 2448
		Connect,
		// Token: 0x04000991 RID: 2449
		ConnectAck,
		// Token: 0x04000992 RID: 2450
		Ping,
		// Token: 0x04000993 RID: 2451
		Pong,
		// Token: 0x04000994 RID: 2452
		ChatMessage,
		// Token: 0x04000995 RID: 2453
		ReadyToStartLevel,
		// Token: 0x04000996 RID: 2454
		PlayInput,
		// Token: 0x04000997 RID: 2455
		CharacterSynchronisation,
		// Token: 0x04000998 RID: 2456
		LevelSynchronisation
	}
}
