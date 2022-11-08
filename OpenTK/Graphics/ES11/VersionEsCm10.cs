using System;

namespace OpenTK.Graphics.ES11
{
	// Token: 0x02000AF2 RID: 2802
	public enum VersionEsCm10
	{
		// Token: 0x0400B333 RID: 45875
		False,
		// Token: 0x0400B334 RID: 45876
		NoError = 0,
		// Token: 0x0400B335 RID: 45877
		Zero = 0,
		// Token: 0x0400B336 RID: 45878
		Points = 0,
		// Token: 0x0400B337 RID: 45879
		DepthBufferBit = 256,
		// Token: 0x0400B338 RID: 45880
		StencilBufferBit = 1024,
		// Token: 0x0400B339 RID: 45881
		ColorBufferBit = 16384,
		// Token: 0x0400B33A RID: 45882
		Lines = 1,
		// Token: 0x0400B33B RID: 45883
		LineLoop,
		// Token: 0x0400B33C RID: 45884
		LineStrip,
		// Token: 0x0400B33D RID: 45885
		Triangles,
		// Token: 0x0400B33E RID: 45886
		TriangleStrip,
		// Token: 0x0400B33F RID: 45887
		TriangleFan,
		// Token: 0x0400B340 RID: 45888
		Add = 260,
		// Token: 0x0400B341 RID: 45889
		Never = 512,
		// Token: 0x0400B342 RID: 45890
		Less,
		// Token: 0x0400B343 RID: 45891
		Equal,
		// Token: 0x0400B344 RID: 45892
		Lequal,
		// Token: 0x0400B345 RID: 45893
		Greater,
		// Token: 0x0400B346 RID: 45894
		Notequal,
		// Token: 0x0400B347 RID: 45895
		Gequal,
		// Token: 0x0400B348 RID: 45896
		Always,
		// Token: 0x0400B349 RID: 45897
		SrcColor = 768,
		// Token: 0x0400B34A RID: 45898
		OneMinusSrcColor,
		// Token: 0x0400B34B RID: 45899
		SrcAlpha,
		// Token: 0x0400B34C RID: 45900
		OneMinusSrcAlpha,
		// Token: 0x0400B34D RID: 45901
		DstAlpha,
		// Token: 0x0400B34E RID: 45902
		OneMinusDstAlpha,
		// Token: 0x0400B34F RID: 45903
		DstColor,
		// Token: 0x0400B350 RID: 45904
		OneMinusDstColor,
		// Token: 0x0400B351 RID: 45905
		SrcAlphaSaturate,
		// Token: 0x0400B352 RID: 45906
		Front = 1028,
		// Token: 0x0400B353 RID: 45907
		Back,
		// Token: 0x0400B354 RID: 45908
		FrontAndBack = 1032,
		// Token: 0x0400B355 RID: 45909
		InvalidEnum = 1280,
		// Token: 0x0400B356 RID: 45910
		InvalidValue,
		// Token: 0x0400B357 RID: 45911
		InvalidOperation,
		// Token: 0x0400B358 RID: 45912
		StackOverflow,
		// Token: 0x0400B359 RID: 45913
		StackUnderflow,
		// Token: 0x0400B35A RID: 45914
		OutOfMemory,
		// Token: 0x0400B35B RID: 45915
		Exp = 2048,
		// Token: 0x0400B35C RID: 45916
		Exp2,
		// Token: 0x0400B35D RID: 45917
		Cw = 2304,
		// Token: 0x0400B35E RID: 45918
		Ccw,
		// Token: 0x0400B35F RID: 45919
		CurrentColor = 2816,
		// Token: 0x0400B360 RID: 45920
		CurrentNormal = 2818,
		// Token: 0x0400B361 RID: 45921
		CurrentTextureCoords,
		// Token: 0x0400B362 RID: 45922
		PointSmooth = 2832,
		// Token: 0x0400B363 RID: 45923
		PointSize,
		// Token: 0x0400B364 RID: 45924
		SmoothPointSizeRange,
		// Token: 0x0400B365 RID: 45925
		LineSmooth = 2848,
		// Token: 0x0400B366 RID: 45926
		LineWidth,
		// Token: 0x0400B367 RID: 45927
		SmoothLineWidthRange,
		// Token: 0x0400B368 RID: 45928
		CullFace = 2884,
		// Token: 0x0400B369 RID: 45929
		CullFaceMode,
		// Token: 0x0400B36A RID: 45930
		FrontFace,
		// Token: 0x0400B36B RID: 45931
		Lighting = 2896,
		// Token: 0x0400B36C RID: 45932
		LightModelTwoSide = 2898,
		// Token: 0x0400B36D RID: 45933
		LightModelAmbient,
		// Token: 0x0400B36E RID: 45934
		ShadeModel,
		// Token: 0x0400B36F RID: 45935
		ColorMaterial = 2903,
		// Token: 0x0400B370 RID: 45936
		Fog = 2912,
		// Token: 0x0400B371 RID: 45937
		FogDensity = 2914,
		// Token: 0x0400B372 RID: 45938
		FogStart,
		// Token: 0x0400B373 RID: 45939
		FogEnd,
		// Token: 0x0400B374 RID: 45940
		FogMode,
		// Token: 0x0400B375 RID: 45941
		FogColor,
		// Token: 0x0400B376 RID: 45942
		DepthRange = 2928,
		// Token: 0x0400B377 RID: 45943
		DepthTest,
		// Token: 0x0400B378 RID: 45944
		DepthWritemask,
		// Token: 0x0400B379 RID: 45945
		DepthClearValue,
		// Token: 0x0400B37A RID: 45946
		DepthFunc,
		// Token: 0x0400B37B RID: 45947
		StencilTest = 2960,
		// Token: 0x0400B37C RID: 45948
		StencilClearValue,
		// Token: 0x0400B37D RID: 45949
		StencilFunc,
		// Token: 0x0400B37E RID: 45950
		StencilValueMask,
		// Token: 0x0400B37F RID: 45951
		StencilFail,
		// Token: 0x0400B380 RID: 45952
		StencilPassDepthFail,
		// Token: 0x0400B381 RID: 45953
		StencilPassDepthPass,
		// Token: 0x0400B382 RID: 45954
		StencilRef,
		// Token: 0x0400B383 RID: 45955
		StencilWritemask,
		// Token: 0x0400B384 RID: 45956
		MatrixMode = 2976,
		// Token: 0x0400B385 RID: 45957
		Normalize,
		// Token: 0x0400B386 RID: 45958
		Viewport,
		// Token: 0x0400B387 RID: 45959
		ModelviewStackDepth,
		// Token: 0x0400B388 RID: 45960
		ProjectionStackDepth,
		// Token: 0x0400B389 RID: 45961
		TextureStackDepth,
		// Token: 0x0400B38A RID: 45962
		ModelviewMatrix,
		// Token: 0x0400B38B RID: 45963
		ProjectionMatrix,
		// Token: 0x0400B38C RID: 45964
		TextureMatrix,
		// Token: 0x0400B38D RID: 45965
		AlphaTest = 3008,
		// Token: 0x0400B38E RID: 45966
		AlphaTestFunc,
		// Token: 0x0400B38F RID: 45967
		AlphaTestRef,
		// Token: 0x0400B390 RID: 45968
		Dither = 3024,
		// Token: 0x0400B391 RID: 45969
		BlendDst = 3040,
		// Token: 0x0400B392 RID: 45970
		BlendSrc,
		// Token: 0x0400B393 RID: 45971
		Blend,
		// Token: 0x0400B394 RID: 45972
		LogicOpMode = 3056,
		// Token: 0x0400B395 RID: 45973
		ColorLogicOp = 3058,
		// Token: 0x0400B396 RID: 45974
		ScissorBox = 3088,
		// Token: 0x0400B397 RID: 45975
		ScissorTest,
		// Token: 0x0400B398 RID: 45976
		ColorClearValue = 3106,
		// Token: 0x0400B399 RID: 45977
		ColorWritemask,
		// Token: 0x0400B39A RID: 45978
		PerspectiveCorrectionHint = 3152,
		// Token: 0x0400B39B RID: 45979
		PointSmoothHint,
		// Token: 0x0400B39C RID: 45980
		LineSmoothHint,
		// Token: 0x0400B39D RID: 45981
		FogHint = 3156,
		// Token: 0x0400B39E RID: 45982
		UnpackAlignment = 3317,
		// Token: 0x0400B39F RID: 45983
		PackAlignment = 3333,
		// Token: 0x0400B3A0 RID: 45984
		AlphaScale = 3356,
		// Token: 0x0400B3A1 RID: 45985
		MaxLights = 3377,
		// Token: 0x0400B3A2 RID: 45986
		MaxClipPlanes,
		// Token: 0x0400B3A3 RID: 45987
		MaxTextureSize,
		// Token: 0x0400B3A4 RID: 45988
		MaxModelviewStackDepth = 3382,
		// Token: 0x0400B3A5 RID: 45989
		MaxProjectionStackDepth = 3384,
		// Token: 0x0400B3A6 RID: 45990
		MaxTextureStackDepth,
		// Token: 0x0400B3A7 RID: 45991
		MaxViewportDims,
		// Token: 0x0400B3A8 RID: 45992
		SubpixelBits = 3408,
		// Token: 0x0400B3A9 RID: 45993
		RedBits = 3410,
		// Token: 0x0400B3AA RID: 45994
		GreenBits,
		// Token: 0x0400B3AB RID: 45995
		BlueBits,
		// Token: 0x0400B3AC RID: 45996
		AlphaBits,
		// Token: 0x0400B3AD RID: 45997
		DepthBits,
		// Token: 0x0400B3AE RID: 45998
		StencilBits,
		// Token: 0x0400B3AF RID: 45999
		Texture2D = 3553,
		// Token: 0x0400B3B0 RID: 46000
		DontCare = 4352,
		// Token: 0x0400B3B1 RID: 46001
		Fastest,
		// Token: 0x0400B3B2 RID: 46002
		Nicest,
		// Token: 0x0400B3B3 RID: 46003
		Ambient = 4608,
		// Token: 0x0400B3B4 RID: 46004
		Diffuse,
		// Token: 0x0400B3B5 RID: 46005
		Specular,
		// Token: 0x0400B3B6 RID: 46006
		Position,
		// Token: 0x0400B3B7 RID: 46007
		SpotDirection,
		// Token: 0x0400B3B8 RID: 46008
		SpotExponent,
		// Token: 0x0400B3B9 RID: 46009
		SpotCutoff,
		// Token: 0x0400B3BA RID: 46010
		ConstantAttenuation,
		// Token: 0x0400B3BB RID: 46011
		LinearAttenuation,
		// Token: 0x0400B3BC RID: 46012
		QuadraticAttenuation,
		// Token: 0x0400B3BD RID: 46013
		Byte = 5120,
		// Token: 0x0400B3BE RID: 46014
		UnsignedByte,
		// Token: 0x0400B3BF RID: 46015
		Short,
		// Token: 0x0400B3C0 RID: 46016
		UnsignedShort,
		// Token: 0x0400B3C1 RID: 46017
		Float = 5126,
		// Token: 0x0400B3C2 RID: 46018
		Fixed = 5132,
		// Token: 0x0400B3C3 RID: 46019
		Clear = 5376,
		// Token: 0x0400B3C4 RID: 46020
		And,
		// Token: 0x0400B3C5 RID: 46021
		AndReverse,
		// Token: 0x0400B3C6 RID: 46022
		Copy,
		// Token: 0x0400B3C7 RID: 46023
		AndInverted,
		// Token: 0x0400B3C8 RID: 46024
		Noop,
		// Token: 0x0400B3C9 RID: 46025
		Xor,
		// Token: 0x0400B3CA RID: 46026
		Or,
		// Token: 0x0400B3CB RID: 46027
		Nor,
		// Token: 0x0400B3CC RID: 46028
		Equiv,
		// Token: 0x0400B3CD RID: 46029
		Invert,
		// Token: 0x0400B3CE RID: 46030
		OrReverse,
		// Token: 0x0400B3CF RID: 46031
		CopyInverted,
		// Token: 0x0400B3D0 RID: 46032
		OrInverted,
		// Token: 0x0400B3D1 RID: 46033
		Nand,
		// Token: 0x0400B3D2 RID: 46034
		Set,
		// Token: 0x0400B3D3 RID: 46035
		Emission = 5632,
		// Token: 0x0400B3D4 RID: 46036
		Shininess,
		// Token: 0x0400B3D5 RID: 46037
		AmbientAndDiffuse,
		// Token: 0x0400B3D6 RID: 46038
		Modelview = 5888,
		// Token: 0x0400B3D7 RID: 46039
		Projection,
		// Token: 0x0400B3D8 RID: 46040
		Texture,
		// Token: 0x0400B3D9 RID: 46041
		Alpha = 6406,
		// Token: 0x0400B3DA RID: 46042
		Rgb,
		// Token: 0x0400B3DB RID: 46043
		Rgba,
		// Token: 0x0400B3DC RID: 46044
		Luminance,
		// Token: 0x0400B3DD RID: 46045
		LuminanceAlpha,
		// Token: 0x0400B3DE RID: 46046
		Flat = 7424,
		// Token: 0x0400B3DF RID: 46047
		Smooth,
		// Token: 0x0400B3E0 RID: 46048
		Keep = 7680,
		// Token: 0x0400B3E1 RID: 46049
		Replace,
		// Token: 0x0400B3E2 RID: 46050
		Incr,
		// Token: 0x0400B3E3 RID: 46051
		Decr,
		// Token: 0x0400B3E4 RID: 46052
		Vendor = 7936,
		// Token: 0x0400B3E5 RID: 46053
		Renderer,
		// Token: 0x0400B3E6 RID: 46054
		Version,
		// Token: 0x0400B3E7 RID: 46055
		Extensions,
		// Token: 0x0400B3E8 RID: 46056
		Modulate = 8448,
		// Token: 0x0400B3E9 RID: 46057
		Decal,
		// Token: 0x0400B3EA RID: 46058
		TextureEnvMode = 8704,
		// Token: 0x0400B3EB RID: 46059
		TextureEnvColor,
		// Token: 0x0400B3EC RID: 46060
		TextureEnv = 8960,
		// Token: 0x0400B3ED RID: 46061
		Nearest = 9728,
		// Token: 0x0400B3EE RID: 46062
		Linear,
		// Token: 0x0400B3EF RID: 46063
		NearestMipmapNearest = 9984,
		// Token: 0x0400B3F0 RID: 46064
		LinearMipmapNearest,
		// Token: 0x0400B3F1 RID: 46065
		NearestMipmapLinear,
		// Token: 0x0400B3F2 RID: 46066
		LinearMipmapLinear,
		// Token: 0x0400B3F3 RID: 46067
		TextureMagFilter = 10240,
		// Token: 0x0400B3F4 RID: 46068
		TextureMinFilter,
		// Token: 0x0400B3F5 RID: 46069
		TextureWrapS,
		// Token: 0x0400B3F6 RID: 46070
		TextureWrapT,
		// Token: 0x0400B3F7 RID: 46071
		Repeat = 10497,
		// Token: 0x0400B3F8 RID: 46072
		PolygonOffsetUnits = 10752,
		// Token: 0x0400B3F9 RID: 46073
		ClipPlane0 = 12288,
		// Token: 0x0400B3FA RID: 46074
		ClipPlane1,
		// Token: 0x0400B3FB RID: 46075
		ClipPlane2,
		// Token: 0x0400B3FC RID: 46076
		ClipPlane3,
		// Token: 0x0400B3FD RID: 46077
		ClipPlane4,
		// Token: 0x0400B3FE RID: 46078
		ClipPlane5,
		// Token: 0x0400B3FF RID: 46079
		Light0 = 16384,
		// Token: 0x0400B400 RID: 46080
		Light1,
		// Token: 0x0400B401 RID: 46081
		Light2,
		// Token: 0x0400B402 RID: 46082
		Light3,
		// Token: 0x0400B403 RID: 46083
		Light4,
		// Token: 0x0400B404 RID: 46084
		Light5,
		// Token: 0x0400B405 RID: 46085
		Light6,
		// Token: 0x0400B406 RID: 46086
		Light7,
		// Token: 0x0400B407 RID: 46087
		UnsignedShort4444 = 32819,
		// Token: 0x0400B408 RID: 46088
		UnsignedShort5551,
		// Token: 0x0400B409 RID: 46089
		PolygonOffsetFill = 32823,
		// Token: 0x0400B40A RID: 46090
		PolygonOffsetFactor,
		// Token: 0x0400B40B RID: 46091
		RescaleNormal = 32826,
		// Token: 0x0400B40C RID: 46092
		TextureBinding2D = 32873,
		// Token: 0x0400B40D RID: 46093
		VertexArray = 32884,
		// Token: 0x0400B40E RID: 46094
		NormalArray,
		// Token: 0x0400B40F RID: 46095
		ColorArray,
		// Token: 0x0400B410 RID: 46096
		TextureCoordArray = 32888,
		// Token: 0x0400B411 RID: 46097
		VertexArraySize = 32890,
		// Token: 0x0400B412 RID: 46098
		VertexArrayType,
		// Token: 0x0400B413 RID: 46099
		VertexArrayStride,
		// Token: 0x0400B414 RID: 46100
		NormalArrayType = 32894,
		// Token: 0x0400B415 RID: 46101
		NormalArrayStride,
		// Token: 0x0400B416 RID: 46102
		ColorArraySize = 32897,
		// Token: 0x0400B417 RID: 46103
		ColorArrayType,
		// Token: 0x0400B418 RID: 46104
		ColorArrayStride,
		// Token: 0x0400B419 RID: 46105
		TextureCoordArraySize = 32904,
		// Token: 0x0400B41A RID: 46106
		TextureCoordArrayType,
		// Token: 0x0400B41B RID: 46107
		TextureCoordArrayStride,
		// Token: 0x0400B41C RID: 46108
		VertexArrayPointer = 32910,
		// Token: 0x0400B41D RID: 46109
		NormalArrayPointer,
		// Token: 0x0400B41E RID: 46110
		ColorArrayPointer,
		// Token: 0x0400B41F RID: 46111
		TextureCoordArrayPointer = 32914,
		// Token: 0x0400B420 RID: 46112
		Multisample = 32925,
		// Token: 0x0400B421 RID: 46113
		SampleAlphaToCoverage,
		// Token: 0x0400B422 RID: 46114
		SampleAlphaToOne,
		// Token: 0x0400B423 RID: 46115
		SampleCoverage,
		// Token: 0x0400B424 RID: 46116
		SampleBuffers = 32936,
		// Token: 0x0400B425 RID: 46117
		Samples,
		// Token: 0x0400B426 RID: 46118
		SampleCoverageValue,
		// Token: 0x0400B427 RID: 46119
		SampleCoverageInvert,
		// Token: 0x0400B428 RID: 46120
		PointSizeMin = 33062,
		// Token: 0x0400B429 RID: 46121
		PointSizeMax,
		// Token: 0x0400B42A RID: 46122
		PointFadeThresholdSize,
		// Token: 0x0400B42B RID: 46123
		PointDistanceAttenuation,
		// Token: 0x0400B42C RID: 46124
		ClampToEdge = 33071,
		// Token: 0x0400B42D RID: 46125
		GenerateMipmap = 33169,
		// Token: 0x0400B42E RID: 46126
		GenerateMipmapHint,
		// Token: 0x0400B42F RID: 46127
		UnsignedShort565 = 33635,
		// Token: 0x0400B430 RID: 46128
		AliasedPointSizeRange = 33901,
		// Token: 0x0400B431 RID: 46129
		AliasedLineWidthRange,
		// Token: 0x0400B432 RID: 46130
		Texture0 = 33984,
		// Token: 0x0400B433 RID: 46131
		Texture1,
		// Token: 0x0400B434 RID: 46132
		Texture2,
		// Token: 0x0400B435 RID: 46133
		Texture3,
		// Token: 0x0400B436 RID: 46134
		Texture4,
		// Token: 0x0400B437 RID: 46135
		Texture5,
		// Token: 0x0400B438 RID: 46136
		Texture6,
		// Token: 0x0400B439 RID: 46137
		Texture7,
		// Token: 0x0400B43A RID: 46138
		Texture8,
		// Token: 0x0400B43B RID: 46139
		Texture9,
		// Token: 0x0400B43C RID: 46140
		Texture10,
		// Token: 0x0400B43D RID: 46141
		Texture11,
		// Token: 0x0400B43E RID: 46142
		Texture12,
		// Token: 0x0400B43F RID: 46143
		Texture13,
		// Token: 0x0400B440 RID: 46144
		Texture14,
		// Token: 0x0400B441 RID: 46145
		Texture15,
		// Token: 0x0400B442 RID: 46146
		Texture16,
		// Token: 0x0400B443 RID: 46147
		Texture17,
		// Token: 0x0400B444 RID: 46148
		Texture18,
		// Token: 0x0400B445 RID: 46149
		Texture19,
		// Token: 0x0400B446 RID: 46150
		Texture20,
		// Token: 0x0400B447 RID: 46151
		Texture21,
		// Token: 0x0400B448 RID: 46152
		Texture22,
		// Token: 0x0400B449 RID: 46153
		Texture23,
		// Token: 0x0400B44A RID: 46154
		Texture24,
		// Token: 0x0400B44B RID: 46155
		Texture25,
		// Token: 0x0400B44C RID: 46156
		Texture26,
		// Token: 0x0400B44D RID: 46157
		Texture27,
		// Token: 0x0400B44E RID: 46158
		Texture28,
		// Token: 0x0400B44F RID: 46159
		Texture29,
		// Token: 0x0400B450 RID: 46160
		Texture30,
		// Token: 0x0400B451 RID: 46161
		Texture31,
		// Token: 0x0400B452 RID: 46162
		ActiveTexture,
		// Token: 0x0400B453 RID: 46163
		ClientActiveTexture,
		// Token: 0x0400B454 RID: 46164
		MaxTextureUnits,
		// Token: 0x0400B455 RID: 46165
		Subtract = 34023,
		// Token: 0x0400B456 RID: 46166
		Combine = 34160,
		// Token: 0x0400B457 RID: 46167
		CombineRgb,
		// Token: 0x0400B458 RID: 46168
		CombineAlpha,
		// Token: 0x0400B459 RID: 46169
		RgbScale,
		// Token: 0x0400B45A RID: 46170
		AddSigned,
		// Token: 0x0400B45B RID: 46171
		Interpolate,
		// Token: 0x0400B45C RID: 46172
		Constant,
		// Token: 0x0400B45D RID: 46173
		PrimaryColor,
		// Token: 0x0400B45E RID: 46174
		Previous,
		// Token: 0x0400B45F RID: 46175
		Src0Rgb = 34176,
		// Token: 0x0400B460 RID: 46176
		Src1Rgb,
		// Token: 0x0400B461 RID: 46177
		Src2Rgb,
		// Token: 0x0400B462 RID: 46178
		Src0Alpha = 34184,
		// Token: 0x0400B463 RID: 46179
		Src1Alpha,
		// Token: 0x0400B464 RID: 46180
		Src2Alpha,
		// Token: 0x0400B465 RID: 46181
		Operand0Rgb = 34192,
		// Token: 0x0400B466 RID: 46182
		Operand1Rgb,
		// Token: 0x0400B467 RID: 46183
		Operand2Rgb,
		// Token: 0x0400B468 RID: 46184
		Operand0Alpha = 34200,
		// Token: 0x0400B469 RID: 46185
		Operand1Alpha,
		// Token: 0x0400B46A RID: 46186
		Operand2Alpha,
		// Token: 0x0400B46B RID: 46187
		NumCompressedTextureFormats = 34466,
		// Token: 0x0400B46C RID: 46188
		CompressedTextureFormats,
		// Token: 0x0400B46D RID: 46189
		Dot3Rgb = 34478,
		// Token: 0x0400B46E RID: 46190
		Dot3Rgba,
		// Token: 0x0400B46F RID: 46191
		BufferSize = 34660,
		// Token: 0x0400B470 RID: 46192
		BufferUsage,
		// Token: 0x0400B471 RID: 46193
		ArrayBuffer = 34962,
		// Token: 0x0400B472 RID: 46194
		ElementArrayBuffer,
		// Token: 0x0400B473 RID: 46195
		ArrayBufferBinding,
		// Token: 0x0400B474 RID: 46196
		ElementArrayBufferBinding,
		// Token: 0x0400B475 RID: 46197
		VertexArrayBufferBinding,
		// Token: 0x0400B476 RID: 46198
		NormalArrayBufferBinding,
		// Token: 0x0400B477 RID: 46199
		ColorArrayBufferBinding,
		// Token: 0x0400B478 RID: 46200
		TextureCoordArrayBufferBinding = 34970,
		// Token: 0x0400B479 RID: 46201
		StaticDraw = 35044,
		// Token: 0x0400B47A RID: 46202
		DynamicDraw = 35048,
		// Token: 0x0400B47B RID: 46203
		One = 1,
		// Token: 0x0400B47C RID: 46204
		True = 1,
		// Token: 0x0400B47D RID: 46205
		VersionEsCl10 = 1,
		// Token: 0x0400B47E RID: 46206
		VersionEsCl11 = 1,
		// Token: 0x0400B47F RID: 46207
		VersionEsCm11 = 1
	}
}
