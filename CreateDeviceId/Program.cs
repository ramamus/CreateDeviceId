using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Devices;
using Microsoft.Azure.Devices.Client.Exceptions;

namespace CreateDeviceId
{
    class Program
    {
        static RegistryManager resgistryManager;
        static string connectionString = "HostName=mtclab.azure-devices.net;SharedAccessKeyName=iothubowner;SharedAccessKey=27pCqd1J/UQmfm0RpfrvR8aXdhtSz5pQMLFylc8RHJo=";
        static void Main(string[] args)
        {
            
            resgistryManager = RegistryManager.CreateFromConnectionString(connectionString);
            AddDeviceAsync().Wait();
            Console.ReadKey();
        }

        private static async Task AddDeviceAsync()
        {
            var deviceId = "NewIoT-11-Device";
            Device device;
            try
            {
                device = await resgistryManager.AddDeviceAsync(new Device(deviceId));

            }
            catch (DeviceAlreadyExistsException ex)
            {
                device = await resgistryManager.GetDeviceAsync(deviceId);
                throw;
            }
        }
    }
}
