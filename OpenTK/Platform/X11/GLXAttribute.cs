﻿using System;

namespace OpenTK.Platform.X11
{
	// Token: 0x020001A2 RID: 418
	internal enum GLXAttribute
	{
		// Token: 0x04001137 RID: 4407
		TRANSPARENT_BLUE_VALUE_EXT = 39,
		// Token: 0x04001138 RID: 4408
		GRAY_SCALE = 32774,
		// Token: 0x04001139 RID: 4409
		RGBA_TYPE = 32788,
		// Token: 0x0400113A RID: 4410
		TRANSPARENT_RGB_EXT = 32776,
		// Token: 0x0400113B RID: 4411
		ACCUM_BLUE_SIZE = 16,
		// Token: 0x0400113C RID: 4412
		SHARE_CONTEXT_EXT = 32778,
		// Token: 0x0400113D RID: 4413
		STEREO = 6,
		// Token: 0x0400113E RID: 4414
		ALPHA_SIZE = 11,
		// Token: 0x0400113F RID: 4415
		FLOAT_COMPONENTS_NV = 8368,
		// Token: 0x04001140 RID: 4416
		NONE = 32768,
		// Token: 0x04001141 RID: 4417
		DEPTH_SIZE = 12,
		// Token: 0x04001142 RID: 4418
		TRANSPARENT_INDEX_VALUE_EXT = 36,
		// Token: 0x04001143 RID: 4419
		MAX_PBUFFER_WIDTH_SGIX = 32790,
		// Token: 0x04001144 RID: 4420
		GREEN_SIZE = 9,
		// Token: 0x04001145 RID: 4421
		X_RENDERABLE_SGIX = 32786,
		// Token: 0x04001146 RID: 4422
		LARGEST_PBUFFER = 32796,
		// Token: 0x04001147 RID: 4423
		DONT_CARE = -1,
		// Token: 0x04001148 RID: 4424
		TRANSPARENT_ALPHA_VALUE_EXT = 40,
		// Token: 0x04001149 RID: 4425
		PSEUDO_COLOR_EXT = 32772,
		// Token: 0x0400114A RID: 4426
		USE_GL = 1,
		// Token: 0x0400114B RID: 4427
		SAMPLE_BUFFERS_SGIS = 100000,
		// Token: 0x0400114C RID: 4428
		TRANSPARENT_GREEN_VALUE_EXT = 38,
		// Token: 0x0400114D RID: 4429
		HYPERPIPE_ID_SGIX = 32816,
		// Token: 0x0400114E RID: 4430
		COLOR_INDEX_TYPE_SGIX = 32789,
		// Token: 0x0400114F RID: 4431
		SLOW_CONFIG = 32769,
		// Token: 0x04001150 RID: 4432
		PRESERVED_CONTENTS = 32795,
		// Token: 0x04001151 RID: 4433
		ACCUM_RED_SIZE = 14,
		// Token: 0x04001152 RID: 4434
		EVENT_MASK = 32799,
		// Token: 0x04001153 RID: 4435
		VISUAL_ID_EXT = 32779,
		// Token: 0x04001154 RID: 4436
		EVENT_MASK_SGIX = 32799,
		// Token: 0x04001155 RID: 4437
		SLOW_VISUAL_EXT = 32769,
		// Token: 0x04001156 RID: 4438
		TRANSPARENT_GREEN_VALUE = 38,
		// Token: 0x04001157 RID: 4439
		MAX_PBUFFER_WIDTH = 32790,
		// Token: 0x04001158 RID: 4440
		DIRECT_COLOR_EXT = 32771,
		// Token: 0x04001159 RID: 4441
		VISUAL_ID = 32779,
		// Token: 0x0400115A RID: 4442
		ACCUM_GREEN_SIZE = 15,
		// Token: 0x0400115B RID: 4443
		DRAWABLE_TYPE_SGIX = 32784,
		// Token: 0x0400115C RID: 4444
		SCREEN_EXT = 32780,
		// Token: 0x0400115D RID: 4445
		SAMPLES = 100001,
		// Token: 0x0400115E RID: 4446
		HEIGHT = 32798,
		// Token: 0x0400115F RID: 4447
		TRANSPARENT_INDEX_VALUE = 36,
		// Token: 0x04001160 RID: 4448
		SAMPLE_BUFFERS_ARB = 100000,
		// Token: 0x04001161 RID: 4449
		PBUFFER = 32803,
		// Token: 0x04001162 RID: 4450
		RGBA_TYPE_SGIX = 32788,
		// Token: 0x04001163 RID: 4451
		MAX_PBUFFER_HEIGHT = 32791,
		// Token: 0x04001164 RID: 4452
		FBCONFIG_ID_SGIX = 32787,
		// Token: 0x04001165 RID: 4453
		DRAWABLE_TYPE = 32784,
		// Token: 0x04001166 RID: 4454
		SCREEN = 32780,
		// Token: 0x04001167 RID: 4455
		RED_SIZE = 8,
		// Token: 0x04001168 RID: 4456
		VISUAL_SELECT_GROUP_SGIX = 32808,
		// Token: 0x04001169 RID: 4457
		VISUAL_CAVEAT_EXT = 32,
		// Token: 0x0400116A RID: 4458
		PSEUDO_COLOR = 32772,
		// Token: 0x0400116B RID: 4459
		PBUFFER_HEIGHT = 32832,
		// Token: 0x0400116C RID: 4460
		STATIC_GRAY = 32775,
		// Token: 0x0400116D RID: 4461
		PRESERVED_CONTENTS_SGIX = 32795,
		// Token: 0x0400116E RID: 4462
		RGBA_FLOAT_TYPE_ARB = 8377,
		// Token: 0x0400116F RID: 4463
		TRANSPARENT_RED_VALUE = 37,
		// Token: 0x04001170 RID: 4464
		TRANSPARENT_ALPHA_VALUE = 40,
		// Token: 0x04001171 RID: 4465
		WINDOW = 32802,
		// Token: 0x04001172 RID: 4466
		X_RENDERABLE = 32786,
		// Token: 0x04001173 RID: 4467
		STENCIL_SIZE = 13,
		// Token: 0x04001174 RID: 4468
		TRANSPARENT_RGB = 32776,
		// Token: 0x04001175 RID: 4469
		LARGEST_PBUFFER_SGIX = 32796,
		// Token: 0x04001176 RID: 4470
		STATIC_GRAY_EXT = 32775,
		// Token: 0x04001177 RID: 4471
		TRANSPARENT_BLUE_VALUE = 39,
		// Token: 0x04001178 RID: 4472
		DIGITAL_MEDIA_PBUFFER_SGIX = 32804,
		// Token: 0x04001179 RID: 4473
		BLENDED_RGBA_SGIS,
		// Token: 0x0400117A RID: 4474
		NON_CONFORMANT_VISUAL_EXT = 32781,
		// Token: 0x0400117B RID: 4475
		COLOR_INDEX_TYPE = 32789,
		// Token: 0x0400117C RID: 4476
		TRANSPARENT_RED_VALUE_EXT = 37,
		// Token: 0x0400117D RID: 4477
		GRAY_SCALE_EXT = 32774,
		// Token: 0x0400117E RID: 4478
		WINDOW_SGIX = 32802,
		// Token: 0x0400117F RID: 4479
		X_VISUAL_TYPE = 34,
		// Token: 0x04001180 RID: 4480
		MAX_PBUFFER_HEIGHT_SGIX = 32791,
		// Token: 0x04001181 RID: 4481
		DOUBLEBUFFER = 5,
		// Token: 0x04001182 RID: 4482
		OPTIMAL_PBUFFER_WIDTH_SGIX = 32793,
		// Token: 0x04001183 RID: 4483
		X_VISUAL_TYPE_EXT = 34,
		// Token: 0x04001184 RID: 4484
		WIDTH_SGIX = 32797,
		// Token: 0x04001185 RID: 4485
		STATIC_COLOR_EXT = 32773,
		// Token: 0x04001186 RID: 4486
		BUFFER_SIZE = 2,
		// Token: 0x04001187 RID: 4487
		DIRECT_COLOR = 32771,
		// Token: 0x04001188 RID: 4488
		MAX_PBUFFER_PIXELS = 32792,
		// Token: 0x04001189 RID: 4489
		NONE_EXT = 32768,
		// Token: 0x0400118A RID: 4490
		HEIGHT_SGIX = 32798,
		// Token: 0x0400118B RID: 4491
		RENDER_TYPE = 32785,
		// Token: 0x0400118C RID: 4492
		FBCONFIG_ID = 32787,
		// Token: 0x0400118D RID: 4493
		TRANSPARENT_INDEX_EXT = 32777,
		// Token: 0x0400118E RID: 4494
		TRANSPARENT_INDEX = 32777,
		// Token: 0x0400118F RID: 4495
		TRANSPARENT_TYPE_EXT = 35,
		// Token: 0x04001190 RID: 4496
		ACCUM_ALPHA_SIZE = 17,
		// Token: 0x04001191 RID: 4497
		PBUFFER_SGIX = 32803,
		// Token: 0x04001192 RID: 4498
		MAX_PBUFFER_PIXELS_SGIX = 32792,
		// Token: 0x04001193 RID: 4499
		OPTIMAL_PBUFFER_HEIGHT_SGIX = 32794,
		// Token: 0x04001194 RID: 4500
		DAMAGED = 32800,
		// Token: 0x04001195 RID: 4501
		SAVED_SGIX,
		// Token: 0x04001196 RID: 4502
		TRANSPARENT_TYPE = 35,
		// Token: 0x04001197 RID: 4503
		MULTISAMPLE_SUB_RECT_WIDTH_SGIS = 32806,
		// Token: 0x04001198 RID: 4504
		NON_CONFORMANT_CONFIG = 32781,
		// Token: 0x04001199 RID: 4505
		BLUE_SIZE = 10,
		// Token: 0x0400119A RID: 4506
		TRUE_COLOR_EXT = 32770,
		// Token: 0x0400119B RID: 4507
		SAMPLES_SGIS = 100001,
		// Token: 0x0400119C RID: 4508
		SAMPLES_ARB = 100001,
		// Token: 0x0400119D RID: 4509
		TRUE_COLOR = 32770,
		// Token: 0x0400119E RID: 4510
		RGBA = 4,
		// Token: 0x0400119F RID: 4511
		AUX_BUFFERS = 7,
		// Token: 0x040011A0 RID: 4512
		SAMPLE_BUFFERS = 100000,
		// Token: 0x040011A1 RID: 4513
		SAVED = 32801,
		// Token: 0x040011A2 RID: 4514
		MULTISAMPLE_SUB_RECT_HEIGHT_SGIS = 32807,
		// Token: 0x040011A3 RID: 4515
		DAMAGED_SGIX = 32800,
		// Token: 0x040011A4 RID: 4516
		STATIC_COLOR = 32773,
		// Token: 0x040011A5 RID: 4517
		PBUFFER_WIDTH = 32833,
		// Token: 0x040011A6 RID: 4518
		WIDTH = 32797,
		// Token: 0x040011A7 RID: 4519
		LEVEL = 3,
		// Token: 0x040011A8 RID: 4520
		CONFIG_CAVEAT = 32,
		// Token: 0x040011A9 RID: 4521
		RENDER_TYPE_SGIX = 32785,
		// Token: 0x040011AA RID: 4522
		SWAP_INTERVAL_EXT = 8433,
		// Token: 0x040011AB RID: 4523
		MAX_SWAP_INTERVAL_EXT
	}
}
