using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using OpenTK.Graphics;
using OpenTK.Input;
using OpenTK.Platform;

namespace OpenTK
{
	// Token: 0x02000058 RID: 88
	public class GameWindow : NativeWindow, IGameWindow, INativeWindow, IDisposable
	{
		// Token: 0x06000638 RID: 1592 RVA: 0x00016A6C File Offset: 0x00014C6C
		public GameWindow() : this(640, 480, GraphicsMode.Default, "OpenTK Game Window", GameWindowFlags.Default, DisplayDevice.Default)
		{
		}

		// Token: 0x06000639 RID: 1593 RVA: 0x00016A90 File Offset: 0x00014C90
		public GameWindow(int width, int height) : this(width, height, GraphicsMode.Default, "OpenTK Game Window", GameWindowFlags.Default, DisplayDevice.Default)
		{
		}

		// Token: 0x0600063A RID: 1594 RVA: 0x00016AAC File Offset: 0x00014CAC
		public GameWindow(int width, int height, GraphicsMode mode) : this(width, height, mode, "OpenTK Game Window", GameWindowFlags.Default, DisplayDevice.Default)
		{
		}

		// Token: 0x0600063B RID: 1595 RVA: 0x00016AC4 File Offset: 0x00014CC4
		public GameWindow(int width, int height, GraphicsMode mode, string title) : this(width, height, mode, title, GameWindowFlags.Default, DisplayDevice.Default)
		{
		}

		// Token: 0x0600063C RID: 1596 RVA: 0x00016AD8 File Offset: 0x00014CD8
		public GameWindow(int width, int height, GraphicsMode mode, string title, GameWindowFlags options) : this(width, height, mode, title, options, DisplayDevice.Default)
		{
		}

		// Token: 0x0600063D RID: 1597 RVA: 0x00016AEC File Offset: 0x00014CEC
		public GameWindow(int width, int height, GraphicsMode mode, string title, GameWindowFlags options, DisplayDevice device) : this(width, height, mode, title, options, device, 1, 0, GraphicsContextFlags.Default)
		{
		}

		// Token: 0x0600063E RID: 1598 RVA: 0x00016B0C File Offset: 0x00014D0C
		public GameWindow(int width, int height, GraphicsMode mode, string title, GameWindowFlags options, DisplayDevice device, int major, int minor, GraphicsContextFlags flags) : this(width, height, mode, title, options, device, major, minor, flags, null)
		{
		}

		// Token: 0x0600063F RID: 1599 RVA: 0x00016B30 File Offset: 0x00014D30
		public GameWindow(int width, int height, GraphicsMode mode, string title, GameWindowFlags options, DisplayDevice device, int major, int minor, GraphicsContextFlags flags, IGraphicsContext sharedContext) : base(width, height, title, options, (mode == null) ? GraphicsMode.Default : mode, (device == null) ? DisplayDevice.Default : device)
		{
			try
			{
				this.glContext = new GraphicsContext((mode == null) ? GraphicsMode.Default : mode, base.WindowInfo, major, minor, flags);
				this.glContext.MakeCurrent(base.WindowInfo);
				(this.glContext as IGraphicsContextInternal).LoadAll();
				this.VSync = VSyncMode.On;
			}
			catch (Exception)
			{
				base.Dispose();
				throw;
			}
		}

		// Token: 0x06000640 RID: 1600 RVA: 0x00016C84 File Offset: 0x00014E84
		public override void Dispose()
		{
			try
			{
				this.Dispose(true);
			}
			finally
			{
				try
				{
					if (this.glContext != null)
					{
						this.glContext.Dispose();
						this.glContext = null;
					}
				}
				finally
				{
					base.Dispose();
				}
			}
			GC.SuppressFinalize(this);
		}

		// Token: 0x06000641 RID: 1601 RVA: 0x00016CE0 File Offset: 0x00014EE0
		public virtual void Exit()
		{
			base.Close();
		}

		// Token: 0x06000642 RID: 1602 RVA: 0x00016CE8 File Offset: 0x00014EE8
		public void MakeCurrent()
		{
			base.EnsureUndisposed();
			this.Context.MakeCurrent(base.WindowInfo);
		}

		// Token: 0x06000643 RID: 1603 RVA: 0x00016D04 File Offset: 0x00014F04
		protected override void OnClosing(CancelEventArgs e)
		{
			base.OnClosing(e);
			if (!e.Cancel)
			{
				this.isExiting = true;
				this.OnUnloadInternal(EventArgs.Empty);
			}
		}

