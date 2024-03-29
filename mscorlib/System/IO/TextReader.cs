﻿using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace System.IO
{
	/// <summary>Represents a reader that can read a sequential series of characters.</summary>
	// Token: 0x020001A6 RID: 422
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public abstract class TextReader : MarshalByRefObject, IDisposable
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.IO.TextReader" /> class.</summary>
		// Token: 0x06001A2D RID: 6701 RVA: 0x00057760 File Offset: 0x00055960
		[__DynamicallyInvokable]
		protected TextReader()
		{
		}

		/// <summary>Closes the <see cref="T:System.IO.TextReader" /> and releases any system resources associated with the <see langword="TextReader" />.</summary>
		// Token: 0x06001A2E RID: 6702 RVA: 0x00057768 File Offset: 0x00055968
		public virtual void Close()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		/// <summary>Releases all resources used by the <see cref="T:System.IO.TextReader" /> object.</summary>
		// Token: 0x06001A2F RID: 6703 RVA: 0x00057777 File Offset: 0x00055977
		[__DynamicallyInvokable]
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		/// <summary>Releases the unmanaged resources used by the <see cref="T:System.IO.TextReader" /> and optionally releases the managed resources.</summary>
		/// <param name="disposing">
		///   <see langword="true" /> to release both managed and unmanaged resources; <see langword="false" /> to release only unmanaged resources.</param>
		// Token: 0x06001A30 RID: 6704 RVA: 0x00057786 File Offset: 0x00055986
		[__DynamicallyInvokable]
		protected virtual void Dispose(bool disposing)
		{
		}

		/// <summary>Reads the next character without changing the state of the reader or the character source. Returns the next available character without actually reading it from the reader.</summary>
		/// <returns>An integer representing the next character to be read, or -1 if no more characters are available or the reader does not support seeking.</returns>
		/// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextReader" /> is closed.</exception>
		/// <exception cref="T:System.IO.IOException">An I/O error occurs.</exception>
		// Token: 0x06001A31 RID: 6705 RVA: 0x00057788 File Offset: 0x00055988
		[__DynamicallyInvokable]
		public virtual int Peek()
		{
			return -1;
		}

		/// <summary>Reads the next character from the text reader and advances the character position by one character.</summary>
		/// <returns>The next character from the text reader, or -1 if no more characters are available. The default implementation returns -1.</returns>
		/// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextReader" /> is closed.</exception>
		/// <exception cref="T:System.IO.IOException">An I/O error occurs.</exception>
		// Token: 0x06001A32 RID: 6706 RVA: 0x0005778B File Offset: 0x0005598B
		[__DynamicallyInvokable]
		public virtual int Read()
		{
			return -1;
		}

		/// <summary>Reads a specified maximum number of characters from the current reader and writes the data to a buffer, beginning at the specified index.</summary>
		/// <param name="buffer">When this method returns, contains the specified character array with the values between <paramref name="index" /> and (<paramref name="index" /> + <paramref name="count" /> - 1) replaced by the characters read from the current source.</param>
		/// <param name="index">The position in <paramref name="buffer" /> at which to begin writing.</param>
		/// <param name="count">The maximum number of characters to read. If the end of the reader is reached before the specified number of characters is read into the buffer, the method returns.</param>
		/// <returns>The number of characters that have been read. The number will be less than or equal to <paramref name="count" />, depending on whether the data is available within the reader. This method returns 0 (zero) if it is called when no more characters are left to read.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="buffer" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">The buffer length minus <paramref name="index" /> is less than <paramref name="count" />.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="index" /> or <paramref name="count" /> is negative.</exception>
		/// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextReader" /> is closed.</exception>
		/// <exception cref="T:System.IO.IOException">An I/O error occurs.</exception>
		// Token: 0x06001A33 RID: 6707 RVA: 0x00057790 File Offset: 0x00055990
		[__DynamicallyInvokable]
		public virtual int Read([In] [Out] char[] buffer, int index, int count)
		{
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer", Environment.GetResourceString("ArgumentNull_Buffer"));
			}
			if (index < 0)
			{
				throw new ArgumentOutOfRangeException("index", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
			}
			if (count < 0)
			{
				throw new ArgumentOutOfRangeException("count", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
			}
			if (buffer.Length - index < count)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_InvalidOffLen"));
			}
			int num = 0;
			do
			{
				int num2 = this.Read();
				if (num2 == -1)
				{
					break;
				}
				buffer[index + num++] = (char)num2;
			}
			while (num < count);
			return num;
		}

		/// <summary>Reads all characters from the current position to the end of the text reader and returns them as one string.</summary>
		/// <returns>A string that contains all characters from the current position to the end of the text reader.</returns>
		/// <exception cref="T:System.IO.IOException">An I/O error occurs.</exception>
		/// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextReader" /> is closed.</exception>
		/// <exception cref="T:System.OutOfMemoryException">There is insufficient memory to allocate a buffer for the returned string.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The number of characters in the next line is larger than <see cref="F:System.Int32.MaxValue" /></exception>
		// Token: 0x06001A34 RID: 6708 RVA: 0x0005781C File Offset: 0x00055A1C
		[__DynamicallyInvokable]
		public virtual string ReadToEnd()
		{
			char[] array = new char[4096];
			StringBuilder stringBuilder = new StringBuilder(4096);
			int charCount;
			while ((charCount = this.Read(array, 0, array.Length)) != 0)
			{
				stringBuilder.Append(array, 0, charCount);
			}
			return stringBuilder.ToString();
		}

		/// <summary>Reads a specified maximum number of characters from the current text reader and writes the data to a buffer, beginning at the specified index.</summary>
		/// <param name="buffer">When this method returns, this parameter contains the specified character array with the values between <paramref name="index" /> and (<paramref name="index" /> + <paramref name="count" /> -1) replaced by the characters read from the current source.</param>
		/// <param name="index">The position in <paramref name="buffer" /> at which to begin writing.</param>
		/// <param name="count">The maximum number of characters to read.</param>
		/// <returns>The number of characters that have been read. The number will be less than or equal to <paramref name="count" />, depending on whether all input characters have been read.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="buffer" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">The buffer length minus <paramref name="index" /> is less than <paramref name="count" />.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="index" /> or <paramref name="count" /> is negative.</exception>
		/// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextReader" /> is closed.</exception>
		/// <exception cref="T:System.IO.IOException">An I/O error occurs.</exception>
		// Token: 0x06001A35 RID: 6709 RVA: 0x00057860 File Offset: 0x00055A60
		[__DynamicallyInvokable]
		public virtual int ReadBlock([In] [Out] char[] buffer, int index, int count)
		{
			int num = 0;
			int num2;
			do
			{
				num += (num2 = this.Read(buffer, index + num, count - num));
			}
			while (num2 > 0 && num < count);
			return num;
		}

		/// <summary>Reads a line of characters from the text reader and returns the data as a string.</summary>
		/// <returns>The next line from the reader, or <see langword="null" /> if all characters have been read.</returns>
		/// <exception cref="T:System.IO.IOException">An I/O error occurs.</exception>
		/// <exception cref="T:System.OutOfMemoryException">There is insufficient memory to allocate a buffer for the returned string.</exception>
		/// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextReader" /> is closed.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The number of characters in the next line is larger than <see cref="F:System.Int32.MaxValue" /></exception>
		// Token: 0x06001A36 RID: 6710 RVA: 0x0005788C File Offset: 0x00055A8C
		[__DynamicallyInvokable]
		public virtual string ReadLine()
		{
			StringBuilder stringBuilder = new StringBuilder();
			int num;
			for (;;)
			{
				num = this.Read();
				if (num == -1)
				{
					goto IL_43;
				}
				if (num == 13 || num == 10)
				{
					break;
				}
				stringBuilder.Append((char)num);
			}
			if (num == 13 && this.Peek() == 10)
			{
				this.Read();
			}
			return stringBuilder.ToString();
			IL_43:
			if (stringBuilder.Length > 0)
			{
				return stringBuilder.ToString();
			}
			return null;
		}

		/// <summary>Reads a line of characters asynchronously and returns the data as a string.</summary>
		/// <returns>A task that represents the asynchronous read operation. The value of the <paramref name="TResult" /> parameter contains the next line from the text reader, or is <see langword="null" /> if all of the characters have been read.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The number of characters in the next line is larger than <see cref="F:System.Int32.MaxValue" />.</exception>
		/// <exception cref="T:System.ObjectDisposedException">The text reader has been disposed.</exception>
		/// <exception cref="T:System.InvalidOperationException">The reader is currently in use by a previous read operation.</exception>
		// Token: 0x06001A37 RID: 6711 RVA: 0x000578ED File Offset: 0x00055AED
		[ComVisible(false)]
		[__DynamicallyInvokable]
		[HostProtection(SecurityAction.LinkDemand, ExternalThreading = true)]
		public virtual Task<string> ReadLineAsync()
		{
			return Task<string>.Factory.StartNew(TextReader._ReadLineDelegate, this, CancellationToken.None, TaskCreationOptions.DenyChildAttach, TaskScheduler.Default);
		}

		/// <summary>Reads all characters from the current position to the end of the text reader asynchronously and returns them as one string.</summary>
		/// <returns>A task that represents the asynchronous read operation. The value of the <paramref name="TResult" /> parameter contains a string with the characters from the current position to the end of the text reader.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The number of characters is larger than <see cref="F:System.Int32.MaxValue" />.</exception>
		/// <exception cref="T:System.ObjectDisposedException">The text reader has been disposed.</exception>
		/// <exception cref="T:System.InvalidOperationException">The reader is currently in use by a previous read operation.</exception>
		// Token: 0x06001A38 RID: 6712 RVA: 0x0005790C File Offset: 0x00055B0C
		[ComVisible(false)]
		[__DynamicallyInvokable]
		[HostProtection(SecurityAction.LinkDemand, ExternalThreading = true)]
		public virtual async Task<string> ReadToEndAsync()
		{
			char[] chars = new char[4096];
			StringBuilder sb = new StringBuilder(4096);
			for (;;)
			{
				int num = await this.ReadAsyncInternal(chars, 0, chars.Length).ConfigureAwait(false);
				int len;
				if ((len = num) == 0)
				{
					break;
				}
				sb.Append(chars, 0, len);
			}
			return sb.ToString();
		}

		/// <summary>Reads a specified maximum number of characters from the current text reader asynchronously and writes the data to a buffer, beginning at the specified index.</summary>
		/// <param name="buffer">When this method returns, contains the specified character array with the values between <paramref name="index" /> and (<paramref name="index" /> + <paramref name="count" /> - 1) replaced by the characters read from the current source.</param>
		/// <param name="index">The position in <paramref name="buffer" /> at which to begin writing.</param>
		/// <param name="count">The maximum number of characters to read. If the end of the text is reached before the specified number of characters is read into the buffer, the current method returns.</param>
		/// <returns>A task that represents the asynchronous read operation. The value of the <paramref name="TResult" /> parameter contains the total number of bytes read into the buffer. The result value can be less than the number of bytes requested if the number of bytes currently available is less than the requested number, or it can be 0 (zero) if the end of the text has been reached.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="buffer" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="index" /> or <paramref name="count" /> is negative.</exception>
		/// <exception cref="T:System.ArgumentException">The sum of <paramref name="index" /> and <paramref name="count" /> is larger than the buffer length.</exception>
		/// <exception cref="T:System.ObjectDisposedException">The text reader has been disposed.</exception>
		/// <exception cref="T:System.InvalidOperationException">The reader is currently in use by a previous read operation.</exception>
		// Token: 0x06001A39 RID: 6713 RVA: 0x00057954 File Offset: 0x00055B54
		[ComVisible(false)]
		[__DynamicallyInvokable]
		[HostProtection(SecurityAction.LinkDemand, ExternalThreading = true)]
		public virtual Task<int> ReadAsync(char[] buffer, int index, int count)
		{
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer", Environment.GetResourceString("ArgumentNull_Buffer"));
			}
			if (index < 0 || count < 0)
			{
				throw new ArgumentOutOfRangeException((index < 0) ? "index" : "count", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
			}
			if (buffer.Length - index < count)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_InvalidOffLen"));
			}
			return this.ReadAsyncInternal(buffer, index, count);
		}

		// Token: 0x06001A3A RID: 6714 RVA: 0x000579C4 File Offset: 0x00055BC4
		internal virtual Task<int> ReadAsyncInternal(char[] buffer, int index, int count)
		{
			Tuple<TextReader, char[], int, int> state = new Tuple<TextReader, char[], int, int>(this, buffer, index, count);
			return Task<int>.Factory.StartNew(TextReader._ReadDelegate, state, CancellationToken.None, TaskCreationOptions.DenyChildAttach, TaskScheduler.Default);
		}

		/// <summary>Reads a specified maximum number of characters from the current text reader asynchronously and writes the data to a buffer, beginning at the specified index.</summary>
		/// <param name="buffer">When this method returns, contains the specified character array with the values between <paramref name="index" /> and (<paramref name="index" /> + <paramref name="count" /> - 1) replaced by the characters read from the current source.</param>
		/// <param name="index">The position in <paramref name="buffer" /> at which to begin writing.</param>
		/// <param name="count">The maximum number of characters to read. If the end of the text is reached before the specified number of characters is read into the buffer, the current method returns.</param>
		/// <returns>A task that represents the asynchronous read operation. The value of the <paramref name="TResult" /> parameter contains the total number of bytes read into the buffer. The result value can be less than the number of bytes requested if the number of bytes currently available is less than the requested number, or it can be 0 (zero) if the end of the text has been reached.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="buffer" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///   <paramref name="index" /> or <paramref name="count" /> is negative.</exception>
		/// <exception cref="T:System.ArgumentException">The sum of <paramref name="index" /> and <paramref name="count" /> is larger than the buffer length.</exception>
		/// <exception cref="T:System.ObjectDisposedException">The text reader has been disposed.</exception>
		/// <exception cref="T:System.InvalidOperationException">The reader is currently in use by a previous read operation.</exception>
		// Token: 0x06001A3B RID: 6715 RVA: 0x000579F8 File Offset: 0x00055BF8
		[ComVisible(false)]
		[__DynamicallyInvokable]
		[HostProtection(SecurityAction.LinkDemand, ExternalThreading = true)]
		public virtual Task<int> ReadBlockAsync(char[] buffer, int index, int count)
		{
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer", Environment.GetResourceString("ArgumentNull_Buffer"));
			}
			if (index < 0 || count < 0)
			{
				throw new ArgumentOutOfRangeException((index < 0) ? "index" : "count", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
			}
			if (buffer.Length - index < count)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_InvalidOffLen"));
			}
			return this.ReadBlockAsyncInternal(buffer, index, count);
		}

		// Token: 0x06001A3C RID: 6716 RVA: 0x00057A68 File Offset: 0x00055C68
		[HostProtection(SecurityAction.LinkDemand, ExternalThreading = true)]
		private async Task<int> ReadBlockAsyncInternal(char[] buffer, int index, int count)
		{
			int i = 0;
			int num2;
			do
			{
				int num = await this.ReadAsyncInternal(buffer, index + i, count - i).ConfigureAwait(false);
				num2 = num;
				i += num2;
			}
			while (num2 > 0 && i < count);
			return i;
		}

		/// <summary>Creates a thread-safe wrapper around the specified <see langword="TextReader" />.</summary>
		/// <param name="reader">The <see langword="TextReader" /> to synchronize.</param>
		/// <returns>A thread-safe <see cref="T:System.IO.TextReader" />.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="reader" /> is <see langword="null" />.</exception>
		// Token: 0x06001A3D RID: 6717 RVA: 0x00057AC5 File Offset: 0x00055CC5
		[HostProtection(SecurityAction.LinkDemand, Synchronization = true)]
		public static TextReader Synchronized(TextReader reader)
		{
			if (reader == null)
			{
				throw new ArgumentNullException("reader");
			}
			if (reader is TextReader.SyncTextReader)
			{
				return reader;
			}
			return new TextReader.SyncTextReader(reader);
		}

		// Token: 0x04000922 RID: 2338
		[NonSerialized]
		private static Func<object, string> _ReadLineDelegate = (object state) => ((TextReader)state).ReadLine();

		// Token: 0x04000923 RID: 2339
		[NonSerialized]
		private static Func<object, int> _ReadDelegate = delegate(object state)
		{
			Tuple<TextReader, char[], int, int> tuple = (Tuple<TextReader, char[], int, int>)state;
			return tuple.Item1.Read(tuple.Item2, tuple.Item3, tuple.Item4);
		};

		/// <summary>Provides a <see langword="TextReader" /> with no data to read from.</summary>
		// Token: 0x04000924 RID: 2340
		[__DynamicallyInvokable]
		public static readonly TextReader Null = new TextReader.NullTextReader();

		// Token: 0x02000AF5 RID: 2805
		[Serializable]
		private sealed class NullTextReader : TextReader
		{
			// Token: 0x060069E6 RID: 27110 RVA: 0x0016E3C6 File Offset: 0x0016C5C6
			public override int Read(char[] buffer, int index, int count)
			{
				return 0;
			}

			// Token: 0x060069E7 RID: 27111 RVA: 0x0016E3C9 File Offset: 0x0016C5C9
			public override string ReadLine()
			{
				return null;
			}
		}

		// Token: 0x02000AF6 RID: 2806
		[Serializable]
		internal sealed class SyncTextReader : TextReader
		{
			// Token: 0x060069E8 RID: 27112 RVA: 0x0016E3CC File Offset: 0x0016C5CC
			internal SyncTextReader(TextReader t)
			{
				this._in = t;
			}

			// Token: 0x060069E9 RID: 27113 RVA: 0x0016E3DB File Offset: 0x0016C5DB
			[MethodImpl(MethodImplOptions.Synchronized)]
			public override void Close()
			{
				this._in.Close();
			}

			// Token: 0x060069EA RID: 27114 RVA: 0x0016E3E8 File Offset: 0x0016C5E8
			[MethodImpl(MethodImplOptions.Synchronized)]
			protected override void Dispose(bool disposing)
			{
				if (disposing)
				{
					((IDisposable)this._in).Dispose();
				}
			}

			// Token: 0x060069EB RID: 27115 RVA: 0x0016E3F8 File Offset: 0x0016C5F8
			[MethodImpl(MethodImplOptions.Synchronized)]
			public override int Peek()
			{
				return this._in.Peek();
			}

			// Token: 0x060069EC RID: 27116 RVA: 0x0016E405 File Offset: 0x0016C605
			[MethodImpl(MethodImplOptions.Synchronized)]
			public override int Read()
			{
				return this._in.Read();
			}

			// Token: 0x060069ED RID: 27117 RVA: 0x0016E412 File Offset: 0x0016C612
			[MethodImpl(MethodImplOptions.Synchronized)]
			public override int Read([In] [Out] char[] buffer, int index, int count)
			{
				return this._in.Read(buffer, index, count);
			}

			// Token: 0x060069EE RID: 27118 RVA: 0x0016E422 File Offset: 0x0016C622
			[MethodImpl(MethodImplOptions.Synchronized)]
			public override int ReadBlock([In] [Out] char[] buffer, int index, int count)
			{
				return this._in.ReadBlock(buffer, index, count);
			}

			// Token: 0x060069EF RID: 27119 RVA: 0x0016E432 File Offset: 0x0016C632
			[MethodImpl(MethodImplOptions.Synchronized)]
			public override string ReadLine()
			{
				return this._in.ReadLine();
			}

			// Token: 0x060069F0 RID: 27120 RVA: 0x0016E43F File Offset: 0x0016C63F
			[MethodImpl(MethodImplOptions.Synchronized)]
			public override string ReadToEnd()
			{
				return this._in.ReadToEnd();
			}

			// Token: 0x060069F1 RID: 27121 RVA: 0x0016E44C File Offset: 0x0016C64C
			[ComVisible(false)]
			[MethodImpl(MethodImplOptions.Synchronized)]
			public override Task<string> ReadLineAsync()
			{
				return Task.FromResult<string>(this.ReadLine());
			}

			// Token: 0x060069F2 RID: 27122 RVA: 0x0016E459 File Offset: 0x0016C659
			[ComVisible(false)]
			[MethodImpl(MethodImplOptions.Synchronized)]
			public override Task<string> ReadToEndAsync()
			{
				return Task.FromResult<string>(this.ReadToEnd());
			}

			// Token: 0x060069F3 RID: 27123 RVA: 0x0016E468 File Offset: 0x0016C668
			[ComVisible(false)]
			[MethodImpl(MethodImplOptions.Synchronized)]
			public override Task<int> ReadBlockAsync(char[] buffer, int index, int count)
			{
				if (buffer == null)
				{
					throw new ArgumentNullException("buffer", Environment.GetResourceString("ArgumentNull_Buffer"));
				}
				if (index < 0 || count < 0)
				{
					throw new ArgumentOutOfRangeException((index < 0) ? "index" : "count", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
				}
				if (buffer.Length - index < count)
				{
					throw new ArgumentException(Environment.GetResourceString("Argument_InvalidOffLen"));
				}
				return Task.FromResult<int>(this.ReadBlock(buffer, index, count));
			}

			// Token: 0x060069F4 RID: 27124 RVA: 0x0016E4DC File Offset: 0x0016C6DC
			[ComVisible(false)]
			[MethodImpl(MethodImplOptions.Synchronized)]
			public override Task<int> ReadAsync(char[] buffer, int index, int count)
			{
				if (buffer == null)
				{
					throw new ArgumentNullException("buffer", Environment.GetResourceString("ArgumentNull_Buffer"));
				}
				if (index < 0 || count < 0)
				{
					throw new ArgumentOutOfRangeException((index < 0) ? "index" : "count", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
				}
				if (buffer.Length - index < count)
				{
					throw new ArgumentException(Environment.GetResourceString("Argument_InvalidOffLen"));
				}
				return Task.FromResult<int>(this.Read(buffer, index, count));
			}

			// Token: 0x0400325B RID: 12891
			internal TextReader _in;
		}
	}
}
