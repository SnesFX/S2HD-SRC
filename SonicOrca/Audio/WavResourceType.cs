using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using SonicOrca.Resources;

namespace SonicOrca.Audio
{
	// Token: 0x020001AC RID: 428
	public class WavResourceType : ResourceType
	{
		// Token: 0x170004F0 RID: 1264
		// (get) Token: 0x06001266 RID: 4710 RVA: 0x0004808B File Offset: 0x0004628B
		public override string Name
		{
			get
			{
				return "wav";
			}
		}

		// Token: 0x170004F1 RID: 1265
		// (get) Token: 0x06001267 RID: 4711 RVA: 0x00048092 File Offset: 0x00046292
		public override string DefaultExtension
		{
			get
			{
				return ".wav";
			}
		}

		// Token: 0x170004F2 RID: 1266
		// (get) Token: 0x06001268 RID: 4712 RVA: 0x0000225B File Offset: 0x0000045B
		public override bool CompressByDefault
		{
			get
			{
				return false;
			}
		}

		// Token: 0x06001269 RID: 4713 RVA: 0x00048099 File Offset: 0x00046299
		public WavResourceType() : base(ResourceTypeIdentifier.SampleWAV)
		{
		}

		// Token: 0x0600126A RID: 4714 RVA: 0x000480A8 File Offset: 0x000462A8
		public override async Task<ILoadedResource> LoadAsync(ResourceLoadArgs e, CancellationToken ct = default(CancellationToken))
		{
			return await Task.Run<ILoadedResource>(delegate()
			{
				BinaryReader binaryReader = new BinaryReader(e.InputStream);
				if (binaryReader.ReadInt32() != 1179011410)
				{
					throw new ResourceException("Invalid wav signature.");
				}
				binaryReader.ReadInt32();
				if (binaryReader.ReadInt32() != 1163280727)
				{
					throw new ResourceException("Invalid wav signature.");
				}
				if (binaryReader.ReadInt32() != 544501094)
				{
					throw new ResourceException("Invalid wav signature.");
				}
				binaryReader.ReadInt32();
				if (binaryReader.ReadInt16() != 1)
				{
					throw new ResourceException("Non PCM wav signature.");
				}
				short channels = binaryReader.ReadInt16();
				int sampleRate = binaryReader.ReadInt32();
				binaryReader.ReadInt32();
				binaryReader.ReadInt16();
				short bitsPerSample = binaryReader.ReadInt16();
				if (binaryReader.ReadInt32() != 1635017060)
				{
					throw new ResourceException("Invalid wav format.");
				}
				int count = binaryReader.ReadInt32();
				return new Sample(binaryReader.ReadBytes(count), (int)bitsPerSample, sampleRate, (int)channels)
				{
					Resource = e.Resource
				};
			});
		}
	}
}
