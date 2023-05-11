using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Практическая_5_задание_3
{
    interface IComputer
    {
        string Name { get; set; }
        decimal Price { get; set; }

        Processor Processor { get; set; }
        VideoCard VideoCard { get; set; }
        Cooler Cooler { get; set; }
        Motherboard Motherboard { get; set; }
    }
}
