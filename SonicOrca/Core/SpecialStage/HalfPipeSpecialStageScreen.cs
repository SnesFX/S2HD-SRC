using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using SonicOrca.Audio;
using SonicOrca.Geometry;
using SonicOrca.Graphics;
using SonicOrca.Input;
using SonicOrca.Menu;
using SonicOrca.Resources;

namespace SonicOrca.Core.SpecialStage
{
	// Token: 0x02000153 RID: 339
	internal class HalfPipeSpecialStageScreen : Screen
	{
		// Token: 0x06000E2A RID: 3626 RVA: 0x000365D4 File Offset: 0x000347D4
		public HalfPipeSpecialStageScreen(SonicOrcaGameContext gameContext)
		{
			this._gameContext = gameContext;
			this._graphicsContext = this._gameContext.Window.GraphicsContext;
			this._resourceSession = new ResourceSession(gameContext.ResourceTree);
		}

		// Token: 0x06000E2B RID: 3627 RVA: 0x00036648 File Offset: 0x00034848
		public override async Task LoadAsync(ScreenLoadingProgress progress, CancellationToken ct = default(CancellationToken))
		{
			this._resourceSession.PushDependency("SONICORCA/FONTS/HUD");
			this._resourceSession.PushDependency("SONICORCA/SPECIALSTAGE/HALFPIPE/BACKGROUND");
			this._resourceSession.PushDependency("SONICORCA/SPECIALSTAGE/HALFPIPE/FLOOR");
			this._resourceSession.PushDependency("SONICORCA/SPECIALSTAGE/HALFPIPE/BALL");
			this._resourceSession.PushDependency("SONICORCA/MUSIC/SPECIALSTAGE/S2");
			await this._resourceSession.LoadAsync(ct, false);
			this._font = this._gameContext.ResourceTree.GetLoadedResource<Font>("SONICORCA/FONTS/HUD");
			this._backgroundTexture = this._gameContext.ResourceTree.GetLoadedResource<ITexture>("SONICORCA/SPECIALSTAGE/HALFPIPE/BACKGROUND");
			this._floorTexture = this._gameContext.ResourceTree.GetLoadedResource<ITexture>("SONICORCA/SPECIALSTAGE/HALFPIPE/FLOOR");
			this._ballTexture = this._gameContext.ResourceTree.GetLoadedResource<ITexture>("SONICORCA/SPECIALSTAGE/HALFPIPE/BALL");
			this._musicSampleInfo = this._gameContext.ResourceTree.GetLoadedResource<SampleInfo>("SONICORCA/MUSIC/SPECIALSTAGE/S2");
		}

		// Token: 0x06000E2C RID: 3628 RVA: 0x00036698 File Offset: 0x00034898
		public override void Initialise()
		{
			this._pipeShader = OrcaShader.CreateFromFile(this._graphicsContext, "shaders/halfpipe/test.shader");
			this._objectShader = OrcaShader.CreateFromFile(this._graphicsContext, "shaders/halfpipe/object.shader");
			this._vertexBuffer = this._graphicsContext.CreateVertexBuffer(new int[]
			{
				3,
				2
			});
			this._projectionMatrix = Matrix4.Perspective(MathX.ToRadians(this._fov), 1.7777777777777777, 1.0, 1024.0);
			this.CreateTrackNodes();
		}

