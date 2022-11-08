using System;
using System.Collections.Generic;
using System.Linq;
using SonicOrca.Core.Collision;
using SonicOrca.Geometry;
using SonicOrca.Graphics;

namespace SonicOrca.Core.Debugging
{
	// Token: 0x02000191 RID: 401
	internal static class DebugOptionDefinitions
	{
		// Token: 0x0600115E RID: 4446 RVA: 0x00044AC8 File Offset: 0x00042CC8
		public static IEnumerable<DebugOption> CreateOptionsInOrder(DebugContext context)
		{
			return new DebugOption[]
			{
				new DebugOptionDefinitions.PlatformStats(context),
				new DebugOptionDefinitions.LevelInfo(context),
				new DebugOptionDefinitions.PlayerInfo(context),
				new DebugOptionDefinitions.ShowHud(context),
				new DebugOptionDefinitions.ClassicDebugMode(context),
				new DebugOptionDefinitions.CameraInfo(context),
				new DebugOptionDefinitions.CameraShowInfo(context),
				new DebugOptionDefinitions.CameraMode(context),
				new DebugOptionDefinitions.CameraZoom(context),
				new DebugOptionDefinitions.LandscapeInfo(context),
				new DebugOptionDefinitions.LandscapeVisible(context),
				new DebugOptionDefinitions.LandscapeAnimate(context),
				new DebugOptionDefinitions.CollisionShowLandscape(context),
				new DebugOptionDefinitions.CollisionShowObjects(context),
				new DebugOptionDefinitions.CollisionStats(context),
				new DebugOptionDefinitions.ObjectsVisible(context),
				new DebugOptionDefinitions.ObjectsAnimate(context),
				new DebugOptionDefinitions.ObjectsShowCharacterInfo(context),
				new DebugOptionDefinitions.ObjectsShowSidekickIntel(context),
				new DebugOptionDefinitions.ObjectsStats(context),
				new DebugOptionDefinitions.WaterInfo(context),
				new DebugOptionDefinitions.WaterVisible(context)
			};
		}

		// Token: 0x0200025F RID: 607
		public class PlatformStats : InformationDebugOption
		{
			// Token: 0x060014D4 RID: 5332 RVA: 0x000500C2 File Offset: 0x0004E2C2
			public PlatformStats(DebugContext context) : base(context, "PLATFORM", "")
			{
			}

			// Token: 0x060014D5 RID: 5333 RVA: 0x000500D8 File Offset: 0x0004E2D8
			protected override IEnumerable<IEnumerable<KeyValuePair<string, object>>> GetInformation()
			{
				IPlatform platform = base.Context.Level.GameContext.Platform;
				IGraphicsContext graphicsContext = platform.Window.GraphicsContext;
				double num = (double)platform.TotalMemory;
				double num2 = (double)Environment.WorkingSet / 1048576.0;
				int num3 = (int)Math.Ceiling(num2 / num * 100.0);
				return new KeyValuePair<string, object>[][]
				{
					new KeyValuePair<string, object>[]
					{
						new KeyValuePair<string, object>("NAME", "SONICORCA"),
						new KeyValuePair<string, object>("VERSION", SonicOrcaInfo.Version)
					},
					new KeyValuePair<string, object>[]
					{
						new KeyValuePair<string, object>("ARCHITECTURE", Environment.Is64BitOperatingSystem ? "x64" : "x86"),
						new KeyValuePair<string, object>("OS ARCHITECTURE", Environment.Is64BitOperatingSystem ? "x64" : "x86")
					},
					new KeyValuePair<string, object>[]
					{
						new KeyValuePair<string, object>("OS", Environment.OSVersion),
						new KeyValuePair<string, object>("MACHINE NAME", Environment.MachineName)
					},
					new KeyValuePair<string, object>[]
					{
						new KeyValuePair<string, object>("LOGICAL PROCESSORS", Environment.ProcessorCount),
						new KeyValuePair<string, object>("TOTAL MEMORY", string.Format("{0:0.0} GB", num / 1024.0))
					},
					new KeyValuePair<string, object>[]
					{
						new KeyValuePair<string, object>("USER", Environment.UserName),
						new KeyValuePair<string, object>("MEMORY USAGE", string.Format("{0:0.0} MB ({1}%)", num2, num3))
					},
					new KeyValuePair<string, object>[0],
					new KeyValuePair<string, object>[]
					{
						new KeyValuePair<string, object>("WINDOW SIZE", string.Format("{0} X {1}", platform.Window.ClientSize.X, platform.Window.ClientSize.Y)),
						new KeyValuePair<string, object>("FULLSCREEN", platform.Window.FullScreen)
					},
					new KeyValuePair<string, object>[]
					{
						new KeyValuePair<string, object>("GRAPHICS API", platform.GraphicsAPI),
						new KeyValuePair<string, object>("VENDOR", platform.GraphicsVendor)
					},
					new KeyValuePair<string, object>[]
					{
						new KeyValuePair<string, object>("TEXTURES", graphicsContext.Textures.Count),
						new KeyValuePair<string, object>("SHADERS", graphicsContext.ShaderPrograms.Count)
					},
					new KeyValuePair<string, object>[]
					{
						new KeyValuePair<string, object>("RENDER TARGETS", graphicsContext.RenderTargets.Count),
						new KeyValuePair<string, object>("VERTEX BUFFERS", graphicsContext.VertexBuffers.Count)
					}
				};
			}
		}

