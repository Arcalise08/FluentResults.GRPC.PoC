using Contracts.Models;
using System.ServiceModel;
using ProtoBuf.Grpc;
using FluentResults;

namespace Contracts;
[ServiceContract]
public interface IHomeService
{
    [OperationContract]
    Task<RPCResponse<TestClass>> SayHelloAsync(CreateTestClass request, CallContext context = default);
}