using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class DeviceModelData 
    {
        public List<DeviceModel> DeviceModels { get; set;}

        public DeviceModelData(){

            DeviceModels = new List<DeviceModel>{

            new DeviceModel
            {
                Id = 1,
                Name = "MPR"
            },

            new DeviceModel
            {
                Id = 2,
                Name = "RG"
            }
            
            };
        }
    }
}
