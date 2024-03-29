﻿using System;
using System.Runtime.InteropServices;

namespace System.Reflection.Emit
{
	/// <summary>The <see langword="FieldToken" /> struct is an object representation of a token that represents a field.</summary>
	// Token: 0x0200060F RID: 1551
	[ComVisible(true)]
	[Serializable]
	public struct FieldToken
	{
		// Token: 0x06004973 RID: 18803 RVA: 0x00108F05 File Offset: 0x00107105
		internal FieldToken(int field, Type fieldClass)
		{
			this.m_fieldTok = field;
			this.m_class = fieldClass;
		}

		/// <summary>Retrieves the metadata token for this field.</summary>
		/// <returns>Read-only. Retrieves the metadata token of this field.</returns>
		// Token: 0x17000B92 RID: 2962
		// (get) Token: 0x06004974 RID: 18804 RVA: 0x00108F15 File Offset: 0x00107115
		public int Token
		{
			get
			{
				return this.m_fieldTok;
			}
		}

		/// <summary>Generates the hash code for this field.</summary>
		/// <returns>The hash code for this instance.</returns>
		// Token: 0x06004975 RID: 18805 RVA: 0x00108F1D File Offset: 0x0010711D
		public override int GetHashCode()
		{
			return this.m_fieldTok;
		}

		/// <summary>Determines if an object is an instance of <see langword="FieldToken" /> and is equal to this instance.</summary>
		/// <param name="obj">The object to compare to this <see langword="FieldToken" />.</param>
		/// <returns>
		///   <see langword="true" /> if <paramref name="obj" /> is an instance of <see langword="FieldToken" /> and is equal to this object; otherwise, <see langword="false" />.</returns>
		// Token: 0x06004976 RID: 18806 RVA: 0x00108F25 File Offset: 0x00107125
		public override bool Equals(object obj)
		{
			return obj is FieldToken && this.Equals((FieldToken)obj);
		}

		/// <summary>Indicates whether the current instance is equal to the specified <see cref="T:System.Reflection.Emit.FieldToken" />.</summary>
		/// <param name="obj">The <see cref="T:System.Reflection.Emit.FieldToken" /> to compare to the current instance.</param>
		/// <returns>
		///   <see langword="true" /> if the value of <paramref name="obj" /> is equal to the value of the current instance; otherwise, <see langword="false" />.</returns>
		// Token: 0x06004977 RID: 18807 RVA: 0x00108F3D File Offset: 0x0010713D
		public bool Equals(FieldToken obj)
		{
			return obj.m_fieldTok == this.m_fieldTok && obj.m_class == this.m_class;
		}

		/// <summary>Indicates whether two <see cref="T:System.Reflection.Emit.FieldToken" /> structures are equal.</summary>
		/// <param name="a">The <see cref="T:System.Reflection.Emit.FieldToken" /> to compare to <paramref name="b" />.</param>
		/// <param name="b">The <see cref="T:System.Reflection.Emit.FieldToken" /> to compare to <paramref name="a" />.</param>
		/// <returns>
		///   <see langword="true" /> if <paramref name="a" /> is equal to <paramref name="b" />; otherwise, <see langword="false" />.</returns>
		// Token: 0x06004978 RID: 18808 RVA: 0x00108F5D File Offset: 0x0010715D
		public static bool operator ==(FieldToken a, FieldToken b)
		{
			return a.Equals(b);
		}

		/// <summary>Indicates whether two <see cref="T:System.Reflection.Emit.FieldToken" /> structures are not equal.</summary>
		/// <param name="a">The <see cref="T:System.Reflection.Emit.FieldToken" /> to compare to <paramref name="b" />.</param>
		/// <param name="b">The <see cref="T:System.Reflection.Emit.FieldToken" /> to compare to <paramref name="a" />.</param>
		/// <returns>
		///   <see langword="true" /> if <paramref name="a" /> is not equal to <paramref name="b" />; otherwise, <see langword="false" />.</returns>
		// Token: 0x06004979 RID: 18809 RVA: 0x00108F67 File Offset: 0x00107167
		public static bool operator !=(FieldToken a, FieldToken b)
		{
			return !(a == b);
		}

		/// <summary>The default FieldToken with <see cref="P:System.Reflection.Emit.FieldToken.Token" /> value 0.</summary>
		// Token: 0x04001E00 RID: 7680
		public static readonly FieldToken Empty;

		// Token: 0x04001E01 RID: 7681
		internal int m_fieldTok;

		// Token: 0x04001E02 RID: 7682
		internal object m_class;
	}
}
