using Contracts;
using Contracts.Models;
using FluentResults;
using ProtoBuf.Grpc;

namespace WebApplication1.Services;


public class HomeService : RPCServices, IHomeService
{
    public async Task<RPCResponse<TestClass>> SayHelloAsync(CreateTestClass request, CallContext context = default)
    {
        if (request.Name.Equals("Mr", StringComparison.CurrentCultureIgnoreCase) && request.Title.Equals("Lord", StringComparison.CurrentCultureIgnoreCase))
        {
            var badResult = Result.Fail(new Error("Mr is too awesome").CausedBy("You not awesome"));
            return ProcessResult<TestClass>(badResult);
        }
        //get result from other service
        var result = Result.Ok(new TestClass() { Description = request.Description, Name = request.Name, Title = request.Title});
  
        return ProcessResult(result);
    }
}


