using System;

namespace OpenTK.Platform.X11
{
	// Token: 0x02000180 RID: 384
	internal enum CursorFontShape
	{
		// Token: 0x04000F88 RID: 3976
		XC_X_cursor,
		// Token: 0x04000F89 RID: 3977
		XC_arrow = 2,
		// Token: 0x04000F8A RID: 3978
		XC_based_arrow_down = 4,
		// Token: 0x04000F8B RID: 3979
		XC_based_arrow_up = 6,
		// Token: 0x04000F8C RID: 3980
		XC_boat = 8,
		// Token: 0x04000F8D RID: 3981
		XC_bogosity = 10,
		// Token: 0x04000F8E RID: 3982
		XC_bottom_left_corner = 12,
		// Token: 0x04000F8F RID: 3983
		XC_bottom_right_corner = 14,
		// Token: 0x04000F90 RID: 3984
		XC_bottom_side = 16,
		// Token: 0x04000F91 RID: 3985
		XC_bottom_tee = 18,
		// Token: 0x04000F92 RID: 3986
		XC_box_spiral = 20,
		// Token: 0x04000F93 RID: 3987
		XC_center_ptr = 22,
		// Token: 0x04000F94 RID: 3988
		XC_circle = 24,
		// Token: 0x04000F95 RID: 3989
		XC_clock = 26,
		// Token: 0x04000F96 RID: 3990
		XC_coffee_mug = 28,
		// Token: 0x04000F97 RID: 3991
		XC_cross = 30,
		// Token: 0x04000F98 RID: 3992
		XC_cross_reverse = 32,
		// Token: 0x04000F99 RID: 3993
		XC_crosshair = 34,
		// Token: 0x04000F9A RID: 3994
		XC_diamond_cross = 36,
		// Token: 0x04000F9B RID: 3995
		XC_dot = 38,
		// Token: 0x04000F9C RID: 3996
		XC_dotbox = 40,
		// Token: 0x04000F9D RID: 3997
		XC_double_arrow = 42,
		// Token: 0x04000F9E RID: 3998
		XC_draft_large = 44,
		// Token: 0x04000F9F RID: 3999
		XC_draft_small = 46,
		// Token: 0x04000FA0 RID: 4000
		XC_draped_box = 48,
		// Token: 0x04000FA1 RID: 4001
		XC_exchange = 50,
		// Token: 0x04000FA2 RID: 4002
		XC_fleur = 52,
		// Token: 0x04000FA3 RID: 4003
		XC_gobbler = 54,
		// Token: 0x04000FA4 RID: 4004
		XC_gumby = 56,
		// Token: 0x04000FA5 RID: 4005
		XC_hand1 = 58,
		// Token: 0x04000FA6 RID: 4006
		XC_hand2 = 60,
		// Token: 0x04000FA7 RID: 4007
		XC_heart = 62,
		// Token: 0x04000FA8 RID: 4008
		XC_icon = 64,
		// Token: 0x04000FA9 RID: 4009
		XC_iron_cross = 66,
		// Token: 0x04000FAA RID: 4010
		XC_left_ptr = 68,
		// Token: 0x04000FAB RID: 4011
		XC_left_side = 70,
		// Token: 0x04000FAC RID: 4012
		XC_left_tee = 72,
		// Token: 0x04000FAD RID: 4013
		XC_left_button = 74,
		// Token: 0x04000FAE RID: 4014
		XC_ll_angle = 76,
		// Token: 0x04000FAF RID: 4015
		XC_lr_angle = 78,
		// Token: 0x04000FB0 RID: 4016
		XC_man = 80,
		// Token: 0x04000FB1 RID: 4017
		XC_middlebutton = 82,
		// Token: 0x04000FB2 RID: 4018
		XC_mouse = 84,
		// Token: 0x04000FB3 RID: 4019
		XC_pencil = 86,
		// Token: 0x04000FB4 RID: 4020
		XC_pirate = 88,
		// Token: 0x04000FB5 RID: 4021
		XC_plus = 90,
		// Token: 0x04000FB6 RID: 4022
		XC_question_arrow = 92,
		// Token: 0x04000FB7 RID: 4023
		XC_right_ptr = 94,
		// Token: 0x04000FB8 RID: 4024
		XC_right_side = 96,
		// Token: 0x04000FB9 RID: 4025
		XC_right_tee = 98,
		// Token: 0x04000FBA RID: 4026
		XC_rightbutton = 100,
		// Token: 0x04000FBB RID: 4027
		XC_rtl_logo = 102,
		// Token: 0x04000FBC RID: 4028
		XC_sailboat = 104,
		// Token: 0x04000FBD RID: 4029
		XC_sb_down_arrow = 106,
		// Token: 0x04000FBE RID: 4030
		XC_sb_h_double_arrow = 108,
		// Token: 0x04000FBF RID: 4031
		XC_sb_left_arrow = 110,
		// Token: 0x04000FC0 RID: 4032
		XC_sb_right_arrow = 112,
		// Token: 0x04000FC1 RID: 4033
		XC_sb_up_arrow = 114,
		// Token: 0x04000FC2 RID: 4034
		XC_sb_v_double_arrow = 116,
		// Token: 0x04000FC3 RID: 4035
		XC_sb_shuttle = 118,
		// Token: 0x04000FC4 RID: 4036
		XC_sizing = 120,
		// Token: 0x04000FC5 RID: 4037
		XC_spider = 122,
		// Token: 0x04000FC6 RID: 4038
		XC_spraycan = 124,
		// Token: 0x04000FC7 RID: 4039
		XC_star = 126,
		// Token: 0x04000FC8 RID: 4040
		XC_target = 128,
		// Token: 0x04000FC9 RID: 4041
		XC_tcross = 130,
		// Token: 0x04000FCA RID: 4042
		XC_top_left_arrow = 132,
		// Token: 0x04000FCB RID: 4043
		XC_top_left_corner = 134,
		// Token: 0x04000FCC RID: 4044
		XC_top_right_corner = 136,
		// Token: 0x04000FCD RID: 4045
		XC_top_side = 138,
		// Token: 0x04000FCE RID: 4046
		XC_top_tee = 140,
		// Token: 0x04000FCF RID: 4047
		XC_trek = 142,
		// Token: 0x04000FD0 RID: 4048
		XC_ul_angle = 144,
		// Token: 0x04000FD1 RID: 4049
		XC_umbrella = 146,
		// Token: 0x04000FD2 RID: 4050
		XC_ur_angle = 148,
		// Token: 0x04000FD3 RID: 4051
		XC_watch = 150,
		// Token: 0x04000FD4 RID: 4052
		XC_xterm = 152,
		// Token: 0x04000FD5 RID: 4053
		XC_num_glyphs = 154
	}
}