		// Token: 0x06000E2D RID: 3629 RVA: 0x00036728 File Offset: 0x00034928
		private void CreateTrackNodes()
		{
			double num = 0.0;
			Vector3 a = default(Vector3);
			foreach (HalfPipeSpecialStageScreen.SegmentGeometry segmentGeometry in this._layout)
			{
				double y = a.Y;
				double num2 = MathX.ToRadians(90.0);
				for (int j = 0; j < 28; j++)
				{
					switch (segmentGeometry)
					{
					case HalfPipeSpecialStageScreen.SegmentGeometry.Drop:
					{
						num2 -= MathX.ToRadians(6.428571428571429);
						double num3 = Math.Cos(num2) / -2.0;
						break;
					}
					case HalfPipeSpecialStageScreen.SegmentGeometry.Rise:
					{
						num2 += MathX.ToRadians(6.428571428571429);
						double num4 = Math.Cos(num2) / -2.0;
						break;
					}
					case HalfPipeSpecialStageScreen.SegmentGeometry.TurnLeft:
						num -= MathX.ToRadians(3.2142857142857144);
						break;
					case HalfPipeSpecialStageScreen.SegmentGeometry.TurnRight:
						num += MathX.ToRadians(3.2142857142857144);
						break;
					}
					Vector3 vector = a + new Vector3(Math.Sin(num), -Math.Cos(num2), Math.Cos(num)) * 2.0;
					double num5 = num2 - MathX.ToRadians(90.0);
					if (num5 > MathX.ToRadians(90.0))
					{
						num5 = MathX.ToRadians(180.0) - num5;
					}
					else if (num5 < MathX.ToRadians(-90.0))
					{
						num5 = MathX.ToRadians(-180.0) - num5;
					}
					this._trackNodes.Add(new HalfPipeSpecialStageScreen.TrackNode(vector, new Vector2(num, num5)));
					a = vector;
				}
			}
		}

		// Token: 0x06000E2E RID: 3630 RVA: 0x000368D0 File Offset: 0x00034AD0
		public override void Update()
		{
			KeyboardState keyboard = this._gameContext.Input.Pressed.Keyboard;
			if (keyboard[46])
			{
				this._fov += 1.0;
			}
			else if (keyboard[45])
			{
				this._fov -= 1.0;
			}
			if (this._ticks == 0)
			{
				this._musicInstance = new SampleInstance(this._gameContext, this._musicSampleInfo);
				this._musicInstance.Play();
			}
			if (this._ticks % 2 == 0)
			{
				this._currentTrackNode = (this._currentTrackNode + 1) % this._trackNodes.Count;
			}
			this.UpdateCamera();
			this._ticks++;
		}

		// Token: 0x06000E2F RID: 3631 RVA: 0x00036998 File Offset: 0x00034B98
		private void UpdateCamera()
		{
			int index = Math.Min(this._trackNodes.Count - 1, this._currentTrackNode + 1);
			double num = (double)(this._ticks % 2) / 2.0;
			HalfPipeSpecialStageScreen.TrackNode trackNode = this._trackNodes[this._currentTrackNode];
			HalfPipeSpecialStageScreen.TrackNode trackNode2 = this._trackNodes[index];
			Vector3 vector = trackNode.Position + new Vector3(0.0, -2.0, 0.0);
			Vector2 angle = trackNode.Angle;
			Vector3 a = trackNode2.Position + new Vector3(0.0, -2.0, 0.0);
			Vector2 angle2 = trackNode2.Angle;
			Vector3 camera = vector + (a - vector) * num;
			Vector2 vector2 = new Vector2(angle.X + (angle2.X - angle.X) * num, angle.Y + (angle2.Y - angle.Y) * num);
			Vector3 b = new Vector3(Math.Sin(vector2.X), Math.Sin(vector2.Y), Math.Cos(vector2.X));
			this._camera = camera;
			this._cameraTarget = this._camera + b;
		}

		// Token: 0x06000E30 RID: 3632 RVA: 0x00036AF8 File Offset: 0x00034CF8
		public override void Draw(Renderer renderer)
		{
			this.DrawBackground(renderer);
			this.DrawPipe(renderer);
			this.DrawHud(renderer);
		}

		// Token: 0x06000E31 RID: 3633 RVA: 0x00036B10 File Offset: 0x00034D10
		private void DrawBackground(Renderer renderer)
		{
			I2dRenderer i2dRenderer = renderer.Get2dRenderer();
			i2dRenderer.BlendMode = BlendMode.Alpha;
			i2dRenderer.Colour = Colours.White;
			i2dRenderer.ClipRectangle = new Rectangle(0.0, 0.0, 1920.0, 1080.0);
			i2dRenderer.RenderTexture(this._backgroundTexture, new Rectangle(0.0, 0.0, 1920.0, 1080.0), false, false);
			i2dRenderer.Deactivate();
		}

