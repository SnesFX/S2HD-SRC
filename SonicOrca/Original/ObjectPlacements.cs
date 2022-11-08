using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SonicOrca.Core;
using SonicOrca.Geometry;

namespace SonicOrca.Original
{
	// Token: 0x020000A5 RID: 165
	public static class ObjectPlacements
	{
		// Token: 0x0600056E RID: 1390 RVA: 0x0001AE38 File Offset: 0x00019038
		public static IReadOnlyCollection<ObjectPlacements.OriginalObjectPlacement> FromFile(string filename)
		{
			IReadOnlyCollection<ObjectPlacements.OriginalObjectPlacement> result;
			using (FileStream fileStream = new FileStream(filename, FileMode.Open, FileAccess.Read))
			{
				result = ObjectPlacements.FromStream(fileStream);
			}
			return result;
		}

		// Token: 0x0600056F RID: 1391 RVA: 0x0001AE74 File Offset: 0x00019074
		public static IReadOnlyCollection<ObjectPlacements.OriginalObjectPlacement> FromStream(Stream stream)
		{
			List<ObjectPlacements.OriginalObjectPlacement> list = new List<ObjectPlacements.OriginalObjectPlacement>();
			byte[] array = new byte[6];
			while (stream.Read(array, 0, 2) == 2 && (array[0] != 255 || array[1] != 255) && stream.Read(array, 2, 4) == 4)
			{
				list.Add(new ObjectPlacements.OriginalObjectPlacement(array));
			}
			return list.ToArray();
		}

		// Token: 0x06000570 RID: 1392 RVA: 0x0001AED0 File Offset: 0x000190D0
		public static IEnumerable<ObjectPlacement> ConvertOriginalObjectPlacement(IEnumerable<ObjectPlacements.OriginalObjectPlacement> originalPlacements)
		{
			return from x in originalPlacements
			select ObjectPlacements.ConvertOriginalObjectPlacement(x) into x
			where x != null
			select x;
		}

