﻿using System;

namespace OpenTK.Platform.SDL2
{
	// Token: 0x020005B4 RID: 1460
	internal enum EventType
	{
		// Token: 0x04005270 RID: 21104
		FIRSTEVENT,
		// Token: 0x04005271 RID: 21105
		QUIT = 256,
		// Token: 0x04005272 RID: 21106
		WINDOWEVENT = 512,
		// Token: 0x04005273 RID: 21107
		SYSWMEVENT,
		// Token: 0x04005274 RID: 21108
		KEYDOWN = 768,
		// Token: 0x04005275 RID: 21109
		KEYUP,
		// Token: 0x04005276 RID: 21110
		TEXTEDITING,
		// Token: 0x04005277 RID: 21111
		TEXTINPUT,
		// Token: 0x04005278 RID: 21112
		MOUSEMOTION = 1024,
		// Token: 0x04005279 RID: 21113
		MOUSEBUTTONDOWN,
		// Token: 0x0400527A RID: 21114
		MOUSEBUTTONUP,
		// Token: 0x0400527B RID: 21115
		MOUSEWHEEL,
		// Token: 0x0400527C RID: 21116
		JOYAXISMOTION = 1536,
		// Token: 0x0400527D RID: 21117
		JOYBALLMOTION,
		// Token: 0x0400527E RID: 21118
		JOYHATMOTION,
		// Token: 0x0400527F RID: 21119
		JOYBUTTONDOWN,
		// Token: 0x04005280 RID: 21120
		JOYBUTTONUP,
		// Token: 0x04005281 RID: 21121
		JOYDEVICEADDED,
		// Token: 0x04005282 RID: 21122
		JOYDEVICEREMOVED,
		// Token: 0x04005283 RID: 21123
		CONTROLLERAXISMOTION = 1616,
		// Token: 0x04005284 RID: 21124
		CONTROLLERBUTTONDOWN,
		// Token: 0x04005285 RID: 21125
		CONTROLLERBUTTONUP,
		// Token: 0x04005286 RID: 21126
		CONTROLLERDEVICEADDED,
		// Token: 0x04005287 RID: 21127
		CONTROLLERDEVICEREMOVED,
		// Token: 0x04005288 RID: 21128
		CONTROLLERDEVICEREMAPPED,
		// Token: 0x04005289 RID: 21129
		FINGERDOWN = 1792,
		// Token: 0x0400528A RID: 21130
		FINGERUP,
		// Token: 0x0400528B RID: 21131
		FINGERMOTION,
		// Token: 0x0400528C RID: 21132
		DOLLARGESTURE = 2048,
		// Token: 0x0400528D RID: 21133
		DOLLARRECORD,
		// Token: 0x0400528E RID: 21134
		MULTIGESTURE,
		// Token: 0x0400528F RID: 21135
		CLIPBOARDUPDATE = 2304,
		// Token: 0x04005290 RID: 21136
		DROPFILE = 4096,
		// Token: 0x04005291 RID: 21137
		USEREVENT = 32768,
		// Token: 0x04005292 RID: 21138
		LASTEVENT = 65535
	}
}