		// Token: 0x06000E32 RID: 3634 RVA: 0x00036BA0 File Offset: 0x00034DA0
		private void DrawPipe(Renderer renderer)
		{
			this._modelViewMatrix = Matrix4.LookAt(this._camera.X, this._camera.Y, -this._camera.Z, this._cameraTarget.X, this._cameraTarget.Y, -this._cameraTarget.Z, 0.0, 1.0, 0.0);
			this._modelViewMatrix *= Matrix4.CreateScale(1.0, 1.0, -1.0);
			this._graphicsContext.ClearDepthBuffer();
			this._graphicsContext.DepthTesting = true;
			List<HalfPipeSpecialStageScreen.TexturedQuad> list = new List<HalfPipeSpecialStageScreen.TexturedQuad>();
			double num = 8.0 / (double)this._floorTexture.Width;
			int num2 = (int)((double)this._floorTexture.Height * num / 2.0);
			Vector3[] array = null;
			for (int i = 0; i < this._trackNodes.Count; i++)
			{
				if (i >= this._currentTrackNode - 128)
				{
					if (i > this._currentTrackNode + 128)
					{
						break;
					}
					HalfPipeSpecialStageScreen.TrackNode trackNode = this._trackNodes[i];
					Matrix4 transform = Matrix4.Identity.RotateY(trackNode.Angle.X).Translate(trackNode.Position);
					Vector3[] array2 = (from x in this.GetCrossSection()
					select transform * x).ToArray<Vector3>();
					if (array != null)
					{
						for (int j = 0; j < array2.Length - 1; j++)
						{
							int num3 = i % num2;
							list.Add(new HalfPipeSpecialStageScreen.TexturedQuad(new Vector3[]
							{
								array2[j],
								array[j],
								array[j + 1],
								array2[j + 1]
							}, new Vector2[]
							{
								new Vector2((double)j / (double)(array2.Length - 1), 1.0 - (double)(num3 + 1) / (double)num2),
								new Vector2((double)j / (double)(array2.Length - 1), 1.0 - (double)num3 / (double)num2),
								new Vector2((double)(j + 1) / (double)(array2.Length - 1), 1.0 - (double)num3 / (double)num2),
								new Vector2((double)(j + 1) / (double)(array2.Length - 1), 1.0 - (double)(num3 + 1) / (double)num2)
							}, this._floorTexture));
						}
					}
					array = array2;
					if ((i + num2 / 2 + 1) % num2 == 0)
					{
						double num4 = 0.5;
						double num5 = 3.0;
						Func<Vector3, Vector3> <>9__1;
						for (int k = 0; k < 7; k++)
						{
							double num6 = (double)k * (MathX.ToRadians(180.0) / 6.0);
							Vector3 vector = new Vector3(-Math.Cos(num6) * num5, Math.Sin(num6) * num5, 0.0);
							List<HalfPipeSpecialStageScreen.TexturedQuad> list2 = list;
							IEnumerable<Vector3> source = new Vector3[]
							{
								new Vector3(vector.X - num4, vector.Y - num4, 0.0),
								new Vector3(vector.X - num4, vector.Y + num4, 0.0),
								new Vector3(vector.X + num4, vector.Y + num4, 0.0),
								new Vector3(vector.X + num4, vector.Y - num4, 0.0)
							};
							Func<Vector3, Vector3> selector;
							if ((selector = <>9__1) == null)
							{
								selector = (<>9__1 = ((Vector3 x) => transform * x));
							}
							list2.Add(new HalfPipeSpecialStageScreen.TexturedQuad(source.Select(selector).ToArray<Vector3>(), new Vector2[]
							{
								new Vector2(0.0, 0.0),
								new Vector2(0.0, 1.0),
								new Vector2(1.0, 1.0),
								new Vector2(1.0, 0.0)
							}, this._ballTexture));
						}
					}
				}
			}
			List<Tuple<int, ITexture>> list3 = new List<Tuple<int, ITexture>>();
			int num7 = 0;
			ITexture texture = null;
			this._vertexBuffer.Begin();
			foreach (HalfPipeSpecialStageScreen.TexturedQuad texturedQuad in from x in list
			orderby (this._camera - x.Position[0]).Length descending
			select x)
			{
				for (int l = 0; l < 4; l++)
				{
					this._vertexBuffer.AddValue(0, texturedQuad.Position[l]);
					this._vertexBuffer.AddValue(1, texturedQuad.TextureMapping[l]);
				}
				if (num7 == 0)
				{
					texture = texturedQuad.Texture;
				}
				else if (texture != texturedQuad.Texture)
				{
					list3.Add(new Tuple<int, ITexture>(num7, texture));
					num7 = 0;
					texture = texturedQuad.Texture;
				}
				num7++;
			}
			if (num7 > 0)
			{
				list3.Add(new Tuple<int, ITexture>(num7, texture));
			}
			this._vertexBuffer.End();
			IShaderProgram program = this._pipeShader.Program;
			program.Activate();
			program.SetUniform("ProjectionMatrix", this._projectionMatrix);
			program.SetUniform("ModelViewMatrix", this._modelViewMatrix);
			program.SetUniform("InputTexture", 0);
			program.SetUniform("InputLightSource", this._trackNodes[this._currentTrackNode].Position + new Vector3(0.0, 0.0, 0.0));
			int num8 = 0;
			foreach (Tuple<int, ITexture> tuple in list3)
			{
				this._graphicsContext.SetTexture(tuple.Item2);
				this._vertexBuffer.Render(PrimitiveType.Quads, num8 * 4, tuple.Item1 * 4);
				num8 += tuple.Item1;
			}
			this._graphicsContext.DepthTesting = false;
		}