		// Token: 0x02000260 RID: 608
		public class LevelInfo : InformationDebugOption
		{
			// Token: 0x060014D6 RID: 5334 RVA: 0x000503DB File Offset: 0x0004E5DB
			public LevelInfo(DebugContext context) : base(context, "LEVEL", "")
			{
			}

			// Token: 0x060014D7 RID: 5335 RVA: 0x000503F0 File Offset: 0x0004E5F0
			protected override IEnumerable<IEnumerable<KeyValuePair<string, object>>> GetInformation()
			{
				Level level = base.Context.Level;
				KeyValuePair<string, object>[] array = level.Area.StateVariables.ToArray<KeyValuePair<string, object>>();
				KeyValuePair<string, object>[] array2 = new KeyValuePair<string, object>[(array.Length + 1) / 2];
				KeyValuePair<string, object>[] array3 = new KeyValuePair<string, object>[array.Length - array2.Length];
				if (array2.Length != 0)
				{
					Array.Copy(array, 0, array2, 0, array2.Length);
				}
				if (array3.Length != 0)
				{
					Array.Copy(array, array2.Length, array3, 0, array3.Length);
				}
				List<IEnumerable<KeyValuePair<string, object>>> list = new List<IEnumerable<KeyValuePair<string, object>>>();
				for (int i = 0; i < array2.Length; i++)
				{
					list.Add(new KeyValuePair<string, object>[]
					{
						array2[i],
						(array3.Length > i) ? array3[i] : new KeyValuePair<string, object>("", "")
					});
				}
				return new KeyValuePair<string, object>[][]
				{
					new KeyValuePair<string, object>[]
					{
						new KeyValuePair<string, object>("NAME", level.Name + (level.ShowAsAct ? " Zone" : string.Empty)),
						new KeyValuePair<string, object>("ACT", level.CurrentAct)
					},
					new KeyValuePair<string, object>[]
					{
						new KeyValuePair<string, object>("TICKS", level.Ticks),
						new KeyValuePair<string, object>("TIME", string.Format("{0}, {1:mm':'ss':'fff}", level.Time, TimeSpan.FromSeconds((double)level.Time / 60.0)))
					},
					new KeyValuePair<string, object>[]
					{
						new KeyValuePair<string, object>("BOUNDS", string.Format("{0}, {1} - {2}, {3}", new object[]
						{
							level.Bounds.Left,
							level.Bounds.Top,
							level.Bounds.Right,
							level.Bounds.Bottom
						})),
						new KeyValuePair<string, object>("BOUNDS SIZE", string.Format("{0} X {1}", level.Bounds.Width, level.Bounds.Height))
					},
					new KeyValuePair<string, object>[]
					{
						new KeyValuePair<string, object>("LAYERS", level.Map.Layers.Count),
						new KeyValuePair<string, object>("", "")
					},
					new KeyValuePair<string, object>[0]
				}.Concat(list);
			}
		}

