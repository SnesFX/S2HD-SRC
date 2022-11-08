using System;
using System.Collections.Generic;
using System.Drawing;

namespace OpenTK.Platform.Linux
{
	// Token: 0x02000B7A RID: 2938
	internal class LinuxDisplayDriver : DisplayDeviceBase
	{
		// Token: 0x06005BD3 RID: 23507 RVA: 0x000F8D08 File Offset: 0x000F6F08
		public LinuxDisplayDriver(int fd)
		{
			this.FD = fd;
			this.UpdateDisplays(fd);
		}

		// Token: 0x06005BD4 RID: 23508 RVA: 0x000F8D2C File Offset: 0x000F6F2C
		internal unsafe static bool QueryDisplays(int fd, List<LinuxDisplay> displays)
		{
			bool flag = false;
			if (displays != null)
			{
				displays.Clear();
			}
			ModeRes* ptr = (ModeRes*)((void*)Drm.ModeGetResources(fd));
			if (ptr == null)
			{
				return false;
			}
			ModeConnector* ptr2 = null;
			for (int i = 0; i < ptr->count_connectors; i++)
			{
				ptr2 = (ModeConnector*)((void*)Drm.ModeGetConnector(fd, ptr->connectors[i]));
				if (ptr2 != null)
				{
					bool flag2 = false;
					LinuxDisplay item = null;
					try
					{
						if (ptr2->connection == ModeConnection.Connected && ptr2->count_modes > 0)
						{
							flag2 = LinuxDisplayDriver.QueryDisplay(fd, ptr2, out item);
							flag = (flag || flag2);
						}
					}
					catch (Exception)
					{
					}
					if (flag2 && displays != null)
					{
						displays.Add(item);
					}
					else
					{
						Drm.ModeFreeConnector((IntPtr)((void*)ptr2));
						ptr2 = null;
					}
				}
			}
			return flag;
		}

		// Token: 0x06005BD5 RID: 23509 RVA: 0x000F8DE8 File Offset: 0x000F6FE8
		private void UpdateDisplays(int fd)
		{
			lock (this)
			{
				this.AvailableDevices.Clear();
				this.DisplayIds.Clear();
				List<LinuxDisplay> list = new List<LinuxDisplay>();
				if (LinuxDisplayDriver.QueryDisplays(fd, list))
				{
					foreach (LinuxDisplay display in list)
					{
						this.AddDisplay(display);
					}
				}
				int count = this.AvailableDevices.Count;
			}
		}

		// Token: 0x06005BD6 RID: 23510 RVA: 0x000F8E84 File Offset: 0x000F7084
		private unsafe static ModeEncoder* GetEncoder(int fd, ModeConnector* c)
		{
			ModeEncoder* ptr = null;
			int num = 0;
			while (num < c->count_encoders && ptr == null)
			{
				ModeEncoder* ptr2 = (ModeEncoder*)((void*)Drm.ModeGetEncoder(fd, c->encoders[num]));
				if (ptr2 != null)
				{
					if (ptr2->encoder_id == c->encoder_id)
					{
						ptr = ptr2;
					}
					else
					{
						Drm.ModeFreeEncoder((IntPtr)((void*)ptr2));
					}
				}
				num++;
			}
			UIntPtr uintPtr = (UIntPtr)0;
			return ptr;
		}

		// Token: 0x06005BD7 RID: 23511 RVA: 0x000F8EEC File Offset: 0x000F70EC
		private unsafe static ModeCrtc* GetCrtc(int fd, ModeEncoder* encoder)
		{
			ModeCrtc* result = (ModeCrtc*)((void*)Drm.ModeGetCrtc(fd, encoder->crtc_id));
			UIntPtr uintPtr = (UIntPtr)0;
			return result;
		}

		// Token: 0x06005BD8 RID: 23512 RVA: 0x000F8F14 File Offset: 0x000F7114
		private unsafe static void GetModes(LinuxDisplay display, DisplayResolution[] modes, out DisplayResolution current)
		{
			int count_modes = display.pConnector->count_modes;
			for (int i = 0; i < count_modes; i++)
			{
				ModeInfo* ptr = display.pConnector->modes + i;
				if (ptr != null)
				{
					DisplayResolution displayResolution = LinuxDisplayDriver.GetDisplayResolution(ptr);
					modes[i] = displayResolution;
				}
			}
			if (display.pCrtc->mode_valid != 0)
			{
				ModeInfo mode = display.pCrtc->mode;
				current = LinuxDisplayDriver.GetDisplayResolution(&mode);
				return;
			}
			current = LinuxDisplayDriver.GetDisplayResolution(display.pConnector->modes);
		}

