﻿using System;
using System.Globalization;
using System.Security;

namespace System.Text
{
	/// <summary>Provides a buffer that allows a fallback handler to return an alternate string to a decoder when it cannot decode an input byte sequence.</summary>
	// Token: 0x02000A38 RID: 2616
	[__DynamicallyInvokable]
	public abstract class DecoderFallbackBuffer
	{
		/// <summary>When overridden in a derived class, prepares the fallback buffer to handle the specified input byte sequence.</summary>
		/// <param name="bytesUnknown">An input array of bytes.</param>
		/// <param name="index">The index position of a byte in <paramref name="bytesUnknown" />.</param>
		/// <returns>
		///   <see langword="true" /> if the fallback buffer can process <paramref name="bytesUnknown" />; <see langword="false" /> if the fallback buffer ignores <paramref name="bytesUnknown" />.</returns>
		// Token: 0x0600668B RID: 26251
		[__DynamicallyInvokable]
		public abstract bool Fallback(byte[] bytesUnknown, int index);

		/// <summary>When overridden in a derived class, retrieves the next character in the fallback buffer.</summary>
		/// <returns>The next character in the fallback buffer.</returns>
		// Token: 0x0600668C RID: 26252
		[__DynamicallyInvokable]
		public abstract char GetNextChar();

		/// <summary>When overridden in a derived class, causes the next call to the <see cref="M:System.Text.DecoderFallbackBuffer.GetNextChar" /> method to access the data buffer character position that is prior to the current character position.</summary>
		/// <returns>
		///   <see langword="true" /> if the <see cref="M:System.Text.DecoderFallbackBuffer.MovePrevious" /> operation was successful; otherwise, <see langword="false" />.</returns>
		// Token: 0x0600668D RID: 26253
		[__DynamicallyInvokable]
		public abstract bool MovePrevious();

		/// <summary>When overridden in a derived class, gets the number of characters in the current <see cref="T:System.Text.DecoderFallbackBuffer" /> object that remain to be processed.</summary>
		/// <returns>The number of characters in the current fallback buffer that have not yet been processed.</returns>
		// Token: 0x17001193 RID: 4499
		// (get) Token: 0x0600668E RID: 26254
		[__DynamicallyInvokable]
		public abstract int Remaining { [__DynamicallyInvokable] get; }

		/// <summary>Initializes all data and state information pertaining to this fallback buffer.</summary>
		// Token: 0x0600668F RID: 26255 RVA: 0x001596C4 File Offset: 0x001578C4
		[__DynamicallyInvokable]
		public virtual void Reset()
		{
			while (this.GetNextChar() != '\0')
			{
			}
		}

		// Token: 0x06006690 RID: 26256 RVA: 0x001596CE File Offset: 0x001578CE
		[SecurityCritical]
		internal void InternalReset()
		{
			this.byteStart = null;
			this.Reset();
		}

		// Token: 0x06006691 RID: 26257 RVA: 0x001596DE File Offset: 0x001578DE
		[SecurityCritical]
		internal unsafe void InternalInitialize(byte* byteStart, char* charEnd)
		{
			this.byteStart = byteStart;
			this.charEnd = charEnd;
		}

		// Token: 0x06006692 RID: 26258 RVA: 0x001596F0 File Offset: 0x001578F0
		[SecurityCritical]
		internal unsafe virtual bool InternalFallback(byte[] bytes, byte* pBytes, ref char* chars)
		{
			if (this.Fallback(bytes, (int)((long)(pBytes - this.byteStart) - (long)bytes.Length)))
			{
				char* ptr = chars;
				bool flag = false;
				char nextChar;
				while ((nextChar = this.GetNextChar()) != '\0')
				{
					if (char.IsSurrogate(nextChar))
					{
						if (char.IsHighSurrogate(nextChar))
						{
							if (flag)
							{
								throw new ArgumentException(Environment.GetResourceString("Argument_InvalidCharSequenceNoIndex"));
							}
							flag = true;
						}
						else
						{
							if (!flag)
							{
								throw new ArgumentException(Environment.GetResourceString("Argument_InvalidCharSequenceNoIndex"));
							}
							flag = false;
						}
					}
					if (ptr >= this.charEnd)
					{
						return false;
					}
					*(ptr++) = nextChar;
				}
				if (flag)
				{
					throw new ArgumentException(Environment.GetResourceString("Argument_InvalidCharSequenceNoIndex"));
				}
				chars = ptr;
			}
			return true;
		}

		// Token: 0x06006693 RID: 26259 RVA: 0x00159790 File Offset: 0x00157990
		[SecurityCritical]
		internal unsafe virtual int InternalFallback(byte[] bytes, byte* pBytes)
		{
			if (!this.Fallback(bytes, (int)((long)(pBytes - this.byteStart) - (long)bytes.Length)))
			{
				return 0;
			}
			int num = 0;
			bool flag = false;
			char nextChar;
			while ((nextChar = this.GetNextChar()) != '\0')
			{
				if (char.IsSurrogate(nextChar))
				{
					if (char.IsHighSurrogate(nextChar))
					{
						if (flag)
						{
							throw new ArgumentException(Environment.GetResourceString("Argument_InvalidCharSequenceNoIndex"));
						}
						flag = true;
					}
					else
					{
						if (!flag)
						{
							throw new ArgumentException(Environment.GetResourceString("Argument_InvalidCharSequenceNoIndex"));
						}
						flag = false;
					}
				}
				num++;
			}
			if (flag)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_InvalidCharSequenceNoIndex"));
			}
			return num;
		}

		// Token: 0x06006694 RID: 26260 RVA: 0x00159820 File Offset: 0x00157A20
		internal void ThrowLastBytesRecursive(byte[] bytesUnknown)
		{
			StringBuilder stringBuilder = new StringBuilder(bytesUnknown.Length * 3);
			int num = 0;
			while (num < bytesUnknown.Length && num < 20)
			{
				if (stringBuilder.Length > 0)
				{
					stringBuilder.Append(" ");
				}
				stringBuilder.Append(string.Format(CultureInfo.InvariantCulture, "\\x{0:X2}", bytesUnknown[num]));
				num++;
			}
			if (num == 20)
			{
				stringBuilder.Append(" ...");
			}
			throw new ArgumentException(Environment.GetResourceString("Argument_RecursiveFallbackBytes", new object[]
			{
				stringBuilder.ToString()
			}), "bytesUnknown");
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Text.DecoderFallbackBuffer" /> class.</summary>
		// Token: 0x06006695 RID: 26261 RVA: 0x001598B2 File Offset: 0x00157AB2
		[__DynamicallyInvokable]
		protected DecoderFallbackBuffer()
		{
		}

		// Token: 0x04002D93 RID: 11667
		[SecurityCritical]
		internal unsafe byte* byteStart;

		// Token: 0x04002D94 RID: 11668
		[SecurityCritical]
		internal unsafe char* charEnd;
	}
}