		// Token: 0x02000261 RID: 609
		public class PlayerInfo : InformationDebugOption
		{
			// Token: 0x060014D8 RID: 5336 RVA: 0x00050691 File Offset: 0x0004E891
			public PlayerInfo(DebugContext context) : base(context, "LEVEL", "PLAYER")
			{
			}

			// Token: 0x060014D9 RID: 5337 RVA: 0x000506A4 File Offset: 0x0004E8A4
			protected override IEnumerable<IEnumerable<KeyValuePair<string, object>>> GetInformation()
			{
				Level level = base.Context.Level;
				Player player = base.Context.Level.Player;
				return new KeyValuePair<string, object>[][]
				{
					new KeyValuePair<string, object>[]
					{
						new KeyValuePair<string, object>("PROTAGONIST", "SONIC"),
						new KeyValuePair<string, object>("SIDEKICK", "TAILS")
					},
					new KeyValuePair<string, object>[]
					{
						new KeyValuePair<string, object>("SCORE", player.Score),
						new KeyValuePair<string, object>("LIFE TARGET SCORE", player.TargetScoreForNextLife)
					},
					new KeyValuePair<string, object>[]
					{
						new KeyValuePair<string, object>("CURRENT RINGS", player.CurrentRings),
						new KeyValuePair<string, object>("LIFE TARGET RINGS", player.TargetRingCountForNextLife)
					},
					new KeyValuePair<string, object>[]
					{
						new KeyValuePair<string, object>("TOTAL COLLECTED RINGS", player.TotalRings),
						new KeyValuePair<string, object>("PERFECT BONUS", player.TotalRings + level.ObjectManager.ObjectEntryTable.GetRingCount())
					},
					new KeyValuePair<string, object>[]
					{
						new KeyValuePair<string, object>("LIVES", player.Lives),
						new KeyValuePair<string, object>("", "")
					},
					new KeyValuePair<string, object>[]
					{
						new KeyValuePair<string, object>("STARPOST ID", player.StarpostIndex),
						new KeyValuePair<string, object>("STARPOST TIME", string.Format("{0}, {1:mm':'ss':'fff}", player.StarpostTime, TimeSpan.FromSeconds((double)player.StarpostTime / 60.0)))
					},
					new KeyValuePair<string, object>[]
					{
						new KeyValuePair<string, object>("INVINCIBILITY, TICKS LEFT", player.InvincibillityTicks),
						new KeyValuePair<string, object>("SPEED SHOES, TICKS LEFT", player.SpeedShoesTicks)
					}
				};
			}
		}

		// Token: 0x02000262 RID: 610
		public class ShowHud : DiscreteDebugOption<bool>
		{
			// Token: 0x060014DA RID: 5338 RVA: 0x000508C0 File Offset: 0x0004EAC0
			public ShowHud(DebugContext context) : base(context, "LEVEL", "", "SHOW HUD", new KeyValuePair<string, bool>[]
			{
				new KeyValuePair<string, bool>("YES", true),
				new KeyValuePair<string, bool>("NO", false)
			})
			{
				base.SelectedValue = true;
			}

			// Token: 0x060014DB RID: 5339 RVA: 0x00050914 File Offset: 0x0004EB14
			public override void OnChange()
			{
				base.Context.Level.ShowHUD = base.SelectedValue;
			}
		}

		// Token: 0x02000263 RID: 611
		public class ClassicDebugMode : DiscreteDebugOption<bool>
		{
			// Token: 0x060014DC RID: 5340 RVA: 0x0005092C File Offset: 0x0004EB2C
			public ClassicDebugMode(DebugContext context) : base(context, "LEVEL", "", "CLASSIC DEBUG MODE", new KeyValuePair<string, bool>[]
			{
				new KeyValuePair<string, bool>("YES", true),
				new KeyValuePair<string, bool>("NO", false)
			})
			{
				base.SelectedValue = false;
			}

			// Token: 0x060014DD RID: 5341 RVA: 0x00050980 File Offset: 0x0004EB80
			public override void OnChange()
			{
				base.Context.Level.ClassicDebugMode = base.SelectedValue;
			}
		}

