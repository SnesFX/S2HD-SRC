﻿using System;
using System.Runtime.InteropServices;

namespace System.Security.Policy
{
	/// <summary>Represents the context for the trust manager to consider when making the decision to run an application, and when setting up the security on a new <see cref="T:System.AppDomain" /> in which to run an application.</summary>
	// Token: 0x02000330 RID: 816
	[ComVisible(true)]
	public class TrustManagerContext
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Security.Policy.TrustManagerContext" /> class.</summary>
		// Token: 0x0600295A RID: 10586 RVA: 0x00098722 File Offset: 0x00096922
		public TrustManagerContext() : this(TrustManagerUIContext.Run)
		{
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Security.Policy.TrustManagerContext" /> class using the specified <see cref="T:System.Security.Policy.TrustManagerUIContext" /> object.</summary>
		/// <param name="uiContext">One of the <see cref="T:System.Security.Policy.TrustManagerUIContext" /> values that specifies the type of trust manager user interface to use.</param>
		// Token: 0x0600295B RID: 10587 RVA: 0x0009872B File Offset: 0x0009692B
		public TrustManagerContext(TrustManagerUIContext uiContext)
		{
			this.m_ignorePersistedDecision = false;
			this.m_uiContext = uiContext;
			this.m_keepAlive = false;
			this.m_persist = true;
		}

		/// <summary>Gets or sets the type of user interface the trust manager should display.</summary>
		/// <returns>One of the <see cref="T:System.Security.Policy.TrustManagerUIContext" /> values. The default is <see cref="F:System.Security.Policy.TrustManagerUIContext.Run" />.</returns>
		// Token: 0x1700058D RID: 1421
		// (get) Token: 0x0600295C RID: 10588 RVA: 0x0009874F File Offset: 0x0009694F
		// (set) Token: 0x0600295D RID: 10589 RVA: 0x00098757 File Offset: 0x00096957
		public virtual TrustManagerUIContext UIContext
		{
			get
			{
				return this.m_uiContext;
			}
			set
			{
				this.m_uiContext = value;
			}
		}

		/// <summary>Gets or sets a value indicating whether the trust manager should prompt the user for trust decisions.</summary>
		/// <returns>
		///   <see langword="true" /> to not prompt the user; <see langword="false" /> to prompt the user. The default is <see langword="false" />.</returns>
		// Token: 0x1700058E RID: 1422
		// (get) Token: 0x0600295E RID: 10590 RVA: 0x00098760 File Offset: 0x00096960
		// (set) Token: 0x0600295F RID: 10591 RVA: 0x00098768 File Offset: 0x00096968
		public virtual bool NoPrompt
		{
			get
			{
				return this.m_noPrompt;
			}
			set
			{
				this.m_noPrompt = value;
			}
		}

		/// <summary>Gets or sets a value indicating whether the application security manager should ignore any persisted decisions and call the trust manager.</summary>
		/// <returns>
		///   <see langword="true" /> to call the trust manager; otherwise, <see langword="false" />.</returns>
		// Token: 0x1700058F RID: 1423
		// (get) Token: 0x06002960 RID: 10592 RVA: 0x00098771 File Offset: 0x00096971
		// (set) Token: 0x06002961 RID: 10593 RVA: 0x00098779 File Offset: 0x00096979
		public virtual bool IgnorePersistedDecision
		{
			get
			{
				return this.m_ignorePersistedDecision;
			}
			set
			{
				this.m_ignorePersistedDecision = value;
			}
		}

		/// <summary>Gets or sets a value indicating whether the trust manager should cache state for this application, to facilitate future requests to determine application trust.</summary>
		/// <returns>
		///   <see langword="true" /> to cache state data; otherwise, <see langword="false" />. The default is <see langword="false" />.</returns>
		// Token: 0x17000590 RID: 1424
		// (get) Token: 0x06002962 RID: 10594 RVA: 0x00098782 File Offset: 0x00096982
		// (set) Token: 0x06002963 RID: 10595 RVA: 0x0009878A File Offset: 0x0009698A
		public virtual bool KeepAlive
		{
			get
			{
				return this.m_keepAlive;
			}
			set
			{
				this.m_keepAlive = value;
			}
		}

		/// <summary>Gets or sets a value indicating whether the user's response to the consent dialog should be persisted.</summary>
		/// <returns>
		///   <see langword="true" /> to cache state data; otherwise, <see langword="false" />. The default is <see langword="true" />.</returns>
		// Token: 0x17000591 RID: 1425
		// (get) Token: 0x06002964 RID: 10596 RVA: 0x00098793 File Offset: 0x00096993
		// (set) Token: 0x06002965 RID: 10597 RVA: 0x0009879B File Offset: 0x0009699B
		public virtual bool Persist
		{
			get
			{
				return this.m_persist;
			}
			set
			{
				this.m_persist = value;
			}
		}

		/// <summary>Gets or sets the identity of the previous application identity.</summary>
		/// <returns>An <see cref="T:System.ApplicationIdentity" /> object representing the previous <see cref="T:System.ApplicationIdentity" />.</returns>
		// Token: 0x17000592 RID: 1426
		// (get) Token: 0x06002966 RID: 10598 RVA: 0x000987A4 File Offset: 0x000969A4
		// (set) Token: 0x06002967 RID: 10599 RVA: 0x000987AC File Offset: 0x000969AC
		public virtual ApplicationIdentity PreviousApplicationIdentity
		{
			get
			{
				return this.m_appId;
			}
			set
			{
				this.m_appId = value;
			}
		}

		// Token: 0x0400108C RID: 4236
		private bool m_ignorePersistedDecision;

		// Token: 0x0400108D RID: 4237
		private TrustManagerUIContext m_uiContext;

		// Token: 0x0400108E RID: 4238
		private bool m_noPrompt;

		// Token: 0x0400108F RID: 4239
		private bool m_keepAlive;

		// Token: 0x04001090 RID: 4240
		private bool m_persist;

		// Token: 0x04001091 RID: 4241
		private ApplicationIdentity m_appId;
	}
}