		// Token: 0x06000571 RID: 1393 RVA: 0x0001AF28 File Offset: 0x00019128
		public static ObjectPlacement ConvertOriginalObjectPlacement(ObjectPlacements.OriginalObjectPlacement originalPlacement)
		{
			string text = null;
			object obj = null;
			Vector2i vector2i = originalPlacement.Position * 4;
			byte type = originalPlacement.Type;
			if (type <= 50)
			{
				if (type <= 13)
				{
					if (type != 3)
					{
						if (type != 11)
						{
							if (type == 13)
							{
								text = "SONICORCA/OBJECTS/SIGNPOST";
							}
						}
						else
						{
							text = "SONICORCA/OBJECTS/CPZTRAPDOOR";
							obj = new
							{
								TimeOffset = (int)((originalPlacement.SubType & 15) * 16)
							};
						}
					}
					else
					{
						text = "SONICORCA/OBJECTS/LAYERSWITCH";
						int[] array = new int[]
						{
							256,
							512,
							1024,
							2048
						};
						if ((originalPlacement.SubType & 4) != 0)
						{
							obj = new
							{
								AllowAirborne = ((originalPlacement.SubType & 128) == 0),
								Width = array[(int)(originalPlacement.SubType & 3)],
								Above = (((originalPlacement.SubType & 16) == 0) ? 0 : 1),
								Below = (((originalPlacement.SubType & 8) == 0) ? 0 : 1)
							};
						}
						else
						{
							obj = new
							{
								AllowAirborne = ((originalPlacement.SubType & 128) == 0),
								Height = array[(int)(originalPlacement.SubType & 3)],
								Left = (((originalPlacement.SubType & 16) == 0) ? 0 : 1),
								Right = (((originalPlacement.SubType & 8) == 0) ? 0 : 1)
							};
						}
					}
				}
				else if (type <= 38)
				{
					switch (type)
					{
					case 20:
						text = "SONICORCA/OBJECTS/HTZSEESAW";
						break;
					case 21:
					case 23:
					case 26:
						break;
					case 22:
						text = "SONICORCA/OBJECTS/HTZVINELIFT";
						obj = new
						{
							Duration = (int)(originalPlacement.SubType * 8),
							Direction = (originalPlacement.FlipX ? "left" : "right")
						};
						vector2i.Y += 152;
						break;
					case 24:
						text = "SONICORCA/OBJECTS/EHZPLATFORM";
						if ((originalPlacement.SubType >> 4 & 1) != 0)
						{
							text = "SONICORCA/OBJECTS/EHZBLOCK";
						}
						switch (originalPlacement.SubType & 3)
						{
						case 1:
							obj = new
							{
								RadiusX = 256,
								TimePeriod = 256
							};
							break;
						case 2:
							obj = new
							{
								RadiusY = 256,
								TimePeriod = 256
							};
							break;
						case 3:
							obj = new
							{
								Falling = true
							};
							break;
						}
						break;
					case 25:
					{
						text = "SONICORCA/OBJECTS/CPZPLATFORM";
						bool flag = (originalPlacement.SubType >> 4 & 1) == 0;
						switch (originalPlacement.SubType & 7)
						{
						case 0:
							obj = new
							{
								Size = (flag ? "large" : "small"),
								RadiusX = 256,
								TimePeriod = 256
							};
							break;
						case 1:
							vector2i += new Vector2i(-192, 0);
							obj = new
							{
								Size = (flag ? "large" : "small"),
								RadiusX = 192,
								TimePeriod = 440,
								TimeOffset = 110
							};
							break;
						case 2:
							vector2i += new Vector2i(0, -256);
							obj = new
							{
								Size = (flag ? "large" : "small"),
								RadiusY = 256,
								TimePeriod = 360,
								TimeOffset = 90
							};
							break;
						case 6:
							vector2i += new Vector2i(0, -384);
							obj = new
							{
								Size = (flag ? "large" : "small"),
								RadiusY = 384,
								TimePeriod = 312,
								TimeOffset = 78
							};
							break;
						case 7:
							vector2i += new Vector2i(0, -392);
							obj = new
							{
								Size = (flag ? "large" : "small"),
								RadiusY = 392,
								TimePeriod = 316,
								TimeOffset = 79
							};
							break;
						}
						break;
					}
					case 27:
						text = "SONICORCA/OBJECTS/CPZSPEEDBOOSTER";
						obj = new
						{
							Strength = (new int[]
							{
								64,
								40
							})[(originalPlacement.SubType & 2) >> 1] * (originalPlacement.FlipX ? -1 : 1)
						};
						break;
					case 28:
						switch (originalPlacement.SubType)
						{
						case 2:
							text = "SONICORCA/OBJECTS/EHZBRIDGE/STAKE";
							break;
						case 4:
							text = "SONICORCA/OBJECTS/HTZVINELIFT/PILLAR";
							break;
						case 5:
							text = "SONICORCA/OBJECTS/HTZVINELIFT/PILLAR";
							obj = new
							{
								Right = true
							};
							break;
						}
						break;
					case 29:
						text = "SONICORCA/OBJECTS/CPZBLOBS";
						obj = new
						{
							Count = (int)(originalPlacement.SubType & 15),
							Type = (((originalPlacement.SubType & 240) != 0) ? "straight" : "arc")
						};
						break;
					case 30:
						text = "SONICORCA/OBJECTS/CPZTUBEENTRANCE";
						obj = new
						{
							Subtype = originalPlacement.SubType
						};
						break;
					default:
						if (type == 38)
						{
							text = "SONICORCA/OBJECTS/MONITOR";
							obj = new
							{
								Contents = (new string[]
								{
									"none",
									"life",
									"life",
									"robotnik",
									"ring",
									"speedshoes",
									"barrier",
									"invincibility",
									"swapplaces",
									"random"
								})[(int)originalPlacement.SubType]
							};
						}
						break;
					}
				}
				else if (type != 45)
				{
					if (type == 50)
					{
						text = "SONICORCA/OBJECTS/HTZROCK";
					}
				}
				else
				{
					text = "SONICORCA/OBJECTS/HTZDOOR";
				}
			}
			else if (type <= 107)
			{
				if (type != 54)
				{
					switch (type)
					{
					case 62:
						text = "SONICORCA/OBJECTS/CAPSULE";
						break;
					case 63:
						break;
					case 64:
						text = "SONICORCA/OBJECTS/SPRINGBOARD";
						if (originalPlacement.FlipX)
						{
							obj = new
							{
								flipX = true
							};
						}
						break;
					case 65:
					{
						text = "SONICORCA/OBJECTS/SPRING";
						int direction = 0;
						switch (originalPlacement.SubType >> 4 & 7)
						{
						case 1:
							direction = (originalPlacement.FlipX ? 6 : 2);
							break;
						case 2:
							direction = 4;
							break;
						case 3:
							direction = (originalPlacement.FlipX ? 7 : 1);
							break;
						case 4:
							direction = (originalPlacement.FlipX ? 5 : 3);
							break;
						}
						obj = new
						{
							Strength = (((originalPlacement.SubType & 2) != 0) ? 40 : 64),
							Direction = direction
						};
						break;
					}
					default:
						if (type == 107)
						{
							text = "SONICORCA/OBJECTS/CPZBLOCK";
							obj = new
							{
								Type = originalPlacement.SubType
							};
						}
						break;
					}
				}
				else
				{
					text = "SONICORCA/OBJECTS/SPIKES";
				}
			}
			else if (type <= 132)
			{
				switch (type)
				{
				case 120:
					text = "SONICORCA/OBJECTS/CPZBLOCK";
					obj = new
					{
						Type = "stairs " + originalPlacement.SubType
					};
					break;
				case 121:
					text = "SONICORCA/OBJECTS/STARPOST";
					obj = new
					{
						Index = originalPlacement.SubType
					};
					vector2i.Y -= 32;
					break;
				case 122:
					break;
				case 123:
					text = "SONICORCA/OBJECTS/CPZTUBESPRING";
					obj = new
					{
						Type = originalPlacement.SubType
					};
					break;
				default:
					if (type == 132)
					{
						text = "SONICORCA/OBJECTS/FORCESPINBALL";
					}
					break;
				}
			}
			else
			{
				switch (type)
				{
				case 146:
					text = "SONICORCA/OBJECTS/SPIKER";
					if (originalPlacement.FlipY)
					{
						vector2i.Y += 64;
					}
					else
					{
						vector2i.Y -= 64;
					}
					obj = new
					{
						UpsideDown = originalPlacement.FlipY
					};
					break;
				case 147:
					break;
				case 148:
				case 150:
					text = "SONICORCA/OBJECTS/REXON";
					break;
				case 149:
					text = "SONICORCA/OBJECTS/SOL";
					break;
				default:
					switch (type)
					{
					case 165:
						text = "SONICORCA/OBJECTS/SPINY";
						break;
					case 166:
						text = "SONICORCA/OBJECTS/SPINY";
						obj = new
						{
							Wall = true
						};
						break;
					case 167:
						text = "SONICORCA/OBJECTS/GRABBER";
						break;
					}
					break;
				}
			}
			if (text == null)
			{
				return null;
			}
			if (obj == null)
			{
				return new ObjectPlacement(text, -1, vector2i);
			}
			return new ObjectPlacement(text, -1, vector2i, obj);
		}

