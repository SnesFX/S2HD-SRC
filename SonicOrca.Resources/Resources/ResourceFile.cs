using System;
using System.IO;
using System.Linq;
using System.Text;
using SonicOrca.Extensions;

namespace SonicOrca.Resources
{
	// Token: 0x02000007 RID: 7
	public class ResourceFile
	{
		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000023 RID: 35 RVA: 0x000025EA File Offset: 0x000007EA
		private static int MagicNumber
		{
			get
			{
				return BitConverter.ToInt32(Encoding.ASCII.GetBytes(ResourceFile.MagicNumberChars), 0);
			}
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000024 RID: 36 RVA: 0x00002601 File Offset: 0x00000801
		public string Filename
		{
			get
			{
				return this._path;
			}
		}

		// Token: 0x06000025 RID: 37 RVA: 0x00002609 File Offset: 0x00000809
		public ResourceFile(string path)
		{
			this._path = path;
		}

		// Token: 0x06000026 RID: 38 RVA: 0x00002601 File Offset: 0x00000801
		public override string ToString()
		{
			return this._path;
		}

		// Token: 0x06000027 RID: 39 RVA: 0x00002618 File Offset: 0x00000818
		public ResourceTree Scan()
		{
			ResourceTree result;
			try
			{
				using (FileStream fileStream = new FileStream(this._path, FileMode.Open, FileAccess.Read))
				{
					BinaryReader binaryReader = new BinaryReader(fileStream);
					if (binaryReader.ReadInt32() != ResourceFile.MagicNumber)
					{
						throw new ResourceException("Invalid resource file.");
					}
					if (binaryReader.ReadByte() > 2)
					{
						throw new ResourceException("Unsupport resouce file version.");
					}
					long dataOffset = binaryReader.ReadInt64() + 13L;
					ResourceTree resourceTree = new ResourceTree();
					this.ScanTableEntry(resourceTree.Head, fileStream, dataOffset, null);
					result = resourceTree;
				}
			}
			catch (IOException ex)
			{
				throw new ResourceException(ex.Message, ex);
			}
			return result;
		}

		// Token: 0x06000028 RID: 40 RVA: 0x000026C0 File Offset: 0x000008C0
		private void ScanTableEntry(ResourceTree.Node resourceNode, Stream stream, long dataOffset, string fullKeyPath = null)
		{
			BinaryReader binaryReader = new BinaryReader(stream);
			ResourceFile.NodeFlags nodeFlags = (ResourceFile.NodeFlags)binaryReader.ReadByte();
			ushort num = 0;
			if (nodeFlags.HasFlag(ResourceFile.NodeFlags.HasChildren))
			{
				num = binaryReader.ReadUInt16();
			}
			string text = binaryReader.ReadNullTerminatedString();
			if (!string.IsNullOrEmpty(fullKeyPath))
			{
				fullKeyPath += "/";
			}
			fullKeyPath += text;
			Resource resource = null;
			if (nodeFlags.HasFlag(ResourceFile.NodeFlags.HasResource))
			{
				ResourceTypeIdentifier identifier = (ResourceTypeIdentifier)binaryReader.ReadUInt16();
				string path = nodeFlags.HasFlag(ResourceFile.NodeFlags.External) ? binaryReader.ReadNullTerminatedString() : this._path;
				long num2 = (long)((ulong)binaryReader.ReadUInt32());
				long size = (long)((ulong)binaryReader.ReadUInt32());
				if (!nodeFlags.HasFlag(ResourceFile.NodeFlags.External))
				{
					num2 += dataOffset;
				}
				resource = new Resource(fullKeyPath, identifier, new FileResourceSource(path, num2, size, nodeFlags.HasFlag(ResourceFile.NodeFlags.Compressed)));
			}
			if (!string.IsNullOrEmpty(text))
			{
				resourceNode = resourceNode.Add(text, resource);
			}
			for (uint num3 = 0U; num3 < (uint)num; num3 += 1U)
			{
				this.ScanTableEntry(resourceNode, stream, dataOffset, fullKeyPath);
			}
		}

		// Token: 0x06000029 RID: 41 RVA: 0x000027E4 File Offset: 0x000009E4
		public void Write(ResourceTree tree)
		{
			MemoryStream memoryStream = new MemoryStream();
			MemoryStream memoryStream2 = new MemoryStream();
			try
			{
				this.WriteTableEntry(tree.Head, memoryStream, memoryStream2);
				using (FileStream fileStream = new FileStream(this._path, FileMode.Create, FileAccess.Write))
				{
					BinaryWriter binaryWriter = new BinaryWriter(fileStream);
					binaryWriter.Write(ResourceFile.MagicNumber);
					binaryWriter.Write(2);
					binaryWriter.Write(memoryStream.Position);
					binaryWriter.Write(memoryStream.ToArray());
					binaryWriter.Write(memoryStream2.ToArray());
				}
			}
			catch (IOException ex)
			{
				throw new ResourceException(ex.Message, ex);
			}
			finally
			{
				memoryStream.Dispose();
				memoryStream2.Dispose();
			}
		}

		// Token: 0x0600002A RID: 42 RVA: 0x000028A8 File Offset: 0x00000AA8
		private void WriteTableEntry(ResourceTree.Node resourceNode, Stream tableStream, Stream dataStream)
		{
			BinaryWriter binaryWriter = new BinaryWriter(tableStream);
			new BinaryWriter(dataStream);
			ResourceFile.NodeFlags nodeFlags = (ResourceFile.NodeFlags)0;
			if (resourceNode.Resource != null)
			{
				ResourceType resourceType = ResourceType.FromIdentifier(resourceNode.Resource.Identifier);
				if (resourceType != null && resourceType.CompressByDefault)
				{
					nodeFlags |= ResourceFile.NodeFlags.Compressed;
				}
			}
			if (resourceNode.Children.Count > 0)
			{
				nodeFlags |= ResourceFile.NodeFlags.HasChildren;
			}
			if (resourceNode.Resource != null)
			{
				nodeFlags |= ResourceFile.NodeFlags.HasResource;
				FileResourceSource fileResourceSource = resourceNode.Resource.Source as FileResourceSource;
				if (fileResourceSource != null && string.Compare(fileResourceSource.Path, this._path, true) != 0)
				{
					nodeFlags |= ResourceFile.NodeFlags.External;
				}
				nodeFlags &= ~ResourceFile.NodeFlags.External;
			}
			binaryWriter.Write((byte)nodeFlags);
			if (nodeFlags.HasFlag(ResourceFile.NodeFlags.HasChildren))
			{
				binaryWriter.Write((short)resourceNode.Children.Count);
			}
			binaryWriter.WriteNullTerminatedString(resourceNode.Key);
			if (nodeFlags.HasFlag(ResourceFile.NodeFlags.HasResource))
			{
				binaryWriter.Write((ushort)resourceNode.Resource.Identifier);
				if (nodeFlags.HasFlag(ResourceFile.NodeFlags.External))
				{
					FileResourceSource fileResourceSource2 = resourceNode.Resource.Source as FileResourceSource;
					binaryWriter.WriteNullTerminatedString(fileResourceSource2.Path);
					binaryWriter.Write((uint)fileResourceSource2.Offset);
					binaryWriter.Write((uint)resourceNode.Resource.Source.Size);
				}
				else
				{
					binaryWriter.Write((uint)dataStream.Position);
					long num = dataStream.Position;
					using (Stream stream = nodeFlags.HasFlag(ResourceFile.NodeFlags.Compressed) ? resourceNode.Resource.Source.ReadCompressed() : resourceNode.Resource.Source.ReadUncompressed())
					{
						stream.CopyTo(dataStream);
					}
					num = dataStream.Position - num;
					binaryWriter.Write((uint)num);
				}
			}
			foreach (ResourceTree.Node resourceNode2 in resourceNode.Children)
			{
				this.WriteTableEntry(resourceNode2, tableStream, dataStream);
			}
		}

		// Token: 0x0600002B RID: 43 RVA: 0x00002AC4 File Offset: 0x00000CC4
		public static void GetResourcesFromDirectory(ResourceTree tree, string path, string currentFullKeyPath = null)
		{
			if (!string.IsNullOrEmpty(currentFullKeyPath))
			{
				if (!currentFullKeyPath.EndsWith("/"))
				{
					currentFullKeyPath += "/";
				}
			}
			else
			{
				currentFullKeyPath = string.Empty;
			}
			currentFullKeyPath += Path.GetFileName(path).ToUpper();
			string[] array = Directory.GetFiles(path);
			for (int i = 0; i < array.Length; i++)
			{
				string text = array[i];
				FileInfo fileInfo = new FileInfo(text);
				if (fileInfo.Name.Contains("."))
				{
					string text2 = fileInfo.Name.Remove(fileInfo.Name.IndexOf('.')).Replace('_', '/').ToUpper();
					string extension = fileInfo.Name.Substring(fileInfo.Name.IndexOf('.'));
					string fullKeyPath = (text2 == "/") ? currentFullKeyPath : (currentFullKeyPath + "/" + text2);
					ResourceType resourceType = ResourceType.RegisteredResourceTypes.FirstOrDefault((ResourceType x) => x.DefaultExtension == extension);
					if (resourceType != null)
					{
						Resource resource = new Resource(fullKeyPath, resourceType.Identifier, new FileResourceSource(text, 0L, fileInfo.Length, false));
						tree.GetOrAdd(fullKeyPath).Resource = resource;
					}
				}
			}
			foreach (string path2 in Directory.GetDirectories(path))
			{
				ResourceFile.GetResourcesFromDirectory(tree, path2, currentFullKeyPath);
			}
		}

		// Token: 0x0400000C RID: 12
		private static readonly char[] MagicNumberChars = new char[]
		{
			'S',
			'O',
			'R',
			'F'
		};

		// Token: 0x0400000D RID: 13
		private const int LatestSupportedVersion = 2;

		// Token: 0x0400000E RID: 14
		private readonly string _path;

		// Token: 0x02000017 RID: 23
		[Flags]
		private enum NodeFlags : byte
		{
			// Token: 0x04000055 RID: 85
			HasChildren = 2,
			// Token: 0x04000056 RID: 86
			HasResource = 4,
			// Token: 0x04000057 RID: 87
			External = 8,
			// Token: 0x04000058 RID: 88
			Compressed = 16
		}
	}
}
