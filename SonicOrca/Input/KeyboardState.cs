using System;
using System.Collections;
using System.Collections.Generic;
using SonicOrca.Extensions;

namespace SonicOrca.Input
{
	// Token: 0x020000B0 RID: 176
	public sealed class KeyboardState : IReadOnlyList<bool>, IReadOnlyCollection<bool>, IEnumerable<bool>, IEnumerable
	{
		// Token: 0x170000E2 RID: 226
		// (get) Token: 0x060005E1 RID: 1505 RVA: 0x0001C151 File Offset: 0x0001A351
		public IReadOnlyList<bool> Keys
		{
			get
			{
				return this._keys;
			}
		}

		// Token: 0x060005E2 RID: 1506 RVA: 0x0001C159 File Offset: 0x0001A359
		public KeyboardState()
		{
			this._keys = new bool[512];
		}

		// Token: 0x060005E3 RID: 1507 RVA: 0x0001C171 File Offset: 0x0001A371
		public KeyboardState(bool[] keys)
		{
			this._keys = keys;
		}

		// Token: 0x170000E3 RID: 227
		public bool this[int index]
		{
			get
			{
				return this._keys[index];
			}
		}

		// Token: 0x170000E4 RID: 228
		// (get) Token: 0x060005E5 RID: 1509 RVA: 0x0001C18A File Offset: 0x0001A38A
		public IEnumerable<int> ActiveKeys
		{
			get
			{
				int num;
				for (int i = 0; i < this._keys.Length; i = num + 1)
				{
					if (this._keys[i])
					{
						yield return i;
					}
					num = i;
				}
				yield break;
			}
		}

		// Token: 0x060005E6 RID: 1510 RVA: 0x0001C19C File Offset: 0x0001A39C
		public static KeyboardState GetPressed(KeyboardState previousState, KeyboardState nextState)
		{
			KeyboardState keyboardState = new KeyboardState();
			for (int i = 0; i < previousState._keys.Length; i++)
			{
				keyboardState._keys[i] = (!previousState._keys[i] && nextState._keys[i]);
			}
			return keyboardState;
		}

		// Token: 0x060005E7 RID: 1511 RVA: 0x0001C1E0 File Offset: 0x0001A3E0
		public static KeyboardState GetReleased(KeyboardState previousState, KeyboardState nextState)
		{
			KeyboardState keyboardState = new KeyboardState();
			for (int i = 0; i < previousState._keys.Length; i++)
			{
				keyboardState._keys[i] = (previousState._keys[i] && !nextState._keys[i]);
			}
			return keyboardState;
		}

		// Token: 0x170000E5 RID: 229
		// (get) Token: 0x060005E8 RID: 1512 RVA: 0x0001C227 File Offset: 0x0001A427
		public int Count
		{
			get
			{
				return this._keys.Length;
			}
		}

		// Token: 0x060005E9 RID: 1513 RVA: 0x0001C231 File Offset: 0x0001A431
		public IEnumerator<bool> GetEnumerator()
		{
			return this._keys.GetEnumeratorGeneric<bool>();
		}

		// Token: 0x060005EA RID: 1514 RVA: 0x0001C23E File Offset: 0x0001A43E
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		// Token: 0x04000378 RID: 888
		public const int KEY_UNKNOWN = 0;

		// Token: 0x04000379 RID: 889
		public const int KEY_A = 4;

		// Token: 0x0400037A RID: 890
		public const int KEY_B = 5;

		// Token: 0x0400037B RID: 891
		public const int KEY_C = 6;

		// Token: 0x0400037C RID: 892
		public const int KEY_D = 7;

		// Token: 0x0400037D RID: 893
		public const int KEY_E = 8;

		// Token: 0x0400037E RID: 894
		public const int KEY_F = 9;

		// Token: 0x0400037F RID: 895
		public const int KEY_G = 10;

		// Token: 0x04000380 RID: 896
		public const int KEY_H = 11;

		// Token: 0x04000381 RID: 897
		public const int KEY_I = 12;

		// Token: 0x04000382 RID: 898
		public const int KEY_J = 13;

		// Token: 0x04000383 RID: 899
		public const int KEY_K = 14;

		// Token: 0x04000384 RID: 900
		public const int KEY_L = 15;

		// Token: 0x04000385 RID: 901
		public const int KEY_M = 16;

