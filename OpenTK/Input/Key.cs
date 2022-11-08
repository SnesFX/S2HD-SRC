using System;

namespace OpenTK.Input
{
	// Token: 0x02000515 RID: 1301
	public enum Key
	{
		// Token: 0x04004D08 RID: 19720
		Unknown,
		// Token: 0x04004D09 RID: 19721
		ShiftLeft,
		// Token: 0x04004D0A RID: 19722
		LShift = 1,
		// Token: 0x04004D0B RID: 19723
		ShiftRight,
		// Token: 0x04004D0C RID: 19724
		RShift = 2,
		// Token: 0x04004D0D RID: 19725
		ControlLeft,
		// Token: 0x04004D0E RID: 19726
		LControl = 3,
		// Token: 0x04004D0F RID: 19727
		ControlRight,
		// Token: 0x04004D10 RID: 19728
		RControl = 4,
		// Token: 0x04004D11 RID: 19729
		AltLeft,
		// Token: 0x04004D12 RID: 19730
		LAlt = 5,
		// Token: 0x04004D13 RID: 19731
		AltRight,
		// Token: 0x04004D14 RID: 19732
		RAlt = 6,
		// Token: 0x04004D15 RID: 19733
		WinLeft,
		// Token: 0x04004D16 RID: 19734
		LWin = 7,
		// Token: 0x04004D17 RID: 19735
		WinRight,
		// Token: 0x04004D18 RID: 19736
		RWin = 8,
		// Token: 0x04004D19 RID: 19737
		Menu,
		// Token: 0x04004D1A RID: 19738
		F1,
		// Token: 0x04004D1B RID: 19739
		F2,
		// Token: 0x04004D1C RID: 19740
		F3,
		// Token: 0x04004D1D RID: 19741
		F4,
		// Token: 0x04004D1E RID: 19742
		F5,
		// Token: 0x04004D1F RID: 19743
		F6,
		// Token: 0x04004D20 RID: 19744
		F7,
		// Token: 0x04004D21 RID: 19745
		F8,
		// Token: 0x04004D22 RID: 19746
		F9,
		// Token: 0x04004D23 RID: 19747
		F10,
		// Token: 0x04004D24 RID: 19748
		F11,
		// Token: 0x04004D25 RID: 19749
		F12,
		// Token: 0x04004D26 RID: 19750
		F13,
		// Token: 0x04004D27 RID: 19751
		F14,
		// Token: 0x04004D28 RID: 19752
		F15,
		// Token: 0x04004D29 RID: 19753
		F16,
		// Token: 0x04004D2A RID: 19754
		F17,
		// Token: 0x04004D2B RID: 19755
		F18,
		// Token: 0x04004D2C RID: 19756
		F19,
		// Token: 0x04004D2D RID: 19757
		F20,
		// Token: 0x04004D2E RID: 19758
		F21,
		// Token: 0x04004D2F RID: 19759
		F22,
		// Token: 0x04004D30 RID: 19760
		F23,
		// Token: 0x04004D31 RID: 19761
		F24,
		// Token: 0x04004D32 RID: 19762
		F25,
		// Token: 0x04004D33 RID: 19763
		F26,
		// Token: 0x04004D34 RID: 19764
		F27,
		// Token: 0x04004D35 RID: 19765
		F28,
		// Token: 0x04004D36 RID: 19766
		F29,
		// Token: 0x04004D37 RID: 19767
		F30,
		// Token: 0x04004D38 RID: 19768
		F31,
		// Token: 0x04004D39 RID: 19769
		F32,
		// Token: 0x04004D3A RID: 19770
		F33,
		// Token: 0x04004D3B RID: 19771
		F34,
		// Token: 0x04004D3C RID: 19772
		F35,
		// Token: 0x04004D3D RID: 19773
		Up,
		// Token: 0x04004D3E RID: 19774
		Down,
		// Token: 0x04004D3F RID: 19775
		Left,
		// Token: 0x04004D40 RID: 19776
		Right,
		// Token: 0x04004D41 RID: 19777
		Enter,
		// Token: 0x04004D42 RID: 19778
		Escape,
		// Token: 0x04004D43 RID: 19779
		Space,
		// Token: 0x04004D44 RID: 19780
		Tab,
		// Token: 0x04004D45 RID: 19781
		BackSpace,
		// Token: 0x04004D46 RID: 19782
		Back = 53,
		// Token: 0x04004D47 RID: 19783
		Insert,
		// Token: 0x04004D48 RID: 19784
		Delete,
		// Token: 0x04004D49 RID: 19785
		PageUp,
		// Token: 0x04004D4A RID: 19786
		PageDown,
		// Token: 0x04004D4B RID: 19787
		Home,
		// Token: 0x04004D4C RID: 19788
		End,
		// Token: 0x04004D4D RID: 19789
		CapsLock,
		// Token: 0x04004D4E RID: 19790
		ScrollLock,
		// Token: 0x04004D4F RID: 19791
		PrintScreen,
		// Token: 0x04004D50 RID: 19792
		Pause,
		// Token: 0x04004D51 RID: 19793
		NumLock,
		// Token: 0x04004D52 RID: 19794
		Clear,
		// Token: 0x04004D53 RID: 19795
		Sleep,
		// Token: 0x04004D54 RID: 19796
		Keypad0,
		// Token: 0x04004D55 RID: 19797
		Keypad1,
		// Token: 0x04004D56 RID: 19798
		Keypad2,
		// Token: 0x04004D57 RID: 19799
		Keypad3,
		// Token: 0x04004D58 RID: 19800
		Keypad4,
		// Token: 0x04004D59 RID: 19801
		Keypad5,
		// Token: 0x04004D5A RID: 19802
		Keypad6,
		// Token: 0x04004D5B RID: 19803
		Keypad7,
		// Token: 0x04004D5C RID: 19804
		Keypad8,
		// Token: 0x04004D5D RID: 19805
		Keypad9,
		// Token: 0x04004D5E RID: 19806
		KeypadDivide,
		// Token: 0x04004D5F RID: 19807
		KeypadMultiply,
		// Token: 0x04004D60 RID: 19808
		KeypadSubtract,
		// Token: 0x04004D61 RID: 19809
		KeypadMinus = 79,
		// Token: 0x04004D62 RID: 19810
		KeypadAdd,
		// Token: 0x04004D63 RID: 19811
		KeypadPlus = 80,
		// Token: 0x04004D64 RID: 19812
		KeypadDecimal,
		// Token: 0x04004D65 RID: 19813
		KeypadPeriod = 81,
		// Token: 0x04004D66 RID: 19814
		KeypadEnter,
		// Token: 0x04004D67 RID: 19815
		A,
		// Token: 0x04004D68 RID: 19816
		B,
		// Token: 0x04004D69 RID: 19817
		C,
		// Token: 0x04004D6A RID: 19818
		D,
		// Token: 0x04004D6B RID: 19819
		E,
		// Token: 0x04004D6C RID: 19820
		F,
		// Token: 0x04004D6D RID: 19821
		G,
		// Token: 0x04004D6E RID: 19822
		H,
		// Token: 0x04004D6F RID: 19823
		I,
		// Token: 0x04004D70 RID: 19824
		J,
		// Token: 0x04004D71 RID: 19825
		K,
		// Token: 0x04004D72 RID: 19826
		L,
		// Token: 0x04004D73 RID: 19827
		M,
		// Token: 0x04004D74 RID: 19828
		N,
		// Token: 0x04004D75 RID: 19829
		O,
		// Token: 0x04004D76 RID: 19830
		P,
		// Token: 0x04004D77 RID: 19831
		Q,
		// Token: 0x04004D78 RID: 19832
		R,
		// Token: 0x04004D79 RID: 19833
		S,
		// Token: 0x04004D7A RID: 19834
		T,
		// Token: 0x04004D7B RID: 19835
		U,
		// Token: 0x04004D7C RID: 19836
		V,
		// Token: 0x04004D7D RID: 19837
		W,
		// Token: 0x04004D7E RID: 19838
		X,
		// Token: 0x04004D7F RID: 19839
		Y,
		// Token: 0x04004D80 RID: 19840
		Z,
		// Token: 0x04004D81 RID: 19841
		Number0,
		// Token: 0x04004D82 RID: 19842
		Number1,
		// Token: 0x04004D83 RID: 19843
		Number2,
		// Token: 0x04004D84 RID: 19844
		Number3,
		// Token: 0x04004D85 RID: 19845
		Number4,
		// Token: 0x04004D86 RID: 19846
		Number5,
		// Token: 0x04004D87 RID: 19847
		Number6,
		// Token: 0x04004D88 RID: 19848
		Number7,
		// Token: 0x04004D89 RID: 19849
		Number8,
		// Token: 0x04004D8A RID: 19850
		Number9,
		// Token: 0x04004D8B RID: 19851
		Tilde,
		// Token: 0x04004D8C RID: 19852
		Grave = 119,
		// Token: 0x04004D8D RID: 19853
		Minus,
		// Token: 0x04004D8E RID: 19854
		Plus,
		// Token: 0x04004D8F RID: 19855
		BracketLeft,
		// Token: 0x04004D90 RID: 19856
		LBracket = 122,
		// Token: 0x04004D91 RID: 19857
		BracketRight,
		// Token: 0x04004D92 RID: 19858
		RBracket = 123,
		// Token: 0x04004D93 RID: 19859
		Semicolon,
		// Token: 0x04004D94 RID: 19860
		Quote,
		// Token: 0x04004D95 RID: 19861
		Comma,
		// Token: 0x04004D96 RID: 19862
		Period,
		// Token: 0x04004D97 RID: 19863
		Slash,
		// Token: 0x04004D98 RID: 19864
		BackSlash,
		// Token: 0x04004D99 RID: 19865
		NonUSBackSlash,
		// Token: 0x04004D9A RID: 19866
		LastKey
	}
}
