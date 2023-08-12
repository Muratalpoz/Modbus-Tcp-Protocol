using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsoleApp1.Entity;

namespace ConsoleApp1.DataSource
{
    public class ParameterData
    {
        public List<Parameter> Parameters { get; set; }
        public ParameterData()
        {
            Parameters = new List<Parameter>{


            new Parameter
            {
                Address = 0,
                ParameterName = "VLN1",
                Unit = (byte)Enums.Unit.V,
                ByteSize = 4,
                DataType = (byte)Enums.DataType.Uint

            },
            new Parameter
            {
                Address = 2,
                ParameterName = "VLN2",
                Unit = (byte)Enums.Unit.V,
                ByteSize = 4,
                DataType = (byte)Enums.DataType.Uint

            },
            new Parameter
            {
                Address = 4,
                ParameterName = "VLN3",
                Unit = (byte)Enums.Unit.V,
                ByteSize = 4,
                DataType = (byte)Enums.DataType.Uint
            },
            new Parameter
            {
                Address = 6,
                ParameterName = "rev",
                Unit = (byte)Enums.Unit.V,
                ByteSize = 4,
                DataType = (byte)Enums.DataType.Uint
            },
            new Parameter
            {
                Address = 8,
                ParameterName = "VLL1",
                Unit = (byte)Enums.Unit.V,
                ByteSize = 4,
                DataType = (byte)Enums.DataType.Uint
            },
            new Parameter
            {
                Address = 10,
                ParameterName = "VLL2",
                Unit = (byte)Enums.Unit.V,
                ByteSize = 4,
                DataType = (byte)Enums.DataType.Uint
            },
            new Parameter
            {
                Address = 12,
                ParameterName = "VLL3",
                Unit = (byte)Enums.Unit.V,
                ByteSize = 4,
                DataType = (byte)Enums.DataType.Uint
            },
            new Parameter
            {
                Address = 14,
                ParameterName = "ILN1",
                Unit = (byte)Enums.Unit.A,
                ByteSize = 4,
                DataType = (byte)Enums.DataType.Uint

            },
            new Parameter
            {
                Address = 16,
                ParameterName = "ILN2",
                Unit = (byte)Enums.Unit.A,
                ByteSize = 4,
                DataType = (byte)Enums.DataType.Uint

            },
            new Parameter
            {
                Address = 18,
                ParameterName = "ILN3",
                Unit = (byte)Enums.Unit.A,
                ByteSize = 4,
                DataType = (byte)Enums.DataType.Uint
                }
            };
        }
    }
}