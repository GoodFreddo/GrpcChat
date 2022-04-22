using Grpc.Core;
using System;
using GrpcChatContract;

namespace GrpcChatServer
{
    class GrpcChatImplimentation : GrpcChat.GrpcChatBase
    {

    }
    class Program
    {
        const int Port = 12345;
        static void Main(string[] args)
        {
            Server server = new Server
            {
                Services = { GrpcChat.BindService(new GrpcChatImplimentation())},
                Ports = { new ServerPort("localhost", Port, ServerCredentials.Insecure) }
            };
            server.Start();

            Console.WriteLine("Chat server listening on port " + Port);
            Console.WriteLine("Press any key to stop the server...");
            Console.ReadKey();

            server.ShutdownAsync().Wait();
        }
    }
}
