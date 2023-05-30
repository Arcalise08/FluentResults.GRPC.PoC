using FluentResults;
using Grpc.Contracts.ProposedMetadataChanges;
using ProtoBuf;

namespace Contracts;

[ProtoContract]
public class RPCError
{

    [ProtoMember(1)]
    public string Message { get; set; }
    [ProtoMember(2)]
    public Dictionary<string, MetadataObject> Metadata { get; set; }
    [ProtoMember(3)]
    public List<RPCError> Reasons { get; set; }
}

[ProtoContract]
public class RPCResponse<TResult>
{
    [ProtoMember(1)]
    public bool IsSuccessful { get; set; }
    [ProtoMember(2)]
    public List<RPCError>? Errors { get; set; }
    [ProtoMember(3)]
    public TResult? Data { get; set; }
}

public abstract class RPCServices
{
    public RPCResponse<TResult> ProcessResult<TResult>(Result<TResult> test)
    {
        if (test.IsSuccess)
        {
            return new RPCResponse<TResult>()
            {
                IsSuccessful = true,
                Data = test.ValueOrDefault,
                Errors = null
            };
        }
        else
        {
            var result = new RPCResponse<TResult>()
            {
                IsSuccessful = false,
                Data = default,
                Errors = ProcessErrors(test.Errors)
            };
            return result;
        }
    }

    private List<RPCError> ProcessErrors(List<IError> errors)
    {
        var list = new List<RPCError>();
        foreach (var error in errors)
        {
            var rpcError = new RPCError();
            if (error.Reasons.Any())
                rpcError.Reasons = ProcessErrors(error.Reasons);
            rpcError.Message = error.Message;
            if (error.Metadata.Any(x => x.Value is not MetadataObject))
            {
                throw new Exception("Invalid metadata entered. Please use MetadataEntry class");
            }
            rpcError.Metadata = error.Metadata.ToDictionary(x => x.Key, x => (MetadataObject)x.Value);
            list.Add(rpcError);
        }
        return list;
    }
}


