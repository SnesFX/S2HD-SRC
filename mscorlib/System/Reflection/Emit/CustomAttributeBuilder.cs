﻿using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using System.Text;

namespace System.Reflection.Emit
{
	/// <summary>Helps build custom attributes.</summary>
	// Token: 0x02000620 RID: 1568
	[ClassInterface(ClassInterfaceType.None)]
	[ComDefaultInterface(typeof(_CustomAttributeBuilder))]
	[ComVisible(true)]
	[HostProtection(SecurityAction.LinkDemand, MayLeakOnAbort = true)]
	public class CustomAttributeBuilder : _CustomAttributeBuilder
	{
		/// <summary>Initializes an instance of the <see langword="CustomAttributeBuilder" /> class given the constructor for the custom attribute and the arguments to the constructor.</summary>
		/// <param name="con">The constructor for the custom attribute.</param>
		/// <param name="constructorArgs">The arguments to the constructor of the custom attribute.</param>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="con" /> is static or private.  
		/// -or-  
		/// The number of supplied arguments does not match the number of parameters of the constructor as required by the calling convention of the constructor.  
		/// -or-  
		/// The type of supplied argument does not match the type of the parameter declared in the constructor.  
		/// -or-  
		/// A supplied argument is a reference type other than <see cref="T:System.String" /> or <see cref="T:System.Type" />.</exception>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="con" /> or <paramref name="constructorArgs" /> is <see langword="null" />.</exception>
		// Token: 0x06004ACA RID: 19146 RVA: 0x0010D9FF File Offset: 0x0010BBFF
		public CustomAttributeBuilder(ConstructorInfo con, object[] constructorArgs)
		{
			this.InitCustomAttributeBuilder(con, constructorArgs, new PropertyInfo[0], new object[0], new FieldInfo[0], new object[0]);
		}

		/// <summary>Initializes an instance of the <see langword="CustomAttributeBuilder" /> class given the constructor for the custom attribute, the arguments to the constructor, and a set of named property or value pairs.</summary>
		/// <param name="con">The constructor for the custom attribute.</param>
		/// <param name="constructorArgs">The arguments to the constructor of the custom attribute.</param>
		/// <param name="namedProperties">Named properties of the custom attribute.</param>
		/// <param name="propertyValues">Values for the named properties of the custom attribute.</param>
		/// <exception cref="T:System.ArgumentException">The lengths of the <paramref name="namedProperties" /> and <paramref name="propertyValues" /> arrays are different.  
		///  -or-  
		///  <paramref name="con" /> is static or private.  
		///  -or-  
		///  The number of supplied arguments does not match the number of parameters of the constructor as required by the calling convention of the constructor.  
		///  -or-  
		///  The type of supplied argument does not match the type of the parameter declared in the constructor.  
		///  -or-  
		///  The types of the property values do not match the types of the named properties.  
		///  -or-  
		///  A property has no setter method.  
		///  -or-  
		///  The property does not belong to the same class or base class as the constructor.  
		///  -or-  
		///  A supplied argument or named property is a reference type other than <see cref="T:System.String" /> or <see cref="T:System.Type" />.</exception>
		/// <exception cref="T:System.ArgumentNullException">One of the parameters is <see langword="null" />.</exception>
		// Token: 0x06004ACB RID: 19147 RVA: 0x0010DA27 File Offset: 0x0010BC27
		public CustomAttributeBuilder(ConstructorInfo con, object[] constructorArgs, PropertyInfo[] namedProperties, object[] propertyValues)
		{
			this.InitCustomAttributeBuilder(con, constructorArgs, namedProperties, propertyValues, new FieldInfo[0], new object[0]);
		}