		// Token: 0x04000386 RID: 902
		public const int KEY_N = 17;

		// Token: 0x04000387 RID: 903
		public const int KEY_O = 18;

		// Token: 0x04000388 RID: 904
		public const int KEY_P = 19;

		// Token: 0x04000389 RID: 905
		public const int KEY_Q = 20;

		// Token: 0x0400038A RID: 906
		public const int KEY_R = 21;

		// Token: 0x0400038B RID: 907
		public const int KEY_S = 22;

		// Token: 0x0400038C RID: 908
		public const int KEY_T = 23;

		// Token: 0x0400038D RID: 909
		public const int KEY_U = 24;

		// Token: 0x0400038E RID: 910
		public const int KEY_V = 25;

		// Token: 0x0400038F RID: 911
		public const int KEY_W = 26;

		// Token: 0x04000390 RID: 912
		public const int KEY_X = 27;

		// Token: 0x04000391 RID: 913
		public const int KEY_Y = 28;

		// Token: 0x04000392 RID: 914
		public const int KEY_Z = 29;

		// Token: 0x04000393 RID: 915
		public const int KEY_1 = 30;

		// Token: 0x04000394 RID: 916
		public const int KEY_2 = 31;

		// Token: 0x04000395 RID: 917
		public const int KEY_3 = 32;

		// Token: 0x04000396 RID: 918
		public const int KEY_4 = 33;

		// Token: 0x04000397 RID: 919
		public const int KEY_5 = 34;

		// Token: 0x04000398 RID: 920
		public const int KEY_6 = 35;

		// Token: 0x04000399 RID: 921
		public const int KEY_7 = 36;

		// Token: 0x0400039A RID: 922
		public const int KEY_8 = 37;

		// Token: 0x0400039B RID: 923
		public const int KEY_9 = 38;

		// Token: 0x0400039C RID: 924
		public const int KEY_0 = 39;

		// Token: 0x0400039D RID: 925
		public const int KEY_RETURN = 40;

		// Token: 0x0400039E RID: 926
		public const int KEY_ESCAPE = 41;

		// Token: 0x0400039F RID: 927
		public const int KEY_BACKSPACE = 42;

		// Token: 0x040003A0 RID: 928
		public const int KEY_TAB = 43;

		// Token: 0x040003A1 RID: 929
		public const int KEY_SPACE = 44;

		// Token: 0x040003A2 RID: 930
		public const int KEY_MINUS = 45;

		// Token: 0x040003A3 RID: 931
		public const int KEY_EQUALS = 46;

		// Token: 0x040003A4 RID: 932
		public const int KEY_LEFTBRACKET = 47;

		// Token: 0x040003A5 RID: 933
		public const int KEY_RIGHTBRACKET = 48;

		// Token: 0x040003A6 RID: 934
		public const int KEY_BACKSLASH = 49;

		// Token: 0x040003A7 RID: 935
		public const int KEY_NONUSHASH = 50;

		// Token: 0x040003A8 RID: 936
		public const int KEY_SEMICOLON = 51;

		// Token: 0x040003A9 RID: 937
		public const int KEY_APOSTROPHE = 52;

		// Token: 0x040003AA RID: 938
		public const int KEY_GRAVE = 53;

		// Token: 0x040003AB RID: 939
		public const int KEY_COMMA = 54;

		// Token: 0x040003AC RID: 940
		public const int KEY_PERIOD = 55;

		// Token: 0x040003AD RID: 941
		public const int KEY_SLASH = 56;

		// Token: 0x040003AE RID: 942
		public const int KEY_CAPSLOCK = 57;

		// Token: 0x040003AF RID: 943
		public const int KEY_F1 = 58;

		// Token: 0x040003B0 RID: 944
		public const int KEY_F2 = 59;

		// Token: 0x040003B1 RID: 945
		public const int KEY_F3 = 60;

		// Token: 0x040003B2 RID: 946
		public const int KEY_F4 = 61;

		// Token: 0x040003B3 RID: 947
		public const int KEY_F5 = 62;

		// Token: 0x040003B4 RID: 948
		public const int KEY_F6 = 63;

		// Token: 0x040003B5 RID: 949
		public const int KEY_F7 = 64;

		// Token: 0x040003B6 RID: 950
		public const int KEY_F8 = 65;

		// Token: 0x040003B7 RID: 951
		public const int KEY_F9 = 66;

