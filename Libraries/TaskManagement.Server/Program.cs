using System;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting;
using TaskManagement.Domain.Services;

namespace TaskManagement.Server
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TcpChannel serverChannel = new TcpChannel(8085);
            ChannelServices.RegisterChannel(serverChannel);
            RemotingConfiguration.RegisterWellKnownServiceType(typeof
                           (RemoteAdd), "RemoteAdd", WellKnownObjectMode.Singleton);
            Console.Write("Sever is  Ready........");
            Console.Read();
        }
    }
}
