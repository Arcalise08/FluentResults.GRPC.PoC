using ProtoBuf;

namespace Grpc.Contracts.ProposedMetadataChanges.ExampleMetadata;
[ProtoContract]
public class StringMetadata : MetadataObject
{
    [ProtoMember(1)]
    public string Value { get; set; }
}