		// Token: 0x06000E33 RID: 3635 RVA: 0x00037268 File Offset: 0x00035468
		private Vector3[] GetCrossSection()
		{
			Vector3[] array = new Vector3[32];
			for (int i = 0; i < array.Length; i++)
			{
				double num = (double)i / 31.0 * 3.141592653589793;
				array[i] = new Vector3(-Math.Cos(num) * 4.0, -Math.Sin(num) * 4.0, 0.0);
			}
			return array;
		}

		// Token: 0x06000E34 RID: 3636 RVA: 0x000372DC File Offset: 0x000354DC
		private void DrawHud(Renderer renderer)
		{
			renderer.GetFontRenderer().RenderString(string.Format("SEGMENT: {0} / {1}", this._currentTrackNode, this._trackNodes.Count), default(Rectangle), FontAlignment.Left, this._font, 0);
		}

		// Token: 0x040007FC RID: 2044
		private const string MusicResourceKey = "SONICORCA/MUSIC/SPECIALSTAGE/S2";

		// Token: 0x040007FD RID: 2045
		private readonly SonicOrcaGameContext _gameContext;

		// Token: 0x040007FE RID: 2046
		private readonly IGraphicsContext _graphicsContext;

		// Token: 0x040007FF RID: 2047
		private readonly ResourceSession _resourceSession;

		// Token: 0x04000800 RID: 2048
		private Font _font;

		// Token: 0x04000801 RID: 2049
		private ITexture _backgroundTexture;

		// Token: 0x04000802 RID: 2050
		private ITexture _floorTexture;

		// Token: 0x04000803 RID: 2051
		private ITexture _ballTexture;

		// Token: 0x04000804 RID: 2052
		private SampleInfo _musicSampleInfo;

		// Token: 0x04000805 RID: 2053
		private Matrix4 _projectionMatrix;

		// Token: 0x04000806 RID: 2054
		private Matrix4 _modelViewMatrix;

		// Token: 0x04000807 RID: 2055
		private VertexBuffer _vertexBuffer;

		// Token: 0x04000808 RID: 2056
		private ManagedShaderProgram _pipeShader;

