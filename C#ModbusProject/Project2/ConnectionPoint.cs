using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp1.Entity
{
    public class ConnectionPoint : IEntityBase
    {

        /// <summary>
        /// Bağlantı noktası Ip adresi
        /// </summary>
        public required string IpAddress { get; set; }


        /// <summary>
        /// Port Numarası
        /// </summary>
        public int PortNumber { get; set; }
     

        public int Id { get; set; }
        public string Name { get; set; }

        public bool Save()
        {
           // throw new NotImplementedException();
           return false;
        }
    } 
}