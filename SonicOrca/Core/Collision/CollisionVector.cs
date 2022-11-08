using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SonicOrca.Geometry;
using SonicOrca.Graphics;

namespace SonicOrca.Core.Collision
{
	// Token: 0x0200019C RID: 412
	public class CollisionVector : IBounds
	{
		// Token: 0x170004A3 RID: 1187
		// (get) Token: 0x06001195 RID: 4501 RVA: 0x00045A01 File Offset: 0x00043C01
		// (set) Token: 0x06001196 RID: 4502 RVA: 0x00045A09 File Offset: 0x00043C09
		public ActiveObject Owner { get; set; }

		// Token: 0x170004A4 RID: 1188
		// (get) Token: 0x06001197 RID: 4503 RVA: 0x00045A12 File Offset: 0x00043C12
		// (set) Token: 0x06001198 RID: 4504 RVA: 0x00045A1A File Offset: 0x00043C1A
		public Vector2i RelativeA { get; set; }

		// Token: 0x170004A5 RID: 1189
		// (get) Token: 0x06001199 RID: 4505 RVA: 0x00045A23 File Offset: 0x00043C23
		// (set) Token: 0x0600119A RID: 4506 RVA: 0x00045A2B File Offset: 0x00043C2B
		public Vector2i RelativeB { get; set; }

		// Token: 0x170004A6 RID: 1190
		// (get) Token: 0x0600119B RID: 4507 RVA: 0x00045A34 File Offset: 0x00043C34
		// (set) Token: 0x0600119C RID: 4508 RVA: 0x00045A3C File Offset: 0x00043C3C
		public uint Paths { get; set; }

		// Token: 0x170004A7 RID: 1191
		// (get) Token: 0x0600119D RID: 4509 RVA: 0x00045A45 File Offset: 0x00043C45
		// (set) Token: 0x0600119E RID: 4510 RVA: 0x00045A4D File Offset: 0x00043C4D
		public CollisionFlags Flags { get; set; }

		// Token: 0x170004A8 RID: 1192
		// (get) Token: 0x0600119F RID: 4511 RVA: 0x00045A56 File Offset: 0x00043C56
		// (set) Token: 0x060011A0 RID: 4512 RVA: 0x00045A5E File Offset: 0x00043C5E
		public int Id { get; set; }

		// Token: 0x170004A9 RID: 1193
		// (get) Token: 0x060011A1 RID: 4513 RVA: 0x00045A67 File Offset: 0x00043C67
		// (set) Token: 0x060011A2 RID: 4514 RVA: 0x00045A6F File Offset: 0x00043C6F
		public double Angle { get; private set; }

		// Token: 0x170004AA RID: 1194
		// (get) Token: 0x060011A3 RID: 4515 RVA: 0x00045A78 File Offset: 0x00043C78
		// (set) Token: 0x060011A4 RID: 4516 RVA: 0x00045A80 File Offset: 0x00043C80
		public int FlipX { get; private set; }

		// Token: 0x170004AB RID: 1195
		// (get) Token: 0x060011A5 RID: 4517 RVA: 0x00045A89 File Offset: 0x00043C89
		// (set) Token: 0x060011A6 RID: 4518 RVA: 0x00045A91 File Offset: 0x00043C91
		public int FlipY { get; private set; }

		// Token: 0x170004AC RID: 1196
		// (get) Token: 0x060011A7 RID: 4519 RVA: 0x00045A9A File Offset: 0x00043C9A
		// (set) Token: 0x060011A8 RID: 4520 RVA: 0x00045AA2 File Offset: 0x00043CA2
		public CollisionMode Mode { get; private set; }

		// Token: 0x170004AD RID: 1197
		// (get) Token: 0x060011A9 RID: 4521 RVA: 0x00045AAC File Offset: 0x00043CAC
		public int Left
		{
			get
			{
				if (this.Owner != null)
				{
					return this._left + this.Owner.Position.X;
				}
				return this._left;
			}
		}