		// Token: 0x02000264 RID: 612
		public class CameraInfo : InformationDebugOption
		{
			// Token: 0x060014DE RID: 5342 RVA: 0x00050998 File Offset: 0x0004EB98
			public CameraInfo(DebugContext context) : base(context, "CAMERA", "")
			{
			}

			// Token: 0x060014DF RID: 5343 RVA: 0x000509AC File Offset: 0x0004EBAC
			protected override IEnumerable<IEnumerable<KeyValuePair<string, object>>> GetInformation()
			{
				Camera camera = base.Context.Level.Camera;
				return new KeyValuePair<string, object>[][]
				{
					new KeyValuePair<string, object>[]
					{
						new KeyValuePair<string, object>("BOUNDS", string.Format("{0}, {1} - {2}, {3}", new object[]
						{
							camera.Bounds.Left,
							camera.Bounds.Top,
							camera.Bounds.Right,
							camera.Bounds.Bottom
						})),
						new KeyValuePair<string, object>("SIZE", string.Format("{0} X {1}", camera.Bounds.Width, camera.Bounds.Height))
					},
					new KeyValuePair<string, object>[]
					{
						new KeyValuePair<string, object>("VELOCITY", camera.Velocity),
						new KeyValuePair<string, object>("ACCELERATION", camera.Acceleration)
					}
				};
			}
		}

		// Token: 0x02000265 RID: 613
		public class CameraShowInfo : DiscreteDebugOption<bool>
		{
			// Token: 0x060014E0 RID: 5344 RVA: 0x00050AD4 File Offset: 0x0004ECD4
			public CameraShowInfo(DebugContext context) : base(context, "CAMERA", "", "SHOW INFO", new KeyValuePair<string, bool>[]
			{
				new KeyValuePair<string, bool>("YES", true),
				new KeyValuePair<string, bool>("NO", false)
			})
			{
			}

			// Token: 0x060014E1 RID: 5345 RVA: 0x00050B21 File Offset: 0x0004ED21
			public override void OnChange()
			{
				base.Context.Level.Camera.ShowDebugInformation = base.SelectedValue;
			}
		}

		// Token: 0x02000266 RID: 614
		public class CameraMode : DiscreteDebugOption<int>
		{
			// Token: 0x060014E2 RID: 5346 RVA: 0x00050B40 File Offset: 0x0004ED40
			public CameraMode(DebugContext context) : base(context, "CAMERA", "", "MODE", new KeyValuePair<string, int>[]
			{
				new KeyValuePair<string, int>("TRACK", 0),
				new KeyValuePair<string, int>("FREECAM", 1)
			})
			{
			}

			// Token: 0x060014E3 RID: 5347 RVA: 0x00050B8D File Offset: 0x0004ED8D
			public override void OnChange()
			{
				base.Context.Level.Camera.SpyMode = (base.SelectedValue == 1);
			}
		}

		// Token: 0x02000267 RID: 615
		public class CameraZoom : DiscreteDebugOption<double>
		{
			// Token: 0x060014E4 RID: 5348 RVA: 0x00050BB0 File Offset: 0x0004EDB0
			public CameraZoom(DebugContext context) : base(context, "CAMERA", "", "ZOOM", new KeyValuePair<string, double>[]
			{
				new KeyValuePair<string, double>("0.25", 0.25),
				new KeyValuePair<string, double>("0.50", 0.5),
				new KeyValuePair<string, double>("1.00", 1.0),
				new KeyValuePair<string, double>("2.00", 2.0),
				new KeyValuePair<string, double>("4.00", 4.0)
			})
			{
				base.SelectedValue = 1.0;
			}

			// Token: 0x060014E5 RID: 5349 RVA: 0x00050C6A File Offset: 0x0004EE6A
			public override void OnChange()
			{
				base.Context.Level.Camera.SetScale(base.SelectedValue);
			}
		}

		// Token: 0x02000268 RID: 616
		public class LandscapeInfo : InformationDebugOption
		{
			// Token: 0x060014E6 RID: 5350 RVA: 0x00050C87 File Offset: 0x0004EE87
			public LandscapeInfo(DebugContext context) : base(context, "LANDSCAPE", "")
			{
			}

