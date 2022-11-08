using System;

namespace OpenTK.Platform.X11
{
	// Token: 0x02000189 RID: 393
	internal enum XRequest : byte
	{
		// Token: 0x04001017 RID: 4119
		X_CreateWindow = 1,
		// Token: 0x04001018 RID: 4120
		X_ChangeWindowAttributes,
		// Token: 0x04001019 RID: 4121
		X_GetWindowAttributes,
		// Token: 0x0400101A RID: 4122
		X_DestroyWindow,
		// Token: 0x0400101B RID: 4123
		X_DestroySubwindows,
		// Token: 0x0400101C RID: 4124
		X_ChangeSaveSet,
		// Token: 0x0400101D RID: 4125
		X_ReparentWindow,
		// Token: 0x0400101E RID: 4126
		X_MapWindow,
		// Token: 0x0400101F RID: 4127
		X_MapSubwindows,
		// Token: 0x04001020 RID: 4128
		X_UnmapWindow,
		// Token: 0x04001021 RID: 4129
		X_UnmapSubwindows,
		// Token: 0x04001022 RID: 4130
		X_ConfigureWindow,
		// Token: 0x04001023 RID: 4131
		X_CirculateWindow,
		// Token: 0x04001024 RID: 4132
		X_GetGeometry,
		// Token: 0x04001025 RID: 4133
		X_QueryTree,
		// Token: 0x04001026 RID: 4134
		X_InternAtom,
		// Token: 0x04001027 RID: 4135
		X_GetAtomName,
		// Token: 0x04001028 RID: 4136
		X_ChangeProperty,
		// Token: 0x04001029 RID: 4137
		X_DeleteProperty,
		// Token: 0x0400102A RID: 4138
		X_GetProperty,
		// Token: 0x0400102B RID: 4139
		X_ListProperties,
		// Token: 0x0400102C RID: 4140
		X_SetSelectionOwner,
		// Token: 0x0400102D RID: 4141
		X_GetSelectionOwner,
		// Token: 0x0400102E RID: 4142
		X_ConvertSelection,
		// Token: 0x0400102F RID: 4143
		X_SendEvent,
		// Token: 0x04001030 RID: 4144
		X_GrabPointer,
		// Token: 0x04001031 RID: 4145
		X_UngrabPointer,
		// Token: 0x04001032 RID: 4146
		X_GrabButton,
		// Token: 0x04001033 RID: 4147
		X_UngrabButton,
		// Token: 0x04001034 RID: 4148
		X_ChangeActivePointerGrab,
		// Token: 0x04001035 RID: 4149
		X_GrabKeyboard,
		// Token: 0x04001036 RID: 4150
		X_UngrabKeyboard,
		// Token: 0x04001037 RID: 4151
		X_GrabKey,
		// Token: 0x04001038 RID: 4152
		X_UngrabKey,
		// Token: 0x04001039 RID: 4153
		X_AllowEvents,
		// Token: 0x0400103A RID: 4154
		X_GrabServer,
		// Token: 0x0400103B RID: 4155
		X_UngrabServer,
		// Token: 0x0400103C RID: 4156
		X_QueryPointer,
		// Token: 0x0400103D RID: 4157
		X_GetMotionEvents,
		// Token: 0x0400103E RID: 4158
		X_TranslateCoords,
		// Token: 0x0400103F RID: 4159
		X_WarpPointer,
		// Token: 0x04001040 RID: 4160
		X_SetInputFocus,
		// Token: 0x04001041 RID: 4161
		X_GetInputFocus,
		// Token: 0x04001042 RID: 4162
		X_QueryKeymap,
		// Token: 0x04001043 RID: 4163
		X_OpenFont,
		// Token: 0x04001044 RID: 4164
		X_CloseFont,
		// Token: 0x04001045 RID: 4165
		X_QueryFont,
		// Token: 0x04001046 RID: 4166
		X_QueryTextExtents,
		// Token: 0x04001047 RID: 4167
		X_ListFonts,
		// Token: 0x04001048 RID: 4168
		X_ListFontsWithInfo,
		// Token: 0x04001049 RID: 4169
		X_SetFontPath,
		// Token: 0x0400104A RID: 4170
		X_GetFontPath,
		// Token: 0x0400104B RID: 4171
		X_CreatePixmap,
		// Token: 0x0400104C RID: 4172
		X_FreePixmap,
		// Token: 0x0400104D RID: 4173
		X_CreateGC,
		// Token: 0x0400104E RID: 4174
		X_ChangeGC,
		// Token: 0x0400104F RID: 4175
		X_CopyGC,
		// Token: 0x04001050 RID: 4176
		X_SetDashes,
		// Token: 0x04001051 RID: 4177
		X_SetClipRectangles,
		// Token: 0x04001052 RID: 4178
		X_FreeGC,
		// Token: 0x04001053 RID: 4179
		X_ClearArea,
		// Token: 0x04001054 RID: 4180
		X_CopyArea,
		// Token: 0x04001055 RID: 4181
		X_CopyPlane,
		// Token: 0x04001056 RID: 4182
		X_PolyPoint,
		// Token: 0x04001057 RID: 4183
		X_PolyLine,
		// Token: 0x04001058 RID: 4184
		X_PolySegment,
		// Token: 0x04001059 RID: 4185
		X_PolyRectangle,
		// Token: 0x0400105A RID: 4186
		X_PolyArc,
		// Token: 0x0400105B RID: 4187
		X_FillPoly,
		// Token: 0x0400105C RID: 4188
		X_PolyFillRectangle,
		// Token: 0x0400105D RID: 4189
		X_PolyFillArc,
		// Token: 0x0400105E RID: 4190
		X_PutImage,
		// Token: 0x0400105F RID: 4191
		X_GetImage,
		// Token: 0x04001060 RID: 4192
		X_PolyText8,
		// Token: 0x04001061 RID: 4193
		X_PolyText16,
		// Token: 0x04001062 RID: 4194
		X_ImageText8,
		// Token: 0x04001063 RID: 4195
		X_ImageText16,
		// Token: 0x04001064 RID: 4196
		X_CreateColormap,
		// Token: 0x04001065 RID: 4197
		X_FreeColormap,
		// Token: 0x04001066 RID: 4198
		X_CopyColormapAndFree,
		// Token: 0x04001067 RID: 4199
		X_InstallColormap,
		// Token: 0x04001068 RID: 4200
		X_UninstallColormap,
		// Token: 0x04001069 RID: 4201
		X_ListInstalledColormaps,
		// Token: 0x0400106A RID: 4202
		X_AllocColor,
		// Token: 0x0400106B RID: 4203
		X_AllocNamedColor,
		// Token: 0x0400106C RID: 4204
		X_AllocColorCells,
		// Token: 0x0400106D RID: 4205
		X_AllocColorPlanes,
		// Token: 0x0400106E RID: 4206
		X_FreeColors,
		// Token: 0x0400106F RID: 4207
		X_StoreColors,
		// Token: 0x04001070 RID: 4208
		X_StoreNamedColor,
		// Token: 0x04001071 RID: 4209
		X_QueryColors,
		// Token: 0x04001072 RID: 4210
		X_LookupColor,
		// Token: 0x04001073 RID: 4211
		X_CreateCursor,
		// Token: 0x04001074 RID: 4212
		X_CreateGlyphCursor,
		// Token: 0x04001075 RID: 4213
		X_FreeCursor,
		// Token: 0x04001076 RID: 4214
		X_RecolorCursor,
		// Token: 0x04001077 RID: 4215
		X_QueryBestSize,
		// Token: 0x04001078 RID: 4216
		X_QueryExtension,
		// Token: 0x04001079 RID: 4217
		X_ListExtensions,
		// Token: 0x0400107A RID: 4218
		X_ChangeKeyboardMapping,
		// Token: 0x0400107B RID: 4219
		X_GetKeyboardMapping,
		// Token: 0x0400107C RID: 4220
		X_ChangeKeyboardControl,
		// Token: 0x0400107D RID: 4221
		X_GetKeyboardControl,
		// Token: 0x0400107E RID: 4222
		X_Bell,
		// Token: 0x0400107F RID: 4223
		X_ChangePointerControl,
		// Token: 0x04001080 RID: 4224
		X_GetPointerControl,
		// Token: 0x04001081 RID: 4225
		X_SetScreenSaver,
		// Token: 0x04001082 RID: 4226
		X_GetScreenSaver,
		// Token: 0x04001083 RID: 4227
		X_ChangeHosts,
		// Token: 0x04001084 RID: 4228
		X_ListHosts,
		// Token: 0x04001085 RID: 4229
		X_SetAccessControl,
		// Token: 0x04001086 RID: 4230
		X_SetCloseDownMode,
		// Token: 0x04001087 RID: 4231
		X_KillClient,
		// Token: 0x04001088 RID: 4232
		X_RotateProperties,
		// Token: 0x04001089 RID: 4233
		X_ForceScreenSaver,
		// Token: 0x0400108A RID: 4234
		X_SetPointerMapping,
		// Token: 0x0400108B RID: 4235
		X_GetPointerMapping,
		// Token: 0x0400108C RID: 4236
		X_SetModifierMapping,
		// Token: 0x0400108D RID: 4237
		X_GetModifierMapping,
		// Token: 0x0400108E RID: 4238
		X_NoOperation = 127
	}
}