		// Token: 0x020001BB RID: 443
		public class OriginalObjectPlacement
		{
			// Token: 0x170004FE RID: 1278
			// (get) Token: 0x06001291 RID: 4753 RVA: 0x000482B9 File Offset: 0x000464B9
			public Vector2i Position
			{
				get
				{
					return this._position;
				}
			}

			// Token: 0x170004FF RID: 1279
			// (get) Token: 0x06001292 RID: 4754 RVA: 0x000482C1 File Offset: 0x000464C1
			public bool Respawn
			{
				get
				{
					return this._respawn;
				}
			}

			// Token: 0x17000500 RID: 1280
			// (get) Token: 0x06001293 RID: 4755 RVA: 0x000482C9 File Offset: 0x000464C9
			public bool FlipX
			{
				get
				{
					return this._flipX;
				}
			}

			// Token: 0x17000501 RID: 1281
			// (get) Token: 0x06001294 RID: 4756 RVA: 0x000482D1 File Offset: 0x000464D1
			public bool FlipY
			{
				get
				{
					return this._flipY;
				}
			}

			// Token: 0x17000502 RID: 1282
			// (get) Token: 0x06001295 RID: 4757 RVA: 0x000482D9 File Offset: 0x000464D9
			public byte Type
			{
				get
				{
					return this._type;
				}
			}

			// Token: 0x17000503 RID: 1283
			// (get) Token: 0x06001296 RID: 4758 RVA: 0x000482E1 File Offset: 0x000464E1
			public byte SubType
			{
				get
				{
					return this._subtype;
				}
			}

			// Token: 0x06001297 RID: 4759 RVA: 0x000482EC File Offset: 0x000464EC
			public OriginalObjectPlacement(byte[] data)
			{
				this._position = new Vector2i((int)data[0] << 8 | (int)data[1], (int)(data[2] & 15) << 8 | (int)data[3]);
				this._respawn = ((data[2] & 128) == 0);
				this._flipX = ((data[2] & 32) > 0);
				this._flipY = ((data[2] & 64) > 0);
				this._type = data[4];
				this._subtype = data[5];
			}

			// Token: 0x04000A69 RID: 2665
			private readonly Vector2i _position;

			// Token: 0x04000A6A RID: 2666
			private readonly bool _respawn;

			// Token: 0x04000A6B RID: 2667
			private readonly bool _flipX;

			// Token: 0x04000A6C RID: 2668
			private readonly bool _flipY;

			// Token: 0x04000A6D RID: 2669
			private readonly byte _type;

			// Token: 0x04000A6E RID: 2670
			private readonly byte _subtype;
		}
	}
}
