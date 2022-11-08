using System;

namespace OpenTK.Platform.X11
{
	// Token: 0x02000128 RID: 296
	[CLSCompliant(false)]
	internal enum XKey
	{
		// Token: 0x04000A6D RID: 2669
		BackSpace = 65288,
		// Token: 0x04000A6E RID: 2670
		Tab,
		// Token: 0x04000A6F RID: 2671
		Linefeed,
		// Token: 0x04000A70 RID: 2672
		Clear,
		// Token: 0x04000A71 RID: 2673
		Return = 65293,
		// Token: 0x04000A72 RID: 2674
		Pause = 65299,
		// Token: 0x04000A73 RID: 2675
		Scroll_Lock,
		// Token: 0x04000A74 RID: 2676
		Sys_Req,
		// Token: 0x04000A75 RID: 2677
		Escape = 65307,
		// Token: 0x04000A76 RID: 2678
		Delete = 65535,
		// Token: 0x04000A77 RID: 2679
		Multi_key = 65312,
		// Token: 0x04000A78 RID: 2680
		Codeinput = 65335,
		// Token: 0x04000A79 RID: 2681
		SingleCandidate = 65340,
		// Token: 0x04000A7A RID: 2682
		MultipleCandidate,
		// Token: 0x04000A7B RID: 2683
		PreviousCandidate,
		// Token: 0x04000A7C RID: 2684
		Kanji = 65313,
		// Token: 0x04000A7D RID: 2685
		Muhenkan,
		// Token: 0x04000A7E RID: 2686
		Henkan_Mode,
		// Token: 0x04000A7F RID: 2687
		Henkan = 65315,
		// Token: 0x04000A80 RID: 2688
		Romaji,
		// Token: 0x04000A81 RID: 2689
		Hiragana,
		// Token: 0x04000A82 RID: 2690
		Katakana,
		// Token: 0x04000A83 RID: 2691
		Hiragana_Katakana,
		// Token: 0x04000A84 RID: 2692
		Zenkaku,
		// Token: 0x04000A85 RID: 2693
		Hankaku,
		// Token: 0x04000A86 RID: 2694
		Zenkaku_Hankaku,
		// Token: 0x04000A87 RID: 2695
		Touroku,
		// Token: 0x04000A88 RID: 2696
		Massyo,
		// Token: 0x04000A89 RID: 2697
		Kana_Lock,
		// Token: 0x04000A8A RID: 2698
		Kana_Shift,
		// Token: 0x04000A8B RID: 2699
		Eisu_Shift,
		// Token: 0x04000A8C RID: 2700
		Eisu_toggle,
		// Token: 0x04000A8D RID: 2701
		Kanji_Bangou = 65335,
		// Token: 0x04000A8E RID: 2702
		Zen_Koho = 65341,
		// Token: 0x04000A8F RID: 2703
		Mae_Koho,
		// Token: 0x04000A90 RID: 2704
		Home = 65360,
		// Token: 0x04000A91 RID: 2705
		Left,
		// Token: 0x04000A92 RID: 2706
		Up,
		// Token: 0x04000A93 RID: 2707
		Right,
		// Token: 0x04000A94 RID: 2708
		Down,
		// Token: 0x04000A95 RID: 2709
		Prior,
		// Token: 0x04000A96 RID: 2710
		Page_Up = 65365,
		// Token: 0x04000A97 RID: 2711
		Next,
		// Token: 0x04000A98 RID: 2712
		Page_Down = 65366,
		// Token: 0x04000A99 RID: 2713
		End,
		// Token: 0x04000A9A RID: 2714
		Begin,
		// Token: 0x04000A9B RID: 2715
		Select = 65376,
		// Token: 0x04000A9C RID: 2716
		Print,
		// Token: 0x04000A9D RID: 2717
		Execute,
		// Token: 0x04000A9E RID: 2718
		Insert,
		// Token: 0x04000A9F RID: 2719
		Undo = 65381,
		// Token: 0x04000AA0 RID: 2720
		Redo,
		// Token: 0x04000AA1 RID: 2721
		Menu,
		// Token: 0x04000AA2 RID: 2722
		Find,
		// Token: 0x04000AA3 RID: 2723
		Cancel,
		// Token: 0x04000AA4 RID: 2724
		Help,
		// Token: 0x04000AA5 RID: 2725
		Break,
		// Token: 0x04000AA6 RID: 2726
		Mode_switch = 65406,
		// Token: 0x04000AA7 RID: 2727
		script_switch = 65406,
		// Token: 0x04000AA8 RID: 2728
		Num_Lock,
		// Token: 0x04000AA9 RID: 2729
		KP_Space,
		// Token: 0x04000AAA RID: 2730
		KP_Tab = 65417,
		// Token: 0x04000AAB RID: 2731
		KP_Enter = 65421,
		// Token: 0x04000AAC RID: 2732
		KP_F1 = 65425,
		// Token: 0x04000AAD RID: 2733
		KP_F2,
		// Token: 0x04000AAE RID: 2734
		KP_F3,
		// Token: 0x04000AAF RID: 2735
		KP_F4,
		// Token: 0x04000AB0 RID: 2736
		KP_Home,
		// Token: 0x04000AB1 RID: 2737
		KP_Left,
		// Token: 0x04000AB2 RID: 2738
		KP_Up,
		// Token: 0x04000AB3 RID: 2739
		KP_Right,
		// Token: 0x04000AB4 RID: 2740
		KP_Down,
		// Token: 0x04000AB5 RID: 2741
		KP_Prior,
		// Token: 0x04000AB6 RID: 2742
		KP_Page_Up = 65434,
		// Token: 0x04000AB7 RID: 2743
		KP_Next,
		// Token: 0x04000AB8 RID: 2744
		KP_Page_Down = 65435,
		// Token: 0x04000AB9 RID: 2745
		KP_End,
		// Token: 0x04000ABA RID: 2746
		KP_Begin,
		// Token: 0x04000ABB RID: 2747
		KP_Insert,
		// Token: 0x04000ABC RID: 2748
		KP_Delete,
		// Token: 0x04000ABD RID: 2749
		KP_Equal = 65469,
		// Token: 0x04000ABE RID: 2750
		KP_Multiply = 65450,
		// Token: 0x04000ABF RID: 2751
		KP_Add,
		// Token: 0x04000AC0 RID: 2752
		KP_Separator,
		// Token: 0x04000AC1 RID: 2753
		KP_Subtract,
		// Token: 0x04000AC2 RID: 2754
		KP_Decimal,
		// Token: 0x04000AC3 RID: 2755
		KP_Divide,
		// Token: 0x04000AC4 RID: 2756
		KP_0,
		// Token: 0x04000AC5 RID: 2757
		KP_1,
		// Token: 0x04000AC6 RID: 2758
		KP_2,
		// Token: 0x04000AC7 RID: 2759
		KP_3,
		// Token: 0x04000AC8 RID: 2760
		KP_4,
		// Token: 0x04000AC9 RID: 2761
		KP_5,
		// Token: 0x04000ACA RID: 2762
		KP_6,
		// Token: 0x04000ACB RID: 2763
		KP_7,
		// Token: 0x04000ACC RID: 2764
		KP_8,
		// Token: 0x04000ACD RID: 2765
		KP_9,
		// Token: 0x04000ACE RID: 2766
		F1 = 65470,
		// Token: 0x04000ACF RID: 2767
		F2,
		// Token: 0x04000AD0 RID: 2768
		F3,
		// Token: 0x04000AD1 RID: 2769
		F4,
		// Token: 0x04000AD2 RID: 2770
		F5,
		// Token: 0x04000AD3 RID: 2771
		F6,
		// Token: 0x04000AD4 RID: 2772
		F7,
		// Token: 0x04000AD5 RID: 2773
		F8,
		// Token: 0x04000AD6 RID: 2774
		F9,
		// Token: 0x04000AD7 RID: 2775
		F10,
		// Token: 0x04000AD8 RID: 2776
		F11,
		// Token: 0x04000AD9 RID: 2777
		L1 = 65480,
		// Token: 0x04000ADA RID: 2778
		F12,
		// Token: 0x04000ADB RID: 2779
		L2 = 65481,
		// Token: 0x04000ADC RID: 2780
		F13,
		// Token: 0x04000ADD RID: 2781
		L3 = 65482,
		// Token: 0x04000ADE RID: 2782
		F14,
		// Token: 0x04000ADF RID: 2783
		L4 = 65483,
		// Token: 0x04000AE0 RID: 2784
		F15,
		// Token: 0x04000AE1 RID: 2785
		L5 = 65484,
		// Token: 0x04000AE2 RID: 2786
		F16,
		// Token: 0x04000AE3 RID: 2787
		L6 = 65485,
		// Token: 0x04000AE4 RID: 2788
		F17,
		// Token: 0x04000AE5 RID: 2789
		L7 = 65486,
		// Token: 0x04000AE6 RID: 2790
		F18,
		// Token: 0x04000AE7 RID: 2791
		L8 = 65487,
		// Token: 0x04000AE8 RID: 2792
		F19,
		// Token: 0x04000AE9 RID: 2793
		L9 = 65488,
		// Token: 0x04000AEA RID: 2794
		F20,
		// Token: 0x04000AEB RID: 2795
		L10 = 65489,
		// Token: 0x04000AEC RID: 2796
		F21,
		// Token: 0x04000AED RID: 2797
		R1 = 65490,
		// Token: 0x04000AEE RID: 2798
		F22,
		// Token: 0x04000AEF RID: 2799
		R2 = 65491,
		// Token: 0x04000AF0 RID: 2800
		F23,
		// Token: 0x04000AF1 RID: 2801
		R3 = 65492,
		// Token: 0x04000AF2 RID: 2802
		F24,
		// Token: 0x04000AF3 RID: 2803
		R4 = 65493,
		// Token: 0x04000AF4 RID: 2804
		F25,
		// Token: 0x04000AF5 RID: 2805
		R5 = 65494,
		// Token: 0x04000AF6 RID: 2806
		F26,
		// Token: 0x04000AF7 RID: 2807
		R6 = 65495,
		// Token: 0x04000AF8 RID: 2808
		F27,
		// Token: 0x04000AF9 RID: 2809
		R7 = 65496,
		// Token: 0x04000AFA RID: 2810
		F28,
		// Token: 0x04000AFB RID: 2811
		R8 = 65497,
		// Token: 0x04000AFC RID: 2812
		F29,
		// Token: 0x04000AFD RID: 2813
		R9 = 65498,
		// Token: 0x04000AFE RID: 2814
		F30,
		// Token: 0x04000AFF RID: 2815
		R10 = 65499,
		// Token: 0x04000B00 RID: 2816
		F31,
		// Token: 0x04000B01 RID: 2817
		R11 = 65500,
		// Token: 0x04000B02 RID: 2818
		F32,
		// Token: 0x04000B03 RID: 2819
		R12 = 65501,
		// Token: 0x04000B04 RID: 2820
		F33,
		// Token: 0x04000B05 RID: 2821
		R13 = 65502,
		// Token: 0x04000B06 RID: 2822
		F34,
		// Token: 0x04000B07 RID: 2823
		R14 = 65503,
		// Token: 0x04000B08 RID: 2824
		F35,
		// Token: 0x04000B09 RID: 2825
		R15 = 65504,
		// Token: 0x04000B0A RID: 2826
		Shift_L,
		// Token: 0x04000B0B RID: 2827
		Shift_R,
		// Token: 0x04000B0C RID: 2828
		Control_L,
		// Token: 0x04000B0D RID: 2829
		Control_R,
		// Token: 0x04000B0E RID: 2830
		Caps_Lock,
		// Token: 0x04000B0F RID: 2831
		Shift_Lock,
		// Token: 0x04000B10 RID: 2832
		Meta_L,
		// Token: 0x04000B11 RID: 2833
		Meta_R,
		// Token: 0x04000B12 RID: 2834
		Alt_L,
		// Token: 0x04000B13 RID: 2835
		Alt_R,
		// Token: 0x04000B14 RID: 2836
		Super_L,
		// Token: 0x04000B15 RID: 2837
		Super_R,
		// Token: 0x04000B16 RID: 2838
		Hyper_L,
		// Token: 0x04000B17 RID: 2839
		Hyper_R,
		// Token: 0x04000B18 RID: 2840
		ISO_Level3_Shift = 65027,
		// Token: 0x04000B19 RID: 2841
		space = 32,
		// Token: 0x04000B1A RID: 2842
		exclam,
		// Token: 0x04000B1B RID: 2843
		quotedbl,
		// Token: 0x04000B1C RID: 2844
		numbersign,
		// Token: 0x04000B1D RID: 2845
		dollar,
		// Token: 0x04000B1E RID: 2846
		percent,
		// Token: 0x04000B1F RID: 2847
		ampersand,
		// Token: 0x04000B20 RID: 2848
		apostrophe,
		// Token: 0x04000B21 RID: 2849
		quoteright = 39,
		// Token: 0x04000B22 RID: 2850
		parenleft,
		// Token: 0x04000B23 RID: 2851
		parenright,
		// Token: 0x04000B24 RID: 2852
		asterisk,
		// Token: 0x04000B25 RID: 2853
		plus,
		// Token: 0x04000B26 RID: 2854
		comma,
		// Token: 0x04000B27 RID: 2855
		minus,
		// Token: 0x04000B28 RID: 2856
		period,
		// Token: 0x04000B29 RID: 2857
		slash,
		// Token: 0x04000B2A RID: 2858
		Number0,
		// Token: 0x04000B2B RID: 2859
		Number1,
		// Token: 0x04000B2C RID: 2860
		Number2,
		// Token: 0x04000B2D RID: 2861
		Number3,
		// Token: 0x04000B2E RID: 2862
		Number4,
		// Token: 0x04000B2F RID: 2863
		Number5,
		// Token: 0x04000B30 RID: 2864
		Number6,
		// Token: 0x04000B31 RID: 2865
		Number7,
		// Token: 0x04000B32 RID: 2866
		Number8,
		// Token: 0x04000B33 RID: 2867
		Number9,
		// Token: 0x04000B34 RID: 2868
		colon,
		// Token: 0x04000B35 RID: 2869
		semicolon,
		// Token: 0x04000B36 RID: 2870
		less,
		// Token: 0x04000B37 RID: 2871
		equal,
		// Token: 0x04000B38 RID: 2872
		greater,
		// Token: 0x04000B39 RID: 2873
		question,
		// Token: 0x04000B3A RID: 2874
		at,
		// Token: 0x04000B3B RID: 2875
		A,
		// Token: 0x04000B3C RID: 2876
		B,
		// Token: 0x04000B3D RID: 2877
		C,
		// Token: 0x04000B3E RID: 2878
		D,
		// Token: 0x04000B3F RID: 2879
		E,
		// Token: 0x04000B40 RID: 2880
		F,
		// Token: 0x04000B41 RID: 2881
		G,
		// Token: 0x04000B42 RID: 2882
		H,
		// Token: 0x04000B43 RID: 2883
		I,
		// Token: 0x04000B44 RID: 2884
		J,
		// Token: 0x04000B45 RID: 2885
		K,
		// Token: 0x04000B46 RID: 2886
		L,
		// Token: 0x04000B47 RID: 2887
		M,
		// Token: 0x04000B48 RID: 2888
		N,
		// Token: 0x04000B49 RID: 2889
		O,
		// Token: 0x04000B4A RID: 2890
		P,
		// Token: 0x04000B4B RID: 2891
		Q,
		// Token: 0x04000B4C RID: 2892
		R,
		// Token: 0x04000B4D RID: 2893
		S,
		// Token: 0x04000B4E RID: 2894
		T,
		// Token: 0x04000B4F RID: 2895
		U,
		// Token: 0x04000B50 RID: 2896
		V,
		// Token: 0x04000B51 RID: 2897
		W,
		// Token: 0x04000B52 RID: 2898
		X,
		// Token: 0x04000B53 RID: 2899
		Y,
		// Token: 0x04000B54 RID: 2900
		Z,
		// Token: 0x04000B55 RID: 2901
		bracketleft,
		// Token: 0x04000B56 RID: 2902
		backslash,
		// Token: 0x04000B57 RID: 2903
		bracketright,
		// Token: 0x04000B58 RID: 2904
		asciicircum,
		// Token: 0x04000B59 RID: 2905
		underscore,
		// Token: 0x04000B5A RID: 2906
		grave,
		// Token: 0x04000B5B RID: 2907
		quoteleft = 96,
		// Token: 0x04000B5C RID: 2908
		a,
		// Token: 0x04000B5D RID: 2909
		b,
		// Token: 0x04000B5E RID: 2910
		c,
		// Token: 0x04000B5F RID: 2911
		d,
		// Token: 0x04000B60 RID: 2912
		e,
		// Token: 0x04000B61 RID: 2913
		f,
		// Token: 0x04000B62 RID: 2914
		g,
		// Token: 0x04000B63 RID: 2915
		h,
		// Token: 0x04000B64 RID: 2916
		i,
		// Token: 0x04000B65 RID: 2917
		j,
		// Token: 0x04000B66 RID: 2918
		k,
		// Token: 0x04000B67 RID: 2919
		l,
		// Token: 0x04000B68 RID: 2920
		m,
		// Token: 0x04000B69 RID: 2921
		n,
		// Token: 0x04000B6A RID: 2922
		o,
		// Token: 0x04000B6B RID: 2923
		p,
		// Token: 0x04000B6C RID: 2924
		q,
		// Token: 0x04000B6D RID: 2925
		r,
		// Token: 0x04000B6E RID: 2926
		s,
		// Token: 0x04000B6F RID: 2927
		t,
		// Token: 0x04000B70 RID: 2928
		u,
		// Token: 0x04000B71 RID: 2929
		v,
		// Token: 0x04000B72 RID: 2930
		w,
		// Token: 0x04000B73 RID: 2931
		x,
		// Token: 0x04000B74 RID: 2932
		y,
		// Token: 0x04000B75 RID: 2933
		z,
		// Token: 0x04000B76 RID: 2934
		braceleft,
		// Token: 0x04000B77 RID: 2935
		bar,
		// Token: 0x04000B78 RID: 2936
		braceright,
		// Token: 0x04000B79 RID: 2937
		asciitilde,
		// Token: 0x04000B7A RID: 2938
		XF86AudioMute = 269025042,
		// Token: 0x04000B7B RID: 2939
		XF86AudioLowerVolume = 269025041,
		// Token: 0x04000B7C RID: 2940
		XF86AudioRaiseVolume = 269025043,
		// Token: 0x04000B7D RID: 2941
		XF86PowerOff = 269025066,
		// Token: 0x04000B7E RID: 2942
		XF86Suspend = 269025191,
		// Token: 0x04000B7F RID: 2943
		XF86Copy = 269025111,
		// Token: 0x04000B80 RID: 2944
		XF86Paste = 269025133,
		// Token: 0x04000B81 RID: 2945
		XF86Cut = 269025112,
		// Token: 0x04000B82 RID: 2946
		XF86MenuKB = 269025125,
		// Token: 0x04000B83 RID: 2947
		XF86Calculator = 269025053,
		// Token: 0x04000B84 RID: 2948
		XF86Sleep = 269025071,
		// Token: 0x04000B85 RID: 2949
		XF86WakeUp = 269025067,
		// Token: 0x04000B86 RID: 2950
		XF86Explorer = 269025117,
		// Token: 0x04000B87 RID: 2951
		XF86Send = 269025147,
		// Token: 0x04000B88 RID: 2952
		XF86Xfer = 269025162,
		// Token: 0x04000B89 RID: 2953
		XF86Launch1 = 269025089,
		// Token: 0x04000B8A RID: 2954
		XF86Launch2,
		// Token: 0x04000B8B RID: 2955
		XF86Launch3,
		// Token: 0x04000B8C RID: 2956
		XF86Launch4,
		// Token: 0x04000B8D RID: 2957
		XF86Launch5,
		// Token: 0x04000B8E RID: 2958
		XF86LaunchA = 269025098,
		// Token: 0x04000B8F RID: 2959
		XF86LaunchB,
		// Token: 0x04000B90 RID: 2960
		XF86WWW = 269025070,
		// Token: 0x04000B91 RID: 2961
		XF86DOS = 269025114,
		// Token: 0x04000B92 RID: 2962
		XF86ScreenSaver = 269025069,
		// Token: 0x04000B93 RID: 2963
		XF86RotateWindows = 269025140,
		// Token: 0x04000B94 RID: 2964
		XF86Mail = 269025049,
		// Token: 0x04000B95 RID: 2965
		XF86Favorites = 269025072,
		// Token: 0x04000B96 RID: 2966
		XF86MyComputer = 269025075,
		// Token: 0x04000B97 RID: 2967
		XF86Back = 269025062,
		// Token: 0x04000B98 RID: 2968
		XF86Forward,
		// Token: 0x04000B99 RID: 2969
		XF86Eject = 269025068,
		// Token: 0x04000B9A RID: 2970
		XF86AudioPlay = 269025044,
		// Token: 0x04000B9B RID: 2971
		XF86AudioStop,
		// Token: 0x04000B9C RID: 2972
		XF86AudioPrev,
		// Token: 0x04000B9D RID: 2973
		XF86AudioNext,
		// Token: 0x04000B9E RID: 2974
		XF86AudioRecord = 269025052,
		// Token: 0x04000B9F RID: 2975
		XF86AudioPause = 269025073,
		// Token: 0x04000BA0 RID: 2976
		XF86AudioRewind = 269025086,
		// Token: 0x04000BA1 RID: 2977
		XF86AudioForward = 269025175,
		// Token: 0x04000BA2 RID: 2978
		XF86Phone = 269025134,
		// Token: 0x04000BA3 RID: 2979
		XF86Tools = 269025153,
		// Token: 0x04000BA4 RID: 2980
		XF86HomePage = 269025048,
		// Token: 0x04000BA5 RID: 2981
		XF86Close = 269025110,
		// Token: 0x04000BA6 RID: 2982
		XF86Reload = 269025139,
		// Token: 0x04000BA7 RID: 2983
		XF86ScrollUp = 269025144,
		// Token: 0x04000BA8 RID: 2984
		XF86ScrollDown,
		// Token: 0x04000BA9 RID: 2985
		XF86New = 269025128,
		// Token: 0x04000BAA RID: 2986
		XF86TouchpadToggle = 269025193,
		// Token: 0x04000BAB RID: 2987
		XF86WebCam = 269025167,
		// Token: 0x04000BAC RID: 2988
		XF86Search = 269025051,
		// Token: 0x04000BAD RID: 2989
		XF86Finance = 269025084,
		// Token: 0x04000BAE RID: 2990
		XF86Shop = 269025078,
		// Token: 0x04000BAF RID: 2991
		XF86MonBrightnessDown = 269025027,
		// Token: 0x04000BB0 RID: 2992
		XF86MonBrightnessUp = 269025026,
		// Token: 0x04000BB1 RID: 2993
		XF86AudioMedia = 269025074,
		// Token: 0x04000BB2 RID: 2994
		XF86Display = 269025113,
		// Token: 0x04000BB3 RID: 2995
		XF86KbdLightOnOff = 269025028,
		// Token: 0x04000BB4 RID: 2996
		XF86KbdBrightnessDown = 269025030,
		// Token: 0x04000BB5 RID: 2997
		XF86KbdBrightnessUp = 269025029,
		// Token: 0x04000BB6 RID: 2998
		XF86Reply = 269025138,
		// Token: 0x04000BB7 RID: 2999
		XF86MailForward = 269025168,
		// Token: 0x04000BB8 RID: 3000
		XF86Save = 269025143,
		// Token: 0x04000BB9 RID: 3001
		XF86Documents = 269025115,
		// Token: 0x04000BBA RID: 3002
		XF86Battery = 269025171,
		// Token: 0x04000BBB RID: 3003
		XF86Bluetooth,
		// Token: 0x04000BBC RID: 3004
		XF86WLAN,
		// Token: 0x04000BBD RID: 3005
		SunProps = 268828528,
		// Token: 0x04000BBE RID: 3006
		SunOpen = 268828531
	}
}