		// Token: 0x040003B8 RID: 952
		public const int KEY_F10 = 67;

		// Token: 0x040003B9 RID: 953
		public const int KEY_F11 = 68;

		// Token: 0x040003BA RID: 954
		public const int KEY_F12 = 69;

		// Token: 0x040003BB RID: 955
		public const int KEY_PRINTSCREEN = 70;

		// Token: 0x040003BC RID: 956
		public const int KEY_SCROLLLOCK = 71;

		// Token: 0x040003BD RID: 957
		public const int KEY_PAUSE = 72;

		// Token: 0x040003BE RID: 958
		public const int KEY_INSERT = 73;

		// Token: 0x040003BF RID: 959
		public const int KEY_HOME = 74;

		// Token: 0x040003C0 RID: 960
		public const int KEY_PAGEUP = 75;

		// Token: 0x040003C1 RID: 961
		public const int KEY_DELETE = 76;

		// Token: 0x040003C2 RID: 962
		public const int KEY_END = 77;

		// Token: 0x040003C3 RID: 963
		public const int KEY_PAGEDOWN = 78;

		// Token: 0x040003C4 RID: 964
		public const int KEY_RIGHT = 79;

		// Token: 0x040003C5 RID: 965
		public const int KEY_LEFT = 80;

		// Token: 0x040003C6 RID: 966
		public const int KEY_DOWN = 81;

		// Token: 0x040003C7 RID: 967
		public const int KEY_UP = 82;

		// Token: 0x040003C8 RID: 968
		public const int KEY_NUMLOCKCLEAR = 83;

		// Token: 0x040003C9 RID: 969
		public const int KEY_KP_DIVIDE = 84;

		// Token: 0x040003CA RID: 970
		public const int KEY_KP_MULTIPLY = 85;

		// Token: 0x040003CB RID: 971
		public const int KEY_KP_MINUS = 86;

		// Token: 0x040003CC RID: 972
		public const int KEY_KP_PLUS = 87;

		// Token: 0x040003CD RID: 973
		public const int KEY_KP_ENTER = 88;

		// Token: 0x040003CE RID: 974
		public const int KEY_KP_1 = 89;

		// Token: 0x040003CF RID: 975
		public const int KEY_KP_2 = 90;

		// Token: 0x040003D0 RID: 976
		public const int KEY_KP_3 = 91;

		// Token: 0x040003D1 RID: 977
		public const int KEY_KP_4 = 92;

		// Token: 0x040003D2 RID: 978
		public const int KEY_KP_5 = 93;

		// Token: 0x040003D3 RID: 979
		public const int KEY_KP_6 = 94;

		// Token: 0x040003D4 RID: 980
		public const int KEY_KP_7 = 95;

		// Token: 0x040003D5 RID: 981
		public const int KEY_KP_8 = 96;

		// Token: 0x040003D6 RID: 982
		public const int KEY_KP_9 = 97;

		// Token: 0x040003D7 RID: 983
		public const int KEY_KP_0 = 98;

		// Token: 0x040003D8 RID: 984
		public const int KEY_KP_PERIOD = 99;

		// Token: 0x040003D9 RID: 985
		public const int KEY_NONUSBACKSLASH = 100;

		// Token: 0x040003DA RID: 986
		public const int KEY_APPLICATION = 101;

		// Token: 0x040003DB RID: 987
		public const int KEY_POWER = 102;

		// Token: 0x040003DC RID: 988
		public const int KEY_KP_EQUALS = 103;

		// Token: 0x040003DD RID: 989
		public const int KEY_F13 = 104;

		// Token: 0x040003DE RID: 990
		public const int KEY_F14 = 105;

		// Token: 0x040003DF RID: 991
		public const int KEY_F15 = 106;

		// Token: 0x040003E0 RID: 992
		public const int KEY_F16 = 107;

		// Token: 0x040003E1 RID: 993
		public const int KEY_F17 = 108;

		// Token: 0x040003E2 RID: 994
		public const int KEY_F18 = 109;

		// Token: 0x040003E3 RID: 995
		public const int KEY_F19 = 110;

		// Token: 0x040003E4 RID: 996
		public const int KEY_F20 = 111;

		// Token: 0x040003E5 RID: 997
		public const int KEY_F21 = 112;

		// Token: 0x040003E6 RID: 998
		public const int KEY_F22 = 113;

