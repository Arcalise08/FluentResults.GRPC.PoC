using ProtoBuf;

namespace Grpc.Contracts.ProposedMetadataChanges;
[ProtoContract]
public abstract class MetadataObject
{
    //Any metadata you want to add needs to have its own class and inherit from this class
    //be sure to include [ProtoContract] and [ProtoMember] attributes
}