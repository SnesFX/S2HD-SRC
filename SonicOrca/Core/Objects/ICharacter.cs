using System;
using System.Collections.Generic;
using SonicOrca.Core.Collision;
using SonicOrca.Core.Objects.Base;
using SonicOrca.Geometry;
using SonicOrca.Graphics;

namespace SonicOrca.Core.Objects
{
	// Token: 0x02000159 RID: 345
	public interface ICharacter : IActiveObject
	{
		// Token: 0x1700038D RID: 909
		// (get) Token: 0x06000E41 RID: 3649
		// (set) Token: 0x06000E42 RID: 3650
		CharacterSpecialState SpecialState { get; set; }

		// Token: 0x1700038E RID: 910
		// (get) Token: 0x06000E43 RID: 3651
		// (set) Token: 0x06000E44 RID: 3652
		bool Jumped { get; set; }

		// Token: 0x1700038F RID: 911
		// (get) Token: 0x06000E45 RID: 3653
		// (set) Token: 0x06000E46 RID: 3654
		bool IsJumping { get; set; }

		// Token: 0x17000390 RID: 912
		// (get) Token: 0x06000E47 RID: 3655
		// (set) Token: 0x06000E48 RID: 3656
		bool IsObjectControlled { get; set; }

		// Token: 0x17000391 RID: 913
		// (get) Token: 0x06000E49 RID: 3657
		bool ShouldReactToLevel { get; }

		// Token: 0x17000392 RID: 914
		// (get) Token: 0x06000E4A RID: 3658
		IReadOnlyList<CharacterHistoryItem> History { get; }

		// Token: 0x17000393 RID: 915
		// (get) Token: 0x06000E4B RID: 3659
		// (set) Token: 0x06000E4C RID: 3660
		ActiveObject ObjectLink { get; set; }

		// Token: 0x17000394 RID: 916
		// (get) Token: 0x06000E4D RID: 3661
		// (set) Token: 0x06000E4E RID: 3662
		object ObjectTag { get; set; }

		// Token: 0x17000395 RID: 917
		// (get) Token: 0x06000E4F RID: 3663
		// (set) Token: 0x06000E50 RID: 3664
		int Path { get; set; }

		// Token: 0x17000396 RID: 918
		// (get) Token: 0x06000E51 RID: 3665
		// (set) Token: 0x06000E52 RID: 3666
		CharacterState StateFlags { get; set; }

		// Token: 0x17000397 RID: 919
		// (get) Token: 0x06000E53 RID: 3667
		AnimationInstance Animation { get; }

		// Token: 0x17000398 RID: 920
		// (get) Token: 0x06000E54 RID: 3668
		// (set) Token: 0x06000E55 RID: 3669
		Player Player { get; set; }

		// Token: 0x17000399 RID: 921
		// (get) Token: 0x06000E56 RID: 3670
		// (set) Token: 0x06000E57 RID: 3671
		bool IsSidekick { get; set; }

		// Token: 0x1700039A RID: 922
		// (get) Token: 0x06000E58 RID: 3672
		// (set) Token: 0x06000E59 RID: 3673
		Vector2 Velocity { get; set; }

		// Token: 0x1700039B RID: 923
		// (get) Token: 0x06000E5A RID: 3674
		// (set) Token: 0x06000E5B RID: 3675
		double GroundVelocity { get; set; }

		// Token: 0x1700039C RID: 924
		// (get) Token: 0x06000E5C RID: 3676
		// (set) Token: 0x06000E5D RID: 3677
		CharacterLookDirection LookDirection { get; set; }

		// Token: 0x1700039D RID: 925
		// (get) Token: 0x06000E5E RID: 3678
		// (set) Token: 0x06000E5F RID: 3679
		double ShowAngle { get; set; }

		// Token: 0x1700039E RID: 926
		// (get) Token: 0x06000E60 RID: 3680
		// (set) Token: 0x06000E61 RID: 3681
		int LookDelay { get; set; }

		// Token: 0x1700039F RID: 927
		// (get) Token: 0x06000E62 RID: 3682
		// (set) Token: 0x06000E63 RID: 3683
		CharacterInputState Input { get; set; }

		// Token: 0x170003A0 RID: 928
		// (get) Token: 0x06000E64 RID: 3684
		// (set) Token: 0x06000E65 RID: 3685
		int Facing { get; set; }

		// Token: 0x170003A1 RID: 929
		// (get) Token: 0x06000E66 RID: 3686
		// (set) Token: 0x06000E67 RID: 3687
		bool IsAirborne { get; set; }

		// Token: 0x170003A2 RID: 930
		// (get) Token: 0x06000E68 RID: 3688
		bool IsDeadly { get; }

		// Token: 0x170003A3 RID: 931
		// (get) Token: 0x06000E69 RID: 3689
		// (set) Token: 0x06000E6A RID: 3690
		bool IsSpinball { get; set; }

		// Token: 0x170003A4 RID: 932
		// (get) Token: 0x06000E6B RID: 3691
		// (set) Token: 0x06000E6C RID: 3692
		bool IsUnderwater { get; set; }

		// Token: 0x170003A5 RID: 933
		// (get) Token: 0x06000E6D RID: 3693
		// (set) Token: 0x06000E6E RID: 3694
		bool IsRollJumping { get; set; }

		// Token: 0x170003A6 RID: 934
		// (get) Token: 0x06000E6F RID: 3695
		// (set) Token: 0x06000E70 RID: 3696
		bool IsHurt { get; set; }

