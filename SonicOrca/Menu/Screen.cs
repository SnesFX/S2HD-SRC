using System;
using System.Threading;
using System.Threading.Tasks;
using SonicOrca.Graphics;

namespace SonicOrca.Menu
{
	// Token: 0x020000A8 RID: 168
	public abstract class Screen
	{
		// Token: 0x170000BF RID: 191
		// (get) Token: 0x06000585 RID: 1413 RVA: 0x0001B8F0 File Offset: 0x00019AF0
		// (set) Token: 0x06000586 RID: 1414 RVA: 0x0001B8F8 File Offset: 0x00019AF8
		public ScreenState State { get; set; }

		// Token: 0x170000C0 RID: 192
		// (get) Token: 0x06000587 RID: 1415 RVA: 0x0001B901 File Offset: 0x00019B01
		// (set) Token: 0x06000588 RID: 1416 RVA: 0x0001B909 File Offset: 0x00019B09
		public Screen SwitchScreen { get; set; }

		// Token: 0x170000C1 RID: 193
		// (get) Token: 0x06000589 RID: 1417 RVA: 0x0001B912 File Offset: 0x00019B12
		// (set) Token: 0x0600058A RID: 1418 RVA: 0x0001B91A File Offset: 0x00019B1A
		public bool ManagerHasResponsibility { get; set; }

		// Token: 0x0600058B RID: 1419 RVA: 0x0001B923 File Offset: 0x00019B23
		public Screen()
		{
			this.State = ScreenState.Constructed;
			this.ManagerHasResponsibility = true;
		}

		// Token: 0x0600058C RID: 1420 RVA: 0x00006325 File Offset: 0x00004525
		public virtual void Initialise()
		{
		}

		// Token: 0x0600058D RID: 1421 RVA: 0x0001B939 File Offset: 0x00019B39
		public virtual Task LoadAsync(ScreenLoadingProgress progress, CancellationToken ct = default(CancellationToken))
		{
			return Task.FromResult<bool>(false);
		}

		// Token: 0x0600058E RID: 1422 RVA: 0x00006325 File Offset: 0x00004525
		public virtual void Update()
		{
		}

		// Token: 0x0600058F RID: 1423 RVA: 0x00006325 File Offset: 0x00004525
		public virtual void Draw(Renderer renderer)
		{
		}

		// Token: 0x06000590 RID: 1424 RVA: 0x00006325 File Offset: 0x00004525
		public virtual void Unload()
		{
		}

		// Token: 0x06000591 RID: 1425 RVA: 0x00006325 File Offset: 0x00004525
		public virtual void Deinitialise()
		{
		}

		// Token: 0x06000592 RID: 1426 RVA: 0x0001B941 File Offset: 0x00019B41
		protected void Finish()
		{
			this.State = ScreenState.Finished;
		}

		// Token: 0x06000593 RID: 1427 RVA: 0x0001B94A File Offset: 0x00019B4A
		protected void SwitchEfficient(Screen screen)
		{
			this.State = ScreenState.SwitchedEfficiently;
			this.SwitchScreen = screen;
		}

		// Token: 0x06000594 RID: 1428 RVA: 0x0001B95A File Offset: 0x00019B5A
		protected void Switch(Screen screen)
		{
			this.State = ScreenState.Switched;
			this.SwitchScreen = screen;
		}
	}
}
