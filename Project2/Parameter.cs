using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp1.Entity
{
    public class Parameter
    {
        /// <summary>
    /// parametre adresi
    /// </summary>
        public int Address { get; set; }

    /// <summary>
    ///parametre adı
    /// </summary>
        public required string ParameterName { get; set; }

    /// <summary>
    /// parametre birimi
    /// </summary>
        public byte Unit{ get; set;}

    /// <summary>
    /// parametre byte uzunluğu
    /// </summary>
        public int ByteSize{ get; set; }

    /// <summary>
    /// parametre data tipi
    /// </summary>
        public byte DataType{ get; set; }


    /// <summary>
    /// Bu parametrenin okunan değeri
    /// </summary>
        public double? Value{ get; set; }


    }
}