		// Token: 0x170003A7 RID: 935
		// (get) Token: 0x06000E71 RID: 3697
		// (set) Token: 0x06000E72 RID: 3698
		int BreathTicks { get; set; }

		// Token: 0x170003A8 RID: 936
		// (get) Token: 0x06000E73 RID: 3699
		// (set) Token: 0x06000E74 RID: 3700
		BarrierType Barrier { get; set; }

		// Token: 0x170003A9 RID: 937
		// (get) Token: 0x06000E75 RID: 3701
		bool HasBarrier { get; }

		// Token: 0x170003AA RID: 938
		// (get) Token: 0x06000E76 RID: 3702
		// (set) Token: 0x06000E77 RID: 3703
		bool ForceSpinball { get; set; }

		// Token: 0x06000E78 RID: 3704
		void Hurt(int direction, PlayerDeathCause cause = PlayerDeathCause.Hurt);

		// Token: 0x170003AB RID: 939
		// (get) Token: 0x06000E79 RID: 3705
		bool IsCharging { get; }

		// Token: 0x170003AC RID: 940
		// (get) Token: 0x06000E7A RID: 3706
		bool Respawning { get; }

		// Token: 0x170003AD RID: 941
		// (get) Token: 0x06000E7B RID: 3707
		// (set) Token: 0x06000E7C RID: 3708
		bool ExhibitsVirtualPlatform { get; set; }

		// Token: 0x170003AE RID: 942
		// (get) Token: 0x06000E7D RID: 3709
		// (set) Token: 0x06000E7E RID: 3710
		bool IsDebug { get; set; }

		// Token: 0x170003AF RID: 943
		// (get) Token: 0x06000E7F RID: 3711
		// (set) Token: 0x06000E80 RID: 3712
		double TumbleAngle { get; set; }

		// Token: 0x170003B0 RID: 944
		// (get) Token: 0x06000E81 RID: 3713
		// (set) Token: 0x06000E82 RID: 3714
		int TumbleTurns { get; set; }

		// Token: 0x170003B1 RID: 945
		// (get) Token: 0x06000E83 RID: 3715
		// (set) Token: 0x06000E84 RID: 3716
		bool HasSpeedShoes { get; set; }

		// Token: 0x170003B2 RID: 946
		// (get) Token: 0x06000E85 RID: 3717
		// (set) Token: 0x06000E86 RID: 3718
		bool IsInvincible { get; set; }

		// Token: 0x170003B3 RID: 947
		// (get) Token: 0x06000E87 RID: 3719
		// (set) Token: 0x06000E88 RID: 3720
		int SlopeLockTicks { get; set; }

		// Token: 0x170003B4 RID: 948
		// (get) Token: 0x06000E89 RID: 3721
		// (set) Token: 0x06000E8A RID: 3722
		bool IsPushing { get; set; }

		// Token: 0x170003B5 RID: 949
		// (get) Token: 0x06000E8B RID: 3723
		// (set) Token: 0x06000E8C RID: 3724
		bool IsDead { get; set; }

		// Token: 0x170003B6 RID: 950
		// (get) Token: 0x06000E8D RID: 3725
		// (set) Token: 0x06000E8E RID: 3726
		bool IsDying { get; set; }

		// Token: 0x06000E8F RID: 3727
		void Kill(PlayerDeathCause cause);

		// Token: 0x06000E90 RID: 3728
		void InhaleOxygen();

		// Token: 0x170003B7 RID: 951
		// (get) Token: 0x06000E91 RID: 3729
		// (set) Token: 0x06000E92 RID: 3730
		bool IsWinning { get; set; }

		// Token: 0x170003B8 RID: 952
		// (get) Token: 0x06000E93 RID: 3731
		// (set) Token: 0x06000E94 RID: 3732
		CameraProperties CameraProperties { get; set; }

		// Token: 0x170003B9 RID: 953
		// (get) Token: 0x06000E95 RID: 3733
		// (set) Token: 0x06000E96 RID: 3734
		bool CheckCollision { get; set; }

		// Token: 0x170003BA RID: 954
		// (get) Token: 0x06000E97 RID: 3735
		// (set) Token: 0x06000E98 RID: 3736
		bool CheckLandscapeCollision { get; set; }

		// Token: 0x170003BB RID: 955
		// (get) Token: 0x06000E99 RID: 3737
		// (set) Token: 0x06000E9A RID: 3738
		bool CheckObjectCollision { get; set; }

		// Token: 0x170003BC RID: 956
		// (get) Token: 0x06000E9B RID: 3739
		int LedgeSensorRadius { get; }

		// Token: 0x170003BD RID: 957
		// (get) Token: 0x06000E9C RID: 3740
		Vector2i NormalCollisionRadius { get; }

		// Token: 0x170003BE RID: 958
		// (get) Token: 0x06000E9D RID: 3741
		Vector2i SpinballCollisionRadius { get; }

		// Token: 0x170003BF RID: 959
		// (get) Token: 0x06000E9E RID: 3742
		Vector2i CollisionRadius { get; }

		// Token: 0x06000E9F RID: 3743
		void LeaveGround();

		// Token: 0x170003C0 RID: 960
		// (get) Token: 0x06000EA0 RID: 3744
		CollisionVector GroundVector { get; }

		// Token: 0x170003C1 RID: 961
		// (get) Token: 0x06000EA1 RID: 3745
		// (set) Token: 0x06000EA2 RID: 3746
		CollisionMode Mode { get; set; }

		// Token: 0x170003C2 RID: 962
		// (get) Token: 0x06000EA3 RID: 3747
		bool CanBeHurt { get; }
	}
}
