using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using SonicOrca.Audio;
using SonicOrca.Extensions;
using SonicOrca.Geometry;
using SonicOrca.Graphics;
using SonicOrca.Resources;

namespace SonicOrca.Menu
{
	// Token: 0x02000096 RID: 150
	internal class SoundtrackScreen : Screen
	{
		// Token: 0x0600033F RID: 831 RVA: 0x00017AE9 File Offset: 0x00015CE9
		public SoundtrackScreen(SonicOrcaGameContext gameContext)
		{
			this._gameContext = gameContext;
		}

		// Token: 0x06000340 RID: 832 RVA: 0x00017B10 File Offset: 0x00015D10
		public override async Task LoadAsync(ScreenLoadingProgress progress, CancellationToken ct = default(CancellationToken))
		{
			ResourceTree resourceTree = this._gameContext.ResourceTree;
			this._loadedTrackResourceSession = new ResourceSession(resourceTree);
			this._resourceSession = new ResourceSession(resourceTree);
			this._resourceSession.PushDependencies(new string[]
			{
				"SONICORCA/MENU/LEVELSELECT/BACKGROUND",
				"SONICORCA/S2/HUD/FONT",
				"SONICORCA/S2/HUD/LIFE/SONIC",
				"SONICORCA/SOUND/TALLY/SWITCH",
				"SONICORCA/MENU/SOUNDTRACK/LISTING"
			});
			await this._resourceSession.LoadAsync(ct, false);
			this._backgroundTexture = resourceTree.GetLoadedResource<ITexture>("SONICORCA/MENU/LEVELSELECT/BACKGROUND");
			this._trackBarTexture = resourceTree.GetLoadedResource<ITexture>("SONICORCA/S2/HUD/LIFE/SONIC");
			this._font = resourceTree.GetLoadedResource<Font>("SONICORCA/S2/HUD/FONT");
			this._selectionChangeSample = resourceTree.GetLoadedResource<Sample>("SONICORCA/SOUND/TALLY/SWITCH");
			this.ParseListingXml(resourceTree.GetLoadedResource<XmlLoadedResource>("SONICORCA/MENU/SOUNDTRACK/LISTING"));
		}

		// Token: 0x06000341 RID: 833 RVA: 0x00017B5D File Offset: 0x00015D5D
		public override void Unload()
		{
			if (this._resourceSession != null)
			{
				this._resourceSession.Unload();
			}
		}

		// Token: 0x06000342 RID: 834 RVA: 0x00017B74 File Offset: 0x00015D74
		private void ParseListingXml(XmlLoadedResource xmlResource)
		{
			this._currentTrackNode = (this._listingHead = new SoundtrackScreen.TrackNode(null, this.ParseListingXml(xmlResource.XmlDocument.SelectSingleNode("soundtrack")), false));
		}

		// Token: 0x06000343 RID: 835 RVA: 0x00017BAD File Offset: 0x00015DAD
		private IEnumerable<SoundtrackScreen.TrackNode> ParseListingXml(XmlNode xmlNode)
		{
			foreach (object obj in xmlNode.ChildNodes)
			{
				XmlNode child = (XmlNode)obj;
				if (child.Name == "track")
				{
					yield return new SoundtrackScreen.TrackNode(child.Attributes["name"].Value, child.InnerText);
				}
				else if (child.Name == "group")
				{
					string a;
					child.TryGetAttributeValue("type", out a);
					yield return new SoundtrackScreen.TrackNode(child.Attributes["name"].Value, this.ParseListingXml(child), a == "mini");
				}
				child = null;
			}
			IEnumerator enumerator = null;
			yield break;
			yield break;
		}

		// Token: 0x06000344 RID: 836 RVA: 0x00017BC4 File Offset: 0x00015DC4
		public override void Update()
		{
			switch (this._state)
			{
			case SoundtrackScreen.InternalState.BeginFadeIn:
				this._fadeTransition.BeginFadeIn();
				this._state = SoundtrackScreen.InternalState.FadingIn;
				return;
			case SoundtrackScreen.InternalState.FadingIn:
				this._fadeTransition.Update();
				if (this._fadeTransition.Finished)
				{
					this._state = SoundtrackScreen.InternalState.Normal;
					return;
				}
				break;
			case SoundtrackScreen.InternalState.Normal:
				this.HandleInput();
				return;
			case SoundtrackScreen.InternalState.BeginFadeOut:
				this._fadeTransition.BeginFadeOut();
				this._state = SoundtrackScreen.InternalState.FadingOut;
				return;
			case SoundtrackScreen.InternalState.FadingOut:
				this._fadeTransition.Update();
				if (this._fadeTransition.Finished)
				{
					base.Finish();
				}
				break;
			default:
				return;
			}
		}