		// Token: 0x170004AE RID: 1198
		// (get) Token: 0x060011AA RID: 4522 RVA: 0x00045AE4 File Offset: 0x00043CE4
		public int Top
		{
			get
			{
				if (this.Owner != null)
				{
					return this._top + this.Owner.Position.Y;
				}
				return this._top;
			}
		}

		// Token: 0x170004AF RID: 1199
		// (get) Token: 0x060011AB RID: 4523 RVA: 0x00045B1C File Offset: 0x00043D1C
		public int Right
		{
			get
			{
				if (this.Owner != null)
				{
					return this._right + this.Owner.Position.X;
				}
				return this._right;
			}
		}

		// Token: 0x170004B0 RID: 1200
		// (get) Token: 0x060011AC RID: 4524 RVA: 0x00045B54 File Offset: 0x00043D54
		public int Bottom
		{
			get
			{
				if (this.Owner != null)
				{
					return this._bottom + this.Owner.Position.Y;
				}
				return this._bottom;
			}
		}

		// Token: 0x170004B1 RID: 1201
		// (get) Token: 0x060011AD RID: 4525 RVA: 0x00045B8A File Offset: 0x00043D8A
		// (set) Token: 0x060011AE RID: 4526 RVA: 0x00045B92 File Offset: 0x00043D92
		public int Width { get; private set; }

		// Token: 0x170004B2 RID: 1202
		// (get) Token: 0x060011AF RID: 4527 RVA: 0x00045B9B File Offset: 0x00043D9B
		// (set) Token: 0x060011B0 RID: 4528 RVA: 0x00045BA3 File Offset: 0x00043DA3
		public int Height { get; private set; }

		// Token: 0x170004B3 RID: 1203
		// (get) Token: 0x060011B1 RID: 4529 RVA: 0x00045BAC File Offset: 0x00043DAC
		// (set) Token: 0x060011B2 RID: 4530 RVA: 0x00045BB4 File Offset: 0x00043DB4
		public double Ratio { get; private set; }

		// Token: 0x170004B4 RID: 1204
		// (get) Token: 0x060011B3 RID: 4531 RVA: 0x00045BBD File Offset: 0x00043DBD
		public Vector2i AbsoluteA
		{
			get
			{
				if (this.Owner != null)
				{
					return this.RelativeA + this.Owner.Position;
				}
				return this.RelativeA;
			}
		}

		// Token: 0x170004B5 RID: 1205
		// (get) Token: 0x060011B4 RID: 4532 RVA: 0x00045BE4 File Offset: 0x00043DE4
		public Vector2i AbsoluteB
		{
			get
			{
				if (this.Owner != null)
				{
					return this.RelativeB + this.Owner.Position;
				}
				return this.RelativeB;
			}
		}

		// Token: 0x170004B6 RID: 1206
		// (get) Token: 0x060011B5 RID: 4533 RVA: 0x00045C0B File Offset: 0x00043E0B
		public Vector2i AB
		{
			get
			{
				return this.RelativeB - this.RelativeA;
			}
		}

		// Token: 0x170004B7 RID: 1207
		// (get) Token: 0x060011B6 RID: 4534 RVA: 0x00045C20 File Offset: 0x00043E20
		public double Length
		{
			get
			{
				return (double)this.AB.Length;
			}
		}

		// Token: 0x170004B8 RID: 1208
		// (get) Token: 0x060011B7 RID: 4535 RVA: 0x00045C3C File Offset: 0x00043E3C
		public double CollisionAngle
		{
			get
			{
				return this.Angle + 3.141592653589793;
			}
		}

		// Token: 0x060011B8 RID: 4536 RVA: 0x00045C4E File Offset: 0x00043E4E
		public CollisionVector()
		{
		}