		// Token: 0x04000809 RID: 2057
		private ManagedShaderProgram _objectShader;

		// Token: 0x0400080A RID: 2058
		private SampleInstance _musicInstance;

		// Token: 0x0400080B RID: 2059
		private double _fov = 60.0;

		// Token: 0x0400080C RID: 2060
		private int _currentTrackNode;

		// Token: 0x0400080D RID: 2061
		private HalfPipeSpecialStageScreen.SegmentGeometry[] _layout = new HalfPipeSpecialStageScreen.SegmentGeometry[]
		{
			HalfPipeSpecialStageScreen.SegmentGeometry.Straight,
			HalfPipeSpecialStageScreen.SegmentGeometry.Straight,
			HalfPipeSpecialStageScreen.SegmentGeometry.Straight,
			HalfPipeSpecialStageScreen.SegmentGeometry.Straight,
			HalfPipeSpecialStageScreen.SegmentGeometry.Straight,
			HalfPipeSpecialStageScreen.SegmentGeometry.Straight,
			HalfPipeSpecialStageScreen.SegmentGeometry.Straight,
			HalfPipeSpecialStageScreen.SegmentGeometry.TurnRight,
			HalfPipeSpecialStageScreen.SegmentGeometry.TurnRight,
			HalfPipeSpecialStageScreen.SegmentGeometry.Straight,
			HalfPipeSpecialStageScreen.SegmentGeometry.Straight,
			HalfPipeSpecialStageScreen.SegmentGeometry.Straight,
			HalfPipeSpecialStageScreen.SegmentGeometry.Straight,
			HalfPipeSpecialStageScreen.SegmentGeometry.Straight,
			HalfPipeSpecialStageScreen.SegmentGeometry.Straight,
			HalfPipeSpecialStageScreen.SegmentGeometry.Straight,
			HalfPipeSpecialStageScreen.SegmentGeometry.Straight,
			HalfPipeSpecialStageScreen.SegmentGeometry.Straight,
			HalfPipeSpecialStageScreen.SegmentGeometry.Straight,
			HalfPipeSpecialStageScreen.SegmentGeometry.Straight,
			HalfPipeSpecialStageScreen.SegmentGeometry.Straight,
			HalfPipeSpecialStageScreen.SegmentGeometry.Straight,
			HalfPipeSpecialStageScreen.SegmentGeometry.Straight,
			HalfPipeSpecialStageScreen.SegmentGeometry.TurnRight,
			HalfPipeSpecialStageScreen.SegmentGeometry.TurnRight,
			HalfPipeSpecialStageScreen.SegmentGeometry.Straight,
			HalfPipeSpecialStageScreen.SegmentGeometry.Straight,
			HalfPipeSpecialStageScreen.SegmentGeometry.Straight,
			HalfPipeSpecialStageScreen.SegmentGeometry.Straight,
			HalfPipeSpecialStageScreen.SegmentGeometry.Straight,
			HalfPipeSpecialStageScreen.SegmentGeometry.Straight,
			HalfPipeSpecialStageScreen.SegmentGeometry.Straight,
			HalfPipeSpecialStageScreen.SegmentGeometry.Straight,
			HalfPipeSpecialStageScreen.SegmentGeometry.Straight,
			HalfPipeSpecialStageScreen.SegmentGeometry.Straight,
			HalfPipeSpecialStageScreen.SegmentGeometry.TurnRight,
			HalfPipeSpecialStageScreen.SegmentGeometry.TurnRight,
			HalfPipeSpecialStageScreen.SegmentGeometry.Rise,
			HalfPipeSpecialStageScreen.SegmentGeometry.TurnRight,
			HalfPipeSpecialStageScreen.SegmentGeometry.Straight,
			HalfPipeSpecialStageScreen.SegmentGeometry.Straight,
			HalfPipeSpecialStageScreen.SegmentGeometry.Straight,
			HalfPipeSpecialStageScreen.SegmentGeometry.Straight,
			HalfPipeSpecialStageScreen.SegmentGeometry.Straight,
			HalfPipeSpecialStageScreen.SegmentGeometry.Straight,
			HalfPipeSpecialStageScreen.SegmentGeometry.TurnRight,
			HalfPipeSpecialStageScreen.SegmentGeometry.Drop,
			HalfPipeSpecialStageScreen.SegmentGeometry.TurnLeft,
			HalfPipeSpecialStageScreen.SegmentGeometry.TurnRight,
			HalfPipeSpecialStageScreen.SegmentGeometry.Straight,
			HalfPipeSpecialStageScreen.SegmentGeometry.Straight,
			HalfPipeSpecialStageScreen.SegmentGeometry.Straight,
			HalfPipeSpecialStageScreen.SegmentGeometry.Straight,
			HalfPipeSpecialStageScreen.SegmentGeometry.Straight,
			HalfPipeSpecialStageScreen.SegmentGeometry.Straight,
			HalfPipeSpecialStageScreen.SegmentGeometry.TurnRight,
			HalfPipeSpecialStageScreen.SegmentGeometry.TurnRight,
			HalfPipeSpecialStageScreen.SegmentGeometry.Straight,
			HalfPipeSpecialStageScreen.SegmentGeometry.Straight,
			HalfPipeSpecialStageScreen.SegmentGeometry.Straight,
			HalfPipeSpecialStageScreen.SegmentGeometry.Straight,
			HalfPipeSpecialStageScreen.SegmentGeometry.TurnRight,
			HalfPipeSpecialStageScreen.SegmentGeometry.TurnRight,
			HalfPipeSpecialStageScreen.SegmentGeometry.Straight,
			HalfPipeSpecialStageScreen.SegmentGeometry.Straight,
			HalfPipeSpecialStageScreen.SegmentGeometry.Straight,
			HalfPipeSpecialStageScreen.SegmentGeometry.Straight,
			HalfPipeSpecialStageScreen.SegmentGeometry.TurnLeft,
			HalfPipeSpecialStageScreen.SegmentGeometry.TurnRight,
			HalfPipeSpecialStageScreen.SegmentGeometry.Straight,
			HalfPipeSpecialStageScreen.SegmentGeometry.Straight,
			HalfPipeSpecialStageScreen.SegmentGeometry.Straight,
			HalfPipeSpecialStageScreen.SegmentGeometry.Straight,
			HalfPipeSpecialStageScreen.SegmentGeometry.TurnRight,
			HalfPipeSpecialStageScreen.SegmentGeometry.TurnRight,
			HalfPipeSpecialStageScreen.SegmentGeometry.Straight,
			HalfPipeSpecialStageScreen.SegmentGeometry.Straight,
			HalfPipeSpecialStageScreen.SegmentGeometry.Straight,
			HalfPipeSpecialStageScreen.SegmentGeometry.Straight,
			HalfPipeSpecialStageScreen.SegmentGeometry.TurnLeft,
			HalfPipeSpecialStageScreen.SegmentGeometry.TurnRight,
			HalfPipeSpecialStageScreen.SegmentGeometry.Straight,
			HalfPipeSpecialStageScreen.SegmentGeometry.Straight,
			HalfPipeSpecialStageScreen.SegmentGeometry.Straight,
			HalfPipeSpecialStageScreen.SegmentGeometry.Straight,
			HalfPipeSpecialStageScreen.SegmentGeometry.Straight,
			HalfPipeSpecialStageScreen.SegmentGeometry.Straight,
			HalfPipeSpecialStageScreen.SegmentGeometry.Straight,
			HalfPipeSpecialStageScreen.SegmentGeometry.Straight,
			HalfPipeSpecialStageScreen.SegmentGeometry.Straight,
			HalfPipeSpecialStageScreen.SegmentGeometry.TurnRight,
			HalfPipeSpecialStageScreen.SegmentGeometry.Rise
		};