			// Token: 0x060014E7 RID: 5351 RVA: 0x00050C9C File Offset: 0x0004EE9C
			protected override IEnumerable<IEnumerable<KeyValuePair<string, object>>> GetInformation()
			{
				TileSet tileSet = base.Context.Level.TileSet;
				KeyValuePair<string, object>[][] array = new KeyValuePair<string, object>[2][];
				int num = 0;
				KeyValuePair<string, object>[] array2 = new KeyValuePair<string, object>[2];
				array2[0] = new KeyValuePair<string, object>("TOTAL TILES", tileSet.Count);
				array2[1] = new KeyValuePair<string, object>("ANIMATED TILES", tileSet.Values.Count((ITile x) => x.Animated));
				array[num] = array2;
				array[1] = new KeyValuePair<string, object>[]
				{
					new KeyValuePair<string, object>("TILESET TEXTURES", tileSet.Textures.Count),
					new KeyValuePair<string, object>("", "")
				};
				return array;
			}
		}

		// Token: 0x02000269 RID: 617
		public class LandscapeVisible : DiscreteDebugOption<bool>
		{
			// Token: 0x060014E8 RID: 5352 RVA: 0x00050D68 File Offset: 0x0004EF68
			public LandscapeVisible(DebugContext context) : base(context, "LANDSCAPE", "", "VISIBLE", new KeyValuePair<string, bool>[]
			{
				new KeyValuePair<string, bool>("YES", true),
				new KeyValuePair<string, bool>("NO", false)
			})
			{
			}

			// Token: 0x060014E9 RID: 5353 RVA: 0x00050DB5 File Offset: 0x0004EFB5
			public override void OnChange()
			{
				base.Context.Level.LayerViewOptions.ShowLandscape = base.SelectedValue;
			}
		}

		// Token: 0x0200026A RID: 618
		public class LandscapeAnimate : DiscreteDebugOption<bool>
		{
			// Token: 0x060014EA RID: 5354 RVA: 0x00050DD4 File Offset: 0x0004EFD4
			public LandscapeAnimate(DebugContext context) : base(context, "LANDSCAPE", "", "ANIMATE", new KeyValuePair<string, bool>[]
			{
				new KeyValuePair<string, bool>("YES", true),
				new KeyValuePair<string, bool>("NO", false)
			})
			{
			}

			// Token: 0x060014EB RID: 5355 RVA: 0x00050E21 File Offset: 0x0004F021
			public override void OnChange()
			{
				base.Context.Level.LandscapeAnimating = base.SelectedValue;
			}
		}

		// Token: 0x0200026B RID: 619
		public class CollisionStats : InformationDebugOption
		{
			// Token: 0x060014EC RID: 5356 RVA: 0x00050E39 File Offset: 0x0004F039
			public CollisionStats(DebugContext context) : base(context, "COLLISION", "STATISTICS")
			{
			}

			// Token: 0x060014ED RID: 5357 RVA: 0x00050E4C File Offset: 0x0004F04C
			protected override IEnumerable<IEnumerable<KeyValuePair<string, object>>> GetInformation()
			{
				Level level = base.Context.Level;
				CollisionTable collisionTable = base.Context.Level.CollisionTable;
				QuadTree<CollisionVector> internalTree = collisionTable.InternalTree;
				return new KeyValuePair<string, object>[][]
				{
					new KeyValuePair<string, object>[]
					{
						new KeyValuePair<string, object>("TOTAL VECTORS", collisionTable.Count),
						new KeyValuePair<string, object>("TOTAL QUADTREE NODES", internalTree.GetDepth())
					}
				};
			}
		}

		// Token: 0x0200026C RID: 620
		public class CollisionShowLandscape : DiscreteDebugOption<bool>
		{
			// Token: 0x060014EE RID: 5358 RVA: 0x00050EC4 File Offset: 0x0004F0C4
			public CollisionShowLandscape(DebugContext context) : base(context, "COLLISION", "", "SHOW LANDSCAPE", new KeyValuePair<string, bool>[]
			{
				new KeyValuePair<string, bool>("YES", true),
				new KeyValuePair<string, bool>("NO", false)
			})
			{
				base.SelectedValue = false;
			}

