using CloudRunDotNetGRPCService;
using Grpc.Core;
using Grpc.Net.Client;
using System;
using System.Threading.Tasks;

namespace CloudRunDotNetGRPCClient
{
    class Program
    {
        // Replace this by your server's address
        private const string SERVER_ADDRESS = "https://dotnetgrpctest-eu-v4eoqzbppa-nw.a.run.app";

        static async Task Main(string[] args)
        {
            var channel = GrpcChannel.ForAddress(
                SERVER_ADDRESS + ":443",
                new GrpcChannelOptions
                {
                    Credentials = new SslCredentials()
                }
            );
            var client = new Greeter.GreeterClient(channel);

            var input = new HelloRequest { Name = "Test User" };

            try
            {
                var response = await client.SayHelloAsync(input);

                Console.WriteLine(response.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("[Error] " + e.Message);
            }

            Console.ReadLine();
        }
    }
}