		// Token: 0x040003E7 RID: 999
		public const int KEY_F23 = 114;

		// Token: 0x040003E8 RID: 1000
		public const int KEY_F24 = 115;

		// Token: 0x040003E9 RID: 1001
		public const int KEY_EXECUTE = 116;

		// Token: 0x040003EA RID: 1002
		public const int KEY_HELP = 117;

		// Token: 0x040003EB RID: 1003
		public const int KEY_MENU = 118;

		// Token: 0x040003EC RID: 1004
		public const int KEY_SELECT = 119;

		// Token: 0x040003ED RID: 1005
		public const int KEY_STOP = 120;

		// Token: 0x040003EE RID: 1006
		public const int KEY_AGAIN = 121;

		// Token: 0x040003EF RID: 1007
		public const int KEY_UNDO = 122;

		// Token: 0x040003F0 RID: 1008
		public const int KEY_CUT = 123;

		// Token: 0x040003F1 RID: 1009
		public const int KEY_COPY = 124;

		// Token: 0x040003F2 RID: 1010
		public const int KEY_PASTE = 125;

		// Token: 0x040003F3 RID: 1011
		public const int KEY_FIND = 126;

		// Token: 0x040003F4 RID: 1012
		public const int KEY_MUTE = 127;

		// Token: 0x040003F5 RID: 1013
		public const int KEY_VOLUMEUP = 128;

		// Token: 0x040003F6 RID: 1014
		public const int KEY_VOLUMEDOWN = 129;

		// Token: 0x040003F7 RID: 1015
		public const int KEY_KP_COMMA = 133;

		// Token: 0x040003F8 RID: 1016
		public const int KEY_KP_EQUALSAS400 = 134;

		// Token: 0x040003F9 RID: 1017
		public const int KEY_INTERNATIONAL1 = 135;

		// Token: 0x040003FA RID: 1018
		public const int KEY_INTERNATIONAL2 = 136;

		// Token: 0x040003FB RID: 1019
		public const int KEY_INTERNATIONAL3 = 137;

		// Token: 0x040003FC RID: 1020
		public const int KEY_INTERNATIONAL4 = 138;

		// Token: 0x040003FD RID: 1021
		public const int KEY_INTERNATIONAL5 = 139;

		// Token: 0x040003FE RID: 1022
		public const int KEY_INTERNATIONAL6 = 140;

		// Token: 0x040003FF RID: 1023
		public const int KEY_INTERNATIONAL7 = 141;

		// Token: 0x04000400 RID: 1024
		public const int KEY_INTERNATIONAL8 = 142;

		// Token: 0x04000401 RID: 1025
		public const int KEY_INTERNATIONAL9 = 143;

		// Token: 0x04000402 RID: 1026
		public const int KEY_LANG1 = 144;

		// Token: 0x04000403 RID: 1027
		public const int KEY_LANG2 = 145;

		// Token: 0x04000404 RID: 1028
		public const int KEY_LANG3 = 146;

		// Token: 0x04000405 RID: 1029
		public const int KEY_LANG4 = 147;

		// Token: 0x04000406 RID: 1030
		public const int KEY_LANG5 = 148;

		// Token: 0x04000407 RID: 1031
		public const int KEY_LANG6 = 149;

		// Token: 0x04000408 RID: 1032
		public const int KEY_LANG7 = 150;

		// Token: 0x04000409 RID: 1033
		public const int KEY_LANG8 = 151;

		// Token: 0x0400040A RID: 1034
		public const int KEY_LANG9 = 152;

		// Token: 0x0400040B RID: 1035
		public const int KEY_ALTERASE = 153;

		// Token: 0x0400040C RID: 1036
		public const int KEY_SYSREQ = 154;

		// Token: 0x0400040D RID: 1037
		public const int KEY_CANCEL = 155;

		// Token: 0x0400040E RID: 1038
		public const int KEY_CLEAR = 156;

		// Token: 0x0400040F RID: 1039
		public const int KEY_PRIOR = 157;

		// Token: 0x04000410 RID: 1040
		public const int KEY_RETURN2 = 158;

		// Token: 0x04000411 RID: 1041
		public const int KEY_SEPARATOR = 159;

		// Token: 0x04000412 RID: 1042
		public const int KEY_OUT = 160;

