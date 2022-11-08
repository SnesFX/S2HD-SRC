using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using OpenTK.Input;

namespace OpenTK.Platform.Linux
{
	// Token: 0x02000B7C RID: 2940
	internal sealed class LinuxJoystick : IJoystickDriver2
	{
		// Token: 0x06005BE1 RID: 23521 RVA: 0x000F922C File Offset: 0x000F742C
		public LinuxJoystick()
		{
			string text = Directory.Exists(LinuxJoystick.JoystickPath) ? LinuxJoystick.JoystickPath : (Directory.Exists(LinuxJoystick.JoystickPathLegacy) ? LinuxJoystick.JoystickPathLegacy : string.Empty);
			if (!string.IsNullOrEmpty(text))
			{
				this.watcher.Path = text;
				this.watcher.Created += this.JoystickAdded;
				this.watcher.Deleted += this.JoystickRemoved;
				this.watcher.EnableRaisingEvents = true;
				this.OpenJoysticks(text);
			}
		}

		// Token: 0x06005BE2 RID: 23522 RVA: 0x000F92EC File Offset: 0x000F74EC
		private void OpenJoysticks(string path)
		{
			lock (this.sync)
			{
				foreach (string path2 in Directory.GetFiles(path))
				{
					JoystickDevice<LinuxJoyDetails> joystickDevice = this.OpenJoystick(path2);
					if (joystickDevice != null)
					{
						this.sticks.Add(joystickDevice);
					}
				}
			}
		}

		// Token: 0x06005BE3 RID: 23523 RVA: 0x000F9354 File Offset: 0x000F7554
		private int GetJoystickNumber(string path)
		{
			int result;
			if (path.StartsWith("js") && int.TryParse(path.Substring(2), out result))
			{
				return result;
			}
			return -1;
		}

		// Token: 0x06005BE4 RID: 23524 RVA: 0x000F9384 File Offset: 0x000F7584
		private void JoystickAdded(object sender, FileSystemEventArgs e)
		{
			lock (this.sync)
			{
				this.OpenJoystick(e.FullPath);
			}
		}

		// Token: 0x06005BE5 RID: 23525 RVA: 0x000F93C4 File Offset: 0x000F75C4
		private void JoystickRemoved(object sender, FileSystemEventArgs e)
		{
			lock (this.sync)
			{
				string fileName = Path.GetFileName(e.FullPath);
				int joystickNumber = this.GetJoystickNumber(fileName);
				if (joystickNumber != -1)
				{
					int num = 0;
					while (num < this.sticks.Count && this.sticks[num].Id != joystickNumber)
					{
						num++;
					}
					if (num != this.sticks.Count)
					{
						this.CloseJoystick(this.sticks[num]);
					}
				}
			}
		}

		// Token: 0x06005BE6 RID: 23526 RVA: 0x000F945C File Offset: 0x000F765C
		private Guid CreateGuid(JoystickDevice<LinuxJoyDetails> js, string path, int number)
		{
			byte[] array = new byte[16];
			for (int i = 0; i < Math.Min(array.Length, js.Description.Length); i++)
			{
				array[i] = (byte)js.Description[i];
			}
			return new Guid(array);
		}

		// Token: 0x06005BE7 RID: 23527 RVA: 0x000F94A8 File Offset: 0x000F76A8
		private JoystickDevice<LinuxJoyDetails> OpenJoystick(string path)
		{
			JoystickDevice<LinuxJoyDetails> joystickDevice = null;
			int joystickNumber = this.GetJoystickNumber(Path.GetFileName(path));
			if (joystickNumber >= 0)
			{
				int num = -1;
				try
				{
					num = Libc.open(path, OpenFlags.NonBlock);
					if (num == -1)
					{
						return null;
					}
					int num2 = 2048;
					Libc.ioctl(num, (JoystickIoctlCode)2147772929U, ref num2);
					if (num2 < 65536)
					{
						return null;
					}
					int axes = 0;
					Libc.ioctl(num, (JoystickIoctlCode)2147576337U, ref axes);
					int buttons = 0;
					Libc.ioctl(num, (JoystickIoctlCode)2147576338U, ref buttons);
					joystickDevice = new JoystickDevice<LinuxJoyDetails>(joystickNumber, axes, buttons);
					StringBuilder stringBuilder = new StringBuilder(128);
					Libc.ioctl(num, (JoystickIoctlCode)2155899411U, stringBuilder);
					joystickDevice.Description = stringBuilder.ToString();
					joystickDevice.Details.FileDescriptor = num;
					joystickDevice.Details.State.SetIsConnected(true);
					joystickDevice.Details.Guid = this.CreateGuid(joystickDevice, path, joystickNumber);
					int num3 = 0;
					while (num3 < this.sticks.Count && this.sticks[num3].Details.State.IsConnected)
					{
						num3++;
					}
					if (num3 == this.sticks.Count)
					{
						this.sticks.Add(joystickDevice);
					}
					else
					{
						this.sticks[num3] = joystickDevice;
					}
					this.index_to_stick.Add(this.index_to_stick.Count, num3);
				}
				finally
				{
					if (joystickDevice == null && num != -1)
					{
						Libc.close(num);
					}
				}
				return joystickDevice;
			}
			return joystickDevice;
		}