		// Token: 0x060011B9 RID: 4537 RVA: 0x00045C6E File Offset: 0x00043E6E
		public CollisionVector(Vector2i a, Vector2i b, uint paths = 4294967295U, CollisionFlags flags = (CollisionFlags)0) : this(null, a, b, paths, flags)
		{
		}

		// Token: 0x060011BA RID: 4538 RVA: 0x00045C7C File Offset: 0x00043E7C
		public CollisionVector(ActiveObject owner, Vector2i a, Vector2i b, uint paths = 4294967295U, CollisionFlags flags = (CollisionFlags)0)
		{
			this.Owner = owner;
			this.RelativeA = a;
			this.RelativeB = b;
			this.Paths = paths;
			this.Flags = flags;
		}

		// Token: 0x060011BB RID: 4539 RVA: 0x00045CCC File Offset: 0x00043ECC
		public static CollisionVector[] FromRectangle(Rectanglei rect)
		{
			return CollisionVector.FromRectangle(null, rect, uint.MaxValue, (CollisionFlags)0);
		}

		// Token: 0x060011BC RID: 4540 RVA: 0x00045CD8 File Offset: 0x00043ED8
		public static CollisionVector[] FromRectangle(ActiveObject owner, Rectanglei rect, uint paths = 4294967295U, CollisionFlags flags = (CollisionFlags)0)
		{
			return new CollisionVector[]
			{
				new CollisionVector(owner, new Vector2i(rect.X, rect.Y + rect.Height), new Vector2i(rect.X, rect.Y), paths, (CollisionFlags)0),
				new CollisionVector(owner, new Vector2i(rect.X, rect.Y), new Vector2i(rect.X + rect.Width, rect.Y), paths, (CollisionFlags)0),
				new CollisionVector(owner, new Vector2i(rect.X + rect.Width, rect.Y), new Vector2i(rect.X + rect.Width, rect.Y + rect.Height), paths, (CollisionFlags)0),
				new CollisionVector(owner, new Vector2i(rect.X + rect.Width, rect.Y + rect.Height), new Vector2i(rect.X, rect.Y + rect.Height), paths, (CollisionFlags)0)
			};
		}

		// Token: 0x060011BD RID: 4541 RVA: 0x00045DF0 File Offset: 0x00043FF0
		public static void UpdateRectangle(CollisionVector[] vectors, Rectanglei rect)
		{
			vectors[0].RelativeA = new Vector2i(rect.X, rect.Y + rect.Height);
			vectors[0].RelativeB = new Vector2i(rect.X, rect.Y);
			vectors[1].RelativeA = new Vector2i(rect.X, rect.Y);
			vectors[1].RelativeB = new Vector2i(rect.X + rect.Width, rect.Y);
			vectors[2].RelativeA = new Vector2i(rect.X + rect.Width, rect.Y);
			vectors[2].RelativeB = new Vector2i(rect.X + rect.Width, rect.Y + rect.Height);
			vectors[3].RelativeA = new Vector2i(rect.X + rect.Width, rect.Y + rect.Height);
			vectors[3].RelativeB = new Vector2i(rect.X, rect.Y + rect.Height);
		}

		// Token: 0x170004B9 RID: 1209
		// (get) Token: 0x060011BE RID: 4542 RVA: 0x00045F18 File Offset: 0x00044118
		public Rectanglei Bounds
		{
			get
			{
				return Rectanglei.FromLTRB(Math.Min(this.AbsoluteA.X, this.AbsoluteB.X), Math.Min(this.AbsoluteA.Y, this.AbsoluteB.Y), Math.Max(this.AbsoluteA.X, this.AbsoluteB.X), Math.Max(this.AbsoluteA.Y, this.AbsoluteB.Y));
			}
		}

		// Token: 0x170004BA RID: 1210
		// (get) Token: 0x060011BF RID: 4543 RVA: 0x00045FAE File Offset: 0x000441AE
		public bool IsWall
		{
			get
			{
				return this.Mode == CollisionMode.Left || this.Mode == CollisionMode.Right;
			}
		}

