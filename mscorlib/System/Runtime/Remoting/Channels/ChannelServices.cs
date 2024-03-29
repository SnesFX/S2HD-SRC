﻿using System;
using System.Collections;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Metadata;
using System.Runtime.Remoting.Proxies;
using System.Security;
using System.Security.Permissions;
using System.Threading;

namespace System.Runtime.Remoting.Channels
{
	/// <summary>Provides static methods to aid with remoting channel registration, resolution, and URL discovery. This class cannot be inherited.</summary>
	// Token: 0x020007FA RID: 2042
	[ComVisible(true)]
	public sealed class ChannelServices
	{
		// Token: 0x17000EBF RID: 3775
		// (get) Token: 0x06005850 RID: 22608 RVA: 0x001366CA File Offset: 0x001348CA
		internal static object[] CurrentChannelData
		{
			[SecurityCritical]
			get
			{
				if (ChannelServices.s_currentChannelData == null)
				{
					ChannelServices.RefreshChannelData();
				}
				return ChannelServices.s_currentChannelData;
			}
		}

		// Token: 0x06005851 RID: 22609 RVA: 0x001366E1 File Offset: 0x001348E1
		private ChannelServices()
		{
		}

		// Token: 0x17000EC0 RID: 3776
		// (get) Token: 0x06005852 RID: 22610 RVA: 0x001366E9 File Offset: 0x001348E9
		// (set) Token: 0x06005853 RID: 22611 RVA: 0x001366FF File Offset: 0x001348FF
		private static long remoteCalls
		{
			get
			{
				return Thread.GetDomain().RemotingData.ChannelServicesData.remoteCalls;
			}
			set
			{
				Thread.GetDomain().RemotingData.ChannelServicesData.remoteCalls = value;
			}
		}

		// Token: 0x06005854 RID: 22612
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private unsafe static extern Perf_Contexts* GetPrivateContextsPerfCounters();

		/// <summary>Registers a channel with the channel services.</summary>
		/// <param name="chnl">The channel to register.</param>
		/// <param name="ensureSecurity">
		///   <see langword="true" /> ensures that security is enabled; otherwise <see langword="false" />. Setting the value to <see langword="false" /> does not effect the security setting on the TCP or IPC channel.</param>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="chnl" /> parameter is <see langword="null" />.</exception>
		/// <exception cref="T:System.Runtime.Remoting.RemotingException">The channel has already been registered.</exception>
		/// <exception cref="T:System.Security.SecurityException">At least one of the callers higher in the call stack does not have permission to configure remoting types and channels.</exception>
		/// <exception cref="T:System.NotSupportedException">Not supported in Windows 98 for <see cref="T:System.Runtime.Remoting.Channels.Tcp.TcpServerChannel" /> and on all platforms for <see cref="T:System.Runtime.Remoting.Channels.Http.HttpServerChannel" />. Host the service using Internet Information Services (IIS) if you require a secure HTTP channel.</exception>
		// Token: 0x06005855 RID: 22613 RVA: 0x00136716 File Offset: 0x00134916
		[SecuritySafeCritical]
		[SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.RemotingConfiguration)]
		public static void RegisterChannel(IChannel chnl, bool ensureSecurity)
		{
			ChannelServices.RegisterChannelInternal(chnl, ensureSecurity);
		}