		// Token: 0x06000345 RID: 837 RVA: 0x00017C60 File Offset: 0x00015E60
		private void HandleInput()
		{
			Controller controller = this._gameContext.Pressed[0];
			if (controller.DirectionLeft.X == 0.0 && controller.DirectionLeft.Y == 0.0)
			{
				this._cursorDelay = 0;
			}
			if (this._cursorDelay > 0)
			{
				this._cursorDelay--;
			}
			else
			{
				if (controller.DirectionLeft.X < 0.0)
				{
					this.ListingLeft();
				}
				if (controller.DirectionLeft.X > 0.0)
				{
					this.ListingRight();
				}
				if (controller.DirectionLeft.Y < 0.0)
				{
					this.ListingUp();
				}
				if (controller.DirectionLeft.Y > 0.0)
				{
					this.ListingDown();
				}
				if (controller.DirectionLeft.X != 0.0 || controller.DirectionLeft.Y != 0.0)
				{
					this._cursorDelay = (int)(10.0 * (2.0 * controller.DirectionLeft.Y));
				}
			}
			if (controller.Action2)
			{
				this.ListingEnter();
			}
			if (controller.Action3)
			{
				this.ListingExit();
			}
			object loadTrackSync = this._loadTrackSync;
			lock (loadTrackSync)
			{
				if (this._loadedTrackSampleInstance != null)
				{
					if (controller.Action1)
					{
						this.TogglePlayTrack();
					}
					double factor = 0.0;
					if (controller.LeftTrigger != 0.0 && controller.RightTrigger == 0.0)
					{
						factor = -controller.LeftTrigger;
					}
					if (controller.LeftTrigger == 0.0 && controller.RightTrigger != 0.0)
					{
						factor = controller.RightTrigger;
					}
					if (this._gameContext.Input.CurrentState.Keyboard[18])
					{
						factor = -1.0;
					}
					if (this._gameContext.Input.CurrentState.Keyboard[19])
					{
						factor = 1.0;
					}
					this.SeekTrack(factor);
					this.SeekTrack(controller.DirectionRight.X, controller.DirectionRight.Y);
				}
			}
		}

		// Token: 0x06000346 RID: 838 RVA: 0x00017EEC File Offset: 0x000160EC
		private void ListingUp()
		{
			if (this._currentTrackNode.SelectedIndex > 0)
			{
				SoundtrackScreen.TrackNode currentTrackNode = this._currentTrackNode;
				int selectedIndex = currentTrackNode.SelectedIndex;
				currentTrackNode.SelectedIndex = selectedIndex - 1;
				this.PlayChangeListingSound();
			}
		}

		// Token: 0x06000347 RID: 839 RVA: 0x00017F24 File Offset: 0x00016124
		private void ListingDown()
		{
			if (this._currentTrackNode.SelectedIndex < this._currentTrackNode.Children.Count - 1)
			{
				SoundtrackScreen.TrackNode currentTrackNode = this._currentTrackNode;
				int selectedIndex = currentTrackNode.SelectedIndex;
				currentTrackNode.SelectedIndex = selectedIndex + 1;
				this.PlayChangeListingSound();
			}
		}

		// Token: 0x06000348 RID: 840 RVA: 0x00017F6C File Offset: 0x0001616C
		private void ListingLeft()
		{
			if (this._currentTrackNode.Children.Count == 0)
			{
				return;
			}
			SoundtrackScreen.TrackNode trackNode = this._currentTrackNode.Children[this._currentTrackNode.SelectedIndex];
			if (trackNode.Type == SoundtrackScreen.ListingType.MiniGroup && trackNode.SelectedIndex > 0)
			{
				SoundtrackScreen.TrackNode trackNode2 = trackNode;
				int selectedIndex = trackNode2.SelectedIndex;
				trackNode2.SelectedIndex = selectedIndex - 1;
				this.PlayChangeListingSound();
			}
		}

