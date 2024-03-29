﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;

namespace System.Reflection.Emit
{
	/// <summary>Defines and creates new instances of classes during run time.</summary>
	// Token: 0x02000636 RID: 1590
	[ClassInterface(ClassInterfaceType.None)]
	[ComDefaultInterface(typeof(_TypeBuilder))]
	[ComVisible(true)]
	[HostProtection(SecurityAction.LinkDemand, MayLeakOnAbort = true)]
	public sealed class TypeBuilder : TypeInfo, _TypeBuilder
	{
		/// <summary>Gets a value that indicates whether a specified <see cref="T:System.Reflection.TypeInfo" /> object can be assigned to this object.</summary>
		/// <param name="typeInfo">The object to test.</param>
		/// <returns>
		///   <see langword="true" /> if <paramref name="typeInfo" /> can be assigned to this object; otherwise, <see langword="false" />.</returns>
		// Token: 0x06004C22 RID: 19490 RVA: 0x00113BCF File Offset: 0x00111DCF
		public override bool IsAssignableFrom(TypeInfo typeInfo)
		{
			return !(typeInfo == null) && this.IsAssignableFrom(typeInfo.AsType());
		}

		/// <summary>Returns the method of the specified constructed generic type that corresponds to the specified method of the generic type definition.</summary>
		/// <param name="type">The constructed generic type whose method is returned.</param>
		/// <param name="method">A method on the generic type definition of <paramref name="type" />, which specifies which method of <paramref name="type" /> to return.</param>
		/// <returns>A <see cref="T:System.Reflection.MethodInfo" /> object that represents the method of <paramref name="type" /> corresponding to <paramref name="method" />, which specifies a method belonging to the generic type definition of <paramref name="type" />.</returns>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="method" /> is a generic method that is not a generic method definition.  
		/// -or-  
		/// <paramref name="type" /> does not represent a generic type.  
		/// -or-  
		/// <paramref name="type" /> is not of type <see cref="T:System.Reflection.Emit.TypeBuilder" />.  
		/// -or-  
		/// The declaring type of <paramref name="method" /> is not a generic type definition.  
		/// -or-  
		/// The declaring type of <paramref name="method" /> is not the generic type definition of <paramref name="type" />.</exception>
		// Token: 0x06004C23 RID: 19491 RVA: 0x00113BE8 File Offset: 0x00111DE8
		public static MethodInfo GetMethod(Type type, MethodInfo method)
		{
			if (!(type is TypeBuilder) && !(type is TypeBuilderInstantiation))
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_MustBeTypeBuilder"));
			}
			if (method.IsGenericMethod && !method.IsGenericMethodDefinition)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_NeedGenericMethodDefinition"), "method");
			}
			if (method.DeclaringType == null || !method.DeclaringType.IsGenericTypeDefinition)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_MethodNeedGenericDeclaringType"), "method");
			}
			if (type.GetGenericTypeDefinition() != method.DeclaringType)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_InvalidMethodDeclaringType"), "type");
			}
			if (type.IsGenericTypeDefinition)
			{
				type = type.MakeGenericType(type.GetGenericArguments());
			}
			if (!(type is TypeBuilderInstantiation))
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_NeedNonGenericType"), "type");
			}
			return MethodOnTypeBuilderInstantiation.GetMethod(method, type as TypeBuilderInstantiation);
		}

		/// <summary>Returns the constructor of the specified constructed generic type that corresponds to the specified constructor of the generic type definition.</summary>
		/// <param name="type">The constructed generic type whose constructor is returned.</param>
		/// <param name="constructor">A constructor on the generic type definition of <paramref name="type" />, which specifies which constructor of <paramref name="type" /> to return.</param>
		/// <returns>A <see cref="T:System.Reflection.ConstructorInfo" /> object that represents the constructor of <paramref name="type" /> corresponding to <paramref name="constructor" />, which specifies a constructor belonging to the generic type definition of <paramref name="type" />.</returns>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="type" /> does not represent a generic type.  
		/// -or-  
		/// <paramref name="type" /> is not of type <see cref="T:System.Reflection.Emit.TypeBuilder" />.  
		/// -or-  
		/// The declaring type of <paramref name="constructor" /> is not a generic type definition.  
		/// -or-  
		/// The declaring type of <paramref name="constructor" /> is not the generic type definition of <paramref name="type" />.</exception>
		// Token: 0x06004C24 RID: 19492 RVA: 0x00113CD4 File Offset: 0x00111ED4
		public static ConstructorInfo GetConstructor(Type type, ConstructorInfo constructor)
		{
			if (!(type is TypeBuilder) && !(type is TypeBuilderInstantiation))
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_MustBeTypeBuilder"));
			}
			if (!constructor.DeclaringType.IsGenericTypeDefinition)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_ConstructorNeedGenericDeclaringType"), "constructor");
			}
			if (!(type is TypeBuilderInstantiation))
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_NeedNonGenericType"), "type");
			}
			if (type is TypeBuilder && type.IsGenericTypeDefinition)
			{
				type = type.MakeGenericType(type.GetGenericArguments());
			}
			if (type.GetGenericTypeDefinition() != constructor.DeclaringType)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_InvalidConstructorDeclaringType"), "type");
			}
			return ConstructorOnTypeBuilderInstantiation.GetConstructor(constructor, type as TypeBuilderInstantiation);
		}

		/// <summary>Returns the field of the specified constructed generic type that corresponds to the specified field of the generic type definition.</summary>
		/// <param name="type">The constructed generic type whose field is returned.</param>
		/// <param name="field">A field on the generic type definition of <paramref name="type" />, which specifies which field of <paramref name="type" /> to return.</param>
		/// <returns>A <see cref="T:System.Reflection.FieldInfo" /> object that represents the field of <paramref name="type" /> corresponding to <paramref name="field" />, which specifies a field belonging to the generic type definition of <paramref name="type" />.</returns>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="type" /> does not represent a generic type.  
		/// -or-  
		/// <paramref name="type" /> is not of type <see cref="T:System.Reflection.Emit.TypeBuilder" />.  
		/// -or-  
		/// The declaring type of <paramref name="field" /> is not a generic type definition.  
		/// -or-  
		/// The declaring type of <paramref name="field" /> is not the generic type definition of <paramref name="type" />.</exception>
		// Token: 0x06004C25 RID: 19493 RVA: 0x00113D94 File Offset: 0x00111F94
		public static FieldInfo GetField(Type type, FieldInfo field)
		{
			if (!(type is TypeBuilder) && !(type is TypeBuilderInstantiation))
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_MustBeTypeBuilder"));
			}
			if (!field.DeclaringType.IsGenericTypeDefinition)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_FieldNeedGenericDeclaringType"), "field");
			}
			if (!(type is TypeBuilderInstantiation))
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_NeedNonGenericType"), "type");
			}
			if (type is TypeBuilder && type.IsGenericTypeDefinition)
			{
				type = type.MakeGenericType(type.GetGenericArguments());
			}
			if (type.GetGenericTypeDefinition() != field.DeclaringType)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_InvalidFieldDeclaringType"), "type");
			}
			return FieldOnTypeBuilderInstantiation.GetField(field, type as TypeBuilderInstantiation);
		}

		// Token: 0x06004C26 RID: 19494
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		private static extern void SetParentType(RuntimeModule module, int tdTypeDef, int tkParent);

		// Token: 0x06004C27 RID: 19495
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		private static extern void AddInterfaceImpl(RuntimeModule module, int tdTypeDef, int tkInterface);

		// Token: 0x06004C28 RID: 19496
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		internal static extern int DefineMethod(RuntimeModule module, int tkParent, string name, byte[] signature, int sigLength, MethodAttributes attributes);

		// Token: 0x06004C29 RID: 19497
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		internal static extern int DefineMethodSpec(RuntimeModule module, int tkParent, byte[] signature, int sigLength);

		// Token: 0x06004C2A RID: 19498
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		internal static extern int DefineField(RuntimeModule module, int tkParent, string name, byte[] signature, int sigLength, FieldAttributes attributes);

		// Token: 0x06004C2B RID: 19499
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		private static extern void SetMethodIL(RuntimeModule module, int tk, bool isInitLocals, byte[] body, int bodyLength, byte[] LocalSig, int sigLength, int maxStackSize, ExceptionHandler[] exceptions, int numExceptions, int[] tokenFixups, int numTokenFixups);

		// Token: 0x06004C2C RID: 19500
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		private static extern void DefineCustomAttribute(RuntimeModule module, int tkAssociate, int tkConstructor, byte[] attr, int attrLength, bool toDisk, bool updateCompilerFlags);

		// Token: 0x06004C2D RID: 19501 RVA: 0x00113E54 File Offset: 0x00112054
		[SecurityCritical]
		internal static void DefineCustomAttribute(ModuleBuilder module, int tkAssociate, int tkConstructor, byte[] attr, bool toDisk, bool updateCompilerFlags)
		{
			byte[] array = null;
			if (attr != null)
			{
				array = new byte[attr.Length];
				Array.Copy(attr, array, attr.Length);
			}
			TypeBuilder.DefineCustomAttribute(module.GetNativeHandle(), tkAssociate, tkConstructor, array, (array != null) ? array.Length : 0, toDisk, updateCompilerFlags);
		}

		// Token: 0x06004C2E RID: 19502
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		internal static extern void SetPInvokeData(RuntimeModule module, string DllName, string name, int token, int linkFlags);

		// Token: 0x06004C2F RID: 19503
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		internal static extern int DefineProperty(RuntimeModule module, int tkParent, string name, PropertyAttributes attributes, byte[] signature, int sigLength);

		// Token: 0x06004C30 RID: 19504
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		internal static extern int DefineEvent(RuntimeModule module, int tkParent, string name, EventAttributes attributes, int tkEventType);

		// Token: 0x06004C31 RID: 19505
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		internal static extern void DefineMethodSemantics(RuntimeModule module, int tkAssociation, MethodSemanticsAttributes semantics, int tkMethod);

		// Token: 0x06004C32 RID: 19506
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		internal static extern void DefineMethodImpl(RuntimeModule module, int tkType, int tkBody, int tkDecl);

		// Token: 0x06004C33 RID: 19507
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		internal static extern void SetMethodImpl(RuntimeModule module, int tkMethod, MethodImplAttributes MethodImplAttributes);

		// Token: 0x06004C34 RID: 19508
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		internal static extern int SetParamInfo(RuntimeModule module, int tkMethod, int iSequence, ParameterAttributes iParamAttributes, string strParamName);

		// Token: 0x06004C35 RID: 19509
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		internal static extern int GetTokenFromSig(RuntimeModule module, byte[] signature, int sigLength);

		// Token: 0x06004C36 RID: 19510
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		internal static extern void SetFieldLayoutOffset(RuntimeModule module, int fdToken, int iOffset);

		// Token: 0x06004C37 RID: 19511
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		internal static extern void SetClassLayout(RuntimeModule module, int tk, PackingSize iPackingSize, int iTypeSize);

		// Token: 0x06004C38 RID: 19512
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		internal static extern void SetFieldMarshal(RuntimeModule module, int tk, byte[] ubMarshal, int ubSize);

		// Token: 0x06004C39 RID: 19513
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		private unsafe static extern void SetConstantValue(RuntimeModule module, int tk, int corType, void* pValue);

		// Token: 0x06004C3A RID: 19514
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		internal static extern void AddDeclarativeSecurity(RuntimeModule module, int parent, SecurityAction action, byte[] blob, int cb);

		// Token: 0x06004C3B RID: 19515 RVA: 0x00113E94 File Offset: 0x00112094
		private static bool IsPublicComType(Type type)
		{
			Type declaringType = type.DeclaringType;
			if (declaringType != null)
			{
				if (TypeBuilder.IsPublicComType(declaringType) && (type.Attributes & TypeAttributes.VisibilityMask) == TypeAttributes.NestedPublic)
				{
					return true;
				}
			}
			else if ((type.Attributes & TypeAttributes.VisibilityMask) == TypeAttributes.Public)
			{
				return true;
			}
			return false;
		}

		// Token: 0x06004C3C RID: 19516 RVA: 0x00113ED4 File Offset: 0x001120D4
		internal static bool IsTypeEqual(Type t1, Type t2)
		{
			if (t1 == t2)
			{
				return true;
			}
			TypeBuilder typeBuilder = null;
			TypeBuilder typeBuilder2 = null;
			Type left;
			if (t1 is TypeBuilder)
			{
				typeBuilder = (TypeBuilder)t1;
				left = typeBuilder.m_bakedRuntimeType;
			}
			else
			{
				left = t1;
			}
			Type type;
			if (t2 is TypeBuilder)
			{
				typeBuilder2 = (TypeBuilder)t2;
				type = typeBuilder2.m_bakedRuntimeType;
			}
			else
			{
				type = t2;
			}
			return (typeBuilder != null && typeBuilder2 != null && typeBuilder == typeBuilder2) || (left != null && type != null && left == type);
		}

		// Token: 0x06004C3D RID: 19517 RVA: 0x00113F60 File Offset: 0x00112160
		[SecurityCritical]
		internal unsafe static void SetConstantValue(ModuleBuilder module, int tk, Type destType, object value)
		{
			if (value != null)
			{
				Type type = value.GetType();
				if (destType.IsByRef)
				{
					destType = destType.GetElementType();
				}
				if (destType.IsEnum)
				{
					EnumBuilder enumBuilder;
					Type type2;
					TypeBuilder typeBuilder;
					if ((enumBuilder = (destType as EnumBuilder)) != null)
					{
						type2 = enumBuilder.GetEnumUnderlyingType();
						if (type != enumBuilder.m_typeBuilder.m_bakedRuntimeType && type != type2)
						{
							throw new ArgumentException(Environment.GetResourceString("Argument_ConstantDoesntMatch"));
						}
					}
					else if ((typeBuilder = (destType as TypeBuilder)) != null)
					{
						type2 = typeBuilder.m_enumUnderlyingType;
						if (type2 == null || (type != typeBuilder.UnderlyingSystemType && type != type2))
						{
							throw new ArgumentException(Environment.GetResourceString("Argument_ConstantDoesntMatch"));
						}
					}
					else
					{
						type2 = Enum.GetUnderlyingType(destType);
						if (type != destType && type != type2)
						{
							throw new ArgumentException(Environment.GetResourceString("Argument_ConstantDoesntMatch"));
						}
					}
					type = type2;
				}
				else if (!destType.IsAssignableFrom(type))
				{
					throw new ArgumentException(Environment.GetResourceString("Argument_ConstantDoesntMatch"));
				}
				CorElementType corElementType = RuntimeTypeHandle.GetCorElementType((RuntimeType)type);
				if (corElementType - CorElementType.Boolean <= 11)
				{
					fixed (byte* ptr = &JitHelpers.GetPinningHelper(value).m_data)
					{
						TypeBuilder.SetConstantValue(module.GetNativeHandle(), tk, (int)corElementType, (void*)ptr);
					}
					return;
				}
				if (type == typeof(string))
				{
					fixed (string text = (string)value)
					{
						char* ptr2 = text;
						if (ptr2 != null)
						{
							ptr2 += RuntimeHelpers.OffsetToStringData / 2;
						}
						TypeBuilder.SetConstantValue(module.GetNativeHandle(), tk, 14, (void*)ptr2);
					}
					return;
				}
				if (type == typeof(DateTime))
				{
					long ticks = ((DateTime)value).Ticks;
					TypeBuilder.SetConstantValue(module.GetNativeHandle(), tk, 10, (void*)(&ticks));
					return;
				}
				throw new ArgumentException(Environment.GetResourceString("Argument_ConstantNotSupported", new object[]
				{
					type.ToString()
				}));
			}
			else
			{
				if (destType.IsValueType && (!destType.IsGenericType || !(destType.GetGenericTypeDefinition() == typeof(Nullable<>))))
				{
					throw new ArgumentException(Environment.GetResourceString("Argument_ConstantNull"));
				}
				TypeBuilder.SetConstantValue(module.GetNativeHandle(), tk, 18, null);
				return;
			}
		}

		// Token: 0x06004C3E RID: 19518 RVA: 0x0011417F File Offset: 0x0011237F
		internal TypeBuilder(ModuleBuilder module)
		{
			this.m_tdType = new TypeToken(33554432);
			this.m_isHiddenGlobalType = true;
			this.m_module = module;
			this.m_listMethods = new List<MethodBuilder>();
			this.m_lastTokenizedMethod = -1;
		}

		// Token: 0x06004C3F RID: 19519 RVA: 0x001141B7 File Offset: 0x001123B7
		internal TypeBuilder(string szName, int genParamPos, MethodBuilder declMeth)
		{
			this.m_declMeth = declMeth;
			this.m_DeclaringType = this.m_declMeth.GetTypeBuilder();
			this.m_module = declMeth.GetModuleBuilder();
			this.InitAsGenericParam(szName, genParamPos);
		}

		// Token: 0x06004C40 RID: 19520 RVA: 0x001141EB File Offset: 0x001123EB
		private TypeBuilder(string szName, int genParamPos, TypeBuilder declType)
		{
			this.m_DeclaringType = declType;
			this.m_module = declType.GetModuleBuilder();
			this.InitAsGenericParam(szName, genParamPos);
		}

		// Token: 0x06004C41 RID: 19521 RVA: 0x0011420E File Offset: 0x0011240E
		private void InitAsGenericParam(string szName, int genParamPos)
		{
			this.m_strName = szName;
			this.m_genParamPos = genParamPos;
			this.m_bIsGenParam = true;
			this.m_typeInterfaces = new List<Type>();
		}

		// Token: 0x06004C42 RID: 19522 RVA: 0x00114230 File Offset: 0x00112430
		[SecurityCritical]
		internal TypeBuilder(string name, TypeAttributes attr, Type parent, Type[] interfaces, ModuleBuilder module, PackingSize iPackingSize, int iTypeSize, TypeBuilder enclosingType)
		{
			this.Init(name, attr, parent, interfaces, module, iPackingSize, iTypeSize, enclosingType);
		}

		// Token: 0x06004C43 RID: 19523 RVA: 0x00114258 File Offset: 0x00112458
		[SecurityCritical]
		private void Init(string fullname, TypeAttributes attr, Type parent, Type[] interfaces, ModuleBuilder module, PackingSize iPackingSize, int iTypeSize, TypeBuilder enclosingType)
		{
			if (fullname == null)
			{
				throw new ArgumentNullException("fullname");
			}
			if (fullname.Length == 0)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_EmptyName"), "fullname");
			}
			if (fullname[0] == '\0')
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_IllegalName"), "fullname");
			}
			if (fullname.Length > 1023)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_TypeNameTooLong"), "fullname");
			}
			this.m_module = module;
			this.m_DeclaringType = enclosingType;
			AssemblyBuilder containingAssemblyBuilder = this.m_module.ContainingAssemblyBuilder;
			containingAssemblyBuilder.m_assemblyData.CheckTypeNameConflict(fullname, enclosingType);
			if (enclosingType != null && ((attr & TypeAttributes.VisibilityMask) == TypeAttributes.Public || (attr & TypeAttributes.VisibilityMask) == TypeAttributes.NotPublic))
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_BadNestedTypeFlags"), "attr");
			}
			int[] array = null;
			if (interfaces != null)
			{
				for (int i = 0; i < interfaces.Length; i++)
				{
					if (interfaces[i] == null)
					{
						throw new ArgumentNullException("interfaces");
					}
				}
				array = new int[interfaces.Length + 1];
				for (int i = 0; i < interfaces.Length; i++)
				{
					array[i] = this.m_module.GetTypeTokenInternal(interfaces[i]).Token;
				}
			}
			int num = fullname.LastIndexOf('.');
			if (num == -1 || num == 0)
			{
				this.m_strNameSpace = string.Empty;
				this.m_strName = fullname;
			}
			else
			{
				this.m_strNameSpace = fullname.Substring(0, num);
				this.m_strName = fullname.Substring(num + 1);
			}
			this.VerifyTypeAttributes(attr);
			this.m_iAttr = attr;
			this.SetParent(parent);
			this.m_listMethods = new List<MethodBuilder>();
			this.m_lastTokenizedMethod = -1;
			this.SetInterfaces(interfaces);
			int tkParent = 0;
			if (this.m_typeParent != null)
			{
				tkParent = this.m_module.GetTypeTokenInternal(this.m_typeParent).Token;
			}
			int tkEnclosingType = 0;
			if (enclosingType != null)
			{
				tkEnclosingType = enclosingType.m_tdType.Token;
			}
			this.m_tdType = new TypeToken(TypeBuilder.DefineType(this.m_module.GetNativeHandle(), fullname, tkParent, this.m_iAttr, tkEnclosingType, array));
			this.m_iPackingSize = iPackingSize;
			this.m_iTypeSize = iTypeSize;
			if (this.m_iPackingSize != PackingSize.Unspecified || this.m_iTypeSize != 0)
			{
				TypeBuilder.SetClassLayout(this.GetModuleBuilder().GetNativeHandle(), this.m_tdType.Token, this.m_iPackingSize, this.m_iTypeSize);
			}
			if (TypeBuilder.IsPublicComType(this))
			{
				if (containingAssemblyBuilder.IsPersistable() && !this.m_module.IsTransient())
				{
					containingAssemblyBuilder.m_assemblyData.AddPublicComType(this);
				}
				if (!this.m_module.Equals(containingAssemblyBuilder.ManifestModule))
				{
					containingAssemblyBuilder.DefineExportedTypeInMemory(this, this.m_module.m_moduleData.FileToken, this.m_tdType.Token);
				}
			}
			this.m_module.AddType(this.FullName, this);
		}

		// Token: 0x06004C44 RID: 19524 RVA: 0x00114520 File Offset: 0x00112720
		[SecurityCritical]
		private MethodBuilder DefinePInvokeMethodHelper(string name, string dllName, string importName, MethodAttributes attributes, CallingConventions callingConvention, Type returnType, Type[] returnTypeRequiredCustomModifiers, Type[] returnTypeOptionalCustomModifiers, Type[] parameterTypes, Type[][] parameterTypeRequiredCustomModifiers, Type[][] parameterTypeOptionalCustomModifiers, CallingConvention nativeCallConv, CharSet nativeCharSet)
		{
			this.CheckContext(new Type[]
			{
				returnType
			});
			this.CheckContext(new Type[][]
			{
				returnTypeRequiredCustomModifiers,
				returnTypeOptionalCustomModifiers,
				parameterTypes
			});
			this.CheckContext(parameterTypeRequiredCustomModifiers);
			this.CheckContext(parameterTypeOptionalCustomModifiers);
			AppDomain.CheckDefinePInvokeSupported();
			object syncRoot = this.SyncRoot;
			MethodBuilder result;
			lock (syncRoot)
			{
				result = this.DefinePInvokeMethodHelperNoLock(name, dllName, importName, attributes, callingConvention, returnType, returnTypeRequiredCustomModifiers, returnTypeOptionalCustomModifiers, parameterTypes, parameterTypeRequiredCustomModifiers, parameterTypeOptionalCustomModifiers, nativeCallConv, nativeCharSet);
			}
			return result;
		}

		// Token: 0x06004C45 RID: 19525 RVA: 0x001145BC File Offset: 0x001127BC
		[SecurityCritical]
		private MethodBuilder DefinePInvokeMethodHelperNoLock(string name, string dllName, string importName, MethodAttributes attributes, CallingConventions callingConvention, Type returnType, Type[] returnTypeRequiredCustomModifiers, Type[] returnTypeOptionalCustomModifiers, Type[] parameterTypes, Type[][] parameterTypeRequiredCustomModifiers, Type[][] parameterTypeOptionalCustomModifiers, CallingConvention nativeCallConv, CharSet nativeCharSet)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			if (name.Length == 0)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_EmptyName"), "name");
			}
			if (dllName == null)
			{
				throw new ArgumentNullException("dllName");
			}
			if (dllName.Length == 0)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_EmptyName"), "dllName");
			}
			if (importName == null)
			{
				throw new ArgumentNullException("importName");
			}
			if (importName.Length == 0)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_EmptyName"), "importName");
			}
			if ((attributes & MethodAttributes.Abstract) != MethodAttributes.PrivateScope)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_BadPInvokeMethod"));
			}
			if ((this.m_iAttr & TypeAttributes.ClassSemanticsMask) == TypeAttributes.ClassSemanticsMask)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_BadPInvokeOnInterface"));
			}
			this.ThrowIfCreated();
			attributes |= MethodAttributes.PinvokeImpl;
			MethodBuilder methodBuilder = new MethodBuilder(name, attributes, callingConvention, returnType, returnTypeRequiredCustomModifiers, returnTypeOptionalCustomModifiers, parameterTypes, parameterTypeRequiredCustomModifiers, parameterTypeOptionalCustomModifiers, this.m_module, this, false);
			int num;
			byte[] array = methodBuilder.GetMethodSignature().InternalGetSignature(out num);
			if (this.m_listMethods.Contains(methodBuilder))
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_MethodRedefined"));
			}
			this.m_listMethods.Add(methodBuilder);
			MethodToken token = methodBuilder.GetToken();
			int num2 = 0;
			switch (nativeCallConv)
			{
			case CallingConvention.Winapi:
				num2 = 256;
				break;
			case CallingConvention.Cdecl:
				num2 = 512;
				break;
			case CallingConvention.StdCall:
				num2 = 768;
				break;
			case CallingConvention.ThisCall:
				num2 = 1024;
				break;
			case CallingConvention.FastCall:
				num2 = 1280;
				break;
			}
			switch (nativeCharSet)
			{
			case CharSet.None:
				num2 |= 0;
				break;
			case CharSet.Ansi:
				num2 |= 2;
				break;
			case CharSet.Unicode:
				num2 |= 4;
				break;
			case CharSet.Auto:
				num2 |= 6;
				break;
			}
			TypeBuilder.SetPInvokeData(this.m_module.GetNativeHandle(), dllName, importName, token.Token, num2);
			methodBuilder.SetToken(token);
			return methodBuilder;
		}

		// Token: 0x06004C46 RID: 19526 RVA: 0x00114798 File Offset: 0x00112998
		[SecurityCritical]
		private FieldBuilder DefineDataHelper(string name, byte[] data, int size, FieldAttributes attributes)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			if (name.Length == 0)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_EmptyName"), "name");
			}
			if (size <= 0 || size >= 4128768)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_BadSizeForData"));
			}
			this.ThrowIfCreated();
			string text = "$ArrayType$" + size;
			Type type = this.m_module.FindTypeBuilderWithName(text, false);
			TypeBuilder typeBuilder = type as TypeBuilder;
			if (typeBuilder == null)
			{
				TypeAttributes attr = TypeAttributes.Public | TypeAttributes.ExplicitLayout | TypeAttributes.Sealed;
				typeBuilder = this.m_module.DefineType(text, attr, typeof(ValueType), PackingSize.Size1, size);
				typeBuilder.CreateType();
			}
			FieldBuilder fieldBuilder = this.DefineField(name, typeBuilder, attributes | FieldAttributes.Static);
			fieldBuilder.SetData(data, size);
			return fieldBuilder;
		}

		// Token: 0x06004C47 RID: 19527 RVA: 0x00114864 File Offset: 0x00112A64
		private void VerifyTypeAttributes(TypeAttributes attr)
		{
			if (this.DeclaringType == null)
			{
				if ((attr & TypeAttributes.VisibilityMask) != TypeAttributes.NotPublic && (attr & TypeAttributes.VisibilityMask) != TypeAttributes.Public)
				{
					throw new ArgumentException(Environment.GetResourceString("Argument_BadTypeAttrNestedVisibilityOnNonNestedType"));
				}
			}
			else if ((attr & TypeAttributes.VisibilityMask) == TypeAttributes.NotPublic || (attr & TypeAttributes.VisibilityMask) == TypeAttributes.Public)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_BadTypeAttrNonNestedVisibilityNestedType"));
			}
			if ((attr & TypeAttributes.LayoutMask) != TypeAttributes.NotPublic && (attr & TypeAttributes.LayoutMask) != TypeAttributes.SequentialLayout && (attr & TypeAttributes.LayoutMask) != TypeAttributes.ExplicitLayout)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_BadTypeAttrInvalidLayout"));
			}
			if ((attr & TypeAttributes.ReservedMask) != TypeAttributes.NotPublic)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_BadTypeAttrReservedBitsSet"));
			}
		}

		/// <summary>Returns a value that indicates whether the current dynamic type has been created.</summary>
		/// <returns>
		///   <see langword="true" /> if the <see cref="M:System.Reflection.Emit.TypeBuilder.CreateType" /> method has been called; otherwise, <see langword="false" />.</returns>
		// Token: 0x06004C48 RID: 19528 RVA: 0x001148F3 File Offset: 0x00112AF3
		public bool IsCreated()
		{
			return this.m_hasBeenCreated;
		}

		// Token: 0x06004C49 RID: 19529
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		private static extern int DefineType(RuntimeModule module, string fullname, int tkParent, TypeAttributes attributes, int tkEnclosingType, int[] interfaceTokens);

		// Token: 0x06004C4A RID: 19530
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		private static extern int DefineGenericParam(RuntimeModule module, string name, int tkParent, GenericParameterAttributes attributes, int position, int[] constraints);

		// Token: 0x06004C4B RID: 19531
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		private static extern void TermCreateClass(RuntimeModule module, int tk, ObjectHandleOnStack type);

		// Token: 0x06004C4C RID: 19532 RVA: 0x001148FB File Offset: 0x00112AFB
		internal void ThrowIfCreated()
		{
			if (this.IsCreated())
			{
				throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_TypeHasBeenCreated"));
			}
		}

		// Token: 0x17000C01 RID: 3073
		// (get) Token: 0x06004C4D RID: 19533 RVA: 0x00114915 File Offset: 0x00112B15
		internal object SyncRoot
		{
			get
			{
				return this.m_module.SyncRoot;
			}
		}

		// Token: 0x06004C4E RID: 19534 RVA: 0x00114922 File Offset: 0x00112B22
		internal ModuleBuilder GetModuleBuilder()
		{
			return this.m_module;
		}

		// Token: 0x17000C02 RID: 3074
		// (get) Token: 0x06004C4F RID: 19535 RVA: 0x0011492A File Offset: 0x00112B2A
		internal RuntimeType BakedRuntimeType
		{
			get
			{
				return this.m_bakedRuntimeType;
			}
		}

		// Token: 0x06004C50 RID: 19536 RVA: 0x00114932 File Offset: 0x00112B32
		internal void SetGenParamAttributes(GenericParameterAttributes genericParameterAttributes)
		{
			this.m_genParamAttributes = genericParameterAttributes;
		}

		// Token: 0x06004C51 RID: 19537 RVA: 0x0011493C File Offset: 0x00112B3C
		internal void SetGenParamCustomAttribute(ConstructorInfo con, byte[] binaryAttribute)
		{
			TypeBuilder.CustAttr genParamCustomAttributeNoLock = new TypeBuilder.CustAttr(con, binaryAttribute);
			object syncRoot = this.SyncRoot;
			lock (syncRoot)
			{
				this.SetGenParamCustomAttributeNoLock(genParamCustomAttributeNoLock);
			}
		}

		// Token: 0x06004C52 RID: 19538 RVA: 0x00114988 File Offset: 0x00112B88
		internal void SetGenParamCustomAttribute(CustomAttributeBuilder customBuilder)
		{
			TypeBuilder.CustAttr genParamCustomAttributeNoLock = new TypeBuilder.CustAttr(customBuilder);
			object syncRoot = this.SyncRoot;
			lock (syncRoot)
			{
				this.SetGenParamCustomAttributeNoLock(genParamCustomAttributeNoLock);
			}
		}

		// Token: 0x06004C53 RID: 19539 RVA: 0x001149D0 File Offset: 0x00112BD0
		private void SetGenParamCustomAttributeNoLock(TypeBuilder.CustAttr ca)
		{
			if (this.m_ca == null)
			{
				this.m_ca = new List<TypeBuilder.CustAttr>();
			}
			this.m_ca.Add(ca);
		}

		/// <summary>Returns the name of the type excluding the namespace.</summary>
		/// <returns>Read-only. The name of the type excluding the namespace.</returns>
		// Token: 0x06004C54 RID: 19540 RVA: 0x001149F1 File Offset: 0x00112BF1
		public override string ToString()
		{
			return TypeNameBuilder.ToString(this, TypeNameBuilder.Format.ToString);
		}

		/// <summary>Returns the type that declared this type.</summary>
		/// <returns>Read-only. The type that declared this type.</returns>
		// Token: 0x17000C03 RID: 3075
		// (get) Token: 0x06004C55 RID: 19541 RVA: 0x001149FA File Offset: 0x00112BFA
		public override Type DeclaringType
		{
			get
			{
				return this.m_DeclaringType;
			}
		}

		/// <summary>Returns the type that was used to obtain this type.</summary>
		/// <returns>Read-only. The type that was used to obtain this type.</returns>
		// Token: 0x17000C04 RID: 3076
		// (get) Token: 0x06004C56 RID: 19542 RVA: 0x00114A02 File Offset: 0x00112C02
		public override Type ReflectedType
		{
			get
			{
				return this.m_DeclaringType;
			}
		}

		/// <summary>Retrieves the name of this type.</summary>
		/// <returns>Read-only. Retrieves the <see cref="T:System.String" /> name of this type.</returns>
		// Token: 0x17000C05 RID: 3077
		// (get) Token: 0x06004C57 RID: 19543 RVA: 0x00114A0A File Offset: 0x00112C0A
		public override string Name
		{
			get
			{
				return this.m_strName;
			}
		}

		/// <summary>Retrieves the dynamic module that contains this type definition.</summary>
		/// <returns>Read-only. Retrieves the dynamic module that contains this type definition.</returns>
		// Token: 0x17000C06 RID: 3078
		// (get) Token: 0x06004C58 RID: 19544 RVA: 0x00114A12 File Offset: 0x00112C12
		public override Module Module
		{
			get
			{
				return this.GetModuleBuilder();
			}
		}

		// Token: 0x17000C07 RID: 3079
		// (get) Token: 0x06004C59 RID: 19545 RVA: 0x00114A1A File Offset: 0x00112C1A
		internal int MetadataTokenInternal
		{
			get
			{
				return this.m_tdType.Token;
			}
		}

		/// <summary>Retrieves the GUID of this type.</summary>
		/// <returns>Read-only. Retrieves the GUID of this type</returns>
		/// <exception cref="T:System.NotSupportedException">This method is not currently supported for incomplete types.</exception>
		// Token: 0x17000C08 RID: 3080
		// (get) Token: 0x06004C5A RID: 19546 RVA: 0x00114A27 File Offset: 0x00112C27
		public override Guid GUID
		{
			get
			{
				if (!this.IsCreated())
				{
					throw new NotSupportedException(Environment.GetResourceString("NotSupported_TypeNotYetCreated"));
				}
				return this.m_bakedRuntimeType.GUID;
			}
		}

		/// <summary>Invokes the specified member. The method that is to be invoked must be accessible and provide the most specific match with the specified argument list, under the constraints of the specified binder and invocation attributes.</summary>
		/// <param name="name">The name of the member to invoke. This can be a constructor, method, property, or field. A suitable invocation attribute must be specified. Note that it is possible to invoke the default member of a class by passing an empty string as the name of the member.</param>
		/// <param name="invokeAttr">The invocation attribute. This must be a bit flag from <see langword="BindingFlags" />.</param>
		/// <param name="binder">An object that enables the binding, coercion of argument types, invocation of members, and retrieval of <see langword="MemberInfo" /> objects using reflection. If binder is <see langword="null" />, the default binder is used. See <see cref="T:System.Reflection.Binder" />.</param>
		/// <param name="target">The object on which to invoke the specified member. If the member is static, this parameter is ignored.</param>
		/// <param name="args">An argument list. This is an array of Objects that contains the number, order, and type of the parameters of the member to be invoked. If there are no parameters this should be null.</param>
		/// <param name="modifiers">An array of the same length as <paramref name="args" /> with elements that represent the attributes associated with the arguments of the member to be invoked. A parameter has attributes associated with it in the metadata. They are used by various interoperability services. See the metadata specs for more details.</param>
		/// <param name="culture">An instance of <see langword="CultureInfo" /> used to govern the coercion of types. If this is null, the <see langword="CultureInfo" /> for the current thread is used. (Note that this is necessary to, for example, convert a String that represents 1000 to a Double value, since 1000 is represented differently by different cultures.)</param>
		/// <param name="namedParameters">Each parameter in the <paramref name="namedParameters" /> array gets the value in the corresponding element in the <paramref name="args" /> array. If the length of <paramref name="args" /> is greater than the length of <paramref name="namedParameters" />, the remaining argument values are passed in order.</param>
		/// <returns>Returns the return value of the invoked member.</returns>
		/// <exception cref="T:System.NotSupportedException">This method is not currently supported for incomplete types.</exception>
		// Token: 0x06004C5B RID: 19547 RVA: 0x00114A4C File Offset: 0x00112C4C
		public override object InvokeMember(string name, BindingFlags invokeAttr, Binder binder, object target, object[] args, ParameterModifier[] modifiers, CultureInfo culture, string[] namedParameters)
		{
			if (!this.IsCreated())
			{
				throw new NotSupportedException(Environment.GetResourceString("NotSupported_TypeNotYetCreated"));
			}
			return this.m_bakedRuntimeType.InvokeMember(name, invokeAttr, binder, target, args, modifiers, culture, namedParameters);
		}

		/// <summary>Retrieves the dynamic assembly that contains this type definition.</summary>
		/// <returns>Read-only. Retrieves the dynamic assembly that contains this type definition.</returns>
		// Token: 0x17000C09 RID: 3081
		// (get) Token: 0x06004C5C RID: 19548 RVA: 0x00114A89 File Offset: 0x00112C89
		public override Assembly Assembly
		{
			get
			{
				return this.m_module.Assembly;
			}
		}

		/// <summary>Not supported in dynamic modules.</summary>
		/// <returns>Read-only.</returns>
		/// <exception cref="T:System.NotSupportedException">Not supported in dynamic modules.</exception>
		// Token: 0x17000C0A RID: 3082
		// (get) Token: 0x06004C5D RID: 19549 RVA: 0x00114A96 File Offset: 0x00112C96
		public override RuntimeTypeHandle TypeHandle
		{
			get
			{
				throw new NotSupportedException(Environment.GetResourceString("NotSupported_DynamicModule"));
			}
		}

		/// <summary>Retrieves the full path of this type.</summary>
		/// <returns>Read-only. Retrieves the full path of this type.</returns>
		// Token: 0x17000C0B RID: 3083
		// (get) Token: 0x06004C5E RID: 19550 RVA: 0x00114AA7 File Offset: 0x00112CA7
		public override string FullName
		{
			get
			{
				if (this.m_strFullQualName == null)
				{
					this.m_strFullQualName = TypeNameBuilder.ToString(this, TypeNameBuilder.Format.FullName);
				}
				return this.m_strFullQualName;
			}
		}

		/// <summary>Retrieves the namespace where this <see langword="TypeBuilder" /> is defined.</summary>
		/// <returns>Read-only. Retrieves the namespace where this <see langword="TypeBuilder" /> is defined.</returns>
		// Token: 0x17000C0C RID: 3084
		// (get) Token: 0x06004C5F RID: 19551 RVA: 0x00114AC4 File Offset: 0x00112CC4
		public override string Namespace
		{
			get
			{
				return this.m_strNameSpace;
			}
		}

		/// <summary>Returns the full name of this type qualified by the display name of the assembly.</summary>
		/// <returns>Read-only. The full name of this type qualified by the display name of the assembly.</returns>
		// Token: 0x17000C0D RID: 3085
		// (get) Token: 0x06004C60 RID: 19552 RVA: 0x00114ACC File Offset: 0x00112CCC
		public override string AssemblyQualifiedName
		{
			get
			{
				return TypeNameBuilder.ToString(this, TypeNameBuilder.Format.AssemblyQualifiedName);
			}
		}

		/// <summary>Retrieves the base type of this type.</summary>
		/// <returns>Read-only. Retrieves the base type of this type.</returns>
		// Token: 0x17000C0E RID: 3086
		// (get) Token: 0x06004C61 RID: 19553 RVA: 0x00114AD5 File Offset: 0x00112CD5
		public override Type BaseType
		{
			get
			{
				return this.m_typeParent;
			}
		}

		// Token: 0x06004C62 RID: 19554 RVA: 0x00114ADD File Offset: 0x00112CDD
		protected override ConstructorInfo GetConstructorImpl(BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, Type[] types, ParameterModifier[] modifiers)
		{
			if (!this.IsCreated())
			{
				throw new NotSupportedException(Environment.GetResourceString("NotSupported_TypeNotYetCreated"));
			}
			return this.m_bakedRuntimeType.GetConstructor(bindingAttr, binder, callConvention, types, modifiers);
		}

		/// <summary>Returns an array of <see cref="T:System.Reflection.ConstructorInfo" /> objects representing the public and non-public constructors defined for this class, as specified.</summary>
		/// <param name="bindingAttr">This must be a bit flag from <see cref="T:System.Reflection.BindingFlags" /> as in <see langword="InvokeMethod" />, <see langword="NonPublic" />, and so on.</param>
		/// <returns>Returns an array of <see cref="T:System.Reflection.ConstructorInfo" /> objects representing the specified constructors defined for this class. If no constructors are defined, an empty array is returned.</returns>
		/// <exception cref="T:System.NotSupportedException">This method is not implemented for incomplete types.</exception>
		// Token: 0x06004C63 RID: 19555 RVA: 0x00114B09 File Offset: 0x00112D09
		[ComVisible(true)]
		public override ConstructorInfo[] GetConstructors(BindingFlags bindingAttr)
		{
			if (!this.IsCreated())
			{
				throw new NotSupportedException(Environment.GetResourceString("NotSupported_TypeNotYetCreated"));
			}
			return this.m_bakedRuntimeType.GetConstructors(bindingAttr);
		}

		// Token: 0x06004C64 RID: 19556 RVA: 0x00114B2F File Offset: 0x00112D2F
		protected override MethodInfo GetMethodImpl(string name, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, Type[] types, ParameterModifier[] modifiers)
		{
			if (!this.IsCreated())
			{
				throw new NotSupportedException(Environment.GetResourceString("NotSupported_TypeNotYetCreated"));
			}
			if (types == null)
			{
				return this.m_bakedRuntimeType.GetMethod(name, bindingAttr);
			}
			return this.m_bakedRuntimeType.GetMethod(name, bindingAttr, binder, callConvention, types, modifiers);
		}

		/// <summary>Returns all the public and non-public methods declared or inherited by this type, as specified.</summary>
		/// <param name="bindingAttr">This must be a bit flag from <see cref="T:System.Reflection.BindingFlags" /> as in <see langword="InvokeMethod" />, <see langword="NonPublic" />, and so on.</param>
		/// <returns>Returns an array of <see cref="T:System.Reflection.MethodInfo" /> objects representing the public and non-public methods defined on this type if <paramref name="nonPublic" /> is used; otherwise, only the public methods are returned.</returns>
		/// <exception cref="T:System.NotSupportedException">This method is not implemented for incomplete types.</exception>
		// Token: 0x06004C65 RID: 19557 RVA: 0x00114B6F File Offset: 0x00112D6F
		public override MethodInfo[] GetMethods(BindingFlags bindingAttr)
		{
			if (!this.IsCreated())
			{
				throw new NotSupportedException(Environment.GetResourceString("NotSupported_TypeNotYetCreated"));
			}
			return this.m_bakedRuntimeType.GetMethods(bindingAttr);
		}

		/// <summary>Returns the field specified by the given name.</summary>
		/// <param name="name">The name of the field to get.</param>
		/// <param name="bindingAttr">This must be a bit flag from <see cref="T:System.Reflection.BindingFlags" /> as in <see langword="InvokeMethod" />, <see langword="NonPublic" />, and so on.</param>
		/// <returns>Returns the <see cref="T:System.Reflection.FieldInfo" /> object representing the field declared or inherited by this type with the specified name and public or non-public modifier. If there are no matches then <see langword="null" /> is returned.</returns>
		/// <exception cref="T:System.NotSupportedException">This method is not implemented for incomplete types.</exception>
		// Token: 0x06004C66 RID: 19558 RVA: 0x00114B95 File Offset: 0x00112D95
		public override FieldInfo GetField(string name, BindingFlags bindingAttr)
		{
			if (!this.IsCreated())
			{
				throw new NotSupportedException(Environment.GetResourceString("NotSupported_TypeNotYetCreated"));
			}
			return this.m_bakedRuntimeType.GetField(name, bindingAttr);
		}

		/// <summary>Returns the public and non-public fields that are declared by this type.</summary>
		/// <param name="bindingAttr">This must be a bit flag from <see cref="T:System.Reflection.BindingFlags" /> : <see langword="InvokeMethod" />, <see langword="NonPublic" />, and so on.</param>
		/// <returns>Returns an array of <see cref="T:System.Reflection.FieldInfo" /> objects representing the public and non-public fields declared or inherited by this type. An empty array is returned if there are no fields, as specified.</returns>
		/// <exception cref="T:System.NotSupportedException">This method is not implemented for incomplete types.</exception>
		// Token: 0x06004C67 RID: 19559 RVA: 0x00114BBC File Offset: 0x00112DBC
		public override FieldInfo[] GetFields(BindingFlags bindingAttr)
		{
			if (!this.IsCreated())
			{
				throw new NotSupportedException(Environment.GetResourceString("NotSupported_TypeNotYetCreated"));
			}
			return this.m_bakedRuntimeType.GetFields(bindingAttr);
		}

		/// <summary>Returns the interface implemented (directly or indirectly) by this class with the fully qualified name matching the given interface name.</summary>
		/// <param name="name">The name of the interface.</param>
		/// <param name="ignoreCase">If <see langword="true" />, the search is case-insensitive. If <see langword="false" />, the search is case-sensitive.</param>
		/// <returns>Returns a <see cref="T:System.Type" /> object representing the implemented interface. Returns null if no interface matching name is found.</returns>
		/// <exception cref="T:System.NotSupportedException">This method is not implemented for incomplete types.</exception>
		// Token: 0x06004C68 RID: 19560 RVA: 0x00114BE2 File Offset: 0x00112DE2
		public override Type GetInterface(string name, bool ignoreCase)
		{
			if (!this.IsCreated())
			{
				throw new NotSupportedException(Environment.GetResourceString("NotSupported_TypeNotYetCreated"));
			}
			return this.m_bakedRuntimeType.GetInterface(name, ignoreCase);
		}

		/// <summary>Returns an array of all the interfaces implemented on this type and its base types.</summary>
		/// <returns>Returns an array of <see cref="T:System.Type" /> objects representing the implemented interfaces. If none are defined, an empty array is returned.</returns>
		// Token: 0x06004C69 RID: 19561 RVA: 0x00114C09 File Offset: 0x00112E09
		public override Type[] GetInterfaces()
		{
			if (this.m_bakedRuntimeType != null)
			{
				return this.m_bakedRuntimeType.GetInterfaces();
			}
			if (this.m_typeInterfaces == null)
			{
				return EmptyArray<Type>.Value;
			}
			return this.m_typeInterfaces.ToArray();
		}

		/// <summary>Returns the event with the specified name.</summary>
		/// <param name="name">The name of the event to search for.</param>
		/// <param name="bindingAttr">A bitwise combination of <see cref="T:System.Reflection.BindingFlags" /> values that limits the search.</param>
		/// <returns>An <see cref="T:System.Reflection.EventInfo" /> object representing the event declared or inherited by this type with the specified name, or <see langword="null" /> if there are no matches.</returns>
		/// <exception cref="T:System.NotSupportedException">This method is not implemented for incomplete types.</exception>
		// Token: 0x06004C6A RID: 19562 RVA: 0x00114C3E File Offset: 0x00112E3E
		public override EventInfo GetEvent(string name, BindingFlags bindingAttr)
		{
			if (!this.IsCreated())
			{
				throw new NotSupportedException(Environment.GetResourceString("NotSupported_TypeNotYetCreated"));
			}
			return this.m_bakedRuntimeType.GetEvent(name, bindingAttr);
		}

		/// <summary>Returns the public events declared or inherited by this type.</summary>
		/// <returns>Returns an array of <see cref="T:System.Reflection.EventInfo" /> objects representing the public events declared or inherited by this type. An empty array is returned if there are no public events.</returns>
		/// <exception cref="T:System.NotSupportedException">This method is not implemented for incomplete types.</exception>
		// Token: 0x06004C6B RID: 19563 RVA: 0x00114C65 File Offset: 0x00112E65
		public override EventInfo[] GetEvents()
		{
			if (!this.IsCreated())
			{
				throw new NotSupportedException(Environment.GetResourceString("NotSupported_TypeNotYetCreated"));
			}
			return this.m_bakedRuntimeType.GetEvents();
		}

		// Token: 0x06004C6C RID: 19564 RVA: 0x00114C8A File Offset: 0x00112E8A
		protected override PropertyInfo GetPropertyImpl(string name, BindingFlags bindingAttr, Binder binder, Type returnType, Type[] types, ParameterModifier[] modifiers)
		{
			throw new NotSupportedException(Environment.GetResourceString("NotSupported_DynamicModule"));
		}

		/// <summary>Returns all the public and non-public properties declared or inherited by this type, as specified.</summary>
		/// <param name="bindingAttr">This invocation attribute. This must be a bit flag from <see cref="T:System.Reflection.BindingFlags" /> : <see langword="InvokeMethod" />, <see langword="NonPublic" />, and so on.</param>
		/// <returns>Returns an array of <see langword="PropertyInfo" /> objects representing the public and non-public properties defined on this type if <paramref name="nonPublic" /> is used; otherwise, only the public properties are returned.</returns>
		/// <exception cref="T:System.NotSupportedException">This method is not implemented for incomplete types.</exception>
		// Token: 0x06004C6D RID: 19565 RVA: 0x00114C9B File Offset: 0x00112E9B
		public override PropertyInfo[] GetProperties(BindingFlags bindingAttr)
		{
			if (!this.IsCreated())
			{
				throw new NotSupportedException(Environment.GetResourceString("NotSupported_TypeNotYetCreated"));
			}
			return this.m_bakedRuntimeType.GetProperties(bindingAttr);
		}

		/// <summary>Returns the public and non-public nested types that are declared or inherited by this type.</summary>
		/// <param name="bindingAttr">This must be a bit flag from <see cref="T:System.Reflection.BindingFlags" />, as in <see langword="InvokeMethod" />, <see langword="NonPublic" />, and so on.</param>
		/// <returns>An array of <see cref="T:System.Type" /> objects representing all the types nested within the current <see cref="T:System.Type" /> that match the specified binding constraints.  
		///  An empty array of type <see cref="T:System.Type" />, if no types are nested within the current <see cref="T:System.Type" />, or if none of the nested types match the binding constraints.</returns>
		/// <exception cref="T:System.NotSupportedException">This method is not implemented for incomplete types.</exception>
		// Token: 0x06004C6E RID: 19566 RVA: 0x00114CC1 File Offset: 0x00112EC1
		public override Type[] GetNestedTypes(BindingFlags bindingAttr)
		{
			if (!this.IsCreated())
			{
				throw new NotSupportedException(Environment.GetResourceString("NotSupported_TypeNotYetCreated"));
			}
			return this.m_bakedRuntimeType.GetNestedTypes(bindingAttr);
		}

		/// <summary>Returns the public and non-public nested types that are declared by this type.</summary>
		/// <param name="name">The <see cref="T:System.String" /> containing the name of the nested type to get.</param>
		/// <param name="bindingAttr">A bitmask comprised of one or more <see cref="T:System.Reflection.BindingFlags" /> that specify how the search is conducted.  
		///  -or-  
		///  Zero, to conduct a case-sensitive search for public methods.</param>
		/// <returns>A <see cref="T:System.Type" /> object representing the nested type that matches the specified requirements, if found; otherwise, <see langword="null" />.</returns>
		/// <exception cref="T:System.NotSupportedException">This method is not implemented for incomplete types.</exception>
		// Token: 0x06004C6F RID: 19567 RVA: 0x00114CE7 File Offset: 0x00112EE7
		public override Type GetNestedType(string name, BindingFlags bindingAttr)
		{
			if (!this.IsCreated())
			{
				throw new NotSupportedException(Environment.GetResourceString("NotSupported_TypeNotYetCreated"));
			}
			return this.m_bakedRuntimeType.GetNestedType(name, bindingAttr);
		}

		/// <summary>Returns all the public and non-public members declared or inherited by this type, as specified.</summary>
		/// <param name="name">The name of the member.</param>
		/// <param name="type">The type of the member to return.</param>
		/// <param name="bindingAttr">This must be a bit flag from <see cref="T:System.Reflection.BindingFlags" />, as in <see langword="InvokeMethod" />, <see langword="NonPublic" />, and so on.</param>
		/// <returns>Returns an array of <see cref="T:System.Reflection.MemberInfo" /> objects representing the public and non-public members defined on this type if <paramref name="nonPublic" /> is used; otherwise, only the public members are returned.</returns>
		/// <exception cref="T:System.NotSupportedException">This method is not implemented for incomplete types.</exception>
		// Token: 0x06004C70 RID: 19568 RVA: 0x00114D0E File Offset: 0x00112F0E
		public override MemberInfo[] GetMember(string name, MemberTypes type, BindingFlags bindingAttr)
		{
			if (!this.IsCreated())
			{
				throw new NotSupportedException(Environment.GetResourceString("NotSupported_TypeNotYetCreated"));
			}
			return this.m_bakedRuntimeType.GetMember(name, type, bindingAttr);
		}

		/// <summary>Returns an interface mapping for the requested interface.</summary>
		/// <param name="interfaceType">The <see cref="T:System.Type" /> of the interface for which the mapping is to be retrieved.</param>
		/// <returns>Returns the requested interface mapping.</returns>
		/// <exception cref="T:System.NotSupportedException">This method is not implemented for incomplete types.</exception>
		// Token: 0x06004C71 RID: 19569 RVA: 0x00114D36 File Offset: 0x00112F36
		[ComVisible(true)]
		public override InterfaceMapping GetInterfaceMap(Type interfaceType)
		{
			if (!this.IsCreated())
			{
				throw new NotSupportedException(Environment.GetResourceString("NotSupported_TypeNotYetCreated"));
			}
			return this.m_bakedRuntimeType.GetInterfaceMap(interfaceType);
		}

		/// <summary>Returns the public and non-public events that are declared by this type.</summary>
		/// <param name="bindingAttr">A bitwise combination of <see cref="T:System.Reflection.BindingFlags" /> values that limits the search.</param>
		/// <returns>Returns an array of <see cref="T:System.Reflection.EventInfo" /> objects representing the events declared or inherited by this type that match the specified binding flags. An empty array is returned if there are no matching events.</returns>
		/// <exception cref="T:System.NotSupportedException">This method is not implemented for incomplete types.</exception>
		// Token: 0x06004C72 RID: 19570 RVA: 0x00114D5C File Offset: 0x00112F5C
		public override EventInfo[] GetEvents(BindingFlags bindingAttr)
		{
			if (!this.IsCreated())
			{
				throw new NotSupportedException(Environment.GetResourceString("NotSupported_TypeNotYetCreated"));
			}
			return this.m_bakedRuntimeType.GetEvents(bindingAttr);
		}

		/// <summary>Returns the members for the public and non-public members declared or inherited by this type.</summary>
		/// <param name="bindingAttr">This must be a bit flag from <see cref="T:System.Reflection.BindingFlags" />, such as <see langword="InvokeMethod" />, <see langword="NonPublic" />, and so on.</param>
		/// <returns>Returns an array of <see cref="T:System.Reflection.MemberInfo" /> objects representing the public and non-public members declared or inherited by this type. An empty array is returned if there are no matching members.</returns>
		/// <exception cref="T:System.NotSupportedException">This method is not implemented for incomplete types.</exception>
		// Token: 0x06004C73 RID: 19571 RVA: 0x00114D82 File Offset: 0x00112F82
		public override MemberInfo[] GetMembers(BindingFlags bindingAttr)
		{
			if (!this.IsCreated())
			{
				throw new NotSupportedException(Environment.GetResourceString("NotSupported_TypeNotYetCreated"));
			}
			return this.m_bakedRuntimeType.GetMembers(bindingAttr);
		}

		/// <summary>Gets a value that indicates whether a specified <see cref="T:System.Type" /> can be assigned to this object.</summary>
		/// <param name="c">The object to test.</param>
		/// <returns>
		///   <see langword="true" /> if the <paramref name="c" /> parameter and the current type represent the same type, or if the current type is in the inheritance hierarchy of <paramref name="c" />, or if the current type is an interface that <paramref name="c" /> supports. <see langword="false" /> if none of these conditions are valid, or if <paramref name="c" /> is <see langword="null" />.</returns>
		// Token: 0x06004C74 RID: 19572 RVA: 0x00114DA8 File Offset: 0x00112FA8
		public override bool IsAssignableFrom(Type c)
		{
			if (TypeBuilder.IsTypeEqual(c, this))
			{
				return true;
			}
			TypeBuilder typeBuilder = c as TypeBuilder;
			Type type;
			if (typeBuilder != null)
			{
				type = typeBuilder.m_bakedRuntimeType;
			}
			else
			{
				type = c;
			}
			if (type != null && type is RuntimeType)
			{
				return !(this.m_bakedRuntimeType == null) && this.m_bakedRuntimeType.IsAssignableFrom(type);
			}
			if (typeBuilder == null)
			{
				return false;
			}
			if (typeBuilder.IsSubclassOf(this))
			{
				return true;
			}
			if (!base.IsInterface)
			{
				return false;
			}
			Type[] interfaces = typeBuilder.GetInterfaces();
			for (int i = 0; i < interfaces.Length; i++)
			{
				if (TypeBuilder.IsTypeEqual(interfaces[i], this))
				{
					return true;
				}
				if (interfaces[i].IsSubclassOf(this))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06004C75 RID: 19573 RVA: 0x00114E5B File Offset: 0x0011305B
		protected override TypeAttributes GetAttributeFlagsImpl()
		{
			return this.m_iAttr;
		}

		// Token: 0x06004C76 RID: 19574 RVA: 0x00114E63 File Offset: 0x00113063
		protected override bool IsArrayImpl()
		{
			return false;
		}

		// Token: 0x06004C77 RID: 19575 RVA: 0x00114E66 File Offset: 0x00113066
		protected override bool IsByRefImpl()
		{
			return false;
		}

		// Token: 0x06004C78 RID: 19576 RVA: 0x00114E69 File Offset: 0x00113069
		protected override bool IsPointerImpl()
		{
			return false;
		}

		// Token: 0x06004C79 RID: 19577 RVA: 0x00114E6C File Offset: 0x0011306C
		protected override bool IsPrimitiveImpl()
		{
			return false;
		}

		// Token: 0x06004C7A RID: 19578 RVA: 0x00114E6F File Offset: 0x0011306F
		protected override bool IsCOMObjectImpl()
		{
			return (this.GetAttributeFlagsImpl() & TypeAttributes.Import) != TypeAttributes.NotPublic;
		}

		/// <summary>Calling this method always throws <see cref="T:System.NotSupportedException" />.</summary>
		/// <returns>This method is not supported. No value is returned.</returns>
		/// <exception cref="T:System.NotSupportedException">This method is not supported.</exception>
		// Token: 0x06004C7B RID: 19579 RVA: 0x00114E82 File Offset: 0x00113082
		public override Type GetElementType()
		{
			throw new NotSupportedException(Environment.GetResourceString("NotSupported_DynamicModule"));
		}

		// Token: 0x06004C7C RID: 19580 RVA: 0x00114E93 File Offset: 0x00113093
		protected override bool HasElementTypeImpl()
		{
			return false;
		}

		/// <summary>Gets a value that indicates whether the current type is security-critical or security-safe-critical, and therefore can perform critical operations.</summary>
		/// <returns>
		///   <see langword="true" /> if the current type is security-critical or security-safe-critical; <see langword="false" /> if it is transparent.</returns>
		/// <exception cref="T:System.NotSupportedException">The current dynamic type has not been created by calling the <see cref="M:System.Reflection.Emit.TypeBuilder.CreateType" /> method.</exception>
		// Token: 0x17000C0F RID: 3087
		// (get) Token: 0x06004C7D RID: 19581 RVA: 0x00114E96 File Offset: 0x00113096
		public override bool IsSecurityCritical
		{
			get
			{
				if (!this.IsCreated())
				{
					throw new NotSupportedException(Environment.GetResourceString("NotSupported_TypeNotYetCreated"));
				}
				return this.m_bakedRuntimeType.IsSecurityCritical;
			}
		}

		/// <summary>Gets a value that indicates whether the current type is security-safe-critical; that is, whether it can perform critical operations and can be accessed by transparent code.</summary>
		/// <returns>
		///   <see langword="true" /> if the current type is security-safe-critical; <see langword="false" /> if it is security-critical or transparent.</returns>
		/// <exception cref="T:System.NotSupportedException">The current dynamic type has not been created by calling the <see cref="M:System.Reflection.Emit.TypeBuilder.CreateType" /> method.</exception>
		// Token: 0x17000C10 RID: 3088
		// (get) Token: 0x06004C7E RID: 19582 RVA: 0x00114EBB File Offset: 0x001130BB
		public override bool IsSecuritySafeCritical
		{
			get
			{
				if (!this.IsCreated())
				{
					throw new NotSupportedException(Environment.GetResourceString("NotSupported_TypeNotYetCreated"));
				}
				return this.m_bakedRuntimeType.IsSecuritySafeCritical;
			}
		}

		/// <summary>Gets a value that indicates whether the current type is transparent, and therefore cannot perform critical operations.</summary>
		/// <returns>
		///   <see langword="true" /> if the type is security-transparent; otherwise, <see langword="false" />.</returns>
		/// <exception cref="T:System.NotSupportedException">The current dynamic type has not been created by calling the <see cref="M:System.Reflection.Emit.TypeBuilder.CreateType" /> method.</exception>
		// Token: 0x17000C11 RID: 3089
		// (get) Token: 0x06004C7F RID: 19583 RVA: 0x00114EE0 File Offset: 0x001130E0
		public override bool IsSecurityTransparent
		{
			get
			{
				if (!this.IsCreated())
				{
					throw new NotSupportedException(Environment.GetResourceString("NotSupported_TypeNotYetCreated"));
				}
				return this.m_bakedRuntimeType.IsSecurityTransparent;
			}
		}

		/// <summary>Determines whether this type is derived from a specified type.</summary>
		/// <param name="c">A <see cref="T:System.Type" /> that is to be checked.</param>
		/// <returns>Read-only. Returns <see langword="true" /> if this type is the same as the type <paramref name="c" />, or is a subtype of type <paramref name="c" />; otherwise, <see langword="false" />.</returns>
		// Token: 0x06004C80 RID: 19584 RVA: 0x00114F08 File Offset: 0x00113108
		[ComVisible(true)]
		public override bool IsSubclassOf(Type c)
		{
			if (TypeBuilder.IsTypeEqual(this, c))
			{
				return false;
			}
			Type baseType = this.BaseType;
			while (baseType != null)
			{
				if (TypeBuilder.IsTypeEqual(baseType, c))
				{
					return true;
				}
				baseType = baseType.BaseType;
			}
			return false;
		}

		/// <summary>Returns the underlying system type for this <see langword="TypeBuilder" />.</summary>
		/// <returns>Read-only. Returns the underlying system type.</returns>
		/// <exception cref="T:System.InvalidOperationException">This type is an enumeration, but there is no underlying system type.</exception>
		// Token: 0x17000C12 RID: 3090
		// (get) Token: 0x06004C81 RID: 19585 RVA: 0x00114F48 File Offset: 0x00113148
		public override Type UnderlyingSystemType
		{
			get
			{
				if (this.m_bakedRuntimeType != null)
				{
					return this.m_bakedRuntimeType;
				}
				if (!this.IsEnum)
				{
					return this;
				}
				if (this.m_enumUnderlyingType == null)
				{
					throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_NoUnderlyingTypeOnEnum"));
				}
				return this.m_enumUnderlyingType;
			}
		}

		/// <summary>Returns a <see cref="T:System.Type" /> object that represents the type of an unmanaged pointer to the current type.</summary>
		/// <returns>A <see cref="T:System.Type" /> object that represents the type of an unmanaged pointer to the current type.</returns>
		// Token: 0x06004C82 RID: 19586 RVA: 0x00114F98 File Offset: 0x00113198
		public override Type MakePointerType()
		{
			return SymbolType.FormCompoundType("*".ToCharArray(), this, 0);
		}

		/// <summary>Returns a <see cref="T:System.Type" /> object that represents the current type when passed as a <see langword="ref" /> parameter (<see langword="ByRef" /> in Visual Basic).</summary>
		/// <returns>A <see cref="T:System.Type" /> object that represents the current type when passed as a <see langword="ref" /> parameter (<see langword="ByRef" /> in Visual Basic).</returns>
		// Token: 0x06004C83 RID: 19587 RVA: 0x00114FAB File Offset: 0x001131AB
		public override Type MakeByRefType()
		{
			return SymbolType.FormCompoundType("&".ToCharArray(), this, 0);
		}

		/// <summary>Returns a <see cref="T:System.Type" /> object that represents a one-dimensional array of the current type, with a lower bound of zero.</summary>
		/// <returns>A <see cref="T:System.Type" /> object representing a one-dimensional array type whose element type is the current type, with a lower bound of zero.</returns>
		// Token: 0x06004C84 RID: 19588 RVA: 0x00114FBE File Offset: 0x001131BE
		public override Type MakeArrayType()
		{
			return SymbolType.FormCompoundType("[]".ToCharArray(), this, 0);
		}

		/// <summary>Returns a <see cref="T:System.Type" /> object that represents an array of the current type, with the specified number of dimensions.</summary>
		/// <param name="rank">The number of dimensions for the array.</param>
		/// <returns>A <see cref="T:System.Type" /> object that represents a one-dimensional array of the current type.</returns>
		/// <exception cref="T:System.IndexOutOfRangeException">
		///   <paramref name="rank" /> is not a valid array dimension.</exception>
		// Token: 0x06004C85 RID: 19589 RVA: 0x00114FD4 File Offset: 0x001131D4
		public override Type MakeArrayType(int rank)
		{
			if (rank <= 0)
			{
				throw new IndexOutOfRangeException();
			}
			string text = "";
			if (rank == 1)
			{
				text = "*";
			}
			else
			{
				for (int i = 1; i < rank; i++)
				{
					text += ",";
				}
			}
			string text2 = string.Format(CultureInfo.InvariantCulture, "[{0}]", text);
			return SymbolType.FormCompoundType(text2.ToCharArray(), this, 0);
		}

		/// <summary>Returns all the custom attributes defined for this type.</summary>
		/// <param name="inherit">Specifies whether to search this member's inheritance chain to find the attributes.</param>
		/// <returns>Returns an array of objects representing all the custom attributes of this type.</returns>
		/// <exception cref="T:System.NotSupportedException">This method is not currently supported for incomplete types. Retrieve the type using <see cref="M:System.Type.GetType" /> and call <see cref="M:System.Reflection.MemberInfo.GetCustomAttributes(System.Boolean)" /> on the returned <see cref="T:System.Type" />.</exception>
		// Token: 0x06004C86 RID: 19590 RVA: 0x00115033 File Offset: 0x00113233
		[SecuritySafeCritical]
		public override object[] GetCustomAttributes(bool inherit)
		{
			if (!this.IsCreated())
			{
				throw new NotSupportedException(Environment.GetResourceString("NotSupported_TypeNotYetCreated"));
			}
			return CustomAttribute.GetCustomAttributes(this.m_bakedRuntimeType, typeof(object) as RuntimeType, inherit);
		}

		/// <summary>Returns all the custom attributes of the current type that are assignable to a specified type.</summary>
		/// <param name="attributeType">The type of attribute to search for. Only attributes that are assignable to this type are returned.</param>
		/// <param name="inherit">Specifies whether to search this member's inheritance chain to find the attributes.</param>
		/// <returns>An array of custom attributes defined on the current type.</returns>
		/// <exception cref="T:System.NotSupportedException">This method is not currently supported for incomplete types. Retrieve the type using <see cref="M:System.Type.GetType" /> and call <see cref="M:System.Reflection.MemberInfo.GetCustomAttributes(System.Boolean)" /> on the returned <see cref="T:System.Type" />.</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="attributeType" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">The type must be a type provided by the underlying runtime system.</exception>
		// Token: 0x06004C87 RID: 19591 RVA: 0x00115068 File Offset: 0x00113268
		[SecuritySafeCritical]
		public override object[] GetCustomAttributes(Type attributeType, bool inherit)
		{
			if (!this.IsCreated())
			{
				throw new NotSupportedException(Environment.GetResourceString("NotSupported_TypeNotYetCreated"));
			}
			if (attributeType == null)
			{
				throw new ArgumentNullException("attributeType");
			}
			RuntimeType runtimeType = attributeType.UnderlyingSystemType as RuntimeType;
			if (runtimeType == null)
			{
				throw new ArgumentException(Environment.GetResourceString("Arg_MustBeType"), "attributeType");
			}
			return CustomAttribute.GetCustomAttributes(this.m_bakedRuntimeType, runtimeType, inherit);
		}

		/// <summary>Determines whether a custom attribute is applied to the current type.</summary>
		/// <param name="attributeType">The type of attribute to search for. Only attributes that are assignable to this type are returned.</param>
		/// <param name="inherit">Specifies whether to search this member's inheritance chain to find the attributes.</param>
		/// <returns>
		///   <see langword="true" /> if one or more instances of <paramref name="attributeType" />, or an attribute derived from <paramref name="attributeType" />, is defined on this type; otherwise, <see langword="false" />.</returns>
		/// <exception cref="T:System.NotSupportedException">This method is not currently supported for incomplete types. Retrieve the type using <see cref="M:System.Type.GetType" /> and call <see cref="M:System.Reflection.MemberInfo.IsDefined(System.Type,System.Boolean)" /> on the returned <see cref="T:System.Type" />.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="attributeType" /> is not defined.</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="attributeType" /> is <see langword="null" />.</exception>
		// Token: 0x06004C88 RID: 19592 RVA: 0x001150D8 File Offset: 0x001132D8
		[SecuritySafeCritical]
		public override bool IsDefined(Type attributeType, bool inherit)
		{
			if (!this.IsCreated())
			{
				throw new NotSupportedException(Environment.GetResourceString("NotSupported_TypeNotYetCreated"));
			}
			if (attributeType == null)
			{
				throw new ArgumentNullException("attributeType");
			}
			RuntimeType runtimeType = attributeType.UnderlyingSystemType as RuntimeType;
			if (runtimeType == null)
			{
				throw new ArgumentException(Environment.GetResourceString("Arg_MustBeType"), "caType");
			}
			return CustomAttribute.IsDefined(this.m_bakedRuntimeType, runtimeType, inherit);
		}

		/// <summary>Gets a value that indicates the covariance and special constraints of the current generic type parameter.</summary>
		/// <returns>A bitwise combination of <see cref="T:System.Reflection.GenericParameterAttributes" /> values that describes the covariance and special constraints of the current generic type parameter.</returns>
		// Token: 0x17000C13 RID: 3091
		// (get) Token: 0x06004C89 RID: 19593 RVA: 0x00115148 File Offset: 0x00113348
		public override GenericParameterAttributes GenericParameterAttributes
		{
			get
			{
				return this.m_genParamAttributes;
			}
		}

		// Token: 0x06004C8A RID: 19594 RVA: 0x00115150 File Offset: 0x00113350
		internal void SetInterfaces(params Type[] interfaces)
		{
			this.ThrowIfCreated();
			this.m_typeInterfaces = new List<Type>();
			if (interfaces != null)
			{
				this.m_typeInterfaces.AddRange(interfaces);
			}
		}

		/// <summary>Defines the generic type parameters for the current type, specifying their number and their names, and returns an array of <see cref="T:System.Reflection.Emit.GenericTypeParameterBuilder" /> objects that can be used to set their constraints.</summary>
		/// <param name="names">An array of names for the generic type parameters.</param>
		/// <returns>An array of <see cref="T:System.Reflection.Emit.GenericTypeParameterBuilder" /> objects that can be used to define the constraints of the generic type parameters for the current type.</returns>
		/// <exception cref="T:System.InvalidOperationException">Generic type parameters have already been defined for this type.</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="names" /> is <see langword="null" />.  
		/// -or-  
		/// An element of <paramref name="names" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="names" /> is an empty array.</exception>
		// Token: 0x06004C8B RID: 19595 RVA: 0x00115174 File Offset: 0x00113374
		public GenericTypeParameterBuilder[] DefineGenericParameters(params string[] names)
		{
			if (names == null)
			{
				throw new ArgumentNullException("names");
			}
			if (names.Length == 0)
			{
				throw new ArgumentException();
			}
			for (int i = 0; i < names.Length; i++)
			{
				if (names[i] == null)
				{
					throw new ArgumentNullException("names");
				}
			}
			if (this.m_inst != null)
			{
				throw new InvalidOperationException();
			}
			this.m_inst = new GenericTypeParameterBuilder[names.Length];
			for (int j = 0; j < names.Length; j++)
			{
				this.m_inst[j] = new GenericTypeParameterBuilder(new TypeBuilder(names[j], j, this));
			}
			return this.m_inst;
		}

		/// <summary>Substitutes the elements of an array of types for the type parameters of the current generic type definition, and returns the resulting constructed type.</summary>
		/// <param name="typeArguments">An array of types to be substituted for the type parameters of the current generic type definition.</param>
		/// <returns>A <see cref="T:System.Type" /> representing the constructed type formed by substituting the elements of <paramref name="typeArguments" /> for the type parameters of the current generic type.</returns>
		/// <exception cref="T:System.InvalidOperationException">The current type does not represent the definition of a generic type. That is, <see cref="P:System.Reflection.Emit.TypeBuilder.IsGenericTypeDefinition" /> returns <see langword="false" />.</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="typeArguments" /> is <see langword="null" />.  
		/// -or-  
		/// Any element of <paramref name="typeArguments" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">The <see cref="P:System.Type.Module" /> property of any element of <paramref name="typeArguments" /> is <see langword="null" />.  
		///  -or-  
		///  The <see cref="P:System.Reflection.Module.Assembly" /> property of the module of any element of <paramref name="typeArguments" /> is <see langword="null" />.</exception>
		// Token: 0x06004C8C RID: 19596 RVA: 0x001151FE File Offset: 0x001133FE
		public override Type MakeGenericType(params Type[] typeArguments)
		{
			this.CheckContext(typeArguments);
			return TypeBuilderInstantiation.MakeGenericType(this, typeArguments);
		}

		/// <summary>Returns an array of <see cref="T:System.Type" /> objects representing the type arguments of a generic type or the type parameters of a generic type definition.</summary>
		/// <returns>An array of <see cref="T:System.Type" /> objects. The elements of the array represent the type arguments of a generic type or the type parameters of a generic type definition.</returns>
		// Token: 0x06004C8D RID: 19597 RVA: 0x0011520E File Offset: 0x0011340E
		public override Type[] GetGenericArguments()
		{
			return this.m_inst;
		}

		/// <summary>Gets a value indicating whether the current <see cref="T:System.Reflection.Emit.TypeBuilder" /> represents a generic type definition from which other generic types can be constructed.</summary>
		/// <returns>
		///   <see langword="true" /> if this <see cref="T:System.Reflection.Emit.TypeBuilder" /> object represents a generic type definition; otherwise, <see langword="false" />.</returns>
		// Token: 0x17000C14 RID: 3092
		// (get) Token: 0x06004C8E RID: 19598 RVA: 0x00115216 File Offset: 0x00113416
		public override bool IsGenericTypeDefinition
		{
			get
			{
				return this.IsGenericType;
			}
		}

		/// <summary>Gets a value indicating whether the current type is a generic type.</summary>
		/// <returns>
		///   <see langword="true" /> if the type represented by the current <see cref="T:System.Reflection.Emit.TypeBuilder" /> object is generic; otherwise, <see langword="false" />.</returns>
		// Token: 0x17000C15 RID: 3093
		// (get) Token: 0x06004C8F RID: 19599 RVA: 0x0011521E File Offset: 0x0011341E
		public override bool IsGenericType
		{
			get
			{
				return this.m_inst != null;
			}
		}

		/// <summary>Gets a value indicating whether the current type is a generic type parameter.</summary>
		/// <returns>
		///   <see langword="true" /> if the current <see cref="T:System.Reflection.Emit.TypeBuilder" /> object represents a generic type parameter; otherwise, <see langword="false" />.</returns>
		// Token: 0x17000C16 RID: 3094
		// (get) Token: 0x06004C90 RID: 19600 RVA: 0x00115229 File Offset: 0x00113429
		public override bool IsGenericParameter
		{
			get
			{
				return this.m_bIsGenParam;
			}
		}

		/// <summary>Gets a value that indicates whether this object represents a constructed generic type.</summary>
		/// <returns>
		///   <see langword="true" /> if this object represents a constructed generic type; otherwise, <see langword="false" />.</returns>
		// Token: 0x17000C17 RID: 3095
		// (get) Token: 0x06004C91 RID: 19601 RVA: 0x00115231 File Offset: 0x00113431
		public override bool IsConstructedGenericType
		{
			get
			{
				return false;
			}
		}

		/// <summary>Gets the position of a type parameter in the type parameter list of the generic type that declared the parameter.</summary>
		/// <returns>If the current <see cref="T:System.Reflection.Emit.TypeBuilder" /> object represents a generic type parameter, the position of the type parameter in the type parameter list of the generic type that declared the parameter; otherwise, undefined.</returns>
		// Token: 0x17000C18 RID: 3096
		// (get) Token: 0x06004C92 RID: 19602 RVA: 0x00115234 File Offset: 0x00113434
		public override int GenericParameterPosition
		{
			get
			{
				return this.m_genParamPos;
			}
		}

		/// <summary>Gets the method that declared the current generic type parameter.</summary>
		/// <returns>A <see cref="T:System.Reflection.MethodBase" /> that represents the method that declared the current type, if the current type is a generic type parameter; otherwise, <see langword="null" />.</returns>
		// Token: 0x17000C19 RID: 3097
		// (get) Token: 0x06004C93 RID: 19603 RVA: 0x0011523C File Offset: 0x0011343C
		public override MethodBase DeclaringMethod
		{
			get
			{
				return this.m_declMeth;
			}
		}

		/// <summary>Returns a <see cref="T:System.Type" /> object that represents a generic type definition from which the current type can be obtained.</summary>
		/// <returns>A <see cref="T:System.Type" /> object representing a generic type definition from which the current type can be obtained.</returns>
		/// <exception cref="T:System.InvalidOperationException">The current type is not generic. That is, <see cref="P:System.Reflection.Emit.TypeBuilder.IsGenericType" /> returns <see langword="false" />.</exception>
		// Token: 0x06004C94 RID: 19604 RVA: 0x00115244 File Offset: 0x00113444
		public override Type GetGenericTypeDefinition()
		{
			if (this.IsGenericTypeDefinition)
			{
				return this;
			}
			if (this.m_genTypeDef == null)
			{
				throw new InvalidOperationException();
			}
			return this.m_genTypeDef;
		}

		/// <summary>Specifies a given method body that implements a given method declaration, potentially with a different name.</summary>
		/// <param name="methodInfoBody">The method body to be used. This should be a <see langword="MethodBuilder" /> object.</param>
		/// <param name="methodInfoDeclaration">The method whose declaration is to be used.</param>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="methodInfoBody" /> does not belong to this class.</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="methodInfoBody" /> or <paramref name="methodInfoDeclaration" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.InvalidOperationException">The type was previously created using <see cref="M:System.Reflection.Emit.TypeBuilder.CreateType" />.  
		///  -or-  
		///  The declaring type of <paramref name="methodInfoBody" /> is not the type represented by this <see cref="T:System.Reflection.Emit.TypeBuilder" />.</exception>
		// Token: 0x06004C95 RID: 19605 RVA: 0x0011526C File Offset: 0x0011346C
		[SecuritySafeCritical]
		public void DefineMethodOverride(MethodInfo methodInfoBody, MethodInfo methodInfoDeclaration)
		{
			object syncRoot = this.SyncRoot;
			lock (syncRoot)
			{
				this.DefineMethodOverrideNoLock(methodInfoBody, methodInfoDeclaration);
			}
		}

		// Token: 0x06004C96 RID: 19606 RVA: 0x001152B0 File Offset: 0x001134B0
		[SecurityCritical]
		private void DefineMethodOverrideNoLock(MethodInfo methodInfoBody, MethodInfo methodInfoDeclaration)
		{
			if (methodInfoBody == null)
			{
				throw new ArgumentNullException("methodInfoBody");
			}
			if (methodInfoDeclaration == null)
			{
				throw new ArgumentNullException("methodInfoDeclaration");
			}
			this.ThrowIfCreated();
			if (methodInfoBody.DeclaringType != this)
			{
				throw new ArgumentException(Environment.GetResourceString("ArgumentException_BadMethodImplBody"));
			}
			MethodToken methodTokenInternal = this.m_module.GetMethodTokenInternal(methodInfoBody);
			MethodToken methodTokenInternal2 = this.m_module.GetMethodTokenInternal(methodInfoDeclaration);
			TypeBuilder.DefineMethodImpl(this.m_module.GetNativeHandle(), this.m_tdType.Token, methodTokenInternal.Token, methodTokenInternal2.Token);
		}

		/// <summary>Adds a new method to the type, with the specified name, method attributes, and method signature.</summary>
		/// <param name="name">The name of the method. <paramref name="name" /> cannot contain embedded nulls.</param>
		/// <param name="attributes">The attributes of the method.</param>
		/// <param name="returnType">The return type of the method.</param>
		/// <param name="parameterTypes">The types of the parameters of the method.</param>
		/// <returns>The defined method.</returns>
		/// <exception cref="T:System.ArgumentException">The length of <paramref name="name" /> is zero.  
		///  -or-  
		///  The type of the parent of this method is an interface, and this method is not virtual (<see langword="Overridable" /> in Visual Basic).</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="name" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.InvalidOperationException">The type was previously created using <see cref="M:System.Reflection.Emit.TypeBuilder.CreateType" />.  
		///  -or-  
		///  For the current dynamic type, the <see cref="P:System.Reflection.Emit.TypeBuilder.IsGenericType" /> property is <see langword="true" />, but the <see cref="P:System.Reflection.Emit.TypeBuilder.IsGenericTypeDefinition" /> property is <see langword="false" />.</exception>
		// Token: 0x06004C97 RID: 19607 RVA: 0x00115347 File Offset: 0x00113547
		public MethodBuilder DefineMethod(string name, MethodAttributes attributes, Type returnType, Type[] parameterTypes)
		{
			return this.DefineMethod(name, attributes, CallingConventions.Standard, returnType, parameterTypes);
		}

		/// <summary>Adds a new method to the type, with the specified name and method attributes.</summary>
		/// <param name="name">The name of the method. <paramref name="name" /> cannot contain embedded nulls.</param>
		/// <param name="attributes">The attributes of the method.</param>
		/// <returns>A <see cref="T:System.Reflection.Emit.MethodBuilder" /> representing the newly defined method.</returns>
		/// <exception cref="T:System.ArgumentException">The length of <paramref name="name" /> is zero.  
		///  -or-  
		///  The type of the parent of this method is an interface, and this method is not virtual (<see langword="Overridable" /> in Visual Basic).</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="name" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.InvalidOperationException">The type was previously created using <see cref="M:System.Reflection.Emit.TypeBuilder.CreateType" />.  
		///  -or-  
		///  For the current dynamic type, the <see cref="P:System.Reflection.Emit.TypeBuilder.IsGenericType" /> property is <see langword="true" />, but the <see cref="P:System.Reflection.Emit.TypeBuilder.IsGenericTypeDefinition" /> property is <see langword="false" />.</exception>
		// Token: 0x06004C98 RID: 19608 RVA: 0x00115355 File Offset: 0x00113555
		public MethodBuilder DefineMethod(string name, MethodAttributes attributes)
		{
			return this.DefineMethod(name, attributes, CallingConventions.Standard, null, null);
		}

		/// <summary>Adds a new method to the type, with the specified name, method attributes, and calling convention.</summary>
		/// <param name="name">The name of the method. <paramref name="name" /> cannot contain embedded nulls.</param>
		/// <param name="attributes">The attributes of the method.</param>
		/// <param name="callingConvention">The calling convention of the method.</param>
		/// <returns>A <see cref="T:System.Reflection.Emit.MethodBuilder" /> representing the newly defined method.</returns>
		/// <exception cref="T:System.ArgumentException">The length of <paramref name="name" /> is zero.  
		///  -or-  
		///  The type of the parent of this method is an interface and this method is not virtual (<see langword="Overridable" /> in Visual Basic).</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="name" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.InvalidOperationException">The type was previously created using <see cref="M:System.Reflection.Emit.TypeBuilder.CreateType" />.  
		///  -or-  
		///  For the current dynamic type, the <see cref="P:System.Reflection.Emit.TypeBuilder.IsGenericType" /> property is <see langword="true" />, but the <see cref="P:System.Reflection.Emit.TypeBuilder.IsGenericTypeDefinition" /> property is <see langword="false" />.</exception>
		// Token: 0x06004C99 RID: 19609 RVA: 0x00115362 File Offset: 0x00113562
		public MethodBuilder DefineMethod(string name, MethodAttributes attributes, CallingConventions callingConvention)
		{
			return this.DefineMethod(name, attributes, callingConvention, null, null);
		}

		/// <summary>Adds a new method to the type, with the specified name, method attributes, calling convention, and method signature.</summary>
		/// <param name="name">The name of the method. <paramref name="name" /> cannot contain embedded nulls.</param>
		/// <param name="attributes">The attributes of the method.</param>
		/// <param name="callingConvention">The calling convention of the method.</param>
		/// <param name="returnType">The return type of the method.</param>
		/// <param name="parameterTypes">The types of the parameters of the method.</param>
		/// <returns>A <see cref="T:System.Reflection.Emit.MethodBuilder" /> representing the newly defined method.</returns>
		/// <exception cref="T:System.ArgumentException">The length of <paramref name="name" /> is zero.  
		///  -or-  
		///  The type of the parent of this method is an interface, and this method is not virtual (<see langword="Overridable" /> in Visual Basic).</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="name" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.InvalidOperationException">The type was previously created using <see cref="M:System.Reflection.Emit.TypeBuilder.CreateType" />.  
		///  -or-  
		///  For the current dynamic type, the <see cref="P:System.Reflection.Emit.TypeBuilder.IsGenericType" /> property is <see langword="true" />, but the <see cref="P:System.Reflection.Emit.TypeBuilder.IsGenericTypeDefinition" /> property is <see langword="false" />.</exception>
		// Token: 0x06004C9A RID: 19610 RVA: 0x00115370 File Offset: 0x00113570
		public MethodBuilder DefineMethod(string name, MethodAttributes attributes, CallingConventions callingConvention, Type returnType, Type[] parameterTypes)
		{
			return this.DefineMethod(name, attributes, callingConvention, returnType, null, null, parameterTypes, null, null);
		}

		/// <summary>Adds a new method to the type, with the specified name, method attributes, calling convention, method signature, and custom modifiers.</summary>
		/// <param name="name">The name of the method. <paramref name="name" /> cannot contain embedded nulls.</param>
		/// <param name="attributes">The attributes of the method.</param>
		/// <param name="callingConvention">The calling convention of the method.</param>
		/// <param name="returnType">The return type of the method.</param>
		/// <param name="returnTypeRequiredCustomModifiers">An array of types representing the required custom modifiers, such as <see cref="T:System.Runtime.CompilerServices.IsConst" />, for the return type of the method. If the return type has no required custom modifiers, specify <see langword="null" />.</param>
		/// <param name="returnTypeOptionalCustomModifiers">An array of types representing the optional custom modifiers, such as <see cref="T:System.Runtime.CompilerServices.IsConst" />, for the return type of the method. If the return type has no optional custom modifiers, specify <see langword="null" />.</param>
		/// <param name="parameterTypes">The types of the parameters of the method.</param>
		/// <param name="parameterTypeRequiredCustomModifiers">An array of arrays of types. Each array of types represents the required custom modifiers for the corresponding parameter, such as <see cref="T:System.Runtime.CompilerServices.IsConst" />. If a particular parameter has no required custom modifiers, specify <see langword="null" /> instead of an array of types. If none of the parameters have required custom modifiers, specify <see langword="null" /> instead of an array of arrays.</param>
		/// <param name="parameterTypeOptionalCustomModifiers">An array of arrays of types. Each array of types represents the optional custom modifiers for the corresponding parameter, such as <see cref="T:System.Runtime.CompilerServices.IsConst" />. If a particular parameter has no optional custom modifiers, specify <see langword="null" /> instead of an array of types. If none of the parameters have optional custom modifiers, specify <see langword="null" /> instead of an array of arrays.</param>
		/// <returns>A <see cref="T:System.Reflection.Emit.MethodBuilder" /> object representing the newly added method.</returns>
		/// <exception cref="T:System.ArgumentException">The length of <paramref name="name" /> is zero.  
		///  -or-  
		///  The type of the parent of this method is an interface, and this method is not virtual (<see langword="Overridable" /> in Visual Basic).  
		///  -or-  
		///  The size of <paramref name="parameterTypeRequiredCustomModifiers" /> or <paramref name="parameterTypeOptionalCustomModifiers" /> does not equal the size of <paramref name="parameterTypes" />.</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="name" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.InvalidOperationException">The type was previously created using <see cref="M:System.Reflection.Emit.TypeBuilder.CreateType" />.  
		///  -or-  
		///  For the current dynamic type, the <see cref="P:System.Reflection.Emit.TypeBuilder.IsGenericType" /> property is <see langword="true" />, but the <see cref="P:System.Reflection.Emit.TypeBuilder.IsGenericTypeDefinition" /> property is <see langword="false" />.</exception>
		// Token: 0x06004C9B RID: 19611 RVA: 0x00115390 File Offset: 0x00113590
		public MethodBuilder DefineMethod(string name, MethodAttributes attributes, CallingConventions callingConvention, Type returnType, Type[] returnTypeRequiredCustomModifiers, Type[] returnTypeOptionalCustomModifiers, Type[] parameterTypes, Type[][] parameterTypeRequiredCustomModifiers, Type[][] parameterTypeOptionalCustomModifiers)
		{
			object syncRoot = this.SyncRoot;
			MethodBuilder result;
			lock (syncRoot)
			{
				result = this.DefineMethodNoLock(name, attributes, callingConvention, returnType, returnTypeRequiredCustomModifiers, returnTypeOptionalCustomModifiers, parameterTypes, parameterTypeRequiredCustomModifiers, parameterTypeOptionalCustomModifiers);
			}
			return result;
		}

		// Token: 0x06004C9C RID: 19612 RVA: 0x001153E4 File Offset: 0x001135E4
		private MethodBuilder DefineMethodNoLock(string name, MethodAttributes attributes, CallingConventions callingConvention, Type returnType, Type[] returnTypeRequiredCustomModifiers, Type[] returnTypeOptionalCustomModifiers, Type[] parameterTypes, Type[][] parameterTypeRequiredCustomModifiers, Type[][] parameterTypeOptionalCustomModifiers)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			if (name.Length == 0)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_EmptyName"), "name");
			}
			this.CheckContext(new Type[]
			{
				returnType
			});
			this.CheckContext(new Type[][]
			{
				returnTypeRequiredCustomModifiers,
				returnTypeOptionalCustomModifiers,
				parameterTypes
			});
			this.CheckContext(parameterTypeRequiredCustomModifiers);
			this.CheckContext(parameterTypeOptionalCustomModifiers);
			if (parameterTypes != null)
			{
				if (parameterTypeOptionalCustomModifiers != null && parameterTypeOptionalCustomModifiers.Length != parameterTypes.Length)
				{
					throw new ArgumentException(Environment.GetResourceString("Argument_MismatchedArrays", new object[]
					{
						"parameterTypeOptionalCustomModifiers",
						"parameterTypes"
					}));
				}
				if (parameterTypeRequiredCustomModifiers != null && parameterTypeRequiredCustomModifiers.Length != parameterTypes.Length)
				{
					throw new ArgumentException(Environment.GetResourceString("Argument_MismatchedArrays", new object[]
					{
						"parameterTypeRequiredCustomModifiers",
						"parameterTypes"
					}));
				}
			}
			this.ThrowIfCreated();
			if (!this.m_isHiddenGlobalType && (this.m_iAttr & TypeAttributes.ClassSemanticsMask) == TypeAttributes.ClassSemanticsMask && (attributes & MethodAttributes.Abstract) == MethodAttributes.PrivateScope && (attributes & MethodAttributes.Static) == MethodAttributes.PrivateScope)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_BadAttributeOnInterfaceMethod"));
			}
			MethodBuilder methodBuilder = new MethodBuilder(name, attributes, callingConvention, returnType, returnTypeRequiredCustomModifiers, returnTypeOptionalCustomModifiers, parameterTypes, parameterTypeRequiredCustomModifiers, parameterTypeOptionalCustomModifiers, this.m_module, this, false);
			if (!this.m_isHiddenGlobalType && (methodBuilder.Attributes & MethodAttributes.SpecialName) != MethodAttributes.PrivateScope && methodBuilder.Name.Equals(ConstructorInfo.ConstructorName))
			{
				this.m_constructorCount++;
			}
			this.m_listMethods.Add(methodBuilder);
			return methodBuilder;
		}

		/// <summary>Defines the initializer for this type.</summary>
		/// <returns>Returns a type initializer.</returns>
		/// <exception cref="T:System.InvalidOperationException">The containing type has been previously created using <see cref="M:System.Reflection.Emit.TypeBuilder.CreateType" />.</exception>
		// Token: 0x06004C9D RID: 19613 RVA: 0x00115560 File Offset: 0x00113760
		[SecuritySafeCritical]
		[ComVisible(true)]
		public ConstructorBuilder DefineTypeInitializer()
		{
			object syncRoot = this.SyncRoot;
			ConstructorBuilder result;
			lock (syncRoot)
			{
				result = this.DefineTypeInitializerNoLock();
			}
			return result;
		}

		// Token: 0x06004C9E RID: 19614 RVA: 0x001155A4 File Offset: 0x001137A4
		[SecurityCritical]
		private ConstructorBuilder DefineTypeInitializerNoLock()
		{
			this.ThrowIfCreated();
			MethodAttributes attributes = MethodAttributes.Private | MethodAttributes.Static | MethodAttributes.SpecialName;
			return new ConstructorBuilder(ConstructorInfo.TypeConstructorName, attributes, CallingConventions.Standard, null, this.m_module, this);
		}

		/// <summary>Defines the default constructor. The constructor defined here will simply call the default constructor of the parent.</summary>
		/// <param name="attributes">A <see langword="MethodAttributes" /> object representing the attributes to be applied to the constructor.</param>
		/// <returns>Returns the constructor.</returns>
		/// <exception cref="T:System.NotSupportedException">The parent type (base type) does not have a default constructor.</exception>
		/// <exception cref="T:System.InvalidOperationException">The type was previously created using <see cref="M:System.Reflection.Emit.TypeBuilder.CreateType" />.  
		///  -or-  
		///  For the current dynamic type, the <see cref="P:System.Reflection.Emit.TypeBuilder.IsGenericType" /> property is <see langword="true" />, but the <see cref="P:System.Reflection.Emit.TypeBuilder.IsGenericTypeDefinition" /> property is <see langword="false" />.</exception>
		// Token: 0x06004C9F RID: 19615 RVA: 0x001155D4 File Offset: 0x001137D4
		[ComVisible(true)]
		public ConstructorBuilder DefineDefaultConstructor(MethodAttributes attributes)
		{
			if ((this.m_iAttr & TypeAttributes.ClassSemanticsMask) == TypeAttributes.ClassSemanticsMask)
			{
				throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_ConstructorNotAllowedOnInterface"));
			}
			object syncRoot = this.SyncRoot;
			ConstructorBuilder result;
			lock (syncRoot)
			{
				result = this.DefineDefaultConstructorNoLock(attributes);
			}
			return result;
		}

		// Token: 0x06004CA0 RID: 19616 RVA: 0x00115634 File Offset: 0x00113834
		private ConstructorBuilder DefineDefaultConstructorNoLock(MethodAttributes attributes)
		{
			ConstructorInfo constructorInfo = null;
			if (this.m_typeParent is TypeBuilderInstantiation)
			{
				Type type = this.m_typeParent.GetGenericTypeDefinition();
				if (type is TypeBuilder)
				{
					type = ((TypeBuilder)type).m_bakedRuntimeType;
				}
				if (type == null)
				{
					throw new NotSupportedException(Environment.GetResourceString("NotSupported_DynamicModule"));
				}
				Type type2 = type.MakeGenericType(this.m_typeParent.GetGenericArguments());
				if (type2 is TypeBuilderInstantiation)
				{
					constructorInfo = TypeBuilder.GetConstructor(type2, type.GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Type.EmptyTypes, null));
				}
				else
				{
					constructorInfo = type2.GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Type.EmptyTypes, null);
				}
			}
			if (constructorInfo == null)
			{
				constructorInfo = this.m_typeParent.GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Type.EmptyTypes, null);
			}
			if (constructorInfo == null)
			{
				throw new NotSupportedException(Environment.GetResourceString("NotSupported_NoParentDefaultConstructor"));
			}
			ConstructorBuilder constructorBuilder = this.DefineConstructor(attributes, CallingConventions.Standard, null);
			this.m_constructorCount++;
			ILGenerator ilgenerator = constructorBuilder.GetILGenerator();
			ilgenerator.Emit(OpCodes.Ldarg_0);
			ilgenerator.Emit(OpCodes.Call, constructorInfo);
			ilgenerator.Emit(OpCodes.Ret);
			constructorBuilder.m_isDefaultConstructor = true;
			return constructorBuilder;
		}

		/// <summary>Adds a new constructor to the type, with the given attributes and signature.</summary>
		/// <param name="attributes">The attributes of the constructor.</param>
		/// <param name="callingConvention">The calling convention of the constructor.</param>
		/// <param name="parameterTypes">The parameter types of the constructor.</param>
		/// <returns>The defined constructor.</returns>
		/// <exception cref="T:System.InvalidOperationException">The type was previously created using <see cref="M:System.Reflection.Emit.TypeBuilder.CreateType" />.</exception>
		// Token: 0x06004CA1 RID: 19617 RVA: 0x0011574F File Offset: 0x0011394F
		[ComVisible(true)]
		public ConstructorBuilder DefineConstructor(MethodAttributes attributes, CallingConventions callingConvention, Type[] parameterTypes)
		{
			return this.DefineConstructor(attributes, callingConvention, parameterTypes, null, null);
		}

		/// <summary>Adds a new constructor to the type, with the given attributes, signature, and custom modifiers.</summary>
		/// <param name="attributes">The attributes of the constructor.</param>
		/// <param name="callingConvention">The calling convention of the constructor.</param>
		/// <param name="parameterTypes">The parameter types of the constructor.</param>
		/// <param name="requiredCustomModifiers">An array of arrays of types. Each array of types represents the required custom modifiers for the corresponding parameter, such as <see cref="T:System.Runtime.CompilerServices.IsConst" />. If a particular parameter has no required custom modifiers, specify <see langword="null" /> instead of an array of types. If none of the parameters have required custom modifiers, specify <see langword="null" /> instead of an array of arrays.</param>
		/// <param name="optionalCustomModifiers">An array of arrays of types. Each array of types represents the optional custom modifiers for the corresponding parameter, such as <see cref="T:System.Runtime.CompilerServices.IsConst" />. If a particular parameter has no optional custom modifiers, specify <see langword="null" /> instead of an array of types. If none of the parameters have optional custom modifiers, specify <see langword="null" /> instead of an array of arrays.</param>
		/// <returns>The defined constructor.</returns>
		/// <exception cref="T:System.ArgumentException">The size of <paramref name="requiredCustomModifiers" /> or <paramref name="optionalCustomModifiers" /> does not equal the size of <paramref name="parameterTypes" />.</exception>
		/// <exception cref="T:System.InvalidOperationException">The type was previously created using <see cref="M:System.Reflection.Emit.TypeBuilder.CreateType" />.  
		///  -or-  
		///  For the current dynamic type, the <see cref="P:System.Reflection.Emit.TypeBuilder.IsGenericType" /> property is <see langword="true" />, but the <see cref="P:System.Reflection.Emit.TypeBuilder.IsGenericTypeDefinition" /> property is <see langword="false" />.</exception>
		// Token: 0x06004CA2 RID: 19618 RVA: 0x0011575C File Offset: 0x0011395C
		[SecuritySafeCritical]
		[ComVisible(true)]
		public ConstructorBuilder DefineConstructor(MethodAttributes attributes, CallingConventions callingConvention, Type[] parameterTypes, Type[][] requiredCustomModifiers, Type[][] optionalCustomModifiers)
		{
			if ((this.m_iAttr & TypeAttributes.ClassSemanticsMask) == TypeAttributes.ClassSemanticsMask && (attributes & MethodAttributes.Static) != MethodAttributes.Static)
			{
				throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_ConstructorNotAllowedOnInterface"));
			}
			object syncRoot = this.SyncRoot;
			ConstructorBuilder result;
			lock (syncRoot)
			{
				result = this.DefineConstructorNoLock(attributes, callingConvention, parameterTypes, requiredCustomModifiers, optionalCustomModifiers);
			}
			return result;
		}

		// Token: 0x06004CA3 RID: 19619 RVA: 0x001157CC File Offset: 0x001139CC
		[SecurityCritical]
		private ConstructorBuilder DefineConstructorNoLock(MethodAttributes attributes, CallingConventions callingConvention, Type[] parameterTypes, Type[][] requiredCustomModifiers, Type[][] optionalCustomModifiers)
		{
			this.CheckContext(parameterTypes);
			this.CheckContext(requiredCustomModifiers);
			this.CheckContext(optionalCustomModifiers);
			this.ThrowIfCreated();
			string name;
			if ((attributes & MethodAttributes.Static) == MethodAttributes.PrivateScope)
			{
				name = ConstructorInfo.ConstructorName;
			}
			else
			{
				name = ConstructorInfo.TypeConstructorName;
			}
			attributes |= MethodAttributes.SpecialName;
			ConstructorBuilder result = new ConstructorBuilder(name, attributes, callingConvention, parameterTypes, requiredCustomModifiers, optionalCustomModifiers, this.m_module, this);
			this.m_constructorCount++;
			return result;
		}

		/// <summary>Defines a <see langword="PInvoke" /> method given its name, the name of the DLL in which the method is defined, the attributes of the method, the calling convention of the method, the return type of the method, the types of the parameters of the method, and the <see langword="PInvoke" /> flags.</summary>
		/// <param name="name">The name of the <see langword="PInvoke" /> method. <paramref name="name" /> cannot contain embedded nulls.</param>
		/// <param name="dllName">The name of the DLL in which the <see langword="PInvoke" /> method is defined.</param>
		/// <param name="attributes">The attributes of the method.</param>
		/// <param name="callingConvention">The method's calling convention.</param>
		/// <param name="returnType">The method's return type.</param>
		/// <param name="parameterTypes">The types of the method's parameters.</param>
		/// <param name="nativeCallConv">The native calling convention.</param>
		/// <param name="nativeCharSet">The method's native character set.</param>
		/// <returns>The defined <see langword="PInvoke" /> method.</returns>
		/// <exception cref="T:System.ArgumentException">The method is not static.  
		///  -or-  
		///  The parent type is an interface.  
		///  -or-  
		///  The method is abstract.  
		///  -or-  
		///  The method was previously defined.  
		///  -or-  
		///  The length of <paramref name="name" /> or <paramref name="dllName" /> is zero.</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="name" /> or <paramref name="dllName" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.InvalidOperationException">The containing type has been previously created using <see cref="M:System.Reflection.Emit.TypeBuilder.CreateType" />.</exception>
		// Token: 0x06004CA4 RID: 19620 RVA: 0x00115838 File Offset: 0x00113A38
		[SecuritySafeCritical]
		public MethodBuilder DefinePInvokeMethod(string name, string dllName, MethodAttributes attributes, CallingConventions callingConvention, Type returnType, Type[] parameterTypes, CallingConvention nativeCallConv, CharSet nativeCharSet)
		{
			return this.DefinePInvokeMethodHelper(name, dllName, name, attributes, callingConvention, returnType, null, null, parameterTypes, null, null, nativeCallConv, nativeCharSet);
		}

		/// <summary>Defines a <see langword="PInvoke" /> method given its name, the name of the DLL in which the method is defined, the name of the entry point, the attributes of the method, the calling convention of the method, the return type of the method, the types of the parameters of the method, and the <see langword="PInvoke" /> flags.</summary>
		/// <param name="name">The name of the <see langword="PInvoke" /> method. <paramref name="name" /> cannot contain embedded nulls.</param>
		/// <param name="dllName">The name of the DLL in which the <see langword="PInvoke" /> method is defined.</param>
		/// <param name="entryName">The name of the entry point in the DLL.</param>
		/// <param name="attributes">The attributes of the method.</param>
		/// <param name="callingConvention">The method's calling convention.</param>
		/// <param name="returnType">The method's return type.</param>
		/// <param name="parameterTypes">The types of the method's parameters.</param>
		/// <param name="nativeCallConv">The native calling convention.</param>
		/// <param name="nativeCharSet">The method's native character set.</param>
		/// <returns>The defined <see langword="PInvoke" /> method.</returns>
		/// <exception cref="T:System.ArgumentException">The method is not static.  
		///  -or-  
		///  The parent type is an interface.  
		///  -or-  
		///  The method is abstract.  
		///  -or-  
		///  The method was previously defined.  
		///  -or-  
		///  The length of <paramref name="name" />, <paramref name="dllName" />, or <paramref name="entryName" /> is zero.</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="name" />, <paramref name="dllName" />, or <paramref name="entryName" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.InvalidOperationException">The containing type has been previously created using <see cref="M:System.Reflection.Emit.TypeBuilder.CreateType" />.</exception>
		// Token: 0x06004CA5 RID: 19621 RVA: 0x00115860 File Offset: 0x00113A60
		[SecuritySafeCritical]
		public MethodBuilder DefinePInvokeMethod(string name, string dllName, string entryName, MethodAttributes attributes, CallingConventions callingConvention, Type returnType, Type[] parameterTypes, CallingConvention nativeCallConv, CharSet nativeCharSet)
		{
			return this.DefinePInvokeMethodHelper(name, dllName, entryName, attributes, callingConvention, returnType, null, null, parameterTypes, null, null, nativeCallConv, nativeCharSet);
		}

		/// <summary>Defines a <see langword="PInvoke" /> method given its name, the name of the DLL in which the method is defined, the name of the entry point, the attributes of the method, the calling convention of the method, the return type of the method, the types of the parameters of the method, the <see langword="PInvoke" /> flags, and custom modifiers for the parameters and return type.</summary>
		/// <param name="name">The name of the <see langword="PInvoke" /> method. <paramref name="name" /> cannot contain embedded nulls.</param>
		/// <param name="dllName">The name of the DLL in which the <see langword="PInvoke" /> method is defined.</param>
		/// <param name="entryName">The name of the entry point in the DLL.</param>
		/// <param name="attributes">The attributes of the method.</param>
		/// <param name="callingConvention">The method's calling convention.</param>
		/// <param name="returnType">The method's return type.</param>
		/// <param name="returnTypeRequiredCustomModifiers">An array of types representing the required custom modifiers, such as <see cref="T:System.Runtime.CompilerServices.IsConst" />, for the return type of the method. If the return type has no required custom modifiers, specify <see langword="null" />.</param>
		/// <param name="returnTypeOptionalCustomModifiers">An array of types representing the optional custom modifiers, such as <see cref="T:System.Runtime.CompilerServices.IsConst" />, for the return type of the method. If the return type has no optional custom modifiers, specify <see langword="null" />.</param>
		/// <param name="parameterTypes">The types of the method's parameters.</param>
		/// <param name="parameterTypeRequiredCustomModifiers">An array of arrays of types. Each array of types represents the required custom modifiers for the corresponding parameter, such as <see cref="T:System.Runtime.CompilerServices.IsConst" />. If a particular parameter has no required custom modifiers, specify <see langword="null" /> instead of an array of types. If none of the parameters have required custom modifiers, specify <see langword="null" /> instead of an array of arrays.</param>
		/// <param name="parameterTypeOptionalCustomModifiers">An array of arrays of types. Each array of types represents the optional custom modifiers for the corresponding parameter, such as <see cref="T:System.Runtime.CompilerServices.IsConst" />. If a particular parameter has no optional custom modifiers, specify <see langword="null" /> instead of an array of types. If none of the parameters have optional custom modifiers, specify <see langword="null" /> instead of an array of arrays.</param>
		/// <param name="nativeCallConv">The native calling convention.</param>
		/// <param name="nativeCharSet">The method's native character set.</param>
		/// <returns>A <see cref="T:System.Reflection.Emit.MethodBuilder" /> representing the defined <see langword="PInvoke" /> method.</returns>
		/// <exception cref="T:System.ArgumentException">The method is not static.  
		///  -or-  
		///  The parent type is an interface.  
		///  -or-  
		///  The method is abstract.  
		///  -or-  
		///  The method was previously defined.  
		///  -or-  
		///  The length of <paramref name="name" />, <paramref name="dllName" />, or <paramref name="entryName" /> is zero.  
		///  -or-  
		///  The size of <paramref name="parameterTypeRequiredCustomModifiers" /> or <paramref name="parameterTypeOptionalCustomModifiers" /> does not equal the size of <paramref name="parameterTypes" />.</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="name" />, <paramref name="dllName" />, or <paramref name="entryName" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.InvalidOperationException">The type was previously created using <see cref="M:System.Reflection.Emit.TypeBuilder.CreateType" />.  
		///  -or-  
		///  For the current dynamic type, the <see cref="P:System.Reflection.Emit.TypeBuilder.IsGenericType" /> property is <see langword="true" />, but the <see cref="P:System.Reflection.Emit.TypeBuilder.IsGenericTypeDefinition" /> property is <see langword="false" />.</exception>
		// Token: 0x06004CA6 RID: 19622 RVA: 0x00115888 File Offset: 0x00113A88
		[SecuritySafeCritical]
		public MethodBuilder DefinePInvokeMethod(string name, string dllName, string entryName, MethodAttributes attributes, CallingConventions callingConvention, Type returnType, Type[] returnTypeRequiredCustomModifiers, Type[] returnTypeOptionalCustomModifiers, Type[] parameterTypes, Type[][] parameterTypeRequiredCustomModifiers, Type[][] parameterTypeOptionalCustomModifiers, CallingConvention nativeCallConv, CharSet nativeCharSet)
		{
			return this.DefinePInvokeMethodHelper(name, dllName, entryName, attributes, callingConvention, returnType, returnTypeRequiredCustomModifiers, returnTypeOptionalCustomModifiers, parameterTypes, parameterTypeRequiredCustomModifiers, parameterTypeOptionalCustomModifiers, nativeCallConv, nativeCharSet);
		}

		/// <summary>Defines a nested type, given its name.</summary>
		/// <param name="name">The short name of the type. <paramref name="name" /> cannot contain embedded nulls.</param>
		/// <returns>The defined nested type.</returns>
		/// <exception cref="T:System.ArgumentException">Length of <paramref name="name" /> is zero or greater than 1023.  
		///  -or-  
		///  This operation would create a type with a duplicate <see cref="P:System.Reflection.Emit.TypeBuilder.FullName" /> in the current assembly.</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="name" /> is <see langword="null" />.</exception>
		// Token: 0x06004CA7 RID: 19623 RVA: 0x001158B4 File Offset: 0x00113AB4
		[SecuritySafeCritical]
		public TypeBuilder DefineNestedType(string name)
		{
			object syncRoot = this.SyncRoot;
			TypeBuilder result;
			lock (syncRoot)
			{
				result = this.DefineNestedTypeNoLock(name, TypeAttributes.NestedPrivate, null, null, PackingSize.Unspecified, 0);
			}
			return result;
		}

		/// <summary>Defines a nested type, given its name, attributes, the type that it extends, and the interfaces that it implements.</summary>
		/// <param name="name">The short name of the type. <paramref name="name" /> cannot contain embedded nulls.</param>
		/// <param name="attr">The attributes of the type.</param>
		/// <param name="parent">The type that the nested type extends.</param>
		/// <param name="interfaces">The interfaces that the nested type implements.</param>
		/// <returns>The defined nested type.</returns>
		/// <exception cref="T:System.ArgumentException">The nested attribute is not specified.  
		///  -or-  
		///  This type is sealed.  
		///  -or-  
		///  This type is an array.  
		///  -or-  
		///  This type is an interface, but the nested type is not an interface.  
		///  -or-  
		///  The length of <paramref name="name" /> is zero or greater than 1023.  
		///  -or-  
		///  This operation would create a type with a duplicate <see cref="P:System.Reflection.Emit.TypeBuilder.FullName" /> in the current assembly.</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="name" /> is <see langword="null" />.  
		/// -or-  
		/// An element of the <paramref name="interfaces" /> array is <see langword="null" />.</exception>
		// Token: 0x06004CA8 RID: 19624 RVA: 0x001158FC File Offset: 0x00113AFC
		[SecuritySafeCritical]
		[ComVisible(true)]
		public TypeBuilder DefineNestedType(string name, TypeAttributes attr, Type parent, Type[] interfaces)
		{
			object syncRoot = this.SyncRoot;
			TypeBuilder result;
			lock (syncRoot)
			{
				this.CheckContext(new Type[]
				{
					parent
				});
				this.CheckContext(interfaces);
				result = this.DefineNestedTypeNoLock(name, attr, parent, interfaces, PackingSize.Unspecified, 0);
			}
			return result;
		}

		/// <summary>Defines a nested type, given its name, attributes, and the type that it extends.</summary>
		/// <param name="name">The short name of the type. <paramref name="name" /> cannot contain embedded nulls.</param>
		/// <param name="attr">The attributes of the type.</param>
		/// <param name="parent">The type that the nested type extends.</param>
		/// <returns>The defined nested type.</returns>
		/// <exception cref="T:System.ArgumentException">The nested attribute is not specified.  
		///  -or-  
		///  This type is sealed.  
		///  -or-  
		///  This type is an array.  
		///  -or-  
		///  This type is an interface, but the nested type is not an interface.  
		///  -or-  
		///  The length of <paramref name="name" /> is zero or greater than 1023.  
		///  -or-  
		///  This operation would create a type with a duplicate <see cref="P:System.Reflection.Emit.TypeBuilder.FullName" /> in the current assembly.</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="name" /> is <see langword="null" />.</exception>
		// Token: 0x06004CA9 RID: 19625 RVA: 0x00115960 File Offset: 0x00113B60
		[SecuritySafeCritical]
		public TypeBuilder DefineNestedType(string name, TypeAttributes attr, Type parent)
		{
			object syncRoot = this.SyncRoot;
			TypeBuilder result;
			lock (syncRoot)
			{
				result = this.DefineNestedTypeNoLock(name, attr, parent, null, PackingSize.Unspecified, 0);
			}
			return result;
		}

		/// <summary>Defines a nested type, given its name and attributes.</summary>
		/// <param name="name">The short name of the type. <paramref name="name" /> cannot contain embedded nulls.</param>
		/// <param name="attr">The attributes of the type.</param>
		/// <returns>The defined nested type.</returns>
		/// <exception cref="T:System.ArgumentException">The nested attribute is not specified.  
		///  -or-  
		///  This type is sealed.  
		///  -or-  
		///  This type is an array.  
		///  -or-  
		///  This type is an interface, but the nested type is not an interface.  
		///  -or-  
		///  The length of <paramref name="name" /> is zero or greater than 1023.  
		///  -or-  
		///  This operation would create a type with a duplicate <see cref="P:System.Reflection.Emit.TypeBuilder.FullName" /> in the current assembly.</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="name" /> is <see langword="null" />.</exception>
		// Token: 0x06004CAA RID: 19626 RVA: 0x001159A8 File Offset: 0x00113BA8
		[SecuritySafeCritical]
		public TypeBuilder DefineNestedType(string name, TypeAttributes attr)
		{
			object syncRoot = this.SyncRoot;
			TypeBuilder result;
			lock (syncRoot)
			{
				result = this.DefineNestedTypeNoLock(name, attr, null, null, PackingSize.Unspecified, 0);
			}
			return result;
		}

		/// <summary>Defines a nested type, given its name, attributes, the total size of the type, and the type that it extends.</summary>
		/// <param name="name">The short name of the type. <paramref name="name" /> cannot contain embedded nulls.</param>
		/// <param name="attr">The attributes of the type.</param>
		/// <param name="parent">The type that the nested type extends.</param>
		/// <param name="typeSize">The total size of the type.</param>
		/// <returns>The defined nested type.</returns>
		/// <exception cref="T:System.ArgumentException">The nested attribute is not specified.  
		///  -or-  
		///  This type is sealed.  
		///  -or-  
		///  This type is an array.  
		///  -or-  
		///  This type is an interface, but the nested type is not an interface.  
		///  -or-  
		///  The length of <paramref name="name" /> is zero or greater than 1023.  
		///  -or-  
		///  This operation would create a type with a duplicate <see cref="P:System.Reflection.Emit.TypeBuilder.FullName" /> in the current assembly.</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="name" /> is <see langword="null" />.</exception>
		// Token: 0x06004CAB RID: 19627 RVA: 0x001159F0 File Offset: 0x00113BF0
		[SecuritySafeCritical]
		public TypeBuilder DefineNestedType(string name, TypeAttributes attr, Type parent, int typeSize)
		{
			object syncRoot = this.SyncRoot;
			TypeBuilder result;
			lock (syncRoot)
			{
				result = this.DefineNestedTypeNoLock(name, attr, parent, null, PackingSize.Unspecified, typeSize);
			}
			return result;
		}

		/// <summary>Defines a nested type, given its name, attributes, the type that it extends, and the packing size.</summary>
		/// <param name="name">The short name of the type. <paramref name="name" /> cannot contain embedded nulls.</param>
		/// <param name="attr">The attributes of the type.</param>
		/// <param name="parent">The type that the nested type extends.</param>
		/// <param name="packSize">The packing size of the type.</param>
		/// <returns>The defined nested type.</returns>
		/// <exception cref="T:System.ArgumentException">The nested attribute is not specified.  
		///  -or-  
		///  This type is sealed.  
		///  -or-  
		///  This type is an array.  
		///  -or-  
		///  This type is an interface, but the nested type is not an interface.  
		///  -or-  
		///  The length of <paramref name="name" /> is zero or greater than 1023.  
		///  -or-  
		///  This operation would create a type with a duplicate <see cref="P:System.Reflection.Emit.TypeBuilder.FullName" /> in the current assembly.</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="name" /> is <see langword="null" />.</exception>
		// Token: 0x06004CAC RID: 19628 RVA: 0x00115A3C File Offset: 0x00113C3C
		[SecuritySafeCritical]
		public TypeBuilder DefineNestedType(string name, TypeAttributes attr, Type parent, PackingSize packSize)
		{
			object syncRoot = this.SyncRoot;
			TypeBuilder result;
			lock (syncRoot)
			{
				result = this.DefineNestedTypeNoLock(name, attr, parent, null, packSize, 0);
			}
			return result;
		}

		/// <summary>Defines a nested type, given its name, attributes, size, and the type that it extends.</summary>
		/// <param name="name">The short name of the type. <paramref name="name" /> cannot contain embedded null values.</param>
		/// <param name="attr">The attributes of the type.</param>
		/// <param name="parent">The type that the nested type extends.</param>
		/// <param name="packSize">The packing size of the type.</param>
		/// <param name="typeSize">The total size of the type.</param>
		/// <returns>The defined nested type.</returns>
		// Token: 0x06004CAD RID: 19629 RVA: 0x00115A88 File Offset: 0x00113C88
		[SecuritySafeCritical]
		public TypeBuilder DefineNestedType(string name, TypeAttributes attr, Type parent, PackingSize packSize, int typeSize)
		{
			object syncRoot = this.SyncRoot;
			TypeBuilder result;
			lock (syncRoot)
			{
				result = this.DefineNestedTypeNoLock(name, attr, parent, null, packSize, typeSize);
			}
			return result;
		}

		// Token: 0x06004CAE RID: 19630 RVA: 0x00115AD4 File Offset: 0x00113CD4
		[SecurityCritical]
		private TypeBuilder DefineNestedTypeNoLock(string name, TypeAttributes attr, Type parent, Type[] interfaces, PackingSize packSize, int typeSize)
		{
			return new TypeBuilder(name, attr, parent, interfaces, this.m_module, packSize, typeSize, this);
		}

		/// <summary>Adds a new field to the type, with the given name, attributes, and field type.</summary>
		/// <param name="fieldName">The name of the field. <paramref name="fieldName" /> cannot contain embedded nulls.</param>
		/// <param name="type">The type of the field</param>
		/// <param name="attributes">The attributes of the field.</param>
		/// <returns>The defined field.</returns>
		/// <exception cref="T:System.ArgumentException">The length of <paramref name="fieldName" /> is zero.  
		///  -or-  
		///  <paramref name="type" /> is System.Void.  
		///  -or-  
		///  A total size was specified for the parent class of this field.</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="fieldName" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.InvalidOperationException">The type was previously created using <see cref="M:System.Reflection.Emit.TypeBuilder.CreateType" />.</exception>
		// Token: 0x06004CAF RID: 19631 RVA: 0x00115AEB File Offset: 0x00113CEB
		public FieldBuilder DefineField(string fieldName, Type type, FieldAttributes attributes)
		{
			return this.DefineField(fieldName, type, null, null, attributes);
		}

		/// <summary>Adds a new field to the type, with the given name, attributes, field type, and custom modifiers.</summary>
		/// <param name="fieldName">The name of the field. <paramref name="fieldName" /> cannot contain embedded nulls.</param>
		/// <param name="type">The type of the field</param>
		/// <param name="requiredCustomModifiers">An array of types representing the required custom modifiers for the field, such as <see cref="T:Microsoft.VisualC.IsConstModifier" />.</param>
		/// <param name="optionalCustomModifiers">An array of types representing the optional custom modifiers for the field, such as <see cref="T:Microsoft.VisualC.IsConstModifier" />.</param>
		/// <param name="attributes">The attributes of the field.</param>
		/// <returns>The defined field.</returns>
		/// <exception cref="T:System.ArgumentException">The length of <paramref name="fieldName" /> is zero.  
		///  -or-  
		///  <paramref name="type" /> is System.Void.  
		///  -or-  
		///  A total size was specified for the parent class of this field.</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="fieldName" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.InvalidOperationException">The type was previously created using <see cref="M:System.Reflection.Emit.TypeBuilder.CreateType" />.</exception>
		// Token: 0x06004CB0 RID: 19632 RVA: 0x00115AF8 File Offset: 0x00113CF8
		[SecuritySafeCritical]
		public FieldBuilder DefineField(string fieldName, Type type, Type[] requiredCustomModifiers, Type[] optionalCustomModifiers, FieldAttributes attributes)
		{
			object syncRoot = this.SyncRoot;
			FieldBuilder result;
			lock (syncRoot)
			{
				result = this.DefineFieldNoLock(fieldName, type, requiredCustomModifiers, optionalCustomModifiers, attributes);
			}
			return result;
		}

		// Token: 0x06004CB1 RID: 19633 RVA: 0x00115B44 File Offset: 0x00113D44
		[SecurityCritical]
		private FieldBuilder DefineFieldNoLock(string fieldName, Type type, Type[] requiredCustomModifiers, Type[] optionalCustomModifiers, FieldAttributes attributes)
		{
			this.ThrowIfCreated();
			this.CheckContext(new Type[]
			{
				type
			});
			this.CheckContext(requiredCustomModifiers);
			if (this.m_enumUnderlyingType == null && this.IsEnum && (attributes & FieldAttributes.Static) == FieldAttributes.PrivateScope)
			{
				this.m_enumUnderlyingType = type;
			}
			return new FieldBuilder(this, fieldName, type, requiredCustomModifiers, optionalCustomModifiers, attributes);
		}

		/// <summary>Defines initialized data field in the .sdata section of the portable executable (PE) file.</summary>
		/// <param name="name">The name used to refer to the data. <paramref name="name" /> cannot contain embedded nulls.</param>
		/// <param name="data">The blob of data.</param>
		/// <param name="attributes">The attributes for the field.</param>
		/// <returns>A field to reference the data.</returns>
		/// <exception cref="T:System.ArgumentException">Length of <paramref name="name" /> is zero.  
		///  -or-  
		///  The size of the data is less than or equal to zero, or greater than or equal to 0x3f0000.</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="name" /> or <paramref name="data" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.InvalidOperationException">
		///   <see cref="M:System.Reflection.Emit.TypeBuilder.CreateType" /> has been previously called.</exception>
		// Token: 0x06004CB2 RID: 19634 RVA: 0x00115BA0 File Offset: 0x00113DA0
		[SecuritySafeCritical]
		public FieldBuilder DefineInitializedData(string name, byte[] data, FieldAttributes attributes)
		{
			object syncRoot = this.SyncRoot;
			FieldBuilder result;
			lock (syncRoot)
			{
				result = this.DefineInitializedDataNoLock(name, data, attributes);
			}
			return result;
		}

		// Token: 0x06004CB3 RID: 19635 RVA: 0x00115BE8 File Offset: 0x00113DE8
		[SecurityCritical]
		private FieldBuilder DefineInitializedDataNoLock(string name, byte[] data, FieldAttributes attributes)
		{
			if (data == null)
			{
				throw new ArgumentNullException("data");
			}
			return this.DefineDataHelper(name, data, data.Length, attributes);
		}

		/// <summary>Defines an uninitialized data field in the <see langword=".sdata" /> section of the portable executable (PE) file.</summary>
		/// <param name="name">The name used to refer to the data. <paramref name="name" /> cannot contain embedded nulls.</param>
		/// <param name="size">The size of the data field.</param>
		/// <param name="attributes">The attributes for the field.</param>
		/// <returns>A field to reference the data.</returns>
		/// <exception cref="T:System.ArgumentException">Length of <paramref name="name" /> is zero.  
		///  -or-  
		///  <paramref name="size" /> is less than or equal to zero, or greater than or equal to 0x003f0000.</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="name" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.InvalidOperationException">The type was previously created using <see cref="M:System.Reflection.Emit.TypeBuilder.CreateType" />.</exception>
		// Token: 0x06004CB4 RID: 19636 RVA: 0x00115C04 File Offset: 0x00113E04
		[SecuritySafeCritical]
		public FieldBuilder DefineUninitializedData(string name, int size, FieldAttributes attributes)
		{
			object syncRoot = this.SyncRoot;
			FieldBuilder result;
			lock (syncRoot)
			{
				result = this.DefineUninitializedDataNoLock(name, size, attributes);
			}
			return result;
		}

		// Token: 0x06004CB5 RID: 19637 RVA: 0x00115C4C File Offset: 0x00113E4C
		[SecurityCritical]
		private FieldBuilder DefineUninitializedDataNoLock(string name, int size, FieldAttributes attributes)
		{
			return this.DefineDataHelper(name, null, size, attributes);
		}

		/// <summary>Adds a new property to the type, with the given name and property signature.</summary>
		/// <param name="name">The name of the property. <paramref name="name" /> cannot contain embedded nulls.</param>
		/// <param name="attributes">The attributes of the property.</param>
		/// <param name="returnType">The return type of the property.</param>
		/// <param name="parameterTypes">The types of the parameters of the property.</param>
		/// <returns>The defined property.</returns>
		/// <exception cref="T:System.ArgumentException">The length of <paramref name="name" /> is zero.</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="name" /> is <see langword="null" />.  
		/// -or-  
		/// Any of the elements of the <paramref name="parameterTypes" /> array is <see langword="null" />.</exception>
		/// <exception cref="T:System.InvalidOperationException">The type was previously created using <see cref="M:System.Reflection.Emit.TypeBuilder.CreateType" />.</exception>
		// Token: 0x06004CB6 RID: 19638 RVA: 0x00115C58 File Offset: 0x00113E58
		public PropertyBuilder DefineProperty(string name, PropertyAttributes attributes, Type returnType, Type[] parameterTypes)
		{
			return this.DefineProperty(name, attributes, returnType, null, null, parameterTypes, null, null);
		}

		/// <summary>Adds a new property to the type, with the given name, attributes, calling convention, and property signature.</summary>
		/// <param name="name">The name of the property. <paramref name="name" /> cannot contain embedded nulls.</param>
		/// <param name="attributes">The attributes of the property.</param>
		/// <param name="callingConvention">The calling convention of the property accessors.</param>
		/// <param name="returnType">The return type of the property.</param>
		/// <param name="parameterTypes">The types of the parameters of the property.</param>
		/// <returns>The defined property.</returns>
		/// <exception cref="T:System.ArgumentException">The length of <paramref name="name" /> is zero.</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="name" /> is <see langword="null" />.  
		/// -or-  
		/// Any of the elements of the <paramref name="parameterTypes" /> array is <see langword="null" />.</exception>
		/// <exception cref="T:System.InvalidOperationException">The type was previously created using <see cref="M:System.Reflection.Emit.TypeBuilder.CreateType" />.</exception>
		// Token: 0x06004CB7 RID: 19639 RVA: 0x00115C74 File Offset: 0x00113E74
		public PropertyBuilder DefineProperty(string name, PropertyAttributes attributes, CallingConventions callingConvention, Type returnType, Type[] parameterTypes)
		{
			return this.DefineProperty(name, attributes, callingConvention, returnType, null, null, parameterTypes, null, null);
		}

		/// <summary>Adds a new property to the type, with the given name, property signature, and custom modifiers.</summary>
		/// <param name="name">The name of the property. <paramref name="name" /> cannot contain embedded nulls.</param>
		/// <param name="attributes">The attributes of the property.</param>
		/// <param name="returnType">The return type of the property.</param>
		/// <param name="returnTypeRequiredCustomModifiers">An array of types representing the required custom modifiers, such as <see cref="T:System.Runtime.CompilerServices.IsConst" />, for the return type of the property. If the return type has no required custom modifiers, specify <see langword="null" />.</param>
		/// <param name="returnTypeOptionalCustomModifiers">An array of types representing the optional custom modifiers, such as <see cref="T:System.Runtime.CompilerServices.IsConst" />, for the return type of the property. If the return type has no optional custom modifiers, specify <see langword="null" />.</param>
		/// <param name="parameterTypes">The types of the parameters of the property.</param>
		/// <param name="parameterTypeRequiredCustomModifiers">An array of arrays of types. Each array of types represents the required custom modifiers for the corresponding parameter, such as <see cref="T:System.Runtime.CompilerServices.IsConst" />. If a particular parameter has no required custom modifiers, specify <see langword="null" /> instead of an array of types. If none of the parameters have required custom modifiers, specify <see langword="null" /> instead of an array of arrays.</param>
		/// <param name="parameterTypeOptionalCustomModifiers">An array of arrays of types. Each array of types represents the optional custom modifiers for the corresponding parameter, such as <see cref="T:System.Runtime.CompilerServices.IsConst" />. If a particular parameter has no optional custom modifiers, specify <see langword="null" /> instead of an array of types. If none of the parameters have optional custom modifiers, specify <see langword="null" /> instead of an array of arrays.</param>
		/// <returns>The defined property.</returns>
		/// <exception cref="T:System.ArgumentException">The length of <paramref name="name" /> is zero.</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="name" /> is <see langword="null" />  
		/// -or-  
		/// Any of the elements of the <paramref name="parameterTypes" /> array is <see langword="null" /></exception>
		/// <exception cref="T:System.InvalidOperationException">The type was previously created using <see cref="M:System.Reflection.Emit.TypeBuilder.CreateType" />.</exception>
		// Token: 0x06004CB8 RID: 19640 RVA: 0x00115C94 File Offset: 0x00113E94
		public PropertyBuilder DefineProperty(string name, PropertyAttributes attributes, Type returnType, Type[] returnTypeRequiredCustomModifiers, Type[] returnTypeOptionalCustomModifiers, Type[] parameterTypes, Type[][] parameterTypeRequiredCustomModifiers, Type[][] parameterTypeOptionalCustomModifiers)
		{
			return this.DefineProperty(name, attributes, (CallingConventions)0, returnType, returnTypeRequiredCustomModifiers, returnTypeOptionalCustomModifiers, parameterTypes, parameterTypeRequiredCustomModifiers, parameterTypeOptionalCustomModifiers);
		}

		/// <summary>Adds a new property to the type, with the given name, calling convention, property signature, and custom modifiers.</summary>
		/// <param name="name">The name of the property. <paramref name="name" /> cannot contain embedded nulls.</param>
		/// <param name="attributes">The attributes of the property.</param>
		/// <param name="callingConvention">The calling convention of the property accessors.</param>
		/// <param name="returnType">The return type of the property.</param>
		/// <param name="returnTypeRequiredCustomModifiers">An array of types representing the required custom modifiers, such as <see cref="T:System.Runtime.CompilerServices.IsConst" />, for the return type of the property. If the return type has no required custom modifiers, specify <see langword="null" />.</param>
		/// <param name="returnTypeOptionalCustomModifiers">An array of types representing the optional custom modifiers, such as <see cref="T:System.Runtime.CompilerServices.IsConst" />, for the return type of the property. If the return type has no optional custom modifiers, specify <see langword="null" />.</param>
		/// <param name="parameterTypes">The types of the parameters of the property.</param>
		/// <param name="parameterTypeRequiredCustomModifiers">An array of arrays of types. Each array of types represents the required custom modifiers for the corresponding parameter, such as <see cref="T:System.Runtime.CompilerServices.IsConst" />. If a particular parameter has no required custom modifiers, specify <see langword="null" /> instead of an array of types. If none of the parameters have required custom modifiers, specify <see langword="null" /> instead of an array of arrays.</param>
		/// <param name="parameterTypeOptionalCustomModifiers">An array of arrays of types. Each array of types represents the optional custom modifiers for the corresponding parameter, such as <see cref="T:System.Runtime.CompilerServices.IsConst" />. If a particular parameter has no optional custom modifiers, specify <see langword="null" /> instead of an array of types. If none of the parameters have optional custom modifiers, specify <see langword="null" /> instead of an array of arrays.</param>
		/// <returns>The defined property.</returns>
		/// <exception cref="T:System.ArgumentException">The length of <paramref name="name" /> is zero.</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="name" /> is <see langword="null" />.  
		/// -or-  
		/// Any of the elements of the <paramref name="parameterTypes" /> array is <see langword="null" />.</exception>
		/// <exception cref="T:System.InvalidOperationException">The type was previously created using <see cref="M:System.Reflection.Emit.TypeBuilder.CreateType" />.</exception>
		// Token: 0x06004CB9 RID: 19641 RVA: 0x00115CB8 File Offset: 0x00113EB8
		[SecuritySafeCritical]
		public PropertyBuilder DefineProperty(string name, PropertyAttributes attributes, CallingConventions callingConvention, Type returnType, Type[] returnTypeRequiredCustomModifiers, Type[] returnTypeOptionalCustomModifiers, Type[] parameterTypes, Type[][] parameterTypeRequiredCustomModifiers, Type[][] parameterTypeOptionalCustomModifiers)
		{
			object syncRoot = this.SyncRoot;
			PropertyBuilder result;
			lock (syncRoot)
			{
				result = this.DefinePropertyNoLock(name, attributes, callingConvention, returnType, returnTypeRequiredCustomModifiers, returnTypeOptionalCustomModifiers, parameterTypes, parameterTypeRequiredCustomModifiers, parameterTypeOptionalCustomModifiers);
			}
			return result;
		}

		// Token: 0x06004CBA RID: 19642 RVA: 0x00115D0C File Offset: 0x00113F0C
		[SecurityCritical]
		private PropertyBuilder DefinePropertyNoLock(string name, PropertyAttributes attributes, CallingConventions callingConvention, Type returnType, Type[] returnTypeRequiredCustomModifiers, Type[] returnTypeOptionalCustomModifiers, Type[] parameterTypes, Type[][] parameterTypeRequiredCustomModifiers, Type[][] parameterTypeOptionalCustomModifiers)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			if (name.Length == 0)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_EmptyName"), "name");
			}
			this.CheckContext(new Type[]
			{
				returnType
			});
			this.CheckContext(new Type[][]
			{
				returnTypeRequiredCustomModifiers,
				returnTypeOptionalCustomModifiers,
				parameterTypes
			});
			this.CheckContext(parameterTypeRequiredCustomModifiers);
			this.CheckContext(parameterTypeOptionalCustomModifiers);
			this.ThrowIfCreated();
			SignatureHelper propertySigHelper = SignatureHelper.GetPropertySigHelper(this.m_module, callingConvention, returnType, returnTypeRequiredCustomModifiers, returnTypeOptionalCustomModifiers, parameterTypes, parameterTypeRequiredCustomModifiers, parameterTypeOptionalCustomModifiers);
			int sigLength;
			byte[] signature = propertySigHelper.InternalGetSignature(out sigLength);
			PropertyToken prToken = new PropertyToken(TypeBuilder.DefineProperty(this.m_module.GetNativeHandle(), this.m_tdType.Token, name, attributes, signature, sigLength));
			return new PropertyBuilder(this.m_module, name, propertySigHelper, attributes, returnType, prToken, this);
		}

		/// <summary>Adds a new event to the type, with the given name, attributes and event type.</summary>
		/// <param name="name">The name of the event. <paramref name="name" /> cannot contain embedded nulls.</param>
		/// <param name="attributes">The attributes of the event.</param>
		/// <param name="eventtype">The type of the event.</param>
		/// <returns>The defined event.</returns>
		/// <exception cref="T:System.ArgumentException">The length of <paramref name="name" /> is zero.</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="name" /> is <see langword="null" />.  
		/// -or-  
		/// <paramref name="eventtype" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.InvalidOperationException">The type was previously created using <see cref="M:System.Reflection.Emit.TypeBuilder.CreateType" />.</exception>
		// Token: 0x06004CBB RID: 19643 RVA: 0x00115DE0 File Offset: 0x00113FE0
		[SecuritySafeCritical]
		public EventBuilder DefineEvent(string name, EventAttributes attributes, Type eventtype)
		{
			object syncRoot = this.SyncRoot;
			EventBuilder result;
			lock (syncRoot)
			{
				result = this.DefineEventNoLock(name, attributes, eventtype);
			}
			return result;
		}

		// Token: 0x06004CBC RID: 19644 RVA: 0x00115E28 File Offset: 0x00114028
		[SecurityCritical]
		private EventBuilder DefineEventNoLock(string name, EventAttributes attributes, Type eventtype)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			if (name.Length == 0)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_EmptyName"), "name");
			}
			if (name[0] == '\0')
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_IllegalName"), "name");
			}
			this.CheckContext(new Type[]
			{
				eventtype
			});
			this.ThrowIfCreated();
			int token = this.m_module.GetTypeTokenInternal(eventtype).Token;
			EventToken evToken = new EventToken(TypeBuilder.DefineEvent(this.m_module.GetNativeHandle(), this.m_tdType.Token, name, attributes, token));
			return new EventBuilder(this.m_module, name, attributes, this, evToken);
		}

		/// <summary>Gets a <see cref="T:System.Reflection.TypeInfo" /> object that represents this type.</summary>
		/// <returns>An object that represents this type.</returns>
		// Token: 0x06004CBD RID: 19645 RVA: 0x00115EE0 File Offset: 0x001140E0
		[SecuritySafeCritical]
		public TypeInfo CreateTypeInfo()
		{
			object syncRoot = this.SyncRoot;
			TypeInfo result;
			lock (syncRoot)
			{
				result = this.CreateTypeNoLock();
			}
			return result;
		}

		/// <summary>Creates a <see cref="T:System.Type" /> object for the class. After defining fields and methods on the class, <see langword="CreateType" /> is called in order to load its <see langword="Type" /> object.</summary>
		/// <returns>Returns the new <see cref="T:System.Type" /> object for this class.</returns>
		/// <exception cref="T:System.InvalidOperationException">The enclosing type has not been created.  
		///  -or-  
		///  This type is non-abstract and contains an abstract method.  
		///  -or-  
		///  This type is not an abstract class or an interface and has a method without a method body.</exception>
		/// <exception cref="T:System.NotSupportedException">The type contains invalid Microsoft intermediate language (MSIL) code.  
		///  -or-  
		///  The branch target is specified using a 1-byte offset, but the target is at a distance greater than 127 bytes from the branch.</exception>
		/// <exception cref="T:System.TypeLoadException">The type cannot be loaded. For example, it contains a <see langword="static" /> method that has the calling convention <see cref="F:System.Reflection.CallingConventions.HasThis" />.</exception>
		// Token: 0x06004CBE RID: 19646 RVA: 0x00115F24 File Offset: 0x00114124
		[SecuritySafeCritical]
		public Type CreateType()
		{
			object syncRoot = this.SyncRoot;
			Type result;
			lock (syncRoot)
			{
				result = this.CreateTypeNoLock();
			}
			return result;
		}

		// Token: 0x06004CBF RID: 19647 RVA: 0x00115F68 File Offset: 0x00114168
		internal void CheckContext(params Type[][] typess)
		{
			this.m_module.CheckContext(typess);
		}

		// Token: 0x06004CC0 RID: 19648 RVA: 0x00115F76 File Offset: 0x00114176
		internal void CheckContext(params Type[] types)
		{
			this.m_module.CheckContext(types);
		}

		// Token: 0x06004CC1 RID: 19649 RVA: 0x00115F84 File Offset: 0x00114184
		[SecurityCritical]
		private TypeInfo CreateTypeNoLock()
		{
			if (this.IsCreated())
			{
				return this.m_bakedRuntimeType;
			}
			this.ThrowIfCreated();
			if (this.m_typeInterfaces == null)
			{
				this.m_typeInterfaces = new List<Type>();
			}
			int[] array = new int[this.m_typeInterfaces.Count];
			for (int i = 0; i < this.m_typeInterfaces.Count; i++)
			{
				array[i] = this.m_module.GetTypeTokenInternal(this.m_typeInterfaces[i]).Token;
			}
			int num = 0;
			if (this.m_typeParent != null)
			{
				num = this.m_module.GetTypeTokenInternal(this.m_typeParent).Token;
			}
			if (this.IsGenericParameter)
			{
				int[] array2;
				if (this.m_typeParent != null)
				{
					array2 = new int[this.m_typeInterfaces.Count + 2];
					array2[array2.Length - 2] = num;
				}
				else
				{
					array2 = new int[this.m_typeInterfaces.Count + 1];
				}
				for (int j = 0; j < this.m_typeInterfaces.Count; j++)
				{
					array2[j] = this.m_module.GetTypeTokenInternal(this.m_typeInterfaces[j]).Token;
				}
				int tkParent = (this.m_declMeth == null) ? this.m_DeclaringType.m_tdType.Token : this.m_declMeth.GetToken().Token;
				this.m_tdType = new TypeToken(TypeBuilder.DefineGenericParam(this.m_module.GetNativeHandle(), this.m_strName, tkParent, this.m_genParamAttributes, this.m_genParamPos, array2));
				if (this.m_ca != null)
				{
					foreach (TypeBuilder.CustAttr custAttr in this.m_ca)
					{
						custAttr.Bake(this.m_module, this.MetadataTokenInternal);
					}
				}
				this.m_hasBeenCreated = true;
				return this;
			}
			if ((this.m_tdType.Token & 16777215) != 0 && (num & 16777215) != 0)
			{
				TypeBuilder.SetParentType(this.m_module.GetNativeHandle(), this.m_tdType.Token, num);
			}
			if (this.m_inst != null)
			{
				foreach (GenericTypeParameterBuilder type in this.m_inst)
				{
					if (type is GenericTypeParameterBuilder)
					{
						((GenericTypeParameterBuilder)type).m_type.CreateType();
					}
				}
			}
			if (!this.m_isHiddenGlobalType && this.m_constructorCount == 0 && (this.m_iAttr & TypeAttributes.ClassSemanticsMask) == TypeAttributes.NotPublic && !base.IsValueType && (this.m_iAttr & (TypeAttributes.Abstract | TypeAttributes.Sealed)) != (TypeAttributes.Abstract | TypeAttributes.Sealed))
			{
				this.DefineDefaultConstructor(MethodAttributes.Public);
			}
			int count = this.m_listMethods.Count;
			for (int l = 0; l < count; l++)
			{
				MethodBuilder methodBuilder = this.m_listMethods[l];
				if (methodBuilder.IsGenericMethodDefinition)
				{
					methodBuilder.GetToken();
				}
				MethodAttributes attributes = methodBuilder.Attributes;
				if ((methodBuilder.GetMethodImplementationFlags() & (MethodImplAttributes)135) == MethodImplAttributes.IL && (attributes & MethodAttributes.PinvokeImpl) == MethodAttributes.PrivateScope)
				{
					int sigLength;
					byte[] localSignature = methodBuilder.GetLocalSignature(out sigLength);
					if ((attributes & MethodAttributes.Abstract) != MethodAttributes.PrivateScope && (this.m_iAttr & TypeAttributes.Abstract) == TypeAttributes.NotPublic)
					{
						throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_BadTypeAttributesNotAbstract"));
					}
					byte[] body = methodBuilder.GetBody();
					if ((attributes & MethodAttributes.Abstract) != MethodAttributes.PrivateScope)
					{
						if (body != null)
						{
							throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_BadMethodBody"));
						}
					}
					else if (body == null || body.Length == 0)
					{
						if (methodBuilder.m_ilGenerator != null)
						{
							methodBuilder.CreateMethodBodyHelper(methodBuilder.GetILGenerator());
						}
						body = methodBuilder.GetBody();
						if ((body == null || body.Length == 0) && !methodBuilder.m_canBeRuntimeImpl)
						{
							throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_BadEmptyMethodBody", new object[]
							{
								methodBuilder.Name
							}));
						}
					}
					int maxStack = methodBuilder.GetMaxStack();
					ExceptionHandler[] exceptionHandlers = methodBuilder.GetExceptionHandlers();
					int[] tokenFixups = methodBuilder.GetTokenFixups();
					TypeBuilder.SetMethodIL(this.m_module.GetNativeHandle(), methodBuilder.GetToken().Token, methodBuilder.InitLocals, body, (body != null) ? body.Length : 0, localSignature, sigLength, maxStack, exceptionHandlers, (exceptionHandlers != null) ? exceptionHandlers.Length : 0, tokenFixups, (tokenFixups != null) ? tokenFixups.Length : 0);
					if (this.m_module.ContainingAssemblyBuilder.m_assemblyData.m_access == AssemblyBuilderAccess.Run)
					{
						methodBuilder.ReleaseBakedStructures();
					}
				}
			}
			this.m_hasBeenCreated = true;
			RuntimeType runtimeType = null;
			TypeBuilder.TermCreateClass(this.m_module.GetNativeHandle(), this.m_tdType.Token, JitHelpers.GetObjectHandleOnStack<RuntimeType>(ref runtimeType));
			if (!this.m_isHiddenGlobalType)
			{
				this.m_bakedRuntimeType = runtimeType;
				if (this.m_DeclaringType != null && this.m_DeclaringType.m_bakedRuntimeType != null)
				{
					this.m_DeclaringType.m_bakedRuntimeType.InvalidateCachedNestedType();
				}
				return runtimeType;
			}
			return null;
		}

		/// <summary>Retrieves the total size of a type.</summary>
		/// <returns>Read-only. Retrieves this type's total size.</returns>
		// Token: 0x17000C1A RID: 3098
		// (get) Token: 0x06004CC2 RID: 19650 RVA: 0x0011645C File Offset: 0x0011465C
		public int Size
		{
			get
			{
				return this.m_iTypeSize;
			}
		}

		/// <summary>Retrieves the packing size of this type.</summary>
		/// <returns>Read-only. Retrieves the packing size of this type.</returns>
		// Token: 0x17000C1B RID: 3099
		// (get) Token: 0x06004CC3 RID: 19651 RVA: 0x00116464 File Offset: 0x00114664
		public PackingSize PackingSize
		{
			get
			{
				return this.m_iPackingSize;
			}
		}

		/// <summary>Sets the base type of the type currently under construction.</summary>
		/// <param name="parent">The new base type.</param>
		/// <exception cref="T:System.InvalidOperationException">The type was previously created using <see cref="M:System.Reflection.Emit.TypeBuilder.CreateType" />.  
		///  -or-  
		///  <paramref name="parent" /> is <see langword="null" />, and the current instance represents an interface whose attributes do not include <see cref="F:System.Reflection.TypeAttributes.Abstract" />.  
		///  -or-  
		///  For the current dynamic type, the <see cref="P:System.Reflection.Emit.TypeBuilder.IsGenericType" /> property is <see langword="true" />, but the <see cref="P:System.Reflection.Emit.TypeBuilder.IsGenericTypeDefinition" /> property is <see langword="false" />.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="parent" /> is an interface. This exception condition is new in the .NET Framework version 2.0.</exception>
		// Token: 0x06004CC4 RID: 19652 RVA: 0x0011646C File Offset: 0x0011466C
		public void SetParent(Type parent)
		{
			this.ThrowIfCreated();
			if (parent != null)
			{
				this.CheckContext(new Type[]
				{
					parent
				});
				if (parent.IsInterface)
				{
					throw new ArgumentException(Environment.GetResourceString("Argument_CannotSetParentToInterface"));
				}
				this.m_typeParent = parent;
				return;
			}
			else
			{
				if ((this.m_iAttr & TypeAttributes.ClassSemanticsMask) != TypeAttributes.ClassSemanticsMask)
				{
					this.m_typeParent = typeof(object);
					return;
				}
				if ((this.m_iAttr & TypeAttributes.Abstract) == TypeAttributes.NotPublic)
				{
					throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_BadInterfaceNotAbstract"));
				}
				this.m_typeParent = null;
				return;
			}
		}

		/// <summary>Adds an interface that this type implements.</summary>
		/// <param name="interfaceType">The interface that this type implements.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="interfaceType" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.InvalidOperationException">The type was previously created using <see cref="M:System.Reflection.Emit.TypeBuilder.CreateType" />.</exception>
		// Token: 0x06004CC5 RID: 19653 RVA: 0x001164FC File Offset: 0x001146FC
		[SecuritySafeCritical]
		[ComVisible(true)]
		public void AddInterfaceImplementation(Type interfaceType)
		{
			if (interfaceType == null)
			{
				throw new ArgumentNullException("interfaceType");
			}
			this.CheckContext(new Type[]
			{
				interfaceType
			});
			this.ThrowIfCreated();
			TypeToken typeTokenInternal = this.m_module.GetTypeTokenInternal(interfaceType);
			TypeBuilder.AddInterfaceImpl(this.m_module.GetNativeHandle(), this.m_tdType.Token, typeTokenInternal.Token);
			this.m_typeInterfaces.Add(interfaceType);
		}

		/// <summary>Adds declarative security to this type.</summary>
		/// <param name="action">The security action to be taken such as Demand, Assert, and so on.</param>
		/// <param name="pset">The set of permissions the action applies to.</param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The <paramref name="action" /> is invalid (<see langword="RequestMinimum" />, <see langword="RequestOptional" />, and <see langword="RequestRefuse" /> are invalid).</exception>
		/// <exception cref="T:System.InvalidOperationException">The containing type has been created using <see cref="M:System.Reflection.Emit.TypeBuilder.CreateType" />.  
		///  -or-  
		///  The permission set <paramref name="pset" /> contains an action that was added earlier by <see langword="AddDeclarativeSecurity" />.</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="pset" /> is <see langword="null" />.</exception>
		// Token: 0x06004CC6 RID: 19654 RVA: 0x00116570 File Offset: 0x00114770
		[SecuritySafeCritical]
		public void AddDeclarativeSecurity(SecurityAction action, PermissionSet pset)
		{
			object syncRoot = this.SyncRoot;
			lock (syncRoot)
			{
				this.AddDeclarativeSecurityNoLock(action, pset);
			}
		}

		// Token: 0x06004CC7 RID: 19655 RVA: 0x001165B4 File Offset: 0x001147B4
		[SecurityCritical]
		private void AddDeclarativeSecurityNoLock(SecurityAction action, PermissionSet pset)
		{
			if (pset == null)
			{
				throw new ArgumentNullException("pset");
			}
			if (!Enum.IsDefined(typeof(SecurityAction), action) || action == SecurityAction.RequestMinimum || action == SecurityAction.RequestOptional || action == SecurityAction.RequestRefuse)
			{
				throw new ArgumentOutOfRangeException("action");
			}
			this.ThrowIfCreated();
			byte[] array = null;
			int cb = 0;
			if (!pset.IsEmpty())
			{
				array = pset.EncodeXml();
				cb = array.Length;
			}
			TypeBuilder.AddDeclarativeSecurity(this.m_module.GetNativeHandle(), this.m_tdType.Token, action, array, cb);
		}

		/// <summary>Returns the type token of this type.</summary>
		/// <returns>Read-only. Returns the <see langword="TypeToken" /> of this type.</returns>
		/// <exception cref="T:System.InvalidOperationException">The type was previously created using <see cref="M:System.Reflection.Emit.TypeBuilder.CreateType" />.</exception>
		// Token: 0x17000C1C RID: 3100
		// (get) Token: 0x06004CC8 RID: 19656 RVA: 0x0011663A File Offset: 0x0011483A
		public TypeToken TypeToken
		{
			get
			{
				if (this.IsGenericParameter)
				{
					this.ThrowIfCreated();
				}
				return this.m_tdType;
			}
		}

		/// <summary>Sets a custom attribute using a specified custom attribute blob.</summary>
		/// <param name="con">The constructor for the custom attribute.</param>
		/// <param name="binaryAttribute">A byte blob representing the attributes.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="con" /> or <paramref name="binaryAttribute" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.InvalidOperationException">For the current dynamic type, the <see cref="P:System.Reflection.Emit.TypeBuilder.IsGenericType" /> property is <see langword="true" />, but the <see cref="P:System.Reflection.Emit.TypeBuilder.IsGenericTypeDefinition" /> property is <see langword="false" />.</exception>
		// Token: 0x06004CC9 RID: 19657 RVA: 0x00116650 File Offset: 0x00114850
		[SecuritySafeCritical]
		[ComVisible(true)]
		public void SetCustomAttribute(ConstructorInfo con, byte[] binaryAttribute)
		{
			if (con == null)
			{
				throw new ArgumentNullException("con");
			}
			if (binaryAttribute == null)
			{
				throw new ArgumentNullException("binaryAttribute");
			}
			TypeBuilder.DefineCustomAttribute(this.m_module, this.m_tdType.Token, this.m_module.GetConstructorToken(con).Token, binaryAttribute, false, false);
		}

		/// <summary>Set a custom attribute using a custom attribute builder.</summary>
		/// <param name="customBuilder">An instance of a helper class to define the custom attribute.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="customBuilder" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.InvalidOperationException">For the current dynamic type, the <see cref="P:System.Reflection.Emit.TypeBuilder.IsGenericType" /> property is <see langword="true" />, but the <see cref="P:System.Reflection.Emit.TypeBuilder.IsGenericTypeDefinition" /> property is <see langword="false" />.</exception>
		// Token: 0x06004CCA RID: 19658 RVA: 0x001166AC File Offset: 0x001148AC
		[SecuritySafeCritical]
		public void SetCustomAttribute(CustomAttributeBuilder customBuilder)
		{
			if (customBuilder == null)
			{
				throw new ArgumentNullException("customBuilder");
			}
			customBuilder.CreateCustomAttribute(this.m_module, this.m_tdType.Token);
		}

		/// <summary>Retrieves the number of type information interfaces that an object provides (either 0 or 1).</summary>
		/// <param name="pcTInfo">Points to a location that receives the number of type information interfaces provided by the object.</param>
		/// <exception cref="T:System.NotImplementedException">Late-bound access using the COM IDispatch interface is not supported.</exception>
		// Token: 0x06004CCB RID: 19659 RVA: 0x001166D3 File Offset: 0x001148D3
		void _TypeBuilder.GetTypeInfoCount(out uint pcTInfo)
		{
			throw new NotImplementedException();
		}

		/// <summary>Retrieves the type information for an object, which can then be used to get the type information for an interface.</summary>
		/// <param name="iTInfo">The type information to return.</param>
		/// <param name="lcid">The locale identifier for the type information.</param>
		/// <param name="ppTInfo">Receives a pointer to the requested type information object.</param>
		/// <exception cref="T:System.NotImplementedException">Late-bound access using the COM IDispatch interface is not supported.</exception>
		// Token: 0x06004CCC RID: 19660 RVA: 0x001166DA File Offset: 0x001148DA
		void _TypeBuilder.GetTypeInfo(uint iTInfo, uint lcid, IntPtr ppTInfo)
		{
			throw new NotImplementedException();
		}

		/// <summary>Maps a set of names to a corresponding set of dispatch identifiers.</summary>
		/// <param name="riid">Reserved for future use. Must be IID_NULL.</param>
		/// <param name="rgszNames">Passed-in array of names to be mapped.</param>
		/// <param name="cNames">Count of the names to be mapped.</param>
		/// <param name="lcid">The locale context in which to interpret the names.</param>
		/// <param name="rgDispId">Caller-allocated array which receives the IDs corresponding to the names.</param>
		/// <exception cref="T:System.NotImplementedException">Late-bound access using the COM IDispatch interface is not supported.</exception>
		// Token: 0x06004CCD RID: 19661 RVA: 0x001166E1 File Offset: 0x001148E1
		void _TypeBuilder.GetIDsOfNames([In] ref Guid riid, IntPtr rgszNames, uint cNames, uint lcid, IntPtr rgDispId)
		{
			throw new NotImplementedException();
		}

		/// <summary>Provides access to properties and methods exposed by an object.</summary>
		/// <param name="dispIdMember">Identifies the member.</param>
		/// <param name="riid">Reserved for future use. Must be IID_NULL.</param>
		/// <param name="lcid">The locale context in which to interpret arguments.</param>
		/// <param name="wFlags">Flags describing the context of the call.</param>
		/// <param name="pDispParams">Pointer to a structure containing an array of arguments, an array of argument DISPIDs for named arguments, and counts for the number of elements in the arrays.</param>
		/// <param name="pVarResult">Pointer to the location where the result is to be stored.</param>
		/// <param name="pExcepInfo">Pointer to a structure that contains exception information.</param>
		/// <param name="puArgErr">The index of the first argument that has an error.</param>
		/// <exception cref="T:System.NotImplementedException">Late-bound access using the COM IDispatch interface is not supported.</exception>
		// Token: 0x06004CCE RID: 19662 RVA: 0x001166E8 File Offset: 0x001148E8
		void _TypeBuilder.Invoke(uint dispIdMember, [In] ref Guid riid, uint lcid, short wFlags, IntPtr pDispParams, IntPtr pVarResult, IntPtr pExcepInfo, IntPtr puArgErr)
		{
			throw new NotImplementedException();
		}

		/// <summary>Represents that total size for the type is not specified.</summary>
		// Token: 0x040020F7 RID: 8439
		public const int UnspecifiedTypeSize = 0;

		// Token: 0x040020F8 RID: 8440
		private List<TypeBuilder.CustAttr> m_ca;

		// Token: 0x040020F9 RID: 8441
		private TypeToken m_tdType;

		// Token: 0x040020FA RID: 8442
		private ModuleBuilder m_module;

		// Token: 0x040020FB RID: 8443
		private string m_strName;

		// Token: 0x040020FC RID: 8444
		private string m_strNameSpace;

		// Token: 0x040020FD RID: 8445
		private string m_strFullQualName;

		// Token: 0x040020FE RID: 8446
		private Type m_typeParent;

		// Token: 0x040020FF RID: 8447
		private List<Type> m_typeInterfaces;

		// Token: 0x04002100 RID: 8448
		private TypeAttributes m_iAttr;

		// Token: 0x04002101 RID: 8449
		private GenericParameterAttributes m_genParamAttributes;

		// Token: 0x04002102 RID: 8450
		internal List<MethodBuilder> m_listMethods;

		// Token: 0x04002103 RID: 8451
		internal int m_lastTokenizedMethod;

		// Token: 0x04002104 RID: 8452
		private int m_constructorCount;

		// Token: 0x04002105 RID: 8453
		private int m_iTypeSize;

		// Token: 0x04002106 RID: 8454
		private PackingSize m_iPackingSize;

		// Token: 0x04002107 RID: 8455
		private TypeBuilder m_DeclaringType;

		// Token: 0x04002108 RID: 8456
		private Type m_enumUnderlyingType;

		// Token: 0x04002109 RID: 8457
		internal bool m_isHiddenGlobalType;

		// Token: 0x0400210A RID: 8458
		private bool m_hasBeenCreated;

		// Token: 0x0400210B RID: 8459
		private RuntimeType m_bakedRuntimeType;

		// Token: 0x0400210C RID: 8460
		private int m_genParamPos;

		// Token: 0x0400210D RID: 8461
		private GenericTypeParameterBuilder[] m_inst;

		// Token: 0x0400210E RID: 8462
		private bool m_bIsGenParam;

		// Token: 0x0400210F RID: 8463
		private MethodBuilder m_declMeth;

		// Token: 0x04002110 RID: 8464
		private TypeBuilder m_genTypeDef;

		// Token: 0x02000C0E RID: 3086
		private class CustAttr
		{
			// Token: 0x06006F3E RID: 28478 RVA: 0x0017E652 File Offset: 0x0017C852
			public CustAttr(ConstructorInfo con, byte[] binaryAttribute)
			{
				if (con == null)
				{
					throw new ArgumentNullException("con");
				}
				if (binaryAttribute == null)
				{
					throw new ArgumentNullException("binaryAttribute");
				}
				this.m_con = con;
				this.m_binaryAttribute = binaryAttribute;
			}

			// Token: 0x06006F3F RID: 28479 RVA: 0x0017E68A File Offset: 0x0017C88A
			public CustAttr(CustomAttributeBuilder customBuilder)
			{
				if (customBuilder == null)
				{
					throw new ArgumentNullException("customBuilder");
				}
				this.m_customBuilder = customBuilder;
			}

			// Token: 0x06006F40 RID: 28480 RVA: 0x0017E6A8 File Offset: 0x0017C8A8
			[SecurityCritical]
			public void Bake(ModuleBuilder module, int token)
			{
				if (this.m_customBuilder == null)
				{
					TypeBuilder.DefineCustomAttribute(module, token, module.GetConstructorToken(this.m_con).Token, this.m_binaryAttribute, false, false);
					return;
				}
				this.m_customBuilder.CreateCustomAttribute(module, token);
			}

			// Token: 0x04003675 RID: 13941
			private ConstructorInfo m_con;

			// Token: 0x04003676 RID: 13942
			private byte[] m_binaryAttribute;

			// Token: 0x04003677 RID: 13943
			private CustomAttributeBuilder m_customBuilder;
		}
	}
}
