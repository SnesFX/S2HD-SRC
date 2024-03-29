﻿using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security;

namespace System.Text
{
	/// <summary>Represents a UTF-8 encoding of Unicode characters.</summary>
	// Token: 0x02000A55 RID: 2645
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public class UTF8Encoding : Encoding
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Text.UTF8Encoding" /> class.</summary>
		// Token: 0x060067F8 RID: 26616 RVA: 0x00161B26 File Offset: 0x0015FD26
		[__DynamicallyInvokable]
		public UTF8Encoding() : this(false)
		{
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Text.UTF8Encoding" /> class. A parameter specifies whether to provide a Unicode byte order mark.</summary>
		/// <param name="encoderShouldEmitUTF8Identifier">
		///   <see langword="true" /> to specify that the <see cref="M:System.Text.UTF8Encoding.GetPreamble" /> method returns a Unicode byte order mark; otherwise, <see langword="false" />.</param>
		// Token: 0x060067F9 RID: 26617 RVA: 0x00161B2F File Offset: 0x0015FD2F
		[__DynamicallyInvokable]
		public UTF8Encoding(bool encoderShouldEmitUTF8Identifier) : this(encoderShouldEmitUTF8Identifier, false)
		{
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Text.UTF8Encoding" /> class. Parameters specify whether to provide a Unicode byte order mark and whether to throw an exception when an invalid encoding is detected.</summary>
		/// <param name="encoderShouldEmitUTF8Identifier">
		///   <see langword="true" /> to specify that the <see cref="M:System.Text.UTF8Encoding.GetPreamble" /> method should return a Unicode byte order mark; otherwise, <see langword="false" />.</param>
		/// <param name="throwOnInvalidBytes">
		///   <see langword="true" /> to throw an exception when an invalid encoding is detected; otherwise, <see langword="false" />.</param>
		// Token: 0x060067FA RID: 26618 RVA: 0x00161B39 File Offset: 0x0015FD39
		[__DynamicallyInvokable]
		public UTF8Encoding(bool encoderShouldEmitUTF8Identifier, bool throwOnInvalidBytes) : base(65001)
		{
			this.emitUTF8Identifier = encoderShouldEmitUTF8Identifier;
			this.isThrowException = throwOnInvalidBytes;
			if (this.isThrowException)
			{
				this.SetDefaultFallbacks();
			}
		}

		// Token: 0x060067FB RID: 26619 RVA: 0x00161B64 File Offset: 0x0015FD64
		internal override void SetDefaultFallbacks()
		{
			if (this.isThrowException)
			{
				this.encoderFallback = EncoderFallback.ExceptionFallback;
				this.decoderFallback = DecoderFallback.ExceptionFallback;
				return;
			}
			this.encoderFallback = new EncoderReplacementFallback("�");
			this.decoderFallback = new DecoderReplacementFallback("�");
		}

		/// <summary>Calculates the number of bytes produced by encoding a set of characters from the specified character array.</summary>
		/// <param name="chars">The character array containing the set of characters to encode.</param>
		/// <param name="index">The index of the first character to encode.</param>
		/// <param name="count">The number of characters to encode.</param>
		/// <returns>The number of bytes produced by encoding the specified characters.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="chars" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="index" /> or <paramref name="count" /> is less than zero.  
		/// -or-  
		/// <paramref name="index" /> and <paramref name="count" /> do not denote a valid range in <paramref name="chars" />.  
		/// -or-  
		/// The resulting number of bytes is greater than the maximum number that can be returned as an integer.</exception>
		/// <exception cref="T:System.ArgumentException">Error detection is enabled, and <paramref name="chars" /> contains an invalid sequence of characters.</exception>
		/// <exception cref="T:System.Text.EncoderFallbackException">A fallback occurred (see Character Encoding in the .NET Framework for complete explanation)  
		///  -and-  
		///  The <see cref="P:System.Text.Encoding.EncoderFallback" /> property is set to <see cref="T:System.Text.EncoderExceptionFallback" />.</exception>
		// Token: 0x060067FC RID: 26620 RVA: 0x00161BB0 File Offset: 0x0015FDB0
		[SecuritySafeCritical]
		[__DynamicallyInvokable]
		public unsafe override int GetByteCount(char[] chars, int index, int count)
		{
			if (chars == null)
			{
				throw new ArgumentNullException("chars", Environment.GetResourceString("ArgumentNull_Array"));
			}
			if (index < 0 || count < 0)
			{
				throw new ArgumentOutOfRangeException((index < 0) ? "index" : "count", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
			}
			if (chars.Length - index < count)
			{
				throw new ArgumentOutOfRangeException("chars", Environment.GetResourceString("ArgumentOutOfRange_IndexCountBuffer"));
			}
			if (chars.Length == 0)
			{
				return 0;
			}
			fixed (char* ptr = chars)
			{
				return this.GetByteCount(ptr + index, count, null);
			}
		}

		/// <summary>Calculates the number of bytes produced by encoding the characters in the specified <see cref="T:System.String" />.</summary>
		/// <param name="chars">The <see cref="T:System.String" /> containing the set of characters to encode.</param>
		/// <returns>The number of bytes produced by encoding the specified characters.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="chars" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The resulting number of bytes is greater than the maximum number that can be returned as an integer.</exception>
		/// <exception cref="T:System.ArgumentException">Error detection is enabled, and <paramref name="chars" /> contains an invalid sequence of characters.</exception>
		/// <exception cref="T:System.Text.EncoderFallbackException">A fallback occurred (see Character Encoding in the .NET Framework for complete explanation)  
		///  -and-  
		///  <see cref="P:System.Text.Encoding.EncoderFallback" /> is set to <see cref="T:System.Text.EncoderExceptionFallback" />.</exception>
		// Token: 0x060067FD RID: 26621 RVA: 0x00161C48 File Offset: 0x0015FE48
		[SecuritySafeCritical]
		[__DynamicallyInvokable]
		public unsafe override int GetByteCount(string chars)
		{
			if (chars == null)
			{
				throw new ArgumentNullException("s");
			}
			char* ptr = chars;
			if (ptr != null)
			{
				ptr += RuntimeHelpers.OffsetToStringData / 2;
			}
			return this.GetByteCount(ptr, chars.Length, null);
		}

		/// <summary>Calculates the number of bytes produced by encoding a set of characters starting at the specified character pointer.</summary>
		/// <param name="chars">A pointer to the first character to encode.</param>
		/// <param name="count">The number of characters to encode.</param>
		/// <returns>The number of bytes produced by encoding the specified characters.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="chars" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="count" /> is less than zero.  
		/// -or-  
		/// The resulting number of bytes is greater than the maximum number that can be returned as an integer.</exception>
		/// <exception cref="T:System.ArgumentException">Error detection is enabled, and <paramref name="chars" /> contains an invalid sequence of characters.</exception>
		/// <exception cref="T:System.Text.EncoderFallbackException">A fallback occurred (see Character Encoding in the .NET Framework for a complete explanation)  
		///  -and-  
		///  <see cref="P:System.Text.Encoding.EncoderFallback" /> is set to <see cref="T:System.Text.EncoderExceptionFallback" />.</exception>
		// Token: 0x060067FE RID: 26622 RVA: 0x00161C81 File Offset: 0x0015FE81
		[SecurityCritical]
		[CLSCompliant(false)]
		[ComVisible(false)]
		public unsafe override int GetByteCount(char* chars, int count)
		{
			if (chars == null)
			{
				throw new ArgumentNullException("chars", Environment.GetResourceString("ArgumentNull_Array"));
			}
			if (count < 0)
			{
				throw new ArgumentOutOfRangeException("count", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
			}
			return this.GetByteCount(chars, count, null);
		}

		/// <summary>Encodes a set of characters from the specified <see cref="T:System.String" /> into the specified byte array.</summary>
		/// <param name="s">The <see cref="T:System.String" /> containing the set of characters to encode.</param>
		/// <param name="charIndex">The index of the first character to encode.</param>
		/// <param name="charCount">The number of characters to encode.</param>
		/// <param name="bytes">The byte array to contain the resulting sequence of bytes.</param>
		/// <param name="byteIndex">The index at which to start writing the resulting sequence of bytes.</param>
		/// <returns>The actual number of bytes written into <paramref name="bytes" />.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="s" /> is <see langword="null" />.  
		/// -or-  
		/// <paramref name="bytes" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="charIndex" /> or <paramref name="charCount" /> or <paramref name="byteIndex" /> is less than zero.  
		/// -or-  
		/// <paramref name="charIndex" /> and <paramref name="charCount" /> do not denote a valid range in <paramref name="chars" />.  
		/// -or-  
		/// <paramref name="byteIndex" /> is not a valid index in <paramref name="bytes" />.</exception>
		/// <exception cref="T:System.ArgumentException">Error detection is enabled, and <paramref name="s" /> contains an invalid sequence of characters.  
		///  -or-  
		///  <paramref name="bytes" /> does not have enough capacity from <paramref name="byteIndex" /> to the end of the array to accommodate the resulting bytes.</exception>
		/// <exception cref="T:System.Text.EncoderFallbackException">A fallback occurred (see Character Encoding in the .NET Framework for complete explanation)  
		///  -and-  
		///  <see cref="P:System.Text.Encoding.EncoderFallback" /> is set to <see cref="T:System.Text.EncoderExceptionFallback" />.</exception>
		// Token: 0x060067FF RID: 26623 RVA: 0x00161CC0 File Offset: 0x0015FEC0
		[SecuritySafeCritical]
		[__DynamicallyInvokable]
		public unsafe override int GetBytes(string s, int charIndex, int charCount, byte[] bytes, int byteIndex)
		{
			if (s == null || bytes == null)
			{
				throw new ArgumentNullException((s == null) ? "s" : "bytes", Environment.GetResourceString("ArgumentNull_Array"));
			}
			if (charIndex < 0 || charCount < 0)
			{
				throw new ArgumentOutOfRangeException((charIndex < 0) ? "charIndex" : "charCount", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
			}
			if (s.Length - charIndex < charCount)
			{
				throw new ArgumentOutOfRangeException("s", Environment.GetResourceString("ArgumentOutOfRange_IndexCount"));
			}
			if (byteIndex < 0 || byteIndex > bytes.Length)
			{
				throw new ArgumentOutOfRangeException("byteIndex", Environment.GetResourceString("ArgumentOutOfRange_Index"));
			}
			int byteCount = bytes.Length - byteIndex;
			if (bytes.Length == 0)
			{
				bytes = new byte[1];
			}
			char* ptr = s;
			if (ptr != null)
			{
				ptr += RuntimeHelpers.OffsetToStringData / 2;
			}
			fixed (byte* ptr2 = bytes)
			{
				return this.GetBytes(ptr + charIndex, charCount, ptr2 + byteIndex, byteCount, null);
			}
		}

		/// <summary>Encodes a set of characters from the specified character array into the specified byte array.</summary>
		/// <param name="chars">The character array containing the set of characters to encode.</param>
		/// <param name="charIndex">The index of the first character to encode.</param>
		/// <param name="charCount">The number of characters to encode.</param>
		/// <param name="bytes">The byte array to contain the resulting sequence of bytes.</param>
		/// <param name="byteIndex">The index at which to start writing the resulting sequence of bytes.</param>
		/// <returns>The actual number of bytes written into <paramref name="bytes" />.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="chars" /> is <see langword="null" />.  
		/// -or-  
		/// <paramref name="bytes" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="charIndex" /> or <paramref name="charCount" /> or <paramref name="byteIndex" /> is less than zero.  
		/// -or-  
		/// <paramref name="charIndex" /> and <paramref name="charCount" /> do not denote a valid range in <paramref name="chars" />.  
		/// -or-  
		/// <paramref name="byteIndex" /> is not a valid index in <paramref name="bytes" />.</exception>
		/// <exception cref="T:System.ArgumentException">Error detection is enabled, and <paramref name="chars" /> contains an invalid sequence of characters.  
		///  -or-  
		///  <paramref name="bytes" /> does not have enough capacity from <paramref name="byteIndex" /> to the end of the array to accommodate the resulting bytes.</exception>
		/// <exception cref="T:System.Text.EncoderFallbackException">A fallback occurred (see Character Encoding in the .NET Framework for complete explanation)  
		///  -and-  
		///  <see cref="P:System.Text.Encoding.EncoderFallback" /> is set to <see cref="T:System.Text.EncoderExceptionFallback" />.</exception>
		// Token: 0x06006800 RID: 26624 RVA: 0x00161DB4 File Offset: 0x0015FFB4
		[SecuritySafeCritical]
		[__DynamicallyInvokable]
		public unsafe override int GetBytes(char[] chars, int charIndex, int charCount, byte[] bytes, int byteIndex)
		{
			if (chars == null || bytes == null)
			{
				throw new ArgumentNullException((chars == null) ? "chars" : "bytes", Environment.GetResourceString("ArgumentNull_Array"));
			}
			if (charIndex < 0 || charCount < 0)
			{
				throw new ArgumentOutOfRangeException((charIndex < 0) ? "charIndex" : "charCount", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
			}
			if (chars.Length - charIndex < charCount)
			{
				throw new ArgumentOutOfRangeException("chars", Environment.GetResourceString("ArgumentOutOfRange_IndexCountBuffer"));
			}
			if (byteIndex < 0 || byteIndex > bytes.Length)
			{
				throw new ArgumentOutOfRangeException("byteIndex", Environment.GetResourceString("ArgumentOutOfRange_Index"));
			}
			if (chars.Length == 0)
			{
				return 0;
			}
			int byteCount = bytes.Length - byteIndex;
			if (bytes.Length == 0)
			{
				bytes = new byte[1];
			}
			fixed (char* ptr = chars)
			{
				fixed (byte* ptr2 = bytes)
				{
					return this.GetBytes(ptr + charIndex, charCount, ptr2 + byteIndex, byteCount, null);
				}
			}
		}

		/// <summary>Encodes a set of characters starting at the specified character pointer into a sequence of bytes that are stored starting at the specified byte pointer.</summary>
		/// <param name="chars">A pointer to the first character to encode.</param>
		/// <param name="charCount">The number of characters to encode.</param>
		/// <param name="bytes">A pointer to the location at which to start writing the resulting sequence of bytes.</param>
		/// <param name="byteCount">The maximum number of bytes to write.</param>
		/// <returns>The actual number of bytes written at the location indicated by <paramref name="bytes" />.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="chars" /> is <see langword="null" />.  
		/// -or-  
		/// <paramref name="bytes" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="charCount" /> or <paramref name="byteCount" /> is less than zero.</exception>
		/// <exception cref="T:System.ArgumentException">Error detection is enabled, and <paramref name="chars" /> contains an invalid sequence of characters.  
		///  -or-  
		///  <paramref name="byteCount" /> is less than the resulting number of bytes.</exception>
		/// <exception cref="T:System.Text.EncoderFallbackException">A fallback occurred (see Character Encoding in the .NET Framework for complete explanation)  
		///  -and-  
		///  <see cref="P:System.Text.Encoding.EncoderFallback" /> is set to <see cref="T:System.Text.EncoderExceptionFallback" />.</exception>
		// Token: 0x06006801 RID: 26625 RVA: 0x00161EB0 File Offset: 0x001600B0
		[SecurityCritical]
		[CLSCompliant(false)]
		[ComVisible(false)]
		public unsafe override int GetBytes(char* chars, int charCount, byte* bytes, int byteCount)
		{
			if (bytes == null || chars == null)
			{
				throw new ArgumentNullException((bytes == null) ? "bytes" : "chars", Environment.GetResourceString("ArgumentNull_Array"));
			}
			if (charCount < 0 || byteCount < 0)
			{
				throw new ArgumentOutOfRangeException((charCount < 0) ? "charCount" : "byteCount", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
			}
			return this.GetBytes(chars, charCount, bytes, byteCount, null);
		}

		/// <summary>Calculates the number of characters produced by decoding a sequence of bytes from the specified byte array.</summary>
		/// <param name="bytes">The byte array containing the sequence of bytes to decode.</param>
		/// <param name="index">The index of the first byte to decode.</param>
		/// <param name="count">The number of bytes to decode.</param>
		/// <returns>The number of characters produced by decoding the specified sequence of bytes.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="bytes" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="index" /> or <paramref name="count" /> is less than zero.  
		/// -or-  
		/// <paramref name="index" /> and <paramref name="count" /> do not denote a valid range in <paramref name="bytes" />.  
		/// -or-  
		/// The resulting number of bytes is greater than the maximum number that can be returned as an integer.</exception>
		/// <exception cref="T:System.ArgumentException">Error detection is enabled, and <paramref name="bytes" /> contains an invalid sequence of bytes.</exception>
		/// <exception cref="T:System.Text.DecoderFallbackException">A fallback occurred (see Character Encoding in the .NET Framework for complete explanation)  
		///  -and-  
		///  <see cref="P:System.Text.Encoding.DecoderFallback" /> is set to <see cref="T:System.Text.DecoderExceptionFallback" />.</exception>
		// Token: 0x06006802 RID: 26626 RVA: 0x00161F20 File Offset: 0x00160120
		[SecuritySafeCritical]
		[__DynamicallyInvokable]
		public unsafe override int GetCharCount(byte[] bytes, int index, int count)
		{
			if (bytes == null)
			{
				throw new ArgumentNullException("bytes", Environment.GetResourceString("ArgumentNull_Array"));
			}
			if (index < 0 || count < 0)
			{
				throw new ArgumentOutOfRangeException((index < 0) ? "index" : "count", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
			}
			if (bytes.Length - index < count)
			{
				throw new ArgumentOutOfRangeException("bytes", Environment.GetResourceString("ArgumentOutOfRange_IndexCountBuffer"));
			}
			if (bytes.Length == 0)
			{
				return 0;
			}
			fixed (byte* ptr = bytes)
			{
				return this.GetCharCount(ptr + index, count, null);
			}
		}

		/// <summary>Calculates the number of characters produced by decoding a sequence of bytes starting at the specified byte pointer.</summary>
		/// <param name="bytes">A pointer to the first byte to decode.</param>
		/// <param name="count">The number of bytes to decode.</param>
		/// <returns>The number of characters produced by decoding the specified sequence of bytes.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="bytes" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="count" /> is less than zero.  
		/// -or-  
		/// The resulting number of bytes is greater than the maximum number that can be returned as an integer.</exception>
		/// <exception cref="T:System.ArgumentException">Error detection is enabled, and <paramref name="bytes" /> contains an invalid sequence of bytes.</exception>
		/// <exception cref="T:System.Text.DecoderFallbackException">A fallback occurred (see Character Encoding in the .NET Framework for complete explanation)  
		///  -and-  
		///  <see cref="P:System.Text.Encoding.DecoderFallback" /> is set to <see cref="T:System.Text.DecoderExceptionFallback" />.</exception>
		// Token: 0x06006803 RID: 26627 RVA: 0x00161FB3 File Offset: 0x001601B3
		[SecurityCritical]
		[CLSCompliant(false)]
		[ComVisible(false)]
		public unsafe override int GetCharCount(byte* bytes, int count)
		{
			if (bytes == null)
			{
				throw new ArgumentNullException("bytes", Environment.GetResourceString("ArgumentNull_Array"));
			}
			if (count < 0)
			{
				throw new ArgumentOutOfRangeException("count", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
			}
			return this.GetCharCount(bytes, count, null);
		}

		/// <summary>Decodes a sequence of bytes from the specified byte array into the specified character array.</summary>
		/// <param name="bytes">The byte array containing the sequence of bytes to decode.</param>
		/// <param name="byteIndex">The index of the first byte to decode.</param>
		/// <param name="byteCount">The number of bytes to decode.</param>
		/// <param name="chars">The character array to contain the resulting set of characters.</param>
		/// <param name="charIndex">The index at which to start writing the resulting set of characters.</param>
		/// <returns>The actual number of characters written into <paramref name="chars" />.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="bytes" /> is <see langword="null" />.  
		/// -or-  
		/// <paramref name="chars" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="byteIndex" /> or <paramref name="byteCount" /> or <paramref name="charIndex" /> is less than zero.  
		/// -or-  
		/// <paramref name="byteindex" /> and <paramref name="byteCount" /> do not denote a valid range in <paramref name="bytes" />.  
		/// -or-  
		/// <paramref name="charIndex" /> is not a valid index in <paramref name="chars" />.</exception>
		/// <exception cref="T:System.ArgumentException">Error detection is enabled, and <paramref name="bytes" /> contains an invalid sequence of bytes.  
		///  -or-  
		///  <paramref name="chars" /> does not have enough capacity from <paramref name="charIndex" /> to the end of the array to accommodate the resulting characters.</exception>
		/// <exception cref="T:System.Text.DecoderFallbackException">A fallback occurred (see Character Encoding in the .NET Framework for complete explanation)  
		///  -and-  
		///  <see cref="P:System.Text.Encoding.DecoderFallback" /> is set to <see cref="T:System.Text.DecoderExceptionFallback" />.</exception>
		// Token: 0x06006804 RID: 26628 RVA: 0x00161FF4 File Offset: 0x001601F4
		[SecuritySafeCritical]
		[__DynamicallyInvokable]
		public unsafe override int GetChars(byte[] bytes, int byteIndex, int byteCount, char[] chars, int charIndex)
		{
			if (bytes == null || chars == null)
			{
				throw new ArgumentNullException((bytes == null) ? "bytes" : "chars", Environment.GetResourceString("ArgumentNull_Array"));
			}
			if (byteIndex < 0 || byteCount < 0)
			{
				throw new ArgumentOutOfRangeException((byteIndex < 0) ? "byteIndex" : "byteCount", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
			}
			if (bytes.Length - byteIndex < byteCount)
			{
				throw new ArgumentOutOfRangeException("bytes", Environment.GetResourceString("ArgumentOutOfRange_IndexCountBuffer"));
			}
			if (charIndex < 0 || charIndex > chars.Length)
			{
				throw new ArgumentOutOfRangeException("charIndex", Environment.GetResourceString("ArgumentOutOfRange_Index"));
			}
			if (bytes.Length == 0)
			{
				return 0;
			}
			int charCount = chars.Length - charIndex;
			if (chars.Length == 0)
			{
				chars = new char[1];
			}
			fixed (byte* ptr = bytes)
			{
				fixed (char* ptr2 = chars)
				{
					return this.GetChars(ptr + byteIndex, byteCount, ptr2 + charIndex, charCount, null);
				}
			}
		}

		/// <summary>Decodes a sequence of bytes starting at the specified byte pointer into a set of characters that are stored starting at the specified character pointer.</summary>
		/// <param name="bytes">A pointer to the first byte to decode.</param>
		/// <param name="byteCount">The number of bytes to decode.</param>
		/// <param name="chars">A pointer to the location at which to start writing the resulting set of characters.</param>
		/// <param name="charCount">The maximum number of characters to write.</param>
		/// <returns>The actual number of characters written at the location indicated by <paramref name="chars" />.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="bytes" /> is <see langword="null" />.  
		/// -or-  
		/// <paramref name="chars" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="byteCount" /> or <paramref name="charCount" /> is less than zero.</exception>
		/// <exception cref="T:System.ArgumentException">Error detection is enabled, and <paramref name="bytes" /> contains an invalid sequence of bytes.  
		///  -or-  
		///  <paramref name="charCount" /> is less than the resulting number of characters.</exception>
		/// <exception cref="T:System.Text.DecoderFallbackException">A fallback occurred (see Character Encoding in the .NET Framework for complete explanation)  
		///  -and-  
		///  <see cref="P:System.Text.Encoding.DecoderFallback" /> is set to <see cref="T:System.Text.DecoderExceptionFallback" />.</exception>
		// Token: 0x06006805 RID: 26629 RVA: 0x001620F0 File Offset: 0x001602F0
		[SecurityCritical]
		[CLSCompliant(false)]
		[ComVisible(false)]
		public unsafe override int GetChars(byte* bytes, int byteCount, char* chars, int charCount)
		{
			if (bytes == null || chars == null)
			{
				throw new ArgumentNullException((bytes == null) ? "bytes" : "chars", Environment.GetResourceString("ArgumentNull_Array"));
			}
			if (charCount < 0 || byteCount < 0)
			{
				throw new ArgumentOutOfRangeException((charCount < 0) ? "charCount" : "byteCount", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
			}
			return this.GetChars(bytes, byteCount, chars, charCount, null);
		}

		/// <summary>Decodes a range of bytes from a byte array into a string.</summary>
		/// <param name="bytes">The byte array containing the sequence of bytes to decode.</param>
		/// <param name="index">The index of the first byte to decode.</param>
		/// <param name="count">The number of bytes to decode.</param>
		/// <returns>A <see cref="T:System.String" /> containing the results of decoding the specified sequence of bytes.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="bytes" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="index" /> or <paramref name="count" /> is less than zero.  
		/// -or-  
		/// <paramref name="index" /> and <paramref name="count" /> do not denote a valid range in <paramref name="bytes" />.</exception>
		/// <exception cref="T:System.ArgumentException">Error detection is enabled, and <paramref name="bytes" /> contains an invalid sequence of bytes.</exception>
		/// <exception cref="T:System.Text.DecoderFallbackException">A fallback occurred (see Character Encoding in the .NET Framework for complete explanation)  
		///  -and-  
		///  <see cref="P:System.Text.Encoding.DecoderFallback" /> is set to <see cref="T:System.Text.DecoderExceptionFallback" />.</exception>
		// Token: 0x06006806 RID: 26630 RVA: 0x00162160 File Offset: 0x00160360
		[SecuritySafeCritical]
		[ComVisible(false)]
		[__DynamicallyInvokable]
		public unsafe override string GetString(byte[] bytes, int index, int count)
		{
			if (bytes == null)
			{
				throw new ArgumentNullException("bytes", Environment.GetResourceString("ArgumentNull_Array"));
			}
			if (index < 0 || count < 0)
			{
				throw new ArgumentOutOfRangeException((index < 0) ? "index" : "count", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
			}
			if (bytes.Length - index < count)
			{
				throw new ArgumentOutOfRangeException("bytes", Environment.GetResourceString("ArgumentOutOfRange_IndexCountBuffer"));
			}
			if (bytes.Length == 0)
			{
				return string.Empty;
			}
			fixed (byte* ptr = bytes)
			{
				return string.CreateStringFromEncoding(ptr + index, count, this);
			}
		}

		// Token: 0x06006807 RID: 26631 RVA: 0x001621F8 File Offset: 0x001603F8
		[SecurityCritical]
		internal unsafe override int GetByteCount(char* chars, int count, EncoderNLS baseEncoder)
		{
			EncoderFallbackBuffer encoderFallbackBuffer = null;
			char* ptr = chars;
			char* ptr2 = ptr + count;
			int num = count;
			int num2 = 0;
			if (baseEncoder != null)
			{
				UTF8Encoding.UTF8Encoder utf8Encoder = (UTF8Encoding.UTF8Encoder)baseEncoder;
				num2 = utf8Encoder.surrogateChar;
				if (utf8Encoder.InternalHasFallbackBuffer)
				{
					encoderFallbackBuffer = utf8Encoder.FallbackBuffer;
					if (encoderFallbackBuffer.Remaining > 0)
					{
						throw new ArgumentException(Environment.GetResourceString("Argument_EncoderFallbackNotEmpty", new object[]
						{
							this.EncodingName,
							utf8Encoder.Fallback.GetType()
						}));
					}
					encoderFallbackBuffer.InternalInitialize(chars, ptr2, utf8Encoder, false);
				}
			}
			for (;;)
			{
				if (ptr >= ptr2)
				{
					if (num2 == 0)
					{
						num2 = (int)((encoderFallbackBuffer != null) ? encoderFallbackBuffer.InternalGetNextChar() : '\0');
						if (num2 > 0)
						{
							num++;
							goto IL_14D;
						}
					}
					else if (encoderFallbackBuffer != null && encoderFallbackBuffer.bFallingBack)
					{
						num2 = (int)encoderFallbackBuffer.InternalGetNextChar();
						num++;
						if (UTF8Encoding.InRange(num2, 56320, 57343))
						{
							num2 = 65533;
							num++;
							goto IL_169;
						}
						if (num2 <= 0)
						{
							break;
						}
						goto IL_14D;
					}
					if (num2 > 0 && (baseEncoder == null || baseEncoder.MustFlush))
					{
						num++;
						goto IL_169;
					}
					goto IL_3F8;
				}
				else if (num2 > 0)
				{
					int ch = (int)(*ptr);
					num++;
					if (UTF8Encoding.InRange(ch, 56320, 57343))
					{
						num2 = 65533;
						ptr++;
						goto IL_169;
					}
					goto IL_169;
				}
				else
				{
					if (encoderFallbackBuffer != null)
					{
						num2 = (int)encoderFallbackBuffer.InternalGetNextChar();
						if (num2 > 0)
						{
							num++;
							goto IL_14D;
						}
					}
					num2 = (int)(*ptr);
					ptr++;
				}
				IL_14D:
				if (UTF8Encoding.InRange(num2, 55296, 56319))
				{
					num--;
					continue;
				}
				IL_169:
				if (UTF8Encoding.InRange(num2, 55296, 57343))
				{
					if (encoderFallbackBuffer == null)
					{
						if (baseEncoder == null)
						{
							encoderFallbackBuffer = this.encoderFallback.CreateFallbackBuffer();
						}
						else
						{
							encoderFallbackBuffer = baseEncoder.FallbackBuffer;
						}
						encoderFallbackBuffer.InternalInitialize(chars, chars + count, baseEncoder, false);
					}
					encoderFallbackBuffer.InternalFallback((char)num2, ref ptr);
					num--;
					num2 = 0;
				}
				else
				{
					if (num2 > 127)
					{
						if (num2 > 2047)
						{
							num++;
						}
						num++;
					}
					if (num < 0)
					{
						goto IL_3F8;
					}
					if (encoderFallbackBuffer != null && (num2 = (int)encoderFallbackBuffer.InternalGetNextChar()) != 0)
					{
						num++;
						goto IL_14D;
					}
					int num3 = UTF8Encoding.PtrDiff(ptr2, ptr);
					if (num3 <= 13)
					{
						char* ptr3 = ptr2;
						while (ptr < ptr3)
						{
							num2 = (int)(*ptr);
							ptr++;
							if (num2 > 127)
							{
								goto IL_14D;
							}
						}
						goto Block_28;
					}
					num3 &= 268435455;
					char* ptr4 = ptr + num3 - 7;
					IL_3E8:
					while (ptr < ptr4)
					{
						num2 = (int)(*ptr);
						ptr++;
						if (num2 > 127)
						{
							if (num2 > 2047)
							{
								if ((num2 & 63488) == 55296)
								{
									goto IL_39A;
								}
								num++;
							}
							num++;
						}
						if ((ptr & 2) != 0)
						{
							num2 = (int)(*ptr);
							ptr++;
							if (num2 > 127)
							{
								if (num2 > 2047)
								{
									if ((num2 & 63488) == 55296)
									{
										goto IL_39A;
									}
									num++;
								}
								num++;
							}
						}
						while (ptr < ptr4)
						{
							num2 = *(int*)ptr;
							int num4 = *(int*)(ptr + 2);
							if (((num2 | num4) & -8323200) != 0)
							{
								if (((num2 | num4) & -134154240) != 0)
								{
									goto IL_38B;
								}
								if ((num2 & -8388608) != 0)
								{
									num++;
								}
								if ((num2 & 65408) != 0)
								{
									num++;
								}
								if ((num4 & -8388608) != 0)
								{
									num++;
								}
								if ((num4 & 65408) != 0)
								{
									num++;
								}
							}
							ptr += 4;
							num2 = *(int*)ptr;
							num4 = *(int*)(ptr + 2);
							if (((num2 | num4) & -8323200) != 0)
							{
								if (((num2 | num4) & -134154240) != 0)
								{
									goto IL_38B;
								}
								if ((num2 & -8388608) != 0)
								{
									num++;
								}
								if ((num2 & 65408) != 0)
								{
									num++;
								}
								if ((num4 & -8388608) != 0)
								{
									num++;
								}
								if ((num4 & 65408) != 0)
								{
									num++;
								}
							}
							ptr += 4;
							continue;
							IL_38B:
							num2 = (int)((ushort)num2);
							ptr++;
							if (num2 > 127)
							{
								goto IL_39A;
							}
							goto IL_3E8;
						}
						break;
						IL_39A:
						if (num2 > 2047)
						{
							if (UTF8Encoding.InRange(num2, 55296, 57343))
							{
								int ch2 = (int)(*ptr);
								if (num2 > 56319 || !UTF8Encoding.InRange(ch2, 56320, 57343))
								{
									ptr--;
									break;
								}
								ptr++;
							}
							num++;
						}
						num++;
					}
					num2 = 0;
				}
			}
			num--;
			Block_28:
			IL_3F8:
			if (num < 0)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_ConversionOverflow"));
			}
			return num;
		}

		// Token: 0x06006808 RID: 26632 RVA: 0x00162612 File Offset: 0x00160812
		[SecurityCritical]
		private unsafe static int PtrDiff(char* a, char* b)
		{
			return (int)((uint)((long)((a - b) / 1 * 2)) >> 1);
		}

		// Token: 0x06006809 RID: 26633 RVA: 0x0016261D File Offset: 0x0016081D
		[SecurityCritical]
		private unsafe static int PtrDiff(byte* a, byte* b)
		{
			return (int)((long)(a - b));
		}

		// Token: 0x0600680A RID: 26634 RVA: 0x00162626 File Offset: 0x00160826
		private static bool InRange(int ch, int start, int end)
		{
			return ch - start <= end - start;
		}

		// Token: 0x0600680B RID: 26635 RVA: 0x00162634 File Offset: 0x00160834
		[SecurityCritical]
		internal unsafe override int GetBytes(char* chars, int charCount, byte* bytes, int byteCount, EncoderNLS baseEncoder)
		{
			UTF8Encoding.UTF8Encoder utf8Encoder = null;
			EncoderFallbackBuffer encoderFallbackBuffer = null;
			char* ptr = chars;
			byte* ptr2 = bytes;
			char* ptr3 = ptr + charCount;
			byte* ptr4 = ptr2 + byteCount;
			int num = 0;
			if (baseEncoder != null)
			{
				utf8Encoder = (UTF8Encoding.UTF8Encoder)baseEncoder;
				num = utf8Encoder.surrogateChar;
				if (utf8Encoder.InternalHasFallbackBuffer)
				{
					encoderFallbackBuffer = utf8Encoder.FallbackBuffer;
					if (encoderFallbackBuffer.Remaining > 0 && utf8Encoder.m_throwOnOverflow)
					{
						throw new ArgumentException(Environment.GetResourceString("Argument_EncoderFallbackNotEmpty", new object[]
						{
							this.EncodingName,
							utf8Encoder.Fallback.GetType()
						}));
					}
					encoderFallbackBuffer.InternalInitialize(chars, ptr3, utf8Encoder, true);
				}
			}
			for (;;)
			{
				if (ptr >= ptr3)
				{
					if (num == 0)
					{
						num = (int)((encoderFallbackBuffer != null) ? encoderFallbackBuffer.InternalGetNextChar() : '\0');
						if (num > 0)
						{
							goto IL_151;
						}
					}
					else if (encoderFallbackBuffer != null && encoderFallbackBuffer.bFallingBack)
					{
						int num2 = num;
						num = (int)encoderFallbackBuffer.InternalGetNextChar();
						if (UTF8Encoding.InRange(num, 56320, 57343))
						{
							num = num + (num2 << 10) + -56613888;
							goto IL_167;
						}
						if (num > 0)
						{
							goto IL_151;
						}
						goto IL_4BE;
					}
					if (num <= 0)
					{
						goto IL_4BE;
					}
					if (utf8Encoder == null)
					{
						goto IL_167;
					}
					if (utf8Encoder.MustFlush)
					{
						goto IL_167;
					}
					goto IL_4BE;
				}
				else if (num > 0)
				{
					int num3 = (int)(*ptr);
					if (UTF8Encoding.InRange(num3, 56320, 57343))
					{
						num = num3 + (num << 10) + -56613888;
						ptr++;
						goto IL_167;
					}
					goto IL_167;
				}
				else
				{
					if (encoderFallbackBuffer != null)
					{
						num = (int)encoderFallbackBuffer.InternalGetNextChar();
						if (num > 0)
						{
							goto IL_151;
						}
					}
					num = (int)(*ptr);
					ptr++;
				}
				IL_151:
				if (UTF8Encoding.InRange(num, 55296, 56319))
				{
					continue;
				}
				IL_167:
				if (UTF8Encoding.InRange(num, 55296, 57343))
				{
					if (encoderFallbackBuffer == null)
					{
						if (baseEncoder == null)
						{
							encoderFallbackBuffer = this.encoderFallback.CreateFallbackBuffer();
						}
						else
						{
							encoderFallbackBuffer = baseEncoder.FallbackBuffer;
						}
						encoderFallbackBuffer.InternalInitialize(chars, ptr3, baseEncoder, true);
					}
					encoderFallbackBuffer.InternalFallback((char)num, ref ptr);
					num = 0;
				}
				else
				{
					int num4 = 1;
					if (num > 127)
					{
						if (num > 2047)
						{
							if (num > 65535)
							{
								num4++;
							}
							num4++;
						}
						num4++;
					}
					if (ptr2 != ptr4 - num4)
					{
						break;
					}
					if (num <= 127)
					{
						*ptr2 = (byte)num;
					}
					else
					{
						int num5;
						if (num <= 2047)
						{
							num5 = (int)((byte)(-64 | num >> 6));
						}
						else
						{
							if (num <= 65535)
							{
								num5 = (int)((byte)(-32 | num >> 12));
							}
							else
							{
								*ptr2 = (byte)(-16 | num >> 18);
								ptr2++;
								num5 = (-128 | (num >> 12 & 63));
							}
							*ptr2 = (byte)num5;
							ptr2++;
							num5 = (-128 | (num >> 6 & 63));
						}
						*ptr2 = (byte)num5;
						ptr2++;
						*ptr2 = (byte)(-128 | (num & 63));
					}
					ptr2++;
					if (encoderFallbackBuffer != null && (num = (int)encoderFallbackBuffer.InternalGetNextChar()) != 0)
					{
						goto IL_151;
					}
					int num6 = UTF8Encoding.PtrDiff(ptr3, ptr);
					int num7 = UTF8Encoding.PtrDiff(ptr4, ptr2);
					if (num6 <= 13)
					{
						if (num7 >= num6)
						{
							char* ptr5 = ptr3;
							while (ptr < ptr5)
							{
								num = (int)(*ptr);
								ptr++;
								if (num > 127)
								{
									goto IL_151;
								}
								*ptr2 = (byte)num;
								ptr2++;
							}
							goto Block_37;
						}
						num = 0;
					}
					else
					{
						if (num7 < num6)
						{
							num6 = num7;
						}
						char* ptr6 = ptr + num6 - 5;
						while (ptr < ptr6)
						{
							num = (int)(*ptr);
							ptr++;
							if (num <= 127)
							{
								*ptr2 = (byte)num;
								ptr2++;
								if ((ptr & 2) != 0)
								{
									num = (int)(*ptr);
									ptr++;
									if (num > 127)
									{
										goto IL_3DD;
									}
									*ptr2 = (byte)num;
									ptr2++;
								}
								while (ptr < ptr6)
								{
									num = *(int*)ptr;
									int num8 = *(int*)(ptr + 2);
									if (((num | num8) & -8323200) == 0)
									{
										*ptr2 = (byte)num;
										ptr2[1] = (byte)(num >> 16);
										ptr += 4;
										ptr2[2] = (byte)num8;
										ptr2[3] = (byte)(num8 >> 16);
										ptr2 += 4;
									}
									else
									{
										num = (int)((ushort)num);
										ptr++;
										if (num <= 127)
										{
											*ptr2 = (byte)num;
											ptr2++;
											break;
										}
										goto IL_3DD;
									}
								}
								continue;
							}
							IL_3DD:
							int num9;
							if (num <= 2047)
							{
								num9 = (-64 | num >> 6);
							}
							else
							{
								if (!UTF8Encoding.InRange(num, 55296, 57343))
								{
									num9 = (-32 | num >> 12);
								}
								else
								{
									if (num > 56319)
									{
										ptr--;
										break;
									}
									num9 = (int)(*ptr);
									ptr++;
									if (!UTF8Encoding.InRange(num9, 56320, 57343))
									{
										ptr -= 2;
										break;
									}
									num = num9 + (num << 10) + -56613888;
									*ptr2 = (byte)(-16 | num >> 18);
									ptr2++;
									num9 = (-128 | (num >> 12 & 63));
								}
								*ptr2 = (byte)num9;
								ptr6--;
								ptr2++;
								num9 = (-128 | (num >> 6 & 63));
							}
							*ptr2 = (byte)num9;
							ptr6--;
							ptr2++;
							*ptr2 = (byte)(-128 | (num & 63));
							ptr2++;
						}
						num = 0;
					}
				}
			}
			if (encoderFallbackBuffer != null && encoderFallbackBuffer.bFallingBack)
			{
				encoderFallbackBuffer.MovePrevious();
				if (num > 65535)
				{
					encoderFallbackBuffer.MovePrevious();
				}
			}
			else
			{
				ptr--;
				if (num > 65535)
				{
					ptr--;
				}
			}
			base.ThrowBytesOverflow(utf8Encoder, ptr2 == bytes);
			num = 0;
			goto IL_4BE;
			Block_37:
			num = 0;
			IL_4BE:
			if (utf8Encoder != null)
			{
				utf8Encoder.surrogateChar = num;
				utf8Encoder.m_charsUsed = (int)((long)(ptr - chars));
			}
			return (int)((long)(ptr2 - bytes));
		}

		// Token: 0x0600680C RID: 26636 RVA: 0x00162B20 File Offset: 0x00160D20
		[SecurityCritical]
		internal unsafe override int GetCharCount(byte* bytes, int count, DecoderNLS baseDecoder)
		{
			byte* ptr = bytes;
			byte* ptr2 = ptr + count;
			int num = count;
			int num2 = 0;
			DecoderFallbackBuffer decoderFallbackBuffer = null;
			if (baseDecoder != null)
			{
				UTF8Encoding.UTF8Decoder utf8Decoder = (UTF8Encoding.UTF8Decoder)baseDecoder;
				num2 = utf8Decoder.bits;
				num -= num2 >> 30;
			}
			IL_27:
			while (ptr < ptr2)
			{
				if (num2 == 0)
				{
					num2 = (int)(*ptr);
					ptr++;
					goto IL_10A;
				}
				int num3 = (int)(*ptr);
				ptr++;
				if ((num3 & -64) != 128)
				{
					ptr--;
					num += num2 >> 30;
				}
				else
				{
					num2 = (num2 << 6 | (num3 & 63));
					if ((num2 & 536870912) == 0)
					{
						if ((num2 & 268435456) != 0)
						{
							if ((num2 & 8388608) != 0 || UTF8Encoding.InRange(num2 & 496, 16, 256))
							{
								continue;
							}
						}
						else if ((num2 & 992) != 0)
						{
							if ((num2 & 992) != 864)
							{
								continue;
							}
						}
					}
					else
					{
						if ((num2 & 270467072) == 268435456)
						{
							num--;
							goto IL_180;
						}
						goto IL_180;
					}
				}
				IL_C7:
				if (decoderFallbackBuffer == null)
				{
					if (baseDecoder == null)
					{
						decoderFallbackBuffer = this.decoderFallback.CreateFallbackBuffer();
					}
					else
					{
						decoderFallbackBuffer = baseDecoder.FallbackBuffer;
					}
					decoderFallbackBuffer.InternalInitialize(bytes, null);
				}
				num += this.FallbackInvalidByteSequence(ptr, num2, decoderFallbackBuffer);
				num2 = 0;
				continue;
				IL_180:
				int num4 = UTF8Encoding.PtrDiff(ptr2, ptr);
				if (num4 <= 13)
				{
					byte* ptr3 = ptr2;
					while (ptr < ptr3)
					{
						num2 = (int)(*ptr);
						ptr++;
						if (num2 > 127)
						{
							goto IL_10A;
						}
					}
					num2 = 0;
					break;
				}
				byte* ptr4 = ptr + num4 - 7;
				while (ptr < ptr4)
				{
					num2 = (int)(*ptr);
					ptr++;
					if (num2 <= 127)
					{
						if ((ptr & 1) != 0)
						{
							num2 = (int)(*ptr);
							ptr++;
							if (num2 > 127)
							{
								goto IL_24D;
							}
						}
						if ((ptr & 2) != 0)
						{
							num2 = (int)(*(ushort*)ptr);
							if ((num2 & 32896) != 0)
							{
								goto IL_239;
							}
							ptr += 2;
						}
						while (ptr < ptr4)
						{
							num2 = *(int*)ptr;
							int num5 = *(int*)(ptr + 4);
							if (((num2 | num5) & -2139062144) != 0)
							{
								goto IL_239;
							}
							ptr += 8;
							if (ptr >= ptr4)
							{
								break;
							}
							num2 = *(int*)ptr;
							num5 = *(int*)(ptr + 4);
							if (((num2 | num5) & -2139062144) != 0)
							{
								goto IL_239;
							}
							ptr += 8;
						}
						break;
						IL_239:
						num2 &= 255;
						ptr++;
						if (num2 <= 127)
						{
							continue;
						}
					}
					IL_24D:
					int num6 = (int)(*ptr);
					ptr++;
					if ((num2 & 64) != 0 && (num6 & -64) == 128)
					{
						num6 &= 63;
						if ((num2 & 32) != 0)
						{
							num6 |= (num2 & 15) << 6;
							if ((num2 & 16) != 0)
							{
								num2 = (int)(*ptr);
								if (!UTF8Encoding.InRange(num6 >> 4, 1, 16) || (num2 & -64) != 128)
								{
									goto IL_319;
								}
								num6 = (num6 << 6 | (num2 & 63));
								num2 = (int)ptr[1];
								if ((num2 & -64) != 128)
								{
									goto IL_319;
								}
								ptr += 2;
								num--;
							}
							else
							{
								num2 = (int)(*ptr);
								if ((num6 & 992) == 0 || (num6 & 992) == 864 || (num2 & -64) != 128)
								{
									goto IL_319;
								}
								ptr++;
								num--;
							}
						}
						else if ((num2 & 30) == 0)
						{
							goto IL_319;
						}
						num--;
						continue;
					}
					IL_319:
					ptr -= 2;
					num2 = 0;
					goto IL_27;
				}
				num2 = 0;
				continue;
				IL_10A:
				if (num2 <= 127)
				{
					goto IL_180;
				}
				num--;
				if ((num2 & 64) == 0)
				{
					goto IL_C7;
				}
				if ((num2 & 32) != 0)
				{
					if ((num2 & 16) != 0)
					{
						num2 &= 15;
						if (num2 > 4)
						{
							num2 |= 240;
							goto IL_C7;
						}
						num2 |= 1347226624;
						num--;
					}
					else
					{
						num2 = ((num2 & 15) | 1210220544);
						num--;
					}
				}
				else
				{
					num2 &= 31;
					if (num2 <= 1)
					{
						num2 |= 192;
						goto IL_C7;
					}
					num2 |= 8388608;
				}
			}
			if (num2 != 0)
			{
				num += num2 >> 30;
				if (baseDecoder == null || baseDecoder.MustFlush)
				{
					if (decoderFallbackBuffer == null)
					{
						if (baseDecoder == null)
						{
							decoderFallbackBuffer = this.decoderFallback.CreateFallbackBuffer();
						}
						else
						{
							decoderFallbackBuffer = baseDecoder.FallbackBuffer;
						}
						decoderFallbackBuffer.InternalInitialize(bytes, null);
					}
					num += this.FallbackInvalidByteSequence(ptr, num2, decoderFallbackBuffer);
				}
			}
			return num;
		}

		// Token: 0x0600680D RID: 26637 RVA: 0x00162E9C File Offset: 0x0016109C
		[SecurityCritical]
		internal unsafe override int GetChars(byte* bytes, int byteCount, char* chars, int charCount, DecoderNLS baseDecoder)
		{
			byte* ptr = bytes;
			char* ptr2 = chars;
			byte* ptr3 = ptr + byteCount;
			char* ptr4 = ptr2 + charCount;
			int num = 0;
			DecoderFallbackBuffer decoderFallbackBuffer = null;
			if (baseDecoder != null)
			{
				UTF8Encoding.UTF8Decoder utf8Decoder = (UTF8Encoding.UTF8Decoder)baseDecoder;
				num = utf8Decoder.bits;
			}
			IL_2C:
			while (ptr < ptr3)
			{
				if (num == 0)
				{
					num = (int)(*ptr);
					ptr++;
					goto IL_161;
				}
				int num2 = (int)(*ptr);
				ptr++;
				if ((num2 & -64) != 128)
				{
					ptr--;
				}
				else
				{
					num = (num << 6 | (num2 & 63));
					if ((num & 536870912) == 0)
					{
						if ((num & 268435456) != 0)
						{
							if ((num & 8388608) != 0 || UTF8Encoding.InRange(num & 496, 16, 256))
							{
								continue;
							}
						}
						else if ((num & 992) != 0)
						{
							if ((num & 992) != 864)
							{
								continue;
							}
						}
					}
					else
					{
						if ((num & 270467072) > 268435456 && ptr2 < ptr4)
						{
							*ptr2 = (char)((num >> 10 & 2047) + -10304);
							ptr2++;
							num = (num & 1023) + 56320;
							goto IL_1E2;
						}
						goto IL_1E2;
					}
				}
				IL_FD:
				if (decoderFallbackBuffer == null)
				{
					if (baseDecoder == null)
					{
						decoderFallbackBuffer = this.decoderFallback.CreateFallbackBuffer();
					}
					else
					{
						decoderFallbackBuffer = baseDecoder.FallbackBuffer;
					}
					decoderFallbackBuffer.InternalInitialize(bytes, ptr4);
				}
				if (!this.FallbackInvalidByteSequence(ref ptr, num, decoderFallbackBuffer, ref ptr2))
				{
					decoderFallbackBuffer.InternalReset();
					base.ThrowCharsOverflow(baseDecoder, ptr2 == chars);
					num = 0;
					break;
				}
				num = 0;
				continue;
				IL_1E2:
				if (ptr2 >= ptr4)
				{
					num &= 2097151;
					if (num > 127)
					{
						if (num > 2047)
						{
							if (num >= 56320 && num <= 57343)
							{
								ptr--;
								ptr2--;
							}
							else if (num > 65535)
							{
								ptr--;
							}
							ptr--;
						}
						ptr--;
					}
					ptr--;
					base.ThrowCharsOverflow(baseDecoder, ptr2 == chars);
					num = 0;
					break;
				}
				*ptr2 = (char)num;
				ptr2++;
				int num3 = UTF8Encoding.PtrDiff(ptr4, ptr2);
				int num4 = UTF8Encoding.PtrDiff(ptr3, ptr);
				if (num4 > 13)
				{
					if (num3 < num4)
					{
						num4 = num3;
					}
					char* ptr5 = ptr2 + num4 - 7;
					while (ptr2 < ptr5)
					{
						num = (int)(*ptr);
						ptr++;
						if (num <= 127)
						{
							*ptr2 = (char)num;
							ptr2++;
							if ((ptr & 1) != 0)
							{
								num = (int)(*ptr);
								ptr++;
								if (num > 127)
								{
									goto IL_3FC;
								}
								*ptr2 = (char)num;
								ptr2++;
							}
							if ((ptr & 2) != 0)
							{
								num = (int)(*(ushort*)ptr);
								if ((num & 32896) != 0)
								{
									goto IL_3DA;
								}
								*ptr2 = (char)(num & 127);
								ptr += 2;
								ptr2[1] = (char)(num >> 8 & 127);
								ptr2 += 2;
							}
							while (ptr2 < ptr5)
							{
								num = *(int*)ptr;
								int num5 = *(int*)(ptr + 4);
								if (((num | num5) & -2139062144) != 0)
								{
									goto IL_3DA;
								}
								*ptr2 = (char)(num & 127);
								ptr2[1] = (char)(num >> 8 & 127);
								ptr2[2] = (char)(num >> 16 & 127);
								ptr2[3] = (char)(num >> 24 & 127);
								ptr += 8;
								ptr2[4] = (char)(num5 & 127);
								ptr2[5] = (char)(num5 >> 8 & 127);
								ptr2[6] = (char)(num5 >> 16 & 127);
								ptr2[7] = (char)(num5 >> 24 & 127);
								ptr2 += 8;
							}
							break;
							IL_3DA:
							num &= 255;
							ptr++;
							if (num <= 127)
							{
								*ptr2 = (char)num;
								ptr2++;
								continue;
							}
						}
						IL_3FC:
						int num6 = (int)(*ptr);
						ptr++;
						if ((num & 64) != 0 && (num6 & -64) == 128)
						{
							num6 &= 63;
							if ((num & 32) != 0)
							{
								num6 |= (num & 15) << 6;
								if ((num & 16) != 0)
								{
									num = (int)(*ptr);
									if (!UTF8Encoding.InRange(num6 >> 4, 1, 16) || (num & -64) != 128)
									{
										goto IL_53E;
									}
									num6 = (num6 << 6 | (num & 63));
									num = (int)ptr[1];
									if ((num & -64) != 128)
									{
										goto IL_53E;
									}
									ptr += 2;
									num = (num6 << 6 | (num & 63));
									*ptr2 = (char)((num >> 10 & 2047) + -10304);
									ptr2++;
									num = (num & 1023) + -9216;
									ptr5--;
								}
								else
								{
									num = (int)(*ptr);
									if ((num6 & 992) == 0 || (num6 & 992) == 864 || (num & -64) != 128)
									{
										goto IL_53E;
									}
									ptr++;
									num = (num6 << 6 | (num & 63));
									ptr5--;
								}
							}
							else
							{
								num &= 31;
								if (num <= 1)
								{
									goto IL_53E;
								}
								num = (num << 6 | num6);
							}
							*ptr2 = (char)num;
							ptr2++;
							ptr5--;
							continue;
						}
						IL_53E:
						ptr -= 2;
						num = 0;
						goto IL_2C;
					}
					num = 0;
					continue;
				}
				if (num3 < num4)
				{
					num = 0;
					continue;
				}
				byte* ptr6 = ptr3;
				while (ptr < ptr6)
				{
					num = (int)(*ptr);
					ptr++;
					if (num > 127)
					{
						goto IL_161;
					}
					*ptr2 = (char)num;
					ptr2++;
				}
				num = 0;
				break;
				IL_161:
				if (num <= 127)
				{
					goto IL_1E2;
				}
				if ((num & 64) == 0)
				{
					goto IL_FD;
				}
				if ((num & 32) != 0)
				{
					if ((num & 16) != 0)
					{
						num &= 15;
						if (num > 4)
						{
							num |= 240;
							goto IL_FD;
						}
						num |= 1347226624;
					}
					else
					{
						num = ((num & 15) | 1210220544);
					}
				}
				else
				{
					num &= 31;
					if (num <= 1)
					{
						num |= 192;
						goto IL_FD;
					}
					num |= 8388608;
				}
			}
			if (num != 0 && (baseDecoder == null || baseDecoder.MustFlush))
			{
				if (decoderFallbackBuffer == null)
				{
					if (baseDecoder == null)
					{
						decoderFallbackBuffer = this.decoderFallback.CreateFallbackBuffer();
					}
					else
					{
						decoderFallbackBuffer = baseDecoder.FallbackBuffer;
					}
					decoderFallbackBuffer.InternalInitialize(bytes, ptr4);
				}
				if (!this.FallbackInvalidByteSequence(ref ptr, num, decoderFallbackBuffer, ref ptr2))
				{
					decoderFallbackBuffer.InternalReset();
					base.ThrowCharsOverflow(baseDecoder, ptr2 == chars);
				}
				num = 0;
			}
			if (baseDecoder != null)
			{
				UTF8Encoding.UTF8Decoder utf8Decoder2 = (UTF8Encoding.UTF8Decoder)baseDecoder;
				utf8Decoder2.bits = num;
				baseDecoder.m_bytesUsed = (int)((long)(ptr - bytes));
			}
			return UTF8Encoding.PtrDiff(ptr2, chars);
		}

		// Token: 0x0600680E RID: 26638 RVA: 0x00163480 File Offset: 0x00161680
		[SecurityCritical]
		private unsafe bool FallbackInvalidByteSequence(ref byte* pSrc, int ch, DecoderFallbackBuffer fallback, ref char* pTarget)
		{
			byte* ptr = pSrc;
			byte[] bytesUnknown = this.GetBytesUnknown(ref ptr, ch);
			if (!fallback.InternalFallback(bytesUnknown, pSrc, ref pTarget))
			{
				pSrc = ptr;
				return false;
			}
			return true;
		}

		// Token: 0x0600680F RID: 26639 RVA: 0x001634B0 File Offset: 0x001616B0
		[SecurityCritical]
		private unsafe int FallbackInvalidByteSequence(byte* pSrc, int ch, DecoderFallbackBuffer fallback)
		{
			byte[] bytesUnknown = this.GetBytesUnknown(ref pSrc, ch);
			return fallback.InternalFallback(bytesUnknown, pSrc);
		}

		// Token: 0x06006810 RID: 26640 RVA: 0x001634D4 File Offset: 0x001616D4
		[SecurityCritical]
		private unsafe byte[] GetBytesUnknown(ref byte* pSrc, int ch)
		{
			byte[] result;
			if (ch < 256 && ch >= 0)
			{
				pSrc--;
				result = new byte[]
				{
					(byte)ch
				};
			}
			else if ((ch & 402653184) == 0)
			{
				pSrc--;
				result = new byte[]
				{
					(byte)((ch & 31) | 192)
				};
			}
			else if ((ch & 268435456) != 0)
			{
				if ((ch & 8388608) != 0)
				{
					pSrc -= 3;
					result = new byte[]
					{
						(byte)((ch >> 12 & 7) | 240),
						(byte)((ch >> 6 & 63) | 128),
						(byte)((ch & 63) | 128)
					};
				}
				else if ((ch & 131072) != 0)
				{
					pSrc -= 2;
					result = new byte[]
					{
						(byte)((ch >> 6 & 7) | 240),
						(byte)((ch & 63) | 128)
					};
				}
				else
				{
					pSrc--;
					result = new byte[]
					{
						(byte)((ch & 7) | 240)
					};
				}
			}
			else if ((ch & 8388608) != 0)
			{
				pSrc -= 2;
				result = new byte[]
				{
					(byte)((ch >> 6 & 15) | 224),
					(byte)((ch & 63) | 128)
				};
			}
			else
			{
				pSrc--;
				result = new byte[]
				{
					(byte)((ch & 15) | 224)
				};
			}
			return result;
		}

		/// <summary>Obtains a decoder that converts a UTF-8 encoded sequence of bytes into a sequence of Unicode characters.</summary>
		/// <returns>A decoder that converts a UTF-8 encoded sequence of bytes into a sequence of Unicode characters.</returns>
		// Token: 0x06006811 RID: 26641 RVA: 0x00163627 File Offset: 0x00161827
		[__DynamicallyInvokable]
		public override Decoder GetDecoder()
		{
			return new UTF8Encoding.UTF8Decoder(this);
		}

		/// <summary>Obtains an encoder that converts a sequence of Unicode characters into a UTF-8 encoded sequence of bytes.</summary>
		/// <returns>A <see cref="T:System.Text.Encoder" /> that converts a sequence of Unicode characters into a UTF-8 encoded sequence of bytes.</returns>
		// Token: 0x06006812 RID: 26642 RVA: 0x0016362F File Offset: 0x0016182F
		[__DynamicallyInvokable]
		public override Encoder GetEncoder()
		{
			return new UTF8Encoding.UTF8Encoder(this);
		}

		/// <summary>Calculates the maximum number of bytes produced by encoding the specified number of characters.</summary>
		/// <param name="charCount">The number of characters to encode.</param>
		/// <returns>The maximum number of bytes produced by encoding the specified number of characters.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="charCount" /> is less than zero.  
		/// -or-  
		/// The resulting number of bytes is greater than the maximum number that can be returned as an integer.</exception>
		/// <exception cref="T:System.Text.EncoderFallbackException">A fallback occurred (see Character Encoding in the .NET Framework for complete explanation)  
		///  -and-  
		///  <see cref="P:System.Text.Encoding.EncoderFallback" /> is set to <see cref="T:System.Text.EncoderExceptionFallback" />.</exception>
		// Token: 0x06006813 RID: 26643 RVA: 0x00163638 File Offset: 0x00161838
		[__DynamicallyInvokable]
		public override int GetMaxByteCount(int charCount)
		{
			if (charCount < 0)
			{
				throw new ArgumentOutOfRangeException("charCount", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
			}
			long num = (long)charCount + 1L;
			if (base.EncoderFallback.MaxCharCount > 1)
			{
				num *= (long)base.EncoderFallback.MaxCharCount;
			}
			num *= 3L;
			if (num > 2147483647L)
			{
				throw new ArgumentOutOfRangeException("charCount", Environment.GetResourceString("ArgumentOutOfRange_GetByteCountOverflow"));
			}
			return (int)num;
		}

		/// <summary>Calculates the maximum number of characters produced by decoding the specified number of bytes.</summary>
		/// <param name="byteCount">The number of bytes to decode.</param>
		/// <returns>The maximum number of characters produced by decoding the specified number of bytes.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="byteCount" /> is less than zero.  
		/// -or-  
		/// The resulting number of bytes is greater than the maximum number that can be returned as an integer.</exception>
		/// <exception cref="T:System.Text.DecoderFallbackException">A fallback occurred (see Character Encoding in the .NET Framework for complete explanation)  
		///  -and-  
		///  <see cref="P:System.Text.Encoding.DecoderFallback" /> is set to <see cref="T:System.Text.DecoderExceptionFallback" />.</exception>
		// Token: 0x06006814 RID: 26644 RVA: 0x001636A8 File Offset: 0x001618A8
		[__DynamicallyInvokable]
		public override int GetMaxCharCount(int byteCount)
		{
			if (byteCount < 0)
			{
				throw new ArgumentOutOfRangeException("byteCount", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
			}
			long num = (long)byteCount + 1L;
			if (base.DecoderFallback.MaxCharCount > 1)
			{
				num *= (long)base.DecoderFallback.MaxCharCount;
			}
			if (num > 2147483647L)
			{
				throw new ArgumentOutOfRangeException("byteCount", Environment.GetResourceString("ArgumentOutOfRange_GetCharCountOverflow"));
			}
			return (int)num;
		}

		/// <summary>Returns a Unicode byte order mark encoded in UTF-8 format, if the <see cref="T:System.Text.UTF8Encoding" /> encoding object is configured to supply one.</summary>
		/// <returns>A byte array containing the Unicode byte order mark, if the <see cref="T:System.Text.UTF8Encoding" /> encoding object is configured to supply one. Otherwise, this method returns a zero-length byte array.</returns>
		// Token: 0x06006815 RID: 26645 RVA: 0x00163711 File Offset: 0x00161911
		[__DynamicallyInvokable]
		public override byte[] GetPreamble()
		{
			if (this.emitUTF8Identifier)
			{
				return new byte[]
				{
					239,
					187,
					191
				};
			}
			return EmptyArray<byte>.Value;
		}

		/// <summary>Determines whether the specified object is equal to the current <see cref="T:System.Text.UTF8Encoding" /> object.</summary>
		/// <param name="value">The object to compare with the current instance.</param>
		/// <returns>
		///   <see langword="true" /> if <paramref name="value" /> is an instance of <see cref="T:System.Text.UTF8Encoding" /> and is equal to the current object; otherwise, <see langword="false" />.</returns>
		// Token: 0x06006816 RID: 26646 RVA: 0x00163734 File Offset: 0x00161934
		[__DynamicallyInvokable]
		public override bool Equals(object value)
		{
			UTF8Encoding utf8Encoding = value as UTF8Encoding;
			return utf8Encoding != null && (this.emitUTF8Identifier == utf8Encoding.emitUTF8Identifier && base.EncoderFallback.Equals(utf8Encoding.EncoderFallback)) && base.DecoderFallback.Equals(utf8Encoding.DecoderFallback);
		}

		/// <summary>Returns the hash code for the current instance.</summary>
		/// <returns>The hash code for the current instance.</returns>
		// Token: 0x06006817 RID: 26647 RVA: 0x00163781 File Offset: 0x00161981
		[__DynamicallyInvokable]
		public override int GetHashCode()
		{
			return base.EncoderFallback.GetHashCode() + base.DecoderFallback.GetHashCode() + 65001 + (this.emitUTF8Identifier ? 1 : 0);
		}

		// Token: 0x04002E5F RID: 11871
		private const int UTF8_CODEPAGE = 65001;

		// Token: 0x04002E60 RID: 11872
		private bool emitUTF8Identifier;

		// Token: 0x04002E61 RID: 11873
		private bool isThrowException;

		// Token: 0x04002E62 RID: 11874
		private const int FinalByte = 536870912;

		// Token: 0x04002E63 RID: 11875
		private const int SupplimentarySeq = 268435456;

		// Token: 0x04002E64 RID: 11876
		private const int ThreeByteSeq = 134217728;

		// Token: 0x02000C89 RID: 3209
		internal sealed class UTF8EncodingSealed : UTF8Encoding
		{
			// Token: 0x06007086 RID: 28806 RVA: 0x0018235A File Offset: 0x0018055A
			public UTF8EncodingSealed(bool encoderShouldEmitUTF8Identifier) : base(encoderShouldEmitUTF8Identifier)
			{
			}
		}

		// Token: 0x02000C8A RID: 3210
		[Serializable]
		internal class UTF8Encoder : EncoderNLS, ISerializable
		{
			// Token: 0x06007087 RID: 28807 RVA: 0x00182363 File Offset: 0x00180563
			public UTF8Encoder(UTF8Encoding encoding) : base(encoding)
			{
			}

			// Token: 0x06007088 RID: 28808 RVA: 0x0018236C File Offset: 0x0018056C
			internal UTF8Encoder(SerializationInfo info, StreamingContext context)
			{
				if (info == null)
				{
					throw new ArgumentNullException("info");
				}
				this.m_encoding = (Encoding)info.GetValue("encoding", typeof(Encoding));
				this.surrogateChar = (int)info.GetValue("surrogateChar", typeof(int));
				try
				{
					this.m_fallback = (EncoderFallback)info.GetValue("m_fallback", typeof(EncoderFallback));
				}
				catch (SerializationException)
				{
					this.m_fallback = null;
				}
			}

			// Token: 0x06007089 RID: 28809 RVA: 0x0018240C File Offset: 0x0018060C
			[SecurityCritical]
			void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
			{
				if (info == null)
				{
					throw new ArgumentNullException("info");
				}
				info.AddValue("encoding", this.m_encoding);
				info.AddValue("surrogateChar", this.surrogateChar);
				info.AddValue("m_fallback", this.m_fallback);
				info.AddValue("storedSurrogate", this.surrogateChar > 0);
				info.AddValue("mustFlush", false);
			}

			// Token: 0x0600708A RID: 28810 RVA: 0x0018247E File Offset: 0x0018067E
			public override void Reset()
			{
				this.surrogateChar = 0;
				if (this.m_fallbackBuffer != null)
				{
					this.m_fallbackBuffer.Reset();
				}
			}

			// Token: 0x17001362 RID: 4962
			// (get) Token: 0x0600708B RID: 28811 RVA: 0x0018249A File Offset: 0x0018069A
			internal override bool HasState
			{
				get
				{
					return this.surrogateChar != 0;
				}
			}

			// Token: 0x040037ED RID: 14317
			internal int surrogateChar;
		}

		// Token: 0x02000C8B RID: 3211
		[Serializable]
		internal class UTF8Decoder : DecoderNLS, ISerializable
		{
			// Token: 0x0600708C RID: 28812 RVA: 0x001824A5 File Offset: 0x001806A5
			public UTF8Decoder(UTF8Encoding encoding) : base(encoding)
			{
			}

			// Token: 0x0600708D RID: 28813 RVA: 0x001824B0 File Offset: 0x001806B0
			internal UTF8Decoder(SerializationInfo info, StreamingContext context)
			{
				if (info == null)
				{
					throw new ArgumentNullException("info");
				}
				this.m_encoding = (Encoding)info.GetValue("encoding", typeof(Encoding));
				try
				{
					this.bits = (int)info.GetValue("wbits", typeof(int));
					this.m_fallback = (DecoderFallback)info.GetValue("m_fallback", typeof(DecoderFallback));
				}
				catch (SerializationException)
				{
					this.bits = 0;
					this.m_fallback = null;
				}
			}

			// Token: 0x0600708E RID: 28814 RVA: 0x00182554 File Offset: 0x00180754
			[SecurityCritical]
			void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
			{
				if (info == null)
				{
					throw new ArgumentNullException("info");
				}
				info.AddValue("encoding", this.m_encoding);
				info.AddValue("wbits", this.bits);
				info.AddValue("m_fallback", this.m_fallback);
				info.AddValue("bits", 0);
				info.AddValue("trailCount", 0);
				info.AddValue("isSurrogate", false);
				info.AddValue("byteSequence", 0);
			}

			// Token: 0x0600708F RID: 28815 RVA: 0x001825D2 File Offset: 0x001807D2
			public override void Reset()
			{
				this.bits = 0;
				if (this.m_fallbackBuffer != null)
				{
					this.m_fallbackBuffer.Reset();
				}
			}

			// Token: 0x17001363 RID: 4963
			// (get) Token: 0x06007090 RID: 28816 RVA: 0x001825EE File Offset: 0x001807EE
			internal override bool HasState
			{
				get
				{
					return this.bits != 0;
				}
			}

			// Token: 0x040037EE RID: 14318
			internal int bits;
		}
	}
}