		// Token: 0x06000644 RID: 1604 RVA: 0x00016D28 File Offset: 0x00014F28
		protected virtual void OnLoad(EventArgs e)
		{
			this.Load(this, e);
		}

		// Token: 0x06000645 RID: 1605 RVA: 0x00016D38 File Offset: 0x00014F38
		protected virtual void OnUnload(EventArgs e)
		{
			this.Unload(this, e);
		}

		// Token: 0x06000646 RID: 1606 RVA: 0x00016D48 File Offset: 0x00014F48
		public void Run()
		{
			this.Run(0.0, 0.0);
		}

		// Token: 0x06000647 RID: 1607 RVA: 0x00016D64 File Offset: 0x00014F64
		public void Run(double updateRate)
		{
			this.Run(updateRate, 0.0);
		}

		// Token: 0x06000648 RID: 1608 RVA: 0x00016D78 File Offset: 0x00014F78
		public void Run(double updates_per_second, double frames_per_second)
		{
			base.EnsureUndisposed();
			try
			{
				if (updates_per_second < 0.0 || updates_per_second > 200.0)
				{
					throw new ArgumentOutOfRangeException("updates_per_second", updates_per_second, "Parameter should be inside the range [0.0, 200.0]");
				}
				if (frames_per_second < 0.0 || frames_per_second > 200.0)
				{
					throw new ArgumentOutOfRangeException("frames_per_second", frames_per_second, "Parameter should be inside the range [0.0, 200.0]");
				}
				if (updates_per_second != 0.0)
				{
					this.TargetUpdateFrequency = updates_per_second;
				}
				if (frames_per_second != 0.0)
				{
					this.TargetRenderFrequency = frames_per_second;
				}
				base.Visible = true;
				this.OnLoadInternal(EventArgs.Empty);
				this.OnResize(EventArgs.Empty);
				this.watch.Start();
				for (;;)
				{
					base.ProcessEvents();
					if (!base.Exists || this.IsExiting)
					{
						break;
					}
					this.DispatchUpdateAndRenderFrame(this, EventArgs.Empty);
				}
			}
			finally
			{
				base.Move -= this.DispatchUpdateAndRenderFrame;
				base.Resize -= this.DispatchUpdateAndRenderFrame;
				bool exists = base.Exists;
			}
		}

		// Token: 0x06000649 RID: 1609 RVA: 0x00016E98 File Offset: 0x00015098
		private double ClampElapsed(double elapsed)
		{
			return MathHelper.Clamp(elapsed, 0.0, 1.0);
		}

		// Token: 0x0600064A RID: 1610 RVA: 0x00016EB4 File Offset: 0x000150B4
		private void DispatchUpdateAndRenderFrame(object sender, EventArgs e)
		{
			int num = 4;
			double totalSeconds = this.watch.Elapsed.TotalSeconds;
			double num2 = this.ClampElapsed(totalSeconds - this.update_timestamp);
			while (num2 > 0.0 && num2 + this.update_epsilon >= this.TargetUpdatePeriod)
			{
				this.RaiseUpdateFrame(num2, ref totalSeconds);
				this.update_epsilon += num2 - this.TargetUpdatePeriod;
				num2 = this.ClampElapsed(totalSeconds - this.update_timestamp);
				if (this.TargetUpdatePeriod <= 5E-324)
				{
					break;
				}
				this.is_running_slowly = (this.update_epsilon >= this.TargetUpdatePeriod);
				if (this.is_running_slowly && --num == 0)
				{
					break;
				}
			}
			num2 = this.ClampElapsed(totalSeconds - this.render_timestamp);
			if (num2 > 0.0 && num2 >= this.TargetRenderPeriod)
			{
				this.RaiseRenderFrame(num2, ref totalSeconds);
			}
		}

		// Token: 0x0600064B RID: 1611 RVA: 0x00016FA0 File Offset: 0x000151A0
		private void RaiseUpdateFrame(double elapsed, ref double timestamp)
		{
			this.update_args.Time = elapsed;
			this.OnUpdateFrameInternal(this.update_args);
			this.update_period = elapsed;
			this.update_timestamp = timestamp;
			timestamp = this.watch.Elapsed.TotalSeconds;
			this.update_time = timestamp - this.update_timestamp;
		}

		// Token: 0x0600064C RID: 1612 RVA: 0x00016FF8 File Offset: 0x000151F8
		private void RaiseRenderFrame(double elapsed, ref double timestamp)
		{
			this.render_args.Time = elapsed;
			this.OnRenderFrameInternal(this.render_args);
			this.render_period = elapsed;
			this.render_timestamp = timestamp;
			timestamp = this.watch.Elapsed.TotalSeconds;
			this.render_time = timestamp - this.render_timestamp;
		}