		// Token: 0x06000349 RID: 841 RVA: 0x00017FD0 File Offset: 0x000161D0
		private void ListingRight()
		{
			if (this._currentTrackNode.Children.Count == 0)
			{
				return;
			}
			SoundtrackScreen.TrackNode trackNode = this._currentTrackNode.Children[this._currentTrackNode.SelectedIndex];
			if (trackNode.Type == SoundtrackScreen.ListingType.MiniGroup && trackNode.SelectedIndex < trackNode.Children.Count - 1)
			{
				SoundtrackScreen.TrackNode trackNode2 = trackNode;
				int selectedIndex = trackNode2.SelectedIndex;
				trackNode2.SelectedIndex = selectedIndex + 1;
				this.PlayChangeListingSound();
			}
		}

		// Token: 0x0600034A RID: 842 RVA: 0x00018040 File Offset: 0x00016240
		private void ListingExit()
		{
			if (this._currentTrackNode.Parent != null)
			{
				this._currentTrackNode = this._currentTrackNode.Parent;
				this.PlayChangeListingSound();
			}
		}

		// Token: 0x0600034B RID: 843 RVA: 0x00018068 File Offset: 0x00016268
		private void ListingEnter()
		{
			if (this._currentTrackNode.Children.Count == 0)
			{
				return;
			}
			SoundtrackScreen.TrackNode trackNode = this._currentTrackNode.Children[this._currentTrackNode.SelectedIndex];
			if (trackNode.Type == SoundtrackScreen.ListingType.Track)
			{
				this.SetAndPlayTrack(trackNode);
				return;
			}
			if (trackNode.Type == SoundtrackScreen.ListingType.MiniGroup)
			{
				if (trackNode.Children.Count == 0)
				{
					return;
				}
				trackNode = trackNode.Children[trackNode.SelectedIndex];
				if (trackNode.Type == SoundtrackScreen.ListingType.Track)
				{
					this.SetAndPlayTrack(trackNode);
					return;
				}
			}
			else
			{
				this._currentTrackNode = trackNode;
				this.PlayChangeListingSound();
			}
		}

		// Token: 0x0600034C RID: 844 RVA: 0x000180FC File Offset: 0x000162FC
		private void PlayChangeListingSound()
		{
			this._gameContext.Audio.PlaySound(this._selectionChangeSample);
		}

		// Token: 0x0600034D RID: 845 RVA: 0x00018114 File Offset: 0x00016314
		private void SetAndPlayTrack(SoundtrackScreen.TrackNode node)
		{
			SoundtrackScreen.<>c__DisplayClass43_0 CS$<>8__locals1 = new SoundtrackScreen.<>c__DisplayClass43_0();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.node = node;
			if (CS$<>8__locals1.node.ResourceKey == this._loadedTrackResourceKey)
			{
				if (this._loadTrackTask == null)
				{
					this.RestartTrack();
				}
				return;
			}
			if (this._loadTrackTask != null)
			{
				this._loadTrackCancellationTokenSource.Cancel();
				while (this._loadTrackTask != null)
				{
				}
			}
			this._loadTrackCancellationTokenSource = new CancellationTokenSource();
			CS$<>8__locals1.ct = this._loadTrackCancellationTokenSource.Token;
			this._loadTrackTask = Task.Run(delegate()
			{
				SoundtrackScreen.<>c__DisplayClass43_0.<<SetAndPlayTrack>b__0>d <<SetAndPlayTrack>b__0>d;
				<<SetAndPlayTrack>b__0>d.<>4__this = CS$<>8__locals1;
				<<SetAndPlayTrack>b__0>d.<>t__builder = AsyncTaskMethodBuilder.Create();
				<<SetAndPlayTrack>b__0>d.<>1__state = -1;
				AsyncTaskMethodBuilder <>t__builder = <<SetAndPlayTrack>b__0>d.<>t__builder;
				<>t__builder.Start<SoundtrackScreen.<>c__DisplayClass43_0.<<SetAndPlayTrack>b__0>d>(ref <<SetAndPlayTrack>b__0>d);
				return <<SetAndPlayTrack>b__0>d.<>t__builder.Task;
			});
		}

