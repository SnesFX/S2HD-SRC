using System;

namespace OpenTK.Platform.X11
{
	// Token: 0x02000B57 RID: 2903
	internal struct XkbNames
	{
		// Token: 0x0400B773 RID: 46963
		internal IntPtr keycodes;

		// Token: 0x0400B774 RID: 46964
		internal IntPtr geometry;

		// Token: 0x0400B775 RID: 46965
		internal IntPtr symbols;

		// Token: 0x0400B776 RID: 46966
		internal IntPtr types;

		// Token: 0x0400B777 RID: 46967
		internal IntPtr compat;

		// Token: 0x0400B778 RID: 46968
		internal XkbNames.VMods vmods;

		// Token: 0x0400B779 RID: 46969
		internal XkbNames.Indicators indicators;

		// Token: 0x0400B77A RID: 46970
		internal XkbNames.Groups groups;

		// Token: 0x0400B77B RID: 46971
		internal unsafe XkbKeyName* keys;

		// Token: 0x0400B77C RID: 46972
		internal unsafe XkbKeyAlias* key_aliases;

		// Token: 0x0400B77D RID: 46973
		internal unsafe IntPtr* radio_groups;

		// Token: 0x0400B77E RID: 46974
		internal IntPtr phys_symbols;

		// Token: 0x0400B77F RID: 46975
		internal byte num_keys;

		// Token: 0x0400B780 RID: 46976
		internal byte num_key_aliases;

		// Token: 0x0400B781 RID: 46977
		internal byte num_rg;

		// Token: 0x02000B58 RID: 2904
		internal struct Groups
		{
			// Token: 0x170004C4 RID: 1220
			internal unsafe IntPtr this[int i]
			{
				get
				{
					if (i < 0 || i > 3)
					{
						throw new IndexOutOfRangeException();
					}
					fixed (IntPtr* ptr = &this.groups0)
					{
						return ptr[(IntPtr)i * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
					}
				}
			}

			// Token: 0x0400B782 RID: 46978
			private IntPtr groups0;

			// Token: 0x0400B783 RID: 46979
			private IntPtr groups1;

			// Token: 0x0400B784 RID: 46980
			private IntPtr groups2;

			// Token: 0x0400B785 RID: 46981
			private IntPtr groups3;
		}

		// Token: 0x02000B59 RID: 2905
		internal struct Indicators
		{
			// Token: 0x170004C5 RID: 1221
			internal unsafe IntPtr this[int i]
			{
				get
				{
					if (i < 0 || i > 31)
					{
						throw new IndexOutOfRangeException();
					}
					fixed (IntPtr* ptr = &this.indicators0)
					{
						return ptr[(IntPtr)i * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
					}
				}
			}

			// Token: 0x0400B786 RID: 46982
			private IntPtr indicators0;

			// Token: 0x0400B787 RID: 46983
			private IntPtr indicators1;

			// Token: 0x0400B788 RID: 46984
			private IntPtr indicators2;

			// Token: 0x0400B789 RID: 46985
			private IntPtr indicators3;

			// Token: 0x0400B78A RID: 46986
			private IntPtr indicators4;

			// Token: 0x0400B78B RID: 46987
			private IntPtr indicators5;

			// Token: 0x0400B78C RID: 46988
			private IntPtr indicators6;

			// Token: 0x0400B78D RID: 46989
			private IntPtr indicators7;

			// Token: 0x0400B78E RID: 46990
			private IntPtr indicators8;

			// Token: 0x0400B78F RID: 46991
			private IntPtr indicators9;

			// Token: 0x0400B790 RID: 46992
			private IntPtr indicators10;

			// Token: 0x0400B791 RID: 46993
			private IntPtr indicators11;

			// Token: 0x0400B792 RID: 46994
			private IntPtr indicators12;

			// Token: 0x0400B793 RID: 46995
			private IntPtr indicators13;

			// Token: 0x0400B794 RID: 46996
			private IntPtr indicators14;

			// Token: 0x0400B795 RID: 46997
			private IntPtr indicators15;

			// Token: 0x0400B796 RID: 46998
			private IntPtr indicators16;

			// Token: 0x0400B797 RID: 46999
			private IntPtr indicators17;

			// Token: 0x0400B798 RID: 47000
			private IntPtr indicators18;

			// Token: 0x0400B799 RID: 47001
			private IntPtr indicators19;

			// Token: 0x0400B79A RID: 47002
			private IntPtr indicators20;

			// Token: 0x0400B79B RID: 47003
			private IntPtr indicators21;

			// Token: 0x0400B79C RID: 47004
			private IntPtr indicators22;

			// Token: 0x0400B79D RID: 47005
			private IntPtr indicators23;

			// Token: 0x0400B79E RID: 47006
			private IntPtr indicators24;

			// Token: 0x0400B79F RID: 47007
			private IntPtr indicators25;

			// Token: 0x0400B7A0 RID: 47008
			private IntPtr indicators26;

			// Token: 0x0400B7A1 RID: 47009
			private IntPtr indicators27;

			// Token: 0x0400B7A2 RID: 47010
			private IntPtr indicators28;

			// Token: 0x0400B7A3 RID: 47011
			private IntPtr indicators29;

			// Token: 0x0400B7A4 RID: 47012
			private IntPtr indicators30;

			// Token: 0x0400B7A5 RID: 47013
			private IntPtr indicators31;
		}

		// Token: 0x02000B5A RID: 2906
		internal struct VMods
		{
			// Token: 0x170004C6 RID: 1222
			internal unsafe IntPtr this[int i]
			{
				get
				{
					if (i < 0 || i > 15)
					{
						throw new IndexOutOfRangeException();
					}
					fixed (IntPtr* ptr = &this.vmods0)
					{
						return ptr[(IntPtr)i * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
					}
				}
			}

			// Token: 0x0400B7A6 RID: 47014
			private IntPtr vmods0;

			// Token: 0x0400B7A7 RID: 47015
			private IntPtr vmods1;

			// Token: 0x0400B7A8 RID: 47016
			private IntPtr vmods2;

			// Token: 0x0400B7A9 RID: 47017
			private IntPtr vmods3;

			// Token: 0x0400B7AA RID: 47018
			private IntPtr vmods4;

			// Token: 0x0400B7AB RID: 47019
			private IntPtr vmods5;

			// Token: 0x0400B7AC RID: 47020
			private IntPtr vmods6;

			// Token: 0x0400B7AD RID: 47021
			private IntPtr vmods7;

			// Token: 0x0400B7AE RID: 47022
			private IntPtr vmods8;

			// Token: 0x0400B7AF RID: 47023
			private IntPtr vmods9;

			// Token: 0x0400B7B0 RID: 47024
			private IntPtr vmods10;

			// Token: 0x0400B7B1 RID: 47025
			private IntPtr vmods11;

			// Token: 0x0400B7B2 RID: 47026
			private IntPtr vmods12;

			// Token: 0x0400B7B3 RID: 47027
			private IntPtr vmods13;

			// Token: 0x0400B7B4 RID: 47028
			private IntPtr vmods14;

			// Token: 0x0400B7B5 RID: 47029
			private IntPtr vmods15;
		}
	}
}