		// Token: 0x170004BB RID: 1211
		// (get) Token: 0x060011C0 RID: 4544 RVA: 0x00045FC4 File Offset: 0x000441C4
		public bool IsFloor
		{
			get
			{
				return !this.IsWall;
			}
		}

		// Token: 0x170004BC RID: 1212
		// (get) Token: 0x060011C1 RID: 4545 RVA: 0x00045FCF File Offset: 0x000441CF
		public bool IsThereConnectionA
		{
			get
			{
				return this._connectionA.Any((CollisionVector x) => x != null);
			}
		}

		// Token: 0x170004BD RID: 1213
		// (get) Token: 0x060011C2 RID: 4546 RVA: 0x00045FFB File Offset: 0x000441FB
		public bool IsThereConnectionB
		{
			get
			{
				return this._connectionB.Any((CollisionVector x) => x != null);
			}
		}

		// Token: 0x060011C3 RID: 4547 RVA: 0x00046028 File Offset: 0x00044228
		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			bool isThereConnectionA = this.IsThereConnectionA;
			bool isThereConnectionB = this.IsThereConnectionB;
			stringBuilder.AppendFormat("A = {0}, B = {1}", this.AbsoluteA, this.AbsoluteB);
			if (isThereConnectionA && isThereConnectionB)
			{
				stringBuilder.Append(" Connected (A, B)");
			}
			else if (isThereConnectionA)
			{
				stringBuilder.Append(" Connected (A)");
			}
			else if (isThereConnectionB)
			{
				stringBuilder.Append(" Connected (B)");
			}
			return stringBuilder.ToString();
		}

		// Token: 0x060011C4 RID: 4548 RVA: 0x000460A4 File Offset: 0x000442A4
		public CollisionVector GetConnectionA(int path)
		{
			if (this._connectionA.Length <= path)
			{
				return null;
			}
			return this._connectionA[path];
		}

		// Token: 0x060011C5 RID: 4549 RVA: 0x000460BB File Offset: 0x000442BB
		public CollisionVector GetConnectionB(int path)
		{
			if (this._connectionB.Length <= path)
			{
				return null;
			}
			return this._connectionB[path];
		}

		// Token: 0x060011C6 RID: 4550 RVA: 0x000460D2 File Offset: 0x000442D2
		public void SetConnectionA(int path, CollisionVector v)
		{
			if (this._connectionA.Length <= path)
			{
				Array.Resize<CollisionVector>(ref this._connectionA, path);
			}
			this._connectionA[path] = v;
		}

		// Token: 0x060011C7 RID: 4551 RVA: 0x000460F4 File Offset: 0x000442F4
		public void SetConnectionB(int path, CollisionVector v)
		{
			if (this._connectionB.Length <= path)
			{
				Array.Resize<CollisionVector>(ref this._connectionB, path);
			}
			this._connectionB[path] = v;
		}

		// Token: 0x060011C8 RID: 4552 RVA: 0x00046118 File Offset: 0x00044318
		public void UpdateDerrivedFields()
		{
			if (this.RelativeA.X < this.RelativeB.X)
			{
				this._left = this.RelativeA.X;
				this._right = this.RelativeB.X;
				this.FlipX = 1;
			}
			else
			{
				this._left = this.RelativeB.X;
				this._right = this.RelativeA.X;
				this.FlipX = ((this._left == this._right) ? 0 : -1);
			}
			if (this.AbsoluteA.Y < this.AbsoluteB.Y)
			{
				this._top = this.RelativeA.Y;
				this._bottom = this.RelativeB.Y;
				this.FlipY = 1;
			}
			else
			{
				this._top = this.RelativeB.Y;
				this._bottom = this.RelativeA.Y;
				this.FlipY = ((this._top == this._bottom) ? 0 : -1);
			}
			this.Width = this.Right - this.Left;
			this.Height = this.Bottom - this.Top;
			if (this.Width >= this.Height)
			{
				this.Mode = ((this.FlipX > 0) ? CollisionMode.Top : CollisionMode.Bottom);
			}
			else
			{
				this.Mode = ((this.FlipY > 0) ? CollisionMode.Right : CollisionMode.Left);
			}
			double num = (double)(this.AbsoluteB.X - this.AbsoluteA.X);
			double num2 = (double)(this.AbsoluteB.Y - this.AbsoluteA.Y);
			this.Ratio = ((num2 == 0.0) ? 0.0 : (num / num2));
			this.Angle = (this.AbsoluteB - this.AbsoluteA).Angle;
		}