		// Token: 0x0600034E RID: 846 RVA: 0x000181AC File Offset: 0x000163AC
		private async Task SetTrack(string resourceKey, CancellationToken ct = default(CancellationToken))
		{
			if (!(this._loadedTrackResourceKey == resourceKey))
			{
				object loadTrackSync = this._loadTrackSync;
				lock (loadTrackSync)
				{
					if (this._loadedTrackSampleInstance != null)
					{
						this._loadedTrackSampleInstance.Dispose();
						this._loadedTrackSampleInstance = null;
					}
				}
				this._loadedTrackResourceKey = resourceKey;
				this._loadedTrackResourceSession.Unload();
				try
				{
					this._loadedTrackResourceSession.PushDependency(resourceKey);
					await this._loadedTrackResourceSession.LoadAsync(ct, false);
					loadTrackSync = this._loadTrackSync;
					lock (loadTrackSync)
					{
						if (this._loadedTrackResourceSession.ResourceTree[resourceKey].Resource.Identifier == ResourceTypeIdentifier.SampleInfo)
						{
							this._loadedTrackSampleInstance = new SampleInstance(this._gameContext.Audio, this._loadedTrackResourceSession.ResourceTree.GetLoadedResource<SampleInfo>(resourceKey));
						}
						else
						{
							this._loadedTrackSampleInstance = new SampleInstance(this._gameContext.Audio, this._loadedTrackResourceSession.ResourceTree.GetLoadedResource<Sample>(resourceKey), null);
						}
					}
				}
				catch (Exception)
				{
					this._loadedTrackResourceKey = null;
				}
			}
		}

		// Token: 0x0600034F RID: 847 RVA: 0x00018204 File Offset: 0x00016404
		private void RestartTrack()
		{
			object loadTrackSync = this._loadTrackSync;
			lock (loadTrackSync)
			{
				if (this._loadedTrackSampleInstance != null)
				{
					this._loadedTrackSampleInstance.Stop();
					this._loadedTrackSampleInstance.SeekToStart();
					this._loadedTrackSampleInstance.Play();
				}
			}
		}

		// Token: 0x06000350 RID: 848 RVA: 0x0001826C File Offset: 0x0001646C
		private void TogglePlayTrack()
		{
			object loadTrackSync = this._loadTrackSync;
			lock (loadTrackSync)
			{
				if (this._loadedTrackSampleInstance != null)
				{
					if (this._loadedTrackSampleInstance.Playing)
					{
						this._loadedTrackSampleInstance.Stop();
					}
					else
					{
						this._loadedTrackSampleInstance.Play();
					}
				}
			}
		}

		// Token: 0x06000351 RID: 849 RVA: 0x000182D8 File Offset: 0x000164D8
		private void SeekTrack(double factor)
		{
			object loadTrackSync = this._loadTrackSync;
			lock (loadTrackSync)
			{
				if (this._loadedTrackSampleInstance != null && factor != 0.0)
				{
					int sampleIndex = this._loadedTrackSampleInstance.SampleIndex;
					int num = this._loadedTrackSampleInstance.Sample.SampleRate / 2;
					int sampleCount = this._loadedTrackSampleInstance.Sample.SampleCount;
					factor = (double)Math.Sign(factor) * factor * factor;
					num = (int)((double)num * factor);
					this._loadedTrackSampleInstance.SeekTo(MathX.Clamp(0, sampleIndex + num, sampleCount));
				}
			}
		}

		// Token: 0x06000352 RID: 850 RVA: 0x00018384 File Offset: 0x00016584
		private void SeekTrack(double x, double y)
		{
			object loadTrackSync = this._loadTrackSync;
			lock (loadTrackSync)
			{
				if (x != 0.0 || y != 0.0)
				{
					double num = (Math.Atan2(y, x) / 6.283185307179586 + 1.25) % 1.0;
					int sampleIndex = MathX.Clamp(0, (int)(num * (double)this._loadedTrackSampleInstance.Sample.SampleCount), this._loadedTrackSampleInstance.Sample.SampleCount);
					this._loadedTrackSampleInstance.SeekTo(sampleIndex);
				}
			}
		}

		// Token: 0x06000353 RID: 851 RVA: 0x00018438 File Offset: 0x00016638
		private TimeSpan GetTime(int sampleOffset)
		{
			return TimeSpan.FromSeconds((double)sampleOffset / (double)this._loadedTrackSampleInstance.Sample.SampleRate);
		}