		/// <summary>Initializes an instance of the <see langword="CustomAttributeBuilder" /> class given the constructor for the custom attribute, the arguments to the constructor, and a set of named field/value pairs.</summary>
		/// <param name="con">The constructor for the custom attribute.</param>
		/// <param name="constructorArgs">The arguments to the constructor of the custom attribute.</param>
		/// <param name="namedFields">Named fields of the custom attribute.</param>
		/// <param name="fieldValues">Values for the named fields of the custom attribute.</param>
		/// <exception cref="T:System.ArgumentException">The lengths of the <paramref name="namedFields" /> and <paramref name="fieldValues" /> arrays are different.  
		///  -or-  
		///  <paramref name="con" /> is static or private.  
		///  -or-  
		///  The number of supplied arguments does not match the number of parameters of the constructor as required by the calling convention of the constructor.  
		///  -or-  
		///  The type of supplied argument does not match the type of the parameter declared in the constructor.  
		///  -or-  
		///  The types of the field values do not match the types of the named fields.  
		///  -or-  
		///  The field does not belong to the same class or base class as the constructor.  
		///  -or-  
		///  A supplied argument or named field is a reference type other than <see cref="T:System.String" /> or <see cref="T:System.Type" />.</exception>
		/// <exception cref="T:System.ArgumentNullException">One of the parameters is <see langword="null" />.</exception>
		// Token: 0x06004ACC RID: 19148 RVA: 0x0010DA46 File Offset: 0x0010BC46
		public CustomAttributeBuilder(ConstructorInfo con, object[] constructorArgs, FieldInfo[] namedFields, object[] fieldValues)
		{
			this.InitCustomAttributeBuilder(con, constructorArgs, new PropertyInfo[0], new object[0], namedFields, fieldValues);
		}

		/// <summary>Initializes an instance of the <see langword="CustomAttributeBuilder" /> class given the constructor for the custom attribute, the arguments to the constructor, a set of named property or value pairs, and a set of named field or value pairs.</summary>
		/// <param name="con">The constructor for the custom attribute.</param>
		/// <param name="constructorArgs">The arguments to the constructor of the custom attribute.</param>
		/// <param name="namedProperties">Named properties of the custom attribute.</param>
		/// <param name="propertyValues">Values for the named properties of the custom attribute.</param>
		/// <param name="namedFields">Named fields of the custom attribute.</param>
		/// <param name="fieldValues">Values for the named fields of the custom attribute.</param>
		/// <exception cref="T:System.ArgumentException">The lengths of the <paramref name="namedProperties" /> and <paramref name="propertyValues" /> arrays are different.  
		///  -or-  
		///  The lengths of the <paramref name="namedFields" /> and <paramref name="fieldValues" /> arrays are different.  
		///  -or-  
		///  <paramref name="con" /> is static or private.  
		///  -or-  
		///  The number of supplied arguments does not match the number of parameters of the constructor as required by the calling convention of the constructor.  
		///  -or-  
		///  The type of supplied argument does not match the type of the parameter declared in the constructor.  
		///  -or-  
		///  The types of the property values do not match the types of the named properties.  
		///  -or-  
		///  The types of the field values do not match the types of the corresponding field types.  
		///  -or-  
		///  A property has no setter.  
		///  -or-  
		///  The property or field does not belong to the same class or base class as the constructor.  
		///  -or-  
		///  A supplied argument, named property, or named field is a reference type other than <see cref="T:System.String" /> or <see cref="T:System.Type" />.</exception>
		/// <exception cref="T:System.ArgumentNullException">One of the parameters is <see langword="null" />.</exception>
		// Token: 0x06004ACD RID: 19149 RVA: 0x0010DA65 File Offset: 0x0010BC65
		public CustomAttributeBuilder(ConstructorInfo con, object[] constructorArgs, PropertyInfo[] namedProperties, object[] propertyValues, FieldInfo[] namedFields, object[] fieldValues)
		{
			this.InitCustomAttributeBuilder(con, constructorArgs, namedProperties, propertyValues, namedFields, fieldValues);
		}

		// Token: 0x06004ACE RID: 19150 RVA: 0x0010DA7C File Offset: 0x0010BC7C
		private bool ValidateType(Type t)
		{
			if (t.IsPrimitive || t == typeof(string) || t == typeof(Type))
			{
				return true;
			}
			if (t.IsEnum)
			{
				TypeCode typeCode = Type.GetTypeCode(Enum.GetUnderlyingType(t));
				return typeCode - TypeCode.SByte <= 7;
			}
			if (t.IsArray)
			{
				return t.GetArrayRank() == 1 && this.ValidateType(t.GetElementType());
			}
			return t == typeof(object);
		}