			// Token: 0x060014EF RID: 5359 RVA: 0x00050F18 File Offset: 0x0004F118
			public override void OnChange()
			{
				base.Context.Level.LayerViewOptions.ShowLandscapeCollision = base.SelectedValue;
			}
		}

		// Token: 0x0200026D RID: 621
		public class CollisionShowObjects : DiscreteDebugOption<bool>
		{
			// Token: 0x060014F0 RID: 5360 RVA: 0x00050F38 File Offset: 0x0004F138
			public CollisionShowObjects(DebugContext context) : base(context, "COLLISION", "", "SHOW OBJECTS", new KeyValuePair<string, bool>[]
			{
				new KeyValuePair<string, bool>("YES", true),
				new KeyValuePair<string, bool>("NO", false)
			})
			{
				base.SelectedValue = false;
			}

			// Token: 0x060014F1 RID: 5361 RVA: 0x00050F8C File Offset: 0x0004F18C
			public override void OnChange()
			{
				base.Context.Level.LayerViewOptions.ShowObjectCollision = base.SelectedValue;
			}
		}

		// Token: 0x0200026E RID: 622
		public class ObjectsVisible : DiscreteDebugOption<bool>
		{
			// Token: 0x060014F2 RID: 5362 RVA: 0x00050FAC File Offset: 0x0004F1AC
			public ObjectsVisible(DebugContext context) : base(context, "OBJECTS", "", "VISIBLE", new KeyValuePair<string, bool>[]
			{
				new KeyValuePair<string, bool>("YES", true),
				new KeyValuePair<string, bool>("NO", false)
			})
			{
			}

			// Token: 0x060014F3 RID: 5363 RVA: 0x00050FF9 File Offset: 0x0004F1F9
			public override void OnChange()
			{
				base.Context.Level.LayerViewOptions.ShowObjects = base.SelectedValue;
			}
		}

		// Token: 0x0200026F RID: 623
		public class ObjectsAnimate : DiscreteDebugOption<bool>
		{
			// Token: 0x060014F4 RID: 5364 RVA: 0x00051018 File Offset: 0x0004F218
			public ObjectsAnimate(DebugContext context) : base(context, "OBJECTS", "", "ANIMATE", new KeyValuePair<string, bool>[]
			{
				new KeyValuePair<string, bool>("YES", true),
				new KeyValuePair<string, bool>("NO", false)
			})
			{
			}

			// Token: 0x060014F5 RID: 5365 RVA: 0x00051065 File Offset: 0x0004F265
			public override void OnChange()
			{
				base.Context.Level.ObjectsAnimating = base.SelectedValue;
			}
		}

		// Token: 0x02000270 RID: 624
		public class ObjectsShowCharacterInfo : DiscreteDebugOption<bool>
		{
			// Token: 0x060014F6 RID: 5366 RVA: 0x00051080 File Offset: 0x0004F280
			public ObjectsShowCharacterInfo(DebugContext context) : base(context, "OBJECTS", "", "SHOW CHARACTER INFO", new KeyValuePair<string, bool>[]
			{
				new KeyValuePair<string, bool>("YES", true),
				new KeyValuePair<string, bool>("NO", false)
			})
			{
				base.SelectedValue = false;
			}

			// Token: 0x060014F7 RID: 5367 RVA: 0x000510D4 File Offset: 0x0004F2D4
			public override void OnChange()
			{
				base.Context.Level.ShowCharacterInfo = base.SelectedValue;
			}
		}

		// Token: 0x02000271 RID: 625
		public class ObjectsShowSidekickIntel : DiscreteDebugOption<bool>
		{
			// Token: 0x060014F8 RID: 5368 RVA: 0x000510EC File Offset: 0x0004F2EC
			public ObjectsShowSidekickIntel(DebugContext context) : base(context, "OBJECTS", "", "SHOW SIDEKICK INTELLIGENCE", new KeyValuePair<string, bool>[]
			{
				new KeyValuePair<string, bool>("YES", true),
				new KeyValuePair<string, bool>("NO", false)
			})
			{
				base.SelectedValue = false;
			}