		// Token: 0x06000354 RID: 852 RVA: 0x00018454 File Offset: 0x00016654
		public override void Draw(Renderer renderer)
		{
			I2dRenderer i2dRenderer = renderer.Get2dRenderer();
			IFontRenderer fontRenderer = renderer.GetFontRenderer();
			i2dRenderer.Colour = Colours.White;
			i2dRenderer.RenderTexture(this._backgroundTexture, new Rectangle(0.0, 0.0, 1920.0, 1080.0), false, false);
			using (i2dRenderer.BeginMatixState())
			{
				i2dRenderer.ModelMatrix = i2dRenderer.ModelMatrix.Scale(2.5, 2.5, 1.0);
				fontRenderer.RenderString("SOUNDTRACK", new Rectangle(32.0, 32.0, 0.0, 0.0), FontAlignment.Left, this._font, Colours.Black, null);
			}
			this.DrawList(renderer, new Rectangle(32.0, 228.0, 896.0, 820.0));
			object loadTrackSync = this._loadTrackSync;
			lock (loadTrackSync)
			{
				this.DrawTrackbar(renderer, new Rectangle(1080.0, 244.0, 804.0, 804.0));
			}
			this._fadeTransition.Draw(renderer);
		}

		// Token: 0x06000355 RID: 853 RVA: 0x000185E8 File Offset: 0x000167E8
		private void DrawList(Renderer renderer, Rectangle bounds)
		{
			I2dRenderer i2dRenderer = renderer.Get2dRenderer();
			using (i2dRenderer.BeginMatixState())
			{
				i2dRenderer.ModelMatrix = i2dRenderer.ModelMatrix.Translate(bounds.X, bounds.Y, 0.0);
				int num = 0;
				int num2 = 0;
				int num3 = this._currentTrackNode.Children.Count - 1;
				int num4 = MathX.Clamp(0, this._currentTrackNode.SelectedIndex - 5, num3 - 9);
				double num5 = 0.0;
				foreach (SoundtrackScreen.TrackNode trackNode in this._currentTrackNode.Children)
				{
					bool flag = num == this._currentTrackNode.SelectedIndex;
					if (num++ >= num4)
					{
						num5 += this.DrawListItem(renderer, trackNode, new Rectangle(0.0, num5, bounds.Width, 74.0), flag) + 8.0;
						if (trackNode.Type == SoundtrackScreen.ListingType.MiniGroup && flag)
						{
							num2++;
						}
						if (++num2 >= 10)
						{
							break;
						}
					}
				}
			}
		}

		// Token: 0x06000356 RID: 854 RVA: 0x00018754 File Offset: 0x00016954
		private double DrawListItem(Renderer renderer, SoundtrackScreen.TrackNode node, Rectangle bounds, bool selected)
		{
			bool flag = false;
			if (node.Type == SoundtrackScreen.ListingType.MiniGroup && selected)
			{
				flag = true;
			}
			if (flag)
			{
				bounds.Height = bounds.Height * 2.0 + 8.0;
			}
			I2dRenderer i2dRenderer = renderer.Get2dRenderer();
			IFontRenderer fontRenderer = renderer.GetFontRenderer();
			i2dRenderer.RenderQuad(new Colour(128, 0, 0, 0), bounds);
			if (flag)
			{
				bounds.Height = (bounds.Height - 8.0) / 2.0;
			}
			bounds.X += 12.0;
			Colour colour = new Colour(128, 128, 128);
			Colour colour2 = Colours.White;
			if (this._loadedTrackResourceKey == node.ResourceKey && this._loadTrackTask != null)
			{
				colour2 = colour;
			}
			fontRenderer.RenderStringWithShadow(node.Name.ToUpper(), bounds, FontAlignment.MiddleY, this._font, colour2, new int?(selected ? 1 : 0));
			if (flag)
			{
				bounds.Y += bounds.Height + 8.0;
				for (int i = 0; i < node.Children.Count; i++)
				{
					SoundtrackScreen.TrackNode trackNode = node.Children[i];
					colour2 = Colours.White;
					if (this._loadedTrackResourceKey == trackNode.ResourceKey && this._loadTrackTask != null)
					{
						colour2 = colour;
					}
					fontRenderer.RenderStringWithShadow(trackNode.Name.ToUpper(), bounds, FontAlignment.MiddleY, this._font, colour2, new int?((node.SelectedIndex == i) ? 1 : 0));
					bounds.X += this._font.MeasureString(trackNode.Name.ToUpper(), bounds, FontAlignment.MiddleY).Width + bounds.Height;
				}
				bounds.Height = bounds.Height * 2.0 + 8.0;
			}
			return bounds.Height;
		}

