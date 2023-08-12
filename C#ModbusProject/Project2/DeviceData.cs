using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsoleApp1.Entity;

namespace ConsoleApp1.DataSource
{
    public class DeviceData
    {
        public List<Device> Devices { get; set; }

        public DeviceModel DeviceModel { get; set; }
        public DeviceData(){
        
            Devices = new List<Device>{
             
                new Device
                {

                    DeviceModelId = 1,
                    Id = 1,
                    Name = "Device 1",
                    ConnectionPointId = 1001,
                    Nad = 1
                    
                }
            };
        }
    }
}