		// Token: 0x060011C9 RID: 4553 RVA: 0x0004631C File Offset: 0x0004451C
		public void ResetConnections()
		{
			Array.Clear(this._connectionA, 0, this._connectionA.Length);
			Array.Clear(this._connectionB, 0, this._connectionB.Length);
		}

		// Token: 0x060011CA RID: 4554 RVA: 0x00046346 File Offset: 0x00044546
		public bool HasPath(int path)
		{
			return ((ulong)this.Paths & (ulong)(1L << (path & 31))) > 0UL;
		}

		// Token: 0x060011CB RID: 4555 RVA: 0x0004635C File Offset: 0x0004455C
		public bool FindFloor(Vector2 sensorPosition, double sensorSize, int path, out CollisionInfo info)
		{
			bool flag = false;
			double num = this.Angle;
			double num2 = sensorPosition.X - Math.Sin(num) * sensorSize;
			double num3 = (double)this.AbsoluteA.Y;
			if (this.GetConnectionB(path) != null && (num2 - (double)this.AbsoluteB.X) * (double)this.FlipX > 0.0)
			{
				num2 = (double)this.AbsoluteB.X;
				flag = true;
			}
			else if (this.GetConnectionA(path) != null && (num2 - (double)this.AbsoluteA.X) * (double)this.FlipX < 0.0)
			{
				num2 = (double)this.AbsoluteA.X;
				flag = true;
			}
			if (flag)
			{
				num = Math.Asin(MathX.Clamp(-1.0, (num2 - sensorPosition.X) / sensorSize, 1.0)) * (double)this.FlipX;
				if (this.FlipX < 0)
				{
					num += 3.141592653589793;
				}
			}
			if (this.Height > 0)
			{
				num3 += (num2 - (double)this.AbsoluteA.X) / this.Ratio;
			}
			double num4 = num3 - Math.Cos(num) * sensorSize - sensorPosition.Y;
			info = new CollisionInfo(this, new Vector2(num2, num3), num4, num);
			return num4 * (double)this.FlipX < 0.0;
		}

		// Token: 0x060011CC RID: 4556 RVA: 0x000464C4 File Offset: 0x000446C4
		public bool FindWall(Vector2 sensorPosition, double sensorSize, int path, out CollisionInfo info)
		{
			bool flag = false;
			double num = this.Angle;
			double num2 = (double)this.AbsoluteA.X;
			double num3 = sensorPosition.Y + Math.Cos(num) * sensorSize;
			if (this.GetConnectionB(path) != null && (num3 - (double)this.AbsoluteB.Y) * (double)this.FlipY > 0.0)
			{
				num3 = (double)this.AbsoluteB.Y;
				flag = true;
			}
			else if (this.GetConnectionA(path) != null && (num3 - (double)this.AbsoluteA.Y) * (double)this.FlipY < 0.0)
			{
				num3 = (double)this.AbsoluteA.Y;
				flag = true;
			}
			if (flag)
			{
				num = Math.Asin(MathX.Clamp(-1.0, (num3 - sensorPosition.Y) / sensorSize, 1.0)) * (double)this.FlipY;
				if (this.FlipY > 0)
				{
					num += 3.141592653589793;
				}
				num -= 1.5707963267948966;
			}
			if (this.Width > 0)
			{
				num2 += (num3 - (double)this.AbsoluteA.Y) * this.Ratio;
			}
			double num4 = num2 + Math.Sin(num) * sensorSize - sensorPosition.X;
			info = new CollisionInfo(this, new Vector2(num2, num3), num4, num);
			return num4 * (double)this.FlipY > 0.0;
		}

