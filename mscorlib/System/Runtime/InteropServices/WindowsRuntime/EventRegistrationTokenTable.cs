﻿using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;

namespace System.Runtime.InteropServices.WindowsRuntime
{
	/// <summary>Stores mappings between delegates and event tokens, to support the implementation of a Windows Runtime event in managed code.</summary>
	/// <typeparam name="T">The type of the event handler delegate for a particular event.</typeparam>
	// Token: 0x020009B4 RID: 2484
	[__DynamicallyInvokable]
	public sealed class EventRegistrationTokenTable<T> where T : class
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.InteropServices.WindowsRuntime.EventRegistrationTokenTable`1" /> class.</summary>
		/// <exception cref="T:System.InvalidOperationException">
		///   <paramref name="T" /> is not a delegate type.</exception>
		// Token: 0x0600635A RID: 25434 RVA: 0x00151BB0 File Offset: 0x0014FDB0
		[__DynamicallyInvokable]
		public EventRegistrationTokenTable()
		{
			if (!typeof(Delegate).IsAssignableFrom(typeof(T)))
			{
				throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_EventTokenTableRequiresDelegate", new object[]
				{
					typeof(T)
				}));
			}
		}

		/// <summary>Gets or sets a delegate of type <paramref name="T" /> whose invocation list includes all the event handler delegates that have been added, and that have not yet been removed. Invoking this delegate invokes all the event handlers.</summary>
		/// <returns>A delegate of type <paramref name="T" /> that represents all the event handler delegates that are currently registered for an event.</returns>
		// Token: 0x1700113B RID: 4411
		// (get) Token: 0x0600635B RID: 25435 RVA: 0x00151C0C File Offset: 0x0014FE0C
		// (set) Token: 0x0600635C RID: 25436 RVA: 0x00151C18 File Offset: 0x0014FE18
		[__DynamicallyInvokable]
		public T InvocationList
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_invokeList;
			}
			[__DynamicallyInvokable]
			set
			{
				Dictionary<EventRegistrationToken, T> tokens = this.m_tokens;
				lock (tokens)
				{
					this.m_tokens.Clear();
					this.m_invokeList = default(T);
					if (value != null)
					{
						this.AddEventHandlerNoLock(value);
					}
				}
			}
		}

		/// <summary>Adds the specified event handler to the table and to the invocation list, and returns a token that can be used to remove the event handler.</summary>
		/// <param name="handler">The event handler to add.</param>
		/// <returns>A token that can be used to remove the event handler from the table and the invocation list.</returns>
		// Token: 0x0600635D RID: 25437 RVA: 0x00151C80 File Offset: 0x0014FE80
		[__DynamicallyInvokable]
		public EventRegistrationToken AddEventHandler(T handler)
		{
			if (handler == null)
			{
				return new EventRegistrationToken(0UL);
			}
			Dictionary<EventRegistrationToken, T> tokens = this.m_tokens;
			EventRegistrationToken result;
			lock (tokens)
			{
				result = this.AddEventHandlerNoLock(handler);
			}
			return result;
		}

		// Token: 0x0600635E RID: 25438 RVA: 0x00151CD4 File Offset: 0x0014FED4
		private EventRegistrationToken AddEventHandlerNoLock(T handler)
		{
			EventRegistrationToken preferredToken = EventRegistrationTokenTable<T>.GetPreferredToken(handler);
			while (this.m_tokens.ContainsKey(preferredToken))
			{
				preferredToken = new EventRegistrationToken(preferredToken.Value + 1UL);
			}
			this.m_tokens[preferredToken] = handler;
			Delegate @delegate = (Delegate)((object)this.m_invokeList);
			@delegate = Delegate.Combine(@delegate, (Delegate)((object)handler));
			this.m_invokeList = (T)((object)@delegate);
			return preferredToken;
		}

		// Token: 0x0600635F RID: 25439 RVA: 0x00151D4C File Offset: 0x0014FF4C
		[FriendAccessAllowed]
		internal T ExtractHandler(EventRegistrationToken token)
		{
			T result = default(T);
			Dictionary<EventRegistrationToken, T> tokens = this.m_tokens;
			lock (tokens)
			{
				if (this.m_tokens.TryGetValue(token, out result))
				{
					this.RemoveEventHandlerNoLock(token);
				}
			}
			return result;
		}

		// Token: 0x06006360 RID: 25440 RVA: 0x00151DA8 File Offset: 0x0014FFA8
		private static EventRegistrationToken GetPreferredToken(T handler)
		{
			Delegate[] invocationList = ((Delegate)((object)handler)).GetInvocationList();
			uint hashCode;
			if (invocationList.Length == 1)
			{
				hashCode = (uint)invocationList[0].Method.GetHashCode();
			}
			else
			{
				hashCode = (uint)handler.GetHashCode();
			}
			ulong value = (ulong)typeof(T).MetadataToken << 32 | (ulong)hashCode;
			return new EventRegistrationToken(value);
		}

		/// <summary>Removes the event handler that is associated with the specified token from the table and the invocation list.</summary>
		/// <param name="token">The token that was returned when the event handler was added.</param>
		// Token: 0x06006361 RID: 25441 RVA: 0x00151E08 File Offset: 0x00150008
		[__DynamicallyInvokable]
		public void RemoveEventHandler(EventRegistrationToken token)
		{
			if (token.Value == 0UL)
			{
				return;
			}
			Dictionary<EventRegistrationToken, T> tokens = this.m_tokens;
			lock (tokens)
			{
				this.RemoveEventHandlerNoLock(token);
			}
		}

		/// <summary>Removes the specified event handler delegate from the table and the invocation list.</summary>
		/// <param name="handler">The event handler to remove.</param>
		// Token: 0x06006362 RID: 25442 RVA: 0x00151E54 File Offset: 0x00150054
		[__DynamicallyInvokable]
		public void RemoveEventHandler(T handler)
		{
			if (handler == null)
			{
				return;
			}
			Dictionary<EventRegistrationToken, T> tokens = this.m_tokens;
			lock (tokens)
			{
				EventRegistrationToken preferredToken = EventRegistrationTokenTable<T>.GetPreferredToken(handler);
				T t;
				if (this.m_tokens.TryGetValue(preferredToken, out t) && t == handler)
				{
					this.RemoveEventHandlerNoLock(preferredToken);
				}
				else
				{
					foreach (KeyValuePair<EventRegistrationToken, T> keyValuePair in this.m_tokens)
					{
						if (keyValuePair.Value == (T)((object)handler))
						{
							this.RemoveEventHandlerNoLock(keyValuePair.Key);
							break;
						}
					}
				}
			}
		}

		// Token: 0x06006363 RID: 25443 RVA: 0x00151F30 File Offset: 0x00150130
		private void RemoveEventHandlerNoLock(EventRegistrationToken token)
		{
			T t;
			if (this.m_tokens.TryGetValue(token, out t))
			{
				this.m_tokens.Remove(token);
				Delegate @delegate = (Delegate)((object)this.m_invokeList);
				@delegate = Delegate.Remove(@delegate, (Delegate)((object)t));
				this.m_invokeList = (T)((object)@delegate);
			}
		}

		/// <summary>Returns the specified event registration token table, if it is not <see langword="null" />; otherwise, returns a new event registration token table.</summary>
		/// <param name="refEventTable">An event registration token table, passed by reference.</param>
		/// <returns>The event registration token table that is specified by <paramref name="refEventTable" />, if it is not <see langword="null" />; otherwise, a new event registration token table.</returns>
		// Token: 0x06006364 RID: 25444 RVA: 0x00151F8D File Offset: 0x0015018D
		[__DynamicallyInvokable]
		public static EventRegistrationTokenTable<T> GetOrCreateEventRegistrationTokenTable(ref EventRegistrationTokenTable<T> refEventTable)
		{
			if (refEventTable == null)
			{
				Interlocked.CompareExchange<EventRegistrationTokenTable<T>>(ref refEventTable, new EventRegistrationTokenTable<T>(), null);
			}
			return refEventTable;
		}

		// Token: 0x04002C35 RID: 11317
		private Dictionary<EventRegistrationToken, T> m_tokens = new Dictionary<EventRegistrationToken, T>();

		// Token: 0x04002C36 RID: 11318
		private volatile T m_invokeList;
	}
}