		// Token: 0x06000357 RID: 855 RVA: 0x0001895C File Offset: 0x00016B5C
		private void DrawTrackbar(Renderer renderer, Rectangle bounds)
		{
			I2dRenderer i2dRenderer = renderer.Get2dRenderer();
			IFontRenderer fontRenderer = renderer.GetFontRenderer();
			using (i2dRenderer.BeginMatixState())
			{
				i2dRenderer.ModelMatrix = i2dRenderer.ModelMatrix.Translate(bounds.CentreX, bounds.CentreY, 0.0);
				double num = bounds.Width / 2.0;
				double num2 = num - 32.0;
				double num3 = num2 + (num - num2) / 2.0;
				i2dRenderer.RenderEllipse(new Colour(128, 0, 0, 0), default(Vector2), num2, num, 64);
				if (this._loadedTrackSampleInstance != null)
				{
					double num4 = (double)this._loadedTrackSampleInstance.SampleIndex / (double)this._loadedTrackSampleInstance.Sample.SampleCount * 6.283185307179586;
					i2dRenderer.Colour = Colours.White;
					i2dRenderer.RenderTexture(this._trackBarTexture, new Vector2(Math.Sin(num4) * num3, -Math.Cos(num4) * num3), false, false);
					fontRenderer.RenderStringWithShadow(this._loadedTrackSampleInstance.SampleIndex.ToString(), default(Rectangle), FontAlignment.Centre, this._font, 0);
					TimeSpan time = this.GetTime(this._loadedTrackSampleInstance.SampleIndex);
					TimeSpan time2 = this.GetTime(this._loadedTrackSampleInstance.Sample.SampleCount);
					fontRenderer.RenderStringWithShadow(string.Format("{0:m\\:ss} / {1:m\\:ss}", time, time2), new Rectangle(0.0, num2 * 0.75, 0.0, 0.0), FontAlignment.Centre, this._font, 0);
				}
			}
		}

		// Token: 0x040003F5 RID: 1013
		private const string BackgroundResourceKey = "SONICORCA/MENU/LEVELSELECT/BACKGROUND";

		// Token: 0x040003F6 RID: 1014
		private const string FontResourceKey = "SONICORCA/S2/HUD/FONT";

		// Token: 0x040003F7 RID: 1015
		private const string TrackBarResourceKey = "SONICORCA/S2/HUD/LIFE/SONIC";

		// Token: 0x040003F8 RID: 1016
		private const string SelectionChangeResourceKey = "SONICORCA/SOUND/TALLY/SWITCH";

		// Token: 0x040003F9 RID: 1017
		private const string ListingResourceKey = "SONICORCA/MENU/SOUNDTRACK/LISTING";

		// Token: 0x040003FA RID: 1018
		private const int CursorMinDelay = 10;

		// Token: 0x040003FB RID: 1019
		private const int ListSize = 10;

		// Token: 0x040003FC RID: 1020
		private const int ListHeight = 74;

		// Token: 0x040003FD RID: 1021
		private const int ListGap = 8;

		// Token: 0x040003FE RID: 1022
		private readonly SonicOrcaGameContext _gameContext;

		// Token: 0x040003FF RID: 1023
		private ResourceSession _resourceSession;

		// Token: 0x04000400 RID: 1024
		private ITexture _backgroundTexture;

		// Token: 0x04000401 RID: 1025
		private ITexture _trackBarTexture;

		// Token: 0x04000402 RID: 1026
		private Font _font;

		// Token: 0x04000403 RID: 1027
		private Sample _selectionChangeSample;

		// Token: 0x04000404 RID: 1028
		private readonly FadeTransition _fadeTransition = new FadeTransition(30);

		// Token: 0x04000405 RID: 1029
		private SoundtrackScreen.InternalState _state;

		// Token: 0x04000406 RID: 1030
		private SoundtrackScreen.TrackNode _listingHead;

		// Token: 0x04000407 RID: 1031
		private SoundtrackScreen.TrackNode _currentTrackNode;

		// Token: 0x04000408 RID: 1032
		private CancellationTokenSource _loadTrackCancellationTokenSource;

		// Token: 0x04000409 RID: 1033
		private Task _loadTrackTask;

		// Token: 0x0400040A RID: 1034
		private ResourceSession _loadedTrackResourceSession;

