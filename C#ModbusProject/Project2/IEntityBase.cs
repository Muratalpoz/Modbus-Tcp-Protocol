using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public interface IEntityBase
    {
        int Id {get;set;}

        string Name {get;set;}


        bool Save();

    }
}