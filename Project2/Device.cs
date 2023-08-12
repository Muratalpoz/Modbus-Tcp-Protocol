using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp1.Entity
{
    public class Device : IEntityBase
    {
        internal int deviceModel;

        /// <summary>
        /// Cihaz ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Cihaz adı
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// Bağlantı Noktası Id
        /// </summary>
        public int ConnectionPointId { get; set; }


        /// <summary>
        /// Cihaz Network Adresi
        /// </summary>
        public int Nad { get; set;}
        
        /// <summary>
        /// bu cihaz hangi modele ait
        /// </summary>
        public int DeviceModelId { get; set;}


        public bool Save()
        {
            return false;
        }
    }
}