using System;
using System.IO;
using SonicOrca.Geometry;

namespace SonicOrca.Core
{
	// Token: 0x02000142 RID: 322
	internal class PlayRecorder : IDisposable
	{
		// Token: 0x17000353 RID: 851
		// (get) Token: 0x06000D48 RID: 3400 RVA: 0x00032535 File Offset: 0x00030735
		public bool Recording
		{
			get
			{
				return this._outputStream != null;
			}
		}

		// Token: 0x17000354 RID: 852
		// (get) Token: 0x06000D49 RID: 3401 RVA: 0x00032540 File Offset: 0x00030740
		public bool Playing
		{
			get
			{
				return this._inputStream != null;
			}
		}

		// Token: 0x06000D4B RID: 3403 RVA: 0x0003254B File Offset: 0x0003074B
		public void Dispose()
		{
			if (this._outputStream != null)
			{
				this._outputStream.Dispose();
			}
		}

		// Token: 0x06000D4C RID: 3404 RVA: 0x00032560 File Offset: 0x00030760
		public void BeginRecording(string path)
		{
			if (this._outputStream != null)
			{
				throw new InvalidOperationException("Already recording.");
			}
			this.BeginRecording(new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.Read));
		}

		// Token: 0x06000D4D RID: 3405 RVA: 0x00032584 File Offset: 0x00030784
		public void BeginRecording(Stream stream)
		{
			if (this._outputStream != null)
			{
				throw new InvalidOperationException("Already recording.");
			}
			this._outputStream = stream;
			this._gameTick = 0;
		}

		// Token: 0x06000D4E RID: 3406 RVA: 0x000325A8 File Offset: 0x000307A8
		public void WriteEntry(PlayRecorder.Entry entry)
		{
			BinaryWriter binaryWriter = new BinaryWriter(this._outputStream);
			binaryWriter.Write(entry.Direction.X);
			binaryWriter.Write(entry.Direction.Y);
			binaryWriter.Write(entry.Action);
			binaryWriter.Write(0);
			binaryWriter.Write(entry.Position.X);
			binaryWriter.Write(entry.Position.Y);
			binaryWriter.Write((short)entry.LayerIndex);
			binaryWriter.Write(entry.State);
			binaryWriter.Write((short)entry.AnimationIndex);
			binaryWriter.Write((short)entry.AnimationFrameIndex);
			binaryWriter.Write(entry.Angle);
			binaryWriter.Flush();
			this._gameTick++;
		}

		// Token: 0x06000D4F RID: 3407 RVA: 0x00032675 File Offset: 0x00030875
		public void EndRecording()
		{
			if (this._outputStream != null)
			{
				this._outputStream.Dispose();
				this._outputStream = null;
			}
		}