		// Token: 0x060011CD RID: 4557 RVA: 0x00046635 File Offset: 0x00044835
		public static bool TestConnection(CollisionVector a, CollisionVector b)
		{
			return a.Mode == b.Mode || Math.Abs(MathX.DifferenceRadians(a.Angle, b.Angle)) <= 1.0471975511965976;
		}

		// Token: 0x060011CE RID: 4558 RVA: 0x0004666C File Offset: 0x0004486C
		public static bool OnSamePath(CollisionVector a, CollisionVector b, int path)
		{
			if (a == b)
			{
				return true;
			}
			if (a.Mode != b.Mode)
			{
				return false;
			}
			if (a.IsWall ? ((a.AbsoluteA.Y - b.AbsoluteA.Y) * a.FlipY > 0) : ((a.AbsoluteA.X - b.AbsoluteA.X) * a.FlipX > 0))
			{
				for (CollisionVector connectionB = b.GetConnectionB(path); connectionB != null; connectionB = connectionB.GetConnectionB(path))
				{
					if (connectionB == a)
					{
						return true;
					}
					if (connectionB.Mode != b.Mode)
					{
						return false;
					}
				}
			}
			else
			{
				for (CollisionVector connectionA = b.GetConnectionA(path); connectionA != null; connectionA = connectionA.GetConnectionA(path))
				{
					if (connectionA == a)
					{
						return true;
					}
					if (connectionA.Mode != b.Mode)
					{
						return false;
					}
				}
			}
			return false;
		}

		// Token: 0x060011CF RID: 4559 RVA: 0x00046744 File Offset: 0x00044944
		public void Draw(Renderer renderer, Viewport viewport)
		{
			Vector2i absoluteA = this.AbsoluteA;
			Vector2i absoluteB = this.AbsoluteB;
			if (absoluteA.X < viewport.Bounds.X && absoluteB.X < viewport.Bounds.X)
			{
				return;
			}
			if (absoluteA.X >= viewport.Bounds.Right && absoluteB.X >= viewport.Bounds.Right)
			{
				return;
			}
			if (absoluteA.Y < viewport.Bounds.Y && absoluteB.Y < viewport.Bounds.Y)
			{
				return;
			}
			if (absoluteA.Y >= viewport.Bounds.Bottom && absoluteB.Y >= viewport.Bounds.Bottom)
			{
				return;
			}
			absoluteA.X -= viewport.Bounds.X;
			absoluteA.Y -= viewport.Bounds.Y;
			absoluteB.X -= viewport.Bounds.X;
			absoluteB.Y -= viewport.Bounds.Y;
			this.Draw(renderer, absoluteA, absoluteB, viewport.Scale);
		}