		// Token: 0x04000413 RID: 1043
		public const int KEY_OPER = 161;

		// Token: 0x04000414 RID: 1044
		public const int KEY_CLEARAGAIN = 162;

		// Token: 0x04000415 RID: 1045
		public const int KEY_CRSEL = 163;

		// Token: 0x04000416 RID: 1046
		public const int KEY_EXSEL = 164;

		// Token: 0x04000417 RID: 1047
		public const int KEY_KP_00 = 176;

		// Token: 0x04000418 RID: 1048
		public const int KEY_KP_000 = 177;

		// Token: 0x04000419 RID: 1049
		public const int KEY_THOUSANDSSEPARATOR = 178;

		// Token: 0x0400041A RID: 1050
		public const int KEY_DECIMALSEPARATOR = 179;

		// Token: 0x0400041B RID: 1051
		public const int KEY_CURRENCYUNIT = 180;

		// Token: 0x0400041C RID: 1052
		public const int KEY_CURRENCYSUBUNIT = 181;

		// Token: 0x0400041D RID: 1053
		public const int KEY_KP_LEFTPAREN = 182;

		// Token: 0x0400041E RID: 1054
		public const int KEY_KP_RIGHTPAREN = 183;

		// Token: 0x0400041F RID: 1055
		public const int KEY_KP_LEFTBRACE = 184;

		// Token: 0x04000420 RID: 1056
		public const int KEY_KP_RIGHTBRACE = 185;

		// Token: 0x04000421 RID: 1057
		public const int KEY_KP_TAB = 186;

		// Token: 0x04000422 RID: 1058
		public const int KEY_KP_BACKSPACE = 187;

		// Token: 0x04000423 RID: 1059
		public const int KEY_KP_A = 188;

		// Token: 0x04000424 RID: 1060
		public const int KEY_KP_B = 189;

		// Token: 0x04000425 RID: 1061
		public const int KEY_KP_C = 190;

		// Token: 0x04000426 RID: 1062
		public const int KEY_KP_D = 191;

		// Token: 0x04000427 RID: 1063
		public const int KEY_KP_E = 192;

		// Token: 0x04000428 RID: 1064
		public const int KEY_KP_F = 193;

		// Token: 0x04000429 RID: 1065
		public const int KEY_KP_XOR = 194;

		// Token: 0x0400042A RID: 1066
		public const int KEY_KP_POWER = 195;

		// Token: 0x0400042B RID: 1067
		public const int KEY_KP_PERCENT = 196;

		// Token: 0x0400042C RID: 1068
		public const int KEY_KP_LESS = 197;

		// Token: 0x0400042D RID: 1069
		public const int KEY_KP_GREATER = 198;

		// Token: 0x0400042E RID: 1070
		public const int KEY_KP_AMPERSAND = 199;

		// Token: 0x0400042F RID: 1071
		public const int KEY_KP_DBLAMPERSAND = 200;

		// Token: 0x04000430 RID: 1072
		public const int KEY_KP_VERTICALBAR = 201;

		// Token: 0x04000431 RID: 1073
		public const int KEY_KP_DBLVERTICALBAR = 202;

		// Token: 0x04000432 RID: 1074
		public const int KEY_KP_COLON = 203;

		// Token: 0x04000433 RID: 1075
		public const int KEY_KP_HASH = 204;

		// Token: 0x04000434 RID: 1076
		public const int KEY_KP_SPACE = 205;

		// Token: 0x04000435 RID: 1077
		public const int KEY_KP_AT = 206;

		// Token: 0x04000436 RID: 1078
		public const int KEY_KP_EXCLAM = 207;

		// Token: 0x04000437 RID: 1079
		public const int KEY_KP_MEMSTORE = 208;

		// Token: 0x04000438 RID: 1080
		public const int KEY_KP_MEMRECALL = 209;

		// Token: 0x04000439 RID: 1081
		public const int KEY_KP_MEMCLEAR = 210;

		// Token: 0x0400043A RID: 1082
		public const int KEY_KP_MEMADD = 211;

		// Token: 0x0400043B RID: 1083
		public const int KEY_KP_MEMSUBTRACT = 212;

		// Token: 0x0400043C RID: 1084
		public const int KEY_KP_MEMMULTIPLY = 213;

		// Token: 0x0400043D RID: 1085
		public const int KEY_KP_MEMDIVIDE = 214;