		// Token: 0x06000D50 RID: 3408 RVA: 0x00032691 File Offset: 0x00030891
		public void BeginPlaying(string path)
		{
			if (this._inputStream != null)
			{
				throw new InvalidOperationException("Already playing.");
			}
			this.BeginPlaying(new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read));
		}

		// Token: 0x06000D51 RID: 3409 RVA: 0x000326B5 File Offset: 0x000308B5
		public void BeginPlaying(Stream stream)
		{
			if (this._inputStream != null)
			{
				throw new InvalidOperationException("Already playing.");
			}
			this._inputStream = stream;
			this._gameTick = 0;
		}

		// Token: 0x06000D52 RID: 3410 RVA: 0x000326D8 File Offset: 0x000308D8
		public PlayRecorder.Entry GetNextEntry()
		{
			PlayRecorder.Entry entry = new PlayRecorder.Entry();
			BinaryReader binaryReader = new BinaryReader(this._inputStream);
			try
			{
				entry.Direction = new Vector2(binaryReader.ReadDouble(), binaryReader.ReadDouble());
				entry.Action = ((binaryReader.ReadByte() & 1) > 0);
				binaryReader.ReadByte();
				entry.Position = new Vector2i(binaryReader.ReadInt32(), binaryReader.ReadInt32());
				entry.LayerIndex = (int)binaryReader.ReadInt16();
				entry.State = binaryReader.ReadInt32();
				entry.AnimationIndex = (int)binaryReader.ReadInt16();
				entry.AnimationFrameIndex = (int)binaryReader.ReadInt16();
				entry.Angle = binaryReader.ReadSingle();
			}
			catch (EndOfStreamException)
			{
				this.EndPlaying();
				return null;
			}
			this._gameTick++;
			return entry;
		}

		// Token: 0x06000D53 RID: 3411 RVA: 0x000327A8 File Offset: 0x000309A8
		public void EndPlaying()
		{
			if (this._inputStream != null)
			{
				this._inputStream.Dispose();
				this._inputStream = null;
			}
		}

		// Token: 0x04000784 RID: 1924
		private Stream _inputStream;

		// Token: 0x04000785 RID: 1925
		private Stream _outputStream;

		// Token: 0x04000786 RID: 1926
		private int _gameTick;

		// Token: 0x0200022D RID: 557
		public class Entry
		{
			// Token: 0x17000532 RID: 1330
			// (get) Token: 0x06001421 RID: 5153 RVA: 0x0004DCEB File Offset: 0x0004BEEB
			// (set) Token: 0x06001422 RID: 5154 RVA: 0x0004DCF3 File Offset: 0x0004BEF3
			public Vector2 Direction { get; set; }

			// Token: 0x17000533 RID: 1331
			// (get) Token: 0x06001423 RID: 5155 RVA: 0x0004DCFC File Offset: 0x0004BEFC
			// (set) Token: 0x06001424 RID: 5156 RVA: 0x0004DD04 File Offset: 0x0004BF04
			public bool Action { get; set; }

			// Token: 0x17000534 RID: 1332
			// (get) Token: 0x06001425 RID: 5157 RVA: 0x0004DD0D File Offset: 0x0004BF0D
			// (set) Token: 0x06001426 RID: 5158 RVA: 0x0004DD15 File Offset: 0x0004BF15
			public Vector2i Position { get; set; }

			// Token: 0x17000535 RID: 1333
			// (get) Token: 0x06001427 RID: 5159 RVA: 0x0004DD1E File Offset: 0x0004BF1E
			// (set) Token: 0x06001428 RID: 5160 RVA: 0x0004DD26 File Offset: 0x0004BF26
			public int LayerIndex { get; set; }

			// Token: 0x17000536 RID: 1334
			// (get) Token: 0x06001429 RID: 5161 RVA: 0x0004DD2F File Offset: 0x0004BF2F
			// (set) Token: 0x0600142A RID: 5162 RVA: 0x0004DD37 File Offset: 0x0004BF37
			public int State { get; set; }

			// Token: 0x17000537 RID: 1335
			// (get) Token: 0x0600142B RID: 5163 RVA: 0x0004DD40 File Offset: 0x0004BF40
			// (set) Token: 0x0600142C RID: 5164 RVA: 0x0004DD48 File Offset: 0x0004BF48
			public int AnimationIndex { get; set; }

			// Token: 0x17000538 RID: 1336
			// (get) Token: 0x0600142D RID: 5165 RVA: 0x0004DD51 File Offset: 0x0004BF51
			// (set) Token: 0x0600142E RID: 5166 RVA: 0x0004DD59 File Offset: 0x0004BF59
			public int AnimationFrameIndex { get; set; }

			// Token: 0x17000539 RID: 1337
			// (get) Token: 0x0600142F RID: 5167 RVA: 0x0004DD62 File Offset: 0x0004BF62
			// (set) Token: 0x06001430 RID: 5168 RVA: 0x0004DD6A File Offset: 0x0004BF6A
			public float Angle { get; set; }
		}
	}
}