		// Token: 0x0400080E RID: 2062
		private const double PipeRadius = 4.0;

		// Token: 0x0400080F RID: 2063
		private const int NumPointsWide = 32;

		// Token: 0x04000810 RID: 2064
		private const int PointsPerSegment = 28;

		// Token: 0x04000811 RID: 2065
		private const int PointLength = 2;

		// Token: 0x04000812 RID: 2066
		private List<HalfPipeSpecialStageScreen.TrackNode> _trackNodes = new List<HalfPipeSpecialStageScreen.TrackNode>();

		// Token: 0x04000813 RID: 2067
		private int _ticks;

		// Token: 0x04000814 RID: 2068
		private Vector3 _camera;

		// Token: 0x04000815 RID: 2069
		private Vector3 _cameraTarget;

		// Token: 0x0200023B RID: 571
		private enum SegmentGeometry
		{
			// Token: 0x04000C5D RID: 3165
			Straight,
			// Token: 0x04000C5E RID: 3166
			Drop,
			// Token: 0x04000C5F RID: 3167
			Rise,
			// Token: 0x04000C60 RID: 3168
			TurnLeft,
			// Token: 0x04000C61 RID: 3169
			TurnRight
		}

		// Token: 0x0200023C RID: 572
		private struct TrackNode
		{
			// Token: 0x1700053F RID: 1343
			// (get) Token: 0x0600145D RID: 5213 RVA: 0x0004E300 File Offset: 0x0004C500
			// (set) Token: 0x0600145E RID: 5214 RVA: 0x0004E308 File Offset: 0x0004C508
			public Vector3 Position { get; set; }

