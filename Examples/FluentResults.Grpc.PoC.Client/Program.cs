// See https://aka.ms/new-console-template for more information

using Contracts;
using Grpc.Net.Client;
using ProtoBuf.Grpc.Client;
using ProtoBuf.Grpc.Configuration;

using var channel = GrpcChannel.ForAddress("https://localhost");

var client = channel.CreateGrpcService<IHomeService>();

var reply = await client.SayHelloAsync(new() { Name = "Mr", Description = "Awesomeness", Title = "Lord"});
Console.ReadKey();