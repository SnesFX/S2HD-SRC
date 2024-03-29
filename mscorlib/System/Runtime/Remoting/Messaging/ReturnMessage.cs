﻿using System;
using System.Collections;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Metadata;
using System.Security;
using System.Security.Permissions;
using System.Threading;

namespace System.Runtime.Remoting.Messaging
{
	/// <summary>Holds a message returned in response to a method call on a remote object.</summary>
	// Token: 0x0200083B RID: 2107
	[SecurityCritical]
	[ComVisible(true)]
	[SecurityPermission(SecurityAction.InheritanceDemand, Flags = SecurityPermissionFlag.Infrastructure)]
	public class ReturnMessage : IMethodReturnMessage, IMethodMessage, IMessage
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.Remoting.Messaging.ReturnMessage" /> class with all the information returning to the caller after the method call.</summary>
		/// <param name="ret">The object returned by the invoked method from which the current <see cref="T:System.Runtime.Remoting.Messaging.ReturnMessage" /> instance originated.</param>
		/// <param name="outArgs">The objects returned from the invoked method as <see langword="out" /> parameters.</param>
		/// <param name="outArgsCount">The number of <see langword="out" /> parameters returned from the invoked method.</param>
		/// <param name="callCtx">The <see cref="T:System.Runtime.Remoting.Messaging.LogicalCallContext" /> of the method call.</param>
		/// <param name="mcm">The original method call to the invoked method.</param>
		// Token: 0x06005A2C RID: 23084 RVA: 0x0013B44C File Offset: 0x0013964C
		[SecurityCritical]
		public ReturnMessage(object ret, object[] outArgs, int outArgsCount, LogicalCallContext callCtx, IMethodCallMessage mcm)
		{
			this._ret = ret;
			this._outArgs = outArgs;
			this._outArgsCount = outArgsCount;
			if (callCtx != null)
			{
				this._callContext = callCtx;
			}
			else
			{
				this._callContext = Thread.CurrentThread.GetMutableExecutionContext().LogicalCallContext;
			}
			if (mcm != null)
			{
				this._URI = mcm.Uri;
				this._methodName = mcm.MethodName;
				this._methodSignature = null;
				this._typeName = mcm.TypeName;
				this._hasVarArgs = mcm.HasVarArgs;
				this._methodBase = mcm.MethodBase;
			}
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.Remoting.Messaging.ReturnMessage" /> class.</summary>
		/// <param name="e">The exception that was thrown during execution of the remotely called method.</param>
		/// <param name="mcm">An <see cref="T:System.Runtime.Remoting.Messaging.IMethodCallMessage" /> with which to create an instance of the <see cref="T:System.Runtime.Remoting.Messaging.ReturnMessage" /> class.</param>
		// Token: 0x06005A2D RID: 23085 RVA: 0x0013B4E4 File Offset: 0x001396E4
		[SecurityCritical]
		public ReturnMessage(Exception e, IMethodCallMessage mcm)
		{
			this._e = (ReturnMessage.IsCustomErrorEnabled() ? new RemotingException(Environment.GetResourceString("Remoting_InternalError")) : e);
			this._callContext = Thread.CurrentThread.GetMutableExecutionContext().LogicalCallContext;
			if (mcm != null)
			{
				this._URI = mcm.Uri;
				this._methodName = mcm.MethodName;
				this._methodSignature = null;
				this._typeName = mcm.TypeName;
				this._hasVarArgs = mcm.HasVarArgs;
				this._methodBase = mcm.MethodBase;
			}
		}

		/// <summary>Gets or sets the URI of the remote object on which the remote method was called.</summary>
		/// <returns>The URI of the remote object on which the remote method was called.</returns>
		// Token: 0x17000F5D RID: 3933
		// (get) Token: 0x06005A2E RID: 23086 RVA: 0x0013B571 File Offset: 0x00139771
		// (set) Token: 0x06005A2F RID: 23087 RVA: 0x0013B579 File Offset: 0x00139779
		public string Uri
		{
			[SecurityCritical]
			get
			{
				return this._URI;
			}
			set
			{
				this._URI = value;
			}
		}

		/// <summary>Gets the name of the called method.</summary>
		/// <returns>The name of the method that the current <see cref="T:System.Runtime.Remoting.Messaging.ReturnMessage" /> originated from.</returns>
		// Token: 0x17000F5E RID: 3934
		// (get) Token: 0x06005A30 RID: 23088 RVA: 0x0013B582 File Offset: 0x00139782
		public string MethodName
		{
			[SecurityCritical]
			get
			{
				return this._methodName;
			}
		}

		/// <summary>Gets the name of the type on which the remote method was called.</summary>
		/// <returns>The type name of the remote object on which the remote method was called.</returns>
		// Token: 0x17000F5F RID: 3935
		// (get) Token: 0x06005A31 RID: 23089 RVA: 0x0013B58A File Offset: 0x0013978A
		public string TypeName
		{
			[SecurityCritical]
			get
			{
				return this._typeName;
			}
		}

		/// <summary>Gets an array of <see cref="T:System.Type" /> objects containing the method signature.</summary>
		/// <returns>An array of <see cref="T:System.Type" /> objects containing the method signature.</returns>
		// Token: 0x17000F60 RID: 3936
		// (get) Token: 0x06005A32 RID: 23090 RVA: 0x0013B592 File Offset: 0x00139792
		public object MethodSignature
		{
			[SecurityCritical]
			get
			{
				if (this._methodSignature == null && this._methodBase != null)
				{
					this._methodSignature = Message.GenerateMethodSignature(this._methodBase);
				}
				return this._methodSignature;
			}
		}

		/// <summary>Gets the <see cref="T:System.Reflection.MethodBase" /> of the called method.</summary>
		/// <returns>The <see cref="T:System.Reflection.MethodBase" /> of the called method.</returns>
		// Token: 0x17000F61 RID: 3937
		// (get) Token: 0x06005A33 RID: 23091 RVA: 0x0013B5C1 File Offset: 0x001397C1
		public MethodBase MethodBase
		{
			[SecurityCritical]
			get
			{
				return this._methodBase;
			}
		}

		/// <summary>Gets a value indicating whether the called method accepts a variable number of arguments.</summary>
		/// <returns>
		///   <see langword="true" /> if the called method accepts a variable number of arguments; otherwise, <see langword="false" />.</returns>
		// Token: 0x17000F62 RID: 3938
		// (get) Token: 0x06005A34 RID: 23092 RVA: 0x0013B5C9 File Offset: 0x001397C9
		public bool HasVarArgs
		{
			[SecurityCritical]
			get
			{
				return this._hasVarArgs;
			}
		}

		/// <summary>Gets the number of arguments of the called method.</summary>
		/// <returns>The number of arguments of the called method.</returns>
		// Token: 0x17000F63 RID: 3939
		// (get) Token: 0x06005A35 RID: 23093 RVA: 0x0013B5D1 File Offset: 0x001397D1
		public int ArgCount
		{
			[SecurityCritical]
			get
			{
				if (this._outArgs == null)
				{
					return this._outArgsCount;
				}
				return this._outArgs.Length;
			}
		}

		/// <summary>Returns a specified argument passed to the remote method during the method call.</summary>
		/// <param name="argNum">The zero-based index of the requested argument.</param>
		/// <returns>An argument passed to the remote method during the method call.</returns>
		// Token: 0x06005A36 RID: 23094 RVA: 0x0013B5EC File Offset: 0x001397EC
		[SecurityCritical]
		public object GetArg(int argNum)
		{
			if (this._outArgs == null)
			{
				if (argNum < 0 || argNum >= this._outArgsCount)
				{
					throw new ArgumentOutOfRangeException("argNum");
				}
				return null;
			}
			else
			{
				if (argNum < 0 || argNum >= this._outArgs.Length)
				{
					throw new ArgumentOutOfRangeException("argNum");
				}
				return this._outArgs[argNum];
			}
		}

		/// <summary>Returns the name of a specified method argument.</summary>
		/// <param name="index">The zero-based index of the requested argument name.</param>
		/// <returns>The name of a specified method argument.</returns>
		// Token: 0x06005A37 RID: 23095 RVA: 0x0013B640 File Offset: 0x00139840
		[SecurityCritical]
		public string GetArgName(int index)
		{
			if (this._outArgs == null)
			{
				if (index < 0 || index >= this._outArgsCount)
				{
					throw new ArgumentOutOfRangeException("index");
				}
			}
			else if (index < 0 || index >= this._outArgs.Length)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			if (this._methodBase != null)
			{
				RemotingMethodCachedData reflectionCachedData = InternalRemotingServices.GetReflectionCachedData(this._methodBase);
				return reflectionCachedData.Parameters[index].Name;
			}
			return "__param" + index;
		}

		/// <summary>Gets a specified argument passed to the method called on the remote object.</summary>
		/// <returns>An argument passed to the method called on the remote object.</returns>
		// Token: 0x17000F64 RID: 3940
		// (get) Token: 0x06005A38 RID: 23096 RVA: 0x0013B6BF File Offset: 0x001398BF
		public object[] Args
		{
			[SecurityCritical]
			get
			{
				if (this._outArgs == null)
				{
					return new object[this._outArgsCount];
				}
				return this._outArgs;
			}
		}

		/// <summary>Gets the number of <see langword="out" /> or <see langword="ref" /> arguments on the called method.</summary>
		/// <returns>The number of <see langword="out" /> or <see langword="ref" /> arguments on the called method.</returns>
		// Token: 0x17000F65 RID: 3941
		// (get) Token: 0x06005A39 RID: 23097 RVA: 0x0013B6DB File Offset: 0x001398DB
		public int OutArgCount
		{
			[SecurityCritical]
			get
			{
				if (this._argMapper == null)
				{
					this._argMapper = new ArgMapper(this, true);
				}
				return this._argMapper.ArgCount;
			}
		}

		/// <summary>Returns the object passed as an <see langword="out" /> or <see langword="ref" /> parameter during the remote method call.</summary>
		/// <param name="argNum">The zero-based index of the requested <see langword="out" /> or <see langword="ref" /> parameter.</param>
		/// <returns>The object passed as an <see langword="out" /> or <see langword="ref" /> parameter during the remote method call.</returns>
		// Token: 0x06005A3A RID: 23098 RVA: 0x0013B6FD File Offset: 0x001398FD
		[SecurityCritical]
		public object GetOutArg(int argNum)
		{
			if (this._argMapper == null)
			{
				this._argMapper = new ArgMapper(this, true);
			}
			return this._argMapper.GetArg(argNum);
		}

		/// <summary>Returns the name of a specified <see langword="out" /> or <see langword="ref" /> parameter passed to the remote method.</summary>
		/// <param name="index">The zero-based index of the requested argument.</param>
		/// <returns>A string representing the name of the specified <see langword="out" /> or <see langword="ref" /> parameter, or <see langword="null" /> if the current method is not implemented.</returns>
		// Token: 0x06005A3B RID: 23099 RVA: 0x0013B720 File Offset: 0x00139920
		[SecurityCritical]
		public string GetOutArgName(int index)
		{
			if (this._argMapper == null)
			{
				this._argMapper = new ArgMapper(this, true);
			}
			return this._argMapper.GetArgName(index);
		}

		/// <summary>Gets a specified object passed as an <see langword="out" /> or <see langword="ref" /> parameter to the called method.</summary>
		/// <returns>An object passed as an <see langword="out" /> or <see langword="ref" /> parameter to the called method.</returns>
		// Token: 0x17000F66 RID: 3942
		// (get) Token: 0x06005A3C RID: 23100 RVA: 0x0013B743 File Offset: 0x00139943
		public object[] OutArgs
		{
			[SecurityCritical]
			get
			{
				if (this._argMapper == null)
				{
					this._argMapper = new ArgMapper(this, true);
				}
				return this._argMapper.Args;
			}
		}

		/// <summary>Gets the exception that was thrown during the remote method call.</summary>
		/// <returns>The exception thrown during the method call, or <see langword="null" /> if an exception did not occur during the call.</returns>
		// Token: 0x17000F67 RID: 3943
		// (get) Token: 0x06005A3D RID: 23101 RVA: 0x0013B765 File Offset: 0x00139965
		public Exception Exception
		{
			[SecurityCritical]
			get
			{
				return this._e;
			}
		}

		/// <summary>Gets the object returned by the called method.</summary>
		/// <returns>The object returned by the called method.</returns>
		// Token: 0x17000F68 RID: 3944
		// (get) Token: 0x06005A3E RID: 23102 RVA: 0x0013B76D File Offset: 0x0013996D
		public virtual object ReturnValue
		{
			[SecurityCritical]
			get
			{
				return this._ret;
			}
		}

		/// <summary>Gets an <see cref="T:System.Collections.IDictionary" /> of properties contained in the current <see cref="T:System.Runtime.Remoting.Messaging.ReturnMessage" />.</summary>
		/// <returns>An <see cref="T:System.Collections.IDictionary" /> of properties contained in the current <see cref="T:System.Runtime.Remoting.Messaging.ReturnMessage" />.</returns>
		// Token: 0x17000F69 RID: 3945
		// (get) Token: 0x06005A3F RID: 23103 RVA: 0x0013B775 File Offset: 0x00139975
		public virtual IDictionary Properties
		{
			[SecurityCritical]
			get
			{
				if (this._properties == null)
				{
					this._properties = new MRMDictionary(this, null);
				}
				return (MRMDictionary)this._properties;
			}
		}

		/// <summary>Gets the <see cref="T:System.Runtime.Remoting.Messaging.LogicalCallContext" /> of the called method.</summary>
		/// <returns>The <see cref="T:System.Runtime.Remoting.Messaging.LogicalCallContext" /> of the called method.</returns>
		// Token: 0x17000F6A RID: 3946
		// (get) Token: 0x06005A40 RID: 23104 RVA: 0x0013B797 File Offset: 0x00139997
		public LogicalCallContext LogicalCallContext
		{
			[SecurityCritical]
			get
			{
				return this.GetLogicalCallContext();
			}
		}

		// Token: 0x06005A41 RID: 23105 RVA: 0x0013B79F File Offset: 0x0013999F
		[SecurityCritical]
		internal LogicalCallContext GetLogicalCallContext()
		{
			if (this._callContext == null)
			{
				this._callContext = new LogicalCallContext();
			}
			return this._callContext;
		}

		// Token: 0x06005A42 RID: 23106 RVA: 0x0013B7BC File Offset: 0x001399BC
		internal LogicalCallContext SetLogicalCallContext(LogicalCallContext ctx)
		{
			LogicalCallContext callContext = this._callContext;
			this._callContext = ctx;
			return callContext;
		}

		// Token: 0x06005A43 RID: 23107 RVA: 0x0013B7D8 File Offset: 0x001399D8
		internal bool HasProperties()
		{
			return this._properties != null;
		}

		// Token: 0x06005A44 RID: 23108 RVA: 0x0013B7E4 File Offset: 0x001399E4
		[SecurityCritical]
		internal static bool IsCustomErrorEnabled()
		{
			object data = CallContext.GetData("__CustomErrorsEnabled");
			return data != null && (bool)data;
		}

		// Token: 0x04002892 RID: 10386
		internal object _ret;

		// Token: 0x04002893 RID: 10387
		internal object _properties;

		// Token: 0x04002894 RID: 10388
		internal string _URI;

		// Token: 0x04002895 RID: 10389
		internal Exception _e;

		// Token: 0x04002896 RID: 10390
		internal object[] _outArgs;

		// Token: 0x04002897 RID: 10391
		internal int _outArgsCount;

		// Token: 0x04002898 RID: 10392
		internal string _methodName;

		// Token: 0x04002899 RID: 10393
		internal string _typeName;

		// Token: 0x0400289A RID: 10394
		internal Type[] _methodSignature;

		// Token: 0x0400289B RID: 10395
		internal bool _hasVarArgs;

		// Token: 0x0400289C RID: 10396
		internal LogicalCallContext _callContext;

		// Token: 0x0400289D RID: 10397
		internal ArgMapper _argMapper;

		// Token: 0x0400289E RID: 10398
		internal MethodBase _methodBase;
	}
}