			// Token: 0x17000540 RID: 1344
			// (get) Token: 0x0600145F RID: 5215 RVA: 0x0004E311 File Offset: 0x0004C511
			// (set) Token: 0x06001460 RID: 5216 RVA: 0x0004E319 File Offset: 0x0004C519
			public Vector2 Angle { get; set; }

			// Token: 0x06001461 RID: 5217 RVA: 0x0004E322 File Offset: 0x0004C522
			public TrackNode(Vector3 position, Vector2 angle)
			{
				this = default(HalfPipeSpecialStageScreen.TrackNode);
				this.Position = position;
				this.Angle = angle;
			}

			// Token: 0x06001462 RID: 5218 RVA: 0x0004E33C File Offset: 0x0004C53C
			public override string ToString()
			{
				return string.Format("{0}, {1:0} DEG, {2:0} DEG", this.Position, MathX.ToDegrees(this.Angle.X), MathX.ToDegrees(this.Angle.Y));
			}
		}

		// Token: 0x0200023D RID: 573
		private struct TexturedQuad
		{
			// Token: 0x17000541 RID: 1345
			// (get) Token: 0x06001463 RID: 5219 RVA: 0x0004E38E File Offset: 0x0004C58E
			// (set) Token: 0x06001464 RID: 5220 RVA: 0x0004E396 File Offset: 0x0004C596
			public Vector3[] Position { get; set; }

			// Token: 0x17000542 RID: 1346
			// (get) Token: 0x06001465 RID: 5221 RVA: 0x0004E39F File Offset: 0x0004C59F
			// (set) Token: 0x06001466 RID: 5222 RVA: 0x0004E3A7 File Offset: 0x0004C5A7
			public Vector2[] TextureMapping { get; set; }

			// Token: 0x17000543 RID: 1347
			// (get) Token: 0x06001467 RID: 5223 RVA: 0x0004E3B0 File Offset: 0x0004C5B0
			// (set) Token: 0x06001468 RID: 5224 RVA: 0x0004E3B8 File Offset: 0x0004C5B8
			public ITexture Texture { get; set; }

			// Token: 0x06001469 RID: 5225 RVA: 0x0004E3C1 File Offset: 0x0004C5C1
			public TexturedQuad(Vector3[] position, Vector2[] textureMapping, ITexture texture)
			{
				this = default(HalfPipeSpecialStageScreen.TexturedQuad);
				this.Position = position;
				this.TextureMapping = textureMapping;
				this.Texture = texture;
			}
		}
	}
}
