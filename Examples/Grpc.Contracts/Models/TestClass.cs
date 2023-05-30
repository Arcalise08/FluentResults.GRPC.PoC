using ProtoBuf;
using System.Runtime.Serialization;

namespace Contracts.Models;
[ProtoContract]
public class TestClass
{
    [ProtoMember(1)]
    public string Name { get; set; }
    [ProtoMember(2)]
    public string Description { get; set; }
    [ProtoMember(3)]
    public string Title { get; set; }
}

[ProtoContract]
public class CreateTestClass
{
    [ProtoMember(1)]
    public string Name { get; set; }
    [ProtoMember(2)]
    public string Description { get; set; }
    [ProtoMember(3)]
    public string Title { get; set; }
}