using System;
using System.Net.Http;
using System.Threading.Tasks;
using gRPC_si_EF;
using Grpc.Net.Client;

namespace GrpcClient
{
	class Program
	{
		static async Task Main(string[] args)
		{
			
			using var channel = GrpcChannel.ForAddress("https://localhost:5001");
			var client = new Greeter.GreeterClient(channel);
			var reply = await client.SayHelloAsync(
			new HelloRequest { Name = "GreeterClient" });
			Console.WriteLine("Greeting: " + reply.Message);
			Console.WriteLine("Press any key to exit...");
			Console.ReadKey();
		}
	}
}