		// Token: 0x0400043E RID: 1086
		public const int KEY_KP_PLUSMINUS = 215;

		// Token: 0x0400043F RID: 1087
		public const int KEY_KP_CLEAR = 216;

		// Token: 0x04000440 RID: 1088
		public const int KEY_KP_CLEARENTRY = 217;

		// Token: 0x04000441 RID: 1089
		public const int KEY_KP_BINARY = 218;

		// Token: 0x04000442 RID: 1090
		public const int KEY_KP_OCTAL = 219;

		// Token: 0x04000443 RID: 1091
		public const int KEY_KP_DECIMAL = 220;

		// Token: 0x04000444 RID: 1092
		public const int KEY_KP_HEXADECIMAL = 221;

		// Token: 0x04000445 RID: 1093
		public const int KEY_LCTRL = 224;

		// Token: 0x04000446 RID: 1094
		public const int KEY_LSHIFT = 225;

		// Token: 0x04000447 RID: 1095
		public const int KEY_LALT = 226;

		// Token: 0x04000448 RID: 1096
		public const int KEY_LGUI = 227;

		// Token: 0x04000449 RID: 1097
		public const int KEY_RCTRL = 228;

		// Token: 0x0400044A RID: 1098
		public const int KEY_RSHIFT = 229;

		// Token: 0x0400044B RID: 1099
		public const int KEY_RALT = 230;

		// Token: 0x0400044C RID: 1100
		public const int KEY_RGUI = 231;

		// Token: 0x0400044D RID: 1101
		public const int KEY_MODE = 257;

		// Token: 0x0400044E RID: 1102
		public const int KEY_AUDIONEXT = 258;

		// Token: 0x0400044F RID: 1103
		public const int KEY_AUDIOPREV = 259;

		// Token: 0x04000450 RID: 1104
		public const int KEY_AUDIOSTOP = 260;

		// Token: 0x04000451 RID: 1105
		public const int KEY_AUDIOPLAY = 261;

		// Token: 0x04000452 RID: 1106
		public const int KEY_AUDIOMUTE = 262;

		// Token: 0x04000453 RID: 1107
		public const int KEY_MEDIASELECT = 263;

		// Token: 0x04000454 RID: 1108
		public const int KEY_WWW = 264;

		// Token: 0x04000455 RID: 1109
		public const int KEY_MAIL = 265;

		// Token: 0x04000456 RID: 1110
		public const int KEY_CALCULATOR = 266;

		// Token: 0x04000457 RID: 1111
		public const int KEY_COMPUTER = 267;

		// Token: 0x04000458 RID: 1112
		public const int KEY_AC_SEARCH = 268;

		// Token: 0x04000459 RID: 1113
		public const int KEY_AC_HOME = 269;

		// Token: 0x0400045A RID: 1114
		public const int KEY_AC_BACK = 270;

		// Token: 0x0400045B RID: 1115
		public const int KEY_AC_FORWARD = 271;

		// Token: 0x0400045C RID: 1116
		public const int KEY_AC_STOP = 272;

		// Token: 0x0400045D RID: 1117
		public const int KEY_AC_REFRESH = 273;

		// Token: 0x0400045E RID: 1118
		public const int KEY_AC_BOOKMARKS = 274;

		// Token: 0x0400045F RID: 1119
		public const int KEY_BRIGHTNESSDOWN = 275;

		// Token: 0x04000460 RID: 1120
		public const int KEY_BRIGHTNESSUP = 276;

		// Token: 0x04000461 RID: 1121
		public const int KEY_DISPLAYSWITCH = 277;

		// Token: 0x04000462 RID: 1122
		public const int KEY_KBDILLUMTOGGLE = 278;

		// Token: 0x04000463 RID: 1123
		public const int KEY_KBDILLUMDOWN = 279;

		// Token: 0x04000464 RID: 1124
		public const int KEY_KBDILLUMUP = 280;

		// Token: 0x04000465 RID: 1125
		public const int KEY_EJECT = 281;

		// Token: 0x04000466 RID: 1126
		public const int KEY_SLEEP = 282;

		// Token: 0x04000467 RID: 1127
		public const int KEY_APP1 = 283;

		// Token: 0x04000468 RID: 1128
		public const int KEY_APP2 = 284;

		// Token: 0x04000469 RID: 1129
		private readonly bool[] _keys;
	}
}