		// Token: 0x06005BD9 RID: 23513 RVA: 0x000F8F98 File Offset: 0x000F7198
		private Rectangle GetBounds(DisplayResolution current)
		{
			int x = (this.AvailableDevices.Count == 0) ? 0 : this.AvailableDevices[this.AvailableDevices.Count - 1].Bounds.Right;
			int y = 0;
			return new Rectangle(x, y, current.Width, current.Height);
		}

		// Token: 0x06005BDA RID: 23514 RVA: 0x000F8FF0 File Offset: 0x000F71F0
		private void UpdateDisplayIndices(LinuxDisplay display, DisplayDevice device)
		{
			if (!this.DisplayIds.ContainsKey(display.Id))
			{
				this.DisplayIds.Add(display.Id, this.AvailableDevices.Count);
			}
			int num = this.DisplayIds[display.Id];
			if (num >= this.AvailableDevices.Count)
			{
				this.AvailableDevices.Add(device);
				return;
			}
			this.AvailableDevices[num] = device;
		}

		// Token: 0x06005BDB RID: 23515 RVA: 0x000F9068 File Offset: 0x000F7268
		private unsafe static bool QueryDisplay(int fd, ModeConnector* c, out LinuxDisplay display)
		{
			display = null;
			ModeEncoder* encoder = LinuxDisplayDriver.GetEncoder(fd, c);
			if (encoder == null)
			{
				return false;
			}
			ModeCrtc* crtc = LinuxDisplayDriver.GetCrtc(fd, encoder);
			if (crtc == null)
			{
				return false;
			}
			display = new LinuxDisplay(fd, (IntPtr)((void*)c), (IntPtr)((void*)encoder), (IntPtr)((void*)crtc));
			return true;
		}

		// Token: 0x06005BDC RID: 23516 RVA: 0x000F90B4 File Offset: 0x000F72B4
		private unsafe void AddDisplay(LinuxDisplay display)
		{
			DisplayResolution[] array = new DisplayResolution[display.pConnector->count_modes];
			DisplayResolution displayResolution;
			LinuxDisplayDriver.GetModes(display, array, out displayResolution);
			bool flag = this.AvailableDevices.Count == 0;
			DisplayDevice displayDevice = new DisplayDevice(displayResolution, flag, array, this.GetBounds(displayResolution), display);
			if (flag)
			{
				this.Primary = displayDevice;
			}
			this.UpdateDisplayIndices(display, displayDevice);
		}

		// Token: 0x06005BDD RID: 23517 RVA: 0x000F9110 File Offset: 0x000F7310
		private unsafe static DisplayResolution GetDisplayResolution(ModeInfo* mode)
		{
			return new DisplayResolution(0, 0, (int)mode->hdisplay, (int)mode->vdisplay, 32, (float)mode->vrefresh);
		}

		// Token: 0x06005BDE RID: 23518 RVA: 0x000F9130 File Offset: 0x000F7330
		private unsafe static ModeInfo* GetModeInfo(LinuxDisplay display, DisplayResolution resolution)
		{
			for (int i = 0; i < display.pConnector->count_modes; i++)
			{
				ModeInfo* ptr = display.pConnector->modes + i;
				if (ptr != null && (int)ptr->hdisplay == resolution.Width && (int)ptr->vdisplay == resolution.Height)
				{
					return ptr;
				}
			}
			return null;
		}

		// Token: 0x06005BDF RID: 23519 RVA: 0x000F9190 File Offset: 0x000F7390
		public unsafe override bool TryChangeResolution(DisplayDevice device, DisplayResolution resolution)
		{
			LinuxDisplay linuxDisplay = (LinuxDisplay)device.Id;
			ModeInfo* modeInfo = LinuxDisplayDriver.GetModeInfo(linuxDisplay, resolution);
			int connector_id = linuxDisplay.pConnector->connector_id;
			return modeInfo != null && Drm.ModeSetCrtc(this.FD, linuxDisplay.Id, 0, 0, 0, &connector_id, 1, modeInfo) == 0;
		}

		// Token: 0x06005BE0 RID: 23520 RVA: 0x000F91E0 File Offset: 0x000F73E0
		public unsafe override bool TryRestoreResolution(DisplayDevice device)
		{
			LinuxDisplay linuxDisplay = (LinuxDisplay)device.Id;
			ModeInfo originalMode = linuxDisplay.OriginalMode;
			int connector_id = linuxDisplay.pConnector->connector_id;
			return Drm.ModeSetCrtc(this.FD, linuxDisplay.Id, 0, 0, 0, &connector_id, 1, &originalMode) == 0;
		}

		// Token: 0x0400B88E RID: 47246
		private readonly int FD;

		// Token: 0x0400B88F RID: 47247
		private readonly Dictionary<int, int> DisplayIds = new Dictionary<int, int>();
	}
}
