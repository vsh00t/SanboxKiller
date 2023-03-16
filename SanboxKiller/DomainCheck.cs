using System;
using System.DirectoryServices.ActiveDirectory;

namespace SandboxKiller

{
    public static class DomainCheck

    {
        public static bool IsRunningInDomain()
        {
            try
            {
                Domain domain = Domain.GetComputerDomain();
                //Console.WriteLine($"Este equipo pertenece al dominio: {domain.Name}");
                return true;
            }
            catch (ActiveDirectoryObjectNotFoundException)
            {
                //Console.WriteLine("Este equipo no está unido a un dominio.");
                // Aquí podrías ajustar el comportamiento del programa en función de si está en un dominio o no
                return false;
            }
        }
    }
}