		// Token: 0x0400040B RID: 1035
		private string _loadedTrackResourceKey;

		// Token: 0x0400040C RID: 1036
		private SampleInstance _loadedTrackSampleInstance;

		// Token: 0x0400040D RID: 1037
		private readonly object _loadTrackSync = new object();

		// Token: 0x0400040E RID: 1038
		private int _cursorDelay;

		// Token: 0x02000109 RID: 265
		private enum ListingType
		{
			// Token: 0x040006AD RID: 1709
			Group,
			// Token: 0x040006AE RID: 1710
			MiniGroup,
			// Token: 0x040006AF RID: 1711
			Track
		}

		// Token: 0x0200010A RID: 266
		private class TrackNode
		{
			// Token: 0x17000101 RID: 257
			// (get) Token: 0x06000667 RID: 1639 RVA: 0x000264F1 File Offset: 0x000246F1
			// (set) Token: 0x06000668 RID: 1640 RVA: 0x000264F9 File Offset: 0x000246F9
			public int SelectedIndex { get; set; }

			// Token: 0x17000102 RID: 258
			// (get) Token: 0x06000669 RID: 1641 RVA: 0x00026502 File Offset: 0x00024702
			public SoundtrackScreen.TrackNode Parent
			{
				get
				{
					return this._parent;
				}
			}

			// Token: 0x17000103 RID: 259
			// (get) Token: 0x0600066A RID: 1642 RVA: 0x0002650A File Offset: 0x0002470A
			public SoundtrackScreen.ListingType Type
			{
				get
				{
					return this._type;
				}
			}

			// Token: 0x17000104 RID: 260
			// (get) Token: 0x0600066B RID: 1643 RVA: 0x00026512 File Offset: 0x00024712
			public IReadOnlyList<SoundtrackScreen.TrackNode> Children
			{
				get
				{
					return this._children;
				}
			}

			// Token: 0x17000105 RID: 261
			// (get) Token: 0x0600066C RID: 1644 RVA: 0x0002651A File Offset: 0x0002471A
			public string Name
			{
				get
				{
					return this._name;
				}
			}

			// Token: 0x17000106 RID: 262
			// (get) Token: 0x0600066D RID: 1645 RVA: 0x00026522 File Offset: 0x00024722
			public string ResourceKey
			{
				get
				{
					return this._resourceKey;
				}
			}

			// Token: 0x0600066E RID: 1646 RVA: 0x0002652C File Offset: 0x0002472C
			public TrackNode(string name, IEnumerable<SoundtrackScreen.TrackNode> children, bool mini = false)
			{
				this._children = children.ToArray<SoundtrackScreen.TrackNode>();
				this._type = (mini ? SoundtrackScreen.ListingType.MiniGroup : SoundtrackScreen.ListingType.Group);
				this._name = name;
				SoundtrackScreen.TrackNode[] children2 = this._children;
				for (int i = 0; i < children2.Length; i++)
				{
					children2[i]._parent = this;
				}
			}

			// Token: 0x0600066F RID: 1647 RVA: 0x0002657D File Offset: 0x0002477D
			public TrackNode(string name, string resourceKey)
			{
				this._type = SoundtrackScreen.ListingType.Track;
				this._name = name;
				this._resourceKey = resourceKey;
			}

			// Token: 0x06000670 RID: 1648 RVA: 0x0002659A File Offset: 0x0002479A
			public override string ToString()
			{
				return this.Name;
			}

			// Token: 0x040006B0 RID: 1712
			private readonly SoundtrackScreen.TrackNode[] _children;

			// Token: 0x040006B1 RID: 1713
			private readonly SoundtrackScreen.ListingType _type;

			// Token: 0x040006B2 RID: 1714
			private readonly string _name;

			// Token: 0x040006B3 RID: 1715
			private readonly string _resourceKey;

			// Token: 0x040006B4 RID: 1716
			private SoundtrackScreen.TrackNode _parent;
		}

		// Token: 0x0200010B RID: 267
		private enum InternalState
		{
			// Token: 0x040006B7 RID: 1719
			BeginFadeIn,
			// Token: 0x040006B8 RID: 1720
			FadingIn,
			// Token: 0x040006B9 RID: 1721
			Normal,
			// Token: 0x040006BA RID: 1722
			BeginFadeOut,
			// Token: 0x040006BB RID: 1723
			FadingOut
		}
	}
}