		// Token: 0x0600064D RID: 1613 RVA: 0x00017050 File Offset: 0x00015250
		public void SwapBuffers()
		{
			base.EnsureUndisposed();
			this.Context.SwapBuffers();
		}

		// Token: 0x1700013F RID: 319
		// (get) Token: 0x0600064E RID: 1614 RVA: 0x00017064 File Offset: 0x00015264
		public IGraphicsContext Context
		{
			get
			{
				base.EnsureUndisposed();
				return this.glContext;
			}
		}

		// Token: 0x17000140 RID: 320
		// (get) Token: 0x0600064F RID: 1615 RVA: 0x00017074 File Offset: 0x00015274
		public bool IsExiting
		{
			get
			{
				base.EnsureUndisposed();
				return this.isExiting;
			}
		}

		// Token: 0x17000141 RID: 321
		// (get) Token: 0x06000650 RID: 1616 RVA: 0x00017084 File Offset: 0x00015284
		[Obsolete("Use OpenTK.Input.Joystick and GamePad instead")]
		public IList<JoystickDevice> Joysticks
		{
			get
			{
				return this.LegacyJoystick.Joysticks;
			}
		}

		// Token: 0x17000142 RID: 322
		// (get) Token: 0x06000651 RID: 1617 RVA: 0x00017094 File Offset: 0x00015294
		public KeyboardDevice Keyboard
		{
			get
			{
				if (base.InputDriver.Keyboard.Count <= 0)
				{
					return null;
				}
				return base.InputDriver.Keyboard[0];
			}
		}

		// Token: 0x17000143 RID: 323
		// (get) Token: 0x06000652 RID: 1618 RVA: 0x000170BC File Offset: 0x000152BC
		public MouseDevice Mouse
		{
			get
			{
				if (base.InputDriver.Mouse.Count <= 0)
				{
					return null;
				}
				return base.InputDriver.Mouse[0];
			}
		}

		// Token: 0x17000144 RID: 324
		// (get) Token: 0x06000653 RID: 1619 RVA: 0x000170E4 File Offset: 0x000152E4
		public double RenderFrequency
		{
			get
			{
				base.EnsureUndisposed();
				if (this.render_period == 0.0)
				{
					return 1.0;
				}
				return 1.0 / this.render_period;
			}
		}

		// Token: 0x17000145 RID: 325
		// (get) Token: 0x06000654 RID: 1620 RVA: 0x00017118 File Offset: 0x00015318
		public double RenderPeriod
		{
			get
			{
				base.EnsureUndisposed();
				return this.render_period;
			}
		}

		// Token: 0x17000146 RID: 326
		// (get) Token: 0x06000655 RID: 1621 RVA: 0x00017128 File Offset: 0x00015328
		// (set) Token: 0x06000656 RID: 1622 RVA: 0x00017138 File Offset: 0x00015338
		public double RenderTime
		{
			get
			{
				base.EnsureUndisposed();
				return this.render_time;
			}
			protected set
			{
				base.EnsureUndisposed();
				this.render_time = value;
			}
		}

		// Token: 0x17000147 RID: 327
		// (get) Token: 0x06000657 RID: 1623 RVA: 0x00017148 File Offset: 0x00015348
		// (set) Token: 0x06000658 RID: 1624 RVA: 0x0001717C File Offset: 0x0001537C
		public double TargetRenderFrequency
		{
			get
			{
				base.EnsureUndisposed();
				if (this.TargetRenderPeriod == 0.0)
				{
					return 0.0;
				}
				return 1.0 / this.TargetRenderPeriod;
			}
			set
			{
				base.EnsureUndisposed();
				if (value < 1.0)
				{
					this.TargetRenderPeriod = 0.0;
					return;
				}
				if (value <= 500.0)
				{
					this.TargetRenderPeriod = 1.0 / value;
				}
			}
		}

		// Token: 0x17000148 RID: 328
		// (get) Token: 0x06000659 RID: 1625 RVA: 0x000171C8 File Offset: 0x000153C8
		// (set) Token: 0x0600065A RID: 1626 RVA: 0x000171D8 File Offset: 0x000153D8
		public double TargetRenderPeriod
		{
			get
			{
				base.EnsureUndisposed();
				return this.target_render_period;
			}
			set
			{
				base.EnsureUndisposed();
				if (value <= 0.002)
				{
					this.target_render_period = 0.0;
					return;
				}
				if (value <= 1.0)
				{
					this.target_render_period = value;
				}
			}
		}