		// Token: 0x06005BE8 RID: 23528 RVA: 0x000F963C File Offset: 0x000F783C
		private void CloseJoystick(JoystickDevice<LinuxJoyDetails> js)
		{
			Libc.close(js.Details.FileDescriptor);
			js.Details.State = default(JoystickState);
			js.Details.FileDescriptor = -1;
			int key = -1;
			foreach (int num in this.index_to_stick.Keys)
			{
				if (this.sticks[this.index_to_stick[num]] == js)
				{
					key = num;
					break;
				}
			}
			if (this.index_to_stick.ContainsKey(key))
			{
				this.index_to_stick.Remove(key);
			}
		}

		// Token: 0x06005BE9 RID: 23529 RVA: 0x000F96F8 File Offset: 0x000F78F8
		private unsafe void PollJoystick(JoystickDevice<LinuxJoyDetails> js)
		{
			JoystickEvent joystickEvent;
			while ((long)Libc.read(js.Details.FileDescriptor, (void*)(&joystickEvent), (UIntPtr)((ulong)((long)sizeof(JoystickEvent)))) > 0L)
			{
				joystickEvent.Type &= ~JoystickEventType.Init;
				switch (joystickEvent.Type)
				{
				case JoystickEventType.Button:
					js.Details.State.SetButton((JoystickButton)joystickEvent.Number, joystickEvent.Value != 0);
					break;
				case JoystickEventType.Axis:
					if (joystickEvent.Number % 2 == 0)
					{
						js.Details.State.SetAxis((JoystickAxis)joystickEvent.Number, joystickEvent.Value);
					}
					else
					{
						js.Details.State.SetAxis((JoystickAxis)joystickEvent.Number, -joystickEvent.Value);
					}
					break;
				}
				js.Details.State.SetPacketNumber((int)joystickEvent.Time);
			}
		}

		// Token: 0x06005BEA RID: 23530 RVA: 0x000F97E8 File Offset: 0x000F79E8
		private bool IsValid(int index)
		{
			return this.index_to_stick.ContainsKey(index);
		}

		// Token: 0x06005BEB RID: 23531 RVA: 0x000F97F8 File Offset: 0x000F79F8
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x06005BEC RID: 23532 RVA: 0x000F9808 File Offset: 0x000F7A08
		private void Dispose(bool manual)
		{
			if (!this.disposed)
			{
				this.watcher.Dispose();
				foreach (JoystickDevice<LinuxJoyDetails> js in this.sticks)
				{
					this.CloseJoystick(js);
				}
				this.disposed = true;
			}
		}

		// Token: 0x06005BED RID: 23533 RVA: 0x000F9878 File Offset: 0x000F7A78
		~LinuxJoystick()
		{
			this.Dispose(false);
		}

		// Token: 0x06005BEE RID: 23534 RVA: 0x000F98A8 File Offset: 0x000F7AA8
		JoystickState IJoystickDriver2.GetState(int index)
		{
			if (this.IsValid(index))
			{
				JoystickDevice<LinuxJoyDetails> joystickDevice = this.sticks[this.index_to_stick[index]];
				this.PollJoystick(joystickDevice);
				return joystickDevice.Details.State;
			}
			return default(JoystickState);
		}

		// Token: 0x06005BEF RID: 23535 RVA: 0x000F98F4 File Offset: 0x000F7AF4
		JoystickCapabilities IJoystickDriver2.GetCapabilities(int index)
		{
			JoystickCapabilities result = default(JoystickCapabilities);
			if (this.IsValid(index))
			{
				JoystickDevice<LinuxJoyDetails> joystickDevice = this.sticks[this.index_to_stick[index]];
				result = new JoystickCapabilities(joystickDevice.Axis.Count, joystickDevice.Button.Count, 0, joystickDevice.Details.State.IsConnected);
			}
			return result;
		}

		// Token: 0x06005BF0 RID: 23536 RVA: 0x000F995C File Offset: 0x000F7B5C
		Guid IJoystickDriver2.GetGuid(int index)
		{
			if (this.IsValid(index))
			{
				JoystickDevice<LinuxJoyDetails> joystickDevice = this.sticks[this.index_to_stick[index]];
				return joystickDevice.Details.Guid;
			}
			return default(Guid);
		}

		// Token: 0x0400B893 RID: 47251
		private readonly object sync = new object();

		// Token: 0x0400B894 RID: 47252
		private readonly FileSystemWatcher watcher = new FileSystemWatcher();

		// Token: 0x0400B895 RID: 47253
		private readonly Dictionary<int, int> index_to_stick = new Dictionary<int, int>();

		// Token: 0x0400B896 RID: 47254
		private List<JoystickDevice<LinuxJoyDetails>> sticks = new List<JoystickDevice<LinuxJoyDetails>>();

		// Token: 0x0400B897 RID: 47255
		private bool disposed;

		// Token: 0x0400B898 RID: 47256
		private static readonly string JoystickPath = "/dev/input";

		// Token: 0x0400B899 RID: 47257
		private static readonly string JoystickPathLegacy = "/dev";
	}
}
