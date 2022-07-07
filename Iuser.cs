using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtmSystem
{
    interface IUser
    {
        long CardNum { get; set; }
        int Count { get; set; }
        long CardPin { get; set; }
        string CardName { get; set; }
        double CardBalance { get; set; }


    }
}