		// Token: 0x060011D0 RID: 4560 RVA: 0x000468A4 File Offset: 0x00044AA4
		private void Draw(Renderer renderer, Vector2 pa, Vector2 pb, Vector2 scale)
		{
			pa = (Vector2i)(pa * scale);
			pb = (Vector2i)(pb * scale);
			I2dRenderer i2dRenderer = renderer.Get2dRenderer();
			Colour colour = (this.Owner == null) ? Colours.White : Colours.Yellow;
			if (this.Owner == null && this.Paths == 1U)
			{
				colour = Colours.Aqua;
			}
			else if (this.Owner == null && this.Paths == 2U)
			{
				colour = Colours.Fuchsia;
			}
			i2dRenderer.RenderLine(colour, pa, pb, 1.0);
			double num = 16.0 * scale.X;
			if (num > 2.0)
			{
				double num2 = this.Angle - 1.5707963267948966;
				Vector2 a = new Vector2((pb.X - pa.X) / 2.0 + pa.X, (pb.Y - pa.Y) / 2.0 + pa.Y);
				Vector2 b = a + new Vector2(Math.Cos(num2) * num, Math.Sin(num2) * num);
				i2dRenderer.RenderLine(colour, a, b, 1.0);
			}
			double num3 = 8.0 * scale.X;
			int sectors = (int)(8.0 * scale.X);
			if (num3 > 1.0)
			{
				if (this.IsThereConnectionA)
				{
					i2dRenderer.RenderEllipse(colour, pa, 0.0, num3 + 0.5, sectors);
				}
				else
				{
					i2dRenderer.RenderRectangle(colour, new Rectangle(pa.X - num3, pa.Y - num3, num3 * 2.0, num3 * 2.0), 1.0);
				}
				if (this.IsThereConnectionB)
				{
					i2dRenderer.RenderEllipse(colour, pb, 0.0, num3 + 0.5, sectors);
					return;
				}
				i2dRenderer.RenderRectangle(colour, new Rectangle(pb.X - num3, pb.Y - num3, num3 * 2.0, num3 * 2.0), 1.0);
			}
		}

		// Token: 0x060011D1 RID: 4561 RVA: 0x00046AE8 File Offset: 0x00044CE8
		public static bool GetIntersection(CollisionVector a, CollisionVector b, out Vector2 intersection)
		{
			Vector2 vector = a.AbsoluteA;
			Vector2 vector2 = a.AbsoluteB;
			Vector2 vector3 = b.AbsoluteA;
			Vector2 vector4 = b.AbsoluteB;
			Vector2 vector5 = new Vector2(vector2.X - vector.X, vector2.Y - vector.Y);
			Vector2 vector6 = new Vector2(vector4.X - vector3.X, vector4.Y - vector3.Y);
			double num = (-vector5.Y * (vector.X - vector3.X) + vector5.X * (vector.Y - vector3.Y)) / (-vector6.X * vector5.Y + vector5.X * vector6.Y);
			double num2 = (vector6.X * (vector.Y - vector3.Y) - vector6.Y * (vector.X - vector3.X)) / (-vector6.X * vector5.Y + vector5.X * vector6.Y);
			if (num >= 0.0 && num <= 1.0 && num2 >= 0.0 && num2 <= 1.0)
			{
				intersection = new Vector2(vector.X + num2 * vector5.X, vector.Y + num2 * vector5.Y);
				return true;
			}
			intersection = default(Vector2);
			return false;
		}

		// Token: 0x060011D2 RID: 4562 RVA: 0x00046C84 File Offset: 0x00044E84
		public static bool Intersects(CollisionVector a, CollisionVector b)
		{
			Vector2 vector;
			return CollisionVector.GetIntersection(a, b, out vector);
		}

		// Token: 0x060011D3 RID: 4563 RVA: 0x00046C9A File Offset: 0x00044E9A
		public static IEnumerable<CollisionInfo> GetCollisions(ActiveObject obj, int radialSensorSize, uint paths = 4294967295U)
		{
			return CollisionVector.GetCollisions(obj, radialSensorSize, radialSensorSize, paths);
		}

		// Token: 0x060011D4 RID: 4564 RVA: 0x00046CA8 File Offset: 0x00044EA8
		public static IEnumerable<CollisionInfo> GetCollisions(ActiveObject obj, int floorSensorSize, int wallSensorSize, uint paths = 4294967295U)
		{
			Vector2i vector2i = (Vector2i)obj.PositionPrecise;
			Rectanglei floorRect = Rectanglei.FromLTRB(vector2i.X - wallSensorSize, vector2i.Y - floorSensorSize, vector2i.X + wallSensorSize, vector2i.Y + floorSensorSize);
			Rectanglei wallRect = Rectanglei.FromLTRB(vector2i.X - wallSensorSize, vector2i.Y - wallSensorSize, vector2i.X + wallSensorSize, vector2i.Y + wallSensorSize);
			return CollisionVector.GetCollisions(obj, floorSensorSize, wallSensorSize, floorRect, wallRect, paths, CollisionMode.Air, null);
		}

