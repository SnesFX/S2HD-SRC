using System;

namespace OpenTK.Platform.Windows
{
	// Token: 0x02000083 RID: 131
	internal static class Constants
	{
		// Token: 0x040002BA RID: 698
		internal const int KEYBOARD_OVERRUN_MAKE_CODE = 255;

		// Token: 0x040002BB RID: 699
		internal const int WA_INACTIVE = 0;

		// Token: 0x040002BC RID: 700
		internal const int WA_ACTIVE = 1;

		// Token: 0x040002BD RID: 701
		internal const int WA_CLICKACTIVE = 2;

		// Token: 0x040002BE RID: 702
		internal const int WM_NULL = 0;

		// Token: 0x040002BF RID: 703
		internal const int WM_CREATE = 1;

		// Token: 0x040002C0 RID: 704
		internal const int WM_DESTROY = 2;

		// Token: 0x040002C1 RID: 705
		internal const int WM_MOVE = 3;

		// Token: 0x040002C2 RID: 706
		internal const int WM_SIZE = 5;

		// Token: 0x040002C3 RID: 707
		internal const int WM_ACTIVATE = 6;

		// Token: 0x040002C4 RID: 708
		internal const int WM_SETFOCUS = 7;

		// Token: 0x040002C5 RID: 709
		internal const int WM_KILLFOCUS = 8;

		// Token: 0x040002C6 RID: 710
		internal const int WM_ENABLE = 10;

		// Token: 0x040002C7 RID: 711
		internal const int WM_SETREDRAW = 11;

		// Token: 0x040002C8 RID: 712
		internal const int WM_SETTEXT = 12;

		// Token: 0x040002C9 RID: 713
		internal const int WM_GETTEXT = 13;

		// Token: 0x040002CA RID: 714
		internal const int WM_GETTEXTLENGTH = 14;

		// Token: 0x040002CB RID: 715
		internal const int WM_PAINT = 15;

		// Token: 0x040002CC RID: 716
		internal const int WM_CLOSE = 16;

		// Token: 0x040002CD RID: 717
		internal const int WM_QUERYENDSESSION = 17;

		// Token: 0x040002CE RID: 718
		internal const int WM_QUERYOPEN = 19;

		// Token: 0x040002CF RID: 719
		internal const int WM_ENDSESSION = 22;

		// Token: 0x040002D0 RID: 720
		internal const int WM_QUIT = 18;

		// Token: 0x040002D1 RID: 721
		internal const int WM_ERASEBKGND = 20;

		// Token: 0x040002D2 RID: 722
		internal const int WM_SYSCOLORCHANGE = 21;

		// Token: 0x040002D3 RID: 723
		internal const int WM_SHOWWINDOW = 24;

		// Token: 0x040002D4 RID: 724
		internal const int WM_WININICHANGE = 26;

		// Token: 0x040002D5 RID: 725
		internal const int WM_SETTINGCHANGE = 26;

		// Token: 0x040002D6 RID: 726
		internal const int WM_DEVMODECHANGE = 27;

		// Token: 0x040002D7 RID: 727
		internal const int WM_ACTIVATEAPP = 28;

		// Token: 0x040002D8 RID: 728
		internal const int WM_FONTCHANGE = 29;

		// Token: 0x040002D9 RID: 729
		internal const int WM_TIMECHANGE = 30;

		// Token: 0x040002DA RID: 730
		internal const int WM_CANCELMODE = 31;

		// Token: 0x040002DB RID: 731
		internal const int WM_SETCURSOR = 32;

		// Token: 0x040002DC RID: 732
		internal const int WM_MOUSEACTIVATE = 33;

		// Token: 0x040002DD RID: 733
		internal const int WM_CHILDACTIVATE = 34;

		// Token: 0x040002DE RID: 734
		internal const int WM_QUEUESYNC = 35;

		// Token: 0x040002DF RID: 735
		internal const int WM_GETMINMAXINFO = 36;

		// Token: 0x040002E0 RID: 736
		internal const int WM_WINDOWPOSCHANGING = 70;

		// Token: 0x040002E1 RID: 737
		internal const int WM_WINDOWPOSCHANGED = 71;

		// Token: 0x040002E2 RID: 738
		internal const int WM_INPUT = 255;

		// Token: 0x040002E3 RID: 739
		internal const int WM_KEYDOWN = 256;

		// Token: 0x040002E4 RID: 740
		internal const int WM_KEYUP = 257;

		// Token: 0x040002E5 RID: 741
		internal const int WM_SYSKEYDOWN = 260;

		// Token: 0x040002E6 RID: 742
		internal const int WM_SYSKEYUP = 261;

		// Token: 0x040002E7 RID: 743
		internal const int WM_COMMAND = 273;

		// Token: 0x040002E8 RID: 744
		internal const int WM_SYSCOMMAND = 274;

		// Token: 0x040002E9 RID: 745
		internal const int WM_ENTERIDLE = 289;

		// Token: 0x040002EA RID: 746
		internal const byte PFD_TYPE_RGBA = 0;

		// Token: 0x040002EB RID: 747
		internal const byte PFD_TYPE_COLORINDEX = 1;

		// Token: 0x040002EC RID: 748
		internal const byte PFD_MAIN_PLANE = 0;

		// Token: 0x040002ED RID: 749
		internal const byte PFD_OVERLAY_PLANE = 1;

		// Token: 0x040002EE RID: 750
		internal const byte PFD_UNDERLAY_PLANE = 255;

		// Token: 0x040002EF RID: 751
		internal const int DM_LOGPIXELS = 131072;

		// Token: 0x040002F0 RID: 752
		internal const int DM_BITSPERPEL = 262144;

		// Token: 0x040002F1 RID: 753
		internal const int DM_PELSWIDTH = 524288;

		// Token: 0x040002F2 RID: 754
		internal const int DM_PELSHEIGHT = 1048576;

		// Token: 0x040002F3 RID: 755
		internal const int DM_DISPLAYFLAGS = 2097152;

		// Token: 0x040002F4 RID: 756
		internal const int DM_DISPLAYFREQUENCY = 4194304;

		// Token: 0x040002F5 RID: 757
		internal const int DISP_CHANGE_SUCCESSFUL = 0;

		// Token: 0x040002F6 RID: 758
		internal const int DISP_CHANGE_RESTART = 1;

		// Token: 0x040002F7 RID: 759
		internal const int DISP_CHANGE_FAILED = -1;

		// Token: 0x040002F8 RID: 760
		internal const int ENUM_REGISTRY_SETTINGS = -2;

		// Token: 0x040002F9 RID: 761
		internal const int ENUM_CURRENT_SETTINGS = -1;

		// Token: 0x040002FA RID: 762
		internal const int ERROR_POINT_NOT_FOUND = 1171;

		// Token: 0x040002FB RID: 763
		internal const int GMMP_USE_DISPLAY_POINTS = 1;

		// Token: 0x040002FC RID: 764
		internal const int GMMP_USE_HIGH_RESOLUTION_POINTS = 2;

		// Token: 0x040002FD RID: 765
		internal static readonly IntPtr MESSAGE_ONLY = new IntPtr(-3);

		// Token: 0x040002FE RID: 766
		internal static readonly IntPtr HKEY_LOCAL_MACHINE = new IntPtr(-2147483646);
	}
}