		// Token: 0x17000149 RID: 329
		// (get) Token: 0x0600065B RID: 1627 RVA: 0x00017210 File Offset: 0x00015410
		// (set) Token: 0x0600065C RID: 1628 RVA: 0x00017244 File Offset: 0x00015444
		public double TargetUpdateFrequency
		{
			get
			{
				base.EnsureUndisposed();
				if (this.TargetUpdatePeriod == 0.0)
				{
					return 0.0;
				}
				return 1.0 / this.TargetUpdatePeriod;
			}
			set
			{
				base.EnsureUndisposed();
				if (value < 1.0)
				{
					this.TargetUpdatePeriod = 0.0;
					return;
				}
				if (value <= 500.0)
				{
					this.TargetUpdatePeriod = 1.0 / value;
				}
			}
		}

		// Token: 0x1700014A RID: 330
		// (get) Token: 0x0600065D RID: 1629 RVA: 0x00017290 File Offset: 0x00015490
		// (set) Token: 0x0600065E RID: 1630 RVA: 0x000172A0 File Offset: 0x000154A0
		public double TargetUpdatePeriod
		{
			get
			{
				base.EnsureUndisposed();
				return this.target_update_period;
			}
			set
			{
				base.EnsureUndisposed();
				if (value <= 0.002)
				{
					this.target_update_period = 0.0;
					return;
				}
				if (value <= 1.0)
				{
					this.target_update_period = value;
				}
			}
		}

		// Token: 0x1700014B RID: 331
		// (get) Token: 0x0600065F RID: 1631 RVA: 0x000172D8 File Offset: 0x000154D8
		public double UpdateFrequency
		{
			get
			{
				base.EnsureUndisposed();
				if (this.update_period == 0.0)
				{
					return 1.0;
				}
				return 1.0 / this.update_period;
			}
		}

		// Token: 0x1700014C RID: 332
		// (get) Token: 0x06000660 RID: 1632 RVA: 0x0001730C File Offset: 0x0001550C
		public double UpdatePeriod
		{
			get
			{
				base.EnsureUndisposed();
				return this.update_period;
			}
		}

		// Token: 0x1700014D RID: 333
		// (get) Token: 0x06000661 RID: 1633 RVA: 0x0001731C File Offset: 0x0001551C
		public double UpdateTime
		{
			get
			{
				base.EnsureUndisposed();
				return this.update_time;
			}
		}

		// Token: 0x1700014E RID: 334
		// (get) Token: 0x06000662 RID: 1634 RVA: 0x0001732C File Offset: 0x0001552C
		// (set) Token: 0x06000663 RID: 1635 RVA: 0x0001735C File Offset: 0x0001555C
		public VSyncMode VSync
		{
			get
			{
				base.EnsureUndisposed();
				GraphicsContext.Assert();
				if (this.Context.SwapInterval < 0)
				{
					return VSyncMode.Adaptive;
				}
				if (this.Context.SwapInterval == 0)
				{
					return VSyncMode.Off;
				}
				return VSyncMode.On;
			}
			set
			{
				base.EnsureUndisposed();
				GraphicsContext.Assert();
				switch (value)
				{
				case VSyncMode.Off:
					this.Context.SwapInterval = 0;
					return;
				case VSyncMode.On:
					this.Context.SwapInterval = 1;
					return;
				case VSyncMode.Adaptive:
					this.Context.SwapInterval = -1;
					return;
				default:
					return;
				}
			}
		}

		// Token: 0x1700014F RID: 335
		// (get) Token: 0x06000664 RID: 1636 RVA: 0x000173B0 File Offset: 0x000155B0
		// (set) Token: 0x06000665 RID: 1637 RVA: 0x000173B8 File Offset: 0x000155B8
		public override WindowState WindowState
		{
			get
			{
				return base.WindowState;
			}
			set
			{
				base.WindowState = value;
				if (this.Context != null)
				{
					this.Context.Update(base.WindowInfo);
				}
			}
		}

		// Token: 0x1400002D RID: 45
		// (add) Token: 0x06000666 RID: 1638 RVA: 0x000173DC File Offset: 0x000155DC
		// (remove) Token: 0x06000667 RID: 1639 RVA: 0x00017414 File Offset: 0x00015614
		public event EventHandler<EventArgs> Load = delegate(object param0, EventArgs param1)
		{
		};

		// Token: 0x1400002E RID: 46
		// (add) Token: 0x06000668 RID: 1640 RVA: 0x0001744C File Offset: 0x0001564C
		// (remove) Token: 0x06000669 RID: 1641 RVA: 0x00017484 File Offset: 0x00015684
		public event EventHandler<FrameEventArgs> RenderFrame = delegate(object param0, FrameEventArgs param1)
		{
		};