		// Token: 0x060011D5 RID: 4565 RVA: 0x00046D22 File Offset: 0x00044F22
		public static IEnumerable<CollisionInfo> GetCollisions(ActiveObject obj, int floorSensorSize, int wallSensorSize, Rectanglei floorRect, Rectanglei wallRect, uint paths, CollisionMode mode, CollisionVector groundVector)
		{
			int numPaths = obj.Level.Map.CollisionPathLayers.Count;
			Rectanglei bounds = new Rectanglei(obj.Position.X - wallSensorSize * 2, obj.Position.Y - floorSensorSize * 2, wallSensorSize * 4, floorSensorSize * 4);
			foreach (CollisionVector t in obj.Level.CollisionTable.GetPossibleCollisionIntersections(bounds, true, true))
			{
				if ((t.Paths & paths) != 0U)
				{
					int num;
					for (int i = 0; i < numPaths; i = num + 1)
					{
						if (((ulong)t.Paths & (ulong)(1L << (i & 31))) != 0UL)
						{
							CollisionInfo collisionInfo2;
							if (t.IsWall)
							{
								CollisionInfo collisionInfo;
								if (CollisionVector.RectangleCheckCollision(wallRect, t.Bounds) && t.FindWall(obj.PositionPrecise, (double)wallSensorSize, i, out collisionInfo) && !CollisionVector.CheckSolidAngle(t, obj.LastPositionPrecise, collisionInfo.Touch) && !CollisionVector.CheckSolidAngle(t, obj.LastPositionPrecise, obj.PositionPrecise))
								{
									yield return collisionInfo;
									break;
								}
							}
							else if (CollisionVector.RectangleCheckCollision(floorRect, t.Bounds) && t.FindFloor(obj.PositionPrecise, (double)floorSensorSize, i, out collisionInfo2) && !CollisionVector.CheckSolidAngle(t, obj.LastPositionPrecise, collisionInfo2.Touch) && !CollisionVector.CheckSolidAngle(t, obj.LastPositionPrecise, obj.PositionPrecise))
							{
								yield return collisionInfo2;
								break;
							}
						}
						num = i;
					}
					t = null;
				}
			}
			IEnumerator<CollisionVector> enumerator = null;
			yield break;
			yield break;
		}

		// Token: 0x060011D6 RID: 4566 RVA: 0x00046D58 File Offset: 0x00044F58
		private static bool CheckSolidAngle(CollisionVector t, Vector2 previousPosition, Vector2 point)
		{
			return point == previousPosition || MathX.DifferenceRadians((point - previousPosition).Angle, t.Angle) > 0.0;
		}

		// Token: 0x060011D7 RID: 4567 RVA: 0x00046D98 File Offset: 0x00044F98
		private static bool RectangleCheckCollision(Rectanglei a, Rectanglei b)
		{
			return a.X < b.X + b.Width && b.X < a.X + a.Width && a.Y < b.Y + b.Height && b.Y < a.Y + a.Height;
		}

		// Token: 0x040009EA RID: 2538
		public const uint AllPaths = 4294967295U;

		// Token: 0x040009EB RID: 2539
		private CollisionVector[] _connectionA = new CollisionVector[2];

		// Token: 0x040009EC RID: 2540
		private CollisionVector[] _connectionB = new CollisionVector[2];

		// Token: 0x040009F3 RID: 2547
		private int _left;

		// Token: 0x040009F4 RID: 2548
		private int _top;

		// Token: 0x040009F5 RID: 2549
		private int _right;

		// Token: 0x040009F6 RID: 2550
		private int _bottom;
	}
}
