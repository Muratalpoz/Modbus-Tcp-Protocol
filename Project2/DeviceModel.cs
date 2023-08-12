using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class DeviceModel : IEntityBase
    {
        /// <summary>
        /// modelinin Id'si
        /// </summary>
        public int Id { get; set;}
        

        /// <summary>
        /// modelinin adı
        /// </summary>
        public string Name { get; set;}

        public bool Save()
        {
            return false;
        }
    }
}