		// Token: 0x06004ACF RID: 19151 RVA: 0x0010DB08 File Offset: 0x0010BD08
		internal void InitCustomAttributeBuilder(ConstructorInfo con, object[] constructorArgs, PropertyInfo[] namedProperties, object[] propertyValues, FieldInfo[] namedFields, object[] fieldValues)
		{
			if (con == null)
			{
				throw new ArgumentNullException("con");
			}
			if (constructorArgs == null)
			{
				throw new ArgumentNullException("constructorArgs");
			}
			if (namedProperties == null)
			{
				throw new ArgumentNullException("namedProperties");
			}
			if (propertyValues == null)
			{
				throw new ArgumentNullException("propertyValues");
			}
			if (namedFields == null)
			{
				throw new ArgumentNullException("namedFields");
			}
			if (fieldValues == null)
			{
				throw new ArgumentNullException("fieldValues");
			}
			if (namedProperties.Length != propertyValues.Length)
			{
				throw new ArgumentException(Environment.GetResourceString("Arg_ArrayLengthsDiffer"), "namedProperties, propertyValues");
			}
			if (namedFields.Length != fieldValues.Length)
			{
				throw new ArgumentException(Environment.GetResourceString("Arg_ArrayLengthsDiffer"), "namedFields, fieldValues");
			}
			if ((con.Attributes & MethodAttributes.Static) == MethodAttributes.Static || (con.Attributes & MethodAttributes.MemberAccessMask) == MethodAttributes.Private)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_BadConstructor"));
			}
			if ((con.CallingConvention & CallingConventions.Standard) != CallingConventions.Standard)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_BadConstructorCallConv"));
			}
			this.m_con = con;
			this.m_constructorArgs = new object[constructorArgs.Length];
			Array.Copy(constructorArgs, this.m_constructorArgs, constructorArgs.Length);
			Type[] parameterTypes = con.GetParameterTypes();
			if (parameterTypes.Length != constructorArgs.Length)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_BadParameterCountsForConstructor"));
			}
			for (int i = 0; i < parameterTypes.Length; i++)
			{
				if (!this.ValidateType(parameterTypes[i]))
				{
					throw new ArgumentException(Environment.GetResourceString("Argument_BadTypeInCustomAttribute"));
				}
			}
			for (int i = 0; i < parameterTypes.Length; i++)
			{
				if (constructorArgs[i] != null)
				{
					TypeCode typeCode = Type.GetTypeCode(parameterTypes[i]);
					if (typeCode != Type.GetTypeCode(constructorArgs[i].GetType()) && (typeCode != TypeCode.Object || !this.ValidateType(constructorArgs[i].GetType())))
					{
						throw new ArgumentException(Environment.GetResourceString("Argument_BadParameterTypeForConstructor", new object[]
						{
							i
						}));
					}
				}
			}
			MemoryStream output = new MemoryStream();
			BinaryWriter binaryWriter = new BinaryWriter(output);
			binaryWriter.Write(1);
			for (int i = 0; i < constructorArgs.Length; i++)
			{
				this.EmitValue(binaryWriter, parameterTypes[i], constructorArgs[i]);
			}
			binaryWriter.Write((ushort)(namedProperties.Length + namedFields.Length));
			for (int i = 0; i < namedProperties.Length; i++)
			{
				if (namedProperties[i] == null)
				{
					throw new ArgumentNullException("namedProperties[" + i + "]");
				}
				Type propertyType = namedProperties[i].PropertyType;
				if (propertyValues[i] == null && propertyType.IsPrimitive)
				{
					throw new ArgumentNullException("propertyValues[" + i + "]");
				}
				if (!this.ValidateType(propertyType))
				{
					throw new ArgumentException(Environment.GetResourceString("Argument_BadTypeInCustomAttribute"));
				}
				if (!namedProperties[i].CanWrite)
				{
					throw new ArgumentException(Environment.GetResourceString("Argument_NotAWritableProperty"));
				}
				if (namedProperties[i].DeclaringType != con.DeclaringType && !(con.DeclaringType is TypeBuilderInstantiation) && !con.DeclaringType.IsSubclassOf(namedProperties[i].DeclaringType) && !TypeBuilder.IsTypeEqual(namedProperties[i].DeclaringType, con.DeclaringType) && (!(namedProperties[i].DeclaringType is TypeBuilder) || !con.DeclaringType.IsSubclassOf(((TypeBuilder)namedProperties[i].DeclaringType).BakedRuntimeType)))
				{
					throw new ArgumentException(Environment.GetResourceString("Argument_BadPropertyForConstructorBuilder"));
				}
				if (propertyValues[i] != null && propertyType != typeof(object) && Type.GetTypeCode(propertyValues[i].GetType()) != Type.GetTypeCode(propertyType))
				{
					throw new ArgumentException(Environment.GetResourceString("Argument_ConstantDoesntMatch"));
				}
				binaryWriter.Write(84);
				this.EmitType(binaryWriter, propertyType);
				this.EmitString(binaryWriter, namedProperties[i].Name);
				this.EmitValue(binaryWriter, propertyType, propertyValues[i]);
			}
			for (int i = 0; i < namedFields.Length; i++)
			{
				if (namedFields[i] == null)
				{
					throw new ArgumentNullException("namedFields[" + i + "]");
				}
				Type fieldType = namedFields[i].FieldType;
				if (fieldValues[i] == null && fieldType.IsPrimitive)
				{
					throw new ArgumentNullException("fieldValues[" + i + "]");
				}
				if (!this.ValidateType(fieldType))
				{
					throw new ArgumentException(Environment.GetResourceString("Argument_BadTypeInCustomAttribute"));
				}
				if (namedFields[i].DeclaringType != con.DeclaringType && !(con.DeclaringType is TypeBuilderInstantiation) && !con.DeclaringType.IsSubclassOf(namedFields[i].DeclaringType) && !TypeBuilder.IsTypeEqual(namedFields[i].DeclaringType, con.DeclaringType) && (!(namedFields[i].DeclaringType is TypeBuilder) || !con.DeclaringType.IsSubclassOf(((TypeBuilder)namedFields[i].DeclaringType).BakedRuntimeType)))
				{
					throw new ArgumentException(Environment.GetResourceString("Argument_BadFieldForConstructorBuilder"));
				}
				if (fieldValues[i] != null && fieldType != typeof(object) && Type.GetTypeCode(fieldValues[i].GetType()) != Type.GetTypeCode(fieldType))
				{
					throw new ArgumentException(Environment.GetResourceString("Argument_ConstantDoesntMatch"));
				}
				binaryWriter.Write(83);
				this.EmitType(binaryWriter, fieldType);
				this.EmitString(binaryWriter, namedFields[i].Name);
				this.EmitValue(binaryWriter, fieldType, fieldValues[i]);
			}
			this.m_blob = ((MemoryStream)binaryWriter.BaseStream).ToArray();
		}

		// Token: 0x06004AD0 RID: 19152 RVA: 0x0010E038 File Offset: 0x0010C238
		private void EmitType(BinaryWriter writer, Type type)
		{
			if (type.IsPrimitive)
			{
				switch (Type.GetTypeCode(type))
				{
				case TypeCode.Boolean:
					writer.Write(2);
					return;
				case TypeCode.Char:
					writer.Write(3);
					return;
				case TypeCode.SByte:
					writer.Write(4);
					return;
				case TypeCode.Byte:
					writer.Write(5);
					return;
				case TypeCode.Int16:
					writer.Write(6);
					return;
				case TypeCode.UInt16:
					writer.Write(7);
					return;
				case TypeCode.Int32:
					writer.Write(8);
					return;
				case TypeCode.UInt32:
					writer.Write(9);
					return;
				case TypeCode.Int64:
					writer.Write(10);
					return;
				case TypeCode.UInt64:
					writer.Write(11);
					return;
				case TypeCode.Single:
					writer.Write(12);
					return;
				case TypeCode.Double:
					writer.Write(13);
					return;
				default:
					return;
				}
			}
			else
			{
				if (type.IsEnum)
				{
					writer.Write(85);
					this.EmitString(writer, type.AssemblyQualifiedName);
					return;
				}
				if (type == typeof(string))
				{
					writer.Write(14);
					return;
				}
				if (type == typeof(Type))
				{
					writer.Write(80);
					return;
				}
				if (type.IsArray)
				{
					writer.Write(29);
					this.EmitType(writer, type.GetElementType());
					return;
				}
				writer.Write(81);
				return;
			}
		}

		// Token: 0x06004AD1 RID: 19153 RVA: 0x0010E170 File Offset: 0x0010C370
		private void EmitString(BinaryWriter writer, string str)
		{
			byte[] bytes = Encoding.UTF8.GetBytes(str);
			uint num = (uint)bytes.Length;
			if (num <= 127U)
			{
				writer.Write((byte)num);
			}
			else if (num <= 16383U)
			{
				writer.Write((byte)(num >> 8 | 128U));
				writer.Write((byte)(num & 255U));
			}
			else
			{
				writer.Write((byte)(num >> 24 | 192U));
				writer.Write((byte)(num >> 16 & 255U));
				writer.Write((byte)(num >> 8 & 255U));
				writer.Write((byte)(num & 255U));
			}
			writer.Write(bytes);
		}

		// Token: 0x06004AD2 RID: 19154 RVA: 0x0010E20C File Offset: 0x0010C40C
		private void EmitValue(BinaryWriter writer, Type type, object value)
		{
			if (type.IsEnum)
			{
				switch (Type.GetTypeCode(Enum.GetUnderlyingType(type)))
				{
				case TypeCode.SByte:
					writer.Write((sbyte)value);
					return;
				case TypeCode.Byte:
					writer.Write((byte)value);
					return;
				case TypeCode.Int16:
					writer.Write((short)value);
					return;
				case TypeCode.UInt16:
					writer.Write((ushort)value);
					return;
				case TypeCode.Int32:
					writer.Write((int)value);
					return;
				case TypeCode.UInt32:
					writer.Write((uint)value);
					return;
				case TypeCode.Int64:
					writer.Write((long)value);
					return;
				case TypeCode.UInt64:
					writer.Write((ulong)value);
					return;
				default:
					return;
				}
			}
			else if (type == typeof(string))
			{
				if (value == null)
				{
					writer.Write(byte.MaxValue);
					return;
				}
				this.EmitString(writer, (string)value);
				return;
			}
			else if (type == typeof(Type))
			{
				if (value == null)
				{
					writer.Write(byte.MaxValue);
					return;
				}
				string text = TypeNameBuilder.ToString((Type)value, TypeNameBuilder.Format.AssemblyQualifiedName);
				if (text == null)
				{
					throw new ArgumentException(Environment.GetResourceString("Argument_InvalidTypeForCA", new object[]
					{
						value.GetType()
					}));
				}
				this.EmitString(writer, text);
				return;
			}
			else if (type.IsArray)
			{
				if (value == null)
				{
					writer.Write(uint.MaxValue);
					return;
				}
				Array array = (Array)value;
				Type elementType = type.GetElementType();
				writer.Write(array.Length);
				for (int i = 0; i < array.Length; i++)
				{
					this.EmitValue(writer, elementType, array.GetValue(i));
				}
				return;
			}
			else if (type.IsPrimitive)
			{
				switch (Type.GetTypeCode(type))
				{
				case TypeCode.Boolean:
					writer.Write(((bool)value) ? 1 : 0);
					return;
				case TypeCode.Char:
					writer.Write(Convert.ToUInt16((char)value));
					return;
				case TypeCode.SByte:
					writer.Write((sbyte)value);
					return;
				case TypeCode.Byte:
					writer.Write((byte)value);
					return;
				case TypeCode.Int16:
					writer.Write((short)value);
					return;
				case TypeCode.UInt16:
					writer.Write((ushort)value);
					return;
				case TypeCode.Int32:
					writer.Write((int)value);
					return;
				case TypeCode.UInt32:
					writer.Write((uint)value);
					return;
				case TypeCode.Int64:
					writer.Write((long)value);
					return;
				case TypeCode.UInt64:
					writer.Write((ulong)value);
					return;
				case TypeCode.Single:
					writer.Write((float)value);
					return;
				case TypeCode.Double:
					writer.Write((double)value);
					return;
				default:
					return;
				}
			}
			else
			{
				if (!(type == typeof(object)))
				{
					string text2 = "null";
					if (value != null)
					{
						text2 = value.GetType().ToString();
					}
					throw new ArgumentException(Environment.GetResourceString("Argument_BadParameterTypeForCAB", new object[]
					{
						text2
					}));
				}
				Type type2 = (value == null) ? typeof(string) : ((value is Type) ? typeof(Type) : value.GetType());
				if (type2 == typeof(object))
				{
					throw new ArgumentException(Environment.GetResourceString("Argument_BadParameterTypeForCAB", new object[]
					{
						type2.ToString()
					}));
				}
				this.EmitType(writer, type2);
				this.EmitValue(writer, type2, value);
				return;
			}
		}

		// Token: 0x06004AD3 RID: 19155 RVA: 0x0010E544 File Offset: 0x0010C744
		[SecurityCritical]
		internal void CreateCustomAttribute(ModuleBuilder mod, int tkOwner)
		{
			this.CreateCustomAttribute(mod, tkOwner, mod.GetConstructorToken(this.m_con).Token, false);
		}

		// Token: 0x06004AD4 RID: 19156 RVA: 0x0010E570 File Offset: 0x0010C770
		[SecurityCritical]
		internal int PrepareCreateCustomAttributeToDisk(ModuleBuilder mod)
		{
			return mod.InternalGetConstructorToken(this.m_con, true).Token;
		}

		// Token: 0x06004AD5 RID: 19157 RVA: 0x0010E592 File Offset: 0x0010C792
		[SecurityCritical]
		internal void CreateCustomAttribute(ModuleBuilder mod, int tkOwner, int tkAttrib, bool toDisk)
		{
			TypeBuilder.DefineCustomAttribute(mod, tkOwner, tkAttrib, this.m_blob, toDisk, typeof(DebuggableAttribute) == this.m_con.DeclaringType);
		}

		/// <summary>Retrieves the number of type information interfaces that an object provides (either 0 or 1).</summary>
		/// <param name="pcTInfo">Points to a location that receives the number of type information interfaces provided by the object.</param>
		/// <exception cref="T:System.NotImplementedException">The method is called late-bound using the COM IDispatch interface.</exception>
		// Token: 0x06004AD6 RID: 19158 RVA: 0x0010E5BE File Offset: 0x0010C7BE
		void _CustomAttributeBuilder.GetTypeInfoCount(out uint pcTInfo)
		{
			throw new NotImplementedException();
		}

		/// <summary>Retrieves the type information for an object, which can then be used to get the type information for an interface.</summary>
		/// <param name="iTInfo">The type information to return.</param>
		/// <param name="lcid">The locale identifier for the type information.</param>
		/// <param name="ppTInfo">Receives a pointer to the requested type information object.</param>
		/// <exception cref="T:System.NotImplementedException">The method is called late-bound using the COM IDispatch interface.</exception>
		// Token: 0x06004AD7 RID: 19159 RVA: 0x0010E5C5 File Offset: 0x0010C7C5
		void _CustomAttributeBuilder.GetTypeInfo(uint iTInfo, uint lcid, IntPtr ppTInfo)
		{
			throw new NotImplementedException();
		}

		/// <summary>Maps a set of names to a corresponding set of dispatch identifiers.</summary>
		/// <param name="riid">Reserved for future use. Must be IID_NULL.</param>
		/// <param name="rgszNames">Passed-in array of names to be mapped.</param>
		/// <param name="cNames">Count of the names to be mapped.</param>
		/// <param name="lcid">The locale context in which to interpret the names.</param>
		/// <param name="rgDispId">Caller-allocated array which receives the IDs corresponding to the names.</param>
		/// <exception cref="T:System.NotImplementedException">The method is called late-bound using the COM IDispatch interface.</exception>
		// Token: 0x06004AD8 RID: 19160 RVA: 0x0010E5CC File Offset: 0x0010C7CC
		void _CustomAttributeBuilder.GetIDsOfNames([In] ref Guid riid, IntPtr rgszNames, uint cNames, uint lcid, IntPtr rgDispId)
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
		/// <exception cref="T:System.NotImplementedException">The method is called late-bound using the COM IDispatch interface.</exception>
		// Token: 0x06004AD9 RID: 19161 RVA: 0x0010E5D3 File Offset: 0x0010C7D3
		void _CustomAttributeBuilder.Invoke(uint dispIdMember, [In] ref Guid riid, uint lcid, short wFlags, IntPtr pDispParams, IntPtr pVarResult, IntPtr pExcepInfo, IntPtr puArgErr)
		{
			throw new NotImplementedException();
		}

		// Token: 0x04001E93 RID: 7827
		internal ConstructorInfo m_con;

		// Token: 0x04001E94 RID: 7828
		internal object[] m_constructorArgs;

		// Token: 0x04001E95 RID: 7829
		internal byte[] m_blob;
	}
}
