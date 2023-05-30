using FluentResults;
using ProtoBuf;

namespace Contracts.Models;
[ProtoContract]
public class TooAwesomeError : Error
{
    public TooAwesomeError()
    {
        Message = "You are too awesome to perform that action";
        Metadata.Add("too cool", "For SCHOOLz");
    }
}