			// Token: 0x060014F9 RID: 5369 RVA: 0x00051140 File Offset: 0x0004F340
			public override void OnChange()
			{
				base.Context.Level.ShowSidekickIntelligence = base.SelectedValue;
			}
		}

		// Token: 0x02000272 RID: 626
		public class ObjectsStats : InformationDebugOption
		{
			// Token: 0x060014FA RID: 5370 RVA: 0x00051158 File Offset: 0x0004F358
			public ObjectsStats(DebugContext context) : base(context, "OBJECTS", "STATISTICS")
			{
			}

			// Token: 0x060014FB RID: 5371 RVA: 0x0005116C File Offset: 0x0004F36C
			protected override IEnumerable<IEnumerable<KeyValuePair<string, object>>> GetInformation()
			{
				Level level = base.Context.Level;
				KeyValuePair<string, object>[][] array = new KeyValuePair<string, object>[2][];
				array[0] = new KeyValuePair<string, object>[]
				{
					new KeyValuePair<string, object>("TOTAL OBJECTS", level.ObjectManager.ObjectEntryTable.Count),
					new KeyValuePair<string, object>("ACTIVE OBJECTS", level.ObjectManager.ActiveObjects.Count)
				};
				int num = 1;
				KeyValuePair<string, object>[] array2 = new KeyValuePair<string, object>[2];
				array2[0] = new KeyValuePair<string, object>("SUB OBJECTS", level.ObjectManager.ActiveObjects.Count((ActiveObject x) => x.IsSubObject));
				array2[1] = new KeyValuePair<string, object>("RESPAWN PREVENTED OBJECTS", "");
				array[num] = array2;
				return array;
			}
		}

		// Token: 0x02000273 RID: 627
		public class WaterInfo : InformationDebugOption
		{
			// Token: 0x060014FC RID: 5372 RVA: 0x00051244 File Offset: 0x0004F444
			public WaterInfo(DebugContext context) : base(context, "WATER", "")
			{
			}

			// Token: 0x060014FD RID: 5373 RVA: 0x00051258 File Offset: 0x0004F458
			protected override IEnumerable<IEnumerable<KeyValuePair<string, object>>> GetInformation()
			{
				WaterManager waterManager = base.Context.Level.WaterManager;
				return new KeyValuePair<string, object>[][]
				{
					new KeyValuePair<string, object>[]
					{
						new KeyValuePair<string, object>("TOTAL AREAS", waterManager.WaterAreas.Count),
						new KeyValuePair<string, object>("", "")
					},
					new KeyValuePair<string, object>[]
					{
						new KeyValuePair<string, object>("HUE", string.Format("{0:0} DEG", waterManager.HueTarget * 360.0)),
						new KeyValuePair<string, object>("HUE CONCENTRATION", waterManager.HueAmount)
					},
					new KeyValuePair<string, object>[]
					{
						new KeyValuePair<string, object>("SATURATION ADJUSTMENT", waterManager.SaturationChange),
						new KeyValuePair<string, object>("LUMINOSITY ADJUSTMENT", waterManager.LuminosityChange)
					},
					new KeyValuePair<string, object>[]
					{
						new KeyValuePair<string, object>("RIPPLE SIZE", waterManager.WaveSize),
						new KeyValuePair<string, object>("RIPPLE PHASE", string.Format("{0:0} DEG", MathX.ToDegrees(waterManager.WavePhase)))
					}
				};
			}
		}

		// Token: 0x02000274 RID: 628
		public class WaterVisible : DiscreteDebugOption<bool>
		{
			// Token: 0x060014FE RID: 5374 RVA: 0x000513A4 File Offset: 0x0004F5A4
			public WaterVisible(DebugContext context) : base(context, "WATER", "", "VISIBLE", new KeyValuePair<string, bool>[]
			{
				new KeyValuePair<string, bool>("YES", true),
				new KeyValuePair<string, bool>("NO", false)
			})
			{
			}

			// Token: 0x060014FF RID: 5375 RVA: 0x000513F1 File Offset: 0x0004F5F1
			public override void OnChange()
			{
				base.Context.Level.LayerViewOptions.ShowWater = base.SelectedValue;
			}
		}
	}
}
