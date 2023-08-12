using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsoleApp1.Entity;

namespace ConsoleApp1.DataSource
{
    public class ConnectionPointData
    {
        public List<ConnectionPoint> ConnectionPoints { get; set; }

        public ConnectionPointData(){
            
            ConnectionPoints =  new List<ConnectionPoint>{
                
                new ConnectionPoint
                {
                    IpAddress ="192.168.4.153",
                    PortNumber = 502,
                    Name = "ConnectionPoint 1",
                    Id = 1001 
                }
            };
        }
    }
}