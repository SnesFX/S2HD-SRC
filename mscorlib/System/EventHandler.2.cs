﻿using System;

namespace System
{
	/// <summary>Represents the method that will handle an event when the event provides data.</summary>
	/// <param name="sender">The source of the event.</param>
	/// <param name="e">An object that contains the event data.</param>
	/// <typeparam name="TEventArgs">The type of the event data generated by the event.</typeparam>
	// Token: 0x020000E1 RID: 225
	// (Invoke) Token: 0x06000E7B RID: 3707
	[__DynamicallyInvokable]
	[Serializable]
	public delegate void EventHandler<TEventArgs>(object sender, TEventArgs e);
}