		// Token: 0x1400002F RID: 47
		// (add) Token: 0x0600066A RID: 1642 RVA: 0x000174BC File Offset: 0x000156BC
		// (remove) Token: 0x0600066B RID: 1643 RVA: 0x000174F4 File Offset: 0x000156F4
		public event EventHandler<EventArgs> Unload = delegate(object param0, EventArgs param1)
		{
		};

		// Token: 0x14000030 RID: 48
		// (add) Token: 0x0600066C RID: 1644 RVA: 0x0001752C File Offset: 0x0001572C
		// (remove) Token: 0x0600066D RID: 1645 RVA: 0x00017564 File Offset: 0x00015764
		public event EventHandler<FrameEventArgs> UpdateFrame = delegate(object param0, FrameEventArgs param1)
		{
		};

		// Token: 0x0600066E RID: 1646 RVA: 0x0001759C File Offset: 0x0001579C
		protected virtual void Dispose(bool manual)
		{
		}

		// Token: 0x0600066F RID: 1647 RVA: 0x000175A0 File Offset: 0x000157A0
		protected virtual void OnRenderFrame(FrameEventArgs e)
		{
			this.RenderFrame(this, e);
		}

		// Token: 0x06000670 RID: 1648 RVA: 0x000175B0 File Offset: 0x000157B0
		protected virtual void OnUpdateFrame(FrameEventArgs e)
		{
			this.UpdateFrame(this, e);
		}

		// Token: 0x06000671 RID: 1649 RVA: 0x000175C0 File Offset: 0x000157C0
		protected virtual void OnWindowInfoChanged(EventArgs e)
		{
		}

		// Token: 0x06000672 RID: 1650 RVA: 0x000175C4 File Offset: 0x000157C4
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			this.glContext.Update(base.WindowInfo);
		}

		// Token: 0x06000673 RID: 1651 RVA: 0x000175E0 File Offset: 0x000157E0
		private void OnLoadInternal(EventArgs e)
		{
			this.OnLoad(e);
		}

		// Token: 0x06000674 RID: 1652 RVA: 0x000175EC File Offset: 0x000157EC
		private void OnRenderFrameInternal(FrameEventArgs e)
		{
			if (base.Exists && !this.isExiting)
			{
				this.OnRenderFrame(e);
			}
		}

		// Token: 0x06000675 RID: 1653 RVA: 0x00017608 File Offset: 0x00015808
		private void OnUnloadInternal(EventArgs e)
		{
			this.OnUnload(e);
		}

		// Token: 0x06000676 RID: 1654 RVA: 0x00017614 File Offset: 0x00015814
		private void OnUpdateFrameInternal(FrameEventArgs e)
		{
			if (base.Exists && !this.isExiting)
			{
				this.OnUpdateFrame(e);
			}
		}

		// Token: 0x06000677 RID: 1655 RVA: 0x00017630 File Offset: 0x00015830
		private void OnWindowInfoChangedInternal(EventArgs e)
		{
			this.glContext.MakeCurrent(base.WindowInfo);
			this.OnWindowInfoChanged(e);
		}

		// Token: 0x04000197 RID: 407
		private const double MaxFrequency = 500.0;

		// Token: 0x04000198 RID: 408
		private readonly Stopwatch watch = new Stopwatch();

		// Token: 0x04000199 RID: 409
		private readonly IJoystickDriver LegacyJoystick = Factory.Default.CreateLegacyJoystickDriver();

		// Token: 0x0400019A RID: 410
		private IGraphicsContext glContext;

		// Token: 0x0400019B RID: 411
		private bool isExiting;

		// Token: 0x0400019C RID: 412
		private double update_period;

		// Token: 0x0400019D RID: 413
		private double render_period;

		// Token: 0x0400019E RID: 414
		private double target_update_period;

		// Token: 0x0400019F RID: 415
		private double target_render_period;

		// Token: 0x040001A0 RID: 416
		private double update_time;

		// Token: 0x040001A1 RID: 417
		private double render_time;

		// Token: 0x040001A2 RID: 418
		private double update_timestamp;

		// Token: 0x040001A3 RID: 419
		private double render_timestamp;

		// Token: 0x040001A4 RID: 420
		private double update_epsilon;

		// Token: 0x040001A5 RID: 421
		private bool is_running_slowly;

		// Token: 0x040001A6 RID: 422
		private FrameEventArgs update_args = new FrameEventArgs();

		// Token: 0x040001A7 RID: 423
		private FrameEventArgs render_args = new FrameEventArgs();
	}
}