		/// <summary>Registers a channel with the channel services. <see cref="M:System.Runtime.Remoting.Channels.ChannelServices.RegisterChannel(System.Runtime.Remoting.Channels.IChannel)" /> is obsolete. Please use <see cref="M:System.Runtime.Remoting.Channels.ChannelServices.RegisterChannel(System.Runtime.Remoting.Channels.IChannel,System.Boolean)" /> instead.</summary>
		/// <param name="chnl">The channel to register.</param>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="chnl" /> parameter is <see langword="null" />.</exception>
		/// <exception cref="T:System.Runtime.Remoting.RemotingException">The channel has already been registered.</exception>
		/// <exception cref="T:System.Security.SecurityException">At least one of the callers higher in the callstack does not have permission to configure remoting types and channels.</exception>
		// Token: 0x06005856 RID: 22614 RVA: 0x0013671F File Offset: 0x0013491F
		[SecuritySafeCritical]
		[Obsolete("Use System.Runtime.Remoting.ChannelServices.RegisterChannel(IChannel chnl, bool ensureSecurity) instead.", false)]
		[SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.RemotingConfiguration)]
		public static void RegisterChannel(IChannel chnl)
		{
			ChannelServices.RegisterChannelInternal(chnl, false);
		}

		// Token: 0x06005857 RID: 22615 RVA: 0x00136728 File Offset: 0x00134928
		[SecurityCritical]
		internal unsafe static void RegisterChannelInternal(IChannel chnl, bool ensureSecurity)
		{
			if (chnl == null)
			{
				throw new ArgumentNullException("chnl");
			}
			bool flag = false;
			RuntimeHelpers.PrepareConstrainedRegions();
			try
			{
				Monitor.Enter(ChannelServices.s_channelLock, ref flag);
				string channelName = chnl.ChannelName;
				RegisteredChannelList registeredChannelList = ChannelServices.s_registeredChannels;
				if (channelName != null && channelName.Length != 0 && -1 != registeredChannelList.FindChannelIndex(chnl.ChannelName))
				{
					throw new RemotingException(Environment.GetResourceString("Remoting_ChannelNameAlreadyRegistered", new object[]
					{
						chnl.ChannelName
					}));
				}
				if (ensureSecurity)
				{
					ISecurableChannel securableChannel = chnl as ISecurableChannel;
					if (securableChannel == null)
					{
						throw new RemotingException(Environment.GetResourceString("Remoting_Channel_CannotBeSecured", new object[]
						{
							chnl.ChannelName ?? chnl.ToString()
						}));
					}
					securableChannel.IsSecured = ensureSecurity;
				}
				RegisteredChannel[] registeredChannels = registeredChannelList.RegisteredChannels;
				RegisteredChannel[] array;
				if (registeredChannels == null)
				{
					array = new RegisteredChannel[1];
				}
				else
				{
					array = new RegisteredChannel[registeredChannels.Length + 1];
				}
				if (!ChannelServices.unloadHandlerRegistered && !(chnl is CrossAppDomainChannel))
				{
					AppDomain.CurrentDomain.DomainUnload += ChannelServices.UnloadHandler;
					ChannelServices.unloadHandlerRegistered = true;
				}
				int channelPriority = chnl.ChannelPriority;
				int i;
				for (i = 0; i < registeredChannels.Length; i++)
				{
					RegisteredChannel registeredChannel = registeredChannels[i];
					if (channelPriority > registeredChannel.Channel.ChannelPriority)
					{
						array[i] = new RegisteredChannel(chnl);
						break;
					}
					array[i] = registeredChannel;
				}
				if (i == registeredChannels.Length)
				{
					array[registeredChannels.Length] = new RegisteredChannel(chnl);
				}
				else
				{
					while (i < registeredChannels.Length)
					{
						array[i + 1] = registeredChannels[i];
						i++;
					}
				}
				if (ChannelServices.perf_Contexts != null)
				{
					ChannelServices.perf_Contexts->cChannels++;
				}
				ChannelServices.s_registeredChannels = new RegisteredChannelList(array);
				ChannelServices.RefreshChannelData();
			}
			finally
			{
				if (flag)
				{
					Monitor.Exit(ChannelServices.s_channelLock);
				}
			}
		}

		/// <summary>Unregisters a particular channel from the registered channels list.</summary>
		/// <param name="chnl">The channel to unregister.</param>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="chnl" /> parameter is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">The channel is not registered.</exception>
		/// <exception cref="T:System.Security.SecurityException">At least one of the callers higher in the callstack does not have permission to configure remoting types and channels.</exception>
		// Token: 0x06005858 RID: 22616 RVA: 0x00136900 File Offset: 0x00134B00
		[SecuritySafeCritical]
		[SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.RemotingConfiguration)]
		public unsafe static void UnregisterChannel(IChannel chnl)
		{
			bool flag = false;
			RuntimeHelpers.PrepareConstrainedRegions();
			try
			{
				Monitor.Enter(ChannelServices.s_channelLock, ref flag);
				if (chnl != null)
				{
					RegisteredChannelList registeredChannelList = ChannelServices.s_registeredChannels;
					int num = registeredChannelList.FindChannelIndex(chnl);
					if (-1 == num)
					{
						throw new RemotingException(Environment.GetResourceString("Remoting_ChannelNotRegistered", new object[]
						{
							chnl.ChannelName
						}));
					}
					RegisteredChannel[] registeredChannels = registeredChannelList.RegisteredChannels;
					RegisteredChannel[] array = new RegisteredChannel[registeredChannels.Length - 1];
					IChannelReceiver channelReceiver = chnl as IChannelReceiver;
					if (channelReceiver != null)
					{
						channelReceiver.StopListening(null);
					}
					int num2 = 0;
					int i = 0;
					while (i < registeredChannels.Length)
					{
						if (i == num)
						{
							i++;
						}
						else
						{
							array[num2] = registeredChannels[i];
							num2++;
							i++;
						}
					}
					if (ChannelServices.perf_Contexts != null)
					{
						ChannelServices.perf_Contexts->cChannels--;
					}
					ChannelServices.s_registeredChannels = new RegisteredChannelList(array);
				}
				ChannelServices.RefreshChannelData();
			}
			finally
			{
				if (flag)
				{
					Monitor.Exit(ChannelServices.s_channelLock);
				}
			}
		}

		/// <summary>Gets a list of currently registered channels.</summary>
		/// <returns>An array of all the currently registered channels.</returns>
		/// <exception cref="T:System.Security.SecurityException">The immediate caller does not have infrastructure permission.</exception>
		// Token: 0x17000EC1 RID: 3777
		// (get) Token: 0x06005859 RID: 22617 RVA: 0x00136A04 File Offset: 0x00134C04
		public static IChannel[] RegisteredChannels
		{
			[SecurityCritical]
			get
			{
				RegisteredChannelList registeredChannelList = ChannelServices.s_registeredChannels;
				int count = registeredChannelList.Count;
				if (count == 0)
				{
					return new IChannel[0];
				}
				int num = count - 1;
				int num2 = 0;
				IChannel[] array = new IChannel[num];
				for (int i = 0; i < count; i++)
				{
					IChannel channel = registeredChannelList.GetChannel(i);
					if (!(channel is CrossAppDomainChannel))
					{
						array[num2++] = channel;
					}
				}
				return array;
			}
		}

		// Token: 0x0600585A RID: 22618 RVA: 0x00136A68 File Offset: 0x00134C68
		[SecurityCritical]
		internal static IMessageSink CreateMessageSink(string url, object data, out string objectURI)
		{
			IMessageSink messageSink = null;
			objectURI = null;
			RegisteredChannelList registeredChannelList = ChannelServices.s_registeredChannels;
			int count = registeredChannelList.Count;
			for (int i = 0; i < count; i++)
			{
				if (registeredChannelList.IsSender(i))
				{
					IChannelSender channelSender = (IChannelSender)registeredChannelList.GetChannel(i);
					messageSink = channelSender.CreateMessageSink(url, data, out objectURI);
					if (messageSink != null)
					{
						break;
					}
				}
			}
			if (objectURI == null)
			{
				objectURI = url;
			}
			return messageSink;
		}

		// Token: 0x0600585B RID: 22619 RVA: 0x00136AC4 File Offset: 0x00134CC4
		[SecurityCritical]
		internal static IMessageSink CreateMessageSink(object data)
		{
			string text;
			return ChannelServices.CreateMessageSink(null, data, out text);
		}

		/// <summary>Returns a registered channel with the specified name.</summary>
		/// <param name="name">The channel name.</param>
		/// <returns>An interface to a registered channel, or <see langword="null" /> if the channel is not registered.</returns>
		/// <exception cref="T:System.Security.SecurityException">The immediate caller does not have infrastructure permission.</exception>
		// Token: 0x0600585C RID: 22620 RVA: 0x00136ADC File Offset: 0x00134CDC
		[SecurityCritical]
		public static IChannel GetChannel(string name)
		{
			RegisteredChannelList registeredChannelList = ChannelServices.s_registeredChannels;
			int num = registeredChannelList.FindChannelIndex(name);
			if (0 > num)
			{
				return null;
			}
			IChannel channel = registeredChannelList.GetChannel(num);
			if (channel is CrossAppDomainChannel || channel is CrossContextChannel)
			{
				return null;
			}
			return channel;
		}

		/// <summary>Returns an array of all the URLs that can be used to reach the specified object.</summary>
		/// <param name="obj">The object to retrieve the URL array for.</param>
		/// <returns>An array of strings that contains the URLs that can be used to remotely identify the object, or <see langword="null" /> if none were found.</returns>
		/// <exception cref="T:System.Security.SecurityException">The immediate caller does not have infrastructure permission.</exception>
		// Token: 0x0600585D RID: 22621 RVA: 0x00136B1C File Offset: 0x00134D1C
		[SecurityCritical]
		public static string[] GetUrlsForObject(MarshalByRefObject obj)
		{
			if (obj == null)
			{
				return null;
			}
			RegisteredChannelList registeredChannelList = ChannelServices.s_registeredChannels;
			int count = registeredChannelList.Count;
			Hashtable hashtable = new Hashtable();
			bool flag;
			Identity identity = MarshalByRefObject.GetIdentity(obj, out flag);
			if (identity != null)
			{
				string objURI = identity.ObjURI;
				if (objURI != null)
				{
					for (int i = 0; i < count; i++)
					{
						if (registeredChannelList.IsReceiver(i))
						{
							try
							{
								string[] urlsForUri = ((IChannelReceiver)registeredChannelList.GetChannel(i)).GetUrlsForUri(objURI);
								for (int j = 0; j < urlsForUri.Length; j++)
								{
									hashtable.Add(urlsForUri[j], urlsForUri[j]);
								}
							}
							catch (NotSupportedException)
							{
							}
						}
					}
				}
			}
			ICollection keys = hashtable.Keys;
			string[] array = new string[keys.Count];
			int num = 0;
			foreach (object obj2 in keys)
			{
				string text = (string)obj2;
				array[num++] = text;
			}
			return array;
		}

		// Token: 0x0600585E RID: 22622 RVA: 0x00136C34 File Offset: 0x00134E34
		[SecurityCritical]
		internal static IMessageSink GetChannelSinkForProxy(object obj)
		{
			IMessageSink result = null;
			if (RemotingServices.IsTransparentProxy(obj))
			{
				RealProxy realProxy = RemotingServices.GetRealProxy(obj);
				RemotingProxy remotingProxy = realProxy as RemotingProxy;
				if (remotingProxy != null)
				{
					Identity identityObject = remotingProxy.IdentityObject;
					result = identityObject.ChannelSink;
				}
			}
			return result;
		}

		/// <summary>Returns a <see cref="T:System.Collections.IDictionary" /> of properties for a given proxy.</summary>
		/// <param name="obj">The proxy to retrieve properties for.</param>
		/// <returns>An interface to the dictionary of properties, or <see langword="null" /> if no properties were found.</returns>
		/// <exception cref="T:System.Security.SecurityException">At least one of the callers that is higher in the callstack does not have permission to configure remoting types and channels.</exception>
		// Token: 0x0600585F RID: 22623 RVA: 0x00136C6C File Offset: 0x00134E6C
		[SecuritySafeCritical]
		[SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.RemotingConfiguration)]
		public static IDictionary GetChannelSinkProperties(object obj)
		{
			IMessageSink channelSinkForProxy = ChannelServices.GetChannelSinkForProxy(obj);
			IClientChannelSink clientChannelSink = channelSinkForProxy as IClientChannelSink;
			if (clientChannelSink != null)
			{
				ArrayList arrayList = new ArrayList();
				do
				{
					IDictionary properties = clientChannelSink.Properties;
					if (properties != null)
					{
						arrayList.Add(properties);
					}
					clientChannelSink = clientChannelSink.NextChannelSink;
				}
				while (clientChannelSink != null);
				return new AggregateDictionary(arrayList);
			}
			IDictionary dictionary = channelSinkForProxy as IDictionary;
			if (dictionary != null)
			{
				return dictionary;
			}
			return null;
		}

		// Token: 0x06005860 RID: 22624 RVA: 0x00136CC3 File Offset: 0x00134EC3
		internal static IMessageSink GetCrossContextChannelSink()
		{
			if (ChannelServices.xCtxChannel == null)
			{
				ChannelServices.xCtxChannel = CrossContextChannel.MessageSink;
			}
			return ChannelServices.xCtxChannel;
		}

		// Token: 0x06005861 RID: 22625 RVA: 0x00136CE1 File Offset: 0x00134EE1
		[SecurityCritical]
		internal unsafe static void IncrementRemoteCalls(long cCalls)
		{
			ChannelServices.remoteCalls += cCalls;
			if (ChannelServices.perf_Contexts != null)
			{
				ChannelServices.perf_Contexts->cRemoteCalls += (int)cCalls;
			}
		}

		// Token: 0x06005862 RID: 22626 RVA: 0x00136D0C File Offset: 0x00134F0C
		[SecurityCritical]
		internal static void IncrementRemoteCalls()
		{
			ChannelServices.IncrementRemoteCalls(1L);
		}

		// Token: 0x06005863 RID: 22627 RVA: 0x00136D18 File Offset: 0x00134F18
		[SecurityCritical]
		internal static void RefreshChannelData()
		{
			bool flag = false;
			RuntimeHelpers.PrepareConstrainedRegions();
			try
			{
				Monitor.Enter(ChannelServices.s_channelLock, ref flag);
				ChannelServices.s_currentChannelData = ChannelServices.CollectChannelDataFromChannels();
			}
			finally
			{
				if (flag)
				{
					Monitor.Exit(ChannelServices.s_channelLock);
				}
			}
		}

		// Token: 0x06005864 RID: 22628 RVA: 0x00136D64 File Offset: 0x00134F64
		[SecurityCritical]
		private static object[] CollectChannelDataFromChannels()
		{
			RemotingServices.RegisterWellKnownChannels();
			RegisteredChannelList registeredChannelList = ChannelServices.s_registeredChannels;
			int count = registeredChannelList.Count;
			int receiverCount = registeredChannelList.ReceiverCount;
			object[] array = new object[receiverCount];
			int num = 0;
			int i = 0;
			int num2 = 0;
			while (i < count)
			{
				IChannel channel = registeredChannelList.GetChannel(i);
				if (channel == null)
				{
					throw new RemotingException(Environment.GetResourceString("Remoting_ChannelNotRegistered", new object[]
					{
						""
					}));
				}
				if (registeredChannelList.IsReceiver(i))
				{
					object channelData = ((IChannelReceiver)channel).ChannelData;
					array[num2] = channelData;
					if (channelData != null)
					{
						num++;
					}
					num2++;
				}
				i++;
			}
			if (num != receiverCount)
			{
				object[] array2 = new object[num];
				int num3 = 0;
				for (int j = 0; j < receiverCount; j++)
				{
					object obj = array[j];
					if (obj != null)
					{
						array2[num3++] = obj;
					}
				}
				array = array2;
			}
			return array;
		}

		// Token: 0x06005865 RID: 22629 RVA: 0x00136E40 File Offset: 0x00135040
		private static bool IsMethodReallyPublic(MethodInfo mi)
		{
			if (!mi.IsPublic || mi.IsStatic)
			{
				return false;
			}
			if (!mi.IsGenericMethod)
			{
				return true;
			}
			foreach (Type type in mi.GetGenericArguments())
			{
				if (!type.IsVisible)
				{
					return false;
				}
			}
			return true;
		}

		/// <summary>Dispatches incoming remote calls.</summary>
		/// <param name="sinkStack">The stack of server channel sinks that the message already traversed.</param>
		/// <param name="msg">The message to dispatch.</param>
		/// <param name="replyMsg">When this method returns, contains a <see cref="T:System.Runtime.Remoting.Messaging.IMessage" /> that holds the reply from the server to the message that is contained in the <paramref name="msg" /> parameter. This parameter is passed uninitialized.</param>
		/// <returns>A <see cref="T:System.Runtime.Remoting.Channels.ServerProcessing" /> that gives the status of the server message processing.</returns>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="msg" /> parameter is <see langword="null" />.</exception>
		/// <exception cref="T:System.Security.SecurityException">The immediate caller does not have infrastructure permission.</exception>
		// Token: 0x06005866 RID: 22630 RVA: 0x00136E90 File Offset: 0x00135090
		[SecurityCritical]
		public static ServerProcessing DispatchMessage(IServerChannelSinkStack sinkStack, IMessage msg, out IMessage replyMsg)
		{
			ServerProcessing serverProcessing = ServerProcessing.Complete;
			replyMsg = null;
			try
			{
				if (msg == null)
				{
					throw new ArgumentNullException("msg");
				}
				ChannelServices.IncrementRemoteCalls();
				ServerIdentity serverIdentity = ChannelServices.CheckDisconnectedOrCreateWellKnownObject(msg);
				if (serverIdentity.ServerType == typeof(AppDomain))
				{
					throw new RemotingException(Environment.GetResourceString("Remoting_AppDomainsCantBeCalledRemotely"));
				}
				IMethodCallMessage methodCallMessage = msg as IMethodCallMessage;
				if (methodCallMessage == null)
				{
					if (!typeof(IMessageSink).IsAssignableFrom(serverIdentity.ServerType))
					{
						throw new RemotingException(Environment.GetResourceString("Remoting_AppDomainsCantBeCalledRemotely"));
					}
					serverProcessing = ServerProcessing.Complete;
					replyMsg = ChannelServices.GetCrossContextChannelSink().SyncProcessMessage(msg);
				}
				else
				{
					MethodInfo methodInfo = (MethodInfo)methodCallMessage.MethodBase;
					if (!ChannelServices.IsMethodReallyPublic(methodInfo) && !RemotingServices.IsMethodAllowedRemotely(methodInfo))
					{
						throw new RemotingException(Environment.GetResourceString("Remoting_NonPublicOrStaticCantBeCalledRemotely"));
					}
					RemotingMethodCachedData reflectionCachedData = InternalRemotingServices.GetReflectionCachedData(methodInfo);
					if (RemotingServices.IsOneWay(methodInfo))
					{
						serverProcessing = ServerProcessing.OneWay;
						ChannelServices.GetCrossContextChannelSink().AsyncProcessMessage(msg, null);
					}
					else
					{
						serverProcessing = ServerProcessing.Complete;
						if (!serverIdentity.ServerType.IsContextful)
						{
							object[] args = new object[]
							{
								msg,
								serverIdentity.ServerContext
							};
							replyMsg = (IMessage)CrossContextChannel.SyncProcessMessageCallback(args);
						}
						else
						{
							replyMsg = ChannelServices.GetCrossContextChannelSink().SyncProcessMessage(msg);
						}
					}
				}
			}
			catch (Exception e)
			{
				if (serverProcessing != ServerProcessing.OneWay)
				{
					try
					{
						IMessage message2;
						if (msg == null)
						{
							IMessage message = new ErrorMessage();
							message2 = message;
						}
						else
						{
							message2 = msg;
						}
						IMethodCallMessage mcm = (IMethodCallMessage)message2;
						replyMsg = new ReturnMessage(e, mcm);
						if (msg != null)
						{
							((ReturnMessage)replyMsg).SetLogicalCallContext((LogicalCallContext)msg.Properties[Message.CallContextKey]);
						}
					}
					catch (Exception)
					{
					}
				}
			}
			return serverProcessing;
		}

		/// <summary>Synchronously dispatches the incoming message to the server-side chain(s) based on the URI embedded in the message.</summary>
		/// <param name="msg">The message to dispatch.</param>
		/// <returns>A reply message is returned by the call to the server-side chain.</returns>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="msg" /> parameter is <see langword="null" />.</exception>
		/// <exception cref="T:System.Security.SecurityException">The immediate caller does not have infrastructure permission.</exception>
		// Token: 0x06005867 RID: 22631 RVA: 0x00137040 File Offset: 0x00135240
		[SecurityCritical]
		public static IMessage SyncDispatchMessage(IMessage msg)
		{
			IMessage message = null;
			bool flag = false;
			try
			{
				if (msg == null)
				{
					throw new ArgumentNullException("msg");
				}
				ChannelServices.IncrementRemoteCalls();
				if (!(msg is TransitionCall))
				{
					ChannelServices.CheckDisconnectedOrCreateWellKnownObject(msg);
					MethodBase methodBase = ((IMethodMessage)msg).MethodBase;
					flag = RemotingServices.IsOneWay(methodBase);
				}
				IMessageSink crossContextChannelSink = ChannelServices.GetCrossContextChannelSink();
				if (!flag)
				{
					message = crossContextChannelSink.SyncProcessMessage(msg);
				}
				else
				{
					crossContextChannelSink.AsyncProcessMessage(msg, null);
				}
			}
			catch (Exception e)
			{
				if (!flag)
				{
					try
					{
						IMessage message3;
						if (msg == null)
						{
							IMessage message2 = new ErrorMessage();
							message3 = message2;
						}
						else
						{
							message3 = msg;
						}
						IMethodCallMessage methodCallMessage = (IMethodCallMessage)message3;
						message = new ReturnMessage(e, methodCallMessage);
						if (msg != null)
						{
							((ReturnMessage)message).SetLogicalCallContext(methodCallMessage.LogicalCallContext);
						}
					}
					catch (Exception)
					{
					}
				}
			}
			return message;
		}

		/// <summary>Asynchronously dispatches the given message to the server-side chain(s) based on the URI embedded in the message.</summary>
		/// <param name="msg">The message to dispatch.</param>
		/// <param name="replySink">The sink that will process the return message if it is not <see langword="null" />.</param>
		/// <returns>A <see cref="T:System.Runtime.Remoting.Messaging.IMessageCtrl" /> object used to control the asynchronously dispatched message.</returns>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="msg" /> parameter is <see langword="null" />.</exception>
		/// <exception cref="T:System.Security.SecurityException">The immediate caller does not have infrastructure permission.</exception>
		// Token: 0x06005868 RID: 22632 RVA: 0x00137104 File Offset: 0x00135304
		[SecurityCritical]
		public static IMessageCtrl AsyncDispatchMessage(IMessage msg, IMessageSink replySink)
		{
			IMessageCtrl result = null;
			try
			{
				if (msg == null)
				{
					throw new ArgumentNullException("msg");
				}
				ChannelServices.IncrementRemoteCalls();
				if (!(msg is TransitionCall))
				{
					ChannelServices.CheckDisconnectedOrCreateWellKnownObject(msg);
				}
				result = ChannelServices.GetCrossContextChannelSink().AsyncProcessMessage(msg, replySink);
			}
			catch (Exception e)
			{
				if (replySink != null)
				{
					try
					{
						IMethodCallMessage methodCallMessage = (IMethodCallMessage)msg;
						ReturnMessage returnMessage = new ReturnMessage(e, (IMethodCallMessage)msg);
						if (msg != null)
						{
							returnMessage.SetLogicalCallContext(methodCallMessage.LogicalCallContext);
						}
						replySink.SyncProcessMessage(returnMessage);
					}
					catch (Exception)
					{
					}
				}
			}
			return result;
		}

		/// <summary>Creates a channel sink chain for the specified channel.</summary>
		/// <param name="provider">The first provider in the chain of sink providers that will create the channel sink chain.</param>
		/// <param name="channel">The <see cref="T:System.Runtime.Remoting.Channels.IChannelReceiver" /> for which to create the channel sink chain.</param>
		/// <returns>A new channel sink chain for the specified channel.</returns>
		/// <exception cref="T:System.Security.SecurityException">The immediate caller does not have infrastructure permission.</exception>
		// Token: 0x06005869 RID: 22633 RVA: 0x00137198 File Offset: 0x00135398
		[SecurityCritical]
		public static IServerChannelSink CreateServerChannelSinkChain(IServerChannelSinkProvider provider, IChannelReceiver channel)
		{
			if (provider == null)
			{
				return new DispatchChannelSink();
			}
			IServerChannelSinkProvider serverChannelSinkProvider = provider;
			while (serverChannelSinkProvider.Next != null)
			{
				serverChannelSinkProvider = serverChannelSinkProvider.Next;
			}
			serverChannelSinkProvider.Next = new DispatchChannelSinkProvider();
			IServerChannelSink result = provider.CreateSink(channel);
			serverChannelSinkProvider.Next = null;
			return result;
		}

		// Token: 0x0600586A RID: 22634 RVA: 0x001371DC File Offset: 0x001353DC
		[SecurityCritical]
		internal static ServerIdentity CheckDisconnectedOrCreateWellKnownObject(IMessage msg)
		{
			ServerIdentity serverIdentity = InternalSink.GetServerIdentity(msg);
			if (serverIdentity == null || serverIdentity.IsRemoteDisconnected())
			{
				string uri = InternalSink.GetURI(msg);
				if (uri != null)
				{
					ServerIdentity serverIdentity2 = RemotingConfigHandler.CreateWellKnownObject(uri);
					if (serverIdentity2 != null)
					{
						serverIdentity = serverIdentity2;
					}
				}
			}
			if (serverIdentity == null || serverIdentity.IsRemoteDisconnected())
			{
				string uri2 = InternalSink.GetURI(msg);
				throw new RemotingException(Environment.GetResourceString("Remoting_Disconnected", new object[]
				{
					uri2
				}));
			}
			return serverIdentity;
		}

		// Token: 0x0600586B RID: 22635 RVA: 0x0013723E File Offset: 0x0013543E
		[SecurityCritical]
		internal static void UnloadHandler(object sender, EventArgs e)
		{
			ChannelServices.StopListeningOnAllChannels();
		}

		// Token: 0x0600586C RID: 22636 RVA: 0x00137248 File Offset: 0x00135448
		[SecurityCritical]
		private static void StopListeningOnAllChannels()
		{
			try
			{
				RegisteredChannelList registeredChannelList = ChannelServices.s_registeredChannels;
				int count = registeredChannelList.Count;
				for (int i = 0; i < count; i++)
				{
					if (registeredChannelList.IsReceiver(i))
					{
						IChannelReceiver channelReceiver = (IChannelReceiver)registeredChannelList.GetChannel(i);
						channelReceiver.StopListening(null);
					}
				}
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x0600586D RID: 22637 RVA: 0x001372A4 File Offset: 0x001354A4
		[SecurityCritical]
		internal static void NotifyProfiler(IMessage msg, RemotingProfilerEvent profilerEvent)
		{
			if (profilerEvent != RemotingProfilerEvent.ClientSend)
			{
				if (profilerEvent != RemotingProfilerEvent.ClientReceive)
				{
					return;
				}
				if (RemotingServices.CORProfilerTrackRemoting())
				{
					Guid id = Guid.Empty;
					if (RemotingServices.CORProfilerTrackRemotingCookie())
					{
						object obj = msg.Properties["CORProfilerCookie"];
						if (obj != null)
						{
							id = (Guid)obj;
						}
					}
					RemotingServices.CORProfilerRemotingClientReceivingReply(id, false);
				}
			}
			else if (RemotingServices.CORProfilerTrackRemoting())
			{
				Guid guid;
				RemotingServices.CORProfilerRemotingClientSendingMessage(out guid, false);
				if (RemotingServices.CORProfilerTrackRemotingCookie())
				{
					msg.Properties["CORProfilerCookie"] = guid;
					return;
				}
			}
		}

		// Token: 0x0600586E RID: 22638 RVA: 0x0013731C File Offset: 0x0013551C
		[SecurityCritical]
		internal static string FindFirstHttpUrlForObject(string objectUri)
		{
			if (objectUri == null)
			{
				return null;
			}
			RegisteredChannelList registeredChannelList = ChannelServices.s_registeredChannels;
			int count = registeredChannelList.Count;
			for (int i = 0; i < count; i++)
			{
				if (registeredChannelList.IsReceiver(i))
				{
					IChannelReceiver channelReceiver = (IChannelReceiver)registeredChannelList.GetChannel(i);
					string fullName = channelReceiver.GetType().FullName;
					if (string.CompareOrdinal(fullName, "System.Runtime.Remoting.Channels.Http.HttpChannel") == 0 || string.CompareOrdinal(fullName, "System.Runtime.Remoting.Channels.Http.HttpServerChannel") == 0)
					{
						string[] urlsForUri = channelReceiver.GetUrlsForUri(objectUri);
						if (urlsForUri != null && urlsForUri.Length != 0)
						{
							return urlsForUri[0];
						}
					}
				}
			}
			return null;
		}

		// Token: 0x04002805 RID: 10245
		private static volatile object[] s_currentChannelData = null;

		// Token: 0x04002806 RID: 10246
		private static object s_channelLock = new object();

		// Token: 0x04002807 RID: 10247
		private static volatile RegisteredChannelList s_registeredChannels = new RegisteredChannelList();

		// Token: 0x04002808 RID: 10248
		private static volatile IMessageSink xCtxChannel;

		// Token: 0x04002809 RID: 10249
		[SecurityCritical]
		private unsafe static volatile Perf_Contexts* perf_Contexts = ChannelServices.GetPrivateContextsPerfCounters();

		// Token: 0x0400280A RID: 10250
		private static bool unloadHandlerRegistered = false;
	}
}
