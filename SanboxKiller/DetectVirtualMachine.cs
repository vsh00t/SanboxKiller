using System;
using System.Management;

namespace SandboxKiller
{ 
public static class DetectVirtualMachine
{
    public static bool IsRunningInVirtualMachine()
    {
        string[] virtualMachineManufacturers = { "VMware, Inc.", "Oracle Corporation", "QEMU" };

        using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_ComputerSystem"))
        {
            foreach (ManagementObject queryObj in searcher.Get())
            {
                string manufacturer = queryObj["Manufacturer"].ToString();
                foreach (string vmManufacturer in virtualMachineManufacturers)
                {
                    if (manufacturer.Contains(vmManufacturer))
                    {
                        return true;
                    }
                }
            }
        }

        return false;
    }

}
}
